using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// Personel - Hastane personel kayitlari
/// </summary>
[Table("PERSONEL")]
public class PERSONEL : VemEntity
{
    [Key]
    public string PERSONEL_KODU { get; set; } = default!;

    [Required]
    public string TC_KIMLIK_NO { get; set; } = default!;

    [Required]
    public string AD { get; set; } = default!;

    [Required]
    public string SOYAD { get; set; } = default!;

    public string? UNVAN { get; set; }
    public string? UZMANLIK_KODU { get; set; }
    public string? BIRIM_KODU { get; set; }
    public string? CINSIYET { get; set; }
    public DateTime? DOGUM_TARIHI { get; set; }
    public string? TELEFON { get; set; }
    public string? EMAIL { get; set; }
    public string? DIPLOMA_NO { get; set; }
    public string? DIPLOMA_TESCIL_NO { get; set; }
    public DateTime? ISE_BASLAMA_TARIHI { get; set; }
    public bool AKTIF { get; set; } = true;

    // Navigation
    [ForeignKey("CINSIYET")]
    public virtual REFERANS_KODLAR? CinsiyetNavigation { get; set; }

    [ForeignKey("UZMANLIK_KODU")]
    public virtual REFERANS_KODLAR? UzmanlikNavigation { get; set; }

    [ForeignKey("BIRIM_KODU")]
    public virtual BIRIM? BirimNavigation { get; set; }
}
