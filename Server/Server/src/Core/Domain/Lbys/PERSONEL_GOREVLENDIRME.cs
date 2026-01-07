using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// PERSONEL_GOREVLENDIRME tablosu - 13 kolon
/// </summary>
[Table("PERSONEL_GOREVLENDIRME")]
public class PERSONEL_GOREVLENDIRME : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin gÃ¶revlendirilme bilgileri iÃ§in SaÄŸlÄ±k Bilgi ...</summary>
    [Key]
    public string PERSONEL_GOREVLENDIRME_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin yaptÄ±ÄŸÄ± gÃ¶rev iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sist...</summary>
    [ForeignKey("GorevTuruNavigation")]
    public string GOREV_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki personelin gÃ¶revlendirildiÄŸi kurumda gÃ¶reve baÅŸladÄ±ÄŸÄ± tarih b...</summary>
    public DateTime? GOREVLENDIRME_BASLAMA_TARIHI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki personelin gÃ¶revlendirildiÄŸi kurumda gÃ¶revinin bittiÄŸi tarih ...</summary>
    public DateTime GOREVLENDIRME_BITIS_TARIHI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki personelin gÃ¶revlendirildiÄŸi ilin, il kodunu ifade eder.</summary>
    [Required]
    [ForeignKey("GorevlendirmeIlNavigation")]
    public string GOREVLENDIRME_IL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki personelin gÃ¶revlendirildiÄŸi ilÃ§enin, ilÃ§e kodunu ifade eder.</summary>
    [Required]
    [ForeignKey("GorevlendirmeIlceNavigation")]
    public string GOREVLENDIRME_ILCE_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki personelin gÃ¶revlendirildiÄŸi kurum iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim ...</summary>
    [Required]
    [ForeignKey("GorevlendirildigiKurumNavigation")]
    public string GOREVLENDIRILDIGI_KURUM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual PERSONEL? PersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? GorevTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? GorevlendirmeIlNavigation { get; set; }
    public virtual REFERANS_KODLAR? GorevlendirmeIlceNavigation { get; set; }
    public virtual KURUM? GorevlendirildigiKurumNavigation { get; set; }
    #endregion

}
