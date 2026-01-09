using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// STERILIZASYON_STOK_DURUM tablosu - 7 kolon
/// </summary>
[Table("STERILIZASYON_STOK_DURUM")]
public class STERILIZASYON_STOK_DURUM : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinin deposunda bulunan steril aletlerin son durumuna iliÅŸkin kayÄ±tla...</summary>
    [Key]
    public string STERILIZASYON_STOK_DURUM_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde bulunan stok depolarÄ± iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±n...</summary>
    [ForeignKey("DepoNavigation")]
    public string DEPO_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan ilaÃ§, malzeme ve Ã¼rÃ¼nlerin bilgilerine eriÅŸim saÄŸlamak ...</summary>
    [ForeignKey("StokKartNavigation")]
    public string STOK_KART_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisi depolarÄ±ndaki toplam stok miktarÄ± bilgisidir.</summary>
    public string STOK_MIKTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinin stoklarÄ±nda bulunan steril edilmemiÅŸ tÄ±bbi aletlerin toplam say...</summary>
    public string STERIL_OLMAYAN_STOK_MIKTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinin stoklarÄ±nda bulunan steril edilmiÅŸ tÄ±bbi aletlerin toplam sayÄ±s...</summary>
    public string STERIL_STOK_MIKTARI { get; set; }

    #region Navigation Properties
    public virtual DEPO? DepoNavigation { get; set; }
    public virtual STOK_KART? StokKartNavigation { get; set; }
    #endregion

}
