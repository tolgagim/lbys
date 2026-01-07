using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// Hasta - Hasta ana kayitlari
/// </summary>
[Table("HASTA")]
public class HASTA : VemEntity
{
    [Key]
    public string HASTA_KODU { get; set; } = default!;

    [Required]
    public string TC_KIMLIK_NO { get; set; } = default!;

    [Required]
    public string AD { get; set; } = default!;

    [Required]
    public string SOYAD { get; set; } = default!;

    public string? CINSIYET { get; set; }
    public DateTime? DOGUM_TARIHI { get; set; }
    public string? DOGUM_YERI { get; set; }
    public string? ANA_ADI { get; set; }
    public string? BABA_ADI { get; set; }
    public string? KAN_GRUBU { get; set; }
    public string? MEDENI_HAL { get; set; }
    public string? UYRUK { get; set; }
    public string? MESLEK { get; set; }
    public string? EGITIM_DURUMU { get; set; }
    public string? IL_KODU { get; set; }
    public string? ILCE_KODU { get; set; }
    public string? ADRES { get; set; }
    public string? TELEFON { get; set; }
    public string? CEP_TELEFON { get; set; }
    public string? EMAIL { get; set; }
    public string? SOSYAL_GUVENCE { get; set; }
    public string? SIGORTA_NO { get; set; }
    public string? PROTOKOL_NO { get; set; }
    public bool AKTIF { get; set; } = true;
    public DateTime? OLUM_TARIHI { get; set; }

    // Navigation
    [ForeignKey("CINSIYET")]
    public virtual REFERANS_KODLAR? CinsiyetNavigation { get; set; }

    [ForeignKey("KAN_GRUBU")]
    public virtual REFERANS_KODLAR? KanGrubuNavigation { get; set; }

    [ForeignKey("MEDENI_HAL")]
    public virtual REFERANS_KODLAR? MedeniHalNavigation { get; set; }

    [ForeignKey("SOSYAL_GUVENCE")]
    public virtual REFERANS_KODLAR? SosyalGuvenceNavigation { get; set; }
}
