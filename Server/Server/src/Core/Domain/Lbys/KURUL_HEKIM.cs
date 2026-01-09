using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// KURUL_HEKIM tablosu - 16 kolon
/// </summary>
[Table("KURUL_HEKIM")]
public class KURUL_HEKIM : VemEntity
{
    /// <summary>Hastaya saÄŸlÄ±k raporu veren kurulda bulunan hekim iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sist...</summary>
    [Key]
    public string KURUL_HEKIM_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Hastaya saÄŸlÄ±k raporu veren kurul iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("KurulRaporNavigation")]
    public string KURUL_RAPOR_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli hekim iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼ret...</summary>
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan klinik ve hekimler iÃ§in MEDULA tarafÄ±ndan tanÄ±mlanmÄ±ÅŸ b...</summary>
    [Required]
    public string MEDULA_BRANS_KODU { get; set; }

    /// <summary>Ä°nsan vÃ¼cudunun sistemleri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼retilen...</summary>
    [Required]
    [ForeignKey("SistemNavigation")]
    public string SISTEM_KODU { get; set; }

    /// <summary>Kurul hekiminin yazdÄ±ÄŸÄ± sonuÃ§ bilgisidir.</summary>
    [Required]
    public string KURUL_SONUC { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran kiÅŸi iÃ§in belirlenen engellilik oranÄ± bilgisidir.</summary>
    [Required]
    public string ENGELLILIK_ORANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde, hekimin saÄŸlÄ±k kurulundaki gÃ¶rev bilgisidir. Ã–rneÄŸin baÅŸkan, Ã¼...</summary>
    [Required]
    public string HEKIM_KURUL_GOREVI { get; set; }

    /// <summary>SaÄŸlÄ±k kurulunda gÃ¶revli hekimlerin sÄ±ra numarasÄ± bilgisidir.</summary>
    public string HEKIM_SIRA_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual KURUL_RAPOR? KurulRaporNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual REFERANS_KODLAR? SistemNavigation { get; set; }
    #endregion

}
