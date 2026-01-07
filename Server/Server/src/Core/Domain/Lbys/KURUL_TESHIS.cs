using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// KURUL_TESHIS tablosu - 11 kolon
/// </summary>
[Table("KURUL_TESHIS")]
public class KURUL_TESHIS : VemEntity
{
    /// <summary>Hasta iÃ§in verilen saÄŸlÄ±k raporunda kurul tarafÄ±ndan onaylanan teÅŸhis bilgileri ...</summary>
    [Key]
    public string KURUL_TESHIS_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Hastaya saÄŸlÄ±k raporu veren kurul iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("KurulRaporNavigation")]
    public string KURUL_RAPOR_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavi alan hastaya dÃ¼zenlenen rapordaki ilaÃ§lar iÃ§in MEDULA ta...</summary>
    [Required]
    public string ILAC_TESHIS_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hastaya konulan tanÄ± iÃ§in ICD-10 kodlarÄ±ndan seÃ§ilen tanÄ± kodu ...</summary>
    [Required]
    [ForeignKey("TaniNavigation")]
    public string TANI_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kiÅŸiye verilen raporun baÅŸlama tarihi bilgisidir.</summary>
    public DateTime RAPOR_BASLAMA_TARIHI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hekim tarafÄ±ndan kiÅŸiye konulan tanÄ±ya ait yazÄ±lan raporun biti...</summary>
    public DateTime RAPOR_BITIS_TARIHI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual KURUL_RAPOR? KurulRaporNavigation { get; set; }
    public virtual REFERANS_KODLAR? TaniNavigation { get; set; }
    #endregion

}
