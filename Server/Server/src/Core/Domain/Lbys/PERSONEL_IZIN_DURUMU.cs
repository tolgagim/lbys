using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// PERSONEL_IZIN_DURUMU tablosu - 6 kolon
/// </summary>
[Table("PERSONEL_IZIN_DURUMU")]
public class PERSONEL_IZIN_DURUMU : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin izin durumu bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶ne...</summary>
    [Key]
    public string PERSONEL_IZIN_DURUMU_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin kalan izin gÃ¼n sayÄ±sÄ± bilgisidir.</summary>
    public string KALAN_IZIN { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin Ã§alÄ±ÅŸtÄ±ÄŸÄ± yÄ±l iÃ§in hak ettiÄŸi izin gÃ¼n sayÄ±s...</summary>
    public string YILLIK_IZIN_HAKKI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin kullandÄ±ÄŸÄ± iznin hangi yÄ±la ait olduÄŸu bilgi...</summary>
    public string PERSONEL_IZIN_YILI { get; set; }

    #region Navigation Properties
    public virtual PERSONEL? PersonelNavigation { get; set; }
    #endregion

}
