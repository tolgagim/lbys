using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Server.Application.Common.Events;
using Server.Application.Common.Interfaces;
using Server.Domain.Lbys;
using Server.Infrastructure.Persistence.Configuration;

namespace Server.Infrastructure.Persistence.Context;

public class ApplicationDbContext : BaseDbContext
{
    public ApplicationDbContext(DbContextOptions options, ICurrentUser currentUser, ISerializerService serializer, IOptions<DatabaseSettings> dbSettings, IEventPublisher events)
        : base(options, currentUser, serializer, dbSettings, events)
    {
    }

    #region VEM Core Entities
    public DbSet<REFERANS_KODLAR> ReferansKodlar => Set<REFERANS_KODLAR>();
    public DbSet<KURUM> Kurum => Set<KURUM>();
    public DbSet<BIRIM> Birim => Set<BIRIM>();
    public DbSet<PERSONEL> Personel => Set<PERSONEL>();
    public DbSet<KULLANICI> Kullanici => Set<KULLANICI>();
    public DbSet<KULLANICI_GRUP> KullaniciGrup => Set<KULLANICI_GRUP>();
    public DbSet<GRUP_UYELIK> GrupUyelik => Set<GRUP_UYELIK>();
    public DbSet<BINA> Bina => Set<BINA>();
    public DbSet<ODA> Oda => Set<ODA>();
    public DbSet<YATAK> Yatak => Set<YATAK>();
    public DbSet<CIHAZ> Cihaz => Set<CIHAZ>();
    public DbSet<FIRMA> Firma => Set<FIRMA>();
    #endregion

    #region Hasta Yonetimi
    public DbSet<HASTA> Hasta => Set<HASTA>();
    public DbSet<HASTA_BASVURU> HastaBasvuru => Set<HASTA_BASVURU>();
    public DbSet<HASTA_HIZMET> HastaHizmet => Set<HASTA_HIZMET>();
    public DbSet<HASTA_YATAK> HastaYatak => Set<HASTA_YATAK>();
    public DbSet<BASVURU_TANI> BasvuruTani => Set<BASVURU_TANI>();
    public DbSet<BASVURU_YEMEK> BasvuruYemek => Set<BASVURU_YEMEK>();
    public DbSet<RANDEVU> Randevu => Set<RANDEVU>();
    public DbSet<ANLIK_YATAN_HASTA> AnlikYatanHasta => Set<ANLIK_YATAN_HASTA>();
    public DbSet<HASTA_ADLI_RAPOR> HastaAdliRapor => Set<HASTA_ADLI_RAPOR>();
    public DbSet<HASTA_ARSIV> HastaArsiv => Set<HASTA_ARSIV>();
    public DbSet<HASTA_ARSIV_DETAY> HastaArsivDetay => Set<HASTA_ARSIV_DETAY>();
    public DbSet<HASTA_BORC> HastaBorc => Set<HASTA_BORC>();
    public DbSet<HASTA_DIS> HastaDis => Set<HASTA_DIS>();
    public DbSet<HASTA_EPIKRIZ> HastaEpikriz => Set<HASTA_EPIKRIZ>();
    public DbSet<HASTA_FOTOGRAF> HastaFotograf => Set<HASTA_FOTOGRAF>();
    public DbSet<HASTA_GIZLILIK> HastaGizlilik => Set<HASTA_GIZLILIK>();
    public DbSet<HASTA_ILETISIM> HastaIletisim => Set<HASTA_ILETISIM>();
    public DbSet<HASTA_MALZEME> HastaMalzeme => Set<HASTA_MALZEME>();
    public DbSet<HASTA_NOTLARI> HastaNotlari => Set<HASTA_NOTLARI>();
    public DbSet<HASTA_OLUM> HastaOlum => Set<HASTA_OLUM>();
    public DbSet<HASTA_SEANS> HastaSeans => Set<HASTA_SEANS>();
    public DbSet<HASTA_SEVK> HastaSevk => Set<HASTA_SEVK>();
    public DbSet<HASTA_TIBBI_BILGI> HastaTibbiBilgi => Set<HASTA_TIBBI_BILGI>();
    public DbSet<HASTA_UYARI> HastaUyari => Set<HASTA_UYARI>();
    public DbSet<HASTA_VENTILATOR> HastaVentilator => Set<HASTA_VENTILATOR>();
    public DbSet<HASTA_VITAL_FIZIKI_BULGU> HastaVitalFizikiBulgu => Set<HASTA_VITAL_FIZIKI_BULGU>();
    #endregion

