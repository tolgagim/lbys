using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// Icmal - Fatura icmal kayitlari
/// </summary>
[Table("ICMAL")]
public class ICMAL : VemEntity
{
    [Key]
    public string ICMAL_KODU { get; set; } = default!;

    public string? ICMAL_DONEMI { get; set; }
    public string? ICMAL_NUMARASI { get; set; }
    public string? ICMAL_ADI { get; set; }
    public string? KURUM_KODU { get; set; }
    public DateTime? ICMAL_ZAMANI { get; set; }
    public decimal? ICMAL_TUTARI { get; set; }

    // Navigation
    [ForeignKey("KURUM_KODU")]
    public virtual KURUM? KurumNavigation { get; set; }
}
