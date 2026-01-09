using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// KLINIK_SEYIR tablosu - 14 kolon
/// </summary>
[Table("KLINIK_SEYIR")]
public class KLINIK_SEYIR : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde tedavi alan hastanÄ±n seyir bilgileri (gÃ¼nlÃ¼k epikriz bilgileri)...</summary>
    [Key]
    public string KLINIK_SEYIR_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>HastanÄ±n tedavisinin seyiri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan yapÄ±lan...</summary>
    [ForeignKey("SeyirTipiNavigation")]
    public string SEYIR_TIPI { get; set; }

    /// <summary>HastanÄ±n tedavisinin seyir bilgisinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine girildiÄŸi z...</summary>
    public DateTime? SEYIR_ZAMANI { get; set; }

    /// <summary>HastanÄ±n tedavisi iÃ§in hekimlerin yazdÄ±ÄŸÄ± gÃ¼nlÃ¼k seyir bilgisini ifade eder.</summary>
    [Required]
    public string SEYIR_BILGISI { get; set; }

    /// <summary>HastanÄ±n septik ÅŸok durumuna iliÅŸkin bilgidir.</summary>
    [Required]
    [ForeignKey("SeptikSokNavigation")]
    public string SEPTIK_SOK { get; set; }

    /// <summary>HastanÄ±n sepsis durumuna iliÅŸkin bilgidir.</summary>
    [Required]
    [ForeignKey("SepsisDurumuNavigation")]
    public string SEPSIS_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli hekim iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼ret...</summary>
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? SeyirTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SeptikSokNavigation { get; set; }
    public virtual REFERANS_KODLAR? SepsisDurumuNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    #endregion

}
