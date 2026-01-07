using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// RECETE_ILAC tablosu - 18 kolon
/// </summary>
[Table("RECETE_ILAC")]
public class RECETE_ILAC : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde tedavi gÃ¶ren hasta iÃ§in dÃ¼zenlenen reÃ§etede bulunan ilaÃ§ bilgil...</summary>
    [Key]
    public string RECETE_ILAC_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavi gÃ¶ren hasta iÃ§in dÃ¼zenlenen reÃ§etede bilgileri iÃ§in SaÄŸl...</summary>
    [ForeignKey("ReceteNavigation")]
    public string RECETE_KODU { get; set; }

    /// <summary>Bir ilacÄ±n, hastaya tek seferde verilebilecek miktarÄ± iÃ§in Ã¶lÃ§Ã¼ bilgisidir. Ã–rne...</summary>
    [Required]
    [ForeignKey("DozBirimNavigation")]
    public string DOZ_BIRIM { get; set; }

    /// <summary>Ã‡ubuk kod ya da Ã§izgi im, verilerin gÃ¶rsel Ã¶zellikli makinelerin okuyabilmesi iÃ§...</summary>
    public string BARKOD { get; set; }

    /// <summary>Ä°lacÄ±n ad bilgisidir.</summary>
    [Required]
    public string ILAC_ADI { get; set; }

    /// <summary>Ä°lacÄ±n kutu adeti bilgisidir.</summary>
    public string KUTU_ADETI { get; set; }

    /// <summary>Ä°lacÄ±n uygulanma yÃ¶ntemini ifade eder. Ã–rneÄŸin gÃ¶z Ã¼zerine, aÄŸÄ±zdan, burun iÃ§i v...</summary>
    [Required]
    [ForeignKey("IlacKullanimSekliNavigation")]
    public string ILAC_KULLANIM_SEKLI { get; set; }

    /// <summary>Ä°lacÄ±n kullanÄ±m sayÄ±sÄ± bilgisidir.</summary>
    [Required]
    public string ILAC_KULLANIM_SAYISI { get; set; }

    /// <summary>Ä°lacÄ±n kullanÄ±lmasÄ± gereken miktar bilgisini ifade eder.</summary>
    [Required]
    public string ILAC_KULLANIM_DOZU { get; set; }

    /// <summary>Ä°lacÄ±n kullanÄ±m periyodunu ifade eder.</summary>
    [Required]
    public string ILAC_KULLANIM_PERIYODU { get; set; }

    /// <summary>Ä°lacÄ±n hangi periyot biriminde kullanÄ±lacaÄŸÄ±nÄ± ifade eder. Ã–rneÄŸin ay, dakika, g...</summary>
    [Required]
    [ForeignKey("IlacKullanimPeriyoduBirimiNavigation")]
    public string ILAC_KULLANIM_PERIYODU_BIRIMI { get; set; }

    /// <summary>Ä°laÃ§ ile ilgili aÃ§Ä±klama bilgisidir.</summary>
    [Required]
    public string ILAC_ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual RECETE? ReceteNavigation { get; set; }
    public virtual REFERANS_KODLAR? DozBirimNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlacKullanimSekliNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlacKullanimPeriyoduBirimiNavigation { get; set; }
    #endregion

}
