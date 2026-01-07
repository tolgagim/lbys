using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// Ameliyat - Ameliyat kayitlari
/// </summary>
[Table("AMELIYAT")]
public class AMELIYAT : VemEntity
{
    [Key]
    public string AMELIYAT_KODU { get; set; } = default!;

    public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }

    [Required]
    public string AMELIYAT_ADI { get; set; } = default!;

    [Required]
    public string AMELIYAT_TURU { get; set; } = default!;

    public DateTime? AMELIYAT_BASLAMA_ZAMANI { get; set; }
    public DateTime? AMELIYAT_BITIS_ZAMANI { get; set; }
    public string? MASA_CIHAZ_KODU { get; set; }
    public string? BIRIM_KODU { get; set; }
    public string? DEFTER_NUMARASI { get; set; }
    public string? AMELIYAT_DURUMU { get; set; }
    public string? ANESTEZI_TURU { get; set; }
    public string? ANESTEZI_NOTU { get; set; }
    public DateTime? ANESTEZI_BASLAMA_ZAMANI { get; set; }
    public DateTime? ANESTEZI_BITIS_ZAMANI { get; set; }
    public string? AMELIYAT_TIPI { get; set; }
    public string? SKOPI_SURESI { get; set; }
    public string? PROFILAKSI_PERIYODU { get; set; }
    public string? PROFILAKSI_KODU { get; set; }

    // Navigation
    [ForeignKey("HASTA_KODU")]
    public virtual HASTA? HastaNavigation { get; set; }

    [ForeignKey("HASTA_BASVURU_KODU")]
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }

    [ForeignKey("AMELIYAT_TURU")]
    public virtual REFERANS_KODLAR? AmeliyatTuruNavigation { get; set; }

    [ForeignKey("MASA_CIHAZ_KODU")]
    public virtual CIHAZ? MasaCihazNavigation { get; set; }

    [ForeignKey("BIRIM_KODU")]
    public virtual BIRIM? BirimNavigation { get; set; }

    [ForeignKey("AMELIYAT_DURUMU")]
    public virtual REFERANS_KODLAR? AmeliyatDurumuNavigation { get; set; }

    [ForeignKey("ANESTEZI_TURU")]
    public virtual REFERANS_KODLAR? AnesteziTuruNavigation { get; set; }

    [ForeignKey("AMELIYAT_TIPI")]
    public virtual REFERANS_KODLAR? AmeliyatTipiNavigation { get; set; }

    [ForeignKey("PROFILAKSI_PERIYODU")]
    public virtual REFERANS_KODLAR? ProfilaksiPeriyoduNavigation { get; set; }

    [ForeignKey("PROFILAKSI_KODU")]
    public virtual REFERANS_KODLAR? ProfilaksiNavigation { get; set; }
}
