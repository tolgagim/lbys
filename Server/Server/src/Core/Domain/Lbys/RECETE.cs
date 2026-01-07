using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// Recete - Hasta recete kayitlari
/// </summary>
[Table("RECETE")]
public class RECETE : VemEntity
{
    [Key]
    public string RECETE_KODU { get; set; } = default!;

    public string? HASTA_BASVURU_KODU { get; set; }
    public string? HASTA_KODU { get; set; }
    public DateTime? RECETE_ZAMANI { get; set; }
    public string? RECETE_TURU { get; set; }
    public string? RECETE_ALT_TURU { get; set; }
    public string? HEKIM_KODU { get; set; }
    public string? DEFTER_NUMARASI { get; set; }
    public string? MEDULA_E_RECETE_NUMARASI { get; set; }
    public string? RENKLI_RECETE_NUMARASI { get; set; }
    public string? SERI_NUMARASI { get; set; }
    public string? RECETE_E_IMZA_DURUMU { get; set; }
    public string? SGK_TAKIP_NUMARASI { get; set; }

    // Navigation
    [ForeignKey("HASTA_BASVURU_KODU")]
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }

    [ForeignKey("HASTA_KODU")]
    public virtual HASTA? HastaNavigation { get; set; }

    [ForeignKey("RECETE_TURU")]
    public virtual REFERANS_KODLAR? ReceteTuruNavigation { get; set; }

    [ForeignKey("RECETE_ALT_TURU")]
    public virtual REFERANS_KODLAR? ReceteAltTuruNavigation { get; set; }

    [ForeignKey("HEKIM_KODU")]
    public virtual PERSONEL? HekimNavigation { get; set; }
}
