using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// VEZNE_DETAY tablosu - 11 kolon
/// </summary>
[Table("VEZNE_DETAY")]
public class VEZNE_DETAY : VemEntity
{
    /// <summary>Veznede yapÄ±lan iÅŸlemlerin ayrÄ±ntÄ±lÄ± bilgisine eriÅŸim saÄŸlamak iÃ§in SaÄŸlÄ±k Bilgi...</summary>
    [Key]
    public string VEZNE_DETAY_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisi veznesinde yapÄ±lan iÅŸlemlerin bilgisi iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Si...</summary>
    [ForeignKey("VezneNavigation")]
    public string VEZNE_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hastaya uygulanacak hizmetler iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi...</summary>
    [Required]
    [ForeignKey("HastaHizmetNavigation")]
    public string HASTA_HIZMET_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta iÃ§in kullanÄ±lan ilaÃ§, malzeme, Ã¼rÃ¼n vb. bilgiler iÃ§in SaÄŸ...</summary>
    [Required]
    [ForeignKey("HastaMalzemeNavigation")]
    public string HASTA_MALZEME_KODU { get; set; }

    /// <summary>Tek DÃ¼zen Muhasebe Sisteminde tanÄ±mlanan, yerine gÃ¶re â€œAlÄ±cÄ±lar HesabÄ±â€ veya "Gi...</summary>
    public string BUTCE_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinin veznesinde iÅŸlem yapÄ±lan makbuzdaki her bir satÄ±rda (kalem) bul...</summary>
    public string MAKBUZ_KALEM_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual VEZNE? VezneNavigation { get; set; }
    public virtual HASTA_HIZMET? HastaHizmetNavigation { get; set; }
    public virtual HASTA_MALZEME? HastaMalzemeNavigation { get; set; }
    #endregion

}
