using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// DIS_TAAHHUT_DETAY tablosu - 10 kolon
/// </summary>
[Table("DIS_TAAHHUT_DETAY")]
public class DIS_TAAHHUT_DETAY : VemEntity
{
    /// <summary>DiÅŸ tedavisi yapÄ±lan hastalar iÃ§in MEDULA sisteminden alÄ±nan taahhÃ¼te iliÅŸkin de...</summary>
    [Key]
    public string DIS_TAAHHUT_DETAY_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>DiÅŸ tedavisi yapÄ±lan hastalar iÃ§in MEDULA sisteminden alÄ±nan taahhÃ¼t bilgilerini...</summary>
    [ForeignKey("DisTaahhutNavigation")]
    public string DIS_TAAHHUT_KODU { get; set; }

    /// <summary>AÄŸÄ±zdaki diÅŸler iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan verilmiÅŸ kod bilgis...</summary>
    [Required]
    [ForeignKey("DisNavigation")]
    public string DIS_KODU { get; set; }

    /// <summary>Sosyal GÃ¼venlik Kurumu tarafÄ±ndan yayÄ±mlanan, hastaya uygulanan iÅŸlem veya hizme...</summary>
    public string SUT_KODU { get; set; }

    /// <summary>KiÅŸinin diÅŸ tedavisi iÃ§in iÅŸlem yapÄ±lan Ã§ene bÃ¶lgesi iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim S...</summary>
    [Required]
    [ForeignKey("CeneNavigation")]
    public string CENE_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual DIS_TAAHHUT? DisTaahhutNavigation { get; set; }
    public virtual REFERANS_KODLAR? DisNavigation { get; set; }
    public virtual REFERANS_KODLAR? CeneNavigation { get; set; }
    #endregion

}
