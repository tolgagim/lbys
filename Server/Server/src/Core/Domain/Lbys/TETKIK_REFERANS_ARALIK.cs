using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// TETKIK_REFERANS_ARALIK tablosu - 17 kolon
/// </summary>
[Table("TETKIK_REFERANS_ARALIK")]
public class TETKIK_REFERANS_ARALIK : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan tetkiklerdeki referans aralÄ±ÄŸÄ± deÄŸerleri iÃ§in SaÄŸlÄ±k Bi...</summary>
    [Key]
    public string TETKIK_REFERANS_ARALIK_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan tetkiklerdeki parametreler iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Si...</summary>
    [ForeignKey("TetkikParametreNavigation")]
    public string TETKIK_PARAMETRE_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan tetkikler iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan ...</summary>
    [ForeignKey("TetkikNavigation")]
    public string TETKIK_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan cihaz iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼ret...</summary>
    [Required]
    [ForeignKey("CihazNavigation")]
    public string CIHAZ_KODU { get; set; }

    /// <summary>Laboratuvar tetkiklerinin karar sÄ±nÄ±rÄ± deÄŸerlerinin hangi cinsiyete gÃ¶re yapÄ±ldÄ±...</summary>
    [ForeignKey("TetkikCinsiyetNavigation")]
    public string TETKIK_CINSIYET { get; set; }

    /// <summary>Tetkik sonuÃ§ aralÄ±ÄŸÄ±nÄ±n geÃ§erli olduÄŸu yaÅŸ aralÄ±ÄŸÄ±nÄ±n gÃ¼n cinsinden baÅŸlangÄ±Ã§ bi...</summary>
    public string YAS_ARALIGI_BASLANGIC_GUN { get; set; }

    /// <summary>Tetkik sonuÃ§ aralÄ±ÄŸÄ±nÄ±n geÃ§erli olduÄŸu yaÅŸ aralÄ±ÄŸÄ±nÄ±n gÃ¼n cinsinden bitiÅŸ bilgis...</summary>
    public string YAS_ARALIGI_BITIS_GUN { get; set; }

    /// <summary>Tetkik sonuÃ§larÄ± iÃ§in referans aralÄ±ÄŸÄ±nÄ±n baÅŸlangÄ±Ã§ deÄŸeri (minimum) bilgisidir.</summary>
    [Required]
    public string REFERANS_BASLANGIC_DEGERI { get; set; }

    /// <summary>Tetkik sonuÃ§lari iÃ§in referans araliginin bitis degeri bilgisidir.</summary>
    [Required]
    public string REFERANS_BITIS_DEGERI { get; set; }

    /// <summary>TÄ±bbi laboratuvar testinde, hasta iÃ§in risk oluÅŸturabilecek durumlarda en kÄ±sa z...</summary>
    [Required]
    public string ALT_KRITIK_DEGER { get; set; }

    /// <summary>TÄ±bbi laboratuvar testinde, hasta iÃ§in risk oluÅŸturabilecek durumlarda en kÄ±sa z...</summary>
    [Required]
    public string UST_KRITIK_DEGER { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual TETKIK_PARAMETRE? TetkikParametreNavigation { get; set; }
    public virtual TETKIK? TetkikNavigation { get; set; }
    public virtual CIHAZ? CihazNavigation { get; set; }
    public virtual REFERANS_KODLAR? TetkikCinsiyetNavigation { get; set; }
    #endregion

}
