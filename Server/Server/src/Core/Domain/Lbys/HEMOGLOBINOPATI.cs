using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// HEMOGLOBINOPATI tablosu - 14 kolon
/// </summary>
[Table("HEMOGLOBINOPATI")]
public class HEMOGLOBINOPATI : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [Key]
    public string HEMOGLOBINOPATI_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>KiÅŸinin hemoglobinopati tarama sonucuna iliÅŸkin bilgiyi ifade eder.</summary>
    [Required]
    [ForeignKey("HemoglobinopatiTaramaSonucuNavigation")]
    public string HEMOGLOBINOPATI_TARAMA_SONUCU { get; set; }

    /// <summary>KiÅŸinin eÅŸ adayÄ±nÄ±n T.C. Kimlik NumarasÄ± bilgisidir.</summary>
    [Required]
    public string ES_ADAYI_TC_KIMLIK_NUMARASI { get; set; }

    /// <summary>KiÅŸinin eÅŸ adayÄ±nÄ±n telefon numarasÄ± bilgisidir.</summary>
    [Required]
    public string ES_ADAYI_TELEFON_NUMARASI { get; set; }

    /// <summary>KiÅŸinin hemoglobinopati tarama testinin sonuÃ§ bilgisidir.</summary>
    [ForeignKey("HemoglobinopatiTestiSonucuNavigation")]
    public string HEMOGLOBINOPATI_TESTI_SONUCU { get; set; }

    /// <summary>KiÅŸiye yapÄ±lan hemoglobinopati tarama testinin yapÄ±lma amacÄ±na iliÅŸkin iÅŸlem bil...</summary>
    public string HEMOGLOBINOPATI_ISLEM_TIPI { get; set; }

    /// <summary>KiÅŸinin hemoglobinopati test sonucu hastalÄ±k tÃ¼rÃ¼ bilgisidir.</summary>
    [Required]
    [ForeignKey("HemoglobinopatiSonucHastalikNavigation")]
    public string HEMOGLOBINOPATI_SONUC_HASTALIK { get; set; }

    /// <summary>KiÅŸinin hemoglobinopati test sonucu taÅŸÄ±yÄ±cÄ±lÄ±k tÃ¼rÃ¼ bilgisidir.</summary>
    [Required]
    [ForeignKey("HemoglobinopatiTasiyicilikNavigation")]
    public string HEMOGLOBINOPATI_TASIYICILIK { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? HemoglobinopatiTaramaSonucuNavigation { get; set; }
    public virtual REFERANS_KODLAR? HemoglobinopatiTestiSonucuNavigation { get; set; }
    public virtual REFERANS_KODLAR? HemoglobinopatiSonucHastalikNavigation { get; set; }
    public virtual REFERANS_KODLAR? HemoglobinopatiTasiyicilikNavigation { get; set; }
    #endregion

}
