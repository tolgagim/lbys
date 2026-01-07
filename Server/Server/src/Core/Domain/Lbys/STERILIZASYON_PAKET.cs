using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// STERILIZASYON_PAKET tablosu - 14 kolon
/// </summary>
[Table("STERILIZASYON_PAKET")]
public class STERILIZASYON_PAKET : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinin deposunda bulunan steril aletlerin paket bilgilerine iliÅŸkin ka...</summary>
    [Key]
    public string STERILIZASYON_PAKET_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sterilizasyon Ã¼nitesinde kullanÄ±lan paketler iÃ§in tanÄ±mlanan ad bilgisidir.</summary>
    public string STERILIZASYON_PAKET_ADI { get; set; }

    /// <summary>Sterilizasyon Ã¼nitesinde kullanÄ±lan paketin barkod bilgisidir. Barkod bilgisi yo...</summary>
    public string PAKET_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>TÄ±bbi aletler iÃ§in sterilizasyon iÅŸleminin yapÄ±ldÄ±ÄŸÄ± yÃ¶ntem bilgisini ifade eder...</summary>
    [Required]
    [ForeignKey("SterilizasyonYontemiNavigation")]
    public string STERILIZASYON_YONTEMI { get; set; }

    /// <summary>Sterilizasyon Ã¼nitesinde kullanÄ±lan paketler iÃ§in tanÄ±mlanan grup bilgisidir. Ã–r...</summary>
    [Required]
    [ForeignKey("SterilizasyonPaketGrubuNavigation")]
    public string STERILIZASYON_PAKET_GRUBU { get; set; }

    /// <summary>Steril edilmiÅŸ setin raf Ã¶mrÃ¼nÃ¼n gÃ¼n olarak deÄŸer bilgisidir. Ã–rneÄŸin 30 gÃ¼n, 60...</summary>
    [Required]
    public string PAKET_RAF_OMRU_BITIS_GUN { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual REFERANS_KODLAR? SterilizasyonYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SterilizasyonPaketGrubuNavigation { get; set; }
    #endregion

}
