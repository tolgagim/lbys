using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// HASTA_EPIKRIZ tablosu - 12 kolon
/// </summary>
[Table("HASTA_EPIKRIZ")]
public class HASTA_EPIKRIZ : VemEntity
{
    /// <summary>Hekimin muayene yaptÄ±ktan sonra hasta iÃ§in yazdÄ±ÄŸÄ± epikriz bilgileri iÃ§in SaÄŸlÄ±k...</summary>
    [Key]
    public string HASTA_EPIKRIZ_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Epikrizin yazÄ±ldÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime? EPIKRIZ_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hastaya hekimi tarafÄ±ndan yazÄ±lan epikrizin baÅŸlÄ±k bilgisidir.</summary>
    [ForeignKey("EpikrizBaslikBilgisiNavigation")]
    public string EPIKRIZ_BASLIK_BILGISI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine gelen, ayaktan ve yatan hastalar iÃ§in hekimlerin yazdÄ±ÄŸÄ± epikriz...</summary>
    [Required]
    public string EPIKRIZ_BILGISI_ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli hekim iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼ret...</summary>
    [Required]
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? EpikrizBaslikBilgisiNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    #endregion

}
