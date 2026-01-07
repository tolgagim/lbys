using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// Oda - Saglik tesisi odalari
/// </summary>
[Table("ODA")]
public class ODA : VemEntity
{
    [Key]
    public string ODA_KODU { get; set; } = default!;

    public string? ODA_ADI { get; set; }
    public string? BIRIM_KODU { get; set; }

    // Navigation
    [ForeignKey("BIRIM_KODU")]
    public virtual BIRIM? BirimNavigation { get; set; }
}
