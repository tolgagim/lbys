using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// PERSONEL_ODUL_CEZA tablosu - 16 kolon
/// </summary>
[Table("PERSONEL_ODUL_CEZA")]
public class PERSONEL_ODUL_CEZA : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personel iÃ§in saÄŸlÄ±k tesisi idaresi tarafÄ±ndan verilen ...</summary>
    [Key]
    public string PERSONEL_ODUL_CEZA_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisi idaresi tarafÄ±ndan personele verilen Ã¶dÃ¼l veya ceza iÃ§in durum bil...</summary>
    public string ODUL_CEZA_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisi idaresi tarafÄ±ndan personele verilen Ã¶dÃ¼l veya cezanÄ±n ikramiye, k...</summary>
    [ForeignKey("OdulCezaTuruNavigation")]
    public string ODUL_CEZA_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele verilen cezanÄ±n baÅŸladÄ±ÄŸÄ± tarih bilgisidir.</summary>
    public DateTime CEZA_BASLANGIC_TARIHI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele verilen cezanÄ±n bittiÄŸi tarih bilgisidir.</summary>
    public DateTime CEZA_BITIS_TARIHI { get; set; }

    /// <summary>SaÄŸlÄ±k personeline Ã¶dÃ¼l veya ceza veren kurum kodu bilgisidir.</summary>
    [ForeignKey("OdulCezaVerenKurumNavigation")]
    public string ODUL_CEZA_VEREN_KURUM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisi idaresi tarafÄ±ndan personele verilen Ã¶dÃ¼l veya cezaya ait aÃ§Ä±klama...</summary>
    [Required]
    public string ODUL_CEZA_ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde personele verilen Ã¶dÃ¼l veya cezanÄ±n personele tebliÄŸ edildiÄŸi t...</summary>
    public DateTime? TEBLIG_TARIHI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele tebliÄŸ edilen evrakÄ±n dÃ¼zenlendiÄŸi tarih bilg...</summary>
    public DateTime TEBLIG_EVRAK_TARIHI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele tebliÄŸ edilen evrakÄ±n numara bilgisidir.</summary>
    [Required]
    public string TEBLIG_EVRAK_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual PERSONEL? PersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? OdulCezaTuruNavigation { get; set; }
    public virtual KURUM? OdulCezaVerenKurumNavigation { get; set; }
    #endregion

}
