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

    public VemSeeder(ApplicationDbContext db, ILogger<VemSeeder> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Checking VEM data and seeding missing tables...");

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
        var faturaTuruCodes = new[] { "YATAN", "AYAKTAN", "ACIL", "GUNUBIRLIK", "AMELIYAT", "RADYOLOJI" };
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
                ["RADYOLOJI"] = "Radyoloji Faturası"
            };
            codesToAdd.AddRange(missingFaturaTuru.Select(code => CreateReferans(code, "FATURA_TURU", faturaTuruData[code], code, code, code, code)));
        }

        if (codesToAdd.Any())
        {
            await _db.Set<REFERANS_KODLAR>().AddRangeAsync(codesToAdd, ct);
            await _db.SaveChangesAsync(ct);
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
            EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
            KURUM_TURU = "KRM-DH",
            IL_KODU = "06",
            ILCE_KODU = "0601",
            ADRES = "Bilkent Bulvarı No:1 Çankaya/Ankara",
            TELEFON = "0312 552 60 00",
            EMAIL = "bilgi@ankarasehirhastanesi.gov.tr",
            VERGI_NO = "1234567890",
            VERGI_DAIRESI = "Çankaya Vergi Dairesi",
            EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
            KURUM_KODU = kurumKodu,
            AKTIF = true,
            EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
            new() { BINA_KODU = "BNA-001", BINA_ADI = "A Blok - Ana Bina", BINA_ADRESI = "Bilkent Bulvarı No:1 A Blok", EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { BINA_KODU = "BNA-002", BINA_ADI = "B Blok - Cerrahi Binası", BINA_ADRESI = "Bilkent Bulvarı No:1 B Blok", EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { BINA_KODU = "BNA-003", BINA_ADI = "C Blok - Acil ve Yoğun Bakım", BINA_ADRESI = "Bilkent Bulvarı No:1 C Blok", EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
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
                    EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                    YATAK_TURU = yatakTuru,
                    AKTIF = true,
                    EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                TC_KIMLIK_NO = GenerateTcKimlik(),
                AD = ad,
                SOYAD = soyad,
                UNVAN = unvan,
                UZMANLIK_KODU = uzmanlik,
                BIRIM_KODU = birim,
                CINSIYET = cinsiyet,
                DOGUM_TARIHI = DateTime.Now.AddYears(-_random.Next(35, 60)),
                EMAIL = $"{ad.ToLower()}.{soyad.ToLower()}@hastane.gov.tr",
                TELEFON = $"0532{_random.Next(1000000, 9999999)}",
                DIPLOMA_NO = $"DIP{_random.Next(100000, 999999)}",
                ISE_BASLAMA_TARIHI = DateTime.Now.AddYears(-_random.Next(5, 25)),
                AKTIF = true,
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                TC_KIMLIK_NO = GenerateTcKimlik(),
                AD = ad,
                SOYAD = soyad,
                UNVAN = "Hemşire",
                UZMANLIK_KODU = "UZM-HMS",
                BIRIM_KODU = birim,
                CINSIYET = cinsiyet,
                DOGUM_TARIHI = DateTime.Now.AddYears(-_random.Next(25, 45)),
                EMAIL = $"{ad.ToLower()}.{soyad.ToLower()}@hastane.gov.tr",
                TELEFON = $"0533{_random.Next(1000000, 9999999)}",
                ISE_BASLAMA_TARIHI = DateTime.Now.AddYears(-_random.Next(2, 15)),
                AKTIF = true,
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
            new() { HIZMET_KODU = "HZM-MYN-001", HIZMET_ADI = "Poliklinik Muayenesi", SUT_KODU = "520010", HIZMET_ISLEM_GRUBU = "HZG-MYN", HIZMET_ISLEM_TURU = "HZT-SUT", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { HIZMET_KODU = "HZM-MYN-002", HIZMET_ADI = "Acil Muayene", SUT_KODU = "520020", HIZMET_ISLEM_GRUBU = "HZG-MYN", HIZMET_ISLEM_TURU = "HZT-SUT", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { HIZMET_KODU = "HZM-MYN-003", HIZMET_ADI = "Konsültasyon", SUT_KODU = "520030", HIZMET_ISLEM_GRUBU = "HZG-MYN", HIZMET_ISLEM_TURU = "HZT-SUT", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { HIZMET_KODU = "HZM-TTK-001", HIZMET_ADI = "Tam Kan Sayımı", SUT_KODU = "900110", HIZMET_ISLEM_GRUBU = "HZG-TTK", HIZMET_ISLEM_TURU = "HZT-SUT", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { HIZMET_KODU = "HZM-TTK-002", HIZMET_ADI = "Biyokimya Paneli", SUT_KODU = "900120", HIZMET_ISLEM_GRUBU = "HZG-TTK", HIZMET_ISLEM_TURU = "HZT-SUT", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { HIZMET_KODU = "HZM-TTK-003", HIZMET_ADI = "İdrar Tahlili", SUT_KODU = "900130", HIZMET_ISLEM_GRUBU = "HZG-TTK", HIZMET_ISLEM_TURU = "HZT-SUT", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { HIZMET_KODU = "HZM-TTK-004", HIZMET_ADI = "EKG", SUT_KODU = "900140", HIZMET_ISLEM_GRUBU = "HZG-TTK", HIZMET_ISLEM_TURU = "HZT-SUT", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { HIZMET_KODU = "HZM-RAD-001", HIZMET_ADI = "Akciğer Grafisi", SUT_KODU = "801010", HIZMET_ISLEM_GRUBU = "HZG-RAD", HIZMET_ISLEM_TURU = "HZT-SUT", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { HIZMET_KODU = "HZM-RAD-002", HIZMET_ADI = "Batın USG", SUT_KODU = "801020", HIZMET_ISLEM_GRUBU = "HZG-RAD", HIZMET_ISLEM_TURU = "HZT-SUT", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { HIZMET_KODU = "HZM-RAD-003", HIZMET_ADI = "Beyin MR", SUT_KODU = "801030", HIZMET_ISLEM_GRUBU = "HZG-RAD", HIZMET_ISLEM_TURU = "HZT-SUT", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { HIZMET_KODU = "HZM-RAD-004", HIZMET_ADI = "Batın BT", SUT_KODU = "801040", HIZMET_ISLEM_GRUBU = "HZG-RAD", HIZMET_ISLEM_TURU = "HZT-SUT", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { HIZMET_KODU = "HZM-AML-001", HIZMET_ADI = "Apendektomi", SUT_KODU = "600110", HIZMET_ISLEM_GRUBU = "HZG-AML", HIZMET_ISLEM_TURU = "HZT-SUT", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { HIZMET_KODU = "HZM-AML-002", HIZMET_ADI = "Kolesistektomi", SUT_KODU = "600120", HIZMET_ISLEM_GRUBU = "HZG-AML", HIZMET_ISLEM_TURU = "HZT-SUT", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { HIZMET_KODU = "HZM-AML-003", HIZMET_ADI = "Herni Onarımı", SUT_KODU = "600130", HIZMET_ISLEM_GRUBU = "HZG-AML", HIZMET_ISLEM_TURU = "HZT-SUT", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
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
            new() { TETKIK_KODU = "TTK-HEM-001", TETKIK_ADI = "Hemoglobin", LOINC_KODU = "718-7", HIZMET_KODU = "HZM-TTK-001", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { TETKIK_KODU = "TTK-HEM-002", TETKIK_ADI = "Hematokrit", LOINC_KODU = "4544-3", HIZMET_KODU = "HZM-TTK-001", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { TETKIK_KODU = "TTK-HEM-003", TETKIK_ADI = "Lökosit (WBC)", LOINC_KODU = "6690-2", HIZMET_KODU = "HZM-TTK-001", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { TETKIK_KODU = "TTK-HEM-004", TETKIK_ADI = "Trombosit (PLT)", LOINC_KODU = "777-3", HIZMET_KODU = "HZM-TTK-001", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { TETKIK_KODU = "TTK-BYO-001", TETKIK_ADI = "Glukoz", LOINC_KODU = "2345-7", HIZMET_KODU = "HZM-TTK-002", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { TETKIK_KODU = "TTK-BYO-002", TETKIK_ADI = "Üre (BUN)", LOINC_KODU = "3094-0", HIZMET_KODU = "HZM-TTK-002", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { TETKIK_KODU = "TTK-BYO-003", TETKIK_ADI = "Kreatinin", LOINC_KODU = "2160-0", HIZMET_KODU = "HZM-TTK-002", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { TETKIK_KODU = "TTK-BYO-004", TETKIK_ADI = "AST (SGOT)", LOINC_KODU = "1920-8", HIZMET_KODU = "HZM-TTK-002", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { TETKIK_KODU = "TTK-BYO-005", TETKIK_ADI = "ALT (SGPT)", LOINC_KODU = "1742-6", HIZMET_KODU = "HZM-TTK-002", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { TETKIK_KODU = "TTK-BYO-006", TETKIK_ADI = "Total Kolesterol", LOINC_KODU = "2093-3", HIZMET_KODU = "HZM-TTK-002", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { TETKIK_KODU = "TTK-BYO-007", TETKIK_ADI = "Trigliserit", LOINC_KODU = "2571-8", HIZMET_KODU = "HZM-TTK-002", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { TETKIK_KODU = "TTK-BYO-008", TETKIK_ADI = "HDL Kolesterol", LOINC_KODU = "2085-9", HIZMET_KODU = "HZM-TTK-002", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { TETKIK_KODU = "TTK-BYO-009", TETKIK_ADI = "LDL Kolesterol", LOINC_KODU = "2089-1", HIZMET_KODU = "HZM-TTK-002", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { TETKIK_KODU = "TTK-IDR-001", TETKIK_ADI = "İdrar pH", LOINC_KODU = "2756-5", HIZMET_KODU = "HZM-TTK-003", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { TETKIK_KODU = "TTK-IDR-002", TETKIK_ADI = "İdrar Dansite", LOINC_KODU = "2965-2", HIZMET_KODU = "HZM-TTK-003", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
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
                TC_KIMLIK_NO = GenerateTcKimlik(),
                AD = ad,
                SOYAD = soyad,
                CINSIYET = erkek ? "CNS-E" : "CNS-K",
                DOGUM_TARIHI = DateTime.Now.AddYears(-_random.Next(1, 85)).AddDays(-_random.Next(0, 365)),
                DOGUM_YERI = iller[_random.Next(iller.Length)],
                ANA_ADI = anaAdi,
                BABA_ADI = babaAdi,
                KAN_GRUBU = kanGruplari[_random.Next(kanGruplari.Length)],
                MEDENI_HAL = i > 25 ? "MDN-EVL" : (i > 10 ? "MDN-BKR" : "MDN-EVL"),
                UYRUK = "TC",
                MESLEK = meslekler[_random.Next(meslekler.Length)],
                IL_KODU = "06",
                ILCE_KODU = $"06{_random.Next(1, 25):D2}",
                ADRES = $"Örnek Mahallesi {_random.Next(1, 100)}. Sokak No:{_random.Next(1, 50)} Ankara",
                TELEFON = $"0312{_random.Next(1000000, 9999999)}",
                CEP_TELEFON = $"053{_random.Next(0, 9)}{_random.Next(1000000, 9999999)}",
                EMAIL = $"{ad.ToLower()}.{soyad.ToLower()}{i}@email.com",
                SOSYAL_GUVENCE = sosyalGuvenceler[_random.Next(sosyalGuvenceler.Length)],
                SIGORTA_NO = $"SGK{_random.Next(10000000, 99999999)}",
                PROTOKOL_NO = $"P{DateTime.Now.Year}{i:D6}",
                AKTIF = true,
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
        var personeller = await _db.Set<PERSONEL>().Where(p => p.UNVAN != "Hemşire").ToListAsync(ct);
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
                var doktor = personeller.FirstOrDefault(p => p.BIRIM_KODU == birim.BIRIM_KODU) ?? personeller[_random.Next(personeller.Count)];
                var basvuruTarihi = DateTime.Now.AddDays(-_random.Next(1, 180));
                bool tapisCikti = _random.Next(100) < 70;

                var basvuru = new HASTA_BASVURU
                {
                    HASTA_BASVURU_KODU = $"BSV-{bsvNo:D5}",
                    HASTA_KODU = hasta.HASTA_KODU,
                    BASVURU_TARIHI = basvuruTarihi,
                    BASVURU_TURU = birim.BIRIM_TURU == "BRM-ACL" ? "BSV-ACL" : "BSV-AYK",
                    BASVURU_SEKLI = _random.Next(100) < 80 ? "BSK-NRM" : "BSK-SVK",
                    BIRIM_KODU = birim.BIRIM_KODU,
                    DOKTOR_KODU = doktor.PERSONEL_KODU,
                    SIKAYET = sikayetler[_random.Next(sikayetler.Length)],
                    TANI_KODU = taniKodlari[_random.Next(taniKodlari.Length)],
                    PROVIZYON_TIPI = "N",
                    TAKIP_NO = $"TKP{basvuruTarihi.Year}{bsvNo:D8}",
                    CIKIS_TARIHI = tapisCikti ? basvuruTarihi.AddHours(_random.Next(1, 8)) : null,
                    CIKIS_SEKLI = tapisCikti ? "CKS-TBR" : null,
                    AKTIF = !tapisCikti,
                    EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                    EKLEYEN_KULLANICI_KODU = "SYSTEM",
                    KAYIT_ZAMANI = basvuruTarihi
                });
                hzmNo++;

                // Tanı
                basvuruTanilar.Add(new BASVURU_TANI
                {
                    BASVURU_TANI_KODU = $"TNI-{tniNo:D5}",
                    HASTA_KODU = hasta.HASTA_KODU,
                    HASTA_BASVURU_KODU = basvuru.HASTA_BASVURU_KODU,
                    TANI_KODU = basvuru.TANI_KODU,
                    TANI_TURU = "ANA",
                    BIRINCIL_TANI = "E",
                    TANI_ZAMANI = basvuruTarihi,
                    EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                        EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                            EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                        EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                        TC_KIMLIK_NUMARASI = hasta.TC_KIMLIK_NO,
                        AD = hasta.AD,
                        SOYADI = hasta.SOYAD,
                        CINSIYET = hasta.CINSIYET,
                        EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                var yatisTarihi = sonBasvuru.BASVURU_TARIHI;

                // Yatış türüne güncelle
                sonBasvuru.BASVURU_TURU = "BSV-YTN";
                sonBasvuru.CIKIS_TARIHI = yatisTarihi.AddDays(_random.Next(2, 10));

                hastaYataklar.Add(new HASTA_YATAK
                {
                    HASTA_YATAK_KODU = $"HYT-{ytNo:D5}",
                    HASTA_KODU = hasta.HASTA_KODU,
                    HASTA_BASVURU_KODU = sonBasvuru.HASTA_BASVURU_KODU,
                    YATAK_KODU = yatak.YATAK_KODU,
                    YATIS_BASLAMA_ZAMANI = yatisTarihi,
                    YATIS_BITIS_ZAMANI = sonBasvuru.CIKIS_TARIHI,
                    EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                        EKLEYEN_KULLANICI_KODU = "SYSTEM",
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

        foreach (var basvuru in basvurular.Where(b => b.CIKIS_TARIHI != null).Take(50))
        {
            numuneler.Add(new TETKIK_NUMUNE
            {
                TETKIK_NUMUNE_KODU = $"NMN-{nmNo:D5}",
                HASTA_KODU = basvuru.HASTA_KODU,
                HASTA_BASVURU_KODU = basvuru.HASTA_BASVURU_KODU,
                NUMUNE_NUMARASI = $"NM{DateTime.Now.Year}{nmNo:D6}",
                NUMUNE_TURU = numuneTurleri[_random.Next(numuneTurleri.Length)],
                BIRIM_KODU = "BRM-LAB-BYO",
                NUMUNE_ALMA_ZAMANI = basvuru.BASVURU_TARIHI.AddMinutes(_random.Next(10, 60)),
                NUMUNE_KABUL_ZAMANI = basvuru.BASVURU_TARIHI.AddMinutes(_random.Next(60, 120)),
                BARKOD = $"BC{_random.Next(100000000, 999999999)}",
                BARKOD_ZAMANI = basvuru.BASVURU_TARIHI.AddMinutes(_random.Next(5, 30)),
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
                KAYIT_ZAMANI = basvuru.BASVURU_TARIHI
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
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
                KAYIT_ZAMANI = DateTime.Now
            });
        }
        await _db.Set<ICMAL>().AddRangeAsync(icmaller, ct);
        await _db.SaveChangesAsync(ct);

        // Fatura
        var faturalar = new List<FATURA>();
        int ftNo = 1;
        foreach (var basvuru in basvurular.Where(b => b.CIKIS_TARIHI != null).Take(80))
        {
            var ay = basvuru.BASVURU_TARIHI.Month;
            var icmal = icmaller.FirstOrDefault(i => i.ICMAL_DONEMI == $"{DateTime.Now.Year}/{ay:D2}");

            faturalar.Add(new FATURA
            {
                FATURA_KODU = $"FTR-{ftNo:D5}",
                HASTA_BASVURU_KODU = basvuru.HASTA_BASVURU_KODU,
                HASTA_KODU = basvuru.HASTA_KODU,
                FATURA_DONEMI = $"{basvuru.BASVURU_TARIHI.Year}/{basvuru.BASVURU_TARIHI.Month:D2}",
                ICMAL_KODU = icmal?.ICMAL_KODU,
                FATURA_TURU = "SGK",
                FATURA_ADI = $"Hasta Faturası - {basvuru.HASTA_BASVURU_KODU}",
                FATURA_ZAMANI = basvuru.CIKIS_TARIHI,
                FATURA_TUTARI = _random.Next(50, 5000),
                FATURA_NUMARASI = $"FT{basvuru.BASVURU_TARIHI.Year}{ftNo:D8}",
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
                KAYIT_ZAMANI = basvuru.CIKIS_TARIHI ?? DateTime.Now
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
            new() { CIHAZ_KODU = "CHZ-001", CIHAZ_ADI = "Biyokimya Analizörü", CIHAZ_GRUBU = "CHZ-LAB", BIRIM_KODU = "BRM-LAB-BYO", CIHAZ_MARKASI = "Roche", CIHAZ_MODELI = "Cobas 8000", SERI_NUMARASI = "RC8K001234", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { CIHAZ_KODU = "CHZ-002", CIHAZ_ADI = "Hematoloji Analizörü", CIHAZ_GRUBU = "CHZ-LAB", BIRIM_KODU = "BRM-LAB-HEM", CIHAZ_MARKASI = "Sysmex", CIHAZ_MODELI = "XN-1000", SERI_NUMARASI = "SX1K005678", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { CIHAZ_KODU = "CHZ-003", CIHAZ_ADI = "İdrar Analizörü", CIHAZ_GRUBU = "CHZ-LAB", BIRIM_KODU = "BRM-LAB-BYO", CIHAZ_MARKASI = "Siemens", CIHAZ_MODELI = "Clinitek Atlas", SERI_NUMARASI = "SCAT009876", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            // Radyoloji Cihazları
            new() { CIHAZ_KODU = "CHZ-004", CIHAZ_ADI = "Dijital Röntgen", CIHAZ_GRUBU = "CHZ-RAD", BIRIM_KODU = "BRM-RAD", CIHAZ_MARKASI = "Philips", CIHAZ_MODELI = "DigitalDiagnost C90", SERI_NUMARASI = "PHC90001122", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { CIHAZ_KODU = "CHZ-005", CIHAZ_ADI = "Ultrason", CIHAZ_GRUBU = "CHZ-RAD", BIRIM_KODU = "BRM-RAD", CIHAZ_MARKASI = "GE", CIHAZ_MODELI = "Voluson E10", SERI_NUMARASI = "GEV10003344", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { CIHAZ_KODU = "CHZ-006", CIHAZ_ADI = "MR Cihazı", CIHAZ_GRUBU = "CHZ-RAD", BIRIM_KODU = "BRM-RAD", CIHAZ_MARKASI = "Siemens", CIHAZ_MODELI = "Magnetom Vida", SERI_NUMARASI = "SMV3T005566", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { CIHAZ_KODU = "CHZ-007", CIHAZ_ADI = "BT Cihazı", CIHAZ_GRUBU = "CHZ-RAD", BIRIM_KODU = "BRM-RAD", CIHAZ_MARKASI = "GE", CIHAZ_MODELI = "Revolution CT", SERI_NUMARASI = "GERCT007788", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            // Ameliyathane Cihazları
            new() { CIHAZ_KODU = "CHZ-008", CIHAZ_ADI = "Ameliyat Masası 1", CIHAZ_GRUBU = "CHZ-AML", BIRIM_KODU = "BRM-AMH-1", CIHAZ_MARKASI = "Maquet", CIHAZ_MODELI = "Magnus", SERI_NUMARASI = "MQM001234", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { CIHAZ_KODU = "CHZ-009", CIHAZ_ADI = "Ameliyat Masası 2", CIHAZ_GRUBU = "CHZ-AML", BIRIM_KODU = "BRM-AMH-2", CIHAZ_MARKASI = "Maquet", CIHAZ_MODELI = "Magnus", SERI_NUMARASI = "MQM005678", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { CIHAZ_KODU = "CHZ-010", CIHAZ_ADI = "Anestezi Cihazı 1", CIHAZ_GRUBU = "CHZ-AML", BIRIM_KODU = "BRM-AMH-1", CIHAZ_MARKASI = "Dräger", CIHAZ_MODELI = "Perseus A500", SERI_NUMARASI = "DRA500001", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { CIHAZ_KODU = "CHZ-011", CIHAZ_ADI = "Anestezi Cihazı 2", CIHAZ_GRUBU = "CHZ-AML", BIRIM_KODU = "BRM-AMH-2", CIHAZ_MARKASI = "Dräger", CIHAZ_MODELI = "Perseus A500", SERI_NUMARASI = "DRA500002", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            // Yoğun Bakım Cihazları
            new() { CIHAZ_KODU = "CHZ-012", CIHAZ_ADI = "Ventilatör 1", CIHAZ_GRUBU = "CHZ-YB", BIRIM_KODU = "BRM-YB-GNL", CIHAZ_MARKASI = "Hamilton", CIHAZ_MODELI = "C6", SERI_NUMARASI = "HMC6001", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { CIHAZ_KODU = "CHZ-013", CIHAZ_ADI = "Ventilatör 2", CIHAZ_GRUBU = "CHZ-YB", BIRIM_KODU = "BRM-YB-GNL", CIHAZ_MARKASI = "Hamilton", CIHAZ_MODELI = "C6", SERI_NUMARASI = "HMC6002", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { CIHAZ_KODU = "CHZ-014", CIHAZ_ADI = "Hasta Monitörü 1", CIHAZ_GRUBU = "CHZ-MON", BIRIM_KODU = "BRM-YB-GNL", CIHAZ_MARKASI = "Philips", CIHAZ_MODELI = "IntelliVue MX800", SERI_NUMARASI = "PHMX001", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { CIHAZ_KODU = "CHZ-015", CIHAZ_ADI = "Hasta Monitörü 2", CIHAZ_GRUBU = "CHZ-MON", BIRIM_KODU = "BRM-YB-KRD", CIHAZ_MARKASI = "Philips", CIHAZ_MODELI = "IntelliVue MX800", SERI_NUMARASI = "PHMX002", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            // EKG Cihazı
            new() { CIHAZ_KODU = "CHZ-016", CIHAZ_ADI = "EKG Cihazı", CIHAZ_GRUBU = "CHZ-MON", BIRIM_KODU = "BRM-KRD", CIHAZ_MARKASI = "GE", CIHAZ_MODELI = "MAC 2000", SERI_NUMARASI = "GEMAC001", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
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
            new() { DEPO_KODU = "DPO-001", DEPO_ADI = "Ana Depo", DEPO_TURU = "DPO-ANA", BINA_KODU = "BNA-001", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { DEPO_KODU = "DPO-002", DEPO_ADI = "Merkez Eczane Deposu", DEPO_TURU = "DPO-ECZ", BINA_KODU = "BNA-001", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { DEPO_KODU = "DPO-003", DEPO_ADI = "Ameliyathane Deposu", DEPO_TURU = "DPO-BRM", BINA_KODU = "BNA-002", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { DEPO_KODU = "DPO-004", DEPO_ADI = "Yoğun Bakım Deposu", DEPO_TURU = "DPO-BRM", BINA_KODU = "BNA-003", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { DEPO_KODU = "DPO-005", DEPO_ADI = "Laboratuvar Deposu", DEPO_TURU = "DPO-BRM", BINA_KODU = "BNA-001", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
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
            new() { STOK_KART_KODU = "STK-001", MALZEME_ADI = "Parol 500mg Tablet", MALZEME_TIPI = "MLZ-ILC", BARKOD = "8699536090108", RECETE_TURU = "RCT-NRM", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { STOK_KART_KODU = "STK-002", MALZEME_ADI = "Aspirin 100mg Tablet", MALZEME_TIPI = "MLZ-ILC", BARKOD = "8699546790203", RECETE_TURU = "RCT-NRM", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { STOK_KART_KODU = "STK-003", MALZEME_ADI = "Augmentin 1000mg Tablet", MALZEME_TIPI = "MLZ-ILC", BARKOD = "8699522093588", RECETE_TURU = "RCT-NRM", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { STOK_KART_KODU = "STK-004", MALZEME_ADI = "Voltaren 75mg Ampul", MALZEME_TIPI = "MLZ-ILC", BARKOD = "8699504090185", RECETE_TURU = "RCT-NRM", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { STOK_KART_KODU = "STK-005", MALZEME_ADI = "Xanax 0.5mg Tablet", MALZEME_TIPI = "MLZ-ILC", BARKOD = "8699532095201", RECETE_TURU = "RCT-KRM", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { STOK_KART_KODU = "STK-006", MALZEME_ADI = "Tramal 50mg Kapsül", MALZEME_TIPI = "MLZ-ILC", BARKOD = "8699504091762", RECETE_TURU = "RCT-YSL", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { STOK_KART_KODU = "STK-007", MALZEME_ADI = "Coumadin 5mg Tablet", MALZEME_TIPI = "MLZ-ILC", BARKOD = "8699504090611", RECETE_TURU = "RCT-NRM", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { STOK_KART_KODU = "STK-008", MALZEME_ADI = "Lantus 100IU/ml Kalem", MALZEME_TIPI = "MLZ-ILC", BARKOD = "8699809090224", RECETE_TURU = "RCT-NRM", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            // Tıbbi Malzemeler
            new() { STOK_KART_KODU = "STK-009", MALZEME_ADI = "Enjektör 5ml", MALZEME_TIPI = "MLZ-TBM", BARKOD = "8690123456789", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { STOK_KART_KODU = "STK-010", MALZEME_ADI = "IV Kanül 20G", MALZEME_TIPI = "MLZ-TBM", BARKOD = "8690234567890", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { STOK_KART_KODU = "STK-011", MALZEME_ADI = "Serum Seti", MALZEME_TIPI = "MLZ-TBM", BARKOD = "8690345678901", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { STOK_KART_KODU = "STK-012", MALZEME_ADI = "Sonda Foley 16F", MALZEME_TIPI = "MLZ-TBM", BARKOD = "8690456789012", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            // Sarf Malzemeler
            new() { STOK_KART_KODU = "STK-013", MALZEME_ADI = "Eldiven (M) 100'lü", MALZEME_TIPI = "MLZ-SRF", BARKOD = "8690567890123", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { STOK_KART_KODU = "STK-014", MALZEME_ADI = "Gazlı Bez 10x10", MALZEME_TIPI = "MLZ-SRF", BARKOD = "8690678901234", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { STOK_KART_KODU = "STK-015", MALZEME_ADI = "Flaster 5mx2.5cm", MALZEME_TIPI = "MLZ-SRF", BARKOD = "8690789012345", AKTIF = true, EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
        };

        await _db.Set<STOK_KART>().AddRangeAsync(stokKartlar, ct);
        await _db.SaveChangesAsync(ct);
    }

    #endregion

    #region Kullanici ve Tetkik Parametre

    private async Task SeedKullanicilarAsync(CancellationToken ct)
    {
        if (await _db.Set<KULLANICI>().AnyAsync(ct)) return;
        _logger.LogInformation("Seeding KULLANICI...");

        var personeller = await _db.Set<PERSONEL>().ToListAsync(ct);
        var kullanicilar = new List<KULLANICI>();

        int kNo = 1;
        foreach (var personel in personeller)
        {
            kullanicilar.Add(new KULLANICI
            {
                KULLANICI_KODU = $"KLN-{kNo:D3}",
                PERSONEL_KODU = personel.PERSONEL_KODU,
                KULLANICI_ADI = $"{personel.AD.ToLower()}.{personel.SOYAD.ToLower()}",
                AKTIF = true,
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                        AKTIF = true,
                        EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
            new() { FIRMA_KODU = "FRM-001", REFERANS_TABLO_ADI = "FIRMA", FIRMA_ADI = "Medikal Sağlık A.Ş.", VERGI_NUMARASI = "1234567890", VERGI_DAIRESI = "Kadıköy", TELEFON_NUMARASI = "02124445566", FIRMA_ADRESI = "İstanbul", YETKILI_KISI = "Ali Yılmaz", AKTIFLIK_BILGISI = "AKTIF", EPOSTA_ADRESI = "info@medikal.com", IBAN_NUMARASI = "TR123456789012345678901234", EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { FIRMA_KODU = "FRM-002", REFERANS_TABLO_ADI = "FIRMA", FIRMA_ADI = "İlaç Dağıtım Ltd.", VERGI_NUMARASI = "2345678901", VERGI_DAIRESI = "Çankaya", TELEFON_NUMARASI = "02163334455", FIRMA_ADRESI = "Ankara", YETKILI_KISI = "Mehmet Kaya", AKTIFLIK_BILGISI = "AKTIF", EPOSTA_ADRESI = "info@ilacdagitim.com", IBAN_NUMARASI = "TR234567890123456789012345", EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { FIRMA_KODU = "FRM-003", REFERANS_TABLO_ADI = "FIRMA", FIRMA_ADI = "Laboratuvar Malzeme A.Ş.", VERGI_NUMARASI = "3456789012", VERGI_DAIRESI = "Konak", TELEFON_NUMARASI = "02327778899", FIRMA_ADRESI = "İzmir", YETKILI_KISI = "Ahmet Demir", AKTIFLIK_BILGISI = "AKTIF", EPOSTA_ADRESI = "info@labmalzeme.com", IBAN_NUMARASI = "TR345678901234567890123456", EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { FIRMA_KODU = "FRM-004", REFERANS_TABLO_ADI = "FIRMA", FIRMA_ADI = "Cerrahi Aletler Ltd.", VERGI_NUMARASI = "4567890123", VERGI_DAIRESI = "Keçiören", TELEFON_NUMARASI = "03125556677", FIRMA_ADRESI = "Ankara", YETKILI_KISI = "Hasan Şahin", AKTIFLIK_BILGISI = "AKTIF", EPOSTA_ADRESI = "info@cerrahialetler.com", IBAN_NUMARASI = "TR456789012345678901234567", EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
            new() { FIRMA_KODU = "FRM-005", REFERANS_TABLO_ADI = "FIRMA", FIRMA_ADI = "Radyoloji Sistemleri A.Ş.", VERGI_NUMARASI = "5678901234", VERGI_DAIRESI = "Beşiktaş", TELEFON_NUMARASI = "02169998877", FIRMA_ADRESI = "İstanbul", YETKILI_KISI = "Hüseyin Çelik", AKTIFLIK_BILGISI = "AKTIF", EPOSTA_ADRESI = "info@radyoloji.com", IBAN_NUMARASI = "TR567890123456789012345678", EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
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
                    REFERANS_TABLO_ADI = "RECETE_ILAC",
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
                    EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "AMELIYAT_ISLEM",
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
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
        var personeller = await _db.Set<PERSONEL>().Where(p => p.UNVAN == "Uzm. Dr." || p.UNVAN == "Prof. Dr." || p.UNVAN == "Doç. Dr." || p.UNVAN == "Hemşire").ToListAsync(ct);

        if (!personeller.Any())
        {
            _logger.LogWarning("Skipping AMELIYAT_EKIP seeding - no PERSONEL records found");
            return;
        }

        var ekipler = new List<AMELIYAT_EKIP>();
        int ekipNo = 1;

        foreach (var ai in ameliyatIslemler)
        {
            var doktorlar = personeller.Where(p => p.UNVAN != "Hemşire").Take(2).ToList();
            var hemsireler = personeller.Where(p => p.UNVAN == "Hemşire").Take(2).ToList();

            foreach (var d in doktorlar)
            {
                ekipler.Add(new AMELIYAT_EKIP
                {
                    AMELIYAT_EKIP_KODU = $"AEK-{ekipNo++:D5}",
                    REFERANS_TABLO_ADI = "AMELIYAT_EKIP",
                    AMELIYAT_KODU = ai.AMELIYAT_KODU,
                    AMELIYAT_ISLEM_KODU = ai.AMELIYAT_ISLEM_KODU,
                    PERSONEL_KODU = d.PERSONEL_KODU,
                    EKIP_NUMARASI = ekipNo.ToString(),
                    AMELIYAT_PERSONEL_GOREV = "CERRAH",
                    EKLEYEN_KULLANICI_KODU = "SYSTEM",
                    KAYIT_ZAMANI = DateTime.Now
                });
            }

            foreach (var h in hemsireler)
            {
                ekipler.Add(new AMELIYAT_EKIP
                {
                    AMELIYAT_EKIP_KODU = $"AEK-{ekipNo++:D5}",
                    REFERANS_TABLO_ADI = "AMELIYAT_EKIP",
                    AMELIYAT_KODU = ai.AMELIYAT_KODU,
                    AMELIYAT_ISLEM_KODU = ai.AMELIYAT_ISLEM_KODU,
                    PERSONEL_KODU = h.PERSONEL_KODU,
                    EKIP_NUMARASI = ekipNo.ToString(),
                    AMELIYAT_PERSONEL_GOREV = "HEMSIRE",
                    EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                KAN_URUN_KODU = "KU-001", REFERANS_TABLO_ADI = "KAN_URUN", KAN_URUN_ADI = "Tam Kan",
                HIZMET_KODU = hizmetler[0].HIZMET_KODU,
                KAN_MIAT_PERIYODU = "GUN", KAN_MIAT_SURESI = "35", KIZILAY_BILESEN_TURU = "TAM_KAN",
                KAN_FILTRELEME_UYGUNLUK = "UYGUN", KAN_YIKAMA_UYGUNLUK_DURUMU = "UYGUN",
                KAN_ISINLAMA_UYGUNLUK_DURUMU = "UYGUN", KAN_HAVUZLAMA_UYGUNLUK = "UYGUN_DEGIL",
                KAN_AYIRMA_UYGUNLUK = "UYGUN", KAN_BOLME_UYGUNLUK = "UYGUN",
                BUFFYCOAT_UZAKLASTIRMAYA_UYGUN = "UYGUN",
                EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now
            },
            new() {
                KAN_URUN_KODU = "KU-002", REFERANS_TABLO_ADI = "KAN_URUN", KAN_URUN_ADI = "Eritrosit Süspansiyonu",
                HIZMET_KODU = hizmetler[1].HIZMET_KODU,
                KAN_MIAT_PERIYODU = "GUN", KAN_MIAT_SURESI = "42", KIZILAY_BILESEN_TURU = "ERITROSIT",
                KAN_FILTRELEME_UYGUNLUK = "UYGUN", KAN_YIKAMA_UYGUNLUK_DURUMU = "UYGUN",
                KAN_ISINLAMA_UYGUNLUK_DURUMU = "UYGUN", KAN_HAVUZLAMA_UYGUNLUK = "UYGUN_DEGIL",
                KAN_AYIRMA_UYGUNLUK = "UYGUN_DEGIL", KAN_BOLME_UYGUNLUK = "UYGUN",
                BUFFYCOAT_UZAKLASTIRMAYA_UYGUN = "UYGUN_DEGIL",
                EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now
            },
            new() {
                KAN_URUN_KODU = "KU-003", REFERANS_TABLO_ADI = "KAN_URUN", KAN_URUN_ADI = "Trombosit Konsantresi",
                HIZMET_KODU = hizmetler[2].HIZMET_KODU,
                KAN_MIAT_PERIYODU = "GUN", KAN_MIAT_SURESI = "5", KIZILAY_BILESEN_TURU = "TROMBOSIT",
                KAN_FILTRELEME_UYGUNLUK = "UYGUN", KAN_YIKAMA_UYGUNLUK_DURUMU = "UYGUN_DEGIL",
                KAN_ISINLAMA_UYGUNLUK_DURUMU = "UYGUN", KAN_HAVUZLAMA_UYGUNLUK = "UYGUN",
                KAN_AYIRMA_UYGUNLUK = "UYGUN_DEGIL", KAN_BOLME_UYGUNLUK = "UYGUN_DEGIL",
                BUFFYCOAT_UZAKLASTIRMAYA_UYGUN = "UYGUN_DEGIL",
                EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now
            },
            new() {
                KAN_URUN_KODU = "KU-004", REFERANS_TABLO_ADI = "KAN_URUN", KAN_URUN_ADI = "Taze Donmuş Plazma",
                HIZMET_KODU = hizmetler[3].HIZMET_KODU,
                KAN_MIAT_PERIYODU = "YIL", KAN_MIAT_SURESI = "1", KIZILAY_BILESEN_TURU = "TDP",
                KAN_FILTRELEME_UYGUNLUK = "UYGUN_DEGIL", KAN_YIKAMA_UYGUNLUK_DURUMU = "UYGUN_DEGIL",
                KAN_ISINLAMA_UYGUNLUK_DURUMU = "UYGUN_DEGIL", KAN_HAVUZLAMA_UYGUNLUK = "UYGUN_DEGIL",
                KAN_AYIRMA_UYGUNLUK = "UYGUN_DEGIL", KAN_BOLME_UYGUNLUK = "UYGUN",
                BUFFYCOAT_UZAKLASTIRMAYA_UYGUN = "UYGUN_DEGIL",
                EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now
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
                REFERANS_TABLO_ADI = "KURUL",
                KURUL_ADI = "Sağlık Kurulu",
                RAPOR_TURU = "HEYET",
                MEDULA_RAPOR_TURU = "MRT_1",
                MEDULA_ALT_RAPOR_TURU = "MART_1",
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
                KAYIT_ZAMANI = DateTime.Now
            },
            new() {
                KURUL_KODU = "KRL-002",
                REFERANS_TABLO_ADI = "KURUL",
                KURUL_ADI = "Engelli Sağlık Kurulu",
                RAPOR_TURU = "HEYET",
                MEDULA_RAPOR_TURU = "MRT_3",
                MEDULA_ALT_RAPOR_TURU = "MART_2",
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
                KAYIT_ZAMANI = DateTime.Now
            },
            new() {
                KURUL_KODU = "KRL-003",
                REFERANS_TABLO_ADI = "KURUL",
                KURUL_ADI = "Askerlik Muayene Kurulu",
                RAPOR_TURU = "HEYET",
                MEDULA_RAPOR_TURU = "MRT_4",
                MEDULA_ALT_RAPOR_TURU = "MART_1",
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
                KAYIT_ZAMANI = DateTime.Now
            },
            new() {
                KURUL_KODU = "KRL-004",
                REFERANS_TABLO_ADI = "KURUL",
                KURUL_ADI = "İş Sağlığı Kurulu",
                RAPOR_TURU = "ISCI_SAGLIGI",
                MEDULA_RAPOR_TURU = "MRT_2",
                MEDULA_ALT_RAPOR_TURU = "MART_1",
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
                KAYIT_ZAMANI = DateTime.Now
            },
            new() {
                KURUL_KODU = "KRL-005",
                REFERANS_TABLO_ADI = "KURUL",
                KURUL_ADI = "Tek Hekim Kurulu",
                RAPOR_TURU = "TEK_HEKIM",
                MEDULA_RAPOR_TURU = "MRT_1",
                MEDULA_ALT_RAPOR_TURU = "MART_3",
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
        var personeller = await _db.Set<PERSONEL>().Where(p => p.UNVAN == "Uzm. Dr." || p.UNVAN == "Prof. Dr." || p.UNVAN == "Doç. Dr.").ToListAsync(ct);
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
                REFERANS_TABLO_ADI = "STOK_ISTEK",
                HASTA_BASVURU_KODU = bsv.HASTA_BASVURU_KODU,
                HASTA_KODU = bsv.HASTA_KODU,
                ISTEK_ZAMANI = bsv.BASVURU_TARIHI.AddMinutes(_random.Next(30, 180)),
                ISTEK_DEPO_KODU = depo.DEPO_KODU,
                HEKIM_KODU = hekim.PERSONEL_KODU,
                STOK_ISTEK_DURUMU = _random.Next(3) switch { 0 => "BEKLEMEDE", 1 => "ONAYLANDI", _ => "TAMAMLANDI" },
                STOK_ISTEK_HEKIM_ACIKLAMA = "Hasta tedavisi için gerekli malzeme",
                AMELIYAT_KODU = ameliyat.AMELIYAT_KODU,
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                    REFERANS_TABLO_ADI = "EK_ODEME_DONEM",
                    YIL = DateTime.Now.Year.ToString(),
                    AY = ay.ToString(),
                    BORDRO_NUMARASI = $"BRD{DateTime.Now.Year}{ay:D4}",
                    GIRISIMSEL_ISLEM_PUAN_TOPLAMI = _random.Next(10000, 50000).ToString(),
                    OZELLIKLI_ISLEM_PUAN_TOPLAMI = _random.Next(5000, 25000).ToString(),
                    ACGK_TOPLAMI = _random.Next(1000, 5000).ToString(),
                    DAGITILACAK_EKODEME_TUTARI = _random.Next(100000, 500000).ToString(),
                    EK_ODEME_KATSAYISI = (1.0 + _random.NextDouble()).ToString("F4"),
                    HASTANE_PUAN_ORTALAMASI = _random.Next(50, 100).ToString(),
                    EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                new() { KULLANICI_GRUP_KODU = "KG-001", REFERANS_TABLO_ADI = "KULLANICI_GRUP", KULLANICI_GRUP_ADI = "Sistem Yöneticisi", AKTIFLIK_BILGISI = "AKTIF", EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
                new() { KULLANICI_GRUP_KODU = "KG-002", REFERANS_TABLO_ADI = "KULLANICI_GRUP", KULLANICI_GRUP_ADI = "Doktor", AKTIFLIK_BILGISI = "AKTIF", EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
                new() { KULLANICI_GRUP_KODU = "KG-003", REFERANS_TABLO_ADI = "KULLANICI_GRUP", KULLANICI_GRUP_ADI = "Hemşire", AKTIFLIK_BILGISI = "AKTIF", EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
                new() { KULLANICI_GRUP_KODU = "KG-004", REFERANS_TABLO_ADI = "KULLANICI_GRUP", KULLANICI_GRUP_ADI = "Laboratuvar Teknisyeni", AKTIFLIK_BILGISI = "AKTIF", EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
                new() { KULLANICI_GRUP_KODU = "KG-005", REFERANS_TABLO_ADI = "KULLANICI_GRUP", KULLANICI_GRUP_ADI = "Radyoloji Teknisyeni", AKTIFLIK_BILGISI = "AKTIF", EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
                new() { KULLANICI_GRUP_KODU = "KG-006", REFERANS_TABLO_ADI = "KULLANICI_GRUP", KULLANICI_GRUP_ADI = "Eczacı", AKTIFLIK_BILGISI = "AKTIF", EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
                new() { KULLANICI_GRUP_KODU = "KG-007", REFERANS_TABLO_ADI = "KULLANICI_GRUP", KULLANICI_GRUP_ADI = "Hasta Kabul", AKTIFLIK_BILGISI = "AKTIF", EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
                new() { KULLANICI_GRUP_KODU = "KG-008", REFERANS_TABLO_ADI = "KULLANICI_GRUP", KULLANICI_GRUP_ADI = "Faturalama", AKTIFLIK_BILGISI = "AKTIF", EKLEYEN_KULLANICI_KODU = "SYSTEM", KAYIT_ZAMANI = DateTime.Now },
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
                    REFERANS_TABLO_ADI = "GRUP_UYELIK",
                    KULLANICI_GRUP_KODU = grupKodu,
                    KULLANICI_KODU = k.KULLANICI_KODU,
                    EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                        REFERANS_TABLO_ADI = "STOK_FIS",
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
                        EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
            var items = hastalar.Take(25).Select((h, i) => new HASTA_ILETISIM
            {
                HASTA_ILETISIM_KODU = $"HI-{i + 1:D5}",
                REFERANS_TABLO_ADI = "HASTA_ILETISIM",
                HASTA_KODU = h.HASTA_KODU,
                ILETISIM_TURU = i % 3 == 0 ? "TELEFON" : i % 3 == 1 ? "EMAIL" : "ADRES",
                ILETISIM_DEGERI = i % 3 == 0 ? $"053{_random.Next(10000000, 99999999)}" : i % 3 == 1 ? $"hasta{i}@email.com" : $"Adres {i + 1}",
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "HASTA_NOTLARI",
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_KODU = b.HASTA_KODU,
                NOT_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                NOT_ICERIGI = $"Hasta notu {i + 1}: Tedavi süreci normal devam etmektedir.",
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "HASTA_UYARI",
                HASTA_KODU = h.HASTA_KODU,
                UYARI_TIPI = uyariTipleri[i % uyariTipleri.Length],
                UYARI_ACIKLAMASI = $"Uyarı: {uyariTipleri[i % uyariTipleri.Length]} - Dikkat edilmeli",
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "HASTA_TIBBI_BILGI",
                HASTA_KODU = h.HASTA_KODU,
                KAN_GRUBU = new[] { "A+", "A-", "B+", "B-", "AB+", "AB-", "0+", "0-" }[i % 8],
                BOY = 160 + _random.Next(0, 30),
                KILO = 60 + _random.Next(0, 40),
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<HASTA_TIBBI_BILGI>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} HASTA_TIBBI_BILGI records");
        }

        // HASTA_EPIKRIZ
        if (!await _db.Set<HASTA_EPIKRIZ>().AnyAsync(ct))
        {
            var items = basvurular.Where(b => b.CIKIS_TARIHI != null).Take(25).Select((b, i) => new HASTA_EPIKRIZ
            {
                HASTA_EPIKRIZ_KODU = $"HE-{i + 1:D5}",
                REFERANS_TABLO_ADI = "HASTA_EPIKRIZ",
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_KODU = b.HASTA_KODU,
                EPIKRIZ_TARIHI = b.CIKIS_TARIHI ?? DateTime.Now,
                EPIKRIZ_METNI = $"Epikriz {i + 1}: Hasta tedavisi tamamlanmış olup taburcu edilmiştir.",
                HAZIRLAYAN_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            if (items.Count < 20)
            {
                var eksik = basvurular.Take(25 - items.Count).Select((b, i) => new HASTA_EPIKRIZ
                {
                    HASTA_EPIKRIZ_KODU = $"HE-{items.Count + i + 1:D5}",
                    REFERANS_TABLO_ADI = "HASTA_EPIKRIZ",
                    HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                    HASTA_KODU = b.HASTA_KODU,
                    EPIKRIZ_TARIHI = DateTime.Now,
                    EPIKRIZ_METNI = $"Epikriz: Hasta takibi devam etmektedir.",
                    HAZIRLAYAN_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                    EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "HASTA_VITAL_FIZIKI_BULGU",
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_KODU = b.HASTA_KODU,
                OLCUM_ZAMANI = b.BASVURU_TARIHI.AddMinutes(_random.Next(10, 60)),
                SISTOLIK_TANSIYON = 110 + _random.Next(0, 40),
                DIASTOLIK_TANSIYON = 70 + _random.Next(0, 20),
                NABIZ = 60 + _random.Next(0, 40),
                ATES = 36.0 + _random.NextDouble() * 2,
                SOLUNUM_SAYISI = 14 + _random.Next(0, 6),
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "HASTA_SEVK",
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_KODU = b.HASTA_KODU,
                SEVK_TARIHI = b.BASVURU_TARIHI.AddDays(_random.Next(1, 5)),
                SEVK_NEDENI = "İleri tetkik ve tedavi için sevk edilmiştir.",
                SEVK_EDEN_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "HASTA_GIZLILIK",
                HASTA_KODU = h.HASTA_KODU,
                GIZLILIK_SEVIYESI = i % 3 == 0 ? "YUKSEK" : i % 3 == 1 ? "ORTA" : "NORMAL",
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "KONSULTASYON",
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_KODU = b.HASTA_KODU,
                ISTEK_TARIHI = b.BASVURU_TARIHI.AddHours(_random.Next(1, 24)),
                ISTEYEN_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                KONSULTAN_HEKIM_KODU = personeller[(i + 1) % personeller.Count].PERSONEL_KODU,
                KONSULTASYON_DURUMU = i % 2 == 0 ? "TAMAMLANDI" : "BEKLIYOR",
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<KONSULTASYON>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} KONSULTASYON records");
        }

        // HEMSIRE_BAKIM
        if (!await _db.Set<HEMSIRE_BAKIM>().AnyAsync(ct))
        {
            var hemsireler = personeller.Where(p => p.UNVAN == "Hemşire").ToList();
            if (hemsireler.Any())
            {
                var items = basvurular.Take(25).Select((b, i) => new HEMSIRE_BAKIM
                {
                    HEMSIRE_BAKIM_KODU = $"HB-{i + 1:D5}",
                    REFERANS_TABLO_ADI = "HEMSIRE_BAKIM",
                    HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                    HASTA_KODU = b.HASTA_KODU,
                    BAKIM_TARIHI = b.BASVURU_TARIHI.AddHours(_random.Next(1, 48)),
                    HEMSIRE_KODU = hemsireler[i % hemsireler.Count].PERSONEL_KODU,
                    BAKIM_NOTU = $"Bakım notu {i + 1}: Hasta takibi yapıldı, vital bulgular normal.",
                    EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "KLINIK_SEYIR",
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_KODU = b.HASTA_KODU,
                SEYIR_TARIHI = b.BASVURU_TARIHI.AddHours(_random.Next(6, 72)),
                SEYIR_NOTU = $"Klinik seyir {i + 1}: Hasta durumu stabil, tedaviye yanıt olumlu.",
                YAZAN_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "TIBBI_ORDER",
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_KODU = b.HASTA_KODU,
                ORDER_TARIHI = b.BASVURU_TARIHI.AddMinutes(_random.Next(30, 180)),
                ORDER_TURU = i % 3 == 0 ? "ILAC" : i % 3 == 1 ? "TETKIK" : "TEDAVI",
                ORDER_DURUMU = i % 2 == 0 ? "TAMAMLANDI" : "BEKLIYOR",
                YAZAN_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                    REFERANS_TABLO_ADI = "TIBBI_ORDER_DETAY",
                    TIBBI_ORDER_KODU = o.TIBBI_ORDER_KODU,
                    DETAY_ACIKLAMASI = $"Order detay {i + 1}: İşlem detayları",
                    MIKTAR = _random.Next(1, 10),
                    BIRIM = "ADET",
                    EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "DOKTOR_MESAJI",
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_KODU = b.HASTA_KODU,
                MESAJ_TARIHI = b.BASVURU_TARIHI.AddHours(_random.Next(1, 24)),
                MESAJ_ICERIGI = $"Doktor mesajı {i + 1}: Hasta ile ilgili önemli not.",
                GONDEREN_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                    REFERANS_TABLO_ADI = "HASTA_MALZEME",
                    HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                    HASTA_KODU = b.HASTA_KODU,
                    STOK_KART_KODU = stokKartlar[i % stokKartlar.Count].STOK_KART_KODU,
                    MIKTAR = _random.Next(1, 5),
                    KULLANIM_TARIHI = b.BASVURU_TARIHI.AddHours(_random.Next(1, 48)),
                    EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "HASTA_SEANS",
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_KODU = b.HASTA_KODU,
                SEANS_NO = i + 1,
                SEANS_TARIHI = b.BASVURU_TARIHI.AddDays(i),
                SEANS_DURUMU = i % 2 == 0 ? "TAMAMLANDI" : "PLANLANDI",
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "PERSONEL_IZIN",
                PERSONEL_KODU = p.PERSONEL_KODU,
                IZIN_TURU = i % 3 == 0 ? "YILLIK" : i % 3 == 1 ? "MAZERET" : "HASTALIK",
                BASLANGIC_TARIHI = DateTime.Now.AddDays(-_random.Next(30, 180)),
                BITIS_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 29)),
                IZIN_GUN_SAYISI = _random.Next(1, 14),
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "PERSONEL_EGITIM",
                PERSONEL_KODU = p.PERSONEL_KODU,
                EGITIM_ADI = $"Hizmet İçi Eğitim {i + 1}",
                EGITIM_TARIHI = DateTime.Now.AddDays(-_random.Next(30, 365)),
                EGITIM_SURESI_SAAT = _random.Next(2, 40),
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "PERSONEL_GOREVLENDIRME",
                PERSONEL_KODU = p.PERSONEL_KODU,
                BIRIM_KODU = birimler[i % birimler.Count].BIRIM_KODU,
                GOREV_BASLANGIC_TARIHI = DateTime.Now.AddDays(-_random.Next(30, 365)),
                GOREV_TURU = i % 2 == 0 ? "ASIL" : "GECICI",
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "NOBETCI_PERSONEL_BILGISI",
                PERSONEL_KODU = p.PERSONEL_KODU,
                BIRIM_KODU = birimler[i % birimler.Count].BIRIM_KODU,
                NOBET_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                NOBET_TURU = i % 2 == 0 ? "GUNDUZ" : "GECE",
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "GEBE_IZLEM",
                HASTA_KODU = h.HASTA_KODU,
                IZLEM_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 180)),
                GEBELIK_HAFTASI = _random.Next(4, 40),
                HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "DIYABET",
                HASTA_KODU = h.HASTA_KODU,
                TANI_TARIHI = DateTime.Now.AddYears(-_random.Next(1, 10)),
                DIYABET_TIPI = i % 2 == 0 ? "TIP1" : "TIP2",
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "ASI_BILGISI",
                HASTA_KODU = h.HASTA_KODU,
                ASI_ADI = asilar[i % asilar.Length],
                ASI_TARIHI = DateTime.Now.AddDays(-_random.Next(30, 365)),
                DOZ_NO = _random.Next(1, 4),
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "RADYOLOJI",
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_KODU = b.HASTA_KODU,
                ISTEK_TARIHI = b.BASVURU_TARIHI.AddHours(_random.Next(1, 24)),
                ISTEYEN_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                TETKIK_TURU = i % 4 == 0 ? "RONTGEN" : i % 4 == 1 ? "USG" : i % 4 == 2 ? "BT" : "MR",
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                    REFERANS_TABLO_ADI = "RADYOLOJI_SONUC",
                    RADYOLOJI_KODU = r.RADYOLOJI_KODU,
                    SONUC_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                    SONUC_RAPORU = $"Radyoloji sonuç raporu {i + 1}: Normal bulgular.",
                    RAPORLAYAN_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                    EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "PATOLOJI",
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_KODU = b.HASTA_KODU,
                NUMUNE_ALMA_TARIHI = b.BASVURU_TARIHI.AddHours(_random.Next(1, 48)),
                NUMUNE_TURU = i % 3 == 0 ? "BIYOPSI" : i % 3 == 1 ? "SITOLOJI" : "FROZEN",
                RAPOR_TARIHI = b.BASVURU_TARIHI.AddDays(_random.Next(3, 14)),
                RAPOR_SONUCU = "Patolojik inceleme sonucu normal.",
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "KAN_BAGISCI",
                TC_KIMLIK_NO = GenerateTcKimlik(),
                AD = $"Bağışçı{i}",
                SOYAD = $"Soyadı{i}",
                KAN_GRUBU = new[] { "A+", "A-", "B+", "B-", "AB+", "AB-", "0+", "0-" }[i % 8],
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                    REFERANS_TABLO_ADI = "KAN_STOK",
                    KAN_URUN_KODU = kanUrunler[i % kanUrunler.Count].KAN_URUN_KODU,
                    DEPO_KODU = depolar[i % depolar.Count].DEPO_KODU,
                    UNITE_NO = $"U{i:D6}",
                    KAN_GRUBU = new[] { "A+", "A-", "B+", "B-", "AB+", "AB-", "0+", "0-" }[i % 8],
                    MIKTAR = _random.Next(1, 10),
                    SON_KULLANMA_TARIHI = DateTime.Now.AddDays(_random.Next(7, 42)),
                    EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "KAN_TALEP",
                HASTA_KODU = h.HASTA_KODU,
                TALEP_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                TALEP_EDEN_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                KAN_GRUBU = new[] { "A+", "A-", "B+", "B-", "AB+", "AB-", "0+", "0-" }[i % 8],
                TALEP_DURUMU = i % 2 == 0 ? "KARSILANDI" : "BEKLIYOR",
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "KURUL_RAPOR",
                KURUL_KODU = kurullar[i % kurullar.Count].KURUL_KODU,
                HASTA_KODU = h.HASTA_KODU,
                RAPOR_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 90)),
                RAPOR_NO = $"RPR{DateTime.Now.Year}{i + 1:D4}",
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
                KAYIT_ZAMANI = DateTime.Now
            }).ToList();
            await _db.Set<KURUL_RAPOR>().AddRangeAsync(items, ct);
            await _db.SaveChangesAsync(ct);
            _logger.LogInformation($"Seeded: {items.Count} KURUL_RAPOR records");
        }

        // KURUL_HEKIM
        if (!await _db.Set<KURUL_HEKIM>().AnyAsync(ct))
        {
            var items = kurullar.SelectMany((k, ki) => personeller.Where(p => p.UNVAN != "Hemşire").Take(5).Select((p, pi) => new KURUL_HEKIM
            {
                KURUL_HEKIM_KODU = $"KH-{ki * 5 + pi + 1:D5}",
                REFERANS_TABLO_ADI = "KURUL_HEKIM",
                KURUL_KODU = k.KURUL_KODU,
                HEKIM_KODU = p.PERSONEL_KODU,
                GOREV = pi == 0 ? "BASKAN" : "UYE",
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                    REFERANS_TABLO_ADI = "STOK_DURUM",
                    STOK_KART_KODU = sk.STOK_KART_KODU,
                    DEPO_KODU = depolar[i % depolar.Count].DEPO_KODU,
                    MIKTAR = _random.Next(10, 500),
                    BIRIM_FIYAT = _random.Next(10, 1000),
                    EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                    REFERANS_TABLO_ADI = "STOK_HAREKET",
                    STOK_KART_KODU = stokKartlar[i % stokKartlar.Count].STOK_KART_KODU,
                    DEPO_KODU = depolar[i % depolar.Count].DEPO_KODU,
                    HAREKET_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 90)),
                    HAREKET_TURU = i % 2 == 0 ? "GIRIS" : "CIKIS",
                    MIKTAR = _random.Next(1, 50),
                    EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "STERILIZASYON_SET",
                SET_ADI = $"Sterilizasyon Seti {i}",
                SET_TURU = i % 3 == 0 ? "CERRAHI" : i % 3 == 1 ? "ENDOSKOPI" : "GENEL",
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                    REFERANS_TABLO_ADI = "STERILIZASYON_GIRIS",
                    STERILIZASYON_SET_KODU = setler[i % setler.Count].STERILIZASYON_SET_KODU,
                    GIRIS_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 30)),
                    TESLIM_ALAN_PERSONEL_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                    EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                    REFERANS_TABLO_ADI = "STERILIZASYON_CIKIS",
                    STERILIZASYON_SET_KODU = setler[i % setler.Count].STERILIZASYON_SET_KODU,
                    CIKIS_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 15)),
                    TESLIM_EDEN_PERSONEL_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                    EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "VEZNE",
                VEZNE_ADI = $"Vezne {i}",
                VEZNE_TURU = i % 2 == 0 ? "ANA_VEZNE" : "BIRIM_VEZNE",
                AKTIF = true,
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                    REFERANS_TABLO_ADI = "VEZNE_DETAY",
                    VEZNE_KODU = vezneler[i % vezneler.Count].VEZNE_KODU,
                    HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                    ISLEM_TARIHI = b.BASVURU_TARIHI,
                    TUTAR = _random.Next(50, 1000),
                    ODEME_TURU = i % 3 == 0 ? "NAKIT" : i % 3 == 1 ? "KART" : "SGK",
                    EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                    REFERANS_TABLO_ADI = "EK_ODEME",
                    PERSONEL_KODU = p.PERSONEL_KODU,
                    DONEM_KODU = donemler[i % donemler.Count].EK_ODEME_DONEM_KODU,
                    TOPLAM_PUAN = _random.Next(100, 1000),
                    EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "TETKIK_REFERANS_ARALIK",
                TETKIK_KODU = t.TETKIK_KODU,
                CINSIYET = i % 2 == 0 ? "E" : "K",
                MIN_YAS = 0,
                MAX_YAS = 99,
                MIN_DEGER = _random.Next(0, 50).ToString(),
                MAX_DEGER = _random.Next(50, 200).ToString(),
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                    REFERANS_TABLO_ADI = "TETKIK_CIHAZ_ESLESME",
                    TETKIK_KODU = t.TETKIK_KODU,
                    CIHAZ_KODU = cihazlar[i % cihazlar.Count].CIHAZ_KODU,
                    EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                    REFERANS_TABLO_ADI = "ANLIK_YATAN_HASTA",
                    HASTA_KODU = h.HASTA_KODU,
                    YATAK_KODU = yataklar[i % yataklar.Count].YATAK_KODU,
                    YATIS_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 14)),
                    EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "MEDULA_TAKIP",
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                TAKIP_NO = $"T{DateTime.Now.Year}{_random.Next(100000, 999999)}",
                TAKIP_TARIHI = b.BASVURU_TARIHI,
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                    REFERANS_TABLO_ADI = "RECETE_ILAC_ACIKLAMA",
                    RECETE_ILAC_KODU = ri.RECETE_ILAC_KODU,
                    ACIKLAMA = $"İlaç kullanım açıklaması {i + 1}",
                    EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "OPTIK_RECETE",
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_KODU = b.HASTA_KODU,
                RECETE_TARIHI = b.BASVURU_TARIHI,
                YAZAN_HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
                SAG_SFERIK = (_random.NextDouble() * 6 - 3).ToString("F2"),
                SOL_SFERIK = (_random.NextDouble() * 6 - 3).ToString("F2"),
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "ILAC_UYUM",
                HASTA_KODU = h.HASTA_KODU,
                DEGERLENDIRME_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 90)),
                UYUM_DURUMU = i % 3 == 0 ? "IYI" : i % 3 == 1 ? "ORTA" : "KOTU",
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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
                REFERANS_TABLO_ADI = "RISK_SKORLAMA",
                HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
                HASTA_KODU = b.HASTA_KODU,
                SKORLAMA_TARIHI = b.BASVURU_TARIHI,
                SKOR_TURU = i % 3 == 0 ? "DUSME" : i % 3 == 1 ? "BASINC_YARASI" : "BESLENME",
                SKOR_DEGERI = _random.Next(1, 10),
                EKLEYEN_KULLANICI_KODU = "SYSTEM",
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

        if (!hastalar.Any() || !basvurular.Any() || !personeller.Any())
        {
            _logger.LogWarning("Skipping Level 3 - missing dependency data");
            return;
        }

        // HASTA_NOTLARI - sadece zorunlu alanlar
        await SeedIfEmpty<HASTA_NOTLARI>(ct, basvurular.Take(25).Select((b, i) => new HASTA_NOTLARI
        {
            HASTA_NOTLARI_KODU = $"HN-{i + 1:D5}",
            REFERANS_TABLO_ADI = "HASTA_NOTLARI",
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
            REFERANS_TABLO_ADI = "HASTA_GIZLILIK",
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
            REFERANS_TABLO_ADI = "DOKTOR_MESAJI",
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
                REFERANS_TABLO_ADI = "KURUL_RAPOR",
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
            REFERANS_TABLO_ADI = "DIYABET",
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
            REFERANS_TABLO_ADI = "HASTA_UYARI",
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
            REFERANS_TABLO_ADI = "HASTA_TIBBI_BILGI",
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
            REFERANS_TABLO_ADI = "HASTA_EPIKRIZ",
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
            REFERANS_TABLO_ADI = "HASTA_FOTOGRAF",
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
            REFERANS_TABLO_ADI = "KLINIK_SEYIR",
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
            REFERANS_TABLO_ADI = "TIBBI_ORDER",
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
                REFERANS_TABLO_ADI = "KONSULTASYON",
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
        var hemsireler = personeller.Where(p => p.UNVAN == "Hemşire").ToList();
        if (hemsireler.Any())
        {
            await SeedIfEmpty<HASTA_VITAL_FIZIKI_BULGU>(ct, basvurular.Take(25).Select((b, i) => new HASTA_VITAL_FIZIKI_BULGU
            {
                HASTA_VITAL_FIZIKI_BULGU_KODU = $"VFB-{i + 1:D5}",
                REFERANS_TABLO_ADI = "HASTA_VITAL_FIZIKI_BULGU",
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
            REFERANS_TABLO_ADI = "HASTA_BORC",
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
            REFERANS_TABLO_ADI = "FIRMA",
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
            REFERANS_TABLO_ADI = "HASTA_ARSIV",
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
                REFERANS_TABLO_ADI = "EK_ODEME",
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
            REFERANS_TABLO_ADI = "BASVURU_YEMEK",
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
                REFERANS_TABLO_ADI = "HASTA_VENTILATOR",
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
                KURUM_TURU = k.Item2,
                ADRES = $"Merkez Mah. Sağlık Cad. No:{i + 1}",
                TELEFON = $"0{_random.Next(200, 600)}{_random.Next(1000000, 9999999)}",
                EMAIL = $"info@kurum{i + 1}.com.tr"
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
            REFERANS_TABLO_ADI = "PERSONEL_BANKA",
            PERSONEL_KODU = p.PERSONEL_KODU,
            BANKA = $"BANKA_{bankaRef[i % bankaRef.Length]}",
            BORDRO_TURU = $"BORDRO_TURU_{bordroTuruRef[i % bordroTuruRef.Length]}",
            HESAP_NUMARASI = $"{_random.Next(1000000, 9999999)}{_random.Next(100, 999)}",
            SUBE_KODU = $"{_random.Next(100, 999)}",
            IBAN_NUMARASI = $"TR{_random.Next(10, 99)}{_random.Next(10000, 99999)}{_random.Next(10000, 99999)}{_random.Next(10000, 99999)}{_random.Next(10000, 99999)}{_random.Next(10, 99)}",
            ACIKLAMA = $"Personel banka hesabı {i + 1}"
        }).ToList());

        // PERSONEL_OGRENIM - Personel Öğrenim Bilgileri
        var okullar = new[] { "İstanbul Üniversitesi", "Hacettepe Üniversitesi", "Ankara Üniversitesi", "Ege Üniversitesi", "Marmara Üniversitesi" };
        await SeedIfEmpty<PERSONEL_OGRENIM>(ct, personeller.Take(25).Select((p, i) => new PERSONEL_OGRENIM
        {
            PERSONEL_OGRENIM_KODU = $"PO-{i + 1:D5}",
            REFERANS_TABLO_ADI = "PERSONEL_OGRENIM",
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
                REFERANS_TABLO_ADI = "PERSONEL_IZIN",
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
                REFERANS_TABLO_ADI = "PERSONEL_BORDRO",
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
                REFERANS_TABLO_ADI = "EK_ODEME_DETAY",
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
                KLINIK_KODU = klinikKodlari[i % klinikKodlari.Length],
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
                REFERANS_TABLO_ADI = "HASTA_ARSIV_DETAY",
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
        if (ameliyatlar.Any() && hemsireler.Any() && birimlerLokal.Any())
        {
            await SeedIfEmpty<DOGUM>(ct, basvurular.Take(25).Select((b, i) => new DOGUM
            {
                DOGUM_KODU = $"DGM-{i + 1:D5}",
                REFERANS_TABLO_ADI = "DOGUM",
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
                DEFTER_NUMARASI = $"DGDF-{DateTime.Now.Year}-{i + 1:D5}"
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
                REFERANS_TABLO_ADI = "KAN_TALEP_DETAY",
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
        if (kanTalepDetaylar.Any())
        {
            await SeedIfEmpty<KAN_CIKIS>(ct, kanTalepDetaylar.Take(25).Select((ktd, i) => new KAN_CIKIS
            {
                KAN_CIKIS_KODU = $"KCK-{i + 1:D5}",
                REFERANS_TABLO_ADI = "KAN_CIKIS",
                KAN_TALEP_DETAY_KODU = ktd.KAN_TALEP_DETAY_KODU,
                HASTA_KODU = hastalar[i % hastalar.Count].HASTA_KODU,
                HASTA_BASVURU_KODU = basvurular[i % basvurular.Count].HASTA_BASVURU_KODU,
                KURUM_KODU = kurumlarMevcut.Any() ? kurumlarMevcut[i % kurumlarMevcut.Count].KURUM_KODU : null,
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
                REFERANS_TABLO_ADI = "KAN_URUN_IMHA",
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
            REFERANS_TABLO_ADI = "STERILIZASYON_PAKET",
            STERILIZASYON_PAKET_ADI = $"Steril Paket {i}",
            PAKET_KODU = $"STR-PKT-{_random.Next(10000, 99999)}",
            ACIKLAMA = $"Sterilizasyon paketi açıklaması {i}",
            STERILIZASYON_YONTEMI = sterilYontemRef[i % sterilYontemRef.Length],
            STERILIZASYON_PAKET_GRUBU = sterilGrupRef[i % sterilGrupRef.Length],
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
                REFERANS_TABLO_ADI = "STERILIZASYON_SET_DETAY",
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
            REFERANS_TABLO_ADI = "DIS_TAAHHUT",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
            DIS_TAAHHUT_NUMARASI = $"DTN-{DateTime.Now.Year}-{_random.Next(100000, 999999)}",
            SGK_TAKIP_NUMARASI = $"SGK-{_random.Next(100000000, 999999999)}",
            CADDE_SOKAK = $"Sağlık Caddesi No:{i + 1}",
            DIS_KAPI_NUMARASI = (_random.Next(1, 200)).ToString(),
            EPOSTA_ADRESI = $"hasta{i + 1}@email.com",
            IC_KAPI_NUMARASI = (_random.Next(1, 50)).ToString(),
            IL_KODU = ilKodlari[i % ilKodlari.Length],
            TELEFON_NUMARASI = $"05{_random.Next(100000000, 999999999)}",
            ILCE_KODU = ilceKodlari[i % ilceKodlari.Length],
            MEDULA_SONUC_KODU = "0000",
            MEDULA_SONUC_MESAJI = "İşlem başarılı",
            IPTAL_DURUMU = i % 10 == 0 ? "EVET" : "HAYIR"
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
            REFERANS_TABLO_ADI = "DISPROTEZ",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            DISPROTEZ_BASLAMA_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 180)),
            TEKNISYEN_KODU = personeller[(i + 1) % personeller.Count].PERSONEL_KODU,
            HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
            BIRIM_KODU = birimlerLokal.Any() ? birimlerLokal[i % birimlerLokal.Count].BIRIM_KODU : null,
            DISPROTEZ_IS_TURU_KODU = disprotezIsTuruRef[i % disprotezIsTuruRef.Length],
            DISPROTEZ_IS_TURU_ALT_KODU = disprotezIsTuruAltRef[i % disprotezIsTuruAltRef.Length],
            PARCA_SAYISI = (_random.Next(1, 10)).ToString(),
            DISPROTEZ_AYAK_SAYISI = (_random.Next(1, 6)).ToString(),
            DISPROTEZ_GOVDE_SAYISI = (_random.Next(1, 4)).ToString(),
            ACIKLAMA = $"Diş protez kaydı {i + 1}",
            DISPROTEZ_BIRIM_KODU = birimlerLokal.Any() ? birimlerLokal[i % birimlerLokal.Count].BIRIM_KODU : null,
            RPT_SEBEBI = rptSebebiRef[i % rptSebebiRef.Length],
            RPT_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 90)),
            RPT_EDEN_PERSONEL_KODU = personeller[(i + 2) % personeller.Count].PERSONEL_KODU,
            BARKOD_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
            DISPROTEZ_KASIK_TURU = disprotezKasikTuruRef[i % disprotezKasikTuruRef.Length],
            DISPROTEZ_RENGI = disprotezRengiRef[i % disprotezRengiRef.Length],
            DIS_BOYUT_BILGISI = disBoyutRef[i % disBoyutRef.Length],
            DISPROTEZ_ACIKLAMA = $"Diş protez açıklama {i + 1}"
        }).ToList());

        _logger.LogInformation("Diş tabloları seeded");

        // === BILDIRIMI_ZORUNLU - Bildirimi Zorunlu Hastalıklar ===
        // Referans kodları ekle
        var bildirimTuruRef = new[] { "KUDUZ", "VEREM", "INTIHAR", "SIDDET", "BULASICI" };
        var evetHayirRef = new[] { "EVET", "HAYIR", "BILINMIYOR" };
        foreach (var t in bildirimTuruRef)
            await AddReferansKodIfNotExists("BILDIRIM_TURU", t, t, ct);
        foreach (var t in evetHayirRef)
        {
            await AddReferansKodIfNotExists("AILESINDE_INTIHAR_GIRISIMI", t, t, ct);
            await AddReferansKodIfNotExists("AILESINDE_PSIKIYATRIK_VAKA", t, t, ct);
        }
        await _db.SaveChangesAsync(ct);

        await SeedIfEmpty<BILDIRIMI_ZORUNLU>(ct, basvurular.Take(25).Select((b, i) => new BILDIRIMI_ZORUNLU
        {
            BILDIRIMI_ZORUNLU_KODU = $"BZH-{i + 1:D5}",
            REFERANS_TABLO_ADI = "BILDIRIMI_ZORUNLU",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            BILDIRIM_TURU = bildirimTuruRef[i % bildirimTuruRef.Length],
            BILDIRIM_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 90)),
            AILESINDE_INTIHAR_GIRISIMI = evetHayirRef[i % evetHayirRef.Length],
            AILESINDE_PSIKIYATRIK_VAKA = evetHayirRef[(i + 1) % evetHayirRef.Length],
            OLAY_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 95)),
            EV_TELEFONU = $"0212{_random.Next(1000000, 9999999)}",
            CEP_TELEFONU = $"05{_random.Next(100000000, 999999999)}",
            EV_ADRESI = $"Mahalle {i + 1}, Sokak {_random.Next(1, 50)}, No:{_random.Next(1, 100)}",
            IL_KODU = ilKodlari[i % ilKodlari.Length],
            ILCE_KODU = ilceKodlari[i % ilceKodlari.Length],
            BCG_SKAR_SAYISI = (_random.Next(0, 3)).ToString(),
            BELIRTILERIN_BASLADIGI_TARIH = DateTime.Now.AddDays(-_random.Next(1, 30)),
            ACIKLAMA = $"Bildirimi zorunlu hastalık kaydı {i + 1}"
        }).ToList());

        // === GETAT - GETAT (Geleneksel ve Tamamlayıcı Tıp) ===
        var getatUygulamaTuruRef = new[] { "AKUPUNKTUR", "OZON_TEDAVISI", "HIPNOZ", "FITOTERAPI", "KAYROPRAKTIK", "HOMEOPATI", "REFLEKSOLOJI" };
        var getatTedaviSonucuRef = new[] { "BASARILI", "DEVAM_EDIYOR", "SONLANDIRILDI" };
        var getatUygulamaBolgesiRef = new[] { "BAS", "BOYUN", "SIRT", "BEL", "BACAK", "KOL" };
        foreach (var t in getatUygulamaTuruRef)
            await AddReferansKodIfNotExists("GETAT_UYGULAMA_TURU", t, t, ct);
        foreach (var t in getatTedaviSonucuRef)
            await AddReferansKodIfNotExists("GETAT_TEDAVI_SONUCU", t, t, ct);
        foreach (var t in getatUygulamaBolgesiRef)
            await AddReferansKodIfNotExists("GETAT_UYGULAMA_BOLGESI", t, t, ct);
        await _db.SaveChangesAsync(ct);

        await SeedIfEmpty<GETAT>(ct, basvurular.Take(25).Select((b, i) => new GETAT
        {
            GETAT_KODU = $"GTT-{i + 1:D5}",
            REFERANS_TABLO_ADI = "GETAT",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            GETAT_UYGULAMA_TURU = getatUygulamaTuruRef[i % getatUygulamaTuruRef.Length],
            KOMPLIKASYON_TANISI = $"KOMPLIKASYON_TANISI_{komplikasyonRef[i % komplikasyonRef.Length]}",
            GETAT_TEDAVI_SONUCU = getatTedaviSonucuRef[i % getatTedaviSonucuRef.Length],
            GETAT_UYGULAMA_BOLGESI = getatUygulamaBolgesiRef[i % getatUygulamaBolgesiRef.Length],
            ACIKLAMA = $"GETAT kaydı {i + 1}"
        }).ToList());

        // === MADDE_BAGIMLILIGI - Madde Bağımlılığı ===
        var birincilMaddeRef = new[] { "ALKOL", "SIGARA", "ESRAR", "EROIN", "KOKAIN", "SENTETIK_UYUSTURUCU" };
        var bagimlillikDurumRef = new[] { "EVET", "HAYIR", "BILINMIYOR" };
        foreach (var t in birincilMaddeRef)
            await AddReferansKodIfNotExists("BIRINCIL_KULLANILAN_ESAS_MADDE", t, t, ct);
        foreach (var t in bagimlillikDurumRef)
        {
            await AddReferansKodIfNotExists("ENJEKSIYON_ILE_MADDE_KULLANIMI", t, t, ct);
            await AddReferansKodIfNotExists("ENJEKTOR_PAYLASIM_DURUMU", t, t, ct);
            await AddReferansKodIfNotExists("HIV_TEST_YAPILMA_DURUMU", t, t, ct);
            await AddReferansKodIfNotExists("HCV_TEST_YAPILMA_DURUMU", t, t, ct);
            await AddReferansKodIfNotExists("HBV_TEST_YAPILMA_DURUMU", t, t, ct);
            await AddReferansKodIfNotExists("BULASICI_HASTALIK_DURUMU", t, t, ct);
        }
        await _db.SaveChangesAsync(ct);

        await SeedIfEmpty<MADDE_BAGIMLILIGI>(ct, basvurular.Take(25).Select((b, i) => new MADDE_BAGIMLILIGI
        {
            MADDE_BAGIMLILIGI_KODU = $"MDB-{i + 1:D5}",
            REFERANS_TABLO_ADI = "MADDE_BAGIMLILIGI",
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            DANISMA_TEDAVI_HIZMET_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 180)),
            SON_IKAME_TEDAVI_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 90)),
            ENJEKSIYON_ILE_MADDE_KULLANIMI = bagimlillikDurumRef[i % bagimlillikDurumRef.Length],
            ENJEKSIYON_ILK_KULLANIM_YASI = (_random.Next(15, 35)).ToString(),
            ENJEKTOR_PAYLASIM_DURUMU = bagimlillikDurumRef[(i + 1) % bagimlillikDurumRef.Length],
            ILK_ENJEKTOR_PAYLASIM_YASI = (_random.Next(16, 40)).ToString(),
            HIV_TEST_YAPILMA_DURUMU = bagimlillikDurumRef[i % bagimlillikDurumRef.Length],
            HCV_TEST_YAPILMA_DURUMU = bagimlillikDurumRef[i % bagimlillikDurumRef.Length],
            HBV_TEST_YAPILMA_DURUMU = bagimlillikDurumRef[i % bagimlillikDurumRef.Length],
            BULASICI_HASTALIK_DURUMU = bagimlillikDurumRef[i % bagimlillikDurumRef.Length],
            BIRINCIL_KULLANILAN_ESAS_MADDE = birincilMaddeRef[i % birincilMaddeRef.Length]
        }).ToList());

        _logger.LogInformation("Özel durum tabloları seeded (BILDIRIMI_ZORUNLU, GETAT, MADDE_BAGIMLILIGI)");

        // === KURUL_ENGELLI - Engelli Kurul ===
        var kurulRaporlar = await _db.Set<KURUL_RAPOR>().ToListAsync(ct);
        if (kurulRaporlar.Any())
        {
            await SeedIfEmpty<KURUL_ENGELLI>(ct, kurulRaporlar.Take(25).Select((kr, i) => new KURUL_ENGELLI
            {
                KURUL_ENGELLI_KODU = $"KRE-{i + 1:D5}",
                REFERANS_TABLO_ADI = "KURUL_ENGELLI",
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

        // === KURUL_ASKERI - Askeri Kurul ===
        var medulaRaporTuruRef = new[] { "ASKERLIK", "ERTELEME", "MUAFIYET" };
        var medulaAltRaporTuruRef = new[] { "SAGLIK", "PSIKOLOJIK", "ORTOPEDIK" };
        foreach (var t in medulaRaporTuruRef)
            await AddReferansKodIfNotExists("MEDULA_RAPOR_TURU", t, t, ct);
        foreach (var t in medulaAltRaporTuruRef)
            await AddReferansKodIfNotExists("MEDULA_ALT_RAPOR_TURU", t, t, ct);
        await _db.SaveChangesAsync(ct);

        await SeedIfEmpty<KURUL_ASKERI>(ct, Enumerable.Range(1, 25).Select(i => new KURUL_ASKERI
        {
            KURUL_ASKERI_KODU = $"KRA-{i:D5}",
            REFERANS_TABLO_ADI = "KURUL_ASKERI",
            KURUL_ADI = $"Askeri Sağlık Kurulu {i}",
            MEDULA_RAPOR_TURU = medulaRaporTuruRef[i % medulaRaporTuruRef.Length],
            MEDULA_ALT_RAPOR_TURU = medulaAltRaporTuruRef[i % medulaAltRaporTuruRef.Length],
            ALKOL_MADDE_BAGIMLILIGI = evetHayirRef[i % evetHayirRef.Length],
            BEDEN_RUH_ILERI_TETKIK_BULGUSU = evetHayirRef[i % evetHayirRef.Length],
            GECMIS_HASTALIGA_DAIR_KAYIT = evetHayirRef[i % evetHayirRef.Length],
            GORME_ISITME_KAYBI = evetHayirRef[i % evetHayirRef.Length],
            PSIKIYATRIK_RAHATSIZLIK = evetHayirRef[i % evetHayirRef.Length],
            ASAL_HASTALIK = evetHayirRef[i % evetHayirRef.Length],
            ASAL_HASTALIK_TIPI = new[] { "KALP", "AKCIGER", "BOBREK", "NOROLOJIK" }[i % 4]
        }).ToList());

        // === KURUL_TESHIS - Kurul Teşhis ===
        var icd10Kodlar = new[] { "J06.9", "K29.7", "I10", "E11.9", "J45.9", "M54.5", "R51", "N39.0" };
        if (kurulRaporlar.Any())
        {
            await SeedIfEmpty<KURUL_TESHIS>(ct, kurulRaporlar.Take(25).Select((kr, i) => new KURUL_TESHIS
            {
                KURUL_TESHIS_KODU = $"KRT-{i + 1:D5}",
                REFERANS_TABLO_ADI = "KURUL_TESHIS",
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

        // === BEBEK_COCUK_IZLEM - Bebek Çocuk İzlem ===
        await SeedIfEmpty<BEBEK_COCUK_IZLEM>(ct, basvurular.Take(25).Select((b, i) => new BEBEK_COCUK_IZLEM
        {
            BEBEK_COCUK_IZLEM_KODU = $"BCI-{i + 1:D5}",
            REFERANS_TABLO_ADI = "BEBEK_COCUK_IZLEM",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            KACINCI_IZLEM = izlemRefKodlar["KACINCI_IZLEM"][i % 10],
            AGIZDAN_SIVI_TEDAVISI = izlemRefKodlar["AGIZDAN_SIVI_TEDAVISI"][i % 3],
            BAS_CEVRESI = (35 + _random.Next(0, 15)).ToString(),
            DEMIR_LOJISTIGI_VE_DESTEGI = izlemRefKodlar["DEMIR_LOJISTIGI_VE_DESTEGI"][i % 3],
            DOGUM_AGIRLIGI = (2500 + _random.Next(0, 2000)).ToString(),
            DVITAMINI_LOJISTIGI_VE_DESTEGI = izlemRefKodlar["DVITAMINI_LOJISTIGI_VE_DESTEGI"][i % 3],
            GKD_TARAMA_SONUCU = izlemRefKodlar["GKD_TARAMA_SONUCU"][i % 4],
            HEMATOKRIT_DEGERI = (35 + _random.Next(0, 15)).ToString(),
            HEMOGLOBIN_DEGERI = (11 + _random.NextDouble() * 4).ToString("F1"),
            TOPUK_KANI = izlemRefKodlar["TOPUK_KANI"][i % 3],
            TOPUK_KANI_ALINMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
            IZLEMIN_YAPILDIGI_YER = izlemRefKodlar["IZLEMIN_YAPILDIGI_YER"][i % 4],
            IZLEMI_YAPAN_PERSONEL_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
            BILGI_ALINAN_KISI_AD_SOYADI = $"Anne Adı {i + 1}",
            BILGI_ALINAN_KISI_TELEFON = $"05{_random.Next(100000000, 999999999)}",
            BEBEKTE_RISK_FAKTORLERI = izlemRefKodlar["BEBEKTE_RISK_FAKTORLERI"][i % 4],
            TARAMA_SONUCU = izlemRefKodlar["TARAMA_SONUCU"][i % 3],
            ANNE_SUTUNDEN_KESILDIGI_AY = (_random.Next(6, 24)).ToString(),
            BEBEGIN_BESLENME_DURUMU = izlemRefKodlar["BEBEGIN_BESLENME_DURUMU"][i % 4],
            EK_GIDAYA_BASLADIGI_AY = (_random.Next(4, 8)).ToString(),
            SADECE_ANNE_SUTU_ALDIGI_SURE = (_random.Next(0, 6)).ToString(),
            GELISIM_TABLOSU_BILGILERI = izlemRefKodlar["GELISIM_TABLOSU_BILGILERI"][i % 3],
            NTP_TAKIP_BILGISI = izlemRefKodlar["NTP_TAKIP_BILGISI"][i % 3],
            BC_BEYIN_GELISIM_RISKLERI = izlemRefKodlar["BC_BEYIN_GELISIM_RISKLERI"][i % 4],
            EBEVEYN_DESTEK_AKTIVITELERI = izlemRefKodlar["EBEVEYN_DESTEK_AKTIVITELERI"][i % 3],
            BC_PSIKOLOJIK_RISK_EGITIM = izlemRefKodlar["BC_PSIKOLOJIK_RISK_EGITIM"][i % 3],
            BC_RISK_YAPILAN_MUDAHALE = izlemRefKodlar["BC_RISK_YAPILAN_MUDAHALE"][i % 3],
            BC_RISKLI_OLGU_TAKIBI = izlemRefKodlar["BC_RISKLI_OLGU_TAKIBI"][i % 3],
            ACIKLAMA = $"Bebek çocuk izlem kaydı {i + 1}"
        }).ToList());

        // === GEBE_IZLEM - Gebe İzlem ===
        await SeedIfEmpty<GEBE_IZLEM>(ct, basvurular.Take(25).Select((b, i) => new GEBE_IZLEM
        {
            GEBE_IZLEM_KODU = $"GBI-{i + 1:D5}",
            REFERANS_TABLO_ADI = "GEBE_IZLEM",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            KACINCI_GEBE_IZLEM = izlemRefKodlar["KACINCI_GEBE_IZLEM"][i % 10],
            SON_ADET_TARIHI = DateTime.Now.AddDays(-_random.Next(60, 280)),
            ONCEKI_DOGUM_DURUMU = izlemRefKodlar["ONCEKI_DOGUM_DURUMU"][i % 5],
            GEBE_IZLEM_ISLEM_TURU = izlemRefKodlar["GEBE_IZLEM_ISLEM_TURU"][i % 4],
            GESTASYONEL_DIYABET_TARAMASI = izlemRefKodlar["GESTASYONEL_DIYABET_TARAMASI"][i % 4],
            IDRARDA_PROTEIN = izlemRefKodlar["IDRARDA_PROTEIN"][i % 4],
            HEMOGLOBIN_DEGERI = (10 + _random.NextDouble() * 4).ToString("F1"),
            DEMIR_LOJISTIGI_VE_DESTEGI = izlemRefKodlar["DEMIR_LOJISTIGI_VE_DESTEGI"][i % 3],
            DVITAMINI_LOJISTIGI_VE_DESTEGI = izlemRefKodlar["DVITAMINI_LOJISTIGI_VE_DESTEGI"][i % 3],
            KONJENITAL_ANOMALI_VARLIGI = izlemRefKodlar["KONJENITAL_ANOMALI_VARLIGI"][i % 3],
            FETUS_KALP_SESI = (120 + _random.Next(0, 40)).ToString(),
            DIASTOLIK_KAN_BASINCI_DEGERI = (60 + _random.Next(0, 30)).ToString(),
            SISTOLIK_KAN_BASINCI_DEGERI = (100 + _random.Next(0, 40)).ToString(),
            GEBELIKTE_RISK_FAKTORLERI = izlemRefKodlar["GEBELIKTE_RISK_FAKTORLERI"][i % 4],
            BC_BEYIN_GELISIM_RISKLERI = izlemRefKodlar["BC_BEYIN_GELISIM_RISKLERI"][i % 4],
            PSIKOLOJIK_GELISIM_RISK_EGITIM = izlemRefKodlar["PSIKOLOJIK_GELISIM_RISK_EGITIM"][i % 3],
            RISK_FAKTORLERINE_MUDAHALE = izlemRefKodlar["RISK_FAKTORLERINE_MUDAHALE"][i % 3],
            RISK_ALTINDAKI_OLGU_TAKIBI = izlemRefKodlar["RISK_ALTINDAKI_OLGU_TAKIBI"][i % 3],
            ACIKLAMA = $"Gebe izlem kaydı {i + 1}"
        }).ToList());

        // === OBEZITE_IZLEM - Obezite İzlem ===
        await SeedIfEmpty<OBEZITE_IZLEM>(ct, basvurular.Take(25).Select((b, i) => new OBEZITE_IZLEM
        {
            OBEZITE_IZLEM_KODU = $"OBI-{i + 1:D5}",
            REFERANS_TABLO_ADI = "OBEZITE_IZLEM",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            DIYET_TIBBI_BESLENME_TEDAVISI = izlemRefKodlar["DIYET_TIBBI_BESLENME_TEDAVISI"][i % 3],
            ILK_TANI_TARIHI = DateTime.Now.AddYears(-_random.Next(1, 5)),
            MORBIT_OBEZ_LENFATIK_ODEM = izlemRefKodlar["MORBIT_OBEZ_LENFATIK_ODEM"][i % 3],
            OBEZITE_ILAC_TEDAVISI = izlemRefKodlar["OBEZITE_ILAC_TEDAVISI"][i % 3],
            PSIKOLOJIK_TEDAVI = izlemRefKodlar["PSIKOLOJIK_TEDAVI"][i % 3],
            BIRLIKTE_GORULEN_EK_HASTALIK = izlemRefKodlar["BIRLIKTE_GORULEN_EK_HASTALIK"][i % 5],
            EGZERSIZ = izlemRefKodlar["EGZERSIZ"][i % 4],
            ACIKLAMA = $"Obezite izlem kaydı {i + 1}"
        }).ToList());

        // === INTIHAR_IZLEM - İntihar İzlem ===
        var intiharRefKodlar = new Dictionary<string, string[]>
        {
            { "INTIHAR_KRIZ_VAKA_TURU", new[] { "INTIHAR_GIRISIMI", "KRIZ_DURUMU", "TEHDIT", "DUSUNCE" } },
            { "INTIHAR_GIRISIM_KRIZ_NEDENLERI", new[] { "AILE_SORUNU", "EKONOMIK", "SAGLIK", "ILISKI", "IS_KAYBI" } },
            { "INTIHAR_GIRISIMI_YONTEMI", new[] { "ILAC", "KESICI_ALET", "YUKSEKTEN_ATLAMA", "ASMA", "DIGER" } },
            { "INTIHAR_KRIZ_VAKA_SONUCU", new[] { "TEDAVI", "SEVK", "TABURCU", "TAKIP", "EXITUS" } }
        };

        foreach (var kvp in intiharRefKodlar)
        {
            foreach (var kod in kvp.Value)
            {
                await AddReferansKodIfNotExists(kvp.Key, kod, kod, ct);
            }
        }
        await _db.SaveChangesAsync(ct);

        await SeedIfEmpty<INTIHAR_IZLEM>(ct, basvurular.Take(25).Select((b, i) => new INTIHAR_IZLEM
        {
            INTIHAR_IZLEM_KODU = $"INI-{i + 1:D5}",
            REFERANS_TABLO_ADI = "INTIHAR_IZLEM",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            INTIHAR_KRIZ_VAKA_TURU = intiharRefKodlar["INTIHAR_KRIZ_VAKA_TURU"][i % 4],
            INTIHAR_GIRISIM_KRIZ_NEDENLERI = intiharRefKodlar["INTIHAR_GIRISIM_KRIZ_NEDENLERI"][i % 5],
            INTIHAR_GIRISIMI_YONTEMI = intiharRefKodlar["INTIHAR_GIRISIMI_YONTEMI"][i % 5],
            INTIHAR_KRIZ_VAKA_SONUCU = intiharRefKodlar["INTIHAR_KRIZ_VAKA_SONUCU"][i % 5],
            ACIKLAMA = $"İntihar/Kriz izlem kaydı {i + 1}"
        }).ToList());

        // === KADIN_IZLEM - Kadın İzlem ===
        var kadinRefKodlar = new Dictionary<string, string[]>
        {
            { "KONJENITAL_ANOMALI_VARLIGI", new[] { "YOK", "VAR", "SUPHE" } },
            { "ONCEKI_DOGUM_DURUMU", new[] { "NORMAL", "KOMPLIKASYONLU", "SEZARYEN", "DUSUK" } },
            { "KULLANILAN_AP_YONTEMI", new[] { "RIA", "HAP", "KONDOM", "IMPLANT", "DOGAL", "YOK" } },
            { "BIR_ONCE_KULLANILAN_AP_YONTEMI", new[] { "RIA", "HAP", "KONDOM", "IMPLANT", "DOGAL", "YOK" } },
            { "AP_YONTEMI_LOJISTIGI", new[] { "VERILDI", "VERILMEDI", "RED" } },
            { "KADIN_SAGLIGI_ISLEMLERI", new[] { "SMEAR", "MAMOGRAFI", "ULTRASON", "MUAYENE" } }
        };

        foreach (var kvp in kadinRefKodlar)
        {
            foreach (var kod in kvp.Value)
            {
                await AddReferansKodIfNotExists(kvp.Key, kod, kod, ct);
            }
        }
        await _db.SaveChangesAsync(ct);

        await SeedIfEmpty<KADIN_IZLEM>(ct, basvurular.Take(25).Select((b, i) => new KADIN_IZLEM
        {
            KADIN_IZLEM_KODU = $"KDI-{i + 1:D5}",
            REFERANS_TABLO_ADI = "KADIN_IZLEM",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            KONJENITAL_ANOMALI_VARLIGI = kadinRefKodlar["KONJENITAL_ANOMALI_VARLIGI"][i % 3],
            CANLI_DOGAN_BEBEK_SAYISI = _random.Next(0, 4).ToString(),
            OLU_DOGAN_BEBEK_SAYISI = _random.Next(0, 2).ToString(),
            HEMOGLOBIN_DEGERI = (10 + _random.Next(0, 5)).ToString(),
            ONCEKI_DOGUM_DURUMU = kadinRefKodlar["ONCEKI_DOGUM_DURUMU"][i % 4],
            IZLEMIN_YAPILDIGI_YER = "HASTANE",
            KULLANILAN_AP_YONTEMI = kadinRefKodlar["KULLANILAN_AP_YONTEMI"][i % 6],
            BIR_ONCE_KULLANILAN_AP_YONTEMI = kadinRefKodlar["BIR_ONCE_KULLANILAN_AP_YONTEMI"][i % 6],
            AP_YONTEMI_LOJISTIGI = kadinRefKodlar["AP_YONTEMI_LOJISTIGI"][i % 3],
            KADIN_SAGLIGI_ISLEMLERI = kadinRefKodlar["KADIN_SAGLIGI_ISLEMLERI"][i % 4],
            AP_YONTEMI_KULLANMAMA_NEDENI = "Aile planlaması yapılıyor",
            ACIKLAMA = $"Kadın sağlığı izlem kaydı {i + 1}"
        }).ToList());

        // === KUDUZ_IZLEM - Kuduz İzlem ===
        var kuduzRefKodlar = new Dictionary<string, string[]>
        {
            { "PROFILAKSI_TAMAMLANMA_DURUMU", new[] { "TAMAMLANDI", "DEVAM_EDIYOR", "YARIDA_BIRAKILDI" } },
            { "UYGULANAN_KUDUZ_PROFILAKSISI", new[] { "ASI", "IMMUNOGLOBULIN", "ASI_VE_IMMUNOGLOBULIN" } }
        };

        foreach (var kvp in kuduzRefKodlar)
        {
            foreach (var kod in kvp.Value)
            {
                await AddReferansKodIfNotExists(kvp.Key, kod, kod, ct);
            }
        }
        await _db.SaveChangesAsync(ct);

        var kuduzKurumlar = await _db.Set<KURUM>().Take(5).ToListAsync(ct);
        await SeedIfEmpty<KUDUZ_IZLEM>(ct, basvurular.Take(25).Select((b, i) => new KUDUZ_IZLEM
        {
            KUDUZ_IZLEM_KODU = $"KDZ-{i + 1:D5}",
            REFERANS_TABLO_ADI = "KUDUZ_IZLEM",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            PROFILAKSI_TAMAMLANMA_DURUMU = kuduzRefKodlar["PROFILAKSI_TAMAMLANMA_DURUMU"][i % 3],
            UYGULANAN_KUDUZ_PROFILAKSISI = kuduzRefKodlar["UYGULANAN_KUDUZ_PROFILAKSISI"][i % 3],
            BEYAN_TSM_KURUM_KODU = kuduzKurumlar.Any() ? kuduzKurumlar[i % kuduzKurumlar.Count].KURUM_KODU : $"KRM-{i + 1:D5}",
            IMMUNGLOBULIN_MIKTARI = (500 + _random.Next(0, 500)).ToString(),
            ACIKLAMA = $"Kuduz izlem kaydı {i + 1}"
        }).ToList());

        // === LOHUSA_IZLEM - Lohusa İzlem ===
        var lohusaRefKodlar = new Dictionary<string, string[]>
        {
            { "KACINCI_LOHUSA_IZLEM", new[] { "BIRINCI", "IKINCI", "UCUNCU", "DORDUNCU" } },
            { "IZLEMIN_YAPILDIGI_YER", new[] { "HASTANE", "ASM", "EVDE", "TSM" } },
            { "DEMIR_LOJISTIGI_VE_DESTEGI", new[] { "VERILDI", "VERILMEDI", "RED" } },
            { "DVITAMINI_LOJISTIGI_VE_DESTEGI", new[] { "VERILDI", "VERILMEDI", "RED" } },
            { "POSTPARTUM_DEPRESYON", new[] { "NORMAL", "RISK", "DEPRESYON" } },
            { "UTERUS_INVOLUSYON", new[] { "NORMAL", "ANORMAL" } },
            { "KOMPLIKASYON_TANISI_LOHUSA", new[] { "YOK", "ENFEKSIYON", "KANAMA", "DIGER" } },
            { "SEYIR_TEHLIKE_ISARETI", new[] { "YOK", "ATES", "KANAMA", "ENFEKSIYON" } }
        };

        foreach (var kvp in lohusaRefKodlar)
        {
            foreach (var kod in kvp.Value)
            {
                await AddReferansKodIfNotExists(kvp.Key, kod, kod, ct);
            }
        }
        await _db.SaveChangesAsync(ct);

        await SeedIfEmpty<LOHUSA_IZLEM>(ct, basvurular.Take(25).Select((b, i) => new LOHUSA_IZLEM
        {
            LOHUSA_IZLEM_KODU = $"LHI-{i + 1:D5}",
            REFERANS_TABLO_ADI = "LOHUSA_IZLEM",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            KACINCI_LOHUSA_IZLEM = lohusaRefKodlar["KACINCI_LOHUSA_IZLEM"][i % 4],
            IZLEMIN_YAPILDIGI_YER = lohusaRefKodlar["IZLEMIN_YAPILDIGI_YER"][i % 4],
            DEMIR_LOJISTIGI_VE_DESTEGI = lohusaRefKodlar["DEMIR_LOJISTIGI_VE_DESTEGI"][i % 3],
            DVITAMINI_LOJISTIGI_VE_DESTEGI = lohusaRefKodlar["DVITAMINI_LOJISTIGI_VE_DESTEGI"][i % 3],
            GEBELIK_SONLANMA_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 42)),
            POSTPARTUM_DEPRESYON = lohusaRefKodlar["POSTPARTUM_DEPRESYON"][i % 3],
            UTERUS_INVOLUSYON = lohusaRefKodlar["UTERUS_INVOLUSYON"][i % 2],
            BILGI_ALINAN_KISI_AD_SOYADI = $"Yakın {i + 1}",
            BILGI_ALINAN_KISI_TELEFON = $"05{_random.Next(100000000, 999999999)}",
            KONJENITAL_ANOMALI_VARLIGI = kadinRefKodlar["KONJENITAL_ANOMALI_VARLIGI"][i % 3],
            HEMOGLOBIN_DEGERI = (10 + _random.Next(0, 5)).ToString(),
            KOMPLIKASYON_TANISI = lohusaRefKodlar["KOMPLIKASYON_TANISI_LOHUSA"][i % 4],
            SEYIR_TEHLIKE_ISARETI = lohusaRefKodlar["SEYIR_TEHLIKE_ISARETI"][i % 4],
            KADIN_SAGLIGI_ISLEMLERI = kadinRefKodlar["KADIN_SAGLIGI_ISLEMLERI"][i % 4],
            ACIKLAMA = $"Lohusa izlem kaydı {i + 1}"
        }).ToList());

        // === EVDE_SAGLIK_IZLEM - Evde Sağlık İzlem ===
        var evdeSaglikRefKodlar = new Dictionary<string, string[]>
        {
            { "AGRI", new[] { "YOK", "HAFIF", "ORTA", "SIDDETLI" } },
            { "AYDINLATMA", new[] { "YETERLI", "YETERSIZ" } },
            { "BAKIM_VE_DESTEK_IHTIYACI", new[] { "BAGIMSIZ", "KISMI_BAGIMLI", "TAM_BAGIMLI" } },
            { "BASI_DEGERLENDIRMESI", new[] { "RISK_YOK", "DUSUK_RISK", "ORTA_RISK", "YUKSEK_RISK" } },
            { "BASVURU_TURU", new[] { "BIREYSEL", "KURUM", "SEVK" } },
            { "BESLENME", new[] { "NORMAL", "YETERSIZ", "ENTERAL", "PARENTERAL" } },
            { "ESH_ESAS_HASTALIK_GRUBU", new[] { "NOROLOJIK", "ONKOLOJIK", "GERIATRIK", "DIGER" } },
            { "EV_HIJYENI", new[] { "IYI", "ORTA", "KOTU" } },
            { "GUVENLIK", new[] { "YETERLI", "YETERSIZ" } },
            { "ISINMA", new[] { "DOGALGAZ", "ELEKTRIK", "KATI_YAKIT", "YOK" } },
            { "KISISEL_BAKIM", new[] { "BAGIMSIZ", "YARDIMLA", "BAGIMLI" } },
            { "KISISEL_HIJYEN", new[] { "IYI", "ORTA", "KOTU" } },
            { "KONUT_TIPI", new[] { "MUSTAKIL", "APARTMAN", "GECEKONDU" } },
            { "KULLANILAN_HELA_TIPI", new[] { "ALATURKA", "ALAFRANGA", "PORTATIF" } },
            { "YATAGA_BAGIMLILIK", new[] { "YOK", "KISMI", "TAM" } },
            { "KULLANDIGI_YARDIMCI_ARACLAR", new[] { "YOK", "BASTON", "YURUYUCU", "TEKERLEKLI_SANDALYE" } },
            { "PSIKOLOJIK_DURUM_DEGERLENDIRME", new[] { "NORMAL", "ANKSIYETE", "DEPRESYON", "DIGER" } },
            { "ESH_SONLANDIRILMASI", new[] { "DEVAM", "TABURCU", "SEVK", "EXITUS" } },
            { "ESH_HASTA_NAKLI", new[] { "YOK", "AMBULANS", "OZEL_ARAC" } },
            { "ESH_ALINACAK_IL", new[] { "34", "06", "35", "16" } },
            { "BIR_SONRAKI_HIZMET_IHTIYACI", new[] { "KONTROL", "TEDAVI", "REHABILITASYON" } },
            { "VERILEN_EGITIMLER", new[] { "BAKIM", "BESLENME", "ILAC_KULLANIMI", "YARA_BAKIMI" } }
        };

        foreach (var kvp in evdeSaglikRefKodlar)
        {
            foreach (var kod in kvp.Value)
            {
                await AddReferansKodIfNotExists(kvp.Key, kod, kod, ct);
            }
        }
        await _db.SaveChangesAsync(ct);

        await SeedIfEmpty<EVDE_SAGLIK_IZLEM>(ct, basvurular.Take(25).Select((b, i) => new EVDE_SAGLIK_IZLEM
        {
            EVDE_SAGLIK_IZLEM_KODU = $"ESI-{i + 1:D5}",
            REFERANS_TABLO_ADI = "EVDE_SAGLIK_IZLEM",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            AGRI = evdeSaglikRefKodlar["AGRI"][i % 4],
            AYDINLATMA = evdeSaglikRefKodlar["AYDINLATMA"][i % 2],
            BAKIM_VE_DESTEK_IHTIYACI = evdeSaglikRefKodlar["BAKIM_VE_DESTEK_IHTIYACI"][i % 3],
            BASI_DEGERLENDIRMESI = evdeSaglikRefKodlar["BASI_DEGERLENDIRMESI"][i % 4],
            BASVURU_TURU = evdeSaglikRefKodlar["BASVURU_TURU"][i % 3],
            BESLENME = evdeSaglikRefKodlar["BESLENME"][i % 4],
            ESH_ESAS_HASTALIK_GRUBU = evdeSaglikRefKodlar["ESH_ESAS_HASTALIK_GRUBU"][i % 4],
            EV_HIJYENI = evdeSaglikRefKodlar["EV_HIJYENI"][i % 3],
            GUVENLIK = evdeSaglikRefKodlar["GUVENLIK"][i % 2],
            ISINMA = evdeSaglikRefKodlar["ISINMA"][i % 4],
            KISISEL_BAKIM = evdeSaglikRefKodlar["KISISEL_BAKIM"][i % 3],
            KISISEL_HIJYEN = evdeSaglikRefKodlar["KISISEL_HIJYEN"][i % 3],
            KONUT_TIPI = evdeSaglikRefKodlar["KONUT_TIPI"][i % 3],
            KULLANILAN_HELA_TIPI = evdeSaglikRefKodlar["KULLANILAN_HELA_TIPI"][i % 3],
            YATAGA_BAGIMLILIK = evdeSaglikRefKodlar["YATAGA_BAGIMLILIK"][i % 3],
            KULLANDIGI_YARDIMCI_ARACLAR = evdeSaglikRefKodlar["KULLANDIGI_YARDIMCI_ARACLAR"][i % 4],
            PSIKOLOJIK_DURUM_DEGERLENDIRME = evdeSaglikRefKodlar["PSIKOLOJIK_DURUM_DEGERLENDIRME"][i % 4],
            ESH_SONLANDIRILMASI = evdeSaglikRefKodlar["ESH_SONLANDIRILMASI"][i % 4],
            ESH_HASTA_NAKLI = evdeSaglikRefKodlar["ESH_HASTA_NAKLI"][i % 3],
            ESH_ALINACAK_IL = evdeSaglikRefKodlar["ESH_ALINACAK_IL"][i % 4],
            BIR_SONRAKI_HIZMET_IHTIYACI = evdeSaglikRefKodlar["BIR_SONRAKI_HIZMET_IHTIYACI"][i % 3],
            VERILEN_EGITIMLER = evdeSaglikRefKodlar["VERILEN_EGITIMLER"][i % 4],
            ACIKLAMA = $"Evde sağlık izlem kaydı {i + 1}"
        }).ToList());

        _logger.LogInformation("İzlem tabloları seeded (BEBEK_COCUK_IZLEM, GEBE_IZLEM, OBEZITE_IZLEM, INTIHAR_IZLEM, KADIN_IZLEM, KUDUZ_IZLEM, LOHUSA_IZLEM, EVDE_SAGLIK_IZLEM)");

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
            var yenidoganIsitmeTaramaRef = new[] { "YAPILDI", "YAPILMADI", "TEKRAR_GEREKLI" };
            var bebekYasamDurumuRef = new[] { "CANLI", "OLUM" };
            var sezaryenEndikasyonRef = new[] { "MUDAHALE_GEREKLI", "FETAL_DISTRES", "MAKAT_GELIS", "PLASENTA_PREVIA" };
            var robsonGrubuRef = new[] { "GRUP_1", "GRUP_2", "GRUP_3", "GRUP_4", "GRUP_5" };

            foreach (var t in yenidoganIsitmeTaramaRef)
                await AddReferansKodIfNotExists("YENIDOGAN_ISITME_TARAMA_DURUMU", t, t, ct);
            foreach (var t in bebekYasamDurumuRef)
                await AddReferansKodIfNotExists("BEBEGIN_YASAM_DURUMU", t, t, ct);
            foreach (var t in sezaryenEndikasyonRef)
                await AddReferansKodIfNotExists("SEZARYEN_ENDIKASYONLAR", t, t, ct);
            foreach (var t in robsonGrubuRef)
                await AddReferansKodIfNotExists("ROBSON_GRUBU", t, t, ct);
            await _db.SaveChangesAsync(ct);

            await SeedIfEmpty<DOGUM_DETAY>(ct, dogumlar.Take(25).Select((d, i) => new DOGUM_DETAY
            {
                DOGUM_DETAY_KODU = $"DGD-{i + 1:D5}",
                REFERANS_TABLO_ADI = "DOGUM_DETAY",
                HASTA_KODU = hastalar[i % hastalar.Count].HASTA_KODU,
                HASTA_BASVURU_KODU = basvurular[i % basvurular.Count].HASTA_BASVURU_KODU,
                DOGUM_KODU = d.DOGUM_KODU,
                DOGUM_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 180)),
                CINSIYET = dogumDetayRef["CINSIYET"][i % 3],
                DOGUM_YONTEMI = dogumDetayRef["DOGUM_YONTEMI"][i % 4],
                AGIRLIK = (2500 + _random.Next(0, 2000)).ToString(),
                BOY = (45 + _random.Next(0, 10)).ToString(),
                BAS_CEVRESI = (32 + _random.Next(0, 8)).ToString(),
                APGAR_1 = (_random.Next(5, 10)).ToString(),
                APGAR_5 = (_random.Next(7, 10)).ToString(),
                APGAR_NOTU = $"Normal APGAR skoru {i + 1}",
                KOMPLIKASYON_TANISI = $"KOMPLIKASYON_TANISI_{komplikasyonRef[i % komplikasyonRef.Length]}",
                DOGUM_SIRASI = (_random.Next(1, 3)).ToString(),
                GOGUS_CEVRESI = (30 + _random.Next(0, 8)).ToString(),
                PROGNOZ_BILGISI = dogumDetayRef["PROGNOZ_BILGISI"][i % 3],
                SURMATURE_BILGISI = dogumDetayRef["SURMATURE_BILGISI"][i % 2],
                K_VITAMINI_UYGULANMA_DURUMU = dogumDetayRef["K_VITAMINI_UYGULANMA_DURUMU"][i % 2],
                BEBEGIN_HEPATIT_ASI_DURUMU = dogumDetayRef["BEBEGIN_HEPATIT_ASI_DURUMU"][i % 3],
                YENIDOGAN_ISITME_TARAMA_DURUMU = yenidoganIsitmeTaramaRef[i % yenidoganIsitmeTaramaRef.Length],
                ILK_BESLENME_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 180)).AddHours(_random.Next(1, 24)),
                TOPUK_KANI = izlemRefKodlar["TOPUK_KANI"][i % 3],
                TOPUK_KANI_ALINMA_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 7)),
                BEBEK_ADI = $"Bebek {i + 1}",
                BABA_TC_KIMLIK_NUMARASI = GenerateTcKimlik(),
                BEBEGIN_YASAM_DURUMU = bebekYasamDurumuRef[i % 2 == 0 ? 0 : 0],
                SEZARYEN_ENDIKASYONLAR = sezaryenEndikasyonRef[i % sezaryenEndikasyonRef.Length],
                ROBSON_GRUBU = robsonGrubuRef[i % robsonGrubuRef.Length]
            }).ToList());
        }

        _logger.LogInformation("Doğum detay tablosu seeded");

        // === NOBETCI_PERSONEL_BILGISI - Nöbetçi Personel Bilgisi ===
        var gorevTuruRef = new[] { "HEKIM", "HEMSIRE", "TEKNISYEN", "SEKRETER" };
        var personelGorevRef = new[] { "NOBET", "ICAP", "MUDAHALE" };
        foreach (var t in gorevTuruRef)
            await AddReferansKodIfNotExists("GOREV_TURU", t, t, ct);
        foreach (var t in personelGorevRef)
            await AddReferansKodIfNotExists("PERSONEL_GOREV_KODU", t, t, ct);
        await _db.SaveChangesAsync(ct);

        await SeedIfEmpty<NOBETCI_PERSONEL_BILGISI>(ct, personeller.Take(25).Select((p, i) => new NOBETCI_PERSONEL_BILGISI
        {
            NOBETCI_PERSONEL_BILGISI_KODU = $"NPB-{i + 1:D5}",
            REFERANS_TABLO_ADI = "NOBETCI_PERSONEL_BILGISI",
            PERSONEL_TC_KIMLIK_NUMARASI = GenerateTcKimlik(),
            KLINIK_KODU = klinikKodlari[i % klinikKodlari.Length],
            GOREV_TURU = gorevTuruRef[i % gorevTuruRef.Length],
            PERSONEL_GOREV_KODU = personelGorevRef[i % personelGorevRef.Length],
            NOBET_BASLANGIC_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 30)),
            NOBET_BITIS_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 30)).AddHours(8),
            TELEFON_NUMARASI = $"05{_random.Next(100000000, 999999999)}"
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
                REFERANS_TABLO_ADI = "VEZNE_DETAY",
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
                REFERANS_TABLO_ADI = "RECETE_ILAC",
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
                REFERANS_TABLO_ADI = "BAKTERI_SONUC",
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
                REFERANS_TABLO_ADI = "ANTIBIYOTIK_SONUC",
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
            REFERANS_TABLO_ADI = "COCUK_DIYABET",
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            ILK_TANI_TARIHI = DateTime.Now.AddYears(-_random.Next(1, 5)),
            AGIRLIK = (20 + _random.Next(0, 30)).ToString(),
            BOY = (100 + _random.Next(0, 60)).ToString(),
            DIYABET_TIPI = cocukDiyabetRef["DIYABET_TIPI"][i % 3],
            KIZ_COCUKLARDA_MENARS_YASI = (11 + _random.Next(0, 4)).ToString(),
            BEYIN_ODEMI_DURUMU = cocukDiyabetRef["BEYIN_ODEMI_DURUMU"][i % 2],
            KETOASIDOZ_DURUMU = cocukDiyabetRef["KETOASIDOZ_DURUMU"][i % 3],
            DIYABET_SIKAYET = cocukDiyabetRef["DIYABET_SIKAYET"][i % 4],
            SIKAYETIN_SURESI = $"{_random.Next(1, 12)} ay",
            AKSILLER_KILLANMA_DURUMU = cocukDiyabetRef["AKSILLER_KILLANMA_DURUMU"][i % 3],
            PUBIK_KILLANMA_DURUMU = cocukDiyabetRef["PUBIK_KILLANMA_DURUMU"][i % 3],
            MEME_EVRE = cocukDiyabetRef["MEME_EVRE"][i % 4],
            TESTIS_VOLUM_SAG = _random.Next(1, 10).ToString(),
            TESTIS_VOLUM_SOL = _random.Next(1, 10).ToString(),
            ESLIKEDEN_HASTALIK = cocukDiyabetRef["ESLIKEDEN_HASTALIK"][i % 4],
            ESLIKEDEN_HASTALIK_TANI_TARIHI = DateTime.Now.AddYears(-_random.Next(1, 3)),
            DIYABET_ILAC_TEDAVI_SEKLI = cocukDiyabetRef["DIYABET_ILAC_TEDAVI_SEKLI"][i % 3],
            DIYET_TIBBI_BESLENME_TEDAVISI = izlemRefKodlar["DIYET_TIBBI_BESLENME_TEDAVISI"][i % 3],
            DIYABETLI_HASTA_AILE_OYKUSU = cocukDiyabetRef["DIYABETLI_HASTA_AILE_OYKUSU"][i % 4],
            DIYABET_EGITIMI_VERILME_DURUMU = cocukDiyabetRef["DIYABET_EGITIMI_VERILME_DURUMU"][i % 2],
            TIROID_MUAYENESI = cocukDiyabetRef["TIROID_MUAYENESI"][i % 2],
            DIYABET_KOMPLIKASYONLARI = cocukDiyabetRef["DIYABET_KOMPLIKASYONLARI"][i % 4]
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
            REFERANS_TABLO_ADI = "HEMOGLOBINOPATI",
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            HEMOGLOBINOPATI_TARAMA_SONUCU = hemoglobinopatiRef["HEMOGLOBINOPATI_TARAMA_SONUCU"][i % 3],
            ES_ADAYI_TC_KIMLIK_NUMARASI = GenerateTcKimlik(),
            ES_ADAYI_TELEFON_NUMARASI = $"05{_random.Next(100000000, 999999999)}",
            HEMOGLOBINOPATI_TESTI_SONUCU = hemoglobinopatiRef["HEMOGLOBINOPATI_TESTI_SONUCU"][i % 3],
            HEMOGLOBINOPATI_ISLEM_TIPI = "EVLILIK_ONCESI",
            HEMOGLOBINOPATI_SONUC_HASTALIK = hemoglobinopatiRef["HEMOGLOBINOPATI_SONUC_HASTALIK"][i % 4],
            HEMOGLOBINOPATI_TASIYICILIK = hemoglobinopatiRef["HEMOGLOBINOPATI_TASIYICILIK"][i % 3]
        }).ToList());
        _logger.LogInformation("HEMOGLOBINOPATI seeded");

        // === HASTA_OLUM - Hasta Ölüm ===
        var olumRef = new Dictionary<string, string[]>
        {
            { "OLUM_YERI", new[] { "HASTANE", "EV", "DIS_MEKAN", "AMBULANS" } },
            { "ANNE_OLUM_NEDENI", new[] { "YOK", "KANAMA", "ENFEKSIYON", "DIGER" } },
            { "OTOPSI_DURUMU", new[] { "YAPILDI", "YAPILMADI", "RED" } },
            { "OLUM_NEDENI_TURU", new[] { "SON_NEDEN", "ARA_NEDEN", "ALTTA_YATAN" } },
            { "OLUM_SEKLI", new[] { "DOGAL", "IS_KAZASI", "TRAFIK", "CINAYET", "INTIHAR" } }
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
            REFERANS_TABLO_ADI = "HASTA_OLUM",
            HASTA_KODU = b.HASTA_KODU,
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            OLUM_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 365)),
            OLUM_YERI = olumRef["OLUM_YERI"][i % 4],
            ANNE_OLUM_NEDENI = olumRef["ANNE_OLUM_NEDENI"][i % 4],
            ACIKLAMA = $"Hasta ölüm kaydı {i + 1}",
            OTOPSI_DURUMU = olumRef["OTOPSI_DURUMU"][i % 3],
            OLUM_BELGESI_PERSONEL_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
            OLUM_NEDENI_TANI_KODU = $"ICD-{_random.Next(100, 999)}",
            OLUM_NEDENI_TURU = olumRef["OLUM_NEDENI_TURU"][i % 3],
            OLUM_SEKLI = olumRef["OLUM_SEKLI"][i % 5],
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
            REFERANS_TABLO_ADI = "HASTA_ADLI_RAPOR",
            HASTA_BASVURU_KODU = b.HASTA_BASVURU_KODU,
            HASTA_KODU = b.HASTA_KODU,
            ADLI_RAPOR_TURU = adliRaporRef["ADLI_RAPOR_TURU"][i % 3],
            RAPOR_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 180)),
            ADLI_MUAYENEYE_GONDEREN_KURUM = "Emniyet Müdürlüğü",
            RESMI_YAZI_NUMARASI = $"RY-{_random.Next(10000, 99999)}",
            RESMI_YAZI_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 180)),
            ADLI_MUAYENE_EDILME_NEDENI = "Darp şüphesi",
            GUVENLIK_SICIL_NUMARASI = $"GS-{_random.Next(1000, 9999)}",
            GUVENLIK_ADI_SOYADI = $"Güvenlik Görevlisi {i + 1}",
            OLAY_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
            ADLI_OLAY_OYKUSU = $"Adli olay öyküsü {i + 1}",
            SIKAYET = "Darp sonrası şikayet",
            OZGECMISI = "Özgeçmiş bilgisi",
            SOYGECMISI = "Soygeçmiş bilgisi",
            MUAYENE_ZAMANI = DateTime.Now.AddDays(-_random.Next(1, 30)),
            HEKIM_KODU = personeller[i % personeller.Count].PERSONEL_KODU,
            TIBBI_MUDAHALE = "Gerekli tıbbi müdahale yapıldı",
            UYGUN_SART_SAGLANMA_DURUMU = "EVET",
            UYGUN_SART_ACIKLAMA = "Muayene koşulları uygun",
            ELBISE_DURUMU = adliRaporRef["ELBISE_DURUMU"][i % 4],
            KONSULTASYON_BILGISI = "Konsültasyon yapıldı",
            LEZYON_BULGULARI = $"Lezyon bulgusu {i + 1}",
            SISTEM_BULGULARI = "Normal",
            BILINC_DURUMU = "Açık",
            PUPILLA_DEGERLENDIRMESI = adliRaporRef["PUPILLA_DEGERLENDIRMESI"][i % 3],
            ISIK_REFLEKSI = adliRaporRef["ISIK_REFLEKSI"][i % 3],
            NABIZ = (60 + _random.Next(0, 40)).ToString(),
            TENDON_REFLEKSI = adliRaporRef["TENDON_REFLEKSI"][i % 3],
            PSIKIYATRIK_MUAYENE = "Normal",
            PSIKIYATRIK_SONUC = "Patoloji yok",
            HIZMET_ACIKLAMA = "Hizmet açıklaması",
            SEVK_DURUMU = "SEVK_YOK",
            SEVK_ACIKLAMA = "Sevk gerekmedi",
            TESLIM_ALAN_ADI_SOYADI = $"Teslim Alan {i + 1}",
            TESLIM_ALAN_TC_KIMLIK_NUMARASI = GenerateTcKimlik(),
            VUCUT_DIYAGRAMI = "Vücut diyagramı bilgisi",
            ACIKLAMA = $"Adli rapor kaydı {i + 1}",
            ADLI_MUAYENE_RIZA_DURUMU = adliRaporRef["ADLI_MUAYENE_RIZA_DURUMU"][i % 3],
            RIZA_VEREN_KISI = $"Rıza Veren {i + 1}",
            RIZA_VERENIN_YAKINLIK_DERECESI = adliRaporRef["RIZA_VERENIN_YAKINLIK_DERECESI"][i % 4],
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
                REFERANS_TABLO_ADI = "HASTA_DIS",
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
                REFERANS_TABLO_ADI = "DIS_TAAHHUT_DETAY",
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
                REFERANS_TABLO_ADI = "DISPROTEZ_DETAY",
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
                REFERANS_TABLO_ADI = "KURUL_ETKEN_MADDE",
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
            REFERANS_TABLO_ADI = "ORTODONTI_ICON_SKOR",
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
            REFERANS_TABLO_ADI = "PERSONEL_BAKMAKLA_YUKUMLU",
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
            REFERANS_TABLO_ADI = "PERSONEL_BORDRO_SONDURUM",
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
            REFERANS_TABLO_ADI = "PERSONEL_IZIN_DURUMU",
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
            REFERANS_TABLO_ADI = "PERSONEL_ODUL_CEZA",
            PERSONEL_KODU = p.PERSONEL_KODU,
            ODUL_CEZA_DURUMU = i % 2 == 0 ? "ODUL" : "CEZA",
            ODUL_CEZA_TURU = odulCezaTuruRef[i % 5],
            CEZA_BASLANGIC_TARIHI = DateTime.Now.AddDays(-_random.Next(30, 365)),
            CEZA_BITIS_TARIHI = DateTime.Now.AddDays(_random.Next(1, 90)),
            ODUL_CEZA_VEREN_KURUM_KODU = kuduzKurumlar.Any() ? kuduzKurumlar[i % kuduzKurumlar.Count].KURUM_KODU : $"KRM-{i + 1:D5}",
            ODUL_CEZA_ACIKLAMA = $"Ödül/Ceza açıklaması {i + 1}",
            TEBLIG_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 30)),
            TEBLIG_EVRAK_TARIHI = DateTime.Now.AddDays(-_random.Next(1, 30)),
            TEBLIG_EVRAK_NUMARASI = $"TEV-{_random.Next(10000, 99999)}"
        }).ToList());

        // PERSONEL_YANDAL
        await SeedIfEmpty<PERSONEL_YANDAL>(ct, personeller.Take(25).Select((p, i) => new PERSONEL_YANDAL
        {
            PERSONEL_YANDAL_KODU = $"PYD-{i + 1:D5}",
            REFERANS_TABLO_ADI = "PERSONEL_YANDAL",
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
                REFERANS_TABLO_ADI = "STERILIZASYON_PAKET_DETAY",
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
                REFERANS_TABLO_ADI = "STERILIZASYON_STOK_DURUM",
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
                REFERANS_TABLO_ADI = "STERILIZASYON_YIKAMA",
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
                REFERANS_TABLO_ADI = "STOK_ISTEK_HAREKET",
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
                REFERANS_TABLO_ADI = "STOK_ISTEK_UYGULAMA",
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
                REFERANS_TABLO_ADI = "STOK_EHU_TAKIP",
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
                REFERANS_TABLO_ADI = "RISK_SKORLAMA_DETAY",
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
            REFERANS_TABLO_ADI = "SYS_PAKET",
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
