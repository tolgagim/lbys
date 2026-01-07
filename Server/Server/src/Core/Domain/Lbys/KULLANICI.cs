using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// Kullanici - VEM sistem kullanicilari (audit icin)
/// Not: Authentication icin ApplicationUser kullanilir
/// </summary>
[Table("KULLANICI")]
public class KULLANICI : VemEntity
{
    [Key]
    public string KULLANICI_KODU { get; set; } = default!;

    public string? PERSONEL_KODU { get; set; }
    public string? KULLANICI_ADI { get; set; }
    public bool AKTIF { get; set; } = true;

    // Navigation
    [ForeignKey("PERSONEL_KODU")]
    public virtual PERSONEL? PersonelNavigation { get; set; }
}
