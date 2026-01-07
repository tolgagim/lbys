using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// Tetkik - Laboratuvar tetkik tanimlari
/// </summary>
[Table("TETKIK")]
public class TETKIK : VemEntity
{
    [Key]
    public string TETKIK_KODU { get; set; } = default!;

    public string? TETKIK_ADI { get; set; }
    public string? LOINC_KODU { get; set; }
    public string? HIZMET_KODU { get; set; }
    public string? RAPOR_SONUC_SIRASI { get; set; }
    public string? HESAPLAMALI_TETKIK_BILGISI { get; set; }
    public string? HESAPLAMALI_TETKIK_FORMULU { get; set; }
    public bool AKTIF { get; set; } = true;

    // Navigation
    [ForeignKey("HIZMET_KODU")]
    public virtual HIZMET? HizmetNavigation { get; set; }
}
