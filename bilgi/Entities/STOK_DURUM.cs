using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// STOK_DURUM tablosu - 11 kolon
/// </summary>
[Table("STOK_DURUM")]
public class STOK_DURUM
{
    /// <summary>Sağlık tesisinin deposunda bulunan malzemelerin son durumuna ilişkin kayıtlara e...</summary>
    [Key]
    public string STOK_DURUM_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde bulunan stok depoları için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [ForeignKey("DepoNavigation")]
    public string DEPO_KODU { get; set; }

    /// <summary>Sağlık tesisinde bulunan ilaç, malzeme ve ürünlerin bilgilerine erişim sağlamak ...</summary>
    [ForeignKey("StokKartNavigation")]
    public string STOK_KART_KODU { get; set; }

    /// <summary>Sağlık tesisinin depolarında bulunan ilaç, malzeme ve ürün vb. için maksimum mik...</summary>
    [Required]
    public string MAKSIMUM_STOK { get; set; }

    /// <summary>İlaç, malzeme, ürün vb. için sağlık tesisinin depolarında bulunması gereken mini...</summary>
    [Required]
    public string MINIMUM_STOK { get; set; }

    /// <summary>Sağlık tesisi depolarında kalan ilaç, malzeme ürün vb. için kritik miktar bilgis...</summary>
    [Required]
    public string KRITIK_STOK { get; set; }

    /// <summary>Sağlık tesisinin depolarına girişi yapılan toplam ilaç, malzeme, ürün vb. miktar...</summary>
    public string TOPLAM_GIRIS_MIKTARI { get; set; }

    /// <summary>Sağlık tesisinin depolarından çıkışı yapılan toplam ilaç, malzeme, ürün vb. mikt...</summary>
    public string TOPLAM_CIKIS_MIKTARI { get; set; }

    /// <summary>Sağlık tesisi depolarındaki toplam stok miktarı bilgisidir.</summary>
    public string STOK_MIKTARI { get; set; }

    /// <summary>İlaç, malzeme, ürün vb. için sağlık tesisinde kullanılan ölçü biriminin Sağlık B...</summary>
    [ForeignKey("OlcuNavigation")]
    public string OLCU_KODU { get; set; }

    #region Navigation Properties
    public virtual DEPO? DepoNavigation { get; set; }
    public virtual STOK_KART? StokKartNavigation { get; set; }
    public virtual REFERANS_KODLAR? OlcuNavigation { get; set; }
    #endregion

}