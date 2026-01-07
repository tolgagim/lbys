using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// Cihaz - Saglik tesisi tibbi cihazlari
/// </summary>
[Table("CIHAZ")]
public class CIHAZ : VemEntity
{
    [Key]
    public string CIHAZ_KODU { get; set; } = default!;

    public string? CIHAZ_ADI { get; set; }
    public string? CIHAZ_GRUBU { get; set; }
    public string? BIRIM_KODU { get; set; }
    public string? CIHAZ_MODELI { get; set; }
    public string? CIHAZ_MARKASI { get; set; }
    public string? SERI_NUMARASI { get; set; }
    public string? MKYS_KUNYE_NUMARASI { get; set; }
    public bool AKTIF { get; set; } = true;

    // Navigation
    [ForeignKey("CIHAZ_GRUBU")]
    public virtual REFERANS_KODLAR? CihazGrubuNavigation { get; set; }

    [ForeignKey("BIRIM_KODU")]
    public virtual BIRIM? BirimNavigation { get; set; }
}
