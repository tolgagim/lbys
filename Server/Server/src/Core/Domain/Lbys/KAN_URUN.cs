using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// KAN_URUN tablosu - 20 kolon
/// </summary>
[Table("KAN_URUN")]
public class KAN_URUN : VemEntity
{
    /// <summary>Kan Ã¼rÃ¼nÃ¼ iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼retilen tekil kod bilgis...</summary>
    [Key]
    public string KAN_URUN_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>Kan Ã¼rÃ¼nÃ¼n adÄ± bilgisidir.</summary>
    public string KAN_URUN_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hastaya uygulanan iÅŸlemler iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi ta...</summary>
    [ForeignKey("HizmetNavigation")]
    public string HIZMET_KODU { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼nÃ¼n gÃ¼n cinsinden miat sÃ¼resi bilgisidir.</summary>
    public string KAN_MIAT_SURESI { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼nÃ¼n gÃ¼n, yÄ±l, saat cinsinden miat periyot bilgisidir.</summary>
    [Required]
    public string KAN_MIAT_PERIYODU { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼ iÃ§in KÄ±zÄ±lay entegrasyonu iÃ§in KÄ±zÄ±lay bileÅŸen tÃ¼rÃ¼ eÅŸleÅŸtirmesinde ku...</summary>
    [Required]
    public string KIZILAY_BILESEN_TURU { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼nÃ¼n filtreleme iÅŸlemi iÃ§in uygun olup olmadÄ±ÄŸÄ±nÄ± ifade eden bilgidir.</summary>
    [Required]
    public string KAN_FILTRELEME_UYGUNLUK { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kullanÄ±lacak Ã¼rÃ¼nÃ¼n yÄ±kama iÅŸlemi iÃ§in uygun olma durumuna iliÅŸ...</summary>
    [Required]
    public string KAN_YIKAMA_UYGUNLUK_DURUMU { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼nÃ¼n Ä±ÅŸÄ±nlanma iÅŸlemine uygunluk durumuna iliÅŸkin bilgiyi ifade eder.</summary>
    [Required]
    public string KAN_ISINLAMA_UYGUNLUK_DURUMU { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼nÃ¼n havuzlama iÅŸlemi iÃ§in uygunluk durumuna iliÅŸkin bilgiyi ifade eder.</summary>
    [Required]
    public string KAN_HAVUZLAMA_UYGUNLUK { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼nÃ¼n ayÄ±rma iÅŸlemine uygunluk durumunu ifade eder.</summary>
    [Required]
    public string KAN_AYIRMA_UYGUNLUK { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼nÃ¼n bÃ¶lme iÅŸlemi iÃ§in uygunluk durumuna iliÅŸkin bilgiyi ifade eder.</summary>
    [Required]
    public string KAN_BOLME_UYGUNLUK { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼nÃ¼n Buffy Coat uzaklaÅŸtÄ±rma iÅŸlemi iÃ§in uygunluk durumunu ifade eder.</summary>
    [Required]
    public string BUFFYCOAT_UZAKLASTIRMAYA_UYGUN { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    /// <summary>Ä°ÅŸlemin gÃ¼ncellemesinin yapÄ±ldÄ±ÄŸÄ± tarih bilgisidir.</summary>

    #region Navigation Properties
    public virtual HIZMET? HizmetNavigation { get; set; }
    #endregion

}
