using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// HASTA_VENTILATOR tablosu - 12 kolon
/// </summary>
[Table("HASTA_VENTILATOR")]
public class HASTA_VENTILATOR : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde bulunan ventilatÃ¶rlerin kullanÄ±m bilgisi iÃ§in SaÄŸlÄ±k Bilgi YÃ¶ne...</summary>
    [Key]
    public string HASTA_VENTILATOR_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki tÄ±bbi cihazlar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("VentilatorCihazNavigation")]
    public string VENTILATOR_CIHAZ_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan yoÄŸun bakÄ±m yatak seviyesi bilgisidir. Ã–rneÄŸin 1.seviye...</summary>
    [Required]
    [ForeignKey("YogunBakimSeviyeBilgisiNavigation")]
    public string YOGUN_BAKIM_SEVIYE_BILGISI { get; set; }

    /// <summary>HastanÄ±n ventilatÃ¶re ilk baÄŸlandÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime? VENTILATOR_BAGLAMA_ZAMANI { get; set; }

    /// <summary>HastanÄ±n ventilatÃ¶rden ayrÄ±ldÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime VENTILATOR_AYRILMA_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual CIHAZ? VentilatorCihazNavigation { get; set; }
    public virtual REFERANS_KODLAR? YogunBakimSeviyeBilgisiNavigation { get; set; }
    #endregion

}