    #region Ameliyat Cerrahi
    public DbSet<AMELIYAT> Ameliyat => Set<AMELIYAT>();
    public DbSet<AMELIYAT_EKIP> AmeliyatEkip => Set<AMELIYAT_EKIP>();
    public DbSet<AMELIYAT_ISLEM> AmeliyatIslem => Set<AMELIYAT_ISLEM>();
    #endregion

    #region Tibbi Kayit
    public DbSet<TIBBI_ORDER> TibbiOrder => Set<TIBBI_ORDER>();
    public DbSet<TIBBI_ORDER_DETAY> TibbiOrderDetay => Set<TIBBI_ORDER_DETAY>();
    public DbSet<KLINIK_SEYIR> KlinikSeyir => Set<KLINIK_SEYIR>();
    public DbSet<KONSULTASYON> Konsultasyon => Set<KONSULTASYON>();
    public DbSet<HEMSIRE_BAKIM> HemsireBakim => Set<HEMSIRE_BAKIM>();
    public DbSet<DOKTOR_MESAJI> DoktorMesaji => Set<DOKTOR_MESAJI>();
    #endregion

    #region Eczane Ilac
    public DbSet<RECETE> Recete => Set<RECETE>();
    public DbSet<RECETE_ILAC> ReceteIlac => Set<RECETE_ILAC>();
    public DbSet<RECETE_ILAC_ACIKLAMA> ReceteIlacAciklama => Set<RECETE_ILAC_ACIKLAMA>();
    public DbSet<ILAC_UYUM> IlacUyum => Set<ILAC_UYUM>();
    public DbSet<OPTIK_RECETE> OptikRecete => Set<OPTIK_RECETE>();
    #endregion

    #region Laboratuvar Tetkik
    public DbSet<TETKIK> Tetkik => Set<TETKIK>();
    public DbSet<TETKIK_NUMUNE> TetkikNumune => Set<TETKIK_NUMUNE>();
    public DbSet<TETKIK_PARAMETRE> TetkikParametre => Set<TETKIK_PARAMETRE>();
    public DbSet<TETKIK_SONUC> TetkikSonuc => Set<TETKIK_SONUC>();
    public DbSet<TETKIK_CIHAZ_ESLESME> TetkikCihazEslesme => Set<TETKIK_CIHAZ_ESLESME>();
    public DbSet<TETKIK_REFERANS_ARALIK> TetkikReferansAralik => Set<TETKIK_REFERANS_ARALIK>();
    public DbSet<BAKTERI_SONUC> BakteriSonuc => Set<BAKTERI_SONUC>();
    public DbSet<ANTIBIYOTIK_SONUC> AntibiyotikSonuc => Set<ANTIBIYOTIK_SONUC>();
    public DbSet<PATOLOJI> Patoloji => Set<PATOLOJI>();
    #endregion

    #region Radyoloji
    public DbSet<RADYOLOJI> Radyoloji => Set<RADYOLOJI>();
    public DbSet<RADYOLOJI_SONUC> RadyolojiSonuc => Set<RADYOLOJI_SONUC>();
    #endregion

    #region Kan Merkezi
    public DbSet<KAN_BAGISCI> KanBagisci => Set<KAN_BAGISCI>();
    public DbSet<KAN_STOK> KanStok => Set<KAN_STOK>();
    public DbSet<KAN_TALEP> KanTalep => Set<KAN_TALEP>();
    public DbSet<KAN_TALEP_DETAY> KanTalepDetay => Set<KAN_TALEP_DETAY>();
    public DbSet<KAN_URUN> KanUrun => Set<KAN_URUN>();
    public DbSet<KAN_CIKIS> KanCikis => Set<KAN_CIKIS>();
    public DbSet<KAN_URUN_IMHA> KanUrunImha => Set<KAN_URUN_IMHA>();
    #endregion

    #region Stok Malzeme
    public DbSet<HIZMET> Hizmet => Set<HIZMET>();
    public DbSet<DEPO> Depo => Set<DEPO>();
    public DbSet<STOK_KART> StokKart => Set<STOK_KART>();
    public DbSet<STOK_FIS> StokFis => Set<STOK_FIS>();
    public DbSet<STOK_HAREKET> StokHareket => Set<STOK_HAREKET>();
    public DbSet<STOK_DURUM> StokDurum => Set<STOK_DURUM>();
    public DbSet<STOK_ISTEK> StokIstek => Set<STOK_ISTEK>();
    public DbSet<STOK_ISTEK_HAREKET> StokIstekHareket => Set<STOK_ISTEK_HAREKET>();
    public DbSet<STOK_ISTEK_UYGULAMA> StokIstekUygulama => Set<STOK_ISTEK_UYGULAMA>();
    public DbSet<STOK_EHU_TAKIP> StokEhuTakip => Set<STOK_EHU_TAKIP>();
    #endregion

