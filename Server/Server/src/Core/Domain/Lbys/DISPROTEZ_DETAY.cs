using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// DISPROTEZ_DETAY tablosu - 21 kolon
/// </summary>
[Table("DISPROTEZ_DETAY")]
public class DISPROTEZ_DETAY : VemEntity
{
    /// <summary>DiÅŸ protez tedavisi yapÄ±lan hastalar iÃ§in protez aÅŸamalarÄ±na iliÅŸkin detaylÄ± bil...</summary>
    [Key]
    public string DISPROTEZ_DETAY_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>DiÅŸ protez tedavisi yapÄ±lan hastalar iÃ§in protez bilgilerini kayÄ±t etmek iÃ§in Sa...</summary>
    [ForeignKey("DisprotezNavigation")]
    public string DISPROTEZ_KODU { get; set; }

    /// <summary>DiÅŸ protezi tedavisinin ne zaman uygulanacaÄŸÄ±na iliÅŸkin planlanan zaman bilgisid...</summary>
    public DateTime? DISPROTEZ_PLANLAMA_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hastaya uygulanan diÅŸ protezinin aÅŸamalarÄ±nÄ± belirten SaÄŸlÄ±k Bi...</summary>
    [ForeignKey("DisprotezIsTuruAsamaNavigation")]
    public string DISPROTEZ_IS_TURU_ASAMA_KODU { get; set; }

    /// <summary>Hastaya uygulanan protez iÅŸleminin ilgili aÅŸamasÄ±nÄ±n tamamlanma zamanÄ± bilgisidi...</summary>
    public DateTime DISPROTEZ_ASAMA_BITIS_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinin mal veya hizmet alÄ±mÄ± yaptÄ±ÄŸÄ± firma iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim S...</summary>
    [Required]
    [ForeignKey("FirmaNavigation")]
    public string FIRMA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hastaya uygulanan diÅŸ protez tedavisi sÃ¼recinde, saÄŸlÄ±k tesisi ...</summary>
    public DateTime FIRMA_DISPROTEZ_ALIM_ZAMANI { get; set; }

    /// <summary>Hasta tedavi sÃ¼recinde yapÄ±lmasÄ± planlanan tedavi uygulamasÄ±nÄ±n bitirilmesi iÃ§in...</summary>
    public DateTime PLANLANAN_BITIS_TARIHI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hastaya uygulanan diÅŸ protez tedavisi sÃ¼recinde, saÄŸlÄ±k tesisi ...</summary>
    public DateTime FIRMA_TESLIM_ZAMANI { get; set; }

    /// <summary>DiÅŸ protezi aÅŸamalarÄ± iÃ§in sÃ¼recin tamamlandÄ±ÄŸÄ±na iliÅŸkin verilen onay zamanÄ± bi...</summary>
    public DateTime DISPROTEZ_ASAMA_ONAY_ZAMANI { get; set; }

    /// <summary>Rise Per Tooth (RPT); Teslim aÅŸamasÄ±na gelmiÅŸ protezin kabul kriterlerine uymama...</summary>
    [Required]
    public string RPT_ONAY_DURUMU { get; set; }

    /// <summary>KiÅŸi iÃ§in dÃ¼zenlenen randevu bilgisi iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±nda...</summary>
    [Required]
    [ForeignKey("RandevuNavigation")]
    public string RANDEVU_KODU { get; set; }

    /// <summary>Protez diÅŸin herhangi bir aÅŸamasÄ±nda kabul kriterlerine uymamasÄ± sonucu, protez ...</summary>
    public DateTime ASAMA_RPT_ZAMANI { get; set; }

    /// <summary>Protez diÅŸin herhangi bir aÅŸamasÄ±nda kabul kriterlerine uymamasÄ± bilgisidir. Ã–rn...</summary>
    [Required]
    [ForeignKey("AsamaRptSebebiNavigation")]
    public string ASAMA_RPT_SEBEBI { get; set; }

    /// <summary>Protez diÅŸin herhangi bir aÅŸamasÄ±nda kabul kriterlerine uymamasÄ± sonucu, protez ...</summary>
    [Required]
    [ForeignKey("AsamaRptKullaniciNavigation")]
    public string ASAMA_RPT_KULLANICI_KODU { get; set; }

    /// <summary>DiÅŸ protezi tedavisinde hastadan Ã¶lÃ§Ã¼ alÄ±nma aÅŸamasÄ±nda, Ã¶lÃ§Ã¼ dÃ¶kÃ¼m zamanÄ± bilgi...</summary>
    public DateTime OLCU_DOKUM_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual DISPROTEZ? DisprotezNavigation { get; set; }
    public virtual REFERANS_KODLAR? DisprotezIsTuruAsamaNavigation { get; set; }
    public virtual FIRMA? FirmaNavigation { get; set; }
    public virtual RANDEVU? RandevuNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsamaRptSebebiNavigation { get; set; }
    public virtual KULLANICI? AsamaRptKullaniciNavigation { get; set; }
    #endregion

}
