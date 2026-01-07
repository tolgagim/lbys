using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// Hasta Basvuru - Hasta basvuru/muayene kayitlari
/// </summary>
[Table("HASTA_BASVURU")]
public class HASTA_BASVURU : VemEntity
{
    [Key]
    public string HASTA_BASVURU_KODU { get; set; } = default!;

    [Required]
    public string HASTA_KODU { get; set; } = default!;

    [Required]
    public DateTime BASVURU_TARIHI { get; set; }

    public string? BASVURU_TURU { get; set; }
    public string? BASVURU_SEKLI { get; set; }
    public string? BIRIM_KODU { get; set; }
    public string? DOKTOR_KODU { get; set; }
    public string? SIKAYET { get; set; }
    public string? TANI_KODU { get; set; }
    public string? TEDAVI_TURU { get; set; }
    public string? SEVK_EDEN_KURUM { get; set; }
    public string? PROVIZYON_TIPI { get; set; }
    public string? TAKIP_NO { get; set; }
    public DateTime? CIKIS_TARIHI { get; set; }
    public string? CIKIS_SEKLI { get; set; }
    public string? SONUC_KODU { get; set; }
    public bool AKTIF { get; set; } = true;

    // Navigation
    [ForeignKey("HASTA_KODU")]
    public virtual HASTA? HastaNavigation { get; set; }

    [ForeignKey("BASVURU_TURU")]
    public virtual REFERANS_KODLAR? BasvuruTuruNavigation { get; set; }

    [ForeignKey("BASVURU_SEKLI")]
    public virtual REFERANS_KODLAR? BasvuruSekliNavigation { get; set; }

    [ForeignKey("BIRIM_KODU")]
    public virtual BIRIM? BirimNavigation { get; set; }

    [ForeignKey("DOKTOR_KODU")]
    public virtual PERSONEL? DoktorNavigation { get; set; }

    [ForeignKey("CIKIS_SEKLI")]
    public virtual REFERANS_KODLAR? CikisSekliNavigation { get; set; }
}
