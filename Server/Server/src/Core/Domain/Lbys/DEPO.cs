using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// Depo - Stok depolari
/// </summary>
[Table("DEPO")]
public class DEPO : VemEntity
{
    [Key]
    public string DEPO_KODU { get; set; } = default!;

    public string? DEPO_ADI { get; set; }
    public string? DEPO_TURU { get; set; }
    public string? BINA_KODU { get; set; }
    public string? MKYS_KODU { get; set; }
    public string? MKYS_KULLANICI_KODU { get; set; }
    public bool AKTIF { get; set; } = true;

    // Navigation
    [ForeignKey("DEPO_TURU")]
    public virtual REFERANS_KODLAR? DepoTuruNavigation { get; set; }

    [ForeignKey("BINA_KODU")]
    public virtual BINA? BinaNavigation { get; set; }
}
