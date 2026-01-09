using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// KULLANICI_GRUP tablosu - 9 kolon
/// </summary>
[Table("KULLANICI_GRUP")]
public class KULLANICI_GRUP : VemEntity
{
    /// <summary>SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi kullanÄ±cÄ±larÄ± iÃ§in tanÄ±mlanmÄ±ÅŸ SaÄŸlÄ±k Bilgi YÃ¶netim...</summary>
    [Key]
    public string KULLANICI_GRUP_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi kullanÄ±cÄ±larÄ±nÄ±n bulunduÄŸu grup adÄ± bilgisidir.</summary>
    public string KULLANICI_GRUP_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi veri tabanÄ±nda bulunan bir kayÄ±tÄ±n aktif olup olmad...</summary>
    public string AKTIFLIK_BILGISI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    #endregion

}
