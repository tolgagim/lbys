using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// TIBBI_ORDER tablosu - 13 kolon
/// </summary>
[Table("TIBBI_ORDER")]
public class TIBBI_ORDER : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde saÄŸlÄ±k hizmetini alan kiÅŸi iÃ§in hekim istemi (order) iÃ§in SaÄŸlÄ±...</summary>
    [Key]
    public string TIBBI_ORDER_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde saÄŸlÄ±k hizmetini alan kiÅŸi iÃ§in hekim isteminin (order) tÃ¼r bil...</summary>
    [ForeignKey("TibbiOrderTuruNavigation")]
    public string TIBBI_ORDER_TURU { get; set; }

    /// <summary>Hekimin orderâ€™Ä± verme zamanÄ± bilgisidir.</summary>
    public DateTime? ORDER_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? TibbiOrderTuruNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    #endregion

}
