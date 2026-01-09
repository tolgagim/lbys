using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// RISK_SKORLAMA_DETAY tablosu - 11 kolon
/// </summary>
[Table("RISK_SKORLAMA_DETAY")]
public class RISK_SKORLAMA_DETAY : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde kullanÄ±lan Risk Skorlama detay bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶ne...</summary>
    [Key]
    public string RISK_SKORLAMA_DETAY_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde kullanÄ±lan Risk Skorlama bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Si...</summary>
    [ForeignKey("RiskSkorlamaNavigation")]
    public string RISK_SKORLAMA_KODU { get; set; }

    /// <summary>Hastanin bilinÃ§ durumunun degerlendirilmesinde kullanilan gÃ¼venilir ve objektif ...</summary>
    [Required]
    public string GLASGOW_SKALASI { get; set; }

    /// <summary>SeÃ§ilen risk skorlama tÃ¼rÃ¼nde bulunan alt tÃ¼r bilgisidir. Ã–rneÄŸin risk skorlama ...</summary>
    [ForeignKey("RiskSkorlamaAltTuruNavigation")]
    public string RISK_SKORLAMA_ALT_TURU { get; set; }

    /// <summary>Risk skorlama alt tÃ¼rÃ¼ne gÃ¶re aldÄ±ÄŸÄ± deÄŸer bilgisidir.</summary>
    [Required]
    public string RISK_SKOR_DEGERI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual RISK_SKORLAMA? RiskSkorlamaNavigation { get; set; }
    public virtual REFERANS_KODLAR? RiskSkorlamaAltTuruNavigation { get; set; }
    #endregion

}
