using Microsoft.EntityFrameworkCore;
using Lbys.Entities;

namespace Lbys.Data;

/// <summary>
/// VEM 2.0 Veritabani Context
/// 141 Tablo, 3892 Kolon
/// </summary>
public class VemDbContext : DbContext
{
    public VemDbContext(DbContextOptions<VemDbContext> options) : base(options) { }

    #region DbSets
    public DbSet<AMELIYAT> AMELIYAT { get; set; }
    public DbSet<AMELIYAT_EKIP> AMELIYAT_EKIP { get; set; }
    public DbSet<AMELIYAT_ISLEM> AMELIYAT_ISLEM { get; set; }
    public DbSet<ANLIK_YATAN_HASTA> ANLIK_YATAN_HASTA { get; set; }
    public DbSet<ANTIBIYOTIK_SONUC> ANTIBIYOTIK_SONUC { get; set; }
    public DbSet<ASI_BILGISI> ASI_BILGISI { get; set; }
    public DbSet<BAKTERI_SONUC> BAKTERI_SONUC { get; set; }
    public DbSet<BASVURU_TANI> BASVURU_TANI { get; set; }
    public DbSet<BASVURU_YEMEK> BASVURU_YEMEK { get; set; }
    public DbSet<BEBEK_COCUK_IZLEM> BEBEK_COCUK_IZLEM { get; set; }
    public DbSet<BILDIRIMI_ZORUNLU> BILDIRIMI_ZORUNLU { get; set; }
    public DbSet<BINA> BINA { get; set; }
    public DbSet<BIRIM> BIRIM { get; set; }
    public DbSet<CIHAZ> CIHAZ { get; set; }
    public DbSet<COCUK_DIYABET> COCUK_DIYABET { get; set; }
    public DbSet<DEPO> DEPO { get; set; }
    public DbSet<DISPROTEZ> DISPROTEZ { get; set; }
    public DbSet<DISPROTEZ_DETAY> DISPROTEZ_DETAY { get; set; }
    public DbSet<DIS_TAAHHUT> DIS_TAAHHUT { get; set; }
    public DbSet<DIS_TAAHHUT_DETAY> DIS_TAAHHUT_DETAY { get; set; }
    public DbSet<DIYABET> DIYABET { get; set; }
    public DbSet<DOGUM> DOGUM { get; set; }
    public DbSet<DOGUM_DETAY> DOGUM_DETAY { get; set; }
    public DbSet<DOKTOR_MESAJI> DOKTOR_MESAJI { get; set; }
    public DbSet<EK_ODEME> EK_ODEME { get; set; }
    public DbSet<EK_ODEME_DETAY> EK_ODEME_DETAY { get; set; }
    public DbSet<EK_ODEME_DONEM> EK_ODEME_DONEM { get; set; }
    public DbSet<EVDE_SAGLIK_IZLEM> EVDE_SAGLIK_IZLEM { get; set; }
    public DbSet<FATURA> FATURA { get; set; }
    public DbSet<FIRMA> FIRMA { get; set; }
    public DbSet<GEBE_IZLEM> GEBE_IZLEM { get; set; }
    public DbSet<GETAT> GETAT { get; set; }
    public DbSet<GRUP_UYELIK> GRUP_UYELIK { get; set; }
    public DbSet<HASTA> HASTA { get; set; }
    public DbSet<HASTA_ADLI_RAPOR> HASTA_ADLI_RAPOR { get; set; }
    public DbSet<HASTA_ARSIV> HASTA_ARSIV { get; set; }
    public DbSet<HASTA_ARSIV_DETAY> HASTA_ARSIV_DETAY { get; set; }
    public DbSet<HASTA_BASVURU> HASTA_BASVURU { get; set; }
    public DbSet<HASTA_BORC> HASTA_BORC { get; set; }
    public DbSet<HASTA_DIS> HASTA_DIS { get; set; }
    public DbSet<HASTA_EPIKRIZ> HASTA_EPIKRIZ { get; set; }
    public DbSet<HASTA_FOTOGRAF> HASTA_FOTOGRAF { get; set; }
    public DbSet<HASTA_GIZLILIK> HASTA_GIZLILIK { get; set; }
    public DbSet<HASTA_HIZMET> HASTA_HIZMET { get; set; }
    public DbSet<HASTA_ILETISIM> HASTA_ILETISIM { get; set; }
    public DbSet<HASTA_MALZEME> HASTA_MALZEME { get; set; }
    public DbSet<HASTA_NOTLARI> HASTA_NOTLARI { get; set; }
    public DbSet<HASTA_OLUM> HASTA_OLUM { get; set; }
    public DbSet<HASTA_SEANS> HASTA_SEANS { get; set; }
    public DbSet<HASTA_SEVK> HASTA_SEVK { get; set; }
    public DbSet<HASTA_TIBBI_BILGI> HASTA_TIBBI_BILGI { get; set; }
    public DbSet<HASTA_UYARI> HASTA_UYARI { get; set; }
    public DbSet<HASTA_VENTILATOR> HASTA_VENTILATOR { get; set; }
    public DbSet<HASTA_VITAL_FIZIKI_BULGU> HASTA_VITAL_FIZIKI_BULGU { get; set; }
    public DbSet<HASTA_YATAK> HASTA_YATAK { get; set; }
    public DbSet<HEMOGLOBINOPATI> HEMOGLOBINOPATI { get; set; }
    public DbSet<HEMSIRE_BAKIM> HEMSIRE_BAKIM { get; set; }
    public DbSet<HIZMET> HIZMET { get; set; }
    public DbSet<ICMAL> ICMAL { get; set; }
    public DbSet<ILAC_UYUM> ILAC_UYUM { get; set; }
    public DbSet<INTIHAR_IZLEM> INTIHAR_IZLEM { get; set; }
    public DbSet<KADIN_IZLEM> KADIN_IZLEM { get; set; }
    public DbSet<KAN_BAGISCI> KAN_BAGISCI { get; set; }
    public DbSet<KAN_CIKIS> KAN_CIKIS { get; set; }
    public DbSet<KAN_STOK> KAN_STOK { get; set; }
    public DbSet<KAN_TALEP> KAN_TALEP { get; set; }
    public DbSet<KAN_TALEP_DETAY> KAN_TALEP_DETAY { get; set; }
    public DbSet<KAN_URUN> KAN_URUN { get; set; }
    public DbSet<KAN_URUN_IMHA> KAN_URUN_IMHA { get; set; }
    public DbSet<KLINIK_SEYIR> KLINIK_SEYIR { get; set; }
    public DbSet<KONSULTASYON> KONSULTASYON { get; set; }
    public DbSet<KUDUZ_IZLEM> KUDUZ_IZLEM { get; set; }
    public DbSet<KULLANICI> KULLANICI { get; set; }
    public DbSet<KULLANICI_GRUP> KULLANICI_GRUP { get; set; }
    public DbSet<KURUL> KURUL { get; set; }
    public DbSet<KURUL_ASKERI> KURUL_ASKERI { get; set; }
    public DbSet<KURUL_ENGELLI> KURUL_ENGELLI { get; set; }
    public DbSet<KURUL_ETKEN_MADDE> KURUL_ETKEN_MADDE { get; set; }
    public DbSet<KURUL_HEKIM> KURUL_HEKIM { get; set; }
    public DbSet<KURUL_RAPOR> KURUL_RAPOR { get; set; }
    public DbSet<KURUL_TESHIS> KURUL_TESHIS { get; set; }
    public DbSet<KURUM> KURUM { get; set; }
    public DbSet<LOHUSA_IZLEM> LOHUSA_IZLEM { get; set; }
    public DbSet<MADDE_BAGIMLILIGI> MADDE_BAGIMLILIGI { get; set; }
    public DbSet<MEDULA_TAKIP> MEDULA_TAKIP { get; set; }
    public DbSet<NOBETCI_PERSONEL_BILGISI> NOBETCI_PERSONEL_BILGISI { get; set; }
    public DbSet<OBEZITE_IZLEM> OBEZITE_IZLEM { get; set; }
    public DbSet<ODA> ODA { get; set; }
    public DbSet<OPTIK_RECETE> OPTIK_RECETE { get; set; }
    public DbSet<ORTODONTI_ICON_SKOR> ORTODONTI_ICON_SKOR { get; set; }
    public DbSet<PATOLOJI> PATOLOJI { get; set; }
    public DbSet<PERSONEL> PERSONEL { get; set; }
    public DbSet<PERSONEL_BAKMAKLA_YUKUMLU> PERSONEL_BAKMAKLA_YUKUMLU { get; set; }
    public DbSet<PERSONEL_BANKA> PERSONEL_BANKA { get; set; }
    public DbSet<PERSONEL_BORDRO> PERSONEL_BORDRO { get; set; }
    public DbSet<PERSONEL_BORDRO_SONDURUM> PERSONEL_BORDRO_SONDURUM { get; set; }
    public DbSet<PERSONEL_EGITIM> PERSONEL_EGITIM { get; set; }
    public DbSet<PERSONEL_GOREVLENDIRME> PERSONEL_GOREVLENDIRME { get; set; }
    public DbSet<PERSONEL_IZIN> PERSONEL_IZIN { get; set; }
    public DbSet<PERSONEL_IZIN_DURUMU> PERSONEL_IZIN_DURUMU { get; set; }
    public DbSet<PERSONEL_ODUL_CEZA> PERSONEL_ODUL_CEZA { get; set; }
    public DbSet<PERSONEL_OGRENIM> PERSONEL_OGRENIM { get; set; }
    public DbSet<PERSONEL_YANDAL> PERSONEL_YANDAL { get; set; }
    public DbSet<RADYOLOJI> RADYOLOJI { get; set; }
    public DbSet<RADYOLOJI_SONUC> RADYOLOJI_SONUC { get; set; }
    public DbSet<RANDEVU> RANDEVU { get; set; }
    public DbSet<RECETE> RECETE { get; set; }
    public DbSet<RECETE_ILAC> RECETE_ILAC { get; set; }
    public DbSet<RECETE_ILAC_ACIKLAMA> RECETE_ILAC_ACIKLAMA { get; set; }
    public DbSet<REFERANS_KODLAR> REFERANS_KODLAR { get; set; }
    public DbSet<RISK_SKORLAMA> RISK_SKORLAMA { get; set; }
    public DbSet<RISK_SKORLAMA_DETAY> RISK_SKORLAMA_DETAY { get; set; }
    public DbSet<SILINEN_KAYITLAR> SILINEN_KAYITLAR { get; set; }
    public DbSet<STERILIZASYON_CIKIS> STERILIZASYON_CIKIS { get; set; }
    public DbSet<STERILIZASYON_GIRIS> STERILIZASYON_GIRIS { get; set; }
    public DbSet<STERILIZASYON_PAKET> STERILIZASYON_PAKET { get; set; }
    public DbSet<STERILIZASYON_PAKET_DETAY> STERILIZASYON_PAKET_DETAY { get; set; }
    public DbSet<STERILIZASYON_SET> STERILIZASYON_SET { get; set; }
    public DbSet<STERILIZASYON_SET_DETAY> STERILIZASYON_SET_DETAY { get; set; }
    public DbSet<STERILIZASYON_STOK_DURUM> STERILIZASYON_STOK_DURUM { get; set; }
    public DbSet<STERILIZASYON_YIKAMA> STERILIZASYON_YIKAMA { get; set; }
    public DbSet<STOK_DURUM> STOK_DURUM { get; set; }
    public DbSet<STOK_EHU_TAKIP> STOK_EHU_TAKIP { get; set; }
    public DbSet<STOK_FIS> STOK_FIS { get; set; }
    public DbSet<STOK_HAREKET> STOK_HAREKET { get; set; }
    public DbSet<STOK_ISTEK> STOK_ISTEK { get; set; }
    public DbSet<STOK_ISTEK_HAREKET> STOK_ISTEK_HAREKET { get; set; }
    public DbSet<STOK_ISTEK_UYGULAMA> STOK_ISTEK_UYGULAMA { get; set; }
    public DbSet<STOK_KART> STOK_KART { get; set; }
    public DbSet<SYS_PAKET> SYS_PAKET { get; set; }
    public DbSet<TETKIK> TETKIK { get; set; }
    public DbSet<TETKIK_CIHAZ_ESLESME> TETKIK_CIHAZ_ESLESME { get; set; }
    public DbSet<TETKIK_NUMUNE> TETKIK_NUMUNE { get; set; }
    public DbSet<TETKIK_PARAMETRE> TETKIK_PARAMETRE { get; set; }
    public DbSet<TETKIK_REFERANS_ARALIK> TETKIK_REFERANS_ARALIK { get; set; }
    public DbSet<TETKIK_SONUC> TETKIK_SONUC { get; set; }
    public DbSet<TIBBI_ORDER> TIBBI_ORDER { get; set; }
    public DbSet<TIBBI_ORDER_DETAY> TIBBI_ORDER_DETAY { get; set; }
    public DbSet<VEZNE> VEZNE { get; set; }
    public DbSet<VEZNE_DETAY> VEZNE_DETAY { get; set; }
    public DbSet<YATAK> YATAK { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Primary Key tanimlamalari
        modelBuilder.Entity<AMELIYAT>().HasKey(e => e.AMELIYAT_KODU);
        modelBuilder.Entity<AMELIYAT_EKIP>().HasKey(e => e.AMELIYAT_EKIP_KODU);
        modelBuilder.Entity<AMELIYAT_ISLEM>().HasKey(e => e.AMELIYAT_ISLEM_KODU);
        modelBuilder.Entity<ANLIK_YATAN_HASTA>().HasKey(e => e.ANLIK_YATAN_HASTA_KODU);
        modelBuilder.Entity<ANTIBIYOTIK_SONUC>().HasKey(e => e.ANTIBIYOTIK_SONUC_KODU);
        modelBuilder.Entity<ASI_BILGISI>().HasKey(e => e.ASI_BILGISI_KODU);
        modelBuilder.Entity<BAKTERI_SONUC>().HasKey(e => e.BAKTERI_SONUC_KODU);
        modelBuilder.Entity<BASVURU_TANI>().HasKey(e => e.BASVURU_TANI_KODU);
        modelBuilder.Entity<BASVURU_YEMEK>().HasKey(e => e.BASVURU_YEMEK_KODU);
        modelBuilder.Entity<BEBEK_COCUK_IZLEM>().HasKey(e => e.BEBEK_COCUK_IZLEM_KODU);
        modelBuilder.Entity<BILDIRIMI_ZORUNLU>().HasKey(e => e.BILDIRIMI_ZORUNLU_KODU);
        modelBuilder.Entity<BINA>().HasKey(e => e.BINA_KODU);
        modelBuilder.Entity<BIRIM>().HasKey(e => e.BIRIM_KODU);
        modelBuilder.Entity<CIHAZ>().HasKey(e => e.CIHAZ_KODU);
        modelBuilder.Entity<COCUK_DIYABET>().HasKey(e => e.COCUK_DIYABET_KODU);
        modelBuilder.Entity<DEPO>().HasKey(e => e.DEPO_KODU);
        modelBuilder.Entity<DISPROTEZ>().HasKey(e => e.DISPROTEZ_KODU);
        modelBuilder.Entity<DISPROTEZ_DETAY>().HasKey(e => e.DISPROTEZ_DETAY_KODU);
        modelBuilder.Entity<DIS_TAAHHUT>().HasKey(e => e.DIS_TAAHHUT_KODU);
        modelBuilder.Entity<DIS_TAAHHUT_DETAY>().HasKey(e => e.DIS_TAAHHUT_DETAY_KODU);
        modelBuilder.Entity<DIYABET>().HasKey(e => e.DIYABET_KODU);
        modelBuilder.Entity<DOGUM>().HasKey(e => e.DOGUM_KODU);
        modelBuilder.Entity<DOGUM_DETAY>().HasKey(e => e.DOGUM_DETAY_KODU);
        modelBuilder.Entity<DOKTOR_MESAJI>().HasKey(e => e.DOKTOR_MESAJI_KODU);
        modelBuilder.Entity<EK_ODEME>().HasKey(e => e.EK_ODEME_KODU);
        modelBuilder.Entity<EK_ODEME_DETAY>().HasKey(e => e.EK_ODEME_DETAY_KODU);
        modelBuilder.Entity<EK_ODEME_DONEM>().HasKey(e => e.EK_ODEME_DONEM_KODU);
        modelBuilder.Entity<EVDE_SAGLIK_IZLEM>().HasKey(e => e.EVDE_SAGLIK_IZLEM_KODU);
        modelBuilder.Entity<FATURA>().HasKey(e => e.FATURA_KODU);
        modelBuilder.Entity<FIRMA>().HasKey(e => e.FIRMA_KODU);
        modelBuilder.Entity<GEBE_IZLEM>().HasKey(e => e.GEBE_IZLEM_KODU);
        modelBuilder.Entity<GETAT>().HasKey(e => e.GETAT_KODU);
        modelBuilder.Entity<GRUP_UYELIK>().HasKey(e => e.GRUP_UYELIK_KODU);
        modelBuilder.Entity<HASTA>().HasKey(e => e.HASTA_KODU);
        modelBuilder.Entity<HASTA_ADLI_RAPOR>().HasKey(e => e.HASTA_ADLI_RAPOR_KODU);
        modelBuilder.Entity<HASTA_ARSIV>().HasKey(e => e.HASTA_ARSIV_KODU);
        modelBuilder.Entity<HASTA_ARSIV_DETAY>().HasKey(e => e.HASTA_ARSIV_DETAY_KODU);
        modelBuilder.Entity<HASTA_BASVURU>().HasKey(e => e.HASTA_BASVURU_KODU);
        modelBuilder.Entity<HASTA_BORC>().HasKey(e => e.HASTA_BORC_KODU);
        modelBuilder.Entity<HASTA_DIS>().HasKey(e => e.HASTA_DIS_KODU);
        modelBuilder.Entity<HASTA_EPIKRIZ>().HasKey(e => e.HASTA_EPIKRIZ_KODU);
        modelBuilder.Entity<HASTA_FOTOGRAF>().HasKey(e => e.HASTA_FOTOGRAF_KODU);
        modelBuilder.Entity<HASTA_GIZLILIK>().HasKey(e => e.HASTA_GIZLILIK_KODU);
        modelBuilder.Entity<HASTA_HIZMET>().HasKey(e => e.HASTA_HIZMET_KODU);
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
        modelBuilder.Entity<HASTA_YATAK>().HasKey(e => e.HASTA_YATAK_KODU);
        modelBuilder.Entity<HEMOGLOBINOPATI>().HasKey(e => e.HEMOGLOBINOPATI_KODU);
        modelBuilder.Entity<HEMSIRE_BAKIM>().HasKey(e => e.HEMSIRE_BAKIM_KODU);
        modelBuilder.Entity<HIZMET>().HasKey(e => e.HIZMET_KODU);
        modelBuilder.Entity<ICMAL>().HasKey(e => e.ICMAL_KODU);
        modelBuilder.Entity<ILAC_UYUM>().HasKey(e => e.ILAC_UYUM_KODU);
        modelBuilder.Entity<INTIHAR_IZLEM>().HasKey(e => e.INTIHAR_IZLEM_KODU);
        modelBuilder.Entity<KADIN_IZLEM>().HasKey(e => e.KADIN_IZLEM_KODU);
        modelBuilder.Entity<KAN_BAGISCI>().HasKey(e => e.KAN_BAGISCI_KODU);
        modelBuilder.Entity<KAN_CIKIS>().HasKey(e => e.KAN_CIKIS_KODU);
        modelBuilder.Entity<KAN_STOK>().HasKey(e => e.KAN_STOK_KODU);
        modelBuilder.Entity<KAN_TALEP>().HasKey(e => e.KAN_TALEP_KODU);
        modelBuilder.Entity<KAN_TALEP_DETAY>().HasKey(e => e.KAN_TALEP_DETAY_KODU);
        modelBuilder.Entity<KAN_URUN>().HasKey(e => e.KAN_URUN_KODU);
        modelBuilder.Entity<KAN_URUN_IMHA>().HasKey(e => e.KAN_URUN_IMHA_KODU);
        modelBuilder.Entity<KLINIK_SEYIR>().HasKey(e => e.KLINIK_SEYIR_KODU);
        modelBuilder.Entity<KONSULTASYON>().HasKey(e => e.KONSULTASYON_KODU);
        modelBuilder.Entity<KUDUZ_IZLEM>().HasKey(e => e.KUDUZ_IZLEM_KODU);
        modelBuilder.Entity<KULLANICI>().HasKey(e => e.KULLANICI_KODU);
        modelBuilder.Entity<KULLANICI_GRUP>().HasKey(e => e.KULLANICI_GRUP_KODU);
        modelBuilder.Entity<KURUL>().HasKey(e => e.KURUL_KODU);
        modelBuilder.Entity<KURUL_ASKERI>().HasKey(e => e.KURUL_ASKERI_KODU);
        modelBuilder.Entity<KURUL_ENGELLI>().HasKey(e => e.KURUL_ENGELLI_KODU);
        modelBuilder.Entity<KURUL_ETKEN_MADDE>().HasKey(e => e.KURUL_ETKEN_MADDE_KODU);
        modelBuilder.Entity<KURUL_HEKIM>().HasKey(e => e.KURUL_HEKIM_KODU);
        modelBuilder.Entity<KURUL_RAPOR>().HasKey(e => e.KURUL_RAPOR_KODU);
        modelBuilder.Entity<KURUL_TESHIS>().HasKey(e => e.KURUL_TESHIS_KODU);
        modelBuilder.Entity<KURUM>().HasKey(e => e.KURUM_KODU);
        modelBuilder.Entity<LOHUSA_IZLEM>().HasKey(e => e.LOHUSA_IZLEM_KODU);
        modelBuilder.Entity<MADDE_BAGIMLILIGI>().HasKey(e => e.MADDE_BAGIMLILIGI_KODU);
        modelBuilder.Entity<MEDULA_TAKIP>().HasKey(e => e.MEDULA_TAKIP_KODU);
        modelBuilder.Entity<NOBETCI_PERSONEL_BILGISI>().HasKey(e => e.NOBETCI_PERSONEL_BILGISI_KODU);
        modelBuilder.Entity<OBEZITE_IZLEM>().HasKey(e => e.OBEZITE_IZLEM_KODU);
        modelBuilder.Entity<ODA>().HasKey(e => e.ODA_KODU);
        modelBuilder.Entity<OPTIK_RECETE>().HasKey(e => e.OPTIK_RECETE_KODU);
        modelBuilder.Entity<ORTODONTI_ICON_SKOR>().HasKey(e => e.ORTODONTI_ICON_SKOR_KODU);
        modelBuilder.Entity<PATOLOJI>().HasKey(e => e.PATOLOJI_KODU);
        modelBuilder.Entity<PERSONEL>().HasKey(e => e.PERSONEL_KODU);
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
        modelBuilder.Entity<RADYOLOJI>().HasKey(e => e.RADYOLOJI_KODU);
        modelBuilder.Entity<RADYOLOJI_SONUC>().HasKey(e => e.RADYOLOJI_SONUC_KODU);
        modelBuilder.Entity<RANDEVU>().HasKey(e => e.RANDEVU_KODU);
        modelBuilder.Entity<RECETE>().HasKey(e => e.RECETE_KODU);
        modelBuilder.Entity<RECETE_ILAC>().HasKey(e => e.RECETE_ILAC_KODU);
        modelBuilder.Entity<RECETE_ILAC_ACIKLAMA>().HasKey(e => e.RECETE_ILAC_ACIKLAMA_KODU);
        modelBuilder.Entity<REFERANS_KODLAR>().HasKey(e => e.REFERANS_KODU);
        modelBuilder.Entity<RISK_SKORLAMA>().HasKey(e => e.RISK_SKORLAMA_KODU);
        modelBuilder.Entity<RISK_SKORLAMA_DETAY>().HasKey(e => e.RISK_SKORLAMA_DETAY_KODU);
        modelBuilder.Entity<SILINEN_KAYITLAR>().HasKey(e => e.SILINEN_KAYITLAR_KODU);
        modelBuilder.Entity<STERILIZASYON_CIKIS>().HasKey(e => e.STERILIZASYON_CIKIS_KODU);
        modelBuilder.Entity<STERILIZASYON_GIRIS>().HasKey(e => e.STERILIZASYON_GIRIS_KODU);
        modelBuilder.Entity<STERILIZASYON_PAKET>().HasKey(e => e.STERILIZASYON_PAKET_KODU);
        modelBuilder.Entity<STERILIZASYON_PAKET_DETAY>().HasKey(e => e.STERILIZASYON_PAKET_DETAY_KODU);
        modelBuilder.Entity<STERILIZASYON_SET>().HasKey(e => e.STERILIZASYON_SET_KODU);
        modelBuilder.Entity<STERILIZASYON_SET_DETAY>().HasKey(e => e.STERILIZASYON_SET_DETAY_KODU);
        modelBuilder.Entity<STERILIZASYON_STOK_DURUM>().HasKey(e => e.STERILIZASYON_STOK_DURUM_KODU);
        modelBuilder.Entity<STERILIZASYON_YIKAMA>().HasKey(e => e.STERILIZASYON_YIKAMA_KODU);
        modelBuilder.Entity<STOK_DURUM>().HasKey(e => e.STOK_DURUM_KODU);
        modelBuilder.Entity<STOK_EHU_TAKIP>().HasKey(e => e.STOK_EHU_TAKIP_KODU);
        modelBuilder.Entity<STOK_FIS>().HasKey(e => e.STOK_FIS_KODU);
        modelBuilder.Entity<STOK_HAREKET>().HasKey(e => e.STOK_HAREKET_KODU);
        modelBuilder.Entity<STOK_ISTEK>().HasKey(e => e.STOK_ISTEK_KODU);
        modelBuilder.Entity<STOK_ISTEK_HAREKET>().HasKey(e => e.STOK_ISTEK_HAREKET_KODU);
        modelBuilder.Entity<STOK_ISTEK_UYGULAMA>().HasKey(e => e.STOK_ISTEK_UYGULAMA_KODU);
        modelBuilder.Entity<STOK_KART>().HasKey(e => e.STOK_KART_KODU);
        modelBuilder.Entity<SYS_PAKET>().HasKey(e => e.SYS_PAKET_KODU);
        modelBuilder.Entity<TETKIK>().HasKey(e => e.TETKIK_KODU);
        modelBuilder.Entity<TETKIK_CIHAZ_ESLESME>().HasKey(e => e.TETKIK_CIHAZ_ESLESME_KODU);
        modelBuilder.Entity<TETKIK_NUMUNE>().HasKey(e => e.TETKIK_NUMUNE_KODU);
        modelBuilder.Entity<TETKIK_PARAMETRE>().HasKey(e => e.TETKIK_PARAMETRE_KODU);
        modelBuilder.Entity<TETKIK_REFERANS_ARALIK>().HasKey(e => e.TETKIK_REFERANS_ARALIK_KODU);
        modelBuilder.Entity<TETKIK_SONUC>().HasKey(e => e.TETKIK_SONUC_KODU);
        modelBuilder.Entity<TIBBI_ORDER>().HasKey(e => e.TIBBI_ORDER_KODU);
        modelBuilder.Entity<TIBBI_ORDER_DETAY>().HasKey(e => e.TIBBI_ORDER_DETAY_KODU);
        modelBuilder.Entity<VEZNE>().HasKey(e => e.VEZNE_KODU);
        modelBuilder.Entity<VEZNE_DETAY>().HasKey(e => e.VEZNE_DETAY_KODU);
        modelBuilder.Entity<YATAK>().HasKey(e => e.YATAK_KODU);
    }
}