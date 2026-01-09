using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// TIBBI_ORDER_DETAY tablosu - 16 kolon
/// </summary>
[Table("TIBBI_ORDER_DETAY")]
public class TIBBI_ORDER_DETAY : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde saÄŸlÄ±k hizmetini alan kiÅŸi iÃ§in hekim isteminin (order) detay b...</summary>
    [Key]
    public string TIBBI_ORDER_DETAY_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde saÄŸlÄ±k hizmetini alan kiÅŸi iÃ§in hekim istemi (order) iÃ§in SaÄŸlÄ±...</summary>
    [ForeignKey("TibbiOrderNavigation")]
    public string TIBBI_ORDER_KODU { get; set; }

    /// <summary>Orderâ€™Ä±n hastaya hangi saatte uygulanacaÄŸÄ±nÄ± belirten zaman bilgisidir.</summary>
    public DateTime? PLANLANAN_UYGULANMA_ZAMANI { get; set; }

    /// <summary>Hekim tarafÄ±ndan yapÄ±lan istemi (order) uygulayan hemÅŸireye ait SaÄŸlÄ±k Bilgi YÃ¶n...</summary>
    [Required]
    [ForeignKey("UygulayanHemsireNavigation")]
    public string UYGULAYAN_HEMSIRE_KODU { get; set; }

    /// <summary>Hekim tarafÄ±ndan yapÄ±lan istemin (orderâ€™Ä±n) uygulandÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime UYGULAMA_ZAMANI { get; set; }

    /// <summary>Hekim tarafÄ±ndan yapÄ±lan istem (order) iÃ§in gereken iÅŸlemin hastaya uygulanma du...</summary>
    public string UYGULANMA_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde saÄŸlÄ±k hizmetini alan kiÅŸi iÃ§in hekim istemi (order) iptal edil...</summary>
    [Required]
    [ForeignKey("TibbiOrderIptalNedeniNavigation")]
    public string TIBBI_ORDER_IPTAL_NEDENI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lmasÄ± planlanan bir tedavi iÅŸlemini iptal eden hemÅŸire bilg...</summary>
    [Required]
    [ForeignKey("IptalEdenHemsireNavigation")]
    public string IPTAL_EDEN_HEMSIRE_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin iptal edildiÄŸi zaman bilgisidir.</summary>
    public DateTime IPTAL_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual TIBBI_ORDER? TibbiOrderNavigation { get; set; }
    public virtual PERSONEL? UygulayanHemsireNavigation { get; set; }
    public virtual REFERANS_KODLAR? TibbiOrderIptalNedeniNavigation { get; set; }
    public virtual PERSONEL? IptalEdenHemsireNavigation { get; set; }
    #endregion

}
