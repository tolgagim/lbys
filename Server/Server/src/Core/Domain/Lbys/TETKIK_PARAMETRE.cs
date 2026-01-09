using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// Tetkik Parametre - Tetkik parametre tanimlari
/// </summary>
[Table("TETKIK_PARAMETRE")]
public class TETKIK_PARAMETRE : VemEntity
{
    [Key]
    public string TETKIK_PARAMETRE_KODU { get; set; } = default!;

    public string? TETKIK_PARAMETRE_ADI { get; set; }
    public string? TETKIK_PARAMETRE_BIRIMI { get; set; }
    public string? TETKIK_KODU { get; set; }
    public string? CIHAZ_KODU { get; set; }
    public string? MEDULA_PARAMETRE_KODU { get; set; }
    public string? LOINC_KODU { get; set; }
    public string? RAPOR_SONUC_SIRASI { get; set; }
    public string? IPTAL_DURUMU { get; set; }

    // Navigation
    [ForeignKey("TETKIK_KODU")]
    public virtual TETKIK? TetkikNavigation { get; set; }

    [ForeignKey("CIHAZ_KODU")]
    public virtual CIHAZ? CihazNavigation { get; set; }
}
