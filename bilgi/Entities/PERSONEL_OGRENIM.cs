using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

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