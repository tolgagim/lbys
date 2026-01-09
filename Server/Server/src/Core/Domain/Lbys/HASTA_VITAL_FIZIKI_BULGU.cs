using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// HASTA_VITAL_FIZIKI_BULGU tablosu - 23 kolon
/// </summary>
[Table("HASTA_VITAL_FIZIKI_BULGU")]
public class HASTA_VITAL_FIZIKI_BULGU : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde tedavi olan hastanÄ±n vital bulgularÄ± iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim ...</summary>
    [Key]
    public string HASTA_VITAL_FIZIKI_BULGU_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan iÅŸlemlerin, uygulanmaya baÅŸladÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime? ISLEM_ZAMANI { get; set; }

    /// <summary>Sistolik kan basÄ±ncÄ± (bÃ¼yÃ¼k tansiyon) bilgisini ifade eder.</summary>
    [Required]
    public string SISTOLIK_KAN_BASINCI_DEGERI { get; set; }

    /// <summary>Kan basÄ±ncÄ± Ã¶lÃ§me protokolÃ¼ne uygun olarak "mm Hg" birimi ile Ã¶lÃ§Ã¼len diastolik ...</summary>
    [Required]
    public string DIASTOLIK_KAN_BASINCI_DEGERI { get; set; }

    /// <summary>HastanÄ±n 1 dakikadaki atÄ±m sayÄ±sÄ± cinsinden nabÄ±z bilgisidir.</summary>
    [Required]
    public string NABIZ { get; set; }

    /// <summary>HastanÄ±n solunum bilgisidir.</summary>
    [Required]
    public string SOLUNUM { get; set; }

    /// <summary>KiÅŸinin santigrat cinsinden vÃ¼cut Ä±sÄ±sÄ± bilgisidir.</summary>
    [Required]
    public string ATES { get; set; }

    /// <summary>Bebek veya Ã§ocuÄŸun baÅŸ Ã§evresinin (santimetre cinsinden) Ã¶lÃ§Ã¼sÃ¼dÃ¼r.</summary>
    [Required]
    public string BAS_CEVRESI { get; set; }

    /// <summary>KiÅŸinin santimetre cinsinden boy bilgisidir.</summary>
    [Required]
    public string BOY { get; set; }

    /// <summary>KiÅŸinin (gram cinsinden) aÄŸÄ±rlÄ±ÄŸÄ±dÄ±r.</summary>
    [Required]
    public string AGIRLIK { get; set; }

    /// <summary>KiÅŸinin yÃ¼zde cinsinden oksijen saturasyonu bilgisini ifade eder.</summary>
    [Required]
    public string SATURASYON { get; set; }

    /// <summary>HastanÄ±n (santimetre cinsinden) bel Ã§evresidir.</summary>
    [Required]
    public string BEL_CEVRESI { get; set; }

    /// <summary>HastanÄ±n (santimetre cinsinden) kalÃ§a Ã§evresidir</summary>
    [Required]
    public string KALCA_CEVRESI { get; set; }

    /// <summary>HastanÄ±n santimetre cinsinden kol Ã§evresi Ã¶lÃ§Ã¼sÃ¼ bilgisidir.</summary>
    [Required]
    public string KOL_CEVRESI { get; set; }

    /// <summary>HastanÄ±n santimetre cinsinden karÄ±n Ã§evresi Ã¶lÃ§Ã¼sÃ¼ bilgisidir.</summary>
    [Required]
    public string KARIN_CEVRESI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli hemÅŸire iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [Required]
    [ForeignKey("HemsireNavigation")]
    public string HEMSIRE_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual PERSONEL? HemsireNavigation { get; set; }
    #endregion

}
