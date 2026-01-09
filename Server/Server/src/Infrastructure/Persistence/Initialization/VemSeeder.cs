using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Server.Domain.Lbys;
using Server.Infrastructure.Persistence.Context;

namespace Server.Infrastructure.Persistence.Initialization;

internal class VemSeeder : ICustomSeeder
{
    private readonly ApplicationDbContext _db;
    private readonly ILogger<VemSeeder> _logger;
    private readonly Random _random = new(42); // Seed for reproducibility

    // Admin kullanıcı kodu - tüm seed verilerinde EKLEYEN_KULLANICI_KODU olarak kullanılır
    private const string AdminKullaniciKodu = "KLN-ADMIN";

    public VemSeeder(ApplicationDbContext db, ILogger<VemSeeder> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Checking VEM data and seeding missing tables...");

        // ÖNCE Admin kullanıcısını seed et - diğer tüm tablolar için gerekli
        await SeedAdminUserAsync(cancellationToken);

        // Her tablo için ayrı kontrol yapılıyor, boş olanlar seed ediliyor
        await SeedReferansKodlarAsync(cancellationToken);
        await SeedKurumAsync(cancellationToken);
        await SeedBirimlerAsync(cancellationToken);
        await SeedBinaOdaYatakAsync(cancellationToken);
        await SeedCihazlarAsync(cancellationToken);
        await SeedDepolarAsync(cancellationToken);
        await SeedStokKartlarAsync(cancellationToken);
        await SeedPersonelAsync(cancellationToken);
        await SeedKullanicilarAsync(cancellationToken);
        await SeedHizmetlerAsync(cancellationToken);
        await SeedTetkiklerAsync(cancellationToken);
        await SeedTetkikParametrelerAsync(cancellationToken);
        await SeedFirmalarAsync(cancellationToken);
        await SeedHastalarAsync(cancellationToken);
        await EnsureIcdCodesExistAsync(cancellationToken); // ICD kodlarını ekle
        await SeedBasvurularAsync(cancellationToken);

        // Ek tablolar
        await SeedEkTabloAsync(cancellationToken);

        // Level 1 tabloları
        await SeedLevel1TablesAsync(cancellationToken);
        // Level 2 - STOK_FIS seeding
        await SeedLevel2TablesAsync(cancellationToken);

        // Level 3 - Tüm ilişkili tablolar (141 tablo için tam seed)
        // Basitleştirilmiş Level 3 seeder
        await SeedLevel3SimplifiedAsync(cancellationToken);

        _logger.LogInformation("VEM data seeding completed!");
    }

    /// <summary>
    /// Admin kullanıcısını en başta seed eder - diğer tüm tablolar için EKLEYEN_KULLANICI_KODU gerektiğinden
    /// </summary>
    private async Task SeedAdminUserAsync(CancellationToken ct)
    {
        var exists = await _db.Set<KULLANICI>().AnyAsync(k => k.KULLANICI_KODU == AdminKullaniciKodu, ct);
        if (exists) return;

        _logger.LogInformation("Seeding admin user (KLN-ADMIN)...");
        var adminUser = new KULLANICI
        {
            KULLANICI_KODU = AdminKullaniciKodu,
            KULLANICI_ADI = "admin",
            AD = "Admin",
            SOYADI = "User",
            AKTIFLIK_BILGISI = "1",
            KAYIT_ZAMANI = DateTime.Now
        };

        await _db.Set<KULLANICI>().AddAsync(adminUser, ct);
        await _db.SaveChangesAsync(ct);
    }

    #region Referans Kodlar

    private async Task EnsureIcdCodesExistAsync(CancellationToken ct)
    {
        // ICD-10 kodları zaten var mı kontrol et
        var icdCodes = new[] { "J06.9", "K29.7", "I10", "E11.9", "J45.9", "M54.5", "R51", "N39.0", "K80.2", "J18.9" };
        var existingCodes = await _db.Set<REFERANS_KODLAR>()
            .Where(r => icdCodes.Contains(r.REFERANS_KODU))
            .Select(r => r.REFERANS_KODU)
            .ToListAsync(ct);

        var missingCodes = icdCodes.Except(existingCodes).ToList();

        var codesToAdd = new List<REFERANS_KODLAR>();

        if (missingCodes.Any())
        {
            _logger.LogInformation("Adding missing ICD-10 codes to REFERANS_KODLAR...");
            var icdData = new Dictionary<string, string>
            {
                ["J06.9"] = "Akut üst solunum yolu enfeksiyonu, tanımlanmamış",
                ["K29.7"] = "Gastrit, tanımlanmamış",
                ["I10"] = "Esansiyel (primer) hipertansiyon",
                ["E11.9"] = "Tip 2 diabetes mellitus, komplikasyonsuz",
                ["J45.9"] = "Astım, tanımlanmamış",
                ["M54.5"] = "Bel ağrısı",
                ["R51"] = "Baş ağrısı",
                ["N39.0"] = "İdrar yolu enfeksiyonu, yeri belirtilmemiş",
                ["K80.2"] = "Safra kesesi taşı, kolesistitli",
                ["J18.9"] = "Pnömoni, tanımlanmamış"
            };

            codesToAdd.AddRange(missingCodes.Select(code => CreateReferans(code, "ICD10_TANI", icdData[code], code.Replace(".", ""), code.Replace(".", ""), code.Replace(".", ""), code.Replace(".", ""))));
        }

        // TANI_TURU referans kodları
        var taniTuruCodes = new[] { "ANA", "EK", "SEKONDER" };
        var existingTaniTuru = await _db.Set<REFERANS_KODLAR>()
            .Where(r => taniTuruCodes.Contains(r.REFERANS_KODU))
            .Select(r => r.REFERANS_KODU)
            .ToListAsync(ct);

        var missingTaniTuru = taniTuruCodes.Except(existingTaniTuru).ToList();
        if (missingTaniTuru.Any())
        {
            _logger.LogInformation("Adding missing TANI_TURU codes to REFERANS_KODLAR...");
            var taniTuruData = new Dictionary<string, string>
            {
                ["ANA"] = "Ana Tanı",
                ["EK"] = "Ek Tanı",
                ["SEKONDER"] = "Sekonder Tanı"
            };
            codesToAdd.AddRange(missingTaniTuru.Select(code => CreateReferans(code, "TANI_TURU", taniTuruData[code], code, code, code, code)));
        }

        // ILAC_KULLANIM_YOLU referans kodları (RECETE_ILAC için)
        var kullanımYoluCodes = new[] { "AG", "IM", "IV", "SC", "SL", "IH", "TOP", "RKT" };
        var existingKullanımYolu = await _db.Set<REFERANS_KODLAR>()
            .Where(r => kullanımYoluCodes.Contains(r.REFERANS_KODU))
            .Select(r => r.REFERANS_KODU)
            .ToListAsync(ct);

        var missingKullanımYolu = kullanımYoluCodes.Except(existingKullanımYolu).ToList();
        if (missingKullanımYolu.Any())
        {
            _logger.LogInformation("Adding missing ILAC_KULLANIM_YOLU codes...");
            var kullanımYoluData = new Dictionary<string, string>
            {
                ["AG"] = "Ağızdan",
                ["IM"] = "İntramüsküler",
                ["IV"] = "İntravenöz",
                ["SC"] = "Subkutan",
                ["SL"] = "Sublingual",
                ["IH"] = "İnhalasyon",
                ["TOP"] = "Topikal",
                ["RKT"] = "Rektal"
            };
            codesToAdd.AddRange(missingKullanımYolu.Select(code => CreateReferans(code, "ILAC_KULLANIM_YOLU", kullanımYoluData[code], code, code, code, code)));
        }

        // DOZ_PERIYOT referans kodları
        var dozPeriyotCodes = new[] { "GUN", "SAAT", "HAFTA" };
        var existingDozPeriyot = await _db.Set<REFERANS_KODLAR>()
            .Where(r => dozPeriyotCodes.Contains(r.REFERANS_KODU))
            .Select(r => r.REFERANS_KODU)
            .ToListAsync(ct);

        var missingDozPeriyot = dozPeriyotCodes.Except(existingDozPeriyot).ToList();
        if (missingDozPeriyot.Any())
        {
            _logger.LogInformation("Adding missing DOZ_PERIYOT codes...");
            var dozPeriyotData = new Dictionary<string, string>
            {
                ["GUN"] = "Günde",
                ["SAAT"] = "Saatte",
                ["HAFTA"] = "Haftada"
            };
            codesToAdd.AddRange(missingDozPeriyot.Select(code => CreateReferans(code, "DOZ_PERIYOT", dozPeriyotData[code], code, code, code, code)));
        }

        // DOZ_BIRIM referans kodları
        var dozBirimCodes = new[] { "ADET", "MG", "ML", "CC" };
        var existingDozBirim = await _db.Set<REFERANS_KODLAR>()
            .Where(r => dozBirimCodes.Contains(r.REFERANS_KODU))
            .Select(r => r.REFERANS_KODU)
            .ToListAsync(ct);

        var missingDozBirim = dozBirimCodes.Except(existingDozBirim).ToList();
        if (missingDozBirim.Any())
        {
            _logger.LogInformation("Adding missing DOZ_BIRIM codes...");
            var dozBirimData = new Dictionary<string, string>
            {
                ["ADET"] = "Adet",
                ["MG"] = "Miligram",
                ["ML"] = "Mililitre",
                ["CC"] = "Santimetreküp"
            };
            codesToAdd.AddRange(missingDozBirim.Select(code => CreateReferans(code, "DOZ_BIRIM", dozBirimData[code], code, code, code, code)));
        }

        // NUMUNE_TURU referans kodları (TETKIK_NUMUNE için)
        var numuneTuruCodes = new[] { "KAN", "IDRAR", "GAITA", "BOS", "BALGAM" };
        var existingNumuneTuru = await _db.Set<REFERANS_KODLAR>()
            .Where(r => numuneTuruCodes.Contains(r.REFERANS_KODU))
            .Select(r => r.REFERANS_KODU)
            .ToListAsync(ct);

        var missingNumuneTuru = numuneTuruCodes.Except(existingNumuneTuru).ToList();
        if (missingNumuneTuru.Any())
        {
            _logger.LogInformation("Adding missing NUMUNE_TURU codes...");
            var numuneTuruData = new Dictionary<string, string>
            {
                ["KAN"] = "Kan",
                ["IDRAR"] = "İdrar",
                ["GAITA"] = "Gaita",
                ["BOS"] = "Beyin Omurilik Sıvısı",
                ["BALGAM"] = "Balgam"
            };
            codesToAdd.AddRange(missingNumuneTuru.Select(code => CreateReferans(code, "NUMUNE_TURU", numuneTuruData[code], code, code, code, code)));
        }

        // AMELIYAT_ISLEM için gerekli referans kodları
        // KESI_ORANI
        var kesiOraniCodes = new[] { "KESI_ORANI_100", "KESI_ORANI_50", "KESI_ORANI_25" };
        var existingKesiOrani = await _db.Set<REFERANS_KODLAR>()
            .Where(r => kesiOraniCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingKesiOrani = kesiOraniCodes.Except(existingKesiOrani).ToList();
        if (missingKesiOrani.Any())
        {
            var kesiOraniData = new Dictionary<string, string>
            {
                ["KESI_ORANI_100"] = "%100 Kesi Oranı",
                ["KESI_ORANI_50"] = "%50 Kesi Oranı",
                ["KESI_ORANI_25"] = "%25 Kesi Oranı"
            };
            codesToAdd.AddRange(missingKesiOrani.Select(code => CreateReferans(code, "KESI_ORANI", kesiOraniData[code], code, code, code, code)));
        }

        // KESI_SEANS_BILGISI
        var kesiSeansCodes = new[] { "BIRINCI_SEANS", "IKINCI_SEANS", "UCUNCU_SEANS" };
        var existingKesiSeans = await _db.Set<REFERANS_KODLAR>()
            .Where(r => kesiSeansCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingKesiSeans = kesiSeansCodes.Except(existingKesiSeans).ToList();
        if (missingKesiSeans.Any())
        {
            var kesiSeansData = new Dictionary<string, string>
            {
                ["BIRINCI_SEANS"] = "Birinci Seans",
                ["IKINCI_SEANS"] = "İkinci Seans",
                ["UCUNCU_SEANS"] = "Üçüncü Seans"
            };
            codesToAdd.AddRange(missingKesiSeans.Select(code => CreateReferans(code, "KESI_SEANS_BILGISI", kesiSeansData[code], code, code, code, code)));
        }

        // TARAF_BILGISI
        var tarafCodes = new[] { "SAG", "SOL", "BILATERAL", "YOK" };
        var existingTaraf = await _db.Set<REFERANS_KODLAR>()
            .Where(r => tarafCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingTaraf = tarafCodes.Except(existingTaraf).ToList();
        if (missingTaraf.Any())
        {
            var tarafData = new Dictionary<string, string>
            {
                ["SAG"] = "Sağ Taraf",
                ["SOL"] = "Sol Taraf",
                ["BILATERAL"] = "Her İki Taraf",
                ["YOK"] = "Taraf Bilgisi Yok"
            };
            codesToAdd.AddRange(missingTaraf.Select(code => CreateReferans(code, "TARAF_BILGISI", tarafData[code], code, code, code, code)));
        }

        // ASA_SKORU
        var asaCodes = new[] { "ASA_1", "ASA_2", "ASA_3", "ASA_4", "ASA_5" };
        var existingAsa = await _db.Set<REFERANS_KODLAR>()
            .Where(r => asaCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingAsa = asaCodes.Except(existingAsa).ToList();
        if (missingAsa.Any())
        {
            var asaData = new Dictionary<string, string>
            {
                ["ASA_1"] = "ASA I - Sağlıklı Hasta",
                ["ASA_2"] = "ASA II - Hafif Sistemik Hastalık",
                ["ASA_3"] = "ASA III - Ciddi Sistemik Hastalık",
                ["ASA_4"] = "ASA IV - Hayatı Tehdit Eden Sistemik Hastalık",
                ["ASA_5"] = "ASA V - Ameliyat Olmadan Yaşaması Beklenmeyen Hasta"
            };
            codesToAdd.AddRange(missingAsa.Select(code => CreateReferans(code, "ASA_SKORU", asaData[code], code, code, code, code)));
        }

        // EUROSCORE
        var euroCodes = new[] { "EURO_LOW", "EURO_MED", "EURO_HIGH" };
        var existingEuro = await _db.Set<REFERANS_KODLAR>()
            .Where(r => euroCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingEuro = euroCodes.Except(existingEuro).ToList();
        if (missingEuro.Any())
        {
            var euroData = new Dictionary<string, string>
            {
                ["EURO_LOW"] = "Düşük Risk (<%1)",
                ["EURO_MED"] = "Orta Risk (%1-5)",
                ["EURO_HIGH"] = "Yüksek Risk (>%5)"
            };
            codesToAdd.AddRange(missingEuro.Select(code => CreateReferans(code, "EUROSCORE", euroData[code], code, code, code, code)));
        }

        // YARA_SINIFI
        var yaraCodes = new[] { "YARA_1", "YARA_2", "YARA_3", "YARA_4" };
        var existingYara = await _db.Set<REFERANS_KODLAR>()
            .Where(r => yaraCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingYara = yaraCodes.Except(existingYara).ToList();
        if (missingYara.Any())
        {
            var yaraData = new Dictionary<string, string>
            {
                ["YARA_1"] = "Temiz Yara",
                ["YARA_2"] = "Temiz-Kontamine Yara",
                ["YARA_3"] = "Kontamine Yara",
                ["YARA_4"] = "Kirli-Enfekte Yara"
            };
            codesToAdd.AddRange(missingYara.Select(code => CreateReferans(code, "YARA_SINIFI", yaraData[code], code, code, code, code)));
        }

        // KURUL için RAPOR_TURU
        var raporTuruCodes = new[] { "HEYET", "TEK_HEKIM", "ISCI_SAGLIGI" };
        var existingRaporTuru = await _db.Set<REFERANS_KODLAR>()
            .Where(r => raporTuruCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingRaporTuru = raporTuruCodes.Except(existingRaporTuru).ToList();
        if (missingRaporTuru.Any())
        {
            var raporTuruData = new Dictionary<string, string>
            {
                ["HEYET"] = "Sağlık Kurulu (Heyet) Raporu",
                ["TEK_HEKIM"] = "Tek Hekim Raporu",
                ["ISCI_SAGLIGI"] = "İşçi Sağlığı Raporu"
            };
            codesToAdd.AddRange(missingRaporTuru.Select(code => CreateReferans(code, "RAPOR_TURU", raporTuruData[code], code, code, code, code)));
        }

        // MEDULA_RAPOR_TURU
        var medulaRaporCodes = new[] { "MRT_1", "MRT_2", "MRT_3", "MRT_4" };
        var existingMedulaRapor = await _db.Set<REFERANS_KODLAR>()
            .Where(r => medulaRaporCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingMedulaRapor = medulaRaporCodes.Except(existingMedulaRapor).ToList();
        if (missingMedulaRapor.Any())
        {
            var medulaRaporData = new Dictionary<string, string>
            {
                ["MRT_1"] = "Normal Rapor",
                ["MRT_2"] = "İş Göremezlik Raporu",
                ["MRT_3"] = "Engellilik Raporu",
                ["MRT_4"] = "Askerlik Raporu"
            };
            codesToAdd.AddRange(missingMedulaRapor.Select(code => CreateReferans(code, "MEDULA_RAPOR_TURU", medulaRaporData[code], code, code, code, code)));
        }

        // MEDULA_ALT_RAPOR_TURU
        var medulaAltCodes = new[] { "MART_1", "MART_2", "MART_3" };
        var existingMedulaAlt = await _db.Set<REFERANS_KODLAR>()
            .Where(r => medulaAltCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingMedulaAlt = medulaAltCodes.Except(existingMedulaAlt).ToList();
        if (missingMedulaAlt.Any())
        {
            var medulaAltData = new Dictionary<string, string>
            {
                ["MART_1"] = "Ayaktan Tedavi",
                ["MART_2"] = "Yatan Hasta",
                ["MART_3"] = "Acil Durum"
            };
            codesToAdd.AddRange(missingMedulaAlt.Select(code => CreateReferans(code, "MEDULA_ALT_RAPOR_TURU", medulaAltData[code], code, code, code, code)));
        }

        // AMELIYAT_PERSONEL_GOREV
        var personelGorevCodes = new[] { "CERRAH", "HEMSIRE", "ANESTEZIST", "ASISTAN" };
        var existingPersonelGorev = await _db.Set<REFERANS_KODLAR>()
            .Where(r => personelGorevCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingPersonelGorev = personelGorevCodes.Except(existingPersonelGorev).ToList();
        if (missingPersonelGorev.Any())
        {
            var personelGorevData = new Dictionary<string, string>
            {
                ["CERRAH"] = "Cerrah",
                ["HEMSIRE"] = "Hemşire",
                ["ANESTEZIST"] = "Anestezist",
                ["ASISTAN"] = "Asistan"
            };
            codesToAdd.AddRange(missingPersonelGorev.Select(code => CreateReferans(code, "AMELIYAT_PERSONEL_GOREV", personelGorevData[code], code, code, code, code)));
        }

        // STOK_ISTEK_DURUMU
        var stokIstekDurumuCodes = new[] { "BEKLEMEDE", "ONAYLANDI", "TAMAMLANDI", "IPTAL" };
        var existingStokIstekDurumu = await _db.Set<REFERANS_KODLAR>()
            .Where(r => stokIstekDurumuCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingStokIstekDurumu = stokIstekDurumuCodes.Except(existingStokIstekDurumu).ToList();
        if (missingStokIstekDurumu.Any())
        {
            var stokIstekDurumuData = new Dictionary<string, string>
            {
                ["BEKLEMEDE"] = "Beklemede",
                ["ONAYLANDI"] = "Onaylandı",
                ["TAMAMLANDI"] = "Tamamlandı",
                ["IPTAL"] = "İptal Edildi"
            };
            codesToAdd.AddRange(missingStokIstekDurumu.Select(code => CreateReferans(code, "STOK_ISTEK_DURUMU", stokIstekDurumuData[code], code, code, code, code)));
        }

        // GIZLILIK_NEDENI referans kodları (HASTA_GIZLILIK için)
        var gizlilikNedeniCodes = new[] { "MAHKEME_KARARI", "HASTA_TALEBI", "VIP_HASTA", "GUVENDE_SAKLI", "DIGER" };
        var existingGizlilikNedeni = await _db.Set<REFERANS_KODLAR>()
            .Where(r => gizlilikNedeniCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingGizlilikNedeni = gizlilikNedeniCodes.Except(existingGizlilikNedeni).ToList();
        if (missingGizlilikNedeni.Any())
        {
            var gizlilikNedeniData = new Dictionary<string, string>
            {
                ["MAHKEME_KARARI"] = "Mahkeme Kararı",
                ["HASTA_TALEBI"] = "Hasta Talebi",
                ["VIP_HASTA"] = "VIP Hasta",
                ["GUVENDE_SAKLI"] = "Güvende Saklı",
                ["DIGER"] = "Diğer"
            };
            codesToAdd.AddRange(missingGizlilikNedeni.Select(code => CreateReferans(code, "GIZLILIK_NEDENI", gizlilikNedeniData[code], code, code, code, code)));
        }

        // GIZLILIK_TURU referans kodları (HASTA_GIZLILIK için)
        var gizlilikTuruCodes = new[] { "TAM", "KISMI", "SINIRLI" };
        var existingGizlilikTuru = await _db.Set<REFERANS_KODLAR>()
            .Where(r => gizlilikTuruCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingGizlilikTuru = gizlilikTuruCodes.Except(existingGizlilikTuru).ToList();
        if (missingGizlilikTuru.Any())
        {
            var gizlilikTuruData = new Dictionary<string, string>
            {
                ["TAM"] = "Tam Gizlilik",
                ["KISMI"] = "Kısmi Gizlilik",
                ["SINIRLI"] = "Sınırlı Gizlilik"
            };
            codesToAdd.AddRange(missingGizlilikTuru.Select(code => CreateReferans(code, "GIZLILIK_TURU", gizlilikTuruData[code], code, code, code, code)));
        }

        // HASTA_MESAJLARI_TURU referans kodları (DOKTOR_MESAJI için)
        var hastaMesajTuruCodes = new[] { "BILGI", "UYARI", "HATIRLATMA", "KONSULTASYON", "ACIL" };
        var existingHastaMesajTuru = await _db.Set<REFERANS_KODLAR>()
            .Where(r => hastaMesajTuruCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingHastaMesajTuru = hastaMesajTuruCodes.Except(existingHastaMesajTuru).ToList();
        if (missingHastaMesajTuru.Any())
        {
            var hastaMesajTuruData = new Dictionary<string, string>
            {
                ["BILGI"] = "Bilgilendirme",
                ["UYARI"] = "Uyarı",
                ["HATIRLATMA"] = "Hatırlatma",
                ["KONSULTASYON"] = "Konsültasyon",
                ["ACIL"] = "Acil Durum"
            };
            codesToAdd.AddRange(missingHastaMesajTuru.Select(code => CreateReferans(code, "HASTA_MESAJLARI_TURU", hastaMesajTuruData[code], code, code, code, code)));
        }

        // DIYABET_EGITIMI referans kodları (DIYABET için)
        var diyabetEgitimiCodes = new[] { "VERILDI", "VERILMEDI", "REDDETTI", "PLANLI" };
        var existingDiyabetEgitimi = await _db.Set<REFERANS_KODLAR>()
            .Where(r => diyabetEgitimiCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingDiyabetEgitimi = diyabetEgitimiCodes.Except(existingDiyabetEgitimi).ToList();
        if (missingDiyabetEgitimi.Any())
        {
            var diyabetEgitimiData = new Dictionary<string, string>
            {
                ["VERILDI"] = "Eğitim Verildi",
                ["VERILMEDI"] = "Eğitim Verilmedi",
                ["REDDETTI"] = "Hasta Reddetti",
                ["PLANLI"] = "Eğitim Planlandı"
            };
            codesToAdd.AddRange(missingDiyabetEgitimi.Select(code => CreateReferans(code, "DIYABET_EGITIMI", diyabetEgitimiData[code], code, code, code, code)));
        }

        // DIYABET_KOMPLIKASYONLARI referans kodları (DIYABET için)
        var diyabetKompCodes = new[] { "YOK", "RETINOPATI", "NEFROPATI", "NOROPATI", "KAH", "AYAK_ULSERI", "COKLU" };
        var existingDiyabetKomp = await _db.Set<REFERANS_KODLAR>()
            .Where(r => diyabetKompCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingDiyabetKomp = diyabetKompCodes.Except(existingDiyabetKomp).ToList();
        if (missingDiyabetKomp.Any())
        {
            var diyabetKompData = new Dictionary<string, string>
            {
                ["YOK"] = "Komplikasyon Yok",
                ["RETINOPATI"] = "Diyabetik Retinopati",
                ["NEFROPATI"] = "Diyabetik Nefropati",
                ["NOROPATI"] = "Diyabetik Nöropati",
                ["KAH"] = "Koroner Arter Hastalığı",
                ["AYAK_ULSERI"] = "Diyabetik Ayak Ülseri",
                ["COKLU"] = "Çoklu Komplikasyon"
            };
            codesToAdd.AddRange(missingDiyabetKomp.Select(code => CreateReferans(code, "DIYABET_KOMPLIKASYONLARI", diyabetKompData[code], code, code, code, code)));
        }

        // UYARI_TURU referans kodları (HASTA_UYARI için)
        var uyariTuruCodes = new[] { "ALLERJI", "ILAC_ETKILESIMI", "KRITIK_DEGER", "OZEL_DURUM", "KRONIK" };
        var existingUyariTuru = await _db.Set<REFERANS_KODLAR>()
            .Where(r => uyariTuruCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingUyariTuru = uyariTuruCodes.Except(existingUyariTuru).ToList();
        if (missingUyariTuru.Any())
        {
            var uyariTuruData = new Dictionary<string, string>
            {
                ["ALLERJI"] = "Alerji Uyarısı",
                ["ILAC_ETKILESIMI"] = "İlaç Etkileşimi",
                ["KRITIK_DEGER"] = "Kritik Değer",
                ["OZEL_DURUM"] = "Özel Durum",
                ["KRONIK"] = "Kronik Hastalık"
            };
            codesToAdd.AddRange(missingUyariTuru.Select(code => CreateReferans(code, "UYARI_TURU", uyariTuruData[code], code, code, code, code)));
        }

        // TIBBI_BILGI_TURU referans kodları (HASTA_TIBBI_BILGI için)
        var tibbiBilgiTuruCodes = new[] { "ANAMNEZ", "OZGECMIS", "SOYGECMIS", "ALISKANLIK", "ALLERJI_BILGISI" };
        var existingTibbiBilgiTuru = await _db.Set<REFERANS_KODLAR>()
            .Where(r => tibbiBilgiTuruCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingTibbiBilgiTuru = tibbiBilgiTuruCodes.Except(existingTibbiBilgiTuru).ToList();
        if (missingTibbiBilgiTuru.Any())
        {
            var tibbiBilgiTuruData = new Dictionary<string, string>
            {
                ["ANAMNEZ"] = "Anamnez",
                ["OZGECMIS"] = "Özgeçmiş",
                ["SOYGECMIS"] = "Soygeçmiş",
                ["ALISKANLIK"] = "Alışkanlıklar",
                ["ALLERJI_BILGISI"] = "Alerji Bilgisi"
            };
            codesToAdd.AddRange(missingTibbiBilgiTuru.Select(code => CreateReferans(code, "TIBBI_BILGI_TURU", tibbiBilgiTuruData[code], code, code, code, code)));
        }

        // TIBBI_BILGI_ALT_TURU referans kodları (HASTA_TIBBI_BILGI için)
        var tibbiBilgiAltTuruCodes = new[] { "DETAY", "GENEL", "OZEL", "KRITIK" };
        var existingTibbiBilgiAltTuru = await _db.Set<REFERANS_KODLAR>()
            .Where(r => tibbiBilgiAltTuruCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingTibbiBilgiAltTuru = tibbiBilgiAltTuruCodes.Except(existingTibbiBilgiAltTuru).ToList();
        if (missingTibbiBilgiAltTuru.Any())
        {
            var tibbiBilgiAltTuruData = new Dictionary<string, string>
            {
                ["DETAY"] = "Detay Bilgi",
                ["GENEL"] = "Genel Bilgi",
                ["OZEL"] = "Özel Bilgi",
                ["KRITIK"] = "Kritik Bilgi"
            };
            codesToAdd.AddRange(missingTibbiBilgiAltTuru.Select(code => CreateReferans(code, "TIBBI_BILGI_ALT_TURU", tibbiBilgiAltTuruData[code], code, code, code, code)));
        }

        // EPIKRIZ_BASLIK_BILGISI referans kodları (HASTA_EPIKRIZ için)
        var epikrizBaslikCodes = new[] { "YATIS_EPIKRIZ", "CIKIS_EPIKRIZ", "GUNLUK_EPIKRIZ", "KONSULTASYON_EPIKRIZ" };
        var existingEpikrizBaslik = await _db.Set<REFERANS_KODLAR>()
            .Where(r => epikrizBaslikCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingEpikrizBaslik = epikrizBaslikCodes.Except(existingEpikrizBaslik).ToList();
        if (missingEpikrizBaslik.Any())
        {
            var epikrizBaslikData = new Dictionary<string, string>
            {
                ["YATIS_EPIKRIZ"] = "Yatış Epikrizi",
                ["CIKIS_EPIKRIZ"] = "Çıkış Epikrizi",
                ["GUNLUK_EPIKRIZ"] = "Günlük Epikriz",
                ["KONSULTASYON_EPIKRIZ"] = "Konsültasyon Epikrizi"
            };
            codesToAdd.AddRange(missingEpikrizBaslik.Select(code => CreateReferans(code, "EPIKRIZ_BASLIK_BILGISI", epikrizBaslikData[code], code, code, code, code)));
        }

        // FOTOGRAF_TURU referans kodları (HASTA_FOTOGRAF için)
        var fotografTuruCodes = new[] { "KIMLIK", "TIBBI", "YARA", "RADYOLOJI", "DIGER_FOTO" };
        var existingFotografTuru = await _db.Set<REFERANS_KODLAR>()
            .Where(r => fotografTuruCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingFotografTuru = fotografTuruCodes.Except(existingFotografTuru).ToList();
        if (missingFotografTuru.Any())
        {
            var fotografTuruData = new Dictionary<string, string>
            {
                ["KIMLIK"] = "Kimlik Fotoğrafı",
                ["TIBBI"] = "Tıbbi Fotoğraf",
                ["YARA"] = "Yara Fotoğrafı",
                ["RADYOLOJI"] = "Radyoloji Görüntüsü",
                ["DIGER_FOTO"] = "Diğer Fotoğraf"
            };
            codesToAdd.AddRange(missingFotografTuru.Select(code => CreateReferans(code, "FOTOGRAF_TURU", fotografTuruData[code], code, code, code, code)));
        }

        // KARAR_ICERIK_FORMATI referans kodları (KURUL_RAPOR için)
        var kararIcerikCodes = new[] { "STANDART", "GENISLETILMIS", "KISALTILMIS", "OZEL_FORMAT" };
        var existingKararIcerik = await _db.Set<REFERANS_KODLAR>()
            .Where(r => kararIcerikCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingKararIcerik = kararIcerikCodes.Except(existingKararIcerik).ToList();
        if (missingKararIcerik.Any())
        {
            var kararIcerikData = new Dictionary<string, string>
            {
                ["STANDART"] = "Standart Format",
                ["GENISLETILMIS"] = "Genişletilmiş Format",
                ["KISALTILMIS"] = "Kısaltılmış Format",
                ["OZEL_FORMAT"] = "Özel Format"
            };
            codesToAdd.AddRange(missingKararIcerik.Select(code => CreateReferans(code, "KARAR_ICERIK_FORMATI", kararIcerikData[code], code, code, code, code)));
        }

        // MURACAAT_DURUMU referans kodları (KURUL_RAPOR için)
        var muracaatDurumCodes = new[] { "NORMAL", "BEKLEMEDE", "ISLENIYOR", "TAMAMLANDI", "IPTAL" };
        var existingMuracaatDurum = await _db.Set<REFERANS_KODLAR>()
            .Where(r => muracaatDurumCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingMuracaatDurum = muracaatDurumCodes.Except(existingMuracaatDurum).ToList();
        if (missingMuracaatDurum.Any())
        {
            var muracaatDurumData = new Dictionary<string, string>
            {
                ["NORMAL"] = "Normal Müracaat",
                ["BEKLEMEDE"] = "Beklemede",
                ["ISLENIYOR"] = "İşleniyor",
                ["TAMAMLANDI"] = "Tamamlandı",
                ["IPTAL"] = "İptal Edildi"
            };
            codesToAdd.AddRange(missingMuracaatDurum.Select(code => CreateReferans(code, "MURACAAT_DURUMU", muracaatDurumData[code], code, code, code, code)));
        }

        // SEPTIK_SOK referans kodları (KLINIK_SEYIR için)
        var septikSokCodes = new[] { "EVET", "HAYIR", "SUPHELI" };
        var existingSeptikSok = await _db.Set<REFERANS_KODLAR>()
            .Where(r => septikSokCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingSeptikSok = septikSokCodes.Except(existingSeptikSok).ToList();
        if (missingSeptikSok.Any())
        {
            var septikSokData = new Dictionary<string, string>
            {
                ["EVET"] = "Evet",
                ["HAYIR"] = "Hayır",
                ["SUPHELI"] = "Şüpheli"
            };
            codesToAdd.AddRange(missingSeptikSok.Select(code => CreateReferans(code, "SEPTIK_SOK", septikSokData[code], code, code, code, code)));
        }

        // SEPSIS_DURUMU referans kodları (KLINIK_SEYIR için)
        var sepsisDurumCodes = new[] { "YOK", "HAFIF", "ORTA", "AGIR", "KRITIK" };
        var existingSepsisDurum = await _db.Set<REFERANS_KODLAR>()
            .Where(r => sepsisDurumCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingSepsisDurum = sepsisDurumCodes.Except(existingSepsisDurum).ToList();
        if (missingSepsisDurum.Any())
        {
            var sepsisDurumData = new Dictionary<string, string>
            {
                ["YOK"] = "Sepsis Yok",
                ["HAFIF"] = "Hafif Sepsis",
                ["ORTA"] = "Orta Sepsis",
                ["AGIR"] = "Ağır Sepsis",
                ["KRITIK"] = "Kritik Sepsis"
            };
            codesToAdd.AddRange(missingSepsisDurum.Select(code => CreateReferans(code, "SEPSIS_DURUMU", sepsisDurumData[code], code, code, code, code)));
        }

        // SEYIR_TIPI referans kodları (KLINIK_SEYIR için)
        var seyirTipiCodes = new[] { "GUNLUK", "HAFTALIK", "TABURCULUK", "KONSULTASYON", "ACIL" };
        var existingSeyirTipi = await _db.Set<REFERANS_KODLAR>()
            .Where(r => seyirTipiCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingSeyirTipi = seyirTipiCodes.Except(existingSeyirTipi).ToList();
        if (missingSeyirTipi.Any())
        {
            var seyirTipiData = new Dictionary<string, string>
            {
                ["GUNLUK"] = "Günlük Seyir",
                ["HAFTALIK"] = "Haftalık Seyir",
                ["TABURCULUK"] = "Taburculuk Seyiri",
                ["KONSULTASYON"] = "Konsültasyon Seyiri",
                ["ACIL"] = "Acil Seyir"
            };
            codesToAdd.AddRange(missingSeyirTipi.Select(code => CreateReferans(code, "SEYIR_TIPI", seyirTipiData[code], code, code, code, code)));
        }

        // RANDEVU_TURU referans kodları (RANDEVU için)
        var randevuTuruCodes = new[] { "POLIKLINIK", "LABORATUVAR", "RADYOLOJI", "AMELIYAT", "FIZIK_TEDAVI" };
        var existingRandevuTuru = await _db.Set<REFERANS_KODLAR>()
            .Where(r => randevuTuruCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingRandevuTuru = randevuTuruCodes.Except(existingRandevuTuru).ToList();
        if (missingRandevuTuru.Any())
        {
            var randevuTuruData = new Dictionary<string, string>
            {
                ["POLIKLINIK"] = "Poliklinik Randevusu",
                ["LABORATUVAR"] = "Laboratuvar Randevusu",
                ["RADYOLOJI"] = "Radyoloji Randevusu",
                ["AMELIYAT"] = "Ameliyat Randevusu",
                ["FIZIK_TEDAVI"] = "Fizik Tedavi Randevusu"
            };
            codesToAdd.AddRange(missingRandevuTuru.Select(code => CreateReferans(code, "RANDEVU_TURU", randevuTuruData[code], code, code, code, code)));
        }

        // RANDEVU_GELME_DURUMU referans kodları (RANDEVU için)
        var randevuGelmeCodes = new[] { "GELDI", "GELMEDI", "BEKLIYOR", "IPTAL", "ERTELENDI" };
        var existingRandevuGelme = await _db.Set<REFERANS_KODLAR>()
            .Where(r => randevuGelmeCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingRandevuGelme = randevuGelmeCodes.Except(existingRandevuGelme).ToList();
        if (missingRandevuGelme.Any())
        {
            var randevuGelmeData = new Dictionary<string, string>
            {
                ["GELDI"] = "Geldi",
                ["GELMEDI"] = "Gelmedi",
                ["BEKLIYOR"] = "Bekliyor",
                ["IPTAL"] = "İptal",
                ["ERTELENDI"] = "Ertelendi"
            };
            codesToAdd.AddRange(missingRandevuGelme.Select(code => CreateReferans(code, "RANDEVU_GELME_DURUMU", randevuGelmeData[code], code, code, code, code)));
        }

        // TIBBI_ORDER_TURU referans kodları (TIBBI_ORDER için)
        var orderTuruCodes = new[] { "ILAC", "TETKIK", "RADYOLOJI", "KONSULTASYON", "MALZEME", "FIZIK_TEDAVI" };
        var existingOrderTuru = await _db.Set<REFERANS_KODLAR>()
            .Where(r => orderTuruCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingOrderTuru = orderTuruCodes.Except(existingOrderTuru).ToList();
        if (missingOrderTuru.Any())
        {
            var orderTuruData = new Dictionary<string, string>
            {
                ["ILAC"] = "İlaç Order",
                ["TETKIK"] = "Tetkik Order",
                ["RADYOLOJI"] = "Radyoloji Order",
                ["KONSULTASYON"] = "Konsültasyon Order",
                ["MALZEME"] = "Malzeme Order",
                ["FIZIK_TEDAVI"] = "Fizik Tedavi Order"
            };
            codesToAdd.AddRange(missingOrderTuru.Select(code => CreateReferans(code, "TIBBI_ORDER_TURU", orderTuruData[code], code, code, code, code)));
        }

        // TANI_TURU2 referans kodları (BASVURU_TANI için - ek kodlar)
        var basvuruTaniTuruCodes = new[] { "BIRINCIL", "IKINCIL", "ONERILEN", "SIRASIZ" };
        var existingBasvuruTaniTuru = await _db.Set<REFERANS_KODLAR>()
            .Where(r => basvuruTaniTuruCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingBasvuruTaniTuru = basvuruTaniTuruCodes.Except(existingBasvuruTaniTuru).ToList();
        if (missingBasvuruTaniTuru.Any())
        {
            var basvuruTaniTuruData = new Dictionary<string, string>
            {
                ["BIRINCIL"] = "Birincil Tanı",
                ["IKINCIL"] = "İkincil Tanı",
                ["ONERILEN"] = "Önerilen Tanı",
                ["SIRASIZ"] = "Sırasız Tanı"
            };
            codesToAdd.AddRange(missingBasvuruTaniTuru.Select(code => CreateReferans(code, "TANI_TURU", basvuruTaniTuruData[code], code, code, code, code)));
        }

        // BAKIM_NEDENI referans kodları (HEMSIRE_BAKIM için)
        var bakimNedeniCodes = new[] { "RUTIN", "ACIL", "BASINC_YARASI", "YARA_BAKIM", "KATETER" };
        var existingBakimNedeni = await _db.Set<REFERANS_KODLAR>()
            .Where(r => bakimNedeniCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingBakimNedeni = bakimNedeniCodes.Except(existingBakimNedeni).ToList();
        if (missingBakimNedeni.Any())
        {
            var bakimNedeniData = new Dictionary<string, string>
            {
                ["RUTIN"] = "Rutin Bakım",
                ["ACIL"] = "Acil Bakım",
                ["BASINC_YARASI"] = "Basınç Yarası Bakımı",
                ["YARA_BAKIM"] = "Yara Bakımı",
                ["KATETER"] = "Kateter Bakımı"
            };
            codesToAdd.AddRange(missingBakimNedeni.Select(code => CreateReferans(code, "BAKIM_NEDENI", bakimNedeniData[code], code, code, code, code)));
        }

        // HEMSIRE_BAKIM_HEDEF_SONUC referans kodları
        var hedefSonucCodes = new[] { "BASARILI", "KISMI_BASARILI", "BASARISIZ", "DEVAM_EDIYOR" };
        var existingHedefSonuc = await _db.Set<REFERANS_KODLAR>()
            .Where(r => hedefSonucCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingHedefSonuc = hedefSonucCodes.Except(existingHedefSonuc).ToList();
        if (missingHedefSonuc.Any())
        {
            var hedefSonucData = new Dictionary<string, string>
            {
                ["BASARILI"] = "Başarılı",
                ["KISMI_BASARILI"] = "Kısmi Başarılı",
                ["BASARISIZ"] = "Başarısız",
                ["DEVAM_EDIYOR"] = "Devam Ediyor"
            };
            codesToAdd.AddRange(missingHedefSonuc.Select(code => CreateReferans(code, "HEMSIRE_BAKIM_HEDEF_SONUC", hedefSonucData[code], code, code, code, code)));
        }

        // HEMSIRELIK_GIRISIMI referans kodları
        var girisimiCodes = new[] { "VITAL_TAKIP", "ILAC_UYGULAMA", "PANSUMAN", "INFUZYON", "KATETER_BAKIMI" };
        var existingGirisimi = await _db.Set<REFERANS_KODLAR>()
            .Where(r => girisimiCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingGirisimi = girisimiCodes.Except(existingGirisimi).ToList();
        if (missingGirisimi.Any())
        {
            var girisimiData = new Dictionary<string, string>
            {
                ["VITAL_TAKIP"] = "Vital Bulgu Takibi",
                ["ILAC_UYGULAMA"] = "İlaç Uygulama",
                ["PANSUMAN"] = "Pansuman",
                ["INFUZYON"] = "İnfüzyon",
                ["KATETER_BAKIMI"] = "Kateter Bakımı"
            };
            codesToAdd.AddRange(missingGirisimi.Select(code => CreateReferans(code, "HEMSIRELIK_GIRISIMI", girisimiData[code], code, code, code, code)));
        }

        // HEMSIRE_DEGERLENDIRME_DURUMU referans kodları
        var degerDurumCodes = new[] { "STABIL", "IYILESME", "KOTULEME", "DEGISIM_YOK", "KRITIK" };
        var existingDegerDurum = await _db.Set<REFERANS_KODLAR>()
            .Where(r => degerDurumCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingDegerDurum = degerDurumCodes.Except(existingDegerDurum).ToList();
        if (missingDegerDurum.Any())
        {
            var degerDurumData = new Dictionary<string, string>
            {
                ["STABIL"] = "Stabil",
                ["IYILESME"] = "İyileşme",
                ["KOTULEME"] = "Kötüleşme",
                ["DEGISIM_YOK"] = "Değişim Yok",
                ["KRITIK"] = "Kritik"
            };
            codesToAdd.AddRange(missingDegerDurum.Select(code => CreateReferans(code, "HEMSIRE_DEGERLENDIRME_DURUMU", degerDurumData[code], code, code, code, code)));
        }

        // KONSULTASYON_YERI referans kodları
        var konsYeriCodes = new[] { "YATAK_BASI", "POLIKLINIK", "ACIL_SERVIS", "AMELIYATHANE", "YOGUN_BAKIM" };
        var existingKonsYeri = await _db.Set<REFERANS_KODLAR>()
            .Where(r => konsYeriCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingKonsYeri = konsYeriCodes.Except(existingKonsYeri).ToList();
        if (missingKonsYeri.Any())
        {
            var konsYeriData = new Dictionary<string, string>
            {
                ["YATAK_BASI"] = "Yatak Başı",
                ["POLIKLINIK"] = "Poliklinik",
                ["ACIL_SERVIS"] = "Acil Servis",
                ["AMELIYATHANE"] = "Ameliyathane",
                ["YOGUN_BAKIM"] = "Yoğun Bakım"
            };
            codesToAdd.AddRange(missingKonsYeri.Select(code => CreateReferans(code, "KONSULTASYON_YERI", konsYeriData[code], code, code, code, code)));
        }

        // ARSIV_DEFTER_TURU referans kodları (HASTA_ARSIV için)
        var arsivDefterCodes = new[] { "POLIKLINIK", "YATAN", "ACIL", "AMELIYAT", "DOGUM", "YOGUN_BAKIM", "GUNUBIRLIK" };
        var existingArsivDefter = await _db.Set<REFERANS_KODLAR>()
            .Where(r => arsivDefterCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingArsivDefter = arsivDefterCodes.Except(existingArsivDefter).ToList();
        if (missingArsivDefter.Any())
        {
            var arsivDefterData = new Dictionary<string, string>
            {
                ["POLIKLINIK"] = "Poliklinik Defteri",
                ["YATAN"] = "Yatan Hasta Defteri",
                ["ACIL"] = "Acil Servis Defteri",
                ["AMELIYAT"] = "Ameliyat Defteri",
                ["DOGUM"] = "Doğum Defteri",
                ["YOGUN_BAKIM"] = "Yoğun Bakım Defteri",
                ["GUNUBIRLIK"] = "Günübirlik Tedavi Defteri"
            };
            codesToAdd.AddRange(missingArsivDefter.Select(code => CreateReferans(code, "ARSIV_DEFTER_TURU", arsivDefterData[code], code, code, code, code)));
        }

        // YEMEK_TURU referans kodları (BASVURU_YEMEK için)
        var yemekTuruCodes = new[] { "NORMAL", "DIYET", "DIYABET", "COCUK", "BEBEK", "VEJETARYEN" };
        var existingYemekTuru = await _db.Set<REFERANS_KODLAR>()
            .Where(r => yemekTuruCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingYemekTuru = yemekTuruCodes.Except(existingYemekTuru).ToList();
        if (missingYemekTuru.Any())
        {
            var yemekTuruData = new Dictionary<string, string>
            {
                ["NORMAL"] = "Normal Yemek",
                ["DIYET"] = "Diyet Yemeği",
                ["DIYABET"] = "Diyabet Yemeği",
                ["COCUK"] = "Çocuk Yemeği",
                ["BEBEK"] = "Bebek Yemeği",
                ["VEJETARYEN"] = "Vejetaryen Yemek"
            };
            codesToAdd.AddRange(missingYemekTuru.Select(code => CreateReferans(code, "YEMEK_TURU", yemekTuruData[code], code, code, code, code)));
        }

        // YEMEK_ZAMANI_TURU referans kodları (BASVURU_YEMEK için)
        var yemekZamaniCodes = new[] { "KAHVALTI", "OGLE", "AKSAM", "ARA_OGUN", "GECE" };
        var existingYemekZamani = await _db.Set<REFERANS_KODLAR>()
            .Where(r => yemekZamaniCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingYemekZamani = yemekZamaniCodes.Except(existingYemekZamani).ToList();
        if (missingYemekZamani.Any())
        {
            var yemekZamaniData = new Dictionary<string, string>
            {
                ["KAHVALTI"] = "Kahvaltı",
                ["OGLE"] = "Öğle Yemeği",
                ["AKSAM"] = "Akşam Yemeği",
                ["ARA_OGUN"] = "Ara Öğün",
                ["GECE"] = "Gece Yemeği"
            };
            codesToAdd.AddRange(missingYemekZamani.Select(code => CreateReferans(code, "YEMEK_ZAMANI_TURU", yemekZamaniData[code], code, code, code, code)));
        }

        // YOGUN_BAKIM_SEVIYE_BILGISI referans kodları (HASTA_VENTILATOR için)
        var yogunBakimSeviyeCodes = new[] { "SEVIYE_1", "SEVIYE_2", "SEVIYE_3", "SEVIYE_4" };
        var existingYogunBakimSeviye = await _db.Set<REFERANS_KODLAR>()
            .Where(r => yogunBakimSeviyeCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingYogunBakimSeviye = yogunBakimSeviyeCodes.Except(existingYogunBakimSeviye).ToList();
        if (missingYogunBakimSeviye.Any())
        {
            var yogunBakimSeviyeData = new Dictionary<string, string>
            {
                ["SEVIYE_1"] = "1. Seviye Yoğun Bakım",
                ["SEVIYE_2"] = "2. Seviye Yoğun Bakım",
                ["SEVIYE_3"] = "3. Seviye Yoğun Bakım",
                ["SEVIYE_4"] = "4. Seviye Yoğun Bakım"
            };
            codesToAdd.AddRange(missingYogunBakimSeviye.Select(code => CreateReferans(code, "YOGUN_BAKIM_SEVIYE_BILGISI", yogunBakimSeviyeData[code], code, code, code, code)));
        }

        // FATURA_TURU referans kodları (FATURA için)
        var faturaTuruCodes = new[] { "YATAN", "AYAKTAN", "ACIL", "GUNUBIRLIK", "AMELIYAT", "RADYOLOJI", "SGK" };
        var existingFaturaTuru = await _db.Set<REFERANS_KODLAR>()
            .Where(r => faturaTuruCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingFaturaTuru = faturaTuruCodes.Except(existingFaturaTuru).ToList();
        if (missingFaturaTuru.Any())
        {
            var faturaTuruData = new Dictionary<string, string>
            {
                ["YATAN"] = "Yatan Hasta Faturası",
                ["AYAKTAN"] = "Ayaktan Hasta Faturası",
                ["ACIL"] = "Acil Hasta Faturası",
                ["GUNUBIRLIK"] = "Günübirlik Tedavi Faturası",
                ["AMELIYAT"] = "Ameliyat Faturası",
                ["RADYOLOJI"] = "Radyoloji Faturası",
                ["SGK"] = "SGK Faturası"
            };
            codesToAdd.AddRange(missingFaturaTuru.Select(code => CreateReferans(code, "FATURA_TURU", faturaTuruData[code], code, code, code, code)));
        }

        // ULKE_KODU referans kodları (HASTA.UYRUK için)
        var ulkeKoduCodes = new[] { "TC", "TR", "DE", "FR", "GB", "US", "RU", "AZ", "GE", "IR", "IQ", "SY", "SA", "AE", "KW", "QA", "JO", "LB", "EG", "LY", "TN", "DZ", "MA" };
        var existingUlkeKodu = await _db.Set<REFERANS_KODLAR>()
            .Where(r => ulkeKoduCodes.Contains(r.REFERANS_KODU)).Select(r => r.REFERANS_KODU).ToListAsync(ct);
        var missingUlkeKodu = ulkeKoduCodes.Except(existingUlkeKodu).ToList();
        if (missingUlkeKodu.Any())
        {
            var ulkeKoduData = new Dictionary<string, string>
            {
                ["TC"] = "Türkiye Cumhuriyeti",
                ["TR"] = "Türkiye",
                ["DE"] = "Almanya",
                ["FR"] = "Fransa",
                ["GB"] = "Birleşik Krallık",
                ["US"] = "Amerika Birleşik Devletleri",
                ["RU"] = "Rusya",
                ["AZ"] = "Azerbaycan",
                ["GE"] = "Gürcistan",
                ["IR"] = "İran",
                ["IQ"] = "Irak",
                ["SY"] = "Suriye",
                ["SA"] = "Suudi Arabistan",
                ["AE"] = "Birleşik Arap Emirlikleri",
                ["KW"] = "Kuveyt",
                ["QA"] = "Katar",
                ["JO"] = "Ürdün",
                ["LB"] = "Lübnan",
                ["EG"] = "Mısır",
                ["LY"] = "Libya",
                ["TN"] = "Tunus",
                ["DZ"] = "Cezayir",
                ["MA"] = "Fas"
            };
            codesToAdd.AddRange(missingUlkeKodu.Select(code => CreateReferans(code, "ULKE_KODU", ulkeKoduData[code], code, code, code, code)));
        }

        if (codesToAdd.Any())
        {
            // Remove duplicates by REFERANS_KODU (keep first occurrence)
            var uniqueCodes = codesToAdd
                .GroupBy(r => r.REFERANS_KODU)
                .Select(g => g.First())
                .ToList();

            // Filter out any that already exist in database
            var alreadyExistingCodes = await _db.Set<REFERANS_KODLAR>()
                .Where(r => uniqueCodes.Select(u => u.REFERANS_KODU).Contains(r.REFERANS_KODU))
                .Select(r => r.REFERANS_KODU)
                .ToListAsync(ct);

            var finalCodes = uniqueCodes.Where(c => !alreadyExistingCodes.Contains(c.REFERANS_KODU)).ToList();

            if (finalCodes.Any())
            {
                await _db.Set<REFERANS_KODLAR>().AddRangeAsync(finalCodes, ct);
                await _db.SaveChangesAsync(ct);
            }
        }
    }

    private async Task SeedReferansKodlarAsync(CancellationToken ct)
    {
        if (await _db.Set<REFERANS_KODLAR>().AnyAsync(ct)) return;
        _logger.LogInformation("Seeding REFERANS_KODLAR...");

        var kodlar = new List<REFERANS_KODLAR>();

        // Cinsiyet
        kodlar.Add(CreateReferans("CNS-E", "CINSIYET", "Erkek", "1", "E", "E", "E"));
        kodlar.Add(CreateReferans("CNS-K", "CINSIYET", "Kadın", "2", "K", "K", "K"));
        kodlar.Add(CreateReferans("CNS-B", "CINSIYET", "Belirsiz", "3", "B", "B", "B"));

        // Kan Grubu
        kodlar.Add(CreateReferans("KAN-AP", "KAN_GRUBU", "A Rh+", "1", "AP", "AP", "AP"));
        kodlar.Add(CreateReferans("KAN-AN", "KAN_GRUBU", "A Rh-", "2", "AN", "AN", "AN"));
        kodlar.Add(CreateReferans("KAN-BP", "KAN_GRUBU", "B Rh+", "3", "BP", "BP", "BP"));
        kodlar.Add(CreateReferans("KAN-BN", "KAN_GRUBU", "B Rh-", "4", "BN", "BN", "BN"));
        kodlar.Add(CreateReferans("KAN-ABP", "KAN_GRUBU", "AB Rh+", "5", "ABP", "ABP", "ABP"));
        kodlar.Add(CreateReferans("KAN-ABN", "KAN_GRUBU", "AB Rh-", "6", "ABN", "ABN", "ABN"));
        kodlar.Add(CreateReferans("KAN-0P", "KAN_GRUBU", "0 Rh+", "7", "0P", "0P", "0P"));
        kodlar.Add(CreateReferans("KAN-0N", "KAN_GRUBU", "0 Rh-", "8", "0N", "0N", "0N"));

        // Medeni Hal
        kodlar.Add(CreateReferans("MDN-BKR", "MEDENI_HAL", "Bekar", "1", "B", "B", "B"));
        kodlar.Add(CreateReferans("MDN-EVL", "MEDENI_HAL", "Evli", "2", "E", "E", "E"));
        kodlar.Add(CreateReferans("MDN-BOS", "MEDENI_HAL", "Boşanmış", "3", "BS", "BS", "BS"));
        kodlar.Add(CreateReferans("MDN-DUL", "MEDENI_HAL", "Dul", "4", "D", "D", "D"));

        // Sosyal Güvence
        kodlar.Add(CreateReferans("SGK-SSK", "SOSYAL_GUVENCE", "SGK (SSK)", "1", "SSK", "SSK", "SSK"));
        kodlar.Add(CreateReferans("SGK-ES", "SOSYAL_GUVENCE", "SGK (Emekli Sandığı)", "2", "ES", "ES", "ES"));
        kodlar.Add(CreateReferans("SGK-BK", "SOSYAL_GUVENCE", "SGK (Bağ-Kur)", "3", "BK", "BK", "BK"));
        kodlar.Add(CreateReferans("SGK-YK", "SOSYAL_GUVENCE", "Yeşil Kart", "4", "YK", "YK", "YK"));
        kodlar.Add(CreateReferans("SGK-OZL", "SOSYAL_GUVENCE", "Özel Sigorta", "5", "OZL", "OZL", "OZL"));
        kodlar.Add(CreateReferans("SGK-UCR", "SOSYAL_GUVENCE", "Ücretli", "6", "UCR", "UCR", "UCR"));

        // Kurum Türü
        kodlar.Add(CreateReferans("KRM-DH", "KURUM_TURU", "Devlet Hastanesi", "1", "DH", "DH", "DH"));
        kodlar.Add(CreateReferans("KRM-UH", "KURUM_TURU", "Üniversite Hastanesi", "2", "UH", "UH", "UH"));
        kodlar.Add(CreateReferans("KRM-OH", "KURUM_TURU", "Özel Hastane", "3", "OH", "OH", "OH"));
        kodlar.Add(CreateReferans("KRM-ASM", "KURUM_TURU", "Aile Sağlığı Merkezi", "4", "ASM", "ASM", "ASM"));

        // Birim Türü
        kodlar.Add(CreateReferans("BRM-POL", "BIRIM_TURU", "Poliklinik", "1", "POL", "POL", "POL"));
        kodlar.Add(CreateReferans("BRM-SRV", "BIRIM_TURU", "Servis", "2", "SRV", "SRV", "SRV"));
        kodlar.Add(CreateReferans("BRM-ACL", "BIRIM_TURU", "Acil Servis", "3", "ACL", "ACL", "ACL"));
        kodlar.Add(CreateReferans("BRM-YB", "BIRIM_TURU", "Yoğun Bakım", "4", "YB", "YB", "YB"));
        kodlar.Add(CreateReferans("BRM-AMH", "BIRIM_TURU", "Ameliyathane", "5", "AMH", "AMH", "AMH"));
        kodlar.Add(CreateReferans("BRM-LAB", "BIRIM_TURU", "Laboratuvar", "6", "LAB", "LAB", "LAB"));
        kodlar.Add(CreateReferans("BRM-RAD", "BIRIM_TURU", "Radyoloji", "7", "RAD", "RAD", "RAD"));
        kodlar.Add(CreateReferans("BRM-ECZ", "BIRIM_TURU", "Eczane", "8", "ECZ", "ECZ", "ECZ"));

        // Başvuru Türü
        kodlar.Add(CreateReferans("BSV-AYK", "BASVURU_TURU", "Ayaktan", "1", "A", "A", "A"));
        kodlar.Add(CreateReferans("BSV-YTN", "BASVURU_TURU", "Yatan", "2", "Y", "Y", "Y"));
        kodlar.Add(CreateReferans("BSV-GND", "BASVURU_TURU", "Günübirlik", "3", "G", "G", "G"));
        kodlar.Add(CreateReferans("BSV-ACL", "BASVURU_TURU", "Acil", "4", "AC", "AC", "AC"));

        // Başvuru Şekli
        kodlar.Add(CreateReferans("BSK-NRM", "BASVURU_SEKLI", "Normal", "1", "N", "N", "N"));
        kodlar.Add(CreateReferans("BSK-SVK", "BASVURU_SEKLI", "Sevkli", "2", "S", "S", "S"));
        kodlar.Add(CreateReferans("BSK-KTL", "BASVURU_SEKLI", "Kontrol", "3", "K", "K", "K"));
        kodlar.Add(CreateReferans("BSK-ACL", "BASVURU_SEKLI", "Acil", "4", "A", "A", "A"));

        // Çıkış Şekli
        kodlar.Add(CreateReferans("CKS-TBR", "CIKIS_SEKLI", "Taburcu", "1", "T", "T", "T"));
        kodlar.Add(CreateReferans("CKS-SVK", "CIKIS_SEKLI", "Sevk", "2", "S", "S", "S"));
        kodlar.Add(CreateReferans("CKS-EKS", "CIKIS_SEKLI", "Exitus", "3", "E", "E", "E"));
        kodlar.Add(CreateReferans("CKS-IST", "CIKIS_SEKLI", "İsteğe Bağlı", "4", "I", "I", "I"));
        kodlar.Add(CreateReferans("CKS-FRR", "CIKIS_SEKLI", "Firar", "5", "F", "F", "F"));

        // Yatak Türü
        kodlar.Add(CreateReferans("YTK-STD", "YATAK_TURU", "Standart", "1", "S", "S", "S"));
        kodlar.Add(CreateReferans("YTK-YB1", "YATAK_TURU", "Yoğun Bakım 1. Seviye", "2", "YB1", "YB1", "YB1"));
        kodlar.Add(CreateReferans("YTK-YB2", "YATAK_TURU", "Yoğun Bakım 2. Seviye", "3", "YB2", "YB2", "YB2"));
        kodlar.Add(CreateReferans("YTK-YB3", "YATAK_TURU", "Yoğun Bakım 3. Seviye", "4", "YB3", "YB3", "YB3"));
        kodlar.Add(CreateReferans("YTK-BBY", "YATAK_TURU", "Bebek Yatağı", "5", "BBY", "BBY", "BBY"));

        // Hizmet İşlem Grubu
        kodlar.Add(CreateReferans("HZG-MYN", "HIZMET_ISLEM_GRUBU", "Muayene", "1", "M", "M", "M"));
        kodlar.Add(CreateReferans("HZG-TTK", "HIZMET_ISLEM_GRUBU", "Tetkik", "2", "T", "T", "T"));
        kodlar.Add(CreateReferans("HZG-TDV", "HIZMET_ISLEM_GRUBU", "Tedavi", "3", "TD", "TD", "TD"));
        kodlar.Add(CreateReferans("HZG-AML", "HIZMET_ISLEM_GRUBU", "Ameliyat", "4", "A", "A", "A"));
        kodlar.Add(CreateReferans("HZG-RAD", "HIZMET_ISLEM_GRUBU", "Radyoloji", "5", "R", "R", "R"));
        kodlar.Add(CreateReferans("HZG-ILC", "HIZMET_ISLEM_GRUBU", "İlaç", "6", "I", "I", "I"));

        // Hizmet İşlem Türü
        kodlar.Add(CreateReferans("HZT-SUT", "HIZMET_ISLEM_TURU", "SUT Kapsamında", "1", "S", "S", "S"));
        kodlar.Add(CreateReferans("HZT-UCR", "HIZMET_ISLEM_TURU", "Ücretli", "2", "U", "U", "U"));

        // Ameliyat Türü
        kodlar.Add(CreateReferans("AML-MAJ", "AMELIYAT_TURU", "Majör", "1", "M", "M", "M"));
        kodlar.Add(CreateReferans("AML-MIN", "AMELIYAT_TURU", "Minör", "2", "MI", "MI", "MI"));
        kodlar.Add(CreateReferans("AML-ACL", "AMELIYAT_TURU", "Acil", "3", "A", "A", "A"));
        kodlar.Add(CreateReferans("AML-PLN", "AMELIYAT_TURU", "Planlı", "4", "P", "P", "P"));

        // Ameliyat Durumu
        kodlar.Add(CreateReferans("AMD-PLN", "AMELIYAT_DURUMU", "Planlandı", "1", "P", "P", "P"));
        kodlar.Add(CreateReferans("AMD-DVE", "AMELIYAT_DURUMU", "Devam Ediyor", "2", "D", "D", "D"));
        kodlar.Add(CreateReferans("AMD-TMM", "AMELIYAT_DURUMU", "Tamamlandı", "3", "T", "T", "T"));
        kodlar.Add(CreateReferans("AMD-IPT", "AMELIYAT_DURUMU", "İptal", "4", "I", "I", "I"));

        // Anestezi Türü
        kodlar.Add(CreateReferans("ANS-GNL", "ANESTEZI_TURU", "Genel Anestezi", "1", "G", "G", "G"));
        kodlar.Add(CreateReferans("ANS-LOK", "ANESTEZI_TURU", "Lokal Anestezi", "2", "L", "L", "L"));
        kodlar.Add(CreateReferans("ANS-SPN", "ANESTEZI_TURU", "Spinal Anestezi", "3", "S", "S", "S"));
        kodlar.Add(CreateReferans("ANS-EPD", "ANESTEZI_TURU", "Epidural Anestezi", "4", "E", "E", "E"));
        kodlar.Add(CreateReferans("ANS-SED", "ANESTEZI_TURU", "Sedasyon", "5", "SD", "SD", "SD"));

        // Uzmanlik
        kodlar.Add(CreateReferans("UZM-DAH", "UZMANLIK", "Dahiliye", "1", "DAH", "DAH", "DAH"));
        kodlar.Add(CreateReferans("UZM-CRH", "UZMANLIK", "Genel Cerrahi", "2", "CRH", "CRH", "CRH"));
        kodlar.Add(CreateReferans("UZM-KRD", "UZMANLIK", "Kardiyoloji", "3", "KRD", "KRD", "KRD"));
        kodlar.Add(CreateReferans("UZM-NRL", "UZMANLIK", "Nöroloji", "4", "NRL", "NRL", "NRL"));
        kodlar.Add(CreateReferans("UZM-ORT", "UZMANLIK", "Ortopedi", "5", "ORT", "ORT", "ORT"));
        kodlar.Add(CreateReferans("UZM-GKD", "UZMANLIK", "Göğüs Hastalıkları", "6", "GKD", "GKD", "GKD"));
        kodlar.Add(CreateReferans("UZM-URO", "UZMANLIK", "Üroloji", "7", "URO", "URO", "URO"));
        kodlar.Add(CreateReferans("UZM-KBB", "UZMANLIK", "KBB", "8", "KBB", "KBB", "KBB"));
        kodlar.Add(CreateReferans("UZM-GZ", "UZMANLIK", "Göz Hastalıkları", "9", "GZ", "GZ", "GZ"));
        kodlar.Add(CreateReferans("UZM-CLD", "UZMANLIK", "Cildiye", "10", "CLD", "CLD", "CLD"));
        kodlar.Add(CreateReferans("UZM-PSK", "UZMANLIK", "Psikiyatri", "11", "PSK", "PSK", "PSK"));
        kodlar.Add(CreateReferans("UZM-PDT", "UZMANLIK", "Pediatri", "12", "PDT", "PDT", "PDT"));
        kodlar.Add(CreateReferans("UZM-KDN", "UZMANLIK", "Kadın Doğum", "13", "KDN", "KDN", "KDN"));
        kodlar.Add(CreateReferans("UZM-ANS", "UZMANLIK", "Anestezi", "14", "ANS", "ANS", "ANS"));
        kodlar.Add(CreateReferans("UZM-RAD", "UZMANLIK", "Radyoloji", "15", "RAD", "RAD", "RAD"));
        kodlar.Add(CreateReferans("UZM-ACL", "UZMANLIK", "Acil Tıp", "16", "ACL", "ACL", "ACL"));
        kodlar.Add(CreateReferans("UZM-HMS", "UZMANLIK", "Hemşire", "17", "HMS", "HMS", "HMS"));

        // Cihaz Grubu
        kodlar.Add(CreateReferans("CHZ-LAB", "CIHAZ_GRUBU", "Laboratuvar Cihazı", "1", "L", "L", "L"));
        kodlar.Add(CreateReferans("CHZ-RAD", "CIHAZ_GRUBU", "Radyoloji Cihazı", "2", "R", "R", "R"));
        kodlar.Add(CreateReferans("CHZ-AML", "CIHAZ_GRUBU", "Ameliyathane Cihazı", "3", "A", "A", "A"));
        kodlar.Add(CreateReferans("CHZ-YB", "CIHAZ_GRUBU", "Yoğun Bakım Cihazı", "4", "Y", "Y", "Y"));
        kodlar.Add(CreateReferans("CHZ-MON", "CIHAZ_GRUBU", "Monitör", "5", "M", "M", "M"));

        // Depo Türü
        kodlar.Add(CreateReferans("DPO-ANA", "DEPO_TURU", "Ana Depo", "1", "A", "A", "A"));
        kodlar.Add(CreateReferans("DPO-BRM", "DEPO_TURU", "Birim Deposu", "2", "B", "B", "B"));
        kodlar.Add(CreateReferans("DPO-ECZ", "DEPO_TURU", "Eczane Deposu", "3", "E", "E", "E"));

        // Malzeme Tipi
        kodlar.Add(CreateReferans("MLZ-ILC", "MALZEME_TIPI", "İlaç", "1", "I", "I", "I"));
        kodlar.Add(CreateReferans("MLZ-TBM", "MALZEME_TIPI", "Tıbbi Malzeme", "2", "T", "T", "T"));
        kodlar.Add(CreateReferans("MLZ-SRF", "MALZEME_TIPI", "Sarf Malzeme", "3", "S", "S", "S"));

        // Reçete Türü
        kodlar.Add(CreateReferans("RCT-NRM", "RECETE_TURU", "Normal Reçete", "1", "N", "N", "N"));
        kodlar.Add(CreateReferans("RCT-KRM", "RECETE_TURU", "Kırmızı Reçete", "2", "K", "K", "K"));
        kodlar.Add(CreateReferans("RCT-YSL", "RECETE_TURU", "Yeşil Reçete", "3", "Y", "Y", "Y"));
        kodlar.Add(CreateReferans("RCT-MOR", "RECETE_TURU", "Mor Reçete", "4", "M", "M", "M"));
        kodlar.Add(CreateReferans("RCT-TRN", "RECETE_TURU", "Turuncu Reçete", "5", "T", "T", "T"));

        // ICD-10 Tanı Kodları
        kodlar.Add(CreateReferans("J06.9", "ICD10_TANI", "Akut üst solunum yolu enfeksiyonu, tanımlanmamış", "J069", "J069", "J069", "J069"));
        kodlar.Add(CreateReferans("K29.7", "ICD10_TANI", "Gastrit, tanımlanmamış", "K297", "K297", "K297", "K297"));
        kodlar.Add(CreateReferans("I10", "ICD10_TANI", "Esansiyel (primer) hipertansiyon", "I10", "I10", "I10", "I10"));
        kodlar.Add(CreateReferans("E11.9", "ICD10_TANI", "Tip 2 diabetes mellitus, komplikasyonsuz", "E119", "E119", "E119", "E119"));
        kodlar.Add(CreateReferans("J45.9", "ICD10_TANI", "Astım, tanımlanmamış", "J459", "J459", "J459", "J459"));
        kodlar.Add(CreateReferans("M54.5", "ICD10_TANI", "Bel ağrısı", "M545", "M545", "M545", "M545"));
        kodlar.Add(CreateReferans("R51", "ICD10_TANI", "Baş ağrısı", "R51", "R51", "R51", "R51"));
        kodlar.Add(CreateReferans("N39.0", "ICD10_TANI", "İdrar yolu enfeksiyonu, yeri belirtilmemiş", "N390", "N390", "N390", "N390"));
        kodlar.Add(CreateReferans("K80.2", "ICD10_TANI", "Safra kesesi taşı, kolesistitli", "K802", "K802", "K802", "K802"));
        kodlar.Add(CreateReferans("J18.9", "ICD10_TANI", "Pnömoni, tanımlanmamış", "J189", "J189", "J189", "J189"));

        await _db.Set<REFERANS_KODLAR>().AddRangeAsync(kodlar, ct);
        await _db.SaveChangesAsync(ct);
    }

    private REFERANS_KODLAR CreateReferans(string kod, string tur, string ad, string skrs, string medula, string mkys, string tig)
    {
        return new REFERANS_KODLAR
        {
            REFERANS_KODU = kod,
            KOD_TURU = tur,
            REFERANS_ADI = ad,
            SKRS_KODU = skrs,
            MEDULA_KODU = medula,
            MKYS_KODU = mkys,
            TIG_KODU = tig,
            EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
            KAYIT_ZAMANI = DateTime.Now
        };
    }

    #endregion

    #region Kurum

    private async Task SeedKurumAsync(CancellationToken ct)
    {
        if (await _db.Set<KURUM>().AnyAsync(ct)) return;
        _logger.LogInformation("Seeding KURUM...");

        var kurum = new KURUM
        {
            KURUM_KODU = "KRM-001",
            KURUM_ADI = "Ankara Şehir Hastanesi",
            HASTA_KURUM_TURU = "KRM-DH",
            EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
            KAYIT_ZAMANI = DateTime.Now
        };

        await _db.Set<KURUM>().AddAsync(kurum, ct);
        await _db.SaveChangesAsync(ct);
    }

    #endregion

    #region Birimler

    private async Task SeedBirimlerAsync(CancellationToken ct)
    {
        if (await _db.Set<BIRIM>().AnyAsync(ct)) return;
        _logger.LogInformation("Seeding BIRIM...");

        var birimler = new List<BIRIM>
        {
            CreateBirim("BRM-DAH", "Dahiliye Polikliniği", "BRM-POL", "KRM-001"),
            CreateBirim("BRM-DAH-SRV", "Dahiliye Servisi", "BRM-SRV", "KRM-001"),
            CreateBirim("BRM-CRH", "Genel Cerrahi Polikliniği", "BRM-POL", "KRM-001"),
            CreateBirim("BRM-CRH-SRV", "Genel Cerrahi Servisi", "BRM-SRV", "KRM-001"),
            CreateBirim("BRM-KRD", "Kardiyoloji Polikliniği", "BRM-POL", "KRM-001"),
            CreateBirim("BRM-KRD-SRV", "Kardiyoloji Servisi", "BRM-SRV", "KRM-001"),
            CreateBirim("BRM-NRL", "Nöroloji Polikliniği", "BRM-POL", "KRM-001"),
            CreateBirim("BRM-ORT", "Ortopedi Polikliniği", "BRM-POL", "KRM-001"),
            CreateBirim("BRM-ORT-SRV", "Ortopedi Servisi", "BRM-SRV", "KRM-001"),
            CreateBirim("BRM-URO", "Üroloji Polikliniği", "BRM-POL", "KRM-001"),
            CreateBirim("BRM-KBB", "KBB Polikliniği", "BRM-POL", "KRM-001"),
            CreateBirim("BRM-GZ", "Göz Hastalıkları Polikliniği", "BRM-POL", "KRM-001"),
            CreateBirim("BRM-CLD", "Cildiye Polikliniği", "BRM-POL", "KRM-001"),
            CreateBirim("BRM-PDT", "Pediatri Polikliniği", "BRM-POL", "KRM-001"),
            CreateBirim("BRM-PDT-SRV", "Pediatri Servisi", "BRM-SRV", "KRM-001"),
            CreateBirim("BRM-KDN", "Kadın Doğum Polikliniği", "BRM-POL", "KRM-001"),
            CreateBirim("BRM-KDN-SRV", "Kadın Doğum Servisi", "BRM-SRV", "KRM-001"),
            CreateBirim("BRM-ACL", "Acil Servis", "BRM-ACL", "KRM-001"),
            CreateBirim("BRM-YB-GNL", "Genel Yoğun Bakım", "BRM-YB", "KRM-001"),
            CreateBirim("BRM-YB-KRD", "Koroner Yoğun Bakım", "BRM-YB", "KRM-001"),
            CreateBirim("BRM-YB-YD", "Yenidoğan Yoğun Bakım", "BRM-YB", "KRM-001"),
            CreateBirim("BRM-AMH-1", "1. Ameliyathane", "BRM-AMH", "KRM-001"),
            CreateBirim("BRM-AMH-2", "2. Ameliyathane", "BRM-AMH", "KRM-001"),
            CreateBirim("BRM-LAB-BYO", "Biyokimya Laboratuvarı", "BRM-LAB", "KRM-001"),
            CreateBirim("BRM-LAB-HEM", "Hematoloji Laboratuvarı", "BRM-LAB", "KRM-001"),
            CreateBirim("BRM-LAB-MIK", "Mikrobiyoloji Laboratuvarı", "BRM-LAB", "KRM-001"),
            CreateBirim("BRM-RAD", "Radyoloji", "BRM-RAD", "KRM-001"),
            CreateBirim("BRM-ECZ", "Merkez Eczane", "BRM-ECZ", "KRM-001"),
        };

        await _db.Set<BIRIM>().AddRangeAsync(birimler, ct);
        await _db.SaveChangesAsync(ct);
    }

    private BIRIM CreateBirim(string kod, string ad, string tur, string kurumKodu)
    {
        return new BIRIM
        {
            BIRIM_KODU = kod,
            BIRIM_ADI = ad,
            BIRIM_TURU = tur,
            EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
            KAYIT_ZAMANI = DateTime.Now
        };
    }

    #endregion

    #region Bina, Oda, Yatak

    private async Task SeedBinaOdaYatakAsync(CancellationToken ct)
    {
        if (await _db.Set<BINA>().AnyAsync(ct)) return;
        _logger.LogInformation("Seeding BINA, ODA, YATAK...");

        // Binalar
        var binalar = new List<BINA>
        {
            new() { BINA_KODU = "BNA-001", BINA_ADI = "A Blok - Ana Bina", BINA_ADRESI = "Bilkent Bulvarı No:1 A Blok", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { BINA_KODU = "BNA-002", BINA_ADI = "B Blok - Cerrahi Binası", BINA_ADRESI = "Bilkent Bulvarı No:1 B Blok", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { BINA_KODU = "BNA-003", BINA_ADI = "C Blok - Acil ve Yoğun Bakım", BINA_ADRESI = "Bilkent Bulvarı No:1 C Blok", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
        };
        await _db.Set<BINA>().AddRangeAsync(binalar, ct);
        await _db.SaveChangesAsync(ct);

        // Odalar
        var odalar = new List<ODA>();
        var birimOdaMap = new Dictionary<string, string>
        {
            {"BRM-DAH-SRV", "BNA-001"}, {"BRM-CRH-SRV", "BNA-002"}, {"BRM-KRD-SRV", "BNA-001"},
            {"BRM-ORT-SRV", "BNA-002"}, {"BRM-PDT-SRV", "BNA-001"}, {"BRM-KDN-SRV", "BNA-001"},
            {"BRM-YB-GNL", "BNA-003"}, {"BRM-YB-KRD", "BNA-003"}, {"BRM-YB-YD", "BNA-003"},
            {"BRM-ACL", "BNA-003"}
        };

        int odaNo = 1;
        foreach (var (birimKodu, binaKodu) in birimOdaMap)
        {
            int odaSayisi = birimKodu.Contains("YB") ? 2 : (birimKodu.Contains("ACL") ? 5 : 4);
            for (int i = 1; i <= odaSayisi; i++)
            {
                odalar.Add(new ODA
                {
                    ODA_KODU = $"ODA-{odaNo:D3}",
                    ODA_ADI = $"Oda {odaNo}",
                    BIRIM_KODU = birimKodu,
                    EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                    KAYIT_ZAMANI = DateTime.Now
                });
                odaNo++;
            }
        }
        await _db.Set<ODA>().AddRangeAsync(odalar, ct);
        await _db.SaveChangesAsync(ct);

        // Yataklar
        var yataklar = new List<YATAK>();
        int yatakNo = 1;
        foreach (var oda in odalar)
        {
            bool isYogunBakim = oda.BIRIM_KODU?.Contains("YB") ?? false;
            int yatakSayisi = isYogunBakim ? 2 : 4;
            string yatakTuru = isYogunBakim ? "YTK-YB2" : "YTK-STD";

            for (int i = 1; i <= yatakSayisi; i++)
            {
                yataklar.Add(new YATAK
                {
                    YATAK_KODU = $"YTK-{yatakNo:D3}",
                    YATAK_ADI = $"Yatak {yatakNo}",
                    ODA_KODU = oda.ODA_KODU,
                                        EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                    KAYIT_ZAMANI = DateTime.Now
                });
                yatakNo++;
            }
        }
        await _db.Set<YATAK>().AddRangeAsync(yataklar, ct);
        await _db.SaveChangesAsync(ct);
    }

    #endregion

    #region Personel

    private async Task SeedPersonelAsync(CancellationToken ct)
    {
        if (await _db.Set<PERSONEL>().AnyAsync(ct)) return;
        _logger.LogInformation("Seeding PERSONEL...");

        var personeller = new List<PERSONEL>();
        var doktorlar = new (string Ad, string Soyad, string Unvan, string Uzmanlik, string Birim, string Cinsiyet)[]
        {
            ("Ahmet", "Yılmaz", "Prof. Dr.", "UZM-DAH", "BRM-DAH", "CNS-E"),
            ("Mehmet", "Kaya", "Doç. Dr.", "UZM-DAH", "BRM-DAH", "CNS-E"),
            ("Fatma", "Demir", "Uzm. Dr.", "UZM-DAH", "BRM-DAH", "CNS-K"),
            ("Ali", "Öztürk", "Prof. Dr.", "UZM-CRH", "BRM-CRH", "CNS-E"),
            ("Ayşe", "Çelik", "Doç. Dr.", "UZM-CRH", "BRM-CRH", "CNS-K"),
            ("Mustafa", "Şahin", "Uzm. Dr.", "UZM-CRH", "BRM-CRH", "CNS-E"),
            ("Zeynep", "Arslan", "Prof. Dr.", "UZM-KRD", "BRM-KRD", "CNS-K"),
            ("Hüseyin", "Doğan", "Uzm. Dr.", "UZM-KRD", "BRM-KRD", "CNS-E"),
            ("Emine", "Kılıç", "Doç. Dr.", "UZM-NRL", "BRM-NRL", "CNS-K"),
            ("Osman", "Aydın", "Uzm. Dr.", "UZM-NRL", "BRM-NRL", "CNS-E"),
            ("Hatice", "Yıldız", "Prof. Dr.", "UZM-ORT", "BRM-ORT", "CNS-K"),
            ("İbrahim", "Erdoğan", "Uzm. Dr.", "UZM-ORT", "BRM-ORT", "CNS-E"),
            ("Meryem", "Koç", "Uzm. Dr.", "UZM-URO", "BRM-URO", "CNS-K"),
            ("Ömer", "Özdemir", "Doç. Dr.", "UZM-KBB", "BRM-KBB", "CNS-E"),
            ("Elif", "Polat", "Uzm. Dr.", "UZM-GZ", "BRM-GZ", "CNS-K"),
            ("Yusuf", "Özkan", "Uzm. Dr.", "UZM-CLD", "BRM-CLD", "CNS-E"),
            ("Büşra", "Aksoy", "Prof. Dr.", "UZM-PDT", "BRM-PDT", "CNS-K"),
            ("Kemal", "Yılmazer", "Uzm. Dr.", "UZM-PDT", "BRM-PDT", "CNS-E"),
            ("Seda", "Karaca", "Doç. Dr.", "UZM-KDN", "BRM-KDN", "CNS-K"),
            ("Serkan", "Tekin", "Uzm. Dr.", "UZM-KDN", "BRM-KDN", "CNS-E"),
            ("Gül", "Korkmaz", "Uzm. Dr.", "UZM-ACL", "BRM-ACL", "CNS-K"),
            ("Burak", "Şimşek", "Uzm. Dr.", "UZM-ACL", "BRM-ACL", "CNS-E"),
            ("Deniz", "Güneş", "Uzm. Dr.", "UZM-ANS", "BRM-AMH-1", "CNS-E"),
            ("Ece", "Kaplan", "Uzm. Dr.", "UZM-ANS", "BRM-AMH-2", "CNS-K"),
            ("Canan", "Acar", "Uzm. Dr.", "UZM-RAD", "BRM-RAD", "CNS-K"),
        };

        int pNo = 1;
        foreach (var (ad, soyad, unvan, uzmanlik, birim, cinsiyet) in doktorlar)
        {
            personeller.Add(new PERSONEL
            {
                PERSONEL_KODU = $"PRS-{pNo:D3}",
                TC_KIMLIK_NUMARASI = GenerateTcKimlik(),
                AD = ad,
                SOYADI = soyad,
                UNVAN_KODU = unvan,
                CALISTIGI_BIRIM_KODU = birim,
                CINSIYET = cinsiyet,
                DOGUM_TARIHI = DateTime.Now.AddYears(-_random.Next(35, 60)),
                EPOSTA_ADRESI = $"{ad.ToLower()}.{soyad.ToLower()}@hastane.gov.tr",
                CEP_TELEFONU = $"0532{_random.Next(1000000, 9999999)}",
                DIPLOMA_NUMARASI = $"DIP{_random.Next(100000, 999999)}",
                ILK_ISE_BASLAMA_TARIHI = DateTime.Now.AddYears(-_random.Next(5, 25)),
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            });
            pNo++;
        }

        // Hemşireler
        var hemsireler = new (string Ad, string Soyad, string Birim, string Cinsiyet)[]
        {
            ("Aylin", "Çakır", "BRM-DAH-SRV", "CNS-K"),
            ("Esra", "Ünal", "BRM-DAH-SRV", "CNS-K"),
            ("Sevgi", "Yalçın", "BRM-CRH-SRV", "CNS-K"),
            ("Melek", "Tan", "BRM-CRH-SRV", "CNS-K"),
            ("Özlem", "Kurt", "BRM-KRD-SRV", "CNS-K"),
            ("Sibel", "Çetin", "BRM-ORT-SRV", "CNS-K"),
            ("Nurgül", "Kara", "BRM-PDT-SRV", "CNS-K"),
            ("Derya", "Bulut", "BRM-KDN-SRV", "CNS-K"),
            ("Hakan", "Yıldırım", "BRM-YB-GNL", "CNS-E"),
            ("Selma", "Taş", "BRM-YB-GNL", "CNS-K"),
            ("Pınar", "Ateş", "BRM-YB-KRD", "CNS-K"),
            ("Tuğba", "Güler", "BRM-YB-YD", "CNS-K"),
            ("Gökhan", "Özer", "BRM-ACL", "CNS-E"),
            ("Filiz", "Sarı", "BRM-ACL", "CNS-K"),
            ("Nermin", "Aktaş", "BRM-ACL", "CNS-K"),
        };

        foreach (var (ad, soyad, birim, cinsiyet) in hemsireler)
        {
            personeller.Add(new PERSONEL
            {
                PERSONEL_KODU = $"PRS-{pNo:D3}",
                TC_KIMLIK_NUMARASI = GenerateTcKimlik(),
                AD = ad,
                SOYADI = soyad,
                UNVAN_KODU = "Hemşire",
                CALISTIGI_BIRIM_KODU = birim,
                CINSIYET = cinsiyet,
                DOGUM_TARIHI = DateTime.Now.AddYears(-_random.Next(25, 45)),
                EPOSTA_ADRESI = $"{ad.ToLower()}.{soyad.ToLower()}@hastane.gov.tr",
                CEP_TELEFONU = $"0533{_random.Next(1000000, 9999999)}",
                ILK_ISE_BASLAMA_TARIHI = DateTime.Now.AddYears(-_random.Next(2, 15)),
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            });
            pNo++;
        }

        await _db.Set<PERSONEL>().AddRangeAsync(personeller, ct);
        await _db.SaveChangesAsync(ct);
    }

    #endregion

    #region Hizmetler ve Tetkikler

    private async Task SeedHizmetlerAsync(CancellationToken ct)
    {
        if (await _db.Set<HIZMET>().AnyAsync(ct)) return;
        _logger.LogInformation("Seeding HIZMET...");

        var hizmetler = new List<HIZMET>
        {
            // Tetkik Hizmetleri
            new() { HIZMET_KODU = "HZM-TTK-001", HIZMET_ADI = "Hemogram (Tam Kan Sayımı)", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { HIZMET_KODU = "HZM-TTK-002", HIZMET_ADI = "Biyokimya Panel", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { HIZMET_KODU = "HZM-TTK-003", HIZMET_ADI = "İdrar Tahlili", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            // Muayene Hizmetleri
            new() { HIZMET_KODU = "HZM-MYN-001", HIZMET_ADI = "Poliklinik Muayenesi", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { HIZMET_KODU = "HZM-MYN-002", HIZMET_ADI = "Acil Muayene", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            // Görüntüleme Hizmetleri
            new() { HIZMET_KODU = "HZM-GRN-001", HIZMET_ADI = "Direkt Röntgen", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { HIZMET_KODU = "HZM-GRN-002", HIZMET_ADI = "Ultrasonografi", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { HIZMET_KODU = "HZM-GRN-003", HIZMET_ADI = "Bilgisayarlı Tomografi (BT)", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { HIZMET_KODU = "HZM-GRN-004", HIZMET_ADI = "Manyetik Rezonans (MR)", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
        };

        await _db.Set<HIZMET>().AddRangeAsync(hizmetler, ct);
        await _db.SaveChangesAsync(ct);
    }

    private async Task SeedTetkiklerAsync(CancellationToken ct)
    {
        if (await _db.Set<TETKIK>().AnyAsync(ct)) return;
        _logger.LogInformation("Seeding TETKIK...");

        var tetkikler = new List<TETKIK>
        {
            new() { TETKIK_KODU = "TTK-HEM-001", TETKIK_ADI = "Hemoglobin", LOINC_KODU = "718-7", HIZMET_KODU = "HZM-TTK-001", IPTAL_DURUMU = "0", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { TETKIK_KODU = "TTK-HEM-002", TETKIK_ADI = "Hematokrit", LOINC_KODU = "4544-3", HIZMET_KODU = "HZM-TTK-001", IPTAL_DURUMU = "0", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { TETKIK_KODU = "TTK-HEM-003", TETKIK_ADI = "Lökosit (WBC)", LOINC_KODU = "6690-2", HIZMET_KODU = "HZM-TTK-001", IPTAL_DURUMU = "0", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { TETKIK_KODU = "TTK-HEM-004", TETKIK_ADI = "Trombosit (PLT)", LOINC_KODU = "777-3", HIZMET_KODU = "HZM-TTK-001", IPTAL_DURUMU = "0", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { TETKIK_KODU = "TTK-BYO-001", TETKIK_ADI = "Glukoz", LOINC_KODU = "2345-7", HIZMET_KODU = "HZM-TTK-002", IPTAL_DURUMU = "0", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { TETKIK_KODU = "TTK-BYO-002", TETKIK_ADI = "Üre (BUN)", LOINC_KODU = "3094-0", HIZMET_KODU = "HZM-TTK-002", IPTAL_DURUMU = "0", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { TETKIK_KODU = "TTK-BYO-003", TETKIK_ADI = "Kreatinin", LOINC_KODU = "2160-0", HIZMET_KODU = "HZM-TTK-002", IPTAL_DURUMU = "0", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { TETKIK_KODU = "TTK-BYO-004", TETKIK_ADI = "AST (SGOT)", LOINC_KODU = "1920-8", HIZMET_KODU = "HZM-TTK-002", IPTAL_DURUMU = "0", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { TETKIK_KODU = "TTK-BYO-005", TETKIK_ADI = "ALT (SGPT)", LOINC_KODU = "1742-6", HIZMET_KODU = "HZM-TTK-002", IPTAL_DURUMU = "0", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { TETKIK_KODU = "TTK-BYO-006", TETKIK_ADI = "Total Kolesterol", LOINC_KODU = "2093-3", HIZMET_KODU = "HZM-TTK-002", IPTAL_DURUMU = "0", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { TETKIK_KODU = "TTK-BYO-007", TETKIK_ADI = "Trigliserit", LOINC_KODU = "2571-8", HIZMET_KODU = "HZM-TTK-002", IPTAL_DURUMU = "0", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { TETKIK_KODU = "TTK-BYO-008", TETKIK_ADI = "HDL Kolesterol", LOINC_KODU = "2085-9", HIZMET_KODU = "HZM-TTK-002", IPTAL_DURUMU = "0", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { TETKIK_KODU = "TTK-BYO-009", TETKIK_ADI = "LDL Kolesterol", LOINC_KODU = "2089-1", HIZMET_KODU = "HZM-TTK-002", IPTAL_DURUMU = "0", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { TETKIK_KODU = "TTK-IDR-001", TETKIK_ADI = "İdrar pH", LOINC_KODU = "2756-5", HIZMET_KODU = "HZM-TTK-003", IPTAL_DURUMU = "0", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { TETKIK_KODU = "TTK-IDR-002", TETKIK_ADI = "İdrar Dansite", LOINC_KODU = "2965-2", HIZMET_KODU = "HZM-TTK-003", IPTAL_DURUMU = "0", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
        };

        await _db.Set<TETKIK>().AddRangeAsync(tetkikler, ct);
        await _db.SaveChangesAsync(ct);
    }

    #endregion

    #region Hastalar

    private async Task SeedHastalarAsync(CancellationToken ct)
    {
        if (await _db.Set<HASTA>().AnyAsync(ct)) return;
        _logger.LogInformation("Seeding 40 HASTA...");

        var kadinAdlari = new[] { "Fatma", "Ayşe", "Emine", "Hatice", "Zeynep", "Elif", "Meryem", "Şerife", "Zehra", "Sultan", "Hanife", "Merve", "Büşra", "Esra", "Ebru", "Özge", "Seda", "Ceren", "Derya", "Gamze" };
        var erkekAdlari = new[] { "Mehmet", "Mustafa", "Ahmet", "Ali", "Hüseyin", "Hasan", "İbrahim", "Osman", "Yusuf", "Ömer", "Murat", "Emre", "Burak", "Cem", "Serkan", "Tolga", "Onur", "Kerem", "Arda", "Kaan" };
        var soyadlar = new[] { "Yılmaz", "Kaya", "Demir", "Çelik", "Şahin", "Öztürk", "Arslan", "Doğan", "Kılıç", "Aydın", "Özdemir", "Yıldız", "Erdoğan", "Koç", "Özkan", "Polat", "Aksoy", "Korkmaz", "Çakır", "Güneş" };
        var iller = new[] { "Ankara", "İstanbul", "İzmir", "Bursa", "Antalya", "Konya", "Adana", "Gaziantep", "Mersin", "Kayseri" };
        var meslekler = new[] { "Memur", "İşçi", "Emekli", "Öğrenci", "Ev Hanımı", "Serbest Meslek", "Öğretmen", "Mühendis", "Doktor", "Avukat", "Esnaf", "Çiftçi" };
        var kanGruplari = new[] { "KAN-AP", "KAN-AN", "KAN-BP", "KAN-BN", "KAN-ABP", "KAN-ABN", "KAN-0P", "KAN-0N" };
        var sosyalGuvenceler = new[] { "SGK-SSK", "SGK-ES", "SGK-BK", "SGK-YK", "SGK-OZL" };

        var hastalar = new List<HASTA>();

        for (int i = 1; i <= 40; i++)
        {
            bool erkek = i % 2 == 1;
            string ad = erkek ? erkekAdlari[_random.Next(erkekAdlari.Length)] : kadinAdlari[_random.Next(kadinAdlari.Length)];
            string soyad = soyadlar[_random.Next(soyadlar.Length)];
            string babaAdi = erkekAdlari[_random.Next(erkekAdlari.Length)];
            string anaAdi = kadinAdlari[_random.Next(kadinAdlari.Length)];

            var hasta = new HASTA
            {
                HASTA_KODU = $"HST-{i:D4}",
                TC_KIMLIK_NUMARASI = GenerateTcKimlik(),
                AD = ad,
                SOYADI = soyad,
                CINSIYET = erkek ? "CNS-E" : "CNS-K",
                DOGUM_TARIHI = DateTime.Now.AddYears(-_random.Next(1, 85)).AddDays(-_random.Next(0, 365)),
                DOGUM_YERI = iller[_random.Next(iller.Length)],
                ANNE_ADI = anaAdi,
                BABA_ADI = babaAdi,
                KAN_GRUBU = kanGruplari[_random.Next(kanGruplari.Length)],
                MEDENI_HALI = i > 25 ? "MDN-EVL" : (i > 10 ? "MDN-BKR" : "MDN-EVL"),
                UYRUK = "TC",
                MESLEK = meslekler[_random.Next(meslekler.Length)],
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 365))
            };

            hastalar.Add(hasta);
        }

        await _db.Set<HASTA>().AddRangeAsync(hastalar, ct);
        await _db.SaveChangesAsync(ct);
    }

    #endregion

    #region Başvurular

    private async Task SeedBasvurularAsync(CancellationToken ct)
    {
        if (await _db.Set<HASTA_BASVURU>().AnyAsync(ct)) return;
        _logger.LogInformation("Seeding HASTA_BASVURU and related data...");

        var hastalar = await _db.Set<HASTA>().ToListAsync(ct);
        var personeller = await _db.Set<PERSONEL>().Where(p => p.UNVAN_KODU != "Hemşire").ToListAsync(ct);
        var birimler = await _db.Set<BIRIM>().Where(b => b.BIRIM_TURU == "BRM-POL" || b.BIRIM_TURU == "BRM-ACL").ToListAsync(ct);
        var hizmetler = await _db.Set<HIZMET>().ToListAsync(ct);
        var tetkikler = await _db.Set<TETKIK>().ToListAsync(ct);
        var yataklar = await _db.Set<YATAK>().Where(y => y.AKTIF).ToListAsync(ct);

        var basvurular = new List<HASTA_BASVURU>();
        var hastaHizmetler = new List<HASTA_HIZMET>();
        var hastaYataklar = new List<HASTA_YATAK>();
        var basvuruTanilar = new List<BASVURU_TANI>();
        var tetkikSonuclar = new List<TETKIK_SONUC>();
        var ameliyatlar = new List<AMELIYAT>();
        var randevular = new List<RANDEVU>();
        var receteler = new List<RECETE>();

        int bsvNo = 1, hzmNo = 1, ytNo = 1, tniNo = 1, snNo = 1, amlNo = 1, rndNo = 1, rcNo = 1;
        var sikayetler = new[] { "Baş ağrısı", "Karın ağrısı", "Göğüs ağrısı", "Ateş", "Öksürük", "Nefes darlığı", "Halsizlik", "Bulantı", "Kusma", "İshal", "Kabızlık", "Bel ağrısı", "Eklem ağrısı", "Cilt döküntüsü", "Baş dönmesi" };
        var taniKodlari = new[] { "J06.9", "K29.7", "I10", "E11.9", "J45.9", "M54.5", "R51", "N39.0", "K80.2", "J18.9" };

        foreach (var hasta in hastalar)
        {
            // Her hasta için 1-5 başvuru
            int basvuruSayisi = _random.Next(1, 6);

            for (int b = 0; b < basvuruSayisi; b++)
            {
                var birim = birimler[_random.Next(birimler.Count)];
                var doktor = personeller.FirstOrDefault(p => p.CALISTIGI_BIRIM_KODU == birim.BIRIM_KODU) ?? personeller[_random.Next(personeller.Count)];
                var basvuruTarihi = DateTime.Now.AddDays(-_random.Next(1, 180));
                bool tapisCikti = _random.Next(100) < 70;

                var basvuru = new HASTA_BASVURU
                {
                    HASTA_BASVURU_KODU = $"BSV-{bsvNo:D5}",
                    HASTA_KODU = hasta.HASTA_KODU,
                    HASTA_KABUL_ZAMANI = basvuruTarihi,
                    MUAYENE_TURU = birim.BIRIM_TURU == "BRM-ACL" ? "BSV-ACL" : "BSV-AYK",
                    KABUL_SEKLI = _random.Next(100) < 80 ? "BSK-NRM" : "BSK-SVK",
                    BIRIM_KODU = birim.BIRIM_KODU,
                    HEKIM_KODU = doktor.PERSONEL_KODU,
                    HEKIM_BASVURU_NOTU = sikayetler[_random.Next(sikayetler.Length)],
                    SOSYAL_GUVENCE_DURUMU = "N",
                    SYS_TAKIP_NUMARASI = $"TKP{basvuruTarihi.Year}{bsvNo:D8}",
                    CIKIS_ZAMANI = tapisCikti ? basvuruTarihi.AddHours(_random.Next(1, 8)) : null,
                    CIKIS_SEKLI = tapisCikti ? "CKS-TBR" : null,
                    EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                    KAYIT_ZAMANI = basvuruTarihi
                };
                basvurular.Add(basvuru);

                // Muayene hizmeti
                hastaHizmetler.Add(new HASTA_HIZMET
                {
                    HASTA_HIZMET_KODU = $"HHZ-{hzmNo:D5}",
                    HASTA_KODU = hasta.HASTA_KODU,
                    HASTA_BASVURU_KODU = basvuru.HASTA_BASVURU_KODU,
                    HIZMET_KODU = birim.BIRIM_TURU == "BRM-ACL" ? "HZM-MYN-002" : "HZM-MYN-001",
                    ISLEM_ZAMANI = basvuruTarihi,
                    HIZMET_ADETI = 1,
                    EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                    KAYIT_ZAMANI = basvuruTarihi
                });
                hzmNo++;

                // Tanı
                basvuruTanilar.Add(new BASVURU_TANI
                {
                    BASVURU_TANI_KODU = $"TNI-{tniNo:D5}",
                    HASTA_KODU = hasta.HASTA_KODU,
                    HASTA_BASVURU_KODU = basvuru.HASTA_BASVURU_KODU,
                    TANI_TURU = "ANA",
                    BIRINCIL_TANI = "E",
                    TANI_ZAMANI = basvuruTarihi,
                    EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                    KAYIT_ZAMANI = basvuruTarihi
                });
                tniNo++;

                // %60 tetkik istemi
                if (_random.Next(100) < 60)
                {
                    var tetkik = tetkikler[_random.Next(tetkikler.Count)];
                    var tetkikHizmetKodu = $"HHZ-{hzmNo:D5}";
                    hastaHizmetler.Add(new HASTA_HIZMET
                    {
                        HASTA_HIZMET_KODU = tetkikHizmetKodu,
                        HASTA_KODU = hasta.HASTA_KODU,
                        HASTA_BASVURU_KODU = basvuru.HASTA_BASVURU_KODU,
                        HIZMET_KODU = tetkik.HIZMET_KODU,
                        ISLEM_ZAMANI = basvuruTarihi,
                        HIZMET_ADETI = 1,
                        EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                        KAYIT_ZAMANI = basvuruTarihi
                    });
                    hzmNo++;

                    // Tetkik sonucu
                    if (tapisCikti)
                    {
                        tetkikSonuclar.Add(new TETKIK_SONUC
                        {
                            TETKIK_SONUC_KODU = $"TSN-{snNo:D5}",
                            TETKIK_KODU = tetkik.TETKIK_KODU,
                            TETKIK_ADI = tetkik.TETKIK_ADI,
                            HASTA_HIZMET_KODU = tetkikHizmetKodu,
                            TETKIK_SONUCU = (_random.NextDouble() * 100).ToString("F2"),
                            TETKIK_SONUCU_BIRIMI = "mg/dL",
                            TETKIK_SONUCU_REFERANS_DEGERI = "0-100",
                            SONUC_ZAMANI = basvuruTarihi.AddMinutes(_random.Next(30, 180)),
                            EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                            KAYIT_ZAMANI = basvuruTarihi
                        });
                        snNo++;
                    }
                }

                // %30 reçete
                if (_random.Next(100) < 30 && tapisCikti)
                {
                    receteler.Add(new RECETE
                    {
                        RECETE_KODU = $"RCT-{rcNo:D5}",
                        HASTA_KODU = hasta.HASTA_KODU,
                        HASTA_BASVURU_KODU = basvuru.HASTA_BASVURU_KODU,
                        RECETE_ZAMANI = basvuruTarihi.AddMinutes(_random.Next(30, 120)),
                        RECETE_TURU = "RCT-NRM",
                        HEKIM_KODU = doktor.PERSONEL_KODU,
                        EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                        KAYIT_ZAMANI = basvuruTarihi
                    });
                    rcNo++;
                }

                // %20 randevu (kontrol)
                if (_random.Next(100) < 20 && tapisCikti)
                {
                    var randevuZamani = basvuruTarihi.AddDays(_random.Next(7, 30)).Date.AddHours(_random.Next(8, 17)).AddMinutes(_random.Next(0, 4) * 15);
                    randevular.Add(new RANDEVU
                    {
                        RANDEVU_KODU = $"RND-{rndNo:D5}",
                        HASTA_KODU = hasta.HASTA_KODU,
                        BIRIM_KODU = birim.BIRIM_KODU,
                        HEKIM_KODU = doktor.PERSONEL_KODU,
                        RANDEVU_ZAMANI = randevuZamani,
                        RANDEVU_KAYIT_ZAMANI = basvuruTarihi,
                        TC_KIMLIK_NUMARASI = hasta.TC_KIMLIK_NUMARASI,
                        AD = hasta.AD,
                        SOYADI = hasta.SOYADI,
                        CINSIYET = hasta.CINSIYET,
                        EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                        KAYIT_ZAMANI = basvuruTarihi
                    });
                    rndNo++;
                }

                bsvNo++;
            }

            // %10 yatış ve ameliyat
            if (_random.Next(100) < 10)
            {
                var sonBasvuru = basvurular.Last(bsv => bsv.HASTA_KODU == hasta.HASTA_KODU);
                var yatak = yataklar[_random.Next(yataklar.Count)];
                var yatisTarihi = sonBasvuru.HASTA_KABUL_ZAMANI!.Value;

                // Yatış türüne güncelle
                sonBasvuru.MUAYENE_TURU = "BSV-YTN";
                sonBasvuru.CIKIS_ZAMANI = yatisTarihi.AddDays(_random.Next(2, 10));

                hastaYataklar.Add(new HASTA_YATAK
                {
                    HASTA_YATAK_KODU = $"HYT-{ytNo:D5}",
                    HASTA_KODU = hasta.HASTA_KODU,
                    HASTA_BASVURU_KODU = sonBasvuru.HASTA_BASVURU_KODU,
                    YATAK_KODU = yatak.YATAK_KODU,
                    YATIS_BASLAMA_ZAMANI = yatisTarihi,
                    YATIS_BITIS_ZAMANI = sonBasvuru.CIKIS_ZAMANI,
                    EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                    KAYIT_ZAMANI = yatisTarihi
                });
                ytNo++;

                // Ameliyat
                if (_random.Next(100) < 50)
                {
                    var ameliyatAdlari = new[] { "Apendektomi", "Kolesistektomi", "Herni Onarımı", "Laparoskopi" };
                    ameliyatlar.Add(new AMELIYAT
                    {
                        AMELIYAT_KODU = $"AML-{amlNo:D5}",
                        HASTA_KODU = hasta.HASTA_KODU,
                        HASTA_BASVURU_KODU = sonBasvuru.HASTA_BASVURU_KODU,
                        AMELIYAT_ADI = ameliyatAdlari[_random.Next(ameliyatAdlari.Length)],
                        AMELIYAT_TURU = "AML-PLN",
                        AMELIYAT_BASLAMA_ZAMANI = yatisTarihi.AddDays(1).AddHours(9),
                        AMELIYAT_BITIS_ZAMANI = yatisTarihi.AddDays(1).AddHours(11),
                        BIRIM_KODU = "BRM-AMH-1",
                        AMELIYAT_DURUMU = "AMD-TMM",
                        ANESTEZI_TURU = "ANS-GNL",
                        EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                        KAYIT_ZAMANI = yatisTarihi
                    });
                    amlNo++;
                }
            }
        }

        await _db.Set<HASTA_BASVURU>().AddRangeAsync(basvurular, ct);
        await _db.Set<HASTA_HIZMET>().AddRangeAsync(hastaHizmetler, ct);
        await _db.Set<HASTA_YATAK>().AddRangeAsync(hastaYataklar, ct);
        await _db.Set<BASVURU_TANI>().AddRangeAsync(basvuruTanilar, ct);
        await _db.Set<TETKIK_SONUC>().AddRangeAsync(tetkikSonuclar, ct);
        await _db.Set<AMELIYAT>().AddRangeAsync(ameliyatlar, ct);
        await _db.Set<RANDEVU>().AddRangeAsync(randevular, ct);
        await _db.Set<RECETE>().AddRangeAsync(receteler, ct);

        await _db.SaveChangesAsync(ct);

        _logger.LogInformation($"Seeded: {basvurular.Count} başvuru, {hastaHizmetler.Count} hizmet, {hastaYataklar.Count} yatış, {tetkikSonuclar.Count} tetkik sonucu, {ameliyatlar.Count} ameliyat, {randevular.Count} randevu, {receteler.Count} reçete");

        // Tetkik Numune ve Fatura seed
        await SeedTetkikNumunelerAsync(basvurular, ct);
        await SeedIcmalFaturaAsync(basvurular, ct);
    }

    private async Task SeedTetkikNumunelerAsync(List<HASTA_BASVURU> basvurular, CancellationToken ct)
    {
        _logger.LogInformation("Seeding TETKIK_NUMUNE...");

        var numuneler = new List<TETKIK_NUMUNE>();
        int nmNo = 1;
        var numuneTurleri = new[] { "KAN", "IDRAR", "GAITA", "BALGAM", "BOS" };

        foreach (var basvuru in basvurular.Where(b => b.CIKIS_ZAMANI != null).Take(50))
        {
            numuneler.Add(new TETKIK_NUMUNE
            {
                TETKIK_NUMUNE_KODU = $"NMN-{nmNo:D5}",
                HASTA_KODU = basvuru.HASTA_KODU,
                HASTA_BASVURU_KODU = basvuru.HASTA_BASVURU_KODU,
                NUMUNE_NUMARASI = $"NM{DateTime.Now.Year}{nmNo:D6}",
                NUMUNE_TURU = numuneTurleri[_random.Next(numuneTurleri.Length)],
                BIRIM_KODU = "BRM-LAB-BYO",
                NUMUNE_ALMA_ZAMANI = basvuru.HASTA_KABUL_ZAMANI.Value.AddMinutes(_random.Next(10, 60)),
                NUMUNE_KABUL_ZAMANI = basvuru.HASTA_KABUL_ZAMANI.Value.AddMinutes(_random.Next(60, 120)),
                BARKOD = $"BC{_random.Next(100000000, 999999999)}",
                BARKOD_ZAMANI = basvuru.HASTA_KABUL_ZAMANI.Value.AddMinutes(_random.Next(5, 30)),
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = basvuru.HASTA_KABUL_ZAMANI
            });
            nmNo++;
        }

        await _db.Set<TETKIK_NUMUNE>().AddRangeAsync(numuneler, ct);
        await _db.SaveChangesAsync(ct);
        _logger.LogInformation($"Seeded: {numuneler.Count} tetkik numune");
    }

    private async Task SeedIcmalFaturaAsync(List<HASTA_BASVURU> basvurular, CancellationToken ct)
    {
        _logger.LogInformation("Seeding ICMAL and FATURA...");

        // İcmal
        var icmaller = new List<ICMAL>();
        for (int ay = 1; ay <= 6; ay++)
        {
            icmaller.Add(new ICMAL
            {
                ICMAL_KODU = $"ICM-{DateTime.Now.Year}{ay:D2}",
                ICMAL_DONEMI = $"{DateTime.Now.Year}/{ay:D2}",
                ICMAL_NUMARASI = $"ICM{DateTime.Now.Year}{ay:D4}",
                ICMAL_ADI = $"{DateTime.Now.Year} {ay}. Ay İcmali",
                KURUM_KODU = "KRM-001",
                ICMAL_ZAMANI = new DateTime(DateTime.Now.Year, ay, 28),
                ICMAL_TUTARI = _random.Next(100000, 500000),
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            });
        }
        await _db.Set<ICMAL>().AddRangeAsync(icmaller, ct);
        await _db.SaveChangesAsync(ct);

        // Fatura
        var faturalar = new List<FATURA>();
        int ftNo = 1;
        foreach (var basvuru in basvurular.Where(b => b.CIKIS_ZAMANI != null).Take(80))
        {
            var ay = basvuru.HASTA_KABUL_ZAMANI.Value.Month;
            var icmal = icmaller.FirstOrDefault(i => i.ICMAL_DONEMI == $"{DateTime.Now.Year}/{ay:D2}");

            faturalar.Add(new FATURA
            {
                FATURA_KODU = $"FTR-{ftNo:D5}",
                HASTA_BASVURU_KODU = basvuru.HASTA_BASVURU_KODU,
                HASTA_KODU = basvuru.HASTA_KODU,
                FATURA_DONEMI = $"{basvuru.HASTA_KABUL_ZAMANI.Value.Year}/{basvuru.HASTA_KABUL_ZAMANI.Value.Month:D2}",
                ICMAL_KODU = icmal?.ICMAL_KODU,
                FATURA_TURU = "SGK",
                FATURA_ADI = $"Hasta Faturası - {basvuru.HASTA_BASVURU_KODU}",
                FATURA_ZAMANI = basvuru.CIKIS_ZAMANI,
                FATURA_TUTARI = _random.Next(50, 5000),
                FATURA_NUMARASI = $"FT{basvuru.HASTA_KABUL_ZAMANI.Value.Year}{ftNo:D8}",
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = basvuru.CIKIS_ZAMANI ?? DateTime.Now
            });
            ftNo++;
        }

        await _db.Set<FATURA>().AddRangeAsync(faturalar, ct);
        await _db.SaveChangesAsync(ct);
        _logger.LogInformation($"Seeded: {icmaller.Count} icmal, {faturalar.Count} fatura");
    }

    #endregion

    #region Cihaz, Depo, Stok

    private async Task SeedCihazlarAsync(CancellationToken ct)
    {
        if (await _db.Set<CIHAZ>().AnyAsync(ct)) return;
        _logger.LogInformation("Seeding CIHAZ...");

        var cihazlar = new List<CIHAZ>
        {
            // Laboratuvar Cihazları
            new() { CIHAZ_KODU = "CHZ-001", CIHAZ_ADI = "Biyokimya Analizörü", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { CIHAZ_KODU = "CHZ-002", CIHAZ_ADI = "Hemogram Cihazı", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { CIHAZ_KODU = "CHZ-003", CIHAZ_ADI = "İdrar Analizörü", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            // Radyoloji Cihazları
            new() { CIHAZ_KODU = "CHZ-004", CIHAZ_ADI = "Röntgen Cihazı", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { CIHAZ_KODU = "CHZ-005", CIHAZ_ADI = "Ultrason Cihazı", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { CIHAZ_KODU = "CHZ-006", CIHAZ_ADI = "BT Cihazı", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { CIHAZ_KODU = "CHZ-007", CIHAZ_ADI = "MR Cihazı", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            // Yoğun Bakım Cihazları
            new() { CIHAZ_KODU = "CHZ-008", CIHAZ_ADI = "Ventilatör", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { CIHAZ_KODU = "CHZ-009", CIHAZ_ADI = "Monitör", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            // EKG Cihazı
            new() { CIHAZ_KODU = "CHZ-010", CIHAZ_ADI = "EKG Cihazı", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
        };

        await _db.Set<CIHAZ>().AddRangeAsync(cihazlar, ct);
        await _db.SaveChangesAsync(ct);
    }

    private async Task SeedDepolarAsync(CancellationToken ct)
    {
        if (await _db.Set<DEPO>().AnyAsync(ct)) return;
        _logger.LogInformation("Seeding DEPO...");

        var depolar = new List<DEPO>
        {
            new() { DEPO_KODU = "DEP-001", DEPO_ADI = "Ana Ecza Deposu", DEPO_TURU = "DPO-ANA", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { DEPO_KODU = "DEP-002", DEPO_ADI = "Laboratuvar Deposu", DEPO_TURU = "DPO-BRM", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { DEPO_KODU = "DEP-003", DEPO_ADI = "Radyoloji Deposu", DEPO_TURU = "DPO-BRM", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { DEPO_KODU = "DEP-004", DEPO_ADI = "Ameliyathane Deposu", DEPO_TURU = "DPO-BRM", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { DEPO_KODU = "DEP-005", DEPO_ADI = "Eczane", DEPO_TURU = "DPO-ECZ", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
        };

        await _db.Set<DEPO>().AddRangeAsync(depolar, ct);
        await _db.SaveChangesAsync(ct);
    }

    private async Task SeedStokKartlarAsync(CancellationToken ct)
    {
        if (await _db.Set<STOK_KART>().AnyAsync(ct)) return;
        _logger.LogInformation("Seeding STOK_KART...");

        var stokKartlar = new List<STOK_KART>
        {
            // İlaçlar
            // Tıbbi Malzemeler
            // Sarf Malzemeler
        };

        await _db.Set<STOK_KART>().AddRangeAsync(stokKartlar, ct);
        await _db.SaveChangesAsync(ct);
    }

    #endregion

    #region Kullanici ve Tetkik Parametre

    private async Task SeedKullanicilarAsync(CancellationToken ct)
    {
        // Admin kullanıcı zaten SeedAdminUserAsync'de oluşturuldu
        // Sadece personel kullanıcıları oluştur
        var existingCount = await _db.Set<KULLANICI>().CountAsync(ct);
        if (existingCount > 1) return; // Admin + diğerleri varsa atla

        _logger.LogInformation("Seeding KULLANICI (for personnel)...");

        var kullanicilar = new List<KULLANICI>();
        var personeller = await _db.Set<PERSONEL>().ToListAsync(ct);

        int kNo = 1;
        foreach (var personel in personeller)
        {
            kullanicilar.Add(new KULLANICI
            {
                KULLANICI_KODU = $"KLN-{kNo:D3}",
                PERSONEL_KODU = personel.PERSONEL_KODU,
                KULLANICI_ADI = $"{personel.AD.ToLower()}.{personel.SOYADI.ToLower()}",
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            });
            kNo++;
        }

        await _db.Set<KULLANICI>().AddRangeAsync(kullanicilar, ct);
        await _db.SaveChangesAsync(ct);
    }

    private async Task SeedTetkikParametrelerAsync(CancellationToken ct)
    {
        if (await _db.Set<TETKIK_PARAMETRE>().AnyAsync(ct)) return;
        _logger.LogInformation("Seeding TETKIK_PARAMETRE...");

        var tetkikler = await _db.Set<TETKIK>().ToListAsync(ct);
        var parametreler = new List<TETKIK_PARAMETRE>();

        var paramDefs = new Dictionary<string, (string Ad, string Birim, string Loinc)[]>
        {
            { "TTK-HEM-001", new[] { ("Hemoglobin", "g/dL", "718-7") } },
            { "TTK-HEM-002", new[] { ("Hematokrit", "%", "4544-3") } },
            { "TTK-HEM-003", new[] { ("WBC", "10^3/uL", "6690-2") } },
            { "TTK-HEM-004", new[] { ("PLT", "10^3/uL", "777-3") } },
            { "TTK-BYO-001", new[] { ("Glukoz", "mg/dL", "2345-7") } },
            { "TTK-BYO-002", new[] { ("BUN", "mg/dL", "3094-0") } },
            { "TTK-BYO-003", new[] { ("Kreatinin", "mg/dL", "2160-0") } },
            { "TTK-BYO-004", new[] { ("AST", "U/L", "1920-8") } },
            { "TTK-BYO-005", new[] { ("ALT", "U/L", "1742-6") } },
            { "TTK-BYO-006", new[] { ("Total Kolesterol", "mg/dL", "2093-3") } },
            { "TTK-BYO-007", new[] { ("Trigliserit", "mg/dL", "2571-8") } },
            { "TTK-BYO-008", new[] { ("HDL", "mg/dL", "2085-9") } },
            { "TTK-BYO-009", new[] { ("LDL", "mg/dL", "2089-1") } },
        };

        int pNo = 1;
        foreach (var tetkik in tetkikler)
        {
            if (paramDefs.TryGetValue(tetkik.TETKIK_KODU, out var defs))
            {
                foreach (var (ad, birim, loinc) in defs)
                {
                    parametreler.Add(new TETKIK_PARAMETRE
                    {
                        TETKIK_PARAMETRE_KODU = $"TPR-{pNo:D4}",
                        TETKIK_PARAMETRE_ADI = ad,
                        TETKIK_PARAMETRE_BIRIMI = birim,
                        TETKIK_KODU = tetkik.TETKIK_KODU,
                        LOINC_KODU = loinc,
                        CIHAZ_KODU = tetkik.TETKIK_KODU.StartsWith("TTK-HEM") ? "CHZ-002" : "CHZ-001",
                        IPTAL_DURUMU = "0",
                        EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                        KAYIT_ZAMANI = DateTime.Now
                    });
                    pNo++;
                }
            }
        }

        await _db.Set<TETKIK_PARAMETRE>().AddRangeAsync(parametreler, ct);
        await _db.SaveChangesAsync(ct);
    }

    #endregion

    #region Ek Tablolar

    private async Task SeedFirmalarAsync(CancellationToken ct)
    {
        if (await _db.Set<FIRMA>().AnyAsync(ct)) return;
        _logger.LogInformation("Seeding FIRMA...");

        var firmalar = new List<FIRMA>
        {
            new() { FIRMA_KODU = "FRM-001", FIRMA_ADI = "Medikal Tedarik A.Ş.", TELEFON_NUMARASI = "02121234567", YETKILI_KISI = "Ali Yılmaz", FIRMA_ADRESI = "İstanbul", AKTIFLIK_BILGISI = "1", VERGI_DAIRESI = "Beyoğlu", VERGI_NUMARASI = "1234567890", EPOSTA_ADRESI = "info@medikal.com", IBAN_NUMARASI = "TR0001", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { FIRMA_KODU = "FRM-002", FIRMA_ADI = "Sağlık Malzemeleri Ltd.", TELEFON_NUMARASI = "02122234567", YETKILI_KISI = "Mehmet Demir", FIRMA_ADRESI = "Ankara", AKTIFLIK_BILGISI = "1", VERGI_DAIRESI = "Çankaya", VERGI_NUMARASI = "2234567890", EPOSTA_ADRESI = "info@saglik.com", IBAN_NUMARASI = "TR0002", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { FIRMA_KODU = "FRM-003", FIRMA_ADI = "Laboratuvar Sistemleri A.Ş.", TELEFON_NUMARASI = "02123234567", YETKILI_KISI = "Ayşe Kaya", FIRMA_ADRESI = "İzmir", AKTIFLIK_BILGISI = "1", VERGI_DAIRESI = "Konak", VERGI_NUMARASI = "3234567890", EPOSTA_ADRESI = "info@labsys.com", IBAN_NUMARASI = "TR0003", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { FIRMA_KODU = "FRM-004", FIRMA_ADI = "Tıbbi Cihaz Tic. A.Ş.", TELEFON_NUMARASI = "02124234567", YETKILI_KISI = "Fatma Öz", FIRMA_ADRESI = "Bursa", AKTIFLIK_BILGISI = "1", VERGI_DAIRESI = "Nilüfer", VERGI_NUMARASI = "4234567890", EPOSTA_ADRESI = "info@tibbicihaz.com", IBAN_NUMARASI = "TR0004", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            new() { FIRMA_KODU = "FRM-005", FIRMA_ADI = "Ecza Deposu Ltd.", TELEFON_NUMARASI = "02125234567", YETKILI_KISI = "Hasan Ak", FIRMA_ADRESI = "Antalya", AKTIFLIK_BILGISI = "1", VERGI_DAIRESI = "Muratpaşa", VERGI_NUMARASI = "5234567890", EPOSTA_ADRESI = "info@eczadepo.com", IBAN_NUMARASI = "TR0005", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
        };

        await _db.Set<FIRMA>().AddRangeAsync(firmalar, ct);
        await _db.SaveChangesAsync(ct);
    }

    private async Task SeedEkTabloAsync(CancellationToken ct)
    {
        // Sadece basit FK ilişkileri olan tabloları seedliyoruz
        // VEM 2.0 tablolarının çoğu karmaşık FK ilişkileri gerektirdiğinden
        // bu aşamada sadece temel tablolar doldurulmuştur
        await SeedReceteIlacAsync(ct);
        await SeedAmeliyatIslemAsync(ct); // AMELIYAT_EKIP'ten önce olmalı
        await SeedAmeliyatEkipAsync(ct);
        await SeedKanUrunAsync(ct);
        await SeedKurulAsync(ct);
        await SeedStokIstekAsync(ct);
    }

    private async Task SeedReceteIlacAsync(CancellationToken ct)
    {
        if (await _db.Set<RECETE_ILAC>().AnyAsync(ct))
        {
            _logger.LogInformation("RECETE_ILAC already has data, skipping...");
            return;
        }
        _logger.LogInformation("Seeding RECETE_ILAC...");
        var receteler = await _db.Set<RECETE>().ToListAsync(ct);

        var ilaclar = new[] {
            ("Parol 500mg", "1", "Ağızdan", "3x1"), ("Augmentin 1000mg", "1", "Ağızdan", "2x1"),
            ("Arveles 25mg", "1", "Ağızdan", "2x1"), ("Majezik 100mg", "1", "Ağızdan", "3x1"),
            ("Nurofen 400mg", "1", "Ağızdan", "3x1"), ("Cipro 500mg", "1", "Ağızdan", "2x1"),
            ("Proton 40mg", "1", "Ağızdan", "1x1"), ("Coraspin 100mg", "1", "Ağızdan", "1x1")
        };

        var receteIlaclar = new List<RECETE_ILAC>();
        int no = 1;
        foreach (var r in receteler)
        {
            int ilacSayisi = _random.Next(1, 4);
            for (int i = 0; i < ilacSayisi; i++)
            {
                var (ad, kutu, sekil, doz) = ilaclar[_random.Next(ilaclar.Length)];
                receteIlaclar.Add(new RECETE_ILAC
                {
                    RECETE_ILAC_KODU = $"RI-{no++:D5}",
RECETE_KODU = r.RECETE_KODU,
                    ILAC_ADI = ad,
                    KUTU_ADETI = kutu,
                    BARKOD = $"869{_random.Next(100000000, 999999999)}",
                    ILAC_KULLANIM_SEKLI = "AG",
                    ILAC_KULLANIM_DOZU = doz.Split('x')[1],
                    ILAC_KULLANIM_SAYISI = doz.Split('x')[0],
                    ILAC_KULLANIM_PERIYODU = "7",
                    ILAC_KULLANIM_PERIYODU_BIRIMI = "GUN",
                    DOZ_BIRIM = "ADET",
                    ILAC_ACIKLAMA = "Yemeklerden sonra alınacak",
                    EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                    KAYIT_ZAMANI = DateTime.Now
                });
            }
        }

        await _db.Set<RECETE_ILAC>().AddRangeAsync(receteIlaclar, ct);
        await _db.SaveChangesAsync(ct);
    }

    private async Task SeedAmeliyatIslemAsync(CancellationToken ct)
    {
        if (await _db.Set<AMELIYAT_ISLEM>().AnyAsync(ct))
        {
            _logger.LogInformation("AMELIYAT_ISLEM already has data, skipping...");
            return;
        }

        // AMELIYAT ve HASTA_HIZMET tabloları gerekli
        var ameliyatlar = await _db.Set<AMELIYAT>().ToListAsync(ct);
        var hastaHizmetler = await _db.Set<HASTA_HIZMET>().ToListAsync(ct);

        if (!ameliyatlar.Any())
        {
            _logger.LogWarning("Skipping AMELIYAT_ISLEM seeding - AMELIYAT tablosu boş");
            return;
        }

        _logger.LogInformation("Seeding AMELIYAT_ISLEM...");

        var kesiOranlari = new[] { "KESI_ORANI_100", "KESI_ORANI_50", "KESI_ORANI_25" };
        var kesiSeanslari = new[] { "BIRINCI_SEANS", "IKINCI_SEANS", "UCUNCU_SEANS" };
        var taraflar = new[] { "SAG", "SOL", "BILATERAL", "YOK" };
        var asaSkorlari = new[] { "ASA_1", "ASA_2", "ASA_3" };
        var euroScores = new[] { "EURO_LOW", "EURO_MED", "EURO_HIGH" };
        var yaraSiniflari = new[] { "YARA_1", "YARA_2", "YARA_3" };
        var ameliyatSonuclari = new[] { "BASARILI", "KOMPLIKASYONLU", "DEVAM_EDIYOR" };
        var ameliyatGruplari = new[] { "A1", "A2", "A3", "B", "C", "D", "E" };

        var islemler = new List<AMELIYAT_ISLEM>();
        int no = 1;

        foreach (var aml in ameliyatlar)
        {
            var hizmet = hastaHizmetler.FirstOrDefault(h => h.HASTA_BASVURU_KODU == aml.HASTA_BASVURU_KODU);

            islemler.Add(new AMELIYAT_ISLEM
            {
                AMELIYAT_ISLEM_KODU = $"AI-{no++:D5}",
AMELIYAT_KODU = aml.AMELIYAT_KODU,
                AMELIYAT_GRUBU = ameliyatGruplari[_random.Next(ameliyatGruplari.Length)],
                HASTA_HIZMET_KODU = hizmet?.HASTA_HIZMET_KODU,
                KESI_SAYISI = _random.Next(1, 4).ToString(),
                KESI_ORANI = kesiOranlari[_random.Next(kesiOranlari.Length)],
                KESI_SEANS_BILGISI = kesiSeanslari[_random.Next(kesiSeanslari.Length)],
                TARAF_BILGISI = taraflar[_random.Next(taraflar.Length)],
                KOMPLIKASYON = _random.Next(10) < 2 ? "VAR" : "YOK",
                AMELIYAT_SONUCU = ameliyatSonuclari[_random.Next(ameliyatSonuclari.Length)],
                AMELIYAT_NOTU = $"Ameliyat başarılı şekilde tamamlanmıştır. Hasta vital bulguları stabil.",
                ASA_SKORU = asaSkorlari[_random.Next(asaSkorlari.Length)],
                EUROSCORE = euroScores[_random.Next(euroScores.Length)],
                YARA_SINIFI = yaraSiniflari[_random.Next(yaraSiniflari.Length)],
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            });
        }

        await _db.Set<AMELIYAT_ISLEM>().AddRangeAsync(islemler, ct);
        await _db.SaveChangesAsync(ct);
        _logger.LogInformation($"Seeded: {islemler.Count} AMELIYAT_ISLEM records");
    }

    private async Task SeedAmeliyatEkipAsync(CancellationToken ct)
    {
        if (await _db.Set<AMELIYAT_EKIP>().AnyAsync(ct))
        {
            _logger.LogInformation("AMELIYAT_EKIP already has data, skipping...");
            return;
        }

        // AMELIYAT_ISLEM tablosu boşsa AMELIYAT_EKIP seedleyemeyiz
        var ameliyatIslemler = await _db.Set<AMELIYAT_ISLEM>().ToListAsync(ct);
        if (!ameliyatIslemler.Any())
        {
            _logger.LogWarning("Skipping AMELIYAT_EKIP seeding - AMELIYAT_ISLEM tablosu boş");
            return;
        }

        _logger.LogInformation("Seeding AMELIYAT_EKIP...");
        var personeller = await _db.Set<PERSONEL>().Where(p => p.UNVAN_KODU == "Uzm. Dr." || p.UNVAN_KODU == "Prof. Dr." || p.UNVAN_KODU == "Doç. Dr." || p.UNVAN_KODU == "Hemşire").ToListAsync(ct);

        if (!personeller.Any())
        {
            _logger.LogWarning("Skipping AMELIYAT_EKIP seeding - no PERSONEL records found");
            return;
        }

        var ekipler = new List<AMELIYAT_EKIP>();
        int ekipNo = 1;

        foreach (var ai in ameliyatIslemler)
        {
            var doktorlar = personeller.Where(p => p.UNVAN_KODU != "Hemşire").Take(2).ToList();
            var hemsireler = personeller.Where(p => p.UNVAN_KODU == "Hemşire").Take(2).ToList();

            foreach (var d in doktorlar)
            {
                ekipler.Add(new AMELIYAT_EKIP
                {
                    AMELIYAT_EKIP_KODU = $"AEK-{ekipNo++:D5}",
AMELIYAT_KODU = ai.AMELIYAT_KODU,
                    AMELIYAT_ISLEM_KODU = ai.AMELIYAT_ISLEM_KODU,
                    PERSONEL_KODU = d.PERSONEL_KODU,
                    EKIP_NUMARASI = ekipNo.ToString(),
                    AMELIYAT_PERSONEL_GOREV = "CERRAH",
                    EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                    KAYIT_ZAMANI = DateTime.Now
                });
            }

            foreach (var h in hemsireler)
            {
                ekipler.Add(new AMELIYAT_EKIP
                {
                    AMELIYAT_EKIP_KODU = $"AEK-{ekipNo++:D5}",
AMELIYAT_KODU = ai.AMELIYAT_KODU,
                    AMELIYAT_ISLEM_KODU = ai.AMELIYAT_ISLEM_KODU,
                    PERSONEL_KODU = h.PERSONEL_KODU,
                    EKIP_NUMARASI = ekipNo.ToString(),
                    AMELIYAT_PERSONEL_GOREV = "HEMSIRE",
                    EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                    KAYIT_ZAMANI = DateTime.Now
                });
            }
        }

        await _db.Set<AMELIYAT_EKIP>().AddRangeAsync(ekipler, ct);
        await _db.SaveChangesAsync(ct);
        _logger.LogInformation($"Seeded: {ekipler.Count} AMELIYAT_EKIP records");
    }

    private async Task SeedKanUrunAsync(CancellationToken ct)
    {
        if (await _db.Set<KAN_URUN>().AnyAsync(ct))
        {
            _logger.LogInformation("KAN_URUN already has data, skipping...");
            return;
        }

        // KAN_URUN tablosu HIZMET'e FK gerektiriyor
        var hizmetler = await _db.Set<HIZMET>().Take(4).ToListAsync(ct);
        if (hizmetler.Count < 4)
        {
            _logger.LogWarning("Skipping KAN_URUN seeding - HIZMET tablosunda yeterli kayıt yok");
            return;
        }

        _logger.LogInformation("Seeding KAN_URUN...");

        var kanUrunler = new List<KAN_URUN>
        {
            new() {
                KAN_URUN_KODU = "KU-001",
KAN_URUN_ADI = "Tam Kan",
                HIZMET_KODU = hizmetler[0].HIZMET_KODU,
                KAN_MIAT_PERIYODU = "GUN", KAN_MIAT_SURESI = "35", KIZILAY_BILESEN_TURU = "TAM_KAN",
                KAN_FILTRELEME_UYGUNLUK = "UYGUN", KAN_YIKAMA_UYGUNLUK_DURUMU = "UYGUN",
                KAN_ISINLAMA_UYGUNLUK_DURUMU = "UYGUN", KAN_HAVUZLAMA_UYGUNLUK = "UYGUN_DEGIL",
                KAN_AYIRMA_UYGUNLUK = "UYGUN", KAN_BOLME_UYGUNLUK = "UYGUN",
                BUFFYCOAT_UZAKLASTIRMAYA_UYGUN = "UYGUN",
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now
            },
            new() {
                KAN_URUN_KODU = "KU-002",
KAN_URUN_ADI = "Eritrosit Süspansiyonu",
                HIZMET_KODU = hizmetler[1].HIZMET_KODU,
                KAN_MIAT_PERIYODU = "GUN", KAN_MIAT_SURESI = "42", KIZILAY_BILESEN_TURU = "ERITROSIT",
                KAN_FILTRELEME_UYGUNLUK = "UYGUN", KAN_YIKAMA_UYGUNLUK_DURUMU = "UYGUN",
                KAN_ISINLAMA_UYGUNLUK_DURUMU = "UYGUN", KAN_HAVUZLAMA_UYGUNLUK = "UYGUN_DEGIL",
                KAN_AYIRMA_UYGUNLUK = "UYGUN_DEGIL", KAN_BOLME_UYGUNLUK = "UYGUN",
                BUFFYCOAT_UZAKLASTIRMAYA_UYGUN = "UYGUN_DEGIL",
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now
            },
            new() {
                KAN_URUN_KODU = "KU-003",
KAN_URUN_ADI = "Trombosit Konsantresi",
                HIZMET_KODU = hizmetler[2].HIZMET_KODU,
                KAN_MIAT_PERIYODU = "GUN", KAN_MIAT_SURESI = "5", KIZILAY_BILESEN_TURU = "TROMBOSIT",
                KAN_FILTRELEME_UYGUNLUK = "UYGUN", KAN_YIKAMA_UYGUNLUK_DURUMU = "UYGUN_DEGIL",
                KAN_ISINLAMA_UYGUNLUK_DURUMU = "UYGUN", KAN_HAVUZLAMA_UYGUNLUK = "UYGUN",
                KAN_AYIRMA_UYGUNLUK = "UYGUN_DEGIL", KAN_BOLME_UYGUNLUK = "UYGUN_DEGIL",
                BUFFYCOAT_UZAKLASTIRMAYA_UYGUN = "UYGUN_DEGIL",
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now
            },
            new() {
                KAN_URUN_KODU = "KU-004",
KAN_URUN_ADI = "Taze Donmuş Plazma",
                HIZMET_KODU = hizmetler[3].HIZMET_KODU,
                KAN_MIAT_PERIYODU = "YIL", KAN_MIAT_SURESI = "1", KIZILAY_BILESEN_TURU = "TDP",
                KAN_FILTRELEME_UYGUNLUK = "UYGUN_DEGIL", KAN_YIKAMA_UYGUNLUK_DURUMU = "UYGUN_DEGIL",
                KAN_ISINLAMA_UYGUNLUK_DURUMU = "UYGUN_DEGIL", KAN_HAVUZLAMA_UYGUNLUK = "UYGUN_DEGIL",
                KAN_AYIRMA_UYGUNLUK = "UYGUN_DEGIL", KAN_BOLME_UYGUNLUK = "UYGUN",
                BUFFYCOAT_UZAKLASTIRMAYA_UYGUN = "UYGUN_DEGIL",
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now
            },
        };

        await _db.Set<KAN_URUN>().AddRangeAsync(kanUrunler, ct);
        await _db.SaveChangesAsync(ct);
        _logger.LogInformation("Seeded: 4 KAN_URUN records");
    }

    private async Task SeedKurulAsync(CancellationToken ct)
    {
        if (await _db.Set<KURUL>().AnyAsync(ct))
        {
            _logger.LogInformation("KURUL already has data, skipping...");
            return;
        }

        _logger.LogInformation("Seeding KURUL...");

        var kurullar = new List<KURUL>
        {
            new() {
                KURUL_KODU = "KRL-001",
KURUL_ADI = "Sağlık Kurulu",
                RAPOR_TURU = "HEYET",
                MEDULA_RAPOR_TURU = "MRT_1",
                MEDULA_ALT_RAPOR_TURU = "MART_1",
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            },
            new() {
                KURUL_KODU = "KRL-002",
KURUL_ADI = "Engelli Sağlık Kurulu",
                RAPOR_TURU = "HEYET",
                MEDULA_RAPOR_TURU = "MRT_3",
                MEDULA_ALT_RAPOR_TURU = "MART_2",
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            },
            new() {
                KURUL_KODU = "KRL-003",
KURUL_ADI = "Askerlik Muayene Kurulu",
                RAPOR_TURU = "HEYET",
                MEDULA_RAPOR_TURU = "MRT_4",
                MEDULA_ALT_RAPOR_TURU = "MART_1",
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            },
            new() {
                KURUL_KODU = "KRL-004",
KURUL_ADI = "İş Sağlığı Kurulu",
                RAPOR_TURU = "ISCI_SAGLIGI",
                MEDULA_RAPOR_TURU = "MRT_2",
                MEDULA_ALT_RAPOR_TURU = "MART_1",
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            },
            new() {
                KURUL_KODU = "KRL-005",
KURUL_ADI = "Tek Hekim Kurulu",
                RAPOR_TURU = "TEK_HEKIM",
                MEDULA_RAPOR_TURU = "MRT_1",
                MEDULA_ALT_RAPOR_TURU = "MART_3",
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            },
        };

        await _db.Set<KURUL>().AddRangeAsync(kurullar, ct);
        await _db.SaveChangesAsync(ct);
        _logger.LogInformation($"Seeded: {kurullar.Count} KURUL records");
    }

    private async Task SeedStokIstekAsync(CancellationToken ct)
    {
        if (await _db.Set<STOK_ISTEK>().AnyAsync(ct))
        {
            _logger.LogInformation("STOK_ISTEK already has data, skipping...");
            return;
        }

        var depolar = await _db.Set<DEPO>().ToListAsync(ct);
        var basvurular = await _db.Set<HASTA_BASVURU>().Take(50).ToListAsync(ct);
        var personeller = await _db.Set<PERSONEL>().Where(p => p.UNVAN_KODU == "Uzm. Dr." || p.UNVAN_KODU == "Prof. Dr." || p.UNVAN_KODU == "Doç. Dr.").ToListAsync(ct);
        var ameliyatlar = await _db.Set<AMELIYAT>().ToListAsync(ct);

        if (!depolar.Any() || !basvurular.Any() || !personeller.Any() || !ameliyatlar.Any())
        {
            _logger.LogWarning("Skipping STOK_ISTEK seeding - missing dependency data (depo/basvuru/personel/ameliyat)");
            return;
        }

        _logger.LogInformation("Seeding STOK_ISTEK...");

        var istekler = new List<STOK_ISTEK>();
        int no = 1;

        foreach (var bsv in basvurular.Take(30))
        {
            var depo = depolar[_random.Next(depolar.Count)];
            var hekim = personeller[_random.Next(personeller.Count)];
            var ameliyat = ameliyatlar[_random.Next(ameliyatlar.Count)];

            istekler.Add(new STOK_ISTEK
            {
                STOK_ISTEK_KODU = $"SI-{no++:D5}",
HASTA_BASVURU_KODU = bsv.HASTA_BASVURU_KODU,
                HASTA_KODU = bsv.HASTA_KODU,
                ISTEK_ZAMANI = bsv.HASTA_KABUL_ZAMANI.Value.AddMinutes(_random.Next(30, 180)),
                ISTEK_DEPO_KODU = depo.DEPO_KODU,
                HEKIM_KODU = hekim.PERSONEL_KODU,
                STOK_ISTEK_DURUMU = _random.Next(3) switch { 0 => "BEKLEMEDE", 1 => "ONAYLANDI", _ => "TAMAMLANDI" },
                STOK_ISTEK_HEKIM_ACIKLAMA = "Hasta tedavisi için gerekli malzeme",
                AMELIYAT_KODU = ameliyat.AMELIYAT_KODU,
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            });
        }

        await _db.Set<STOK_ISTEK>().AddRangeAsync(istekler, ct);
        await _db.SaveChangesAsync(ct);
        _logger.LogInformation($"Seeded: {istekler.Count} STOK_ISTEK records");
    }

    #endregion

    #region Level 1 - Ek Odeme, Kullanici Grup, Grup Uyelik

    private async Task SeedLevel1TablesAsync(CancellationToken ct)
    {
        _logger.LogInformation("Seeding Level 1 tables (EK_ODEME_DONEM, KULLANICI_GRUP, GRUP_UYELIK)...");

        // EK_ODEME_DONEM
        if (!await _db.Set<EK_ODEME_DONEM>().AnyAsync(ct))
        {
            var donemler = new List<EK_ODEME_DONEM>();
            for (int ay = 1; ay <= 12; ay++)
            {
                donemler.Add(new EK_ODEME_DONEM
                {
                    EK_ODEME_DONEM_KODU = $"EOD-{DateTime.Now.Year}{ay:D2}",
YIL = DateTime.Now.Year.ToString(),
                    AY = ay.ToString(),
                    BORDRO_NUMARASI = $"BRD{DateTime.Now.Year}{ay:D4}",
                    GIRISIMSEL_ISLEM_PUAN_TOPLAMI = _random.Next(10000, 50000).ToString(),
                    OZELLIKLI_ISLEM_PUAN_TOPLAMI = _random.Next(5000, 25000).ToString(),
                    ACGK_TOPLAMI = _random.Next(1000, 5000).ToString(),
                    DAGITILACAK_EKODEME_TUTARI = _random.Next(100000, 500000).ToString(),
                    EK_ODEME_KATSAYISI = (1.0 + _random.NextDouble()).ToString("F4"),
                    HASTANE_PUAN_ORTALAMASI = _random.Next(50, 100).ToString(),
                    EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                    KAYIT_ZAMANI = DateTime.Now
                });
            }
            await _db.Set<EK_ODEME_DONEM>().AddRangeAsync(donemler, ct);
            await _db.SaveChangesAsync(ct);
        }

        // KULLANICI_GRUP
        if (!await _db.Set<KULLANICI_GRUP>().AnyAsync(ct))
        {
            var gruplar = new List<KULLANICI_GRUP>
            {
                new() { KULLANICI_GRUP_KODU = "KG-001", KULLANICI_GRUP_ADI = "Yöneticiler", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
                new() { KULLANICI_GRUP_KODU = "KG-002", KULLANICI_GRUP_ADI = "Doktorlar", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
                new() { KULLANICI_GRUP_KODU = "KG-003", KULLANICI_GRUP_ADI = "Hemşireler", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
                new() { KULLANICI_GRUP_KODU = "KG-004", KULLANICI_GRUP_ADI = "Teknisyenler", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
                new() { KULLANICI_GRUP_KODU = "KG-005", KULLANICI_GRUP_ADI = "Sekreterler", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
                new() { KULLANICI_GRUP_KODU = "KG-006", KULLANICI_GRUP_ADI = "Güvenlik", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
                new() { KULLANICI_GRUP_KODU = "KG-007", KULLANICI_GRUP_ADI = "Temizlik", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
                new() { KULLANICI_GRUP_KODU = "KG-008", KULLANICI_GRUP_ADI = "Muhasebe", AKTIFLIK_BILGISI = "1", EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu, KAYIT_ZAMANI = DateTime.Now },
            };
            await _db.Set<KULLANICI_GRUP>().AddRangeAsync(gruplar, ct);
            await _db.SaveChangesAsync(ct);
        }

        // GRUP_UYELIK
        if (!await _db.Set<GRUP_UYELIK>().AnyAsync(ct))
        {
            var kullanicilar = await _db.Set<KULLANICI>().ToListAsync(ct);
            var uyelikler = new List<GRUP_UYELIK>();
            int no = 1;

            foreach (var k in kullanicilar)
            {
                // Her kullanıcıyı uygun gruba ata
                string grupKodu = k.KULLANICI_ADI.Contains("admin") ? "KG-001" :
                                  k.KULLANICI_KODU.StartsWith("KLN-0") && int.Parse(k.KULLANICI_KODU[4..]) <= 25 ? "KG-002" : "KG-003";

                uyelikler.Add(new GRUP_UYELIK
                {
                    GRUP_UYELIK_KODU = $"GU-{no++:D4}",
KULLANICI_GRUP_KODU = grupKodu,
                    KULLANICI_KODU = k.KULLANICI_KODU,
                    EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                    KAYIT_ZAMANI = DateTime.Now
                });
            }

            await _db.Set<GRUP_UYELIK>().AddRangeAsync(uyelikler, ct);
            await _db.SaveChangesAsync(ct);
        }

        _logger.LogInformation("Level 1 tables seeded.");
    }

    #endregion

    #region Level 2 - Hasta Related Tables

    private async Task SeedLevel2TablesAsync(CancellationToken ct)
    {
        _logger.LogInformation("Seeding Level 2 tables...");

        // STOK_FIS - FK hatası alıyor, şimdilik atlanıyor
        // var basvurular = await _db.Set<HASTA_BASVURU>().ToListAsync(ct);
        // var personeller = await _db.Set<PERSONEL>().ToListAsync(ct);
        // try { await SeedStokFisAsync(ct, basvurular, personeller); } catch (Exception ex) { _logger.LogWarning($"STOK_FIS seeding failed: {ex.Message}"); }

        _logger.LogInformation("Level 2 tables seeding completed.");
    }

    private async Task SeedStokFisAsync(CancellationToken ct, List<HASTA_BASVURU> basvurular, List<PERSONEL> personeller)
    {
        if (await _db.Set<STOK_FIS>().AnyAsync(ct))
        {
            _logger.LogInformation("STOK_FIS already has data, skipping...");
            return;
        }

        _logger.LogInformation("Seeding STOK_FIS...");
        var depolar = await _db.Set<DEPO>().ToListAsync(ct);
        var firmalar = await _db.Set<FIRMA>().ToListAsync(ct);

        if (!depolar.Any() || !firmalar.Any() || !personeller.Any())
        {
            _logger.LogWarning("Skipping STOK_FIS - missing dependency data");
            return;
        }

        var fisler = new List<STOK_FIS>();
        int no = 1;

        for (int i = 0; i < 20; i++)
                {
                    var depo = depolar[_random.Next(depolar.Count)];
                    var firma = firmalar[_random.Next(firmalar.Count)];
                    var personel = personeller[_random.Next(personeller.Count)];
                    var tarih = DateTime.Now.AddDays(-_random.Next(1, 60));

                    fisler.Add(new STOK_FIS
                    {
                        STOK_FIS_KODU = $"SF-{no:D5}",
HASTA_KODU = "HST-0001",
                        HASTA_BASVURU_KODU = "BSV-00001",
                        BAGLI_STOK_FIS_KODU = $"SF-{no:D5}",
                        DEPO_KODU = depo.DEPO_KODU,
                        HAREKET_TURU = no % 2 == 0 ? "GIRIS" : "CIKIS",
                        MKYS_AYNIYAT_MAKBUZ_KODU = $"MKYS{no:D8}",
                        HAREKET_TARIHI = tarih,
                        SHCEK_PAYI = "0",
                        HAZINE_PAYI = "0",
                        SAGLIK_BAKANLIGI_PAYI = "0",
                        BEDELSIZ_FIS = "H",
                        FIS_TUTARI = _random.Next(1000, 50000).ToString(),
                        HAREKET_SEKLI = "NORMAL",
                        ISLEMI_YAPAN_PERSONEL_KODU = personel.PERSONEL_KODU,
                        ISLEM_ZAMANI = tarih,
                        FIRMA_KODU = firma.FIRMA_KODU,
                        IHALE_NUMARASI = $"IHL{DateTime.Now.Year}{no:D4}",
                        IHALE_TARIHI = tarih.AddDays(-30),
                        IHALE_TURU = "ACIK",
                        MUAYENE_KABUL_NUMARASI = $"MK{no:D6}",
                        MUAYENE_TARIHI = tarih.AddDays(-5),
                        TESLIM_EDEN_KISI = "Firma Yetkilisi",
                        TESLIM_EDEN_KISI_UNVANI = "Satış Temsilcisi",
                        BUTCE_TURU = "DONER",
                        FATURA_NUMARASI = $"FT{DateTime.Now.Year}{no:D6}",
                        FATURA_ZAMANI = tarih,
                        IRSALIYE_NUMARASI = $"IRS{no:D6}",
                        IRSALIYE_TARIHI = tarih.AddDays(-1),
                        MKYS_KURUM_KODU = "123456",
                        EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                        KAYIT_ZAMANI = DateTime.Now
                    });
                    no++;
                }
        await _db.Set<STOK_FIS>().AddRangeAsync(fisler, ct);
        await _db.SaveChangesAsync(ct);
        _logger.LogInformation($"Seeded: {fisler.Count} STOK_FIS records");
    }

    #endregion

    #region Level 3 - All Remaining Tables (20+ records each)

    // TODO: Entity yapılarına göre düzeltilecek - Level 3 seed metotları geçici olarak devre dışı
    #if LEVEL3_SEED_ENABLED
    private async Task SeedLevel3TablesAsync(CancellationToken ct)
    {
        _logger.LogInformation("Seeding Level 3 tables (all remaining VEM tables with 20+ records)...");

        // Gerekli referans verilerini al
        var hastalar = await _db.Set<HASTA>().ToListAsync(ct);
        var basvurular = await _db.Set<HASTA_BASVURU>().ToListAsync(ct);
        var personeller = await _db.Set<PERSONEL>().ToListAsync(ct);
        var birimler = await _db.Set<BIRIM>().ToListAsync(ct);
        var hizmetler = await _db.Set<HIZMET>().ToListAsync(ct);
        var tetkikler = await _db.Set<TETKIK>().ToListAsync(ct);
        var depolar = await _db.Set<DEPO>().ToListAsync(ct);
        var kurullar = await _db.Set<KURUL>().ToListAsync(ct);

        // HASTA İlişkili Tablolar
        await SeedHastaIliskiliAsync(hastalar, basvurular, personeller, ct);

        // PERSONEL İlişkili Tablolar
        await SeedPersonelIliskiliAsync(personeller, birimler, ct);

        // Klinik İzlem Tablolar
        await SeedKlinikIzlemAsync(hastalar, basvurular, personeller, ct);

        // Kan Bankası Tabloları
        await SeedKanBankasiAsync(hastalar, personeller, depolar, ct);

        // Kurul İlişkili Tablolar
        await SeedKurulIliskiliAsync(kurullar, hastalar, basvurular, personeller, ct);

        // Stok ve Sterilizasyon
        await SeedStokSterilizasyonAsync(depolar, personeller, ct);

        // Diğer Tablolar
        await SeedDigerTablolarAsync(hastalar, basvurular, personeller, birimler, hizmetler, tetkikler, ct);

        _logger.LogInformation("Level 3 tables seeding completed!");
    }

    private async Task SeedHastaIliskiliAsync(List<HASTA> hastalar, List<HASTA_BASVURU> basvurular, List<PERSONEL> personeller, CancellationToken ct)
    {
        // HASTA_ILETISIM
        if (!await _db.Set<HASTA_ILETISIM>().AnyAsync(ct))
        {
            // Referans kodları ekle
            var hiAdresTipiRef = new[] { "EV", "IS", "DIGER" };
            var hiAdresSeviyesiRef = new[] { "IL", "ILCE", "MAHALLE" };
            var hiIlKoduRef = new[] { "006", "034", "035", "041" };
            foreach (var r in hiAdresTipiRef) await AddReferansKodIfNotExists("ADRES_TIPI", r, r, ct);
            foreach (var r in hiAdresSeviyesiRef) await AddReferansKodIfNotExists("ADRES_KODU_SEVIYESI", r, r, ct);
            foreach (var r in hiIlKoduRef) await AddReferansKodIfNotExists("IL_KODU", r, $"İl {r}", ct);
            await _db.SaveChangesAsync(ct);

            var items = basvurular.Take(25).Select((b, i) => new HASTA_ILETISIM
            {
                HASTA_ILETISIM_KODU = $"HI-{i + 1:D5}",
                HASTA_KODU = b.HASTA_KODU,
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                ADRES_TIPI = $"ADRES_TIPI_{hiAdresTipiRef[i % hiAdresTipiRef.Length]}",
                ADRES_KODU_SEVIYESI = $"ADRES_KODU_SEVIYESI_{hiAdresSeviyesiRef[i % hiAdresSeviyesiRef.Length]}",
                BEYAN_ADRESI = $"Test Mahallesi, Test Sokak No:{i + 1}",
                NVI_ADRES = $"Test Mahallesi, Test Caddesi No:{i + 1}",
                ADRES_NUMARASI = $"{_random.Next(1000000, 9999999)}",
                IL_KODU = $"IL_KODU_{hiIlKoduRef[i % hiIlKoduRef.Length]}",
                ILCE_KODU = $"ILCE_{_random.Next(100, 999)}",
                BUCAK_KODU = $"BCK_{_random.Next(100, 999)}",
                KOY_KODU = $"KOY_{_random.Next(100, 999)}",
                MAHALLE_KODU = $"MHL_{_random.Next(1000, 9999)}",
                CSBM_KODU = $"CSBM{_random.Next(100000, 999999)}",
                DIS_KAPI_NUMARASI = $"{_random.Next(1, 200)}",
                IC_KAPI_NUMARASI = $"{_random.Next(1, 50)}",
                EV_TELEFONU = $"0{_random.Next(212, 216)}{_random.Next(1000000, 9999999)}",
                CEP_TELEFONU = $"05{_random.Next(30, 59)}{_random.Next(1000000, 9999999)}",
                IS_TELEFONU = $"0{_random.Next(212, 216)}{_random.Next(1000000, 9999999)}",
                EPOSTA_ADRESI = $"hasta{i + 1}@test.com",
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<HASTA_ILETISIM>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} HASTA_ILETISIM records");
        }

        // HASTA_NOTLARI
        if (!await _db.Set<HASTA_NOTLARI>().AnyAsync(ct))
        {
            var items = basvurular.Take(25).Select((b, i) => new HASTA_NOTLARI
            {
                HASTA_NOTLARI_KODU = $"HN-{i + 1:D5}",
HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_KODU = b.HASTA_KODU,
                NOT_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                NOT_ICERIGI = $"Hasta notu {i + 1}: Tedavi süreci normal devam etmektedir.",
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<HASTA_NOTLARI>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} HASTA_NOTLARI records");
        }

        // HASTA_UYARI
        if (!await _db.Set<HASTA_UYARI>().AnyAsync(ct))
        {
            var uyariTipleri = new[] { "ALERJI", "KRONIK_HASTALIK", "ILAC_ETKILESIMI", "DIKKAT" };
            var items = hastalar.Take(25).Select((h, i) => new HASTA_UYARI
            {
                HASTA_UYARI_KODU = $"HU-{i + 1:D5}",
HASTA_KODU = h.HASTA_KODU,
                UYARI_TIPI = uyariTipleri[i % uyariTipleri.Length],
                UYARI_ACIKLAMASI = $"Uyarı: {uyariTipleri[i % uyariTipleri.Length]} - Dikkat edilmeli",
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<HASTA_UYARI>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} HASTA_UYARI records");
        }

        // HASTA_TIBBI_BILGI
        if (!await _db.Set<HASTA_TIBBI_BILGI>().AnyAsync(ct))
        {
            var items = hastalar.Take(25).Select((h, i) => new HASTA_TIBBI_BILGI
            {
                HASTA_TIBBI_BILGI_KODU = $"HTB-{i + 1:D5}",
HASTA_KODU = h.HASTA_KODU,
                KAN_GRUBU = new[] { "A+", "A-", "B+", "B-", "AB+", "AB-", "0+", "0-" }[i % 8],
                BOY = 160 + _random.Next(0, 30),
                KILO = 60 + _random.Next(0, 40),
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<HASTA_TIBBI_BILGI>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} HASTA_TIBBI_BILGI records");
        }

        // HASTA_EPIKRIZ
        if (!await _db.Set<HASTA_EPIKRIZ>().AnyAsync(ct))
        {
            var items = basvurular.Where(b => b.CIKIS_ZAMANI != null).Take(25).Select((b, i) => new HASTA_EPIKRIZ
            {
                HASTA_EPIKRIZ_KODU = $"HE-{i + 1:D5}",
HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_KODU = b.HASTA_KODU,
                EPIKRIZ_TARIHI = b.CIKIS_ZAMANI ?? DateTime.Now,
                EPIKRIZ_METNI = $"Epikriz {i + 1}: Hasta tedavisi tamamlanmış olup taburcu edilmiştir.",
                HAZIRLAYAN_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            if (items.Count < 20)
            {
                var eksik = basvurular.Take(25 - items.Count).Select((b, i) => new HASTA_EPIKRIZ
                {
                    HASTA_EPIKRIZ_KODU = $"HE-{items.Count + i + 1:D5}",
HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                    HASTA_KODU = b.HASTA_KODU,
                    EPIKRIZ_TARIHI = DateTime.Now,
                    EPIKRIZ_METNI = $"Epikriz: Hasta takibi devam etmektedir.",
                    HAZIRLAYAN_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                    EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                    KAYIT_ZAMANI = DateTime.Now
                });
                items.AddRange(eksik);
            }
            await _db.Set<HASTA_EPIKRIZ>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} HASTA_EPIKRIZ records");
        }

        // HASTA_VITAL_FIZIKI_BULGU
        if (!await _db.Set<HASTA_VITAL_FIZIKI_BULGU>().AnyAsync(ct))
        {
            var items = basvurular.Take(25).Select((b, i) => new HASTA_VITAL_FIZIKI_BULGU
            {
                HASTA_VITAL_FIZIKI_BULGU_KODU = $"HVF-{i + 1:D5}",
HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_KODU = b.HASTA_KODU,
                OLCUM_ZAMANI = b.HASTA_KABUL_ZAMANI.Value.AddMinutes(_random.Next(10, 60)),
                SISTOLIK_TANSIYON = 110 + _random.Next(0, 40),
                DIASTOLIK_TANSIYON = 70 + _random.Next(0, 20),
                NABIZ = 60 + _random.Next(0, 40),
                ATES = 36.0 + _random.NextDouble() * 2,
                SOLUNUM_SAYISI = 14 + _random.Next(0, 6),
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<HASTA_VITAL_FIZIKI_BULGU>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} HASTA_VITAL_FIZIKI_BULGU records");
        }

        // HASTA_SEVK
        if (!await _db.Set<HASTA_SEVK>().AnyAsync(ct))
        {
            var items = basvurular.Take(25).Select((b, i) => new HASTA_SEVK
            {
                HASTA_SEVK_KODU = $"HS-{i + 1:D5}",
HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_KODU = b.HASTA_KODU,
                SEVK_TARIHI = b.HASTA_KABUL_ZAMANI.Value.AddDays(_random.Next(1, 5)),
                SEVK_NEDENI = "İleri tetkik ve tedavi için sevk edilmiştir.",
                SEVK_EDEN_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<HASTA_SEVK>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} HASTA_SEVK records");
        }

        // HASTA_GIZLILIK
        if (!await _db.Set<HASTA_GIZLILIK>().AnyAsync(ct))
        {
            var items = hastalar.Take(25).Select((h, i) => new HASTA_GIZLILIK
            {
                HASTA_GIZLILIK_KODU = $"HG-{i + 1:D5}",
HASTA_KODU = h.HASTA_KODU,
                GIZLILIK_SEVIYESI = i % 3 == 0 ? "YUKSEK" : i % 3 == 1 ? "ORTA" : "NORMAL",
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<HASTA_GIZLILIK>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} HASTA_GIZLILIK records");
        }

        // KONSULTASYON
        if (!await _db.Set<KONSULTASYON>().AnyAsync(ct))
        {
            var items = basvurular.Take(25).Select((b, i) => new KONSULTASYON
            {
                KONSULTASYON_KODU = $"KNS-{i + 1:D5}",
HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_KODU = b.HASTA_KODU,
                ISTEK_TARIHI = b.HASTA_KABUL_ZAMANI.AddHours(_random.Next(1, 24)),
                ISTEYEN_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                KONSULTAN_HEKIM_KODU = personeller[(i + 1) % personeller.Count].PERSONEL_KODU,
                KONSULTASYON_DURUMU = i % 2 == 0 ? "TAMAMLANDI" : "BEKLIYOR",
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<KONSULTASYON>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} KONSULTASYON records");
        }

        // HEMSIRE_BAKIM
        if (!await _db.Set<HEMSIRE_BAKIM>().AnyAsync(ct))
        {
            var hemsireler = personeller.Where(p => p.UNVAN_KODU == "Hemşire").ToList();
            if (hemsireler.Any())
            {
                var items = basvurular.Take(25).Select((b, i) => new HEMSIRE_BAKIM
                {
                    HEMSIRE_BAKIM_KODU = $"HB-{i + 1:D5}",
HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                    HASTA_KODU = b.HASTA_KODU,
                    BAKIM_TARIHI = b.HASTA_KABUL_ZAMANI.AddHours(_random.Next(1, 48)),
                    HEMSIRE_KODU = hemsireler[i % hemsireler.Count].PERSONEL_KODU,
                    BAKIM_NOTU = $"Bakım notu {i + 1}: Hasta takibi yapıldı, vital bulgular normal.",
                    EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                    KAYIT_ZAMANI = DateTime.Now
                }).ToList();
                await _db.Set<HEMSIRE_BAKIM>().AddRangeAsync(items, ct);
                await _db.SaveChangesAsync(ct);
                _logger.LogInformation($"Seeded: {items.Count} HEMSIRE_BAKIM records");
            }
        }

        // KLINIK_SEYIR
        if (!await _db.Set<KLINIK_SEYIR>().AnyAsync(ct))
        {
            var items = basvurular.Take(25).Select((b, i) => new KLINIK_SEYIR
            {
                KLINIK_SEYIR_KODU = $"KS-{i + 1:D5}",
HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_KODU = b.HASTA_KODU,
                SEYIR_TARIHI = b.HASTA_KABUL_ZAMANI.AddHours(_random.Next(6, 72)),
                SEYIR_NOTU = $"Klinik seyir {i + 1}: Hasta durumu stabil, tedaviye yanıt olumlu.",
                YAZAN_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<KLINIK_SEYIR>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} KLINIK_SEYIR records");
        }

        // TIBBI_ORDER
        if (!await _db.Set<TIBBI_ORDER>().AnyAsync(ct))
        {
            var items = basvurular.Take(25).Select((b, i) => new TIBBI_ORDER
            {
                TIBBI_ORDER_KODU = $"TO-{i + 1:D5}",
HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_KODU = b.HASTA_KODU,
                ORDER_TARIHI = b.HASTA_KABUL_ZAMANI.Value.AddMinutes(_random.Next(30, 180)),
                ORDER_TURU = i % 3 == 0 ? "ILAC" : i % 3 == 1 ? "TETKIK" : "TEDAVI",
                ORDER_DURUMU = i % 2 == 0 ? "TAMAMLANDI" : "BEKLIYOR",
                YAZAN_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<TIBBI_ORDER>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} TIBBI_ORDER records");
        }

        // TIBBI_ORDER_DETAY
        if (!await _db.Set<TIBBI_ORDER_DETAY>().AnyAsync(ct))
        {
            var orders = await _db.Set<TIBBI_ORDER>().ToListAsync(ct);
            if (orders.Any())
            {
                var items = orders.Take(25).Select((o, i) => new TIBBI_ORDER_DETAY
                {
                    TIBBI_ORDER_DETAY_KODU = $"TOD-{i + 1:D5}",
TIBBI_ORDER_KODU = o.TIBBI_ORDER_KODU,
                    DETAY_ACIKLAMASI = $"Order detay {i + 1}: İşlem detayları",
                    MIKTAR = _random.Next(1, 10),
                    BIRIM = "ADET",
                    EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                    KAYIT_ZAMANI = DateTime.Now
                }).ToList();
                await _db.Set<TIBBI_ORDER_DETAY>().AddRangeAsync(items, ct);
                await _db.SaveChangesAsync(ct);
                _logger.LogInformation($"Seeded: {items.Count} TIBBI_ORDER_DETAY records");
            }
        }

        // DOKTOR_MESAJI
        if (!await _db.Set<DOKTOR_MESAJI>().AnyAsync(ct))
        {
            var items = basvurular.Take(25).Select((b, i) => new DOKTOR_MESAJI
            {
                DOKTOR_MESAJI_KODU = $"DM-{i + 1:D5}",
HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_KODU = b.HASTA_KODU,
                MESAJ_TARIHI = b.HASTA_KABUL_ZAMANI.AddHours(_random.Next(1, 24)),
                MESAJ_ICERIGI = $"Doktor mesajı {i + 1}: Hasta ile ilgili önemli not.",
                GONDEREN_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<DOKTOR_MESAJI>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} DOKTOR_MESAJI records");
        }

        // HASTA_MALZEME
        if (!await _db.Set<HASTA_MALZEME>().AnyAsync(ct))
        {
            var stokKartlar = await _db.Set<STOK_KART>().ToListAsync(ct);
            if (stokKartlar.Any())
            {
                var items = basvurular.Take(25).Select((b, i) => new HASTA_MALZEME
                {
                    HASTA_MALZEME_KODU = $"HM-{i + 1:D5}",
HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                    HASTA_KODU = b.HASTA_KODU,
                    STOK_KART_KODU = stokKartlar[i % stokKartlar.Count].STOK_KART_KODU,
                    MIKTAR = _random.Next(1, 5),
                    KULLANIM_TARIHI = b.HASTA_KABUL_ZAMANI.AddHours(_random.Next(1, 48)),
                    EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                    KAYIT_ZAMANI = DateTime.Now
                }).ToList();
                await _db.Set<HASTA_MALZEME>().AddRangeAsync(items, ct);
                await _db.SaveChangesAsync(ct);
                _logger.LogInformation($"Seeded: {items.Count} HASTA_MALZEME records");
            }
        }

        // HASTA_SEANS
        if (!await _db.Set<HASTA_SEANS>().AnyAsync(ct))
        {
            var items = basvurular.Take(25).Select((b, i) => new HASTA_SEANS
            {
                HASTA_SEANS_KODU = $"HSS-{i + 1:D5}",
HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_KODU = b.HASTA_KODU,
                SEANS_NO = i + 1,
                SEANS_TARIHI = b.HASTA_KABUL_ZAMANI.Value.AddDays(i),
                SEANS_DURUMU = i % 2 == 0 ? "TAMAMLANDI" : "PLANLANDI",
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<HASTA_SEANS>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} HASTA_SEANS records");
        }
    }

    private async Task SeedPersonelIliskiliAsync(List<PERSONEL> personeller, List<BIRIM> birimler, CancellationToken ct)
    {
        // PERSONEL_IZIN
        if (!await _db.Set<PERSONEL_IZIN>().AnyAsync(ct))
        {
            var items = personeller.Take(25).Select((p, i) => new PERSONEL_IZIN
            {
                PERSONEL_IZIN_KODU = $"PI-{i + 1:D5}",
PERSONEL_KODU = p.PERSONEL_KODU,
                IZIN_TURU = i % 3 == 0 ? "YILLIK" : i % 3 == 1 ? "MAZERET" : "HASTALIK",
                BASLANGIC_TARIHI = DateTime.Now.AddDays(-_random.Next(30, 180)),
                BITIS_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 29)),
                IZIN_GUN_SAYISI = _random.Next(1, 14),
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<PERSONEL_IZIN>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} PERSONEL_IZIN records");
        }

        // PERSONEL_EGITIM
        if (!await _db.Set<PERSONEL_EGITIM>().AnyAsync(ct))
        {
            var items = personeller.Take(25).Select((p, i) => new PERSONEL_EGITIM
            {
                PERSONEL_EGITIM_KODU = $"PE-{i + 1:D5}",
PERSONEL_KODU = p.PERSONEL_KODU,
                EGITIM_ADI = $"Hizmet İçi Eğitim {i + 1}",
                EGITIM_TARIHI = DateTime.Now.AddDays(-_random.Next(30, 365)),
                EGITIM_SURESI_SAAT = _random.Next(2, 40),
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<PERSONEL_EGITIM>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} PERSONEL_EGITIM records");
        }

        // PERSONEL_GOREVLENDIRME
        if (!await _db.Set<PERSONEL_GOREVLENDIRME>().AnyAsync(ct) && birimler.Any())
        {
            var items = personeller.Take(25).Select((p, i) => new PERSONEL_GOREVLENDIRME
            {
                PERSONEL_GOREVLENDIRME_KODU = $"PG-{i + 1:D5}",
PERSONEL_KODU = p.PERSONEL_KODU,
                CALISTIGI_BIRIM_KODU = birimler[i % birimler.Count].CALISTIGI_CALISTIGI_BIRIM_KODU,
                GOREV_BASLANGIC_TARIHI = DateTime.Now.AddDays(-_random.Next(30, 365)),
                GOREV_TURU = i % 2 == 0 ? "ASIL" : "GECICI",
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<PERSONEL_GOREVLENDIRME>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} PERSONEL_GOREVLENDIRME records");
        }

        // NOBETCI_PERSONEL_BILGISI
        if (!await _db.Set<NOBETCI_PERSONEL_BILGISI>().AnyAsync(ct) && birimler.Any())
        {
            var items = personeller.Take(25).Select((p, i) => new NOBETCI_PERSONEL_BILGISI
            {
                NOBETCI_PERSONEL_BILGISI_KODU = $"NPB-{i + 1:D5}",
                PERSONEL_KODU = p.PERSONEL_KODU,
                BIRIM_KODU = birimler[i % birimler.Count].CALISTIGI_BIRIM_KODU,
                NOBET_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                NOBET_TURU = i % 2 == 0 ? "GUNDUZ" : "GECE",
                SKRS_KURUM_KODU = "11111111",
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<NOBETCI_PERSONEL_BILGISI>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} NOBETCI_PERSONEL_BILGISI records");
        }
    }

    private async Task SeedKlinikIzlemAsync(List<HASTA> hastalar, List<HASTA_BASVURU> basvurular, List<PERSONEL> personeller, CancellationToken ct)
    {
        // GEBE_IZLEM
        if (!await _db.Set<GEBE_IZLEM>().AnyAsync(ct))
        {
            var kadinHastalar = hastalar.Where(h => h.CINSIYET == "CNS-K").Take(25).ToList();
            if (kadinHastalar.Count < 20) kadinHastalar = hastalar.Take(25).ToList();
            var items = kadinHastalar.Select((h, i) => new GEBE_IZLEM
            {
                GEBE_IZLEM_KODU = $"GI-{i + 1:D5}",
HASTA_KODU = h.HASTA_KODU,
                IZLEM_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 180)),
                GEBELIK_HAFTASI = _random.Next(4, 40),
                HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<GEBE_IZLEM>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} GEBE_IZLEM records");
        }

        // DIYABET
        if (!await _db.Set<DIYABET>().AnyAsync(ct))
        {
            var items = hastalar.Take(25).Select((h, i) => new DIYABET
            {
                DIYABET_KODU = $"DYB-{i + 1:D5}",
HASTA_KODU = h.HASTA_KODU,
                TANI_TARIHI = DateTime.Now.AddYears(-_random.Next(1, 10)),
                DIYABET_TIPI = i % 2 == 0 ? "TIP1" : "TIP2",
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<DIYABET>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} DIYABET records");
        }

        // ASI_BILGISI
        if (!await _db.Set<ASI_BILGISI>().AnyAsync(ct))
        {
            var asilar = new[] { "COVID-19", "GRIP", "HEPATIT-B", "TETANOS", "MMR" };
            var items = hastalar.Take(25).Select((h, i) => new ASI_BILGISI
            {
                ASI_BILGISI_KODU = $"ASI-{i + 1:D5}",
HASTA_KODU = h.HASTA_KODU,
                ASI_ADI = asilar[i % asilar.Length],
                ASI_TARIHI = DateTime.Now.AddDays(-_random.Next(30, 365)),
                DOZ_NO = _random.Next(1, 4),
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<ASI_BILGISI>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} ASI_BILGISI records");
        }

        // RADYOLOJI
        if (!await _db.Set<RADYOLOJI>().AnyAsync(ct))
        {
            var items = basvurular.Take(25).Select((b, i) => new RADYOLOJI
            {
                RADYOLOJI_KODU = $"RAD-{i + 1:D5}",
HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_KODU = b.HASTA_KODU,
                ISTEK_TARIHI = b.HASTA_KABUL_ZAMANI.AddHours(_random.Next(1, 24)),
                ISTEYEN_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                TETKIK_TURU = i % 4 == 0 ? "RONTGEN" : i % 4 == 1 ? "USG" : i % 4 == 2 ? "BT" : "MR",
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<RADYOLOJI>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} RADYOLOJI records");
        }

        // RADYOLOJI_SONUC
        if (!await _db.Set<RADYOLOJI_SONUC>().AnyAsync(ct))
        {
            var radyolojiler = await _db.Set<RADYOLOJI>().ToListAsync(ct);
            if (radyolojiler.Any())
            {
                var items = radyolojiler.Take(25).Select((r, i) => new RADYOLOJI_SONUC
                {
                    RADYOLOJI_SONUC_KODU = $"RADS-{i + 1:D5}",
RADYOLOJI_KODU = r.RADYOLOJI_KODU,
                    SONUC_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                    SONUC_RAPORU = $"Radyoloji sonuç raporu {i + 1}: Normal bulgular.",
                    RAPORLAYAN_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                    EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                    KAYIT_ZAMANI = DateTime.Now
                }).ToList();
                await _db.Set<RADYOLOJI_SONUC>().AddRangeAsync(items, ct);
                await _db.SaveChangesAsync(ct);
                _logger.LogInformation($"Seeded: {items.Count} RADYOLOJI_SONUC records");
            }
        }

        // PATOLOJI
        if (!await _db.Set<PATOLOJI>().AnyAsync(ct))
        {
            var items = basvurular.Take(25).Select((b, i) => new PATOLOJI
            {
                PATOLOJI_KODU = $"PAT-{i + 1:D5}",
HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_KODU = b.HASTA_KODU,
                NUMUNE_ALMA_TARIHI = b.HASTA_KABUL_ZAMANI.AddHours(_random.Next(1, 48)),
                NUMUNE_TURU = i % 3 == 0 ? "BIYOPSI" : i % 3 == 1 ? "SITOLOJI" : "FROZEN",
                RAPOR_TARIHI = b.HASTA_KABUL_ZAMANI.Value.AddDays(_random.Next(3, 14)),
                RAPOR_SONUCU = "Patolojik inceleme sonucu normal.",
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<PATOLOJI>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} PATOLOJI records");
        }
    }

    private async Task SeedKanBankasiAsync(List<HASTA> hastalar, List<PERSONEL> personeller, List<DEPO> depolar, CancellationToken ct)
    {
        // KAN_BAGISCI
        if (!await _db.Set<KAN_BAGISCI>().AnyAsync(ct))
        {
            var items = Enumerable.Range(1, 25).Select(i => new KAN_BAGISCI
            {
                KAN_BAGISCI_KODU = $"KB-{i:D5}",
TC_KIMLIK_NUMARASI = GenerateTcKimlik(),
                AD = $"Bağışçı{i}",
                SOYADI = $"Soyadı{i}",
                KAN_GRUBU = new[] { "A+", "A-", "B+", "B-", "AB+", "AB-", "0+", "0-" }[i % 8],
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<KAN_BAGISCI>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} KAN_BAGISCI records");
        }

        // KAN_STOK
        if (!await _db.Set<KAN_STOK>().AnyAsync(ct))
        {
            var kanUrunler = await _db.Set<KAN_URUN>().ToListAsync(ct);
            if (kanUrunler.Any() && depolar.Any())
            {
                var items = Enumerable.Range(1, 25).Select(i => new KAN_STOK
                {
                    KAN_STOK_KODU = $"KST-{i:D5}",
KAN_URUN_KODU = kanUrunler[i % kanUrunler.Count].KAN_URUN_KODU,
                    DEPO_KODU = depolar[i % depolar.Count].DEPO_KODU,
                    UNITE_NO = $"U{i:D6}",
                    KAN_GRUBU = new[] { "A+", "A-", "B+", "B-", "AB+", "AB-", "0+", "0-" }[i % 8],
                    MIKTAR = _random.Next(1, 10),
                    SON_KULLANMA_TARIHI = DateTime.Now.AddDays(_random.Next(7, 42)),
                    EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                    KAYIT_ZAMANI = DateTime.Now
                }).ToList();
                await _db.Set<KAN_STOK>().AddRangeAsync(items, ct);
                await _db.SaveChangesAsync(ct);
                _logger.LogInformation($"Seeded: {items.Count} KAN_STOK records");
            }
        }

        // KAN_TALEP
        if (!await _db.Set<KAN_TALEP>().AnyAsync(ct))
        {
            var items = hastalar.Take(25).Select((h, i) => new KAN_TALEP
            {
                KAN_TALEP_KODU = $"KT-{i + 1:D5}",
HASTA_KODU = h.HASTA_KODU,
                TALEP_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                TALEP_EDEN_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                KAN_GRUBU = new[] { "A+", "A-", "B+", "B-", "AB+", "AB-", "0+", "0-" }[i % 8],
                TALEP_DURUMU = i % 2 == 0 ? "KARSILANDI" : "BEKLIYOR",
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<KAN_TALEP>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} KAN_TALEP records");
        }
    }

    private async Task SeedKurulIliskiliAsync(List<KURUL> kurullar, List<HASTA> hastalar, List<HASTA_BASVURU> basvurular, List<PERSONEL> personeller, CancellationToken ct)
    {
        if (!kurullar.Any()) return;

        // KURUL_RAPOR
        if (!await _db.Set<KURUL_RAPOR>().AnyAsync(ct))
        {
            var items = hastalar.Take(25).Select((h, i) => new KURUL_RAPOR
            {
                KURUL_RAPOR_KODU = $"KR-{i + 1:D5}",
KURUL_KODU = kurullar[i % kurullar.Count].KURUL_KODU,
                HASTA_KODU = h.HASTA_KODU,
                RAPOR_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 90)),
                RAPOR_NO = $"RPR{DateTime.Now.Year}{i + 1:D4}",
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<KURUL_RAPOR>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} KURUL_RAPOR records");
        }

        // KURUL_HEKIM
        if (!await _db.Set<KURUL_HEKIM>().AnyAsync(ct))
        {
            var items = kurullar.SelectMany((k, ki) => personeller.Where(p => p.UNVAN_KODU != "Hemşire").Take(5).Select((p, pi) => new KURUL_HEKIM
            {
                KURUL_HEKIM_KODU = $"KH-{ki * 5 + pi + 1:D5}",
KURUL_KODU = k.KURUL_KODU,
                HEKIM_KODU = p.PERSONEL_KODU,
                GOREV = pi == 0 ? "BASKAN" : "UYE",
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            })).Take(25).ToList();
            await _db.Set<KURUL_HEKIM>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} KURUL_HEKIM records");
        }
    }

    private async Task SeedStokSterilizasyonAsync(List<DEPO> depolar, List<PERSONEL> personeller, CancellationToken ct)
    {
        // STOK_DURUM
        if (!await _db.Set<STOK_DURUM>().AnyAsync(ct))
        {
            var stokKartlar = await _db.Set<STOK_KART>().ToListAsync(ct);
            if (stokKartlar.Any() && depolar.Any())
            {
                var items = stokKartlar.Take(25).Select((sk, i) => new STOK_DURUM
                {
                    STOK_DURUM_KODU = $"SD-{i + 1:D5}",
STOK_KART_KODU = sk.STOK_KART_KODU,
                    DEPO_KODU = depolar[i % depolar.Count].DEPO_KODU,
                    MIKTAR = _random.Next(10, 500),
                    BIRIM_FIYAT = _random.Next(10, 1000),
                    EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                    KAYIT_ZAMANI = DateTime.Now
                }).ToList();
                await _db.Set<STOK_DURUM>().AddRangeAsync(items, ct);
                await _db.SaveChangesAsync(ct);
                _logger.LogInformation($"Seeded: {items.Count} STOK_DURUM records");
            }
        }

        // STOK_HAREKET
        if (!await _db.Set<STOK_HAREKET>().AnyAsync(ct))
        {
            var stokKartlar = await _db.Set<STOK_KART>().ToListAsync(ct);
            if (stokKartlar.Any() && depolar.Any())
            {
                var items = Enumerable.Range(1, 25).Select(i => new STOK_HAREKET
                {
                    STOK_HAREKET_KODU = $"SH-{i:D5}",
STOK_KART_KODU = stokKartlar[i % stokKartlar.Count].STOK_KART_KODU,
                    DEPO_KODU = depolar[i % depolar.Count].DEPO_KODU,
                    HAREKET_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 90)),
                    HAREKET_TURU = i % 2 == 0 ? "GIRIS" : "CIKIS",
                    MIKTAR = _random.Next(1, 50),
                    EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                    KAYIT_ZAMANI = DateTime.Now
                }).ToList();
                await _db.Set<STOK_HAREKET>().AddRangeAsync(items, ct);
                await _db.SaveChangesAsync(ct);
                _logger.LogInformation($"Seeded: {items.Count} STOK_HAREKET records");
            }
        }

        // STERILIZASYON_SET
        if (!await _db.Set<STERILIZASYON_SET>().AnyAsync(ct))
        {
            var items = Enumerable.Range(1, 25).Select(i => new STERILIZASYON_SET
            {
                STERILIZASYON_SET_KODU = $"SS-{i:D5}",
SET_ADI = $"Sterilizasyon Seti {i}",
                SET_TURU = i % 3 == 0 ? "CERRAHI" : i % 3 == 1 ? "ENDOSKOPI" : "GENEL",
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<STERILIZASYON_SET>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} STERILIZASYON_SET records");
        }

        // STERILIZASYON_GIRIS
        if (!await _db.Set<STERILIZASYON_GIRIS>().AnyAsync(ct))
        {
            var setler = await _db.Set<STERILIZASYON_SET>().ToListAsync(ct);
            if (setler.Any())
            {
                var items = Enumerable.Range(1, 25).Select(i => new STERILIZASYON_GIRIS
                {
                    STERILIZASYON_GIRIS_KODU = $"SG-{i:D5}",
STERILIZASYON_SET_KODU = setler[i % setler.Count].STERILIZASYON_SET_KODU,
                    GIRIS_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                    TESLIM_ALAN_PERSONEL_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                    EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                    KAYIT_ZAMANI = DateTime.Now
                }).ToList();
                await _db.Set<STERILIZASYON_GIRIS>().AddRangeAsync(items, ct);
                await _db.SaveChangesAsync(ct);
                _logger.LogInformation($"Seeded: {items.Count} STERILIZASYON_GIRIS records");
            }
        }

        // STERILIZASYON_CIKIS
        if (!await _db.Set<STERILIZASYON_CIKIS>().AnyAsync(ct))
        {
            var setler = await _db.Set<STERILIZASYON_SET>().ToListAsync(ct);
            if (setler.Any())
            {
                var items = Enumerable.Range(1, 25).Select(i => new STERILIZASYON_CIKIS
                {
                    STERILIZASYON_CIKIS_KODU = $"SC-{i:D5}",
STERILIZASYON_SET_KODU = setler[i % setler.Count].STERILIZASYON_SET_KODU,
                    CIKIS_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 15)),
                    TESLIM_EDEN_PERSONEL_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                    EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                    KAYIT_ZAMANI = DateTime.Now
                }).ToList();
                await _db.Set<STERILIZASYON_CIKIS>().AddRangeAsync(items, ct);
                await _db.SaveChangesAsync(ct);
                _logger.LogInformation($"Seeded: {items.Count} STERILIZASYON_CIKIS records");
            }
        }
    }

    private async Task SeedDigerTablolarAsync(List<HASTA> hastalar, List<HASTA_BASVURU> basvurular, List<PERSONEL> personeller, List<BIRIM> birimler, List<HIZMET> hizmetler, List<TETKIK> tetkikler, CancellationToken ct)
    {
        // VEZNE
        if (!await _db.Set<VEZNE>().AnyAsync(ct))
        {
            var items = Enumerable.Range(1, 25).Select(i => new VEZNE
            {
                VEZNE_KODU = $"VZN-{i:D5}",
VEZNE_ADI = $"Vezne {i}",
                VEZNE_TURU = i % 2 == 0 ? "ANA_VEZNE" : "BIRIM_VEZNE",
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<VEZNE>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} VEZNE records");
        }

        // VEZNE_DETAY
        if (!await _db.Set<VEZNE_DETAY>().AnyAsync(ct))
        {
            var vezneler = await _db.Set<VEZNE>().ToListAsync(ct);
            if (vezneler.Any())
            {
                var items = basvurular.Take(25).Select((b, i) => new VEZNE_DETAY
                {
                    VEZNE_DETAY_KODU = $"VD-{i + 1:D5}",
VEZNE_KODU = vezneler[i % vezneler.Count].VEZNE_KODU,
                    HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                    ISLEM_TARIHI = b.HASTA_KABUL_ZAMANI,
                    TUTAR = _random.Next(50, 1000),
                    ODEME_TURU = i % 3 == 0 ? "NAKIT" : i % 3 == 1 ? "KART" : "SGK",
                    EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                    KAYIT_ZAMANI = DateTime.Now
                }).ToList();
                await _db.Set<VEZNE_DETAY>().AddRangeAsync(items, ct);
                await _db.SaveChangesAsync(ct);
                _logger.LogInformation($"Seeded: {items.Count} VEZNE_DETAY records");
            }
        }

        // EK_ODEME
        if (!await _db.Set<EK_ODEME>().AnyAsync(ct))
        {
            var donemler = await _db.Set<EK_ODEME_DONEM>().ToListAsync(ct);
            if (donemler.Any())
            {
                var items = personeller.Take(25).Select((p, i) => new EK_ODEME
                {
                    EK_ODEME_KODU = $"EO-{i + 1:D5}",
PERSONEL_KODU = p.PERSONEL_KODU,
                    DONEM_KODU = donemler[i % donemler.Count].EK_ODEME_DONEM_KODU,
                    TOPLAM_PUAN = _random.Next(100, 1000),
                    EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                    KAYIT_ZAMANI = DateTime.Now
                }).ToList();
                await _db.Set<EK_ODEME>().AddRangeAsync(items, ct);
                await _db.SaveChangesAsync(ct);
                _logger.LogInformation($"Seeded: {items.Count} EK_ODEME records");
            }
        }

        // TETKIK_REFERANS_ARALIK
        if (!await _db.Set<TETKIK_REFERANS_ARALIK>().AnyAsync(ct) && tetkikler.Any())
        {
            var items = tetkikler.Take(25).Select((t, i) => new TETKIK_REFERANS_ARALIK
            {
                TETKIK_REFERANS_ARALIK_KODU = $"TRA-{i + 1:D5}",
TETKIK_KODU = t.TETKIK_KODU,
                CINSIYET = i % 2 == 0 ? "E" : "K",
                MIN_YAS = 0,
                MAX_YAS = 99,
                MIN_DEGER = _random.Next(0, 50).ToString(),
                MAX_DEGER = _random.Next(50, 200).ToString(),
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<TETKIK_REFERANS_ARALIK>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} TETKIK_REFERANS_ARALIK records");
        }

        // TETKIK_CIHAZ_ESLESME
        if (!await _db.Set<TETKIK_CIHAZ_ESLESME>().AnyAsync(ct))
        {
            var cihazlar = await _db.Set<CIHAZ>().ToListAsync(ct);
            if (tetkikler.Any() && cihazlar.Any())
            {
                var items = tetkikler.Take(25).Select((t, i) => new TETKIK_CIHAZ_ESLESME
                {
                    TETKIK_CIHAZ_ESLESME_KODU = $"TCE-{i + 1:D5}",
TETKIK_KODU = t.TETKIK_KODU,
                    CIHAZ_KODU = cihazlar[i % cihazlar.Count].CIHAZ_KODU,
                    EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                    KAYIT_ZAMANI = DateTime.Now
                }).ToList();
                await _db.Set<TETKIK_CIHAZ_ESLESME>().AddRangeAsync(items, ct);
                await _db.SaveChangesAsync(ct);
                _logger.LogInformation($"Seeded: {items.Count} TETKIK_CIHAZ_ESLESME records");
            }
        }

        // ANLIK_YATAN_HASTA
        if (!await _db.Set<ANLIK_YATAN_HASTA>().AnyAsync(ct))
        {
            var yataklar = await _db.Set<YATAK>().ToListAsync(ct);
            if (yataklar.Any())
            {
                var items = hastalar.Take(25).Select((h, i) => new ANLIK_YATAN_HASTA
                {
                    ANLIK_YATAN_HASTA_KODU = $"AYH-{i + 1:D5}",
HASTA_KODU = h.HASTA_KODU,
                    YATAK_KODU = yataklar[i % yataklar.Count].YATAK_KODU,
                    YATIS_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 14)),
                    EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                    KAYIT_ZAMANI = DateTime.Now
                }).ToList();
                await _db.Set<ANLIK_YATAN_HASTA>().AddRangeAsync(items, ct);
                await _db.SaveChangesAsync(ct);
                _logger.LogInformation($"Seeded: {items.Count} ANLIK_YATAN_HASTA records");
            }
        }

        // MEDULA_TAKIP
        if (!await _db.Set<MEDULA_TAKIP>().AnyAsync(ct))
        {
            var items = basvurular.Take(25).Select((b, i) => new MEDULA_TAKIP
            {
                MEDULA_TAKIP_KODU = $"MT-{i + 1:D5}",
HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                SYS_TAKIP_NUMARASI = $"T{DateTime.Now.Year}{_random.Next(100000, 999999)}",
                TAKIP_TARIHI = b.HASTA_KABUL_ZAMANI,
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<MEDULA_TAKIP>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} MEDULA_TAKIP records");
        }

        // RECETE_ILAC_ACIKLAMA
        if (!await _db.Set<RECETE_ILAC_ACIKLAMA>().AnyAsync(ct))
        {
            var receteIlaclar = await _db.Set<RECETE_ILAC>().ToListAsync(ct);
            if (receteIlaclar.Any())
            {
                var items = receteIlaclar.Take(25).Select((ri, i) => new RECETE_ILAC_ACIKLAMA
                {
                    RECETE_ILAC_ACIKLAMA_KODU = $"RIA-{i + 1:D5}",
RECETE_ILAC_KODU = ri.RECETE_ILAC_KODU,
                    ACIKLAMA = $"İlaç kullanım açıklaması {i + 1}",
                    EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                    KAYIT_ZAMANI = DateTime.Now
                }).ToList();
                await _db.Set<RECETE_ILAC_ACIKLAMA>().AddRangeAsync(items, ct);
                await _db.SaveChangesAsync(ct);
                _logger.LogInformation($"Seeded: {items.Count} RECETE_ILAC_ACIKLAMA records");
            }
        }

        // OPTIK_RECETE
        if (!await _db.Set<OPTIK_RECETE>().AnyAsync(ct))
        {
            var items = basvurular.Take(25).Select((b, i) => new OPTIK_RECETE
            {
                OPTIK_RECETE_KODU = $"OR-{i + 1:D5}",
HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_KODU = b.HASTA_KODU,
                RECETE_TARIHI = b.HASTA_KABUL_ZAMANI,
                YAZAN_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                SAG_SFERIK = (_random.NextDouble() * 6 - 3).ToString("F2"),
                SOL_SFERIK = (_random.NextDouble() * 6 - 3).ToString("F2"),
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<OPTIK_RECETE>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} OPTIK_RECETE records");
        }

        // ILAC_UYUM
        if (!await _db.Set<ILAC_UYUM>().AnyAsync(ct))
        {
            var items = hastalar.Take(25).Select((h, i) => new ILAC_UYUM
            {
                ILAC_UYUM_KODU = $"IU-{i + 1:D5}",
HASTA_KODU = h.HASTA_KODU,
                DEGERLENDIRME_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 90)),
                UYUM_DURUMU = i % 3 == 0 ? "IYI" : i % 3 == 1 ? "ORTA" : "KOTU",
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<ILAC_UYUM>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} ILAC_UYUM records");
        }

        // RISK_SKORLAMA
        if (!await _db.Set<RISK_SKORLAMA>().AnyAsync(ct))
        {
            var items = basvurular.Take(25).Select((b, i) => new RISK_SKORLAMA
            {
                RISK_SKORLAMA_KODU = $"RS-{i + 1:D5}",
HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_KODU = b.HASTA_KODU,
                SKORLAMA_TARIHI = b.HASTA_KABUL_ZAMANI,
                SKOR_TURU = i % 3 == 0 ? "DUSME" : i % 3 == 1 ? "BASINC_YARASI" : "BESLENME",
                SKOR_DEGERI = _random.Next(1, 10),
                EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<RISK_SKORLAMA>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} RISK_SKORLAMA records");
        }
    }
    #endif // LEVEL3_SEED_ENABLED

    // Yeni basitleştirilmiş Level 3 seeder - doğru entity yapılarıyla
    private async Task SeedLevel3SimplifiedAsync(CancellationToken ct)
    {
        _logger.LogInformation("Seeding Level 3 simplified tables...");

        var hastalar = await _db.Set<HASTA>().ToListAsync(ct);
        var basvurular = await _db.Set<HASTA_BASVURU>().ToListAsync(ct);
        var personeller = await _db.Set<PERSONEL>().ToListAsync(ct);
        var kurullar = await _db.Set<KURUL>().ToListAsync(ct);
        var hastaHizmetler = await _db.Set<HASTA_HIZMET>().ToListAsync(ct);
        var birimler = await _db.Set<BIRIM>().ToListAsync(ct);

        if (!hastalar.Any() || !basvurular.Any() || !personeller.Any())
        {
            _logger.LogWarning($"Level 3 dependency check: HASTA={hastalar.Count}, HASTA_BASVURU={basvurular.Count}, PERSONEL={personeller.Count}");

            // Eksik verileri yeniden seed et
            if (!hastalar.Any())
            {
                _logger.LogInformation("Re-seeding HASTA for Level 3...");
                await SeedHastalarAsync(ct);
                hastalar = await _db.Set<HASTA>().ToListAsync(ct);
            }
            if (!personeller.Any())
            {
                _logger.LogInformation("Re-seeding PERSONEL for Level 3...");
                await SeedPersonelAsync(ct);
                personeller = await _db.Set<PERSONEL>().ToListAsync(ct);
            }
            if (!basvurular.Any() && hastalar.Any() && personeller.Any())
            {
                _logger.LogInformation("Re-seeding HASTA_BASVURU for Level 3...");
                await SeedBasvurularAsync(ct);
                basvurular = await _db.Set<HASTA_BASVURU>().ToListAsync(ct);
            }

            // Hala eksik varsa atla
            if (!hastalar.Any() || !basvurular.Any() || !personeller.Any())
            {
                _logger.LogError($"Cannot proceed with Level 3 - still missing: HASTA={hastalar.Count}, HASTA_BASVURU={basvurular.Count}, PERSONEL={personeller.Count}");
                return;
            }
        }

        // HASTA_NOTLARI - sadece zorunlu alanlar
        await SeedIfEmpty<HASTA_NOTLARI>(ct, basvurular.Take(25).Select((b, i) => new HASTA_NOTLARI
        {
            HASTA_NOTLARI_KODU = $"HN-{i + 1:D5}",
HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            HASTA_NOT_TURU = i % 2 == 0 ? "GENEL" : "OZEL",
            PERSONEL_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
            HASTA_NOT_ACIKLAMASI = $"Hasta notu {i + 1}: Tedavi süreci devam ediyor."
        }).ToList());

        // HASTA_GIZLILIK
        var gizlilikNedenleri = new[] { "MAHKEME_KARARI", "HASTA_TALEBI", "VIP_HASTA", "GUVENDE_SAKLI", "DIGER" };
        var gizlilikTurleri = new[] { "TAM", "KISMI", "SINIRLI" };
        await SeedIfEmpty<HASTA_GIZLILIK>(ct, basvurular.Take(25).Select((b, i) => new HASTA_GIZLILIK
        {
            HASTA_GIZLILIK_KODU = $"HG-{i + 1:D5}",
HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            GORUNECEK_HASTA_ADI = $"Gizli{i + 1}",
            GORUNECEK_HASTA_SOYADI = $"Hasta{i + 1}",
            ACIKLAMA = "Hasta gizlilik kaydı",
            GIZLILIK_NEDENI = gizlilikNedenleri[i % gizlilikNedenleri.Length],
            GIZLILIK_TURU = gizlilikTurleri[i % gizlilikTurleri.Length],
            GIZLILIK_BASLAMA_ZAMANI = DateTime.Now.AddDays(-30),
            GIZLILIK_BITIS_ZAMANI = DateTime.Now.AddYears(1)
        }).ToList());

        // DOKTOR_MESAJI
        await SeedIfEmpty<DOKTOR_MESAJI>(ct, basvurular.Take(25).Select((b, i) => new DOKTOR_MESAJI
        {
            DOKTOR_MESAJI_KODU = $"DM-{i + 1:D5}",
HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            HASTA_MESAJLARI_TURU = "BILGI",
            MESAJ_DETAYI = $"Doktor mesajı {i + 1}: Hasta takibi hakkında bilgi.",
            MESAJ_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 30))
        }).ToList());

        // KURUL_RAPOR - kurullar varsa
        if (kurullar.Any())
        {
            await SeedIfEmpty<KURUL_RAPOR>(ct, hastalar.Take(25).Select((h, i) => new KURUL_RAPOR
            {
                KURUL_RAPOR_KODU = $"KR-{i + 1:D5}",
KURUL_KODU = kurullar[i % kurullar.Count].KURUL_KODU,
                HASTA_KODU = h.HASTA_KODU,
                HASTA_BASVURU_KODU = basvurular[i % basvurular.Count].HASTA_BASVURU_KODU,
                RAPOR_ADI = $"Sağlık Kurulu Raporu {i + 1}",
                RAPOR_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 60)),
                ACIKLAMA = $"Kurul raporu açıklaması {i + 1}",
                RAPOR_KARAR_NUMARASI = $"KN{DateTime.Now.Year}{i + 1:D4}",
                RAPOR_SIRA_NUMARASI = $"{i + 1}",
                RAPOR_TAKIP_NUMARASI = $"TN{DateTime.Now.Year}{i + 1:D6}",
                RAPOR_BASLAMA_TARIHI = DateTime.Now.AddDays(-30),
                RAPOR_BITIS_TARIHI = DateTime.Now.AddMonths(6),
                LABORATUVAR_BULGU = "Normal değerler içinde",
                KURUL_RAPOR_MUAYENE_BULGUSU = "Muayene bulguları normal",
                KURUL_TANI_BILGISI = "Tanı bilgisi",
                KURUL_RAPOR_KARARI = "OLUMLU",
                KARAR_ICERIK_FORMATI = "STANDART",
                KURUL_RAPOR_NUMARASI = $"KRN{DateTime.Now.Year}{i + 1:D6}",
                ENGELLILIK_ORANI = "0",
                ILAC_RAPOR_DUZELTME_ACIKLAMASI = "-",
                MURACAAT_DURUMU = "NORMAL"
            }).ToList());
        }

        // DIYABET
        var diyabetKomps = new[] { "YOK", "RETINOPATI", "NEFROPATI", "NOROPATI", "KAH", "AYAK_ULSERI", "COKLU" };
        var diyabetEgitims = new[] { "VERILDI", "VERILMEDI", "REDDETTI", "PLANLI" };
        await SeedIfEmpty<DIYABET>(ct, basvurular.Take(25).Select((b, i) => new DIYABET
        {
            DIYABET_KODU = $"DYB-{i + 1:D5}",
HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            ILK_TANI_TARIHI = DateTime.Now.AddYears(-_random.Next(1, 10)),
            AGIRLIK = (60 + _random.Next(0, 40)).ToString(),
            BOY = (160 + _random.Next(0, 30)).ToString(),
            DIYABET_EGITIMI = diyabetEgitims[i % diyabetEgitims.Length],
            DIYABET_KOMPLIKASYONLARI = diyabetKomps[i % diyabetKomps.Length]
        }).ToList());

        // HASTA_UYARI
        var uyariTurleri = new[] { "ALLERJI", "ILAC_ETKILESIMI", "KRITIK_DEGER", "OZEL_DURUM", "KRONIK" };
        await SeedIfEmpty<HASTA_UYARI>(ct, basvurular.Take(25).Select((b, i) => new HASTA_UYARI
        {
            HASTA_UYARI_KODU = $"HU-{i + 1:D5}",
HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            UYARI_TURU = uyariTurleri[i % uyariTurleri.Length],
            ISLEME_IZIN_VERME_DURUMU = "IZINLI",
            HASTA_UYARI_BASLAMA_ZAMANI = DateTime.Now.AddDays(-30),
            HASTA_UYARI_BITIS_ZAMANI = DateTime.Now.AddYears(1),
            ACIKLAMA = $"Hasta uyarı kaydı {i + 1}"
        }).ToList());

        // HASTA_TIBBI_BILGI
        var tibbiBilgiTurleri = new[] { "ANAMNEZ", "OZGECMIS", "SOYGECMIS", "ALISKANLIK", "ALLERJI_BILGISI" };
        var tibbiBilgiAltTurleri = new[] { "DETAY", "GENEL", "OZEL", "KRITIK" };
        await SeedIfEmpty<HASTA_TIBBI_BILGI>(ct, basvurular.Take(25).Select((b, i) => new HASTA_TIBBI_BILGI
        {
            HASTA_TIBBI_BILGI_KODU = $"HTB-{i + 1:D5}",
HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            TIBBI_BILGI_TURU = tibbiBilgiTurleri[i % tibbiBilgiTurleri.Length],
            TIBBI_BILGI_ALT_TURU = tibbiBilgiAltTurleri[i % tibbiBilgiAltTurleri.Length],
            ACIKLAMA = $"Tıbbi bilgi açıklaması {i + 1}: Hasta özgeçmişi ve soygeçmiş bilgileri."
        }).ToList());

        // HASTA_EPIKRIZ
        var epikrizBasliklari = new[] { "YATIS_EPIKRIZ", "CIKIS_EPIKRIZ", "GUNLUK_EPIKRIZ", "KONSULTASYON_EPIKRIZ" };
        await SeedIfEmpty<HASTA_EPIKRIZ>(ct, basvurular.Take(25).Select((b, i) => new HASTA_EPIKRIZ
        {
            HASTA_EPIKRIZ_KODU = $"HE-{i + 1:D5}",
HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            EPIKRIZ_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
            EPIKRIZ_BASLIK_BILGISI = epikrizBasliklari[i % epikrizBasliklari.Length],
            EPIKRIZ_BILGISI_ACIKLAMA = $"Epikriz {i + 1}: Hasta tedavi süreci ve öneriler.",
            HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU
        }).ToList());

        // HASTA_FOTOGRAF
        var fotografTurleri = new[] { "KIMLIK", "TIBBI", "YARA", "RADYOLOJI", "DIGER_FOTO" };
        await SeedIfEmpty<HASTA_FOTOGRAF>(ct, basvurular.Take(25).Select((b, i) => new HASTA_FOTOGRAF
        {
            HASTA_FOTOGRAF_KODU = $"HF-{i + 1:D5}",
HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            FOTOGRAF_TURU = fotografTurleri[i % fotografTurleri.Length],
            FOTOGRAF_BILGISI = $"Fotoğraf {i + 1}",
            FOTOGRAF_DOSYA_YOLU = $"/photos/hasta_{b.HASTA_KODU}/foto_{i + 1}.jpg",
            ACIKLAMA = $"Hasta fotoğrafı {i + 1}"
        }).ToList());

        // HASTA_HIZMET
        await SeedIfEmpty<HASTA_HIZMET>(ct, basvurular.Take(25).Select((b, i) => new HASTA_HIZMET
        {
            HASTA_HIZMET_KODU = $"HH-{i + 1:D5}",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            HASTA_HIZMET_DURUMU = "TAMAMLANDI",
            ISLEM_GERCEKLESME_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
            HIZMET_ADETI = 1,
            HASTA_TUTARI = _random.Next(10, 100),
            KURUM_TUTARI = _random.Next(100, 500),
            MEDULA_TAKIP_KODU = $"MTK{DateTime.Now.Year}{i + 1:D6}"
        }).ToList());

        // RANDEVU
        var randevuTurleri = new[] { "POLIKLINIK", "LABORATUVAR", "RADYOLOJI", "AMELIYAT", "FIZIK_TEDAVI" };
        var randevuGelme = new[] { "GELDI", "GELMEDI", "BEKLIYOR" };
        await SeedIfEmpty<RANDEVU>(ct, basvurular.Take(25).Select((b, i) => new RANDEVU
        {
            RANDEVU_KODU = $"RND-{i + 1:D5}",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            RANDEVU_TURU = randevuTurleri[i % randevuTurleri.Length],
            RANDEVU_ZAMANI = DateTime.Now.AddDays(_random.Next(1, 30)),
            RANDEVU_KAYIT_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 7)),
            RANDEVU_GELME_DURUMU = randevuGelme[i % randevuGelme.Length],
            AD = $"Hasta{i + 1}",
            SOYADI = $"Test{i + 1}",
            TELEFON_NUMARASI = $"05{_random.Next(100000000, 999999999)}"
        }).ToList());

        // KLINIK_SEYIR
        var seyirTipleri = new[] { "GUNLUK", "HAFTALIK", "TABURCULUK", "KONSULTASYON", "ACIL" };
        var septikSok = new[] { "HAYIR", "EVET", "SUPHELI" };
        var sepsisDurum = new[] { "YOK", "HAFIF", "ORTA", "AGIR", "KRITIK" };
        await SeedIfEmpty<KLINIK_SEYIR>(ct, basvurular.Take(25).Select((b, i) => new KLINIK_SEYIR
        {
            KLINIK_SEYIR_KODU = $"KS-{i + 1:D5}",
HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            SEYIR_TIPI = seyirTipleri[i % seyirTipleri.Length],
            SEYIR_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 10)),
            SEYIR_BILGISI = $"Hasta seyir bilgisi {i + 1}. Genel durumu iyi.",
            SEPTIK_SOK = septikSok[i % septikSok.Length],
            SEPSIS_DURUMU = sepsisDurum[i % sepsisDurum.Length],
            HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU
        }).ToList());

        // TIBBI_ORDER
        var orderTurleri = new[] { "ILAC", "TETKIK", "RADYOLOJI", "KONSULTASYON", "MALZEME" };
        await SeedIfEmpty<TIBBI_ORDER>(ct, basvurular.Take(25).Select((b, i) => new TIBBI_ORDER
        {
            TIBBI_ORDER_KODU = $"TO-{i + 1:D5}",
HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            TIBBI_ORDER_TURU = orderTurleri[i % orderTurleri.Length],
            ORDER_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 15)),
            HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
            ACIKLAMA = $"Tıbbi order açıklaması {i + 1}"
        }).ToList());

        // BASVURU_TANI
        var taniTurleri = new[] { "BIRINCIL", "IKINCIL", "ONERILEN" };
        await SeedIfEmpty<BASVURU_TANI>(ct, basvurular.Take(25).Select((b, i) => new BASVURU_TANI
        {
            BASVURU_TANI_KODU = $"BT-{i + 1:D5}",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            TANI_TURU = taniTurleri[i % taniTurleri.Length],
            BIRINCIL_TANI = i % 3 == 0 ? "EVET" : "HAYIR",
            TANI_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
            HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU
        }).ToList());

        // HEMSIRE_BAKIM - atlıyoruz çünkü HEMSIRELIK_TANI_KODU zorunlu FK ve referans kodu yok
        // Bu tablo için ayrı bir FK referans tablosu gerekiyor
        _logger.LogInformation("HEMSIRE_BAKIM skipped - requires HEMSIRELIK_TANI reference codes");

        // KONSULTASYON
        if (hastaHizmetler.Any())
        {
            var konsYerleri = new[] { "YATAK_BASI", "POLIKLINIK", "ACIL_SERVIS" };
            await SeedIfEmpty<KONSULTASYON>(ct, basvurular.Take(25).Select((b, i) => new KONSULTASYON
            {
                KONSULTASYON_KODU = $"KNS-{i + 1:D5}",
HASTA_KODU = b.HASTA_KODU,
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_HIZMET_KODU = hastaHizmetler[i % hastaHizmetler.Count].HASTA_HIZMET_KODU,
                KONSULTASYON_BASVURU_KODU = basvurular[(i + 1) % basvurular.Count].HASTA_BASVURU_KODU,
                KONSULTASYON_ISTEK_NOTU = $"Konsültasyon istek notu {i + 1}",
                KONSULTASYON_CEVAP_NOTU = $"Konsültasyon cevap notu {i + 1}",
                KONSULTASYONA_CAGRILMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 5)),
                KONSULTASYONA_GELIS_ZAMANI = DateTime.Now.AddDays(-_random.Next(0, 4)),
                KONSULTASYON_YERI = konsYerleri[i % konsYerleri.Length]
            }).ToList());
        }

        // HASTA_VITAL_FIZIKI_BULGU - Vital Bulgular
        var hemsireler = personeller.Where(p => p.UNVAN_KODU == "Hemşire").ToList();
        if (hemsireler.Any())
        {
            await SeedIfEmpty<HASTA_VITAL_FIZIKI_BULGU>(ct, basvurular.Take(25).Select((b, i) => new HASTA_VITAL_FIZIKI_BULGU
            {
                HASTA_VITAL_FIZIKI_BULGU_KODU = $"VFB-{i + 1:D5}",
HASTA_KODU = b.HASTA_KODU,
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                ISLEM_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 10)),
                SISTOLIK_KAN_BASINCI_DEGERI = (110 + _random.Next(0, 30)).ToString(),
                DIASTOLIK_KAN_BASINCI_DEGERI = (70 + _random.Next(0, 20)).ToString(),
                NABIZ = (60 + _random.Next(0, 40)).ToString(),
                SOLUNUM = (12 + _random.Next(0, 8)).ToString(),
                ATES = (36.0 + _random.NextDouble() * 2).ToString("F1"),
                BAS_CEVRESI = (50 + _random.Next(0, 10)).ToString(),
                BOY = (160 + _random.Next(0, 30)).ToString(),
                AGIRLIK = (60000 + _random.Next(0, 40000)).ToString(),
                SATURASYON = (95 + _random.Next(0, 5)).ToString(),
                BEL_CEVRESI = (70 + _random.Next(0, 30)).ToString(),
                KALCA_CEVRESI = (90 + _random.Next(0, 20)).ToString(),
                KOL_CEVRESI = (25 + _random.Next(0, 10)).ToString(),
                KARIN_CEVRESI = (80 + _random.Next(0, 30)).ToString(),
                HEMSIRE_KODU = hemsireler[i % hemsireler.Count].PERSONEL_KODU
            }).ToList());
        }

        // HASTA_BORC - Hasta Borç Bilgileri (çok basit tablo)
        await SeedIfEmpty<HASTA_BORC>(ct, basvurular.Take(25).Select((b, i) => new HASTA_BORC
        {
            HASTA_BORC_KODU = $"HB-{i + 1:D5}",
HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            TOPLAM_BORC = (_random.Next(100, 5000) * 100).ToString(),
            ODENEN_BORC = (_random.Next(0, 2500) * 100).ToString(),
            KALAN_BORC = (_random.Next(50, 2500) * 100).ToString()
        }).ToList());

        // FIRMA - Tedarikçi Firma Bilgileri
        var firmalar = new[]
        {
            ("Medikal Plus A.Ş.", "İstanbul", "Ali Yılmaz"),
            ("Saglik Depo Ltd.", "Ankara", "Mehmet Öz"),
            ("Tıbbi Malzeme San.", "İzmir", "Ayşe Kaya"),
            ("Farma Dağıtım A.Ş.", "Bursa", "Fatih Demir"),
            ("Medikal Trade Ltd.", "Antalya", "Zeynep Aydın"),
            ("Saglik Araç A.Ş.", "Konya", "Hüseyin Çelik"),
            ("Lab Malzeme Ltd.", "Adana", "Elif Şahin"),
            ("Cerrahi Set San.", "Mersin", "Murat Arslan"),
            ("Protez Medikal A.Ş.", "Kayseri", "Selin Yıldız"),
            ("Eczane Malzeme Ltd.", "Eskişehir", "Burak Özdemir"),
            ("Radyoloji Teknik A.Ş.", "Samsun", "Derya Kılıç"),
            ("Ortopedi Malzeme Ltd.", "Trabzon", "Ercan Güneş"),
            ("Kardiyoloji Ekipman A.Ş.", "Diyarbakır", "Sibel Acar"),
            ("Nöroloji Araç Ltd.", "Gaziantep", "Kemal Turan"),
            ("Oftalmoloji Malzeme A.Ş.", "Denizli", "Nur Erdem"),
            ("Dermatoloji Ürün Ltd.", "Manisa", "Orhan Yavuz"),
            ("Pediatri Malzeme A.Ş.", "Balıkesir", "Pınar Güler"),
            ("Onkoloji Araç Ltd.", "Malatya", "Rıza Koç"),
            ("Üroloji Malzeme A.Ş.", "Şanlıurfa", "Sema Çetin"),
            ("Diş Malzeme Ltd.", "Tekirdağ", "Tarık Yalçın"),
            ("KBB Ekipman A.Ş.", "Muğla", "Ümit Korkmaz"),
            ("Plastik Cerrahi Ltd.", "Aydın", "Vildan Şen"),
            ("Göğüs Cerrahisi A.Ş.", "Hatay", "Yasemin Bulut"),
            ("Beyin Cerrahisi Ltd.", "Zonguldak", "Zafer Kara"),
            ("Acil Tıp Malzeme A.Ş.", "Kocaeli", "Ahmet Polat")
        };
        await SeedIfEmpty<FIRMA>(ct, firmalar.Select((f, i) => new FIRMA
        {
            FIRMA_KODU = $"FRM-{i + 1:D5}",
            FIRMA_ADI = f.Item1,
            TELEFON_NUMARASI = $"0{_random.Next(200, 600)}{_random.Next(1000000, 9999999)}",
            YETKILI_KISI = f.Item3,
            FIRMA_ADRESI = $"{f.Item2} Merkez, Sanayi Cad. No:{i + 1}",
            AKTIFLIK_BILGISI = "AKTIF",
            VERGI_DAIRESI = $"{f.Item2} Vergi Dairesi",
            VERGI_NUMARASI = _random.Next(100000000, 999999999).ToString() + _random.Next(0, 9).ToString(),
            EPOSTA_ADRESI = $"info@{f.Item1.ToLower().Replace(" ", "").Replace(".", "").Replace("ş", "s").Replace("ı", "i").Replace("ö", "o").Replace("ü", "u").Replace("ğ", "g").Replace("ç", "c")}.com.tr",
            IBAN_NUMARASI = $"TR{_random.Next(10, 99)}{_random.Next(10000, 99999)}{_random.Next(10000, 99999)}{_random.Next(10000, 99999)}{_random.Next(10000, 99999)}{_random.Next(10, 99)}"
        }).ToList());

        // HASTA_ARSIV - Hasta Arşiv Bilgileri
        var arsivDefterTurleri = new[] { "POLIKLINIK", "YATAN", "ACIL", "AMELIYAT", "DOGUM" };
        await SeedIfEmpty<HASTA_ARSIV>(ct, hastalar.Take(25).Select((h, i) => new HASTA_ARSIV
        {
            HASTA_ARSIV_KODU = $"ARSV-{i + 1:D5}",
HASTA_KODU = h.HASTA_KODU,
            ARSIV_NUMARASI = $"ARN-{DateTime.Now.Year}-{i + 1:D6}",
            ESKI_ARSIV_NUMARASI = $"ESK-{DateTime.Now.Year - 5}-{i + 1:D6}",
            ARSIV_DEFTER_TURU = arsivDefterTurleri[i % arsivDefterTurleri.Length],
            ARSIV_YERI = $"A Blok / {(i / 5) + 1}. Kat / Oda-{(i % 5) + 1} / Raf-{(i % 10) + 1}",
            ACIKLAMA = $"Hasta arşiv dosyası {i + 1}",
            ARSIV_ILK_GIRIS_TARIHI = DateTime.Now.AddYears(-_random.Next(1, 10))
        }).ToList());

        // EK_ODEME - Personel Ek Ödeme Bilgileri
        var ekOdemeDonemler = await _db.Set<EK_ODEME_DONEM>().ToListAsync(ct);
        if (ekOdemeDonemler.Any())
        {
            await SeedIfEmpty<EK_ODEME>(ct, personeller.Take(25).Select((p, i) => new EK_ODEME
            {
                EK_ODEME_KODU = $"EKO-{i + 1:D5}",
EK_ODEME_DONEM_KODU = ekOdemeDonemler[i % ekOdemeDonemler.Count].EK_ODEME_DONEM_KODU,
                PERSONEL_KODU = p.PERSONEL_KODU,
                HESAPLAMA_YONTEMI = "STANDART",
                MAAS_DERECESI = (_random.Next(1, 10)).ToString(),
                MAAS_KADEMESI = (_random.Next(1, 4)).ToString(),
                MAAS_GOSTERGESI = (_random.Next(500, 3000)).ToString(),
                AYLIK_TUTARI = (_random.Next(15000, 50000) * 100).ToString(),
                OZEL_HIZMET_TUTARI = (_random.Next(1000, 5000) * 100).ToString(),
                EK_GOSTERGE_TUTARI = (_random.Next(500, 3000) * 100).ToString(),
                YAN_ODEME_TUTARI = (_random.Next(200, 1000) * 100).ToString(),
                DOGU_TAZMINATI_TUTARI = "0",
                EK_ODEME_MATRAHI = (_random.Next(20000, 60000) * 100).ToString(),
                BASKA_KURUMDAKI_EKODEME_TUTARI = "0",
                DSSO_TUTARI = (_random.Next(5000, 15000) * 100).ToString(),
                ENGELLILIK_INDIRIM_ORANI = "0",
                KOMISYON_EK_PUANI_ORANI = (_random.Next(0, 20)).ToString(),
                EK_PUAN_ORANI = (_random.Next(0, 30)).ToString(),
                BIRIM_PERFORMANS_KATSAYISI = (1.0 + _random.NextDouble()).ToString("F2")
            }).ToList());
        }

        // BASVURU_YEMEK - Yatan Hasta Yemek Bilgileri
        var yemekTurleri = new[] { "NORMAL", "DIYET", "DIYABET", "COCUK", "VEJETARYEN" };
        var yemekZamanlari = new[] { "KAHVALTI", "OGLE", "AKSAM", "ARA_OGUN" };
        await SeedIfEmpty<BASVURU_YEMEK>(ct, basvurular.Take(25).Select((b, i) => new BASVURU_YEMEK
        {
            BASVURU_YEMEK_KODU = $"BYM-{i + 1:D5}",
HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            YEMEK_TURU = yemekTurleri[i % yemekTurleri.Length],
            YEMEK_ZAMANI_TURU = yemekZamanlari[i % yemekZamanlari.Length],
            YEMEK_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 10)).AddHours(_random.Next(7, 20)),
            ACIKLAMA = $"Yemek servisi #{i + 1}"
        }).ToList());

        // HASTA_VENTILATOR - Ventilatör Kullanım Bilgileri
        var cihazlar = await _db.Set<CIHAZ>().Where(c => c.CIHAZ_ADI != null && c.CIHAZ_ADI.Contains("Vent")).ToListAsync(ct);
        if (!cihazlar.Any())
        {
            cihazlar = await _db.Set<CIHAZ>().Take(5).ToListAsync(ct);
        }
        if (cihazlar.Any())
        {
            var yogunBakimSeviyeler = new[] { "SEVIYE_1", "SEVIYE_2", "SEVIYE_3" };
            await SeedIfEmpty<HASTA_VENTILATOR>(ct, basvurular.Take(25).Select((b, i) => new HASTA_VENTILATOR
            {
                HASTA_VENTILATOR_KODU = $"HV-{i + 1:D5}",
HASTA_KODU = b.HASTA_KODU,
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                VENTILATOR_CIHAZ_KODU = cihazlar[i % cihazlar.Count].CIHAZ_KODU,
                YOGUN_BAKIM_SEVIYE_BILGISI = yogunBakimSeviyeler[i % yogunBakimSeviyeler.Length],
                VENTILATOR_BAGLAMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(3, 15)),
                VENTILATOR_AYRILMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(0, 2))
            }).ToList());
        }

        // KURUL_HEKIM ve KURUL_TESHIS atlandı - SISTEM_KODU ve TANI_KODU için özel REFERANS_KODLAR gerekiyor
        _logger.LogInformation("KURUL_HEKIM, KURUL_TESHIS skipped - requires complex reference codes");

        // ICMAL - Fatura İcmal Kayıtları
        var kurumlar = await _db.Set<KURUM>().ToListAsync(ct);
        await SeedIfEmpty<ICMAL>(ct, Enumerable.Range(1, 25).Select(i => new ICMAL
        {
            ICMAL_KODU = $"ICM-{i:D5}",
            ICMAL_DONEMI = $"{DateTime.Now.Year}-{(i % 12) + 1:D2}",
            ICMAL_NUMARASI = $"ICM-{DateTime.Now.Year}-{i:D6}",
            ICMAL_ADI = $"İcmal {i} - {DateTime.Now.Year}",
            KURUM_KODU = kurumlar.Any() ? kurumlar[i % kurumlar.Count].KURUM_KODU : null,
            ICMAL_ZAMANI = DateTime.Now.AddMonths(-_random.Next(1, 12)),
            ICMAL_TUTARI = _random.Next(50000, 500000) * 100m
        }).ToList());

        // FATURA - Hasta Fatura Kayıtları
        var icmaller = await _db.Set<ICMAL>().ToListAsync(ct);
        var faturaTurleri = new[] { "YATAN", "AYAKTAN", "ACIL", "GUNUBIRLIK" };
        await SeedIfEmpty<FATURA>(ct, basvurular.Take(25).Select((b, i) => new FATURA
        {
            FATURA_KODU = $"FAT-{i + 1:D5}",
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            HASTA_KODU = b.HASTA_KODU,
            FATURA_DONEMI = $"{DateTime.Now.Year}-{(i % 12) + 1:D2}",
            ICMAL_KODU = icmaller.Any() ? icmaller[i % icmaller.Count].ICMAL_KODU : null,
            FATURA_TURU = faturaTurleri[i % faturaTurleri.Length],
            FATURA_ADI = $"Fatura #{i + 1}",
            FATURA_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 60)),
            FATURA_TUTARI = _random.Next(100, 10000) * 100m,
            FATURA_NUMARASI = $"FTR-{DateTime.Now.Year}-{i + 1:D8}",
            MEDULA_TESLIM_NUMARASI = $"MTN-{_random.Next(100000, 999999)}",
            FATURA_KESILEN_KURUM_KODU = kurumlar.Any() ? kurumlar[i % kurumlar.Count].KURUM_KODU : null,
            BUTCE_KODU = $"BTK-{_random.Next(100, 999)}"
        }).ToList());

        // HASTA_YATAK - Hasta Yatak Kullanım Kayıtları
        var yataklar = await _db.Set<YATAK>().ToListAsync(ct);
        if (yataklar.Any())
        {
            await SeedIfEmpty<HASTA_YATAK>(ct, basvurular.Take(25).Select((b, i) => new HASTA_YATAK
            {
                HASTA_YATAK_KODU = $"HY-{i + 1:D5}",
                HASTA_KODU = b.HASTA_KODU,
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                YATAK_KODU = yataklar[i % yataklar.Count].YATAK_KODU,
                YATIS_BASLAMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                YATIS_BITIS_ZAMANI = DateTime.Now.AddDays(-_random.Next(0, 5))
            }).ToList());
        }

        // TETKIK_SONUC - Laboratuvar Tetkik Sonuçları
        var tetkikler = await _db.Set<TETKIK>().ToListAsync(ct);
        var tetkikNumuneler = await _db.Set<TETKIK_NUMUNE>().ToListAsync(ct);
        var tetkikParametreler = await _db.Set<TETKIK_PARAMETRE>().ToListAsync(ct);
        if (tetkikler.Any() && tetkikNumuneler.Any())
        {
            await SeedIfEmpty<TETKIK_SONUC>(ct, tetkikNumuneler.Take(25).Select((tn, i) => new TETKIK_SONUC
            {
                TETKIK_SONUC_KODU = $"TS-{i + 1:D5}",
                TETKIK_NUMUNE_KODU = tn.TETKIK_NUMUNE_KODU,
                TETKIK_PARAMETRE_KODU = tetkikParametreler.Any() ? tetkikParametreler[i % tetkikParametreler.Count].TETKIK_PARAMETRE_KODU : null,
                TETKIK_KODU = tetkikler[i % tetkikler.Count].TETKIK_KODU,
                TETKIK_ADI = $"Tetkik Sonucu {i + 1}",
                HASTA_HIZMET_KODU = hastaHizmetler.Any() ? hastaHizmetler[i % hastaHizmetler.Count].HASTA_HIZMET_KODU : null,
                TETKIK_SONUCU = $"{_random.Next(1, 200)}.{_random.Next(0, 99):D2}",
                SONUC_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 10)),
                TETKIK_SONUCU_BIRIMI = new[] { "mg/dL", "mmol/L", "U/L", "g/L", "%", "mL/min" }[i % 6],
                TETKIK_SONUCU_REFERANS_DEGERI = $"{_random.Next(0, 50)}-{_random.Next(100, 200)}",
                TETKIK_SONUC_ACIKLAMA = $"Tetkik sonuç açıklaması {i + 1}",
                ONAYLAYAN_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                TETKIK_UZMAN_ONAY_ZAMANI = DateTime.Now.AddDays(-_random.Next(0, 5))
            }).ToList());
        }

        // === KALAN 52 TABLO İÇİN SEEDERLAR ===

        // KURUM - Kurum Bilgileri (önce kurumları seed edelim, diğer tablolar için kullanacağız)
        var kurumlarMevcut = await _db.Set<KURUM>().ToListAsync(ct);
        if (!kurumlarMevcut.Any())
        {
            var kurumListesi = new[]
            {
                ("Sağlık Bakanlığı", "KAMU"), ("SGK", "KAMU"), ("Özel Sigorta A.Ş.", "OZEL"),
                ("Medipol Hastanesi", "OZEL"), ("Acıbadem Hastanesi", "OZEL"), ("Memorial Hastanesi", "OZEL"),
                ("Florence Nightingale", "OZEL"), ("Amerikan Hastanesi", "OZEL"), ("Liv Hospital", "OZEL"),
                ("Medical Park", "OZEL"), ("Medicana", "OZEL"), ("VM Medical Park", "OZEL"),
                ("Anadolu Sağlık Merkezi", "OZEL"), ("Koç Üniversitesi Hastanesi", "OZEL"),
                ("İstanbul Üniversitesi Tıp", "KAMU"), ("Hacettepe Hastanesi", "KAMU"),
                ("Ankara Üniversitesi Tıp", "KAMU"), ("Ege Üniversitesi Tıp", "KAMU"),
                ("Dokuz Eylül Tıp", "KAMU"), ("Çukurova Tıp", "KAMU"),
                ("Gazi Üniversitesi Tıp", "KAMU"), ("Marmara Tıp", "KAMU"),
                ("Cerrahpaşa Tıp", "KAMU"), ("İÜC Kardiyoloji", "KAMU"), ("GATA", "KAMU")
            };
            await SeedIfEmpty<KURUM>(ct, kurumListesi.Select((k, i) => new KURUM
            {
                KURUM_KODU = $"KRM-{i + 1:D5}",
                KURUM_ADI = k.Item1,
                HASTA_KURUM_TURU = k.Item2,
                KURUM_ADRESI = $"Merkez Mah. Sağlık Cad. No:{i + 1}",
            }).ToList());
            kurumlarMevcut = await _db.Set<KURUM>().ToListAsync(ct);
        }

        // Referans Kodları - Personel tabloları için
        var bordroTuruRef = new[] { "MAAS", "EK_ODEME", "IKRAMIYE", "FAZLA_MESAI", "NOBET", "PRIM" };
        var esCalismaDurumuRef = new[] { "CALISIYOR", "CALISMIYOR", "EMEKLI" };
        var izinTuruRef = new[] { "YILLIK", "SAGLIK", "DOGUM", "BABALIK", "UCRETSIZ", "MAZERET", "OLUM", "EVLILIK" };
        var ogrenimDurumuRef = new[] { "ILKOKUL", "ORTAOKUL", "LISE", "ONLISANS", "LISANS", "YUKSEK_LISANS", "DOKTORA" };
        var bankaRef = new[] { "ZIRAAT", "VAKIFBANK", "HALKBANK", "IS_BANKASI", "GARANTI", "AKBANK", "YAPI_KREDI", "QNB" };
        var dilRef = new[] { "INGILIZCE", "ALMANCA", "FRANSIZCA", "ARAPCA", "RUSCA", "ISPANYOLCA" };
        var sendikaRef = new[] { "TURK_SAGLIK_SEN", "SAGLIK_SEN", "BIRLIK_SAGLIK_SEN", "GENEL_SAGLIK_IS" };

        foreach (var t in bordroTuruRef)
            await AddReferansKodIfNotExists("BORDRO_TURU", t, t, ct);
        foreach (var t in esCalismaDurumuRef)
            await AddReferansKodIfNotExists("ES_CALISMA_DURUMU", t, t, ct);
        foreach (var t in izinTuruRef)
            await AddReferansKodIfNotExists("PERSONEL_IZIN_TURU", t, t, ct);
        foreach (var t in ogrenimDurumuRef)
            await AddReferansKodIfNotExists("OGRENIM_DURUMU", t, t, ct);
        foreach (var t in bankaRef)
            await AddReferansKodIfNotExists("BANKA", t, t, ct);
        foreach (var t in dilRef)
            await AddReferansKodIfNotExists("YABANCI_DIL_BILGISI", t, t, ct);
        foreach (var t in sendikaRef)
            await AddReferansKodIfNotExists("SENDIKA_BILGISI", t, t, ct);

        // Referans Kodları - Kan tabloları için
        var kanGrubuRef = new[] { "A_RH_POZITIF", "A_RH_NEGATIF", "B_RH_POZITIF", "B_RH_NEGATIF", "AB_RH_POZITIF", "AB_RH_NEGATIF", "O_RH_POZITIF", "O_RH_NEGATIF" };
        var kanRetNedeniRef = new[] { "STOK_YOK", "UYUMSUZ", "HASTA_DURUMU_DEGISTI", "HEKIM_KARARI", "TEKRAR_TEST" };
        var kanImhaNedeniRef = new[] { "SON_KULLANIM", "KONTAMINE", "BOZULMA", "UYUMSUZLUK", "ARIZALI_TORBA" };
        var crossMatchSonucuRef = new[] { "UYUMLU", "UYUMSUZ", "BELIRSIZ" };
        var crossMatchYontemiRef = new[] { "TUPTA_TEST", "JEL_SANTRIFUJ", "MIKROPLAK" };

        foreach (var t in kanGrubuRef)
            await AddReferansKodIfNotExists("KAN_GRUBU", t, t, ct);
        foreach (var t in kanRetNedeniRef)
            await AddReferansKodIfNotExists("KAN_TALEP_RET_NEDENI", t, t, ct);
        foreach (var t in kanImhaNedeniRef)
            await AddReferansKodIfNotExists("KAN_IMHA_NEDENI", t, t, ct);
        foreach (var t in crossMatchSonucuRef)
            await AddReferansKodIfNotExists("CROSS_MATCH_SONUCU", t, t, ct);
        foreach (var t in crossMatchYontemiRef)
            await AddReferansKodIfNotExists("CROSS_MATCH_CALISMA_YONTEMI", t, t, ct);

        // Referans Kodları - Sterilizasyon tabloları için
        var sterilYontemRef = new[] { "BUHAR", "ETILEN_OKSIT", "PLAZMA", "FORMALDEHIT", "KURU_HAVA" };
        var sterilGrupRef = new[] { "CERRAHI_SET", "PANSUMAN_SETI", "STERIL_MALZEME", "IMPLANT", "ORTOPEDI_SETI" };

        foreach (var t in sterilYontemRef)
            await AddReferansKodIfNotExists("STERILIZASYON_YONTEMI", t, t, ct);
        foreach (var t in sterilGrupRef)
            await AddReferansKodIfNotExists("STERILIZASYON_PAKET_GRUBU", t, t, ct);

        // Referans Kodları - Diğer tablolar için
        var komplikasyonRef = new[] { "YOK", "KANAMA", "ENFEKSIYON", "TROMBOZ", "SOLUNUM_YETMEZLIGI", "KARDIYAK_ARREST" };
        var kurulTuruRef = new[] { "SAGLIK_KURULU", "ENGELLI_KURULU", "ASKERI_KURUL", "MALULIYET_KURULU" };
        var sistemRef = new[] { "SINDIRIM", "SOLUNUM", "DOLASIM", "SINIR", "UROGENITAL", "ENDOKRIN" };

        foreach (var t in komplikasyonRef)
            await AddReferansKodIfNotExists("KOMPLIKASYON_TANISI", t, t, ct);
        foreach (var t in kurulTuruRef)
            await AddReferansKodIfNotExists("KURUL_TURU", t, t, ct);
        foreach (var t in sistemRef)
            await AddReferansKodIfNotExists("SISTEM_KODU", t, t, ct);

        await _db.SaveChangesAsync(ct);
        _logger.LogInformation("Additional reference codes added for remaining 52 tables");

        // === PERSONEL DETAY TABLOLARI ===

        // PERSONEL_BANKA - Personel Banka Bilgileri
        await SeedIfEmpty<PERSONEL_BANKA>(ct, personeller.Take(25).Select((p, i) => new PERSONEL_BANKA
        {
            PERSONEL_BANKA_KODU = $"PB-{i + 1:D5}",
            PERSONEL_KODU = p.PERSONEL_KODU,
            BANKA = $"BANKA_{bankaRef[i % bankaRef.Length]}",
            BORDRO_TURU = $"BORDRO_TURU_{bordroTuruRef[i % bordroTuruRef.Length]}",
            HESAP_NUMARASI = $"{_random.Next(1000000, 9999999)}{_random.Next(100, 999)}",
            SUBE_KODU = $"{_random.Next(100, 999)}",
            IBAN_NUMARASI = $"TR{_random.Next(10, 99)}{_random.Next(10000, 99999)}{_random.Next(10000, 99999)}{_random.Next(10000, 99999)}{_random.Next(10000, 99999)}{_random.Next(10, 99)}",
            HESAP_AKTIFLIK_BILGISI = "1",
            ACIKLAMA = $"Personel banka hesabı {i + 1}",
            EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
            KAYIT_ZAMANI = DateTime.Now
        }).ToList());

        // PERSONEL_OGRENIM - Personel Öğrenim Bilgileri
        var okullar = new[] { "İstanbul Üniversitesi", "Hacettepe Üniversitesi", "Ankara Üniversitesi", "Ege Üniversitesi", "Marmara Üniversitesi" };
        await SeedIfEmpty<PERSONEL_OGRENIM>(ct, personeller.Take(25).Select((p, i) => new PERSONEL_OGRENIM
        {
            PERSONEL_OGRENIM_KODU = $"PO-{i + 1:D5}",
PERSONEL_KODU = p.PERSONEL_KODU,
            OGRENIM_DURUMU = $"OGRENIM_DURUMU_{ogrenimDurumuRef[i % ogrenimDurumuRef.Length]}",
            OKUL_ADI = okullar[i % okullar.Length],
            OKULA_BASLANGIC_TARIHI = DateTime.Now.AddYears(-_random.Next(10, 25)),
            MEZUNIYET_TARIHI = DateTime.Now.AddYears(-_random.Next(1, 10)),
            BELGE_NUMARASI = $"DIP-{DateTime.Now.Year - _random.Next(1, 10)}-{_random.Next(10000, 99999)}",
            ONAYLAYAN_PERSONEL_KODU = personeller[0].PERSONEL_KODU
        }).ToList());

        // PERSONEL_IZIN - Personel İzin Bilgileri
        var kullanicilar = await _db.Set<KULLANICI>().Take(10).ToListAsync(ct);
        if (kullanicilar.Any())
        {
            await SeedIfEmpty<PERSONEL_IZIN>(ct, personeller.Take(25).Select((p, i) => new PERSONEL_IZIN
            {
                PERSONEL_IZIN_KODU = $"PIZ-{i + 1:D5}",
PERSONEL_KODU = p.PERSONEL_KODU,
                PERSONEL_IZIN_TURU = $"PERSONEL_IZIN_TURU_{izinTuruRef[i % izinTuruRef.Length]}",
                KULLANILAN_IZIN = (_random.Next(1, 15)).ToString(),
                GECEN_YILDAN_KULLANILAN_IZIN = (_random.Next(0, 5)).ToString(),
                AKTIF_YILDAN_KULLANILAN_IZIN = (_random.Next(1, 10)).ToString(),
                IZIN_BASLAMA_TARIHI = DateTime.Now.AddDays(-_random.Next(30, 60)),
                IZIN_BITIS_TARIHI = DateTime.Now.AddDays(-_random.Next(15, 29)),
                PERSONEL_IZIN_YILI = DateTime.Now.Year.ToString(),
                PERSONEL_DONUS_TARIHI = DateTime.Now.AddDays(-_random.Next(10, 14)),
                IZIN_ADRESI = $"İzin adresi {i + 1}, İstanbul",
                ACIKLAMA = $"Personel izin kaydı {i + 1}",
                SBYS_ENGELLENME_DURUMU = "HAYIR",
                SBYS_KULLANIM_ENGELLEME_ZAMANI = DateTime.Now,
                SBYS_ENGELLEYEN_KULLANICI_KODU = kullanicilar[i % kullanicilar.Count].KULLANICI_KODU,
                ONAYLAYAN_PERSONEL_KODU = personeller[0].PERSONEL_KODU
            }).ToList());
        }

        // PERSONEL_BORDRO - Personel Bordro Bilgileri (85 kolon)
        var firmaListesi = await _db.Set<FIRMA>().Take(5).ToListAsync(ct);
        if (firmaListesi.Any())
        {
            await SeedIfEmpty<PERSONEL_BORDRO>(ct, personeller.Take(25).Select((p, i) => new PERSONEL_BORDRO
            {
                PERSONEL_BORDRO_KODU = $"PBRD-{i + 1:D5}",
YIL = DateTime.Now.Year.ToString(),
                AY = DateTime.Now.Month.ToString("D2"),
                PERSONEL_KODU = p.PERSONEL_KODU,
                BORDRO_TURU = $"BORDRO_TURU_{bordroTuruRef[0]}",
                BORDRO_NUMARASI = $"BRD-{DateTime.Now.Year}-{i + 1:D6}",
                MAAS_DERECESI = (_random.Next(1, 10)).ToString(),
                MAAS_KADEMESI = (_random.Next(1, 4)).ToString(),
                MAAS_GOSTERGESI = (_random.Next(500, 3000)).ToString(),
                MAAS_EK_GOSTERGESI = (_random.Next(100, 1000)).ToString(),
                EMEKLI_DERECESI = (_random.Next(1, 10)).ToString(),
                EMEKLI_KADEMESI = (_random.Next(1, 4)).ToString(),
                EMEKLI_GOSTERGESI = (_random.Next(500, 3000)).ToString(),
                EMEKLI_EK_GOSTERGESI = (_random.Next(100, 1000)).ToString(),
                TABAN_AYLIK_TUTARI = (_random.Next(15000, 25000) * 100).ToString(),
                AYLIK_TUTARI = (_random.Next(20000, 50000) * 100).ToString(),
                KIDEM_TUTARI = (_random.Next(500, 2000) * 100).ToString(),
                EK_GOSTERGE_TUTARI = (_random.Next(500, 3000) * 100).ToString(),
                YAN_ODEME_TUTARI = (_random.Next(200, 1000) * 100).ToString(),
                OZEL_HIZMET_TUTARI = (_random.Next(1000, 5000) * 100).ToString(),
                AILE_YARDIMI_TUTARI = (_random.Next(500, 1500) * 100).ToString(),
                COCUK_YARDIMI_TUTARI = (_random.Next(200, 800) * 100).ToString(),
                COCUK_SAYISI_6_YAS_ALTI = _random.Next(0, 3).ToString(),
                COCUK_SAYISI_6_YAS_USTU = _random.Next(0, 3).ToString(),
                AGI_ESAS_COCUK_SAYISI = _random.Next(0, 4).ToString(),
                ES_CALISMA_DURUMU = $"ES_CALISMA_DURUMU_{esCalismaDurumuRef[i % esCalismaDurumuRef.Length]}",
                BES_FIRMA_KODU = firmaListesi[i % firmaListesi.Count].FIRMA_KODU,
                BES_ORANI = (_random.Next(3, 10)).ToString(),
                BES_KESINTI_TUTARI = (_random.Next(500, 2000) * 100).ToString(),
                YABANCI_DIL_TAZMINATI_TUTARI = (_random.Next(0, 500) * 100).ToString(),
                YABANCI_DIL_BILGISI = $"YABANCI_DIL_BILGISI_{dilRef[i % dilRef.Length]}",
                YABANCI_DIL_PUANI = (_random.Next(50, 100)).ToString(),
                SENDIKA_ODENEGI_TUTARI = (_random.Next(100, 500) * 100).ToString(),
                SENDIKA_BILGISI = $"SENDIKA_BILGISI_{sendikaRef[i % sendikaRef.Length]}",
                SENDIKA_SIRA_NUMARASI = (i + 1).ToString(),
                SENDIKA_KESINTI_ORANI = "1.5",
                SENDIKA_AIDATI_TUTARI = (_random.Next(50, 200) * 100).ToString(),
                DEVLET_EMEKLI_KESENEGI = (_random.Next(1000, 3000) * 100).ToString(),
                SAHIS_EMEKLI_KESENEGI = (_random.Next(500, 1500) * 100).ToString(),
                EMEKLI_KESENEGI_MATRAHI_TUTARI = (_random.Next(20000, 40000) * 100).ToString(),
                OZEL_SIGORTA_TUTARI = "0",
                VERGI_INDIRIMI_TUTARI = (_random.Next(100, 500) * 100).ToString(),
                DAMGA_VERGISI_TUTARI = (_random.Next(200, 800) * 100).ToString(),
                GELIR_VERGISI_TUTARI = (_random.Next(2000, 8000) * 100).ToString(),
                GELIR_VERGISI_MATRAHI_TUTARI = (_random.Next(25000, 50000) * 100).ToString(),
                KUMULATIF_GELIR_VERGISI_TUTARI = (_random.Next(10000, 50000) * 100).ToString(),
                ICRA_TUTARI = "0",
                NAFAKA_TUTARI = "0",
                YUZDE_YUZ_TUTARI = "0",
                DOGU_TAZMINATI_TUTARI = "0",
                SGK_SAHIS_TUTARI = (_random.Next(1000, 3000) * 100).ToString(),
                SGK_ISVEREN_TUTARI = (_random.Next(2000, 5000) * 100).ToString(),
                SGK_MATRAHI_TUTARI = (_random.Next(25000, 50000) * 100).ToString(),
                KEFALET_TUTARI = "0",
                SOZLESME_UCRETI_TUTARI = "0",
                LOJMAN_KESINTISI_TUTARI = "0",
                ASGARI_GECIM_INDIRIMI_TUTARI = (_random.Next(500, 1500) * 100).ToString(),
                ISSIZLIK_SAHIS_TUTARI = (_random.Next(200, 600) * 100).ToString(),
                ISSIZLIK_ISVEREN_TUTARI = (_random.Next(300, 800) * 100).ToString(),
                ISSIZLIK_PRIMI_MATRAHI_TUTARI = (_random.Next(20000, 40000) * 100).ToString(),
                MALULLUK_DEVLET_TUTARI = "0",
                MALULLUK_SAHIS_TUTARI = "0",
                GIYECEK_YARDIMI_TUTARI = (_random.Next(100, 500) * 100).ToString(),
                FARK_TAZMINATI_TUTARI = "0",
                HIZMET_ZAMMI_TUTARI = (_random.Next(100, 300) * 100).ToString(),
                VASITA_YARDIMI_TUTARI = "0",
                KIRA_YARDIMI_TUTARI = "0",
                YEMEK_YARDIMI_TUTARI = (_random.Next(500, 1500) * 100).ToString(),
                FAZLA_MESAI_TUTARI = (_random.Next(0, 2000) * 100).ToString(),
                NOBET_BIRIM_UCRET_TUTARI = (_random.Next(50, 150) * 100).ToString(),
                NOBET_BIRIM_UCRET_20_TUTARI = (_random.Next(60, 180) * 100).ToString(),
                NOBET_BIRIM_UCRET_50_TUTARI = (_random.Next(75, 225) * 100).ToString(),
                NOBET_SAATI = (_random.Next(0, 80)).ToString(),
                NOBET_20_SAATI = (_random.Next(0, 16)).ToString(),
                NOBET_50_SAATI = (_random.Next(0, 24)).ToString(),
                YEVMIYE_TUTARI = (_random.Next(500, 1500) * 100).ToString(),
                CALISMA_SAATI = "160",
                TAHAKKUK_TOPLAMI = (_random.Next(30000, 70000) * 100).ToString(),
                NET_TUTAR = (_random.Next(25000, 55000) * 100).ToString(),
                KESINTI_TOPLAMI = (_random.Next(5000, 15000) * 100).ToString()
            }).ToList());
        }

        _logger.LogInformation("Personel detail tables seeded (BANKA, OGRENIM, IZIN, BORDRO)");

        // === EK_ODEME_DETAY - Ek Ödeme Detay ===
        var ekOdemeler = await _db.Set<EK_ODEME>().ToListAsync(ct);
        // KLINIK_KODU için referans kodu ekle
        var klinikKodlari = new[] { "DAHILIYE", "CERRAHI", "KARDIYOLOJI", "PEDIATRI", "ORTOPEDI", "NOROLOJI", "PSIKIYATRI", "DERMATOLOJI" };
        foreach (var k in klinikKodlari)
            await AddReferansKodIfNotExists("KLINIK_KODU", k, k, ct);
        await _db.SaveChangesAsync(ct);

        if (ekOdemeler.Any())
        {
            await SeedIfEmpty<EK_ODEME_DETAY>(ct, ekOdemeler.Take(25).Select((e, i) => new EK_ODEME_DETAY
            {
                EK_ODEME_DETAY_KODU = $"EKOD-{i + 1:D5}",
EK_ODEME_KODU = e.EK_ODEME_KODU,
                GOREV_NUMARASI = $"GRV-{i + 1:D4}",
                KADRO_KODU = $"KDR-{_random.Next(100, 999)}",
                KADRO_KATSAYISI = (1.0 + _random.NextDouble()).ToString("F2"),
                GIRISIMSEL_ISLEM_PUANI = (_random.Next(50, 300)).ToString(),
                OZELLIKLI_ISLEM_PUANI = (_random.Next(100, 500)).ToString(),
                TAVAN_KATSAYISI = (0.5 + _random.NextDouble() * 0.5).ToString("F2"),
                CALISILAN_GUN_TOPLAMI = (_random.Next(20, 30)).ToString(),
                CALISILAN_SAAT_TOPLAMI = (_random.Next(160, 240)).ToString(),
                AKTIF_CALISILAN_GUN_KATSAYISI = (0.8 + _random.NextDouble() * 0.2).ToString("F2"),
                HASTANE_PUAN_ORTALAMASI = (_random.Next(100, 300)).ToString(),
                KLINIK_KODU = $"KLINIK_KODU_{klinikKodlari[i % klinikKodlari.Length]}",
                KLINIK_PUAN_ORTALAMASI = (_random.Next(80, 250)).ToString(),
                BRUT_PERFORMANS_PUANI = (_random.Next(500, 2000)).ToString(),
                EK_PERFORMANS_PUANI = (_random.Next(100, 500)).ToString(),
                NET_PERFORMANS_PUANI = (_random.Next(400, 1800)).ToString(),
                EGITICI_DESTEKLEME_PUANI = (_random.Next(50, 200)).ToString(),
                BILIMSEL_CALISMA_PUANI = (_random.Next(0, 100)).ToString(),
                SERBEST_MESLEK_KATSAYISI = "0"
            }).ToList());
        }

        // === HASTA_ARSIV_DETAY - Hasta Arşiv Detay ===
        var hastaArsivler = await _db.Set<HASTA_ARSIV>().ToListAsync(ct);
        var birimlerLokal = await _db.Set<BIRIM>().Take(10).ToListAsync(ct);
        if (hastaArsivler.Any() && kullanicilar.Any() && birimlerLokal.Any())
        {
            await SeedIfEmpty<HASTA_ARSIV_DETAY>(ct, hastaArsivler.Take(25).Select((a, i) => new HASTA_ARSIV_DETAY
            {
                HASTA_ARSIV_DETAY_KODU = $"ARSD-{i + 1:D5}",
                HASTA_ARSIV_KODU = a.HASTA_ARSIV_KODU,
                HASTA_KODU = hastalar[i % hastalar.Count].HASTA_KODU,
                HASTA_BASVURU_KODU = basvurular[i % basvurular.Count].HASTA_BASVURU_KODU,
                DOSYA_ALAN_BIRIM_KODU = birimlerLokal[i % birimlerLokal.Count].BIRIM_KODU,
                DOSYA_ALAN_PERSONEL_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                DOSYANIN_ALINDIGI_ZAMAN = DateTime.Now.AddDays(-_random.Next(1, 30)),
                DOSYA_VEREN_BIRIM_KODU = birimlerLokal[(i + 1) % birimlerLokal.Count].BIRIM_KODU,
                DOSYA_VEREN_KULLANICI_KODU = kullanicilar[i % kullanicilar.Count].KULLANICI_KODU,
                DOSYANIN_VERILDIGI_ZAMAN = DateTime.Now.AddDays(-_random.Next(31, 60)),
                ACIKLAMA = $"Arşiv dosya detayı {i + 1}"
            }).ToList());
        }

        // === DOGUM - Doğum Kayıtları ===
        var ameliyatlar = await _db.Set<AMELIYAT>().ToListAsync(ct);
        if (ameliyatlar.Any() && hemsireler.Any() && birimlerLokal.Any() && kullanicilar.Any())
        {
            await SeedIfEmpty<DOGUM>(ct, basvurular.Take(25).Select((b, i) => new DOGUM
            {
                DOGUM_KODU = $"DGM-{i + 1:D5}",
HASTA_KODU = b.HASTA_KODU,
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_HIZMET_KODU = hastaHizmetler.Any() ? hastaHizmetler[i % hastaHizmetler.Count].HASTA_HIZMET_KODU : null,
                AMELIYAT_KODU = ameliyatlar[i % ameliyatlar.Count].AMELIYAT_KODU,
                BABA_TC_KIMLIK_NUMARASI = GenerateTcKimlik(),
                KOMPLIKASYON_TANISI = $"KOMPLIKASYON_TANISI_{komplikasyonRef[i % komplikasyonRef.Length]}",
                DOGUM_NOTU = $"Doğum notu {i + 1}. Normal doğum gerçekleşti.",
                DOGUM_BASLAMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(30, 180)),
                DOGUM_BITIS_ZAMANI = DateTime.Now.AddDays(-_random.Next(30, 180)).AddHours(_random.Next(2, 12)),
                HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                EBE_KODU = hemsireler[i % hemsireler.Count].PERSONEL_KODU,
                BIRIM_KODU = birimlerLokal[i % birimlerLokal.Count].BIRIM_KODU,
                DEFTER_NUMARASI = $"DGDF-{DateTime.Now.Year}-{i + 1:D5}",
                GUNCELLEYEN_KULLANICI_KODU = kullanicilar[i % kullanicilar.Count].KULLANICI_KODU
            }).ToList());
        }

        // === KAN_TALEP_DETAY - Kan Talep Detay ===
        var kanTalepler = await _db.Set<KAN_TALEP>().ToListAsync(ct);
        var kanUrunler = await _db.Set<KAN_URUN>().ToListAsync(ct);
        if (kanTalepler.Any() && kanUrunler.Any() && kullanicilar.Any())
        {
            await SeedIfEmpty<KAN_TALEP_DETAY>(ct, kanTalepler.Take(25).Select((kt, i) => new KAN_TALEP_DETAY
            {
                KAN_TALEP_DETAY_KODU = $"KTD-{i + 1:D5}",
KAN_TALEP_KODU = kt.KAN_TALEP_KODU,
                KAN_URUN_KODU = kanUrunler[i % kanUrunler.Count].KAN_URUN_KODU,
                ISTENEN_KAN_GRUBU = $"KAN_GRUBU_{kanGrubuRef[i % kanGrubuRef.Length]}",
                RET_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                RET_EDEN_KULLANICI_KODU = kullanicilar[i % kullanicilar.Count].KULLANICI_KODU,
                KAN_TALEP_RET_NEDENI = $"KAN_TALEP_RET_NEDENI_{kanRetNedeniRef[i % kanRetNedeniRef.Length]}",
                KAN_TALEP_MIKTARI = (_random.Next(1, 5)).ToString(),
                KAN_HACIM = (_random.Next(250, 500)).ToString(),
                ACIKLAMA = $"Kan talep detayı {i + 1}",
                BUFFYCOAT_UZAKLASTIRMA_DURUMU = i % 2 == 0 ? "EVET" : "HAYIR",
                KAN_FILTRELEME_DURUMU = i % 3 == 0 ? "EVET" : "HAYIR",
                KAN_ISINLAMA_DURUMU = i % 4 == 0 ? "EVET" : "HAYIR",
                KAN_YIKAMA_DURUMU = i % 5 == 0 ? "EVET" : "HAYIR"
            }).ToList());
        }

        // === KAN_CIKIS - Kan Çıkış Kayıtları ===
        var kanTalepDetaylar = await _db.Set<KAN_TALEP_DETAY>().ToListAsync(ct);
        var kanStoklar_forCikis = await _db.Set<KAN_STOK>().Take(25).ToListAsync(ct);
        if (kanTalepDetaylar.Any() && kurumlarMevcut.Any() && kanStoklar_forCikis.Any())
        {
            await SeedIfEmpty<KAN_CIKIS>(ct, kanTalepDetaylar.Take(25).Select((ktd, i) => new KAN_CIKIS
            {
                KAN_CIKIS_KODU = $"KCK-{i + 1:D5}",
                KAN_TALEP_DETAY_KODU = ktd.KAN_TALEP_DETAY_KODU,
                HASTA_KODU = hastalar[i % hastalar.Count].HASTA_KODU,
                HASTA_BASVURU_KODU = basvurular[i % basvurular.Count].HASTA_BASVURU_KODU,
                KAN_STOK_KODU = kanStoklar_forCikis[i % kanStoklar_forCikis.Count].KAN_STOK_KODU,
                KURUM_KODU = kurumlarMevcut[i % kurumlarMevcut.Count].KURUM_KODU,
                KAN_CIKIS_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                REZERVE_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)).AddHours(-_random.Next(1, 24)),
                REZERVE_EDEN_KULLANICI_KODU = kullanicilar[i % kullanicilar.Count].KULLANICI_KODU,
                CROSS_MATCH_KULLANICI_KODU = kullanicilar[(i + 1) % kullanicilar.Count].KULLANICI_KODU,
                CROSS_MATCH_CALISMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)).AddHours(-_random.Next(1, 12)),
                CROSS_MATCH_CALISMA_YONTEMI = $"CROSS_MATCH_CALISMA_YONTEMI_{crossMatchYontemiRef[i % crossMatchYontemiRef.Length]}",
                CROSS_MATCH_SONUCU = $"CROSS_MATCH_SONUCU_{crossMatchSonucuRef[i % crossMatchSonucuRef.Length]}"
            }).ToList());
        }

        // === KAN_URUN_IMHA - Kan Ürünü İmha ===
        var kanStoklar = await _db.Set<KAN_STOK>().ToListAsync(ct);
        if (kanStoklar.Any())
        {
            await SeedIfEmpty<KAN_URUN_IMHA>(ct, kanStoklar.Take(25).Select((ks, i) => new KAN_URUN_IMHA
            {
                KAN_URUN_IMHA_KODU = $"KUI-{i + 1:D5}",
KAN_STOK_KODU = ks.KAN_STOK_KODU,
                KAN_IMHA_NEDENI = $"KAN_IMHA_NEDENI_{kanImhaNedeniRef[i % kanImhaNedeniRef.Length]}",
                KAN_IMHA_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 60)),
                KAN_IMHA_ONAYLAYAN_HEKIM = personeller[i % personeller.Count].PERSONEL_KODU,
                KAN_IMHA_ONAYLAYAN_TEKNISYEN = personeller[(i + 1) % personeller.Count].PERSONEL_KODU,
                KAN_IMHA_EDEN_PERSONEL_KODU = personeller[(i + 2) % personeller.Count].PERSONEL_KODU
            }).ToList());
        }

        _logger.LogInformation("Kan ve Doğum tabloları seeded");

        // === STERILIZASYON_PAKET - Sterilizasyon Paket ===
        await SeedIfEmpty<STERILIZASYON_PAKET>(ct, Enumerable.Range(1, 25).Select(i => new STERILIZASYON_PAKET
        {
            STERILIZASYON_PAKET_KODU = $"STP-{i:D5}",
STERILIZASYON_PAKET_ADI = $"Steril Paket {i}",
            PAKET_KODU = $"STR-PKT-{_random.Next(10000, 99999)}",
            ACIKLAMA = $"Sterilizasyon paketi açıklaması {i}",
            STERILIZASYON_YONTEMI = $"STERILIZASYON_YONTEMI_{sterilYontemRef[i % sterilYontemRef.Length]}",
            STERILIZASYON_PAKET_GRUBU = $"STERILIZASYON_PAKET_GRUBU_{sterilGrupRef[i % sterilGrupRef.Length]}",
            PAKET_RAF_OMRU_BITIS_GUN = (_random.Next(30, 180)).ToString()
        }).ToList());

        // === STERILIZASYON_SET_DETAY - Sterilizasyon Set Detay ===
        var sterilPaketler = await _db.Set<STERILIZASYON_PAKET>().ToListAsync(ct);
        var sterilSetler = await _db.Set<STERILIZASYON_SET>().ToListAsync(ct);
        var stokKartlar = await _db.Set<STOK_KART>().Take(10).ToListAsync(ct);
        if (sterilSetler.Any() && stokKartlar.Any())
        {
            await SeedIfEmpty<STERILIZASYON_SET_DETAY>(ct, sterilSetler.Take(25).Select((ss, i) => new STERILIZASYON_SET_DETAY
            {
                STERILIZASYON_SET_DETAY_KODU = $"STSD-{i + 1:D5}",
STERILIZASYON_SET_KODU = ss.STERILIZASYON_SET_KODU,
                STOK_KART_KODU = stokKartlar[i % stokKartlar.Count].STOK_KART_KODU,
                STERILIZASYON_MALZEME_MIKTARI = (_random.Next(1, 20)).ToString()
            }).ToList());
        }

        _logger.LogInformation("Sterilizasyon tabloları seeded");

        // === DIS_TAAHHUT - Diş Taahhüt ===
        // IL_KODU ve ILCE_KODU referans kodları
        var ilKodlari = new[] { "34", "06", "35", "16", "07", "01", "21", "33", "42", "31" }; // İstanbul, Ankara, İzmir, Bursa, Antalya...
        var ilceKodlari = new[] { "001", "002", "003", "004", "005", "006", "007", "008", "009", "010" };
        foreach (var il in ilKodlari)
            await AddReferansKodIfNotExists("IL_KODU", il, il, ct);
        foreach (var ilce in ilceKodlari)
            await AddReferansKodIfNotExists("ILCE_KODU", ilce, ilce, ct);
        await _db.SaveChangesAsync(ct);

        await SeedIfEmpty<DIS_TAAHHUT>(ct, basvurular.Take(25).Select((b, i) => new DIS_TAAHHUT
        {
            DIS_TAAHHUT_KODU = $"DTH-{i + 1:D5}",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
            DIS_TAAHHUT_NUMARASI = $"DTN-{DateTime.Now.Year}-{_random.Next(100000, 999999)}",
            SGK_TAKIP_NUMARASI = $"SGK-{_random.Next(100000000, 999999999)}",
            CADDE_SOKAK = $"Sağlık Caddesi No:{i + 1}",
            DIS_KAPI_NUMARASI = (_random.Next(1, 200)).ToString(),
            EPOSTA_ADRESI = $"hasta{i + 1}@email.com",
            IC_KAPI_NUMARASI = (_random.Next(1, 50)).ToString(),
            TELEFON_NUMARASI = $"05{_random.Next(100000000, 999999999)}",
            MEDULA_SONUC_KODU = "0000",
            MEDULA_SONUC_MESAJI = "İşlem başarılı",
            IPTAL_DURUMU = i % 10 == 0 ? "EVET" : "HAYIR",
            IL_KODU = $"IL_KODU_{ilKodlari[i % ilKodlari.Length]}",
            ILCE_KODU = $"ILCE_KODU_{ilceKodlari[i % ilceKodlari.Length]}"
        }).ToList());

        // === DISPROTEZ - Diş Protez ===
        // DISPROTEZ referans kodları
        var disprotezIsTuruRef = new[] { "TAM_PROTEZ", "BOLUMLU_PROTEZ", "IMPLANT_PROTEZ", "KOPRULU_PROTEZ", "KRON" };
        var disprotezIsTuruAltRef = new[] { "METAL_DESTEKLI", "ZIRKONYUM", "PORSELEN", "AKRILIK", "KOMPOZIT" };
        var rptSebebiRef = new[] { "KIRIK", "ASINMA", "RENK_DEGISIMI", "UYUMSUZLUK", "HASAR" };
        var disprotezKasikTuruRef = new[] { "UST_CENE", "ALT_CENE", "TAM_KASIK" };
        var disprotezRengiRef = new[] { "A1", "A2", "A3", "B1", "B2", "C1", "D2" };
        var disBoyutRef = new[] { "KUCUK", "NORMAL", "BUYUK" };

        foreach (var t in disprotezIsTuruRef)
            await AddReferansKodIfNotExists("DISPROTEZ_IS_TURU_KODU", t, t, ct);
        foreach (var t in disprotezIsTuruAltRef)
            await AddReferansKodIfNotExists("DISPROTEZ_IS_TURU_ALT_KODU", t, t, ct);
        foreach (var t in rptSebebiRef)
            await AddReferansKodIfNotExists("RPT_SEBEBI", t, t, ct);
        foreach (var t in disprotezKasikTuruRef)
            await AddReferansKodIfNotExists("DISPROTEZ_KASIK_TURU", t, t, ct);
        foreach (var t in disprotezRengiRef)
            await AddReferansKodIfNotExists("DISPROTEZ_RENGI", t, t, ct);
        foreach (var t in disBoyutRef)
            await AddReferansKodIfNotExists("DIS_BOYUT_BILGISI", t, t, ct);
        await _db.SaveChangesAsync(ct);

        await SeedIfEmpty<DISPROTEZ>(ct, basvurular.Take(25).Select((b, i) => new DISPROTEZ
        {
            DISPROTEZ_KODU = $"DPR-{i + 1:D5}",
HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            DISPROTEZ_BASLAMA_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 180)),
            TEKNISYEN_KODU = personeller[(i + 1) % personeller.Count].PERSONEL_KODU,
            HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
            BIRIM_KODU = birimlerLokal.Any() ? birimlerLokal[i % birimlerLokal.Count].BIRIM_KODU : null,
            DISPROTEZ_IS_TURU_KODU = $"DISPROTEZ_IS_TURU_KODU_{disprotezIsTuruRef[i % disprotezIsTuruRef.Length]}",
            DISPROTEZ_IS_TURU_ALT_KODU = $"DISPROTEZ_IS_TURU_ALT_KODU_{disprotezIsTuruAltRef[i % disprotezIsTuruAltRef.Length]}",
            PARCA_SAYISI = (_random.Next(1, 10)).ToString(),
            DISPROTEZ_AYAK_SAYISI = (_random.Next(1, 6)).ToString(),
            DISPROTEZ_GOVDE_SAYISI = (_random.Next(1, 4)).ToString(),
            ACIKLAMA = $"Diş protez kaydı {i + 1}",
            DISPROTEZ_BIRIM_KODU = birimlerLokal.Any() ? birimlerLokal[i % birimlerLokal.Count].BIRIM_KODU : null,
            RPT_SEBEBI = $"RPT_SEBEBI_{rptSebebiRef[i % rptSebebiRef.Length]}",
            RPT_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 90)),
            RPT_EDEN_PERSONEL_KODU = personeller[(i + 2) % personeller.Count].PERSONEL_KODU,
            BARKOD_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
            DISPROTEZ_KASIK_TURU = $"DISPROTEZ_KASIK_TURU_{disprotezKasikTuruRef[i % disprotezKasikTuruRef.Length]}",
            DISPROTEZ_RENGI = $"DISPROTEZ_RENGI_{disprotezRengiRef[i % disprotezRengiRef.Length]}",
            DIS_BOYUT_BILGISI = $"DIS_BOYUT_BILGISI_{disBoyutRef[i % disBoyutRef.Length]}",
            DISPROTEZ_ACIKLAMA = $"Diş protez açıklama {i + 1}"
        }).ToList());

        _logger.LogInformation("Diş tabloları seeded");

        // === GETAT - Geleneksel ve Tamamlayıcı Tıp ===
        var getatUygulamaBirimiRef = new[] { "AKUPUNKTUR", "FITOTERAPI", "HIPNOZ", "KUPA", "OZON", "SOLUCAN" };
        var komplikasyonTanisiRef = new[] { "K00", "K01", "K02", "K03", "K04", "K05" };
        var getatTedaviSonucuRef = new[] { "BASARILI", "KISMEN_BASARILI", "BASARISIZ", "DEVAM_EDIYOR" };
        var getatUygulamaTuruRef = new[] { "AKUPUNKTUR", "KUPA", "HACAMAT", "OZON_TEDAVISI", "FITOTERAPI", "MUZIK_TERAPI" };
        var getatUygulandigiDurumRef = new[] { "AGRI", "STRES", "DEPRESYON", "BAGIMLLIK", "KRONIK_HASTALIK" };
        var getatUygulamaBolgesiRef = new[] { "BAS", "BOYUN", "SIRT", "BEL", "BACAK", "KOL", "AYAK" };

        foreach (var r in getatUygulamaBirimiRef) await AddReferansKodIfNotExists("GETAT_UYGULAMA_BIRIMI", r, r, ct);
        foreach (var r in komplikasyonTanisiRef) await AddReferansKodIfNotExists("KOMPLIKASYON_TANISI", r, r, ct);
        foreach (var r in getatTedaviSonucuRef) await AddReferansKodIfNotExists("GETAT_TEDAVI_SONUCU", r, r, ct);
        foreach (var r in getatUygulamaTuruRef) await AddReferansKodIfNotExists("GETAT_UYGULAMA_TURU", r, r, ct);
        foreach (var r in getatUygulandigiDurumRef) await AddReferansKodIfNotExists("GETAT_UYGULANDIGI_DURUMLAR", r, r, ct);
        foreach (var r in getatUygulamaBolgesiRef) await AddReferansKodIfNotExists("GETAT_UYGULAMA_BOLGESI", r, r, ct);
        await _db.SaveChangesAsync(ct);

        await SeedIfEmpty<GETAT>(ct, basvurular.Take(25).Select((b, i) => new GETAT
        {
            GETAT_KODU = $"GTT-{i + 1:D5}",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            GETAT_UYGULAMA_BIRIMI = $"GETAT_UYGULAMA_BIRIMI_{getatUygulamaBirimiRef[i % getatUygulamaBirimiRef.Length]}",
            KOMPLIKASYON_TANISI = $"KOMPLIKASYON_TANISI_{komplikasyonTanisiRef[i % komplikasyonTanisiRef.Length]}",
            GETAT_TEDAVI_SONUCU = $"GETAT_TEDAVI_SONUCU_{getatTedaviSonucuRef[i % getatTedaviSonucuRef.Length]}",
            GETAT_UYGULAMA_TURU = $"GETAT_UYGULAMA_TURU_{getatUygulamaTuruRef[i % getatUygulamaTuruRef.Length]}",
            GETAT_UYGULANDIGI_DURUMLAR = $"GETAT_UYGULANDIGI_DURUMLAR_{getatUygulandigiDurumRef[i % getatUygulandigiDurumRef.Length]}",
            GETAT_UYGULAMA_BOLGESI = $"GETAT_UYGULAMA_BOLGESI_{getatUygulamaBolgesiRef[i % getatUygulamaBolgesiRef.Length]}",
            ACIKLAMA = $"GETAT kaydı - {getatUygulamaTuruRef[i % getatUygulamaTuruRef.Length]} uygulaması",
            EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
            KAYIT_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 90))
        }).ToList());

        _logger.LogInformation("GETAT seeded");

        // === MADDE_BAGIMLILIGI - Madde Bağımlılığı ===
        var bilgiAlinanKaynakRef = new[] { "HASTA_KENDISI", "AILE", "ARKADAS", "SAGLIK_KURULUSU", "ADLI_MAKAM" };
        var danismaTedaviDurumRef = new[] { "DEVAM_EDIYOR", "TAMAMLANDI", "YARIDA_BIRAKILDI", "BEKLEMEDE" };
        var ikameTedaviDurumRef = new[] { "UYGULANMADI", "METADON", "BUPRENORFIN", "DIGER" };
        var cezaeviOykusuRef = new[] { "HAYIR", "EVET_SURUYOR", "EVET_SONLANDI" };
        var sosyalYardimRef = new[] { "HAYIR", "EVET_DUZENLI", "EVET_DUZENSIZ" };
        var yasadigiBolgeRef = new[] { "KENTSEL", "KIRSAL", "YARIKENTSEL" };
        var yasamBicimiRef = new[] { "AILEYLE", "YALNIZ", "ARKADASLA", "EVSIZ", "BARINMA_EVI" };
        var cocuklarYasamaRef = new[] { "COCUK_YOK", "BIRLIKTE", "AYRI" };
        var enjeksiyonKullanimRef = new[] { "HICBIR_ZAMAN", "GECMISTE", "HALEN", "SON_1_AY" };
        var enjektorPaylasimRef = new[] { "HICBIR_ZAMAN", "NADIREN", "SIK_SIK", "HER_ZAMAN" };
        var testYapilmaRef = new[] { "YAPILMADI", "POZITIF", "NEGATIF", "BILINMIYOR" };
        var gorusmeSonucuRef = new[] { "YATAKLI_TEDAVI", "AYAKTAN_TEDAVI", "SEVK", "RANDEVU", "TEDAVI_RED" };
        var gonderenBirimRef = new[] { "KENDISI", "AILE", "HASTANE", "TRAFIK", "ADLI_MAKAM", "ASM" };
        var yasamOrtamiRef = new[] { "SABIT_IKAMET", "GECICI", "EVSIZ" };
        var bulasiciHastalikRef = new[] { "YOK", "HIV", "HCV", "HBV", "TUBERKULOZ", "BIRDEN_FAZLA" };
        var tedaviTipiRef = new[] { "AYAKTAN", "YATAKLI", "IKAME", "REHABILITASYON" };
        var esasMaddeRef = new[] { "ESRAR", "EROIN", "KOKAIN", "METAMFETAMIN", "EKSTAZI", "BONZAI", "ALKOL", "DIGER" };
        var digerMaddeRef = new[] { "ESRAR", "EROIN", "KOKAIN", "ALKOL", "SIGARA", "DIGER", "YOK" };

        foreach (var r in bilgiAlinanKaynakRef) await AddReferansKodIfNotExists("BILGI_ALINAN_KAYNAK", r, r, ct);
        foreach (var r in danismaTedaviDurumRef) await AddReferansKodIfNotExists("DANISMA_TEDAVI_HIZMET_DURUMU", r, r, ct);
        foreach (var r in ikameTedaviDurumRef) await AddReferansKodIfNotExists("IKAME_TEDAVI_DURUMU", r, r, ct);
        foreach (var r in cezaeviOykusuRef) await AddReferansKodIfNotExists("CEZAEVI_OYKUSU", r, r, ct);
        foreach (var r in sosyalYardimRef) await AddReferansKodIfNotExists("SOSYAL_YARDIM_ALMA_DURUMU", r, r, ct);
        foreach (var r in yasadigiBolgeRef) await AddReferansKodIfNotExists("YASADIGI_BOLGE", r, r, ct);
        foreach (var r in yasamBicimiRef) await AddReferansKodIfNotExists("YASAM_BICIMI", r, r, ct);
        foreach (var r in cocuklarYasamaRef) await AddReferansKodIfNotExists("COCUKLARIYLA_YASAMA_DURUMU", r, r, ct);
        foreach (var r in enjeksiyonKullanimRef) await AddReferansKodIfNotExists("ENJEKSIYON_ILE_MADDE_KULLANIMI", r, r, ct);
        foreach (var r in enjektorPaylasimRef) await AddReferansKodIfNotExists("ENJEKTOR_PAYLASIM_DURUMU", r, r, ct);
        foreach (var r in testYapilmaRef) await AddReferansKodIfNotExists("HIV_TEST_YAPILMA_DURUMU", r, r, ct);
        foreach (var r in testYapilmaRef) await AddReferansKodIfNotExists("HCV_TEST_YAPILMA_DURUMU", r, r, ct);
        foreach (var r in testYapilmaRef) await AddReferansKodIfNotExists("HBV_TEST_YAPILMA_DURUMU", r, r, ct);
        foreach (var r in gorusmeSonucuRef) await AddReferansKodIfNotExists("GORUSME_SONUCU", r, r, ct);
        foreach (var r in gonderenBirimRef) await AddReferansKodIfNotExists("GONDEREN_BIRIM", r, r, ct);
        foreach (var r in yasamOrtamiRef) await AddReferansKodIfNotExists("YASAM_ORTAMI", r, r, ct);
        foreach (var r in bulasiciHastalikRef) await AddReferansKodIfNotExists("BULASICI_HASTALIK_DURUMU", r, r, ct);
        foreach (var r in tedaviTipiRef) await AddReferansKodIfNotExists("BASLANAN_TEDAVI_TIPI_BILGISI", r, r, ct);
        foreach (var r in esasMaddeRef) await AddReferansKodIfNotExists("BIRINCIL_KULLANILAN_ESAS_MADDE", r, r, ct);
        foreach (var r in digerMaddeRef) await AddReferansKodIfNotExists("KULLANILAN_DIGER_MADDE", r, r, ct);
        await _db.SaveChangesAsync(ct);

        await SeedIfEmpty<MADDE_BAGIMLILIGI>(ct, basvurular.Take(25).Select((b, i) => new MADDE_BAGIMLILIGI
        {
            MADDE_BAGIMLILIGI_KODU = $"MDB-{i + 1:D5}",
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            BILGI_ALINAN_KAYNAK = $"BILGI_ALINAN_KAYNAK_{bilgiAlinanKaynakRef[i % bilgiAlinanKaynakRef.Length]}",
            DANISMA_TEDAVI_HIZMET_DURUMU = $"DANISMA_TEDAVI_HIZMET_DURUMU_{danismaTedaviDurumRef[i % danismaTedaviDurumRef.Length]}",
            DANISMA_TEDAVI_HIZMET_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 365)),
            IKAME_TEDAVI_DURUMU = $"IKAME_TEDAVI_DURUMU_{ikameTedaviDurumRef[i % ikameTedaviDurumRef.Length]}",
            SON_IKAME_TEDAVI_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 180)),
            CEZAEVI_OYKUSU = $"CEZAEVI_OYKUSU_{cezaeviOykusuRef[i % cezaeviOykusuRef.Length]}",
            SOSYAL_YARDIM_ALMA_DURUMU = $"SOSYAL_YARDIM_ALMA_DURUMU_{sosyalYardimRef[i % sosyalYardimRef.Length]}",
            YASADIGI_BOLGE = $"YASADIGI_BOLGE_{yasadigiBolgeRef[i % yasadigiBolgeRef.Length]}",
            YASAM_BICIMI = $"YASAM_BICIMI_{yasamBicimiRef[i % yasamBicimiRef.Length]}",
            COCUKLARIYLA_YASAMA_DURUMU = $"COCUKLARIYLA_YASAMA_DURUMU_{cocuklarYasamaRef[i % cocuklarYasamaRef.Length]}",
            ENJEKSIYON_ILE_MADDE_KULLANIMI = $"ENJEKSIYON_ILE_MADDE_KULLANIMI_{enjeksiyonKullanimRef[i % enjeksiyonKullanimRef.Length]}",
            ENJEKSIYON_ILK_KULLANIM_YASI = (_random.Next(15, 35)).ToString(),
            ENJEKTOR_PAYLASIM_DURUMU = $"ENJEKTOR_PAYLASIM_DURUMU_{enjektorPaylasimRef[i % enjektorPaylasimRef.Length]}",
            ILK_ENJEKTOR_PAYLASIM_YASI = (_random.Next(16, 40)).ToString(),
            HIV_TEST_YAPILMA_DURUMU = $"HIV_TEST_YAPILMA_DURUMU_{testYapilmaRef[i % testYapilmaRef.Length]}",
            HCV_TEST_YAPILMA_DURUMU = $"HCV_TEST_YAPILMA_DURUMU_{testYapilmaRef[(i + 1) % testYapilmaRef.Length]}",
            HBV_TEST_YAPILMA_DURUMU = $"HBV_TEST_YAPILMA_DURUMU_{testYapilmaRef[(i + 2) % testYapilmaRef.Length]}",
            GORUSME_SONUCU = $"GORUSME_SONUCU_{gorusmeSonucuRef[i % gorusmeSonucuRef.Length]}",
            GONDEREN_BIRIM = $"GONDEREN_BIRIM_{gonderenBirimRef[i % gonderenBirimRef.Length]}",
            YASAM_ORTAMI = $"YASAM_ORTAMI_{yasamOrtamiRef[i % yasamOrtamiRef.Length]}",
            BULASICI_HASTALIK_DURUMU = $"BULASICI_HASTALIK_DURUMU_{bulasiciHastalikRef[i % bulasiciHastalikRef.Length]}",
            BASLANAN_TEDAVI_TIPI_BILGISI = $"BASLANAN_TEDAVI_TIPI_BILGISI_{tedaviTipiRef[i % tedaviTipiRef.Length]}",
            BIRINCIL_KULLANILAN_ESAS_MADDE = $"BIRINCIL_KULLANILAN_ESAS_MADDE_{esasMaddeRef[i % esasMaddeRef.Length]}",
            KULLANILAN_DIGER_MADDE = $"KULLANILAN_DIGER_MADDE_{digerMaddeRef[i % digerMaddeRef.Length]}",
            EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
            KAYIT_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 180))
        }).ToList());

        _logger.LogInformation("MADDE_BAGIMLILIGI seeded");

        // === BILDIRIMI_ZORUNLU - Bildirimi Zorunlu Hastalıklar ===
        var bildirimTuruRef = new[] { "INTIHAR", "KUDUZ", "VEREM", "SIDDET", "ZEHIRLENME" };
        var evetHayirRef = new[] { "EVET", "HAYIR", "BILINMIYOR" };
        var intiharKrizTuruRef = new[] { "INTIHAR_GIRISIMI", "KRIZ" };
        var intiharGirisimNedeniRef = new[] { "AILE_SORUNLARI", "EKONOMIK", "SAGLIK", "ILISKI", "IS_KAYBI", "DIGER" };
        var intiharYontemiRef = new[] { "ILAC", "KESICI_ALET", "ASMA", "ATLAMA", "ATES_SILAHI", "DIGER" };
        var intiharSonucRef = new[] { "IYILESTI", "HASTANEDE", "SEVK", "OLUM" };
        var hayvanDurumRef = new[] { "CANLI", "OLU", "BILINMIYOR", "KAYIP" };
        var sahiplikDurumRef = new[] { "SAHIPLI", "SAHIPSIZ", "BARINAKTA" };
        var immunglobulinTuruRef = new[] { "AT_KAYNAKLI", "INSAN_KAYNAKLI" };
        var kategorizasyonRef = new[] { "KATEGORI_1", "KATEGORI_2", "KATEGORI_3" };
        var temasDeğerlendirmeRef = new[] { "TEMAS_VAR", "TEMAS_YOK", "SUPHELI" };
        var kuduzHayvanRef = new[] { "KOPEK", "KEDI", "YARASA", "TILKI", "DIGER" };
        var riskliTemasTipiRef = new[] { "ISIRMA", "TIRMALAMA", "TEMAS", "BESLEME" };
        var dgtUygulayanRef = new[] { "SAGLIK_PERSONELI", "AILE_UYESI", "HASTA_KENDISI" };
        var dgtYeriRef = new[] { "SAGLIK_KURULUSU", "EV", "IS_YERI" };
        var tedaviyeUyumRef = new[] { "TAM_UYUM", "KISMEN_UYUM", "UYUMSUZ" };
        var kulturSonucRef = new[] { "POZITIF", "NEGATIF", "BEKLEMEDE", "YAPILMADI" };
        var tuberkulinSonucRef = new[] { "POZITIF", "NEGATIF", "YAPILMADI" };
        var veremTedaviYontemRef = new[] { "DGT", "STANDART", "COKLU_ILAC_DIRENCI" };
        var veremOlguRef = new[] { "YENI_OLGU", "NUKS", "TEDAVI_BASARISIZLIGI", "TRANSFER" };
        var yaymaSonucRef = new[] { "POZITIF", "NEGATIF", "YAPILMADI" };
        var tutulumYeriRef = new[] { "AKCIGER", "LENF_NODU", "PLEVRA", "KEMIK", "DIGER" };
        var klinikOrnegiRef = new[] { "BALGAM", "BRONKOALVEOLER_LAVAJ", "BIYOPSI", "DIGER" };
        var veremIlacRef = new[] { "IZONIAZID", "RIFAMPISIN", "ETAMBUTOL", "PIRAZINAMID", "STREPTOMISIN" };
        var veremTedaviSonucRef = new[] { "KUR", "TEDAVI_TAMAMLAMA", "TEDAVI_BASARISIZLIGI", "OLUM", "KAYIP" };
        var vakaTipiRef = new[] { "KESIN", "OLASI", "SUPHELI" };
        var siddetTuruRef = new[] { "FIZIKSEL", "CINSEL", "DUYGUSAL", "EKONOMIK", "IHMAL" };
        var siddetSonucRef = new[] { "HAFIF_YARALANMA", "AGIR_YARALANMA", "OLUM", "BELIRTI_YOK" };

        foreach (var r in bildirimTuruRef) await AddReferansKodIfNotExists("BILDIRIM_TURU", r, r, ct);
        foreach (var r in evetHayirRef) await AddReferansKodIfNotExists("AILESINDE_INTIHAR_GIRISIMI", r, r, ct);
        foreach (var r in evetHayirRef) await AddReferansKodIfNotExists("AILESINDE_PSIKIYATRIK_VAKA", r, r, ct);
        foreach (var r in intiharKrizTuruRef) await AddReferansKodIfNotExists("INTIHAR_KRIZ_VAKA_TURU", r, r, ct);
        foreach (var r in evetHayirRef) await AddReferansKodIfNotExists("PSIKIYATRIK_TEDAVI_GECMISI", r, r, ct);
        foreach (var r in intiharGirisimNedeniRef) await AddReferansKodIfNotExists("INTIHAR_GIRISIM_KRIZ_NEDENLERI", r, r, ct);
        foreach (var r in intiharYontemiRef) await AddReferansKodIfNotExists("INTIHAR_GIRISIMI_YONTEMI", r, r, ct);
        foreach (var r in evetHayirRef) await AddReferansKodIfNotExists("INTIHAR_GIRISIMI_GECMISI", r, r, ct);
        foreach (var r in intiharSonucRef) await AddReferansKodIfNotExists("INTIHAR_KRIZ_VAKA_SONUCU", r, r, ct);
        foreach (var r in evetHayirRef) await AddReferansKodIfNotExists("PSIKIYATRIK_TANI_GECMISI", r, r, ct);
        foreach (var r in hayvanDurumRef) await AddReferansKodIfNotExists("HAYVANIN_MEVCUT_DURUMU", r, r, ct);
        foreach (var r in sahiplikDurumRef) await AddReferansKodIfNotExists("HAYVANIN_SAHIPLIK_DURUMU", r, r, ct);
        foreach (var r in immunglobulinTuruRef) await AddReferansKodIfNotExists("IMMUNGLOBULIN_TURU", r, r, ct);
        foreach (var r in kategorizasyonRef) await AddReferansKodIfNotExists("KATEGORIZASYON", r, r, ct);
        foreach (var r in temasDeğerlendirmeRef) await AddReferansKodIfNotExists("TEMAS_DEGERLENDIRME_DURUMU", r, r, ct);
        foreach (var r in kuduzHayvanRef) await AddReferansKodIfNotExists("KUDUZ_SEBEP_OLAN_HAYVAN", r, r, ct);
        foreach (var r in riskliTemasTipiRef) await AddReferansKodIfNotExists("RISKLI_TEMAS_TIPI", r, r, ct);
        foreach (var r in dgtUygulayanRef) await AddReferansKodIfNotExists("DGT_UYGULAMASINI_YAPAN_KISI", r, r, ct);
        foreach (var r in dgtYeriRef) await AddReferansKodIfNotExists("DGT_UYGULAMA_YERI", r, r, ct);
        foreach (var r in tedaviyeUyumRef) await AddReferansKodIfNotExists("HASTANIN_TEDAVIYE_UYUMU", r, r, ct);
        foreach (var r in kulturSonucRef) await AddReferansKodIfNotExists("KULTUR_SONUCU", r, r, ct);
        foreach (var r in tuberkulinSonucRef) await AddReferansKodIfNotExists("TUBERKULIN_DERI_TESTI_SONUCU", r, r, ct);
        foreach (var r in veremTedaviYontemRef) await AddReferansKodIfNotExists("VEREM_HASTASI_TEDAVI_YONTEMI", r, r, ct);
        foreach (var r in veremOlguRef) await AddReferansKodIfNotExists("VEREM_OLGU_TANIMI", r, r, ct);
        foreach (var r in yaymaSonucRef) await AddReferansKodIfNotExists("YAYMA_SONUCU", r, r, ct);
        foreach (var r in tutulumYeriRef) await AddReferansKodIfNotExists("VEREM_HASTALIGI_TUTULUM_YERI", r, r, ct);
        foreach (var r in klinikOrnegiRef) await AddReferansKodIfNotExists("VEREM_HASTASI_KLINIK_ORNEGI", r, r, ct);
        foreach (var r in veremIlacRef) await AddReferansKodIfNotExists("VEREM_ILAC_ADI", r, r, ct);
        foreach (var r in veremTedaviSonucRef) await AddReferansKodIfNotExists("VEREM_TEDAVI_SONUCU", r, r, ct);
        foreach (var r in vakaTipiRef) await AddReferansKodIfNotExists("BULASICI_HASTALIK_VAKA_TIPI", r, r, ct);
        foreach (var r in siddetTuruRef) await AddReferansKodIfNotExists("SIDDET_TURU", r, r, ct);
        foreach (var r in siddetSonucRef) await AddReferansKodIfNotExists("SIDDET_DEGERLENDIRME_SONUCU", r, r, ct);
        await _db.SaveChangesAsync(ct);

        var bdz_ilKodlari = new[] { "006", "034", "035", "041", "026", "016" };
        var bdz_ilceKodlari = new[] { "001", "002", "003", "004", "005" };
        var bdz_icd10Kodlar = new[] { "J06.9", "K29.7", "I10", "E11.9", "J45.9", "M54.5", "R51", "N39.0" };
        foreach (var il in bdz_ilKodlari) await AddReferansKodIfNotExists("IL_KODU", il, $"İl {il}", ct);
        foreach (var ilce in bdz_ilceKodlari) await AddReferansKodIfNotExists("ILCE_KODU", ilce, $"İlçe {ilce}", ct);
        await _db.SaveChangesAsync(ct);

        var bdz_kurumlar = await _db.Set<KURUM>().ToListAsync(ct);
        await SeedIfEmpty<BILDIRIMI_ZORUNLU>(ct, basvurular.Take(25).Select((b, i) => new BILDIRIMI_ZORUNLU
        {
            BILDIRIMI_ZORUNLU_KODU = $"BDZ-{i + 1:D5}",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            BILDIRIM_TURU = $"BILDIRIM_TURU_{bildirimTuruRef[i % bildirimTuruRef.Length]}",
            BILDIRIM_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 60)),
            TANI_KODU = bdz_icd10Kodlar[i % bdz_icd10Kodlar.Length],
            AILESINDE_INTIHAR_GIRISIMI = $"AILESINDE_INTIHAR_GIRISIMI_{evetHayirRef[i % evetHayirRef.Length]}",
            AILESINDE_PSIKIYATRIK_VAKA = $"AILESINDE_PSIKIYATRIK_VAKA_{evetHayirRef[(i + 1) % evetHayirRef.Length]}",
            INTIHAR_KRIZ_VAKA_TURU = $"INTIHAR_KRIZ_VAKA_TURU_{intiharKrizTuruRef[i % intiharKrizTuruRef.Length]}",
            OLAY_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
            PSIKIYATRIK_TEDAVI_GECMISI = $"PSIKIYATRIK_TEDAVI_GECMISI_{evetHayirRef[i % evetHayirRef.Length]}",
            INTIHAR_GIRISIM_KRIZ_NEDENLERI = $"INTIHAR_GIRISIM_KRIZ_NEDENLERI_{intiharGirisimNedeniRef[i % intiharGirisimNedeniRef.Length]}",
            INTIHAR_GIRISIMI_YONTEMI = $"INTIHAR_GIRISIMI_YONTEMI_{intiharYontemiRef[i % intiharYontemiRef.Length]}",
            INTIHAR_GIRISIMI_GECMISI = $"INTIHAR_GIRISIMI_GECMISI_{evetHayirRef[i % evetHayirRef.Length]}",
            INTIHAR_KRIZ_VAKA_SONUCU = $"INTIHAR_KRIZ_VAKA_SONUCU_{intiharSonucRef[i % intiharSonucRef.Length]}",
            PSIKIYATRIK_TANI_GECMISI = $"PSIKIYATRIK_TANI_GECMISI_{evetHayirRef[i % evetHayirRef.Length]}",
            HAYVANIN_MEVCUT_DURUMU = $"HAYVANIN_MEVCUT_DURUMU_{hayvanDurumRef[i % hayvanDurumRef.Length]}",
            HAYVANIN_SAHIPLIK_DURUMU = $"HAYVANIN_SAHIPLIK_DURUMU_{sahiplikDurumRef[i % sahiplikDurumRef.Length]}",
            IMMUNGLOBULIN_TURU = $"IMMUNGLOBULIN_TURU_{immunglobulinTuruRef[i % immunglobulinTuruRef.Length]}",
            IMMUNGLOBULIN_MIKTARI = (_random.Next(100, 1000)).ToString(),
            KATEGORIZASYON = $"KATEGORIZASYON_{kategorizasyonRef[i % kategorizasyonRef.Length]}",
            TEMAS_DEGERLENDIRME_DURUMU = $"TEMAS_DEGERLENDIRME_DURUMU_{temasDeğerlendirmeRef[i % temasDeğerlendirmeRef.Length]}",
            KUDUZ_SEBEP_OLAN_HAYVAN = $"KUDUZ_SEBEP_OLAN_HAYVAN_{kuduzHayvanRef[i % kuduzHayvanRef.Length]}",
            YAPTIRACAGINI_BEYAN_ETTIGI_TSM = bdz_kurumlar.Any() ? bdz_kurumlar[i % bdz_kurumlar.Count].KURUM_KODU : null,
            RISKLI_TEMAS_TIPI = $"RISKLI_TEMAS_TIPI_{riskliTemasTipiRef[i % riskliTemasTipiRef.Length]}",
            EV_TELEFONU = $"0312{_random.Next(1000000, 9999999)}",
            CEP_TELEFONU = $"05{_random.Next(100000000, 999999999)}",
            EV_ADRESI = $"Örnek Mahallesi {i + 1}. Sokak No:{_random.Next(1, 50)}",
            IL_KODU = $"IL_KODU_{ilKodlari[i % ilKodlari.Length]}",
            ILCE_KODU = $"ILCE_KODU_{ilceKodlari[i % ilceKodlari.Length]}",
            BCG_SKAR_SAYISI = (_random.Next(0, 3)).ToString(),
            DGT_UYGULAMASINI_YAPAN_KISI = $"DGT_UYGULAMASINI_YAPAN_KISI_{dgtUygulayanRef[i % dgtUygulayanRef.Length]}",
            DGT_UYGULAMA_YERI = $"DGT_UYGULAMA_YERI_{dgtYeriRef[i % dgtYeriRef.Length]}",
            HASTANIN_TEDAVIYE_UYUMU = $"HASTANIN_TEDAVIYE_UYUMU_{tedaviyeUyumRef[i % tedaviyeUyumRef.Length]}",
            KULTUR_SONUCU = $"KULTUR_SONUCU_{kulturSonucRef[i % kulturSonucRef.Length]}",
            TUBERKULIN_DERI_TESTI_SONUCU = $"TUBERKULIN_DERI_TESTI_SONUCU_{tuberkulinSonucRef[i % tuberkulinSonucRef.Length]}",
            VEREM_HASTASI_TEDAVI_YONTEMI = $"VEREM_HASTASI_TEDAVI_YONTEMI_{veremTedaviYontemRef[i % veremTedaviYontemRef.Length]}",
            VEREM_OLGU_TANIMI = $"VEREM_OLGU_TANIMI_{veremOlguRef[i % veremOlguRef.Length]}",
            YAYMA_SONUCU = $"YAYMA_SONUCU_{yaymaSonucRef[i % yaymaSonucRef.Length]}",
            VEREM_HASTALIGI_TUTULUM_YERI = $"VEREM_HASTALIGI_TUTULUM_YERI_{tutulumYeriRef[i % tutulumYeriRef.Length]}",
            VEREM_HASTASI_KLINIK_ORNEGI = $"VEREM_HASTASI_KLINIK_ORNEGI_{klinikOrnegiRef[i % klinikOrnegiRef.Length]}",
            VEREM_ILAC_ADI = $"VEREM_ILAC_ADI_{veremIlacRef[i % veremIlacRef.Length]}",
            VEREM_TEDAVI_SONUCU = $"VEREM_TEDAVI_SONUCU_{veremTedaviSonucRef[i % veremTedaviSonucRef.Length]}",
            BULASICI_HASTALIK_VAKA_TIPI = $"BULASICI_HASTALIK_VAKA_TIPI_{vakaTipiRef[i % vakaTipiRef.Length]}",
            BELIRTILERIN_BASLADIGI_TARIH = DateTime.Now.AddDays(-_random.Next(1, 14)),
            SIDDET_TURU = $"SIDDET_TURU_{siddetTuruRef[i % siddetTuruRef.Length]}",
            SIDDET_DEGERLENDIRME_SONUCU = $"SIDDET_DEGERLENDIRME_SONUCU_{siddetSonucRef[i % siddetSonucRef.Length]}",
            ACIKLAMA = $"Bildirimi zorunlu hastalık kaydı {i + 1}",
            EKLEYEN_KULLANICI_KODU = AdminKullaniciKodu,
            KAYIT_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 90))
        }).ToList());

        _logger.LogInformation("BILDIRIMI_ZORUNLU seeded");

        // === KURUL_ENGELLI - Engelli Kurul ===
        var kurulRaporlar = await _db.Set<KURUL_RAPOR>().ToListAsync(ct);
        if (kurulRaporlar.Any())
        {
            await SeedIfEmpty<KURUL_ENGELLI>(ct, kurulRaporlar.Take(25).Select((kr, i) => new KURUL_ENGELLI
            {
                KURUL_ENGELLI_KODU = $"KRE-{i + 1:D5}",
HASTA_KODU = hastalar[i % hastalar.Count].HASTA_KODU,
                HASTA_BASVURU_KODU = basvurular[i % basvurular.Count].HASTA_BASVURU_KODU,
                KURUL_RAPOR_KODU = kr.KURUL_RAPOR_KODU,
                CALISTIRILAMAYACAK_ISNITELIGI = $"Ağır işler, ayakta uzun süre kalmayı gerektiren işler {i + 1}",
                ENGELLI_SUREKLILIK_DURUMU = new[] { "SUREKLI", "GECICI", "BELIRSIZ" }[i % 3],
                AGIR_ENGELLI = i % 3 == 0 ? "EVET" : "HAYIR",
                ENGELLI_GRUBU = new[] { "ORTOPEDIK", "ZIHINSEL", "GORSEL", "ISITSEL", "KRONIK" }[i % 5],
                ENGELLI_RAPOR_KULLANIM_AMACI = new[] { "ISTIHDAM", "SOSYAL_YARDIM", "VERGI_INDIRIMI", "SAGLIK" }[i % 4]
            }).ToList());
        }

        // === KURUL_ASKERI - Skipped (too many required fields) ===
        _logger.LogInformation("KURUL_ASKERI skipped - requires many FK reference codes");

        // === KURUL_TESHIS - Kurul Teşhis ===
        var icd10Kodlar = new[] { "J06.9", "K29.7", "I10", "E11.9", "J45.9", "M54.5", "R51", "N39.0" };
        foreach (var icd in icd10Kodlar)
            await AddReferansKodIfNotExists("TANI_KODU", icd, icd, ct);
        await _db.SaveChangesAsync(ct);

        if (kurulRaporlar.Any())
        {
            await SeedIfEmpty<KURUL_TESHIS>(ct, kurulRaporlar.Take(25).Select((kr, i) => new KURUL_TESHIS
            {
                KURUL_TESHIS_KODU = $"KRT-{i + 1:D5}",
                KURUL_RAPOR_KODU = kr.KURUL_RAPOR_KODU,
                ILAC_TESHIS_KODU = $"ILT-{_random.Next(10000, 99999)}",
                TANI_KODU = icd10Kodlar[i % icd10Kodlar.Length],
                RAPOR_BASLAMA_TARIHI = DateTime.Now.AddDays(-_random.Next(30, 180)),
                RAPOR_BITIS_TARIHI = DateTime.Now.AddDays(_random.Next(30, 365))
            }).ToList());
        }

        _logger.LogInformation("Kurul tabloları seeded");

        // === İZLEM TABLOLARI İÇİN REFERANS KODLARI ===
        var izlemRefKodlar = new Dictionary<string, string[]>
        {
            { "KACINCI_IZLEM", new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" } },
            { "AGIZDAN_SIVI_TEDAVISI", new[] { "UYGULANMADI", "UYGULANDI", "REDDETTI" } },
            { "DEMIR_LOJISTIGI_VE_DESTEGI", new[] { "VERILDI", "VERILMEDI", "STOK_YOK" } },
            { "DVITAMINI_LOJISTIGI_VE_DESTEGI", new[] { "VERILDI", "VERILMEDI", "STOK_YOK" } },
            { "GKD_TARAMA_SONUCU", new[] { "NORMAL", "ANORMAL", "SUPHELI", "YAPILMADI" } },
            { "TOPUK_KANI", new[] { "ALINDI", "ALINMADI", "TEKRAR_GEREKLI" } },
            { "IZLEMIN_YAPILDIGI_YER", new[] { "ASM", "HASTANE", "EVDE", "POLIKLINIK" } },
            { "BEBEKTE_RISK_FAKTORLERI", new[] { "YOK", "DUSUK", "ORTA", "YUKSEK" } },
            { "TARAMA_SONUCU", new[] { "NORMAL", "ANORMAL", "TEKRAR_GEREKLI" } },
            { "BEBEGIN_BESLENME_DURUMU", new[] { "ANNE_SUTU", "MAMA", "KARMA", "EK_GIDA" } },
            { "GELISIM_TABLOSU_BILGILERI", new[] { "NORMAL", "GECIKME_VAR", "CIDDI_GECIKME" } },
            { "NTP_TAKIP_BILGISI", new[] { "TAKIPTE", "TAKIP_DISI", "SONLANDI" } },
            { "BC_BEYIN_GELISIM_RISKLERI", new[] { "YOK", "DUSUK", "ORTA", "YUKSEK" } },
            { "EBEVEYN_DESTEK_AKTIVITELERI", new[] { "YAPILIYOR", "YAPILMIYOR", "KISMEN" } },
            { "BC_PSIKOLOJIK_RISK_EGITIM", new[] { "VERILDI", "VERILMEDI", "PLANLI" } },
            { "BC_RISK_YAPILAN_MUDAHALE", new[] { "YAPILDI", "YAPILMADI", "GEREKLI_DEGIL" } },
            { "BC_RISKLI_OLGU_TAKIBI", new[] { "TAKIPTE", "TAKIP_DISI", "SEVK_EDILDI" } },
            { "KACINCI_GEBE_IZLEM", new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" } },
            { "ONCEKI_DOGUM_DURUMU", new[] { "ILK_GEBELIK", "CANLI_DOGUM", "DUSUK", "OLUM_DOGUM", "SEZERYAN" } },
            { "GEBE_IZLEM_ISLEM_TURU", new[] { "RUTIN", "ACIL", "KONTROL", "TARAMA" } },
            { "GESTASYONEL_DIYABET_TARAMASI", new[] { "NORMAL", "BOZUK", "DIYABET", "YAPILMADI" } },
            { "IDRARDA_PROTEIN", new[] { "NEGATIF", "ESER", "POZITIF", "YUKSEK" } },
            { "KONJENITAL_ANOMALI_VARLIGI", new[] { "YOK", "VAR", "SUPHELI" } },
            { "GEBELIKTE_RISK_FAKTORLERI", new[] { "YOK", "DUSUK", "ORTA", "YUKSEK" } },
            { "PSIKOLOJIK_GELISIM_RISK_EGITIM", new[] { "VERILDI", "VERILMEDI", "PLANLI" } },
            { "RISK_FAKTORLERINE_MUDAHALE", new[] { "YAPILDI", "YAPILMADI", "PLANLI" } },
            { "RISK_ALTINDAKI_OLGU_TAKIBI", new[] { "TAKIPTE", "SONLANDI", "SEVK" } },
            { "DIYET_TIBBI_BESLENME_TEDAVISI", new[] { "UYGULANIYOR", "UYGULANMIYOR", "PLANLI" } },
            { "MORBIT_OBEZ_LENFATIK_ODEM", new[] { "YOK", "VAR", "TEDAVIDE" } },
            { "OBEZITE_ILAC_TEDAVISI", new[] { "UYGULANIYOR", "UYGULANMIYOR", "PLANLI" } },
            { "PSIKOLOJIK_TEDAVI", new[] { "ALINIYOR", "ALINMIYOR", "PLANLI" } },
            { "BIRLIKTE_GORULEN_EK_HASTALIK", new[] { "YOK", "HIPERTANSIYON", "DIYABET", "KALP_HAST", "DISLIPIDEMI" } },
            { "EGZERSIZ", new[] { "DUZENSIZ", "DUZENLI", "HIPERTANSIYON", "SPOR" } }
        };

        foreach (var kvp in izlemRefKodlar)
        {
            foreach (var kod in kvp.Value)
            {
                await AddReferansKodIfNotExists(kvp.Key, kod, kod, ct);
            }
        }
        await _db.SaveChangesAsync(ct);
        _logger.LogInformation("İzlem referans kodları eklendi");

        // === IZLEM TABLOLARI - Skipped (too many complex FK fields) ===
        _logger.LogInformation("İzlem tabloları skipped - BEBEK_COCUK_IZLEM, GEBE_IZLEM, OBEZITE_IZLEM, INTIHAR_IZLEM, KADIN_IZLEM, KUDUZ_IZLEM, LOHUSA_IZLEM, EVDE_SAGLIK_IZLEM require many FK fields");


        // === DOGUM_DETAY - Doğum Detay ===
        var dogumlar = await _db.Set<DOGUM>().ToListAsync(ct);
        if (dogumlar.Any())
        {
            // Doğum detay için ek referans kodları
            var dogumDetayRef = new Dictionary<string, string[]>
            {
                { "CINSIYET", new[] { "ERKEK", "KADIN", "BELIRSIZ" } },
                { "DOGUM_YONTEMI", new[] { "NORMAL", "SEZERYAN", "VAKUM", "FORSEPS" } },
                { "PROGNOZ_BILGISI", new[] { "IYI", "ORTA", "KOTU" } },
                { "SURMATURE_BILGISI", new[] { "YOK", "VAR" } },
                { "K_VITAMINI_UYGULANMA_DURUMU", new[] { "UYGULANDI", "UYGULANMADI" } },
                { "BEBEGIN_HEPATIT_ASI_DURUMU", new[] { "YAPILDI", "YAPILMADI", "BEKLEMEDE" } },
                { "CANLI_DOGUM_BILGISI", new[] { "CANLI", "OLUM" } },
                { "BEBEK_TABURCULUK_DURUMU", new[] { "TABURCU", "YATARAK_TEDAVI", "SEVK", "EXITUS" } }
            };

            foreach (var kvp in dogumDetayRef)
            {
                foreach (var kod in kvp.Value)
                {
                    await AddReferansKodIfNotExists(kvp.Key, kod, kod, ct);
                }
            }
            await _db.SaveChangesAsync(ct);

            // Ek referans kodları
            var yenidoganIsitmeTaramaRefExtra = new[] { "YAPILDI", "YAPILMADI", "TEKRAR_GEREKLI" };
            var bebekYasamDurumuRefExtra = new[] { "CANLI", "OLUM" };
            var sezaryenEndikasyonRefExtra = new[] { "MUDAHALE_GEREKLI", "FETAL_DISTRES", "MAKAT_GELIS", "PLASENTA_PREVIA" };
            var robsonGrubuRefExtra = new[] { "GRUP_1", "GRUP_2", "GRUP_3", "GRUP_4", "GRUP_5" };

            foreach (var t in yenidoganIsitmeTaramaRefExtra)
                await AddReferansKodIfNotExists("YENIDOGAN_ISITME_TARAMA_DURUMU", t, t, ct);
            foreach (var t in bebekYasamDurumuRefExtra)
                await AddReferansKodIfNotExists("BEBEGIN_YASAM_DURUMU", t, t, ct);
            foreach (var t in sezaryenEndikasyonRefExtra)
                await AddReferansKodIfNotExists("SEZARYEN_ENDIKASYONLAR", t, t, ct);
            foreach (var t in robsonGrubuRefExtra)
                await AddReferansKodIfNotExists("ROBSON_GRUBU", t, t, ct);
            await _db.SaveChangesAsync(ct);

            // DOGUM_DETAY skipped - requires complex FK references
            _logger.LogInformation("DOGUM_DETAY skipped - requires many FK reference codes");
        }

        _logger.LogInformation("Doğum detay tablosu references added");

        // === NOBETCI_PERSONEL_BILGISI - Nöbetçi Personel Bilgisi ===
        var gorevTuruRef = new[] { "HEKIM", "HEMSIRE", "TEKNISYEN", "SEKRETER" };
        var personelGorevRef = new[] { "NOBET", "ICAP", "MUDAHALE" };
        foreach (var t in gorevTuruRef)
            await AddReferansKodIfNotExists("GOREV_TURU", t, t, ct);
        foreach (var t in personelGorevRef)
            await AddReferansKodIfNotExists("PERSONEL_GOREV_KODU", t, t, ct);
        await AddReferansKodIfNotExists("SKRS_KURUM_KODU", "11111111", "Kurum Kodu", ct);
        await _db.SaveChangesAsync(ct);

        await SeedIfEmpty<NOBETCI_PERSONEL_BILGISI>(ct, personeller.Take(25).Select((p, i) => new NOBETCI_PERSONEL_BILGISI
        {
            NOBETCI_PERSONEL_BILGISI_KODU = $"NPB-{i + 1:D5}",
            PERSONEL_TC_KIMLIK_NUMARASI = GenerateTcKimlik(),
            KLINIK_KODU = $"KLINIK_KODU_{klinikKodlari[i % klinikKodlari.Length]}",
            GOREV_TURU = $"GOREV_TURU_{gorevTuruRef[i % gorevTuruRef.Length]}",
            PERSONEL_GOREV_KODU = $"PERSONEL_GOREV_KODU_{personelGorevRef[i % personelGorevRef.Length]}",
            NOBET_BASLANGIC_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 30)),
            NOBET_BITIS_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 30)).AddHours(8),
            TELEFON_NUMARASI = $"05{_random.Next(100000000, 999999999)}",
            SKRS_KURUM_KODU = "SKRS_KURUM_KODU_11111111"
        }).ToList());

        _logger.LogInformation("Nöbetçi personel bilgisi tablosu seeded");

        // === VEZNE_DETAY - Vezne Detay ===
        var vezneler = await _db.Set<VEZNE>().ToListAsync(ct);
        var hastaMalzemeler = await _db.Set<HASTA_MALZEME>().Take(10).ToListAsync(ct);
        if (vezneler.Any() && hastaHizmetler.Any() && hastaMalzemeler.Any())
        {
            await SeedIfEmpty<VEZNE_DETAY>(ct, vezneler.Take(25).Select((v, i) => new VEZNE_DETAY
            {
                VEZNE_DETAY_KODU = $"VZD-{i + 1:D5}",
VEZNE_KODU = v.VEZNE_KODU,
                HASTA_HIZMET_KODU = hastaHizmetler[i % hastaHizmetler.Count].HASTA_HIZMET_KODU,
                HASTA_MALZEME_KODU = hastaMalzemeler[i % hastaMalzemeler.Count].HASTA_MALZEME_KODU,
                BUTCE_KODU = $"BTK-{_random.Next(1000, 9999)}",
                MAKBUZ_KALEM_TUTARI = (_random.Next(50, 500) * 100).ToString()
            }).ToList());
        }

        _logger.LogInformation("Vezne detay tablosu seeded");

        // === RECETE_ILAC - Reçete İlaç ===
        var receteler = await _db.Set<RECETE>().ToListAsync(ct);
        var dozBirimRef = new[] { "MG", "ML", "TABLET", "DAMLA", "AMPUL" };
        var ilacKullanimSekliRef = new[] { "ORAL", "IV", "IM", "SC", "TOPIKAL", "INHALASYON" };
        var periyotBirimRef = new[] { "GUN", "SAAT", "HAFTA" };
        foreach (var t in dozBirimRef)
            await AddReferansKodIfNotExists("DOZ_BIRIM", t, t, ct);
        foreach (var t in ilacKullanimSekliRef)
            await AddReferansKodIfNotExists("ILAC_KULLANIM_SEKLI", t, t, ct);
        foreach (var t in periyotBirimRef)
            await AddReferansKodIfNotExists("ILAC_KULLANIM_PERIYODU_BIRIMI", t, t, ct);
        await _db.SaveChangesAsync(ct);

        if (receteler.Any())
        {
            await SeedIfEmpty<RECETE_ILAC>(ct, receteler.Take(25).Select((r, i) => new RECETE_ILAC
            {
                RECETE_ILAC_KODU = $"RCI-{i + 1:D5}",
RECETE_KODU = r.RECETE_KODU,
                DOZ_BIRIM = dozBirimRef[i % dozBirimRef.Length],
                BARKOD = $"869{_random.Next(1000000000, 2000000000)}",
                ILAC_ADI = new[] { "Parol", "Arveles", "Majezik", "Cipro", "Augmentin", "Nurofen", "Aspirin" }[i % 7],
                KUTU_ADETI = (_random.Next(1, 5)).ToString(),
                ILAC_KULLANIM_SEKLI = ilacKullanimSekliRef[i % ilacKullanimSekliRef.Length],
                ILAC_KULLANIM_SAYISI = (_random.Next(1, 4)).ToString(),
                ILAC_KULLANIM_DOZU = (_random.Next(1, 3)).ToString(),
                ILAC_KULLANIM_PERIYODU = (_random.Next(1, 3)).ToString(),
                ILAC_KULLANIM_PERIYODU_BIRIMI = periyotBirimRef[i % periyotBirimRef.Length],
                ILAC_ACIKLAMA = $"İlaç açıklaması {i + 1}"
            }).ToList());
        }

        _logger.LogInformation("Reçete ilaç tablosu seeded");

        // ======================================================================
        // EKSİK 24 TABLO SEED - BAKTERI/ANTIBIYOTIK, HASTA, PERSONEL, STOK, STERILIZASYON
        // ======================================================================

        // === BAKTERI_SONUC - Bakteri Sonuç ===
        var tetkikSonuclar2 = await _db.Set<TETKIK_SONUC>().Take(25).ToListAsync(ct);
        var bakteriRef = new[] { "ECOLI", "STAPH_AUREUS", "STREP_PNEUMO", "PSEUDOMONAS", "KLEBSIELLA" };
        foreach (var b in bakteriRef)
            await AddReferansKodIfNotExists("BAKTERI_KODU", b, b, ct);
        await _db.SaveChangesAsync(ct);

        if (tetkikSonuclar2.Any())
        {
            await SeedIfEmpty<BAKTERI_SONUC>(ct, tetkikSonuclar2.Take(25).Select((ts, i) => new BAKTERI_SONUC
            {
                BAKTERI_SONUC_KODU = $"BKT-{i + 1:D5}",
TETKIK_SONUC_KODU = ts.TETKIK_SONUC_KODU,
                BAKTERI_KODU = bakteriRef[i % bakteriRef.Length],
                KOLONI_SAYISI = (_random.Next(1000, 100000)).ToString(),
                RAPOR_SONUC_SIRASI = (i + 1).ToString(),
                ACIKLAMA = $"Bakteri sonuç kaydı {i + 1}"
            }).ToList());
        }

        // === ANTIBIYOTIK_SONUC - Antibiyotik Sonuç ===
        var bakteriSonuclar = await _db.Set<BAKTERI_SONUC>().Take(25).ToListAsync(ct);
        var antibiyotikRef = new[] { "PENISILIN", "AMIKASIN", "GENTAMISIN", "CIPROFLOXACIN", "VANCOMYCIN" };
        var tetkikSonucuRef = new[] { "DUYARLI", "DIRENCLI", "ORTA_DUYARLI" };
        foreach (var a in antibiyotikRef)
            await AddReferansKodIfNotExists("ANTIBIYOTIK_KODU", a, a, ct);
        foreach (var t in tetkikSonucuRef)
            await AddReferansKodIfNotExists("TETKIK_SONUCU", t, t, ct);
        await _db.SaveChangesAsync(ct);

        if (bakteriSonuclar.Any())
        {
            await SeedIfEmpty<ANTIBIYOTIK_SONUC>(ct, bakteriSonuclar.Take(25).Select((bs, i) => new ANTIBIYOTIK_SONUC
            {
                ANTIBIYOTIK_SONUC_KODU = $"ANT-{i + 1:D5}",
BAKTERI_SONUC_KODU = bs.BAKTERI_SONUC_KODU,
                ANTIBIYOTIK_KODU = antibiyotikRef[i % antibiyotikRef.Length],
                TETKIK_SONUCU = tetkikSonucuRef[i % tetkikSonucuRef.Length],
                ZON_CAPI = (_random.Next(10, 30)).ToString(),
                ACIKLAMA = $"Antibiyotik sonuç kaydı {i + 1}",
                RAPORDA_GORULME_DURUMU = "EVET"
            }).ToList());
        }
        _logger.LogInformation("BAKTERI_SONUC ve ANTIBIYOTIK_SONUC seeded");

        // === COCUK_DIYABET - Çocuk Diyabet ===
        var cocukDiyabetRef = new Dictionary<string, string[]>
        {
            { "DIYABET_TIPI", new[] { "TIP_1", "TIP_2", "GESTASYONEL" } },
            { "BEYIN_ODEMI_DURUMU", new[] { "YOK", "VAR" } },
            { "KETOASIDOZ_DURUMU", new[] { "YOK", "VAR", "GECMISTE" } },
            { "DIYABET_SIKAYET", new[] { "POLIURI", "POLIDIPSI", "KILO_KAYBI", "YORGUNLUK" } },
            { "AKSILLER_KILLANMA_DURUMU", new[] { "YOK", "AZ", "NORMAL" } },
            { "PUBIK_KILLANMA_DURUMU", new[] { "YOK", "AZ", "NORMAL" } },
            { "MEME_EVRE", new[] { "EVRE_1", "EVRE_2", "EVRE_3", "EVRE_4" } },
            { "ESLIKEDEN_HASTALIK", new[] { "YOK", "TIROID", "COLYAK", "DIGER" } },
            { "DIYABET_ILAC_TEDAVI_SEKLI", new[] { "INSULIN", "ORAL", "KOMBINE" } },
            { "DIYABETLI_HASTA_AILE_OYKUSU", new[] { "YOK", "ANNE", "BABA", "KARDES" } },
            { "DIYABET_EGITIMI_VERILME_DURUMU", new[] { "VERILDI", "VERILMEDI" } },
            { "TIROID_MUAYENESI", new[] { "NORMAL", "ANORMAL" } },
            { "DIYABET_KOMPLIKASYONLARI", new[] { "YOK", "RETINOPATI", "NEFROPATI", "NOROPATI" } }
        };

        foreach (var kvp in cocukDiyabetRef)
        {
            foreach (var kod in kvp.Value)
                await AddReferansKodIfNotExists(kvp.Key, kod, kod, ct);
        }
        await _db.SaveChangesAsync(ct);

        await SeedIfEmpty<COCUK_DIYABET>(ct, basvurular.Take(25).Select((b, i) => new COCUK_DIYABET
        {
            COCUK_DIYABET_KODU = $"CDY-{i + 1:D5}",
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            ILK_TANI_TARIHI = DateTime.Now.AddYears(-_random.Next(1, 5)),
            AGIRLIK = (20 + _random.Next(0, 30)).ToString(),
            BOY = (100 + _random.Next(0, 60)).ToString(),
            DIYABET_TIPI = $"DIYABET_TIPI_{cocukDiyabetRef["DIYABET_TIPI"][i % 3]}",
            KIZ_COCUKLARDA_MENARS_YASI = (11 + _random.Next(0, 4)).ToString(),
            BEYIN_ODEMI_DURUMU = $"BEYIN_ODEMI_DURUMU_{cocukDiyabetRef["BEYIN_ODEMI_DURUMU"][i % 2]}",
            KETOASIDOZ_DURUMU = $"KETOASIDOZ_DURUMU_{cocukDiyabetRef["KETOASIDOZ_DURUMU"][i % 3]}",
            DIYABET_SIKAYET = $"DIYABET_SIKAYET_{cocukDiyabetRef["DIYABET_SIKAYET"][i % 4]}",
            SIKAYETIN_SURESI = $"{_random.Next(1, 12)} ay",
            AKSILLER_KILLANMA_DURUMU = $"AKSILLER_KILLANMA_DURUMU_{cocukDiyabetRef["AKSILLER_KILLANMA_DURUMU"][i % 3]}",
            PUBIK_KILLANMA_DURUMU = $"PUBIK_KILLANMA_DURUMU_{cocukDiyabetRef["PUBIK_KILLANMA_DURUMU"][i % 3]}",
            MEME_EVRE = $"MEME_EVRE_{cocukDiyabetRef["MEME_EVRE"][i % 4]}",
            TESTIS_VOLUM_SAG = _random.Next(1, 10).ToString(),
            TESTIS_VOLUM_SOL = _random.Next(1, 10).ToString(),
            ESLIKEDEN_HASTALIK = $"ESLIKEDEN_HASTALIK_{cocukDiyabetRef["ESLIKEDEN_HASTALIK"][i % 4]}",
            ESLIKEDEN_HASTALIK_TANI_TARIHI = DateTime.Now.AddYears(-_random.Next(1, 3)),
            DIYABET_ILAC_TEDAVI_SEKLI = $"DIYABET_ILAC_TEDAVI_SEKLI_{cocukDiyabetRef["DIYABET_ILAC_TEDAVI_SEKLI"][i % 3]}",
            DIYET_TIBBI_BESLENME_TEDAVISI = $"DIYET_TIBBI_BESLENME_TEDAVISI_{izlemRefKodlar["DIYET_TIBBI_BESLENME_TEDAVISI"][i % 3]}",
            DIYABETLI_HASTA_AILE_OYKUSU = $"DIYABETLI_HASTA_AILE_OYKUSU_{cocukDiyabetRef["DIYABETLI_HASTA_AILE_OYKUSU"][i % 4]}",
            DIYABET_EGITIMI_VERILME_DURUMU = $"DIYABET_EGITIMI_VERILME_DURUMU_{cocukDiyabetRef["DIYABET_EGITIMI_VERILME_DURUMU"][i % 2]}",
            TIROID_MUAYENESI = $"TIROID_MUAYENESI_{cocukDiyabetRef["TIROID_MUAYENESI"][i % 2]}",
            DIYABET_KOMPLIKASYONLARI = $"DIYABET_KOMPLIKASYONLARI_{cocukDiyabetRef["DIYABET_KOMPLIKASYONLARI"][i % 4]}"
        }).ToList());
        _logger.LogInformation("COCUK_DIYABET seeded");

        // === HEMOGLOBINOPATI - Hemoglobinopati ===
        var hemoglobinopatiRef = new Dictionary<string, string[]>
        {
            { "HEMOGLOBINOPATI_TARAMA_SONUCU", new[] { "NORMAL", "ANORMAL", "TEKRAR_GEREKLI" } },
            { "HEMOGLOBINOPATI_TESTI_SONUCU", new[] { "NEGATIF", "POZITIF", "SINIR" } },
            { "HEMOGLOBINOPATI_SONUC_HASTALIK", new[] { "YOK", "TALASEMI", "ORAK_HUCRE", "DIGER" } },
            { "HEMOGLOBINOPATI_TASIYICILIK", new[] { "YOK", "TALASEMI_TASIYICI", "ORAK_HUCRE_TASIYICI" } }
        };

        foreach (var kvp in hemoglobinopatiRef)
        {
            foreach (var kod in kvp.Value)
                await AddReferansKodIfNotExists(kvp.Key, kod, kod, ct);
        }
        await _db.SaveChangesAsync(ct);

        await SeedIfEmpty<HEMOGLOBINOPATI>(ct, basvurular.Take(25).Select((b, i) => new HEMOGLOBINOPATI
        {
            HEMOGLOBINOPATI_KODU = $"HMG-{i + 1:D5}",
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            HEMOGLOBINOPATI_TARAMA_SONUCU = $"HEMOGLOBINOPATI_TARAMA_SONUCU_{hemoglobinopatiRef["HEMOGLOBINOPATI_TARAMA_SONUCU"][i % 3]}",
            ES_ADAYI_TC_KIMLIK_NUMARASI = GenerateTcKimlik(),
            ES_ADAYI_TELEFON_NUMARASI = $"05{_random.Next(100000000, 999999999)}",
            HEMOGLOBINOPATI_TESTI_SONUCU = $"HEMOGLOBINOPATI_TESTI_SONUCU_{hemoglobinopatiRef["HEMOGLOBINOPATI_TESTI_SONUCU"][i % 3]}",
            HEMOGLOBINOPATI_ISLEM_TIPI = "EVLILIK_ONCESI",
            HEMOGLOBINOPATI_SONUC_HASTALIK = $"HEMOGLOBINOPATI_SONUC_HASTALIK_{hemoglobinopatiRef["HEMOGLOBINOPATI_SONUC_HASTALIK"][i % 4]}",
            HEMOGLOBINOPATI_TASIYICILIK = $"HEMOGLOBINOPATI_TASIYICILIK_{hemoglobinopatiRef["HEMOGLOBINOPATI_TASIYICILIK"][i % 3]}"
        }).ToList());
        _logger.LogInformation("HEMOGLOBINOPATI seeded");

        // === HASTA_OLUM - Hasta Ölüm ===
        var olumRef = new Dictionary<string, string[]>
        {
            { "OLUM_YERI", new[] { "HASTANE", "EV", "DIS_MEKAN", "AMBULANS" } },
            { "ANNE_OLUM_NEDENI", new[] { "YOK", "KANAMA", "ENFEKSIYON", "DIGER" } },
            { "OTOPSI_DURUMU", new[] { "YAPILDI", "YAPILMADI", "RED" } },
            { "OLUM_NEDENI_TURU", new[] { "SON_NEDEN", "ARA_NEDEN", "ALTTA_YATAN" } },
            { "OLUM_SEKLI", new[] { "DOGAL", "IS_KAZASI", "TRAFIK", "CINAYET", "INTIHAR" } },
            { "OLUM_NEDENI_TANI_KODU", new[] { "KALP_YETMEZLIGI", "SOLUNUM_YETMEZLIGI", "KANSER", "ENFEKSIYON", "TRAVMA" } }
        };

        foreach (var kvp in olumRef)
        {
            foreach (var kod in kvp.Value)
                await AddReferansKodIfNotExists(kvp.Key, kod, kod, ct);
        }
        await _db.SaveChangesAsync(ct);

        await SeedIfEmpty<HASTA_OLUM>(ct, basvurular.Take(25).Select((b, i) => new HASTA_OLUM
        {
            HASTA_OLUM_KODU = $"HOL-{i + 1:D5}",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            OLUM_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 365)),
            OLUM_YERI = $"OLUM_YERI_{olumRef["OLUM_YERI"][i % 4]}",
            ANNE_OLUM_NEDENI = $"ANNE_OLUM_NEDENI_{olumRef["ANNE_OLUM_NEDENI"][i % 4]}",
            ACIKLAMA = $"Hasta ölüm kaydı {i + 1}",
            OTOPSI_DURUMU = $"OTOPSI_DURUMU_{olumRef["OTOPSI_DURUMU"][i % 3]}",
            OLUM_BELGESI_PERSONEL_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
            OLUM_NEDENI_TANI_KODU = $"OLUM_NEDENI_TANI_KODU_{olumRef["OLUM_NEDENI_TANI_KODU"][i % 5]}",
            OLUM_NEDENI_TURU = $"OLUM_NEDENI_TURU_{olumRef["OLUM_NEDENI_TURU"][i % 3]}",
            OLUM_SEKLI = $"OLUM_SEKLI_{olumRef["OLUM_SEKLI"][i % 5]}",
            EX_KARARINI_VEREN_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
            TUTANAK_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 365)),
            TESLIM_ALAN_TC_KIMLIK_NUMARASI = GenerateTcKimlik(),
            TESLIM_ALAN_ADI_SOYADI = $"Teslim Alan {i + 1}",
            TESLIM_ALAN_TELEFON_BILGISI = $"05{_random.Next(100000000, 999999999)}",
            TESLIM_ALAN_ADRESI = $"Adres {i + 1}, Ankara",
            TESLIM_EDEN_PERSONEL_KODU = personeller[i % personeller.Count].PERSONEL_KODU
        }).ToList());
        _logger.LogInformation("HASTA_OLUM seeded");

        // === HASTA_ADLI_RAPOR - Hasta Adli Rapor ===
        var adliRaporRef = new Dictionary<string, string[]>
        {
            { "ADLI_RAPOR_TURU", new[] { "GIRIS_RAPORU", "CIKIS_RAPORU", "KESIN_RAPOR" } },
            { "ELBISE_DURUMU", new[] { "DUZGUN", "YIRTIK", "KANLI", "NORMAL" } },
            { "PUPILLA_DEGERLENDIRMESI", new[] { "NORMAL", "MIYOZIS", "MIDRIAZIS" } },
            { "ISIK_REFLEKSI", new[] { "VAR", "YOK", "AZALMIS" } },
            { "TENDON_REFLEKSI", new[] { "NORMOAKTIF", "HIPOAKTIF", "HIPERAKTIF" } },
            { "ADLI_MUAYENE_RIZA_DURUMU", new[] { "ONAYLANDI", "RED", "YAKIN_ONAY" } },
            { "RIZA_VERENIN_YAKINLIK_DERECESI", new[] { "KENDISI", "ANNE", "BABA", "ES" } }
        };

        foreach (var kvp in adliRaporRef)
        {
            foreach (var kod in kvp.Value)
                await AddReferansKodIfNotExists(kvp.Key, kod, kod, ct);
        }
        await _db.SaveChangesAsync(ct);

        var kullanicilar2 = await _db.Set<KULLANICI>().Take(10).ToListAsync(ct);
        await SeedIfEmpty<HASTA_ADLI_RAPOR>(ct, basvurular.Take(25).Select((b, i) => new HASTA_ADLI_RAPOR
        {
            HASTA_ADLI_RAPOR_KODU = $"HAR-{i + 1:D5}",
HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            HASTA_KODU = b.HASTA_KODU,
            ADLI_RAPOR_TURU = $"ADLI_RAPOR_TURU_{adliRaporRef["ADLI_RAPOR_TURU"][i % 3]}",
            RAPOR_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 180)),
            ADLI_MUAYENEYE_GONDEREN_KURUM = "Emniyet Müdürlüğü",
            RESMI_YAZI_NUMARASI = $"RY-{_random.Next(10000, 99999)}",
            RESMI_YAZI_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 180)),
            ADLI_MUAYENE_EDILME_NEDENI = "Darp şüphesi",
            GUVENLIK_SICIL_NUMARASI = $"GS-{_random.Next(1000, 9999)}",
            GUVENLIK_ADI_SOYADI = $"Güvenlik Görevlisi {i + 1}",
            OLAY_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
            ADLI_OLAY_OYKUSU = $"Adli olay öyküsü {i + 1}",
            OZGECMISI = "Özgeçmiş bilgisi",
            SOYGECMISI = "Soygeçmiş bilgisi",
            MUAYENE_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
            HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
            TIBBI_MUDAHALE = "Gerekli tıbbi müdahale yapıldı",
            UYGUN_SART_SAGLANMA_DURUMU = "EVET",
            UYGUN_SART_ACIKLAMA = "Muayene koşulları uygun",
            ELBISE_DURUMU = $"ELBISE_DURUMU_{adliRaporRef["ELBISE_DURUMU"][i % 4]}",
            KONSULTASYON_BILGISI = "Konsültasyon yapıldı",
            LEZYON_BULGULARI = $"Lezyon bulgusu {i + 1}",
            SISTEM_BULGULARI = "Normal",
            BILINC_DURUMU = "Açık",
            PUPILLA_DEGERLENDIRMESI = $"PUPILLA_DEGERLENDIRMESI_{adliRaporRef["PUPILLA_DEGERLENDIRMESI"][i % 3]}",
            ISIK_REFLEKSI = $"ISIK_REFLEKSI_{adliRaporRef["ISIK_REFLEKSI"][i % 3]}",
            NABIZ = (60 + _random.Next(0, 40)).ToString(),
            TENDON_REFLEKSI = $"TENDON_REFLEKSI_{adliRaporRef["TENDON_REFLEKSI"][i % 3]}",
            PSIKIYATRIK_MUAYENE = "Normal",
            PSIKIYATRIK_SONUC = "Patoloji yok",
            HIZMET_ACIKLAMA = "Hizmet açıklaması",
            SEVK_DURUMU = "SEVK_YOK",
            SEVK_ACIKLAMA = "Sevk gerekmedi",
            TESLIM_ALAN_ADI_SOYADI = $"Teslim Alan {i + 1}",
            TESLIM_ALAN_TC_KIMLIK_NUMARASI = GenerateTcKimlik(),
            VUCUT_DIYAGRAMI = "Vücut diyagramı bilgisi",
            ACIKLAMA = $"Adli rapor kaydı {i + 1}",
            ADLI_MUAYENE_RIZA_DURUMU = $"ADLI_MUAYENE_RIZA_DURUMU_{adliRaporRef["ADLI_MUAYENE_RIZA_DURUMU"][i % 3]}",
            RIZA_VEREN_KISI = $"Rıza Veren {i + 1}",
            RIZA_VERENIN_YAKINLIK_DERECESI = $"RIZA_VERENIN_YAKINLIK_DERECESI_{adliRaporRef["RIZA_VERENIN_YAKINLIK_DERECESI"][i % 4]}",
            SON_CINSEL_ILISKI_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 30)),
            HAMILELIK_DURUMU = "HAYIR",
            HAMILELIK_OYKUSU_ACIKLAMA = "Hamilelik öyküsü yok",
            VENERYAL_HASTALIK_OYKUSU = "Yok",
            EMOSYONEL_HASTALIK_OYKUSU = "Normal",
            SOLUNUM = "Normal",
            ADLI_MUAYENE_NOTU = $"Muayene notu {i + 1}",
            ALINAN_MATERYAL = "Kan, idrar",
            MUAYENEDEKI_KISI_BILGISI = "Hemşire",
            MUAYENEDEKI_KISI_ACIKLAMA = "Muayene sırasında hemşire bulundu",
            ALKOL_KULLANIMI = "HAYIR",
            SIDDET_TEHDIT_BILGISI = "Darp mağduru",
            SILAH_ALET_BILGISI = "Künt cisim",
            HAYATI_TEHLIKE_DURUMU = "YOK",
            SISTOLIK_KAN_BASINCI_DEGERI = (100 + _random.Next(0, 40)).ToString(),
            DIASTOLIK_KAN_BASINCI_DEGERI = (60 + _random.Next(0, 30)).ToString(),
            IPTAL_ZAMANI = DateTime.Now.AddDays(30),
            IPTAL_EDEN_KULLANICI_KODU = kullanicilar2.Any() ? kullanicilar2[i % kullanicilar2.Count].KULLANICI_KODU : $"KLN-{i + 1:D5}",
            ADLI_RAPOR_IPTAL_GEREKCESI = "İptal gerekçesi",
            ONAYLAYAN_KULLANICI_KODU = kullanicilar2.Any() ? kullanicilar2[i % kullanicilar2.Count].KULLANICI_KODU : $"KLN-{i + 1:D5}",
            ADLI_RAPOR_ONAYLANMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 10))
        }).ToList());
        _logger.LogInformation("HASTA_ADLI_RAPOR seeded");

        // === HASTA_DIS - Hasta Diş ===
        var disRef = new Dictionary<string, string[]>
        {
            { "DIS_ISLEM_TURU", new[] { "DIAGNOZ", "TEDAVI", "PLANLAMA", "KONTROL" } },
            { "MEVCUT_DIS_DURUMU", new[] { "SAGLIKLI", "CURUMUS", "DOLGULU", "CEKILMIS" } },
            { "DIS_KODU", new[] { "11", "12", "21", "22", "31", "32", "41", "42" } },
            { "CENE_BOLGESI", new[] { "UST_CENE", "ALT_CENE", "TUM_CENE" } }
        };

        foreach (var kvp in disRef)
        {
            foreach (var kod in kvp.Value)
                await AddReferansKodIfNotExists(kvp.Key, kod, kod, ct);
        }
        await _db.SaveChangesAsync(ct);

        var disTaahhutler = await _db.Set<DIS_TAAHHUT>().Take(25).ToListAsync(ct);
        var disprotezler = await _db.Set<DISPROTEZ>().Take(25).ToListAsync(ct);
        if (disTaahhutler.Any() && disprotezler.Any() && hastaHizmetler.Any())
        {
            await SeedIfEmpty<HASTA_DIS>(ct, basvurular.Take(25).Select((b, i) => new HASTA_DIS
            {
                HASTA_DIS_KODU = $"HDS-{i + 1:D5}",
HASTA_KODU = b.HASTA_KODU,
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                DIS_ISLEM_TURU = disRef["DIS_ISLEM_TURU"][i % 4],
                HASTA_HIZMET_KODU = hastaHizmetler[i % hastaHizmetler.Count].HASTA_HIZMET_KODU,
                DIS_TAAHHUT_KODU = disTaahhutler[i % disTaahhutler.Count].DIS_TAAHHUT_KODU,
                MEVCUT_DIS_DURUMU = disRef["MEVCUT_DIS_DURUMU"][i % 4],
                DIS_KODU = disRef["DIS_KODU"][i % 8],
                CENE_BOLGESI = disRef["CENE_BOLGESI"][i % 3],
                CENE_BOLGESI_DISLERI = "11,12,21,22",
                DISPROTEZ_KODU = disprotezler[i % disprotezler.Count].DISPROTEZ_KODU,
                SONUC_KODU = $"SNK-{_random.Next(1000, 9999)}",
                SONUC_MESAJI = $"İşlem başarılı {i + 1}"
            }).ToList());
        }
        _logger.LogInformation("HASTA_DIS seeded");

        // === DIS_TAAHHUT_DETAY - Diş Taahhüt Detay ===
        var ceneRef = new[] { "UST_CENE", "ALT_CENE" };
        foreach (var c in ceneRef)
            await AddReferansKodIfNotExists("CENE_KODU", c, c, ct);
        await _db.SaveChangesAsync(ct);

        if (disTaahhutler.Any())
        {
            await SeedIfEmpty<DIS_TAAHHUT_DETAY>(ct, disTaahhutler.Take(25).Select((dt, i) => new DIS_TAAHHUT_DETAY
            {
                DIS_TAAHHUT_DETAY_KODU = $"DTD-{i + 1:D5}",
DIS_TAAHHUT_KODU = dt.DIS_TAAHHUT_KODU,
                DIS_KODU = disRef["DIS_KODU"][i % 8],
                SUT_KODU = $"SUT-{_random.Next(1000, 9999)}",
                CENE_KODU = ceneRef[i % 2]
            }).ToList());
        }
        _logger.LogInformation("DIS_TAAHHUT_DETAY seeded");

        // === DISPROTEZ_DETAY - Diş Protez Detay ===
        var disprotezAsamaRef = new[] { "OLCU", "PROVA", "TESLIM", "KONTROL" };
        var asamaRptSebebiRef = new[] { "UYUMSUZLUK", "RENK_FARKI", "KIRIK", "DIGER" };
        foreach (var a in disprotezAsamaRef)
            await AddReferansKodIfNotExists("DISPROTEZ_IS_TURU_ASAMA_KODU", a, a, ct);
        foreach (var r in asamaRptSebebiRef)
            await AddReferansKodIfNotExists("ASAMA_RPT_SEBEBI", r, r, ct);
        await _db.SaveChangesAsync(ct);

        var randevular2 = await _db.Set<RANDEVU>().Take(25).ToListAsync(ct);
        var firmalar2 = await _db.Set<FIRMA>().Take(10).ToListAsync(ct);
        if (disprotezler.Any() && randevular2.Any() && firmalar2.Any())
        {
            await SeedIfEmpty<DISPROTEZ_DETAY>(ct, disprotezler.Take(25).Select((dp, i) => new DISPROTEZ_DETAY
            {
                DISPROTEZ_DETAY_KODU = $"DPD-{i + 1:D5}",
DISPROTEZ_KODU = dp.DISPROTEZ_KODU,
                DISPROTEZ_PLANLAMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                DISPROTEZ_IS_TURU_ASAMA_KODU = disprotezAsamaRef[i % 4],
                DISPROTEZ_ASAMA_BITIS_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 20)),
                FIRMA_KODU = firmalar2[i % firmalar2.Count].FIRMA_KODU,
                FIRMA_DISPROTEZ_ALIM_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 25)),
                PLANLANAN_BITIS_TARIHI = DateTime.Now.AddDays(_random.Next(1, 30)),
                FIRMA_TESLIM_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 15)),
                DISPROTEZ_ASAMA_ONAY_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 10)),
                RPT_ONAY_DURUMU = "ONAYLANDI",
                RANDEVU_KODU = randevular2[i % randevular2.Count].RANDEVU_KODU,
                ASAMA_RPT_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 10)),
                ASAMA_RPT_SEBEBI = asamaRptSebebiRef[i % 4],
                ASAMA_RPT_KULLANICI_KODU = kullanicilar2.Any() ? kullanicilar2[i % kullanicilar2.Count].KULLANICI_KODU : $"KLN-{i + 1:D5}",
                OLCU_DOKUM_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30))
            }).ToList());
        }
        _logger.LogInformation("DISPROTEZ_DETAY seeded");

        // === KURUL_ETKEN_MADDE - Kurul Etken Madde ===
        var kurulRaporlar2 = await _db.Set<KURUL_RAPOR>().Take(25).ToListAsync(ct);
        var dozBirimKurulRef = new[] { "MG", "ML", "GR", "TABLET" };
        var ilacPeriyotBirimiRef = new[] { "GUN", "HAFTA", "AY" };
        foreach (var d in dozBirimKurulRef)
            await AddReferansKodIfNotExists("DOZ_BIRIM", d, d, ct);
        foreach (var p in ilacPeriyotBirimiRef)
            await AddReferansKodIfNotExists("ILAC_PERIYOT_BIRIMI", p, p, ct);
        await _db.SaveChangesAsync(ct);

        if (kurulRaporlar2.Any())
        {
            await SeedIfEmpty<KURUL_ETKEN_MADDE>(ct, kurulRaporlar2.Take(25).Select((kr, i) => new KURUL_ETKEN_MADDE
            {
                KURUL_ETKEN_MADDE_KODU = $"KEM-{i + 1:D5}",
KURUL_RAPOR_KODU = kr.KURUL_RAPOR_KODU,
                ILAC_ETKEN_MADDE_KODU = $"ETK-{_random.Next(1000, 9999)}",
                DOZ_SAYISI = _random.Next(1, 4).ToString(),
                DOZ_MIKTARI = _random.Next(100, 1000).ToString(),
                DOZ_BIRIM = dozBirimKurulRef[i % 4],
                ILAC_KULLANIM_PERIYODU = _random.Next(1, 3).ToString(),
                ILAC_PERIYOT_BIRIMI = ilacPeriyotBirimiRef[i % 3]
            }).ToList());
        }
        _logger.LogInformation("KURUL_ETKEN_MADDE seeded");

        // === ORTODONTI_ICON_SKOR - Ortodonti Icon Skor ===
        await SeedIfEmpty<ORTODONTI_ICON_SKOR>(ct, basvurular.Take(25).Select((b, i) => new ORTODONTI_ICON_SKOR
        {
            ORTODONTI_ICON_SKOR_KODU = $"OIS-{i + 1:D5}",
HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            OIS_DEGERLENDIRME_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 90)),
            OIS_ESTETIK_BOZUKLUK_BILGISI = _random.Next(1, 10).ToString(),
            OIS_ESTETIK_PUAN_KATSAYISI = "7",
            OIS_ESTETIK_PUANI = (_random.Next(7, 70)).ToString(),
            UST_DIS_ARKA_CAPRASIKLIK = _random.Next(0, 5).ToString(),
            UST_ARKA_CAPRASIKLIK_KATSAYISI = "5",
            UST_ARKA_CAPRASIKLIK_PUANI = _random.Next(0, 25).ToString(),
            UST_DIS_ARKA_BOSLUK = _random.Next(0, 3).ToString(),
            UST_ARKA_BOSLUK_KATSAYISI = "5",
            UST_ARKA_BOSLUK_PUANI = _random.Next(0, 15).ToString(),
            DIS_CAPRAZLIK_DURUMU = i % 2 == 0 ? "EVET" : "HAYIR",
            DIS_CAPRAZLIK_KATSAYISI = "5",
            DIS_CAPRAZLIK_PUANI = _random.Next(0, 5).ToString(),
            ON_ACIK_KAPANIS = _random.Next(0, 4).ToString(),
            ON_ACIK_KAPANIS_KATSAYISI = "4",
            ON_ACIK_KAPANIS_PUANI = _random.Next(0, 16).ToString(),
            ON_DERIN_KAPANIS = _random.Next(0, 4).ToString(),
            ON_DERIN_KAPANIS_KATSAYISI = "4",
            ON_DERIN_KAPANIS_PUANI = _random.Next(0, 16).ToString(),
            BUKKAL_BOLGE_SAG = _random.Next(0, 3).ToString(),
            BUKKAL_BOLGE_SAG_KATSAYISI = "3",
            BUKKAL_BOLGE_SAG_PUANI = _random.Next(0, 9).ToString(),
            BUKKAL_BOLGE_SOL = _random.Next(0, 3).ToString(),
            BUKKAL_BOLGE_SOL_KATSAYISI = "3",
            BUKKAL_BOLGE_SOL_PUANI = _random.Next(0, 9).ToString(),
            BUKKAL_TOPLAM_PUANI = _random.Next(0, 18).ToString(),
            TOPLAM_ICON_SKOR_PUANI = _random.Next(20, 150).ToString(),
            OIS_DEGERLENDIREN_1_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
            OIS_DEGERLENDIREN_2_HEKIM_KODU = personeller[(i + 1) % personeller.Count].PERSONEL_KODU,
            OIS_DEGERLENDIREN_3_HEKIM_KODU = personeller[(i + 2) % personeller.Count].PERSONEL_KODU,
            ACIKLAMA = $"Ortodonti icon skor kaydı {i + 1}"
        }).ToList());
        _logger.LogInformation("ORTODONTI_ICON_SKOR seeded");

        // === PERSONEL TABLOLARI (5 TABLO) ===

        // PERSONEL_BAKMAKLA_YUKUMLU
        var yakinlikDerecesiRef = new[] { "ES", "COCUK", "ANNE", "BABA" };
        var ogrenimDurumuRef2 = new[] { "ILKOKUL", "ORTAOKUL", "LISE", "UNIVERSITE" };
        var engellilikDurumuRef = new[] { "YOK", "BEDENSEL", "ZIHINSEL", "GORME", "ISITME" };
        foreach (var y in yakinlikDerecesiRef)
            await AddReferansKodIfNotExists("PERSONEL_YAKINLIK_DERECESI", y, y, ct);
        foreach (var o in ogrenimDurumuRef2)
            await AddReferansKodIfNotExists("OGRENIM_DURUMU", o, o, ct);
        foreach (var e in engellilikDurumuRef)
            await AddReferansKodIfNotExists("ENGELLILIK_DURUMU", e, e, ct);
        await _db.SaveChangesAsync(ct);

        await SeedIfEmpty<PERSONEL_BAKMAKLA_YUKUMLU>(ct, personeller.Take(25).Select((p, i) => new PERSONEL_BAKMAKLA_YUKUMLU
        {
            PERSONEL_BAKMAKLA_YUKUMLU_KODU = $"PBY-{i + 1:D5}",
PERSONEL_KODU = p.PERSONEL_KODU,
            PERSONEL_YAKINLIK_DERECESI = $"PERSONEL_YAKINLIK_DERECESI_{yakinlikDerecesiRef[i % 4]}",
            TC_KIMLIK_NUMARASI = GenerateTcKimlik(),
            AD = $"Yakın Ad {i + 1}",
            SOYADI = $"Yakın Soyad {i + 1}",
            DOGUM_TARIHI = DateTime.Now.AddYears(-_random.Next(5, 80)),
            OGRENIM_DURUMU = $"OGRENIM_DURUMU_{ogrenimDurumuRef2[i % 4]}",
            ENGELLILIK_DURUMU = $"ENGELLILIK_DURUMU_{engellilikDurumuRef[i % 5]}"
        }).ToList());

        // PERSONEL_BORDRO_SONDURUM
        await SeedIfEmpty<PERSONEL_BORDRO_SONDURUM>(ct, personeller.Take(25).Select((p, i) => new PERSONEL_BORDRO_SONDURUM
        {
            PERSONEL_SONDURUM_KODU = $"PBS-{i + 1:D5}",
PERSONEL_KODU = p.PERSONEL_KODU,
            PERSONEL_KADEMESI = _random.Next(1, 4).ToString(),
            PERSONEL_DERECESI = _random.Next(1, 9).ToString(),
            EMEKLI_DERECESI = _random.Next(1, 9).ToString(),
            EMEKLI_KADEMESI = _random.Next(1, 4).ToString(),
            SENDIKA_BILGISI = new[] { "YOK", "SAGLIK_SEN", "GENEL_IS" }[i % 3],
            KIDEM_YILI = _random.Next(1, 30).ToString(),
            KIDEM_AYI = _random.Next(0, 12).ToString(),
            KIDEM_GUNU = _random.Next(0, 30).ToString(),
            EK_GOSTERGE = _random.Next(1000, 5000).ToString(),
            EMEKLI_EK_GOSTERGESI = _random.Next(1000, 5000).ToString(),
            GOSTERGE = _random.Next(500, 2000).ToString(),
            EMEKLI_GOSTERGESI = _random.Next(500, 2000).ToString(),
            YAN_ODEME_PUANI = _random.Next(50, 200).ToString(),
            OZEL_HIZMET_PUANI = _random.Next(50, 200).ToString()
        }).ToList());

        // PERSONEL_IZIN_DURUMU
        await SeedIfEmpty<PERSONEL_IZIN_DURUMU>(ct, personeller.Take(25).Select((p, i) => new PERSONEL_IZIN_DURUMU
        {
            PERSONEL_IZIN_DURUMU_KODU = $"PID-{i + 1:D5}",
PERSONEL_KODU = p.PERSONEL_KODU,
            KALAN_IZIN = _random.Next(0, 20).ToString(),
            YILLIK_IZIN_HAKKI = _random.Next(14, 30).ToString(),
            PERSONEL_IZIN_YILI = DateTime.Now.Year.ToString()
        }).ToList());

        // PERSONEL_ODUL_CEZA
        var odulCezaTuruRef = new[] { "IKRAMIYE", "TAKDIR", "UYARI", "KINAMA", "MAAS_KESINTISI" };
        foreach (var o in odulCezaTuruRef)
            await AddReferansKodIfNotExists("ODUL_CEZA_TURU", o, o, ct);
        await _db.SaveChangesAsync(ct);

        await SeedIfEmpty<PERSONEL_ODUL_CEZA>(ct, personeller.Take(25).Select((p, i) => new PERSONEL_ODUL_CEZA
        {
            PERSONEL_ODUL_CEZA_KODU = $"POC-{i + 1:D5}",
PERSONEL_KODU = p.PERSONEL_KODU,
            ODUL_CEZA_DURUMU = i % 2 == 0 ? "ODUL" : "CEZA",
            ODUL_CEZA_TURU = odulCezaTuruRef[i % 5],
            CEZA_BASLANGIC_TARIHI = DateTime.Now.AddDays(-_random.Next(30, 365)),
            CEZA_BITIS_TARIHI = DateTime.Now.AddDays(_random.Next(1, 90)),
            ODUL_CEZA_VEREN_KURUM_KODU = kurumlar.Any() ? kurumlar[i % kurumlar.Count].KURUM_KODU : $"KRM-{i + 1:D5}",
            ODUL_CEZA_ACIKLAMA = $"Ödül/Ceza açıklaması {i + 1}",
            TEBLIG_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 30)),
            TEBLIG_EVRAK_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 30)),
            TEBLIG_EVRAK_NUMARASI = $"TEV-{_random.Next(10000, 99999)}"
        }).ToList());

        // PERSONEL_YANDAL
        await SeedIfEmpty<PERSONEL_YANDAL>(ct, personeller.Take(25).Select((p, i) => new PERSONEL_YANDAL
        {
            PERSONEL_YANDAL_KODU = $"PYD-{i + 1:D5}",
PERSONEL_KODU = p.PERSONEL_KODU,
            YANDAL_BASLANGIC_TARIHI = DateTime.Now.AddYears(-_random.Next(1, 10)),
            YANDAL_BITIS_TARIHI = DateTime.Now.AddYears(_random.Next(1, 5)),
            MEDULA_BRANS_KODU = $"BRN-{_random.Next(100, 999)}"
        }).ToList());
        _logger.LogInformation("PERSONEL tabloları seeded (5 tablo)");

        // === STERILIZASYON TABLOLARI (3 TABLO) ===
        var sterilPaketler2 = await _db.Set<STERILIZASYON_PAKET>().Take(25).ToListAsync(ct);
        var depolar2 = await _db.Set<DEPO>().Take(10).ToListAsync(ct);
        var stokKartlar2 = await _db.Set<STOK_KART>().Take(25).ToListAsync(ct);
        var olcuRef = new[] { "ADET", "PAKET", "KUTU" };
        foreach (var o in olcuRef)
            await AddReferansKodIfNotExists("OLCU_KODU", o, o, ct);
        await _db.SaveChangesAsync(ct);

        // STERILIZASYON_PAKET_DETAY
        if (sterilPaketler2.Any() && stokKartlar2.Any())
        {
            await SeedIfEmpty<STERILIZASYON_PAKET_DETAY>(ct, sterilPaketler2.Take(25).Select((sp, i) => new STERILIZASYON_PAKET_DETAY
            {
                STERILIZASYON_PAKET_DETAY_KODU = $"SPD-{i + 1:D5}",
STERILIZASYON_PAKET_KODU = sp.STERILIZASYON_PAKET_KODU,
                STOK_KART_KODU = stokKartlar2[i % stokKartlar2.Count].STOK_KART_KODU,
                STERILIZASYON_MALZEME_MIKTARI = _random.Next(1, 10).ToString(),
                OLCU_KODU = olcuRef[i % 3],
                ACIKLAMA = $"Sterilizasyon paket detay {i + 1}"
            }).ToList());
        }

        // STERILIZASYON_STOK_DURUM
        if (depolar2.Any() && stokKartlar2.Any())
        {
            await SeedIfEmpty<STERILIZASYON_STOK_DURUM>(ct, stokKartlar2.Take(25).Select((sk, i) => new STERILIZASYON_STOK_DURUM
            {
                STERILIZASYON_STOK_DURUM_KODU = $"SSD-{i + 1:D5}",
DEPO_KODU = depolar2[i % depolar2.Count].DEPO_KODU,
                STOK_KART_KODU = sk.STOK_KART_KODU,
                STOK_MIKTARI = _random.Next(10, 100).ToString(),
                STERIL_OLMAYAN_STOK_MIKTARI = _random.Next(1, 20).ToString(),
                STERIL_STOK_MIKTARI = _random.Next(5, 80).ToString()
            }).ToList());
        }

        // STERILIZASYON_YIKAMA
        var yikamaTuruRef = new[] { "MAKINE", "MANUEL", "ULTRASONIK" };
        foreach (var y in yikamaTuruRef)
            await AddReferansKodIfNotExists("STERILIZASYON_YIKAMA_TURU", y, y, ct);
        await _db.SaveChangesAsync(ct);

        if (depolar2.Any() && stokKartlar2.Any())
        {
            await SeedIfEmpty<STERILIZASYON_YIKAMA>(ct, stokKartlar2.Take(25).Select((sk, i) => new STERILIZASYON_YIKAMA
            {
                STERILIZASYON_YIKAMA_KODU = $"SYK-{i + 1:D5}",
DEPO_KODU = depolar2[i % depolar2.Count].DEPO_KODU,
                STOK_KART_KODU = sk.STOK_KART_KODU,
                YIKANAN_ALET_MIKTARI = _random.Next(1, 20).ToString(),
                STERILIZASYON_YIKAMA_TURU = yikamaTuruRef[i % 3],
                YIKAMA_YAPAN_PERSONEL_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                YIKAMA_BASLAMA_ZAMANI = DateTime.Now.AddHours(-_random.Next(1, 24)),
                YIKAMA_BITIS_ZAMANI = DateTime.Now.AddHours(-_random.Next(0, 12))
            }).ToList());
        }
        _logger.LogInformation("STERILIZASYON tabloları seeded (3 tablo)");

        // === STOK TABLOLARI (3 TABLO) ===
        var stokIstekler = await _db.Set<STOK_ISTEK>().Take(25).ToListAsync(ct);
        var stokIstekRetNedeniRef = new[] { "STOK_YOK", "ONAY_YOK", "YANLIS_ISTEK", "DIGER" };
        var ilacJenerikRef = new[] { "PARASETAMOL", "IBUPROFEN", "AMOKSISILIN", "METFORMIN" };
        foreach (var r in stokIstekRetNedeniRef)
            await AddReferansKodIfNotExists("STOK_ISTEK_RET_NEDENI", r, r, ct);
        foreach (var j in ilacJenerikRef)
            await AddReferansKodIfNotExists("ISTENEN_ILAC_JENERIK_KODU", j, j, ct);
        await _db.SaveChangesAsync(ct);

        // STOK_ISTEK_HAREKET
        if (stokIstekler.Any() && stokKartlar2.Any())
        {
            await SeedIfEmpty<STOK_ISTEK_HAREKET>(ct, stokIstekler.Take(25).Select((si, i) => new STOK_ISTEK_HAREKET
            {
                STOK_ISTEK_HAREKET_KODU = $"SIH-{i + 1:D5}",
STOK_ISTEK_KODU = si.STOK_ISTEK_KODU,
                ISTENEN_STOK_KART_KODU = stokKartlar2[i % stokKartlar2.Count].STOK_KART_KODU,
                ISTENEN_ILAC_JENERIK_KODU = ilacJenerikRef[i % 4],
                VERILEN_STOK_KART_KODU = stokKartlar2[i % stokKartlar2.Count].STOK_KART_KODU,
                ISTEK_GEREKLILIK_DURUMU = "GEREKLI",
                TEDAVIDE_KULLANILAN_ILAC = "EVET",
                ISTENEN_MIKTAR = _random.Next(1, 10).ToString(),
                ACIKLAMA = $"Stok istek hareket {i + 1}",
                DEPODAN_VERILEN_MIKTAR = _random.Next(1, 10).ToString(),
                STOK_ISTEK_RET_NEDENI = stokIstekRetNedeniRef[i % 4],
                STOK_ISTEK_RET_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                STOK_ISTEK_RET_KULLANICI_KODU = kullanicilar2.Any() ? kullanicilar2[i % kullanicilar2.Count].KULLANICI_KODU : $"KLN-{i + 1:D5}"
            }).ToList());
        }

        // STOK_ISTEK_UYGULAMA
        var stokIstekHareketler = await _db.Set<STOK_ISTEK_HAREKET>().Take(25).ToListAsync(ct);
        var istekIptalNedeniRef = new[] { "HASTA_CIKMIS", "DOKTOR_IPTALI", "STOK_YOK", "DIGER" };
        foreach (var ipn in istekIptalNedeniRef)
            await AddReferansKodIfNotExists("ISTEK_IPTAL_NEDENI", ipn, ipn, ct);
        await _db.SaveChangesAsync(ct);

        if (stokIstekHareketler.Any())
        {
            await SeedIfEmpty<STOK_ISTEK_UYGULAMA>(ct, stokIstekHareketler.Take(25).Select((sih, i) => new STOK_ISTEK_UYGULAMA
            {
                STOK_ISTEK_UYGULAMA_KODU = $"SIU-{i + 1:D5}",
STOK_ISTEK_HAREKET_KODU = sih.STOK_ISTEK_HAREKET_KODU,
                ORDER_PLANLANAN_ZAMAN = DateTime.Now.AddHours(-_random.Next(1, 48)),
                ORDER_UYGULANAN_ZAMAN = DateTime.Now.AddHours(-_random.Next(0, 24)),
                UYGULAYAN_HEMSIRE_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                ISTEK_IPTAL_NEDENI = istekIptalNedeniRef[i % 4],
                IPTAL_EDEN_HEMSIRE_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                IPTAL_ZAMANI = DateTime.Now.AddDays(30),
                UYGULANAN_MIKTAR = _random.Next(1, 5).ToString(),
                ACIKLAMA = $"Stok istek uygulama {i + 1}"
            }).ToList());
        }

        // STOK_EHU_TAKIP
        var ehuRetNedeniRef = new[] { "ENDIKASYON_YOK", "DOZ_UYUMSUZ", "ALTERNATIF_VAR", "DIGER" };
        foreach (var e in ehuRetNedeniRef)
            await AddReferansKodIfNotExists("EHU_RET_NEDENI", e, e, ct);
        await _db.SaveChangesAsync(ct);

        if (stokIstekler.Any() && stokIstekHareketler.Any() && stokKartlar2.Any())
        {
            await SeedIfEmpty<STOK_EHU_TAKIP>(ct, stokIstekler.Take(25).Select((si, i) => new STOK_EHU_TAKIP
            {
                STOK_EHU_TAKIP_KODU = $"SEH-{i + 1:D5}",
STOK_ISTEK_KODU = si.STOK_ISTEK_KODU,
                STOK_ISTEK_HAREKET_KODU = stokIstekHareketler.Any() ? stokIstekHareketler[i % stokIstekHareketler.Count].STOK_ISTEK_HAREKET_KODU : $"SIH-{i + 1:D5}",
                STOK_KART_KODU = stokKartlar2[i % stokKartlar2.Count].STOK_KART_KODU,
                EHU_ONAY_BASLAMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                EHU_ONAY_BITIS_ZAMANI = DateTime.Now.AddDays(_random.Next(1, 30)),
                EHU_ILAC_MAKSIMUM_MIKTAR = _random.Next(10, 100).ToString(),
                ACIKLAMA = $"EHU takip kaydı {i + 1}",
                EHU_ONAYLAMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 10)),
                ONAYLAYAN_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                EHU_RET_NEDENI = ehuRetNedeniRef[i % 4],
                EHU_RET_ZAMANI = DateTime.Now.AddDays(30),
                EHU_RET_PERSONEL_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                EHU_RET_ACIKLAMA = $"EHU ret açıklama {i + 1}"
            }).ToList());
        }
        _logger.LogInformation("STOK tabloları seeded (3 tablo)");

        // === DİĞER TABLOLAR ===

        // RISK_SKORLAMA_DETAY
        var riskSkorlamalar = await _db.Set<RISK_SKORLAMA>().Take(25).ToListAsync(ct);
        var riskSkorlamaAltTuruRef = new[] { "DUSME_RISKI", "BASI_RISKI", "BESLENME_RISKI" };
        foreach (var r in riskSkorlamaAltTuruRef)
            await AddReferansKodIfNotExists("RISK_SKORLAMA_ALT_TURU", r, r, ct);
        await _db.SaveChangesAsync(ct);

        if (riskSkorlamalar.Any())
        {
            await SeedIfEmpty<RISK_SKORLAMA_DETAY>(ct, riskSkorlamalar.Take(25).Select((rs, i) => new RISK_SKORLAMA_DETAY
            {
                RISK_SKORLAMA_DETAY_KODU = $"RSD-{i + 1:D5}",
RISK_SKORLAMA_KODU = rs.RISK_SKORLAMA_KODU,
                GLASGOW_SKALASI = _random.Next(3, 15).ToString(),
                RISK_SKORLAMA_ALT_TURU = riskSkorlamaAltTuruRef[i % 3],
                RISK_SKOR_DEGERI = _random.Next(0, 100).ToString(),
                ACIKLAMA = $"Risk skorlama detay {i + 1}"
            }).ToList());
        }
        _logger.LogInformation("RISK_SKORLAMA_DETAY seeded");

        // SILINEN_KAYITLAR
        await SeedIfEmpty<SILINEN_KAYITLAR>(ct, Enumerable.Range(1, 25).Select(i => new SILINEN_KAYITLAR
        {
            SILINEN_KAYITLAR_KODU = $"SLK-{i:D5}",
            REFERANS_GORUNTU_ADI = new[] { "HASTA", "HASTA_BASVURU", "RANDEVU", "RECETE" }[i % 4],
            SILINME_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 365)),
            SILINEN_KAYDIN_KODU = $"SIL-{_random.Next(10000, 99999)}"
        }).ToList());
        _logger.LogInformation("SILINEN_KAYITLAR seeded");

        // SYS_PAKET
        await SeedIfEmpty<SYS_PAKET>(ct, basvurular.Take(25).Select((b, i) => new SYS_PAKET
        {
            SYS_PAKET_KODU = $"SYP-{i + 1:D5}",
HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            HASTA_KODU = b.HASTA_KODU,
            VERI_PAKETI_NUMARASI = $"VPN-{_random.Next(100000, 999999)}",
            VERI_PAKETI_GONDERILME_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
            VERI_PAKETI_GONDERIM_DURUMU = i % 2 == 0 ? "GONDERILDI" : "BEKLEMEDE",
            GONDERILEN_PAKET_BILGISI = $"{{\"hasta\":\"{b.HASTA_KODU}\",\"basvuru\":\"{b.HASTA_BASVURU_KODU}\"}}",
            GELEN_CEVAP_BILGISI = $"{{\"status\":\"OK\",\"code\":{_random.Next(200, 299)}}}"
        }).ToList());
        _logger.LogInformation("SYS_PAKET seeded");

        _logger.LogInformation("Eksik 24 tablo seeding tamamlandı!");

        // === AMELIYAT TABLOLARI ===

        // AMELIYAT referans kodları
        var ameliyatTuruRef = new[] { "ACIL", "ELEKTIF", "POLIKLINIK" };
        var ameliyatDurumuRef = new[] { "PLANLANDI", "DEVAM_EDIYOR", "TAMAMLANDI", "IPTAL" };
        var anesteziTuruRef = new[] { "GENEL", "LOKAL", "SPINAL", "EPIDURAL", "SEDASYON" };
        var ameliyatTipiRef = new[] { "MAJÖR", "MINÖR", "ORTA" };
        var profilaksiPeriyoduRef = new[] { "24_SAAT", "48_SAAT", "72_SAAT" };
        var profilaksiKoduRef = new[] { "PROF_001", "PROF_002", "PROF_003" };

        foreach (var r in ameliyatTuruRef) await AddReferansKodIfNotExists("AMELIYAT_TURU", r, r, ct);
        foreach (var r in ameliyatDurumuRef) await AddReferansKodIfNotExists("AMELIYAT_DURUMU", r, r, ct);
        foreach (var r in anesteziTuruRef) await AddReferansKodIfNotExists("ANESTEZI_TURU", r, r, ct);
        foreach (var r in ameliyatTipiRef) await AddReferansKodIfNotExists("AMELIYAT_TIPI", r, r, ct);
        foreach (var r in profilaksiPeriyoduRef) await AddReferansKodIfNotExists("PROFILAKSI_PERIYODU", r, r, ct);
        foreach (var r in profilaksiKoduRef) await AddReferansKodIfNotExists("PROFILAKSI_KODU", r, r, ct);
        await _db.SaveChangesAsync(ct);

        var cihazlarAml = await _db.Set<CIHAZ>().Take(25).ToListAsync(ct);

        // AMELIYAT
        await SeedIfEmpty<AMELIYAT>(ct, basvurular.Take(25).Select((b, i) => new AMELIYAT
        {
            AMELIYAT_KODU = $"AML-{i + 1:D5}",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            AMELIYAT_ADI = new[] { "Apandektomi", "Kolesistektomi", "Herni Onarımı", "Artroskopi", "Laparoskopi" }[i % 5],
            AMELIYAT_TURU = $"AMELIYAT_TURU_{ameliyatTuruRef[i % 3]}",
            AMELIYAT_BASLAMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 90)).AddHours(_random.Next(8, 16)),
            AMELIYAT_BITIS_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 90)).AddHours(_random.Next(10, 20)),
            MASA_CIHAZ_KODU = cihazlarAml.Any() ? cihazlarAml[i % cihazlarAml.Count].CIHAZ_KODU : null,
            BIRIM_KODU = birimler[i % birimler.Count].BIRIM_KODU,
            DEFTER_NUMARASI = $"DEF-{_random.Next(1000, 9999)}",
            AMELIYAT_DURUMU = $"AMELIYAT_DURUMU_{ameliyatDurumuRef[i % 4]}",
            ANESTEZI_TURU = $"ANESTEZI_TURU_{anesteziTuruRef[i % 5]}",
            ANESTEZI_NOTU = $"Anestezi notu {i + 1}",
            ANESTEZI_BASLAMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 90)).AddHours(_random.Next(7, 15)),
            ANESTEZI_BITIS_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 90)).AddHours(_random.Next(11, 21)),
            AMELIYAT_TIPI = $"AMELIYAT_TIPI_{ameliyatTipiRef[i % 3]}",
            SKOPI_SURESI = $"{_random.Next(5, 60)}",
            PROFILAKSI_PERIYODU = $"PROFILAKSI_PERIYODU_{profilaksiPeriyoduRef[i % 3]}",
            PROFILAKSI_KODU = $"PROFILAKSI_KODU_{profilaksiKoduRef[i % 3]}"
        }).ToList());
        _logger.LogInformation("AMELIYAT seeded");

        // AMELIYAT_ISLEM referans kodları
        var kesiOraniRef = new[] { "TAM", "YARIM", "UCTE_BIR" };
        var kesiSeansBilgisiRef = new[] { "TEK_KESI", "COKLU_KESI", "SEANS_KESI" };
        var tarafBilgisiRef = new[] { "SAG", "SOL", "BILATERAL", "ORTA" };
        var asaSkoruRef = new[] { "ASA_I", "ASA_II", "ASA_III", "ASA_IV" };
        var euroscoreRef = new[] { "DUSUK", "ORTA", "YUKSEK" };
        var yaraSinifiRef = new[] { "TEMIZ", "TEMIZ_KONTAMINE", "KONTAMINE", "KIRLI" };

        foreach (var r in kesiOraniRef) await AddReferansKodIfNotExists("KESI_ORANI", r, r, ct);
        foreach (var r in kesiSeansBilgisiRef) await AddReferansKodIfNotExists("KESI_SEANS_BILGISI", r, r, ct);
        foreach (var r in tarafBilgisiRef) await AddReferansKodIfNotExists("TARAF_BILGISI", r, r, ct);
        foreach (var r in asaSkoruRef) await AddReferansKodIfNotExists("ASA_SKORU", r, r, ct);
        foreach (var r in euroscoreRef) await AddReferansKodIfNotExists("EUROSCORE", r, r, ct);
        foreach (var r in yaraSinifiRef) await AddReferansKodIfNotExists("YARA_SINIFI", r, r, ct);
        await _db.SaveChangesAsync(ct);

        var ameliyatlarNew = await _db.Set<AMELIYAT>().Take(25).ToListAsync(ct);

        // AMELIYAT_ISLEM
        if (ameliyatlarNew.Any() && hastaHizmetler.Any())
        {
            await SeedIfEmpty<AMELIYAT_ISLEM>(ct, ameliyatlarNew.Take(25).Select((a, i) => new AMELIYAT_ISLEM
            {
                AMELIYAT_ISLEM_KODU = $"AMI-{i + 1:D5}",
                AMELIYAT_KODU = a.AMELIYAT_KODU,
                AMELIYAT_GRUBU = new[] { "A1", "A2", "B1", "B2", "C1" }[i % 5],
                HASTA_HIZMET_KODU = hastaHizmetler[i % hastaHizmetler.Count].HASTA_HIZMET_KODU,
                KESI_SAYISI = $"{_random.Next(1, 5)}",
                KESI_ORANI = $"KESI_ORANI_{kesiOraniRef[i % 3]}",
                KESI_SEANS_BILGISI = $"KESI_SEANS_BILGISI_{kesiSeansBilgisiRef[i % 3]}",
                TARAF_BILGISI = $"TARAF_BILGISI_{tarafBilgisiRef[i % 4]}",
                KOMPLIKASYON = i % 5 == 0 ? "Kanama" : "Yok",
                AMELIYAT_SONUCU = new[] { "Başarılı", "Komplikasyonlu", "Takip Gerekli" }[i % 3],
                AMELIYAT_NOTU = $"Ameliyat notu detay {i + 1}",
                ASA_SKORU = $"ASA_SKORU_{asaSkoruRef[i % 4]}",
                EUROSCORE = $"EUROSCORE_{euroscoreRef[i % 3]}",
                YARA_SINIFI = $"YARA_SINIFI_{yaraSinifiRef[i % 4]}"
            }).ToList());
        }
        _logger.LogInformation("AMELIYAT_ISLEM seeded");

        // AMELIYAT_EKIP referans kodları
        var ameliyatPersonelGorevRef = new[] { "OPERATOR", "ASISTAN", "ANESTEZIST", "HEMSIRE", "TEKNISYEN" };
        foreach (var r in ameliyatPersonelGorevRef) await AddReferansKodIfNotExists("AMELIYAT_PERSONEL_GOREV", r, r, ct);
        await _db.SaveChangesAsync(ct);

        var ameliyatIslemler = await _db.Set<AMELIYAT_ISLEM>().Take(25).ToListAsync(ct);

        // AMELIYAT_EKIP
        if (ameliyatlarNew.Any() && ameliyatIslemler.Any())
        {
            await SeedIfEmpty<AMELIYAT_EKIP>(ct, ameliyatlarNew.Take(25).Select((a, i) => new AMELIYAT_EKIP
            {
                AMELIYAT_EKIP_KODU = $"AEK-{i + 1:D5}",
                AMELIYAT_KODU = a.AMELIYAT_KODU,
                AMELIYAT_ISLEM_KODU = ameliyatIslemler[i % ameliyatIslemler.Count].AMELIYAT_ISLEM_KODU,
                EKIP_NUMARASI = $"EKP-{i + 1:D3}",
                PERSONEL_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                AMELIYAT_PERSONEL_GOREV = $"AMELIYAT_PERSONEL_GOREV_{ameliyatPersonelGorevRef[i % 5]}"
            }).ToList());
        }
        _logger.LogInformation("AMELIYAT_EKIP seeded");

        // === KAN TABLOLARI ===

        // KAN_URUN
        var hizmetler = await _db.Set<HIZMET>().Take(25).ToListAsync(ct);

        await SeedIfEmpty<KAN_URUN>(ct, Enumerable.Range(1, 25).Select(i => new KAN_URUN
        {
            KAN_URUN_KODU = $"KUR-{i:D5}",
            KAN_URUN_ADI = new[] { "Eritrosit Süspansiyonu", "Taze Donmuş Plazma", "Trombosit Konsantresi", "Tam Kan", "Kriyopresipitat" }[i % 5],
            HIZMET_KODU = hizmetler.Any() ? hizmetler[i % hizmetler.Count].HIZMET_KODU : null,
            KAN_MIAT_SURESI = $"{_random.Next(7, 42)}",
            KAN_MIAT_PERIYODU = "GUN",
            KIZILAY_BILESEN_TURU = new[] { "ES", "TDP", "TS", "TK", "KRYO" }[i % 5],
            KAN_FILTRELEME_UYGUNLUK = "1",
            KAN_YIKAMA_UYGUNLUK_DURUMU = "1",
            KAN_ISINLAMA_UYGUNLUK_DURUMU = "1",
            KAN_HAVUZLAMA_UYGUNLUK = i % 3 == 0 ? "1" : "0",
            KAN_AYIRMA_UYGUNLUK = "1",
            KAN_BOLME_UYGUNLUK = i % 2 == 0 ? "1" : "0",
            BUFFYCOAT_UZAKLASTIRMAYA_UYGUN = "1"
        }).ToList());
        _logger.LogInformation("KAN_URUN seeded");

        // KAN_BAGISCI referans kodları
        var kanGrubuRefNew = new[] { "A_RH_POZITIF", "A_RH_NEGATIF", "B_RH_POZITIF", "B_RH_NEGATIF", "AB_RH_POZITIF", "AB_RH_NEGATIF", "O_RH_POZITIF", "O_RH_NEGATIF" };
        var bagislananKanTuruRef = new[] { "TAM_KAN", "AFEREZ_TROMBOSIT", "AFEREZ_PLAZMA", "ERITROSIT" };
        var reaksiyonTuruRef = new[] { "HAFIF", "ORTA", "AGIR", "YOK" };
        var bagisciTuruRef = new[] { "GONULLU", "HASTA_YAKINI", "OTOLOG" };
        var kanBagisDegerlendirmeSonucuRef = new[] { "ONAYLI", "GECICI_RET", "KALICI_RET" };
        var kanBagiscisiRetNedenleriRef = new[] { "ANEMI", "ENFEKSIYON", "ILAÇ_KULLANIMI", "YAS_SINIRI", "AGIRLIK_SINIRI" };

        foreach (var r in kanGrubuRefNew) await AddReferansKodIfNotExists("KAN_GRUBU", r, r, ct);
        foreach (var r in bagislananKanTuruRef) await AddReferansKodIfNotExists("BAGISLANAN_KAN_TURU", r, r, ct);
        foreach (var r in reaksiyonTuruRef) await AddReferansKodIfNotExists("REAKSIYON_TURU", r, r, ct);
        foreach (var r in bagisciTuruRef) await AddReferansKodIfNotExists("BAGISCI_TURU", r, r, ct);
        foreach (var r in kanBagisDegerlendirmeSonucuRef) await AddReferansKodIfNotExists("KAN_BAGIS_DEGERLENDIRME_SONUCU", r, r, ct);
        foreach (var r in kanBagiscisiRetNedenleriRef) await AddReferansKodIfNotExists("KAN_BAGISCISI_RET_NEDENLERI", r, r, ct);
        await _db.SaveChangesAsync(ct);

        // KAN_BAGISCI
        await SeedIfEmpty<KAN_BAGISCI>(ct, basvurular.Take(25).Select((b, i) => new KAN_BAGISCI
        {
            KAN_BAGISCI_KODU = $"KBG-{i + 1:D5}",
            BAGISCI_HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            BAGISCI_HASTA_KODU = b.HASTA_KODU,
            KAN_BAGIS_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 180)),
            KAN_GRUBU = $"KAN_GRUBU_{kanGrubuRefNew[i % 8]}",
            ACIKLAMA = $"Kan bağışı açıklaması {i + 1}",
            REZERV_HASTA_KODU = hastalar[i % hastalar.Count].HASTA_KODU,
            BAGISLANAN_KAN_TURU = $"BAGISLANAN_KAN_TURU_{bagislananKanTuruRef[i % 4]}",
            REAKSIYON_DURUMU = i % 5 == 0 ? "1" : "0",
            REAKSIYON_TURU = $"REAKSIYON_TURU_{reaksiyonTuruRef[i % 4]}",
            REAKSIYON_ACIKLAMA = i % 5 == 0 ? "Hafif reaksiyon gözlendi" : "Reaksiyon yok",
            KIZILAY_IZIN_NUMARASI = $"KIZ-{_random.Next(100000, 999999)}",
            SISTOLIK_KAN_BASINCI_DEGERI = $"{_random.Next(110, 140)}",
            DIASTOLIK_KAN_BASINCI_DEGERI = $"{_random.Next(70, 90)}",
            ATES = $"{_random.Next(36, 38)}.{_random.Next(0, 9)}",
            BOY = $"{_random.Next(155, 195)}",
            AGIRLIK = $"{_random.Next(55000, 100000)}",
            UZMAN_DEGERLENDIRME = $"Bağışçı uygun {i + 1}",
            LOT_NUMARASI = $"LOT-{_random.Next(10000, 99999)}",
            KAN_HACIM = $"{_random.Next(400, 500)}",
            SEGMENT_NUMARASI = $"SEG-{_random.Next(1000, 9999)}",
            BAGISCI_TURU = $"BAGISCI_TURU_{bagisciTuruRef[i % 3]}",
            KAN_BAGIS_DEGERLENDIRME_SONUCU = $"KAN_BAGIS_DEGERLENDIRME_SONUCU_{kanBagisDegerlendirmeSonucuRef[i % 3]}",
            DEGERLENDIREN_PERSONEL_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
            KAN_BAGIS_DEGERLENDIRME_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 180)),
            KAN_BAGISCISI_RET_NEDENLERI = $"KAN_BAGISCISI_RET_NEDENLERI_{kanBagiscisiRetNedenleriRef[i % 5]}",
            RET_SURESI = $"{_random.Next(7, 365)}"
        }).ToList());
        _logger.LogInformation("KAN_BAGISCI seeded");

        // KAN_STOK referans kodları
        var kanStokDurumuRef = new[] { "MEVCUT", "REZERVE", "KULLANILDI", "IMHA" };
        foreach (var r in kanStokDurumuRef) await AddReferansKodIfNotExists("KAN_STOK_DURUMU", r, r, ct);
        await _db.SaveChangesAsync(ct);

        var kanUrunlerNew = await _db.Set<KAN_URUN>().Take(25).ToListAsync(ct);
        var kanBagiscilar = await _db.Set<KAN_BAGISCI>().Take(25).ToListAsync(ct);
        var kurumlarNew = await _db.Set<KURUM>().Take(25).ToListAsync(ct);

        // KAN_STOK - self-referencing için önce ana kayıtları oluştur
        var kanStokListesi = new List<KAN_STOK>();
        for (int i = 0; i < 25; i++)
        {
            kanStokListesi.Add(new KAN_STOK
            {
                KAN_STOK_KODU = $"KST-{i + 1:D5}",
                KAN_STOK_DURUMU = $"KAN_STOK_DURUMU_{kanStokDurumuRef[i % 4]}",
                KAN_STOK_GIRIS_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 90)),
                DEFTER_NUMARASI = $"KDF-{_random.Next(1000, 9999)}",
                KAN_GRUBU = $"KAN_GRUBU_{kanGrubuRefNew[i % 8]}",
                KAN_URUN_KODU = kanUrunlerNew.Any() ? kanUrunlerNew[i % kanUrunlerNew.Count].KAN_URUN_KODU : null,
                KAN_BAGISCI_KODU = kanBagiscilar.Any() ? kanBagiscilar[i % kanBagiscilar.Count].KAN_BAGISCI_KODU : $"KBG-{(i % 25) + 1:D5}",
                KURUM_KODU = kurumlarNew.Any() ? kurumlarNew[i % kurumlarNew.Count].KURUM_KODU : $"KRM-{i + 1:D5}",
                BIRIM_KODU = birimler[i % birimler.Count].BIRIM_KODU,
                BAGLI_KAN_STOK_KODU = $"KST-{((i + 1) % 25) + 1:D5}",
                ISBT_UNITE_NUMARASI = $"ISBT-U-{_random.Next(100000, 999999)}",
                ISBT_BILESEN_NUMARASI = $"ISBT-B-{_random.Next(10000, 99999)}",
                KAN_HACIM = $"{_random.Next(250, 500)}",
                KAN_BAGIS_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 90)),
                KAN_FILTRELEME_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 90)),
                KAN_ISINLAMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 90)),
                KAN_YIKAMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 90)),
                KAN_AYIRMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 90)),
                KAN_BOLME_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 90)),
                BUFFYCOAT_UZAKLASTIRMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 90)),
                KAN_HAVUZLAMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 90)),
                SON_KULLANMA_TARIHI = DateTime.Now.AddDays(_random.Next(7, 42))
            });
        }
        await SeedIfEmpty<KAN_STOK>(ct, kanStokListesi);
        _logger.LogInformation("KAN_STOK seeded");

        // KAN_TALEP referans kodları
        var kanTalepNedeniRef = new[] { "AMELIYAT", "TRANSFUZYON", "ACIL", "PLANLI_TEDAVI" };
        var kanTalepAciliyetSeviyesiRef = new[] { "ACIL", "RUTIN", "PLANLI" };
        var kanEndikasyonTuruRef = new[] { "ANEMI", "KANAMA", "AMELIYAT_ONCESI", "KEMIK_ILIGI_NAKLI" };

        foreach (var r in kanTalepNedeniRef) await AddReferansKodIfNotExists("KAN_TALEP_NEDENI", r, r, ct);
        foreach (var r in kanTalepAciliyetSeviyesiRef) await AddReferansKodIfNotExists("KAN_TALEP_ACILIYET_SEVIYESI", r, r, ct);
        foreach (var r in kanEndikasyonTuruRef) await AddReferansKodIfNotExists("KAN_ENDIKASYON_TURU", r, r, ct);
        foreach (var r in kanGrubuRefNew) await AddReferansKodIfNotExists("ISTENEN_KAN_GRUBU", r, r, ct);
        await _db.SaveChangesAsync(ct);

        // KAN_TALEP
        await SeedIfEmpty<KAN_TALEP>(ct, basvurular.Take(25).Select((b, i) => new KAN_TALEP
        {
            KAN_TALEP_KODU = $"KTL-{i + 1:D5}",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            KAN_TALEP_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 60)),
            KAN_TALEP_ACIKLAMA = $"Kan talebi açıklaması {i + 1}",
            KAN_TALEP_NEDENI = $"KAN_TALEP_NEDENI_{kanTalepNedeniRef[i % 4]}",
            KAN_ISTEYEN_BIRIM_KODU = birimler[i % birimler.Count].BIRIM_KODU,
            ISTEYEN_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
            ISTENEN_KAN_GRUBU = $"ISTENEN_KAN_GRUBU_{kanGrubuRefNew[i % 8]}",
            PLANLANAN_TRANSFUZYON_ZAMANI = DateTime.Now.AddDays(_random.Next(1, 7)),
            PLANLANAN_TRANSFUZYON_SURESI = $"{_random.Next(30, 240)}",
            KAN_TALEP_ACILIYET_SEVIYESI = $"KAN_TALEP_ACILIYET_SEVIYESI_{kanTalepAciliyetSeviyesiRef[i % 3]}",
            CROSS_MATCH_YAPILMA_DURUMU = i % 2 == 0 ? "1" : "0",
            KAN_ACIL_ACIKLAMA = i % 3 == 0 ? "Acil ameliyat" : "Rutin işlem",
            KAN_ANTIKOR_DURUMU = i % 4 == 0 ? "1" : "0",
            TRANSPLANTASYON_GECIRME_DURUMU = i % 10 == 0 ? "1" : "0",
            TRANSFUZYON_GECIRME_DURUMU = i % 3 == 0 ? "1" : "0",
            TRANSFUZYON_REAKSIYON_DURUMU = i % 8 == 0 ? "1" : "0",
            GEBELIK_GECIRME_DURUMU = i % 2 == 0 ? "1" : "0",
            FETOMATERNAL_UYUSMAZLIK_DURUMU = i % 15 == 0 ? "1" : "0",
            KAN_TALEP_OZEL_DURUM = i % 5 == 0 ? "Özel durum mevcut" : "Yok",
            HEMATOKRIT_ORANI = $"{_random.Next(30, 50)}.{_random.Next(0, 9)}",
            TROMBOSIT_SAYISI = $"{_random.Next(150000, 450000)}",
            KAN_ENDIKASYON_TURU = $"KAN_ENDIKASYON_TURU_{kanEndikasyonTuruRef[i % 4]}"
        }).ToList());
        _logger.LogInformation("KAN_TALEP seeded");

        // KAN_TALEP_DETAY referans kodları
        var kanTalepRetNedeniRef = new[] { "STOK_YOK", "UYGUN_GRUP_YOK", "HEKIM_IPTALI", "HASTA_IPTALI" };
        foreach (var r in kanTalepRetNedeniRef) await AddReferansKodIfNotExists("KAN_TALEP_RET_NEDENI", r, r, ct);
        await _db.SaveChangesAsync(ct);

        var kanTaleplerNew = await _db.Set<KAN_TALEP>().Take(25).ToListAsync(ct);
        var kullanicilarNew = await _db.Set<KULLANICI>().Take(25).ToListAsync(ct);

        // KAN_TALEP_DETAY
        if (kanTaleplerNew.Any() && kanUrunlerNew.Any() && kullanicilarNew.Any())
        {
            await SeedIfEmpty<KAN_TALEP_DETAY>(ct, kanTaleplerNew.Take(25).Select((kt, i) => new KAN_TALEP_DETAY
            {
                KAN_TALEP_DETAY_KODU = $"KTD-{i + 1:D5}",
                KAN_TALEP_KODU = kt.KAN_TALEP_KODU,
                KAN_URUN_KODU = kanUrunlerNew[i % kanUrunlerNew.Count].KAN_URUN_KODU,
                ISTENEN_KAN_GRUBU = $"ISTENEN_KAN_GRUBU_{kanGrubuRefNew[i % 8]}",
                RET_TARIHI = DateTime.Now.AddDays(30),
                RET_EDEN_KULLANICI_KODU = kullanicilarNew[i % kullanicilarNew.Count].KULLANICI_KODU,
                KAN_TALEP_RET_NEDENI = $"KAN_TALEP_RET_NEDENI_{kanTalepRetNedeniRef[i % 4]}",
                KAN_TALEP_MIKTARI = $"{_random.Next(1, 5)}",
                KAN_HACIM = $"{_random.Next(250, 500)}",
                ACIKLAMA = $"Kan talep detay açıklaması {i + 1}",
                BUFFYCOAT_UZAKLASTIRMA_DURUMU = i % 3 == 0 ? "1" : "0",
                KAN_FILTRELEME_DURUMU = i % 2 == 0 ? "1" : "0",
                KAN_ISINLAMA_DURUMU = i % 4 == 0 ? "1" : "0",
                KAN_YIKAMA_DURUMU = i % 5 == 0 ? "1" : "0"
            }).ToList());
        }
        _logger.LogInformation("KAN_TALEP_DETAY seeded");

        // KAN_CIKIS referans kodları
        var crossMatchCalismaYontemiRef = new[] { "TUP", "JEL", "KOLON" };
        var crossMatchSonucuRefNew = new[] { "UYUMLU", "UYUMSUZ", "ZAYIF_POZITIF" };

        foreach (var r in crossMatchCalismaYontemiRef) await AddReferansKodIfNotExists("CROSS_MATCH_CALISMA_YONTEMI", r, r, ct);
        foreach (var r in crossMatchSonucuRefNew) await AddReferansKodIfNotExists("CROSS_MATCH_SONUCU", r, r, ct);
        await _db.SaveChangesAsync(ct);

        var kanTalepDetaylarNew = await _db.Set<KAN_TALEP_DETAY>().Take(25).ToListAsync(ct);
        var kanStoklarNew = await _db.Set<KAN_STOK>().Take(25).ToListAsync(ct);

        // KAN_CIKIS
        if (kanTalepDetaylarNew.Any() && kanStoklarNew.Any() && kullanicilarNew.Any())
        {
            await SeedIfEmpty<KAN_CIKIS>(ct, kanTalepDetaylarNew.Take(25).Select((ktd, i) => new KAN_CIKIS
            {
                KAN_CIKIS_KODU = $"KCK-{i + 1:D5}",
                KAN_TALEP_DETAY_KODU = ktd.KAN_TALEP_DETAY_KODU,
                HASTA_KODU = hastalar[i % hastalar.Count].HASTA_KODU,
                HASTA_BASVURU_KODU = basvurular[i % basvurular.Count].HASTA_BASVURU_KODU,
                KAN_STOK_KODU = kanStoklarNew[i % kanStoklarNew.Count].KAN_STOK_KODU,
                KANI_TESLIM_ALAN_KISI = $"Hemşire {i + 1}",
                KAN_CIKIS_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                KURUM_KODU = kurumlarNew.Any() ? kurumlarNew[i % kurumlarNew.Count].KURUM_KODU : $"KRM-{i + 1:D5}",
                KAN_CIKIS_PERSONEL_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                REZERVE_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                REZERVE_EDEN_KULLANICI_KODU = kullanicilarNew[i % kullanicilarNew.Count].KULLANICI_KODU,
                CROSS_MATCH_KULLANICI_KODU = kullanicilarNew[i % kullanicilarNew.Count].KULLANICI_KODU,
                CROSS_MATCH_CALISMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                CROSS_MATCH_CALISMA_YONTEMI = $"CROSS_MATCH_CALISMA_YONTEMI_{crossMatchCalismaYontemiRef[i % 3]}",
                CROSS_MATCH_SONUCU = $"CROSS_MATCH_SONUCU_{crossMatchSonucuRefNew[i % 3]}"
            }).ToList());
        }
        _logger.LogInformation("KAN_CIKIS seeded");
        _logger.LogInformation("KAN tabloları seeded (6 tablo)");

        // === RECETE TABLOLARI ===

        // RECETE referans kodları
        var receteTuruRef = new[] { "NORMAL", "YESIL", "KIRMIZI", "TURUNCU", "MOR" };
        var receteAltTuruRef = new[] { "AYAKTAN", "YATAN", "ACIL", "SERVIS" };

        foreach (var r in receteTuruRef) await AddReferansKodIfNotExists("RECETE_TURU", r, r, ct);
        foreach (var r in receteAltTuruRef) await AddReferansKodIfNotExists("RECETE_ALT_TURU", r, r, ct);
        await _db.SaveChangesAsync(ct);

        // RECETE
        await SeedIfEmpty<RECETE>(ct, basvurular.Take(25).Select((b, i) => new RECETE
        {
            RECETE_KODU = $"RCT-{i + 1:D5}",
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            HASTA_KODU = b.HASTA_KODU,
            RECETE_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 90)),
            RECETE_TURU = $"RECETE_TURU_{receteTuruRef[i % 5]}",
            RECETE_ALT_TURU = $"RECETE_ALT_TURU_{receteAltTuruRef[i % 4]}",
            HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
            DEFTER_NUMARASI = $"RDF-{_random.Next(1000, 9999)}",
            MEDULA_E_RECETE_NUMARASI = $"MED-{_random.Next(1000000000, int.MaxValue)}",
            RENKLI_RECETE_NUMARASI = i % 3 != 0 ? $"RNK-{_random.Next(100000, 999999)}" : null,
            SERI_NUMARASI = $"SER-{_random.Next(10000, 99999)}",
            RECETE_E_IMZA_DURUMU = i % 2 == 0 ? "IMZALI" : "IMZASIZ",
            SGK_TAKIP_NUMARASI = $"SGK-{_random.Next(100000000, 999999999)}"
        }).ToList());
        _logger.LogInformation("RECETE seeded");

        // RECETE_ILAC referans kodları
        var dozBirimRefNew = new[] { "MG", "ML", "TABLET", "DAMLA", "AMPUL" };
        var ilacKullanimSekliRefNew = new[] { "ORAL", "IV", "IM", "SC", "TOPIKAL", "INHALASYON" };
        var ilacKullanimPeriyoduBirimiRefNew = new[] { "GUN", "SAAT", "HAFTA", "AY" };

        foreach (var r in dozBirimRefNew) await AddReferansKodIfNotExists("DOZ_BIRIM", r, r, ct);
        foreach (var r in ilacKullanimSekliRefNew) await AddReferansKodIfNotExists("ILAC_KULLANIM_SEKLI", r, r, ct);
        foreach (var r in ilacKullanimPeriyoduBirimiRefNew) await AddReferansKodIfNotExists("ILAC_KULLANIM_PERIYODU_BIRIMI", r, r, ct);
        await _db.SaveChangesAsync(ct);

        var recetelerNew = await _db.Set<RECETE>().Take(25).ToListAsync(ct);

        // RECETE_ILAC
        if (recetelerNew.Any())
        {
            var ilacAdlari = new[] { "Parol", "Aspirin", "Augmentin", "Cipro", "Voltaren", "Nexium", "Lipitor", "Coumadin", "Glucophage", "Zyrtec" };

            await SeedIfEmpty<RECETE_ILAC>(ct, recetelerNew.Take(25).Select((r, i) => new RECETE_ILAC
            {
                RECETE_ILAC_KODU = $"RIL-{i + 1:D5}",
                RECETE_KODU = r.RECETE_KODU,
                DOZ_BIRIM = $"DOZ_BIRIM_{dozBirimRefNew[i % 5]}",
                BARKOD = $"869{_random.Next(1000000000, int.MaxValue)}",
                ILAC_ADI = ilacAdlari[i % ilacAdlari.Length],
                KUTU_ADETI = $"{_random.Next(1, 5)}",
                ILAC_KULLANIM_SEKLI = $"ILAC_KULLANIM_SEKLI_{ilacKullanimSekliRefNew[i % 6]}",
                ILAC_KULLANIM_SAYISI = $"{_random.Next(1, 4)}",
                ILAC_KULLANIM_DOZU = $"{_random.Next(1, 3) * 250}",
                ILAC_KULLANIM_PERIYODU = $"{_random.Next(1, 14)}",
                ILAC_KULLANIM_PERIYODU_BIRIMI = $"ILAC_KULLANIM_PERIYODU_BIRIMI_{ilacKullanimPeriyoduBirimiRefNew[i % 4]}",
                ILAC_ACIKLAMA = $"Günde {_random.Next(1, 4)} kez alınacak"
            }).ToList());
        }
        _logger.LogInformation("RECETE_ILAC seeded");
        _logger.LogInformation("RECETE tabloları seeded (2 tablo)");

        // === IZLEM TABLOLARI ===

        // BEBEK_COCUK_IZLEM referans kodları
        var kacinciIzlemRef = new[] { "1", "2", "3", "4", "5", "6", "7", "8" };
        var agizdanSiviTedavisiRef = new[] { "PLAN_A", "PLAN_B", "PLAN_C", "GEREKMIYOR" };
        var demirLojistigiRef = new[] { "VERILDI", "VERILMEDI", "KONTRENDIKE" };
        var dvitaminiLojistigiRef = new[] { "VERILDI", "VERILMEDI", "KONTRENDIKE" };
        var gkdTaramaSonucuRef = new[] { "NORMAL", "ANORMAL", "SUPHELI" };
        var topukKaniRef = new[] { "ALINDI", "ALINMADI", "PLANLI" };
        var izleminYapildigiYerRef = new[] { "HASTANE", "ASM", "EVDE", "MOBIL" };
        var bebekteRiskFaktorleriRef = new[] { "YOK", "PREMATURE", "DUSUK_DOGUM_AGIRLIGI", "KONJENITAL_ANOMALI" };
        var taramaSonucuRef = new[] { "NORMAL", "ANORMAL", "TEKRAR_GEREKLI" };
        var bebeginBeslenmeDurumuRef = new[] { "SADECE_ANNE_SUTU", "KARMA", "MAMA", "EK_GIDA" };
        var gelisimTablosuRef = new[] { "NORMAL", "GERI", "ILERI" };
        var ntpTakipBilgisiRef = new[] { "TAKIPTE", "TAMAMLANDI", "TAKIPTEN_CIKTI" };
        var bcBeyinGelisimRef = new[] { "RISK_YOK", "DUSUK_RISK", "ORTA_RISK", "YUKSEK_RISK" };
        var ebeveynDestekRef = new[] { "YAPILDI", "YAPILMADI", "PLANLI" };
        var bcPsikolojikRiskRef = new[] { "EGITIM_VERILDI", "VERILMEDI", "PLANLI" };
        var bcRiskMudahaleRef = new[] { "MUDAHALE_EDILDI", "GEREK_YOK", "SEVK_EDILDI" };
        var bcRiskliOlguRef = new[] { "TAKIPTE", "TAMAMLANDI", "SEVK_EDILDI" };

        foreach (var r in kacinciIzlemRef) await AddReferansKodIfNotExists("KACINCI_IZLEM", r, r, ct);
        foreach (var r in agizdanSiviTedavisiRef) await AddReferansKodIfNotExists("AGIZDAN_SIVI_TEDAVISI", r, r, ct);
        foreach (var r in demirLojistigiRef) await AddReferansKodIfNotExists("DEMIR_LOJISTIGI_VE_DESTEGI", r, r, ct);
        foreach (var r in dvitaminiLojistigiRef) await AddReferansKodIfNotExists("DVITAMINI_LOJISTIGI_VE_DESTEGI", r, r, ct);
        foreach (var r in gkdTaramaSonucuRef) await AddReferansKodIfNotExists("GKD_TARAMA_SONUCU", r, r, ct);
        foreach (var r in topukKaniRef) await AddReferansKodIfNotExists("TOPUK_KANI", r, r, ct);
        foreach (var r in izleminYapildigiYerRef) await AddReferansKodIfNotExists("IZLEMIN_YAPILDIGI_YER", r, r, ct);
        foreach (var r in bebekteRiskFaktorleriRef) await AddReferansKodIfNotExists("BEBEKTE_RISK_FAKTORLERI", r, r, ct);
        foreach (var r in taramaSonucuRef) await AddReferansKodIfNotExists("TARAMA_SONUCU", r, r, ct);
        foreach (var r in bebeginBeslenmeDurumuRef) await AddReferansKodIfNotExists("BEBEGIN_BESLENME_DURUMU", r, r, ct);
        foreach (var r in gelisimTablosuRef) await AddReferansKodIfNotExists("GELISIM_TABLOSU_BILGILERI", r, r, ct);
        foreach (var r in ntpTakipBilgisiRef) await AddReferansKodIfNotExists("NTP_TAKIP_BILGISI", r, r, ct);
        foreach (var r in bcBeyinGelisimRef) await AddReferansKodIfNotExists("BC_BEYIN_GELISIM_RISKLERI", r, r, ct);
        foreach (var r in ebeveynDestekRef) await AddReferansKodIfNotExists("EBEVEYN_DESTEK_AKTIVITELERI", r, r, ct);
        foreach (var r in bcPsikolojikRiskRef) await AddReferansKodIfNotExists("BC_PSIKOLOJIK_RISK_EGITIM", r, r, ct);
        foreach (var r in bcRiskMudahaleRef) await AddReferansKodIfNotExists("BC_RISK_YAPILAN_MUDAHALE", r, r, ct);
        foreach (var r in bcRiskliOlguRef) await AddReferansKodIfNotExists("BC_RISKLI_OLGU_TAKIBI", r, r, ct);
        await _db.SaveChangesAsync(ct);

        // BEBEK_COCUK_IZLEM
        await SeedIfEmpty<BEBEK_COCUK_IZLEM>(ct, basvurular.Take(25).Select((b, i) => new BEBEK_COCUK_IZLEM
        {
            BEBEK_COCUK_IZLEM_KODU = $"BCI-{i + 1:D5}",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            KACINCI_IZLEM = $"KACINCI_IZLEM_{kacinciIzlemRef[i % 8]}",
            AGIZDAN_SIVI_TEDAVISI = $"AGIZDAN_SIVI_TEDAVISI_{agizdanSiviTedavisiRef[i % 4]}",
            BAS_CEVRESI = $"{_random.Next(32, 50)}",
            DEMIR_LOJISTIGI_VE_DESTEGI = $"DEMIR_LOJISTIGI_VE_DESTEGI_{demirLojistigiRef[i % 3]}",
            DOGUM_AGIRLIGI = $"{_random.Next(2500, 4500)}",
            DVITAMINI_LOJISTIGI_VE_DESTEGI = $"DVITAMINI_LOJISTIGI_VE_DESTEGI_{dvitaminiLojistigiRef[i % 3]}",
            GKD_TARAMA_SONUCU = $"GKD_TARAMA_SONUCU_{gkdTaramaSonucuRef[i % 3]}",
            HEMATOKRIT_DEGERI = $"{_random.Next(35, 50)}.{_random.Next(0, 9)}",
            HEMOGLOBIN_DEGERI = $"{_random.Next(10, 16)}.{_random.Next(0, 9)}",
            TOPUK_KANI = $"TOPUK_KANI_{topukKaniRef[i % 3]}",
            TOPUK_KANI_ALINMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
            IZLEMIN_YAPILDIGI_YER = $"IZLEMIN_YAPILDIGI_YER_{izleminYapildigiYerRef[i % 4]}",
            IZLEMI_YAPAN_PERSONEL_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
            BILGI_ALINAN_KISI_AD_SOYADI = $"Anne Adı {i + 1}",
            BILGI_ALINAN_KISI_TELEFON = $"05{_random.Next(30, 60)}{_random.Next(1000000, 9999999)}",
            BEBEKTE_RISK_FAKTORLERI = $"BEBEKTE_RISK_FAKTORLERI_{bebekteRiskFaktorleriRef[i % 4]}",
            TARAMA_SONUCU = $"TARAMA_SONUCU_{taramaSonucuRef[i % 3]}",
            ANNE_SUTUNDEN_KESILDIGI_AY = $"{_random.Next(6, 24)}",
            BEBEGIN_BESLENME_DURUMU = $"BEBEGIN_BESLENME_DURUMU_{bebeginBeslenmeDurumuRef[i % 4]}",
            EK_GIDAYA_BASLADIGI_AY = $"{_random.Next(4, 8)}",
            SADECE_ANNE_SUTU_ALDIGI_SURE = $"{_random.Next(1, 6)}",
            GELISIM_TABLOSU_BILGILERI = $"GELISIM_TABLOSU_BILGILERI_{gelisimTablosuRef[i % 3]}",
            NTP_TAKIP_BILGISI = $"NTP_TAKIP_BILGISI_{ntpTakipBilgisiRef[i % 3]}",
            BC_BEYIN_GELISIM_RISKLERI = $"BC_BEYIN_GELISIM_RISKLERI_{bcBeyinGelisimRef[i % 4]}",
            EBEVEYN_DESTEK_AKTIVITELERI = $"EBEVEYN_DESTEK_AKTIVITELERI_{ebeveynDestekRef[i % 3]}",
            BC_PSIKOLOJIK_RISK_EGITIM = $"BC_PSIKOLOJIK_RISK_EGITIM_{bcPsikolojikRiskRef[i % 3]}",
            BC_RISK_YAPILAN_MUDAHALE = $"BC_RISK_YAPILAN_MUDAHALE_{bcRiskMudahaleRef[i % 3]}",
            BC_RISKLI_OLGU_TAKIBI = $"BC_RISKLI_OLGU_TAKIBI_{bcRiskliOlguRef[i % 3]}",
            ACIKLAMA = $"Bebek çocuk izlem açıklaması {i + 1}"
        }).ToList());
        _logger.LogInformation("BEBEK_COCUK_IZLEM seeded");

        // GEBE_IZLEM referans kodları
        var kacinciGebeIzlemRef = new[] { "1", "2", "3", "4", "5", "6", "7", "8" };
        var oncekiDogumDurumuRef = new[] { "ILK_GEBELIK", "NORMAL_DOGUM", "SEZARYEN", "DUSUK" };
        var gebeIzlemIslemTuruRef = new[] { "RUTIN_IZLEM", "RISK_IZLEM", "ACIL_IZLEM" };
        var gestasyonelDiyabetRef = new[] { "NORMAL", "BOZUK_TOLERANS", "DIYABET" };
        var idrardaProteinRef = new[] { "NEGATIF", "ESSER", "POZITIF" };
        var konjenitalAnomaliRef = new[] { "YOK", "MUHTEMEL", "KESIN" };
        var gebelikteRiskRef = new[] { "DUSUK_RISK", "ORTA_RISK", "YUKSEK_RISK" };
        var riskMudahaleRef = new[] { "MUDAHALE_EDILDI", "GEREK_YOK", "SEVK_EDILDI" };
        var riskOlguTakibiRef = new[] { "TAKIPTE", "TAMAMLANDI", "SEVK_EDILDI" };

        foreach (var r in kacinciGebeIzlemRef) await AddReferansKodIfNotExists("KACINCI_GEBE_IZLEM", r, r, ct);
        foreach (var r in oncekiDogumDurumuRef) await AddReferansKodIfNotExists("ONCEKI_DOGUM_DURUMU", r, r, ct);
        foreach (var r in gebeIzlemIslemTuruRef) await AddReferansKodIfNotExists("GEBE_IZLEM_ISLEM_TURU", r, r, ct);
        foreach (var r in gestasyonelDiyabetRef) await AddReferansKodIfNotExists("GESTASYONEL_DIYABET_TARAMASI", r, r, ct);
        foreach (var r in idrardaProteinRef) await AddReferansKodIfNotExists("IDRARDA_PROTEIN", r, r, ct);
        foreach (var r in konjenitalAnomaliRef) await AddReferansKodIfNotExists("KONJENITAL_ANOMALI_VARLIGI", r, r, ct);
        foreach (var r in gebelikteRiskRef) await AddReferansKodIfNotExists("GEBELIKTE_RISK_FAKTORLERI", r, r, ct);
        foreach (var r in bcPsikolojikRiskRef) await AddReferansKodIfNotExists("PSIKOLOJIK_GELISIM_RISK_EGITIM", r, r, ct);
        foreach (var r in riskMudahaleRef) await AddReferansKodIfNotExists("RISK_FAKTORLERINE_MUDAHALE", r, r, ct);
        foreach (var r in riskOlguTakibiRef) await AddReferansKodIfNotExists("RISK_ALTINDAKI_OLGU_TAKIBI", r, r, ct);
        await _db.SaveChangesAsync(ct);

        // GEBE_IZLEM
        await SeedIfEmpty<GEBE_IZLEM>(ct, basvurular.Take(25).Select((b, i) => new GEBE_IZLEM
        {
            GEBE_IZLEM_KODU = $"GBI-{i + 1:D5}",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            KACINCI_GEBE_IZLEM = $"KACINCI_GEBE_IZLEM_{kacinciGebeIzlemRef[i % 8]}",
            SON_ADET_TARIHI = DateTime.Now.AddDays(-_random.Next(60, 280)),
            ONCEKI_DOGUM_DURUMU = $"ONCEKI_DOGUM_DURUMU_{oncekiDogumDurumuRef[i % 4]}",
            GEBE_IZLEM_ISLEM_TURU = $"GEBE_IZLEM_ISLEM_TURU_{gebeIzlemIslemTuruRef[i % 3]}",
            GESTASYONEL_DIYABET_TARAMASI = $"GESTASYONEL_DIYABET_TARAMASI_{gestasyonelDiyabetRef[i % 3]}",
            IDRARDA_PROTEIN = $"IDRARDA_PROTEIN_{idrardaProteinRef[i % 3]}",
            HEMOGLOBIN_DEGERI = $"{_random.Next(10, 14)}.{_random.Next(0, 9)}",
            DEMIR_LOJISTIGI_VE_DESTEGI = $"DEMIR_LOJISTIGI_VE_DESTEGI_{demirLojistigiRef[i % 3]}",
            DVITAMINI_LOJISTIGI_VE_DESTEGI = $"DVITAMINI_LOJISTIGI_VE_DESTEGI_{dvitaminiLojistigiRef[i % 3]}",
            KONJENITAL_ANOMALI_VARLIGI = $"KONJENITAL_ANOMALI_VARLIGI_{konjenitalAnomaliRef[i % 3]}",
            FETUS_KALP_SESI = $"{_random.Next(120, 160)}",
            DIASTOLIK_KAN_BASINCI_DEGERI = $"{_random.Next(60, 90)}",
            SISTOLIK_KAN_BASINCI_DEGERI = $"{_random.Next(100, 140)}",
            GEBELIKTE_RISK_FAKTORLERI = $"GEBELIKTE_RISK_FAKTORLERI_{gebelikteRiskRef[i % 3]}",
            BC_BEYIN_GELISIM_RISKLERI = $"BC_BEYIN_GELISIM_RISKLERI_{bcBeyinGelisimRef[i % 4]}",
            PSIKOLOJIK_GELISIM_RISK_EGITIM = $"PSIKOLOJIK_GELISIM_RISK_EGITIM_{bcPsikolojikRiskRef[i % 3]}",
            RISK_FAKTORLERINE_MUDAHALE = $"RISK_FAKTORLERINE_MUDAHALE_{riskMudahaleRef[i % 3]}",
            RISK_ALTINDAKI_OLGU_TAKIBI = $"RISK_ALTINDAKI_OLGU_TAKIBI_{riskOlguTakibiRef[i % 3]}",
            ACIKLAMA = $"Gebe izlem açıklaması {i + 1}"
        }).ToList());
        _logger.LogInformation("GEBE_IZLEM seeded");
        _logger.LogInformation("IZLEM tabloları seeded (2 tablo)");

        // === RADYOLOJI TABLOLARI ===

        // RADYOLOJI referans kodları
        var tetkikIstenmeDurumuRef = new[] { "ISTENDI", "KABUL", "SONUCLANDI", "IPTAL" };
        foreach (var r in tetkikIstenmeDurumuRef) await AddReferansKodIfNotExists("TETKIK_ISTENME_DURUMU", r, r, ct);
        await _db.SaveChangesAsync(ct);

        // RADYOLOJI
        if (cihazlarAml.Any() && kullanicilarNew.Any() && hastaHizmetler.Any())
        {
            await SeedIfEmpty<RADYOLOJI>(ct, basvurular.Take(25).Select((b, i) => new RADYOLOJI
            {
                RADYOLOJI_KODU = $"RAD-{i + 1:D5}",
                HASTA_KODU = b.HASTA_KODU,
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                BIRIM_KODU = birimler[i % birimler.Count].BIRIM_KODU,
                TETKIK_CEKIM_KABUL_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 60)),
                BARKOD = $"RAD{_random.Next(100000000, 999999999)}",
                BARKOD_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 60)),
                CIHAZ_KODU = cihazlarAml[i % cihazlarAml.Count].CIHAZ_KODU,
                CALISMA_BASLAMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 60)).AddHours(_random.Next(8, 16)),
                CALISMA_BITIS_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 60)).AddHours(_random.Next(9, 17)),
                KABUL_EDEN_KULLANICI_KODU = kullanicilarNew[i % kullanicilarNew.Count].KULLANICI_KODU,
                TETKIK_CEKEN_TEKNISYEN_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                HASTA_HIZMET_KODU = hastaHizmetler[i % hastaHizmetler.Count].HASTA_HIZMET_KODU,
                LOINC_KODU = new[] { "24627-2", "30755-2", "30746-1", "36813-4", "24628-0" }[i % 5],
                TETKIK_ISTENME_DURUMU = $"TETKIK_ISTENME_DURUMU_{tetkikIstenmeDurumuRef[i % 4]}",
                ERISIM_NUMARASI = $"ACC-{_random.Next(10000000, 99999999)}"
            }).ToList());
        }
        _logger.LogInformation("RADYOLOJI seeded");

        // === DOGUM TABLOLARI ===

        // DOGUM referans kodları
        var dogumKomplikasyonRef = new[] { "YOK", "KANAMA", "ENFEKSIYON", "PREEKLAMPSI", "DIGER" };
        foreach (var r in dogumKomplikasyonRef) await AddReferansKodIfNotExists("KOMPLIKASYON_TANISI", r, r, ct);
        await _db.SaveChangesAsync(ct);

        // DOGUM
        if (ameliyatlarNew.Any() && hastaHizmetler.Any() && kullanicilarNew.Any())
        {
            await SeedIfEmpty<DOGUM>(ct, basvurular.Take(25).Select((b, i) => new DOGUM
            {
                DOGUM_KODU = $"DGM-{i + 1:D5}",
                HASTA_KODU = b.HASTA_KODU,
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_HIZMET_KODU = hastaHizmetler[i % hastaHizmetler.Count].HASTA_HIZMET_KODU,
                AMELIYAT_KODU = ameliyatlarNew[i % ameliyatlarNew.Count].AMELIYAT_KODU,
                BABA_TC_KIMLIK_NUMARASI = GenerateTcKimlik(),
                KOMPLIKASYON_TANISI = $"KOMPLIKASYON_TANISI_{dogumKomplikasyonRef[i % 5]}",
                DOGUM_NOTU = $"Doğum notu açıklaması {i + 1}",
                DOGUM_BASLAMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 180)).AddHours(_random.Next(0, 24)),
                DOGUM_BITIS_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 180)).AddHours(_random.Next(1, 24)),
                HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                EBE_KODU = personeller[(i + 1) % personeller.Count].PERSONEL_KODU,
                BIRIM_KODU = birimler[i % birimler.Count].BIRIM_KODU,
                DEFTER_NUMARASI = $"DDF-{_random.Next(1000, 9999)}",
                GUNCELLEYEN_KULLANICI_KODU = kullanicilarNew[i % kullanicilarNew.Count].KULLANICI_KODU
            }).ToList());
        }
        _logger.LogInformation("DOGUM seeded");
        _logger.LogInformation("DOGUM tabloları seeded (1 tablo)");

        // === EKSİK 36 TABLO İÇİN SEEDERLAR ===
        _logger.LogInformation("Seeding remaining 36 tables...");

        // Referans kodları ekle
        var vezneGirisCikis = new[] { "GIRIS", "CIKIS" };
        var tahsilTuru = new[] { "NAKIT", "KREDI_KARTI", "HAVALE", "EFT", "CARI" };
        var medulaTedaviTuru = new[] { "AYAKTAN", "GUNUBIRLIK", "YATAN", "ACIL" };
        var medulaTakipTipi = new[] { "NORMAL", "ESLIK_EDEN", "UZAYAN_YATIS" };
        var medulaTedaviSekli = new[] { "NORMAL", "DEVIR", "TRAFIK_KAZASI", "IS_KAZASI" };
        var provizyonTuru = new[] { "NORMAL", "ACIL", "SEVK", "KONTROL" };
        var numuneTuru = new[] { "KAN", "IDRAR", "GAITA", "BOS", "BALGAM", "SWAB" };
        var stokIstekDurumu = new[] { "BEKLEMEDE", "ONAYLANDI", "REDDEDILDI", "KARSILANDI", "IPTAL" };
        var hareketSekli = new[] { "SATIN_ALMA", "DEVIR_GIRIS", "DEVIR_CIKIS", "IADE", "FIRE", "HASTA_CIKIS" };
        var ihaleTuru = new[] { "ACIK_IHALE", "PAZARLIK", "DOGRUDAN_TEMIN", "CERCEVE_ANLASMA" };
        var butceTuru = new[] { "DONER_SERMAYE", "GENEL_BUTCE" };
        var orderIptalNedeni = new[] { "HASTA_REDDI", "HEKIM_KARARI", "TEDAVI_DEGISIKLIGI", "DIGER" };
        var radyolojiSonucDurum = new[] { "RAPORLANDI", "BEKLEMEDE", "IPTAL" };
        var riskSkorlamaTuru = new[] { "BRADEN", "WATERLOW", "NORTON", "MORSE" };
        var sterilCikisDurum = new[] { "KULLANILDI", "IADE", "IMHA" };
        var sterilGirisDurum = new[] { "BEKLEMEDE", "ISLEMDE", "TAMAMLANDI" };

        foreach (var t in vezneGirisCikis) await AddReferansKodIfNotExists("VEZNE_GIRIS_CIKIS_BILGISI", t, t, ct);
        foreach (var t in tahsilTuru) await AddReferansKodIfNotExists("TAHSIL_TURU", t, t, ct);
        foreach (var t in medulaTedaviTuru) await AddReferansKodIfNotExists("TEDAVI_TURU", t, t, ct);
        foreach (var t in medulaTakipTipi) await AddReferansKodIfNotExists("TAKIP_TIPI", t, t, ct);
        foreach (var t in medulaTedaviSekli) await AddReferansKodIfNotExists("TEDAVI_SEKLI", t, t, ct);
        foreach (var t in provizyonTuru) await AddReferansKodIfNotExists("PROVIZYON_TURU", t, t, ct);
        foreach (var t in numuneTuru) await AddReferansKodIfNotExists("NUMUNE_TURU", t, t, ct);
        foreach (var t in stokIstekDurumu) await AddReferansKodIfNotExists("STOK_ISTEK_DURUMU", t, t, ct);
        foreach (var t in hareketSekli) await AddReferansKodIfNotExists("HAREKET_SEKLI", t, t, ct);
        foreach (var t in ihaleTuru) await AddReferansKodIfNotExists("IHALE_TURU", t, t, ct);
        foreach (var t in butceTuru) await AddReferansKodIfNotExists("BUTCE_TURU", t, t, ct);
        foreach (var t in orderIptalNedeni) await AddReferansKodIfNotExists("TIBBI_ORDER_IPTAL_NEDENI", t, t, ct);
        foreach (var t in radyolojiSonucDurum) await AddReferansKodIfNotExists("RADYOLOJI_SONUC_DURUMU", t, t, ct);
        foreach (var t in riskSkorlamaTuru) await AddReferansKodIfNotExists("RISK_SKORLAMA_TURU", t, t, ct);
        foreach (var t in sterilCikisDurum) await AddReferansKodIfNotExists("STERILIZASYON_CIKIS_DURUMU", t, t, ct);
        foreach (var t in sterilGirisDurum) await AddReferansKodIfNotExists("STERILIZASYON_GIRIS_DURUMU", t, t, ct);
        await _db.SaveChangesAsync(ct);
        _logger.LogInformation("Additional reference codes added for 36 tables");

        // 1. VEZNE - Vezne İşlemleri
        var firmalarNew = await _db.Set<FIRMA>().Take(5).ToListAsync(ct);
        if (firmalarNew.Any())
        {
            await SeedIfEmpty<VEZNE>(ct, basvurular.Take(25).Select((b, i) => new VEZNE
            {
                VEZNE_KODU = $"VZN-{i + 1:D5}",
                HASTA_KODU = b.HASTA_KODU,
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                MAKBUZ_NUMARASI = $"MKB-{DateTime.Now.Year}-{_random.Next(100000, 999999)}",
                VEZNE_OZEL_NUMARASI = $"VON-{_random.Next(10000, 99999)}",
                VEZNE_GIRIS_CIKIS_BILGISI = i % 2 == 0 ? "GIRIS" : "CIKIS",
                MAKBUZ_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 60)),
                VEZNE_BIRIM_KODU = birimler.Any() ? birimler[i % birimler.Count].BIRIM_KODU : null,
                MAKBUZ_SERI_NUMARASI = $"SN-{_random.Next(1000, 9999)}",
                IPTAL_DURUMU = i % 10 == 0 ? "EVET" : "HAYIR",
                IPTAL_ZAMANI = DateTime.Now,
                IPTAL_ACIKLAMA = "-",
                TAHSIL_TURU = $"TAHSIL_TURU_{tahsilTuru[i % tahsilTuru.Length]}",
                MAKBUZ_TUTARI = (_random.Next(50, 5000) * 100).ToString(),
                ACIKLAMA = $"Vezne işlemi {i + 1}",
                MAKBUZ_SAHIBI_ADRESI = $"Adres {i + 1}, İstanbul",
                FIRMA_ADI = firmalarNew[i % firmalarNew.Count].FIRMA_ADI ?? "Firma",
                FIRMA_KODU = firmalarNew[i % firmalarNew.Count].FIRMA_KODU
            }).ToList());
        }
        _logger.LogInformation("VEZNE seeded");

        // 2. MEDULA_TAKIP - Medula Takip Kayıtları
        await SeedIfEmpty<MEDULA_TAKIP>(ct, basvurular.Take(25).Select((b, i) => new MEDULA_TAKIP
        {
            MEDULA_TAKIP_KODU = $"MTK-{i + 1:D5}",
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            HASTA_KODU = b.HASTA_KODU,
            SGK_TAKIP_NUMARASI = $"SGK{_random.Next(100000000, 999999999)}",
            SGK_ILKTAKIP_NUMARASI = $"ILK{_random.Next(100000000, 999999999)}",
            MEDULA_TESIS_KODU = $"MED{_random.Next(10000, 99999)}",
            MEDULA_BRANS_KODU = $"BRN{_random.Next(100, 999)}",
            PROVIZYON_TURU = $"PROVIZYON_TURU_{provizyonTuru[i % provizyonTuru.Length]}",
            PROVIZYON_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 30)),
            TC_KIMLIK_NUMARASI = GenerateTcKimlik(),
            CINSIYET = i % 2 == 0 ? "E" : "K",
            MEDULA_TUTARI = (_random.Next(100, 10000) * 100).ToString(),
            FATURA_TESLIM_NUMARASI = $"FTN{_random.Next(100000, 999999)}",
            FATURA_TESLIM_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 30)),
            TEDAVI_TURU = $"TEDAVI_TURU_{medulaTedaviTuru[i % medulaTedaviTuru.Length]}",
            SIGORTALI_TURU = "CALISAN",
            DEVREDILEN_KURUM = "SGK",
            SONUC_KODU = "0000",
            SONUC_MESAJI = "İşlem başarılı",
            TAKIP_TIPI = $"TAKIP_TIPI_{medulaTakipTipi[i % medulaTakipTipi.Length]}",
            BASVURU_NUMARASI = $"BN{_random.Next(100000000, 999999999)}",
            TEDAVI_TIPI = "NORMAL",
            TEDAVI_SEKLI = $"TEDAVI_SEKLI_{medulaTedaviSekli[i % medulaTedaviSekli.Length]}"
        }).ToList());
        _logger.LogInformation("MEDULA_TAKIP seeded");

        // 3. TETKIK_NUMUNE - Laboratuvar Numune Kayıtları
        var kullanicilarForNumune = await _db.Set<KULLANICI>().Take(10).ToListAsync(ct);
        if (kullanicilarForNumune.Any())
        {
            await SeedIfEmpty<TETKIK_NUMUNE>(ct, basvurular.Take(25).Select((b, i) => new TETKIK_NUMUNE
            {
                TETKIK_NUMUNE_KODU = $"TN-{i + 1:D5}",
                HASTA_KODU = b.HASTA_KODU,
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                NUMUNE_NUMARASI = $"NUM-{DateTime.Now.Year}-{_random.Next(100000, 999999)}",
                NUMUNE_TURU = $"NUMUNE_TURU_{numuneTuru[i % numuneTuru.Length]}",
                BIRIM_KODU = birimler.Any() ? birimler[i % birimler.Count].BIRIM_KODU : null,
                NUMUNE_ALMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                NUMUNE_KABUL_ZAMANI = DateTime.Now.AddDays(-_random.Next(0, 29)),
                BARKOD = $"BC{_random.Next(1000000000, int.MaxValue)}",
                BARKOD_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                NUMUNE_ALAN_KULLANICI_KODU = kullanicilarForNumune[i % kullanicilarForNumune.Count].KULLANICI_KODU,
                KABUL_EDEN_KULLANICI_KODU = kullanicilarForNumune[(i + 1) % kullanicilarForNumune.Count].KULLANICI_KODU,
                NUMUNE_ACILIYET_DURUMU = i % 5 == 0 ? "ACIL" : "NORMAL",
                ENTEGRASYON_NUMARASI = $"ENT{_random.Next(100000, 999999)}"
            }).ToList());
        }
        _logger.LogInformation("TETKIK_NUMUNE seeded");

        // 4. STOK_ISTEK - Stok İstek Kayıtları
        var ameliyatlarForStok = await _db.Set<AMELIYAT>().Take(10).ToListAsync(ct);
        var depolarForStok = await _db.Set<DEPO>().Take(5).ToListAsync(ct);
        if (ameliyatlarForStok.Any() && depolarForStok.Any())
        {
            await SeedIfEmpty<STOK_ISTEK>(ct, basvurular.Take(25).Select((b, i) => new STOK_ISTEK
            {
                STOK_ISTEK_KODU = $"SI-{i + 1:D5}",
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_KODU = b.HASTA_KODU,
                ISTEK_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                ISTEK_DEPO_KODU = depolarForStok[i % depolarForStok.Count].DEPO_KODU,
                HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                STOK_ISTEK_DURUMU = $"STOK_ISTEK_DURUMU_{stokIstekDurumu[i % stokIstekDurumu.Length]}",
                STOK_ISTEK_HEKIM_ACIKLAMA = $"İstek açıklaması {i + 1}",
                AMELIYAT_KODU = ameliyatlarForStok[i % ameliyatlarForStok.Count].AMELIYAT_KODU
            }).ToList());
        }
        _logger.LogInformation("STOK_ISTEK seeded");

        // 5. TIBBI_ORDER_DETAY - Tıbbi Order Detayları
        var tibbiOrderlar = await _db.Set<TIBBI_ORDER>().Take(25).ToListAsync(ct);
        var hemsireler2 = personeller.Where(p => p.UNVAN_KODU == "Hemşire" || p.UNVAN_KODU?.Contains("Hem") == true).ToList();
        if (!hemsireler2.Any()) hemsireler2 = personeller.Take(5).ToList();
        if (tibbiOrderlar.Any() && hemsireler2.Any())
        {
            await SeedIfEmpty<TIBBI_ORDER_DETAY>(ct, tibbiOrderlar.Take(25).Select((to, i) => new TIBBI_ORDER_DETAY
            {
                TIBBI_ORDER_DETAY_KODU = $"TOD-{i + 1:D5}",
                TIBBI_ORDER_KODU = to.TIBBI_ORDER_KODU,
                PLANLANAN_UYGULANMA_ZAMANI = DateTime.Now.AddHours(_random.Next(1, 48)),
                UYGULAYAN_HEMSIRE_KODU = hemsireler2[i % hemsireler2.Count].PERSONEL_KODU,
                UYGULAMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(0, 5)),
                UYGULANMA_DURUMU = i % 4 == 0 ? "BEKLEMEDE" : "UYGULANDI",
                TIBBI_ORDER_IPTAL_NEDENI = $"TIBBI_ORDER_IPTAL_NEDENI_{orderIptalNedeni[0]}",
                IPTAL_EDEN_HEMSIRE_KODU = hemsireler2[(i + 1) % hemsireler2.Count].PERSONEL_KODU,
                IPTAL_ZAMANI = DateTime.Now,
                ACIKLAMA = $"Order detay açıklaması {i + 1}"
            }).ToList());
        }
        _logger.LogInformation("TIBBI_ORDER_DETAY seeded");

        // 6. RADYOLOJI_SONUC - Radyoloji Sonuçları
        var radyolojiler = await _db.Set<RADYOLOJI>().Take(25).ToListAsync(ct);
        var raporFormatiRef = new[] { "PDF", "DICOM", "JPG", "HTML" };
        var raporTipiRef = new[] { "ANA_RAPOR", "EK_RAPOR", "KONSULTASYON" };
        foreach (var f in raporFormatiRef) await AddReferansKodIfNotExists("RADYOLOJI_RAPOR_FORMATI", f, f, ct);
        foreach (var t in raporTipiRef) await AddReferansKodIfNotExists("RAPOR_TIPI", t, t, ct);
        await _db.SaveChangesAsync(ct);

        if (radyolojiler.Any())
        {
            await SeedIfEmpty<RADYOLOJI_SONUC>(ct, radyolojiler.Take(25).Select((r, i) => new RADYOLOJI_SONUC
            {
                RADYOLOJI_SONUC_KODU = $"RS-{i + 1:D5}",
                RADYOLOJI_KODU = r.RADYOLOJI_KODU,
                TETKIK_SONUCU_METIN = $"Radyoloji sonuç bulguları {i + 1}. Normal sınırlarda izlenmektedir.",
                RADYOLOJI_TETKIK_SONUCU = $"Normal",
                RADYOLOJI_RAPOR_FORMATI = $"RADYOLOJI_RAPOR_FORMATI_{raporFormatiRef[i % raporFormatiRef.Length]}",
                RAPOR_TIPI = $"RAPOR_TIPI_{raporTipiRef[i % raporTipiRef.Length]}",
                RAPOR_YAZAN_PERSONEL_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                ONAYLAYAN_PERSONEL_KODU_1 = personeller[i % personeller.Count].PERSONEL_KODU,
                ONAYLAYAN_PERSONEL_KODU_2 = personeller[(i + 1) % personeller.Count].PERSONEL_KODU,
                ONAYLAYAN_PERSONEL_KODU_3 = personeller[(i + 2) % personeller.Count].PERSONEL_KODU,
                RAPOR_UZMAN_ONAY_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                RAPOR_KAYIT_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30))
            }).ToList());
        }
        _logger.LogInformation("RADYOLOJI_SONUC seeded");

        // 7. RECETE_ILAC_ACIKLAMA - Reçete İlaç Açıklamaları
        var receteIlaclar = await _db.Set<RECETE_ILAC>().Take(25).ToListAsync(ct);
        if (receteIlaclar.Any())
        {
            await SeedIfEmpty<RECETE_ILAC_ACIKLAMA>(ct, receteIlaclar.Take(25).Select((ri, i) => new RECETE_ILAC_ACIKLAMA
            {
                RECETE_ILAC_ACIKLAMA_KODU = $"RIA-{i + 1:D5}",
                RECETE_ILAC_KODU = ri.RECETE_ILAC_KODU,
                ACIKLAMA = $"İlaç kullanım açıklaması {i + 1}. Yemeklerden sonra alınmalıdır."
            }).ToList());
        }
        _logger.LogInformation("RECETE_ILAC_ACIKLAMA seeded");

        // 8. RISK_SKORLAMA - Risk Skorlaması
        var tibbiOrderDetaylar = await _db.Set<TIBBI_ORDER_DETAY>().Take(25).ToListAsync(ct);
        await SeedIfEmpty<RISK_SKORLAMA>(ct, basvurular.Take(25).Select((b, i) => new RISK_SKORLAMA
        {
            RISK_SKORLAMA_KODU = $"RSK-{i + 1:D5}",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            RISK_SKORLAMA_TURU = $"RISK_SKORLAMA_TURU_{riskSkorlamaTuru[i % riskSkorlamaTuru.Length]}",
            ISLEM_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
            RISK_SKORLAMA_TOPLAM_PUANI = (_random.Next(5, 25)).ToString(),
            BEKLENEN_OLUM_ORANI = $"{_random.Next(1, 30)}%",
            GLASGOW_SKALASI = (_random.Next(3, 15)).ToString(),
            DUZELTILMISBEKLENEN_OLUM_ORANI = $"{_random.Next(1, 25)}%",
            TIBBI_ORDER_DETAY_KODU = tibbiOrderDetaylar.Any() ? tibbiOrderDetaylar[i % tibbiOrderDetaylar.Count].TIBBI_ORDER_DETAY_KODU : $"TOD-{i + 1:D5}",
            ACIKLAMA = $"Risk skorlama kaydı {i + 1}"
        }).ToList());
        _logger.LogInformation("RISK_SKORLAMA seeded");

        // 9. STERILIZASYON_SET - Sterilizasyon Setleri
        var depolarForSteril = await _db.Set<DEPO>().Take(5).ToListAsync(ct);
        var sterilPaketlerForSet = await _db.Set<STERILIZASYON_PAKET>().Take(10).ToListAsync(ct);
        var kullanicilarForSteril = await _db.Set<KULLANICI>().Take(10).ToListAsync(ct);
        var cihazlarForSteril = await _db.Set<CIHAZ>().Take(5).ToListAsync(ct);
        if (depolarForSteril.Any() && sterilPaketlerForSet.Any() && kullanicilarForSteril.Any() && personeller.Any())
        {
            await SeedIfEmpty<STERILIZASYON_SET>(ct, Enumerable.Range(1, 25).Select(i => new STERILIZASYON_SET
            {
                STERILIZASYON_SET_KODU = $"STS-{i:D5}",
                DEPO_KODU = depolarForSteril[i % depolarForSteril.Count].DEPO_KODU,
                STERILIZASYON_PAKET_KODU = sterilPaketlerForSet[i % sterilPaketlerForSet.Count].STERILIZASYON_PAKET_KODU,
                BARKOD = $"STB{_random.Next(1000000, 9999999)}",
                BARKOD_BASAN_KULLANICI_KODU = kullanicilarForSteril[i % kullanicilarForSteril.Count].KULLANICI_KODU,
                BARKOD_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                CIHAZ_KODU = cihazlarForSteril.Any() ? cihazlarForSteril[i % cihazlarForSteril.Count].CIHAZ_KODU : null,
                STERILIZASYON_CEVRIM_NUMARASI = $"SCN{_random.Next(1000, 9999)}",
                SET_IADE_DURUMU = "0",
                SET_IADE_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 10)),
                SET_IADE_EDEN_PERSONEL_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                SET_IADE_ALAN_PERSONEL_KODU = personeller[(i + 1) % personeller.Count].PERSONEL_KODU,
                PAKET_RAF_OMRU_BITIS_TARIHI = DateTime.Now.AddDays(_random.Next(30, 180)),
                PAKETLEYEN_PERSONEL_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                ISLEM_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                STERILIZASYON_BASLAMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)).AddHours(-2),
                STERILIZASYON_BITIS_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                STERILIZASYON_PERSONEL_KODU = personeller[(i + 2) % personeller.Count].PERSONEL_KODU,
                ACIKLAMA = $"Sterilizasyon seti açıklaması {i}"
            }).ToList());
        }
        _logger.LogInformation("STERILIZASYON_SET seeded");

        // 10. STERILIZASYON_GIRIS - Sterilizasyon Giriş
        var stokKartlarForSteril = await _db.Set<STOK_KART>().Take(25).ToListAsync(ct);
        if (depolarForSteril.Any() && stokKartlarForSteril.Any() && birimler.Any() && personeller.Any())
        {
            await SeedIfEmpty<STERILIZASYON_GIRIS>(ct, stokKartlarForSteril.Take(25).Select((sk, i) => new STERILIZASYON_GIRIS
            {
                STERILIZASYON_GIRIS_KODU = $"STG-{i + 1:D5}",
                DEPO_KODU = depolarForSteril[i % depolarForSteril.Count].DEPO_KODU,
                STOK_KART_KODU = sk.STOK_KART_KODU,
                STERILIZASYON_GIRIS_MIKTARI = (_random.Next(1, 50)).ToString(),
                TESLIM_EDEN_BIRIM_KODU = birimler[i % birimler.Count].BIRIM_KODU,
                TESLIM_EDEN_PERSONEL_KODU = personeller[(i + 1) % personeller.Count].PERSONEL_KODU,
                TESLIM_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                TESLIM_ALAN_PERSONEL_KODU = personeller[i % personeller.Count].PERSONEL_KODU
            }).ToList());
        }
        _logger.LogInformation("STERILIZASYON_GIRIS seeded");

        // 11. STERILIZASYON_CIKIS - Sterilizasyon Çıkış
        var sterilSetlerForCikis = await _db.Set<STERILIZASYON_SET>().Take(25).ToListAsync(ct);
        if (sterilSetlerForCikis.Any() && depolarForSteril.Any() && birimler.Any())
        {
            await SeedIfEmpty<STERILIZASYON_CIKIS>(ct, basvurular.Take(25).Select((b, i) => new STERILIZASYON_CIKIS
            {
                STERILIZASYON_CIKIS_KODU = $"STC-{i + 1:D5}",
                DEPO_KODU = depolarForSteril[i % depolarForSteril.Count].DEPO_KODU,
                STERILIZASYON_SET_KODU = sterilSetlerForCikis[i % sterilSetlerForCikis.Count].STERILIZASYON_SET_KODU,
                HASTA_KODU = b.HASTA_KODU,
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                STERILIZASYON_CIKIS_MIKTARI = (_random.Next(1, 10)).ToString(),
                STERILIZASYON_CIKIS_ZAMANI = DateTime.Now.AddDays(-_random.Next(0, 15)),
                CIKIS_YAPILAN_BIRIM_KODU = birimler[i % birimler.Count].BIRIM_KODU,
                TESLIM_EDEN_PERSONEL_KODU = personeller[(i + 1) % personeller.Count].PERSONEL_KODU,
                TESLIM_ALAN_PERSONEL_KODU = personeller[i % personeller.Count].PERSONEL_KODU
            }).ToList());
        }
        _logger.LogInformation("STERILIZASYON_CIKIS seeded");

        // 12. STOK_DURUM - Stok Durumu
        var stokKartlarForDurum = await _db.Set<STOK_KART>().Take(25).ToListAsync(ct);
        if (stokKartlarForDurum.Any() && depolarForStok.Any())
        {
            await SeedIfEmpty<STOK_DURUM>(ct, stokKartlarForDurum.Take(25).Select((sk, i) => new STOK_DURUM
            {
                STOK_DURUM_KODU = $"SD-{i + 1:D5}",
                STOK_KART_KODU = sk.STOK_KART_KODU,
                DEPO_KODU = depolarForStok[i % depolarForStok.Count].DEPO_KODU,
                STOK_MIKTARI = (_random.Next(10, 500)).ToString(),
                MINIMUM_STOK = (_random.Next(5, 20)).ToString(),
                MAKSIMUM_STOK = (_random.Next(500, 1000)).ToString(),
                KRITIK_STOK = (_random.Next(10, 30)).ToString()
            }).ToList());
        }
        _logger.LogInformation("STOK_DURUM seeded");

        // 13. STOK_HAREKET - Stok Hareket
        var stokFislerForHareket = await _db.Set<STOK_FIS>().Take(10).ToListAsync(ct);
        var stokIstekHareketlerForHareket = await _db.Set<STOK_ISTEK_HAREKET>().Take(10).ToListAsync(ct);
        var olcuKoduRef = new[] { "ADET", "KUTU", "PAKET", "LITRE", "KILOGRAM" };
        foreach (var o in olcuKoduRef) await AddReferansKodIfNotExists("OLCU_KODU", o, o, ct);
        await _db.SaveChangesAsync(ct);

        if (stokKartlarForDurum.Any() && personeller.Any() && cihazlarForSteril.Any())
        {
            await SeedIfEmpty<STOK_HAREKET>(ct, stokKartlarForDurum.Take(25).Select((sk, i) => new STOK_HAREKET
            {
                STOK_HAREKET_KODU = $"SH-{i + 1:D5}",
                BAGLI_STOK_HAREKET_KODU = i > 0 ? $"SH-{i:D5}" : $"SH-{i + 1:D5}",
                ILK_GIRIS_STOK_HAREKET_KODU = $"SH-00001",
                STOK_ISTEK_HAREKET_KODU = stokIstekHareketlerForHareket.Any() ? stokIstekHareketlerForHareket[i % stokIstekHareketlerForHareket.Count].STOK_ISTEK_HAREKET_KODU : $"SIH-{i + 1:D5}",
                STOK_FIS_KODU = stokFislerForHareket.Any() ? stokFislerForHareket[i % stokFislerForHareket.Count].STOK_FIS_KODU : null,
                STOK_KART_KODU = sk.STOK_KART_KODU,
                BARKOD = $"BRK{_random.Next(1000000, 9999999)}",
                LOT_NUMARASI = $"LOT{_random.Next(10000, 99999)}",
                SERI_SIRA_NUMARASI = $"SN{_random.Next(10000, 99999)}",
                FIRMA_TANIMLAYICI_NUMARASI = $"FTN{_random.Next(1000, 9999)}",
                MALZEME_SUT_KODU = $"SUT{_random.Next(100000, 999999)}",
                STOK_HAREKET_MIKTARI = (_random.Next(1, 50)).ToString(),
                TASINIR_NUMARASI = $"TSN{_random.Next(10000, 99999)}",
                ALIS_BIRIM_FIYATI = (_random.Next(10, 1000) * 100).ToString(),
                SATIS_BIRIM_FIYATI = (_random.Next(15, 1500) * 100).ToString(),
                OLCU_KODU = $"OLCU_KODU_{olcuKoduRef[i % olcuKoduRef.Length]}",
                ISLEMI_YAPAN_PERSONEL_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                KDV_ORANI = "18",
                ISKONTO_ORANI = (_random.Next(0, 20)).ToString(),
                ISKONTO_TUTARI = (_random.Next(0, 500)).ToString(),
                SON_KULLANMA_TARIHI = DateTime.Now.AddDays(_random.Next(180, 730)),
                MKYS_STOK_HAREKET_KODU = $"MKYS{_random.Next(100000, 999999)}",
                IPTAL_DURUMU = "0",
                MKYS_KARSI_STOK_HAREKET_KODU = $"MKYSK{_random.Next(100000, 999999)}",
                MKYS_KUNYE_NUMARASI = $"KNY{_random.Next(10000, 99999)}",
                UTS_KAYIT_UDI = $"UDI{_random.Next(1000000, 9999999)}",
                BAYILIK_NUMARASI = $"BYL{_random.Next(1000, 9999)}",
                CIHAZ_KODU = cihazlarForSteril[i % cihazlarForSteril.Count].CIHAZ_KODU,
                ATS_SORGU_NUMARASI = $"ATS{_random.Next(100000, 999999)}",
                ALLOGREFT_DONOR_KODU = $"ADK{_random.Next(10000, 99999)}"
            }).ToList());
        }
        _logger.LogInformation("STOK_HAREKET seeded");

        // 14. STOK_FIS - Stok Fiş
        if (firmalarNew.Any() && depolarForStok.Any())
        {
            await SeedIfEmpty<STOK_FIS>(ct, basvurular.Take(25).Select((b, i) => new STOK_FIS
            {
                STOK_FIS_KODU = $"SF-{i + 1:D5}",
                HASTA_KODU = b.HASTA_KODU,
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                BAGLI_STOK_FIS_KODU = $"SF-{(i % 10) + 1:D5}",
                DEPO_KODU = depolarForStok[i % depolarForStok.Count].DEPO_KODU,
                HAREKET_TURU = i % 2 == 0 ? "GIRIS" : "CIKIS",
                MKYS_AYNIYAT_MAKBUZ_KODU = $"MKYS{_random.Next(100000, 999999)}",
                HAREKET_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 60)),
                SHCEK_PAYI = "0",
                HAZINE_PAYI = "0",
                SAGLIK_BAKANLIGI_PAYI = "0",
                BEDELSIZ_FIS = i % 10 == 0 ? "EVET" : "HAYIR",
                FIS_TUTARI = (_random.Next(1000, 50000) * 100).ToString(),
                HAREKET_SEKLI = $"HAREKET_SEKLI_{hareketSekli[i % hareketSekli.Length]}",
                ISLEMI_YAPAN_PERSONEL_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                ISLEM_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 60)),
                FIRMA_KODU = firmalarNew[i % firmalarNew.Count].FIRMA_KODU,
                IHALE_NUMARASI = $"IHL{DateTime.Now.Year}{_random.Next(10000, 99999)}",
                IHALE_TARIHI = DateTime.Now.AddDays(-_random.Next(30, 180)),
                IHALE_TURU = $"IHALE_TURU_{ihaleTuru[i % ihaleTuru.Length]}",
                MUAYENE_KABUL_NUMARASI = $"MKN{_random.Next(100000, 999999)}",
                MUAYENE_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                TESLIM_EDEN_KISI = $"Teslim Eden {i + 1}",
                TESLIM_EDEN_KISI_UNVANI = "Depo Sorumlusu",
                BUTCE_TURU = $"BUTCE_TURU_{butceTuru[i % butceTuru.Length]}",
                FATURA_NUMARASI = $"FTR{DateTime.Now.Year}{_random.Next(100000, 999999)}",
                FATURA_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 60)),
                IRSALIYE_NUMARASI = $"IRS{_random.Next(100000, 999999)}",
                IRSALIYE_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 60)),
                MKYS_KURUM_KODU = $"MKYS{_random.Next(1000, 9999)}"
            }).ToList());
        }
        _logger.LogInformation("STOK_FIS seeded");

        // 15. TETKIK_CIHAZ_ESLESME - Tetkik Cihaz Eşleşme
        var tetkiklerForEslesme = await _db.Set<TETKIK>().Take(25).ToListAsync(ct);
        var cihazlarForEslesme = await _db.Set<CIHAZ>().Take(10).ToListAsync(ct);
        var tetkikParamsForEslesme = await _db.Set<TETKIK_PARAMETRE>().Take(25).ToListAsync(ct);
        if (tetkiklerForEslesme.Any() && cihazlarForEslesme.Any() && tetkikParamsForEslesme.Any())
        {
            await SeedIfEmpty<TETKIK_CIHAZ_ESLESME>(ct, tetkiklerForEslesme.Take(25).Select((t, i) => new TETKIK_CIHAZ_ESLESME
            {
                TETKIK_CIHAZ_ESLESME_KODU = $"TCE-{i + 1:D5}",
                TETKIK_KODU = t.TETKIK_KODU,
                CIHAZ_KODU = cihazlarForEslesme[i % cihazlarForEslesme.Count].CIHAZ_KODU,
                TETKIK_PARAMETRE_KODU = tetkikParamsForEslesme[i % tetkikParamsForEslesme.Count].TETKIK_PARAMETRE_KODU,
                CIHAZDAN_GELEN_TEST_KODU = $"CGT{_random.Next(1000, 9999)}",
                CIHAZA_GIDEN_TEST_KODU = $"CGD{_random.Next(1000, 9999)}",
                IPTAL_DURUMU = "0"
            }).ToList());
        }
        _logger.LogInformation("TETKIK_CIHAZ_ESLESME seeded");

        // 16. TETKIK_REFERANS_ARALIK - Tetkik Referans Aralıkları
        var tetkikParamsForRef = await _db.Set<TETKIK_PARAMETRE>().Take(25).ToListAsync(ct);
        var tetkiklerForRef = await _db.Set<TETKIK>().Take(25).ToListAsync(ct);
        var cihazlarForRef = await _db.Set<CIHAZ>().Take(10).ToListAsync(ct);
        var tetkikCinsiyetRefValues = new[] { "E", "K", "H" };
        foreach (var c in tetkikCinsiyetRefValues) await AddReferansKodIfNotExists("TETKIK_CINSIYET", c, c == "E" ? "Erkek" : (c == "K" ? "Kadın" : "Her İkisi"), ct);
        await _db.SaveChangesAsync(ct);

        if (tetkikParamsForRef.Any() && tetkiklerForRef.Any() && cihazlarForRef.Any())
        {
            await SeedIfEmpty<TETKIK_REFERANS_ARALIK>(ct, tetkikParamsForRef.Take(25).Select((tp, i) => new TETKIK_REFERANS_ARALIK
            {
                TETKIK_REFERANS_ARALIK_KODU = $"TRA-{i + 1:D5}",
                TETKIK_PARAMETRE_KODU = tp.TETKIK_PARAMETRE_KODU,
                TETKIK_KODU = tetkiklerForRef[i % tetkiklerForRef.Count].TETKIK_KODU,
                CIHAZ_KODU = cihazlarForRef[i % cihazlarForRef.Count].CIHAZ_KODU,
                TETKIK_CINSIYET = $"TETKIK_CINSIYET_{tetkikCinsiyetRefValues[i % 3]}",
                YAS_ARALIGI_BASLANGIC_GUN = "0",
                YAS_ARALIGI_BITIS_GUN = "43800",
                REFERANS_BASLANGIC_DEGERI = (_random.Next(0, 50)).ToString(),
                REFERANS_BITIS_DEGERI = (_random.Next(100, 200)).ToString(),
                ALT_KRITIK_DEGER = (_random.Next(0, 20)).ToString(),
                UST_KRITIK_DEGER = (_random.Next(200, 500)).ToString(),
                ACIKLAMA = $"Referans aralık açıklaması {i + 1}"
            }).ToList());
        }
        _logger.LogInformation("TETKIK_REFERANS_ARALIK seeded");

        // 17. ANLIK_YATAN_HASTA - Anlık Yatan Hasta
        var yataklarForAnlik = await _db.Set<YATAK>().Take(25).ToListAsync(ct);
        var odalarForAnlik = await _db.Set<ODA>().Take(10).ToListAsync(ct);
        if (yataklarForAnlik.Any() && odalarForAnlik.Any())
        {
            await SeedIfEmpty<ANLIK_YATAN_HASTA>(ct, basvurular.Take(25).Select((b, i) => new ANLIK_YATAN_HASTA
            {
                ANLIK_YATAN_HASTA_KODU = $"AYH-{i + 1:D5}",
                HASTA_KODU = b.HASTA_KODU,
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                YATIS_PROTOKOL_NUMARASI = $"YPN{DateTime.Now.Year}{_random.Next(100000, 999999)}",
                BIRIM_KODU = birimler.Any() ? birimler[i % birimler.Count].BIRIM_KODU : null,
                YATAK_KODU = yataklarForAnlik[i % yataklarForAnlik.Count].YATAK_KODU,
                ODA_KODU = odalarForAnlik[i % odalarForAnlik.Count].ODA_KODU,
                YATIS_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30))
            }).ToList());
        }
        _logger.LogInformation("ANLIK_YATAN_HASTA seeded");

        // 18. PERSONEL_EGITIM - Personel Eğitim
        var egitimTuruRef = new[] { "HIZMETICI", "SERTIFIKA", "KONFERANS", "SEMINER", "KURS" };
        var sertifikaTipiRef = new[] { "TEMEL", "ILERI", "UZMANLIK", "YENILEME" };
        foreach (var e in egitimTuruRef) await AddReferansKodIfNotExists("PERSONEL_EGITIM_TURU", e, e, ct);
        foreach (var s in sertifikaTipiRef) await AddReferansKodIfNotExists("SERTIFIKA_TIPI", s, s, ct);
        await _db.SaveChangesAsync(ct);

        await SeedIfEmpty<PERSONEL_EGITIM>(ct, personeller.Take(25).Select((p, i) => new PERSONEL_EGITIM
        {
            PERSONEL_EGITIM_KODU = $"PE-{i + 1:D5}",
            PERSONEL_KODU = p.PERSONEL_KODU,
            PERSONEL_EGITIM_TURU = $"PERSONEL_EGITIM_TURU_{egitimTuruRef[i % egitimTuruRef.Length]}",
            SERTIFIKA_TIPI = $"SERTIFIKA_TIPI_{sertifikaTipiRef[i % sertifikaTipiRef.Length]}",
            SERTIFIKA_PUANI = (_random.Next(60, 100)).ToString(),
            BELGE_NUMARASI = $"BLG{DateTime.Now.Year}{_random.Next(10000, 99999)}",
            EGITIM_BASLANGIC_ZAMANI = DateTime.Now.AddDays(-_random.Next(60, 180)),
            EGITIM_BITIS_ZAMANI = DateTime.Now.AddDays(-_random.Next(30, 59)),
            EGITIM_VEREN_KISI_BILGISI = $"Eğitmen {(i % 5) + 1}",
            EGITIM_YERI = $"Eğitim Salonu {(i % 5) + 1}",
            ONAYLAYAN_PERSONEL_KODU = personeller[(i + 1) % personeller.Count].PERSONEL_KODU
        }).ToList());
        _logger.LogInformation("PERSONEL_EGITIM seeded");

        // 19. PERSONEL_GOREVLENDIRME - Personel Görevlendirme
        var personelGorevTuruRef = new[] { "GECICI", "SUREKLI", "VEKALET", "ROTASYON" };
        var gorevIlKoduRef = new[] { "06", "34", "35", "16", "01" }; // Ankara, Istanbul, Izmir, Bursa, Adana
        var gorevIlceKoduRef = new[] { "0601", "0602", "3401", "3402", "3501" };
        foreach (var g in personelGorevTuruRef) await AddReferansKodIfNotExists("GOREV_TURU", g, g, ct);
        foreach (var il in gorevIlKoduRef) await AddReferansKodIfNotExists("GOREVLENDIRME_IL_KODU", il, il, ct);
        foreach (var ilce in gorevIlceKoduRef) await AddReferansKodIfNotExists("GOREVLENDIRME_ILCE_KODU", ilce, ilce, ct);
        await _db.SaveChangesAsync(ct);

        await SeedIfEmpty<PERSONEL_GOREVLENDIRME>(ct, personeller.Take(25).Select((p, i) => new PERSONEL_GOREVLENDIRME
        {
            PERSONEL_GOREVLENDIRME_KODU = $"PG-{i + 1:D5}",
            PERSONEL_KODU = p.PERSONEL_KODU,
            GOREV_TURU = $"GOREV_TURU_{personelGorevTuruRef[i % personelGorevTuruRef.Length]}",
            GOREVLENDIRME_BASLAMA_TARIHI = DateTime.Now.AddDays(-_random.Next(30, 180)),
            GOREVLENDIRME_BITIS_TARIHI = DateTime.Now.AddDays(_random.Next(30, 365)),
            GOREVLENDIRME_IL_KODU = $"GOREVLENDIRME_IL_KODU_{gorevIlKoduRef[i % gorevIlKoduRef.Length]}",
            GOREVLENDIRME_ILCE_KODU = $"GOREVLENDIRME_ILCE_KODU_{gorevIlceKoduRef[i % gorevIlceKoduRef.Length]}",
            GOREVLENDIRILDIGI_KURUM_KODU = kurumlar.Any() ? kurumlar[i % kurumlar.Count].KURUM_KODU : null
        }).ToList());
        _logger.LogInformation("PERSONEL_GOREVLENDIRME seeded");

        // 20. DOGUM_DETAY - Doğum Detay
        var dogumlarForDetay = await _db.Set<DOGUM>().Take(25).ToListAsync(ct);
        var cinsiyetRef = new[] { "E", "K" };
        var dogumYontemiRef = new[] { "NORMAL", "SEZARYEN", "VAKUM", "FORSEPS" };
        var prognozRef = new[] { "IYI", "ORTA", "KOTU" };
        var uygulamaDurumRef = new[] { "YAPILDI", "YAPILMADI", "REDDEDILDI" };
        var robsonRef = new[] { "GRUP_1", "GRUP_2A", "GRUP_2B", "GRUP_3", "GRUP_4A", "GRUP_4B", "GRUP_5", "GRUP_6", "GRUP_7", "GRUP_8", "GRUP_9", "GRUP_10" };
        var sezaryenEndikasyonRef = new[] { "ELEKTIF", "ACIL", "TEKRARLAYAN", "FETAL_DISTRES", "CPD" };

        foreach (var c in cinsiyetRef) await AddReferansKodIfNotExists("CINSIYET_DOGUM", c, c, ct);
        foreach (var d in dogumYontemiRef) await AddReferansKodIfNotExists("DOGUM_YONTEMI", d, d, ct);
        foreach (var p in prognozRef) await AddReferansKodIfNotExists("PROGNOZ_BILGISI", p, p, ct);
        foreach (var u in uygulamaDurumRef) await AddReferansKodIfNotExists("K_VITAMINI_UYGULANMA_DURUMU", u, u, ct);
        foreach (var u in uygulamaDurumRef) await AddReferansKodIfNotExists("BEBEGIN_HEPATIT_ASI_DURUMU", u, u, ct);
        foreach (var u in uygulamaDurumRef) await AddReferansKodIfNotExists("YENIDOGAN_ISITME_TARAMA_DURUMU", u, u, ct);
        foreach (var u in uygulamaDurumRef) await AddReferansKodIfNotExists("TOPUK_KANI", u, u, ct);
        foreach (var u in uygulamaDurumRef) await AddReferansKodIfNotExists("SURMATURE_BILGISI", u, u, ct);
        foreach (var r in robsonRef) await AddReferansKodIfNotExists("ROBSON_GRUBU", r, r, ct);
        foreach (var s in sezaryenEndikasyonRef) await AddReferansKodIfNotExists("SEZARYEN_ENDIKASYONLAR", s, s, ct);
        var yasamDurumuRef = new[] { "CANLI", "OLUM" };
        foreach (var y in yasamDurumuRef) await AddReferansKodIfNotExists("BEBEGIN_YASAM_DURUMU", y, y, ct);
        await _db.SaveChangesAsync(ct);

        if (dogumlarForDetay.Any())
        {
            await SeedIfEmpty<DOGUM_DETAY>(ct, dogumlarForDetay.Take(25).Select((d, i) => new DOGUM_DETAY
            {
                DOGUM_DETAY_KODU = $"DD-{i + 1:D5}",
                HASTA_KODU = hastalar[i % hastalar.Count].HASTA_KODU,
                HASTA_BASVURU_KODU = basvurular[i % basvurular.Count].HASTA_BASVURU_KODU,
                DOGUM_KODU = d.DOGUM_KODU,
                DOGUM_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 180)),
                CINSIYET = $"CINSIYET_DOGUM_{cinsiyetRef[i % 2]}",
                DOGUM_YONTEMI = $"DOGUM_YONTEMI_{dogumYontemiRef[i % dogumYontemiRef.Length]}",
                AGIRLIK = (2500 + _random.Next(0, 2000)).ToString(),
                BOY = (45 + _random.Next(0, 10)).ToString(),
                BAS_CEVRESI = (32 + _random.Next(0, 5)).ToString(),
                APGAR_1 = (_random.Next(6, 10)).ToString(),
                APGAR_5 = (_random.Next(7, 10)).ToString(),
                APGAR_NOTU = "Normal sınırlarda",
                KOMPLIKASYON_TANISI = $"KOMPLIKASYON_TANISI_{komplikasyonTanisiRef[i % komplikasyonTanisiRef.Length]}",
                DOGUM_SIRASI = (i % 3 + 1).ToString(),
                GOGUS_CEVRESI = (30 + _random.Next(0, 5)).ToString(),
                PROGNOZ_BILGISI = $"PROGNOZ_BILGISI_{prognozRef[i % prognozRef.Length]}",
                SURMATURE_BILGISI = $"SURMATURE_BILGISI_{uygulamaDurumRef[0]}",
                K_VITAMINI_UYGULANMA_DURUMU = $"K_VITAMINI_UYGULANMA_DURUMU_{uygulamaDurumRef[0]}",
                BEBEGIN_HEPATIT_ASI_DURUMU = $"BEBEGIN_HEPATIT_ASI_DURUMU_{uygulamaDurumRef[0]}",
                YENIDOGAN_ISITME_TARAMA_DURUMU = $"YENIDOGAN_ISITME_TARAMA_DURUMU_{uygulamaDurumRef[0]}",
                ILK_BESLENME_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 180)).AddHours(1),
                TOPUK_KANI = $"TOPUK_KANI_{uygulamaDurumRef[0]}",
                TOPUK_KANI_ALINMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 180)).AddDays(3),
                BEBEK_ADI = $"Bebek{i + 1}",
                BABA_TC_KIMLIK_NUMARASI = GenerateTcKimlik(),
                BEBEGIN_YASAM_DURUMU = $"BEBEGIN_YASAM_DURUMU_{yasamDurumuRef[0]}",
                SEZARYEN_ENDIKASYONLAR = $"SEZARYEN_ENDIKASYONLAR_{sezaryenEndikasyonRef[i % sezaryenEndikasyonRef.Length]}",
                ROBSON_GRUBU = $"ROBSON_GRUBU_{robsonRef[i % robsonRef.Length]}"
            }).ToList());
        }
        _logger.LogInformation("DOGUM_DETAY seeded");

        // === KALAN 16 KARMAŞIK TABLO İÇİN SEEDERLAR ===
        _logger.LogInformation("Seeding remaining 16 complex tables...");

        // ASI_BILGISI referans kodları
        var asiRef = new[] { "HEPATIT_B", "BCG", "DBT", "KPA", "KIZAMIK", "KIZAMIKÇIK", "KABAKULAK", "ROTAVIRUS" };
        var asiDozuRef = new[] { "1_DOZ", "2_DOZ", "3_DOZ", "RAPEL" };
        var asiUygulamaSekliRef = new[] { "IM", "SC", "ORAL", "ID" };
        var asiUygulamaYeriRef = new[] { "SAG_KOL", "SOL_KOL", "SAG_BACAK", "SOL_BACAK", "KALCA" };
        var asiIslemTuruRef = new[] { "YAPILDI", "ERTELENDI", "IPTAL", "SEVK" };
        var asiOzelDurumNedeniRef = new[] { "HASTALIK", "ALERJI", "RED", "DIGER" };
        var asieNedenleriRef = new[] { "ATES", "KIZARIKLIK", "SISLIK", "AGRI", "DIGER" };
        var asiYapilmamaDurumuRef = new[] { "ERTELENDI", "IPTAL" };
        var asiYapilmamaNedeniRef = new[] { "HASTALIK", "ALERJI", "VELI_REDDI", "MALZEME_YOK", "DIGER" };
        var alttaYatanHastalikRef = new[] { "YOK", "KALP_HASTALIGI", "AKCIGER_HASTALIGI", "DIYABET", "KANSER", "DIGER" };

        foreach (var r in asiRef) await AddReferansKodIfNotExists("ASI_KODU", r, r, ct);
        foreach (var r in asiDozuRef) await AddReferansKodIfNotExists("ASININ_DOZU", r, r, ct);
        foreach (var r in asiUygulamaSekliRef) await AddReferansKodIfNotExists("ASININ_UYGULAMA_SEKLI", r, r, ct);
        foreach (var r in asiUygulamaYeriRef) await AddReferansKodIfNotExists("ASI_UYGULAMA_YERI", r, r, ct);
        foreach (var r in asiIslemTuruRef) await AddReferansKodIfNotExists("ASI_ISLEM_TURU", r, r, ct);
        foreach (var r in asiOzelDurumNedeniRef) await AddReferansKodIfNotExists("ASI_OZEL_DURUM_NEDENI", r, r, ct);
        foreach (var r in asieNedenleriRef) await AddReferansKodIfNotExists("ASIE_NEDENLERI", r, r, ct);
        foreach (var r in asiYapilmamaDurumuRef) await AddReferansKodIfNotExists("ASI_YAPILMAMA_DURUMU", r, r, ct);
        foreach (var r in asiYapilmamaNedeniRef) await AddReferansKodIfNotExists("ASI_YAPILMAMA_NEDENI", r, r, ct);
        foreach (var r in alttaYatanHastalikRef) await AddReferansKodIfNotExists("ALTTA_YATAN_HASTALIK", r, r, ct);
        await _db.SaveChangesAsync(ct);

        // 21. ASI_BILGISI - Aşı Bilgileri
        await SeedIfEmpty<ASI_BILGISI>(ct, basvurular.Take(25).Select((b, i) => new ASI_BILGISI
        {
            ASI_BILGISI_KODU = $"ASI-{i + 1:D5}",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            ASI_KODU = $"ASI_KODU_{asiRef[i % asiRef.Length]}",
            ASININ_DOZU = $"ASININ_DOZU_{asiDozuRef[i % asiDozuRef.Length]}",
            ASININ_UYGULAMA_SEKLI = $"ASININ_UYGULAMA_SEKLI_{asiUygulamaSekliRef[i % asiUygulamaSekliRef.Length]}",
            ASI_UYGULAMA_YERI = $"ASI_UYGULAMA_YERI_{asiUygulamaYeriRef[i % asiUygulamaYeriRef.Length]}",
            ASI_SORGU_NUMARASI = $"ASN{_random.Next(100000000, 999999999)}",
            ASI_ISLEM_TURU = $"ASI_ISLEM_TURU_{asiIslemTuruRef[0]}",
            BILGI_ALINAN_KISI_AD_SOYADI = $"Veli {i + 1}",
            BILGI_ALINAN_KISI_TELEFON = $"05{_random.Next(10, 99)}{_random.Next(1000000, 9999999)}",
            ASI_YAPILMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 365)),
            ASI_OZEL_DURUM_NEDENI = $"ASI_OZEL_DURUM_NEDENI_{asiOzelDurumNedeniRef[0]}",
            ASIE_ORTAYA_CIKIS_ZAMANI = DateTime.Now,
            ASIE_NEDENLERI = $"ASIE_NEDENLERI_{asieNedenleriRef[0]}",
            ASI_ERTELEME_SURESI = "0",
            ASI_YAPILMAMA_DURUMU = $"ASI_YAPILMAMA_DURUMU_{asiYapilmamaDurumuRef[0]}",
            ASI_YAPILMAMA_NEDENI = $"ASI_YAPILMAMA_NEDENI_{asiYapilmamaNedeniRef[0]}",
            ALTTA_YATAN_HASTALIK = $"ALTTA_YATAN_HASTALIK_{alttaYatanHastalikRef[0]}",
            ACIKLAMA = $"Aşı bilgisi kaydı {i + 1}"
        }).ToList());
        _logger.LogInformation("ASI_BILGISI seeded");

        // EVDE_SAGLIK_IZLEM referans kodları
        var agriRef = new[] { "YOK", "HAFIF", "ORTA", "SIDDETLI" };
        var aydinlatmaRef = new[] { "YETERLI", "YETERSIZ" };
        var bakimDestekRef = new[] { "GEREKLI", "GEREKSIZ", "MEVCUT" };
        var basiDegerlendirmesiRef = new[] { "RISK_YOK", "DUSUK_RISK", "ORTA_RISK", "YUKSEK_RISK" };
        var eshBasvuruTuruRef = new[] { "ASM", "TSM", "HASTANE", "OZEL" };
        var beslenmeRef = new[] { "NORMAL", "ENTERAL", "PARENTERAL", "KARMA" };
        var eshHastalikGrubuRef = new[] { "NOROLOJIK", "ONKOLOJIK", "KARDIYOLOJIK", "SOLUNUM", "DIGER" };
        var evHijyeniRef = new[] { "IYI", "ORTA", "KOTU" };
        var guvenlikRef = new[] { "YETERLI", "YETERSIZ" };
        var isinmaRef = new[] { "DOGALGAZ", "KOMUR", "ELEKTRIK", "ODUN", "YOK" };
        var kisiselBakimRef = new[] { "BAGIMSIZ", "KISMI_BAGIMLI", "TAM_BAGIMLI" };
        var kisiselHijyenRef = new[] { "IYI", "ORTA", "KOTU" };
        var konutTipiRef = new[] { "APARTMAN", "MUSTAKILEV", "GECEKONDU", "DIGER" };
        var helaTipiRef = new[] { "ALATURKA", "ALAFRANGA", "YOK" };
        var yatagaBagimlilikRef = new[] { "BAGIMLI_DEGIL", "KISMI", "TAM" };
        var yardimciAraclarRef = new[] { "YOK", "BASTON", "YURUYUS_CIHAZI", "TEKERLEKLI_SANDALYE" };
        var psikolojikDurumRef = new[] { "NORMAL", "ANKSIYETE", "DEPRESYON", "DIGER" };
        var eshSonlandirmaRef = new[] { "DEVAM", "IYILESME", "VEFAT", "NAKIL", "RED" };
        var eshHastaNakliRef = new[] { "YOK", "HASTANE", "BAKIM_MERKEZI" };
        var eshIlKoduRef = new[] { "034", "006", "035", "016", "001" };
        var sonrakiHizmetRef = new[] { "KONTROL", "TEDAVI", "REHABILITASYON", "PALYATIF" };
        var verilenEgitimRef = new[] { "BESLENME", "HIJYEN", "ILAC_KULLANIMI", "BAKIM", "EGZERSIZ" };

        foreach (var r in agriRef) await AddReferansKodIfNotExists("AGRI", r, r, ct);
        foreach (var r in aydinlatmaRef) await AddReferansKodIfNotExists("AYDINLATMA", r, r, ct);
        foreach (var r in bakimDestekRef) await AddReferansKodIfNotExists("BAKIM_VE_DESTEK_IHTIYACI", r, r, ct);
        foreach (var r in basiDegerlendirmesiRef) await AddReferansKodIfNotExists("BASI_DEGERLENDIRMESI", r, r, ct);
        foreach (var r in eshBasvuruTuruRef) await AddReferansKodIfNotExists("BASVURU_TURU_ESH", r, r, ct);
        foreach (var r in beslenmeRef) await AddReferansKodIfNotExists("BESLENME", r, r, ct);
        foreach (var r in eshHastalikGrubuRef) await AddReferansKodIfNotExists("ESH_ESAS_HASTALIK_GRUBU", r, r, ct);
        foreach (var r in evHijyeniRef) await AddReferansKodIfNotExists("EV_HIJYENI", r, r, ct);
        foreach (var r in guvenlikRef) await AddReferansKodIfNotExists("GUVENLIK", r, r, ct);
        foreach (var r in isinmaRef) await AddReferansKodIfNotExists("ISINMA", r, r, ct);
        foreach (var r in kisiselBakimRef) await AddReferansKodIfNotExists("KISISEL_BAKIM", r, r, ct);
        foreach (var r in kisiselHijyenRef) await AddReferansKodIfNotExists("KISISEL_HIJYEN", r, r, ct);
        foreach (var r in konutTipiRef) await AddReferansKodIfNotExists("KONUT_TIPI", r, r, ct);
        foreach (var r in helaTipiRef) await AddReferansKodIfNotExists("KULLANILAN_HELA_TIPI", r, r, ct);
        foreach (var r in yatagaBagimlilikRef) await AddReferansKodIfNotExists("YATAGA_BAGIMLILIK", r, r, ct);
        foreach (var r in yardimciAraclarRef) await AddReferansKodIfNotExists("KULLANDIGI_YARDIMCI_ARACLAR", r, r, ct);
        foreach (var r in psikolojikDurumRef) await AddReferansKodIfNotExists("PSIKOLOJIK_DURUM_DEGERLENDIRME", r, r, ct);
        foreach (var r in eshSonlandirmaRef) await AddReferansKodIfNotExists("ESH_SONLANDIRILMASI", r, r, ct);
        foreach (var r in eshHastaNakliRef) await AddReferansKodIfNotExists("ESH_HASTA_NAKLI", r, r, ct);
        foreach (var r in eshIlKoduRef) await AddReferansKodIfNotExists("ESH_ALINACAK_IL", r, r, ct);
        foreach (var r in sonrakiHizmetRef) await AddReferansKodIfNotExists("BIR_SONRAKI_HIZMET_IHTIYACI", r, r, ct);
        foreach (var r in verilenEgitimRef) await AddReferansKodIfNotExists("VERILEN_EGITIMLER", r, r, ct);
        await _db.SaveChangesAsync(ct);

        // 22. EVDE_SAGLIK_IZLEM - Evde Sağlık İzlem
        await SeedIfEmpty<EVDE_SAGLIK_IZLEM>(ct, basvurular.Take(25).Select((b, i) => new EVDE_SAGLIK_IZLEM
        {
            EVDE_SAGLIK_IZLEM_KODU = $"ESI-{i + 1:D5}",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            AGRI = $"AGRI_{agriRef[i % agriRef.Length]}",
            AYDINLATMA = $"AYDINLATMA_{aydinlatmaRef[i % aydinlatmaRef.Length]}",
            BAKIM_VE_DESTEK_IHTIYACI = $"BAKIM_VE_DESTEK_IHTIYACI_{bakimDestekRef[i % bakimDestekRef.Length]}",
            BASI_DEGERLENDIRMESI = $"BASI_DEGERLENDIRMESI_{basiDegerlendirmesiRef[i % basiDegerlendirmesiRef.Length]}",
            BASVURU_TURU = $"BASVURU_TURU_ESH_{eshBasvuruTuruRef[i % eshBasvuruTuruRef.Length]}",
            BESLENME = $"BESLENME_{beslenmeRef[i % beslenmeRef.Length]}",
            ESH_ESAS_HASTALIK_GRUBU = $"ESH_ESAS_HASTALIK_GRUBU_{eshHastalikGrubuRef[i % eshHastalikGrubuRef.Length]}",
            EV_HIJYENI = $"EV_HIJYENI_{evHijyeniRef[i % evHijyeniRef.Length]}",
            GUVENLIK = $"GUVENLIK_{guvenlikRef[i % guvenlikRef.Length]}",
            ISINMA = $"ISINMA_{isinmaRef[i % isinmaRef.Length]}",
            KISISEL_BAKIM = $"KISISEL_BAKIM_{kisiselBakimRef[i % kisiselBakimRef.Length]}",
            KISISEL_HIJYEN = $"KISISEL_HIJYEN_{kisiselHijyenRef[i % kisiselHijyenRef.Length]}",
            KONUT_TIPI = $"KONUT_TIPI_{konutTipiRef[i % konutTipiRef.Length]}",
            KULLANILAN_HELA_TIPI = $"KULLANILAN_HELA_TIPI_{helaTipiRef[i % helaTipiRef.Length]}",
            YATAGA_BAGIMLILIK = $"YATAGA_BAGIMLILIK_{yatagaBagimlilikRef[i % yatagaBagimlilikRef.Length]}",
            KULLANDIGI_YARDIMCI_ARACLAR = $"KULLANDIGI_YARDIMCI_ARACLAR_{yardimciAraclarRef[i % yardimciAraclarRef.Length]}",
            PSIKOLOJIK_DURUM_DEGERLENDIRME = $"PSIKOLOJIK_DURUM_DEGERLENDIRME_{psikolojikDurumRef[i % psikolojikDurumRef.Length]}",
            ESH_SONLANDIRILMASI = $"ESH_SONLANDIRILMASI_{eshSonlandirmaRef[0]}",
            ESH_HASTA_NAKLI = $"ESH_HASTA_NAKLI_{eshHastaNakliRef[0]}",
            ESH_ALINACAK_IL = $"ESH_ALINACAK_IL_{eshIlKoduRef[i % eshIlKoduRef.Length]}",
            BIR_SONRAKI_HIZMET_IHTIYACI = $"BIR_SONRAKI_HIZMET_IHTIYACI_{sonrakiHizmetRef[i % sonrakiHizmetRef.Length]}",
            VERILEN_EGITIMLER = $"VERILEN_EGITIMLER_{verilenEgitimRef[i % verilenEgitimRef.Length]}",
            ACIKLAMA = $"Evde sağlık izlem kaydı {i + 1}"
        }).ToList());
        _logger.LogInformation("EVDE_SAGLIK_IZLEM seeded");

        // HASTA_ILETISIM referans kodları
        var adresTipiRef = new[] { "EV", "IS", "DIGER" };
        var adresSeviyesiRef = new[] { "IL", "ILCE", "MAHALLE" };
        foreach (var r in adresTipiRef) await AddReferansKodIfNotExists("ADRES_TIPI", r, r, ct);
        foreach (var r in adresSeviyesiRef) await AddReferansKodIfNotExists("ADRES_KODU_SEVIYESI", r, r, ct);
        foreach (var r in eshIlKoduRef) await AddReferansKodIfNotExists("IL_KODU", r, r, ct);
        await _db.SaveChangesAsync(ct);

        // 23. HASTA_ILETISIM - Hasta İletişim Bilgileri
        await SeedIfEmpty<HASTA_ILETISIM>(ct, basvurular.Take(25).Select((b, i) => new HASTA_ILETISIM
        {
            HASTA_ILETISIM_KODU = $"HI-{i + 1:D5}",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            ADRES_TIPI = $"ADRES_TIPI_{adresTipiRef[i % adresTipiRef.Length]}",
            ADRES_KODU_SEVIYESI = $"ADRES_KODU_SEVIYESI_{adresSeviyesiRef[i % adresSeviyesiRef.Length]}",
            BEYAN_ADRESI = $"Test Mahallesi, Test Sokak No:{i + 1}",
            NVI_ADRES = $"Test Mahallesi, Test Caddesi No:{i + 1}",
            ADRES_NUMARASI = $"{_random.Next(1000000, 9999999)}",
            IL_KODU = $"IL_KODU_{eshIlKoduRef[i % eshIlKoduRef.Length]}",
            ILCE_KODU = $"ILCE_{_random.Next(100, 999)}",
            BUCAK_KODU = $"BCK_{_random.Next(100, 999)}",
            KOY_KODU = $"KOY_{_random.Next(100, 999)}",
            MAHALLE_KODU = $"MHL_{_random.Next(1000, 9999)}",
            CSBM_KODU = $"CSBM{_random.Next(100000, 999999)}",
            DIS_KAPI_NUMARASI = $"{_random.Next(1, 200)}",
            IC_KAPI_NUMARASI = $"{_random.Next(1, 50)}",
            EV_TELEFONU = $"0{_random.Next(212, 216)}{_random.Next(1000000, 9999999)}",
            CEP_TELEFONU = $"05{_random.Next(30, 59)}{_random.Next(1000000, 9999999)}",
            IS_TELEFONU = $"0{_random.Next(212, 216)}{_random.Next(1000000, 9999999)}",
            EPOSTA_ADRESI = $"hasta{i + 1}@test.com"
        }).ToList());
        _logger.LogInformation("HASTA_ILETISIM seeded");

        // HASTA_MALZEME referans kodları
        var malzemeFaturaDurumuRef = new[] { "FATURALANMADI", "FATURALANDI", "BEKLEMEDE" };
        foreach (var r in malzemeFaturaDurumuRef) await AddReferansKodIfNotExists("MALZEME_FATURA_DURUMU", r, r, ct);
        await _db.SaveChangesAsync(ct);

        // 24. HASTA_MALZEME - Hasta Malzeme Kullanım Bilgileri
        var stokKartlarForMalzeme = await _db.Set<STOK_KART>().Take(25).ToListAsync(ct);
        var stokHareketlerForMalzeme = await _db.Set<STOK_HAREKET>().Take(25).ToListAsync(ct);
        var faturalarForMalzeme = await _db.Set<FATURA>().Take(10).ToListAsync(ct);
        var medulaTakiplerForMalzeme = await _db.Set<MEDULA_TAKIP>().Take(10).ToListAsync(ct);
        var ameliyatlarForMalzeme = await _db.Set<AMELIYAT>().Take(10).ToListAsync(ct);
        var depolarForMalzeme = await _db.Set<DEPO>().Take(5).ToListAsync(ct);

        if (stokKartlarForMalzeme.Any() && depolarForMalzeme.Any())
        {
            await SeedIfEmpty<HASTA_MALZEME>(ct, basvurular.Take(25).Select((b, i) => new HASTA_MALZEME
            {
                HASTA_MALZEME_KODU = $"HM-{i + 1:D5}",
                HASTA_KODU = b.HASTA_KODU,
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                STOK_KART_KODU = stokKartlarForMalzeme[i % stokKartlarForMalzeme.Count].STOK_KART_KODU,
                STOK_HAREKET_KODU = stokHareketlerForMalzeme.Any() ? stokHareketlerForMalzeme[i % stokHareketlerForMalzeme.Count].STOK_HAREKET_KODU : null,
                MALZEME_FATURA_DURUMU = $"MALZEME_FATURA_DURUMU_{malzemeFaturaDurumuRef[i % malzemeFaturaDurumuRef.Length]}",
                ISLEM_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 60)),
                ISLEM_GERCEKLESME_ZAMANI = DateTime.Now.AddDays(-_random.Next(0, 59)),
                ATS_SORGU_NUMARASI = $"ATS{_random.Next(100000000, 999999999)}",
                ALLOGREFT_DONOR_KODU = "-",
                MALZEME_ADETI = $"{_random.Next(1, 10)}",
                FATURA_ADET = $"{_random.Next(1, 10)}",
                FATURA_KODU = faturalarForMalzeme.Any() ? faturalarForMalzeme[i % faturalarForMalzeme.Count].FATURA_KODU : "-",
                FATURA_TUTARI = $"{_random.Next(100, 5000) * 100}",
                HASTA_TUTARI = $"{_random.Next(0, 500) * 100}",
                KURUM_TUTARI = $"{_random.Next(100, 4500) * 100}",
                MEDULA_TUTARI = $"{_random.Next(100, 5000) * 100}",
                MEDULA_ISLEM_SIRA_NUMARASI = $"{_random.Next(1, 100)}",
                MEDULA_HIZMET_REF_NUMARASI = $"MHR{_random.Next(100000, 999999)}",
                SYS_REFERANS_NUMARASI = $"SYS{_random.Next(100000, 999999)}",
                MEDULA_TAKIP_KODU = medulaTakiplerForMalzeme.Any() ? medulaTakiplerForMalzeme[i % medulaTakiplerForMalzeme.Count].MEDULA_TAKIP_KODU : "-",
                MEDULA_OZEL_DURUM = "-",
                AMELIYAT_KODU = ameliyatlarForMalzeme.Any() ? ameliyatlarForMalzeme[i % ameliyatlarForMalzeme.Count].AMELIYAT_KODU : "-",
                ISTEYEN_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                DEPO_KODU = depolarForMalzeme[i % depolarForMalzeme.Count].DEPO_KODU,
                IPTAL_DURUMU = "HAYIR"
            }).ToList());
        }
        _logger.LogInformation("HASTA_MALZEME seeded");

        // HASTA_SEANS referans kodları
        var seansIslemTuruRef = new[] { "HEMODIYALIZ", "PERITON_DIYALIZI", "RADYOTERAPI", "FIZIK_TEDAVI" };
        var antihipertansifRef = new[] { "KULLANMIYOR", "KULLANIYOR" };
        var oncekiRrtRef = new[] { "YOK", "HEMODIYALIZ", "PERITON", "TRANSPLANT" };
        var hemodiyalizeGecmeRef = new[] { "DIYABET", "HIPERTANSIYON", "GLOMERULONEFRIT", "POLIKISTIK", "DIGER" };
        var damarErisimRef = new[] { "AVF", "AVG", "KATETER" };
        var diyalizSikligiRef = new[] { "HAFTADA_2", "HAFTADA_3", "HAFTADA_4" };
        var diyalizorAlaniRef = new[] { "1_0", "1_4", "1_6", "1_8", "2_0" };
        var diyalizorTipiRef = new[] { "LOW_FLUX", "HIGH_FLUX" };
        var kanAkimHiziRef = new[] { "250", "300", "350", "400" };
        var agirlikOlcumRef = new[] { "SEANS_ONCESI", "SEANS_SONRASI" };
        var diyalizTedavisiRef = new[] { "STANDART_HD", "HDF", "AFB" };
        var peritonGecirgenlikRef = new[] { "DUSUK", "DUSUK_ORTA", "YUKSEK_ORTA", "YUKSEK" };
        var peritonKateterRef = new[] { "1", "2", "3" };
        var peritonKateterTipiRef = new[] { "CURLED", "STRAIGHT", "SWAN_NECK" };
        var peritonKateterYontemiRef = new[] { "CERRAHI", "PERUKTAN" };
        var peritonTunelYonuRef = new[] { "YUKARI", "ASAGI", "YATAY" };
        var sinekalsetRef = new[] { "KULLANMIYOR", "ORAL", "IV" };
        var tedavininSeyriRef = new[] { "NORMAL", "KOMPLIKASYONLU", "ACIL" };
        var vitaminDRef = new[] { "KULLANMIYOR", "ORAL", "IV" };
        var anemiTedavisiRef = new[] { "YOK", "EPO", "DEMIR", "TRANSFUZYON" };
        var fosforBaglayiciRef = new[] { "KULLANMIYOR", "KALSIYUM_BAZLI", "KALSIYUM_ICERMEYEN" };
        var peritonKomplikasyonRef = new[] { "YOK", "PERITONIT", "KATETER_ENFEKSIYONU", "HERNI" };

        foreach (var r in seansIslemTuruRef) await AddReferansKodIfNotExists("SEANS_ISLEM_TURU", r, r, ct);
        foreach (var r in antihipertansifRef) await AddReferansKodIfNotExists("ANTIHIPERTANSIF_ILAC_DURUMU", r, r, ct);
        foreach (var r in oncekiRrtRef) await AddReferansKodIfNotExists("ONCEKI_RRT_YONTEMI", r, r, ct);
        foreach (var r in hemodiyalizeGecmeRef) await AddReferansKodIfNotExists("HEMODIYALIZE_GECME_NEDENLERI", r, r, ct);
        foreach (var r in damarErisimRef) await AddReferansKodIfNotExists("DAMAR_ERISIM_YOLU", r, r, ct);
        foreach (var r in diyalizSikligiRef) await AddReferansKodIfNotExists("DIYALIZE_GIRME_SIKLIGI", r, r, ct);
        foreach (var r in diyalizorAlaniRef) await AddReferansKodIfNotExists("DIYALIZOR_ALANI", r, r, ct);
        foreach (var r in diyalizorTipiRef) await AddReferansKodIfNotExists("DIYALIZOR_TIPI", r, r, ct);
        foreach (var r in kanAkimHiziRef) await AddReferansKodIfNotExists("KAN_AKIM_HIZI", r, r, ct);
        foreach (var r in agirlikOlcumRef) await AddReferansKodIfNotExists("AGIRLIK_OLCUM_ZAMANI", r, r, ct);
        foreach (var r in diyalizTedavisiRef) await AddReferansKodIfNotExists("KULLANILAN_DIYALIZ_TEDAVISI", r, r, ct);
        foreach (var r in peritonGecirgenlikRef) await AddReferansKodIfNotExists("PERITONEAL_GECIRGENLIK_DURUMU", r, r, ct);
        foreach (var r in peritonKateterRef) await AddReferansKodIfNotExists("PERITON_KACINCI_KATETER", r, r, ct);
        foreach (var r in peritonKateterTipiRef) await AddReferansKodIfNotExists("PERITON_KATETER_TIPI", r, r, ct);
        foreach (var r in peritonKateterYontemiRef) await AddReferansKodIfNotExists("PERITON_KATETER_YONTEMI", r, r, ct);
        foreach (var r in peritonTunelYonuRef) await AddReferansKodIfNotExists("PERITON_TUNEL_YONU", r, r, ct);
        foreach (var r in sinekalsetRef) await AddReferansKodIfNotExists("SINEKALSET", r, r, ct);
        foreach (var r in tedavininSeyriRef) await AddReferansKodIfNotExists("TEDAVININ_SEYRI", r, r, ct);
        foreach (var r in vitaminDRef) await AddReferansKodIfNotExists("AKTIF_VITAMIN_D_KULLANIMI", r, r, ct);
        foreach (var r in anemiTedavisiRef) await AddReferansKodIfNotExists("ANEMI_TEDAVISI_YONTEMI", r, r, ct);
        foreach (var r in fosforBaglayiciRef) await AddReferansKodIfNotExists("FOSFOR_BAGLAYICI_AJAN", r, r, ct);
        foreach (var r in peritonKomplikasyonRef) await AddReferansKodIfNotExists("PERITON_KOMPLIKASYON", r, r, ct);
        await _db.SaveChangesAsync(ct);

        // 25. HASTA_SEANS - Hasta Seans Bilgileri
        var cihazlarForSeans = await _db.Set<CIHAZ>().Take(10).ToListAsync(ct);
        if (cihazlarForSeans.Any())
        {
            await SeedIfEmpty<HASTA_SEANS>(ct, basvurular.Take(25).Select((b, i) => new HASTA_SEANS
            {
                HASTA_SEANS_KODU = $"HS-{i + 1:D5}",
                HASTA_KODU = b.HASTA_KODU,
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                SEANS_ISLEM_TURU = $"SEANS_ISLEM_TURU_{seansIslemTuruRef[i % seansIslemTuruRef.Length]}",
                CIHAZ_KODU = cihazlarForSeans[i % cihazlarForSeans.Count].CIHAZ_KODU,
                PLANLANAN_SEANS_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                SEANS_BASLAMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)).AddHours(8),
                SEANS_BITIS_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)).AddHours(12),
                ANTIHIPERTANSIF_ILAC_DURUMU = $"ANTIHIPERTANSIF_ILAC_DURUMU_{antihipertansifRef[i % antihipertansifRef.Length]}",
                ONCEKI_RRT_YONTEMI = $"ONCEKI_RRT_YONTEMI_{oncekiRrtRef[i % oncekiRrtRef.Length]}",
                HEMODIYALIZE_GECME_NEDENLERI = $"HEMODIYALIZE_GECME_NEDENLERI_{hemodiyalizeGecmeRef[i % hemodiyalizeGecmeRef.Length]}",
                DAMAR_ERISIM_YOLU = $"DAMAR_ERISIM_YOLU_{damarErisimRef[i % damarErisimRef.Length]}",
                DIYALIZE_GIRME_SIKLIGI = $"DIYALIZE_GIRME_SIKLIGI_{diyalizSikligiRef[i % diyalizSikligiRef.Length]}",
                DIYALIZOR_ALANI = $"DIYALIZOR_ALANI_{diyalizorAlaniRef[i % diyalizorAlaniRef.Length]}",
                DIYALIZOR_TIPI = $"DIYALIZOR_TIPI_{diyalizorTipiRef[i % diyalizorTipiRef.Length]}",
                KAN_AKIM_HIZI = $"KAN_AKIM_HIZI_{kanAkimHiziRef[i % kanAkimHiziRef.Length]}",
                AGIRLIK_OLCUM_ZAMANI = $"AGIRLIK_OLCUM_ZAMANI_{agirlikOlcumRef[i % agirlikOlcumRef.Length]}",
                KULLANILAN_DIYALIZ_TEDAVISI = $"KULLANILAN_DIYALIZ_TEDAVISI_{diyalizTedavisiRef[i % diyalizTedavisiRef.Length]}",
                PERITONEAL_GECIRGENLIK_DURUMU = $"PERITONEAL_GECIRGENLIK_DURUMU_{peritonGecirgenlikRef[i % peritonGecirgenlikRef.Length]}",
                PERITON_KACINCI_KATETER = $"PERITON_KACINCI_KATETER_{peritonKateterRef[i % peritonKateterRef.Length]}",
                PERITON_KATETER_TIPI = $"PERITON_KATETER_TIPI_{peritonKateterTipiRef[i % peritonKateterTipiRef.Length]}",
                PERITON_KATETER_YONTEMI = $"PERITON_KATETER_YONTEMI_{peritonKateterYontemiRef[i % peritonKateterYontemiRef.Length]}",
                PERITON_TUNEL_YONU = $"PERITON_TUNEL_YONU_{peritonTunelYonuRef[i % peritonTunelYonuRef.Length]}",
                SINEKALSET = $"SINEKALSET_{sinekalsetRef[i % sinekalsetRef.Length]}",
                TEDAVININ_SEYRI = $"TEDAVININ_SEYRI_{tedavininSeyriRef[i % tedavininSeyriRef.Length]}",
                AKTIF_VITAMIN_D_KULLANIMI = $"AKTIF_VITAMIN_D_KULLANIMI_{vitaminDRef[i % vitaminDRef.Length]}",
                ANEMI_TEDAVISI_YONTEMI = $"ANEMI_TEDAVISI_YONTEMI_{anemiTedavisiRef[i % anemiTedavisiRef.Length]}",
                FOSFOR_BAGLAYICI_AJAN = $"FOSFOR_BAGLAYICI_AJAN_{fosforBaglayiciRef[i % fosforBaglayiciRef.Length]}",
                PERITON_KOMPLIKASYON = $"PERITON_KOMPLIKASYON_{peritonKomplikasyonRef[i % peritonKomplikasyonRef.Length]}",
                ACIKLAMA = $"Hasta seans kaydı {i + 1}"
            }).ToList());
        }
        _logger.LogInformation("HASTA_SEANS seeded");

        // HASTA_SEVK referans kodları
        var sevkNedeniRef = new[] { "TANI", "TEDAVI", "AMELIYAT", "KONSULTASYON", "DIGER" };
        var sevkTanisiRef = new[] { "J18.9", "I10", "E11.9", "K80.2", "M54.5" };
        var sevkSekliRef = new[] { "REFAKATLI", "POLISLI", "JANDARMA", "TEK" };
        var sevkVasitasiRef = new[] { "AMBULANS", "OZEL_ARAC", "TOPLU_TASIMA", "HELIKOPTER" };
        var sevkTedaviTipiRef = new[] { "AYAKTAN", "YATARAK", "GUNUBIRLIK" };

        foreach (var r in sevkNedeniRef) await AddReferansKodIfNotExists("SEVK_NEDENI", r, r, ct);
        foreach (var r in sevkTanisiRef) await AddReferansKodIfNotExists("SEVK_TANISI", r, r, ct);
        foreach (var r in sevkSekliRef) await AddReferansKodIfNotExists("SEVK_SEKLI", r, r, ct);
        foreach (var r in sevkVasitasiRef) await AddReferansKodIfNotExists("SEVK_VASITASI_KODU", r, r, ct);
        foreach (var r in sevkTedaviTipiRef) await AddReferansKodIfNotExists("SEVK_TEDAVI_TIPI", r, r, ct);
        await _db.SaveChangesAsync(ct);

        // 26. HASTA_SEVK - Hasta Sevk Bilgileri
        var kurumlarForSevk = await _db.Set<KURUM>().Take(10).ToListAsync(ct);
        if (kurumlarForSevk.Any())
        {
            await SeedIfEmpty<HASTA_SEVK>(ct, basvurular.Take(25).Select((b, i) => new HASTA_SEVK
            {
                HASTA_SEVK_KODU = $"HSV-{i + 1:D5}",
                HASTA_KODU = b.HASTA_KODU,
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                SEVK_TAKIP_NUMARASI = $"STN{_random.Next(100000000, 999999999)}",
                SEVK_NEDENI = $"SEVK_NEDENI_{sevkNedeniRef[i % sevkNedeniRef.Length]}",
                SEVK_EDILEN_BRANS_KODU = $"BRN{_random.Next(100, 999)}",
                SEVK_EDILEN_KURUM_KODU = kurumlarForSevk[i % kurumlarForSevk.Count].KURUM_KODU,
                SEVK_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 60)),
                SEVK_TANISI = $"SEVK_TANISI_{sevkTanisiRef[i % sevkTanisiRef.Length]}",
                SEVK_SEKLI = $"SEVK_SEKLI_{sevkSekliRef[i % sevkSekliRef.Length]}",
                SEVK_VASITASI_KODU = $"SEVK_VASITASI_KODU_{sevkVasitasiRef[i % sevkVasitasiRef.Length]}",
                SEVK_TEDAVI_TIPI = $"SEVK_TEDAVI_TIPI_{sevkTedaviTipiRef[i % sevkTedaviTipiRef.Length]}",
                SEVK_ACIKLAMA = $"Sevk açıklaması {i + 1}",
                SEVK_EDEN_1_PERSONEL_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                SEVK_EDEN_2_PERSONEL_KODU = personeller[(i + 1) % personeller.Count].PERSONEL_KODU,
                SEVK_EDEN_3_PERSONEL_KODU = personeller[(i + 2) % personeller.Count].PERSONEL_KODU,
                REFAKATCI_DURUMU = i % 2 == 0 ? "VAR" : "YOK",
                MEDULA_E_SEVK_NUMARASI = $"ESN{_random.Next(100000000, 999999999)}",
                AMBULANS_PROTOKOL_NUMARASI = $"APN{_random.Next(100000, 999999)}"
            }).ToList());
        }
        _logger.LogInformation("HASTA_SEVK seeded");

        // ILAC_UYUM referans kodları
        var ilacUyumsuzlukTuruRef = new[] { "ETKILESIM", "KONTRAENDIKASYON", "ALERJI", "DOZ_ASIMI" };
        var ilacBarkoduRef = new[] { "8699508012345", "8699508012346", "8699508012347", "8699508012348" };
        var etkenMaddeRef = new[] { "PARASETAMOL", "IBUPROFEN", "ASPIRIN", "METFORMIN" };
        var besinRef = new[] { "GREYFURT", "SUT", "ISPANAK", "ALKOL" };
        var renkSeviyeRef = new[] { "KIRMIZI", "SARI", "YESIL" };

        foreach (var r in ilacUyumsuzlukTuruRef) await AddReferansKodIfNotExists("ILAC_UYUMSUZLUK_TURU", r, r, ct);
        foreach (var r in ilacBarkoduRef) await AddReferansKodIfNotExists("BIRINCI_ILAC_BARKODU", r, r, ct);
        foreach (var r in ilacBarkoduRef) await AddReferansKodIfNotExists("IKINCI_ILAC_BARKODU", r, r, ct);
        foreach (var r in etkenMaddeRef) await AddReferansKodIfNotExists("BIRINCI_ETKEN_MADDE_KODU", r, r, ct);
        foreach (var r in etkenMaddeRef) await AddReferansKodIfNotExists("IKINCI_ETKEN_MADDE_KODU", r, r, ct);
        foreach (var r in besinRef) await AddReferansKodIfNotExists("BESIN_KODU", r, r, ct);
        foreach (var r in new[] { "E", "K" }) await AddReferansKodIfNotExists("CINSIYET_ILAC", r, r, ct);
        foreach (var r in renkSeviyeRef) await AddReferansKodIfNotExists("RENK_SEVIYE_KODU", r, r, ct);
        await _db.SaveChangesAsync(ct);

        // 27. ILAC_UYUM - İlaç Uyum Bilgileri
        await SeedIfEmpty<ILAC_UYUM>(ct, Enumerable.Range(1, 25).Select(i => new ILAC_UYUM
        {
            ILAC_UYUM_KODU = $"IU-{i:D5}",
            ILAC_UYUMSUZLUK_TURU = $"ILAC_UYUMSUZLUK_TURU_{ilacUyumsuzlukTuruRef[i % ilacUyumsuzlukTuruRef.Length]}",
            BIRINCI_ILAC_BARKODU = $"BIRINCI_ILAC_BARKODU_{ilacBarkoduRef[i % ilacBarkoduRef.Length]}",
            BIRINCI_ETKEN_MADDE_KODU = $"BIRINCI_ETKEN_MADDE_KODU_{etkenMaddeRef[i % etkenMaddeRef.Length]}",
            IKINCI_ILAC_BARKODU = $"IKINCI_ILAC_BARKODU_{ilacBarkoduRef[(i + 1) % ilacBarkoduRef.Length]}",
            IKINCI_ETKEN_MADDE_KODU = $"IKINCI_ETKEN_MADDE_KODU_{etkenMaddeRef[(i + 1) % etkenMaddeRef.Length]}",
            BESIN_KODU = $"BESIN_KODU_{besinRef[i % besinRef.Length]}",
            YAS_BASLANGIC = "0",
            YAS_BITIS = "36500",
            CINSIYET = $"CINSIYET_ILAC_{(i % 2 == 0 ? "E" : "K")}",
            RENK_SEVIYE_KODU = $"RENK_SEVIYE_KODU_{renkSeviyeRef[i % renkSeviyeRef.Length]}",
            ACIKLAMA = $"İlaç uyum kaydı {i}"
        }).ToList());
        _logger.LogInformation("ILAC_UYUM seeded");

        // INTIHAR_IZLEM referans kodları
        var ii_intiharVakaTuruRef = new[] { "INTIHAR", "KRIZ" };
        var ii_intiharKrizNedeniRef = new[] { "AILE", "EKONOMIK", "SAGLIK", "ILISKI", "IS", "DIGER" };
        var ii_intiharYontemiRef = new[] { "ILAC", "ASI", "YUKSEKTEN_ATLAMA", "KESICI_ALET", "ATES_SILAHI", "DIGER" };
        var ii_intiharSonucuRef = new[] { "TABURCU", "YATIS", "SEVK", "EXITUS" };

        foreach (var r in ii_intiharVakaTuruRef) await AddReferansKodIfNotExists("INTIHAR_KRIZ_VAKA_TURU", r, r, ct);
        foreach (var r in ii_intiharKrizNedeniRef) await AddReferansKodIfNotExists("INTIHAR_GIRISIM_KRIZ_NEDENLERI", r, r, ct);
        foreach (var r in ii_intiharYontemiRef) await AddReferansKodIfNotExists("INTIHAR_GIRISIMI_YONTEMI", r, r, ct);
        foreach (var r in ii_intiharSonucuRef) await AddReferansKodIfNotExists("INTIHAR_KRIZ_VAKA_SONUCU", r, r, ct);
        await _db.SaveChangesAsync(ct);

        // 28. INTIHAR_IZLEM - İntihar/Kriz İzlem Bilgileri
        await SeedIfEmpty<INTIHAR_IZLEM>(ct, basvurular.Take(25).Select((b, i) => new INTIHAR_IZLEM
        {
            INTIHAR_IZLEM_KODU = $"II-{i + 1:D5}",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            INTIHAR_KRIZ_VAKA_TURU = $"INTIHAR_KRIZ_VAKA_TURU_{ii_intiharVakaTuruRef[i % ii_intiharVakaTuruRef.Length]}",
            INTIHAR_GIRISIM_KRIZ_NEDENLERI = $"INTIHAR_GIRISIM_KRIZ_NEDENLERI_{ii_intiharKrizNedeniRef[i % ii_intiharKrizNedeniRef.Length]}",
            INTIHAR_GIRISIMI_YONTEMI = $"INTIHAR_GIRISIMI_YONTEMI_{ii_intiharYontemiRef[i % ii_intiharYontemiRef.Length]}",
            INTIHAR_KRIZ_VAKA_SONUCU = $"INTIHAR_KRIZ_VAKA_SONUCU_{ii_intiharSonucuRef[i % ii_intiharSonucuRef.Length]}",
            ACIKLAMA = $"İntihar/Kriz izlem kaydı {i + 1}"
        }).ToList());
        _logger.LogInformation("INTIHAR_IZLEM seeded");

        // KADIN_IZLEM referans kodları
        var konjenitalAnomaliKadinRef = new[] { "YOK", "VAR", "BILINMIYOR" };
        var apYontemiRef = new[] { "HAPYOK", "RIA", "KONDOM", "IMPLANT", "CERRAHI", "DIGER" };
        var apLojistigiRef = new[] { "VERILDI", "STOK_YOK", "RED" };
        var kadinSagligiIslemleriRef = new[] { "MUAYENE", "SMEAR", "MAMOGRAFI", "ULTRASON", "DIGER" };

        foreach (var r in konjenitalAnomaliKadinRef) await AddReferansKodIfNotExists("KONJENITAL_ANOMALI_VARLIGI", r, r, ct);
        foreach (var r in apYontemiRef) await AddReferansKodIfNotExists("KULLANILAN_AP_YONTEMI", r, r, ct);
        foreach (var r in apYontemiRef) await AddReferansKodIfNotExists("BIR_ONCE_KULLANILAN_AP_YONTEMI", r, r, ct);
        foreach (var r in apLojistigiRef) await AddReferansKodIfNotExists("AP_YONTEMI_LOJISTIGI", r, r, ct);
        foreach (var r in kadinSagligiIslemleriRef) await AddReferansKodIfNotExists("KADIN_SAGLIGI_ISLEMLERI", r, r, ct);
        await _db.SaveChangesAsync(ct);

        // 29. KADIN_IZLEM - Kadın İzlem (15-49 Yaş)
        await SeedIfEmpty<KADIN_IZLEM>(ct, basvurular.Take(25).Select((b, i) => new KADIN_IZLEM
        {
            KADIN_IZLEM_KODU = $"KI-{i + 1:D5}",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            KONJENITAL_ANOMALI_VARLIGI = $"KONJENITAL_ANOMALI_VARLIGI_{konjenitalAnomaliKadinRef[i % konjenitalAnomaliKadinRef.Length]}",
            CANLI_DOGAN_BEBEK_SAYISI = $"{_random.Next(0, 4)}",
            OLU_DOGAN_BEBEK_SAYISI = "0",
            HEMOGLOBIN_DEGERI = $"{_random.Next(10, 16)}.{_random.Next(0, 9)}",
            ONCEKI_DOGUM_DURUMU = $"ONCEKI_DOGUM_DURUMU_{oncekiDogumDurumuRef[i % oncekiDogumDurumuRef.Length]}",
            IZLEMIN_YAPILDIGI_YER = birimler.Any() ? birimler[i % birimler.Count].BIRIM_ADI : "Kadın Hastalıkları",
            KULLANILAN_AP_YONTEMI = $"KULLANILAN_AP_YONTEMI_{apYontemiRef[i % apYontemiRef.Length]}",
            BIR_ONCE_KULLANILAN_AP_YONTEMI = $"BIR_ONCE_KULLANILAN_AP_YONTEMI_{apYontemiRef[(i + 1) % apYontemiRef.Length]}",
            AP_YONTEMI_LOJISTIGI = $"AP_YONTEMI_LOJISTIGI_{apLojistigiRef[i % apLojistigiRef.Length]}",
            KADIN_SAGLIGI_ISLEMLERI = $"KADIN_SAGLIGI_ISLEMLERI_{kadinSagligiIslemleriRef[i % kadinSagligiIslemleriRef.Length]}",
            AP_YONTEMI_KULLANMAMA_NEDENI = "-",
            ACIKLAMA = $"Kadın izlem kaydı {i + 1}"
        }).ToList());
        _logger.LogInformation("KADIN_IZLEM seeded");

        // KUDUZ_IZLEM referans kodları
        var profilaksiDurumRef = new[] { "TAMAMLANDI", "DEVAM_EDIYOR", "YARIDA_KALDI" };
        var kuduzProfilaksisiRef = new[] { "ASI", "IMMUNOGLOBULIN", "ASI_VE_IMMUNOGLOBULIN" };

        foreach (var r in profilaksiDurumRef) await AddReferansKodIfNotExists("PROFILAKSI_TAMAMLANMA_DURUMU", r, r, ct);
        foreach (var r in kuduzProfilaksisiRef) await AddReferansKodIfNotExists("UYGULANAN_KUDUZ_PROFILAKSISI", r, r, ct);
        await _db.SaveChangesAsync(ct);

        // 30. KUDUZ_IZLEM - Kuduz İzlem
        if (kurumlarForSevk.Any())
        {
            await SeedIfEmpty<KUDUZ_IZLEM>(ct, basvurular.Take(25).Select((b, i) => new KUDUZ_IZLEM
            {
                KUDUZ_IZLEM_KODU = $"KZ-{i + 1:D5}",
                HASTA_KODU = b.HASTA_KODU,
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                PROFILAKSI_TAMAMLANMA_DURUMU = $"PROFILAKSI_TAMAMLANMA_DURUMU_{profilaksiDurumRef[i % profilaksiDurumRef.Length]}",
                UYGULANAN_KUDUZ_PROFILAKSISI = $"UYGULANAN_KUDUZ_PROFILAKSISI_{kuduzProfilaksisiRef[i % kuduzProfilaksisiRef.Length]}",
                BEYAN_TSM_KURUM_KODU = kurumlarForSevk[i % kurumlarForSevk.Count].KURUM_KODU,
                IMMUNGLOBULIN_MIKTARI = $"{_random.Next(150, 500)}",
                ACIKLAMA = $"Kuduz izlem kaydı {i + 1}"
            }).ToList());
        }
        _logger.LogInformation("KUDUZ_IZLEM seeded");

        // KURUL_ASKERI referans kodları
        var medulaRaporTuruRef = new[] { "ASKERI_RAPOR", "SIVIL_RAPOR" };
        var medulaAltRaporTuruRef = new[] { "YOKLAMA", "CELP", "MUAYENE" };
        var alkolMaddeBagimliligiRef = new[] { "YOK", "ALKOL", "MADDE", "HER_IKISI" };
        var bedenRuhBulguRef = new[] { "YOK", "BEDEN", "RUH", "HER_IKISI" };
        var gecmisHastalikRef = new[] { "YOK", "VAR" };
        var gormeIsitmeRef = new[] { "YOK", "GORME", "ISITME", "HER_IKISI" };
        var psikiyatrikRef = new[] { "YOK", "VAR" };
        var uzuvKaybiRef = new[] { "YOK", "VAR" };
        var asalHastalikRef = new[] { "YOK", "VAR" };
        var asalHastalikTipiRef = new[] { "TIP_A", "TIP_B", "TIP_C" };

        foreach (var r in medulaRaporTuruRef) await AddReferansKodIfNotExists("MEDULA_RAPOR_TURU", r, r, ct);
        foreach (var r in medulaAltRaporTuruRef) await AddReferansKodIfNotExists("MEDULA_ALT_RAPOR_TURU", r, r, ct);
        foreach (var r in alkolMaddeBagimliligiRef) await AddReferansKodIfNotExists("ALKOL_MADDE_BAGIMLILIGI", r, r, ct);
        foreach (var r in bedenRuhBulguRef) await AddReferansKodIfNotExists("BEDEN_RUH_ILERI_TETKIK_BULGUSU", r, r, ct);
        foreach (var r in gecmisHastalikRef) await AddReferansKodIfNotExists("GECMIS_HASTALIGA_DAIR_KAYIT", r, r, ct);
        foreach (var r in gormeIsitmeRef) await AddReferansKodIfNotExists("GORME_ISITME_KAYBI", r, r, ct);
        foreach (var r in psikiyatrikRef) await AddReferansKodIfNotExists("PSIKIYATRIK_RAHATSIZLIK", r, r, ct);
        foreach (var r in uzuvKaybiRef) await AddReferansKodIfNotExists("UZUVKAYBI_ORTOPEDI_RAHATSIZLIK", r, r, ct);
        foreach (var r in asalHastalikRef) await AddReferansKodIfNotExists("ASAL_HASTALIK", r, r, ct);
        foreach (var r in asalHastalikTipiRef) await AddReferansKodIfNotExists("ASAL_HASTALIK_TIPI", r, r, ct);
        await _db.SaveChangesAsync(ct);

        // 31. KURUL_ASKERI - Askeri Kurul Bilgileri
        await SeedIfEmpty<KURUL_ASKERI>(ct, Enumerable.Range(1, 25).Select(i => new KURUL_ASKERI
        {
            KURUL_ASKERI_KODU = $"KA-{i:D5}",
            KURUL_ADI = $"Askeri Sağlık Kurulu {i}",
            MEDULA_RAPOR_TURU = $"MEDULA_RAPOR_TURU_{medulaRaporTuruRef[i % medulaRaporTuruRef.Length]}",
            MEDULA_ALT_RAPOR_TURU = $"MEDULA_ALT_RAPOR_TURU_{medulaAltRaporTuruRef[i % medulaAltRaporTuruRef.Length]}",
            ALKOL_MADDE_BAGIMLILIGI = $"ALKOL_MADDE_BAGIMLILIGI_{alkolMaddeBagimliligiRef[0]}",
            BEDEN_RUH_ILERI_TETKIK_BULGUSU = $"BEDEN_RUH_ILERI_TETKIK_BULGUSU_{bedenRuhBulguRef[0]}",
            GECMIS_HASTALIGA_DAIR_KAYIT = $"GECMIS_HASTALIGA_DAIR_KAYIT_{gecmisHastalikRef[0]}",
            GORME_ISITME_KAYBI = $"GORME_ISITME_KAYBI_{gormeIsitmeRef[0]}",
            PSIKIYATRIK_RAHATSIZLIK = $"PSIKIYATRIK_RAHATSIZLIK_{psikiyatrikRef[0]}",
            UZUVKAYBI_ORTOPEDI_RAHATSIZLIK = $"UZUVKAYBI_ORTOPEDI_RAHATSIZLIK_{uzuvKaybiRef[0]}",
            ASAL_HASTALIK = $"ASAL_HASTALIK_{asalHastalikRef[0]}",
            ASAL_HASTALIK_TIPI = $"ASAL_HASTALIK_TIPI_{asalHastalikTipiRef[i % asalHastalikTipiRef.Length]}"
        }).ToList());
        _logger.LogInformation("KURUL_ASKERI seeded");

        // KURUL_HEKIM referans kodları
        var sistemKoduRef = new[] { "NOROLOJI", "KARDIYOLOJI", "ORTOPEDI", "PSIKIYATRI", "GOZ", "KBB" };
        foreach (var r in sistemKoduRef) await AddReferansKodIfNotExists("SISTEM_KODU", r, r, ct);
        await _db.SaveChangesAsync(ct);

        // 32. KURUL_HEKIM - Kurul Hekim Bilgileri
        var kurulRaporlarForHekim = await _db.Set<KURUL_RAPOR>().Take(10).ToListAsync(ct);
        if (kurulRaporlarForHekim.Any())
        {
            await SeedIfEmpty<KURUL_HEKIM>(ct, basvurular.Take(25).Select((b, i) => new KURUL_HEKIM
            {
                KURUL_HEKIM_KODU = $"KH-{i + 1:D5}",
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_KODU = b.HASTA_KODU,
                KURUL_RAPOR_KODU = kurulRaporlarForHekim[i % kurulRaporlarForHekim.Count].KURUL_RAPOR_KODU,
                HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                MEDULA_BRANS_KODU = $"BRN{_random.Next(100, 999)}",
                SISTEM_KODU = $"SISTEM_KODU_{sistemKoduRef[i % sistemKoduRef.Length]}",
                KURUL_SONUC = $"Kurul sonuç açıklaması {i + 1}",
                ENGELLILIK_ORANI = $"{_random.Next(0, 100)}",
                HEKIM_KURUL_GOREVI = i % 3 == 0 ? "BASKAN" : (i % 3 == 1 ? "UYE" : "RAPORTER"),
                HEKIM_SIRA_NUMARASI = $"{(i % 5) + 1}"
            }).ToList());
        }
        _logger.LogInformation("KURUL_HEKIM seeded");

        // LOHUSA_IZLEM referans kodları
        var lohusaIzlemRef = new[] { "1_IZLEM", "2_IZLEM", "3_IZLEM" };
        var izlemYeriRef = new[] { "HASTANE", "ASM", "EVDE" };
        var postpartumDepresyonRef = new[] { "NORMAL", "RISK", "DEPRESYON" };
        var uterusInvolusyonRef = new[] { "NORMAL", "GECIKMIŞ", "ANORMAL" };
        var seyirTehlikeRef = new[] { "YOK", "KANAMA", "ATES", "ENFEKSIYON" };

        foreach (var r in lohusaIzlemRef) await AddReferansKodIfNotExists("KACINCI_LOHUSA_IZLEM", r, r, ct);
        foreach (var r in izlemYeriRef) await AddReferansKodIfNotExists("IZLEMIN_YAPILDIGI_YER", r, r, ct);
        foreach (var r in postpartumDepresyonRef) await AddReferansKodIfNotExists("POSTPARTUM_DEPRESYON", r, r, ct);
        foreach (var r in uterusInvolusyonRef) await AddReferansKodIfNotExists("UTERUS_INVOLUSYON", r, r, ct);
        foreach (var r in seyirTehlikeRef) await AddReferansKodIfNotExists("SEYIR_TEHLIKE_ISARETI", r, r, ct);
        await _db.SaveChangesAsync(ct);

        // 33. LOHUSA_IZLEM - Lohusa İzlem
        await SeedIfEmpty<LOHUSA_IZLEM>(ct, basvurular.Take(25).Select((b, i) => new LOHUSA_IZLEM
        {
            LOHUSA_IZLEM_KODU = $"LI-{i + 1:D5}",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            KACINCI_LOHUSA_IZLEM = $"KACINCI_LOHUSA_IZLEM_{lohusaIzlemRef[i % lohusaIzlemRef.Length]}",
            IZLEMIN_YAPILDIGI_YER = $"IZLEMIN_YAPILDIGI_YER_{izlemYeriRef[i % izlemYeriRef.Length]}",
            DEMIR_LOJISTIGI_VE_DESTEGI = $"DEMIR_LOJISTIGI_VE_DESTEGI_{demirLojistigiRef[i % demirLojistigiRef.Length]}",
            DVITAMINI_LOJISTIGI_VE_DESTEGI = $"DVITAMINI_LOJISTIGI_VE_DESTEGI_{dvitaminiLojistigiRef[i % dvitaminiLojistigiRef.Length]}",
            GEBELIK_SONLANMA_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 42)),
            POSTPARTUM_DEPRESYON = $"POSTPARTUM_DEPRESYON_{postpartumDepresyonRef[i % postpartumDepresyonRef.Length]}",
            UTERUS_INVOLUSYON = $"UTERUS_INVOLUSYON_{uterusInvolusyonRef[i % uterusInvolusyonRef.Length]}",
            BILGI_ALINAN_KISI_AD_SOYADI = $"Eş {i + 1}",
            BILGI_ALINAN_KISI_TELEFON = $"05{_random.Next(30, 59)}{_random.Next(1000000, 9999999)}",
            KONJENITAL_ANOMALI_VARLIGI = $"KONJENITAL_ANOMALI_VARLIGI_{konjenitalAnomaliRef[0]}",
            HEMOGLOBIN_DEGERI = $"{_random.Next(10, 14)}.{_random.Next(0, 9)}",
            KOMPLIKASYON_TANISI = $"KOMPLIKASYON_TANISI_{komplikasyonTanisiRef[0]}",
            SEYIR_TEHLIKE_ISARETI = $"SEYIR_TEHLIKE_ISARETI_{seyirTehlikeRef[i % seyirTehlikeRef.Length]}",
            KADIN_SAGLIGI_ISLEMLERI = $"KADIN_SAGLIGI_ISLEMLERI_{kadinSagligiIslemleriRef[0]}",
            ACIKLAMA = $"Lohusa izlem kaydı {i + 1}"
        }).ToList());
        _logger.LogInformation("LOHUSA_IZLEM seeded");

        // OBEZITE_IZLEM referans kodları
        var diyetTedavisiRef = new[] { "UYGULANMIYOR", "UYGULANIYOR", "UYUM_SORUNU" };
        var morbitObezRef = new[] { "YOK", "VAR" };
        var obeziteIlacRef = new[] { "KULLANILMIYOR", "ORLISTAT", "DIGER" };
        var psikolojikTedaviRef = new[] { "UYGULANMIYOR", "UYGULANIYOR" };
        var ekHastalikRef = new[] { "YOK", "DIYABET", "HIPERTANSIYON", "DISLIPIDEMI", "DIGER" };
        var egzersizRef = new[] { "SEDANTER", "HAFIF", "ORTA", "YOGUN" };

        foreach (var r in diyetTedavisiRef) await AddReferansKodIfNotExists("DIYET_TIBBI_BESLENME_TEDAVISI", r, r, ct);
        foreach (var r in morbitObezRef) await AddReferansKodIfNotExists("MORBIT_OBEZ_LENFATIK_ODEM", r, r, ct);
        foreach (var r in obeziteIlacRef) await AddReferansKodIfNotExists("OBEZITE_ILAC_TEDAVISI", r, r, ct);
        foreach (var r in psikolojikTedaviRef) await AddReferansKodIfNotExists("PSIKOLOJIK_TEDAVI", r, r, ct);
        foreach (var r in ekHastalikRef) await AddReferansKodIfNotExists("BIRLIKTE_GORULEN_EK_HASTALIK", r, r, ct);
        foreach (var r in egzersizRef) await AddReferansKodIfNotExists("EGZERSIZ", r, r, ct);
        await _db.SaveChangesAsync(ct);

        // 34. OBEZITE_IZLEM - Obezite İzlem
        await SeedIfEmpty<OBEZITE_IZLEM>(ct, basvurular.Take(25).Select((b, i) => new OBEZITE_IZLEM
        {
            OBEZITE_IZLEM_KODU = $"OI-{i + 1:D5}",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            DIYET_TIBBI_BESLENME_TEDAVISI = $"DIYET_TIBBI_BESLENME_TEDAVISI_{diyetTedavisiRef[i % diyetTedavisiRef.Length]}",
            ILK_TANI_TARIHI = DateTime.Now.AddDays(-_random.Next(30, 365)),
            MORBIT_OBEZ_LENFATIK_ODEM = $"MORBIT_OBEZ_LENFATIK_ODEM_{morbitObezRef[i % morbitObezRef.Length]}",
            OBEZITE_ILAC_TEDAVISI = $"OBEZITE_ILAC_TEDAVISI_{obeziteIlacRef[i % obeziteIlacRef.Length]}",
            PSIKOLOJIK_TEDAVI = $"PSIKOLOJIK_TEDAVI_{psikolojikTedaviRef[i % psikolojikTedaviRef.Length]}",
            BIRLIKTE_GORULEN_EK_HASTALIK = $"BIRLIKTE_GORULEN_EK_HASTALIK_{ekHastalikRef[i % ekHastalikRef.Length]}",
            EGZERSIZ = $"EGZERSIZ_{egzersizRef[i % egzersizRef.Length]}",
            ACIKLAMA = $"Obezite izlem kaydı {i + 1}"
        }).ToList());
        _logger.LogInformation("OBEZITE_IZLEM seeded");

        // OPTIK_RECETE referans kodları
        var gozlukReceteTipiRef = new[] { "NORMAL", "TELESKOPIK", "LENS" };
        var gozlukTuruRef = new[] { "TEK_ODAK", "CIFT_ODAK", "PROGRESIF" };
        var camTipiRef = new[] { "DUZ", "ORGANIK", "BIFOKAL", "PROGRESIF" };
        var camRengiRef = new[] { "SEFFAF", "GRI", "KAHVERENGI", "YESIL" };
        var teleskopikTipiRef = new[] { "TEK", "CIFT", "TEK_KAREKOD" };
        var teleskopikTuruRef = new[] { "UZAK_DAIMI", "YAKIN" };

        foreach (var r in gozlukReceteTipiRef) await AddReferansKodIfNotExists("GOZLUK_RECETE_TIPI", r, r, ct);
        foreach (var r in gozlukTuruRef) await AddReferansKodIfNotExists("GOZLUK_TURU", r, r, ct);
        foreach (var r in camTipiRef) await AddReferansKodIfNotExists("SAG_CAM_TIPI", r, r, ct);
        foreach (var r in camTipiRef) await AddReferansKodIfNotExists("SOL_CAM_TIPI", r, r, ct);
        foreach (var r in camRengiRef) await AddReferansKodIfNotExists("SAG_CAM_RENGI", r, r, ct);
        foreach (var r in camRengiRef) await AddReferansKodIfNotExists("SOL_CAM_RENGI", r, r, ct);
        foreach (var r in teleskopikTipiRef) await AddReferansKodIfNotExists("TELESKOPIK_GOZLUK_TIPI", r, r, ct);
        foreach (var r in teleskopikTuruRef) await AddReferansKodIfNotExists("TELESKOPIK_GOZLUK_TURU", r, r, ct);
        await _db.SaveChangesAsync(ct);

        // 35. OPTIK_RECETE - Optik Reçete
        await SeedIfEmpty<OPTIK_RECETE>(ct, basvurular.Take(25).Select((b, i) => new OPTIK_RECETE
        {
            OPTIK_RECETE_KODU = $"OR-{i + 1:D5}",
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            HASTA_KODU = b.HASTA_KODU,
            GOZLUK_RECETE_TIPI = $"GOZLUK_RECETE_TIPI_{gozlukReceteTipiRef[i % gozlukReceteTipiRef.Length]}",
            HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
            RECETE_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 60)),
            GOZLUK_TURU = $"GOZLUK_TURU_{gozlukTuruRef[i % gozlukTuruRef.Length]}",
            SAG_CAM_TIPI = $"SAG_CAM_TIPI_{camTipiRef[i % camTipiRef.Length]}",
            SAG_CAM_RENGI = $"SAG_CAM_RENGI_{camRengiRef[i % camRengiRef.Length]}",
            SAG_CAM_SFERIK = $"{(_random.Next(-6, 6) + _random.NextDouble()):F2}",
            SAG_CAM_SILINDIRIK = $"{(_random.Next(-3, 3) + _random.NextDouble()):F2}",
            SAG_CAM_AKS = $"{_random.Next(0, 180)}",
            SOL_CAM_TIPI = $"SOL_CAM_TIPI_{camTipiRef[i % camTipiRef.Length]}",
            SOL_CAM_RENGI = $"SOL_CAM_RENGI_{camRengiRef[i % camRengiRef.Length]}",
            SOL_CAM_SFERIK = $"{(_random.Next(-6, 6) + _random.NextDouble()):F2}",
            SOL_CAM_SILINDIRIK = $"{(_random.Next(-3, 3) + _random.NextDouble()):F2}",
            SOL_CAM_AKS = $"{_random.Next(0, 180)}",
            SAG_LENS_CAM_SFERIK = "-",
            SAG_LENS_CAM_SILINDIRIK = "-",
            SAG_LENS_CAM_CAP = "-",
            SAG_LENS_CAM_EGIM = "-",
            SAG_LENS_CAM_AKS = "-",
            SOL_LENS_CAM_SFERIK = "-",
            SOL_LENS_CAM_SILINDIRIK = "-",
            SOL_LENS_CAM_CAP = "-",
            SOL_LENS_CAM_EGIM = "-",
            SOL_LENS_CAM_AKS = "-",
            SAG_KERATAKONUS_CAM_SFERIK = "-",
            SAG_KERATAKONUS_CAM_SILINDIR = "-",
            SAG_KERATAKONUS_CAM_CAP = "-",
            SAG_KERATAKONUS_CAM_EGIM = "-",
            SAG_KERATAKONUS_CAM_AKS = "-",
            SOL_KERATAKONUS_CAM_SFERIK = "-",
            SOL_KERATAKONUS_CAM_SILINDIR = "-",
            SOL_KERATAKONUS_CAM_CAP = "-",
            SOL_KERATAKONUS_CAM_EGIM = "-",
            SOL_KERATAKONUS_CAM_AKS = "-",
            TELESKOPIK_GOZLUK_TIPI = $"TELESKOPIK_GOZLUK_TIPI_{teleskopikTipiRef[0]}",
            TELESKOPIK_GOZLUK_TURU = $"TELESKOPIK_GOZLUK_TURU_{teleskopikTuruRef[0]}",
            TELESKOPIK_SAG_CAM = "-",
            TELESKOPIK_SOL_CAM = "-"
        }).ToList());
        _logger.LogInformation("OPTIK_RECETE seeded");

        // PATOLOJI referans kodları
        var patolojiRaporTuruRef = new[] { "BIYOPSI", "SITOLOJI", "FROZEN", "OTOPSI" };
        var dokununOzelligiRef = new[] { "NORMAL", "BENIGN", "MALIGN", "SUPHE" };
        var numuneAlinmaSekliRef = new[] { "BIYOPSI", "EKSIZYON", "INCE_IGNE", "BRUSH" };
        var preparatiDurumuRef = new[] { "YETERLI", "YETERSIZ", "TEKRAR_GEREKLI" };
        var numuneAlinmaYeriRef = new[] { "MIDE", "KOLON", "AKCIGER", "MEME", "PROSTAT", "DERI", "DIGER" };
        var morfolojiRef = new[] { "8000/0", "8010/2", "8140/3", "8500/3" };
        var yerlesimYeriRef = new[] { "C16.9", "C18.9", "C34.9", "C50.9", "C61" };
        var sonucIcerikTuruRef = new[] { "DOC", "RTF", "HTML", "PDF" };

        foreach (var r in patolojiRaporTuruRef) await AddReferansKodIfNotExists("PATOLOJI_RAPOR_TURU", r, r, ct);
        foreach (var r in dokununOzelligiRef) await AddReferansKodIfNotExists("DOKUNUN_TEMEL_OZELLIGI", r, r, ct);
        foreach (var r in numuneAlinmaSekliRef) await AddReferansKodIfNotExists("NUMUNE_ALINMA_SEKLI", r, r, ct);
        foreach (var r in preparatiDurumuRef) await AddReferansKodIfNotExists("PATOLOJI_PREPARATI_DURUMU", r, r, ct);
        foreach (var r in numuneAlinmaYeriRef) await AddReferansKodIfNotExists("NUMUNE_ALINMA_YERI", r, r, ct);
        foreach (var r in morfolojiRef) await AddReferansKodIfNotExists("PATOLOJIK_TANI_MORFOLOJI_KODU", r, r, ct);
        foreach (var r in yerlesimYeriRef) await AddReferansKodIfNotExists("PATOLOJIK_TANI_YERLESIM_YERI", r, r, ct);
        foreach (var r in sonucIcerikTuruRef) await AddReferansKodIfNotExists("SONUC_ICERIK_TURU", r, r, ct);
        await _db.SaveChangesAsync(ct);

        // 36. PATOLOJI - Patoloji Tetkik Bilgileri
        var tetkikNumunelerForPatoloji = await _db.Set<TETKIK_NUMUNE>().Take(10).ToListAsync(ct);
        await SeedIfEmpty<PATOLOJI>(ct, basvurular.Take(25).Select((b, i) => new PATOLOJI
        {
            PATOLOJI_KODU = $"PAT-{i + 1:D5}",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            PATOLOJI_RAPOR_TURU = $"PATOLOJI_RAPOR_TURU_{patolojiRaporTuruRef[i % patolojiRaporTuruRef.Length]}",
            DOKUNUN_TEMEL_OZELLIGI = $"DOKUNUN_TEMEL_OZELLIGI_{dokununOzelligiRef[i % dokununOzelligiRef.Length]}",
            NUMUNE_ALINMA_SEKLI = $"NUMUNE_ALINMA_SEKLI_{numuneAlinmaSekliRef[i % numuneAlinmaSekliRef.Length]}",
            PATOLOJI_PREPARATI_DURUMU = $"PATOLOJI_PREPARATI_DURUMU_{preparatiDurumuRef[0]}",
            PATOLOJI_DEFTER_NUMARASI = $"PDF{DateTime.Now.Year}{_random.Next(10000, 99999)}",
            TETKIK_NUMUNE_KODU = tetkikNumunelerForPatoloji.Any() ? tetkikNumunelerForPatoloji[i % tetkikNumunelerForPatoloji.Count].TETKIK_NUMUNE_KODU : null,
            PATOLOJI_MATERYALI = $"Patoloji materyali {i + 1}",
            ORGAN = numuneAlinmaYeriRef[i % numuneAlinmaYeriRef.Length],
            NUMUNE_ALINMA_YERI = $"NUMUNE_ALINMA_YERI_{numuneAlinmaYeriRef[i % numuneAlinmaYeriRef.Length]}",
            PATOLOJIK_BULGU = $"Patolojik bulgu açıklaması {i + 1}",
            PATOLOJIK_TANI_MORFOLOJI_KODU = $"PATOLOJIK_TANI_MORFOLOJI_KODU_{morfolojiRef[i % morfolojiRef.Length]}",
            PATOLOJIK_TANI_YERLESIM_YERI = $"PATOLOJIK_TANI_YERLESIM_YERI_{yerlesimYeriRef[i % yerlesimYeriRef.Length]}",
            MAKROSKOPI_SONUCU = $"Makroskopi sonucu {i + 1}",
            MIKROSKOPI_SONUCU = $"Mikroskopi sonucu {i + 1}",
            SONUC_ICERIK_TURU = $"SONUC_ICERIK_TURU_{sonucIcerikTuruRef[i % sonucIcerikTuruRef.Length]}",
            RAPOR_YAZAN_PERSONEL_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
            PARCA_KABUL_ZAMANI = DateTime.Now.AddDays(-_random.Next(7, 30)),
            RAPOR_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 7)),
            PATOLOJI_ACIKLAMA = $"Patoloji açıklaması {i + 1}",
            HISTOPATOLOJIK_TANI = $"Histopatolojik tanı {i + 1}",
            SITOPATOLOJIK_TANI = $"Sitopatolojik tanı {i + 1}",
            HISTOKIMYASAL_BOYAMA = "H&E",
            IMMUNHISTOKIMYA_BOYAMA = "-",
            FROZEN_TANI = "-",
            NUMUNE_BOYAMA_YONTEMI = "H&E",
            ONAYLAYAN_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
            ASISTAN_HEKIM_KODU = personeller[(i + 1) % personeller.Count].PERSONEL_KODU,
            PATOLOJI_DIGER_HEKIM_KODU = personeller[(i + 2) % personeller.Count].PERSONEL_KODU,
            YORUM = $"Patoloji uzman yorumu {i + 1}"
        }).ToList());
        _logger.LogInformation("PATOLOJI seeded");

        _logger.LogInformation("All 16 remaining complex tables seeded successfully!");
        _logger.LogInformation("36 table seeding completed!");

        _logger.LogInformation("Level 3 simplified seeding completed!");
    }

    private async Task SeedIfEmpty<T>(CancellationToken ct, List<T> items) where T : class
    {
        try
        {
            if (await _db.Set<T>().AnyAsync(ct))
            {
                _logger.LogInformation($"{typeof(T).Name} already has data, skipping...");
                return;
            }

            await _db.Set<T>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} {typeof(T).Name} records");
        }
        catch (Exception ex)
        {
            _logger.LogWarning($"{typeof(T).Name} seeding failed: {ex.Message}");
            // Clear change tracker to prevent failed entities from affecting subsequent operations
            _db.ChangeTracker.Clear();
        }
    }

    #endregion

    #region Helpers

    private string GenerateTcKimlik()
    {
        // Generate valid TC Kimlik No
        int[] digits = new int[11];
        digits[0] = _random.Next(1, 10);
        for (int i = 1; i < 9; i++)
            digits[i] = _random.Next(0, 10);

        int oddSum = digits[0] + digits[2] + digits[4] + digits[6] + digits[8];
        int evenSum = digits[1] + digits[3] + digits[5] + digits[7];
        digits[9] = ((oddSum * 7) - evenSum) % 10;
        if (digits[9] < 0) digits[9] += 10;

        int total = 0;
        for (int i = 0; i < 10; i++) total += digits[i];
        digits[10] = total % 10;

        return string.Join("", digits);
    }

    private async Task AddReferansKodIfNotExists(string kodTuru, string refKodu, string aciklama, CancellationToken ct)
    {
        var fullKey = $"{kodTuru}_{refKodu}";
        var exists = await _db.Set<REFERANS_KODLAR>()
            .AnyAsync(r => r.REFERANS_KODU == fullKey, ct);
        if (!exists)
        {
            await _db.Set<REFERANS_KODLAR>().AddAsync(new REFERANS_KODLAR
            {
                REFERANS_KODU = fullKey,
                KOD_TURU = kodTuru,
                REFERANS_ADI = aciklama,
                SKRS_KODU = refKodu,
                MEDULA_KODU = refKodu,
                MKYS_KODU = refKodu,
                TIG_KODU = refKodu
            }, ct);
        }
    }

    #endregion
}
