using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// HASTA_UYARI tablosu - 13 kolon
/// </summary>
[Table("HASTA_UYARI")]
public class HASTA_UYARI : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hasta iÃ§in personele yapÄ±lmasÄ± gereken uyarÄ±lar iÃ§in Sa...</summary>
    [Key]
    public string HASTA_UYARI_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan bir iÅŸlem, kiÅŸiye uygulanan tedavi, verilen ilaÃ§ vb. du...</summary>
    [ForeignKey("UyariTuruNavigation")]
    public string UYARI_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavi olan hastaya yapÄ±lacak her hangi bir iÅŸlemin yapÄ±lmasÄ± i...</summary>
    public string ISLEME_IZIN_VERME_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran kiÅŸi iÃ§in yapÄ±lmasÄ± planlanan uyarÄ±larÄ±n baÅŸlamasÄ± gere...</summary>
    public DateTime? HASTA_UYARI_BASLAMA_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran kiÅŸi iÃ§in yapÄ±lmasÄ± planlanan uyarÄ±larÄ±n bitmesi gereke...</summary>
    public DateTime HASTA_UYARI_BITIS_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? UyariTuruNavigation { get; set; }
    #endregion

}
