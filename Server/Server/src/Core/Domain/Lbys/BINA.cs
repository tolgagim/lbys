using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// Bina - Saglik tesisi binalari
/// </summary>
[Table("BINA")]
public class BINA : VemEntity
{
    [Key]
    public string BINA_KODU { get; set; } = default!;

    public string? BINA_ADI { get; set; }
    public string? BINA_ADRESI { get; set; }
    public string? SKRS_KURUM_KODU { get; set; }

    // Navigation
    [ForeignKey("SKRS_KURUM_KODU")]
    public virtual REFERANS_KODLAR? SkrsKurumNavigation { get; set; }
}
