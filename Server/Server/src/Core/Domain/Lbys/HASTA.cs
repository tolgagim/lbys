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
    public string AD { get; set; } = default!;

    public string? TC_KIMLIK_NUMARASI { get; set; }
    public string? SOYADI { get; set; }
    public string? CINSIYET { get; set; }
    public DateTime? DOGUM_TARIHI { get; set; }
    public string? DOGUM_YERI { get; set; }
    public string? ANNE_ADI { get; set; }
    public string? ANNE_HASTA_KODU { get; set; }
    public string? ANNE_TC_KIMLIK_NUMARASI { get; set; }
    public string? BABA_ADI { get; set; }
    public string? BABA_HASTA_KODU { get; set; }
    public string? BABA_TC_KIMLIK_NUMARASI { get; set; }
    public DateTime? BEYAN_DOGUM_TARIHI { get; set; }
    public int? DOGUM_SIRASI { get; set; }
    public string? ENGELLILIK_DURUMU { get; set; }
    public string? HASTA_TIPI { get; set; }
    public string? KIMLIKSIZ_HASTA_BILGISI { get; set; }
    public string? KAN_GRUBU { get; set; }
    public string? MEDENI_HALI { get; set; }
    public string? MESLEK { get; set; }
    public int? MUAYENE_ONCELIK_SIRASI { get; set; }
    public string? OGRENIM_DURUMU { get; set; }
    public DateTime? OLUM_TARIHI { get; set; }
    public string? OLUM_YERI { get; set; }
    public string? PASAPORT_NUMARASI { get; set; }
    public string? SON_KURUM_KODU { get; set; }
    public string? UYRUK { get; set; }
    public string? YUPASS_NUMARASI { get; set; }

    // Navigation
    [ForeignKey("CINSIYET")]
    public virtual REFERANS_KODLAR? CinsiyetNavigation { get; set; }

    [ForeignKey("KAN_GRUBU")]
    public virtual REFERANS_KODLAR? KanGrubuNavigation { get; set; }

    [ForeignKey("MEDENI_HALI")]
    public virtual REFERANS_KODLAR? MedeniHaliNavigation { get; set; }
}
