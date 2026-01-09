using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// INTIHAR_IZLEM tablosu - 13 kolon
/// </summary>
[Table("INTIHAR_IZLEM")]
public class INTIHAR_IZLEM : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde tedavi olan hastalarÄ±n intihar/kriz izlem bilgileri iÃ§in SaÄŸlÄ±k...</summary>
    [Key]
    public string INTIHAR_IZLEM_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>VakanÄ±n intihar vakasÄ± ya da kriz vakasÄ± olma durumunu ifade eder.</summary>
    [ForeignKey("IntiharKrizVakaTuruNavigation")]
    public string INTIHAR_KRIZ_VAKA_TURU { get; set; }

    /// <summary>KiÅŸinin intihar giriÅŸimi ya da kriz nedenlerini ifade eder.</summary>
    [Required]
    [ForeignKey("IntiharGirisimKrizNedenleriNavigation")]
    public string INTIHAR_GIRISIM_KRIZ_NEDENLERI { get; set; }

    /// <summary>KiÅŸinin intihar giriÅŸimini gerÃ§ekleÅŸtirirken kullandÄ±ÄŸÄ± yÃ¶ntem/yÃ¶ntemleri ifade ...</summary>
    [ForeignKey("IntiharGirisimiYontemiNavigation")]
    public string INTIHAR_GIRISIMI_YONTEMI { get; set; }

    /// <summary>Ä°ntihar giriÅŸiminde bulunan ya da kriz geÃ§iren kiÅŸiye yapÄ±lan mÃ¼dahalenin nasÄ±l ...</summary>
    [ForeignKey("IntiharKrizVakaSonucuNavigation")]
    public string INTIHAR_KRIZ_VAKA_SONUCU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    /// <summary>Ä°ÅŸlemin gÃ¼ncellemesinin yapÄ±ldÄ±ÄŸÄ± tarih bilgisidir.</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? IntiharKrizVakaTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? IntiharGirisimKrizNedenleriNavigation { get; set; }
    public virtual REFERANS_KODLAR? IntiharGirisimiYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? IntiharKrizVakaSonucuNavigation { get; set; }
    #endregion

}
