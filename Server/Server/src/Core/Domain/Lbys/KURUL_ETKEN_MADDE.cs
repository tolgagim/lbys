using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// KURUL_ETKEN_MADDE tablosu - 13 kolon
/// </summary>
[Table("KURUL_ETKEN_MADDE")]
public class KURUL_ETKEN_MADDE : VemEntity
{
    /// <summary>Hasta iÃ§in verilen saÄŸlÄ±k raporunda bulunan ilaÃ§larÄ±n etken madde bilgileri iÃ§in...</summary>
    [Key]
    public string KURUL_ETKEN_MADDE_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>Hastaya saÄŸlÄ±k raporu veren kurul iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("KurulRaporNavigation")]
    public string KURUL_RAPOR_KODU { get; set; }

    /// <summary>Ä°lacÄ±n iÃ§eriÄŸinde bulunan etken maddeler iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi taraf...</summary>
    public string ILAC_ETKEN_MADDE_KODU { get; set; }

    /// <summary>Ä°lacÄ±n gÃ¼nde kaÃ§ kez kullanÄ±lacaÄŸÄ± bilgisidir. Ã–rneÄŸin 3 yazÄ±lmÄ±ÅŸsa periyot biri...</summary>
    [Required]
    public string DOZ_SAYISI { get; set; }

    /// <summary>HastanÄ±n bir seferde kullanÄ±lacaÄŸÄ± ilacÄ±n miktar bilgisidir.</summary>
    [Required]
    public string DOZ_MIKTARI { get; set; }

    /// <summary>Bir ilacÄ±n, hastaya tek seferde verilebilecek miktarÄ± iÃ§in Ã¶lÃ§Ã¼ bilgisidir.</summary>
    [Required]
    [ForeignKey("DozBirimNavigation")]
    public string DOZ_BIRIM { get; set; }

    /// <summary>Ä°lacÄ±n kullanÄ±m periyodunu ifade eder.</summary>
    [Required]
    public string ILAC_KULLANIM_PERIYODU { get; set; }

    /// <summary>Ä°lacÄ±n hangi periyot biriminde kullanÄ±lacaÄŸÄ±nÄ± ifade eder.</summary>
    [Required]
    [ForeignKey("IlacPeriyotBirimiNavigation")]
    public string ILAC_PERIYOT_BIRIMI { get; set; }

    /// <summary>Kurul etken madde bilgisinin ilk kayÄ±t edildiÄŸi zaman bilgisidir.</summary>

    #region Navigation Properties
    public virtual KURUL_RAPOR? KurulRaporNavigation { get; set; }
    public virtual REFERANS_KODLAR? DozBirimNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlacPeriyotBirimiNavigation { get; set; }
    #endregion

}
