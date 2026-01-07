using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// STERILIZASYON_STOK_DURUM tablosu - 7 kolon
/// </summary>
[Table("STERILIZASYON_STOK_DURUM")]
public class STERILIZASYON_STOK_DURUM
{
    /// <summary>Sağlık tesisinin deposunda bulunan steril aletlerin son durumuna ilişkin kayıtla...</summary>
    [Key]
    public string STERILIZASYON_STOK_DURUM_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde bulunan stok depoları için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [ForeignKey("DepoNavigation")]
    public string DEPO_KODU { get; set; }

    /// <summary>Sağlık tesisinde bulunan ilaç, malzeme ve ürünlerin bilgilerine erişim sağlamak ...</summary>
    [ForeignKey("StokKartNavigation")]
    public string STOK_KART_KODU { get; set; }

    /// <summary>Sağlık tesisi depolarındaki toplam stok miktarı bilgisidir.</summary>
    public string STOK_MIKTARI { get; set; }

    /// <summary>Sağlık tesisinin stoklarında bulunan steril edilmemiş tıbbi aletlerin toplam say...</summary>
    public string STERIL_OLMAYAN_STOK_MIKTARI { get; set; }

    /// <summary>Sağlık tesisinin stoklarında bulunan steril edilmiş tıbbi aletlerin toplam sayıs...</summary>
    public string STERIL_STOK_MIKTARI { get; set; }

    #region Navigation Properties
    public virtual DEPO? DepoNavigation { get; set; }
    public virtual STOK_KART? StokKartNavigation { get; set; }
    #endregion

}