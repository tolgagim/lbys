using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// Referans Kodlar - Tum lookup/referans verileri
/// </summary>
[Table("REFERANS_KODLAR")]
public class REFERANS_KODLAR : VemEntity
{
    [Key]
    public string REFERANS_KODU { get; set; } = default!;

    public string? KOD_TURU { get; set; }
    public string? REFERANS_ADI { get; set; }

    [Required]
    public string SKRS_KODU { get; set; } = default!;

    [Required]
    public string MEDULA_KODU { get; set; } = default!;

    [Required]
    public string MKYS_KODU { get; set; } = default!;

    [Required]
    public string TIG_KODU { get; set; } = default!;
}
