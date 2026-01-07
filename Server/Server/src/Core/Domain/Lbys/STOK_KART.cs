using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// Stok Kart - Ilac ve malzeme tanimlari
/// </summary>
[Table("STOK_KART")]
public class STOK_KART : VemEntity
{
    [Key]
    public string STOK_KART_KODU { get; set; } = default!;

    public string? MALZEME_ADI { get; set; }
    public string? MKYS_MALZEME_KODU { get; set; }
    public string? TASINIR_KODU { get; set; }
    public string? MALZEME_TIPI { get; set; }
    public string? BARKOD { get; set; }
    public string? MALZEME_SUT_KODU { get; set; }
    public string? RECETE_TURU { get; set; }
    public string? MEDULA_CARPANI { get; set; }
    public string? EHU_ILAC_GUN_MIKTARI { get; set; }
    public string? EHU_ILAC_MAKSIMUM_ADET { get; set; }
    public string? EHU_ONAY_DURUMU { get; set; }
    public bool AKTIF { get; set; } = true;

    // Navigation
    [ForeignKey("MALZEME_TIPI")]
    public virtual REFERANS_KODLAR? MalzemeTipiNavigation { get; set; }

    [ForeignKey("RECETE_TURU")]
    public virtual REFERANS_KODLAR? ReceteTuruNavigation { get; set; }
}
