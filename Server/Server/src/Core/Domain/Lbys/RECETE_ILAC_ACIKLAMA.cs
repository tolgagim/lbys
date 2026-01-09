using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// RECETE_ILAC_ACIKLAMA tablosu - 10 kolon
/// </summary>
[Table("RECETE_ILAC_ACIKLAMA")]
public class RECETE_ILAC_ACIKLAMA : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde tedavi gÃ¶ren hasta iÃ§in dÃ¼zenlenen reÃ§etede bulunan ilaÃ§ aÃ§Ä±kla...</summary>
    [Key]
    public string RECETE_ILAC_ACIKLAMA_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde tedavi gÃ¶ren hasta iÃ§in dÃ¼zenlenen reÃ§etede bulunan ilaÃ§ bilgil...</summary>
    [Required]
    [ForeignKey("ReceteIlacNavigation")]
    public string RECETE_ILAC_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavi gÃ¶ren hasta iÃ§in dÃ¼zenlenen reÃ§etede bilgileri iÃ§in SaÄŸl...</summary>
    [ForeignKey("ReceteNavigation")]
    public string RECETE_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k hizmetini alan kiÅŸi iÃ§in yazÄ±lmÄ±ÅŸ reÃ§ete ve/veya ilaÃ§ iÃ§in yapÄ±lmÄ±ÅŸ aÃ§Ä±kl...</summary>
    [ForeignKey("IlacAciklamaTuruNavigation")]
    public string ILAC_ACIKLAMA_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual RECETE_ILAC? ReceteIlacNavigation { get; set; }
    public virtual RECETE? ReceteNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlacAciklamaTuruNavigation { get; set; }
    #endregion

}
