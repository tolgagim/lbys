using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

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