using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

#region VEM 2.0 - 141 Tablo Entity Siniflari
// Otomatik olusturuldu - VEM 2.0 Saglik Bakanligi Veri Modeli
// Toplam: 141 Tablo, 3892 Kolon
#endregion

/// <summary>
/// AMELIYAT tablosu - 29 kolon
/// </summary>
[Table("AMELIYAT")]
public class AMELIYAT
{
    /// <summary>Sağlık tesisinde yapılan ameliyatın bilgilerine erişim sağlamak için Sağlık Bilg...</summary>
    [Key]
    public string AMELIYAT_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde yapılan ameliyatın adı bilgisidir.</summary>
    [Required]
    public string AMELIYAT_ADI { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanan cerrahi girişimin bilgisidir.</summary>
    [Required]
    [ForeignKey("AmeliyatTuruNavigation")]
    public string AMELIYAT_TURU { get; set; }
    /// <summary>Sağlık tesisinde yapılan ameliyatın başlama zamanı bilgisidir.</summary>
    public DateTime? AMELIYAT_BASLAMA_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde yapılan ameliyatın bitiş zamanı bilgisidir.</summary>
    public DateTime AMELIYAT_BITIS_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde ameliyathanede bulunan ameliyat masaları tanımları için Sağlık ...</summary>
    [Required]
    [ForeignKey("MasaCihazNavigation")]
    public string MASA_CIHAZ_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan bölümler için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("BirimNavigation")]
    public string BIRIM_KODU { get; set; }
    /// <summary>Sağlık tesisindeki birimlerde hasta bilgilerinin olduğu defter numarası bilgisid...</summary>
    public string DEFTER_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde yapılan ameliyata ilişkin anlık durum bilgisidir.</summary>
    [Required]
    [ForeignKey("AmeliyatDurumuNavigation")]
    public string AMELIYAT_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanan anestezi işleminin tür bilgisidir.</summary>
    [Required]
    [ForeignKey("AnesteziTuruNavigation")]
    public string ANESTEZI_TURU { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanan anestezi işleminin tüm süreçlerine ilişkin an...</summary>
    [Required]
    public string ANESTEZI_NOTU { get; set; }
    /// <summary>Sağlık tesisinde hastaya anestezinin verilmeye başlama zamanı bilgisidir.</summary>
    public DateTime ANESTEZI_BASLAMA_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde hastaya verilen anestezinin kesildiği zamanı bilgisidir.</summary>
    public DateTime ANESTEZI_BITIS_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde yapılan ameliyatın acil, elektif vb. olma durumuna ilişkin bilg...</summary>
    [Required]
    [ForeignKey("AmeliyatTipiNavigation")]
    public string AMELIYAT_TIPI { get; set; }
    /// <summary>Skopi cihazının kullanım süresi bilgisini ifade eder.</summary>
    [Required]
    public string SKOPI_SURESI { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanacak cerrahi işlem öncesinde/sırasında/sonrasınd...</summary>
    [Required]
    [ForeignKey("ProfilaksiPeriyoduNavigation")]
    public string PROFILAKSI_PERIYODU { get; set; }
    /// <summary>Referans kodlar tablosunda kod türü olarak “PROFILAKSI_KODU” alanina karsilik ge...</summary>
    [Required]
    [ForeignKey("ProfilaksiNavigation")]
    public string PROFILAKSI_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? AmeliyatTuruNavigation { get; set; }
    public virtual CIHAZ? MasaCihazNavigation { get; set; }
    public virtual BIRIM? BirimNavigation { get; set; }
    public virtual REFERANS_KODLAR? AmeliyatDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? AnesteziTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? AmeliyatTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? ProfilaksiPeriyoduNavigation { get; set; }
    public virtual REFERANS_KODLAR? ProfilaksiNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// AMELIYAT_EKIP tablosu - 11 kolon
/// </summary>
[Table("AMELIYAT_EKIP")]
public class AMELIYAT_EKIP
{
    /// <summary>Sağlık tesisinde ameliyatı gerçekleştiren ekip (operatör, anestezi uzmanı, hemşi...</summary>
    [Key]
    public string AMELIYAT_EKIP_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde yapılan ameliyatın bilgilerine erişim sağlamak için Sağlık Bilg...</summary>
    [ForeignKey("AmeliyatNavigation")]
    public string AMELIYAT_KODU { get; set; }
    /// <summary>Sağlık tesisinde yapılan ameliyatın işlem bilgilerine erişim sağlamak için Sağlı...</summary>
    [ForeignKey("AmeliyatIslemNavigation")]
    public string AMELIYAT_ISLEM_KODU { get; set; }
    /// <summary>Ameliyatı yapan ekibe (hekim, hemşire, anestezi uzmanı, anestezi teknisyeni vb. ...</summary>
    [Required]
    public string EKIP_NUMARASI { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }
    /// <summary>Ameliyat ekibinde bulunan personelin görevlerine ilişkin bilgiyi ifade eder.</summary>
    [Required]
    [ForeignKey("AmeliyatPersonelGorevNavigation")]
    public string AMELIYAT_PERSONEL_GOREV { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual AMELIYAT? AmeliyatNavigation { get; set; }
    public virtual AMELIYAT_ISLEM? AmeliyatIslemNavigation { get; set; }
    public virtual PERSONEL? PersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? AmeliyatPersonelGorevNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// AMELIYAT_ISLEM tablosu - 21 kolon
/// </summary>
[Table("AMELIYAT_ISLEM")]
public class AMELIYAT_ISLEM
{
    /// <summary>Sağlık tesisinde yapılan ameliyatın işlem bilgilerine erişim sağlamak için Sağlı...</summary>
    [Key]
    public string AMELIYAT_ISLEM_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde yapılan ameliyatın bilgilerine erişim sağlamak için Sağlık Bilg...</summary>
    [ForeignKey("AmeliyatNavigation")]
    public string AMELIYAT_KODU { get; set; }
    /// <summary>Tıbbi İşlemler Listesinde yayımlanan ameliyat grubu bilgisidir. Örneğin A1, A2, ...</summary>
    [Required]
    public string AMELIYAT_GRUBU { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanacak hizmetler için Sağlık Bilgi Yönetim Sistemi...</summary>
    [ForeignKey("HastaHizmetNavigation")]
    public string HASTA_HIZMET_KODU { get; set; }
    /// <summary>Cerrahi uygulama sırasında yapılan kesi sayısı bilgisidir.</summary>
    public string KESI_SAYISI { get; set; }
    /// <summary>Cerrahi uygulama sırasında yapılan kesi için belirlenen oran bilgisidir. Örneğin...</summary>
    [Required]
    [ForeignKey("KesiOraniNavigation")]
    public string KESI_ORANI { get; set; }
    /// <summary>Hastaya uygulanan cerrahi girişimde seans ve kesi arasındaki ilişkiyi ifade eden...</summary>
    [Required]
    [ForeignKey("KesiSeansBilgisiNavigation")]
    public string KESI_SEANS_BILGISI { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanan işlemin vücudun hangi tarafına yapıldığına il...</summary>
    [Required]
    [ForeignKey("TarafBilgisiNavigation")]
    public string TARAF_BILGISI { get; set; }
    /// <summary>Sağlık tesisinde tedavi alan hastaya uygulanan cerrahi girişim sonrasında hastad...</summary>
    [Required]
    public string KOMPLIKASYON { get; set; }
    /// <summary>Sağlık tesisinde yapılan ameliyatın sonuç bilgisini ifade eder.</summary>
    [Required]
    public string AMELIYAT_SONUCU { get; set; }
    /// <summary>Sağlık tesisinde yapılan ameliyatın tüm süreçlerine ilişkin operatör tarafından ...</summary>
    [Required]
    public string AMELIYAT_NOTU { get; set; }
    /// <summary>Sağlık tesisinde ameliyat olacak hastanın ameliyat öncesi fiziki sağlık durumunu...</summary>
    [Required]
    [ForeignKey("AsaSkoruNavigation")]
    public string ASA_SKORU { get; set; }
    /// <summary>Avrupa Kardiyak Operasyonel Risk Değerlendirme Sistemi (EuroSCORE), kalp ameliya...</summary>
    [Required]
    [ForeignKey("EuroscoreNavigation")]
    public string EUROSCORE { get; set; }
    /// <summary>Sağlık hizmetini alan kişinin vücudunda bulunan/oluşan yaraların sınıfına ilişki...</summary>
    [Required]
    [ForeignKey("YaraSinifiNavigation")]
    public string YARA_SINIFI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual AMELIYAT? AmeliyatNavigation { get; set; }
    public virtual HASTA_HIZMET? HastaHizmetNavigation { get; set; }
    public virtual REFERANS_KODLAR? KesiOraniNavigation { get; set; }
    public virtual REFERANS_KODLAR? KesiSeansBilgisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? TarafBilgisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsaSkoruNavigation { get; set; }
    public virtual REFERANS_KODLAR? EuroscoreNavigation { get; set; }
    public virtual REFERANS_KODLAR? YaraSinifiNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// ANLIK_YATAN_HASTA tablosu - 10 kolon
/// </summary>
[Table("ANLIK_YATAN_HASTA")]
public class ANLIK_YATAN_HASTA
{
    /// <summary>Sağlık tesisinde anlık yatan hastaların bilgisine erişim sağlamak için Sağlık Bi...</summary>
    [Key]
    public string ANLIK_YATAN_HASTA_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde görevli hekim için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }
    /// <summary>Hasta yatış işlemi yapılırken Sağlık Bilgi Yönetim Sistemi tarafından online pro...</summary>
    public string YATIS_PROTOKOL_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde bulunan bölümler için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("BirimNavigation")]
    public string BIRIM_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi tarafından sağlık tesisindeki yataklar için üretile...</summary>
    [Required]
    [ForeignKey("YatakNavigation")]
    public string YATAK_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan oda için Sağlık Bilgi Yönetim Sistemi tarafından üretil...</summary>
    [Required]
    [ForeignKey("OdaNavigation")]
    public string ODA_KODU { get; set; }
    /// <summary>Hastanın sağlık tesisinde yatağa yattığı zaman bilgisidir.</summary>
    public DateTime? YATIS_ZAMANI { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual BIRIM? BirimNavigation { get; set; }
    public virtual YATAK? YatakNavigation { get; set; }
    public virtual ODA? OdaNavigation { get; set; }
    #endregion
}

/// <summary>
/// ANTIBIYOTIK_SONUC tablosu - 12 kolon
/// </summary>
[Table("ANTIBIYOTIK_SONUC")]
public class ANTIBIYOTIK_SONUC
{
    /// <summary>Sağlık tesisinde laboratuvarda hastadan alınan materyallerde antibiyotik direnç ...</summary>
    [Key]
    public string ANTIBIYOTIK_SONUC_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde laboratuvarda yapılan testler sonucunda numunede üreyen bakteri...</summary>
    [ForeignKey("BakteriSonucNavigation")]
    public string BAKTERI_SONUC_KODU { get; set; }
    /// <summary>Penisilin, amikasin, gentamisin vb. antibiyotikler için Sağlık Bilgi Yönetim Sis...</summary>
    [ForeignKey("AntibiyotikNavigation")]
    public string ANTIBIYOTIK_KODU { get; set; }
    /// <summary>Sağlık tesisinde yapılan tetkiklerin sonuç bilgisidir.</summary>
    [ForeignKey("TetkikSonucuNavigation")]
    public string TETKIK_SONUCU { get; set; }
    /// <summary>Disk etrafında bakterinin üremediği bölgenin milimetrik olarak çap bilgisidir.</summary>
    [Required]
    public string ZON_CAPI { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Hastaya verilen tetkik sonuç raporunda tetkik, parametre, antibiyotik vb. sonucu...</summary>
    public string RAPORDA_GORULME_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual BAKTERI_SONUC? BakteriSonucNavigation { get; set; }
    public virtual REFERANS_KODLAR? AntibiyotikNavigation { get; set; }
    public virtual REFERANS_KODLAR? TetkikSonucuNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// ASI_BILGISI tablosu - 27 kolon
/// </summary>
[Table("ASI_BILGISI")]
public class ASI_BILGISI
{
    /// <summary>Sağlık tesisinde aşılar ile ilgili işlemler (yapılan, ertelenen, iptal edilen aş...</summary>
    [Key]
    public string ASI_BILGISI_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı tablo adı bilgisidir.</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Aşı, aktif ve kazanılmış bağışıklığın sağlanması amacı ile canlı veya ölü mikroo...</summary>
    [ForeignKey("AsiNavigation")]
    public string ASI_KODU { get; set; }
    /// <summary>Aşının (antijenin) kaçıncı kez yapıldığını ifade eder.</summary>
    [ForeignKey("AsininDozuNavigation")]
    public string ASININ_DOZU { get; set; }
    /// <summary>Aşının uygulandığı yolu ifade eder.</summary>
    [ForeignKey("AsininUygulamaSekliNavigation")]
    public string ASININ_UYGULAMA_SEKLI { get; set; }
    /// <summary>Aşının uygulandığı anatomik bölgeyi ifade eder.</summary>
    [ForeignKey("AsiUygulamaYeriNavigation")]
    public string ASI_UYGULAMA_YERI { get; set; }
    /// <summary>Sağlık tesisinde kişiye aşı uygulanmadan önce Sağlık Bilgi Yönetim Sistemi taraf...</summary>
    [Required]
    public string ASI_SORGU_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde kayıt altına alınan aşı bilgisinin sağlık tesisinde yapılma bil...</summary>
    [ForeignKey("AsiIslemTuruNavigation")]
    public string ASI_ISLEM_TURU { get; set; }
    /// <summary>Bilgi alınan kişinin ad soyadı bilgisidir.</summary>
    [Required]
    public string BILGI_ALINAN_KISI_AD_SOYADI { get; set; }
    /// <summary>Bilgi alınan kişinin telefon numarası bilgisidir.</summary>
    [Required]
    public string BILGI_ALINAN_KISI_TELEFON { get; set; }
    /// <summary>Aşı yapılma zamanı bilgisidir.</summary>
    public DateTime? ASI_YAPILMA_ZAMANI { get; set; }
    /// <summary>Bir aşı takvime dahil olsa dahi kişinin sağlık sorunlarından dolayı aynı dozun b...</summary>
    [Required]
    [ForeignKey("AsiOzelDurumNedeniNavigation")]
    public string ASI_OZEL_DURUM_NEDENI { get; set; }
    /// <summary>Aşı Sonrası İstenmeyen Etki (ASİE) 'nin başladığı zamanı ifade eder.</summary>
    public DateTime ASIE_ORTAYA_CIKIS_ZAMANI { get; set; }
    /// <summary>Bildirimi Zorunlu Aşı Sonrası İstenmeyen Etki (ASİE) saptanması durumunda bunun ...</summary>
    [Required]
    [ForeignKey("AsieNedenleriNavigation")]
    public string ASIE_NEDENLERI { get; set; }
    /// <summary>Kişinin planlı aşısının kaç gün süre ile ertelendiği bilgisidir.</summary>
    [Required]
    public string ASI_ERTELEME_SURESI { get; set; }
    /// <summary>Aşının ertelenme/iptal edilme durumunu tanımlar. Örneğin ertelendi, iptal edildi...</summary>
    [Required]
    [ForeignKey("AsiYapilmamaDurumuNavigation")]
    public string ASI_YAPILMAMA_DURUMU { get; set; }
    /// <summary>Bebeğe/Çocuğa yapılması gereken ama ertelenen/iptal edilen aşının neden ertelend...</summary>
    [Required]
    [ForeignKey("AsiYapilmamaNedeniNavigation")]
    public string ASI_YAPILMAMA_NEDENI { get; set; }
    /// <summary>Aşının planlanan zamanda yapılmamasına neden olan hastalık bilgisidir.</summary>
    [Required]
    [ForeignKey("AlttaYatanHastalikNavigation")]
    public string ALTTA_YATAN_HASTALIK { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsiNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsininDozuNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsininUygulamaSekliNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsiUygulamaYeriNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsiIslemTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsiOzelDurumNedeniNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsieNedenleriNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsiYapilmamaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsiYapilmamaNedeniNavigation { get; set; }
    public virtual REFERANS_KODLAR? AlttaYatanHastalikNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// BAKTERI_SONUC tablosu - 12 kolon
/// </summary>
[Table("BAKTERI_SONUC")]
public class BAKTERI_SONUC
{
    /// <summary>SBYS tarafından üretilen tekil kod bilgisidir.</summary>
    [Key]
    public string BAKTERI_SONUC_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde yapılan tetkiklerin sonuçları için Sağlık Bilgi Yönetim Sistemi...</summary>
    [ForeignKey("TetkikSonucNavigation")]
    public string TETKIK_SONUC_KODU { get; set; }
    /// <summary>Sağlık tesisinde laboratuvarda yapılan testler sonucunda numunede üreyebilecek b...</summary>
    [ForeignKey("BakteriNavigation")]
    public string BAKTERI_KODU { get; set; }
    /// <summary>Koloni sayısı bilgisidir.</summary>
    [Required]
    public string KOLONI_SAYISI { get; set; }
    /// <summary>Hastaya verilen tetkik sonuç raporunda tetkik veya parametrenin bulunduğu sıra b...</summary>
    [Required]
    public string RAPOR_SONUC_SIRASI { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual TETKIK_SONUC? TetkikSonucNavigation { get; set; }
    public virtual REFERANS_KODLAR? BakteriNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// BASVURU_TANI tablosu - 15 kolon
/// </summary>
[Table("BASVURU_TANI")]
public class BASVURU_TANI
{
    /// <summary>Sağlık tesisine başvuran kişinin tanı bilgileri için Sağlık Bilgi Yönetim Sistem...</summary>
    [Key]
    public string BASVURU_TANI_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde hastaya konulan tanı için ICD-10 kodlarından seçilen tanı kodu ...</summary>
    [ForeignKey("TaniNavigation")]
    public string TANI_KODU { get; set; }
    /// <summary>Sağlık tesisinde tanı konulan bir hasta için hekim tarafından seçilen tanı tipi ...</summary>
    [ForeignKey("TaniTuruNavigation")]
    public string TANI_TURU { get; set; }
    /// <summary>Sağlık tesisinde başvuran kişiye hekim tarafından ana tanı konulma durumunu ifad...</summary>
    public string BIRINCIL_TANI { get; set; }
    /// <summary>Sağlık tesisinde hastanın hastalığına ilişkin belirlenen tanının Sağlık Bilgi Yö...</summary>
    public DateTime TANI_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde görevli hekim için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [Required]
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }
    /// <summary>Hastaya sağlık raporu veren kurul için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("KurulRaporNavigation")]
    public string KURUL_RAPOR_KODU { get; set; }
    /// <summary>Sağlık tesisinden başka bir sağlık tesisine sevk edilen hastanın sevk bilgileri ...</summary>
    [Required]
    [ForeignKey("HastaSevkNavigation")]
    public string HASTA_SEVK_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? TaniNavigation { get; set; }
    public virtual REFERANS_KODLAR? TaniTuruNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual KURUL_RAPOR? KurulRaporNavigation { get; set; }
    public virtual HASTA_SEVK? HastaSevkNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// BASVURU_YEMEK tablosu - 12 kolon
/// </summary>
[Table("BASVURU_YEMEK")]
public class BASVURU_YEMEK
{
    /// <summary>Sağlık tesisinde yatan hastaya verilen yemek bilgileri için Sağlık Bilgi Yönetim...</summary>
    [Key]
    public string BASVURU_YEMEK_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı tablo adı bilgisidir.</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde yatan hastaya verilen yemeğin normal yemek, diyet yemeği, diyab...</summary>
    [ForeignKey("YemekTuruNavigation")]
    public string YEMEK_TURU { get; set; }
    /// <summary>Sağlık tesisinde yatan hastalara verilen yemeğin tür bilgisini ifade eder. Örneğ...</summary>
    [ForeignKey("YemekZamaniTuruNavigation")]
    public string YEMEK_ZAMANI_TURU { get; set; }
    /// <summary>Sağlık tesisinde yatan hastaya yemeğin verildiği zaman bilgisidir.</summary>
    public DateTime? YEMEK_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? YemekTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? YemekZamaniTuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// BEBEK_COCUK_IZLEM tablosu - 37 kolon
/// </summary>
[Table("BEBEK_COCUK_IZLEM")]
public class BEBEK_COCUK_IZLEM
{
    /// <summary>Sağlık tesisinde muayene olan bebek ve/veya çocukların izlem bilgileri için Sağl...</summary>
    [Key]
    public string BEBEK_COCUK_IZLEM_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı tablo adı bilgisidir.</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Bebek ve çocuklar için Sağlık Bakanlığı tarafından tanımlanan izlem protokolü ka...</summary>
    [ForeignKey("KacinciIzlemNavigation")]
    public string KACINCI_IZLEM { get; set; }
    /// <summary>İshal tanısı alan 0-59 ay bebek ve çocuklarda Ağızdan Sıvı Tedavisi (AST) bilgis...</summary>
    [Required]
    [ForeignKey("AgizdanSiviTedavisiNavigation")]
    public string AGIZDAN_SIVI_TEDAVISI { get; set; }
    /// <summary>Bebek veya çocuğun baş çevresinin (santimetre cinsinden) ölçüsüdür.</summary>
    [Required]
    public string BAS_CEVRESI { get; set; }
    /// <summary>Gebelikte dışarıdan demir desteği; demirin uygulanmayacağı durumlar hariç, ayrım...</summary>
    [Required]
    [ForeignKey("DemirLojistigiVeDestegiNavigation")]
    public string DEMIR_LOJISTIGI_VE_DESTEGI { get; set; }
    /// <summary>Bebeğin doğum ağırlığını gram olarak ifade eder.</summary>
    [Required]
    public string DOGUM_AGIRLIGI { get; set; }
    /// <summary>Gebeler için; gebeliğin 12. haftasından başlanarak doğumdan sonra 6. ayın sonuna...</summary>
    [Required]
    [ForeignKey("DvitaminiLojistigiVeDestegiNavigation")]
    public string DVITAMINI_LOJISTIGI_VE_DESTEGI { get; set; }
    /// <summary>Gelişimsel Kalça Displazisi (GKD) tarama sonucu bilgisidir.</summary>
    [ForeignKey("GkdTaramaSonucuNavigation")]
    public string GKD_TARAMA_SONUCU { get; set; }
    /// <summary>Bebek veya çocuğun hematokrit değeri bilgisidir.</summary>
    [Required]
    public string HEMATOKRIT_DEGERI { get; set; }
    /// <summary>Kişinin hemoglobin değeri bilgisidir.</summary>
    [Required]
    public string HEMOGLOBIN_DEGERI { get; set; }
    /// <summary>Doğumdan sonraki günlerde bebeğin topuğundan alınan kanın alınma durumunu ifade ...</summary>
    [Required]
    [ForeignKey("TopukKaniNavigation")]
    public string TOPUK_KANI { get; set; }
    /// <summary>Yeni doğan bebeğin topuk kanının alındığı zaman bilgisidir.</summary>
    public DateTime TOPUK_KANI_ALINMA_ZAMANI { get; set; }
    /// <summary>İzlemin yapıldığı kurum bilgisidir.</summary>
    [Required]
    [ForeignKey("IzleminYapildigiYerNavigation")]
    public string IZLEMIN_YAPILDIGI_YER { get; set; }
    /// <summary>Sağlık tesisinde hastaya yapılan izlemleri (bebek çocuk izlem, gebe izlem vb.) y...</summary>
    [Required]
    [ForeignKey("IzlemiYapanPersonelNavigation")]
    public string IZLEMI_YAPAN_PERSONEL_KODU { get; set; }
    /// <summary>Bilgi alınan kişinin ad ve soyadı bilgisidir.</summary>
    [Required]
    public string BILGI_ALINAN_KISI_AD_SOYADI { get; set; }
    /// <summary>Bilgi alınan kişinin telefon bilgisidir.</summary>
    [Required]
    public string BILGI_ALINAN_KISI_TELEFON { get; set; }
    /// <summary>Bebekte yapılan muayene ve risk faktörlerinin belirlenmesi sonucu gelişimsel kal...</summary>
    [Required]
    [ForeignKey("BebekteRiskFaktorleriNavigation")]
    public string BEBEKTE_RISK_FAKTORLERI { get; set; }
    /// <summary>Bebekte yapılan ve bebek sağlığı işlemleri veri elemanında yer alan tarama testl...</summary>
    [Required]
    [ForeignKey("TaramaSonucuNavigation")]
    public string TARAMA_SONUCU { get; set; }
    /// <summary>Bebeğin anne sütünden tamamen kesildiği (ay cinsinden) yaşını ifade eder.</summary>
    [Required]
    public string ANNE_SUTUNDEN_KESILDIGI_AY { get; set; }
    /// <summary>Bebeğin anne sütü ile beslenmesi durumuna ilişkin bilgidir. Örneğin sadece anne ...</summary>
    [Required]
    [ForeignKey("BebeginBeslenmeDurumuNavigation")]
    public string BEBEGIN_BESLENME_DURUMU { get; set; }
    /// <summary>Bebeğin anne sütü dışında gıda almaya başladığı (ay cinsinden) yaşını ifade eder...</summary>
    [Required]
    public string EK_GIDAYA_BASLADIGI_AY { get; set; }
    /// <summary>Bebeğin veya çocuğun anne sütü aldığı sürenin ay cinsinden bilgisini ifade eder.</summary>
    [Required]
    public string SADECE_ANNE_SUTU_ALDIGI_SURE { get; set; }
    /// <summary>Bebeğin/çocuğun gelişim bilgilerinin sorgulanmasıdır.</summary>
    [Required]
    [ForeignKey("GelisimTablosuBilgileriNavigation")]
    public string GELISIM_TABLOSU_BILGILERI { get; set; }
    [Required]
    [ForeignKey("NtpTakipBilgisiNavigation")]
    public string NTP_TAKIP_BILGISI { get; set; }
    /// <summary>0-6 yaş döneminde, bebeğin/çocuğun beyin gelişimini olumsuz yönde etkileyebilece...</summary>
    [Required]
    [ForeignKey("BcBeyinGelisimRiskleriNavigation")]
    public string BC_BEYIN_GELISIM_RISKLERI { get; set; }
    /// <summary>Anne/babanın, bebeğin veya çocuğun psikolojik gelişimini destekleyebilmek amacı ...</summary>
    [Required]
    [ForeignKey("EbeveynDestekAktiviteleriNavigation")]
    public string EBEVEYN_DESTEK_AKTIVITELERI { get; set; }
    /// <summary>Anne karnındaki dönem dahil olmak üzere, çocuğun 0-6 yaş döneminde beyin gelişim...</summary>
    [Required]
    [ForeignKey("BcPsikolojikRiskEgitimNavigation")]
    public string BC_PSIKOLOJIK_RISK_EGITIM { get; set; }
    /// <summary>0-6 yaş döneminde, Bebeğin/Çocuğun beyin gelişimini olumsuz yönde etkileyebilece...</summary>
    [Required]
    [ForeignKey("BcRiskYapilanMudahaleNavigation")]
    public string BC_RISK_YAPILAN_MUDAHALE { get; set; }
    /// <summary>Çocuğun psikolojik gelişiminin risk altında olduğu durumda, sık izleme alınan ol...</summary>
    [Required]
    [ForeignKey("BcRiskliOlguTakibiNavigation")]
    public string BC_RISKLI_OLGU_TAKIBI { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? KacinciIzlemNavigation { get; set; }
    public virtual REFERANS_KODLAR? AgizdanSiviTedavisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DemirLojistigiVeDestegiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DvitaminiLojistigiVeDestegiNavigation { get; set; }
    public virtual REFERANS_KODLAR? GkdTaramaSonucuNavigation { get; set; }
    public virtual REFERANS_KODLAR? TopukKaniNavigation { get; set; }
    public virtual REFERANS_KODLAR? IzleminYapildigiYerNavigation { get; set; }
    public virtual PERSONEL? IzlemiYapanPersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? BebekteRiskFaktorleriNavigation { get; set; }
    public virtual REFERANS_KODLAR? TaramaSonucuNavigation { get; set; }
    public virtual REFERANS_KODLAR? BebeginBeslenmeDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? GelisimTablosuBilgileriNavigation { get; set; }
    public virtual REFERANS_KODLAR? NtpTakipBilgisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? BcBeyinGelisimRiskleriNavigation { get; set; }
    public virtual REFERANS_KODLAR? EbeveynDestekAktiviteleriNavigation { get; set; }
    public virtual REFERANS_KODLAR? BcPsikolojikRiskEgitimNavigation { get; set; }
    public virtual REFERANS_KODLAR? BcRiskYapilanMudahaleNavigation { get; set; }
    public virtual REFERANS_KODLAR? BcRiskliOlguTakibiNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// BILDIRIMI_ZORUNLU tablosu - 53 kolon
/// </summary>
[Table("BILDIRIMI_ZORUNLU")]
public class BILDIRIMI_ZORUNLU
{
    /// <summary>Bildirimi zorunlu hastalık için Sağlık Bilgi Yönetim Sistemi tarafından üretilen...</summary>
    [Key]
    public string BILDIRIMI_ZORUNLU_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Bildirimi zorunlu hastalıklar veya durumlar kapsamında yapılan bildirimin türünü...</summary>
    [ForeignKey("BildirimTuruNavigation")]
    public string BILDIRIM_TURU { get; set; }
    /// <summary>Bildirimi zorunlu hastalığın veya durumların ilgili yerlere bildirildiği zaman b...</summary>
    public DateTime? BILDIRIM_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde hastaya konulan tanı için ICD-10 kodlarından seçilen tanı kodu ...</summary>
    [ForeignKey("TaniNavigation")]
    public string TANI_KODU { get; set; }
    /// <summary>İntihar girişiminde bulunan veya kriz geçiren kişinin aile üyelerinin herhangi b...</summary>
    [Required]
    [ForeignKey("AilesindeIntiharGirisimiNavigation")]
    public string AILESINDE_INTIHAR_GIRISIMI { get; set; }
    /// <summary>İntihar girişiminde bulunan veya kriz geçiren kişinin aile üyelerinin herhangi b...</summary>
    [Required]
    [ForeignKey("AilesindePsikiyatrikVakaNavigation")]
    public string AILESINDE_PSIKIYATRIK_VAKA { get; set; }
    /// <summary>Vakanın intihar vakası ya da kriz vakası olma durumunu ifade eder.</summary>
    [Required]
    [ForeignKey("IntiharKrizVakaTuruNavigation")]
    public string INTIHAR_KRIZ_VAKA_TURU { get; set; }
    /// <summary>Olayın gerçekleştiği zaman bilgisidir.</summary>
    public DateTime OLAY_ZAMANI { get; set; }
    /// <summary>Hastanın acil servise başvuru tarihinden önceki son 6 aylık dönemde psikiyatrik ...</summary>
    [Required]
    [ForeignKey("PsikiyatrikTedaviGecmisiNavigation")]
    public string PSIKIYATRIK_TEDAVI_GECMISI { get; set; }
    /// <summary>Kişinin intihar girişimi ya da kriz nedenlerini ifade eder.</summary>
    [Required]
    [ForeignKey("IntiharGirisimKrizNedenleriNavigation")]
    public string INTIHAR_GIRISIM_KRIZ_NEDENLERI { get; set; }
    /// <summary>Kişinin intihar girişimini gerçekleştirirken kullandığı yöntem/yöntemleri ifade ...</summary>
    [Required]
    [ForeignKey("IntiharGirisimiYontemiNavigation")]
    public string INTIHAR_GIRISIMI_YONTEMI { get; set; }
    /// <summary>Kişinin geçmişinde intihar girişimi olup olmadığı bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("IntiharGirisimiGecmisiNavigation")]
    public string INTIHAR_GIRISIMI_GECMISI { get; set; }
    /// <summary>İntihar girişiminde bulunan ya da kriz geçiren kişiye yapılan müdahalenin nasıl ...</summary>
    [Required]
    [ForeignKey("IntiharKrizVakaSonucuNavigation")]
    public string INTIHAR_KRIZ_VAKA_SONUCU { get; set; }
    /// <summary>Sağlık tesisine adli muayene için getirilmiş kişinin psikiyatrik tanı geçmişi bi...</summary>
    [Required]
    [ForeignKey("PsikiyatrikTaniGecmisiNavigation")]
    public string PSIKIYATRIK_TANI_GECMISI { get; set; }
    /// <summary>Kuduz şüpheli temasa neden olan hayvanın mevcut durumunun ne olduğunu ifade eder...</summary>
    [Required]
    [ForeignKey("HayvaninMevcutDurumuNavigation")]
    public string HAYVANIN_MEVCUT_DURUMU { get; set; }
    /// <summary>Kuduz şüpheli temasa neden olan hayvanın sahiplik durumu bilgisidir.</summary>
    [Required]
    [ForeignKey("HayvaninSahiplikDurumuNavigation")]
    public string HAYVANIN_SAHIPLIK_DURUMU { get; set; }
    /// <summary>Uygulanan immünglobilinin tür bilgisidir. Örneğin at kaynaklı, insan kaynaklı vb...</summary>
    [Required]
    [ForeignKey("ImmunglobulinTuruNavigation")]
    public string IMMUNGLOBULIN_TURU { get; set; }
    /// <summary>Uygulanan immünglobilinin IU cinsinden miktar bilgisidir.</summary>
    [Required]
    public string IMMUNGLOBULIN_MIKTARI { get; set; }
    /// <summary>Kuduz riskli temas sonrası, temas şekline ve temas eden hayvanın durumuna göre p...</summary>
    [Required]
    [ForeignKey("KategorizasyonNavigation")]
    public string KATEGORIZASYON { get; set; }
    /// <summary>Bildirimi zorunlu hastalıklarda hasta için temas olgusunun değerlendirilmesi ile...</summary>
    [Required]
    [ForeignKey("TemasDegerlendirmeDurumuNavigation")]
    public string TEMAS_DEGERLENDIRME_DURUMU { get; set; }
    /// <summary>Kuduz şüpheli temasa sebep olan hayvan türünü ifade eder.</summary>
    [Required]
    [ForeignKey("KuduzSebepOlanHayvanNavigation")]
    public string KUDUZ_SEBEP_OLAN_HAYVAN { get; set; }
    /// <summary>Kişinin kendi sağlığı ile ilgili bir işlem yaptıracağına ilişkin beyan ettiği To...</summary>
    [Required]
    [ForeignKey("YaptiracaginiBeyanEttigiTsmNavigation")]
    public string YAPTIRACAGINI_BEYAN_ETTIGI_TSM { get; set; }
    /// <summary>Riskli temas tipi bilgisini ifade eder. Örneğin hayvana dokunma veya besleme, sa...</summary>
    [Required]
    [ForeignKey("RiskliTemasTipiNavigation")]
    public string RISKLI_TEMAS_TIPI { get; set; }
    /// <summary>Kişinin ev telefonu bilgisidir.</summary>
    [Required]
    public string EV_TELEFONU { get; set; }
    /// <summary>Kişinin cep telefonu bilgisidir.</summary>
    [Required]
    public string CEP_TELEFONU { get; set; }
    /// <summary>Kişinin ev adresi bilgisidir.</summary>
    [Required]
    public string EV_ADRESI { get; set; }
    /// <summary>İl kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("IlNavigation")]
    public string IL_KODU { get; set; }
    /// <summary>İlçe kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("IlceNavigation")]
    public string ILCE_KODU { get; set; }
    /// <summary>Verem hastalığından korunmada kullanılan BCG (Bacille Calmette-Guérin) aşısına a...</summary>
    [Required]
    public string BCG_SKAR_SAYISI { get; set; }
    /// <summary>Doğrudan Gözetimli Tedavi (DGT) uygulamasını yapan, hastanın tedavisi süresince ...</summary>
    [Required]
    [ForeignKey("DgtUygulamasiniYapanKisiNavigation")]
    public string DGT_UYGULAMASINI_YAPAN_KISI { get; set; }
    /// <summary>Kişiye Doğrudan Gözetimli Tedavi (DGT) uygulamasının yapıldığı yeri ifade eder.</summary>
    [Required]
    [ForeignKey("DgtUygulamaYeriNavigation")]
    public string DGT_UYGULAMA_YERI { get; set; }
    /// <summary>Hastanın kendisine uygulanan tedaviye uyum gösterme durumunu ifade eder.</summary>
    [Required]
    [ForeignKey("HastaninTedaviyeUyumuNavigation")]
    public string HASTANIN_TEDAVIYE_UYUMU { get; set; }
    /// <summary>Hastadan alınan numunenin kültür sonucunu ifade eder. Örneğin pozitif, negatif, ...</summary>
    [Required]
    [ForeignKey("KulturSonucuNavigation")]
    public string KULTUR_SONUCU { get; set; }
    /// <summary>Verem şüpheli bireylerde tarama amacıyla kullanılan deri testinin sonucunu tanım...</summary>
    [Required]
    [ForeignKey("TuberkulinDeriTestiSonucuNavigation")]
    public string TUBERKULIN_DERI_TESTI_SONUCU { get; set; }
    /// <summary>Verem hastasının tedavisinde seçilen yöntem bilgisidir. Örneğin doğrudan gözetim...</summary>
    [Required]
    [ForeignKey("VeremHastasiTedaviYontemiNavigation")]
    public string VEREM_HASTASI_TEDAVI_YONTEMI { get; set; }
    /// <summary>Verem tanısı konulan hastada tedavi rejiminin belirlenmesinde ve hastaya yapılac...</summary>
    [Required]
    [ForeignKey("VeremOlguTanimiNavigation")]
    public string VEREM_OLGU_TANIMI { get; set; }
    /// <summary>Kişiden alınan kan, idrar, gaita vb. numuneleri için laboratuvarda yapılan yayma...</summary>
    [Required]
    [ForeignKey("YaymaSonucuNavigation")]
    public string YAYMA_SONUCU { get; set; }
    /// <summary>Verem Hastalığının vücutta yerleştiği organ/sistemi ifade eder. Örneğin akciğer,...</summary>
    [Required]
    [ForeignKey("VeremHastaligiTutulumYeriNavigation")]
    public string VEREM_HASTALIGI_TUTULUM_YERI { get; set; }
    /// <summary>Verem hastalığının teşhisinde yapılan yayma ve kültür için kullanılan hastaya ai...</summary>
    [Required]
    [ForeignKey("VeremHastasiKlinikOrnegiNavigation")]
    public string VEREM_HASTASI_KLINIK_ORNEGI { get; set; }
    /// <summary>Verem hastalığı için duyarlılık testi yapılan ilaç türleridir. Örneğin amikasin,...</summary>
    [Required]
    [ForeignKey("VeremIlacAdiNavigation")]
    public string VEREM_ILAC_ADI { get; set; }
    /// <summary>Verem hastasının tedavi sonucunu ifade eder. Örneğin kür, tedavi tamamlama, ölüm...</summary>
    [Required]
    [ForeignKey("VeremTedaviSonucuNavigation")]
    public string VEREM_TEDAVI_SONUCU { get; set; }
    /// <summary>Bildirimi zorunlu bulaşıcı hastalıkların bildirimi yapılırken teşhis edilen hast...</summary>
    [Required]
    [ForeignKey("BulasiciHastalikVakaTipiNavigation")]
    public string BULASICI_HASTALIK_VAKA_TIPI { get; set; }
    /// <summary>Klinik belirtilerin başladığı tarih bilgisidir.</summary>
    public DateTime BELIRTILERIN_BASLADIGI_TARIH { get; set; }
    /// <summary>Güç ve baskı uygulayarak insanın bedensel ve ruhsal açıdan zarar görmesine neden...</summary>
    [Required]
    [ForeignKey("SiddetTuruNavigation")]
    public string SIDDET_TURU { get; set; }
    /// <summary>Şiddet görmüş hastaya sağlık tesisinde yapılan muayene sonucunu ifade eden bilgi...</summary>
    [Required]
    [ForeignKey("SiddetDegerlendirmeSonucuNavigation")]
    public string SIDDET_DEGERLENDIRME_SONUCU { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? BildirimTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? TaniNavigation { get; set; }
    public virtual REFERANS_KODLAR? AilesindeIntiharGirisimiNavigation { get; set; }
    public virtual REFERANS_KODLAR? AilesindePsikiyatrikVakaNavigation { get; set; }
    public virtual REFERANS_KODLAR? IntiharKrizVakaTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? PsikiyatrikTedaviGecmisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? IntiharGirisimKrizNedenleriNavigation { get; set; }
    public virtual REFERANS_KODLAR? IntiharGirisimiYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? IntiharGirisimiGecmisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? IntiharKrizVakaSonucuNavigation { get; set; }
    public virtual REFERANS_KODLAR? PsikiyatrikTaniGecmisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? HayvaninMevcutDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? HayvaninSahiplikDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? ImmunglobulinTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? KategorizasyonNavigation { get; set; }
    public virtual REFERANS_KODLAR? TemasDegerlendirmeDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? KuduzSebepOlanHayvanNavigation { get; set; }
    public virtual KURUM? YaptiracaginiBeyanEttigiTsmNavigation { get; set; }
    public virtual REFERANS_KODLAR? RiskliTemasTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlceNavigation { get; set; }
    public virtual REFERANS_KODLAR? DgtUygulamasiniYapanKisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DgtUygulamaYeriNavigation { get; set; }
    public virtual REFERANS_KODLAR? HastaninTedaviyeUyumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? KulturSonucuNavigation { get; set; }
    public virtual REFERANS_KODLAR? TuberkulinDeriTestiSonucuNavigation { get; set; }
    public virtual REFERANS_KODLAR? VeremHastasiTedaviYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? VeremOlguTanimiNavigation { get; set; }
    public virtual REFERANS_KODLAR? YaymaSonucuNavigation { get; set; }
    public virtual REFERANS_KODLAR? VeremHastaligiTutulumYeriNavigation { get; set; }
    public virtual REFERANS_KODLAR? VeremHastasiKlinikOrnegiNavigation { get; set; }
    public virtual REFERANS_KODLAR? VeremIlacAdiNavigation { get; set; }
    public virtual REFERANS_KODLAR? VeremTedaviSonucuNavigation { get; set; }
    public virtual REFERANS_KODLAR? BulasiciHastalikVakaTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SiddetTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? SiddetDegerlendirmeSonucuNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// BINA tablosu - 11 kolon
/// </summary>
[Table("BINA")]
public class BINA
{
    /// <summary>Sağlık tesisinin her binası için Sağlık Bilgi Yönetim Sistemi tarafından üretile...</summary>
    [Key]
    public string BINA_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisi binasının ad bilgisidir.</summary>
    public string BINA_ADI { get; set; }
    /// <summary>Sağlık tesisinin adres bilgisidir.</summary>
    [Required]
    public string BINA_ADRESI { get; set; }
    /// <summary>Sağlık Kodlama Referans Sunucusu (SKRS) kod sistemlerinde tanımlanan Kurum Kodu ...</summary>
    [Required]
    [ForeignKey("SkrsKurumNavigation")]
    public string SKRS_KURUM_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual REFERANS_KODLAR? SkrsKurumNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// BIRIM tablosu - 35 kolon
/// </summary>
[Table("BIRIM")]
public class BIRIM
{
    /// <summary>Sağlık tesisinde bulunan bölümler için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Key]
    public string BIRIM_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde bulunan kliniklerin Sağlık Bilgi Yönetim Sistemi tarafından gru...</summary>
    [ForeignKey("KlinikNavigation")]
    public string KLINIK_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan bölümlerin Sağlık Bilgi Yönetim Sistemi tarafından yapı...</summary>
    [ForeignKey("BirimTuruNavigation")]
    public string BIRIM_TURU { get; set; }
    /// <summary>Sağlık tesisinin her binası için Sağlık Bilgi Yönetim Sistemi tarafından üretile...</summary>
    [Required]
    [ForeignKey("BinaNavigation")]
    public string BINA_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan bölümlerin isim bilgisidir. Örneğin poliklinik1, polikl...</summary>
    public string BIRIM_ADI { get; set; }
    /// <summary>Sağlık tesisinde veya sağlık tesisindeki birimlerde bulunan yatak sayısı bilgisi...</summary>
    [Required]
    public string YATAK_SAYISI { get; set; }
    /// <summary>Sağlık tesisinde tanımlanmış muayene eden birimler için MHRS tarafından üretilen...</summary>
    [Required]
    public string MHRS_KODU { get; set; }
    /// <summary>Sağlık tesisinde tanımlı olan poliklinik biriminin MHRS sistemine tanımlanmış ad...</summary>
    [Required]
    public string MHRS_ADI { get; set; }
    /// <summary>Malzeme Kaynak Yönetim Sistemi (MKYS) tarafından depo ve birimler için üretilen ...</summary>
    [Required]
    public string MKYS_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan klinik ve hekimler için MEDULA tarafından tanımlanmış b...</summary>
    [Required]
    public string MEDULA_BRANS_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi veri tabanında bulunan bir kayıtın aktif olup olmad...</summary>
    [Required]
    public string AKTIFLIK_BILGISI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual REFERANS_KODLAR? KlinikNavigation { get; set; }
    public virtual REFERANS_KODLAR? BirimTuruNavigation { get; set; }
    public virtual BINA? BinaNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// CIHAZ tablosu - 26 kolon
/// </summary>
[Table("CIHAZ")]
public class CIHAZ
{
    /// <summary>Sağlık tesisinde bulunan cihaz için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [Key]
    public string CIHAZ_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde bulunan cihaz adı bilgisidir.</summary>
    public string CIHAZ_ADI { get; set; }
    /// <summary>Sağlık tesisinde bulunan cihazları gruplandırmak için Sağlık Bilgi Yönetim Siste...</summary>
    [Required]
    [ForeignKey("CihazGrubuNavigation")]
    public string CIHAZ_GRUBU { get; set; }
    /// <summary>Sağlık tesisinde bulunan bölümler için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("BirimNavigation")]
    public string BIRIM_KODU { get; set; }
    /// <summary>Sağlık tesisinde kullanılan cihazın model bilgisidir.</summary>
    [Required]
    public string CIHAZ_MODELI { get; set; }
    /// <summary>Sağlık tesisinde kullanılan cihazın marka bilgisidir.</summary>
    [Required]
    public string CIHAZ_MARKASI { get; set; }
    /// <summary>Sağlık tesisinde bulunan tıbbi cihazların seri numarası bilgisini ifade eder.</summary>
    [Required]
    public string SERI_NUMARASI { get; set; }
    /// <summary>Malzeme Kaynak Yönetim Sistemi (MKYS) tarafından üretilen cihaz künye numarası b...</summary>
    [Required]
    public string MKYS_KUNYE_NUMARASI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi veri tabanında bulunan bir kayıtın aktif olup olmad...</summary>
    public string AKTIFLIK_BILGISI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual REFERANS_KODLAR? CihazGrubuNavigation { get; set; }
    public virtual BIRIM? BirimNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// COCUK_DIYABET tablosu - 29 kolon
/// </summary>
[Table("COCUK_DIYABET")]
public class COCUK_DIYABET
{
    /// <summary>Sağlık tesisinde bulunan cihaz için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [Key]
    public string COCUK_DIYABET_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Hastaya izlem ve tedavi uygulanacak olan hastalık (diyabetis mellitus, kanser, H...</summary>
    public DateTime? ILK_TANI_TARIHI { get; set; }
    /// <summary>Kişinin (gram cinsinden) ağırlığı bilgisidir.</summary>
    [Required]
    public string AGIRLIK { get; set; }
    /// <summary>Kişinin santimetre cinsinden boy bilgisidir.</summary>
    [Required]
    public string BOY { get; set; }
    /// <summary>Kişinin diyabet tipi bilgisidir.</summary>
    [ForeignKey("DiyabetTipiNavigation")]
    public string DIYABET_TIPI { get; set; }
    /// <summary>Kız çocuğuna ait menarş yaşı bilgisidir.</summary>
    [Required]
    public string KIZ_COCUKLARDA_MENARS_YASI { get; set; }
    /// <summary>Kişide beyin ödemi olup olmadığına ilişkin bilgiyi ifade eder.</summary>
    [ForeignKey("BeyinOdemiDurumuNavigation")]
    public string BEYIN_ODEMI_DURUMU { get; set; }
    /// <summary>Kişide son 3 ay içerisinde ketoasidoz gelişip gelişmediğine ait bilgidir.</summary>
    [ForeignKey("KetoasidozDurumuNavigation")]
    public string KETOASIDOZ_DURUMU { get; set; }
    /// <summary>Çocuğun diyabet hastalığına ilişkin şikayet bilgilerini ifade eder.</summary>
    [Required]
    [ForeignKey("DiyabetSikayetNavigation")]
    public string DIYABET_SIKAYET { get; set; }
    /// <summary>Çocuğun diyabet şikayetlerine ilişkin süre bilgisidir.</summary>
    [Required]
    public string SIKAYETIN_SURESI { get; set; }
    /// <summary>Çocuğun aksiller kıllanmasına ait durum bilgisidir.</summary>
    [Required]
    [ForeignKey("AksillerKillanmaDurumuNavigation")]
    public string AKSILLER_KILLANMA_DURUMU { get; set; }
    /// <summary>Çocuğun pubik kıllanmasına ait durum bilgisidir.</summary>
    [Required]
    [ForeignKey("PubikKillanmaDurumuNavigation")]
    public string PUBIK_KILLANMA_DURUMU { get; set; }
    /// <summary>Çocuğun meme gelişim evresine ait durum bilgisidir.</summary>
    [Required]
    [ForeignKey("MemeEvreNavigation")]
    public string MEME_EVRE { get; set; }
    /// <summary>Sağ testisin ml cinsinden hacim bilgisini ifade eder.</summary>
    [Required]
    public string TESTIS_VOLUM_SAG { get; set; }
    /// <summary>Sol testisin ml cinsinden hacim bilgisini ifade eder.</summary>
    [Required]
    public string TESTIS_VOLUM_SOL { get; set; }
    /// <summary>Çocuğun eşlik eden başka hastalık bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("EslikedenHastalikNavigation")]
    public string ESLIKEDEN_HASTALIK { get; set; }
    /// <summary>Çocuğun eşlik eden başka hastalık tanı tarihi bilgisini ifade eder.</summary>
    public DateTime ESLIKEDEN_HASTALIK_TANI_TARIHI { get; set; }
    /// <summary>Çocuğa uygulanan ilaç tedavi şekline ait bilgiyi ifade eder.</summary>
    [ForeignKey("DiyabetIlacTedaviSekliNavigation")]
    public string DIYABET_ILAC_TEDAVI_SEKLI { get; set; }
    /// <summary>Çocuğun diyet tedavisi durum bilgisini ifade eder.</summary>
    [ForeignKey("DiyetTibbiBeslenmeTedavisiNavigation")]
    public string DIYET_TIBBI_BESLENME_TEDAVISI { get; set; }
    /// <summary>Çocuğun diyabet hastası olan aile bireyi bilgisidir.</summary>
    [ForeignKey("DiyabetliHastaAileOykusuNavigation")]
    public string DIYABETLI_HASTA_AILE_OYKUSU { get; set; }
    /// <summary>Hastaya diyabet eğitim verilip verilmediği bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("DiyabetEgitimiVerilmeDurumuNavigation")]
    public string DIYABET_EGITIMI_VERILME_DURUMU { get; set; }
    /// <summary>Tiroid muayenesi sonucuna ilişkin ait bilgiyi ifade eder.</summary>
    [ForeignKey("TiroidMuayenesiNavigation")]
    public string TIROID_MUAYENESI { get; set; }
    /// <summary>Diyabet hastaliginin mikro ve makrovasküler komplikasyonlarini ifade eder.</summary>
    [Required]
    [ForeignKey("DiyabetKomplikasyonlariNavigation")]
    public string DIYABET_KOMPLIKASYONLARI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyabetTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? BeyinOdemiDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? KetoasidozDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyabetSikayetNavigation { get; set; }
    public virtual REFERANS_KODLAR? AksillerKillanmaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? PubikKillanmaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? MemeEvreNavigation { get; set; }
    public virtual REFERANS_KODLAR? EslikedenHastalikNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyabetIlacTedaviSekliNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyetTibbiBeslenmeTedavisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyabetliHastaAileOykusuNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyabetEgitimiVerilmeDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? TiroidMuayenesiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyabetKomplikasyonlariNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// DEPO tablosu - 22 kolon
/// </summary>
[Table("DEPO")]
public class DEPO
{
    /// <summary>Sağlık tesisinde bulunan stok depoları için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [Key]
    public string DEPO_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde bulunan stok depolarının ad bilgisidir.</summary>
    public string DEPO_ADI { get; set; }
    /// <summary>Sağlık tesisinde bulunan stok depolarını sınıflandırmak için Sağlık Bilgi Yöneti...</summary>
    [ForeignKey("DepoTuruNavigation")]
    public string DEPO_TURU { get; set; }
    /// <summary>Sağlık tesisinin her binası için Sağlık Bilgi Yönetim Sistemi tarafından üretile...</summary>
    [Required]
    [ForeignKey("BinaNavigation")]
    public string BINA_KODU { get; set; }
    /// <summary>Malzeme Kaynak Yönetim Sistemi (MKYS) tarafından depo ve birimler için üretilen ...</summary>
    [Required]
    public string MKYS_KODU { get; set; }
    /// <summary>Malzeme Kaynak Yönetim Sistemi (MKYS) tarafından sistemin kullanıcısı için üreti...</summary>
    [Required]
    public string MKYS_KULLANICI_KODU { get; set; }
    /// <summary>Malzeme Kaynak Yönetim Sistemi (MKYS) tarafından sistemin kullanıcısı için üreti...</summary>
    [Required]
    public string MKYS_KULLANICI_SIFRESI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi veri tabanında bulunan bir kayıtın aktif olup olmad...</summary>
    [Required]
    public string AKTIFLIK_BILGISI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual REFERANS_KODLAR? DepoTuruNavigation { get; set; }
    public virtual BINA? BinaNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// DISPROTEZ tablosu - 29 kolon
/// </summary>
[Table("DISPROTEZ")]
public class DISPROTEZ
{
    /// <summary>Diş protez tedavisi yapılan hastalar için protez bilgilerini kayıt etmek için Sa...</summary>
    [Key]
    public string DISPROTEZ_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisinde başvuran hastaya yapılan diş protezinin başlama tarihini ifade ...</summary>
    public DateTime? DISPROTEZ_BASLAMA_TARIHI { get; set; }
    /// <summary>Sağlık tesisinde görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("TeknisyenNavigation")]
    public string TEKNISYEN_KODU { get; set; }
    /// <summary>Sağlık tesisinde görevli hekim için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan bölümler için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("BirimNavigation")]
    public string BIRIM_KODU { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanan diş protezinin türü için Sağlık Bilgi Yönetim...</summary>
    [ForeignKey("DisprotezIsTuruNavigation")]
    public string DISPROTEZ_IS_TURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanan diş protezi tedavisinin türü ile ilgili Sağlı...</summary>
    [Required]
    [ForeignKey("DisprotezIsTuruAltNavigation")]
    public string DISPROTEZ_IS_TURU_ALT_KODU { get; set; }
    /// <summary>Diş protezi tedavisinde kullanılan parça sayısı bilgisidir. Örneğin hareketli pr...</summary>
    [Required]
    public string PARCA_SAYISI { get; set; }
    /// <summary>Dişe takılan sabit protezlerdeki ayak sayısı bilgisidir.</summary>
    [Required]
    public string DISPROTEZ_AYAK_SAYISI { get; set; }
    /// <summary>Diş tedavisinde kullanılan sabit protezlerdeki gövde sayısı bilgisidir.</summary>
    [Required]
    public string DISPROTEZ_GOVDE_SAYISI { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Diş protezi işleminin sağlık tesisinde yapıldığı birim için Sağlık Bilgi Yönetim...</summary>
    [Required]
    [ForeignKey("DisprotezBirimNavigation")]
    public string DISPROTEZ_BIRIM_KODU { get; set; }
    /// <summary>Gerçekleştirilen iş tekrarlayan bir işlem (RPT) ise tekrarlanma sebebini ifade e...</summary>
    [Required]
    [ForeignKey("RptSebebiNavigation")]
    public string RPT_SEBEBI { get; set; }
    /// <summary>Tekrar edilen işin tekrar zamanını ifade eder.</summary>
    public DateTime RPT_ZAMANI { get; set; }
    /// <summary>RPT işlemini yapan personel için Sağlık Bilgi Yönetim Sistemi tarafından üretile...</summary>
    [Required]
    [ForeignKey("RptEdenPersonelNavigation")]
    public string RPT_EDEN_PERSONEL_KODU { get; set; }
    /// <summary>Barkodun basıldığı zaman bilgisidir.</summary>
    public DateTime BARKOD_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde diş tedavisi alan hasta için kalıbı çıkarılan tedavi bölgesini ...</summary>
    [Required]
    [ForeignKey("DisprotezKasikTuruNavigation")]
    public string DISPROTEZ_KASIK_TURU { get; set; }
    /// <summary>Diş protez tedavisinde kullanılan protez dişin vita skalasına göre değer bilgisi...</summary>
    [Required]
    [ForeignKey("DisprotezRengiNavigation")]
    public string DISPROTEZ_RENGI { get; set; }
    /// <summary>Protezi yapılan dişin boyut bilgisidir. Örneğin küçük, normal, büyük vb.</summary>
    [Required]
    [ForeignKey("DisBoyutBilgisiNavigation")]
    public string DIS_BOYUT_BILGISI { get; set; }
    /// <summary>Sağlık tesisinin hizmet aldığı dış laboratuvarda yapılan diş protezi işlemi için...</summary>
    [Required]
    public string DISPROTEZ_ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual PERSONEL? TeknisyenNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual BIRIM? BirimNavigation { get; set; }
    public virtual REFERANS_KODLAR? DisprotezIsTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? DisprotezIsTuruAltNavigation { get; set; }
    public virtual BIRIM? DisprotezBirimNavigation { get; set; }
    public virtual REFERANS_KODLAR? RptSebebiNavigation { get; set; }
    public virtual PERSONEL? RptEdenPersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? DisprotezKasikTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? DisprotezRengiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DisBoyutBilgisiNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// DISPROTEZ_DETAY tablosu - 21 kolon
/// </summary>
[Table("DISPROTEZ_DETAY")]
public class DISPROTEZ_DETAY
{
    /// <summary>Diş protez tedavisi yapılan hastalar için protez aşamalarına ilişkin detaylı bil...</summary>
    [Key]
    public string DISPROTEZ_DETAY_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Diş protez tedavisi yapılan hastalar için protez bilgilerini kayıt etmek için Sa...</summary>
    [ForeignKey("DisprotezNavigation")]
    public string DISPROTEZ_KODU { get; set; }
    /// <summary>Diş protezi tedavisinin ne zaman uygulanacağına ilişkin planlanan zaman bilgisid...</summary>
    public DateTime? DISPROTEZ_PLANLAMA_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanan diş protezinin aşamalarını belirten Sağlık Bi...</summary>
    [ForeignKey("DisprotezIsTuruAsamaNavigation")]
    public string DISPROTEZ_IS_TURU_ASAMA_KODU { get; set; }
    /// <summary>Hastaya uygulanan protez işleminin ilgili aşamasının tamamlanma zamanı bilgisidi...</summary>
    public DateTime DISPROTEZ_ASAMA_BITIS_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinin mal veya hizmet alımı yaptığı firma için Sağlık Bilgi Yönetim S...</summary>
    [Required]
    [ForeignKey("FirmaNavigation")]
    public string FIRMA_KODU { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanan diş protez tedavisi sürecinde, sağlık tesisi ...</summary>
    public DateTime FIRMA_DISPROTEZ_ALIM_ZAMANI { get; set; }
    /// <summary>Hasta tedavi sürecinde yapılması planlanan tedavi uygulamasının bitirilmesi için...</summary>
    public DateTime PLANLANAN_BITIS_TARIHI { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanan diş protez tedavisi sürecinde, sağlık tesisi ...</summary>
    public DateTime FIRMA_TESLIM_ZAMANI { get; set; }
    /// <summary>Diş protezi aşamaları için sürecin tamamlandığına ilişkin verilen onay zamanı bi...</summary>
    public DateTime DISPROTEZ_ASAMA_ONAY_ZAMANI { get; set; }
    /// <summary>Rise Per Tooth (RPT); Teslim aşamasına gelmiş protezin kabul kriterlerine uymama...</summary>
    [Required]
    public string RPT_ONAY_DURUMU { get; set; }
    /// <summary>Kişi için düzenlenen randevu bilgisi için Sağlık Bilgi Yönetim Sistemi tarafında...</summary>
    [Required]
    [ForeignKey("RandevuNavigation")]
    public string RANDEVU_KODU { get; set; }
    /// <summary>Protez dişin herhangi bir aşamasında kabul kriterlerine uymaması sonucu, protez ...</summary>
    public DateTime ASAMA_RPT_ZAMANI { get; set; }
    /// <summary>Protez dişin herhangi bir aşamasında kabul kriterlerine uymaması bilgisidir. Örn...</summary>
    [Required]
    [ForeignKey("AsamaRptSebebiNavigation")]
    public string ASAMA_RPT_SEBEBI { get; set; }
    /// <summary>Protez dişin herhangi bir aşamasında kabul kriterlerine uymaması sonucu, protez ...</summary>
    [Required]
    [ForeignKey("AsamaRptKullaniciNavigation")]
    public string ASAMA_RPT_KULLANICI_KODU { get; set; }
    /// <summary>Diş protezi tedavisinde hastadan ölçü alınma aşamasında, ölçü döküm zamanı bilgi...</summary>
    public DateTime OLCU_DOKUM_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual DISPROTEZ? DisprotezNavigation { get; set; }
    public virtual REFERANS_KODLAR? DisprotezIsTuruAsamaNavigation { get; set; }
    public virtual FIRMA? FirmaNavigation { get; set; }
    public virtual RANDEVU? RandevuNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsamaRptSebebiNavigation { get; set; }
    public virtual KULLANICI? AsamaRptKullaniciNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// DIS_TAAHHUT tablosu - 23 kolon
/// </summary>
[Table("DIS_TAAHHUT")]
public class DIS_TAAHHUT
{
    /// <summary>Diş tedavisi yapılan hastalar için MEDULA sisteminden alınan taahhüt bilgilerini...</summary>
    [Key]
    public string DIS_TAAHHUT_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisinde görevli hekim için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }
    /// <summary>Sağlık tesisinde işlem yapılacak kişiye ait diş işlemleri için MEDULA sisteminde...</summary>
    [Required]
    public string DIS_TAAHHUT_NUMARASI { get; set; }
    /// <summary>Sağlık tesisine gelen hasta için MEDULA sisteminden Sağlık Bilgi Yönetim Sistemi...</summary>
    public string SGK_TAKIP_NUMARASI { get; set; }
    /// <summary>Kişinin adres bilgisinde bulunan cadde sokak bilgisidir.</summary>
    [Required]
    public string CADDE_SOKAK { get; set; }
    /// <summary>Adresin dış kapı numarası bilgisidir.</summary>
    [Required]
    public string DIS_KAPI_NUMARASI { get; set; }
    /// <summary>Kişinin elektronik posta adresidir.</summary>
    [Required]
    public string EPOSTA_ADRESI { get; set; }
    /// <summary>Adresin iç kapı numarası bilgisidir.</summary>
    [Required]
    public string IC_KAPI_NUMARASI { get; set; }
    /// <summary>İl kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("IlNavigation")]
    public string IL_KODU { get; set; }
    /// <summary>Telefon numarası bilgisini ifade eder.</summary>
    [Required]
    public string TELEFON_NUMARASI { get; set; }
    /// <summary>İlçe kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("IlceNavigation")]
    public string ILCE_KODU { get; set; }
    /// <summary>MEDULA sisteminden web servis aracılığı ile alınan cevapların kod numarası bilgi...</summary>
    [Required]
    public string MEDULA_SONUC_KODU { get; set; }
    /// <summary>MEDULA sisteminden web servis aracılığı ile alınan cevapların metin bilgisidir.</summary>
    [Required]
    public string MEDULA_SONUC_MESAJI { get; set; }
    /// <summary>Sağlık tesisinde yapılan bir işlemin iptal edilip edilmediği bilgisidir.</summary>
    [Required]
    public string IPTAL_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlceNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// DIS_TAAHHUT_DETAY tablosu - 10 kolon
/// </summary>
[Table("DIS_TAAHHUT_DETAY")]
public class DIS_TAAHHUT_DETAY
{
    /// <summary>Diş tedavisi yapılan hastalar için MEDULA sisteminden alınan taahhüte ilişkin de...</summary>
    [Key]
    public string DIS_TAAHHUT_DETAY_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Diş tedavisi yapılan hastalar için MEDULA sisteminden alınan taahhüt bilgilerini...</summary>
    [ForeignKey("DisTaahhutNavigation")]
    public string DIS_TAAHHUT_KODU { get; set; }
    /// <summary>Ağızdaki dişler için Sağlık Bilgi Yönetim Sistemi tarafından verilmiş kod bilgis...</summary>
    [Required]
    [ForeignKey("DisNavigation")]
    public string DIS_KODU { get; set; }
    /// <summary>Sosyal Güvenlik Kurumu tarafından yayımlanan, hastaya uygulanan işlem veya hizme...</summary>
    public string SUT_KODU { get; set; }
    /// <summary>Kişinin diş tedavisi için işlem yapılan çene bölgesi için Sağlık Bilgi Yönetim S...</summary>
    [Required]
    [ForeignKey("CeneNavigation")]
    public string CENE_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual DIS_TAAHHUT? DisTaahhutNavigation { get; set; }
    public virtual REFERANS_KODLAR? DisNavigation { get; set; }
    public virtual REFERANS_KODLAR? CeneNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// DIYABET tablosu - 12 kolon
/// </summary>
[Table("DIYABET")]
public class DIYABET
{
    /// <summary>Sağlık tesisinde bulunan cihaz için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [Key]
    public string DIYABET_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Hastaya izlem ve tedavi uygulanacak olan hastalık (diyabetis mellitus, kanser, H...</summary>
    public DateTime? ILK_TANI_TARIHI { get; set; }
    /// <summary>Kişinin (gram cinsinden) ağırlığı bilgisidir.</summary>
    public string AGIRLIK { get; set; }
    /// <summary>Kişinin santimetre cinsinden boy bilgisidir.</summary>
    public string BOY { get; set; }
    /// <summary>Diabetes Mellitus (Şeker Hastalığı) tanısı alan hastanın ve /veya ailesinin hast...</summary>
    [Required]
    [ForeignKey("DiyabetEgitimiNavigation")]
    public string DIYABET_EGITIMI { get; set; }
    /// <summary>Kişide gelişen diyabet komplikasyonları bilgisidir.</summary>
    [ForeignKey("DiyabetKomplikasyonlariNavigation")]
    public string DIYABET_KOMPLIKASYONLARI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyabetEgitimiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyabetKomplikasyonlariNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// DOGUM tablosu - 21 kolon
/// </summary>
[Table("DOGUM")]
public class DOGUM
{
    /// <summary>Sağlık tesisinde doğum yapan hastaya ait bilgilerin kayıt edilmesi için Sağlık B...</summary>
    [Key]
    public string DOGUM_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanacak hizmetler için Sağlık Bilgi Yönetim Sistemi...</summary>
    [ForeignKey("HastaHizmetNavigation")]
    public string HASTA_HIZMET_KODU { get; set; }
    /// <summary>Sağlık tesisinde yapılan ameliyatın bilgilerine erişim sağlamak için Sağlık Bilg...</summary>
    [Required]
    [ForeignKey("AmeliyatNavigation")]
    public string AMELIYAT_KODU { get; set; }
    /// <summary>Yenidogan bebegin baba T.C. Kimlik Numarasi bilgisidir.</summary>
    [Required]
    public string BABA_TC_KIMLIK_NUMARASI { get; set; }
    /// <summary>Herhangi bir müdahale (ameliyat, doğum vb.) sonrası oluşan karmaşık ve olumsuz k...</summary>
    [Required]
    [ForeignKey("KomplikasyonTanisiNavigation")]
    public string KOMPLIKASYON_TANISI { get; set; }
    /// <summary>Sağlık tesisinde doğum yapan hasta için hekim tarafından yazılan, doğuma ilişkin...</summary>
    [Required]
    public string DOGUM_NOTU { get; set; }
    /// <summary>Doğum başlama zamanı bilgisidir.</summary>
    public DateTime? DOGUM_BASLAMA_ZAMANI { get; set; }
    /// <summary>Doğum bitiş zamanı bilgisidir.</summary>
    public DateTime DOGUM_BITIS_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde görevli hekim için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [Required]
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }
    /// <summary>Sağlık tesisinde doğumu gerçekleştiren ebe için Sağlık Bilgi Yönetim Sistemi tar...</summary>
    [Required]
    [ForeignKey("EbeNavigation")]
    public string EBE_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan bölümler için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("BirimNavigation")]
    public string BIRIM_KODU { get; set; }
    /// <summary>Sağlık tesisindeki birimlerde hasta bilgilerinin olduğu defter numarası bilgisid...</summary>
    [Required]
    public string DEFTER_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA_HIZMET? HastaHizmetNavigation { get; set; }
    public virtual AMELIYAT? AmeliyatNavigation { get; set; }
    public virtual REFERANS_KODLAR? KomplikasyonTanisiNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual PERSONEL? EbeNavigation { get; set; }
    public virtual BIRIM? BirimNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// DOGUM_DETAY tablosu - 34 kolon
/// </summary>
[Table("DOGUM_DETAY")]
public class DOGUM_DETAY
{
    /// <summary>Sağlık tesisinde doğum yapan hastaya ait detay bilgilerinin kayıt edilmesi için ...</summary>
    [Key]
    public string DOGUM_DETAY_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde doğum yapan hastaya ait bilgilerin kayıt edilmesi için Sağlık B...</summary>
    [ForeignKey("DogumNavigation")]
    public string DOGUM_KODU { get; set; }
    /// <summary>Yeni doğan bebeğin doğum zamanı bilgisidir.</summary>
    public DateTime? DOGUM_ZAMANI { get; set; }
    /// <summary>Kişinin cinsiyetini ifade eder.</summary>
    [ForeignKey("CinsiyetNavigation")]
    public string CINSIYET { get; set; }
    /// <summary>Gebeliğin 22. haftası ve sonrasında veya 500 gram ve üzerinde olarak gerçekleşen...</summary>
    [ForeignKey("DogumYontemiNavigation")]
    public string DOGUM_YONTEMI { get; set; }
    /// <summary>Kişinin (gram cinsinden) ağırlığıdır.</summary>
    [Required]
    public string AGIRLIK { get; set; }
    /// <summary>Kişinin santimetre cinsinden boy bilgisidir.</summary>
    [Required]
    public string BOY { get; set; }
    /// <summary>Bebek veya çocuğun baş çevresinin (santimetre cinsinden) ölçüsüdür.</summary>
    [Required]
    public string BAS_CEVRESI { get; set; }
    /// <summary>Doğumdan 1 dakika sonra bebeğin durumunu değerlendirmek için kullanılan Nümerik ...</summary>
    [Required]
    public string APGAR_1 { get; set; }
    /// <summary>Doğumdan 5 dakika sonra, bebeğin durumunu değerlendirmek için kullanılan nümerik...</summary>
    [Required]
    public string APGAR_5 { get; set; }
    /// <summary>APGAR sonuçlarına ilişkin hekim tarafından yazılan değerlendirme bilgisidir.</summary>
    [Required]
    public string APGAR_NOTU { get; set; }
    /// <summary>Herhangi bir müdahale (ameliyat, doğum vb.) sonrası oluşan karmaşık ve olumsuz k...</summary>
    [Required]
    [ForeignKey("KomplikasyonTanisiNavigation")]
    public string KOMPLIKASYON_TANISI { get; set; }
    /// <summary>Yeni doğan bebeğin aynı gün aynı anneden doğan kaçıncı bebek olduğu bilgisidir.</summary>
    public string DOGUM_SIRASI { get; set; }
    /// <summary>Bebek veya çocuğun santimetre cinsinden göğüs çevresi bilgisidir.</summary>
    [Required]
    public string GOGUS_CEVRESI { get; set; }
    /// <summary>Prognoz, tedavinin olası seyri ve sonuçlarına ilişkin hekim tarafından verilen b...</summary>
    [Required]
    [ForeignKey("PrognozBilgisiNavigation")]
    public string PROGNOZ_BILGISI { get; set; }
    /// <summary>Sağlık tesisinde doğum yapmış hastalar için gün cinsinden sürmaturasyon (Gün Aşı...</summary>
    [Required]
    [ForeignKey("SurmatureBilgisiNavigation")]
    public string SURMATURE_BILGISI { get; set; }
    /// <summary>Sağlık tesisinde yenidoğan bebeğe doğduktan sonra K vitamini uygulanma durumu il...</summary>
    [Required]
    [ForeignKey("KVitaminiUygulanmaDurumuNavigation")]
    public string K_VITAMINI_UYGULANMA_DURUMU { get; set; }
    /// <summary>Saglik tesisinde yenidogan bebege dogduktan sonra Hepatit-B Asisinin yapilma dur...</summary>
    [Required]
    [ForeignKey("BebeginHepatitAsiDurumuNavigation")]
    public string BEBEGIN_HEPATIT_ASI_DURUMU { get; set; }
    /// <summary>Saglik tesisinde yenidogan bebege dogduktan sonra isitme tarama yapilma durumu i...</summary>
    [Required]
    [ForeignKey("YenidoganIsitmeTaramaDurumuNavigation")]
    public string YENIDOGAN_ISITME_TARAMA_DURUMU { get; set; }
    /// <summary>Yenidoğan bebeğin ilk beslenme zamanı bilgisidir.</summary>
    public DateTime ILK_BESLENME_ZAMANI { get; set; }
    /// <summary>Doğumdan sonraki günlerde bebeğin topuğundan alınan kanın alınma durumunu ifade ...</summary>
    [Required]
    [ForeignKey("TopukKaniNavigation")]
    public string TOPUK_KANI { get; set; }
    /// <summary>Yeni doğan bebeğin topuk kanının alındığı zaman bilgisidir.</summary>
    public DateTime TOPUK_KANI_ALINMA_ZAMANI { get; set; }
    /// <summary>Yenidoğan bebeğin adı bilgisidir.</summary>
    [Required]
    public string BEBEK_ADI { get; set; }
    /// <summary>Yenidoğan bebeğin baba T.C. Kimlik Numarası bilgisidir.</summary>
    [Required]
    public string BABA_TC_KIMLIK_NUMARASI { get; set; }
    /// <summary>Yeni doğan bebeğin yaşam durumuna ilişkin bilgiyi ifade eder. Örneğin canlı (sağ...</summary>
    [ForeignKey("BebeginYasamDurumuNavigation")]
    public string BEBEGIN_YASAM_DURUMU { get; set; }
    /// <summary>Hastaya sezaryen yapılma nedenini ifade eder.</summary>
    [Required]
    [ForeignKey("SezaryenEndikasyonlarNavigation")]
    public string SEZARYEN_ENDIKASYONLAR { get; set; }
    /// <summary>Robson On Gruplu Sınıflandırma Sistemi, sezaryen endikasyonları bakımından objek...</summary>
    [Required]
    [ForeignKey("RobsonGrubuNavigation")]
    public string ROBSON_GRUBU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual DOGUM? DogumNavigation { get; set; }
    public virtual REFERANS_KODLAR? CinsiyetNavigation { get; set; }
    public virtual REFERANS_KODLAR? DogumYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? KomplikasyonTanisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? PrognozBilgisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SurmatureBilgisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? KVitaminiUygulanmaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? BebeginHepatitAsiDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? YenidoganIsitmeTaramaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? TopukKaniNavigation { get; set; }
    public virtual REFERANS_KODLAR? BebeginYasamDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? SezaryenEndikasyonlarNavigation { get; set; }
    public virtual REFERANS_KODLAR? RobsonGrubuNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// DOKTOR_MESAJI tablosu - 10 kolon
/// </summary>
[Table("DOKTOR_MESAJI")]
public class DOKTOR_MESAJI
{
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Key]
    public string DOKTOR_MESAJI_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Hekim tarafından hastasına gönderilen mesajların içeriğine ilişkin bilgiyi ifade...</summary>
    [Required]
    [ForeignKey("HastaMesajlariTuruNavigation")]
    public string HASTA_MESAJLARI_TURU { get; set; }
    /// <summary>Hekim tarafından hastasına gönderilen mesajın detay bilgisidir.</summary>
    [Required]
    public string MESAJ_DETAYI { get; set; }
    /// <summary>Hekim tarafından hastasına gönderilen mesajın tarih bilgisidir.</summary>
    public DateTime MESAJ_TARIHI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? HastaMesajlariTuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// EK_ODEME tablosu - 25 kolon
/// </summary>
[Table("EK_ODEME")]
public class EK_ODEME
{
    /// <summary>SBYS tarafından üretilen tekil kod bilgisidir.</summary>
    [Key]
    public string EK_ODEME_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı veri tabanındaki tablo adı bilgisidir.</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele ödenecek ek ödeme için Sağlık Bilgi Yönetim S...</summary>
    [ForeignKey("EkOdemeDonemNavigation")]
    public string EK_ODEME_DONEM_KODU { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisinde görevli personel için ilgili mevzuat kapsamında maaş hesaplama ...</summary>
    public string HESAPLAMA_YONTEMI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele ait maaş derece bilgisidir.</summary>
    public string MAAS_DERECESI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele ait maaş kademe bilgisidir.</summary>
    public string MAAS_KADEMESI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele ait maaş gösterge bilgisidir.</summary>
    public string MAAS_GOSTERGESI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele yapılan aylık ödeme bilgisidir.</summary>
    public string AYLIK_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele ait özel hizmet tutarı bilgisidir.</summary>
    [Required]
    public string OZEL_HIZMET_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin ek gösterge tutarı bilgisidir.</summary>
    [Required]
    public string EK_GOSTERGE_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele ait yan ödeme tutarı bilgisidir.</summary>
    [Required]
    public string YAN_ODEME_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin doğu tazminat tutarı bilgisidir.</summary>
    [Required]
    public string DOGU_TAZMINATI_TUTARI { get; set; }
    /// <summary>Personelin bir ayda alacağı aylık (ek gösterge dâhil), yan ödeme ve her türlü ta...</summary>
    public string EK_ODEME_MATRAHI { get; set; }
    /// <summary>Sağlık tesisinde geçici görevli personelin, kadrosunun olduğu kurumdan almış old...</summary>
    [Required]
    public string BASKA_KURUMDAKI_EKODEME_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personel için Döner Sermaye Sabit Ödemesi (DSSÖ) için h...</summary>
    [Required]
    public string DSSO_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personel için yapılan ek ödeme hesaplanmasında kullanıl...</summary>
    [Required]
    public string ENGELLILIK_INDIRIM_ORANI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin komisyon görevi için elde edilen ek puan ora...</summary>
    [Required]
    public string KOMISYON_EK_PUANI_ORANI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin asil görevi dışında başka bir görev yapması ...</summary>
    [Required]
    public string EK_PUAN_ORANI { get; set; }
    /// <summary>Sağlık tesisinde görevli tüm uzman tabiplerin birim performans katsayılarının or...</summary>
    [Required]
    public string BIRIM_PERFORMANS_KATSAYISI { get; set; }
    /// <summary>Ek ödeme bilgisinin ilk kayıt edildiği zaman bilgisidir.</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>İşlemi ekleyen kullanıcı kodu, KULLANICI görüntüsündeki KULLANICI_KODU bilgi...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>İşlemin güncellemesinin yapıldığı zaman bilgisidir.</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>İşlemi güncelleyen kullanıcı kodu, KULLANICI görüntüsündeki KULLANICI_KODU b...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual EK_ODEME_DONEM? EkOdemeDonemNavigation { get; set; }
    public virtual PERSONEL? PersonelNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// EK_ODEME_DETAY tablosu - 25 kolon
/// </summary>
[Table("EK_ODEME_DETAY")]
public class EK_ODEME_DETAY
{
    /// <summary>SBYS tarafından üretilen tekil kod bilgisidir.</summary>
    [Key]
    public string EK_ODEME_DETAY_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele ödenecek ek ödemeye ait kayıtlara ulaşılabilm...</summary>
    [ForeignKey("EkOdemeNavigation")]
    public string EK_ODEME_KODU { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin aynı ay içinde birden fazla kadroda görev ya...</summary>
    [Required]
    public string GOREV_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin kadrosuna ilişkin kod bilgisidir.</summary>
    [Required]
    public string KADRO_KODU { get; set; }
    /// <summary>Sağlık tesisinde görevli personel için maaş hesaplamasında kullanılacak kadrosun...</summary>
    [Required]
    public string KADRO_KATSAYISI { get; set; }
    /// <summary>Sağlık tesisinde görevli hekimler tarafından, hastaya uygulanan tıbbi işlem için...</summary>
    public string GIRISIMSEL_ISLEM_PUANI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin uyguladığı tıbbi işlemler için aldığı özelli...</summary>
    [Required]
    public string OZELLIKLI_ISLEM_PUANI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin kadrosu için tavan katsayısı bilgisidir.</summary>
    [Required]
    public string TAVAN_KATSAYISI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin ilgili kadroda çalışmış olduğu toplam gün sa...</summary>
    [Required]
    public string CALISILAN_GUN_TOPLAMI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin ilgili kadroda çalışmış olduğu toplam saat b...</summary>
    [Required]
    public string CALISILAN_SAAT_TOPLAMI { get; set; }
    /// <summary>Belirli bir dönem içindeki toplam gün sayısından çalışılmayan günlerin çıkarılma...</summary>
    [Required]
    public string AKTIF_CALISILAN_GUN_KATSAYISI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele aylık ödenen ek ödeme için hesaplanan hastane...</summary>
    public string HASTANE_PUAN_ORTALAMASI { get; set; }
    /// <summary>Sağlık tesisinde bulunan kliniklerin Sağlık Bilgi Yönetim Sistemi tarafından gru...</summary>
    [Required]
    [ForeignKey("KlinikNavigation")]
    public string KLINIK_KODU { get; set; }
    /// <summary>İlgili klinik için ek ödeme hesaplamasında kullanılmış puan ortalaması bilgisidi...</summary>
    [Required]
    public string KLINIK_PUAN_ORTALAMASI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin kadro unvan katsayısına göre hesaplanan puan...</summary>
    [Required]
    public string BRUT_PERFORMANS_PUANI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin asil görevi dışında başka bir görev yapması ...</summary>
    [Required]
    public string EK_PERFORMANS_PUANI { get; set; }
    /// <summary>Sağlık tesisindeki personelin tüm ek performans puanların ve brüt performans pua...</summary>
    [Required]
    public string NET_PERFORMANS_PUANI { get; set; }
    /// <summary>Üçüncü basamak sağlık tesislerinde, başhekimlik tarafından belirlenen usul çerçe...</summary>
    [Required]
    public string EGITICI_DESTEKLEME_PUANI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin bilimsel çalışma puan bilgisidir.</summary>
    [Required]
    public string BILIMSEL_CALISMA_PUANI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin varsa serbest meslek katsayısı bilgisini ifa...</summary>
    [Required]
    public string SERBEST_MESLEK_KATSAYISI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual EK_ODEME? EkOdemeNavigation { get; set; }
    public virtual REFERANS_KODLAR? KlinikNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// EK_ODEME_DONEM tablosu - 16 kolon
/// </summary>
[Table("EK_ODEME_DONEM")]
public class EK_ODEME_DONEM
{
    /// <summary>Sağlık tesisinde görevli personele ödenecek ek ödeme için Sağlık Bilgi Yönetim S...</summary>
    [Key]
    public string EK_ODEME_DONEM_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Yıl bilgisini ifade eder.</summary>
    public string YIL { get; set; }
    /// <summary>Yılın on iki bölümünden her birini ifade eder.</summary>
    public string AY { get; set; }
    /// <summary>Sağlık tesisinde görev yapan personel için yapılan her türlü ödeme bilgisine ait...</summary>
    [Required]
    public string BORDRO_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde görevli hekimler tarafından, hastaya uygulanan tıbbi işlemler i...</summary>
    public string GIRISIMSEL_ISLEM_PUAN_TOPLAMI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin uyguladığı tıbbi işlemler için aldığı özelli...</summary>
    public string OZELLIKLI_ISLEM_PUAN_TOPLAMI { get; set; }
    /// <summary>Sağlık tesisinde görevli tüm personelin mevcut kadrosundaki aktif çalıştığı gün ...</summary>
    public string ACGK_TOPLAMI { get; set; }
    /// <summary>Sağlık tesisinde görevli personel için ek ödeme dönemi için dağıtılması planlana...</summary>
    public string DAGITILACAK_EKODEME_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele ait bordro için hesaplanan ek ödeme katsayısı...</summary>
    public string EK_ODEME_KATSAYISI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele aylık ödenen ek ödeme için hesaplanan hastane...</summary>
    public string HASTANE_PUAN_ORTALAMASI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// EVDE_SAGLIK_IZLEM tablosu - 31 kolon
/// </summary>
[Table("EVDE_SAGLIK_IZLEM")]
public class EVDE_SAGLIK_IZLEM
{
    /// <summary>Evde sağlık hizmeti alan kişilerin izlem bilgileri için Sağlık Bilgi Yönetim Sis...</summary>
    [Key]
    public string EVDE_SAGLIK_IZLEM_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı tablo adı bilgisidir.</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Kişinin ağrı hissedip hissetmediğini gösterir.</summary>
    [Required]
    [ForeignKey("AgriNavigation")]
    public string AGRI { get; set; }
    /// <summary>Yaşanılan alanın aydınlanma durumunu tanımlar.</summary>
    [Required]
    [ForeignKey("AydinlatmaNavigation")]
    public string AYDINLATMA { get; set; }
    /// <summary>Evde sağlık hizmeti almak için, kişinin tıbbi bakım, sosyal hizmet, destek ve ya...</summary>
    [Required]
    [ForeignKey("BakimVeDestekIhtiyaciNavigation")]
    public string BAKIM_VE_DESTEK_IHTIYACI { get; set; }
    /// <summary>Braden skalasına göre hastada bası durumunu gösterir.</summary>
    [Required]
    [ForeignKey("BasiDegerlendirmesiNavigation")]
    public string BASI_DEGERLENDIRMESI { get; set; }
    /// <summary>Evde sağlık hizmetinden yararlanmak amacı ile başvurulan kurumu tanımlar.</summary>
    [ForeignKey("BasvuruTuruNavigation")]
    public string BASVURU_TURU { get; set; }
    /// <summary>Kişinin beslenme durumunu tanımlar.</summary>
    [Required]
    [ForeignKey("BeslenmeNavigation")]
    public string BESLENME { get; set; }
    /// <summary>Evde Sağlık Hizmeti (ESH) verilen hastaların, hastalık gruplarını ifade eder.</summary>
    [Required]
    [ForeignKey("EshEsasHastalikGrubuNavigation")]
    public string ESH_ESAS_HASTALIK_GRUBU { get; set; }
    /// <summary>Kişinin yaşadığı alanın hijyen şartlarını tanımlar.</summary>
    [Required]
    [ForeignKey("EvHijyeniNavigation")]
    public string EV_HIJYENI { get; set; }
    /// <summary>Evde sağlık hizmetini alan kişiler için alınan güvenlik önlemlerinin yeterli olu...</summary>
    [Required]
    [ForeignKey("GuvenlikNavigation")]
    public string GUVENLIK { get; set; }
    /// <summary>Kişinin barındığı alandaki ısınma tipini ifade eder.</summary>
    [Required]
    [ForeignKey("IsinmaNavigation")]
    public string ISINMA { get; set; }
    /// <summary>Kişinin kendi ihtiyaçlarını karşılama durumunu tanımlar.</summary>
    [Required]
    [ForeignKey("KisiselBakimNavigation")]
    public string KISISEL_BAKIM { get; set; }
    /// <summary>Kişinin kendine bakım durumunu ifade eder.</summary>
    [Required]
    [ForeignKey("KisiselHijyenNavigation")]
    public string KISISEL_HIJYEN { get; set; }
    /// <summary>Kişinin ikamet ettiği alanı tanımlar.</summary>
    [Required]
    [ForeignKey("KonutTipiNavigation")]
    public string KONUT_TIPI { get; set; }
    /// <summary>Meskenin hela tipini tanımlar.</summary>
    [Required]
    [ForeignKey("KullanilanHelaTipiNavigation")]
    public string KULLANILAN_HELA_TIPI { get; set; }
    /// <summary>Hizmet alan kişinin yatağa bağımlılık durumunu tanımlar.</summary>
    [Required]
    [ForeignKey("YatagaBagimlilikNavigation")]
    public string YATAGA_BAGIMLILIK { get; set; }
    /// <summary>Kişinin hareketi için kullanılan yardımcı araçları ifade eder.</summary>
    [Required]
    [ForeignKey("KullandigiYardimciAraclarNavigation")]
    public string KULLANDIGI_YARDIMCI_ARACLAR { get; set; }
    /// <summary>Kişinin psikolojik durumu hakkında genel bilgi verir.</summary>
    [Required]
    [ForeignKey("PsikolojikDurumDegerlendirmeNavigation")]
    public string PSIKOLOJIK_DURUM_DEGERLENDIRME { get; set; }
    /// <summary>Evde Sağlık Hizmeti (ESH) verilen hastalarda, sağlık hizmetinin herhangi bir ned...</summary>
    [Required]
    [ForeignKey("EshSonlandirilmasiNavigation")]
    public string ESH_SONLANDIRILMASI { get; set; }
    /// <summary>Evde Sağlık Hizmeti (ESH) verilen hastaların herhangi bir sağlık tesisine nakil ...</summary>
    [Required]
    [ForeignKey("EshHastaNakliNavigation")]
    public string ESH_HASTA_NAKLI { get; set; }
    /// <summary>Evde sağlık hizmetinin alındığı il bilgisidir.</summary>
    [Required]
    [ForeignKey("EshAlinacakIlNavigation")]
    public string ESH_ALINACAK_IL { get; set; }
    /// <summary>Kişiye verilmesi planlanan hizmet türü bilgisidir. Örneğin aile hekimi değerlend...</summary>
    [Required]
    [ForeignKey("BirSonrakiHizmetIhtiyaciNavigation")]
    public string BIR_SONRAKI_HIZMET_IHTIYACI { get; set; }
    /// <summary>Sağlık tesisinde görevli personel tarafından verilen eğitimin bilgisidir. Örneği...</summary>
    [Required]
    [ForeignKey("VerilenEgitimlerNavigation")]
    public string VERILEN_EGITIMLER { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? AgriNavigation { get; set; }
    public virtual REFERANS_KODLAR? AydinlatmaNavigation { get; set; }
    public virtual REFERANS_KODLAR? BakimVeDestekIhtiyaciNavigation { get; set; }
    public virtual REFERANS_KODLAR? BasiDegerlendirmesiNavigation { get; set; }
    public virtual REFERANS_KODLAR? BasvuruTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? BeslenmeNavigation { get; set; }
    public virtual REFERANS_KODLAR? EshEsasHastalikGrubuNavigation { get; set; }
    public virtual REFERANS_KODLAR? EvHijyeniNavigation { get; set; }
    public virtual REFERANS_KODLAR? GuvenlikNavigation { get; set; }
    public virtual REFERANS_KODLAR? IsinmaNavigation { get; set; }
    public virtual REFERANS_KODLAR? KisiselBakimNavigation { get; set; }
    public virtual REFERANS_KODLAR? KisiselHijyenNavigation { get; set; }
    public virtual REFERANS_KODLAR? KonutTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? KullanilanHelaTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? YatagaBagimlilikNavigation { get; set; }
    public virtual REFERANS_KODLAR? KullandigiYardimciAraclarNavigation { get; set; }
    public virtual REFERANS_KODLAR? PsikolojikDurumDegerlendirmeNavigation { get; set; }
    public virtual REFERANS_KODLAR? EshSonlandirilmasiNavigation { get; set; }
    public virtual REFERANS_KODLAR? EshHastaNakliNavigation { get; set; }
    public virtual REFERANS_KODLAR? EshAlinacakIlNavigation { get; set; }
    public virtual REFERANS_KODLAR? BirSonrakiHizmetIhtiyaciNavigation { get; set; }
    public virtual REFERANS_KODLAR? VerilenEgitimlerNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// FATURA tablosu - 20 kolon
/// </summary>
[Table("FATURA")]
public class FATURA
{
    /// <summary>SBYS tarafından üretilen tekil kod bilgisidir.</summary>
    [Key]
    public string FATURA_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisinde kesilen faturanın ait olduğu dönem bilgisidir.</summary>
    public string FATURA_DONEMI { get; set; }
    /// <summary>Sağlık tesisinde kesilen faturaları gruplandırmak için tanımlanan icmal için Sağ...</summary>
    [Required]
    [ForeignKey("IcmalNavigation")]
    public string ICMAL_KODU { get; set; }
    /// <summary>Sağlık tesisi tarafından kesilen fatura için Sağlık Bilgi Yönetim Sistemi tarafı...</summary>
    [ForeignKey("FaturaTuruNavigation")]
    public string FATURA_TURU { get; set; }
    /// <summary>Sağlık tesisinde kesilen fatura için ad bilgisidir.</summary>
    [Required]
    public string FATURA_ADI { get; set; }
    /// <summary>Sağlık tesisi tarafından kesilen faturanın zaman bilgisidir.</summary>
    public DateTime? FATURA_ZAMANI { get; set; }
    /// <summary>Sağlık tesisi tarafından kesilen faturanın toplam tutar bilgisidir.</summary>
    public string FATURA_TUTARI { get; set; }
    /// <summary>Sağlık tesisi tarafından kesilen faturanın numara bilgisidir.</summary>
    public string FATURA_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinden tedavi gören hasta için MEDULA sistemine gönderilen faturalar ...</summary>
    [Required]
    public string MEDULA_TESLIM_NUMARASI { get; set; }
    /// <summary>Sağlık tesisi tarafından fatura kesilen kurum için Sağlık Bilgi Yönetim Sistemi ...</summary>
    [ForeignKey("FaturaKesilenKurumNavigation")]
    public string FATURA_KESILEN_KURUM_KODU { get; set; }
    /// <summary>Tek Düzen Muhasebe Sisteminde tanımlanan, yerine göre “Alıcılar Hesabı” veya "Gi...</summary>
    [Required]
    public string BUTCE_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual ICMAL? IcmalNavigation { get; set; }
    public virtual REFERANS_KODLAR? FaturaTuruNavigation { get; set; }
    public virtual KURUM? FaturaKesilenKurumNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// FIRMA tablosu - 19 kolon
/// </summary>
[Table("FIRMA")]
public class FIRMA
{
    /// <summary>Sağlık tesisinin mal veya hizmet alımı yaptığı firma için Sağlık Bilgi Yönetim S...</summary>
    [Key]
    public string FIRMA_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinin mal veya hizmet alımı yaptığı firma için ad bilgisidir.</summary>
    public string FIRMA_ADI { get; set; }
    /// <summary>Telefon numarası bilgisini ifade eder.</summary>
    [Required]
    public string TELEFON_NUMARASI { get; set; }
    /// <summary>Sağlık tesisine hizmet veren firma yetkilisinin ad ve soyadı bilgisidir.</summary>
    [Required]
    public string YETKILI_KISI { get; set; }
    /// <summary>Sağlık tesisinin mal veya hizmet alımı yaptığı firmanın adres bilgisidir.</summary>
    [Required]
    public string FIRMA_ADRESI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi veri tabanında bulunan bir kayıtın aktif olup olmad...</summary>
    [Required]
    public string AKTIFLIK_BILGISI { get; set; }
    /// <summary>Sağlık tesisinin hizmet aldığı firmanın bağlı olduğu vergi dairesi bilgisidir.</summary>
    [Required]
    public string VERGI_DAIRESI { get; set; }
    /// <summary>Sağlık tesisinin hizmet aldığı firmaya ait vergi numarası bilgisidir.</summary>
    [Required]
    public string VERGI_NUMARASI { get; set; }
    /// <summary>Firma e-posta adresi bilgisidir.</summary>
    [Required]
    public string EPOSTA_ADRESI { get; set; }
    /// <summary>Firmaya ait IBAN numarası bilgisidir.</summary>
    [Required]
    public string IBAN_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// GEBE_IZLEM tablosu - 27 kolon
/// </summary>
[Table("GEBE_IZLEM")]
public class GEBE_IZLEM
{
    /// <summary>Sağlık tesisinde muayene olan kadın hastaların gebelik izlem bilgileri için Sağl...</summary>
    [Key]
    public string GEBE_IZLEM_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı tablo adı bilgisidir.</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Gebede kaçıncı izlemin yapıldığını ifade eder</summary>
    [ForeignKey("KacinciGebeIzlemNavigation")]
    public string KACINCI_GEBE_IZLEM { get; set; }
    /// <summary>Kadının gebe kalmadan önceki son âdet döneminin ilk günüdür.</summary>
    public DateTime? SON_ADET_TARIHI { get; set; }
    /// <summary>Kadının bir önceki doğum durumu bilgisidir.</summary>
    [Required]
    [ForeignKey("OncekiDogumDurumuNavigation")]
    public string ONCEKI_DOGUM_DURUMU { get; set; }
    /// <summary>Gebe için kaydı tutulan izlemin sağlık tesisinde yapılma bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("GebeIzlemIslemTuruNavigation")]
    public string GEBE_IZLEM_ISLEM_TURU { get; set; }
    /// <summary>Gestasyonel Diyabetes için; OGTT gebeliğin 2. trimestirinde 75 gram glukoz veril...</summary>
    [Required]
    [ForeignKey("GestasyonelDiyabetTaramasiNavigation")]
    public string GESTASYONEL_DIYABET_TARAMASI { get; set; }
    /// <summary>Gebenin izlem esnasında idrarında kalitatif olarak protein varlığının değerlendi...</summary>
    [Required]
    [ForeignKey("IdrardaProteinNavigation")]
    public string IDRARDA_PROTEIN { get; set; }
    /// <summary>Kişinin hemoglobin değeri bilgisidir.</summary>
    [Required]
    public string HEMOGLOBIN_DEGERI { get; set; }
    /// <summary>Gebelikte dışarıdan demir desteği; demirin uygulanmayacağı durumlar hariç, ayrım...</summary>
    [Required]
    [ForeignKey("DemirLojistigiVeDestegiNavigation")]
    public string DEMIR_LOJISTIGI_VE_DESTEGI { get; set; }
    /// <summary>Gebeler için; gebeliğin 12. haftasından başlanarak doğumdan sonra 6. ayın sonuna...</summary>
    [Required]
    [ForeignKey("DvitaminiLojistigiVeDestegiNavigation")]
    public string DVITAMINI_LOJISTIGI_VE_DESTEGI { get; set; }
    /// <summary>Kadının 22. gebelik haftası ve sonrasında veya 500 gram ve üzerinde konjenital a...</summary>
    [Required]
    [ForeignKey("KonjenitalAnomaliVarligiNavigation")]
    public string KONJENITAL_ANOMALI_VARLIGI { get; set; }
    /// <summary>Gebe izlem muayenesinde tespit edilen fetusa ait kalp sesinin varlığı ve sayısın...</summary>
    [Required]
    public string FETUS_KALP_SESI { get; set; }
    /// <summary>Kan basıncı ölçme protokolüne uygun olarak "mm Hg" birimi ile ölçülen diastolik ...</summary>
    [Required]
    public string DIASTOLIK_KAN_BASINCI_DEGERI { get; set; }
    /// <summary>Sistolik kan basıncı (büyük tansiyon) bilgisini ifade eder.</summary>
    [Required]
    public string SISTOLIK_KAN_BASINCI_DEGERI { get; set; }
    /// <summary>Gebenin önceki ve mevcut gebelikleri ile genel tıbbi durumu değerlendirilerek be...</summary>
    [Required]
    [ForeignKey("GebelikteRiskFaktorleriNavigation")]
    public string GEBELIKTE_RISK_FAKTORLERI { get; set; }
    /// <summary>0-6 yaş döneminde, bebeğin/çocuğun beyin gelişimini olumsuz yönde etkileyebilece...</summary>
    [Required]
    [ForeignKey("BcBeyinGelisimRiskleriNavigation")]
    public string BC_BEYIN_GELISIM_RISKLERI { get; set; }
    /// <summary>Anne karnındaki dönem dahil olmak üzere, çocuğun 0-6 yaş döneminde beyin gelişim...</summary>
    [Required]
    [ForeignKey("PsikolojikGelisimRiskEgitimNavigation")]
    public string PSIKOLOJIK_GELISIM_RISK_EGITIM { get; set; }
    /// <summary>0-6 yaş döneminde, Bebeğin/Çocuğun beyin gelişimini olumsuz yönde etkileyebilece...</summary>
    [Required]
    [ForeignKey("RiskFaktorlerineMudahaleNavigation")]
    public string RISK_FAKTORLERINE_MUDAHALE { get; set; }
    /// <summary>Çocuğun psikolojik gelişiminin risk altında olduğu durumda, sık izleme alınan ol...</summary>
    [Required]
    [ForeignKey("RiskAltindakiOlguTakibiNavigation")]
    public string RISK_ALTINDAKI_OLGU_TAKIBI { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? KacinciGebeIzlemNavigation { get; set; }
    public virtual REFERANS_KODLAR? OncekiDogumDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? GebeIzlemIslemTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? GestasyonelDiyabetTaramasiNavigation { get; set; }
    public virtual REFERANS_KODLAR? IdrardaProteinNavigation { get; set; }
    public virtual REFERANS_KODLAR? DemirLojistigiVeDestegiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DvitaminiLojistigiVeDestegiNavigation { get; set; }
    public virtual REFERANS_KODLAR? KonjenitalAnomaliVarligiNavigation { get; set; }
    public virtual REFERANS_KODLAR? GebelikteRiskFaktorleriNavigation { get; set; }
    public virtual REFERANS_KODLAR? BcBeyinGelisimRiskleriNavigation { get; set; }
    public virtual REFERANS_KODLAR? PsikolojikGelisimRiskEgitimNavigation { get; set; }
    public virtual REFERANS_KODLAR? RiskFaktorlerineMudahaleNavigation { get; set; }
    public virtual REFERANS_KODLAR? RiskAltindakiOlguTakibiNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// GETAT tablosu - 15 kolon
/// </summary>
[Table("GETAT")]
public class GETAT
{
    /// <summary>Geleneksel ve Tamamlayıcı Tıp Tedavisi (GETAT) kayıtları için Sağlık Bilgi Yönet...</summary>
    [Key]
    public string GETAT_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı tablo adı bilgisidir.</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde Geleneksel ve Tamamlayıcı Tıp Uygulamaları (GETAT) uygulamasını...</summary>
    [ForeignKey("GetatUygulamaBirimiNavigation")]
    public string GETAT_UYGULAMA_BIRIMI { get; set; }
    /// <summary>Geleneksel ve tamamlayıcı tıp tedavisinde oluşan komplikasyon tanı bilgisini ifa...</summary>
    [Required]
    [ForeignKey("KomplikasyonTanisiNavigation")]
    public string KOMPLIKASYON_TANISI { get; set; }
    /// <summary>Sağlık tesisinde Geleneksel ve Tamamlayıcı Tıp Uygulamaları (GETAT) uygulamasını...</summary>
    [Required]
    [ForeignKey("GetatTedaviSonucuNavigation")]
    public string GETAT_TEDAVI_SONUCU { get; set; }
    /// <summary>Geleneksel ve Tamamlayıcı Tıp Uygulamaları (GETAT) işleminin tür bilgisidir. Örn...</summary>
    [ForeignKey("GetatUygulamaTuruNavigation")]
    public string GETAT_UYGULAMA_TURU { get; set; }
    /// <summary>Sağlık tesisinde Geleneksel ve Tamamlayıcı Tıp Uygulamaları (GETAT) uygulamasını...</summary>
    [ForeignKey("GetatUygulandigiDurumlarNavigation")]
    public string GETAT_UYGULANDIGI_DURUMLAR { get; set; }
    /// <summary>Geleneksel ve Tamamlayıcı Tıp Uygulamaları (GETAT) işleminin sağlık hizmetini al...</summary>
    [ForeignKey("GetatUygulamaBolgesiNavigation")]
    public string GETAT_UYGULAMA_BOLGESI { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? GetatUygulamaBirimiNavigation { get; set; }
    public virtual REFERANS_KODLAR? KomplikasyonTanisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? GetatTedaviSonucuNavigation { get; set; }
    public virtual REFERANS_KODLAR? GetatUygulamaTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? GetatUygulandigiDurumlarNavigation { get; set; }
    public virtual REFERANS_KODLAR? GetatUygulamaBolgesiNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// GRUP_UYELIK tablosu - 8 kolon
/// </summary>
[Table("GRUP_UYELIK")]
public class GRUP_UYELIK
{
    /// <summary>Sağlık tesisinde görevli personel arasından Sağlık Bilgi Yönetim Sistemini kulla...</summary>
    [Key]
    public string GRUP_UYELIK_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi kullanıcıları için tanımlanmış Sağlık Bilgi Yönetim...</summary>
    [ForeignKey("KullaniciGrupNavigation")]
    public string KULLANICI_GRUP_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemini kullanan personel için Sağlık Bilgi Yönetim Siste...</summary>
    [ForeignKey("KullaniciNavigation")]
    public string KULLANICI_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual KULLANICI_GRUP? KullaniciGrupNavigation { get; set; }
    public virtual KULLANICI? KullaniciNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// HASTA tablosu - 103 kolon
/// </summary>
[Table("HASTA")]
public class HASTA
{
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [Key]
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Hastanın T.C. Kimlik Numarası bilgisidir.</summary>
    [Required]
    public string TC_KIMLIK_NUMARASI { get; set; }
    /// <summary>Herhangi bir tanımlayıcı bilgisi bulunmayan, yabancı hasta kimlik numarası veya ...</summary>
    [Required]
    public string KIMLIKSIZ_HASTA_BILGISI { get; set; }
    /// <summary>Sağlık hizmetini almak için sağlık tesisine başvuran kişinin uyruk bilgisidir. Ö...</summary>
    [Required]
    [ForeignKey("UyrukNavigation")]
    public string UYRUK { get; set; }
    /// <summary>Sağlık tesisine gelen kişinin vatandaşlık durumunu ifade eder. Örneğin vatandaş ...</summary>
    [ForeignKey("HastaTipiNavigation")]
    public string HASTA_TIPI { get; set; }
    /// <summary>Kişinin adı bilgisidir.</summary>
    public string AD { get; set; }
    /// <summary>Kişinin soyadı bilgisidir.</summary>
    public string SOYADI { get; set; }
    /// <summary>Hastanın doğum tarihi bilgisidir.</summary>
    public DateTime DOGUM_TARIHI { get; set; }
    /// <summary>Kişinin beyan doğum tarihini ifade eder.</summary>
    public DateTime BEYAN_DOGUM_TARIHI { get; set; }
    /// <summary>Kişinin doğum yeri bilgisidir.</summary>
    [Required]
    public string DOGUM_YERI { get; set; }
    /// <summary>Kişinin cinsiyetini ifade eder.</summary>
    [ForeignKey("CinsiyetNavigation")]
    public string CINSIYET { get; set; }
    /// <summary>Yeni doğanlar için anne T.C. Kimlik Numarası bilgisidir.</summary>
    [Required]
    public string ANNE_TC_KIMLIK_NUMARASI { get; set; }
    /// <summary>Yeni doğanlar için baba T.C. Kimlik Numarası bilgisidir.</summary>
    [Required]
    public string BABA_TC_KIMLIK_NUMARASI { get; set; }
    /// <summary>Kişinin annesinin daha önceden sağlık tesisine başvurduğunu gösterir Sağlık Bilg...</summary>
    [Required]
    [ForeignKey("AnneHastaNavigation")]
    public string ANNE_HASTA_KODU { get; set; }
    /// <summary>Kişinin babasının daha önceden sağlık tesisine başvurduğunu gösterir Sağlık Bilg...</summary>
    [Required]
    [ForeignKey("BabaHastaNavigation")]
    public string BABA_HASTA_KODU { get; set; }
    /// <summary>Yeni doğan bebeğin aynı gün aynı anneden doğan kaçıncı bebek olduğu bilgisidir.</summary>
    [Required]
    public string DOGUM_SIRASI { get; set; }
    /// <summary>Kişinin anne adı bilgisidir.</summary>
    [Required]
    public string ANNE_ADI { get; set; }
    /// <summary>Kişinin baba adı bilgisidir.</summary>
    [Required]
    public string BABA_ADI { get; set; }
    /// <summary>Kişinin medeni hâlini ifade eder.</summary>
    [Required]
    [ForeignKey("MedeniHaliNavigation")]
    public string MEDENI_HALI { get; set; }
    /// <summary>Kişinin meşgul olduğu işi veya görevi ifade eder.</summary>
    [Required]
    [ForeignKey("MeslekNavigation")]
    public string MESLEK { get; set; }
    /// <summary>Kişinin en son bitirdiği okul seviyesini veya okuryazarlık durumunu ifade eder. ...</summary>
    [Required]
    [ForeignKey("OgrenimDurumuNavigation")]
    public string OGRENIM_DURUMU { get; set; }
    /// <summary>Kişinin kan grubunu ifade eder.</summary>
    [Required]
    [ForeignKey("KanGrubuNavigation")]
    public string KAN_GRUBU { get; set; }
    /// <summary>Sağlık tesisine muayene olmak için gelen kişinin, Sağlık Bakanlığı tarafından be...</summary>
    [Required]
    [ForeignKey("MuayeneOncelikSirasiNavigation")]
    public string MUAYENE_ONCELIK_SIRASI { get; set; }
    /// <summary>Sağlık tesisine başvuran kişinin engellilik durumunu ifade eder. Örneğin bedense...</summary>
    [Required]
    [ForeignKey("EngellilikDurumuNavigation")]
    public string ENGELLILIK_DURUMU { get; set; }
    /// <summary>Kişinin ölüm tarihi bilgisidir.</summary>
    public DateTime OLUM_TARIHI { get; set; }
    /// <summary>Ölümün gerçekleştiği yeri ifade eder. Örneğin ev, iş, birinci basamak sağlık kur...</summary>
    [Required]
    [ForeignKey("OlumYeriNavigation")]
    public string OLUM_YERI { get; set; }
    /// <summary>Pasaport numarası bilgisidir.</summary>
    [Required]
    public string PASAPORT_NUMARASI { get; set; }
    /// <summary>Kişinin Yurtdışı Provizyon Aktivasyon ve Sağlık Sistemi (YUPASS) numarası bilgis...</summary>
    [Required]
    public string YUPASS_NUMARASI { get; set; }
    /// <summary>Hastanın son başvurduğu kurumu ifade eden Sağlık Bilgi Yönetim Sistemi tarafında...</summary>
    [ForeignKey("SonKurumNavigation")]
    public string SON_KURUM_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual REFERANS_KODLAR? UyrukNavigation { get; set; }
    public virtual REFERANS_KODLAR? HastaTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? CinsiyetNavigation { get; set; }
    public virtual HASTA? AnneHastaNavigation { get; set; }
    public virtual HASTA? BabaHastaNavigation { get; set; }
    public virtual REFERANS_KODLAR? MedeniHaliNavigation { get; set; }
    public virtual REFERANS_KODLAR? MeslekNavigation { get; set; }
    public virtual REFERANS_KODLAR? OgrenimDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanGrubuNavigation { get; set; }
    public virtual REFERANS_KODLAR? MuayeneOncelikSirasiNavigation { get; set; }
    public virtual REFERANS_KODLAR? EngellilikDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? OlumYeriNavigation { get; set; }
    public virtual KURUM? SonKurumNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// HASTA_ADLI_RAPOR tablosu - 68 kolon
/// </summary>
[Table("HASTA_ADLI_RAPOR")]
public class HASTA_ADLI_RAPOR
{
    /// <summary>Adli rapor düzenlenen hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafınd...</summary>
    [Key]
    public string HASTA_ADLI_RAPOR_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Kişiye verilen adli raporun tür bilgisidir. Örneğin giriş raporu, çıkış raporu, ...</summary>
    [ForeignKey("AdliRaporTuruNavigation")]
    public string ADLI_RAPOR_TURU { get; set; }
    /// <summary>Rapor zamanı bilgisidir.</summary>
    public DateTime? RAPOR_ZAMANI { get; set; }
    /// <summary>Kişiyi adli muayene için sağlık tesisine gönderen kurum bilgisidir.</summary>
    [Required]
    public string ADLI_MUAYENEYE_GONDEREN_KURUM { get; set; }
    /// <summary>Adli merciler tarafından, sağlık tesisine gönderilen kişinin muayeneye gönderilm...</summary>
    [Required]
    public string RESMI_YAZI_NUMARASI { get; set; }
    /// <summary>Adli merciler tarafından, sağlık tesisine gönderilen kişinin muayeneye gönderilm...</summary>
    public DateTime RESMI_YAZI_TARIHI { get; set; }
    /// <summary>Adli raporu isteyen kurumun hastayı muayeneye gönderme nedeni bilgisidir.</summary>
    [Required]
    public string ADLI_MUAYENE_EDILME_NEDENI { get; set; }
    /// <summary>Kolluk kuvvetinin sicil numarası bilgisidir.</summary>
    [Required]
    public string GUVENLIK_SICIL_NUMARASI { get; set; }
    /// <summary>Kolluk kuvvetinin ad soyadı bilgisidir.</summary>
    [Required]
    public string GUVENLIK_ADI_SOYADI { get; set; }
    /// <summary>Olayın gerçekleştiği zaman bilgisidir.</summary>
    public DateTime OLAY_ZAMANI { get; set; }
    /// <summary>Adli vakalarda meydana gelen olayın öyküsü bilgisidir.</summary>
    [Required]
    public string ADLI_OLAY_OYKUSU { get; set; }
    /// <summary>Hastanın sağlık tesisine başvurmasına neden olan şikayet bilgisini ifade eder.</summary>
    [Required]
    public string SIKAYET { get; set; }
    /// <summary>Kişinin özgeçmiş bilgisidir.</summary>
    [Required]
    public string OZGECMISI { get; set; }
    /// <summary>Sağlık hizmeti alan kişinin soy geçmiş bilgisidir.</summary>
    [Required]
    public string SOYGECMISI { get; set; }
    /// <summary>Sağlık tesisine başvuran kişinin hekim tarafından ilk muayene edildiği zaman bil...</summary>
    public DateTime MUAYENE_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde görevli hekim için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [Required]
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }
    /// <summary>Sağlık tesisinde sağlık hizmetini alan kişi için uygulanan tıbbi müdahale bilgis...</summary>
    [Required]
    public string TIBBI_MUDAHALE { get; set; }
    /// <summary>Sağlık hizmetini almak isteyen kişiyi muayene etmek için uygun şartların sağlanm...</summary>
    public string UYGUN_SART_SAGLANMA_DURUMU { get; set; }
    /// <summary>Sağlık hizmetini almak isteyen kişiyi muayene etmek için uygun şartların sağlanm...</summary>
    [Required]
    public string UYGUN_SART_ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisine adli muayene için getirilmiş kişinin üzerinde bulunan kıyafetler...</summary>
    [Required]
    [ForeignKey("ElbiseDurumuNavigation")]
    public string ELBISE_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde hekim tarafından yapılan konsültasyon bilgisidir.</summary>
    [Required]
    public string KONSULTASYON_BILGISI { get; set; }
    /// <summary>Kişinin vücudunda tespit edilen lezyonlara ilişkin bilgidir.</summary>
    [Required]
    public string LEZYON_BULGULARI { get; set; }
    /// <summary>Sistem bulguları bilgisidir.</summary>
    [Required]
    public string SISTEM_BULGULARI { get; set; }
    /// <summary>Kişinin bilinç durumu bilgisidir.</summary>
    [Required]
    public string BILINC_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde muayene olan kişinin pupilla (gözbebeği) refleksi değerlendirme...</summary>
    [Required]
    [ForeignKey("PupillaDegerlendirmesiNavigation")]
    public string PUPILLA_DEGERLENDIRMESI { get; set; }
    /// <summary>Sağlık tesisine adli muayene için gelen hastanın göz muayenesinde bakılan ışık r...</summary>
    [Required]
    [ForeignKey("IsikRefleksiNavigation")]
    public string ISIK_REFLEKSI { get; set; }
    /// <summary>Hastanın 1 dakikadaki atım sayısı cinsinden nabız bilgisidir.</summary>
    [Required]
    public string NABIZ { get; set; }
    /// <summary>Hastanın refleks ölçümünde elde edilen sonuç bilgisidir. Örneğin normoaktif, hip...</summary>
    [Required]
    [ForeignKey("TendonRefleksiNavigation")]
    public string TENDON_REFLEKSI { get; set; }
    /// <summary>Sağlık tesisine adli muayene için getirilmiş kişinin psikiyatrik muayene bilgisi...</summary>
    [Required]
    public string PSIKIYATRIK_MUAYENE { get; set; }
    /// <summary>Sağlık tesisine adli muayene için getirilmiş kişinin psikiyatrik muayene sonuç b...</summary>
    [Required]
    public string PSIKIYATRIK_SONUC { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanan işlemler için yapılan açıklama bilgisidir.</summary>
    [Required]
    public string HIZMET_ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisindeki hastanın sevk edilip edilmediğine ilişkin bilgiyi ifade eder.</summary>
    [Required]
    public string SEVK_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde sevk edilen hasta için yapılan açıklama bilgisini ifade eder.</summary>
    [Required]
    public string SEVK_ACIKLAMA { get; set; }
    /// <summary>Kan ürünü, numune, adli rapor, nüfus cüzdanı, malzeme vb. teslim alan kişinin ad...</summary>
    [Required]
    public string TESLIM_ALAN_ADI_SOYADI { get; set; }
    /// <summary>Kan ürünü, numune, adli rapor, nüfus cüzdanı, malzeme vb. teslim alan kişinin TC...</summary>
    [Required]
    public string TESLIM_ALAN_TC_KIMLIK_NUMARASI { get; set; }
    /// <summary>Muayene edilen kişinin vücudunda tespit edilen tıbbi bulguların vücut diyagramın...</summary>
    [Required]
    public string VUCUT_DIYAGRAMI { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisine adli muayene için getirilmiş kişinin yapılacak olan muayene için...</summary>
    [Required]
    [ForeignKey("AdliMuayeneRizaDurumuNavigation")]
    public string ADLI_MUAYENE_RIZA_DURUMU { get; set; }
    /// <summary>Adli muayeneye rıza veren kişinin adı ve soyadı bilgisini ifade eder.</summary>
    [Required]
    public string RIZA_VEREN_KISI { get; set; }
    /// <summary>Adli muayeneye rıza veren kişinin muayene olan kişiye yakınlık durumunu ifade ed...</summary>
    [Required]
    [ForeignKey("RizaVereninYakinlikDerecesiNavigation")]
    public string RIZA_VERENIN_YAKINLIK_DERECESI { get; set; }
    /// <summary>Muayene edilen kişinin son cinsel ilişki tarihidir.</summary>
    public DateTime SON_CINSEL_ILISKI_TARIHI { get; set; }
    /// <summary>Kadının hamile olup olmadığını ifade eder.</summary>
    [Required]
    public string HAMILELIK_DURUMU { get; set; }
    /// <summary>Kadının hamilelik öyküsü açıklama bilgisidir.</summary>
    [Required]
    public string HAMILELIK_OYKUSU_ACIKLAMA { get; set; }
    /// <summary>Sağlık hizmeti almak isteyen kişinin veneryal hastalık (cinsel yolla bulaşan has...</summary>
    [Required]
    public string VENERYAL_HASTALIK_OYKUSU { get; set; }
    /// <summary>Sağlık tesisine adli muayene için getirilmiş kişinin emosyonel (duygu durumu) du...</summary>
    [Required]
    public string EMOSYONEL_HASTALIK_OYKUSU { get; set; }
    /// <summary>Hastanın solunum bilgisidir.</summary>
    [Required]
    public string SOLUNUM { get; set; }
    /// <summary>Sağlık tesisine adli muayene için getirilmiş kişiye hekim tarafından yazılan mua...</summary>
    [Required]
    public string ADLI_MUAYENE_NOTU { get; set; }
    /// <summary>Hastadan alınan materyal bilgisidir.</summary>
    [Required]
    public string ALINAN_MATERYAL { get; set; }
    /// <summary>Muayene sırasında muayene odasında bulunan hekim dışındaki kişi bilgisidir.</summary>
    [Required]
    public string MUAYENEDEKI_KISI_BILGISI { get; set; }
    /// <summary>Muayene sırasında muayene odasında bulunan hekim dışındaki kişiler ile ilgili aç...</summary>
    [Required]
    public string MUAYENEDEKI_KISI_ACIKLAMA { get; set; }
    /// <summary>Kişinin alkol kullanma durumunu ifade eder.</summary>
    [Required]
    public string ALKOL_KULLANIMI { get; set; }
    /// <summary>Hastanın şiddet veya tehdide maruz kalıp kalmadığına ilişkin sağlık tesisinde ve...</summary>
    [Required]
    public string SIDDET_TEHDIT_BILGISI { get; set; }
    /// <summary>Hastanın silah, alet vb. maruz kalma bilgisini ifade eder.</summary>
    [Required]
    public string SILAH_ALET_BILGISI { get; set; }
    /// <summary>Hastanın hayati tehlikesinin olup olmadığına ilişkin bilgiyi ifade eder.</summary>
    [Required]
    public string HAYATI_TEHLIKE_DURUMU { get; set; }
    /// <summary>Sistolik kan basıncı (büyük tansiyon) bilgisini ifade eder.</summary>
    [Required]
    public string SISTOLIK_KAN_BASINCI_DEGERI { get; set; }
    /// <summary>Diastolik kan basıncı (küçük tansiyon) bilgisini ifade eder.</summary>
    [Required]
    public string DIASTOLIK_KAN_BASINCI_DEGERI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin iptal edildiği zaman bilgisidir.</summary>
    public DateTime IPTAL_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde yapılan bir işlemi iptal eden Sağlık Bilgi Yönetim Sistemi kull...</summary>
    [Required]
    [ForeignKey("IptalEdenKullaniciNavigation")]
    public string IPTAL_EDEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık tesisinde düzenlenen adli raporun iptal edilmesi durumunda, belirtilen ip...</summary>
    [Required]
    public string ADLI_RAPOR_IPTAL_GEREKCESI { get; set; }
    /// <summary>Sağlık tesisinde işlemi gerçekleştiren veya işlemin sonucunu onaylayan kullanıcı...</summary>
    [Required]
    [ForeignKey("OnaylayanKullaniciNavigation")]
    public string ONAYLAYAN_KULLANICI_KODU { get; set; }
    /// <summary>Adli raporun onaylandığı zaman bilgisidir.</summary>
    public DateTime ADLI_RAPOR_ONAYLANMA_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual REFERANS_KODLAR? AdliRaporTuruNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual REFERANS_KODLAR? ElbiseDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? PupillaDegerlendirmesiNavigation { get; set; }
    public virtual REFERANS_KODLAR? IsikRefleksiNavigation { get; set; }
    public virtual REFERANS_KODLAR? TendonRefleksiNavigation { get; set; }
    public virtual REFERANS_KODLAR? AdliMuayeneRizaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? RizaVereninYakinlikDerecesiNavigation { get; set; }
    public virtual KULLANICI? IptalEdenKullaniciNavigation { get; set; }
    public virtual KULLANICI? OnaylayanKullaniciNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// HASTA_ARSIV tablosu - 14 kolon
/// </summary>
[Table("HASTA_ARSIV")]
public class HASTA_ARSIV
{
    /// <summary>Arşivde bulunan hasta dosyası bilgileri için Sağlık Bilgi Yönetim Sistemi tarafı...</summary>
    [Key]
    public string HASTA_ARSIV_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Hasta dosyasının arşiv numarası bilgisidir.</summary>
    public string ARSIV_NUMARASI { get; set; }
    /// <summary>Hastanın herhangi bir sağlık tesisinde bulunan sağlık bilgilerinin yer aldığı do...</summary>
    [Required]
    public string ESKI_ARSIV_NUMARASI { get; set; }
    /// <summary>Sağlık tesisindeki birimlerde oluşturulan, hasta bilgilerinin olduğu dosyaların ...</summary>
    [ForeignKey("ArsivDefterTuruNavigation")]
    public string ARSIV_DEFTER_TURU { get; set; }
    /// <summary>Hasta dosyanın arşivdeki fiziksel yerinin bilgisidir. Örneğin bina/oda/raf bloğu...</summary>
    [Required]
    public string ARSIV_YERI { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Hasta dosyasının sağlık tesisi arşivine ilk kayıt edilen tarih bilgisidir.</summary>
    public DateTime ARSIV_ILK_GIRIS_TARIHI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual REFERANS_KODLAR? ArsivDefterTuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// HASTA_ARSIV_DETAY tablosu - 16 kolon
/// </summary>
[Table("HASTA_ARSIV_DETAY")]
public class HASTA_ARSIV_DETAY
{
    /// <summary>Arşivde bulunan hasta dosyası detay bilgileri için Sağlık Bilgi Yönetim Sistemi ...</summary>
    [Key]
    public string HASTA_ARSIV_DETAY_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Arşivde bulunan hasta dosyası bilgileri için Sağlık Bilgi Yönetim Sistemi tarafı...</summary>
    [ForeignKey("HastaArsivNavigation")]
    public string HASTA_ARSIV_KODU { get; set; }
    /// <summary>Sağlık tesisindeki hasta dosyasını teslim alan birim için Sağlık Bilgi Yönetim S...</summary>
    [Required]
    [ForeignKey("DosyaAlanBirimNavigation")]
    public string DOSYA_ALAN_BIRIM_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan hasta dosyasının arşivden alındığı zaman bilgisidir.</summary>
    public DateTime DOSYANIN_ALINDIGI_ZAMAN { get; set; }
    /// <summary>Sağlık tesisindeki hasta dosyasını teslim alan personel için Sağlık Bilgi Yöneti...</summary>
    [Required]
    [ForeignKey("DosyaAlanPersonelNavigation")]
    public string DOSYA_ALAN_PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisindeki hasta dosyasını arşive veren birimler için Sağlık Bilgi Yönet...</summary>
    [Required]
    [ForeignKey("DosyaVerenBirimNavigation")]
    public string DOSYA_VEREN_BIRIM_KODU { get; set; }
    /// <summary>Dosyanın verildiği zaman bilgisidir.</summary>
    public DateTime DOSYANIN_VERILDIGI_ZAMAN { get; set; }
    /// <summary>Sağlık tesisinde hasta dosyasını arşive veren kullanıcı için Sağlık Bilgi Yöneti...</summary>
    [Required]
    [ForeignKey("DosyaVerenKullaniciNavigation")]
    public string DOSYA_VEREN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA_ARSIV? HastaArsivNavigation { get; set; }
    public virtual BIRIM? DosyaAlanBirimNavigation { get; set; }
    public virtual PERSONEL? DosyaAlanPersonelNavigation { get; set; }
    public virtual BIRIM? DosyaVerenBirimNavigation { get; set; }
    public virtual KULLANICI? DosyaVerenKullaniciNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// HASTA_BASVURU tablosu - 123 kolon
/// </summary>
[Table("HASTA_BASVURU")]
public class HASTA_BASVURU
{
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Key]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Kişinin sağlık tesisine ilk başvurusuna bağlı olan tedavi süreçlerinin takip edi...</summary>
    [Required]
    [ForeignKey("BagliOlduguBasvuruNavigation")]
    public string BAGLI_OLDUGU_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisindeki birimlerde hasta bilgilerinin olduğu defter numarası bilgisid...</summary>
    [Required]
    public string DEFTER_NUMARASI { get; set; }
    /// <summary>Sağlık tesisine muayene olmak için gelen kişilere Sağlık Bilgi Yönetim Sistemi t...</summary>
    [Required]
    public string GUNLUK_SIRA_NUMARASI { get; set; }
    /// <summary>Sağlık tesisine muayene olmak için gelen kişinin, Sağlık Bakanlığı tarafından be...</summary>
    [Required]
    [ForeignKey("MuayeneOncelikSirasiNavigation")]
    public string MUAYENE_ONCELIK_SIRASI { get; set; }
    /// <summary>Hastaya uygulanacak tedavi kapsamında sağlık tesisi dışından hizmet alınan kurum...</summary>
    [ForeignKey("HizmetSunucuNavigation")]
    public string HIZMET_SUNUCU { get; set; }
    /// <summary>Sağlık tesisine tedavi için başvuruda bulunan hastanın ilk başvurusunu gerçekleş...</summary>
    [ForeignKey("KayitYeriNavigation")]
    public string KAYIT_YERI { get; set; }
    /// <summary>Kişinin yararlandığı sağlık güvencesinin kurumuna ait bilgiler için Sağlık Bilgi...</summary>
    [ForeignKey("KurumNavigation")]
    public string KURUM_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran kişinin tedavi tutarının hastadan alınacak kısmı için h...</summary>
    [Required]
    [ForeignKey("TamamlayiciKurumNavigation")]
    public string TAMAMLAYICI_KURUM_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran kişi için, Sağlık Bakanlığı tarafından geliştirilen onl...</summary>
    [Required]
    public string ONLINE_PROTOKOL_NUMARASI { get; set; }
    /// <summary>Sağlık tesisine başvuran hastanın başvurusu için Sağlık Bilgi Yönetim Sistemi ta...</summary>
    public string BASVURU_PROTOKOL_NUMARASI { get; set; }
    /// <summary>Gebeler için, Gebe, Bebek, Lohusa İzleme Sistemi (GEBLİZ) sistemine iletilen bil...</summary>
    [Required]
    public string GEBLIZ_BILDIRIM_NUMARASI { get; set; }
    /// <summary>Acil Sağlık Hizmetleri Genel Müdürlüğü tarafından takip edilen acil kapsamına al...</summary>
    [Required]
    [ForeignKey("OlayAfetNavigation")]
    public string OLAY_AFET_KODU { get; set; }
    /// <summary>Hastanın hayati tehlikesinin olup olmadığına ilişkin bilgiyi ifade eder.</summary>
    [Required]
    [ForeignKey("HayatiTehlikeDurumuNavigation")]
    public string HAYATI_TEHLIKE_DURUMU { get; set; }
    /// <summary>Tüm sağlık kurum ve kuruluşları ve aile hekimliği tarafından hastaya hizmet verm...</summary>
    public DateTime? HASTA_KABUL_ZAMANI { get; set; }
    /// <summary>Kişinin sağlık kurumuna geliş şeklini ifade eder.</summary>
    [Required]
    [ForeignKey("KabulSekliNavigation")]
    public string KABUL_SEKLI { get; set; }
    /// <summary>Bir kişinin Sosyal Güvence Durumu, kişinin sağlık hizmetlerinin karşılanması ama...</summary>
    [Required]
    [ForeignKey("SosyalGuvenceDurumuNavigation")]
    public string SOSYAL_GUVENCE_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde görevli hekim için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [Required]
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }
    /// <summary>Sağlık tesisinde sağlık hizmetini alan kişiyi muayene eden asistan hekimin Sağlı...</summary>
    [Required]
    [ForeignKey("AsistanHekimNavigation")]
    public string ASISTAN_HEKIM_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hasta için hekimin girdiği açıklama bilgisidir.</summary>
    [Required]
    public string HEKIM_BASVURU_NOTU { get; set; }
    /// <summary>Sağlık hizmeti almak üzere sağlık tesisine başvuruda bulunan kişinin, hangi nede...</summary>
    [Required]
    [ForeignKey("VakaTuruNavigation")]
    public string VAKA_TURU { get; set; }
    /// <summary>Hastanın sevk gerekçesi olan hastalık tanı (ları) dır.</summary>
    [Required]
    [ForeignKey("SevkTanisiNavigation")]
    public string SEVK_TANISI { get; set; }
    /// <summary>Hastanın ilk başvurduğu sağlık tesisinin (sevk edildiği sağlık tesisi) hastayı s...</summary>
    public DateTime SEVK_ZAMANI { get; set; }
    /// <summary>Adli vakanın sağlık kurumuna gelişi ile ilgili bilgiyi ifade eder. Örneğin savcı...</summary>
    [Required]
    [ForeignKey("AdliVakaGelisSekliNavigation")]
    public string ADLI_VAKA_GELIS_SEKLI { get; set; }
    /// <summary>Hastanın hastaneye getirildiği araç türünün bilgisidir.</summary>
    [Required]
    [ForeignKey("AracTuruNavigation")]
    public string ARAC_TURU { get; set; }
    /// <summary>Hastanın sağlık tesisine ambulans ile gelmesi durumunda ambulansta sağlık ekibi ...</summary>
    [Required]
    public string AMBULANS_TAKIP_NUMARASI { get; set; }
    /// <summary>Hastanın ambulans ile gelmesi durumunda ambulansın plaka numarasıdır.</summary>
    [Required]
    public string AMBULANS_PLAKA_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinin acile servisine başvuran hastalar için hastalık durumuna göre y...</summary>
    [Required]
    [ForeignKey("TriajNavigation")]
    public string TRIAJ_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran kişinin başvurusuna ait Merkezi Veri Sistemi tarafından...</summary>
    [Required]
    public string SYS_TAKIP_NUMARASI { get; set; }
    /// <summary>Sağlık Yönetim Sistemi (SYS) Referans Numarası, sağlık tesisine başvuran hastala...</summary>
    [Required]
    public string SYS_REFERANS_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde tedavi gören hastanın yatışı ile ilgili bilgiyi ifade eder.</summary>
    [Required]
    [ForeignKey("YatisBilgisiNavigation")]
    public string YATIS_BILGISI { get; set; }
    /// <summary>Hasta yatış işlemi yapılırken Sağlık Bilgi Yönetim Sistemi tarafından online pro...</summary>
    [Required]
    public string YATIS_PROTOKOL_NUMARASI { get; set; }
    /// <summary>Sağlık tesisine başvuran kişi için anlık durum bilgisidir. Örneğin, muayene oldu...</summary>
    [Required]
    [ForeignKey("BasvuruDurumuNavigation")]
    public string BASVURU_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde bulunan bölümler için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("BirimNavigation")]
    public string BIRIM_KODU { get; set; }
    /// <summary>Hastanın muayene başlama zamanı bilgisidir.</summary>
    public DateTime MUAYENE_BASLAMA_ZAMANI { get; set; }
    /// <summary>Hastanın muayene bitiş zamanı bilgisidir.</summary>
    public DateTime MUAYENE_BITIS_ZAMANI { get; set; }
    /// <summary>Sağlık tesisine muayene olmak için gelen kişiye Sağlık Bilgi Yönetim Sistemi tar...</summary>
    [Required]
    [ForeignKey("MuayeneTuruNavigation")]
    public string MUAYENE_TURU { get; set; }
    /// <summary>Hastaya uygulanan tedavinin ayaktan, günübirlik, yatan vb. olduğunu belirten Sağ...</summary>
    [ForeignKey("TedaviTuruNavigation")]
    public string TEDAVI_TURU { get; set; }
    /// <summary>Sağlık tesisi tarafından kişiye verilen sağlık hizmetinin sonlanma zamanıdır. Çı...</summary>
    public DateTime CIKIS_ZAMANI { get; set; }
    /// <summary>Kişinin sağlık kurumundan çıkış şeklini ifade eder.</summary>
    [Required]
    [ForeignKey("CikisSekliNavigation")]
    public string CIKIS_SEKLI { get; set; }
    /// <summary>Kişinin sağlık kurumundan çıkış kararını veren hekim için Sağlık Bilgi Yönetim S...</summary>
    [Required]
    [ForeignKey("CikisVerenHekimNavigation")]
    public string CIKIS_VEREN_HEKIM_KODU { get; set; }
    /// <summary>Sağlık turizmi amacı ile ülkemize gelen yabancı hastaların vatandaşı olduğu ülke...</summary>
    [Required]
    public string SAGLIK_TURIZMI_ULKE_KODU { get; set; }
    /// <summary>Kişinin geldiği ülkenin ülke kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("GeldigiUlkeNavigation")]
    public string GELDIGI_ULKE_KODU { get; set; }
    /// <summary>Sağlık hizmetini alan kişinin hangi amaç ile ülkemizde bulunduğunu açıklayan bil...</summary>
    [Required]
    [ForeignKey("YabanciHastaTuruNavigation")]
    public string YABANCI_HASTA_TURU { get; set; }
    /// <summary>10-24 yaş grubundaki adolesanların gelişimsel izlemlerinin yapılmasını tanımlar.</summary>
    [Required]
    [ForeignKey("GenclikSagligiIslemleriNavigation")]
    public string GENCLIK_SAGLIGI_ISLEMLERI { get; set; }
    /// <summary>Diabetes Mellitus (Şeker Hastalığı) tanısı alan hastanın ve /veya ailesinin hast...</summary>
    [Required]
    [ForeignKey("DiyabetEgitimiNavigation")]
    public string DIYABET_EGITIMI { get; set; }
    /// <summary>Diabetes Mellitus hastalığının mikro ve makrovasküler komplikasyonlarını ifade e...</summary>
    [Required]
    [ForeignKey("DiyabetKomplikasyonlariNavigation")]
    public string DIYABET_KOMPLIKASYONLARI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? BagliOlduguBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? MuayeneOncelikSirasiNavigation { get; set; }
    public virtual REFERANS_KODLAR? HizmetSunucuNavigation { get; set; }
    public virtual REFERANS_KODLAR? KayitYeriNavigation { get; set; }
    public virtual KURUM? KurumNavigation { get; set; }
    public virtual KURUM? TamamlayiciKurumNavigation { get; set; }
    public virtual REFERANS_KODLAR? OlayAfetNavigation { get; set; }
    public virtual REFERANS_KODLAR? HayatiTehlikeDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? KabulSekliNavigation { get; set; }
    public virtual REFERANS_KODLAR? SosyalGuvenceDurumuNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual PERSONEL? AsistanHekimNavigation { get; set; }
    public virtual REFERANS_KODLAR? VakaTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? SevkTanisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? AdliVakaGelisSekliNavigation { get; set; }
    public virtual REFERANS_KODLAR? AracTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? TriajNavigation { get; set; }
    public virtual REFERANS_KODLAR? YatisBilgisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? BasvuruDurumuNavigation { get; set; }
    public virtual BIRIM? BirimNavigation { get; set; }
    public virtual REFERANS_KODLAR? MuayeneTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? TedaviTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? CikisSekliNavigation { get; set; }
    public virtual PERSONEL? CikisVerenHekimNavigation { get; set; }
    public virtual REFERANS_KODLAR? GeldigiUlkeNavigation { get; set; }
    public virtual REFERANS_KODLAR? YabanciHastaTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? GenclikSagligiIslemleriNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyabetEgitimiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyabetKomplikasyonlariNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// HASTA_BORC tablosu - 7 kolon
/// </summary>
[Table("HASTA_BORC")]
public class HASTA_BORC
{
    /// <summary>Hastaların borç bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından üretilen ...</summary>
    [Key]
    public string HASTA_BORC_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Hastanın ödemiş olduğu borç bilgisidir.</summary>
    public string ODENEN_BORC { get; set; }
    /// <summary>Sağlık tesisinde sağlık hizmetini alan kişinin kendisine uygulanan tanı ve tedav...</summary>
    public string TOPLAM_BORC { get; set; }
    /// <summary>Sağlık tesisinde tedavisi yapılan hastanın kalan borç bilgisidir.</summary>
    public string KALAN_BORC { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    #endregion
}

/// <summary>
/// HASTA_DIS tablosu - 18 kolon
/// </summary>
[Table("HASTA_DIS")]
public class HASTA_DIS
{
    /// <summary>Hastaya uygulanan diş tedavi bilgileri için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [Key]
    public string HASTA_DIS_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Dişe uygulanan işlem türüdür. Örneğin diagnoz, tedavi, planlama vb.</summary>
    [ForeignKey("DisIslemTuruNavigation")]
    public string DIS_ISLEM_TURU { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanacak hizmetler için Sağlık Bilgi Yönetim Sistemi...</summary>
    [Required]
    [ForeignKey("HastaHizmetNavigation")]
    public string HASTA_HIZMET_KODU { get; set; }
    /// <summary>Diş tedavisi yapılan hastalar için MEDULA sisteminden alınan taahhüt bilgilerini...</summary>
    [Required]
    [ForeignKey("DisTaahhutNavigation")]
    public string DIS_TAAHHUT_KODU { get; set; }
    /// <summary>Hastanın mevcut diş durumunu ifade eder.</summary>
    [Required]
    [ForeignKey("MevcutDisDurumuNavigation")]
    public string MEVCUT_DIS_DURUMU { get; set; }
    /// <summary>Ağızdaki dişler için Sağlık Bilgi Yönetim Sistemi tarafından verilmiş kod bilgis...</summary>
    [Required]
    [ForeignKey("DisNavigation")]
    public string DIS_KODU { get; set; }
    /// <summary>Kişinin diş tedavisi için işlem yapılan bölge bilgisidir. Örneğin tüm çene bölge...</summary>
    [Required]
    [ForeignKey("CeneBolgesiNavigation")]
    public string CENE_BOLGESI { get; set; }
    /// <summary>Kişinin diş tedavisi için işlem yapılan çene bölgesinde bulunan diş bilgisidir.</summary>
    [Required]
    public string CENE_BOLGESI_DISLERI { get; set; }
    /// <summary>Diş protez tedavisi yapılan hastalar için protez bilgilerini kayıt etmek için Sa...</summary>
    [Required]
    [ForeignKey("DisprotezNavigation")]
    public string DISPROTEZ_KODU { get; set; }
    /// <summary>Sağlık tesisinde hasta için yapılan tüm işlemler için MEDULA'dan Sağlık Bilgi Yö...</summary>
    [Required]
    public string SONUC_KODU { get; set; }
    /// <summary>Sağlık tesisinde hasta için yapılan tüm işlemler için MEDULA'dan Sağlık Bilgi Yö...</summary>
    [Required]
    public string SONUC_MESAJI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? DisIslemTuruNavigation { get; set; }
    public virtual HASTA_HIZMET? HastaHizmetNavigation { get; set; }
    public virtual DIS_TAAHHUT? DisTaahhutNavigation { get; set; }
    public virtual REFERANS_KODLAR? MevcutDisDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? DisNavigation { get; set; }
    public virtual REFERANS_KODLAR? CeneBolgesiNavigation { get; set; }
    public virtual DISPROTEZ? DisprotezNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// HASTA_EPIKRIZ tablosu - 12 kolon
/// </summary>
[Table("HASTA_EPIKRIZ")]
public class HASTA_EPIKRIZ
{
    /// <summary>Hekimin muayene yaptıktan sonra hasta için yazdığı epikriz bilgileri için Sağlık...</summary>
    [Key]
    public string HASTA_EPIKRIZ_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Epikrizin yazıldığı zaman bilgisidir.</summary>
    public DateTime? EPIKRIZ_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde hastaya hekimi tarafından yazılan epikrizin başlık bilgisidir.</summary>
    [ForeignKey("EpikrizBaslikBilgisiNavigation")]
    public string EPIKRIZ_BASLIK_BILGISI { get; set; }
    /// <summary>Sağlık tesisine gelen, ayaktan ve yatan hastalar için hekimlerin yazdığı epikriz...</summary>
    [Required]
    public string EPIKRIZ_BILGISI_ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde görevli hekim için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [Required]
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? EpikrizBaslikBilgisiNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// HASTA_FOTOGRAF tablosu - 12 kolon
/// </summary>
[Table("HASTA_FOTOGRAF")]
public class HASTA_FOTOGRAF
{
    /// <summary>Sağlık tesisinde hastanın tedavisine yardımcı olmak amacı ile kaydedilen fotoğra...</summary>
    [Key]
    public string HASTA_FOTOGRAF_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Saglik Bilgi Yönetim Sistemine kayit edilmis fotograflar için Saglik Bilgi Yönet...</summary>
    [Required]
    [ForeignKey("FotografTuruNavigation")]
    public string FOTOGRAF_TURU { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin dosyası için veya sağlık tesisine müracaat e...</summary>
    [Required]
    public string FOTOGRAF_BILGISI { get; set; }
    /// <summary>Kişiye ait fotoğrafın Sağlık Bilgi Yönetim Sistemi’nde kayıt edildiği dosyanın a...</summary>
    [Required]
    public string FOTOGRAF_DOSYA_YOLU { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? FotografTuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// HASTA_GIZLILIK tablosu - 15 kolon
/// </summary>
[Table("HASTA_GIZLILIK")]
public class HASTA_GIZLILIK
{
    /// <summary>Sağlık tesisinde gizlenen hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tara...</summary>
    [Key]
    public string HASTA_GIZLILIK_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Kişinin, sağlık tesisindeki verilerinin gizli olması durumunda verilerin gizlenm...</summary>
    [ForeignKey("GizlilikNedeniNavigation")]
    public string GIZLILIK_NEDENI { get; set; }
    /// <summary>Hastanın tıbbi işlemleri ile ilgili ekranlarda (arayüzlerde) kullanılacak ad bil...</summary>
    [Required]
    public string GORUNECEK_HASTA_ADI { get; set; }
    /// <summary>Hastanın tıbbi işlemleri ile ilgili ekranlarda (arayüzlerde) kullanılacak soyadı...</summary>
    [Required]
    public string GORUNECEK_HASTA_SOYADI { get; set; }
    /// <summary>Kişinin, sağlık tesisindeki hangi verilerinin gizlendiğini ifade eder. Örneğin h...</summary>
    [ForeignKey("GizlilikTuruNavigation")]
    public string GIZLILIK_TURU { get; set; }
    /// <summary>Kişinin, sağlık tesisindeki verilerinin gizlenmesi talebine ilişkin olarak kişin...</summary>
    public DateTime? GIZLILIK_BASLAMA_ZAMANI { get; set; }
    /// <summary>Kişinin, sağlık tesisindeki verilerinin gizlilik durumunun bittiği zaman bilgisi...</summary>
    public DateTime GIZLILIK_BITIS_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? GizlilikNedeniNavigation { get; set; }
    public virtual REFERANS_KODLAR? GizlilikTuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// HASTA_HIZMET tablosu - 46 kolon
/// </summary>
[Table("HASTA_HIZMET")]
public class HASTA_HIZMET
{
    /// <summary>Sağlık tesisinde hastaya uygulanacak hizmetler için Sağlık Bilgi Yönetim Sistemi...</summary>
    [Key]
    public string HASTA_HIZMET_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanan işlemler için Sağlık Bilgi Yönetim Sistemi ta...</summary>
    [ForeignKey("HizmetNavigation")]
    public string HIZMET_KODU { get; set; }
    /// <summary>Sağlık tesisinde doğum yapan hastaya ait bilgilerin kayıt edilmesi için Sağlık B...</summary>
    [Required]
    [ForeignKey("DogumNavigation")]
    public string DOGUM_KODU { get; set; }
    /// <summary>Sağlık tesisinde yapılan ameliyatın işlem bilgilerine erişim sağlamak için Sağlı...</summary>
    [Required]
    [ForeignKey("AmeliyatIslemNavigation")]
    public string AMELIYAT_ISLEM_KODU { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanacak hizmetlerin anlık durum bilgisini ifade ede...</summary>
    [ForeignKey("HastaHizmetDurumuNavigation")]
    public string HASTA_HIZMET_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanan işlemler için fatura kesilip kesilmediğine il...</summary>
    [ForeignKey("HizmetFaturaDurumuNavigation")]
    public string HIZMET_FATURA_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde sağlık hizmetini alan kişi için yapılan işlemlere ilişkin puan ...</summary>
    [Required]
    [ForeignKey("TibbiIslemPuanBilgisiNavigation")]
    public string TIBBI_ISLEM_PUAN_BILGISI { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanan işlemin vücudun hangi tarafına yapıldığına il...</summary>
    [Required]
    [ForeignKey("TarafBilgisiNavigation")]
    public string TARAF_BILGISI { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanan işlemler için hasta dosyasına işlenen işlemin...</summary>
    [Required]
    public string HIZMET_PUAN_BILGISI { get; set; }
    /// <summary>Hastaya uygulanan işlemin gerçekleşme zamanı bilgisidir.</summary>
    public DateTime ISLEM_GERCEKLESME_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde uygulanan tetkik ve tedaviye ilişkin puanların hekimin performa...</summary>
    public DateTime PUAN_HAKEDIS_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde yapılan işlemlerin, uygulanmaya başladığı zaman bilgisidir.</summary>
    public DateTime? ISLEM_ZAMANI { get; set; }
    /// <summary>Kişinin randevu zamanı bilgisidir.</summary>
    public DateTime RANDEVU_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde bulunan cihaza Malzeme Kaynak Yönetim Sisteminde tanımlanmış ol...</summary>
    [Required]
    public string CIHAZ_KUNYE_NUMARASI { get; set; }
    /// <summary>Kişiye sağlık tesisinde uygulanan hizmetlerin sayı bilgisidir.</summary>
    public string HIZMET_ADETI { get; set; }
    /// <summary>Sağlık tesisinde fatura edilen işlemler için adet bilgisidir.</summary>
    [Required]
    public string FATURA_ADET { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanan hizmetler için hasta dosyasına kayıt edilen h...</summary>
    [Required]
    public string HASTA_TUTARI { get; set; }
    /// <summary>Hasta dosyasına işlenen işlemin hastanın sosyal güvencesinin bulunduğu kuruma ya...</summary>
    public string KURUM_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde tedavi gören hastaya yapılan işlem için MEDULA sisteminin ödeme...</summary>
    [Required]
    public string MEDULA_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde tedavi gören hastaların işlemlerine ait MEDULA tarafından Sağlı...</summary>
    [Required]
    public string MEDULA_ISLEM_SIRA_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde tedavi gören hastaların işlemlerine ait Sağlık Bilgi Yönetim Si...</summary>
    [Required]
    public string MEDULA_HIZMET_REF_NUMARASI { get; set; }
    /// <summary>Sağlık Yönetim Sistemi (SYS) Referans Numarası, sağlık tesisine başvuran hastala...</summary>
    [Required]
    public string SYS_REFERANS_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde tedavi gören hasta için, çeşitli kriterlere göre MEDULA tarafın...</summary>
    [Required]
    [ForeignKey("MedulaTakipNavigation")]
    public string MEDULA_TAKIP_KODU { get; set; }
    /// <summary>Sağlık tesisinde tedavi gören hastaların işlemlerine ait MEDULA tarafından tanım...</summary>
    [Required]
    public string MEDULA_OZEL_DURUM { get; set; }
    /// <summary>Sağlık tesisinde işlemi gerçekleştiren veya işlemin sonucunu onaylayan hekim içi...</summary>
    [Required]
    [ForeignKey("OnaylayanHekimNavigation")]
    public string ONAYLAYAN_HEKIM_KODU { get; set; }
    /// <summary>Sağlık tesisinde ilaç, malzeme, ürün vb. istemini yapan hekim için Sağlık Bilgi ...</summary>
    [Required]
    [ForeignKey("IsteyenHekimNavigation")]
    public string ISTEYEN_HEKIM_KODU { get; set; }
    /// <summary>Sağlık tesisinde kesilen fatura kayıtlarına erişim için Sağlık Bilgi Yönetim Sis...</summary>
    [Required]
    [ForeignKey("FaturaNavigation")]
    public string FATURA_KODU { get; set; }
    /// <summary>Sağlık tesisi tarafından kesilen faturanın toplam tutar bilgisidir.</summary>
    [Required]
    public string FATURA_TUTARI { get; set; }
    /// <summary>Sağlık tesisi tarafından hastaya takılan kan ürünleri için Kızılay tarafından ür...</summary>
    [Required]
    public string ISBT_UNITE_NUMARASI { get; set; }
    /// <summary>Sağlık tesisi tarafından hastaya takılan kan ürünleri için Kızılay tarafından ür...</summary>
    [Required]
    public string ISBT_BILESEN_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde yapılan bir işlemin iptal edilip edilmediği bilgisidir.</summary>
    public string IPTAL_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HIZMET? HizmetNavigation { get; set; }
    public virtual DOGUM? DogumNavigation { get; set; }
    public virtual AMELIYAT_ISLEM? AmeliyatIslemNavigation { get; set; }
    public virtual REFERANS_KODLAR? HastaHizmetDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? HizmetFaturaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? TibbiIslemPuanBilgisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? TarafBilgisiNavigation { get; set; }
    public virtual MEDULA_TAKIP? MedulaTakipNavigation { get; set; }
    public virtual PERSONEL? OnaylayanHekimNavigation { get; set; }
    public virtual PERSONEL? IsteyenHekimNavigation { get; set; }
    public virtual FATURA? FaturaNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// HASTA_ILETISIM tablosu - 25 kolon
/// </summary>
[Table("HASTA_ILETISIM")]
public class HASTA_ILETISIM
{
    /// <summary>Sağlık tesisinde hastadan alınan iletişim bilgileri için Sağlık Bilgi Yönetim Si...</summary>
    [Key]
    public string HASTA_ILETISIM_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Kişiye ait kayıt altına alınacak adresin tipini ifade eder.</summary>
    [Required]
    [ForeignKey("AdresTipiNavigation")]
    public string ADRES_TIPI { get; set; }
    /// <summary>Adres kodunun hangi seviyeden seçildiğini ifade eder.</summary>
    [ForeignKey("AdresSeviyesiNavigation")]
    public string ADRES_KODU_SEVIYESI { get; set; }
    /// <summary>Kişinin beyan ettiği adres bilgisidir.</summary>
    [Required]
    public string BEYAN_ADRESI { get; set; }
    /// <summary>Nüfus ve Vatandaşlık İşleri (NVİ) Genel Müdürlüğü tarafından Sağlık Bilgi Yöneti...</summary>
    [Required]
    public string NVI_ADRES { get; set; }
    /// <summary>Adres numarası bilgisidir.</summary>
    [Required]
    public string ADRES_NUMARASI { get; set; }
    /// <summary>İl kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("IlNavigation")]
    public string IL_KODU { get; set; }
    /// <summary>İlçe kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("IlceNavigation")]
    public string ILCE_KODU { get; set; }
    /// <summary>Nüfus ve Vatandaşlık İşlerinden (NVİ) alınan Bucak kod bilgisidir. Örneğin Kemal...</summary>
    [Required]
    [ForeignKey("BucakNavigation")]
    public string BUCAK_KODU { get; set; }
    /// <summary>Nüfus ve Vatandaşlık İşlerinden (NVİ) alınan Köy kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("KoyNavigation")]
    public string KOY_KODU { get; set; }
    /// <summary>Nüfus ve Vatandaşlık İşlerinden (NVİ) alınan Mahalle kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("MahalleNavigation")]
    public string MAHALLE_KODU { get; set; }
    /// <summary>MERNİS tarafından üretilen Cadde Sokak Bucak Mahalle (CSBM) kodu bilgisidir.</summary>
    [Required]
    public string CSBM_KODU { get; set; }
    /// <summary>Adresin dış kapı numarası bilgisidir.</summary>
    [Required]
    public string DIS_KAPI_NUMARASI { get; set; }
    /// <summary>Adresin iç kapı numarası bilgisidir.</summary>
    [Required]
    public string IC_KAPI_NUMARASI { get; set; }
    /// <summary>Kişinin ev telefonu bilgisidir.</summary>
    [Required]
    public string EV_TELEFONU { get; set; }
    /// <summary>Kişinin cep telefonu bilgisidir.</summary>
    [Required]
    public string CEP_TELEFONU { get; set; }
    /// <summary>Kişinin iş telefonu bilgisidir.</summary>
    [Required]
    public string IS_TELEFONU { get; set; }
    /// <summary>Kişinin elektronik posta adresidir.</summary>
    [Required]
    public string EPOSTA_ADRESI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? AdresTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? AdresSeviyesiNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlceNavigation { get; set; }
    public virtual REFERANS_KODLAR? BucakNavigation { get; set; }
    public virtual REFERANS_KODLAR? KoyNavigation { get; set; }
    public virtual REFERANS_KODLAR? MahalleNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// HASTA_MALZEME tablosu - 32 kolon
/// </summary>
[Table("HASTA_MALZEME")]
public class HASTA_MALZEME
{
    /// <summary>Sağlık tesisinde hasta için kullanılan ilaç, malzeme, ürün vb. bilgiler için Sağ...</summary>
    [Key]
    public string HASTA_MALZEME_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan ilaç, malzeme ve ürünlerin bilgilerine erişim sağlamak ...</summary>
    [ForeignKey("StokKartNavigation")]
    public string STOK_KART_KODU { get; set; }
    /// <summary>Sağlık tesisinde kullanılan malzemelerin ayrıntılı hareket bilgilerini takip etm...</summary>
    [ForeignKey("StokHareketNavigation")]
    public string STOK_HAREKET_KODU { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanan malzemeler için fatura kesilip kesilmediğine ...</summary>
    [ForeignKey("MalzemeFaturaDurumuNavigation")]
    public string MALZEME_FATURA_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde yapılan işlemlerin, uygulanmaya başladığı zaman bilgisidir.</summary>
    public DateTime? ISLEM_ZAMANI { get; set; }
    /// <summary>Hastaya uygulanan işlemin gerçekleşme zamanı bilgisidir.</summary>
    public DateTime? ISLEM_GERCEKLESME_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde kişiye aşı uygulanmadan önce Sağlık Bilgi Yönetim Sistemi taraf...</summary>
    [Required]
    public string ATS_SORGU_NUMARASI { get; set; }
    /// <summary>Vericinin uygun bir biçimde tanımlanmış ve bağışlanan materyalin izlenebilirliği...</summary>
    [Required]
    public string ALLOGREFT_DONOR_KODU { get; set; }
    /// <summary>Kişiye sağlık tesisinde kullanılan ilaç/sarf malzeme miktar bilgisidir.</summary>
    public string MALZEME_ADETI { get; set; }
    /// <summary>Sağlık tesisinde fatura edilen işlemler için adet bilgisidir.</summary>
    [Required]
    public string FATURA_ADET { get; set; }
    /// <summary>Sağlık tesisinde kesilen fatura kayıtlarına erişim için Sağlık Bilgi Yönetim Sis...</summary>
    [Required]
    [ForeignKey("FaturaNavigation")]
    public string FATURA_KODU { get; set; }
    /// <summary>Sağlık tesisi tarafından kesilen faturanın toplam tutar bilgisidir.</summary>
    [Required]
    public string FATURA_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanan hizmetler için hasta dosyasına kayıt edilen h...</summary>
    [Required]
    public string HASTA_TUTARI { get; set; }
    /// <summary>Hasta dosyasına işlenen işlemin hastanın sosyal güvencesinin bulunduğu kuruma ya...</summary>
    [Required]
    public string KURUM_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde tedavi gören hastaya yapılan işlem için MEDULA sisteminin ödeme...</summary>
    [Required]
    public string MEDULA_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde tedavi gören hastaların işlemlerine ait MEDULA tarafından Sağlı...</summary>
    [Required]
    public string MEDULA_ISLEM_SIRA_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde tedavi gören hastaların işlemlerine ait Sağlık Bilgi Yönetim Si...</summary>
    [Required]
    public string MEDULA_HIZMET_REF_NUMARASI { get; set; }
    /// <summary>Sağlık Yönetim Sistemi (SYS) Referans Numarası, sağlık tesisine başvuran hastala...</summary>
    [Required]
    public string SYS_REFERANS_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde tedavi gören hasta için, çeşitli kriterlere göre MEDULA tarafın...</summary>
    [Required]
    [ForeignKey("MedulaTakipNavigation")]
    public string MEDULA_TAKIP_KODU { get; set; }
    /// <summary>Sağlık tesisinde tedavi gören hastaların işlemlerine ait MEDULA tarafından tanım...</summary>
    [Required]
    public string MEDULA_OZEL_DURUM { get; set; }
    /// <summary>Sağlık tesisinde yapılan ameliyatın bilgilerine erişim sağlamak için Sağlık Bilg...</summary>
    [Required]
    [ForeignKey("AmeliyatNavigation")]
    public string AMELIYAT_KODU { get; set; }
    /// <summary>Sağlık tesisinde ilaç, malzeme, ürün vb. istemini yapan hekim için Sağlık Bilgi ...</summary>
    [ForeignKey("IsteyenHekimNavigation")]
    public string ISTEYEN_HEKIM_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan stok depoları için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [ForeignKey("DepoNavigation")]
    public string DEPO_KODU { get; set; }
    /// <summary>Sağlık tesisinde yapılan bir işlemin iptal edilip edilmediği bilgisidir.</summary>
    public string IPTAL_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual STOK_KART? StokKartNavigation { get; set; }
    public virtual STOK_HAREKET? StokHareketNavigation { get; set; }
    public virtual REFERANS_KODLAR? MalzemeFaturaDurumuNavigation { get; set; }
    public virtual FATURA? FaturaNavigation { get; set; }
    public virtual MEDULA_TAKIP? MedulaTakipNavigation { get; set; }
    public virtual AMELIYAT? AmeliyatNavigation { get; set; }
    public virtual PERSONEL? IsteyenHekimNavigation { get; set; }
    public virtual DEPO? DepoNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// HASTA_NOTLARI tablosu - 11 kolon
/// </summary>
[Table("HASTA_NOTLARI")]
public class HASTA_NOTLARI
{
    /// <summary>Hastaya özgü girilen not için Sağlık Bilgi Yönetim Sistemi tarafından üretilen t...</summary>
    [Key]
    public string HASTA_NOTLARI_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Hastaya özgü girilen notun Sağlık Bilgi Yönetim Sistemi tarafından belirlenmiş g...</summary>
    public string HASTA_NOT_TURU { get; set; }
    /// <summary>Hastaya özgü girilen notu yazan personel için SBYS tarafından tanımlanmış kod bi...</summary>
    public string PERSONEL_KODU { get; set; }
    /// <summary>Hastaya özgü girilen not için yazılan açıklama bilgisini ifade eder.</summary>
    public string HASTA_NOT_ACIKLAMASI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// HASTA_OLUM tablosu - 24 kolon
/// </summary>
[Table("HASTA_OLUM")]
public class HASTA_OLUM
{
    /// <summary>Hasta ölüm bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından üretilen tekil...</summary>
    [Key]
    public string HASTA_OLUM_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Kişinin ölüm zamanı bilgisidir.</summary>
    public DateTime? OLUM_ZAMANI { get; set; }
    /// <summary>Ölümün gerçeklestigi yeri ifade eder. Örnegin ev, is, birinci basamak saglik kur...</summary>
    [Required]
    [ForeignKey("OlumYeriNavigation")]
    public string OLUM_YERI { get; set; }
    /// <summary>Bir kadının, gebelik sırasında ya da gebeliğin sonlanmasından sonraki 42 gün içi...</summary>
    [Required]
    [ForeignKey("AnneOlumNedeniNavigation")]
    public string ANNE_OLUM_NEDENI { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Ölümden sonra hastalıktan kaynaklanan bir değişimin özellikle boyutunu ya da ölü...</summary>
    [Required]
    [ForeignKey("OtopsiDurumuNavigation")]
    public string OTOPSI_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde ölüm belgesini düzenleyen personel için Sağlık Bilgi Yönetim Si...</summary>
    [Required]
    [ForeignKey("OlumBelgesiPersonelNavigation")]
    public string OLUM_BELGESI_PERSONEL_KODU { get; set; }
    /// <summary>Ölüm nedeni, ölüme katkıda bulunmuş ya da ölümle sonuçlanmış tüm hastalıklar, mo...</summary>
    [Required]
    [ForeignKey("OlumNedeniTaniNavigation")]
    public string OLUM_NEDENI_TANI_KODU { get; set; }
    /// <summary>Ölüm nedenlerinin sınıflandırılmasını ifade eder. Örneğin son neden, ara neden v...</summary>
    [Required]
    [ForeignKey("OlumNedeniTuruNavigation")]
    public string OLUM_NEDENI_TURU { get; set; }
    /// <summary>Ölümün ne şekilde gerçekleştiğini ifade eder. Örneğin doğal ölüm, iş kazası, cin...</summary>
    [ForeignKey("OlumSekliNavigation")]
    public string OLUM_SEKLI { get; set; }
    /// <summary>Kişinin öldüğüne dair ölüm kararını veren hekim için Sağlık Bilgi Yönetim Sistem...</summary>
    [Required]
    [ForeignKey("ExKarariniVerenHekimNavigation")]
    public string EX_KARARINI_VEREN_HEKIM_KODU { get; set; }
    /// <summary>Sağlık tesisinde ölüm gibi olaylar esnasında tutulan tutanağın zaman bilgisidir.</summary>
    public DateTime TUTANAK_ZAMANI { get; set; }
    /// <summary>Kan ürünü, numune, adli rapor, nüfus cüzdanı, malzeme vb. teslim alan kişinin T....</summary>
    [Required]
    public string TESLIM_ALAN_TC_KIMLIK_NUMARASI { get; set; }
    /// <summary>Kan ürünü, numune, adli rapor, nüfus cüzdanı, malzeme vb. teslim alan kişinin ad...</summary>
    [Required]
    public string TESLIM_ALAN_ADI_SOYADI { get; set; }
    /// <summary>Kan ürünü, numune, adli rapor, nüfus cüzdanı, malzeme vb. teslim alan kişinin te...</summary>
    [Required]
    public string TESLIM_ALAN_TELEFON_BILGISI { get; set; }
    /// <summary>Kan ürünü, numune, adli rapor, nüfus cüzdanı, malzeme vb. teslim alan kişinin ad...</summary>
    [Required]
    public string TESLIM_ALAN_ADRESI { get; set; }
    /// <summary>Kan ürünü, numune, adli rapor, nüfus cüzdanı, malzeme vb. ilgili kişiye teslim e...</summary>
    [Required]
    [ForeignKey("TeslimEdenPersonelNavigation")]
    public string TESLIM_EDEN_PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? OlumYeriNavigation { get; set; }
    public virtual REFERANS_KODLAR? AnneOlumNedeniNavigation { get; set; }
    public virtual REFERANS_KODLAR? OtopsiDurumuNavigation { get; set; }
    public virtual PERSONEL? OlumBelgesiPersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? OlumNedeniTaniNavigation { get; set; }
    public virtual REFERANS_KODLAR? OlumNedeniTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? OlumSekliNavigation { get; set; }
    public virtual PERSONEL? ExKarariniVerenHekimNavigation { get; set; }
    public virtual PERSONEL? TeslimEdenPersonelNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// HASTA_SEANS tablosu - 35 kolon
/// </summary>
[Table("HASTA_SEANS")]
public class HASTA_SEANS
{
    /// <summary>Sağlık tesisinde tedavi kapsamında hastalara verilen seans bilgileri için Sağlık...</summary>
    [Key]
    public string HASTA_SEANS_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Hastanın sağlık tesisinde tedavisinin gereği olarak aldığı seansın hangi tedavi ...</summary>
    [ForeignKey("SeansIslemTuruNavigation")]
    public string SEANS_ISLEM_TURU { get; set; }
    /// <summary>Sağlık tesisinde bulunan cihaz için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [Required]
    [ForeignKey("CihazNavigation")]
    public string CIHAZ_KODU { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanan tedavi kapsamında yapılması planlanan seans t...</summary>
    public DateTime? PLANLANAN_SEANS_TARIHI { get; set; }
    /// <summary>Hastanın sağlık tesisinde tedavisinin gereği olarak aldığı seansa başladığı zama...</summary>
    public DateTime SEANS_BASLAMA_ZAMANI { get; set; }
    /// <summary>Hastanın sağlık tesisinde tedavisinin gereği olarak aldığı seansın bittiği zaman...</summary>
    public DateTime SEANS_BITIS_ZAMANI { get; set; }
    /// <summary>Kişinin kullandığı antihipertansif ilaç kullanım durumunu ifade eder.</summary>
    [Required]
    [ForeignKey("AntihipertansifIlacDurumuNavigation")]
    public string ANTIHIPERTANSIF_ILAC_DURUMU { get; set; }
    /// <summary>Kişinin Önceki Renal Replasman yöntemi bilgisidir.</summary>
    [ForeignKey("OncekiRrtYontemiNavigation")]
    public string ONCEKI_RRT_YONTEMI { get; set; }
    /// <summary>Kişinin hemodiyalize geçme nedenini ifade eder.</summary>
    [Required]
    [ForeignKey("HemodiyalizeGecmeNedenleriNavigation")]
    public string HEMODIYALIZE_GECME_NEDENLERI { get; set; }
    /// <summary>Hastanın tedavisi için ne tür damar erişim yolu kullanıldığını ifade eder.</summary>
    [Required]
    [ForeignKey("DamarErisimYoluNavigation")]
    public string DAMAR_ERISIM_YOLU { get; set; }
    /// <summary>Hastanın haftada kaç defa diyaliz tedavisi aldığını ifade eder.</summary>
    [Required]
    [ForeignKey("DiyalizeGirmeSikligiNavigation")]
    public string DIYALIZE_GIRME_SIKLIGI { get; set; }
    /// <summary>Diyaliz hastasının beden kitle endeksine göre kullanılacak olan metrekare cinsin...</summary>
    [Required]
    [ForeignKey("DiyalizorAlaniNavigation")]
    public string DIYALIZOR_ALANI { get; set; }
    /// <summary>Hastanın diyalizi için kullanılan diyalizör tipi bilgisidir.</summary>
    [Required]
    [ForeignKey("DiyalizorTipiNavigation")]
    public string DIYALIZOR_TIPI { get; set; }
    /// <summary>Hemodiyaliz tedavisi için kullanılan cihazda ayarlanan kan akım hızıdır.</summary>
    [Required]
    [ForeignKey("KanAkimHiziNavigation")]
    public string KAN_AKIM_HIZI { get; set; }
    /// <summary>Kişinin ağırlığının ölçüm zamanı bilgisidir.</summary>
    [Required]
    [ForeignKey("AgirlikOlcumZamaniNavigation")]
    public string AGIRLIK_OLCUM_ZAMANI { get; set; }
    /// <summary>Hastaya uygulanan tedavi yöntemini ifade eder.</summary>
    [Required]
    [ForeignKey("KullanilanDiyalizTedavisiNavigation")]
    public string KULLANILAN_DIYALIZ_TEDAVISI { get; set; }
    /// <summary>Hastanın peritoneal geçirgenlik durumunu ifade eder. Örneğin düşük, orta, yüksek...</summary>
    [Required]
    [ForeignKey("PeritonealGecirgenlikDurumuNavigation")]
    public string PERITONEAL_GECIRGENLIK_DURUMU { get; set; }
    /// <summary>Periton diyalizi gören hastanın kaçıncı kateteri olduğunu ifade eder.</summary>
    [Required]
    [ForeignKey("PeritonKacinciKateterNavigation")]
    public string PERITON_KACINCI_KATETER { get; set; }
    /// <summary>Periton diyalizinde kullanılan kateter tipini ifade eder. Örneğin curlet tenckho...</summary>
    [Required]
    [ForeignKey("PeritonKateterTipiNavigation")]
    public string PERITON_KATETER_TIPI { get; set; }
    /// <summary>Periton diyalizi tedavisi gören hastaya uygulanan kateter yerleştirme yöntemini ...</summary>
    [Required]
    [ForeignKey("PeritonKateterYontemiNavigation")]
    public string PERITON_KATETER_YONTEMI { get; set; }
    /// <summary>Periton diyalizi tedavisi uygulanan hastanın kateter için açılan tünel yönünü if...</summary>
    [Required]
    [ForeignKey("PeritonTunelYonuNavigation")]
    public string PERITON_TUNEL_YONU { get; set; }
    /// <summary>Hastanın sekonder hiperparatiroidizm tedavisine ihtiyacı olup olmadığını, ihtiya...</summary>
    [Required]
    [ForeignKey("SinekalsetNavigation")]
    public string SINEKALSET { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanan tedavinin seyir bilgisidir. Örneğin diyaliz t...</summary>
    [Required]
    [ForeignKey("TedavininSeyriNavigation")]
    public string TEDAVININ_SEYRI { get; set; }
    /// <summary>Hastanın aktif Vitamin D kullanım ihtiyacını ve uygulama yolunu ifade eder.</summary>
    [Required]
    [ForeignKey("AktifVitaminDKullanimiNavigation")]
    public string AKTIF_VITAMIN_D_KULLANIMI { get; set; }
    /// <summary>Hastanın anemi tedavisine ihtiyacı olup olmadığını, ihtiyacı varsa hangi yönteml...</summary>
    [Required]
    [ForeignKey("AnemiTedavisiYontemiNavigation")]
    public string ANEMI_TEDAVISI_YONTEMI { get; set; }
    /// <summary>Hastanın fosfor bağlayıcı ajan ile tedavi ihtiyacı olup olmadığını, ihtiyacı var...</summary>
    [Required]
    [ForeignKey("FosforBaglayiciAjanNavigation")]
    public string FOSFOR_BAGLAYICI_AJAN { get; set; }
    /// <summary>Periton diyalizi tedavisi verilen hastada görülen komplikasyonları ifade eder. Ö...</summary>
    [Required]
    [ForeignKey("PeritonKomplikasyonNavigation")]
    public string PERITON_KOMPLIKASYON { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? SeansIslemTuruNavigation { get; set; }
    public virtual CIHAZ? CihazNavigation { get; set; }
    public virtual REFERANS_KODLAR? AntihipertansifIlacDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? OncekiRrtYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? HemodiyalizeGecmeNedenleriNavigation { get; set; }
    public virtual REFERANS_KODLAR? DamarErisimYoluNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyalizeGirmeSikligiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyalizorAlaniNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyalizorTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanAkimHiziNavigation { get; set; }
    public virtual REFERANS_KODLAR? AgirlikOlcumZamaniNavigation { get; set; }
    public virtual REFERANS_KODLAR? KullanilanDiyalizTedavisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? PeritonealGecirgenlikDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? PeritonKacinciKateterNavigation { get; set; }
    public virtual REFERANS_KODLAR? PeritonKateterTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? PeritonKateterYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? PeritonTunelYonuNavigation { get; set; }
    public virtual REFERANS_KODLAR? SinekalsetNavigation { get; set; }
    public virtual REFERANS_KODLAR? TedavininSeyriNavigation { get; set; }
    public virtual REFERANS_KODLAR? AktifVitaminDKullanimiNavigation { get; set; }
    public virtual REFERANS_KODLAR? AnemiTedavisiYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? FosforBaglayiciAjanNavigation { get; set; }
    public virtual REFERANS_KODLAR? PeritonKomplikasyonNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// HASTA_SEVK tablosu - 25 kolon
/// </summary>
[Table("HASTA_SEVK")]
public class HASTA_SEVK
{
    /// <summary>Sağlık tesisinden başka bir sağlık tesisine sevk edilen hastanın sevk bilgileri ...</summary>
    [Key]
    public string HASTA_SEVK_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>HASTA görüntüsündeki HASTA_KODU bilgisidir.</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sevk edilen hastanın MEDULA sisteminden Sağlık Bilgi Yönetim Sistemine iletilen ...</summary>
    [Required]
    public string SEVK_TAKIP_NUMARASI { get; set; }
    /// <summary>Sağlık tesisine sevk edilerek gelen hastanın sevk nedeni bilgisidir.</summary>
    [Required]
    [ForeignKey("SevkNedeniNavigation")]
    public string SEVK_NEDENI { get; set; }
    /// <summary>Sağlık tesisindeki hastanın sevk edildiği kliniğin MEDULA’daki branş kodu bilgis...</summary>
    [Required]
    public string SEVK_EDILEN_BRANS_KODU { get; set; }
    /// <summary>Sağlık tesisindeki hastanın sevk edildiği kurum bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("SevkEdilenKurumNavigation")]
    public string SEVK_EDILEN_KURUM_KODU { get; set; }
    /// <summary>Hastanın ilk başvurduğu sağlık tesisinin (sevk edildiği sağlık tesisi) hastayı b...</summary>
    public DateTime? SEVK_ZAMANI { get; set; }
    /// <summary>Hastanın sevk gerekçesi olan hastalık tanı (ları) dır.</summary>
    [Required]
    [ForeignKey("SevkTanisiNavigation")]
    public string SEVK_TANISI { get; set; }
    /// <summary>Sevk edilen hastaya eşlik eden kişi bilgisini ifade eder. Örneğin refakatli, pol...</summary>
    [Required]
    [ForeignKey("SevkSekliNavigation")]
    public string SEVK_SEKLI { get; set; }
    /// <summary>Hastanın sevk edildiği araç için Sağlık Bilgi Yönetim Sistemi tarafından üretile...</summary>
    [Required]
    [ForeignKey("SevkVasitasiNavigation")]
    public string SEVK_VASITASI_KODU { get; set; }
    /// <summary>Sağlık tesisinden sevk edilen hastanın, sevk edildiği yerde uygulanacak tedavi b...</summary>
    [Required]
    [ForeignKey("SevkTedaviTipiNavigation")]
    public string SEVK_TEDAVI_TIPI { get; set; }
    /// <summary>Sağlık tesisinde sevk edilen hasta için yapılan açıklama bilgisini ifade eder.</summary>
    [Required]
    public string SEVK_ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisindeki hastanın sevk kararını veren hekime ait Sağlık Bilgi Yönetim ...</summary>
    [ForeignKey("SevkEden1PersonelNavigation")]
    public string SEVK_EDEN_1_PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisindeki hastanın sevk kararını veren hekime ait Sağlık Bilgi Yönetim ...</summary>
    [Required]
    [ForeignKey("SevkEden2PersonelNavigation")]
    public string SEVK_EDEN_2_PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisindeki hastanın sevk kararını veren hekime ait Sağlık Bilgi Yönetim ...</summary>
    [Required]
    [ForeignKey("SevkEden3PersonelNavigation")]
    public string SEVK_EDEN_3_PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisinde yatan hastanın refakatçisinin olup olmadığına ilişkin bilgiyi i...</summary>
    [Required]
    public string REFAKATCI_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde tedavi gören hastanın başka bir sağlık tesisine sevk edilmesi d...</summary>
    [Required]
    public string MEDULA_E_SEVK_NUMARASI { get; set; }
    /// <summary>Ambulans ile sevk edilen hasta için oluşturulmuş protokol numarası bilgisidir.</summary>
    [Required]
    public string AMBULANS_PROTOKOL_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? SevkNedeniNavigation { get; set; }
    public virtual KURUM? SevkEdilenKurumNavigation { get; set; }
    public virtual REFERANS_KODLAR? SevkTanisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SevkSekliNavigation { get; set; }
    public virtual REFERANS_KODLAR? SevkVasitasiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SevkTedaviTipiNavigation { get; set; }
    public virtual PERSONEL? SevkEden1PersonelNavigation { get; set; }
    public virtual PERSONEL? SevkEden2PersonelNavigation { get; set; }
    public virtual PERSONEL? SevkEden3PersonelNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// HASTA_TIBBI_BILGI tablosu - 11 kolon
/// </summary>
[Table("HASTA_TIBBI_BILGI")]
public class HASTA_TIBBI_BILGI
{
    /// <summary>Sağlık tesisinde tedavi olan hastaya ait tüm tıbbi bilgiler için Sağlık Bilgi Yö...</summary>
    [Key]
    public string HASTA_TIBBI_BILGI_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde sağlık hizmetini alan kişinin tıbbi bilgisinin tür bilgisidir. ...</summary>
    [ForeignKey("TibbiBilgiTuruNavigation")]
    public string TIBBI_BILGI_TURU { get; set; }
    /// <summary>Sağlık tesisinde sağlık hizmetini alan kişinin tıbbi bilgisinin alt tür bilgisid...</summary>
    [ForeignKey("TibbiBilgiAltTuruNavigation")]
    public string TIBBI_BILGI_ALT_TURU { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? TibbiBilgiTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? TibbiBilgiAltTuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// HASTA_UYARI tablosu - 13 kolon
/// </summary>
[Table("HASTA_UYARI")]
public class HASTA_UYARI
{
    /// <summary>Sağlık tesisine başvuran hasta için personele yapılması gereken uyarılar için Sa...</summary>
    [Key]
    public string HASTA_UYARI_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde yapılan bir işlem, kişiye uygulanan tedavi, verilen ilaç vb. du...</summary>
    [ForeignKey("UyariTuruNavigation")]
    public string UYARI_TURU { get; set; }
    /// <summary>Sağlık tesisinde tedavi olan hastaya yapılacak her hangi bir işlemin yapılması i...</summary>
    public string ISLEME_IZIN_VERME_DURUMU { get; set; }
    /// <summary>Sağlık tesisine başvuran kişi için yapılması planlanan uyarıların başlaması gere...</summary>
    public DateTime? HASTA_UYARI_BASLAMA_ZAMANI { get; set; }
    /// <summary>Sağlık tesisine başvuran kişi için yapılması planlanan uyarıların bitmesi gereke...</summary>
    public DateTime HASTA_UYARI_BITIS_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? UyariTuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// HASTA_VENTILATOR tablosu - 12 kolon
/// </summary>
[Table("HASTA_VENTILATOR")]
public class HASTA_VENTILATOR
{
    /// <summary>Sağlık tesisinde bulunan ventilatörlerin kullanım bilgisi için Sağlık Bilgi Yöne...</summary>
    [Key]
    public string HASTA_VENTILATOR_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisindeki tıbbi cihazlar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("VentilatorCihazNavigation")]
    public string VENTILATOR_CIHAZ_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan yoğun bakım yatak seviyesi bilgisidir. Örneğin 1.seviye...</summary>
    [Required]
    [ForeignKey("YogunBakimSeviyeBilgisiNavigation")]
    public string YOGUN_BAKIM_SEVIYE_BILGISI { get; set; }
    /// <summary>Hastanın ventilatöre ilk bağlandığı zaman bilgisidir.</summary>
    public DateTime? VENTILATOR_BAGLAMA_ZAMANI { get; set; }
    /// <summary>Hastanın ventilatörden ayrıldığı zaman bilgisidir.</summary>
    public DateTime VENTILATOR_AYRILMA_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual CIHAZ? VentilatorCihazNavigation { get; set; }
    public virtual REFERANS_KODLAR? YogunBakimSeviyeBilgisiNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// HASTA_VITAL_FIZIKI_BULGU tablosu - 23 kolon
/// </summary>
[Table("HASTA_VITAL_FIZIKI_BULGU")]
public class HASTA_VITAL_FIZIKI_BULGU
{
    /// <summary>Sağlık tesisinde tedavi olan hastanın vital bulguları için Sağlık Bilgi Yönetim ...</summary>
    [Key]
    public string HASTA_VITAL_FIZIKI_BULGU_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde yapılan işlemlerin, uygulanmaya başladığı zaman bilgisidir.</summary>
    public DateTime? ISLEM_ZAMANI { get; set; }
    /// <summary>Sistolik kan basıncı (büyük tansiyon) bilgisini ifade eder.</summary>
    [Required]
    public string SISTOLIK_KAN_BASINCI_DEGERI { get; set; }
    /// <summary>Kan basıncı ölçme protokolüne uygun olarak "mm Hg" birimi ile ölçülen diastolik ...</summary>
    [Required]
    public string DIASTOLIK_KAN_BASINCI_DEGERI { get; set; }
    /// <summary>Hastanın 1 dakikadaki atım sayısı cinsinden nabız bilgisidir.</summary>
    [Required]
    public string NABIZ { get; set; }
    /// <summary>Hastanın solunum bilgisidir.</summary>
    [Required]
    public string SOLUNUM { get; set; }
    /// <summary>Kişinin santigrat cinsinden vücut ısısı bilgisidir.</summary>
    [Required]
    public string ATES { get; set; }
    /// <summary>Bebek veya çocuğun baş çevresinin (santimetre cinsinden) ölçüsüdür.</summary>
    [Required]
    public string BAS_CEVRESI { get; set; }
    /// <summary>Kişinin santimetre cinsinden boy bilgisidir.</summary>
    [Required]
    public string BOY { get; set; }
    /// <summary>Kişinin (gram cinsinden) ağırlığıdır.</summary>
    [Required]
    public string AGIRLIK { get; set; }
    /// <summary>Kişinin yüzde cinsinden oksijen saturasyonu bilgisini ifade eder.</summary>
    [Required]
    public string SATURASYON { get; set; }
    /// <summary>Hastanın (santimetre cinsinden) bel çevresidir.</summary>
    [Required]
    public string BEL_CEVRESI { get; set; }
    /// <summary>Hastanın (santimetre cinsinden) kalça çevresidir</summary>
    [Required]
    public string KALCA_CEVRESI { get; set; }
    /// <summary>Hastanın santimetre cinsinden kol çevresi ölçüsü bilgisidir.</summary>
    [Required]
    public string KOL_CEVRESI { get; set; }
    /// <summary>Hastanın santimetre cinsinden karın çevresi ölçüsü bilgisidir.</summary>
    [Required]
    public string KARIN_CEVRESI { get; set; }
    /// <summary>Sağlık tesisinde görevli hemşire için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [Required]
    [ForeignKey("HemsireNavigation")]
    public string HEMSIRE_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual PERSONEL? HemsireNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// HASTA_YATAK tablosu - 11 kolon
/// </summary>
[Table("HASTA_YATAK")]
public class HASTA_YATAK
{
    /// <summary>Sağlık tesisindeki hasta yataklarının kullanım bilgisi için Sağlık Bilgi Yönetim...</summary>
    [Key]
    public string HASTA_YATAK_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi tarafından sağlık tesisindeki yataklar için üretile...</summary>
    [ForeignKey("YatakNavigation")]
    public string YATAK_KODU { get; set; }
    /// <summary>Sağlık tesisinde yatışı verilen hastanın yatağa ilk yattığı zaman bilgisidir.</summary>
    public DateTime? YATIS_BASLAMA_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde yatışı verilen hastanın yataktan ayrıldığı zaman bilgisidir.</summary>
    public DateTime YATIS_BITIS_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual YATAK? YatakNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// HEMOGLOBINOPATI tablosu - 14 kolon
/// </summary>
[Table("HEMOGLOBINOPATI")]
public class HEMOGLOBINOPATI
{
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Key]
    public string HEMOGLOBINOPATI_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Kişinin hemoglobinopati tarama sonucuna ilişkin bilgiyi ifade eder.</summary>
    [Required]
    [ForeignKey("HemoglobinopatiTaramaSonucuNavigation")]
    public string HEMOGLOBINOPATI_TARAMA_SONUCU { get; set; }
    /// <summary>Kişinin eş adayının T.C. Kimlik Numarası bilgisidir.</summary>
    [Required]
    public string ES_ADAYI_TC_KIMLIK_NUMARASI { get; set; }
    /// <summary>Kişinin eş adayının telefon numarası bilgisidir.</summary>
    [Required]
    public string ES_ADAYI_TELEFON_NUMARASI { get; set; }
    /// <summary>Kişinin hemoglobinopati tarama testinin sonuç bilgisidir.</summary>
    [ForeignKey("HemoglobinopatiTestiSonucuNavigation")]
    public string HEMOGLOBINOPATI_TESTI_SONUCU { get; set; }
    /// <summary>Kişiye yapılan hemoglobinopati tarama testinin yapılma amacına ilişkin işlem bil...</summary>
    public string HEMOGLOBINOPATI_ISLEM_TIPI { get; set; }
    /// <summary>Kişinin hemoglobinopati test sonucu hastalık türü bilgisidir.</summary>
    [Required]
    [ForeignKey("HemoglobinopatiSonucHastalikNavigation")]
    public string HEMOGLOBINOPATI_SONUC_HASTALIK { get; set; }
    /// <summary>Kişinin hemoglobinopati test sonucu taşıyıcılık türü bilgisidir.</summary>
    [Required]
    [ForeignKey("HemoglobinopatiTasiyicilikNavigation")]
    public string HEMOGLOBINOPATI_TASIYICILIK { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? HemoglobinopatiTaramaSonucuNavigation { get; set; }
    public virtual REFERANS_KODLAR? HemoglobinopatiTestiSonucuNavigation { get; set; }
    public virtual REFERANS_KODLAR? HemoglobinopatiSonucHastalikNavigation { get; set; }
    public virtual REFERANS_KODLAR? HemoglobinopatiTasiyicilikNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// HEMSIRE_BAKIM tablosu - 17 kolon
/// </summary>
[Table("HEMSIRE_BAKIM")]
public class HEMSIRE_BAKIM
{
    /// <summary>Sağlık tesisinde tedavi olan hastaya hemşire tarafından uygulanan bakım bilgiler...</summary>
    [Key]
    public string HEMSIRE_BAKIM_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Hemşirenin hastayı değerlendirdiği zaman bilgisidir.</summary>
    public DateTime? HEMSIRE_DEGERLENDIRME_ZAMANI { get; set; }
    /// <summary>Hemşirelik bakım planı kapsamında hemşire tarafından hastaya konulan hemşirelik ...</summary>
    [ForeignKey("HemsirelikTaniNavigation")]
    public string HEMSIRELIK_TANI_KODU { get; set; }
    /// <summary>Sağlık tesisinde tedavi olan hastalara hemşire tarafından uygulanan bakıma ilişk...</summary>
    [Required]
    [ForeignKey("BakimNedeniNavigation")]
    public string BAKIM_NEDENI { get; set; }
    /// <summary>Sağlık tesisinde tedavi olan hastaya hemşire tarafından uygulanan bakım tedavisi...</summary>
    [Required]
    [ForeignKey("HemsireBakimHedefSonucNavigation")]
    public string HEMSIRE_BAKIM_HEDEF_SONUC { get; set; }
    /// <summary>Sağlık tesisinde tedavi alan hasta için hemşire tarafından uygulanan girişim bil...</summary>
    [Required]
    [ForeignKey("HemsirelikGirisimiNavigation")]
    public string HEMSIRELIK_GIRISIMI { get; set; }
    /// <summary>Sağlık tesisinde tedavi olan hastaya hemşire tarafından uygulanan bakım için hem...</summary>
    [Required]
    [ForeignKey("HemsireDegerlendirmeDurumuNavigation")]
    public string HEMSIRE_DEGERLENDIRME_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde tedavi gören hastaya, hemşire tarafından uygulanan işlemlere il...</summary>
    [Required]
    public string HEMSIRE_DEGERLENDIRME_NOTU { get; set; }
    /// <summary>Sağlık tesisinde görevli hemşire için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [Required]
    [ForeignKey("HemsireNavigation")]
    public string HEMSIRE_KODU { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? HemsirelikTaniNavigation { get; set; }
    public virtual REFERANS_KODLAR? BakimNedeniNavigation { get; set; }
    public virtual REFERANS_KODLAR? HemsireBakimHedefSonucNavigation { get; set; }
    public virtual REFERANS_KODLAR? HemsirelikGirisimiNavigation { get; set; }
    public virtual REFERANS_KODLAR? HemsireDegerlendirmeDurumuNavigation { get; set; }
    public virtual PERSONEL? HemsireNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// HIZMET tablosu - 15 kolon
/// </summary>
[Table("HIZMET")]
public class HIZMET
{
    /// <summary>Sağlık tesisinde hastaya uygulanan işlemler için Sağlık Bilgi Yönetim Sistemi ta...</summary>
    [Key]
    public string HIZMET_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde kullanılan tetkik, tedavi vb. işlemlerinin gruplandırılması içi...</summary>
    [Required]
    [ForeignKey("HizmetIslemGrubuNavigation")]
    public string HIZMET_ISLEM_GRUBU { get; set; }
    /// <summary>Sağlık tesisinde kullanılan tetkik, tedavi vb. işlemleri için Sağlık Bilgi Yönet...</summary>
    [Required]
    [ForeignKey("HizmetIslemTuruNavigation")]
    public string HIZMET_ISLEM_TURU { get; set; }
    /// <summary>Sosyal Güvenlik Kurumu tarafından yayımlanan, hastaya uygulanan işlem veya hizme...</summary>
    [Required]
    public string SUT_KODU { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanan işlemler için Sağlık Bilgi Yönetim Sisteminde...</summary>
    public string HIZMET_ADI { get; set; }
    /// <summary>Sağlık tesisinde sağlık hizmetini alan kişi için yapılan işlemlere ilişkin puan ...</summary>
    [Required]
    [ForeignKey("TibbiIslemPuanBilgisiNavigation")]
    public string TIBBI_ISLEM_PUAN_BILGISI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi veri tabanında bulunan bir kayıtın aktif olup olmad...</summary>
    public string AKTIFLIK_BILGISI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual REFERANS_KODLAR? HizmetIslemGrubuNavigation { get; set; }
    public virtual REFERANS_KODLAR? HizmetIslemTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? TibbiIslemPuanBilgisiNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// ICMAL tablosu - 13 kolon
/// </summary>
[Table("ICMAL")]
public class ICMAL
{
    /// <summary>Sağlık tesisinde kesilen faturaları gruplandırmak için tanımlanan icmal için Sağ...</summary>
    [Key]
    public string ICMAL_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>İcmalin ait olduğu dönem bilgisidir.</summary>
    public string ICMAL_DONEMI { get; set; }
    /// <summary>Sağlık tesisinde kesilen faturaları gruplandırmak için tanımlanan icmal için Sağ...</summary>
    public string ICMAL_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde kesilen faturaları gruplandırmak için tanımlanan icmal adı bilg...</summary>
    [Required]
    public string ICMAL_ADI { get; set; }
    /// <summary>Kişinin yararlandığı sağlık güvencesinin kurumuna ait bilgiler için Sağlık Bilgi...</summary>
    [Required]
    [ForeignKey("KurumNavigation")]
    public string KURUM_KODU { get; set; }
    /// <summary>İcmalin kullanıcı tarafından oluşturulduğu zaman bilgisidir.</summary>
    public DateTime? ICMAL_ZAMANI { get; set; }
    /// <summary>İcmal tutarı bilgisidir.</summary>
    public string ICMAL_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual KURUM? KurumNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// ILAC_UYUM tablosu - 17 kolon
/// </summary>
[Table("ILAC_UYUM")]
public class ILAC_UYUM
{
    /// <summary>Hastaya verilen ilaçlar arasında uyum bilgisi için Sağlık Bilgi Yönetim Sistemi ...</summary>
    [Key]
    public string ILAC_UYUM_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Hastaya verilen ilaçlar arasında tespit edilen uyumsuzluk için yapılan sınıfland...</summary>
    [ForeignKey("IlacUyumsuzlukTuruNavigation")]
    public string ILAC_UYUMSUZLUK_TURU { get; set; }
    /// <summary>Sağlık tesisinde birlikte kullanılan ilaçlar arasında etkileşim durumu sorgulama...</summary>
    [Required]
    [ForeignKey("BirinciIlacBarkoduNavigation")]
    public string BIRINCI_ILAC_BARKODU { get; set; }
    /// <summary>İlacın içeriğinde bulunan etken maddeler için Sağlık Bilgi Yönetim Sistemi taraf...</summary>
    [Required]
    [ForeignKey("BirinciEtkenMaddeNavigation")]
    public string BIRINCI_ETKEN_MADDE_KODU { get; set; }
    /// <summary>Sağlık tesisinde birlikte kullanılan ilaçlar arasında etkileşim durumu sorgulama...</summary>
    [Required]
    [ForeignKey("IkinciIlacBarkoduNavigation")]
    public string IKINCI_ILAC_BARKODU { get; set; }
    /// <summary>İlacın içeriğinde bulunan etken maddeler için Sağlık Bilgi Yönetim Sistemi taraf...</summary>
    [Required]
    [ForeignKey("IkinciEtkenMaddeNavigation")]
    public string IKINCI_ETKEN_MADDE_KODU { get; set; }
    /// <summary>İlaçlarla, besinlerle etkileşebilecek veya alerji yapabilecek besin tanımları iç...</summary>
    [Required]
    [ForeignKey("BesinNavigation")]
    public string BESIN_KODU { get; set; }
    /// <summary>Yaş başlangıcının gün cinsinden değer bilgisidir.</summary>
    [Required]
    public string YAS_BASLANGIC { get; set; }
    /// <summary>Yaş bitişinin gün cinsinden değer bilgisidir</summary>
    [Required]
    public string YAS_BITIS { get; set; }
    /// <summary>Kişinin cinsiyetini ifade eder.</summary>
    [Required]
    [ForeignKey("CinsiyetNavigation")]
    public string CINSIYET { get; set; }
    /// <summary>İlaç ile ilgili uyarıları verebilmek için Sağlık Bilgi Yönetim Sistemi tarafında...</summary>
    [ForeignKey("RenkSeviyeNavigation")]
    public string RENK_SEVIYE_KODU { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual REFERANS_KODLAR? IlacUyumsuzlukTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? BirinciIlacBarkoduNavigation { get; set; }
    public virtual REFERANS_KODLAR? BirinciEtkenMaddeNavigation { get; set; }
    public virtual REFERANS_KODLAR? IkinciIlacBarkoduNavigation { get; set; }
    public virtual REFERANS_KODLAR? IkinciEtkenMaddeNavigation { get; set; }
    public virtual REFERANS_KODLAR? BesinNavigation { get; set; }
    public virtual REFERANS_KODLAR? CinsiyetNavigation { get; set; }
    public virtual REFERANS_KODLAR? RenkSeviyeNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// INTIHAR_IZLEM tablosu - 13 kolon
/// </summary>
[Table("INTIHAR_IZLEM")]
public class INTIHAR_IZLEM
{
    /// <summary>Sağlık tesisinde tedavi olan hastaların intihar/kriz izlem bilgileri için Sağlık...</summary>
    [Key]
    public string INTIHAR_IZLEM_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Vakanın intihar vakası ya da kriz vakası olma durumunu ifade eder.</summary>
    [ForeignKey("IntiharKrizVakaTuruNavigation")]
    public string INTIHAR_KRIZ_VAKA_TURU { get; set; }
    /// <summary>Kişinin intihar girişimi ya da kriz nedenlerini ifade eder.</summary>
    [Required]
    [ForeignKey("IntiharGirisimKrizNedenleriNavigation")]
    public string INTIHAR_GIRISIM_KRIZ_NEDENLERI { get; set; }
    /// <summary>Kişinin intihar girişimini gerçekleştirirken kullandığı yöntem/yöntemleri ifade ...</summary>
    [ForeignKey("IntiharGirisimiYontemiNavigation")]
    public string INTIHAR_GIRISIMI_YONTEMI { get; set; }
    /// <summary>İntihar girişiminde bulunan ya da kriz geçiren kişiye yapılan müdahalenin nasıl ...</summary>
    [ForeignKey("IntiharKrizVakaSonucuNavigation")]
    public string INTIHAR_KRIZ_VAKA_SONUCU { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>İşlemin güncellemesinin yapıldığı tarih bilgisidir.</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? IntiharKrizVakaTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? IntiharGirisimKrizNedenleriNavigation { get; set; }
    public virtual REFERANS_KODLAR? IntiharGirisimiYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? IntiharKrizVakaSonucuNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// KADIN_IZLEM tablosu - 20 kolon
/// </summary>
[Table("KADIN_IZLEM")]
public class KADIN_IZLEM
{
    /// <summary>Sağlık tesisinde muayene olan kadın hastaların 15-49 yaş arası izlem bilgileri i...</summary>
    [Key]
    public string KADIN_IZLEM_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı tablo adı bilgisidir.</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Kadının 22. gebelik haftası ve sonrasında veya 500 gram ve üzerinde konjenital a...</summary>
    [Required]
    [ForeignKey("KonjenitalAnomaliVarligiNavigation")]
    public string KONJENITAL_ANOMALI_VARLIGI { get; set; }
    /// <summary>Gebeliğin 22. haftası ve sonrasında veya 500 gram ve üzerinde doğmuş, doğduğunda...</summary>
    [Required]
    public string CANLI_DOGAN_BEBEK_SAYISI { get; set; }
    /// <summary>Gebeliğin 22. haftası ve sonrasında veya 500 gram ve üzerinde dünyaya gelmiş, hi...</summary>
    [Required]
    public string OLU_DOGAN_BEBEK_SAYISI { get; set; }
    /// <summary>Kişinin hemoglobin değeri bilgisidir.</summary>
    [Required]
    public string HEMOGLOBIN_DEGERI { get; set; }
    /// <summary>Doğum yapan kadının bir önceki doğumuna ilişkin doğum durumu bilgisidir. Örneğin...</summary>
    [ForeignKey("OncekiDogumDurumuNavigation")]
    public string ONCEKI_DOGUM_DURUMU { get; set; }
    /// <summary>İzlemin yapıldığı kurum bilgisidir.</summary>
    public string IZLEMIN_YAPILDIGI_YER { get; set; }
    /// <summary>Kadının gebeliği önlemek için kullandığı yöntemi ifade eder.</summary>
    [Required]
    [ForeignKey("KullanilanApYontemiNavigation")]
    public string KULLANILAN_AP_YONTEMI { get; set; }
    /// <summary>Bir önceki kullanılan Aile Planlaması (AP) yöntemlerini tanımlamaktadır.</summary>
    [Required]
    [ForeignKey("BirOnceKullanilanApYontemiNavigation")]
    public string BIR_ONCE_KULLANILAN_AP_YONTEMI { get; set; }
    /// <summary>Hekim tarafından verilen Aile Planlaması (AP) Yönteminin verilme durumuna ilişki...</summary>
    [Required]
    [ForeignKey("ApYontemiLojistigiNavigation")]
    public string AP_YONTEMI_LOJISTIGI { get; set; }
    /// <summary>Gebelik öncesi, gebelik süresi ve gebelik sonrası dönemlerde kadın sağlığı açısı...</summary>
    [Required]
    [ForeignKey("KadinSagligiIslemleriNavigation")]
    public string KADIN_SAGLIGI_ISLEMLERI { get; set; }
    /// <summary>Kadının, Aile Planlaması (AP) Yöntemi kullanmama gerekçesini ifade eder.</summary>
    [Required]
    public string AP_YONTEMI_KULLANMAMA_NEDENI { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? KonjenitalAnomaliVarligiNavigation { get; set; }
    public virtual REFERANS_KODLAR? OncekiDogumDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? KullanilanApYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? BirOnceKullanilanApYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? ApYontemiLojistigiNavigation { get; set; }
    public virtual REFERANS_KODLAR? KadinSagligiIslemleriNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// KAN_BAGISCI tablosu - 33 kolon
/// </summary>
[Table("KAN_BAGISCI")]
public class KAN_BAGISCI
{
    /// <summary>Kan bağışında bulunan kişi için Sağlık Bilgi Yönetim Sistemi tarafından üretilen...</summary>
    [Key]
    public string KAN_BAGISCI_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Kanı bağışlayan kişinin sağlık tesisine başvurusu için Sağlık Bilgi Yönetim Sist...</summary>
    [ForeignKey("BagisciHastaBasvuruNavigation")]
    public string BAGISCI_HASTA_BASVURU_KODU { get; set; }
    /// <summary>Kanı bağışlayan kişi için Sağlık Bilgi Yönetim Sistemi tarafından üretilen tekil...</summary>
    [ForeignKey("BagisciHastaNavigation")]
    public string BAGISCI_HASTA_KODU { get; set; }
    /// <summary>Kan bağışı işleminin yapıldığı zaman bilgisidir.</summary>
    public DateTime? KAN_BAGIS_ZAMANI { get; set; }
    /// <summary>Kişinin kan grubunu ifade eder</summary>
    [ForeignKey("KanGrubuNavigation")]
    public string KAN_GRUBU { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde bağışı yapılan kan ürününün hangi hasta için rezerve edildiği b...</summary>
    [Required]
    [ForeignKey("RezervHastaNavigation")]
    public string REZERV_HASTA_KODU { get; set; }
    /// <summary>Bağışlanan kan türünü ifade eder. Örneğin tam kan, aferez trombosit, aferez gran...</summary>
    [ForeignKey("BagislananKanTuruNavigation")]
    public string BAGISLANAN_KAN_TURU { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanan tıbbi işlem sonucunda hastada reaksiyon oluşm...</summary>
    [Required]
    public string REAKSIYON_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanan tıbbi işlem sonucunda hastada gelişen reaksiy...</summary>
    [Required]
    [ForeignKey("ReaksiyonTuruNavigation")]
    public string REAKSIYON_TURU { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanan tıbbi işlem sonucunda hastada oluşan reaksiyo...</summary>
    [Required]
    public string REAKSIYON_ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde kan bağışı yapılan hasta için Kızılay’dan alınan izin numarası ...</summary>
    [Required]
    public string KIZILAY_IZIN_NUMARASI { get; set; }
    /// <summary>Sistolik kan basıncı (büyük tansiyon) bilgisini ifade eder.</summary>
    [Required]
    public string SISTOLIK_KAN_BASINCI_DEGERI { get; set; }
    /// <summary>Kan basıncı ölçme protokolüne uygun olarak "mm Hg" birimi ile ölçülen diastolik ...</summary>
    [Required]
    public string DIASTOLIK_KAN_BASINCI_DEGERI { get; set; }
    /// <summary>Kişinin santigrat cinsinden vücut ısısı bilgisidir.</summary>
    [Required]
    public string ATES { get; set; }
    /// <summary>Kişinin santimetre cinsinden boy bilgisidir.</summary>
    [Required]
    public string BOY { get; set; }
    /// <summary>Kişinin (gram cinsinden) ağırlığıdır.</summary>
    [Required]
    public string AGIRLIK { get; set; }
    /// <summary>Kan bağışında bulunan kişinin muayenesi için uzman düşüncelerini ifade eder.</summary>
    [Required]
    public string UZMAN_DEGERLENDIRME { get; set; }
    /// <summary>Sağlık tesisi depolarında hareket gören malzemelerin üretimi ile bilgileri içere...</summary>
    [Required]
    public string LOT_NUMARASI { get; set; }
    /// <summary>Kan ürününün mililitre cinsinden hacim bilgisidir.</summary>
    [Required]
    public string KAN_HACIM { get; set; }
    /// <summary>Kan ürünü torbası üzerine Kızılay tarafından yazılan numara bilgisidir.</summary>
    [Required]
    public string SEGMENT_NUMARASI { get; set; }
    /// <summary>Kan bağışında bulunan kişinin kan bağışında bulunma nedenine ilişkin bilgiyi ifa...</summary>
    [ForeignKey("BagisciTuruNavigation")]
    public string BAGISCI_TURU { get; set; }
    /// <summary>Bağış yapılan kan ürününün değerlendirme sonuç bilgisidir. Örneğin onaylı, geçic...</summary>
    [Required]
    [ForeignKey("KanBagisDegerlendirmeSonucuNavigation")]
    public string KAN_BAGIS_DEGERLENDIRME_SONUCU { get; set; }
    /// <summary>Sağlık tesisinde kan ürününü değerlendiren personel için Sağlık Bilgi Yönetim Si...</summary>
    [Required]
    [ForeignKey("DegerlendirenPersonelNavigation")]
    public string DEGERLENDIREN_PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisine yapılan kan bağışı sonucunun değerlendirildiği zaman bilgisidir.</summary>
    public DateTime KAN_BAGIS_DEGERLENDIRME_ZAMANI { get; set; }
    /// <summary>Kan bağışçısı ret nedenlerini ifade eder.</summary>
    [Required]
    [ForeignKey("KanBagiscisiRetNedenleriNavigation")]
    public string KAN_BAGISCISI_RET_NEDENLERI { get; set; }
    /// <summary>Ret süresinin gün cinsinden bilgisidir.</summary>
    [Required]
    public string RET_SURESI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA_BASVURU? BagisciHastaBasvuruNavigation { get; set; }
    public virtual HASTA? BagisciHastaNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanGrubuNavigation { get; set; }
    public virtual HASTA? RezervHastaNavigation { get; set; }
    public virtual REFERANS_KODLAR? BagislananKanTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? ReaksiyonTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? BagisciTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanBagisDegerlendirmeSonucuNavigation { get; set; }
    public virtual PERSONEL? DegerlendirenPersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanBagiscisiRetNedenleriNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// KAN_CIKIS tablosu - 20 kolon
/// </summary>
[Table("KAN_CIKIS")]
public class KAN_CIKIS
{
    /// <summary>Kan ürününün sağlık tesisi deposundan çıkış işlemi için Sağlık Bilgi Yönetim Sis...</summary>
    [Key]
    public string KAN_CIKIS_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Talep edilen kan ürünü detay bilgileri için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [Required]
    [ForeignKey("KanTalepDetayNavigation")]
    public string KAN_TALEP_DETAY_KODU { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [Required]
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisindeki depolarda bulunan kan ürünü için Sağlık Bilgi Yönetim Sistemi...</summary>
    [ForeignKey("KanStokNavigation")]
    public string KAN_STOK_KODU { get; set; }
    /// <summary>Sağlık tesisinde kan ürününü teslim alan kişi bilgisidir.</summary>
    public string KANI_TESLIM_ALAN_KISI { get; set; }
    /// <summary>Kan ürününün bulunduğu birimden çıkış zamanı bilgisidir.</summary>
    public DateTime? KAN_CIKIS_ZAMANI { get; set; }
    /// <summary>Kişinin yararlandığı sağlık güvencesinin kurumuna ait bilgiler için Sağlık Bilgi...</summary>
    [Required]
    [ForeignKey("KurumNavigation")]
    public string KURUM_KODU { get; set; }
    /// <summary>Sağlık tesisinde kan ürününün diğer birimlere gönderilmesini onaylayan personel ...</summary>
    [ForeignKey("KanCikisPersonelNavigation")]
    public string KAN_CIKIS_PERSONEL_KODU { get; set; }
    /// <summary>Kan ürünün rezerve edildiği zaman bilgisidir.</summary>
    public DateTime REZERVE_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde bağışı yapılan kan ürününü rezerve eden kullanıcı için Sağlık B...</summary>
    [Required]
    [ForeignKey("RezerveEdenKullaniciNavigation")]
    public string REZERVE_EDEN_KULLANICI_KODU { get; set; }
    /// <summary>Kan ürünü için yapılan cross-match işlem sonucunu Sağlık Bilgi Yönetim Sistemine...</summary>
    [Required]
    [ForeignKey("CrossMatchKullaniciNavigation")]
    public string CROSS_MATCH_KULLANICI_KODU { get; set; }
    /// <summary>Kan ürünü için yapılan cross-match işleminin uygulanma zamanı bilgisidir.</summary>
    public DateTime CROSS_MATCH_CALISMA_ZAMANI { get; set; }
    /// <summary>Kan ürünü için yapılan cross-match işlemi için çalışma yöntemini ifade eder. Örn...</summary>
    [Required]
    [ForeignKey("CrossMatchCalismaYontemiNavigation")]
    public string CROSS_MATCH_CALISMA_YONTEMI { get; set; }
    /// <summary>Kan ürünü için yapılan cross-match işleminin sonuç bilgisidir.</summary>
    [Required]
    [ForeignKey("CrossMatchSonucuNavigation")]
    public string CROSS_MATCH_SONUCU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>İşlemin güncellemesinin yapıldığı tarih bilgisidir.</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual KAN_TALEP_DETAY? KanTalepDetayNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual KAN_STOK? KanStokNavigation { get; set; }
    public virtual KURUM? KurumNavigation { get; set; }
    public virtual PERSONEL? KanCikisPersonelNavigation { get; set; }
    public virtual KULLANICI? RezerveEdenKullaniciNavigation { get; set; }
    public virtual KULLANICI? CrossMatchKullaniciNavigation { get; set; }
    public virtual REFERANS_KODLAR? CrossMatchCalismaYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? CrossMatchSonucuNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// KAN_STOK tablosu - 30 kolon
/// </summary>
[Table("KAN_STOK")]
public class KAN_STOK
{
    /// <summary>Sağlık tesisindeki depolarda bulunan kan ürünü için Sağlık Bilgi Yönetim Sistemi...</summary>
    [Key]
    public string KAN_STOK_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisisin kan bankasında işlem gören kan ürününün, son durum bilgisini if...</summary>
    [ForeignKey("KanStokDurumuNavigation")]
    public string KAN_STOK_DURUMU { get; set; }
    /// <summary>Kan ürününün sağlık tesisinin deposuna giriş tarihi bilgisidir.</summary>
    public DateTime? KAN_STOK_GIRIS_TARIHI { get; set; }
    /// <summary>Sağlık tesisindeki birimlerde hasta bilgilerinin olduğu defter numarası bilgisid...</summary>
    public string DEFTER_NUMARASI { get; set; }
    /// <summary>Kişinin kan grubunu ifade eder</summary>
    [ForeignKey("KanGrubuNavigation")]
    public string KAN_GRUBU { get; set; }
    /// <summary>Kan ürünü için Sağlık Bilgi Yönetim Sistemi tarafından üretilen tekil kod bilgis...</summary>
    [ForeignKey("KanUrunNavigation")]
    public string KAN_URUN_KODU { get; set; }
    /// <summary>Kan bağışında bulunan kişi için Sağlık Bilgi Yönetim Sistemi tarafından üretilen...</summary>
    [Required]
    [ForeignKey("KanBagisciNavigation")]
    public string KAN_BAGISCI_KODU { get; set; }
    /// <summary>Kişinin yararlandığı sağlık güvencesinin kurumuna ait bilgiler için Sağlık Bilgi...</summary>
    [Required]
    [ForeignKey("KurumNavigation")]
    public string KURUM_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan bölümler için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("BirimNavigation")]
    public string BIRIM_KODU { get; set; }
    /// <summary>Sağlık tesisinde stokta kaydı bulunan kan ürününe uygulanan işlemler sonucunda e...</summary>
    [Required]
    [ForeignKey("BagliKanStokNavigation")]
    public string BAGLI_KAN_STOK_KODU { get; set; }
    /// <summary>Sağlık tesisi tarafından hastaya takılan kan ürünleri için Kızılay tarafından ür...</summary>
    [Required]
    public string ISBT_UNITE_NUMARASI { get; set; }
    /// <summary>Sağlık tesisi tarafından hastaya takılan kan ürünleri için Kızılay tarafından ür...</summary>
    [Required]
    public string ISBT_BILESEN_NUMARASI { get; set; }
    /// <summary>Kan ürününün mililitre cinsinden hacim bilgisidir.</summary>
    [Required]
    public string KAN_HACIM { get; set; }
    /// <summary>Kan bağışı işleminin yapıldığı zaman bilgisidir.</summary>
    public DateTime KAN_BAGIS_ZAMANI { get; set; }
    /// <summary>Kan ürününe filtreleme işleminin yapıldığı zaman bilgisidir.</summary>
    public DateTime KAN_FILTRELEME_ZAMANI { get; set; }
    /// <summary>Kan ürününün ışınlanma işleminin uygulandığı zaman bilgisidir.</summary>
    public DateTime KAN_ISINLAMA_ZAMANI { get; set; }
    /// <summary>Kan ürününe yıkama işleminin uygulandığı zaman bilgisidir.</summary>
    public DateTime KAN_YIKAMA_ZAMANI { get; set; }
    /// <summary>Kan ürününe ayırma işleminin uygulandığı zaman bilgisidir.</summary>
    public DateTime KAN_AYIRMA_ZAMANI { get; set; }
    /// <summary>Kan ürününe bölme işleminin uygulandığı zaman bilgisidir.</summary>
    public DateTime KAN_BOLME_ZAMANI { get; set; }
    /// <summary>Kan ürününe Buffy Coat uzaklaştırma işlemi uygulandığı zaman bilgisidir.</summary>
    public DateTime BUFFYCOAT_UZAKLASTIRMA_ZAMANI { get; set; }
    /// <summary>Kan ürününe havuzlama işleminin uygulandığı zaman bilgisidir.</summary>
    public DateTime KAN_HAVUZLAMA_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde kullanılan ilaç, aşı, tıbbi alet vb. son kullanma tarihi bilgis...</summary>
    public DateTime SON_KULLANMA_TARIHI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual REFERANS_KODLAR? KanStokDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanGrubuNavigation { get; set; }
    public virtual KAN_URUN? KanUrunNavigation { get; set; }
    public virtual KAN_BAGISCI? KanBagisciNavigation { get; set; }
    public virtual KURUM? KurumNavigation { get; set; }
    public virtual BIRIM? BirimNavigation { get; set; }
    public virtual KAN_STOK? BagliKanStokNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// KAN_TALEP tablosu - 30 kolon
/// </summary>
[Table("KAN_TALEP")]
public class KAN_TALEP
{
    /// <summary>Talep edilen kan ürünü bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [Key]
    public string KAN_TALEP_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde kan ürününün talep edildiği zaman bilgisidir.</summary>
    public DateTime? KAN_TALEP_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde kan talep edilen kişi için yapılan açıklama bilgisidir.</summary>
    [Required]
    public string KAN_TALEP_ACIKLAMA { get; set; }
    /// <summary>Talep edilen kan ürünü için belirtilen talep nedeni bilgisidir. Örneğin ameliyat...</summary>
    [ForeignKey("KanTalepNedeniNavigation")]
    public string KAN_TALEP_NEDENI { get; set; }
    /// <summary>Sağlık tesisinde kan ürününü talep eden birim için Sağlık Bilgi Yönetim Sistemi ...</summary>
    [ForeignKey("KanIsteyenBirimNavigation")]
    public string KAN_ISTEYEN_BIRIM_KODU { get; set; }
    /// <summary>Sağlık tesisinde ilaç, malzeme, ürün vb. istemini yapan hekim için Sağlık Bilgi ...</summary>
    [ForeignKey("IsteyenHekimNavigation")]
    public string ISTEYEN_HEKIM_KODU { get; set; }
    /// <summary>Sağlık tesisinde tedavi olan hasta için istenen kan grubuna bilgisine ait Sağlık...</summary>
    [Required]
    [ForeignKey("IstenenKanGrubuNavigation")]
    public string ISTENEN_KAN_GRUBU { get; set; }
    /// <summary>Kan ürünü için planlanan transfüzyon zamanı bilgisidir.</summary>
    public DateTime PLANLANAN_TRANSFUZYON_ZAMANI { get; set; }
    /// <summary>Planlanan kan ürünü transfüzyon süresinin dakika cinsinden bilgisidir.</summary>
    [Required]
    public string PLANLANAN_TRANSFUZYON_SURESI { get; set; }
    /// <summary>Sağlık tesisinde talep edilen kan ürününün aciliyetinin seviyesine ilişkin bilgi...</summary>
    [Required]
    [ForeignKey("KanTalepAciliyetSeviyesiNavigation")]
    public string KAN_TALEP_ACILIYET_SEVIYESI { get; set; }
    /// <summary>Kan ürününe cross-match işleminin uygulanıp uygulanmayacağına ilişkin bilgiyi if...</summary>
    public string CROSS_MATCH_YAPILMA_DURUMU { get; set; }
    /// <summary>Kan ürününün acil olarak istenmesine ilişkin aciliyet sebebi bilgisidir.</summary>
    [Required]
    public string KAN_ACIL_ACIKLAMA { get; set; }
    /// <summary>Kişinin kanında herhangi bir kan gurubuna karşı antikor varlığına ilişkin bilgiy...</summary>
    public string KAN_ANTIKOR_DURUMU { get; set; }
    /// <summary>Sağlık hizmetini almak için sağlık tesisine başvuran kişinin tıbbi öyküsünde tra...</summary>
    public string TRANSPLANTASYON_GECIRME_DURUMU { get; set; }
    /// <summary>Sağlık hizmetini almak için sağlık tesisine başvuran kişinin tıbbi öyküsünde tra...</summary>
    public string TRANSFUZYON_GECIRME_DURUMU { get; set; }
    /// <summary>Sağlık hizmetini almak için sağlık tesisine başvuran kişinin tıbbi öyküsünde tra...</summary>
    public string TRANSFUZYON_REAKSIYON_DURUMU { get; set; }
    /// <summary>Hasta öyküsünde gebelik olup olmadığına ilişkin bilgiyi ifade eder.</summary>
    public string GEBELIK_GECIRME_DURUMU { get; set; }
    /// <summary>Fetusun (anne karnındaki doğmamış bebek) anne ile olan kan uyuşmazlığı olup olma...</summary>
    public string FETOMATERNAL_UYUSMAZLIK_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde kan talep edilen hasta için özel durum bilgisidir.</summary>
    [Required]
    public string KAN_TALEP_OZEL_DURUM { get; set; }
    /// <summary>Hematokrit (HCT) / Hemoglobin (HGB) oranı bilgisidir.</summary>
    [Required]
    public string HEMATOKRIT_ORANI { get; set; }
    /// <summary>Kişiden alınan kan örneğinde sayımı yapılan trombosit sayısı bilgisidir.</summary>
    [Required]
    public string TROMBOSIT_SAYISI { get; set; }
    /// <summary>Kişiye kan transfüzyonu yapılacağı zaman kanın hangi amaçla kişiye verileceğini ...</summary>
    [Required]
    [ForeignKey("KanEndikasyonTuruNavigation")]
    public string KAN_ENDIKASYON_TURU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanTalepNedeniNavigation { get; set; }
    public virtual BIRIM? KanIsteyenBirimNavigation { get; set; }
    public virtual PERSONEL? IsteyenHekimNavigation { get; set; }
    public virtual REFERANS_KODLAR? IstenenKanGrubuNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanTalepAciliyetSeviyesiNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanEndikasyonTuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// KAN_TALEP_DETAY tablosu - 20 kolon
/// </summary>
[Table("KAN_TALEP_DETAY")]
public class KAN_TALEP_DETAY
{
    /// <summary>Talep edilen kan ürünü detay bilgileri için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [Key]
    public string KAN_TALEP_DETAY_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Talep edilen kan ürünü bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("KanTalepNavigation")]
    public string KAN_TALEP_KODU { get; set; }
    /// <summary>Kan ürünü için Sağlık Bilgi Yönetim Sistemi tarafından üretilen tekil kod bilgis...</summary>
    [ForeignKey("KanUrunNavigation")]
    public string KAN_URUN_KODU { get; set; }
    /// <summary>Sağlık tesisinde tedavi olan hasta için istenen kan grubuna bilgisine ait Sağlık...</summary>
    [ForeignKey("IstenenKanGrubuNavigation")]
    public string ISTENEN_KAN_GRUBU { get; set; }
    /// <summary>Talebin reddedildiği tarih bilgisidir.</summary>
    public DateTime RET_TARIHI { get; set; }
    /// <summary>Ret işlemini gerçekleştiren Sağlık Bilgi Yönetim Sistemi kullanıcısı için Sağlık...</summary>
    [Required]
    [ForeignKey("RetEdenKullaniciNavigation")]
    public string RET_EDEN_KULLANICI_KODU { get; set; }
    /// <summary>Talep edilen kan ürününün reddedilmesi durumunda belirtilen ret bilgisidir. Örne...</summary>
    [Required]
    [ForeignKey("KanTalepRetNedeniNavigation")]
    public string KAN_TALEP_RET_NEDENI { get; set; }
    /// <summary>Talep edilen kan ürünü için miktar (torba adedi) bilgisidir.</summary>
    [Required]
    public string KAN_TALEP_MIKTARI { get; set; }
    /// <summary>Kan ürününün mililitre cinsinden hacim bilgisidir.</summary>
    [Required]
    public string KAN_HACIM { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Kan ürününe Buffy Coat uzaklaştırma işlemi uygulanma durumunu ifade eder.</summary>
    public string BUFFYCOAT_UZAKLASTIRMA_DURUMU { get; set; }
    /// <summary>Kan ürününe filtreleme işlemi uygulanıp uygulanmadığını ifade eden durum bilgisi...</summary>
    public string KAN_FILTRELEME_DURUMU { get; set; }
    /// <summary>Kan ürününün ışınlanma işleminin durumuna ilişkin bilgiyi ifade eder.</summary>
    public string KAN_ISINLAMA_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde kullanılacak ürüne yıkama işleminin uygulanmasına ilişkin bilgi...</summary>
    public string KAN_YIKAMA_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>İşlemin güncellemesinin yapıldığı tarih bilgisidir.</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual KAN_TALEP? KanTalepNavigation { get; set; }
    public virtual KAN_URUN? KanUrunNavigation { get; set; }
    public virtual REFERANS_KODLAR? IstenenKanGrubuNavigation { get; set; }
    public virtual KULLANICI? RetEdenKullaniciNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanTalepRetNedeniNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// KAN_URUN tablosu - 20 kolon
/// </summary>
[Table("KAN_URUN")]
public class KAN_URUN
{
    /// <summary>Kan ürünü için Sağlık Bilgi Yönetim Sistemi tarafından üretilen tekil kod bilgis...</summary>
    [Key]
    public string KAN_URUN_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Kan ürünün adı bilgisidir.</summary>
    public string KAN_URUN_ADI { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanan işlemler için Sağlık Bilgi Yönetim Sistemi ta...</summary>
    [ForeignKey("HizmetNavigation")]
    public string HIZMET_KODU { get; set; }
    /// <summary>Kan ürününün gün cinsinden miat süresi bilgisidir.</summary>
    public string KAN_MIAT_SURESI { get; set; }
    /// <summary>Kan ürününün gün, yıl, saat cinsinden miat periyot bilgisidir.</summary>
    [Required]
    public string KAN_MIAT_PERIYODU { get; set; }
    /// <summary>Kan ürünü için Kızılay entegrasyonu için Kızılay bileşen türü eşleştirmesinde ku...</summary>
    [Required]
    public string KIZILAY_BILESEN_TURU { get; set; }
    /// <summary>Kan ürününün filtreleme işlemi için uygun olup olmadığını ifade eden bilgidir.</summary>
    [Required]
    public string KAN_FILTRELEME_UYGUNLUK { get; set; }
    /// <summary>Sağlık tesisinde kullanılacak ürünün yıkama işlemi için uygun olma durumuna iliş...</summary>
    [Required]
    public string KAN_YIKAMA_UYGUNLUK_DURUMU { get; set; }
    /// <summary>Kan ürününün ışınlanma işlemine uygunluk durumuna ilişkin bilgiyi ifade eder.</summary>
    [Required]
    public string KAN_ISINLAMA_UYGUNLUK_DURUMU { get; set; }
    /// <summary>Kan ürününün havuzlama işlemi için uygunluk durumuna ilişkin bilgiyi ifade eder.</summary>
    [Required]
    public string KAN_HAVUZLAMA_UYGUNLUK { get; set; }
    /// <summary>Kan ürününün ayırma işlemine uygunluk durumunu ifade eder.</summary>
    [Required]
    public string KAN_AYIRMA_UYGUNLUK { get; set; }
    /// <summary>Kan ürününün bölme işlemi için uygunluk durumuna ilişkin bilgiyi ifade eder.</summary>
    [Required]
    public string KAN_BOLME_UYGUNLUK { get; set; }
    /// <summary>Kan ürününün Buffy Coat uzaklaştırma işlemi için uygunluk durumunu ifade eder.</summary>
    [Required]
    public string BUFFYCOAT_UZAKLASTIRMAYA_UYGUN { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>İşlemin güncellemesinin yapıldığı tarih bilgisidir.</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HIZMET? HizmetNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// KAN_URUN_IMHA tablosu - 12 kolon
/// </summary>
[Table("KAN_URUN_IMHA")]
public class KAN_URUN_IMHA
{
    /// <summary>İmha edilen kan ürünü için Sağlık Bilgi Yönetim Sistemi tarafından üretilen teki...</summary>
    [Key]
    public string KAN_URUN_IMHA_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisindeki depolarda bulunan kan ürünü için Sağlık Bilgi Yönetim Sistemi...</summary>
    [ForeignKey("KanStokNavigation")]
    public string KAN_STOK_KODU { get; set; }
    /// <summary>Kan ürününün imha edilmesi durumunda belirtilen neden bilgisidir. Örneğin son ku...</summary>
    [ForeignKey("KanImhaNedeniNavigation")]
    public string KAN_IMHA_NEDENI { get; set; }
    /// <summary>Kan ürününün imha edildiği zaman bilgisidir.</summary>
    public DateTime? KAN_IMHA_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde kan ürününün imha edilmesini onaylayan hekim bilgileri için Sağ...</summary>
    [Required]
    [ForeignKey("KanImhaOnaylayanHekimNavigation")]
    public string KAN_IMHA_ONAYLAYAN_HEKIM { get; set; }
    /// <summary>Sağlık tesisinde kan ürününün imha edilmesini onaylayan teknisyen bilgileri için...</summary>
    [Required]
    [ForeignKey("KanImhaOnaylayanTeknisyenNavigation")]
    public string KAN_IMHA_ONAYLAYAN_TEKNISYEN { get; set; }
    /// <summary>Sağlık tesisinde kan ürününü imha eden personel bilgileri için Sağlık Bilgi Yöne...</summary>
    [Required]
    [ForeignKey("KanImhaEdenPersonelNavigation")]
    public string KAN_IMHA_EDEN_PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual KAN_STOK? KanStokNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanImhaNedeniNavigation { get; set; }
    public virtual PERSONEL? KanImhaOnaylayanHekimNavigation { get; set; }
    public virtual PERSONEL? KanImhaOnaylayanTeknisyenNavigation { get; set; }
    public virtual PERSONEL? KanImhaEdenPersonelNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// KLINIK_SEYIR tablosu - 14 kolon
/// </summary>
[Table("KLINIK_SEYIR")]
public class KLINIK_SEYIR
{
    /// <summary>Sağlık tesisinde tedavi alan hastanın seyir bilgileri (günlük epikriz bilgileri)...</summary>
    [Key]
    public string KLINIK_SEYIR_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Hastanın tedavisinin seyiri için Sağlık Bilgi Yönetim Sistemi tarafından yapılan...</summary>
    [ForeignKey("SeyirTipiNavigation")]
    public string SEYIR_TIPI { get; set; }
    /// <summary>Hastanın tedavisinin seyir bilgisinin Sağlık Bilgi Yönetim Sistemine girildiği z...</summary>
    public DateTime? SEYIR_ZAMANI { get; set; }
    /// <summary>Hastanın tedavisi için hekimlerin yazdığı günlük seyir bilgisini ifade eder.</summary>
    [Required]
    public string SEYIR_BILGISI { get; set; }
    /// <summary>Hastanın septik şok durumuna ilişkin bilgidir.</summary>
    [Required]
    [ForeignKey("SeptikSokNavigation")]
    public string SEPTIK_SOK { get; set; }
    /// <summary>Hastanın sepsis durumuna ilişkin bilgidir.</summary>
    [Required]
    [ForeignKey("SepsisDurumuNavigation")]
    public string SEPSIS_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde görevli hekim için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? SeyirTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SeptikSokNavigation { get; set; }
    public virtual REFERANS_KODLAR? SepsisDurumuNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// KONSULTASYON tablosu - 15 kolon
/// </summary>
[Table("KONSULTASYON")]
public class KONSULTASYON
{
    /// <summary>Sağlık tesisinde tedavi alan hastanın konsültasyon bilgileri için Sağlık Bilgi Y...</summary>
    [Key]
    public string KONSULTASYON_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanacak hizmetler için Sağlık Bilgi Yönetim Sistemi...</summary>
    [ForeignKey("HastaHizmetNavigation")]
    public string HASTA_HIZMET_KODU { get; set; }
    /// <summary>Sağlık tesisinde konsültasyon yapılması amacıyla açılan yeni bir hasta başvuru k...</summary>
    [Required]
    [ForeignKey("KonsultasyonBasvuruNavigation")]
    public string KONSULTASYON_BASVURU_KODU { get; set; }
    /// <summary>Konsültasyon isteğinde bulunan hekimin yazdığı istek notu bilgisidir.</summary>
    [Required]
    public string KONSULTASYON_ISTEK_NOTU { get; set; }
    /// <summary>Sağlık tesisinde konsültasyon yapan hekimin yazdığı cevap notu bilgisidir.</summary>
    [Required]
    public string KONSULTASYON_CEVAP_NOTU { get; set; }
    /// <summary>Hekimin konsültasyon için, diğer bir hekim tarafından Sağlık Bilgi Yönetim Siste...</summary>
    public DateTime KONSULTASYONA_CAGRILMA_ZAMANI { get; set; }
    /// <summary>Hekimin konsültasyona geliş zamanı bilgisidir.</summary>
    public DateTime KONSULTASYONA_GELIS_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde tedavi olan hastaya konsültasyonun nerede yapıldığı bilgisidir....</summary>
    [ForeignKey("KonsultasyonYeriNavigation")]
    public string KONSULTASYON_YERI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA_HIZMET? HastaHizmetNavigation { get; set; }
    public virtual HASTA_BASVURU? KonsultasyonBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? KonsultasyonYeriNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// KUDUZ_IZLEM tablosu - 13 kolon
/// </summary>
[Table("KUDUZ_IZLEM")]
public class KUDUZ_IZLEM
{
    /// <summary>Sağlık tesisinde tedavi olan hastaların kuduz izlem bilgileri için Sağlık Bilgi ...</summary>
    [Key]
    public string KUDUZ_IZLEM_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Kuduz şüpheli temaslılar ve risk grubunda yer alan ve temas öncesi profilaksi ih...</summary>
    [Required]
    [ForeignKey("ProfilaksiTamamlanmaDurumuNavigation")]
    public string PROFILAKSI_TAMAMLANMA_DURUMU { get; set; }
    /// <summary>Kuduz şüpheli temasa maruz kalan kişiye kuduz profilaksisi programı çerçevesinde...</summary>
    [Required]
    [ForeignKey("UygulananKuduzProfilaksisiNavigation")]
    public string UYGULANAN_KUDUZ_PROFILAKSISI { get; set; }
    /// <summary>Kişinin kuduz aşısını yaptırdığı veya yaptıracağını beyan ettiği Toplum Sağlığı ...</summary>
    [Required]
    [ForeignKey("BeyanTsmKurumNavigation")]
    public string BEYAN_TSM_KURUM_KODU { get; set; }
    /// <summary>Uygulanan immünglobilinin IU cinsinden miktar bilgisidir.</summary>
    [Required]
    public string IMMUNGLOBULIN_MIKTARI { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? ProfilaksiTamamlanmaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? UygulananKuduzProfilaksisiNavigation { get; set; }
    public virtual KURUM? BeyanTsmKurumNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// KULLANICI tablosu - 298 kolon
/// </summary>
[Table("KULLANICI")]
public class KULLANICI
{
    /// <summary>Sağlık Bilgi Yönetim Sistemini kullanan personel için Sağlık Bilgi Yönetim Siste...</summary>
    [Key]
    public string KULLANICI_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Kişinin adı bilgisidir.</summary>
    public string AD { get; set; }
    /// <summary>Sağlık hizmeti alan kişinin kimlik belgesinde yer alan soyadıdır.</summary>
    public string SOYADI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi kullanıcıları için tanımlanmış kullanıcı adı bilgis...</summary>
    public string KULLANICI_ADI { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [Required]
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }
    /// <summary>Kişiyi niteleyen eşsiz numaradır.</summary>
    [Required]
    public string TC_KIMLIK_NUMARASI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi veri tabanında bulunan bir kayıtın aktif olup olmad...</summary>
    public string AKTIFLIK_BILGISI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi kullanıcısı için tanımlanan parolanın şifrelenme al...</summary>
    [Required]
    public string PAROLA { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi kullanıcısı için tanımlanan parolanın şifrelenme al...</summary>
    [Required]
    [ForeignKey("ParolaSifrelemeTuruNavigation")]
    public string PAROLA_SIFRELEME_TURU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual PERSONEL? PersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? ParolaSifrelemeTuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// KULLANICI_GRUP tablosu - 9 kolon
/// </summary>
[Table("KULLANICI_GRUP")]
public class KULLANICI_GRUP
{
    /// <summary>Sağlık Bilgi Yönetim Sistemi kullanıcıları için tanımlanmış Sağlık Bilgi Yönetim...</summary>
    [Key]
    public string KULLANICI_GRUP_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi kullanıcılarının bulunduğu grup adı bilgisidir.</summary>
    public string KULLANICI_GRUP_ADI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi veri tabanında bulunan bir kayıtın aktif olup olmad...</summary>
    public string AKTIFLIK_BILGISI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// KURUL tablosu - 11 kolon
/// </summary>
[Table("KURUL")]
public class KURUL
{
    /// <summary>Sağlık tesisinde düzenlenen sağlık kurulu tarafından verilen raporların tanım bi...</summary>
    [Key]
    public string KURUL_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Kurul adı bilgisidir.</summary>
    public string KURUL_ADI { get; set; }
    /// <summary>Hastaya verilen rapor türünü ifade eder.</summary>
    [ForeignKey("RaporTuruNavigation")]
    public string RAPOR_TURU { get; set; }
    /// <summary>Sağlık tesisinde düzenlenen heyet veya tek hekim raporları için MEDULA tarafında...</summary>
    [Required]
    [ForeignKey("MedulaRaporTuruNavigation")]
    public string MEDULA_RAPOR_TURU { get; set; }
    /// <summary>Sağlık tesisinde tedavi olan hastalar için düzenlenmiş heyet veya tek hekim rapo...</summary>
    [Required]
    [ForeignKey("MedulaAltRaporTuruNavigation")]
    public string MEDULA_ALT_RAPOR_TURU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual REFERANS_KODLAR? RaporTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? MedulaRaporTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? MedulaAltRaporTuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// KURUL_ASKERI tablosu - 17 kolon
/// </summary>
[Table("KURUL_ASKERI")]
public class KURUL_ASKERI
{
    /// <summary>Sağlık tesisinde düzenlenen sağlık kurulu tarafından verilen raporların tanım bi...</summary>
    [Key]
    public string KURUL_ASKERI_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Kurul adı bilgisidir.</summary>
    public string KURUL_ADI { get; set; }
    /// <summary>Sağlık tesisinde düzenlenen heyet veya tek hekim raporları için MEDULA tarafında...</summary>
    [ForeignKey("MedulaRaporTuruNavigation")]
    public string MEDULA_RAPOR_TURU { get; set; }
    /// <summary>Sağlık tesisinde tedavi olan hastalar için düzenlenmiş heyet veya tek hekim rapo...</summary>
    [Required]
    [ForeignKey("MedulaAltRaporTuruNavigation")]
    public string MEDULA_ALT_RAPOR_TURU { get; set; }
    /// <summary>Kişinin alkol veya madde bağımlısı olup olmadığına ilişkin bilgiyi ifade eder.</summary>
    [Required]
    [ForeignKey("AlkolMaddeBagimliligiNavigation")]
    public string ALKOL_MADDE_BAGIMLILIGI { get; set; }
    /// <summary>Kişinin bedensel veya ruhsal ileri tetkik bulgusuna ait bilgiyi ifade eder.</summary>
    [Required]
    [ForeignKey("BedenRuhIleriTetkikBulgusuNavigation")]
    public string BEDEN_RUH_ILERI_TETKIK_BULGUSU { get; set; }
    /// <summary>Kişinin geçmiş hastalığına dair kayıt bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("GecmisHastaligaDairKayitNavigation")]
    public string GECMIS_HASTALIGA_DAIR_KAYIT { get; set; }
    /// <summary>Kişinin görme veya işitme kaybı olup olmadığı bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("GormeIsitmeKaybiNavigation")]
    public string GORME_ISITME_KAYBI { get; set; }
    /// <summary>Kişinin psikiyatrik rahatsızlık durumuna ilişkin bilgiyi ifade eder.</summary>
    [Required]
    [ForeignKey("PsikiyatrikRahatsizlikNavigation")]
    public string PSIKIYATRIK_RAHATSIZLIK { get; set; }
    /// <summary>Kişinin uzuv kaybı veya ortopedik rahatsızlığı olup olmadığı bilgisini ifade ede...</summary>
    [ForeignKey("UzuvkaybiOrtopediRahatsizlikNavigation")]
    public string UZUVKAYBI_ORTOPEDI_RAHATSIZLIK { get; set; }
    /// <summary>Kişinin asal hastalık bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("AsalHastalikNavigation")]
    public string ASAL_HASTALIK { get; set; }
    /// <summary>Kişinin asal hastalık tipi bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("AsalHastalikTipiNavigation")]
    public string ASAL_HASTALIK_TIPI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual REFERANS_KODLAR? MedulaRaporTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? MedulaAltRaporTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? AlkolMaddeBagimliligiNavigation { get; set; }
    public virtual REFERANS_KODLAR? BedenRuhIleriTetkikBulgusuNavigation { get; set; }
    public virtual REFERANS_KODLAR? GecmisHastaligaDairKayitNavigation { get; set; }
    public virtual REFERANS_KODLAR? GormeIsitmeKaybiNavigation { get; set; }
    public virtual REFERANS_KODLAR? PsikiyatrikRahatsizlikNavigation { get; set; }
    public virtual REFERANS_KODLAR? UzuvkaybiOrtopediRahatsizlikNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsalHastalikNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsalHastalikTipiNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// KURUL_ENGELLI tablosu - 14 kolon
/// </summary>
[Table("KURUL_ENGELLI")]
public class KURUL_ENGELLI
{
    /// <summary>Sağlık kurulunda düzenlenen engelli raporlarına ait bilgiler için Sağlık Bilgi Y...</summary>
    [Key]
    public string KURUL_ENGELLI_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Hastaya sağlık raporu veren kurul için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("KurulRaporNavigation")]
    public string KURUL_RAPOR_KODU { get; set; }
    /// <summary>Engelli raporu düzenlenen kişinin, çalıştırılamayacağı işlerin niteliğini ifade ...</summary>
    [Required]
    public string CALISTIRILAMAYACAK_ISNITELIGI { get; set; }
    /// <summary>Engelli raporu düzenlenen kişiye ait raporun süreklilik durumunu ifade eder.</summary>
    [Required]
    public string ENGELLI_SUREKLILIK_DURUMU { get; set; }
    /// <summary>Engel durumuna göre engellilik oranı %50 ve üzerinde olduğu tespit edilenlerden ...</summary>
    [Required]
    public string AGIR_ENGELLI { get; set; }
    /// <summary>Engelli raporu düzenlenen kişinin engellilik grubunu ifade eder.</summary>
    [Required]
    public string ENGELLI_GRUBU { get; set; }
    /// <summary>Engelli raporu düzenlenen kişinin raporu kullanım amacını ifade eder.</summary>
    [Required]
    public string ENGELLI_RAPOR_KULLANIM_AMACI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual KURUL_RAPOR? KurulRaporNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// KURUL_ETKEN_MADDE tablosu - 13 kolon
/// </summary>
[Table("KURUL_ETKEN_MADDE")]
public class KURUL_ETKEN_MADDE
{
    /// <summary>Hasta için verilen sağlık raporunda bulunan ilaçların etken madde bilgileri için...</summary>
    [Key]
    public string KURUL_ETKEN_MADDE_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Hastaya sağlık raporu veren kurul için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("KurulRaporNavigation")]
    public string KURUL_RAPOR_KODU { get; set; }
    /// <summary>İlacın içeriğinde bulunan etken maddeler için Sağlık Bilgi Yönetim Sistemi taraf...</summary>
    public string ILAC_ETKEN_MADDE_KODU { get; set; }
    /// <summary>İlacın günde kaç kez kullanılacağı bilgisidir. Örneğin 3 yazılmışsa periyot biri...</summary>
    [Required]
    public string DOZ_SAYISI { get; set; }
    /// <summary>Hastanın bir seferde kullanılacağı ilacın miktar bilgisidir.</summary>
    [Required]
    public string DOZ_MIKTARI { get; set; }
    /// <summary>Bir ilacın, hastaya tek seferde verilebilecek miktarı için ölçü bilgisidir.</summary>
    [Required]
    [ForeignKey("DozBirimNavigation")]
    public string DOZ_BIRIM { get; set; }
    /// <summary>İlacın kullanım periyodunu ifade eder.</summary>
    [Required]
    public string ILAC_KULLANIM_PERIYODU { get; set; }
    /// <summary>İlacın hangi periyot biriminde kullanılacağını ifade eder.</summary>
    [Required]
    [ForeignKey("IlacPeriyotBirimiNavigation")]
    public string ILAC_PERIYOT_BIRIMI { get; set; }
    /// <summary>Kurul etken madde bilgisinin ilk kayıt edildiği zaman bilgisidir.</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual KURUL_RAPOR? KurulRaporNavigation { get; set; }
    public virtual REFERANS_KODLAR? DozBirimNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlacPeriyotBirimiNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// KURUL_HEKIM tablosu - 16 kolon
/// </summary>
[Table("KURUL_HEKIM")]
public class KURUL_HEKIM
{
    /// <summary>Hastaya sağlık raporu veren kurulda bulunan hekim için Sağlık Bilgi Yönetim Sist...</summary>
    [Key]
    public string KURUL_HEKIM_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Hastaya sağlık raporu veren kurul için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("KurulRaporNavigation")]
    public string KURUL_RAPOR_KODU { get; set; }
    /// <summary>Sağlık tesisinde görevli hekim için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan klinik ve hekimler için MEDULA tarafından tanımlanmış b...</summary>
    [Required]
    public string MEDULA_BRANS_KODU { get; set; }
    /// <summary>İnsan vücudunun sistemleri için Sağlık Bilgi Yönetim Sistemi tarafından üretilen...</summary>
    [Required]
    [ForeignKey("SistemNavigation")]
    public string SISTEM_KODU { get; set; }
    /// <summary>Kurul hekiminin yazdığı sonuç bilgisidir.</summary>
    [Required]
    public string KURUL_SONUC { get; set; }
    /// <summary>Sağlık tesisine başvuran kişi için belirlenen engellilik oranı bilgisidir.</summary>
    [Required]
    public string ENGELLILIK_ORANI { get; set; }
    /// <summary>Sağlık tesisinde, hekimin sağlık kurulundaki görev bilgisidir. Örneğin başkan, ü...</summary>
    [Required]
    public string HEKIM_KURUL_GOREVI { get; set; }
    /// <summary>Sağlık kurulunda görevli hekimlerin sıra numarası bilgisidir.</summary>
    public string HEKIM_SIRA_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual KURUL_RAPOR? KurulRaporNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual REFERANS_KODLAR? SistemNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// KURUL_RAPOR tablosu - 31 kolon
/// </summary>
[Table("KURUL_RAPOR")]
public class KURUL_RAPOR
{
    /// <summary>Hastaya sağlık raporu veren kurul için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Key]
    public string KURUL_RAPOR_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde düzenlenen sağlık kurulu tarafından verilen raporların tanım bi...</summary>
    [ForeignKey("KurulNavigation")]
    public string KURUL_KODU { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık kurulu tarafından verilen raporlar için ad bilgisidir.</summary>
    [Required]
    public string RAPOR_ADI { get; set; }
    /// <summary>Rapor zamanı bilgisidir.</summary>
    public DateTime? RAPOR_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık kurulu tarafından verilen raporların karar numarası bilgisidir.</summary>
    [Required]
    public string RAPOR_KARAR_NUMARASI { get; set; }
    /// <summary>Sağlık tesisine başvuran hastaya verilen iş göremezlik raporu için MEDULA sistem...</summary>
    [Required]
    public string RAPOR_SIRA_NUMARASI { get; set; }
    /// <summary>Sağlık tesisine başvuran hastaya verilen sağlık kurulu raporu için Sağlık Bilgi ...</summary>
    [Required]
    public string RAPOR_TAKIP_NUMARASI { get; set; }
    /// <summary>Sağlık kurulu tarafından verilen raporlar için Sağlık Bilgi Yönetim Sistemi tara...</summary>
    public string KURUL_RAPOR_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde kişiye verilen raporun başlama tarihi bilgisidir.</summary>
    public DateTime? RAPOR_BASLAMA_TARIHI { get; set; }
    /// <summary>Raporun bitiş tarihi bilgisidir.</summary>
    public DateTime RAPOR_BITIS_TARIHI { get; set; }
    /// <summary>Sağlık tesisinde laboratuvarda yapılan tetkikler sonucunda elde edilen bulguları...</summary>
    [Required]
    public string LABORATUVAR_BULGU { get; set; }
    /// <summary>Sağlık tesisine kurul raporu almak için başvurmuş kişinin muayene bulguları bilg...</summary>
    [Required]
    public string KURUL_RAPOR_MUAYENE_BULGUSU { get; set; }
    /// <summary>Sağlık tesisinde düzenlenen kurul raporlarında hasta için verilen tanı bilgisini...</summary>
    [Required]
    public string KURUL_TANI_BILGISI { get; set; }
    /// <summary>Sağlık tesisinde kişiye verilen kurul raporu için kurul tarafından verilen karar...</summary>
    [Required]
    public string KURUL_RAPOR_KARARI { get; set; }
    /// <summary>Sağlık tesisinde kişiye verilen kurul raporunun içeriğinin Sağlık Bilgi Yönetim ...</summary>
    [Required]
    [ForeignKey("KararIcerikFormatiNavigation")]
    public string KARAR_ICERIK_FORMATI { get; set; }
    /// <summary>Sağlık tesisine rapor almak için gelen kişinin sağlık tesisine müracaatına ilişk...</summary>
    public string MURACAAT_DURUMU { get; set; }
    /// <summary>Sağlık tesisine başvuran kişi için belirlenen engellilik oranı bilgisidir.</summary>
    [Required]
    public string ENGELLILIK_ORANI { get; set; }
    /// <summary>Sağlık tesisinde düzenlenen onaylanmış ilaç raporunda sonradan yapılan değişikli...</summary>
    [Required]
    public string ILAC_RAPOR_DUZELTME_ACIKLAMASI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual KURUL? KurulNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? KararIcerikFormatiNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// KURUL_TESHIS tablosu - 11 kolon
/// </summary>
[Table("KURUL_TESHIS")]
public class KURUL_TESHIS
{
    /// <summary>Hasta için verilen sağlık raporunda kurul tarafından onaylanan teşhis bilgileri ...</summary>
    [Key]
    public string KURUL_TESHIS_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Hastaya sağlık raporu veren kurul için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("KurulRaporNavigation")]
    public string KURUL_RAPOR_KODU { get; set; }
    /// <summary>Sağlık tesisinde tedavi alan hastaya düzenlenen rapordaki ilaçlar için MEDULA ta...</summary>
    [Required]
    public string ILAC_TESHIS_KODU { get; set; }
    /// <summary>Sağlık tesisinde hastaya konulan tanı için ICD-10 kodlarından seçilen tanı kodu ...</summary>
    [Required]
    [ForeignKey("TaniNavigation")]
    public string TANI_KODU { get; set; }
    /// <summary>Sağlık tesisinde kişiye verilen raporun başlama tarihi bilgisidir.</summary>
    public DateTime RAPOR_BASLAMA_TARIHI { get; set; }
    /// <summary>Sağlık tesisinde hekim tarafından kişiye konulan tanıya ait yazılan raporun biti...</summary>
    public DateTime RAPOR_BITIS_TARIHI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual KURUL_RAPOR? KurulRaporNavigation { get; set; }
    public virtual REFERANS_KODLAR? TaniNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// KURUM tablosu - 27 kolon
/// </summary>
[Table("KURUM")]
public class KURUM
{
    /// <summary>Kişinin yararlandığı sağlık güvencesinin kurumuna ait bilgiler için Sağlık Bilgi...</summary>
    [Key]
    public string KURUM_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Kişinin yararlandığı sağlık güvencesinin kurumuna ait ad bilgisidir.</summary>
    public string KURUM_ADI { get; set; }
    /// <summary>Hastanın sosyal güvencesinin bulunduğu kurumların gruplandırılma bilgisidir. Örn...</summary>
    [Required]
    [ForeignKey("HastaKurumTuruNavigation")]
    public string HASTA_KURUM_TURU { get; set; }
    /// <summary>Sağlık tesisinde muayene olan kişi için MEDULA tarafından Sağlık Bilgi Yönetim S...</summary>
    [Required]
    public string DEVREDILEN_KURUM { get; set; }
    /// <summary>Sağlık Kodlama Referans Sunucusu (SKRS) kod sistemlerinde tanımlanan Kurum Kodu ...</summary>
    [Required]
    [ForeignKey("SkrsKurumNavigation")]
    public string SKRS_KURUM_KODU { get; set; }
    /// <summary>Kişinin yararlandığı sağlık güvencesinin kurumuna ait adres bilgisidir.</summary>
    [Required]
    public string KURUM_ADRESI { get; set; }
    /// <summary>Sağlık tesisine ayaktan tedavi için başvuran hastalara yapılan işlemlerin geliri...</summary>
    [Required]
    public string AYAKTAN_BUTCE_KODU { get; set; }
    /// <summary>Sağlık tesisine yatarak tedavi için başvuran hastalara yapılan işlemlerin geliri...</summary>
    [Required]
    public string YATAN_BUTCE_KODU { get; set; }
    /// <summary>Sağlık tesisine günübirlik tedavi için başvuran hastalara yapılan işlemlerin gel...</summary>
    [Required]
    public string GUNUBIRLIK_BUTCE_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi veri tabanında bulunan bir kayıtın aktif olup olmad...</summary>
    [Required]
    public string AKTIFLIK_BILGISI { get; set; }
    /// <summary>Kurum bilgisinin ilk kayıt edildiği zaman bilgisidir.</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual REFERANS_KODLAR? HastaKurumTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? SkrsKurumNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// LOHUSA_IZLEM tablosu - 23 kolon
/// </summary>
[Table("LOHUSA_IZLEM")]
public class LOHUSA_IZLEM
{
    /// <summary>Doğum yapmış kadınların izlem bilgileri için Sağlık Bilgi Yönetim Sistemi tarafı...</summary>
    [Key]
    public string LOHUSA_IZLEM_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Lohusada kaçıncı izlemin yapıldığını ifade eder.</summary>
    [ForeignKey("KacinciLohusaIzlemNavigation")]
    public string KACINCI_LOHUSA_IZLEM { get; set; }
    /// <summary>İzlemin yapıldığı kurum bilgisidir.</summary>
    [Required]
    [ForeignKey("IzleminYapildigiYerNavigation")]
    public string IZLEMIN_YAPILDIGI_YER { get; set; }
    /// <summary>Gebelikte dışarıdan demir desteği; demirin uygulanmayacağı durumlar hariç, ayrım...</summary>
    [Required]
    [ForeignKey("DemirLojistigiVeDestegiNavigation")]
    public string DEMIR_LOJISTIGI_VE_DESTEGI { get; set; }
    /// <summary>Gebeler için; gebeliğin 12. haftasından başlanarak doğumdan sonra 6. ayın sonuna...</summary>
    [Required]
    [ForeignKey("DvitaminiLojistigiVeDestegiNavigation")]
    public string DVITAMINI_LOJISTIGI_VE_DESTEGI { get; set; }
    /// <summary>Gebeliğin doğum veya başka sebepler ile sonlandığı tarih bilgisidir.</summary>
    public DateTime? GEBELIK_SONLANMA_TARIHI { get; set; }
    /// <summary>EDINBURGH Postpartum Depresyon Ölçeği, doğum sonrası dönemdeki kadınlara uygulan...</summary>
    [Required]
    [ForeignKey("PostpartumDepresyonNavigation")]
    public string POSTPARTUM_DEPRESYON { get; set; }
    /// <summary>Uterus involusyon takibinin yapılma durumuna ilişkin bilgidir. Örneğin uterus ın...</summary>
    [ForeignKey("UterusInvolusyonNavigation")]
    public string UTERUS_INVOLUSYON { get; set; }
    /// <summary>Bilgi alınan kişinin ad ve soyadı bilgisidir.</summary>
    [Required]
    public string BILGI_ALINAN_KISI_AD_SOYADI { get; set; }
    /// <summary>Bilgi alınan kişinin telefon numarası bilgisidir.</summary>
    [Required]
    public string BILGI_ALINAN_KISI_TELEFON { get; set; }
    /// <summary>Kadının 22. gebelik haftası ve sonrasında veya 500 gram ve üzerinde konjenital a...</summary>
    [Required]
    [ForeignKey("KonjenitalAnomaliVarligiNavigation")]
    public string KONJENITAL_ANOMALI_VARLIGI { get; set; }
    /// <summary>Kişinin hemoglobin değeri bilgisidir.</summary>
    [Required]
    public string HEMOGLOBIN_DEGERI { get; set; }
    /// <summary>Herhangi bir müdahale (ameliyat, doğum vb.) sonrası oluşan karmaşık ve olumsuz k...</summary>
    [Required]
    [ForeignKey("KomplikasyonTanisiNavigation")]
    public string KOMPLIKASYON_TANISI { get; set; }
    /// <summary>Gebelik/lohusalık seyrinde anne ve fetüs sağlığını olumsuz yönde etkileyen faktö...</summary>
    [Required]
    [ForeignKey("SeyirTehlikeIsaretiNavigation")]
    public string SEYIR_TEHLIKE_ISARETI { get; set; }
    /// <summary>Gebelik öncesi, gebelik süresi ve gebelik sonrası dönemlerde kadın sağlığı açısı...</summary>
    [Required]
    [ForeignKey("KadinSagligiIslemleriNavigation")]
    public string KADIN_SAGLIGI_ISLEMLERI { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? KacinciLohusaIzlemNavigation { get; set; }
    public virtual REFERANS_KODLAR? IzleminYapildigiYerNavigation { get; set; }
    public virtual REFERANS_KODLAR? DemirLojistigiVeDestegiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DvitaminiLojistigiVeDestegiNavigation { get; set; }
    public virtual REFERANS_KODLAR? PostpartumDepresyonNavigation { get; set; }
    public virtual REFERANS_KODLAR? UterusInvolusyonNavigation { get; set; }
    public virtual REFERANS_KODLAR? KonjenitalAnomaliVarligiNavigation { get; set; }
    public virtual REFERANS_KODLAR? KomplikasyonTanisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SeyirTehlikeIsaretiNavigation { get; set; }
    public virtual REFERANS_KODLAR? KadinSagligiIslemleriNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// MADDE_BAGIMLILIGI tablosu - 31 kolon
/// </summary>
[Table("MADDE_BAGIMLILIGI")]
public class MADDE_BAGIMLILIGI
{
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Key]
    public string MADDE_BAGIMLILIGI_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Madde bağımlısı için bilgi alınan kişi bilgisidir.</summary>
    [ForeignKey("BilgiAlinanKaynakNavigation")]
    public string BILGI_ALINAN_KAYNAK { get; set; }
    /// <summary>Kişinin danışma/tedavi hizmet alma durumu bilgisidir.</summary>
    [ForeignKey("DanismaTedaviHizmetDurumuNavigation")]
    public string DANISMA_TEDAVI_HIZMET_DURUMU { get; set; }
    /// <summary>Kişinin danışma/tedavi hizmet alma zaman bilgisidir.</summary>
    public DateTime DANISMA_TEDAVI_HIZMET_ZAMANI { get; set; }
    /// <summary>Kişinin ikame tedavisi görme durumu bilgisidir.</summary>
    [ForeignKey("IkameTedaviDurumuNavigation")]
    public string IKAME_TEDAVI_DURUMU { get; set; }
    /// <summary>Kişinin en son ikame tedavisi görme zaman bilgisidir.</summary>
    public DateTime SON_IKAME_TEDAVI_ZAMANI { get; set; }
    /// <summary>Kişinin cezaevinde kalmış olma durumuna ilişkin bilgiyi ifade eder.</summary>
    [ForeignKey("CezaeviOykusuNavigation")]
    public string CEZAEVI_OYKUSU { get; set; }
    /// <summary>Kişinin sosyal yardım alma durumu bilgisidir.</summary>
    [ForeignKey("SosyalYardimAlmaDurumuNavigation")]
    public string SOSYAL_YARDIM_ALMA_DURUMU { get; set; }
    /// <summary>Hastanın yaşam yerinin kırsal ve kentsel durumunu ifade eder.</summary>
    [ForeignKey("YasadigiBolgeNavigation")]
    public string YASADIGI_BOLGE { get; set; }
    /// <summary>Alkol veya madde kullanan hastanın nerede ve kimlerle birlikte yaşadığını ifade ...</summary>
    [ForeignKey("YasamBicimiNavigation")]
    public string YASAM_BICIMI { get; set; }
    /// <summary>Kişinin çocuklarıyla yaşama durumu bilgisidir.</summary>
    [ForeignKey("CocuklariylaYasamaDurumuNavigation")]
    public string COCUKLARIYLA_YASAMA_DURUMU { get; set; }
    /// <summary>Kişinin enjeksiyon yolu ile madde kullanımına ilişkin bilgiyi ifade eder.</summary>
    [Required]
    [ForeignKey("EnjeksiyonIleMaddeKullanimiNavigation")]
    public string ENJEKSIYON_ILE_MADDE_KULLANIMI { get; set; }
    /// <summary>Madde bağımlısı olan kişinin enjeksiyon ile ilk defa madde kullandığı yaş bilgis...</summary>
    [Required]
    public string ENJEKSIYON_ILK_KULLANIM_YASI { get; set; }
    /// <summary>Enjeksiyon yolu ile madde kullanan hastanın enjektör paylaşımı durumunu ifade ed...</summary>
    [Required]
    [ForeignKey("EnjektorPaylasimDurumuNavigation")]
    public string ENJEKTOR_PAYLASIM_DURUMU { get; set; }
    /// <summary>Madde bağımlısı olan kişinin ilk defa enjektör paylaştığı yaş bilgisidir</summary>
    [Required]
    public string ILK_ENJEKTOR_PAYLASIM_YASI { get; set; }
    /// <summary>Kişinin HIV test yapılma durumu bilgisidir.</summary>
    [Required]
    [ForeignKey("HivTestYapilmaDurumuNavigation")]
    public string HIV_TEST_YAPILMA_DURUMU { get; set; }
    /// <summary>Kişinin HCV test yapılma durumu bilgisidir.</summary>
    [Required]
    [ForeignKey("HcvTestYapilmaDurumuNavigation")]
    public string HCV_TEST_YAPILMA_DURUMU { get; set; }
    /// <summary>Kişinin HBV test yapılma durumu bilgisidir.</summary>
    [Required]
    [ForeignKey("HbvTestYapilmaDurumuNavigation")]
    public string HBV_TEST_YAPILMA_DURUMU { get; set; }
    /// <summary>Sağlık hizmeti alan kişiye tedavi/danışmanlık hizmetinin sonucunda hangi hizmeti...</summary>
    [ForeignKey("GorusmeSonucuNavigation")]
    public string GORUSME_SONUCU { get; set; }
    /// <summary>Hastanın tedavi merkezine kim tarafından gönderildiğini ifade eder.</summary>
    [ForeignKey("GonderenBirimNavigation")]
    public string GONDEREN_BIRIM { get; set; }
    /// <summary>Uyuşturucu madde kullanan kişinin ikametinin sabit olup olmadığı bilgisidir.</summary>
    [ForeignKey("YasamOrtamiNavigation")]
    public string YASAM_ORTAMI { get; set; }
    /// <summary>Madde kullanan hastanın madde kullanımı ile birlikte sık görülen bulaşıcı hastal...</summary>
    [Required]
    [ForeignKey("BulasiciHastalikDurumuNavigation")]
    public string BULASICI_HASTALIK_DURUMU { get; set; }
    /// <summary>Sağlık hizmeti alan kişiye ne tür tedavi başlandığı bilgisidir.</summary>
    [Required]
    [ForeignKey("BaslananTedaviTipiBilgisiNavigation")]
    public string BASLANAN_TEDAVI_TIPI_BILGISI { get; set; }
    /// <summary>Madde bağımlısı olan kişinin en çok kullandığı esas madde bilgisidir.</summary>
    [Required]
    [ForeignKey("BirincilKullanilanEsasMaddeNavigation")]
    public string BIRINCIL_KULLANILAN_ESAS_MADDE { get; set; }
    /// <summary>Kişinin bağımlısı olduğu madde dışında kullandığı diğer madde bilgisidir.</summary>
    [Required]
    [ForeignKey("KullanilanDigerMaddeNavigation")]
    public string KULLANILAN_DIGER_MADDE { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? BilgiAlinanKaynakNavigation { get; set; }
    public virtual REFERANS_KODLAR? DanismaTedaviHizmetDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? IkameTedaviDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? CezaeviOykusuNavigation { get; set; }
    public virtual REFERANS_KODLAR? SosyalYardimAlmaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? YasadigiBolgeNavigation { get; set; }
    public virtual REFERANS_KODLAR? YasamBicimiNavigation { get; set; }
    public virtual REFERANS_KODLAR? CocuklariylaYasamaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? EnjeksiyonIleMaddeKullanimiNavigation { get; set; }
    public virtual REFERANS_KODLAR? EnjektorPaylasimDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? HivTestYapilmaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? HcvTestYapilmaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? HbvTestYapilmaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? GorusmeSonucuNavigation { get; set; }
    public virtual REFERANS_KODLAR? GonderenBirimNavigation { get; set; }
    public virtual REFERANS_KODLAR? YasamOrtamiNavigation { get; set; }
    public virtual REFERANS_KODLAR? BulasiciHastalikDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? BaslananTedaviTipiBilgisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? BirincilKullanilanEsasMaddeNavigation { get; set; }
    public virtual REFERANS_KODLAR? KullanilanDigerMaddeNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// MEDULA_TAKIP tablosu - 30 kolon
/// </summary>
[Table("MEDULA_TAKIP")]
public class MEDULA_TAKIP
{
    /// <summary>Sağlık tesisinde tedavi gören hasta için, çeşitli kriterlere göre MEDULA tarafın...</summary>
    [Key]
    public string MEDULA_TAKIP_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine gelen hasta için MEDULA sisteminden Sağlık Bilgi Yönetim Sistemi...</summary>
    public string SGK_TAKIP_NUMARASI { get; set; }
    /// <summary>Sağlık tesisine gelen hasta için MEDULA sisteminden Sağlık Bilgi Yönetim Sistemi...</summary>
    [Required]
    public string SGK_ILKTAKIP_NUMARASI { get; set; }
    /// <summary>Sağlık tesisi için MEDULA tarafından tanımlanmış numara bilgisidir.</summary>
    public string MEDULA_TESIS_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan klinik ve hekimler için MEDULA tarafından tanımlanmış b...</summary>
    public string MEDULA_BRANS_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastanın başvurusu için MEDULA sistemine iletilen provi...</summary>
    [ForeignKey("ProvizyonTuruNavigation")]
    public string PROVIZYON_TURU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastanın başvurusu için MEDULA sistemine iletilen provi...</summary>
    public DateTime? PROVIZYON_TARIHI { get; set; }
    /// <summary>Kişiyi niteleyen eşsiz numaradır.</summary>
    [Required]
    public string TC_KIMLIK_NUMARASI { get; set; }
    /// <summary>Kişinin cinsiyetini ifade eder.</summary>
    [Required]
    public string CINSIYET { get; set; }
    /// <summary>Sağlık tesisinde tedavi gören hastaya yapılan işlem için MEDULA sisteminin ödeme...</summary>
    [Required]
    public string MEDULA_TUTARI { get; set; }
    /// <summary>Sağlık tesisi tarafından hasta için kesilen faturanın MEDULA’ya gönderildikten s...</summary>
    [Required]
    public string FATURA_TESLIM_NUMARASI { get; set; }
    /// <summary>Sağlık tesisi tarafından hasta için kesilen faturanın web servis aracılığı ile M...</summary>
    public DateTime FATURA_TESLIM_TARIHI { get; set; }
    /// <summary>Hastaya uygulanan tedavinin ayaktan, günübirlik, yatan vb. olduğunu belirten Sağ...</summary>
    [ForeignKey("TedaviTuruNavigation")]
    public string TEDAVI_TURU { get; set; }
    /// <summary>Sağlık tesisine gelen hastanın emekli, çalışan vb. durumlarını belirten bilgiyi ...</summary>
    [Required]
    public string SIGORTALI_TURU { get; set; }
    /// <summary>Sağlık tesisinde muayene olan kişi için MEDULA tarafından Sağlık Bilgi Yönetim S...</summary>
    [Required]
    public string DEVREDILEN_KURUM { get; set; }
    /// <summary>Sağlık tesisinde hasta için yapılan tüm işlemler için MEDULA'dan Sağlık Bilgi Yö...</summary>
    [Required]
    public string SONUC_KODU { get; set; }
    /// <summary>Sağlık tesisinde hasta için yapılan tüm işlemler için MEDULA'dan Sağlık Bilgi Yö...</summary>
    [Required]
    public string SONUC_MESAJI { get; set; }
    /// <summary>Sağlık tesisinde tedavi gören hasta için normal, eşlik eden hastalık, uzayan yat...</summary>
    [Required]
    [ForeignKey("TakipTipiNavigation")]
    public string TAKIP_TIPI { get; set; }
    /// <summary>Sağlık tesisine başvuran kişi için MEDULA sisteminden Sağlık Bilgi Yönetim Siste...</summary>
    [Required]
    public string BASVURU_NUMARASI { get; set; }
    /// <summary>Hastaya uygulanan tedavinin normal, diş tedavisi, analık hali vb. olduğunu belir...</summary>
    [ForeignKey("TedaviTipiNavigation")]
    public string TEDAVI_TIPI { get; set; }
    /// <summary>Sağlık tesisindeki hastaya uygulanan tedaviye ilişkin bilgiyi ifade eder. Örneği...</summary>
    [Required]
    [ForeignKey("TedaviSekliNavigation")]
    public string TEDAVI_SEKLI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual REFERANS_KODLAR? ProvizyonTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? TedaviTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? TakipTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? TedaviTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? TedaviSekliNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// NOBETCI_PERSONEL_BILGISI tablosu - 14 kolon
/// </summary>
[Table("NOBETCI_PERSONEL_BILGISI")]
public class NOBETCI_PERSONEL_BILGISI
{
    /// <summary>Sağlık tesisinde nöbetçi personelin bilgileri için Sağlık Bilgi Yönetim Sistemi ...</summary>
    [Key]
    public string NOBETCI_PERSONEL_BILGISI_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık Kodlama Referans Sunucusu (SKRS) kod sistemlerinde tanımlanan Kurum Kodu ...</summary>
    [ForeignKey("SkrsKurumNavigation")]
    public string SKRS_KURUM_KODU { get; set; }
    /// <summary>Personele ait TC Kimlik Numarası bilgisidir.</summary>
    public string PERSONEL_TC_KIMLIK_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde bulunan kliniklerin Sağlık Bilgi Yönetim Sistemi tarafından gru...</summary>
    [Required]
    [ForeignKey("KlinikNavigation")]
    public string KLINIK_KODU { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin yaptığı görev için Sağlık Bilgi Yönetim Sist...</summary>
    [Required]
    [ForeignKey("GorevTuruNavigation")]
    public string GOREV_TURU { get; set; }
    /// <summary>Sağlık tesisinde görevli personel için görevini tanımlayan kod bilgisidir.</summary>
    [Required]
    [ForeignKey("PersonelGorevNavigation")]
    public string PERSONEL_GOREV_KODU { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin nöbette başlama tarihi bilgisidir.</summary>
    public DateTime NOBET_BASLANGIC_TARIHI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin nöbetinin bitiş tarihi bilgisidir.</summary>
    public DateTime NOBET_BITIS_TARIHI { get; set; }
    /// <summary>Telefon numarası bilgisini ifade eder.</summary>
    [Required]
    public string TELEFON_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual REFERANS_KODLAR? SkrsKurumNavigation { get; set; }
    public virtual REFERANS_KODLAR? KlinikNavigation { get; set; }
    public virtual REFERANS_KODLAR? GorevTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? PersonelGorevNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// OBEZITE_IZLEM tablosu - 16 kolon
/// </summary>
[Table("OBEZITE_IZLEM")]
public class OBEZITE_IZLEM
{
    /// <summary>Sağlık tesisinde muayene olan hastaların obezite izlem bilgileri için Sağlık Bil...</summary>
    [Key]
    public string OBEZITE_IZLEM_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Hastalara diyetisyen tarafından verilen diyet programının varlığını ve hastanın ...</summary>
    [Required]
    [ForeignKey("DiyetTibbiBeslenmeTedavisiNavigation")]
    public string DIYET_TIBBI_BESLENME_TEDAVISI { get; set; }
    /// <summary>Hastaya izlem ve tedavi uygulanacak olan hastalık (diyabetis mellitus, kanser, H...</summary>
    public DateTime ILK_TANI_TARIHI { get; set; }
    /// <summary>Morbid obez tanısı olan (BKI 40 kg/m2 ve üstü) hastalarda lenfatik ödem olup olm...</summary>
    [Required]
    [ForeignKey("MorbitObezLenfatikOdemNavigation")]
    public string MORBIT_OBEZ_LENFATIK_ODEM { get; set; }
    /// <summary>Diyet (tıbbi beslenme) ve egzersizi içeren davranış tedavisine yanıt alınamayan ...</summary>
    [Required]
    [ForeignKey("ObeziteIlacTedavisiNavigation")]
    public string OBEZITE_ILAC_TEDAVISI { get; set; }
    /// <summary>Obezite ve diyabet ile ilişkili tutum ve davranışlara yönelik farkındalığın bili...</summary>
    [Required]
    [ForeignKey("PsikolojikTedaviNavigation")]
    public string PSIKOLOJIK_TEDAVI { get; set; }
    /// <summary>Hastaya konulan tanıya eşlik eden hastalıklardır.</summary>
    [Required]
    [ForeignKey("BirlikteGorulenEkHastalikNavigation")]
    public string BIRLIKTE_GORULEN_EK_HASTALIK { get; set; }
    /// <summary>Hastanın günlük fiziksel aktivite düzeyini ifade eder.</summary>
    [Required]
    [ForeignKey("EgzersizNavigation")]
    public string EGZERSIZ { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyetTibbiBeslenmeTedavisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? MorbitObezLenfatikOdemNavigation { get; set; }
    public virtual REFERANS_KODLAR? ObeziteIlacTedavisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? PsikolojikTedaviNavigation { get; set; }
    public virtual REFERANS_KODLAR? BirlikteGorulenEkHastalikNavigation { get; set; }
    public virtual REFERANS_KODLAR? EgzersizNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// ODA tablosu - 10 kolon
/// </summary>
[Table("ODA")]
public class ODA
{
    /// <summary>Sağlık tesisinde bulunan oda için Sağlık Bilgi Yönetim Sistemi tarafından üretil...</summary>
    [Key]
    public string ODA_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde bulunan oda adı bilgisidir.</summary>
    public string ODA_ADI { get; set; }
    /// <summary>Sağlık tesisinde bulunan bölümler için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("BirimNavigation")]
    public string BIRIM_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual BIRIM? BirimNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// OPTIK_RECETE tablosu - 46 kolon
/// </summary>
[Table("OPTIK_RECETE")]
public class OPTIK_RECETE
{
    /// <summary>Optik reçete bilgisi için Sağlık Bilgi Yönetim Sistemi tarafından üretilen tekil...</summary>
    [Key]
    public string OPTIK_RECETE_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Reçete edilen gözlük için normal, teleskopik, lens vb. tip bilgisidir.</summary>
    [ForeignKey("GozlukReceteTipiNavigation")]
    public string GOZLUK_RECETE_TIPI { get; set; }
    /// <summary>Sağlık tesisinde görevli hekim için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }
    /// <summary>Reçetenin yazıldığı zaman bilgisidir.</summary>
    public DateTime? RECETE_ZAMANI { get; set; }
    /// <summary>Kişinin kullandığı ya da kişiye reçete edilen gözlüğün türünü ifade eder. Örneği...</summary>
    [ForeignKey("GozlukTuruNavigation")]
    public string GOZLUK_TURU { get; set; }
    /// <summary>Gözlüğün sağ camının hangi tipte olduğunu ifade eder. Örneğin düz, organik, bifo...</summary>
    [Required]
    [ForeignKey("SagCamTipiNavigation")]
    public string SAG_CAM_TIPI { get; set; }
    /// <summary>Gözlüğün sağ camının renk bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("SagCamRengiNavigation")]
    public string SAG_CAM_RENGI { get; set; }
    /// <summary>Gözlüğün sağ camının sferik değer bilgisini ifade eder.</summary>
    [Required]
    public string SAG_CAM_SFERIK { get; set; }
    /// <summary>Gözlüğün sağ camının silindirik değer bilgisini ifade eder.</summary>
    [Required]
    public string SAG_CAM_SILINDIRIK { get; set; }
    /// <summary>Gözlüğün sağ camındaki astigmat açısının (Aks) değer bilgisini ifade eder.</summary>
    [Required]
    public string SAG_CAM_AKS { get; set; }
    /// <summary>Gözlüğün sol camının hangi tipte olduğunu ifade eder. Örneğin düz, organik, bifo...</summary>
    [Required]
    [ForeignKey("SolCamTipiNavigation")]
    public string SOL_CAM_TIPI { get; set; }
    /// <summary>Gözlüğün sol camının renk bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("SolCamRengiNavigation")]
    public string SOL_CAM_RENGI { get; set; }
    /// <summary>Gözlüğün sol camının sferik değer bilgisini ifade eder.</summary>
    [Required]
    public string SOL_CAM_SFERIK { get; set; }
    /// <summary>Gözlüğün sol camının silindirik değer bilgisini ifade eder.</summary>
    [Required]
    public string SOL_CAM_SILINDIRIK { get; set; }
    /// <summary>Gözlüğün sol camındaki astigmat açısının (Aks) değer bilgisini ifade eder.</summary>
    [Required]
    public string SOL_CAM_AKS { get; set; }
    /// <summary>Sağ lensin cam sferik değer bilgisini ifade eder.</summary>
    [Required]
    public string SAG_LENS_CAM_SFERIK { get; set; }
    /// <summary>Sağ lensin cam silindirik değer bilgisini ifade eder.</summary>
    [Required]
    public string SAG_LENS_CAM_SILINDIRIK { get; set; }
    /// <summary>Sağ lensin cam çap değer bilgisini ifade eder.</summary>
    [Required]
    public string SAG_LENS_CAM_CAP { get; set; }
    /// <summary>Sağ lensin cam eğim değer bilgisini ifade eder.</summary>
    [Required]
    public string SAG_LENS_CAM_EGIM { get; set; }
    /// <summary>Sağ lensin cam astigmat açısının (Aks) değer bilgisini ifade eder.</summary>
    [Required]
    public string SAG_LENS_CAM_AKS { get; set; }
    /// <summary>Sol lens cam sferik değer bilgisidir.</summary>
    [Required]
    public string SOL_LENS_CAM_SFERIK { get; set; }
    /// <summary>Sol lensin cam silindirik değer bilgisini ifade eder.</summary>
    [Required]
    public string SOL_LENS_CAM_SILINDIRIK { get; set; }
    /// <summary>Sol lensin cam çap değer bilgisini ifade eder.</summary>
    [Required]
    public string SOL_LENS_CAM_CAP { get; set; }
    /// <summary>Sol lensin cam eğim değer bilgisini ifade eder.</summary>
    [Required]
    public string SOL_LENS_CAM_EGIM { get; set; }
    /// <summary>Sol lensin cam astigmat açısının (Aks) değer bilgisini ifade eder.</summary>
    [Required]
    public string SOL_LENS_CAM_AKS { get; set; }
    /// <summary>Gözlüğün sağ camının keratakonus cam sferik bilgisini ifade eder.</summary>
    [Required]
    public string SAG_KERATAKONUS_CAM_SFERIK { get; set; }
    /// <summary>Gözlüğün sağ camının keratakonus cam silindirik bilgisini ifade eder.</summary>
    [Required]
    public string SAG_KERATAKONUS_CAM_SILINDIR { get; set; }
    /// <summary>Gözlüğün sağ camının keratakonus cam çap bilgisini ifade eder.</summary>
    [Required]
    public string SAG_KERATAKONUS_CAM_CAP { get; set; }
    /// <summary>Gözlüğün sağ camının keratakonus cam eğim bilgisini ifade eder.</summary>
    [Required]
    public string SAG_KERATAKONUS_CAM_EGIM { get; set; }
    /// <summary>Gözlüğün sağ camının keratakonus astigmat açısının (Aks) değer bilgisini ifade e...</summary>
    [Required]
    public string SAG_KERATAKONUS_CAM_AKS { get; set; }
    /// <summary>Gözlüğün sol camının keratakonus cam sferik bilgisini ifade eder.</summary>
    [Required]
    public string SOL_KERATAKONUS_CAM_SFERIK { get; set; }
    /// <summary>Gözlüğün sol camının keratakonus cam silindirik bilgisini ifade eder.</summary>
    [Required]
    public string SOL_KERATAKONUS_CAM_SILINDIR { get; set; }
    /// <summary>Gözlüğün sol camının keratakonus cam çap bilgisini ifade eder.</summary>
    [Required]
    public string SOL_KERATAKONUS_CAM_CAP { get; set; }
    /// <summary>Gözlüğün sol camının keratakonus cam eğim bilgisini ifade eder.</summary>
    [Required]
    public string SOL_KERATAKONUS_CAM_EGIM { get; set; }
    /// <summary>Gözlüğün sol camının keratakonus astigmat açısının (Aks) değer bilgisini ifade e...</summary>
    [Required]
    public string SOL_KERATAKONUS_CAM_AKS { get; set; }
    /// <summary>Teleskopik gözlük tipi değer bilgisidir. Örneğin tek, çift, tek karekod vb.</summary>
    [Required]
    [ForeignKey("TeleskopikGozlukTipiNavigation")]
    public string TELESKOPIK_GOZLUK_TIPI { get; set; }
    /// <summary>Teleskopik gözlük türü değer bilgisidir. Örneğin uzak-daimi, yakın vb.</summary>
    [Required]
    [ForeignKey("TeleskopikGozlukTuruNavigation")]
    public string TELESKOPIK_GOZLUK_TURU { get; set; }
    /// <summary>Sağlık tesisinde düzenlenen gözlük reçetesinin sağ camında teleskobik özelliğine...</summary>
    [Required]
    public string TELESKOPIK_SAG_CAM { get; set; }
    /// <summary>Sağlık tesisinde düzenlenen gözlük reçetesinin sol camında teleskobik özelliğine...</summary>
    [Required]
    public string TELESKOPIK_SOL_CAM { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual REFERANS_KODLAR? GozlukReceteTipiNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual REFERANS_KODLAR? GozlukTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? SagCamTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SagCamRengiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SolCamTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SolCamRengiNavigation { get; set; }
    public virtual REFERANS_KODLAR? TeleskopikGozlukTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? TeleskopikGozlukTuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// ORTODONTI_ICON_SKOR tablosu - 39 kolon
/// </summary>
[Table("ORTODONTI_ICON_SKOR")]
public class ORTODONTI_ICON_SKOR
{
    /// <summary>Ortodonti Icon Skor bilgisi için Sağlık Bilgi Yönetim Sistemi tarafından üretile...</summary>
    [Key]
    public string ORTODONTI_ICON_SKOR_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Diş tedavisi yapılan hastalar için Ortodonti Icon Skor (OIS) formunun değerlendi...</summary>
    public DateTime? OIS_DEGERLENDIRME_ZAMANI { get; set; }
    /// <summary>Hastanın dişlerindeki estetik bozukluğun Ortodonti Icon Skor (OIS) standartların...</summary>
    [Required]
    public string OIS_ESTETIK_BOZUKLUK_BILGISI { get; set; }
    /// <summary>Ortodonti Icon Skor (OIS) standartlarına göre belirlenmiş estetik puanının hesap...</summary>
    [Required]
    public string OIS_ESTETIK_PUAN_KATSAYISI { get; set; }
    /// <summary>Ortodonti Icon Skor (OIS) standartlarına göre belirlenmiş estetik bozukluk derec...</summary>
    [Required]
    public string OIS_ESTETIK_PUANI { get; set; }
    /// <summary>Üst çene dişlerindeki çapraşıklığın derecesinin bilgisidir.</summary>
    [Required]
    public string UST_DIS_ARKA_CAPRASIKLIK { get; set; }
    /// <summary>Üst çene dişlerindeki çapraşıklık puanının hesaplanması için gerekli olan katsay...</summary>
    [Required]
    public string UST_ARKA_CAPRASIKLIK_KATSAYISI { get; set; }
    /// <summary>Üst çapraşıklık derecesi ile katsayısının çarpımı ile hesaplanan puan bilgisidir...</summary>
    [Required]
    public string UST_ARKA_CAPRASIKLIK_PUANI { get; set; }
    /// <summary>Üst çene dişlerindeki boşluk derecesinin bilgisidir.</summary>
    [Required]
    public string UST_DIS_ARKA_BOSLUK { get; set; }
    /// <summary>Üst çene dişlerindeki boşluk puanının hesaplanması için gerekli olan katsayı bil...</summary>
    [Required]
    public string UST_ARKA_BOSLUK_KATSAYISI { get; set; }
    /// <summary>Üst çene dişlerindeki boşluk derecesi ve katsayısının çarpımı ile hesaplanan pua...</summary>
    [Required]
    public string UST_ARKA_BOSLUK_PUANI { get; set; }
    /// <summary>Kişinin dişlerinde çaprazlık olup olmadığı bilgisidir.</summary>
    [Required]
    public string DIS_CAPRAZLIK_DURUMU { get; set; }
    /// <summary>Ortodonti Icon Skorlamasında kullanılan çaprazlık puanının hesaplanması için ger...</summary>
    [Required]
    public string DIS_CAPRAZLIK_KATSAYISI { get; set; }
    /// <summary>Ortodonti Icon Skorlaması için dişlerde çaprazlık katsayısı kullanılarak hesapla...</summary>
    [Required]
    public string DIS_CAPRAZLIK_PUANI { get; set; }
    /// <summary>Kişinin dişlerinde, ön açık kapanış bozukluğu için milimetre cinsinden derece bi...</summary>
    [Required]
    public string ON_ACIK_KAPANIS { get; set; }
    /// <summary>Kişinin dişlerinde, ön açık kapanış puanının hesaplanması için katsayı bilgisidi...</summary>
    [Required]
    public string ON_ACIK_KAPANIS_KATSAYISI { get; set; }
    /// <summary>Kişinin dişlerinde, ön açık kapanış katsayısı ve ön açık kapanış derecesinin çar...</summary>
    [Required]
    public string ON_ACIK_KAPANIS_PUANI { get; set; }
    /// <summary>Kişinin dişlerinde, ön derin kapanış bozukluğu için milimetre cinsinden derece b...</summary>
    [Required]
    public string ON_DERIN_KAPANIS { get; set; }
    /// <summary>Kişinin dişlerinde, ön derin kapanış puanının hesaplanması için katsayı bilgisid...</summary>
    [Required]
    public string ON_DERIN_KAPANIS_KATSAYISI { get; set; }
    /// <summary>Kişinin dişlerinde, ön derin kapanış katsayısı ve ön derin kapanış derecesinin ç...</summary>
    [Required]
    public string ON_DERIN_KAPANIS_PUANI { get; set; }
    /// <summary>Sağ bukkal (yanak) bölgesinde bulunan dişlerin ön-arka yön ilişki derecesi bilgi...</summary>
    [Required]
    public string BUKKAL_BOLGE_SAG { get; set; }
    /// <summary>Sağ bukkal (yanak) bölge puanının hesaplanması için gerekli katsayı bilgisidir.</summary>
    [Required]
    public string BUKKAL_BOLGE_SAG_KATSAYISI { get; set; }
    /// <summary>Sağ bukkal (yanak) bölge puanı bilgisidir.</summary>
    [Required]
    public string BUKKAL_BOLGE_SAG_PUANI { get; set; }
    /// <summary>Sol bukkal (yanak) bölgesinde bulunan dişlerin ön-arka yön ilişki derecesi bilgi...</summary>
    [Required]
    public string BUKKAL_BOLGE_SOL { get; set; }
    /// <summary>Sol bukkal (yanak) bölge puanının hesaplanması için gerekli katsayı bilgisidir.</summary>
    [Required]
    public string BUKKAL_BOLGE_SOL_KATSAYISI { get; set; }
    /// <summary>Sol bukkal (yanak) bölge puanı bilgisidir.</summary>
    [Required]
    public string BUKKAL_BOLGE_SOL_PUANI { get; set; }
    /// <summary>Bukkal (yanak) bölge sağ ve sol puanlarının toplanarak elde edildiği toplam bukk...</summary>
    [Required]
    public string BUKKAL_TOPLAM_PUANI { get; set; }
    /// <summary>Ortodonti için tüm kriterlerin puanlarının toplandığı toplam puan bilgisidir.</summary>
    [Required]
    public string TOPLAM_ICON_SKOR_PUANI { get; set; }
    /// <summary>Diş tedavisi yapılan hastalar için Ortodonti Icon Skoru (OIS) form bilgilerini d...</summary>
    [Required]
    [ForeignKey("OisDegerlendiren1HekimNavigation")]
    public string OIS_DEGERLENDIREN_1_HEKIM_KODU { get; set; }
    /// <summary>Diş tedavisi yapılan hastalar için Ortodonti Icon Skoru (OIS) form bilgilerini d...</summary>
    [Required]
    [ForeignKey("OisDegerlendiren2HekimNavigation")]
    public string OIS_DEGERLENDIREN_2_HEKIM_KODU { get; set; }
    /// <summary>Diş tedavisi yapılan hastalar için Ortodonti Icon Skoru (OIS) form bilgilerini d...</summary>
    [Required]
    [ForeignKey("OisDegerlendiren3HekimNavigation")]
    public string OIS_DEGERLENDIREN_3_HEKIM_KODU { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual PERSONEL? OisDegerlendiren1HekimNavigation { get; set; }
    public virtual PERSONEL? OisDegerlendiren2HekimNavigation { get; set; }
    public virtual PERSONEL? OisDegerlendiren3HekimNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// PATOLOJI tablosu - 37 kolon
/// </summary>
[Table("PATOLOJI")]
public class PATOLOJI
{
    /// <summary>Patoloji tetkikleri için Sağlık Bilgi Yönetim Sistemi tarafından üretilen tekil ...</summary>
    [Key]
    public string PATOLOJI_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Patoloji biriminde hastaya yazılan rapor için Sağlık Bilgi Yönetim Sistemi taraf...</summary>
    [Required]
    [ForeignKey("PatolojiRaporTuruNavigation")]
    public string PATOLOJI_RAPOR_TURU { get; set; }
    /// <summary>Patoloji için hastadan alınan numunenin alındığı dokunun temel özellik bilgisidi...</summary>
    [Required]
    [ForeignKey("DokununTemelOzelligiNavigation")]
    public string DOKUNUN_TEMEL_OZELLIGI { get; set; }
    /// <summary>Sağlık tesisinde kişiden alınan numunenin nasıl alındığına ilişkin bilgiyi ifade...</summary>
    [Required]
    [ForeignKey("NumuneAlinmaSekliNavigation")]
    public string NUMUNE_ALINMA_SEKLI { get; set; }
    /// <summary>Patoloji tetkiki için alınan preparatın durum bilgidir. Örneğin materyal yeterli...</summary>
    [Required]
    [ForeignKey("PatolojiPreparatiDurumuNavigation")]
    public string PATOLOJI_PREPARATI_DURUMU { get; set; }
    /// <summary>Sağlık tesisindeki patoloji biriminde hasta bilgilerinin olduğu defter numarası ...</summary>
    [Required]
    public string PATOLOJI_DEFTER_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde yapılan tetkiklerde kullanılan numuneler için Sağlık Bilgi Yöne...</summary>
    [ForeignKey("TetkikNumuneNavigation")]
    public string TETKIK_NUMUNE_KODU { get; set; }
    /// <summary>Sağlık tesisinde incelenmek için hastadan alınan numunenin materyal bilgisidir.</summary>
    [Required]
    public string PATOLOJI_MATERYALI { get; set; }
    /// <summary>Parçanın alındığı organ bilgisidir.</summary>
    [Required]
    public string ORGAN { get; set; }
    /// <summary>Sağlık tesisinde kişiden alınan numunenin nasıl alındığına ilişkin bilgiyi ifade...</summary>
    [Required]
    [ForeignKey("NumuneAlinmaYeriNavigation")]
    public string NUMUNE_ALINMA_YERI { get; set; }
    /// <summary>Sağlık tesisine başvuran kişiden alınan materyalin patolojik incelemesi sonucu e...</summary>
    [Required]
    public string PATOLOJIK_BULGU { get; set; }
    /// <summary>ICD-O Morfoloji kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("PatolojikTaniMorfolojiNavigation")]
    public string PATOLOJIK_TANI_MORFOLOJI_KODU { get; set; }
    /// <summary>Hastadan alınan patolojik dokunun vücutta bulunduğu yer için ICD-O yerleşim yeri...</summary>
    [Required]
    [ForeignKey("PatolojikTaniYerlesimYeriNavigation")]
    public string PATOLOJIK_TANI_YERLESIM_YERI { get; set; }
    /// <summary>Makroskopi sonuç bilgisidir.</summary>
    [Required]
    public string MAKROSKOPI_SONUCU { get; set; }
    /// <summary>Mikroskopi işlemi sonuç bilgisidir.</summary>
    [Required]
    public string MIKROSKOPI_SONUCU { get; set; }
    /// <summary>Raporun içeriğinin türüne ilişkin DOC, RTF, HTML vb. bilgiyi ifade eder.</summary>
    [ForeignKey("SonucIcerikTuruNavigation")]
    public string SONUC_ICERIK_TURU { get; set; }
    /// <summary>Raporu bilgisayar ortamına aktaran personel için Sağlık Bilgi Yönetim Sistemi ta...</summary>
    [Required]
    [ForeignKey("RaporYazanPersonelNavigation")]
    public string RAPOR_YAZAN_PERSONEL_KODU { get; set; }
    /// <summary>Hastadan alınan numunenin tetkikinin yapılması için laboratuvara kabul edildiği ...</summary>
    public DateTime PARCA_KABUL_ZAMANI { get; set; }
    /// <summary>Rapor zamanı bilgisidir.</summary>
    public DateTime RAPOR_ZAMANI { get; set; }
    /// <summary>Patoloji tetkiki için açıklama bilgisidir.</summary>
    [Required]
    public string PATOLOJI_ACIKLAMA { get; set; }
    /// <summary>Patoloji uzmanı tarafından yazılan tanı bilgisidir.</summary>
    [Required]
    public string HISTOPATOLOJIK_TANI { get; set; }
    /// <summary>Patoloji uzmanı tarafından yazılan tanı bilgisidir.</summary>
    [Required]
    public string SITOPATOLOJIK_TANI { get; set; }
    /// <summary>Patoloji numunesine uygulanan histokimyasal boyama yöntemi için uzman tarafından...</summary>
    [Required]
    public string HISTOKIMYASAL_BOYAMA { get; set; }
    /// <summary>Patoloji numunesinin immünhistokimya boyama işlemine göre elde edilen bilgidir.</summary>
    [Required]
    public string IMMUNHISTOKIMYA_BOYAMA { get; set; }
    /// <summary>Kişiden ameliyat sırasında alınan doku örneğine kısa süre içerisinde tanı koymak...</summary>
    [Required]
    public string FROZEN_TANI { get; set; }
    /// <summary>Numunenin hangi yöntemle boyandığı bilgisidir.</summary>
    [Required]
    public string NUMUNE_BOYAMA_YONTEMI { get; set; }
    /// <summary>Sağlık tesisinde işlemi gerçekleştiren veya işlemin sonucunu onaylayan hekim içi...</summary>
    [Required]
    [ForeignKey("OnaylayanHekimNavigation")]
    public string ONAYLAYAN_HEKIM_KODU { get; set; }
    /// <summary>Sağlık tesisinde sağlık hizmetini alan kişiyi muayene eden asistan hekimin Sağlı...</summary>
    [Required]
    [ForeignKey("AsistanHekimNavigation")]
    public string ASISTAN_HEKIM_KODU { get; set; }
    /// <summary>Patoloji tetkik sonucunu değerlendiren diğer hekim için Sağlık Bilgi Yönetim Sis...</summary>
    [Required]
    [ForeignKey("PatolojiDigerHekimNavigation")]
    public string PATOLOJI_DIGER_HEKIM_KODU { get; set; }
    /// <summary>Sağlık tesisinde uzman hekimin yazdığı yorum bilgisidir.</summary>
    [Required]
    public string YORUM { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? PatolojiRaporTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? DokununTemelOzelligiNavigation { get; set; }
    public virtual REFERANS_KODLAR? NumuneAlinmaSekliNavigation { get; set; }
    public virtual REFERANS_KODLAR? PatolojiPreparatiDurumuNavigation { get; set; }
    public virtual TETKIK_NUMUNE? TetkikNumuneNavigation { get; set; }
    public virtual REFERANS_KODLAR? NumuneAlinmaYeriNavigation { get; set; }
    public virtual REFERANS_KODLAR? PatolojikTaniMorfolojiNavigation { get; set; }
    public virtual REFERANS_KODLAR? PatolojikTaniYerlesimYeriNavigation { get; set; }
    public virtual REFERANS_KODLAR? SonucIcerikTuruNavigation { get; set; }
    public virtual PERSONEL? RaporYazanPersonelNavigation { get; set; }
    public virtual PERSONEL? OnaylayanHekimNavigation { get; set; }
    public virtual PERSONEL? AsistanHekimNavigation { get; set; }
    public virtual PERSONEL? PatolojiDigerHekimNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// PERSONEL tablosu - 146 kolon
/// </summary>
[Table("PERSONEL")]
public class PERSONEL
{
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [Key]
    public string PERSONEL_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Kişinin adı bilgisidir.</summary>
    public string AD { get; set; }
    /// <summary>Sağlık hizmeti alan kişinin kimlik belgesinde yer alan soyadıdır.</summary>
    public string SOYADI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin önceki soyadı bilgisidir.</summary>
    [Required]
    public string ONCEKI_SOYADI { get; set; }
    /// <summary>Kişinin resmi doğum tarihini ifade eder.</summary>
    public DateTime DOGUM_TARIHI { get; set; }
    /// <summary>Kişinin doğum yeri bilgisidir.</summary>
    [Required]
    public string DOGUM_YERI { get; set; }
    /// <summary>Kişinin cinsiyetini ifade eder.</summary>
    [ForeignKey("CinsiyetNavigation")]
    public string CINSIYET { get; set; }
    /// <summary>Kişinin anne adı bilgisidir.</summary>
    [Required]
    public string ANNE_ADI { get; set; }
    /// <summary>Kişinin baba adı bilgisidir.</summary>
    [Required]
    public string BABA_ADI { get; set; }
    /// <summary>Kişinin ev telefonu bilgisidir.</summary>
    [Required]
    public string EV_TELEFONU { get; set; }
    /// <summary>Kişinin cep telefonu bilgisidir.</summary>
    [Required]
    public string CEP_TELEFONU { get; set; }
    /// <summary>Kişinin elektronik posta adresidir.</summary>
    [Required]
    public string EPOSTA_ADRESI { get; set; }
    /// <summary>Kişinin en son bitirdiği okul seviyesini veya okuryazarlık durumunu ifade eder. ...</summary>
    [Required]
    [ForeignKey("OgrenimDurumuNavigation")]
    public string OGRENIM_DURUMU { get; set; }
    /// <summary>Kişiyi niteleyen eşsiz numaradır.</summary>
    [Required]
    public string TC_KIMLIK_NUMARASI { get; set; }
    /// <summary>Kişinin kan grubunu ifade eder</summary>
    [Required]
    [ForeignKey("KanGrubuNavigation")]
    public string KAN_GRUBU { get; set; }
    /// <summary>Sağlık hizmetini almak için sağlık tesisine başvuran kişinin vatandaşı olduğu ül...</summary>
    [Required]
    [ForeignKey("UlkeNavigation")]
    public string ULKE_KODU { get; set; }
    /// <summary>Kişiye ait kayıt altına alınacak adresin tipini ifade eder.</summary>
    [Required]
    [ForeignKey("AdresTipiNavigation")]
    public string ADRES_TIPI { get; set; }
    /// <summary>Adres kodunun hangi seviyeden seçildiğini ifade eder.</summary>
    [Required]
    [ForeignKey("AdresSeviyesiNavigation")]
    public string ADRES_KODU_SEVIYESI { get; set; }
    /// <summary>Kişinin açık adresidir.</summary>
    [Required]
    public string ACIK_ADRES { get; set; }
    /// <summary>İl kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("IlNavigation")]
    public string IL_KODU { get; set; }
    /// <summary>İlçe kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("IlceNavigation")]
    public string ILCE_KODU { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin sicil numarasını ifade eder.</summary>
    [Required]
    public string PERSONEL_SICIL_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin emekli sicil numarası bilgisidir.</summary>
    [Required]
    public string EMEKLI_SICIL_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin askerlik durumuna ilişkin bilgiyi ifade eder...</summary>
    [Required]
    [ForeignKey("AskerlikDurumuNavigation")]
    public string ASKERLIK_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde bulunan kliniklerin Sağlık Bilgi Yönetim Sistemi tarafından gru...</summary>
    [Required]
    [ForeignKey("KlinikNavigation")]
    public string KLINIK_KODU { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin tescil numarası bilgisidir.</summary>
    [Required]
    public string TESCIL_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin diploma numarası bilgisidir.</summary>
    [Required]
    public string DIPLOMA_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde bulunan klinik ve hekimler için MEDULA tarafından tanımlanmış b...</summary>
    [Required]
    public string MEDULA_BRANS_KODU { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin anlık olarak çalışma durumunu ifade eder. Ör...</summary>
    [Required]
    [ForeignKey("CalismaDurumuNavigation")]
    public string CALISMA_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin biyolog, çevre sağlık teknisyeni, uzman heki...</summary>
    [ForeignKey("UnvanNavigation")]
    public string UNVAN_KODU { get; set; }
    /// <summary>Sağlık tesisinde görevli personel için görevini tanımlayan kod bilgisidir.</summary>
    [Required]
    [ForeignKey("PersonelGorevNavigation")]
    public string PERSONEL_GOREV_KODU { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin sağlık tesisinde çalışma şeklini ifade eder....</summary>
    [Required]
    [ForeignKey("IsDurumuNavigation")]
    public string IS_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin kadro türünü belirleyen bilgiyi ifade eder. ...</summary>
    [ForeignKey("MemuriyetTipiNavigation")]
    public string MEMURIYET_TIPI { get; set; }
    /// <summary>Personelin sağlık tesisinde işe başladığı tarih bilgisidir.</summary>
    public DateTime? SAGLIK_TESISINE_BASLAMA_TARIHI { get; set; }
    /// <summary>Sağlık tesisinde görev yapan personelin asaletini aldığı tarih bilgisidir.</summary>
    public DateTime ASALET_ALMA_TARIHI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin terfi aldığı tarih bilgisidir.</summary>
    public DateTime TERFI_TARIHI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin emekli terfi tarihi bilgisidir.</summary>
    public DateTime EMEKLI_TERFI_TARIHI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin ilk işe başlama tarihi bilgisidir.</summary>
    public DateTime? ILK_ISE_BASLAMA_TARIHI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin işten ayrılma açıklama bilgisidir.</summary>
    public DateTime ISTEN_AYRILMA_TARIHI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin işten ayrılma nedenine ait Sağlık Bilgi Yöne...</summary>
    [Required]
    [ForeignKey("IstenAyrilmaNedeniNavigation")]
    public string ISTEN_AYRILMA_NEDENI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin işten ayrılma açıklama bilgisidir.</summary>
    [Required]
    public string ISTEN_AYRILMA_ACIKLAMASI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin memuriyete başlama tarihi bilgisidir.</summary>
    public DateTime MEMURIYETE_BASLAMA_TARIHI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin kadro unvan bilgisidir.</summary>
    [Required]
    [ForeignKey("KadroUnvanNavigation")]
    public string KADRO_UNVAN_KODU { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin imzasında bulunan unvanının Sağlık Bilgi Yön...</summary>
    [Required]
    [ForeignKey("ImzaUnvanNavigation")]
    public string IMZA_UNVAN_KODU { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin akademik unvanını belirten bilgidir. Örneğin...</summary>
    [Required]
    [ForeignKey("AkademikUnvanNavigation")]
    public string AKADEMIK_UNVAN { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin görev yaptığı birimi ifade eden Sağlık Bilgi...</summary>
    [Required]
    [ForeignKey("CalistigiBirimNavigation")]
    public string CALISTIGI_BIRIM_KODU { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin kadrosunun bulunduğu kurum bilgisidir.</summary>
    [Required]
    [ForeignKey("KadroluGorevYeriNavigation")]
    public string KADROLU_GOREV_YERI { get; set; }
    /// <summary>Sağlık tesisine başvuran kişinin engellilik durumunu ifade eder. Örneğin bedense...</summary>
    [Required]
    [ForeignKey("EngellilikDurumuNavigation")]
    public string ENGELLILIK_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde devlet hizmet yükümlüsü olarak çalışan personel için Sağlık Bil...</summary>
    [Required]
    public string DEVLET_HIZMET_YUKUMLULUK_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi veri tabanında bulunan bir kayıtın aktif olup olmad...</summary>
    [Required]
    public string AKTIFLIK_BILGISI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin dosyası için veya sağlık tesisine müracat et...</summary>
    [Required]
    public string FOTOGRAF_BILGISI { get; set; }
    /// <summary>Kişiye ait fotoğrafın Sağlık Bilgi Yönetim Sistemi'ne kayıt edildiği dosyanın ad...</summary>
    [Required]
    public string FOTOGRAF_DOSYA_YOLU { get; set; }
    /// <summary>Sağlık tesisinde görevli hekim için MEDULA sisteminde tanımlanmış kullanıcı şifr...</summary>
    [Required]
    public string HEKIM_MEDULA_SIFRESI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual REFERANS_KODLAR? CinsiyetNavigation { get; set; }
    public virtual REFERANS_KODLAR? OgrenimDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanGrubuNavigation { get; set; }
    public virtual REFERANS_KODLAR? UlkeNavigation { get; set; }
    public virtual REFERANS_KODLAR? AdresTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? AdresSeviyesiNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlceNavigation { get; set; }
    public virtual REFERANS_KODLAR? AskerlikDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? KlinikNavigation { get; set; }
    public virtual REFERANS_KODLAR? CalismaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? UnvanNavigation { get; set; }
    public virtual REFERANS_KODLAR? PersonelGorevNavigation { get; set; }
    public virtual REFERANS_KODLAR? IsDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? MemuriyetTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? IstenAyrilmaNedeniNavigation { get; set; }
    public virtual REFERANS_KODLAR? KadroUnvanNavigation { get; set; }
    public virtual REFERANS_KODLAR? ImzaUnvanNavigation { get; set; }
    public virtual REFERANS_KODLAR? AkademikUnvanNavigation { get; set; }
    public virtual BIRIM? CalistigiBirimNavigation { get; set; }
    public virtual REFERANS_KODLAR? KadroluGorevYeriNavigation { get; set; }
    public virtual REFERANS_KODLAR? EngellilikDurumuNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// PERSONEL_BAKMAKLA_YUKUMLU tablosu - 14 kolon
/// </summary>
[Table("PERSONEL_BAKMAKLA_YUKUMLU")]
public class PERSONEL_BAKMAKLA_YUKUMLU
{
    /// <summary>Sağlık tesisinde görevli personelin bakmakla yükümlü olduğu kişilerin bilgileri ...</summary>
    [Key]
    public string PERSONEL_BAKMAKLA_YUKUMLU_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin bakmakla yükümlü olduğu kişinin personele ya...</summary>
    [ForeignKey("PersonelYakinlikDerecesiNavigation")]
    public string PERSONEL_YAKINLIK_DERECESI { get; set; }
    /// <summary>Kişiyi niteleyen eşsiz numaradır.</summary>
    [Required]
    public string TC_KIMLIK_NUMARASI { get; set; }
    /// <summary>Kişinin adı bilgisidir.</summary>
    public string AD { get; set; }
    /// <summary>Sağlık hizmeti alan kişinin kimlik belgesinde yer alan soyadıdır.</summary>
    public string SOYADI { get; set; }
    /// <summary>Kişinin resmi doğum tarihini ifade eder.</summary>
    public DateTime? DOGUM_TARIHI { get; set; }
    /// <summary>Kişinin en son bitirdiği okul seviyesini veya okuryazarlık durumunu ifade eder. ...</summary>
    [Required]
    [ForeignKey("OgrenimDurumuNavigation")]
    public string OGRENIM_DURUMU { get; set; }
    /// <summary>Sağlık tesisine başvuran kişinin engellilik durumunu ifade eder. Örneğin bedense...</summary>
    [Required]
    [ForeignKey("EngellilikDurumuNavigation")]
    public string ENGELLILIK_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual PERSONEL? PersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? PersonelYakinlikDerecesiNavigation { get; set; }
    public virtual REFERANS_KODLAR? OgrenimDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? EngellilikDurumuNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// PERSONEL_BANKA tablosu - 14 kolon
/// </summary>
[Table("PERSONEL_BANKA")]
public class PERSONEL_BANKA
{
    /// <summary>Sağlık tesisinde görevli personelin banka bilgileri için Sağlık Bilgi Yönetim Si...</summary>
    [Key]
    public string PERSONEL_BANKA_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisinin hizmet aldığı banka isim bilgisidir. Örneğin T.C Ziraat Bankası...</summary>
    [ForeignKey("BankaNavigation")]
    public string BANKA { get; set; }
    /// <summary>Kişinin banka hesap numarası bilgisidir.</summary>
    [Required]
    public string HESAP_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin hesap numarasının şube kodu bilgisidir.</summary>
    [Required]
    public string SUBE_KODU { get; set; }
    /// <summary>Firmaya ait IBAN numarası bilgisidir.</summary>
    [Required]
    public string IBAN_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde görev yapan personel için hesaplanan ödemenin tür bilgisidir.</summary>
    [Required]
    [ForeignKey("BordroTuruNavigation")]
    public string BORDRO_TURU { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin Sağlık Bilgi Yönetim Sistemi' de kayıtlı ban...</summary>
    public string HESAP_AKTIFLIK_BILGISI { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual PERSONEL? PersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? BankaNavigation { get; set; }
    public virtual REFERANS_KODLAR? BordroTuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// PERSONEL_BORDRO tablosu - 85 kolon
/// </summary>
[Table("PERSONEL_BORDRO")]
public class PERSONEL_BORDRO
{
    /// <summary>Sağlık tesisinde görevli personelin bordro bilgileri için Sağlık Bilgi Yönetim S...</summary>
    [Key]
    public string PERSONEL_BORDRO_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Yıl bilgisini ifade eder.</summary>
    public string YIL { get; set; }
    /// <summary>Yılın on iki bölümünden her birini ifade eder.</summary>
    public string AY { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisinde görev yapan personel için hesaplanan ödemenin tür bilgisidir.</summary>
    [ForeignKey("BordroTuruNavigation")]
    public string BORDRO_TURU { get; set; }
    /// <summary>Sağlık tesisinde görev yapan personel için yapılan her türlü ödeme bilgisine ait...</summary>
    [Required]
    public string BORDRO_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele ait maaş derece bilgisidir.</summary>
    [Required]
    public string MAAS_DERECESI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele ait maaş kademe bilgisidir.</summary>
    [Required]
    public string MAAS_KADEMESI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele ait maaş gösterge bilgisidir.</summary>
    [Required]
    public string MAAS_GOSTERGESI { get; set; }
    /// <summary>Sağlık tesisinde görevli Personele ait maaş ek gösterge bilgisidir.</summary>
    [Required]
    public string MAAS_EK_GOSTERGESI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele ait emekli derecesi bilgisidir.</summary>
    [Required]
    public string EMEKLI_DERECESI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele ait emekli kademe bilgisidir.</summary>
    [Required]
    public string EMEKLI_KADEMESI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin ait emekli gösterge bilgisidir.</summary>
    [Required]
    public string EMEKLI_GOSTERGESI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele ait emekli ek göstergesi bilgisidir.</summary>
    [Required]
    public string EMEKLI_EK_GOSTERGESI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele ait taban aylık tutar bilgisidir.</summary>
    [Required]
    public string TABAN_AYLIK_TUTARI { get; set; }
    /// <summary>Sağlık tesisisinde görevli personele yapılan aylık ödeme bilgisidir.</summary>
    [Required]
    public string AYLIK_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele ait kıdem tutarı bilgisidir.</summary>
    [Required]
    public string KIDEM_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin ek gösterge tutarı bilgisidir.</summary>
    [Required]
    public string EK_GOSTERGE_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele ait yan ödeme tutarı bilgisidir.</summary>
    [Required]
    public string YAN_ODEME_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele ait özel hizmet tutarı bilgisidir.</summary>
    [Required]
    public string OZEL_HIZMET_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele yapılan aile yardımı tutarı bilgisidir.</summary>
    [Required]
    public string AILE_YARDIMI_TUTARI { get; set; }
    /// <summary>Sağlık tesisindeki görevli personele yapılan çocuk yardımı tutarı bilgisidir.</summary>
    [Required]
    public string COCUK_YARDIMI_TUTARI { get; set; }
    /// <summary>Sağlık tesisindeki görevli personelin 6 yaş altındaki (yaş < 6) çocuk sayısı bil...</summary>
    [Required]
    public string COCUK_SAYISI_6_YAS_ALTI { get; set; }
    /// <summary>Sağlık tesisindeki görevli personelin 6 yaş üstündeki (yaş > 6) çocuk sayısı bil...</summary>
    [Required]
    public string COCUK_SAYISI_6_YAS_USTU { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin Asgari Geçim İndirimine (AGİ) esas çocuk say...</summary>
    [Required]
    public string AGI_ESAS_COCUK_SAYISI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin eşinin herhangi bir işte çalışma durumunu if...</summary>
    [Required]
    [ForeignKey("EsCalismaDurumuNavigation")]
    public string ES_CALISMA_DURUMU { get; set; }
    /// <summary>Bireysel Emeklilik Sigortası (BES) kesintisinin aktarıldığı sigorta firması için...</summary>
    [Required]
    [ForeignKey("BesFirmaNavigation")]
    public string BES_FIRMA_KODU { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin maaşından, Bireysel Emeklilik Sigortası (BES...</summary>
    [Required]
    public string BES_ORANI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin maaşından, Bireysel Emeklilik Sigortası (BES...</summary>
    [Required]
    public string BES_KESINTI_TUTARI { get; set; }
    /// <summary>Devlet tarafından sağlık tesisinde görevli personele ödenen yabancı dil tazminat...</summary>
    [Required]
    public string YABANCI_DIL_TAZMINATI_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin bildiği yabancı dillerin bilgisidir. Örneğin...</summary>
    [Required]
    [ForeignKey("YabanciDilBilgisiNavigation")]
    public string YABANCI_DIL_BILGISI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin bildiği yabancı dillerin derecesini gösteren...</summary>
    [Required]
    public string YABANCI_DIL_PUANI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin bordrosunda bulunan sendika ödeneği tutarı b...</summary>
    [Required]
    public string SENDIKA_ODENEGI_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin bordrosunda hangi sendika için kesinti yapıl...</summary>
    [Required]
    [ForeignKey("SendikaBilgisiNavigation")]
    public string SENDIKA_BILGISI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin sendika listelerinde kişinin bilgilerinin bu...</summary>
    [Required]
    public string SENDIKA_SIRA_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin bordrosunda bulunan sendika kesinti oranı bi...</summary>
    [Required]
    public string SENDIKA_KESINTI_ORANI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin sendika aidatı tutar bilgisini ifade eder.</summary>
    [Required]
    public string SENDIKA_AIDATI_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele ait devlete kesilen emekli keseneği bilgisidi...</summary>
    [Required]
    public string DEVLET_EMEKLI_KESENEGI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele ait şahsa kesilen emekli keseneği bilgisidir.</summary>
    [Required]
    public string SAHIS_EMEKLI_KESENEGI { get; set; }
    /// <summary>Emekli keseneği primlerinin hesaplanmasında kullanılan tutar bilgisidir.</summary>
    [Required]
    public string EMEKLI_KESENEGI_MATRAHI_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin maaşına eklenen özel sağlık sigortası tutar ...</summary>
    [Required]
    public string OZEL_SIGORTA_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin vergi indirimi tutarı bilgisidir.</summary>
    [Required]
    public string VERGI_INDIRIMI_TUTARI { get; set; }
    /// <summary>Damga vergisi tutar bilgisidir.</summary>
    [Required]
    public string DAMGA_VERGISI_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personel için gelir vergisi tutar bilgisidir.</summary>
    [Required]
    public string GELIR_VERGISI_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personel için gelir vergisi hesaplanmasında kullanılan ...</summary>
    [Required]
    public string GELIR_VERGISI_MATRAHI_TUTARI { get; set; }
    /// <summary>Kümülatif gelir vergisi tutar bilgisidir.</summary>
    [Required]
    public string KUMULATIF_GELIR_VERGISI_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin maaşından kesilen icra tutarı bilgisidir.</summary>
    [Required]
    public string ICRA_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin maaşından kesilen nafaka tutarı bilgisidir.</summary>
    [Required]
    public string NAFAKA_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin terfisi nedeni ile maaşına eklenen tutar bil...</summary>
    [Required]
    public string YUZDE_YUZ_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin doğu tazminat tutarı bilgisidir.</summary>
    [Required]
    public string DOGU_TAZMINATI_TUTARI { get; set; }
    /// <summary>Sosyal Güvenlik Kurumu (SGK) şahıs tutarı bilgisidir.</summary>
    [Required]
    public string SGK_SAHIS_TUTARI { get; set; }
    /// <summary>Sosyal Güvenlik Kurumu (SGK) işveren tutarı bilgisidir.</summary>
    [Required]
    public string SGK_ISVEREN_TUTARI { get; set; }
    /// <summary>Sosyal Güvenlik Kurumu (SGK) matrahı tutarı bilgisidir.</summary>
    [Required]
    public string SGK_MATRAHI_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin maaşından kesilen kefalet tutarı bilgisidir.</summary>
    [Required]
    public string KEFALET_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde sözleşmeli olarak görev yapan personelin sözleşme ücret tutarı ...</summary>
    [Required]
    public string SOZLESME_UCRETI_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin lojmandan yararlanması durumunda maaşından y...</summary>
    [Required]
    public string LOJMAN_KESINTISI_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görev yapan personelin asgari geçim indirimi (AGİ) tutarı bilgi...</summary>
    [Required]
    public string ASGARI_GECIM_INDIRIMI_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personel için hesaplanan ay işsizlik şahıs tutarı bilgi...</summary>
    [Required]
    public string ISSIZLIK_SAHIS_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personel için hesaplanan işsizlik işveren tutarı bilgis...</summary>
    [Required]
    public string ISSIZLIK_ISVEREN_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personel için hesaplanan ay için toplam işsizlik primi ...</summary>
    [Required]
    public string ISSIZLIK_PRIMI_MATRAHI_TUTARI { get; set; }
    /// <summary>Malullük devlet tutarı bilgisidir.</summary>
    [Required]
    public string MALULLUK_DEVLET_TUTARI { get; set; }
    /// <summary>Malullük şahıs tutarı bilgisidir.</summary>
    [Required]
    public string MALULLUK_SAHIS_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele yapılan giyecek yardımı tutarı bilgisidir.</summary>
    [Required]
    public string GIYECEK_YARDIMI_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele ödenen fark tazminatı tutar bilgisidir.</summary>
    [Required]
    public string FARK_TAZMINATI_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personel için hizmet zammı tutar bilgisidir.</summary>
    [Required]
    public string HIZMET_ZAMMI_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele yapılan vasıta yardımı tutar bilgisidir.</summary>
    [Required]
    public string VASITA_YARDIMI_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele yapılan kira yardımı tutarı bilgisidir.</summary>
    [Required]
    public string KIRA_YARDIMI_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele yapılan yemek yardımı tutarı bilgisidir.</summary>
    [Required]
    public string YEMEK_YARDIMI_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele ödenen fazla mesai tutarı bilgisidir.</summary>
    [Required]
    public string FAZLA_MESAI_TUTARI { get; set; }
    /// <summary>Nöbet hesaplamasında kullanılan 1 saate karşılık gelen tutar bilgisidir.</summary>
    [Required]
    public string NOBET_BIRIM_UCRET_TUTARI { get; set; }
    /// <summary>Nöbet hesaplamasında kullanılan 1 saate karşılık gelen tutarın %20 fazlasıdır.</summary>
    [Required]
    public string NOBET_BIRIM_UCRET_20_TUTARI { get; set; }
    /// <summary>Nöbet hesaplamasında kullanılan 1 saate karşılık gelen tutarın %50 fazlasıdır.</summary>
    [Required]
    public string NOBET_BIRIM_UCRET_50_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin nöbet hesaplamasında kullanılan toplam nöbet...</summary>
    [Required]
    public string NOBET_SAATI { get; set; }
    /// <summary>Sağlık tesisindeki personelin bir aylık süre içerisinde dini bayramlarda tuttuğu...</summary>
    [Required]
    public string NOBET_20_SAATI { get; set; }
    /// <summary>Sağlık tesisindeki personelin bir aylık süre içerisinde riskli birimlerde (yoğun...</summary>
    [Required]
    public string NOBET_50_SAATI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele ait yevmiye tutarı bilgisidir.</summary>
    [Required]
    public string YEVMIYE_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin çalışmış olduğu saat bilgisidir.</summary>
    [Required]
    public string CALISMA_SAATI { get; set; }
    /// <summary>Sağlık tesisinde görevli personel için hesaplanan tahakkuk toplamı bilgisidir.</summary>
    [Required]
    public string TAHAKKUK_TOPLAMI { get; set; }
    /// <summary>Sağlık tesisindeki personelin net tutar bilgisidir.</summary>
    [Required]
    public string NET_TUTAR { get; set; }
    /// <summary>Sağlık tesisinde görevli personele yapılan ödemelerden (maaş, ek ödeme, nöbet vb...</summary>
    [Required]
    public string KESINTI_TOPLAMI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual PERSONEL? PersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? BordroTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? EsCalismaDurumuNavigation { get; set; }
    public virtual FIRMA? BesFirmaNavigation { get; set; }
    public virtual REFERANS_KODLAR? YabanciDilBilgisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SendikaBilgisiNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// PERSONEL_BORDRO_SONDURUM tablosu - 17 kolon
/// </summary>
[Table("PERSONEL_BORDRO_SONDURUM")]
public class PERSONEL_BORDRO_SONDURUM
{
    /// <summary>Sağlık tesisinde görevli personelin bordrosuna ait son durum bilgileri için Sağl...</summary>
    [Key]
    public string PERSONEL_SONDURUM_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin kademe bilgisidir.</summary>
    [Required]
    public string PERSONEL_KADEMESI { get; set; }
    /// <summary>Sağlık tesisinde görevli personel için kıdem derece bilgisidir.</summary>
    [Required]
    public string PERSONEL_DERECESI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele ait emekli derecesi bilgisidir.</summary>
    [Required]
    public string EMEKLI_DERECESI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele ait emekli kademe bilgisidir.</summary>
    [Required]
    public string EMEKLI_KADEMESI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin bordrosunda hangi sendika için kesinti yapıl...</summary>
    [Required]
    public string SENDIKA_BILGISI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin kıdem yılı bilgisidir.</summary>
    [Required]
    public string KIDEM_YILI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin kıdem ayı bilgisidir.</summary>
    [Required]
    public string KIDEM_AYI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin kıdem günü bilgisidir.</summary>
    [Required]
    public string KIDEM_GUNU { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin ek gösterge bilgisidir.</summary>
    [Required]
    public string EK_GOSTERGE { get; set; }
    /// <summary>Sağlık tesisinde görevli personele ait emekli ek göstergesi bilgisidir.</summary>
    [Required]
    public string EMEKLI_EK_GOSTERGESI { get; set; }
    /// <summary>Sağlık tesisinde 657 sayılı Devlet Memurları Kanunu kapsamında görevli personeli...</summary>
    [Required]
    public string GOSTERGE { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin ait emekli gösterge bilgisidir.</summary>
    [Required]
    public string EMEKLI_GOSTERGESI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin yan ödeme puan bilgisidir.</summary>
    [Required]
    public string YAN_ODEME_PUANI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin özel hizmet puanı bilgisidir.</summary>
    [Required]
    public string OZEL_HIZMET_PUANI { get; set; }
    #region Navigation Properties
    public virtual PERSONEL? PersonelNavigation { get; set; }
    #endregion
}

/// <summary>
/// PERSONEL_EGITIM tablosu - 16 kolon
/// </summary>
[Table("PERSONEL_EGITIM")]
public class PERSONEL_EGITIM
{
    /// <summary>Sağlık tesisinde görevli personelin almış olduğu eğitim bilgileri için Sağlık Bi...</summary>
    [Key]
    public string PERSONEL_EGITIM_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin almış olduğu eğitim bilgileri için Sağlık Bi...</summary>
    [ForeignKey("PersonelEgitimTuruNavigation")]
    public string PERSONEL_EGITIM_TURU { get; set; }
    /// <summary>Sağlık tesisinde görevli personele ait sertifikalara ilişkin detaylı bilgiyi ifa...</summary>
    [Required]
    [ForeignKey("SertifikaTipiNavigation")]
    public string SERTIFIKA_TIPI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele ait sertifikaların puan bilgisini ifade eder.</summary>
    [Required]
    public string SERTIFIKA_PUANI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin eğitim veya öğrenim için aldığı belgenin num...</summary>
    [Required]
    public string BELGE_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin aldığı eğitimin başladığı zaman bilgisidir.</summary>
    public DateTime? EGITIM_BASLANGIC_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin aldığı eğitimin bittiği zaman bilgisidir.</summary>
    public DateTime EGITIM_BITIS_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin aldığı eğitimi veren kişinin ad soyadı bilgi...</summary>
    [Required]
    public string EGITIM_VEREN_KISI_BILGISI { get; set; }
    /// <summary>Eğitimin verildiği yer bilgisidir.</summary>
    [Required]
    public string EGITIM_YERI { get; set; }
    /// <summary>Yapılan bir işlemi onaylayan personel için Sağlık Bilgi Yönetim Sistemi tarafınd...</summary>
    [Required]
    [ForeignKey("OnaylayanPersonelNavigation")]
    public string ONAYLAYAN_PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual PERSONEL? PersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? PersonelEgitimTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? SertifikaTipiNavigation { get; set; }
    public virtual PERSONEL? OnaylayanPersonelNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// PERSONEL_GOREVLENDIRME tablosu - 13 kolon
/// </summary>
[Table("PERSONEL_GOREVLENDIRME")]
public class PERSONEL_GOREVLENDIRME
{
    /// <summary>Sağlık tesisinde görevli personelin görevlendirilme bilgileri için Sağlık Bilgi ...</summary>
    [Key]
    public string PERSONEL_GOREVLENDIRME_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin yaptığı görev için Sağlık Bilgi Yönetim Sist...</summary>
    [ForeignKey("GorevTuruNavigation")]
    public string GOREV_TURU { get; set; }
    /// <summary>Sağlık tesisindeki personelin görevlendirildiği kurumda göreve başladığı tarih b...</summary>
    public DateTime? GOREVLENDIRME_BASLAMA_TARIHI { get; set; }
    /// <summary>Sağlık tesisindeki personelin görevlendirildiği kurumda görevinin bittiği tarih ...</summary>
    public DateTime GOREVLENDIRME_BITIS_TARIHI { get; set; }
    /// <summary>Sağlık tesisindeki personelin görevlendirildiği ilin, il kodunu ifade eder.</summary>
    [Required]
    [ForeignKey("GorevlendirmeIlNavigation")]
    public string GOREVLENDIRME_IL_KODU { get; set; }
    /// <summary>Sağlık tesisindeki personelin görevlendirildiği ilçenin, ilçe kodunu ifade eder.</summary>
    [Required]
    [ForeignKey("GorevlendirmeIlceNavigation")]
    public string GOREVLENDIRME_ILCE_KODU { get; set; }
    /// <summary>Sağlık tesisindeki personelin görevlendirildiği kurum için Sağlık Bilgi Yönetim ...</summary>
    [Required]
    [ForeignKey("GorevlendirildigiKurumNavigation")]
    public string GOREVLENDIRILDIGI_KURUM_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual PERSONEL? PersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? GorevTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? GorevlendirmeIlNavigation { get; set; }
    public virtual REFERANS_KODLAR? GorevlendirmeIlceNavigation { get; set; }
    public virtual KURUM? GorevlendirildigiKurumNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// PERSONEL_IZIN tablosu - 21 kolon
/// </summary>
[Table("PERSONEL_IZIN")]
public class PERSONEL_IZIN
{
    /// <summary>SBYS tarafından üretilen tekil kod bilgisidir.</summary>
    [Key]
    public string PERSONEL_IZIN_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin kullandığı iznin türü (doğum izni, yıllık iz...</summary>
    [ForeignKey("PersonelIzinTuruNavigation")]
    public string PERSONEL_IZIN_TURU { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin kullandığı iznin gün sayısı bilgisidir.</summary>
    public string KULLANILAN_IZIN { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin bir önceki yıldan kalan izninden kullandığı ...</summary>
    [Required]
    public string GECEN_YILDAN_KULLANILAN_IZIN { get; set; }
    /// <summary>Sağlık tesisi personelinin içinde bulunduğu yıldan kullanılan yıllık izin gün sa...</summary>
    [Required]
    public string AKTIF_YILDAN_KULLANILAN_IZIN { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin izin başlama tarihi bilgisidir.</summary>
    public DateTime? IZIN_BASLAMA_TARIHI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin izninin bitiş tarihi bilgisidir.</summary>
    public DateTime IZIN_BITIS_TARIHI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin kullandığı iznin hangi yıla ait olduğu bilgi...</summary>
    public string PERSONEL_IZIN_YILI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin göreve başladığı tarih bilgisidir.</summary>
    public DateTime PERSONEL_DONUS_TARIHI { get; set; }
    /// <summary>Sağlık tesisinde görev yapan personelin izne çıktığı adres bilgisidir.</summary>
    [Required]
    public string IZIN_ADRESI { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin izin döneminde Sağlık Bilgi Yönetim Sistemin...</summary>
    [Required]
    public string SBYS_ENGELLENME_DURUMU { get; set; }
    /// <summary>SBYS kullanımının engellendiği zaman bilgisidir.</summary>
    public DateTime SBYS_KULLANIM_ENGELLEME_ZAMANI { get; set; }
    /// <summary>SBYS kullanımını engelleyen kullanıcının</summary>
    [Required]
    [ForeignKey("SbysEngelleyenKullaniciNavigation")]
    public string SBYS_ENGELLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Yapılan bir işlemi onaylayan personel için Sağlık Bilgi Yönetim Sistemi tarafınd...</summary>
    [Required]
    [ForeignKey("OnaylayanPersonelNavigation")]
    public string ONAYLAYAN_PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual PERSONEL? PersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? PersonelIzinTuruNavigation { get; set; }
    public virtual KULLANICI? SbysEngelleyenKullaniciNavigation { get; set; }
    public virtual PERSONEL? OnaylayanPersonelNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// PERSONEL_IZIN_DURUMU tablosu - 6 kolon
/// </summary>
[Table("PERSONEL_IZIN_DURUMU")]
public class PERSONEL_IZIN_DURUMU
{
    /// <summary>Sağlık tesisinde görevli personelin izin durumu bilgileri için Sağlık Bilgi Yöne...</summary>
    [Key]
    public string PERSONEL_IZIN_DURUMU_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin kalan izin gün sayısı bilgisidir.</summary>
    public string KALAN_IZIN { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin çalıştığı yıl için hak ettiği izin gün sayıs...</summary>
    public string YILLIK_IZIN_HAKKI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin kullandığı iznin hangi yıla ait olduğu bilgi...</summary>
    public string PERSONEL_IZIN_YILI { get; set; }
    #region Navigation Properties
    public virtual PERSONEL? PersonelNavigation { get; set; }
    #endregion
}

/// <summary>
/// PERSONEL_ODUL_CEZA tablosu - 16 kolon
/// </summary>
[Table("PERSONEL_ODUL_CEZA")]
public class PERSONEL_ODUL_CEZA
{
    /// <summary>Sağlık tesisinde görevli personel için sağlık tesisi idaresi tarafından verilen ...</summary>
    [Key]
    public string PERSONEL_ODUL_CEZA_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisi idaresi tarafından personele verilen ödül veya ceza için durum bil...</summary>
    public string ODUL_CEZA_DURUMU { get; set; }
    /// <summary>Sağlık tesisi idaresi tarafından personele verilen ödül veya cezanın ikramiye, k...</summary>
    [ForeignKey("OdulCezaTuruNavigation")]
    public string ODUL_CEZA_TURU { get; set; }
    /// <summary>Sağlık tesisinde görevli personele verilen cezanın başladığı tarih bilgisidir.</summary>
    public DateTime CEZA_BASLANGIC_TARIHI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele verilen cezanın bittiği tarih bilgisidir.</summary>
    public DateTime CEZA_BITIS_TARIHI { get; set; }
    /// <summary>Sağlık personeline ödül veya ceza veren kurum kodu bilgisidir.</summary>
    [ForeignKey("OdulCezaVerenKurumNavigation")]
    public string ODUL_CEZA_VEREN_KURUM_KODU { get; set; }
    /// <summary>Sağlık tesisi idaresi tarafından personele verilen ödül veya cezaya ait açıklama...</summary>
    [Required]
    public string ODUL_CEZA_ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde personele verilen ödül veya cezanın personele tebliğ edildiği t...</summary>
    public DateTime? TEBLIG_TARIHI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele tebliğ edilen evrakın düzenlendiği tarih bilg...</summary>
    public DateTime TEBLIG_EVRAK_TARIHI { get; set; }
    /// <summary>Sağlık tesisinde görevli personele tebliğ edilen evrakın numara bilgisidir.</summary>
    [Required]
    public string TEBLIG_EVRAK_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual PERSONEL? PersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? OdulCezaTuruNavigation { get; set; }
    public virtual KURUM? OdulCezaVerenKurumNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// PERSONEL_OGRENIM tablosu - 13 kolon
/// </summary>
[Table("PERSONEL_OGRENIM")]
public class PERSONEL_OGRENIM
{
    /// <summary>Sağlık tesisinde görevli personelin öğrenim bilgileri için Sağlık Bilgi Yönetim ...</summary>
    [Key]
    public string PERSONEL_OGRENIM_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }
    /// <summary>Kişinin en son bitirdiği okul seviyesini veya okuryazarlık durumunu ifade eder. ...</summary>
    [ForeignKey("OgrenimDurumuNavigation")]
    public string OGRENIM_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin öğrenim gördüğü okul bilgisidir.</summary>
    [Required]
    public string OKUL_ADI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin öğrenim gördüğü okula başlama tarihi bilgisi...</summary>
    public DateTime OKULA_BASLANGIC_TARIHI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin öğrenim gördüğü okuldan mezun olduğu tarih b...</summary>
    public DateTime MEZUNIYET_TARIHI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin eğitim veya öğrenim için aldığı belgenin num...</summary>
    [Required]
    public string BELGE_NUMARASI { get; set; }
    /// <summary>Yapılan bir işlemi onaylayan personel için Sağlık Bilgi Yönetim Sistemi tarafınd...</summary>
    [Required]
    [ForeignKey("OnaylayanPersonelNavigation")]
    public string ONAYLAYAN_PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual PERSONEL? PersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? OgrenimDurumuNavigation { get; set; }
    public virtual PERSONEL? OnaylayanPersonelNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// PERSONEL_YANDAL tablosu - 10 kolon
/// </summary>
[Table("PERSONEL_YANDAL")]
public class PERSONEL_YANDAL
{
    /// <summary>Sağlık tesisinde görevli personelin yan dal bilgileri için Sağlık Bilgi Yönetim ...</summary>
    [Key]
    public string PERSONEL_YANDAL_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin yan dal eğitimine başladığı tarih bilgisidir...</summary>
    public DateTime? YANDAL_BASLANGIC_TARIHI { get; set; }
    /// <summary>Sağlık tesisinde görevli personelin yan dal eğitiminin bitiş tarih bilgisidir.</summary>
    public DateTime YANDAL_BITIS_TARIHI { get; set; }
    /// <summary>Sağlık tesisinde bulunan klinik ve hekimler için MEDULA tarafından tanımlanmış b...</summary>
    public string MEDULA_BRANS_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual PERSONEL? PersonelNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// RADYOLOJI tablosu - 22 kolon
/// </summary>
[Table("RADYOLOJI")]
public class RADYOLOJI
{
    /// <summary>SBYS tarafından üretilen tekil kod bilgisidir.</summary>
    [Key]
    public string RADYOLOJI_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan bölümler için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("BirimNavigation")]
    public string BIRIM_KODU { get; set; }
    /// <summary>Radyolojik tetkik çekimi için hastanın kabulünün yapıldığı zamandır.</summary>
    public DateTime TETKIK_CEKIM_KABUL_ZAMANI { get; set; }
    /// <summary>Çubuk kod ya da çizgi im, verilerin görsel özellikli makinelerin okuyabilmesi iç...</summary>
    [Required]
    public string BARKOD { get; set; }
    /// <summary>Barkod yazdırma zamanı bilgisidir.</summary>
    public DateTime BARKOD_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde bulunan cihaz için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [Required]
    [ForeignKey("CihazNavigation")]
    public string CIHAZ_KODU { get; set; }
    /// <summary>Tetkikin tıbbi cihazda çalışılmaya başlandığı zaman bilgisidir.</summary>
    public DateTime CALISMA_BASLAMA_ZAMANI { get; set; }
    /// <summary>Tetkikin tıbbi cihazda çalışılmasının bittiği zaman bilgisidir.</summary>
    public DateTime CALISMA_BITIS_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde tedavi alan hastaya istenen tetkiklerin kabulünü yapan Sağlık B...</summary>
    [Required]
    [ForeignKey("KabulEdenKullaniciNavigation")]
    public string KABUL_EDEN_KULLANICI_KODU { get; set; }
    /// <summary>Radyolojik tetkik çekimini gerçekleştiren sağlık tesisinde görevli personel için...</summary>
    [Required]
    [ForeignKey("TetkikCekenTeknisyenNavigation")]
    public string TETKIK_CEKEN_TEKNISYEN_KODU { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanacak hizmetler için Sağlık Bilgi Yönetim Sistemi...</summary>
    [ForeignKey("HastaHizmetNavigation")]
    public string HASTA_HIZMET_KODU { get; set; }
    /// <summary>LOINC, Sağlık tesisinde laboratuvar veya radyolojik tetkik sonuçlarının sınıflan...</summary>
    [Required]
    public string LOINC_KODU { get; set; }
    /// <summary>Sağlık tesisinde yapılan tetkiklerin istenme durumuna ilişkin ön kabul, kabul, s...</summary>
    [Required]
    [ForeignKey("TetkikIstenmeDurumuNavigation")]
    public string TETKIK_ISTENME_DURUMU { get; set; }
    /// <summary>Radyolojik tetkik çekimine ait erişim numarası (Accession Number) bilgisidir.</summary>
    [Required]
    public string ERISIM_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual BIRIM? BirimNavigation { get; set; }
    public virtual CIHAZ? CihazNavigation { get; set; }
    public virtual KULLANICI? KabulEdenKullaniciNavigation { get; set; }
    public virtual PERSONEL? TetkikCekenTeknisyenNavigation { get; set; }
    public virtual HASTA_HIZMET? HastaHizmetNavigation { get; set; }
    public virtual REFERANS_KODLAR? TetkikIstenmeDurumuNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// RADYOLOJI_SONUC tablosu - 17 kolon
/// </summary>
[Table("RADYOLOJI_SONUC")]
public class RADYOLOJI_SONUC
{
    /// <summary>Sağlık tesisinde çalışılan radyoloji tetkikinin sonucu için Sağlık Bilgi Yönetim...</summary>
    [Key]
    public string RADYOLOJI_SONUC_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde çalışılan radyoloji tetkileri için Sağlık Bilgi Yönetim Sistemi...</summary>
    [ForeignKey("RadyolojiNavigation")]
    public string RADYOLOJI_KODU { get; set; }
    /// <summary>Radyoloji tetkikleri için rapora yazılan sonuç bilgisinin metin (text) bilgisidi...</summary>
    [Required]
    public string TETKIK_SONUCU_METIN { get; set; }
    /// <summary>Radyoloji tetkikleri için rapora yazılan sonuç bilgisinin raporda yazıldığı hali...</summary>
    [Required]
    public string RADYOLOJI_TETKIK_SONUCU { get; set; }
    /// <summary>Radyoloji raporları için Sağlık Bilgi Yönetim Sistemi tarafından kayıt edilen do...</summary>
    [ForeignKey("RadyolojiRaporFormatiNavigation")]
    public string RADYOLOJI_RAPOR_FORMATI { get; set; }
    /// <summary>Raporun ana rapor, ek rapor, konsültasyon raporu vb. olma durumuna ilişkin bilgi...</summary>
    [ForeignKey("RaporTipiNavigation")]
    public string RAPOR_TIPI { get; set; }
    /// <summary>Raporu bilgisayar ortamına aktaran personel için Sağlık Bilgi Yönetim Sistemi ta...</summary>
    [Required]
    [ForeignKey("RaporYazanPersonelNavigation")]
    public string RAPOR_YAZAN_PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [Required]
    [ForeignKey("OnaylayanPersonel1Navigation")]
    public string ONAYLAYAN_PERSONEL_KODU_1 { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [Required]
    [ForeignKey("OnaylayanPersonel2Navigation")]
    public string ONAYLAYAN_PERSONEL_KODU_2 { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [Required]
    [ForeignKey("OnaylayanPersonel3Navigation")]
    public string ONAYLAYAN_PERSONEL_KODU_3 { get; set; }
    /// <summary>Sağlık tesisinde üretilen tıbbi raporun uzman hekim tarafından onaylandığı zaman...</summary>
    public DateTime RAPOR_UZMAN_ONAY_ZAMANI { get; set; }
    /// <summary>Raporun kaydedildiği zaman bilgisidir.</summary>
    public DateTime? RAPOR_KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual RADYOLOJI? RadyolojiNavigation { get; set; }
    public virtual REFERANS_KODLAR? RadyolojiRaporFormatiNavigation { get; set; }
    public virtual REFERANS_KODLAR? RaporTipiNavigation { get; set; }
    public virtual PERSONEL? RaporYazanPersonelNavigation { get; set; }
    public virtual PERSONEL? OnaylayanPersonel1Navigation { get; set; }
    public virtual PERSONEL? OnaylayanPersonel2Navigation { get; set; }
    public virtual PERSONEL? OnaylayanPersonel3Navigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// RANDEVU tablosu - 29 kolon
/// </summary>
[Table("RANDEVU")]
public class RANDEVU
{
    /// <summary>Kişi için düzenlenen randevu bilgisi için Sağlık Bilgi Yönetim Sistemi tarafında...</summary>
    [Key]
    public string RANDEVU_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Kişinin almış olduğu randevu için Sağlık Bilgi Yönetim Sistemi tarafından tanıml...</summary>
    [ForeignKey("RandevuTuruNavigation")]
    public string RANDEVU_TURU { get; set; }
    /// <summary>Kişinin diş tedavisi için aldığı randevunun dolgu, kanal tedavisi, diş çekimi vb...</summary>
    [Required]
    [ForeignKey("RandevuAltTuruNavigation")]
    public string RANDEVU_ALT_TURU { get; set; }
    /// <summary>Kişinin randevu zamanı bilgisidir.</summary>
    public DateTime? RANDEVU_ZAMANI { get; set; }
    /// <summary>Randevunun kayıt edildiği zaman bilgisidir.</summary>
    public DateTime? RANDEVU_KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanacak hizmetler için Sağlık Bilgi Yönetim Sistemi...</summary>
    [Required]
    [ForeignKey("HastaHizmetNavigation")]
    public string HASTA_HIZMET_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan bölümler için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("BirimNavigation")]
    public string BIRIM_KODU { get; set; }
    /// <summary>Sağlık tesisinde görevli hekim için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [Required]
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }
    /// <summary>Sağlık tesisindeki muayeneye MHRS sisteminden randevu alarak gelen hastalara, mu...</summary>
    [Required]
    public string MHRS_HRN_KODU { get; set; }
    /// <summary>Sağlık tesisinde yapılacak muayeneler için MHRS sisteminden randevu alan hastala...</summary>
    [Required]
    public string MHRS_RANDEVU_NOTU { get; set; }
    /// <summary>Kişinin sağlık tesisinden aldığı randevuya gelip gelmediğine ilişkin bilgiyi ifa...</summary>
    [ForeignKey("RandevuGelmeDurumuNavigation")]
    public string RANDEVU_GELME_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde bulunan cihaz için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [Required]
    [ForeignKey("CihazNavigation")]
    public string CIHAZ_KODU { get; set; }
    /// <summary>Kişiyi niteleyen eşsiz numaradır.</summary>
    [Required]
    public string TC_KIMLIK_NUMARASI { get; set; }
    /// <summary>Kişinin adı bilgisidir.</summary>
    [Required]
    public string AD { get; set; }
    /// <summary>Kişinin soyadı bilgisidir.</summary>
    [Required]
    public string SOYADI { get; set; }
    /// <summary>Kişinin cinsiyetini ifade eder.</summary>
    [Required]
    [ForeignKey("CinsiyetNavigation")]
    public string CINSIYET { get; set; }
    /// <summary>Telefon numarası bilgisini ifade eder.</summary>
    [Required]
    public string TELEFON_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde yapılan bir işlemin iptal edilip edilmediği bilgisidir.</summary>
    public string IPTAL_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde yapılan bir işlemi iptal eden Sağlık Bilgi Yönetim Sistemi kull...</summary>
    [Required]
    [ForeignKey("IptalEdenKullaniciNavigation")]
    public string IPTAL_EDEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin iptal edildiği zaman bilgisidir.</summary>
    public DateTime IPTAL_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde yapılan bir işlemin iptal edilmesi durumunda Sağlık Bilgi Yönet...</summary>
    [Required]
    public string IPTAL_ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? RandevuTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? RandevuAltTuruNavigation { get; set; }
    public virtual HASTA_HIZMET? HastaHizmetNavigation { get; set; }
    public virtual BIRIM? BirimNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual REFERANS_KODLAR? RandevuGelmeDurumuNavigation { get; set; }
    public virtual CIHAZ? CihazNavigation { get; set; }
    public virtual REFERANS_KODLAR? CinsiyetNavigation { get; set; }
    public virtual KULLANICI? IptalEdenKullaniciNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// RECETE tablosu - 20 kolon
/// </summary>
[Table("RECETE")]
public class RECETE
{
    /// <summary>SBYS tarafından üretilen tekil kod bilgisidir.</summary>
    [Key]
    public string RECETE_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Reçetenin yazıldığı zaman bilgisidir.</summary>
    public DateTime? RECETE_ZAMANI { get; set; }
    /// <summary>Reçetenin, içerdiği ilaç cinsine göre belirlenen türünü ifade etmektedir. Örneği...</summary>
    [ForeignKey("ReceteTuruNavigation")]
    public string RECETE_TURU { get; set; }
    /// <summary>Sağlık tesisinde tedavi gören hasta için düzenlenen reçetenin alt türü bilgisidi...</summary>
    [Required]
    [ForeignKey("ReceteAltTuruNavigation")]
    public string RECETE_ALT_TURU { get; set; }
    /// <summary>Sağlık tesisinde görevli hekim için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }
    /// <summary>Sağlık tesisindeki birimlerde hasta bilgilerinin olduğu defter numarası bilgisid...</summary>
    [Required]
    public string DEFTER_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde düzenlenen reçete için MEDULA tarafından Sağlık Bilgi Yönetim S...</summary>
    [Required]
    public string MEDULA_E_RECETE_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde hastaya düzenlenen reçete için Renkli Reçete Sistemi tarafından...</summary>
    [Required]
    public string RENKLI_RECETE_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde bulunan tıbbi cihazların seri numarası bilgisini ifade eder.</summary>
    [Required]
    public string SERI_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde tedavi gören hasta için düzenlenen reçetenin e-İmza imzalanma d...</summary>
    [Required]
    public string RECETE_E_IMZA_DURUMU { get; set; }
    /// <summary>Sağlık tesisine gelen hasta için MEDULA sisteminden Sağlık Bilgi Yönetim Sistemi...</summary>
    [Required]
    public string SGK_TAKIP_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual REFERANS_KODLAR? ReceteTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? ReceteAltTuruNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// RECETE_ILAC tablosu - 18 kolon
/// </summary>
[Table("RECETE_ILAC")]
public class RECETE_ILAC
{
    /// <summary>Sağlık tesisinde tedavi gören hasta için düzenlenen reçetede bulunan ilaç bilgil...</summary>
    [Key]
    public string RECETE_ILAC_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde tedavi gören hasta için düzenlenen reçetede bilgileri için Sağl...</summary>
    [ForeignKey("ReceteNavigation")]
    public string RECETE_KODU { get; set; }
    /// <summary>Bir ilacın, hastaya tek seferde verilebilecek miktarı için ölçü bilgisidir. Örne...</summary>
    [Required]
    [ForeignKey("DozBirimNavigation")]
    public string DOZ_BIRIM { get; set; }
    /// <summary>Çubuk kod ya da çizgi im, verilerin görsel özellikli makinelerin okuyabilmesi iç...</summary>
    public string BARKOD { get; set; }
    /// <summary>İlacın ad bilgisidir.</summary>
    [Required]
    public string ILAC_ADI { get; set; }
    /// <summary>İlacın kutu adeti bilgisidir.</summary>
    public string KUTU_ADETI { get; set; }
    /// <summary>İlacın uygulanma yöntemini ifade eder. Örneğin göz üzerine, ağızdan, burun içi v...</summary>
    [Required]
    [ForeignKey("IlacKullanimSekliNavigation")]
    public string ILAC_KULLANIM_SEKLI { get; set; }
    /// <summary>İlacın kullanım sayısı bilgisidir.</summary>
    [Required]
    public string ILAC_KULLANIM_SAYISI { get; set; }
    /// <summary>İlacın kullanılması gereken miktar bilgisini ifade eder.</summary>
    [Required]
    public string ILAC_KULLANIM_DOZU { get; set; }
    /// <summary>İlacın kullanım periyodunu ifade eder.</summary>
    [Required]
    public string ILAC_KULLANIM_PERIYODU { get; set; }
    /// <summary>İlacın hangi periyot biriminde kullanılacağını ifade eder. Örneğin ay, dakika, g...</summary>
    [Required]
    [ForeignKey("IlacKullanimPeriyoduBirimiNavigation")]
    public string ILAC_KULLANIM_PERIYODU_BIRIMI { get; set; }
    /// <summary>İlaç ile ilgili açıklama bilgisidir.</summary>
    [Required]
    public string ILAC_ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual RECETE? ReceteNavigation { get; set; }
    public virtual REFERANS_KODLAR? DozBirimNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlacKullanimSekliNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlacKullanimPeriyoduBirimiNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// RECETE_ILAC_ACIKLAMA tablosu - 10 kolon
/// </summary>
[Table("RECETE_ILAC_ACIKLAMA")]
public class RECETE_ILAC_ACIKLAMA
{
    /// <summary>Sağlık tesisinde tedavi gören hasta için düzenlenen reçetede bulunan ilaç açıkla...</summary>
    [Key]
    public string RECETE_ILAC_ACIKLAMA_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde tedavi gören hasta için düzenlenen reçetede bulunan ilaç bilgil...</summary>
    [Required]
    [ForeignKey("ReceteIlacNavigation")]
    public string RECETE_ILAC_KODU { get; set; }
    /// <summary>Sağlık tesisinde tedavi gören hasta için düzenlenen reçetede bilgileri için Sağl...</summary>
    [ForeignKey("ReceteNavigation")]
    public string RECETE_KODU { get; set; }
    /// <summary>Sağlık hizmetini alan kişi için yazılmış reçete ve/veya ilaç için yapılmış açıkl...</summary>
    [ForeignKey("IlacAciklamaTuruNavigation")]
    public string ILAC_ACIKLAMA_TURU { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual RECETE_ILAC? ReceteIlacNavigation { get; set; }
    public virtual RECETE? ReceteNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlacAciklamaTuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// REFERANS_KODLAR tablosu - 490 kolon
/// </summary>
[Table("REFERANS_KODLAR")]
public class REFERANS_KODLAR
{
    /// <summary>SBYS tarafinda olusturulan ya da olusturulacak Tekil Referans Kodudur (ID).</summary>
    [Key]
    public string REFERANS_KODU { get; set; }
    /// <summary>SBYS tarafinda sabit olarak kullanilan verilerin alan adidir.</summary>
    public string KOD_TURU { get; set; }
    /// <summary>SBYS tarafinda olusturulan ya da olusturulacak Referans adi bilgisidir.</summary>
    public string REFERANS_ADI { get; set; }
    /// <summary>SKRS kod sisteminden seçilen ve ilgili koda karsilik gelen deger bilgisidir. Örn...</summary>
    [Required]
    public string SKRS_KODU { get; set; }
    /// <summary>Medula sisteminden alinan deger bilgisidir.</summary>
    [Required]
    public string MEDULA_KODU { get; set; }
    /// <summary>MKYS sisteminden alinan deger bilgisidir.</summary>
    [Required]
    public string MKYS_KODU { get; set; }
    /// <summary>Teshisle Iliskili Gruplar (Diagnosis Related Group) kod bilgisidir.</summary>
    [Required]
    public string TIG_KODU { get; set; }
}

/// <summary>
/// RISK_SKORLAMA tablosu - 17 kolon
/// </summary>
[Table("RISK_SKORLAMA")]
public class RISK_SKORLAMA
{
    /// <summary>Sağlık tesisinde kullanılan Risk Skorlama bilgileri için Sağlık Bilgi Yönetim Si...</summary>
    [Key]
    public string RISK_SKORLAMA_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisinde kullanılan APACHE, SNAP, SAPS, İtaki, Harizmi vb. gibi risk sko...</summary>
    [ForeignKey("RiskSkorlamaTuruNavigation")]
    public string RISK_SKORLAMA_TURU { get; set; }
    /// <summary>Sağlık tesisinde yapılan işlemlerin, uygulanmaya başladığı zaman bilgisidir.</summary>
    public DateTime? ISLEM_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde tedavi gören hastanın ölüm oranı riskini belirleyebilmek için k...</summary>
    [Required]
    public string RISK_SKORLAMA_TOPLAM_PUANI { get; set; }
    /// <summary>Sağlık tesisinde kullanılan risk skorlama sistemi ile belirlenen, hastanın bekle...</summary>
    [Required]
    public string BEKLENEN_OLUM_ORANI { get; set; }
    /// <summary>Hastanin bilinç durumunun degerlendirilmesinde kullanilan güvenilir ve objektif ...</summary>
    [Required]
    public string GLASGOW_SKALASI { get; set; }
    /// <summary>Sağlık tesisinde kullanılan risk skorlama sistemi ile belirlenen düzeltilmiş bek...</summary>
    [Required]
    public string DUZELTILMISBEKLENEN_OLUM_ORANI { get; set; }
    /// <summary>Sağlık tesisinde sağlık hizmetini alan kişi için hekim isteminin (order) detay b...</summary>
    [Required]
    [ForeignKey("TibbiOrderDetayNavigation")]
    public string TIBBI_ORDER_DETAY_KODU { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual REFERANS_KODLAR? RiskSkorlamaTuruNavigation { get; set; }
    public virtual TIBBI_ORDER_DETAY? TibbiOrderDetayNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// RISK_SKORLAMA_DETAY tablosu - 11 kolon
/// </summary>
[Table("RISK_SKORLAMA_DETAY")]
public class RISK_SKORLAMA_DETAY
{
    /// <summary>Sağlık tesisinde kullanılan Risk Skorlama detay bilgileri için Sağlık Bilgi Yöne...</summary>
    [Key]
    public string RISK_SKORLAMA_DETAY_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde kullanılan Risk Skorlama bilgileri için Sağlık Bilgi Yönetim Si...</summary>
    [ForeignKey("RiskSkorlamaNavigation")]
    public string RISK_SKORLAMA_KODU { get; set; }
    /// <summary>Hastanin bilinç durumunun degerlendirilmesinde kullanilan güvenilir ve objektif ...</summary>
    [Required]
    public string GLASGOW_SKALASI { get; set; }
    /// <summary>Seçilen risk skorlama türünde bulunan alt tür bilgisidir. Örneğin risk skorlama ...</summary>
    [ForeignKey("RiskSkorlamaAltTuruNavigation")]
    public string RISK_SKORLAMA_ALT_TURU { get; set; }
    /// <summary>Risk skorlama alt türüne göre aldığı değer bilgisidir.</summary>
    [Required]
    public string RISK_SKOR_DEGERI { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual RISK_SKORLAMA? RiskSkorlamaNavigation { get; set; }
    public virtual REFERANS_KODLAR? RiskSkorlamaAltTuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// SILINEN_KAYITLAR tablosu - 6 kolon
/// </summary>
[Table("SILINEN_KAYITLAR")]
public class SILINEN_KAYITLAR
{
    /// <summary>Silinen kayitlar için Saglik Bilgi Yönetim Sistemi tarafindan üretilen tekil kod...</summary>
    [Key]
    public string SILINEN_KAYITLAR_KODU { get; set; }
    /// <summary>Kaydın silinmeden önce bulunduğu VEM Görüntü Adı bilgisidir.</summary>
    public string REFERANS_GORUNTU_ADI { get; set; }
    /// <summary>Kaydın silinme zamanı bilgisidir.</summary>
    public DateTime? SILINME_ZAMANI { get; set; }
    /// <summary>Kaydin silinmeden önce bulundugu VEM Görüntüsü içerisindeki SBYS tarafindan üret...</summary>
    public string SILINEN_KAYDIN_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime? GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// STERILIZASYON_CIKIS tablosu - 15 kolon
/// </summary>
[Table("STERILIZASYON_CIKIS")]
public class STERILIZASYON_CIKIS
{
    /// <summary>Sağlık tesisinde steril edilmiş tıbbi aletlerin, steril deposundan sağlık tesisi...</summary>
    [Key]
    public string STERILIZASYON_CIKIS_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde bulunan stok depoları için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [ForeignKey("DepoNavigation")]
    public string DEPO_KODU { get; set; }
    /// <summary>Tıbbi aletlerin steril edilmeden önce ve sterilizasyon aşamasında oluşturulan se...</summary>
    [ForeignKey("SterilizasyonSetNavigation")]
    public string STERILIZASYON_SET_KODU { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [Required]
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sterilizasyon ünitesinden birime çıkılan setin miktar bilgisidir.</summary>
    public string STERILIZASYON_CIKIS_MIKTARI { get; set; }
    /// <summary>Setin sterilizasyon ünitesinden birime çıkıldığı zaman bilgisidir</summary>
    public DateTime? STERILIZASYON_CIKIS_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde bulunan ilaç, malzeme, set gibi ürünlerin gönderildiği birim iç...</summary>
    [Required]
    [ForeignKey("CikisYapilanBirimNavigation")]
    public string CIKIS_YAPILAN_BIRIM_KODU { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("TeslimEdenPersonelNavigation")]
    public string TESLIM_EDEN_PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("TeslimAlanPersonelNavigation")]
    public string TESLIM_ALAN_PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual DEPO? DepoNavigation { get; set; }
    public virtual STERILIZASYON_SET? SterilizasyonSetNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual BIRIM? CikisYapilanBirimNavigation { get; set; }
    public virtual PERSONEL? TeslimEdenPersonelNavigation { get; set; }
    public virtual PERSONEL? TeslimAlanPersonelNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// STERILIZASYON_GIRIS tablosu - 13 kolon
/// </summary>
[Table("STERILIZASYON_GIRIS")]
public class STERILIZASYON_GIRIS
{
    /// <summary>Sağlık tesisinde steril edilmemiş tıbbi aletlerin, steril deposuna sağlık tesisi...</summary>
    [Key]
    public string STERILIZASYON_GIRIS_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde bulunan stok depoları için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [ForeignKey("DepoNavigation")]
    public string DEPO_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan ilaç, malzeme ve ürünlerin bilgilerine erişim sağlamak ...</summary>
    [ForeignKey("StokKartNavigation")]
    public string STOK_KART_KODU { get; set; }
    /// <summary>Sağlık tesisinde birimlerden sterilizasyon ünitesine gönderilen setin miktar bil...</summary>
    public string STERILIZASYON_GIRIS_MIKTARI { get; set; }
    /// <summary>Sağlık tesisinde bulunan bölümler için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("TeslimEdenBirimNavigation")]
    public string TESLIM_EDEN_BIRIM_KODU { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [Required]
    [ForeignKey("TeslimEdenPersonelNavigation")]
    public string TESLIM_EDEN_PERSONEL_KODU { get; set; }
    /// <summary>Teslim zamanı bilgisidir.</summary>
    public DateTime? TESLIM_ZAMANI { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("TeslimAlanPersonelNavigation")]
    public string TESLIM_ALAN_PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual DEPO? DepoNavigation { get; set; }
    public virtual STOK_KART? StokKartNavigation { get; set; }
    public virtual BIRIM? TeslimEdenBirimNavigation { get; set; }
    public virtual PERSONEL? TeslimEdenPersonelNavigation { get; set; }
    public virtual PERSONEL? TeslimAlanPersonelNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// STERILIZASYON_PAKET tablosu - 14 kolon
/// </summary>
[Table("STERILIZASYON_PAKET")]
public class STERILIZASYON_PAKET
{
    /// <summary>Sağlık tesisinin deposunda bulunan steril aletlerin paket bilgilerine ilişkin ka...</summary>
    [Key]
    public string STERILIZASYON_PAKET_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sterilizasyon ünitesinde kullanılan paketler için tanımlanan ad bilgisidir.</summary>
    public string STERILIZASYON_PAKET_ADI { get; set; }
    /// <summary>Sterilizasyon ünitesinde kullanılan paketin barkod bilgisidir. Barkod bilgisi yo...</summary>
    public string PAKET_KODU { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Tıbbi aletler için sterilizasyon işleminin yapıldığı yöntem bilgisini ifade eder...</summary>
    [Required]
    [ForeignKey("SterilizasyonYontemiNavigation")]
    public string STERILIZASYON_YONTEMI { get; set; }
    /// <summary>Sterilizasyon ünitesinde kullanılan paketler için tanımlanan grup bilgisidir. Ör...</summary>
    [Required]
    [ForeignKey("SterilizasyonPaketGrubuNavigation")]
    public string STERILIZASYON_PAKET_GRUBU { get; set; }
    /// <summary>Steril edilmiş setin raf ömrünün gün olarak değer bilgisidir. Örneğin 30 gün, 60...</summary>
    [Required]
    public string PAKET_RAF_OMRU_BITIS_GUN { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual REFERANS_KODLAR? SterilizasyonYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SterilizasyonPaketGrubuNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// STERILIZASYON_PAKET_DETAY tablosu - 11 kolon
/// </summary>
[Table("STERILIZASYON_PAKET_DETAY")]
public class STERILIZASYON_PAKET_DETAY
{
    /// <summary>Sterilizasyon ünitesinde kullanılan paketlerin detay bilgileri için Sağlık Bilgi...</summary>
    [Key]
    public string STERILIZASYON_PAKET_DETAY_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinin deposunda bulunan steril aletlerin paket bilgilerine ilişkin ka...</summary>
    [ForeignKey("SterilizasyonPaketNavigation")]
    public string STERILIZASYON_PAKET_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan ilaç, malzeme ve ürünlerin bilgilerine erişim sağlamak ...</summary>
    [ForeignKey("StokKartNavigation")]
    public string STOK_KART_KODU { get; set; }
    /// <summary>Sağlık tesisinde sterilizasyon işlemine giren veya çıkan setlerde bulunan malzem...</summary>
    public string STERILIZASYON_MALZEME_MIKTARI { get; set; }
    /// <summary>İlaç, malzeme, ürün vb. için sağlık tesisinde kullanılan ölçü biriminin Sağlık B...</summary>
    [ForeignKey("OlcuNavigation")]
    public string OLCU_KODU { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual STERILIZASYON_PAKET? SterilizasyonPaketNavigation { get; set; }
    public virtual STOK_KART? StokKartNavigation { get; set; }
    public virtual REFERANS_KODLAR? OlcuNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// STERILIZASYON_SET tablosu - 26 kolon
/// </summary>
[Table("STERILIZASYON_SET")]
public class STERILIZASYON_SET
{
    /// <summary>Tıbbi aletlerin steril edilmeden önce ve sterilizasyon aşamasında oluşturulan se...</summary>
    [Key]
    public string STERILIZASYON_SET_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde bulunan stok depoları için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [ForeignKey("DepoNavigation")]
    public string DEPO_KODU { get; set; }
    /// <summary>Sağlık tesisinin deposunda bulunan steril aletlerin paket bilgilerine ilişkin ka...</summary>
    [ForeignKey("SterilizasyonPaketNavigation")]
    public string STERILIZASYON_PAKET_KODU { get; set; }
    /// <summary>Çubuk kod ya da çizgi im, verilerin görsel özellikli makinelerin okuyabilmesi iç...</summary>
    [Required]
    public string BARKOD { get; set; }
    /// <summary>Sağlık tesisinde üretilen barkodları, barkod yazıcıdan bastıran Sağlık Bilgi Yön...</summary>
    [Required]
    [ForeignKey("BarkodBasanKullaniciNavigation")]
    public string BARKOD_BASAN_KULLANICI_KODU { get; set; }
    /// <summary>Barkodun basıldığı zaman bilgisidir.</summary>
    public DateTime BARKOD_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde bulunan cihaz için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [ForeignKey("CihazNavigation")]
    public string CIHAZ_KODU { get; set; }
    /// <summary>Sağlık tesisinde sterilizasyon işlemi uygulanan alet, malzeme veya setler için s...</summary>
    [Required]
    public string STERILIZASYON_CEVRIM_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde tedavide kullanılan setin iade edilip edilmediğine ilişkin bilg...</summary>
    public string SET_IADE_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde tedavide kullanılan setin kullanılmayıp ilgili birime iade edil...</summary>
    public DateTime SET_IADE_ZAMANI { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [Required]
    [ForeignKey("SetIadeEdenPersonelNavigation")]
    public string SET_IADE_EDEN_PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [Required]
    [ForeignKey("SetIadeAlanPersonelNavigation")]
    public string SET_IADE_ALAN_PERSONEL_KODU { get; set; }
    /// <summary>Steril edilmiş setin raf ömrünün bitiş tarihi bilgisidir.</summary>
    public DateTime PAKET_RAF_OMRU_BITIS_TARIHI { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("PaketleyenPersonelNavigation")]
    public string PAKETLEYEN_PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisinde yapılan işlemlerin, uygulanmaya başladığı zaman bilgisidir.</summary>
    public DateTime? ISLEM_ZAMANI { get; set; }
    /// <summary>Sterilizasyon işleminin başladığı zaman bilgisidir.</summary>
    public DateTime? STERILIZASYON_BASLAMA_ZAMANI { get; set; }
    /// <summary>Sterilizasyon işleminin bittiği zaman bilgisidir.</summary>
    public DateTime STERILIZASYON_BITIS_ZAMANI { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [Required]
    [ForeignKey("SterilizasyonPersonelNavigation")]
    public string STERILIZASYON_PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual DEPO? DepoNavigation { get; set; }
    public virtual STERILIZASYON_PAKET? SterilizasyonPaketNavigation { get; set; }
    public virtual KULLANICI? BarkodBasanKullaniciNavigation { get; set; }
    public virtual CIHAZ? CihazNavigation { get; set; }
    public virtual PERSONEL? SetIadeEdenPersonelNavigation { get; set; }
    public virtual PERSONEL? SetIadeAlanPersonelNavigation { get; set; }
    public virtual PERSONEL? PaketleyenPersonelNavigation { get; set; }
    public virtual PERSONEL? SterilizasyonPersonelNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// STERILIZASYON_SET_DETAY tablosu - 9 kolon
/// </summary>
[Table("STERILIZASYON_SET_DETAY")]
public class STERILIZASYON_SET_DETAY
{
    /// <summary>Tıbbi aletlerin steril edilmeden önce ve sterilizasyon aşamasında oluşturulan se...</summary>
    [Key]
    public string STERILIZASYON_SET_DETAY_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Tıbbi aletlerin steril edilmeden önce ve sterilizasyon aşamasında oluşturulan se...</summary>
    [ForeignKey("SterilizasyonSetNavigation")]
    public string STERILIZASYON_SET_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan ilaç, malzeme ve ürünlerin bilgilerine erişim sağlamak ...</summary>
    [ForeignKey("StokKartNavigation")]
    public string STOK_KART_KODU { get; set; }
    /// <summary>Sağlık tesisinde sterilizasyon işlemine giren veya çıkan setlerde bulunan malzem...</summary>
    public string STERILIZASYON_MALZEME_MIKTARI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual STERILIZASYON_SET? SterilizasyonSetNavigation { get; set; }
    public virtual STOK_KART? StokKartNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// STERILIZASYON_STOK_DURUM tablosu - 7 kolon
/// </summary>
[Table("STERILIZASYON_STOK_DURUM")]
public class STERILIZASYON_STOK_DURUM
{
    /// <summary>Sağlık tesisinin deposunda bulunan steril aletlerin son durumuna ilişkin kayıtla...</summary>
    [Key]
    public string STERILIZASYON_STOK_DURUM_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde bulunan stok depoları için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [ForeignKey("DepoNavigation")]
    public string DEPO_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan ilaç, malzeme ve ürünlerin bilgilerine erişim sağlamak ...</summary>
    [ForeignKey("StokKartNavigation")]
    public string STOK_KART_KODU { get; set; }
    /// <summary>Sağlık tesisi depolarındaki toplam stok miktarı bilgisidir.</summary>
    public string STOK_MIKTARI { get; set; }
    /// <summary>Sağlık tesisinin stoklarında bulunan steril edilmemiş tıbbi aletlerin toplam say...</summary>
    public string STERIL_OLMAYAN_STOK_MIKTARI { get; set; }
    /// <summary>Sağlık tesisinin stoklarında bulunan steril edilmiş tıbbi aletlerin toplam sayıs...</summary>
    public string STERIL_STOK_MIKTARI { get; set; }
    #region Navigation Properties
    public virtual DEPO? DepoNavigation { get; set; }
    public virtual STOK_KART? StokKartNavigation { get; set; }
    #endregion
}

/// <summary>
/// STERILIZASYON_YIKAMA tablosu - 13 kolon
/// </summary>
[Table("STERILIZASYON_YIKAMA")]
public class STERILIZASYON_YIKAMA
{
    /// <summary>Sağlık tesisinin sterilizasyon ünitesinde yıkama işlemi yapılan tıbbi aletler iç...</summary>
    [Key]
    public string STERILIZASYON_YIKAMA_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde bulunan stok depoları için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [ForeignKey("DepoNavigation")]
    public string DEPO_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan ilaç, malzeme ve ürünlerin bilgilerine erişim sağlamak ...</summary>
    [ForeignKey("StokKartNavigation")]
    public string STOK_KART_KODU { get; set; }
    /// <summary>Sağlık tesisinde sterilizasyon öncesi yıkanan alet miktarı bilgisidir.</summary>
    public string YIKANAN_ALET_MIKTARI { get; set; }
    /// <summary>Sağlık tesisinde yıkama işleminden geçmiş ürün, malzeme vb. için yıkamanın makin...</summary>
    [ForeignKey("SterilizasyonYikamaTuruNavigation")]
    public string STERILIZASYON_YIKAMA_TURU { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("YikamaYapanPersonelNavigation")]
    public string YIKAMA_YAPAN_PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisinde steril edilecek malzemelerin yıkama işleminin başladığı zaman b...</summary>
    public DateTime? YIKAMA_BASLAMA_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde steril edilecek malzemelerin yıkama işleminin bittiği zaman bil...</summary>
    public DateTime YIKAMA_BITIS_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual DEPO? DepoNavigation { get; set; }
    public virtual STOK_KART? StokKartNavigation { get; set; }
    public virtual REFERANS_KODLAR? SterilizasyonYikamaTuruNavigation { get; set; }
    public virtual PERSONEL? YikamaYapanPersonelNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// STOK_DURUM tablosu - 11 kolon
/// </summary>
[Table("STOK_DURUM")]
public class STOK_DURUM
{
    /// <summary>Sağlık tesisinin deposunda bulunan malzemelerin son durumuna ilişkin kayıtlara e...</summary>
    [Key]
    public string STOK_DURUM_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde bulunan stok depoları için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [ForeignKey("DepoNavigation")]
    public string DEPO_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan ilaç, malzeme ve ürünlerin bilgilerine erişim sağlamak ...</summary>
    [ForeignKey("StokKartNavigation")]
    public string STOK_KART_KODU { get; set; }
    /// <summary>Sağlık tesisinin depolarında bulunan ilaç, malzeme ve ürün vb. için maksimum mik...</summary>
    [Required]
    public string MAKSIMUM_STOK { get; set; }
    /// <summary>İlaç, malzeme, ürün vb. için sağlık tesisinin depolarında bulunması gereken mini...</summary>
    [Required]
    public string MINIMUM_STOK { get; set; }
    /// <summary>Sağlık tesisi depolarında kalan ilaç, malzeme ürün vb. için kritik miktar bilgis...</summary>
    [Required]
    public string KRITIK_STOK { get; set; }
    /// <summary>Sağlık tesisinin depolarına girişi yapılan toplam ilaç, malzeme, ürün vb. miktar...</summary>
    public string TOPLAM_GIRIS_MIKTARI { get; set; }
    /// <summary>Sağlık tesisinin depolarından çıkışı yapılan toplam ilaç, malzeme, ürün vb. mikt...</summary>
    public string TOPLAM_CIKIS_MIKTARI { get; set; }
    /// <summary>Sağlık tesisi depolarındaki toplam stok miktarı bilgisidir.</summary>
    public string STOK_MIKTARI { get; set; }
    /// <summary>İlaç, malzeme, ürün vb. için sağlık tesisinde kullanılan ölçü biriminin Sağlık B...</summary>
    [ForeignKey("OlcuNavigation")]
    public string OLCU_KODU { get; set; }
    #region Navigation Properties
    public virtual DEPO? DepoNavigation { get; set; }
    public virtual STOK_KART? StokKartNavigation { get; set; }
    public virtual REFERANS_KODLAR? OlcuNavigation { get; set; }
    #endregion
}

/// <summary>
/// STOK_EHU_TAKIP tablosu - 19 kolon
/// </summary>
[Table("STOK_EHU_TAKIP")]
public class STOK_EHU_TAKIP
{
    /// <summary>Enfeksiyon Hastalıkları Uzmanının (EHU) onayını gerektiren isteklerin takip bilg...</summary>
    [Key]
    public string STOK_EHU_TAKIP_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisindeki hekimin, hasta için istediği malzeme ve ilaçların sağlık tesi...</summary>
    [ForeignKey("StokIstekNavigation")]
    public string STOK_ISTEK_KODU { get; set; }
    /// <summary>Sağlık tesisinde hasta için depodan yapılan isteklerin detay bilgilerine erişim ...</summary>
    [ForeignKey("StokIstekHareketNavigation")]
    public string STOK_ISTEK_HAREKET_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan ilaç, malzeme ve ürünlerin bilgilerine erişim sağlamak ...</summary>
    [ForeignKey("StokKartNavigation")]
    public string STOK_KART_KODU { get; set; }
    /// <summary>Enfeksiyon Hastalıkları Uzmanı (EHU) tarafından hekim isteminin (order) hastaya ...</summary>
    public DateTime? EHU_ONAY_BASLAMA_ZAMANI { get; set; }
    /// <summary>Enfeksiyon Hastalıkları Uzmanı (EHU) tarafından hekim isteminin (order) hastaya ...</summary>
    public DateTime? EHU_ONAY_BITIS_ZAMANI { get; set; }
    /// <summary>Enfeksiyon Hastalıkları Uzmanı (EHU) tarafından onaylanan ilacın hastaya uygulan...</summary>
    public string EHU_ILAC_MAKSIMUM_MIKTAR { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>EHU onay zamanı bilgisidir.</summary>
    public DateTime EHU_ONAYLAMA_ZAMANI { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("OnaylayanHekimNavigation")]
    public string ONAYLAYAN_HEKIM_KODU { get; set; }
    /// <summary>Enfeksiyon Hastalıkları Uzmanı (EHU) tarafından ilaç isteğinin ret edilme nedeni...</summary>
    [Required]
    [ForeignKey("EhuRetNedeniNavigation")]
    public string EHU_RET_NEDENI { get; set; }
    /// <summary>Enfeksiyon Hastalıkları Uzmanı (EHU) tarafından ilaç isteğinin ret edilme zamanı...</summary>
    public DateTime EHU_RET_ZAMANI { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [Required]
    [ForeignKey("EhuRetPersonelNavigation")]
    public string EHU_RET_PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisinde hastaya istenen ilacın Enfeksiyon Hastalıkları Uzmanı (EHU) tar...</summary>
    [Required]
    public string EHU_RET_ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual STOK_ISTEK? StokIstekNavigation { get; set; }
    public virtual STOK_ISTEK_HAREKET? StokIstekHareketNavigation { get; set; }
    public virtual STOK_KART? StokKartNavigation { get; set; }
    public virtual PERSONEL? OnaylayanHekimNavigation { get; set; }
    public virtual REFERANS_KODLAR? EhuRetNedeniNavigation { get; set; }
    public virtual PERSONEL? EhuRetPersonelNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// STOK_FIS tablosu - 37 kolon
/// </summary>
[Table("STOK_FIS")]
public class STOK_FIS
{
    /// <summary>Sağlık tesisinde kullanılan malzemelerin hareket bilgilerini takip etmek için Sa...</summary>
    [Key]
    public string STOK_FIS_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [Required]
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinin deposuna girişi veya çıkışı yapılan ilaç, malzeme, ürün vb. içi...</summary>
    [Required]
    [ForeignKey("BagliStokFisNavigation")]
    public string BAGLI_STOK_FIS_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan stok depoları için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [ForeignKey("DepoNavigation")]
    public string DEPO_KODU { get; set; }
    /// <summary>Sağlık tesisindeki depolarda yapılan işlem hareketinin depoya giriş veya çıkış i...</summary>
    public string HAREKET_TURU { get; set; }
    /// <summary>Sağlık tesisinin depolarına girişi yapılan ilaç, ürün Taşınır işlem fişi için Ma...</summary>
    [Required]
    public string MKYS_AYNIYAT_MAKBUZ_KODU { get; set; }
    /// <summary>Sağlık tesisindeki depolarda yapılan işlem hareketinin tarih bilgisidir.</summary>
    public DateTime? HAREKET_TARIHI { get; set; }
    /// <summary>Sağlık tesisinin deposundan başka sağlık tesisinin deposuna ilaç, malzeme, ürün ...</summary>
    [Required]
    public string SHCEK_PAYI { get; set; }
    /// <summary>Sağlık tesisinde kesilen fişin hazine kurumu için (%) cinsinden pay bilgisidir. ...</summary>
    [Required]
    public string HAZINE_PAYI { get; set; }
    /// <summary>Sağlık tesisinde yapılan hizmet için kesilen fişin Sağlık Bakanlığı (SB) payı iç...</summary>
    [Required]
    public string SAGLIK_BAKANLIGI_PAYI { get; set; }
    [Required]
    public string BEDELSIZ_FIS { get; set; }
    /// <summary>Sağlık tesisine ücretsiz yapılan ilaç, malzeme, ürün vb. girişlerinin bilgisini ...</summary>
    public string FIS_TUTARI { get; set; }
    /// <summary>Sağlık tesisindeki depolarda yapılan işlem hareketinin türünü ifade eden bilgidi...</summary>
    [ForeignKey("HareketSekliNavigation")]
    public string HAREKET_SEKLI { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [Required]
    [ForeignKey("IslemiYapanPersonelNavigation")]
    public string ISLEMI_YAPAN_PERSONEL_KODU { get; set; }
    /// <summary>Sağlık tesisinde yapılan işlemlerin, uygulanmaya başladığı zaman bilgisidir.</summary>
    public DateTime? ISLEM_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinin mal veya hizmet alımı yaptığı firma için Sağlık Bilgi Yönetim S...</summary>
    [Required]
    [ForeignKey("FirmaNavigation")]
    public string FIRMA_KODU { get; set; }
    /// <summary>Sağlık tesisinde mal veya hizmet alımı kapsamında gerçekleştirilen ihalenin numa...</summary>
    [Required]
    public string IHALE_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde mal veya hizmet alımı kapsamında gerçekleştirilen ihalenin tari...</summary>
    public DateTime IHALE_TARIHI { get; set; }
    /// <summary>Sağlık tesisinde mal veya hizmet alımı için gerçekleştirilen ihalenin kapsamına ...</summary>
    [Required]
    [ForeignKey("IhaleTuruNavigation")]
    public string IHALE_TURU { get; set; }
    /// <summary>Sağlık tesisinde alımı yapılan ilaç, malzeme, ürün vb. kabul aşamasında sağlık t...</summary>
    [Required]
    public string MUAYENE_KABUL_NUMARASI { get; set; }
    /// <summary>Hastanın muayene tarihi bilgisidir.</summary>
    public DateTime MUAYENE_TARIHI { get; set; }
    /// <summary>Kan ürünü, numune, adli rapor, nüfus cüzdanı, malzeme vb. ilgili kişiye teslim e...</summary>
    [Required]
    public string TESLIM_EDEN_KISI { get; set; }
    /// <summary>Kan ürünü, numune, adli rapor, nüfus cüzdanı, malzeme vb. ilgili kişiye teslim e...</summary>
    [Required]
    public string TESLIM_EDEN_KISI_UNVANI { get; set; }
    /// <summary>Bütçe türü bilgisidir. Örneğin döner sermaye bütçesi, genel bütçe vb.</summary>
    [ForeignKey("ButceTuruNavigation")]
    public string BUTCE_TURU { get; set; }
    /// <summary>Sağlık tesisi tarafından kesilen faturanın numara bilgisidir.</summary>
    [Required]
    public string FATURA_NUMARASI { get; set; }
    /// <summary>Sağlık tesisi tarafından kesilen faturanın zaman bilgisidir.</summary>
    public DateTime FATURA_ZAMANI { get; set; }
    /// <summary>Sağlık tesisi tarafından temin edilen ilaç, malzeme veya ürünlere ait fişin irsa...</summary>
    [Required]
    public string IRSALIYE_NUMARASI { get; set; }
    /// <summary>Sağlık tesisi tarafından temin edilen ilaç, malzeme veya ürünlere ait fişin irsa...</summary>
    public DateTime IRSALIYE_TARIHI { get; set; }
    /// <summary>Kurumlar arasındaki devir işlerinde geçerli olan ve Malzeme Kaynak Yönetim Siste...</summary>
    [Required]
    public string MKYS_KURUM_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual STOK_FIS? BagliStokFisNavigation { get; set; }
    public virtual DEPO? DepoNavigation { get; set; }
    public virtual REFERANS_KODLAR? HareketSekliNavigation { get; set; }
    public virtual PERSONEL? IslemiYapanPersonelNavigation { get; set; }
    public virtual FIRMA? FirmaNavigation { get; set; }
    public virtual REFERANS_KODLAR? IhaleTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? ButceTuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// STOK_HAREKET tablosu - 38 kolon
/// </summary>
[Table("STOK_HAREKET")]
public class STOK_HAREKET
{
    /// <summary>Sağlık tesisinde kullanılan malzemelerin ayrıntılı hareket bilgilerini takip etm...</summary>
    [Key]
    public string STOK_HAREKET_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinin deposuna girişi veya çıkışı yapılan ilaç, malzeme, ürün vb. içi...</summary>
    [Required]
    [ForeignKey("BagliStokHareketNavigation")]
    public string BAGLI_STOK_HAREKET_KODU { get; set; }
    /// <summary>Sağlık tesisi depolarına giriş işlemi yapılan ilaç, malzeme, ürün vb. bilgileri ...</summary>
    [Required]
    [ForeignKey("IlkGirisStokHareketNavigation")]
    public string ILK_GIRIS_STOK_HAREKET_KODU { get; set; }
    /// <summary>Sağlık tesisinde hasta için depodan yapılan isteklerin detay bilgilerine erişim ...</summary>
    [Required]
    [ForeignKey("StokIstekHareketNavigation")]
    public string STOK_ISTEK_HAREKET_KODU { get; set; }
    /// <summary>Sağlık tesisinde kullanılan malzemelerin hareket bilgilerini takip etmek için Sa...</summary>
    [ForeignKey("StokFisNavigation")]
    public string STOK_FIS_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan ilaç, malzeme ve ürünlerin bilgilerine erişim sağlamak ...</summary>
    [ForeignKey("StokKartNavigation")]
    public string STOK_KART_KODU { get; set; }
    /// <summary>Çubuk kod ya da çizgi im, verilerin görsel özellikli makinelerin okuyabilmesi iç...</summary>
    [Required]
    public string BARKOD { get; set; }
    /// <summary>Sağlık tesisi depolarında hareket gören malzemelerin üretimi ile bilgileri içere...</summary>
    [Required]
    public string LOT_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde bulunan tıbbi cihazların ürünlere verilen grup numarası olan LO...</summary>
    [Required]
    public string SERI_SIRA_NUMARASI { get; set; }
    /// <summary>Türkiye İlaç ve Tıbbi Cihaz Kurumu tarafından üretici firma numarası bilgisidir.</summary>
    [Required]
    public string FIRMA_TANIMLAYICI_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanan malzemeler için SUT'ta tanımlanmış kod bilgis...</summary>
    [Required]
    public string MALZEME_SUT_KODU { get; set; }
    /// <summary>Sağlık tesisi depolarına giriş veya çıkış işlemi yapılan ilaç, malzeme, ürün vb....</summary>
    public string STOK_HAREKET_MIKTARI { get; set; }
    /// <summary>Sağlık tesisinde bulunan taşınır malzemeler için Sağlık Bilgi Yönetim Sistemi ta...</summary>
    public string TASINIR_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinin deposuna alınan ilaç, malzeme vb. birim fiyat bilgisidir.</summary>
    public string ALIS_BIRIM_FIYATI { get; set; }
    /// <summary>Sağlık tesisine alınan malın satış birim fiyat bilgisini ifade eder.</summary>
    public string SATIS_BIRIM_FIYATI { get; set; }
    /// <summary>İlaç, malzeme, ürün vb. için sağlık tesisinde kullanılan ölçü biriminin Sağlık B...</summary>
    [ForeignKey("OlcuNavigation")]
    public string OLCU_KODU { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [Required]
    [ForeignKey("IslemiYapanPersonelNavigation")]
    public string ISLEMI_YAPAN_PERSONEL_KODU { get; set; }
    /// <summary>KDV oranı bilgisidir.</summary>
    [Required]
    public string KDV_ORANI { get; set; }
    /// <summary>İskonto oranı bilgisidir.</summary>
    [Required]
    public string ISKONTO_ORANI { get; set; }
    /// <summary>İskonto tutar bilgisidir.</summary>
    [Required]
    public string ISKONTO_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde kullanılan ilaç, aşı, tıbbi alet vb. son kullanma tarihi bilgis...</summary>
    public DateTime SON_KULLANMA_TARIHI { get; set; }
    /// <summary>Sağlık tesisinin stoklarına girişi yapılan İlaç ve malzeme için Malzeme Kaynak Y...</summary>
    [Required]
    public string MKYS_STOK_HAREKET_KODU { get; set; }
    /// <summary>Sağlık tesisinde yapılan bir işlemin iptal edilip edilmediği bilgisidir.</summary>
    [Required]
    public string IPTAL_DURUMU { get; set; }
    /// <summary>İlaç ve malzemenin sağlık tesisinin stoklarına girmesinden sonra hareketlerini t...</summary>
    [Required]
    public string MKYS_KARSI_STOK_HAREKET_KODU { get; set; }
    /// <summary>Malzeme Kaynak Yönetim Sistemi (MKYS) tarafından üretilen cihaz künye numarası b...</summary>
    [Required]
    public string MKYS_KUNYE_NUMARASI { get; set; }
    /// <summary>İlgili ürünün ÜTS sistemine kayıt edilmesi durumunda dönen UDI (Unique Device Id...</summary>
    [Required]
    public string UTS_KAYIT_UDI { get; set; }
    /// <summary>Ürünün alındığı bayinin numara bilgisidir.</summary>
    [Required]
    public string BAYILIK_NUMARASI { get; set; }
    /// <summary>Ürünler için Ürün Takip Sisteminde (ÜTS) tanımlanmış Unique Device Identificatio...</summary>
    [Required]
    [ForeignKey("CihazNavigation")]
    public string CIHAZ_KODU { get; set; }
    /// <summary>Sağlık tesisinde kişiye aşı uygulanmadan önce Sağlık Bilgi Yönetim Sistemi taraf...</summary>
    [Required]
    public string ATS_SORGU_NUMARASI { get; set; }
    /// <summary>Vericinin uygun bir biçimde tanımlanmış ve bağışlanan materyalin izlenebilirliği...</summary>
    [Required]
    public string ALLOGREFT_DONOR_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual STOK_HAREKET? BagliStokHareketNavigation { get; set; }
    public virtual STOK_HAREKET? IlkGirisStokHareketNavigation { get; set; }
    public virtual STOK_ISTEK_HAREKET? StokIstekHareketNavigation { get; set; }
    public virtual STOK_FIS? StokFisNavigation { get; set; }
    public virtual STOK_KART? StokKartNavigation { get; set; }
    public virtual REFERANS_KODLAR? OlcuNavigation { get; set; }
    public virtual PERSONEL? IslemiYapanPersonelNavigation { get; set; }
    public virtual CIHAZ? CihazNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// STOK_ISTEK tablosu - 16 kolon
/// </summary>
[Table("STOK_ISTEK")]
public class STOK_ISTEK
{
    /// <summary>Sağlık tesisindeki hekimin, hasta için istediği malzeme ve ilaçların sağlık tesi...</summary>
    [Key]
    public string STOK_ISTEK_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisinde tedavi gören hasta için hekim tarafından yapılan ilaç, malzeme ...</summary>
    public DateTime? ISTEK_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde bulunan stok depoları için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [ForeignKey("IstekDepoNavigation")]
    public string ISTEK_DEPO_KODU { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }
    /// <summary>Sağlık tesisindeki depolardan yapılan isteklerin durumunu gösteren Sağlık Bilgi ...</summary>
    [ForeignKey("StokIstekDurumuNavigation")]
    public string STOK_ISTEK_DURUMU { get; set; }
    /// <summary>İstekle ilgili hekimin açıklama bilgisidir.</summary>
    [Required]
    public string STOK_ISTEK_HEKIM_ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde yapılan ameliyatın bilgilerine erişim sağlamak için Sağlık Bilg...</summary>
    [Required]
    [ForeignKey("AmeliyatNavigation")]
    public string AMELIYAT_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual DEPO? IstekDepoNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual REFERANS_KODLAR? StokIstekDurumuNavigation { get; set; }
    public virtual AMELIYAT? AmeliyatNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// STOK_ISTEK_HAREKET tablosu - 21 kolon
/// </summary>
[Table("STOK_ISTEK_HAREKET")]
public class STOK_ISTEK_HAREKET
{
    /// <summary>Sağlık tesisinde hasta için depodan yapılan isteklerin detay bilgilerine erişim ...</summary>
    [Key]
    public string STOK_ISTEK_HAREKET_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisindeki hekimin, hasta için istediği malzeme ve ilaçların sağlık tesi...</summary>
    [ForeignKey("StokIstekNavigation")]
    public string STOK_ISTEK_KODU { get; set; }
    /// <summary>Sağlık tesisi deposundan istemi yapılan ilaç, malzeme, ürün vb. için Sağlık Bilg...</summary>
    [Required]
    [ForeignKey("IstenenStokKartNavigation")]
    public string ISTENEN_STOK_KART_KODU { get; set; }
    /// <summary>Sağlık tesisinin deposunda bulunan ilacın jeneriği için Sağlık Bilgi Yönetim Sis...</summary>
    [Required]
    [ForeignKey("IstenenIlacJenerikNavigation")]
    public string ISTENEN_ILAC_JENERIK_KODU { get; set; }
    /// <summary>Sağlık tesisinde ilgili stok depo görevlisi tarafından teslim edilen ilaç, malze...</summary>
    [Required]
    [ForeignKey("VerilenStokKartNavigation")]
    public string VERILEN_STOK_KART_KODU { get; set; }
    /// <summary>Sağlık tesisinde tedavi gören hastaya ait ilaç, malzeme isteğinin hekim tarafınd...</summary>
    public string ISTEK_GEREKLILIK_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanacak tedavi için kullanılacak ilacın, hastanın y...</summary>
    public string TEDAVIDE_KULLANILAN_ILAC { get; set; }
    /// <summary>Sağlık tesisinden tedavi gören hasta için hekim tarafından istenen ilaç, malzeme...</summary>
    public string ISTENEN_MIKTAR { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>İlaç, malzeme, ürün vb. isteklerinden sağlık tesisi deposundan karşılanan miktar...</summary>
    [Required]
    public string DEPODAN_VERILEN_MIKTAR { get; set; }
    /// <summary>Sağlık tesisinde ürün, ilaç veya malzemeye ilişkin yapılan isteğin ret edilmesin...</summary>
    [Required]
    [ForeignKey("StokIstekRetNedeniNavigation")]
    public string STOK_ISTEK_RET_NEDENI { get; set; }
    /// <summary>Stoktan yapılan isteğin reddedildiği zaman bilgisidir.</summary>
    public DateTime STOK_ISTEK_RET_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde ürün, ilaç veya malzemeye ilişkin yapılan isteğin reddedildiği ...</summary>
    [Required]
    [ForeignKey("StokIstekRetKullaniciNavigation")]
    public string STOK_ISTEK_RET_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual STOK_ISTEK? StokIstekNavigation { get; set; }
    public virtual STOK_KART? IstenenStokKartNavigation { get; set; }
    public virtual REFERANS_KODLAR? IstenenIlacJenerikNavigation { get; set; }
    public virtual STOK_KART? VerilenStokKartNavigation { get; set; }
    public virtual REFERANS_KODLAR? StokIstekRetNedeniNavigation { get; set; }
    public virtual KULLANICI? StokIstekRetKullaniciNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// STOK_ISTEK_UYGULAMA tablosu - 15 kolon
/// </summary>
[Table("STOK_ISTEK_UYGULAMA")]
public class STOK_ISTEK_UYGULAMA
{
    /// <summary>Sağlık tesisinde hekim tarafından yapılan istemin (order) uygulama bilgilerine e...</summary>
    [Key]
    public string STOK_ISTEK_UYGULAMA_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta için depodan yapılan isteklerin detay bilgilerine erişim ...</summary>
    [ForeignKey("StokIstekHareketNavigation")]
    public string STOK_ISTEK_HAREKET_KODU { get; set; }
    /// <summary>Order'ın hastaya uygulanma zamanına ilişkin planlanan zaman bilgisidir.</summary>
    public DateTime? ORDER_PLANLANAN_ZAMAN { get; set; }
    /// <summary>Order’ın hastaya uygulandığı zaman bilgisidir.</summary>
    public DateTime ORDER_UYGULANAN_ZAMAN { get; set; }
    /// <summary>Hekim tarafından yapılan istemi (order) uygulayan hemşireye ait Sağlık Bilgi Yön...</summary>
    [Required]
    [ForeignKey("UygulayanHemsireNavigation")]
    public string UYGULAYAN_HEMSIRE_KODU { get; set; }
    /// <summary>Sağlık tesisinde tedavi gören hastaya ait istemin iptal edilmesine ilişkin bilgi...</summary>
    [Required]
    [ForeignKey("IstekIptalNedeniNavigation")]
    public string ISTEK_IPTAL_NEDENI { get; set; }
    /// <summary>Sağlık tesisinde yapılması planlanan bir tedavi işlemini iptal eden hemşire bilg...</summary>
    [Required]
    [ForeignKey("IptalEdenHemsireNavigation")]
    public string IPTAL_EDEN_HEMSIRE_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin iptal edildiği zaman bilgisidir.</summary>
    public DateTime IPTAL_ZAMANI { get; set; }
    /// <summary>Hekim tarafından yapılan istemde (order’ın) miktar bilgisi olması durumunda iste...</summary>
    [Required]
    public string UYGULANAN_MIKTAR { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual STOK_ISTEK_HAREKET? StokIstekHareketNavigation { get; set; }
    public virtual PERSONEL? UygulayanHemsireNavigation { get; set; }
    public virtual REFERANS_KODLAR? IstekIptalNedeniNavigation { get; set; }
    public virtual PERSONEL? IptalEdenHemsireNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// STOK_KART tablosu - 28 kolon
/// </summary>
[Table("STOK_KART")]
public class STOK_KART
{
    /// <summary>Sağlık tesisinde bulunan ilaç, malzeme ve ürünlerin bilgilerine erişim sağlamak ...</summary>
    [Key]
    public string STOK_KART_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde kullanılan malzemenin ad bilgisidir.</summary>
    public string MALZEME_ADI { get; set; }
    /// <summary>Malzeme Kaynak Yönetim Sistemi (MKYS) tarafından ilaç ve malzeme için üretilen k...</summary>
    [Required]
    public string MKYS_MALZEME_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan taşınır malzemeler için Sağlık Bilgi Yönetim Sistemi ta...</summary>
    [Required]
    public string TASINIR_KODU { get; set; }
    /// <summary>Sağlık tesisi depolarında bulunan ilaç, malzeme, ürün vb. leri gruplandırmak içi...</summary>
    [ForeignKey("MalzemeTipiNavigation")]
    public string MALZEME_TIPI { get; set; }
    /// <summary>Çubuk kod ya da çizgi im, verilerin görsel özellikli makinelerin okuyabilmesi iç...</summary>
    [Required]
    public string BARKOD { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanan malzemeler için SUT'ta tanımlanmış kod bilgis...</summary>
    [Required]
    public string MALZEME_SUT_KODU { get; set; }
    /// <summary>Reçetenin, içerdiği ilaç cinsine göre belirlenen türünü ifade etmektedir. Örneği...</summary>
    [Required]
    [ForeignKey("ReceteTuruNavigation")]
    public string RECETE_TURU { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanan ilacın ölçülebilir en alt seviyede miligram, ...</summary>
    [Required]
    public string MEDULA_CARPANI { get; set; }
    /// <summary>Enfeksiyon Hastalıkları Uzmanı (EHU) tarafından onaylanan, ilacın hastaya uygula...</summary>
    [Required]
    public string EHU_ILAC_GUN_MIKTARI { get; set; }
    /// <summary>Enfeksiyon Hastalıkları Uzmanı (EHU) tarafından onaylanan, ilacın hastaya uygula...</summary>
    [Required]
    public string EHU_ILAC_MAKSIMUM_ADET { get; set; }
    /// <summary>Sağlık tesisinde istem yapılan bir ilaç için Enfeksiyon Hastalıkları Uzmanı (EHU...</summary>
    public string EHU_ONAY_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual REFERANS_KODLAR? MalzemeTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? ReceteTuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// SYS_PAKET tablosu - 13 kolon
/// </summary>
[Table("SYS_PAKET")]
public class SYS_PAKET
{
    /// <summary>Sağlık Yönetim Sistemi (SYS) Paket Kodu, Sağlık Bilgi Yönetim Sistemi yazılımlar...</summary>
    [Key]
    public string SYS_PAKET_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alindigi SBYS veri tabanindaki tablo adinin bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık Bakanlığı Merkezi Veri Sistemine iletilmesi gereken veri paketleri için B...</summary>
    [Required]
    public string VERI_PAKETI_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinden veri paketinin e-Nabız sistemine iletildiği zaman bilgisidir.</summary>
    public DateTime VERI_PAKETI_GONDERILME_ZAMANI { get; set; }
    /// <summary>Saglik tesisinden veri paketinin e-Nabiz sistemine gönderilip gönderilmedigi bil...</summary>
    public string VERI_PAKETI_GONDERIM_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde kullanılan Sağlık Bilgi Yönetim Sistemi ile diğer bilgi sisteml...</summary>
    [Required]
    public string GONDERILEN_PAKET_BILGISI { get; set; }
    /// <summary>Sağlık tesisinde kullanılan Sağlık Bilgi Yönetim Sistemi ile diğer bilgi sisteml...</summary>
    [Required]
    public string GELEN_CEVAP_BILGISI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// TETKIK tablosu - 17 kolon
/// </summary>
[Table("TETKIK")]
public class TETKIK
{
    /// <summary>Sağlık tesisinde yapılan tetkikler için Sağlık Bilgi Yönetim Sistemi tarafından ...</summary>
    [Key]
    public string TETKIK_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Kişinin hastalığı veya durumu ile ilgili tanı ve tedaviye karar verme amacıyla y...</summary>
    public string TETKIK_ADI { get; set; }
    /// <summary>LOINC, Sağlık tesisinde laboratuvar veya radyolojik tetkik sonuçlarının sınıflan...</summary>
    [Required]
    public string LOINC_KODU { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanan işlemler için Sağlık Bilgi Yönetim Sistemi ta...</summary>
    [ForeignKey("HizmetNavigation")]
    public string HIZMET_KODU { get; set; }
    /// <summary>Hastaya verilen tetkik sonuç raporunda tetkik veya parametrenin bulunduğu sıra b...</summary>
    public string RAPOR_SONUC_SIRASI { get; set; }
    /// <summary>Sağlık tesisinde yapılan bir işlemin iptal edilip edilmediği bilgisidir.</summary>
    public string IPTAL_DURUMU { get; set; }
    /// <summary>Laboratuvarda yapılan tetkikler için özel bir hesaplama yöntemi kullanılıp kulla...</summary>
    public string HESAPLAMALI_TETKIK_BILGISI { get; set; }
    /// <summary>Laboratuvarda yapılan tetkikler için özel bir hesaplama yöntemi kullanılması dur...</summary>
    [Required]
    public string HESAPLAMALI_TETKIK_FORMULU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HIZMET? HizmetNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// TETKIK_CIHAZ_ESLESME tablosu - 12 kolon
/// </summary>
[Table("TETKIK_CIHAZ_ESLESME")]
public class TETKIK_CIHAZ_ESLESME
{
    /// <summary>Sağlık tesisinde yapılan tetkiklerin çalışıldığı tıbbi cihazlar ile eşleştirilme...</summary>
    [Key]
    public string TETKIK_CIHAZ_ESLESME_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde bulunan cihaz için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [ForeignKey("CihazNavigation")]
    public string CIHAZ_KODU { get; set; }
    /// <summary>Sağlık tesisinde yapılan tetkikler için Sağlık Bilgi Yönetim Sistemi tarafından ...</summary>
    [ForeignKey("TetkikNavigation")]
    public string TETKIK_KODU { get; set; }
    /// <summary>Sağlık tesisinde yapılan tetkiklerdeki parametreler için Sağlık Bilgi Yönetim Si...</summary>
    [Required]
    [ForeignKey("TetkikParametreNavigation")]
    public string TETKIK_PARAMETRE_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan cihazların hangi tetkikler için çalışma yaptığına ilişk...</summary>
    [Required]
    public string CIHAZDAN_GELEN_TEST_KODU { get; set; }
    /// <summary>Cihaza gönderilen mesajın içerisindeki testin kodu bilgisidir.</summary>
    [Required]
    public string CIHAZA_GIDEN_TEST_KODU { get; set; }
    /// <summary>Sağlık tesisinde yapılan bir işlemin iptal edilip edilmediği bilgisidir.</summary>
    public string IPTAL_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual CIHAZ? CihazNavigation { get; set; }
    public virtual TETKIK? TetkikNavigation { get; set; }
    public virtual TETKIK_PARAMETRE? TetkikParametreNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// TETKIK_NUMUNE tablosu - 24 kolon
/// </summary>
[Table("TETKIK_NUMUNE")]
public class TETKIK_NUMUNE
{
    /// <summary>Sağlık tesisinde yapılan tetkiklerde kullanılan numuneler için Sağlık Bilgi Yöne...</summary>
    [Key]
    public string TETKIK_NUMUNE_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde kişiden alınan numune için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [Required]
    public string NUMUNE_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde kişiden alınan numune için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [ForeignKey("NumuneTuruNavigation")]
    public string NUMUNE_TURU { get; set; }
    /// <summary>Sağlık tesisinde bulunan bölümler için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("BirimNavigation")]
    public string BIRIM_KODU { get; set; }
    /// <summary>Sağlık tesisinde kişiden alınan numunenin alınma zamanı bilgisidir.</summary>
    public DateTime NUMUNE_ALMA_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde kişiden alınan numunenin laboratuvara kabul edildiği zaman bilg...</summary>
    public DateTime NUMUNE_KABUL_ZAMANI { get; set; }
    /// <summary>Çubuk kod ya da çizgi im, verilerin görsel özellikli makinelerin okuyabilmesi iç...</summary>
    [Required]
    public string BARKOD { get; set; }
    /// <summary>Barkodun basıldığı zaman bilgisidir.</summary>
    public DateTime BARKOD_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde numune alan kullanıcı için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [Required]
    [ForeignKey("NumuneAlanKullaniciNavigation")]
    public string NUMUNE_ALAN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık tesisinde tedavi alan hastaya istenen tetkiklerin kabulünü yapan Sağlık B...</summary>
    [Required]
    [ForeignKey("KabulEdenKullaniciNavigation")]
    public string KABUL_EDEN_KULLANICI_KODU { get; set; }
    /// <summary>Numunenin ret edilmesine ilişkin neden bilgisidir.</summary>
    [Required]
    [ForeignKey("NumuneRetNedeniNavigation")]
    public string NUMUNE_RET_NEDENI { get; set; }
    /// <summary>Ret işlemini gerçekleştiren Sağlık Bilgi Yönetim Sistemi kullanıcısı için Sağlık...</summary>
    [Required]
    [ForeignKey("RetEdenKullaniciNavigation")]
    public string RET_EDEN_KULLANICI_KODU { get; set; }
    /// <summary>Numunenin ret edildiği zaman bilgisidir.</summary>
    public DateTime RET_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde laboratuvarda tetkiki yapılacak numunenin öncelik durumuna iliş...</summary>
    [Required]
    public string NUMUNE_ACILIYET_DURUMU { get; set; }
    /// <summary>Kişinin sağlık tesisi dışında başka bir laboratuvarda yaptırmış olduğu tahliller...</summary>
    [Required]
    public string ENTEGRASYON_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? NumuneTuruNavigation { get; set; }
    public virtual BIRIM? BirimNavigation { get; set; }
    public virtual KULLANICI? NumuneAlanKullaniciNavigation { get; set; }
    public virtual KULLANICI? KabulEdenKullaniciNavigation { get; set; }
    public virtual REFERANS_KODLAR? NumuneRetNedeniNavigation { get; set; }
    public virtual KULLANICI? RetEdenKullaniciNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// TETKIK_PARAMETRE tablosu - 17 kolon
/// </summary>
[Table("TETKIK_PARAMETRE")]
public class TETKIK_PARAMETRE
{
    /// <summary>Sağlık tesisinde yapılan tetkiklerdeki parametreler için Sağlık Bilgi Yönetim Si...</summary>
    [Key]
    public string TETKIK_PARAMETRE_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde yapılan tetkiklerde varsa parametre ad bilgisidir.</summary>
    public string TETKIK_PARAMETRE_ADI { get; set; }
    /// <summary>Sağlık tesisinde yapılan tetkiklerin parametresinin birim bilgisidir. Örneğin mg...</summary>
    [Required]
    public string TETKIK_PARAMETRE_BIRIMI { get; set; }
    /// <summary>Sağlık tesisinde yapılan tetkikler için Sağlık Bilgi Yönetim Sistemi tarafından ...</summary>
    [ForeignKey("TetkikNavigation")]
    public string TETKIK_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan cihaz için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [Required]
    [ForeignKey("CihazNavigation")]
    public string CIHAZ_KODU { get; set; }
    /// <summary>Sağlık tesisinde tedavi gören hastalara laboratuvar tarafından girilen test para...</summary>
    [Required]
    public string MEDULA_PARAMETRE_KODU { get; set; }
    /// <summary>LOINC, Sağlık tesisinde laboratuvar veya radyolojik tetkik sonuçlarının sınıflan...</summary>
    [Required]
    public string LOINC_KODU { get; set; }
    /// <summary>Hastaya verilen tetkik sonuç raporunda tetkik veya parametrenin bulunduğu sıra b...</summary>
    public string RAPOR_SONUC_SIRASI { get; set; }
    /// <summary>Sağlık tesisinde yapılan bir işlemin iptal edilip edilmediği bilgisidir.</summary>
    public string IPTAL_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual TETKIK? TetkikNavigation { get; set; }
    public virtual CIHAZ? CihazNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// TETKIK_REFERANS_ARALIK tablosu - 17 kolon
/// </summary>
[Table("TETKIK_REFERANS_ARALIK")]
public class TETKIK_REFERANS_ARALIK
{
    /// <summary>Sağlık tesisinde yapılan tetkiklerdeki referans aralığı değerleri için Sağlık Bi...</summary>
    [Key]
    public string TETKIK_REFERANS_ARALIK_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde yapılan tetkiklerdeki parametreler için Sağlık Bilgi Yönetim Si...</summary>
    [ForeignKey("TetkikParametreNavigation")]
    public string TETKIK_PARAMETRE_KODU { get; set; }
    /// <summary>Sağlık tesisinde yapılan tetkikler için Sağlık Bilgi Yönetim Sistemi tarafından ...</summary>
    [ForeignKey("TetkikNavigation")]
    public string TETKIK_KODU { get; set; }
    /// <summary>Sağlık tesisinde bulunan cihaz için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [Required]
    [ForeignKey("CihazNavigation")]
    public string CIHAZ_KODU { get; set; }
    /// <summary>Laboratuvar tetkiklerinin karar sınırı değerlerinin hangi cinsiyete göre yapıldı...</summary>
    [ForeignKey("TetkikCinsiyetNavigation")]
    public string TETKIK_CINSIYET { get; set; }
    /// <summary>Tetkik sonuç aralığının geçerli olduğu yaş aralığının gün cinsinden başlangıç bi...</summary>
    public string YAS_ARALIGI_BASLANGIC_GUN { get; set; }
    /// <summary>Tetkik sonuç aralığının geçerli olduğu yaş aralığının gün cinsinden bitiş bilgis...</summary>
    public string YAS_ARALIGI_BITIS_GUN { get; set; }
    /// <summary>Tetkik sonuçları için referans aralığının başlangıç değeri (minimum) bilgisidir.</summary>
    [Required]
    public string REFERANS_BASLANGIC_DEGERI { get; set; }
    /// <summary>Tetkik sonuçlari için referans araliginin bitis degeri bilgisidir.</summary>
    [Required]
    public string REFERANS_BITIS_DEGERI { get; set; }
    /// <summary>Tıbbi laboratuvar testinde, hasta için risk oluşturabilecek durumlarda en kısa z...</summary>
    [Required]
    public string ALT_KRITIK_DEGER { get; set; }
    /// <summary>Tıbbi laboratuvar testinde, hasta için risk oluşturabilecek durumlarda en kısa z...</summary>
    [Required]
    public string UST_KRITIK_DEGER { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual TETKIK_PARAMETRE? TetkikParametreNavigation { get; set; }
    public virtual TETKIK? TetkikNavigation { get; set; }
    public virtual CIHAZ? CihazNavigation { get; set; }
    public virtual REFERANS_KODLAR? TetkikCinsiyetNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// TETKIK_SONUC tablosu - 38 kolon
/// </summary>
[Table("TETKIK_SONUC")]
public class TETKIK_SONUC
{
    /// <summary>Sağlık tesisinde yapılan tetkiklerin sonuçları için Sağlık Bilgi Yönetim Sistemi...</summary>
    [Key]
    public string TETKIK_SONUC_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde yapılan tetkiklerde kullanılan numuneler için Sağlık Bilgi Yöne...</summary>
    [ForeignKey("TetkikNumuneNavigation")]
    public string TETKIK_NUMUNE_KODU { get; set; }
    /// <summary>Sağlık tesisinde yapılan tetkiklerdeki parametreler için Sağlık Bilgi Yönetim Si...</summary>
    [Required]
    [ForeignKey("TetkikParametreNavigation")]
    public string TETKIK_PARAMETRE_KODU { get; set; }
    /// <summary>Sağlık tesisinde yapılan tetkikler için Sağlık Bilgi Yönetim Sistemi tarafından ...</summary>
    [ForeignKey("TetkikNavigation")]
    public string TETKIK_KODU { get; set; }
    /// <summary>Kişinin hastalığı veya durumu ile ilgili tanı ve tedaviye karar verme amacıyla y...</summary>
    public string TETKIK_ADI { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanacak hizmetler için Sağlık Bilgi Yönetim Sistemi...</summary>
    [ForeignKey("HastaHizmetNavigation")]
    public string HASTA_HIZMET_KODU { get; set; }
    /// <summary>Saglik tesisinde çalisilan tetkikler için tetkik sonuç degeri bilgisidir.</summary>
    public string TETKIK_SONUCU { get; set; }
    /// <summary>Sağlık tesisinde yapılan tetkikler için laboratuvar tetkik sonucunun, laboratuva...</summary>
    public DateTime SONUC_ZAMANI { get; set; }
    /// <summary>Hastaya ait tetkik sonucunun gizlenmesine ilişkin bilgiyi ifade eder.</summary>
    public string TETKIK_SONUC_GIZLENME_DURUMU { get; set; }
    /// <summary>Hastaya ait tetkik sonucunun web portallarında gizlenme durumu ifade eden bilgid...</summary>
    public string WEB_SONUC_GIZLENME_DURUMU { get; set; }
    /// <summary>Numunenin ret edilmesine ilişkin neden bilgisidir.</summary>
    [Required]
    [ForeignKey("NumuneRetNedeniNavigation")]
    public string NUMUNE_RET_NEDENI { get; set; }
    /// <summary>Ret işlemini gerçekleştiren Sağlık Bilgi Yönetim Sistemi kullanıcısı için Sağlık...</summary>
    [Required]
    [ForeignKey("RetEdenKullaniciNavigation")]
    public string RET_EDEN_KULLANICI_KODU { get; set; }
    /// <summary>Numunenin ret edildiği zaman bilgisidir.</summary>
    public DateTime RET_ZAMANI { get; set; }
    /// <summary>Kritik değer, tıbbi laboratuvar testinde, hasta için risk oluşturabilecek duruml...</summary>
    [Required]
    public string KRITIK_DEGER_ARALIGI { get; set; }
    /// <summary>Tetkikin tıbbi cihazda çalışılmaya başlandığı zaman bilgisidir.</summary>
    public DateTime CALISMA_BASLAMA_ZAMANI { get; set; }
    /// <summary>Tetkikin tıbbi cihazda çalışılmasının bittiği zaman bilgisidir.</summary>
    public DateTime CALISMA_BITIS_ZAMANI { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [Required]
    [ForeignKey("OnaylayanTeknisyenNavigation")]
    public string ONAYLAYAN_TEKNISYEN_KODU { get; set; }
    /// <summary>Sağlık tesisinde teknisyenin tetkik sonucunu onayladığı zaman bilgisidir.</summary>
    public DateTime TEKNISYEN_ONAY_ZAMANI { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [Required]
    [ForeignKey("OnaylayanHekimNavigation")]
    public string ONAYLAYAN_HEKIM_KODU { get; set; }
    /// <summary>Laboratuvarda yapılan tetkikin sonucunun uzman tarafından onaylandığı zaman bilg...</summary>
    public DateTime TETKIK_UZMAN_ONAY_ZAMANI { get; set; }
    /// <summary>LOINC, Sağlık tesisinde laboratuvar veya radyolojik tetkik sonuçlarının sınıflan...</summary>
    [Required]
    public string LOINC_KODU { get; set; }
    /// <summary>Tetkiki yapılan numunenin tekrar çalışılma (ReRun) durumuna ilişkin bilgiyi ifad...</summary>
    [Required]
    public string TEKRAR_CALISMA_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde çalışılan tetkikin sonuç bilgisinin Sağlık Bilgi Yönetim Sistem...</summary>
    [Required]
    public string MANUEL_TETKIK_SONUC_DURUMU { get; set; }
    /// <summary>Kültür tetkiklerinde bakteri üreme durumuna ilişkin bilgiyi ifade eder.</summary>
    [Required]
    public string UREME_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde bulunan cihaz için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [Required]
    [ForeignKey("CihazNavigation")]
    public string CIHAZ_KODU { get; set; }
    /// <summary>Sağlık tesisinde yapılan tetkikler için cihazlardan Sağlık Bilgi Yönetim Sistemi...</summary>
    [Required]
    public string CIHAZ_TETKIK_SONUCU { get; set; }
    /// <summary>Sağlık tesisinde yapılan tetkiklerin sonuç değerinin birim bilgisidir. Örneğin m...</summary>
    [Required]
    public string TETKIK_SONUCU_BIRIMI { get; set; }
    /// <summary>Sağlık tesisinde yapılan tetkiklerin sonucu için beklenen değer aralığı bilgisid...</summary>
    [Required]
    public string TETKIK_SONUCU_REFERANS_DEGERI { get; set; }
    /// <summary>Sağlık tesisinde yapılan tetkiklerin sonuç durumunu yüksek, alçak, panik durumu,...</summary>
    [Required]
    [ForeignKey("TetkikSonucuDurumuNavigation")]
    public string TETKIK_SONUCU_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde yapılan tetkiklerin sonucu ile ilgili açıklama bilgisidir.</summary>
    [Required]
    public string TETKIK_SONUC_ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [Required]
    [ForeignKey("RaporYazanPersonelNavigation")]
    public string RAPOR_YAZAN_PERSONEL_KODU { get; set; }
    /// <summary>Laboratuvar sonuçlari için sonuç PDF erisim Linki, Görüntülü islem sonuçlari içi...</summary>
    [Required]
    public string SONUC_DIS_ERISIM_BILGISI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual TETKIK_NUMUNE? TetkikNumuneNavigation { get; set; }
    public virtual TETKIK_PARAMETRE? TetkikParametreNavigation { get; set; }
    public virtual TETKIK? TetkikNavigation { get; set; }
    public virtual HASTA_HIZMET? HastaHizmetNavigation { get; set; }
    public virtual REFERANS_KODLAR? NumuneRetNedeniNavigation { get; set; }
    public virtual KULLANICI? RetEdenKullaniciNavigation { get; set; }
    public virtual PERSONEL? OnaylayanTeknisyenNavigation { get; set; }
    public virtual PERSONEL? OnaylayanHekimNavigation { get; set; }
    public virtual CIHAZ? CihazNavigation { get; set; }
    public virtual REFERANS_KODLAR? TetkikSonucuDurumuNavigation { get; set; }
    public virtual PERSONEL? RaporYazanPersonelNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// TIBBI_ORDER tablosu - 13 kolon
/// </summary>
[Table("TIBBI_ORDER")]
public class TIBBI_ORDER
{
    /// <summary>Sağlık tesisinde sağlık hizmetini alan kişi için hekim istemi (order) için Sağlı...</summary>
    [Key]
    public string TIBBI_ORDER_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisinde sağlık hizmetini alan kişi için hekim isteminin (order) tür bil...</summary>
    [ForeignKey("TibbiOrderTuruNavigation")]
    public string TIBBI_ORDER_TURU { get; set; }
    /// <summary>Hekimin order’ı verme zamanı bilgisidir.</summary>
    public DateTime? ORDER_ZAMANI { get; set; }
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? TibbiOrderTuruNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// TIBBI_ORDER_DETAY tablosu - 16 kolon
/// </summary>
[Table("TIBBI_ORDER_DETAY")]
public class TIBBI_ORDER_DETAY
{
    /// <summary>Sağlık tesisinde sağlık hizmetini alan kişi için hekim isteminin (order) detay b...</summary>
    [Key]
    public string TIBBI_ORDER_DETAY_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde sağlık hizmetini alan kişi için hekim istemi (order) için Sağlı...</summary>
    [ForeignKey("TibbiOrderNavigation")]
    public string TIBBI_ORDER_KODU { get; set; }
    /// <summary>Order’ın hastaya hangi saatte uygulanacağını belirten zaman bilgisidir.</summary>
    public DateTime? PLANLANAN_UYGULANMA_ZAMANI { get; set; }
    /// <summary>Hekim tarafından yapılan istemi (order) uygulayan hemşireye ait Sağlık Bilgi Yön...</summary>
    [Required]
    [ForeignKey("UygulayanHemsireNavigation")]
    public string UYGULAYAN_HEMSIRE_KODU { get; set; }
    /// <summary>Hekim tarafından yapılan istemin (order’ın) uygulandığı zaman bilgisidir.</summary>
    public DateTime UYGULAMA_ZAMANI { get; set; }
    /// <summary>Hekim tarafından yapılan istem (order) için gereken işlemin hastaya uygulanma du...</summary>
    public string UYGULANMA_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde sağlık hizmetini alan kişi için hekim istemi (order) iptal edil...</summary>
    [Required]
    [ForeignKey("TibbiOrderIptalNedeniNavigation")]
    public string TIBBI_ORDER_IPTAL_NEDENI { get; set; }
    /// <summary>Sağlık tesisinde yapılması planlanan bir tedavi işlemini iptal eden hemşire bilg...</summary>
    [Required]
    [ForeignKey("IptalEdenHemsireNavigation")]
    public string IPTAL_EDEN_HEMSIRE_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin iptal edildiği zaman bilgisidir.</summary>
    public DateTime IPTAL_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual TIBBI_ORDER? TibbiOrderNavigation { get; set; }
    public virtual PERSONEL? UygulayanHemsireNavigation { get; set; }
    public virtual REFERANS_KODLAR? TibbiOrderIptalNedeniNavigation { get; set; }
    public virtual PERSONEL? IptalEdenHemsireNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// VEZNE tablosu - 24 kolon
/// </summary>
[Table("VEZNE")]
public class VEZNE
{
    /// <summary>Sağlık tesisi veznesinde yapılan işlemlerin bilgisi için Sağlık Bilgi Yönetim Si...</summary>
    [Key]
    public string VEZNE_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [Required]
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }
    /// <summary>Sağlık tesisindeki vezne birimi tarafından kesilen tahsilat veya ödemelerin yıl ...</summary>
    public string MAKBUZ_NUMARASI { get; set; }
    /// <summary>Sağlık tesisi veznesinde yapılan tahsilat veya ödemelerle ilgili Sağlık Bilgi Yö...</summary>
    [Required]
    public string VEZNE_OZEL_NUMARASI { get; set; }
    /// <summary>Sağlık tesisi veznesinin yaptığı işlemin tahsilat veya ödeme işlemine ilişkin bi...</summary>
    public string VEZNE_GIRIS_CIKIS_BILGISI { get; set; }
    /// <summary>Sağlık tesisindeki vezne birimi tarafından kesilen tahsilat veya ödemelerin yapı...</summary>
    public DateTime? MAKBUZ_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde bulunan vezne birimleri için Sağlık Bilgi Yönetim Sistemi taraf...</summary>
    [ForeignKey("VezneBirimNavigation")]
    public string VEZNE_BIRIM_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen makbuzun seri numarası bilgisini ifade eder.</summary>
    [Required]
    public string MAKBUZ_SERI_NUMARASI { get; set; }
    /// <summary>Sağlık tesisinde yapılan bir işlemin iptal edilip edilmediği bilgisidir.</summary>
    public string IPTAL_DURUMU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin iptal edildiği zaman bilgisidir.</summary>
    public DateTime IPTAL_ZAMANI { get; set; }
    /// <summary>Sağlık tesisinde yapılan bir işlemin iptal edilmesi durumunda Sağlık Bilgi Yönet...</summary>
    [Required]
    public string IPTAL_ACIKLAMA { get; set; }
    /// <summary>Sağlık tesisindeki vezne tarafından yapılan tahsilat ve ödemelerin türünü ifade ...</summary>
    [Required]
    [ForeignKey("TahsilTuruNavigation")]
    public string TAHSIL_TURU { get; set; }
    /// <summary>Sağlık tesisinin veznesinde işlem yapılan makbuz tutarı bilgisidir.</summary>
    public string MAKBUZ_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }
    /// <summary>Makbuz sahibinin adres bilgisidir.</summary>
    [Required]
    public string MAKBUZ_SAHIBI_ADRESI { get; set; }
    /// <summary>Sağlık tesisinin mal veya hizmet alımı yaptığı firma için ad bilgisidir.</summary>
    [Required]
    public string FIRMA_ADI { get; set; }
    /// <summary>Sağlık tesisinin mal veya hizmet alımı yaptığı firma için Sağlık Bilgi Yönetim S...</summary>
    [Required]
    [ForeignKey("FirmaNavigation")]
    public string FIRMA_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual BIRIM? VezneBirimNavigation { get; set; }
    public virtual REFERANS_KODLAR? TahsilTuruNavigation { get; set; }
    public virtual FIRMA? FirmaNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// VEZNE_DETAY tablosu - 11 kolon
/// </summary>
[Table("VEZNE_DETAY")]
public class VEZNE_DETAY
{
    /// <summary>Veznede yapılan işlemlerin ayrıntılı bilgisine erişim sağlamak için Sağlık Bilgi...</summary>
    [Key]
    public string VEZNE_DETAY_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisi veznesinde yapılan işlemlerin bilgisi için Sağlık Bilgi Yönetim Si...</summary>
    [ForeignKey("VezneNavigation")]
    public string VEZNE_KODU { get; set; }
    /// <summary>Sağlık tesisinde hastaya uygulanacak hizmetler için Sağlık Bilgi Yönetim Sistemi...</summary>
    [Required]
    [ForeignKey("HastaHizmetNavigation")]
    public string HASTA_HIZMET_KODU { get; set; }
    /// <summary>Sağlık tesisinde hasta için kullanılan ilaç, malzeme, ürün vb. bilgiler için Sağ...</summary>
    [Required]
    [ForeignKey("HastaMalzemeNavigation")]
    public string HASTA_MALZEME_KODU { get; set; }
    /// <summary>Tek Düzen Muhasebe Sisteminde tanımlanan, yerine göre “Alıcılar Hesabı” veya "Gi...</summary>
    public string BUTCE_KODU { get; set; }
    /// <summary>Sağlık tesisinin veznesinde işlem yapılan makbuzdaki her bir satırda (kalem) bul...</summary>
    public string MAKBUZ_KALEM_TUTARI { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual VEZNE? VezneNavigation { get; set; }
    public virtual HASTA_HIZMET? HastaHizmetNavigation { get; set; }
    public virtual HASTA_MALZEME? HastaMalzemeNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

/// <summary>
/// YATAK tablosu - 13 kolon
/// </summary>
[Table("YATAK")]
public class YATAK
{
    /// <summary>Sağlık Bilgi Yönetim Sistemi tarafından sağlık tesisindeki yataklar için üretile...</summary>
    [Key]
    public string YATAK_KODU { get; set; }
    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }
    /// <summary>Sağlık tesisinde bulunan yatağın ad bilgisidir.</summary>
    public string YATAK_ADI { get; set; }
    /// <summary>Sağlık tesisinde bulunan oda için Sağlık Bilgi Yönetim Sistemi tarafından üretil...</summary>
    [ForeignKey("OdaNavigation")]
    public string ODA_KODU { get; set; }
    /// <summary>Sağlık tesisinde hasta yatağı olarak tanımlanan yatakların tür bilgisidir. Örneğ...</summary>
    [ForeignKey("YatakTuruNavigation")]
    public string YATAK_TURU { get; set; }
    /// <summary>Sağlık tesisinde bulunan yoğun bakım yatak seviyesi bilgisidir. Örneğin 1.seviye...</summary>
    [Required]
    [ForeignKey("YogunBakimYatakSeviyesiNavigation")]
    public string YOGUN_BAKIM_YATAK_SEVIYESI { get; set; }
    /// <summary>Sağlık tesisindeki tıbbi cihazlar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("VentilatorCihazNavigation")]
    public string VENTILATOR_CIHAZ_KODU { get; set; }
    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }
    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }
    #region Navigation Properties
    public virtual ODA? OdaNavigation { get; set; }
    public virtual REFERANS_KODLAR? YatakTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? YogunBakimYatakSeviyesiNavigation { get; set; }
    public virtual CIHAZ? VentilatorCihazNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion
}

