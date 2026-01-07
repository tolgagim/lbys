using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// Basvuru Tani - Hasta tani kayitlari (ICD-10)
/// </summary>
[Table("BASVURU_TANI")]
public class BASVURU_TANI : VemEntity
{
    [Key]
    public string BASVURU_TANI_KODU { get; set; } = default!;

    public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? TANI_KODU { get; set; }
    public string? TANI_TURU { get; set; }
    public string? BIRINCIL_TANI { get; set; }
    public DateTime? TANI_ZAMANI { get; set; }
    public string? HEKIM_KODU { get; set; }
    public string? KURUL_RAPOR_KODU { get; set; }
    public string? HASTA_SEVK_KODU { get; set; }

    // Navigation
    [ForeignKey("HASTA_KODU")]
    public virtual HASTA? HastaNavigation { get; set; }

    [ForeignKey("HASTA_BASVURU_KODU")]
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }

    [ForeignKey("TANI_KODU")]
    public virtual REFERANS_KODLAR? TaniNavigation { get; set; }

    [ForeignKey("TANI_TURU")]
    public virtual REFERANS_KODLAR? TaniTuruNavigation { get; set; }

    [ForeignKey("HEKIM_KODU")]
    public virtual PERSONEL? HekimNavigation { get; set; }
}
