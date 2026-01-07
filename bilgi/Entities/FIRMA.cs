using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

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