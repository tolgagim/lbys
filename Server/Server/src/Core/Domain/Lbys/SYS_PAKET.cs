using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// SYS_PAKET tablosu - 13 kolon
/// </summary>
[Table("SYS_PAKET")]
public class SYS_PAKET : VemEntity
{
    /// <summary>SaÄŸlÄ±k YÃ¶netim Sistemi (SYS) Paket Kodu, SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi yazÄ±lÄ±mlar...</summary>
    [Key]
    public string SYS_PAKET_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alindigi SBYS veri tabanindaki tablo adinin bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k BakanlÄ±ÄŸÄ± Merkezi Veri Sistemine iletilmesi gereken veri paketleri iÃ§in B...</summary>
    [Required]
    public string VERI_PAKETI_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinden veri paketinin e-NabÄ±z sistemine iletildiÄŸi zaman bilgisidir.</summary>
    public DateTime VERI_PAKETI_GONDERILME_ZAMANI { get; set; }

    /// <summary>Saglik tesisinden veri paketinin e-Nabiz sistemine gÃ¶nderilip gÃ¶nderilmedigi bil...</summary>
    public string VERI_PAKETI_GONDERIM_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kullanÄ±lan SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi ile diÄŸer bilgi sisteml...</summary>
    [Required]
    public string GONDERILEN_PAKET_BILGISI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kullanÄ±lan SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi ile diÄŸer bilgi sisteml...</summary>
    [Required]
    public string GELEN_CEVAP_BILGISI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    #endregion

}
