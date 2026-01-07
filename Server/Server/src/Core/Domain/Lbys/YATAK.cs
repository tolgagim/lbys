using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// Yatak - Hasta yataklari
/// </summary>
[Table("YATAK")]
public class YATAK : VemEntity
{
    [Key]
    public string YATAK_KODU { get; set; } = default!;

    public string? YATAK_ADI { get; set; }
    public string? ODA_KODU { get; set; }
    public string? YATAK_TURU { get; set; }
    public string? YOGUN_BAKIM_YATAK_SEVIYESI { get; set; }
    public string? VENTILATOR_CIHAZ_KODU { get; set; }
    public bool AKTIF { get; set; } = true;

    // Navigation
    [ForeignKey("ODA_KODU")]
    public virtual ODA? OdaNavigation { get; set; }

    [ForeignKey("YATAK_TURU")]
    public virtual REFERANS_KODLAR? YatakTuruNavigation { get; set; }

    [ForeignKey("YOGUN_BAKIM_YATAK_SEVIYESI")]
    public virtual REFERANS_KODLAR? YogunBakimYatakSeviyesiNavigation { get; set; }

    [ForeignKey("VENTILATOR_CIHAZ_KODU")]
    public virtual CIHAZ? VentilatorCihazNavigation { get; set; }
}
