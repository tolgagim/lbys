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
    public string? AKTIFLIK_BILGISI { get; set; }
    public string? BINA_KODU { get; set; }
    public string? KLINIK_KODU { get; set; }
    public string? MEDULA_BRANS_KODU { get; set; }
    public string? MHRS_ADI { get; set; }
    public string? MHRS_KODU { get; set; }
    public string? MKYS_KODU { get; set; }
    public int? YATAK_SAYISI { get; set; }

    // Navigation
    [ForeignKey("BIRIM_TURU")]
    public virtual REFERANS_KODLAR? BirimTuruNavigation { get; set; }

    [ForeignKey("BINA_KODU")]
    public virtual BINA? BinaNavigation { get; set; }
}
