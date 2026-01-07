using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// SILINEN_KAYITLAR tablosu - 6 kolon
/// </summary>
[Table("SILINEN_KAYITLAR")]
public class SILINEN_KAYITLAR : VemEntity
{
    /// <summary>Silinen kayitlar iÃ§in Saglik Bilgi YÃ¶netim Sistemi tarafindan Ã¼retilen tekil kod...</summary>
    [Key]
    public string SILINEN_KAYITLAR_KODU { get; set; } = default!;
    /// <summary>KaydÄ±n silinmeden Ã¶nce bulunduÄŸu VEM GÃ¶rÃ¼ntÃ¼ AdÄ± bilgisidir.</summary>
    public string REFERANS_GORUNTU_ADI { get; set; }

    /// <summary>KaydÄ±n silinme zamanÄ± bilgisidir.</summary>
    public DateTime? SILINME_ZAMANI { get; set; }

    /// <summary>Kaydin silinmeden Ã¶nce bulundugu VEM GÃ¶rÃ¼ntÃ¼sÃ¼ iÃ§erisindeki SBYS tarafindan Ã¼ret...</summary>
    public string SILINEN_KAYDIN_KODU { get; set; }

    #region Navigation Properties
    #endregion

}
