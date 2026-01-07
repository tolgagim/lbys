using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// HASTA_DIS tablosu - 18 kolon
/// </summary>
[Table("HASTA_DIS")]
public class HASTA_DIS : VemEntity
{
    /// <summary>Hastaya uygulanan diÅŸ tedavi bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±n...</summary>
    [Key]
    public string HASTA_DIS_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>DiÅŸe uygulanan iÅŸlem tÃ¼rÃ¼dÃ¼r. Ã–rneÄŸin diagnoz, tedavi, planlama vb.</summary>
    [ForeignKey("DisIslemTuruNavigation")]
    public string DIS_ISLEM_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hastaya uygulanacak hizmetler iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi...</summary>
    [Required]
    [ForeignKey("HastaHizmetNavigation")]
    public string HASTA_HIZMET_KODU { get; set; }

    /// <summary>DiÅŸ tedavisi yapÄ±lan hastalar iÃ§in MEDULA sisteminden alÄ±nan taahhÃ¼t bilgilerini...</summary>
    [Required]
    [ForeignKey("DisTaahhutNavigation")]
    public string DIS_TAAHHUT_KODU { get; set; }

    /// <summary>HastanÄ±n mevcut diÅŸ durumunu ifade eder.</summary>
    [Required]
    [ForeignKey("MevcutDisDurumuNavigation")]
    public string MEVCUT_DIS_DURUMU { get; set; }

    /// <summary>AÄŸÄ±zdaki diÅŸler iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan verilmiÅŸ kod bilgis...</summary>
    [Required]
    [ForeignKey("DisNavigation")]
    public string DIS_KODU { get; set; }

    /// <summary>KiÅŸinin diÅŸ tedavisi iÃ§in iÅŸlem yapÄ±lan bÃ¶lge bilgisidir. Ã–rneÄŸin tÃ¼m Ã§ene bÃ¶lge...</summary>
    [Required]
    [ForeignKey("CeneBolgesiNavigation")]
    public string CENE_BOLGESI { get; set; }

    /// <summary>KiÅŸinin diÅŸ tedavisi iÃ§in iÅŸlem yapÄ±lan Ã§ene bÃ¶lgesinde bulunan diÅŸ bilgisidir.</summary>
    [Required]
    public string CENE_BOLGESI_DISLERI { get; set; }

    /// <summary>DiÅŸ protez tedavisi yapÄ±lan hastalar iÃ§in protez bilgilerini kayÄ±t etmek iÃ§in Sa...</summary>
    [Required]
    [ForeignKey("DisprotezNavigation")]
    public string DISPROTEZ_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta iÃ§in yapÄ±lan tÃ¼m iÅŸlemler iÃ§in MEDULA'dan SaÄŸlÄ±k Bilgi YÃ¶...</summary>
    [Required]
    public string SONUC_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta iÃ§in yapÄ±lan tÃ¼m iÅŸlemler iÃ§in MEDULA'dan SaÄŸlÄ±k Bilgi YÃ¶...</summary>
    [Required]
    public string SONUC_MESAJI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? DisIslemTuruNavigation { get; set; }
    public virtual HASTA_HIZMET? HastaHizmetNavigation { get; set; }
    public virtual DIS_TAAHHUT? DisTaahhutNavigation { get; set; }
    public virtual REFERANS_KODLAR? MevcutDisDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? DisNavigation { get; set; }
    public virtual REFERANS_KODLAR? CeneBolgesiNavigation { get; set; }
    public virtual DISPROTEZ? DisprotezNavigation { get; set; }
    #endregion

}
