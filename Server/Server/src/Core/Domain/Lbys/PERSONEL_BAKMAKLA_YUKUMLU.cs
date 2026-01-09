using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// PERSONEL_BAKMAKLA_YUKUMLU tablosu - 14 kolon
/// </summary>
[Table("PERSONEL_BAKMAKLA_YUKUMLU")]
public class PERSONEL_BAKMAKLA_YUKUMLU : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin bakmakla yÃ¼kÃ¼mlÃ¼ olduÄŸu kiÅŸilerin bilgileri ...</summary>
    [Key]
    public string PERSONEL_BAKMAKLA_YUKUMLU_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin bakmakla yÃ¼kÃ¼mlÃ¼ olduÄŸu kiÅŸinin personele ya...</summary>
    [ForeignKey("PersonelYakinlikDerecesiNavigation")]
    public string PERSONEL_YAKINLIK_DERECESI { get; set; }

    /// <summary>KiÅŸiyi niteleyen eÅŸsiz numaradÄ±r.</summary>
    [Required]
    public string TC_KIMLIK_NUMARASI { get; set; }

    /// <summary>KiÅŸinin adÄ± bilgisidir.</summary>
    public string AD { get; set; }

    /// <summary>SaÄŸlÄ±k hizmeti alan kiÅŸinin kimlik belgesinde yer alan soyadÄ±dÄ±r.</summary>
    public string SOYADI { get; set; }

    /// <summary>KiÅŸinin resmi doÄŸum tarihini ifade eder.</summary>
    public DateTime? DOGUM_TARIHI { get; set; }

    /// <summary>KiÅŸinin en son bitirdiÄŸi okul seviyesini veya okuryazarlÄ±k durumunu ifade eder. ...</summary>
    [Required]
    [ForeignKey("OgrenimDurumuNavigation")]
    public string OGRENIM_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran kiÅŸinin engellilik durumunu ifade eder. Ã–rneÄŸin bedense...</summary>
    [Required]
    [ForeignKey("EngellilikDurumuNavigation")]
    public string ENGELLILIK_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual PERSONEL? PersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? PersonelYakinlikDerecesiNavigation { get; set; }
    public virtual REFERANS_KODLAR? OgrenimDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? EngellilikDurumuNavigation { get; set; }
    #endregion

}
