using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// RISK_SKORLAMA tablosu - 17 kolon
/// </summary>
[Table("RISK_SKORLAMA")]
public class RISK_SKORLAMA : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde kullanÄ±lan Risk Skorlama bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Si...</summary>
    [Key]
    public string RISK_SKORLAMA_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kullanÄ±lan APACHE, SNAP, SAPS, Ä°taki, Harizmi vb. gibi risk sko...</summary>
    [ForeignKey("RiskSkorlamaTuruNavigation")]
    public string RISK_SKORLAMA_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan iÅŸlemlerin, uygulanmaya baÅŸladÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime? ISLEM_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavi gÃ¶ren hastanÄ±n Ã¶lÃ¼m oranÄ± riskini belirleyebilmek iÃ§in k...</summary>
    [Required]
    public string RISK_SKORLAMA_TOPLAM_PUANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kullanÄ±lan risk skorlama sistemi ile belirlenen, hastanÄ±n bekle...</summary>
    [Required]
    public string BEKLENEN_OLUM_ORANI { get; set; }

    /// <summary>Hastanin bilinÃ§ durumunun degerlendirilmesinde kullanilan gÃ¼venilir ve objektif ...</summary>
    [Required]
    public string GLASGOW_SKALASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kullanÄ±lan risk skorlama sistemi ile belirlenen dÃ¼zeltilmiÅŸ bek...</summary>
    [Required]
    public string DUZELTILMISBEKLENEN_OLUM_ORANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde saÄŸlÄ±k hizmetini alan kiÅŸi iÃ§in hekim isteminin (order) detay b...</summary>
    [Required]
    [ForeignKey("TibbiOrderDetayNavigation")]
    public string TIBBI_ORDER_DETAY_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual REFERANS_KODLAR? RiskSkorlamaTuruNavigation { get; set; }
    public virtual TIBBI_ORDER_DETAY? TibbiOrderDetayNavigation { get; set; }
    #endregion

}
