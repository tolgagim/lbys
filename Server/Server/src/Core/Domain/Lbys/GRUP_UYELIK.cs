using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// GRUP_UYELIK tablosu - 8 kolon
/// </summary>
[Table("GRUP_UYELIK")]
public class GRUP_UYELIK : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personel arasÄ±ndan SaÄŸlÄ±k Bilgi YÃ¶netim Sistemini kulla...</summary>
    [Key]
    public string GRUP_UYELIK_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi kullanÄ±cÄ±larÄ± iÃ§in tanÄ±mlanmÄ±ÅŸ SaÄŸlÄ±k Bilgi YÃ¶netim...</summary>
    [ForeignKey("KullaniciGrupNavigation")]
    public string KULLANICI_GRUP_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k Bilgi YÃ¶netim Sistemini kullanan personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Siste...</summary>
    [ForeignKey("KullaniciNavigation")]
    public string KULLANICI_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual KULLANICI_GRUP? KullaniciGrupNavigation { get; set; }
    public virtual KULLANICI? KullaniciNavigation { get; set; }
    #endregion

}
