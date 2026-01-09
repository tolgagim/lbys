using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// KURUL tablosu - 11 kolon
/// </summary>
[Table("KURUL")]
public class KURUL : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde dÃ¼zenlenen saÄŸlÄ±k kurulu tarafÄ±ndan verilen raporlarÄ±n tanÄ±m bi...</summary>
    [Key]
    public string KURUL_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>Kurul adÄ± bilgisidir.</summary>
    public string KURUL_ADI { get; set; }

    /// <summary>Hastaya verilen rapor tÃ¼rÃ¼nÃ¼ ifade eder.</summary>
    [ForeignKey("RaporTuruNavigation")]
    public string RAPOR_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde dÃ¼zenlenen heyet veya tek hekim raporlarÄ± iÃ§in MEDULA tarafÄ±nda...</summary>
    [Required]
    [ForeignKey("MedulaRaporTuruNavigation")]
    public string MEDULA_RAPOR_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavi olan hastalar iÃ§in dÃ¼zenlenmiÅŸ heyet veya tek hekim rapo...</summary>
    [Required]
    [ForeignKey("MedulaAltRaporTuruNavigation")]
    public string MEDULA_ALT_RAPOR_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual REFERANS_KODLAR? RaporTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? MedulaRaporTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? MedulaAltRaporTuruNavigation { get; set; }
    #endregion

}
