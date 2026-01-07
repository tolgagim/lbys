using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// ILAC_UYUM tablosu - 17 kolon
/// </summary>
[Table("ILAC_UYUM")]
public class ILAC_UYUM : VemEntity
{
    /// <summary>Hastaya verilen ilaÃ§lar arasÄ±nda uyum bilgisi iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi ...</summary>
    [Key]
    public string ILAC_UYUM_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Hastaya verilen ilaÃ§lar arasÄ±nda tespit edilen uyumsuzluk iÃ§in yapÄ±lan sÄ±nÄ±fland...</summary>
    [ForeignKey("IlacUyumsuzlukTuruNavigation")]
    public string ILAC_UYUMSUZLUK_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde birlikte kullanÄ±lan ilaÃ§lar arasÄ±nda etkileÅŸim durumu sorgulama...</summary>
    [Required]
    [ForeignKey("BirinciIlacBarkoduNavigation")]
    public string BIRINCI_ILAC_BARKODU { get; set; }

    /// <summary>Ä°lacÄ±n iÃ§eriÄŸinde bulunan etken maddeler iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi taraf...</summary>
    [Required]
    [ForeignKey("BirinciEtkenMaddeNavigation")]
    public string BIRINCI_ETKEN_MADDE_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde birlikte kullanÄ±lan ilaÃ§lar arasÄ±nda etkileÅŸim durumu sorgulama...</summary>
    [Required]
    [ForeignKey("IkinciIlacBarkoduNavigation")]
    public string IKINCI_ILAC_BARKODU { get; set; }

    /// <summary>Ä°lacÄ±n iÃ§eriÄŸinde bulunan etken maddeler iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi taraf...</summary>
    [Required]
    [ForeignKey("IkinciEtkenMaddeNavigation")]
    public string IKINCI_ETKEN_MADDE_KODU { get; set; }

    /// <summary>Ä°laÃ§larla, besinlerle etkileÅŸebilecek veya alerji yapabilecek besin tanÄ±mlarÄ± iÃ§...</summary>
    [Required]
    [ForeignKey("BesinNavigation")]
    public string BESIN_KODU { get; set; }

    /// <summary>YaÅŸ baÅŸlangÄ±cÄ±nÄ±n gÃ¼n cinsinden deÄŸer bilgisidir.</summary>
    [Required]
    public string YAS_BASLANGIC { get; set; }

    /// <summary>YaÅŸ bitiÅŸinin gÃ¼n cinsinden deÄŸer bilgisidir</summary>
    [Required]
    public string YAS_BITIS { get; set; }

    /// <summary>KiÅŸinin cinsiyetini ifade eder.</summary>
    [Required]
    [ForeignKey("CinsiyetNavigation")]
    public string CINSIYET { get; set; }

    /// <summary>Ä°laÃ§ ile ilgili uyarÄ±larÄ± verebilmek iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±nda...</summary>
    [ForeignKey("RenkSeviyeNavigation")]
    public string RENK_SEVIYE_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual REFERANS_KODLAR? IlacUyumsuzlukTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? BirinciIlacBarkoduNavigation { get; set; }
    public virtual REFERANS_KODLAR? BirinciEtkenMaddeNavigation { get; set; }
    public virtual REFERANS_KODLAR? IkinciIlacBarkoduNavigation { get; set; }
    public virtual REFERANS_KODLAR? IkinciEtkenMaddeNavigation { get; set; }
    public virtual REFERANS_KODLAR? BesinNavigation { get; set; }
    public virtual REFERANS_KODLAR? CinsiyetNavigation { get; set; }
    public virtual REFERANS_KODLAR? RenkSeviyeNavigation { get; set; }
    #endregion

}
