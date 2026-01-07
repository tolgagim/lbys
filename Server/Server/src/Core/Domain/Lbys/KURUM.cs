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

    public string? KURUM_TURU { get; set; }
    public string? IL_KODU { get; set; }
    public string? ILCE_KODU { get; set; }
    public string? ADRES { get; set; }
    public string? TELEFON { get; set; }
    public string? EMAIL { get; set; }
    public string? VERGI_NO { get; set; }
    public string? VERGI_DAIRESI { get; set; }

    // Navigation
    [ForeignKey("KURUM_TURU")]
    public virtual REFERANS_KODLAR? KurumTuruNavigation { get; set; }
}
