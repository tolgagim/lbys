using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// TETKIK_CIHAZ_ESLESME tablosu - 12 kolon
/// </summary>
[Table("TETKIK_CIHAZ_ESLESME")]
public class TETKIK_CIHAZ_ESLESME : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan tetkiklerin Ã§alÄ±ÅŸÄ±ldÄ±ÄŸÄ± tÄ±bbi cihazlar ile eÅŸleÅŸtirilme...</summary>
    [Key]
    public string TETKIK_CIHAZ_ESLESME_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan cihaz iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼ret...</summary>
    [ForeignKey("CihazNavigation")]
    public string CIHAZ_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan tetkikler iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan ...</summary>
    [ForeignKey("TetkikNavigation")]
    public string TETKIK_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan tetkiklerdeki parametreler iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Si...</summary>
    [Required]
    [ForeignKey("TetkikParametreNavigation")]
    public string TETKIK_PARAMETRE_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan cihazlarÄ±n hangi tetkikler iÃ§in Ã§alÄ±ÅŸma yaptÄ±ÄŸÄ±na iliÅŸk...</summary>
    [Required]
    public string CIHAZDAN_GELEN_TEST_KODU { get; set; }

    /// <summary>Cihaza gÃ¶nderilen mesajÄ±n iÃ§erisindeki testin kodu bilgisidir.</summary>
    [Required]
    public string CIHAZA_GIDEN_TEST_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan bir iÅŸlemin iptal edilip edilmediÄŸi bilgisidir.</summary>
    public string IPTAL_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual CIHAZ? CihazNavigation { get; set; }
    public virtual TETKIK? TetkikNavigation { get; set; }
    public virtual TETKIK_PARAMETRE? TetkikParametreNavigation { get; set; }
    #endregion

}
