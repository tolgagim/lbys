using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// PERSONEL_YANDAL tablosu - 10 kolon
/// </summary>
[Table("PERSONEL_YANDAL")]
public class PERSONEL_YANDAL : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin yan dal bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim ...</summary>
    [Key]
    public string PERSONEL_YANDAL_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin yan dal eÄŸitimine baÅŸladÄ±ÄŸÄ± tarih bilgisidir...</summary>
    public DateTime? YANDAL_BASLANGIC_TARIHI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin yan dal eÄŸitiminin bitiÅŸ tarih bilgisidir.</summary>
    public DateTime YANDAL_BITIS_TARIHI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan klinik ve hekimler iÃ§in MEDULA tarafÄ±ndan tanÄ±mlanmÄ±ÅŸ b...</summary>
    public string MEDULA_BRANS_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual PERSONEL? PersonelNavigation { get; set; }
    #endregion

}
