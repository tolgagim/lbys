using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// RADYOLOJI_SONUC tablosu - 17 kolon
/// </summary>
[Table("RADYOLOJI_SONUC")]
public class RADYOLOJI_SONUC : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde Ã§alÄ±ÅŸÄ±lan radyoloji tetkikinin sonucu iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim...</summary>
    [Key]
    public string RADYOLOJI_SONUC_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde Ã§alÄ±ÅŸÄ±lan radyoloji tetkileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi...</summary>
    [ForeignKey("RadyolojiNavigation")]
    public string RADYOLOJI_KODU { get; set; }

    /// <summary>Radyoloji tetkikleri iÃ§in rapora yazÄ±lan sonuÃ§ bilgisinin metin (text) bilgisidi...</summary>
    [Required]
    public string TETKIK_SONUCU_METIN { get; set; }

    /// <summary>Radyoloji tetkikleri iÃ§in rapora yazÄ±lan sonuÃ§ bilgisinin raporda yazÄ±ldÄ±ÄŸÄ± hali...</summary>
    [Required]
    public string RADYOLOJI_TETKIK_SONUCU { get; set; }

    /// <summary>Radyoloji raporlarÄ± iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan kayÄ±t edilen do...</summary>
    [ForeignKey("RadyolojiRaporFormatiNavigation")]
    public string RADYOLOJI_RAPOR_FORMATI { get; set; }

    /// <summary>Raporun ana rapor, ek rapor, konsÃ¼ltasyon raporu vb. olma durumuna iliÅŸkin bilgi...</summary>
    [ForeignKey("RaporTipiNavigation")]
    public string RAPOR_TIPI { get; set; }

    /// <summary>Raporu bilgisayar ortamÄ±na aktaran personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi ta...</summary>
    [Required]
    [ForeignKey("RaporYazanPersonelNavigation")]
    public string RAPOR_YAZAN_PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [Required]
    [ForeignKey("OnaylayanPersonel1Navigation")]
    public string ONAYLAYAN_PERSONEL_KODU_1 { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [Required]
    [ForeignKey("OnaylayanPersonel2Navigation")]
    public string ONAYLAYAN_PERSONEL_KODU_2 { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [Required]
    [ForeignKey("OnaylayanPersonel3Navigation")]
    public string ONAYLAYAN_PERSONEL_KODU_3 { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen tÄ±bbi raporun uzman hekim tarafÄ±ndan onaylandÄ±ÄŸÄ± zaman...</summary>
    public DateTime RAPOR_UZMAN_ONAY_ZAMANI { get; set; }

    /// <summary>Raporun kaydedildiÄŸi zaman bilgisidir.</summary>
    public DateTime? RAPOR_KAYIT_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual RADYOLOJI? RadyolojiNavigation { get; set; }
    public virtual REFERANS_KODLAR? RadyolojiRaporFormatiNavigation { get; set; }
    public virtual REFERANS_KODLAR? RaporTipiNavigation { get; set; }
    public virtual PERSONEL? RaporYazanPersonelNavigation { get; set; }
    public virtual PERSONEL? OnaylayanPersonel1Navigation { get; set; }
    public virtual PERSONEL? OnaylayanPersonel2Navigation { get; set; }
    public virtual PERSONEL? OnaylayanPersonel3Navigation { get; set; }
    #endregion

}
