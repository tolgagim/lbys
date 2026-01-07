using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

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