    #region Faturalama Finans
    public DbSet<ICMAL> Icmal => Set<ICMAL>();
    public DbSet<FATURA> Fatura => Set<FATURA>();
    public DbSet<VEZNE> Vezne => Set<VEZNE>();
    public DbSet<VEZNE_DETAY> VezneDetay => Set<VEZNE_DETAY>();
    public DbSet<MEDULA_TAKIP> MedulaTakip => Set<MEDULA_TAKIP>();
    public DbSet<EK_ODEME> EkOdeme => Set<EK_ODEME>();
    public DbSet<EK_ODEME_DETAY> EkOdemeDetay => Set<EK_ODEME_DETAY>();
    public DbSet<EK_ODEME_DONEM> EkOdemeDonem => Set<EK_ODEME_DONEM>();
    #endregion

    #region Personel Yonetimi
    public DbSet<PERSONEL_BAKMAKLA_YUKUMLU> PersonelBakmaklaYukumlu => Set<PERSONEL_BAKMAKLA_YUKUMLU>();
    public DbSet<PERSONEL_BANKA> PersonelBanka => Set<PERSONEL_BANKA>();
    public DbSet<PERSONEL_BORDRO> PersonelBordro => Set<PERSONEL_BORDRO>();
    public DbSet<PERSONEL_BORDRO_SONDURUM> PersonelBordroSondurum => Set<PERSONEL_BORDRO_SONDURUM>();
    public DbSet<PERSONEL_EGITIM> PersonelEgitim => Set<PERSONEL_EGITIM>();
    public DbSet<PERSONEL_GOREVLENDIRME> PersonelGorevlendirme => Set<PERSONEL_GOREVLENDIRME>();
    public DbSet<PERSONEL_IZIN> PersonelIzin => Set<PERSONEL_IZIN>();
    public DbSet<PERSONEL_IZIN_DURUMU> PersonelIzinDurumu => Set<PERSONEL_IZIN_DURUMU>();
    public DbSet<PERSONEL_ODUL_CEZA> PersonelOdulCeza => Set<PERSONEL_ODUL_CEZA>();
    public DbSet<PERSONEL_OGRENIM> PersonelOgrenim => Set<PERSONEL_OGRENIM>();
    public DbSet<PERSONEL_YANDAL> PersonelYandal => Set<PERSONEL_YANDAL>();
    public DbSet<NOBETCI_PERSONEL_BILGISI> NobetciPersonelBilgisi => Set<NOBETCI_PERSONEL_BILGISI>();
    #endregion

    #region Dis Hekimligi
    public DbSet<DIS_TAAHHUT> DisTaahhut => Set<DIS_TAAHHUT>();
    public DbSet<DIS_TAAHHUT_DETAY> DisTaahhutDetay => Set<DIS_TAAHHUT_DETAY>();
    public DbSet<DISPROTEZ> Disprotez => Set<DISPROTEZ>();
    public DbSet<DISPROTEZ_DETAY> DisprotezDetay => Set<DISPROTEZ_DETAY>();
    public DbSet<ORTODONTI_ICON_SKOR> OrtodontiIconSkor => Set<ORTODONTI_ICON_SKOR>();
    #endregion

    #region Dogum Kadin
    public DbSet<DOGUM> Dogum => Set<DOGUM>();
    public DbSet<DOGUM_DETAY> DogumDetay => Set<DOGUM_DETAY>();
    public DbSet<GEBE_IZLEM> GebeIzlem => Set<GEBE_IZLEM>();
    public DbSet<LOHUSA_IZLEM> LohusaIzlem => Set<LOHUSA_IZLEM>();
    public DbSet<KADIN_IZLEM> KadinIzlem => Set<KADIN_IZLEM>();
    #endregion

    #region Cocuk Sagligi
    public DbSet<BEBEK_COCUK_IZLEM> BebekCocukIzlem => Set<BEBEK_COCUK_IZLEM>();
    public DbSet<COCUK_DIYABET> CocukDiyabet => Set<COCUK_DIYABET>();
    public DbSet<HEMOGLOBINOPATI> Hemoglobinopati => Set<HEMOGLOBINOPATI>();
    #endregion

