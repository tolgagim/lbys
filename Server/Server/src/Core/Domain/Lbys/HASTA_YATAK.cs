using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// Hasta Yatak - Hasta yatak kullanim kayitlari
/// </summary>
[Table("HASTA_YATAK")]
public class HASTA_YATAK : VemEntity
{
    [Key]
    public string HASTA_YATAK_KODU { get; set; } = default!;

    public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? YATAK_KODU { get; set; }
    public DateTime? YATIS_BASLAMA_ZAMANI { get; set; }
    public DateTime? YATIS_BITIS_ZAMANI { get; set; }

    // Navigation
    [ForeignKey("HASTA_KODU")]
    public virtual HASTA? HastaNavigation { get; set; }

    [ForeignKey("HASTA_BASVURU_KODU")]
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }

    [ForeignKey("YATAK_KODU")]
    public virtual YATAK? YatakNavigation { get; set; }
}
