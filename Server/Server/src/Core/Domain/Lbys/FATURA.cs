using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// Fatura - Hasta fatura kayitlari
/// </summary>
[Table("FATURA")]
public class FATURA : VemEntity
{
    [Key]
    public string FATURA_KODU { get; set; } = default!;

    [Required]
    public string HASTA_BASVURU_KODU { get; set; } = default!;

    public string? HASTA_KODU { get; set; }
    public string? FATURA_DONEMI { get; set; }
    public string? ICMAL_KODU { get; set; }
    public string? FATURA_TURU { get; set; }
    public string? FATURA_ADI { get; set; }
    public DateTime? FATURA_ZAMANI { get; set; }
    public decimal? FATURA_TUTARI { get; set; }
    public string? FATURA_NUMARASI { get; set; }
    public string? MEDULA_TESLIM_NUMARASI { get; set; }
    public string? FATURA_KESILEN_KURUM_KODU { get; set; }
    public string? BUTCE_KODU { get; set; }

    // Navigation
    [ForeignKey("HASTA_BASVURU_KODU")]
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }

    [ForeignKey("HASTA_KODU")]
    public virtual HASTA? HastaNavigation { get; set; }

    [ForeignKey("ICMAL_KODU")]
    public virtual ICMAL? IcmalNavigation { get; set; }

    [ForeignKey("FATURA_TURU")]
    public virtual REFERANS_KODLAR? FaturaTuruNavigation { get; set; }

    [ForeignKey("FATURA_KESILEN_KURUM_KODU")]
    public virtual KURUM? FaturaKesilenKurumNavigation { get; set; }
}
