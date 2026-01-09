using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// Hizmet - Saglik hizmetleri tanimlari
/// </summary>
[Table("HIZMET")]
public class HIZMET : VemEntity
{
    [Key]
    public string HIZMET_KODU { get; set; } = default!;

    public string? HIZMET_ISLEM_GRUBU { get; set; }
    public string? HIZMET_ISLEM_TURU { get; set; }
    public string? SUT_KODU { get; set; }
    public string? HIZMET_ADI { get; set; }
    public string? TIBBI_ISLEM_PUAN_BILGISI { get; set; }
    public string? AKTIFLIK_BILGISI { get; set; }

    // Navigation
    [ForeignKey("HIZMET_ISLEM_GRUBU")]
    public virtual REFERANS_KODLAR? HizmetIslemGrubuNavigation { get; set; }

    [ForeignKey("HIZMET_ISLEM_TURU")]
    public virtual REFERANS_KODLAR? HizmetIslemTuruNavigation { get; set; }

    [ForeignKey("TIBBI_ISLEM_PUAN_BILGISI")]
    public virtual REFERANS_KODLAR? TibbiIslemPuanBilgisiNavigation { get; set; }
}