    #region Kronik Hastalik
    public DbSet<DIYABET> Diyabet => Set<DIYABET>();
    public DbSet<OBEZITE_IZLEM> ObeziteIzlem => Set<OBEZITE_IZLEM>();
    public DbSet<EVDE_SAGLIK_IZLEM> EvdeSaglikIzlem => Set<EVDE_SAGLIK_IZLEM>();
    #endregion

    #region Sterilizasyon
    public DbSet<STERILIZASYON_SET> SterilizasyonSet => Set<STERILIZASYON_SET>();
    public DbSet<STERILIZASYON_SET_DETAY> SterilizasyonSetDetay => Set<STERILIZASYON_SET_DETAY>();
    public DbSet<STERILIZASYON_PAKET> SterilizasyonPaket => Set<STERILIZASYON_PAKET>();
    public DbSet<STERILIZASYON_PAKET_DETAY> SterilizasyonPaketDetay => Set<STERILIZASYON_PAKET_DETAY>();
    public DbSet<STERILIZASYON_GIRIS> SterilizasyonGiris => Set<STERILIZASYON_GIRIS>();
    public DbSet<STERILIZASYON_CIKIS> SterilizasyonCikis => Set<STERILIZASYON_CIKIS>();
    public DbSet<STERILIZASYON_YIKAMA> SterilizasyonYikama => Set<STERILIZASYON_YIKAMA>();
    public DbSet<STERILIZASYON_STOK_DURUM> SterilizasyonStokDurum => Set<STERILIZASYON_STOK_DURUM>();
    #endregion

    #region Kurul Rapor
    public DbSet<KURUL> Kurul => Set<KURUL>();
    public DbSet<KURUL_RAPOR> KurulRapor => Set<KURUL_RAPOR>();
    public DbSet<KURUL_ASKERI> KurulAskeri => Set<KURUL_ASKERI>();
    public DbSet<KURUL_ENGELLI> KurulEngelli => Set<KURUL_ENGELLI>();
    public DbSet<KURUL_ETKEN_MADDE> KurulEtkenMadde => Set<KURUL_ETKEN_MADDE>();
    public DbSet<KURUL_HEKIM> KurulHekim => Set<KURUL_HEKIM>();
    public DbSet<KURUL_TESHIS> KurulTeshis => Set<KURUL_TESHIS>();
    public DbSet<RISK_SKORLAMA> RiskSkorlama => Set<RISK_SKORLAMA>();
    public DbSet<RISK_SKORLAMA_DETAY> RiskSkorlamaDetay => Set<RISK_SKORLAMA_DETAY>();
    #endregion

    #region Ozel Izlem
    public DbSet<ASI_BILGISI> AsiBilgisi => Set<ASI_BILGISI>();
    public DbSet<GETAT> Getat => Set<GETAT>();
    public DbSet<INTIHAR_IZLEM> IntiharIzlem => Set<INTIHAR_IZLEM>();
    public DbSet<KUDUZ_IZLEM> KuduzIzlem => Set<KUDUZ_IZLEM>();
    public DbSet<MADDE_BAGIMLILIGI> MaddeBagimliligi => Set<MADDE_BAGIMLILIGI>();
    public DbSet<BILDIRIMI_ZORUNLU> BildirimiZorunlu => Set<BILDIRIMI_ZORUNLU>();
    #endregion

    #region Sistem
    public DbSet<SYS_PAKET> SysPaket => Set<SYS_PAKET>();
    public DbSet<SILINEN_KAYITLAR> SilinenKayitlar => Set<SILINEN_KAYITLAR>();
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(SchemaNames.Lbys);

