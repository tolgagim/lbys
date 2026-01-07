using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// Birim - Hastane birimleri/klinikleri
/// </summary>
[Table("BIRIM")]
public class BIRIM : VemEntity
{
    [Key]
    public string BIRIM_KODU { get; set; } = default!;

    [Required]
    public string BIRIM_ADI { get; set; } = default!;

    public string? BIRIM_TURU { get; set; }
    public string? UST_BIRIM_KODU { get; set; }
    public string? KURUM_KODU { get; set; }
    public bool AKTIF { get; set; } = true;

    // Navigation
    [ForeignKey("BIRIM_TURU")]
    public virtual REFERANS_KODLAR? BirimTuruNavigation { get; set; }

    [ForeignKey("KURUM_KODU")]
    public virtual KURUM? KurumNavigation { get; set; }

    [ForeignKey("UST_BIRIM_KODU")]
    public virtual BIRIM? UstBirimNavigation { get; set; }
}
