using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_KAN_URUN_IMHA tablosu - 12 kolon
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