using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// KONSULTASYON tablosu - 15 kolon
/// </summary>
[Table("KONSULTASYON")]
public class KONSULTASYON : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde tedavi alan hastanÄ±n konsÃ¼ltasyon bilgileri iÃ§in SaÄŸlÄ±k Bilgi Y...</summary>
    [Key]
    public string KONSULTASYON_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hastaya uygulanacak hizmetler iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi...</summary>
    [ForeignKey("HastaHizmetNavigation")]
    public string HASTA_HIZMET_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde konsÃ¼ltasyon yapÄ±lmasÄ± amacÄ±yla aÃ§Ä±lan yeni bir hasta baÅŸvuru k...</summary>
    [Required]
    [ForeignKey("KonsultasyonBasvuruNavigation")]
    public string KONSULTASYON_BASVURU_KODU { get; set; }

    /// <summary>KonsÃ¼ltasyon isteÄŸinde bulunan hekimin yazdÄ±ÄŸÄ± istek notu bilgisidir.</summary>
    [Required]
    public string KONSULTASYON_ISTEK_NOTU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde konsÃ¼ltasyon yapan hekimin yazdÄ±ÄŸÄ± cevap notu bilgisidir.</summary>
    [Required]
    public string KONSULTASYON_CEVAP_NOTU { get; set; }

    /// <summary>Hekimin konsÃ¼ltasyon iÃ§in, diÄŸer bir hekim tarafÄ±ndan SaÄŸlÄ±k Bilgi YÃ¶netim Siste...</summary>
    public DateTime KONSULTASYONA_CAGRILMA_ZAMANI { get; set; }

    /// <summary>Hekimin konsÃ¼ltasyona geliÅŸ zamanÄ± bilgisidir.</summary>
    public DateTime KONSULTASYONA_GELIS_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavi olan hastaya konsÃ¼ltasyonun nerede yapÄ±ldÄ±ÄŸÄ± bilgisidir....</summary>
    [ForeignKey("KonsultasyonYeriNavigation")]
    public string KONSULTASYON_YERI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA_HIZMET? HastaHizmetNavigation { get; set; }
    public virtual HASTA_BASVURU? KonsultasyonBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? KonsultasyonYeriNavigation { get; set; }
    #endregion

}
