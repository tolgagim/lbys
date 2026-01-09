using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// HASTA_TIBBI_BILGI tablosu - 11 kolon
/// </summary>
[Table("HASTA_TIBBI_BILGI")]
public class HASTA_TIBBI_BILGI : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde tedavi olan hastaya ait tÃ¼m tÄ±bbi bilgiler iÃ§in SaÄŸlÄ±k Bilgi YÃ¶...</summary>
    [Key]
    public string HASTA_TIBBI_BILGI_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde saÄŸlÄ±k hizmetini alan kiÅŸinin tÄ±bbi bilgisinin tÃ¼r bilgisidir. ...</summary>
    [ForeignKey("TibbiBilgiTuruNavigation")]
    public string TIBBI_BILGI_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde saÄŸlÄ±k hizmetini alan kiÅŸinin tÄ±bbi bilgisinin alt tÃ¼r bilgisid...</summary>
    [ForeignKey("TibbiBilgiAltTuruNavigation")]
    public string TIBBI_BILGI_ALT_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? TibbiBilgiTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? TibbiBilgiAltTuruNavigation { get; set; }
    #endregion

}
