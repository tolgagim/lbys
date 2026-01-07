using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

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