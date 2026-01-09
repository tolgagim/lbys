using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// ANLIK_YATAN_HASTA tablosu - 10 kolon
/// </summary>
[Table("ANLIK_YATAN_HASTA")]
public class ANLIK_YATAN_HASTA : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde anlÄ±k yatan hastalarÄ±n bilgisine eriÅŸim saÄŸlamak iÃ§in SaÄŸlÄ±k Bi...</summary>
    [Key]
    public string ANLIK_YATAN_HASTA_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli hekim iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼ret...</summary>
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }

    /// <summary>Hasta yatÄ±ÅŸ iÅŸlemi yapÄ±lÄ±rken SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan online pro...</summary>
    public string YATIS_PROTOKOL_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan bÃ¶lÃ¼mler iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("BirimNavigation")]
    public string BIRIM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan saÄŸlÄ±k tesisindeki yataklar iÃ§in Ã¼retile...</summary>
    [Required]
    [ForeignKey("YatakNavigation")]
    public string YATAK_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan oda iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼retil...</summary>
    [Required]
    [ForeignKey("OdaNavigation")]
    public string ODA_KODU { get; set; }

    /// <summary>HastanÄ±n saÄŸlÄ±k tesisinde yataÄŸa yattÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime? YATIS_ZAMANI { get; set; }

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual BIRIM? BirimNavigation { get; set; }
    public virtual YATAK? YatakNavigation { get; set; }
    public virtual ODA? OdaNavigation { get; set; }
    #endregion

}
