using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// STERILIZASYON_GIRIS tablosu - 13 kolon
/// </summary>
[Table("STERILIZASYON_GIRIS")]
public class STERILIZASYON_GIRIS : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde steril edilmemiÅŸ tÄ±bbi aletlerin, steril deposuna saÄŸlÄ±k tesisi...</summary>
    [Key]
    public string STERILIZASYON_GIRIS_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde bulunan stok depolarÄ± iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±n...</summary>
    [ForeignKey("DepoNavigation")]
    public string DEPO_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan ilaÃ§, malzeme ve Ã¼rÃ¼nlerin bilgilerine eriÅŸim saÄŸlamak ...</summary>
    [ForeignKey("StokKartNavigation")]
    public string STOK_KART_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde birimlerden sterilizasyon Ã¼nitesine gÃ¶nderilen setin miktar bil...</summary>
    public string STERILIZASYON_GIRIS_MIKTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan bÃ¶lÃ¼mler iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [Required]
    [ForeignKey("TeslimEdenBirimNavigation")]
    public string TESLIM_EDEN_BIRIM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [Required]
    [ForeignKey("TeslimEdenPersonelNavigation")]
    public string TESLIM_EDEN_PERSONEL_KODU { get; set; }

    /// <summary>Teslim zamanÄ± bilgisidir.</summary>
    public DateTime? TESLIM_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [ForeignKey("TeslimAlanPersonelNavigation")]
    public string TESLIM_ALAN_PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual DEPO? DepoNavigation { get; set; }
    public virtual STOK_KART? StokKartNavigation { get; set; }
    public virtual BIRIM? TeslimEdenBirimNavigation { get; set; }
    public virtual PERSONEL? TeslimEdenPersonelNavigation { get; set; }
    public virtual PERSONEL? TeslimAlanPersonelNavigation { get; set; }
    #endregion

}
