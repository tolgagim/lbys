using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

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