using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// DOKTOR_MESAJI tablosu - 10 kolon
/// </summary>
[Table("DOKTOR_MESAJI")]
public class DOKTOR_MESAJI : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [Key]
    public string DOKTOR_MESAJI_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Hekim tarafÄ±ndan hastasÄ±na gÃ¶nderilen mesajlarÄ±n iÃ§eriÄŸine iliÅŸkin bilgiyi ifade...</summary>
    [Required]
    [ForeignKey("HastaMesajlariTuruNavigation")]
    public string HASTA_MESAJLARI_TURU { get; set; }

    /// <summary>Hekim tarafÄ±ndan hastasÄ±na gÃ¶nderilen mesajÄ±n detay bilgisidir.</summary>
    [Required]
    public string MESAJ_DETAYI { get; set; }

    /// <summary>Hekim tarafÄ±ndan hastasÄ±na gÃ¶nderilen mesajÄ±n tarih bilgisidir.</summary>
    public DateTime MESAJ_TARIHI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? HastaMesajlariTuruNavigation { get; set; }
    #endregion

}