        // Disable cascade delete for all foreign keys to avoid cycles
        foreach (var relationship in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        // VEM Core
        modelBuilder.Entity<REFERANS_KODLAR>().HasKey(e => e.REFERANS_KODU);
        modelBuilder.Entity<KURUM>().HasKey(e => e.KURUM_KODU);
        modelBuilder.Entity<BIRIM>().HasKey(e => e.BIRIM_KODU);
        modelBuilder.Entity<PERSONEL>().HasKey(e => e.PERSONEL_KODU);
        modelBuilder.Entity<KULLANICI>().HasKey(e => e.KULLANICI_KODU);
        modelBuilder.Entity<KULLANICI_GRUP>().HasKey(e => e.KULLANICI_GRUP_KODU);
        modelBuilder.Entity<GRUP_UYELIK>().HasKey(e => e.GRUP_UYELIK_KODU);
        modelBuilder.Entity<BINA>().HasKey(e => e.BINA_KODU);
        modelBuilder.Entity<ODA>().HasKey(e => e.ODA_KODU);
        modelBuilder.Entity<YATAK>().HasKey(e => e.YATAK_KODU);
        modelBuilder.Entity<CIHAZ>().HasKey(e => e.CIHAZ_KODU);
        modelBuilder.Entity<FIRMA>().HasKey(e => e.FIRMA_KODU);

        // Hasta Yonetimi
        modelBuilder.Entity<HASTA>().HasKey(e => e.HASTA_KODU);
        modelBuilder.Entity<HASTA_BASVURU>().HasKey(e => e.HASTA_BASVURU_KODU);
        modelBuilder.Entity<HASTA_HIZMET>().HasKey(e => e.HASTA_HIZMET_KODU);
        modelBuilder.Entity<HASTA_YATAK>().HasKey(e => e.HASTA_YATAK_KODU);
        modelBuilder.Entity<BASVURU_TANI>().HasKey(e => e.BASVURU_TANI_KODU);
        modelBuilder.Entity<BASVURU_YEMEK>().HasKey(e => e.BASVURU_YEMEK_KODU);
        modelBuilder.Entity<RANDEVU>().HasKey(e => e.RANDEVU_KODU);
        modelBuilder.Entity<ANLIK_YATAN_HASTA>().HasKey(e => e.ANLIK_YATAN_HASTA_KODU);
        modelBuilder.Entity<HASTA_ADLI_RAPOR>().HasKey(e => e.HASTA_ADLI_RAPOR_KODU);
        modelBuilder.Entity<HASTA_ARSIV>().HasKey(e => e.HASTA_ARSIV_KODU);
        modelBuilder.Entity<HASTA_ARSIV_DETAY>().HasKey(e => e.HASTA_ARSIV_DETAY_KODU);
        modelBuilder.Entity<HASTA_BORC>().HasKey(e => e.HASTA_BORC_KODU);
        modelBuilder.Entity<HASTA_DIS>().HasKey(e => e.HASTA_DIS_KODU);
        modelBuilder.Entity<HASTA_EPIKRIZ>().HasKey(e => e.HASTA_EPIKRIZ_KODU);
        modelBuilder.Entity<HASTA_FOTOGRAF>().HasKey(e => e.HASTA_FOTOGRAF_KODU);
        modelBuilder.Entity<HASTA_GIZLILIK>().HasKey(e => e.HASTA_GIZLILIK_KODU);
        modelBuilder.Entity<HASTA_ILETISIM>().HasKey(e => e.HASTA_ILETISIM_KODU);
        modelBuilder.Entity<HASTA_MALZEME>().HasKey(e => e.HASTA_MALZEME_KODU);
        modelBuilder.Entity<HASTA_NOTLARI>().HasKey(e => e.HASTA_NOTLARI_KODU);
        modelBuilder.Entity<HASTA_OLUM>().HasKey(e => e.HASTA_OLUM_KODU);
        modelBuilder.Entity<HASTA_SEANS>().HasKey(e => e.HASTA_SEANS_KODU);
        modelBuilder.Entity<HASTA_SEVK>().HasKey(e => e.HASTA_SEVK_KODU);
        modelBuilder.Entity<HASTA_TIBBI_BILGI>().HasKey(e => e.HASTA_TIBBI_BILGI_KODU);
        modelBuilder.Entity<HASTA_UYARI>().HasKey(e => e.HASTA_UYARI_KODU);
        modelBuilder.Entity<HASTA_VENTILATOR>().HasKey(e => e.HASTA_VENTILATOR_KODU);
        modelBuilder.Entity<HASTA_VITAL_FIZIKI_BULGU>().HasKey(e => e.HASTA_VITAL_FIZIKI_BULGU_KODU);

        // Ameliyat Cerrahi
        modelBuilder.Entity<AMELIYAT>().HasKey(e => e.AMELIYAT_KODU);
        modelBuilder.Entity<AMELIYAT_EKIP>().HasKey(e => e.AMELIYAT_EKIP_KODU);
        modelBuilder.Entity<AMELIYAT_ISLEM>().HasKey(e => e.AMELIYAT_ISLEM_KODU);

        // Tibbi Kayit
        modelBuilder.Entity<TIBBI_ORDER>().HasKey(e => e.TIBBI_ORDER_KODU);
        modelBuilder.Entity<TIBBI_ORDER_DETAY>().HasKey(e => e.TIBBI_ORDER_DETAY_KODU);
        modelBuilder.Entity<KLINIK_SEYIR>().HasKey(e => e.KLINIK_SEYIR_KODU);
        modelBuilder.Entity<KONSULTASYON>().HasKey(e => e.KONSULTASYON_KODU);
        modelBuilder.Entity<HEMSIRE_BAKIM>().HasKey(e => e.HEMSIRE_BAKIM_KODU);
        modelBuilder.Entity<DOKTOR_MESAJI>().HasKey(e => e.DOKTOR_MESAJI_KODU);

        // Eczane Ilac
        modelBuilder.Entity<RECETE>().HasKey(e => e.RECETE_KODU);
        modelBuilder.Entity<RECETE_ILAC>().HasKey(e => e.RECETE_ILAC_KODU);
        modelBuilder.Entity<RECETE_ILAC_ACIKLAMA>().HasKey(e => e.RECETE_ILAC_ACIKLAMA_KODU);
        modelBuilder.Entity<ILAC_UYUM>().HasKey(e => e.ILAC_UYUM_KODU);
        modelBuilder.Entity<OPTIK_RECETE>().HasKey(e => e.OPTIK_RECETE_KODU);

        // Laboratuvar Tetkik
        modelBuilder.Entity<TETKIK>().HasKey(e => e.TETKIK_KODU);
        modelBuilder.Entity<TETKIK_NUMUNE>().HasKey(e => e.TETKIK_NUMUNE_KODU);
        modelBuilder.Entity<TETKIK_PARAMETRE>().HasKey(e => e.TETKIK_PARAMETRE_KODU);
        modelBuilder.Entity<TETKIK_SONUC>().HasKey(e => e.TETKIK_SONUC_KODU);
        modelBuilder.Entity<TETKIK_CIHAZ_ESLESME>().HasKey(e => e.TETKIK_CIHAZ_ESLESME_KODU);
        modelBuilder.Entity<TETKIK_REFERANS_ARALIK>().HasKey(e => e.TETKIK_REFERANS_ARALIK_KODU);
        modelBuilder.Entity<BAKTERI_SONUC>().HasKey(e => e.BAKTERI_SONUC_KODU);
        modelBuilder.Entity<ANTIBIYOTIK_SONUC>().HasKey(e => e.ANTIBIYOTIK_SONUC_KODU);
        modelBuilder.Entity<PATOLOJI>().HasKey(e => e.PATOLOJI_KODU);

        // Radyoloji
        modelBuilder.Entity<RADYOLOJI>().HasKey(e => e.RADYOLOJI_KODU);
        modelBuilder.Entity<RADYOLOJI_SONUC>().HasKey(e => e.RADYOLOJI_SONUC_KODU);

        // Kan Merkezi
        modelBuilder.Entity<KAN_BAGISCI>().HasKey(e => e.KAN_BAGISCI_KODU);
        modelBuilder.Entity<KAN_STOK>().HasKey(e => e.KAN_STOK_KODU);
        modelBuilder.Entity<KAN_TALEP>().HasKey(e => e.KAN_TALEP_KODU);
        modelBuilder.Entity<KAN_TALEP_DETAY>().HasKey(e => e.KAN_TALEP_DETAY_KODU);
        modelBuilder.Entity<KAN_URUN>().HasKey(e => e.KAN_URUN_KODU);
        modelBuilder.Entity<KAN_CIKIS>().HasKey(e => e.KAN_CIKIS_KODU);
        modelBuilder.Entity<KAN_URUN_IMHA>().HasKey(e => e.KAN_URUN_IMHA_KODU);

        // Stok Malzeme
        modelBuilder.Entity<HIZMET>().HasKey(e => e.HIZMET_KODU);
        modelBuilder.Entity<DEPO>().HasKey(e => e.DEPO_KODU);
        modelBuilder.Entity<STOK_KART>().HasKey(e => e.STOK_KART_KODU);
        modelBuilder.Entity<STOK_FIS>().HasKey(e => e.STOK_FIS_KODU);
        modelBuilder.Entity<STOK_HAREKET>().HasKey(e => e.STOK_HAREKET_KODU);
        modelBuilder.Entity<STOK_DURUM>().HasKey(e => e.STOK_DURUM_KODU);
        modelBuilder.Entity<STOK_ISTEK>().HasKey(e => e.STOK_ISTEK_KODU);
        modelBuilder.Entity<STOK_ISTEK_HAREKET>().HasKey(e => e.STOK_ISTEK_HAREKET_KODU);
        modelBuilder.Entity<STOK_ISTEK_UYGULAMA>().HasKey(e => e.STOK_ISTEK_UYGULAMA_KODU);
        modelBuilder.Entity<STOK_EHU_TAKIP>().HasKey(e => e.STOK_EHU_TAKIP_KODU);

        // Faturalama Finans
        modelBuilder.Entity<ICMAL>().HasKey(e => e.ICMAL_KODU);
        modelBuilder.Entity<FATURA>().HasKey(e => e.FATURA_KODU);
        modelBuilder.Entity<VEZNE>().HasKey(e => e.VEZNE_KODU);
        modelBuilder.Entity<VEZNE_DETAY>().HasKey(e => e.VEZNE_DETAY_KODU);
        modelBuilder.Entity<MEDULA_TAKIP>().HasKey(e => e.MEDULA_TAKIP_KODU);
        modelBuilder.Entity<EK_ODEME>().HasKey(e => e.EK_ODEME_KODU);
        modelBuilder.Entity<EK_ODEME_DETAY>().HasKey(e => e.EK_ODEME_DETAY_KODU);
        modelBuilder.Entity<EK_ODEME_DONEM>().HasKey(e => e.EK_ODEME_DONEM_KODU);

        // Personel Yonetimi
        modelBuilder.Entity<PERSONEL_BAKMAKLA_YUKUMLU>().HasKey(e => e.PERSONEL_BAKMAKLA_YUKUMLU_KODU);
        modelBuilder.Entity<PERSONEL_BANKA>().HasKey(e => e.PERSONEL_BANKA_KODU);
        modelBuilder.Entity<PERSONEL_BORDRO>().HasKey(e => e.PERSONEL_BORDRO_KODU);
        modelBuilder.Entity<PERSONEL_BORDRO_SONDURUM>().HasKey(e => e.PERSONEL_SONDURUM_KODU);
        modelBuilder.Entity<PERSONEL_EGITIM>().HasKey(e => e.PERSONEL_EGITIM_KODU);
        modelBuilder.Entity<PERSONEL_GOREVLENDIRME>().HasKey(e => e.PERSONEL_GOREVLENDIRME_KODU);
        modelBuilder.Entity<PERSONEL_IZIN>().HasKey(e => e.PERSONEL_IZIN_KODU);
        modelBuilder.Entity<PERSONEL_IZIN_DURUMU>().HasKey(e => e.PERSONEL_IZIN_DURUMU_KODU);
        modelBuilder.Entity<PERSONEL_ODUL_CEZA>().HasKey(e => e.PERSONEL_ODUL_CEZA_KODU);
        modelBuilder.Entity<PERSONEL_OGRENIM>().HasKey(e => e.PERSONEL_OGRENIM_KODU);
        modelBuilder.Entity<PERSONEL_YANDAL>().HasKey(e => e.PERSONEL_YANDAL_KODU);
        modelBuilder.Entity<NOBETCI_PERSONEL_BILGISI>().HasKey(e => e.NOBETCI_PERSONEL_BILGISI_KODU);

        // Dis Hekimligi
        modelBuilder.Entity<DIS_TAAHHUT>().HasKey(e => e.DIS_TAAHHUT_KODU);
        modelBuilder.Entity<DIS_TAAHHUT_DETAY>().HasKey(e => e.DIS_TAAHHUT_DETAY_KODU);
        modelBuilder.Entity<DISPROTEZ>().HasKey(e => e.DISPROTEZ_KODU);
        modelBuilder.Entity<DISPROTEZ_DETAY>().HasKey(e => e.DISPROTEZ_DETAY_KODU);
        modelBuilder.Entity<ORTODONTI_ICON_SKOR>().HasKey(e => e.ORTODONTI_ICON_SKOR_KODU);

        // Dogum Kadin
        modelBuilder.Entity<DOGUM>().HasKey(e => e.DOGUM_KODU);
        modelBuilder.Entity<DOGUM_DETAY>().HasKey(e => e.DOGUM_DETAY_KODU);
        modelBuilder.Entity<GEBE_IZLEM>().HasKey(e => e.GEBE_IZLEM_KODU);
        modelBuilder.Entity<LOHUSA_IZLEM>().HasKey(e => e.LOHUSA_IZLEM_KODU);
        modelBuilder.Entity<KADIN_IZLEM>().HasKey(e => e.KADIN_IZLEM_KODU);

        // Cocuk Sagligi
        modelBuilder.Entity<BEBEK_COCUK_IZLEM>().HasKey(e => e.BEBEK_COCUK_IZLEM_KODU);
        modelBuilder.Entity<COCUK_DIYABET>().HasKey(e => e.COCUK_DIYABET_KODU);
        modelBuilder.Entity<HEMOGLOBINOPATI>().HasKey(e => e.HEMOGLOBINOPATI_KODU);

        // Kronik Hastalik
        modelBuilder.Entity<DIYABET>().HasKey(e => e.DIYABET_KODU);
        modelBuilder.Entity<OBEZITE_IZLEM>().HasKey(e => e.OBEZITE_IZLEM_KODU);
        modelBuilder.Entity<EVDE_SAGLIK_IZLEM>().HasKey(e => e.EVDE_SAGLIK_IZLEM_KODU);

        // Sterilizasyon
        modelBuilder.Entity<STERILIZASYON_SET>().HasKey(e => e.STERILIZASYON_SET_KODU);
        modelBuilder.Entity<STERILIZASYON_SET_DETAY>().HasKey(e => e.STERILIZASYON_SET_DETAY_KODU);
        modelBuilder.Entity<STERILIZASYON_PAKET>().HasKey(e => e.STERILIZASYON_PAKET_KODU);
        modelBuilder.Entity<STERILIZASYON_PAKET_DETAY>().HasKey(e => e.STERILIZASYON_PAKET_DETAY_KODU);
        modelBuilder.Entity<STERILIZASYON_GIRIS>().HasKey(e => e.STERILIZASYON_GIRIS_KODU);
        modelBuilder.Entity<STERILIZASYON_CIKIS>().HasKey(e => e.STERILIZASYON_CIKIS_KODU);
        modelBuilder.Entity<STERILIZASYON_YIKAMA>().HasKey(e => e.STERILIZASYON_YIKAMA_KODU);
        modelBuilder.Entity<STERILIZASYON_STOK_DURUM>().HasKey(e => e.STERILIZASYON_STOK_DURUM_KODU);

        // Kurul Rapor
        modelBuilder.Entity<KURUL>().HasKey(e => e.KURUL_KODU);
        modelBuilder.Entity<KURUL_RAPOR>().HasKey(e => e.KURUL_RAPOR_KODU);
        modelBuilder.Entity<KURUL_ASKERI>().HasKey(e => e.KURUL_ASKERI_KODU);
        modelBuilder.Entity<KURUL_ENGELLI>().HasKey(e => e.KURUL_ENGELLI_KODU);
        modelBuilder.Entity<KURUL_ETKEN_MADDE>().HasKey(e => e.KURUL_ETKEN_MADDE_KODU);
        modelBuilder.Entity<KURUL_HEKIM>().HasKey(e => e.KURUL_HEKIM_KODU);
        modelBuilder.Entity<KURUL_TESHIS>().HasKey(e => e.KURUL_TESHIS_KODU);
        modelBuilder.Entity<RISK_SKORLAMA>().HasKey(e => e.RISK_SKORLAMA_KODU);
        modelBuilder.Entity<RISK_SKORLAMA_DETAY>().HasKey(e => e.RISK_SKORLAMA_DETAY_KODU);

        // Ozel Izlem
        modelBuilder.Entity<ASI_BILGISI>().HasKey(e => e.ASI_BILGISI_KODU);
        modelBuilder.Entity<GETAT>().HasKey(e => e.GETAT_KODU);
        modelBuilder.Entity<INTIHAR_IZLEM>().HasKey(e => e.INTIHAR_IZLEM_KODU);
        modelBuilder.Entity<KUDUZ_IZLEM>().HasKey(e => e.KUDUZ_IZLEM_KODU);
        modelBuilder.Entity<MADDE_BAGIMLILIGI>().HasKey(e => e.MADDE_BAGIMLILIGI_KODU);
        modelBuilder.Entity<BILDIRIMI_ZORUNLU>().HasKey(e => e.BILDIRIMI_ZORUNLU_KODU);

        // Sistem
        modelBuilder.Entity<SYS_PAKET>().HasKey(e => e.SYS_PAKET_KODU);
        modelBuilder.Entity<SILINEN_KAYITLAR>().HasKey(e => e.SILINEN_KAYITLAR_KODU);
    }
}
