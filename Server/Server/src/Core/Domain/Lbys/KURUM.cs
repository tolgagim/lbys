using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// Kurum - Hastane/Saglik tesisi bilgileri
/// </summary>
[Table("KURUM")]
public class KURUM : VemEntity
{
    [Key]
    public string KURUM_KODU { get; set; } = default!;

    [Required]
    public string KURUM_ADI { get; set; } = default!;

    public string? AKTIFLIK_BILGISI { get; set; }
    public string? AYAKTAN_BUTCE_KODU { get; set; }
    public string? DEVREDILEN_KURUM { get; set; }
    public string? GUNUBIRLIK_BUTCE_KODU { get; set; }
    public string? HASTA_KURUM_TURU { get; set; }
    public string? KURUM_ADRESI { get; set; }
    public string? SKRS_KURUM_KODU { get; set; }
    public string? YATAN_BUTCE_KODU { get; set; }
}
