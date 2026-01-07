using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// STOK_ISTEK_UYGULAMA tablosu - 15 kolon
/// </summary>
[Table("STOK_ISTEK_UYGULAMA")]
public class STOK_ISTEK_UYGULAMA : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde hekim tarafÄ±ndan yapÄ±lan istemin (order) uygulama bilgilerine e...</summary>
    [Key]
    public string STOK_ISTEK_UYGULAMA_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta iÃ§in depodan yapÄ±lan isteklerin detay bilgilerine eriÅŸim ...</summary>
    [ForeignKey("StokIstekHareketNavigation")]
    public string STOK_ISTEK_HAREKET_KODU { get; set; }

    /// <summary>Order'Ä±n hastaya uygulanma zamanÄ±na iliÅŸkin planlanan zaman bilgisidir.</summary>
    public DateTime? ORDER_PLANLANAN_ZAMAN { get; set; }

    /// <summary>Orderâ€™Ä±n hastaya uygulandÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime ORDER_UYGULANAN_ZAMAN { get; set; }

    /// <summary>Hekim tarafÄ±ndan yapÄ±lan istemi (order) uygulayan hemÅŸireye ait SaÄŸlÄ±k Bilgi YÃ¶n...</summary>
    [Required]
    [ForeignKey("UygulayanHemsireNavigation")]
    public string UYGULAYAN_HEMSIRE_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavi gÃ¶ren hastaya ait istemin iptal edilmesine iliÅŸkin bilgi...</summary>
    [Required]
    [ForeignKey("IstekIptalNedeniNavigation")]
    public string ISTEK_IPTAL_NEDENI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lmasÄ± planlanan bir tedavi iÅŸlemini iptal eden hemÅŸire bilg...</summary>
    [Required]
    [ForeignKey("IptalEdenHemsireNavigation")]
    public string IPTAL_EDEN_HEMSIRE_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin iptal edildiÄŸi zaman bilgisidir.</summary>
    public DateTime IPTAL_ZAMANI { get; set; }

    /// <summary>Hekim tarafÄ±ndan yapÄ±lan istemde (orderâ€™Ä±n) miktar bilgisi olmasÄ± durumunda iste...</summary>
    [Required]
    public string UYGULANAN_MIKTAR { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual STOK_ISTEK_HAREKET? StokIstekHareketNavigation { get; set; }
    public virtual PERSONEL? UygulayanHemsireNavigation { get; set; }
    public virtual REFERANS_KODLAR? IstekIptalNedeniNavigation { get; set; }
    public virtual PERSONEL? IptalEdenHemsireNavigation { get; set; }
    #endregion

}
