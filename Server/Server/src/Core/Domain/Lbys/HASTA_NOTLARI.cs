using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// HASTA_NOTLARI tablosu - 11 kolon
/// </summary>
[Table("HASTA_NOTLARI")]
public class HASTA_NOTLARI : VemEntity
{
    /// <summary>Hastaya Ã¶zgÃ¼ girilen not iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼retilen t...</summary>
    [Key]
    public string HASTA_NOTLARI_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Hastaya Ã¶zgÃ¼ girilen notun SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan belirlenmiÅŸ g...</summary>
    public string HASTA_NOT_TURU { get; set; }

    /// <summary>Hastaya Ã¶zgÃ¼ girilen notu yazan personel iÃ§in SBYS tarafÄ±ndan tanÄ±mlanmÄ±ÅŸ kod bi...</summary>
    public string PERSONEL_KODU { get; set; }

    /// <summary>Hastaya Ã¶zgÃ¼ girilen not iÃ§in yazÄ±lan aÃ§Ä±klama bilgisini ifade eder.</summary>
    public string HASTA_NOT_ACIKLAMASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    #endregion

}
