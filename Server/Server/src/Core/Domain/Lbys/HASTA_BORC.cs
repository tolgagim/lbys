using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// HASTA_BORC tablosu - 7 kolon
/// </summary>
[Table("HASTA_BORC")]
public class HASTA_BORC : VemEntity
{
    /// <summary>HastalarÄ±n borÃ§ bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼retilen ...</summary>
    [Key]
    public string HASTA_BORC_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>HastanÄ±n Ã¶demiÅŸ olduÄŸu borÃ§ bilgisidir.</summary>
    public string ODENEN_BORC { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde saÄŸlÄ±k hizmetini alan kiÅŸinin kendisine uygulanan tanÄ± ve tedav...</summary>
    public string TOPLAM_BORC { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavisi yapÄ±lan hastanÄ±n kalan borÃ§ bilgisidir.</summary>
    public string KALAN_BORC { get; set; }

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    #endregion

}
