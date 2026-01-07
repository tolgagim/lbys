using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// STERILIZASYON_PAKET_DETAY tablosu - 11 kolon
/// </summary>
[Table("STERILIZASYON_PAKET_DETAY")]
public class STERILIZASYON_PAKET_DETAY
{
    /// <summary>Sterilizasyon ünitesinde kullanılan paketlerin detay bilgileri için Sağlık Bilgi...</summary>
    [Key]
    public string STERILIZASYON_PAKET_DETAY_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinin deposunda bulunan steril aletlerin paket bilgilerine ilişkin ka...</summary>
    [ForeignKey("SterilizasyonPaketNavigation")]
    public string STERILIZASYON_PAKET_KODU { get; set; }

    /// <summary>Sağlık tesisinde bulunan ilaç, malzeme ve ürünlerin bilgilerine erişim sağlamak ...</summary>
    [ForeignKey("StokKartNavigation")]
    public string STOK_KART_KODU { get; set; }

    /// <summary>Sağlık tesisinde sterilizasyon işlemine giren veya çıkan setlerde bulunan malzem...</summary>
    public string STERILIZASYON_MALZEME_MIKTARI { get; set; }

    /// <summary>İlaç, malzeme, ürün vb. için sağlık tesisinde kullanılan ölçü biriminin Sağlık B...</summary>
    [ForeignKey("OlcuNavigation")]
    public string OLCU_KODU { get; set; }

    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

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
    public virtual STERILIZASYON_PAKET? SterilizasyonPaketNavigation { get; set; }
    public virtual STOK_KART? StokKartNavigation { get; set; }
    public virtual REFERANS_KODLAR? OlcuNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}