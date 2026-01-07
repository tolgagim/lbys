using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

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