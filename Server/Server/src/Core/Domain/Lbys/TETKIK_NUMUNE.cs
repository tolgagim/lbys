using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// Tetkik Numune - Laboratuvar numune kayitlari
/// </summary>
[Table("TETKIK_NUMUNE")]
public class TETKIK_NUMUNE : VemEntity
{
    [Key]
    public string TETKIK_NUMUNE_KODU { get; set; } = default!;

    public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? NUMUNE_NUMARASI { get; set; }
    public string? NUMUNE_TURU { get; set; }
    public string? BIRIM_KODU { get; set; }
    public DateTime? NUMUNE_ALMA_ZAMANI { get; set; }
    public DateTime? NUMUNE_KABUL_ZAMANI { get; set; }
    public string? BARKOD { get; set; }
    public DateTime? BARKOD_ZAMANI { get; set; }
    public string? NUMUNE_ALAN_KULLANICI_KODU { get; set; }
    public string? KABUL_EDEN_KULLANICI_KODU { get; set; }
    public string? NUMUNE_RET_NEDENI { get; set; }
    public string? RET_EDEN_KULLANICI_KODU { get; set; }
    public DateTime? RET_ZAMANI { get; set; }
    public string? NUMUNE_ACILIYET_DURUMU { get; set; }
    public string? ENTEGRASYON_NUMARASI { get; set; }

    // Navigation
    [ForeignKey("HASTA_KODU")]
    public virtual HASTA? HastaNavigation { get; set; }

    [ForeignKey("HASTA_BASVURU_KODU")]
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }

    [ForeignKey("NUMUNE_TURU")]
    public virtual REFERANS_KODLAR? NumuneTuruNavigation { get; set; }

    [ForeignKey("BIRIM_KODU")]
    public virtual BIRIM? BirimNavigation { get; set; }

    [ForeignKey("NUMUNE_ALAN_KULLANICI_KODU")]
    public virtual KULLANICI? NumuneAlanKullaniciNavigation { get; set; }

    [ForeignKey("KABUL_EDEN_KULLANICI_KODU")]
    public virtual KULLANICI? KabulEdenKullaniciNavigation { get; set; }

    [ForeignKey("NUMUNE_RET_NEDENI")]
    public virtual REFERANS_KODLAR? NumuneRetNedeniNavigation { get; set; }

    [ForeignKey("RET_EDEN_KULLANICI_KODU")]
    public virtual KULLANICI? RetEdenKullaniciNavigation { get; set; }
}
