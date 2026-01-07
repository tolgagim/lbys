using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// REFERANS_KODLAR tablosu - 490 kolon
/// </summary>
[Table("REFERANS_KODLAR")]
public class REFERANS_KODLAR
{
    /// <summary>SBYS tarafinda olusturulan ya da olusturulacak Tekil Referans Kodudur (ID).</summary>
    [Key]
    public string REFERANS_KODU { get; set; }

    /// <summary>SBYS tarafinda sabit olarak kullanilan verilerin alan adidir.</summary>
    public string KOD_TURU { get; set; }

    /// <summary>SBYS tarafinda olusturulan ya da olusturulacak Referans adi bilgisidir.</summary>
    public string REFERANS_ADI { get; set; }

    /// <summary>SKRS kod sisteminden seçilen ve ilgili koda karsilik gelen deger bilgisidir. Örn...</summary>
    [Required]
    public string SKRS_KODU { get; set; }

    /// <summary>Medula sisteminden alinan deger bilgisidir.</summary>
    [Required]
    public string MEDULA_KODU { get; set; }

    /// <summary>MKYS sisteminden alinan deger bilgisidir.</summary>
    [Required]
    public string MKYS_KODU { get; set; }

    /// <summary>Teshisle Iliskili Gruplar (Diagnosis Related Group) kod bilgisidir.</summary>
    [Required]
    public string TIG_KODU { get; set; }

}