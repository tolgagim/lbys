using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_DEPO tablosu - 22 kolon
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