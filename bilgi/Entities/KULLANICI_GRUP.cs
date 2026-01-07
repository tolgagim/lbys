using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

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