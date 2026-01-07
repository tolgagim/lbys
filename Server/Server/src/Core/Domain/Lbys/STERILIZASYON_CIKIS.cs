using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// STERILIZASYON_CIKIS tablosu - 15 kolon
/// </summary>
[Table("STERILIZASYON_CIKIS")]
public class STERILIZASYON_CIKIS : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde steril edilmiÅŸ tÄ±bbi aletlerin, steril deposundan saÄŸlÄ±k tesisi...</summary>
    [Key]
    public string STERILIZASYON_CIKIS_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan stok depolarÄ± iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±n...</summary>
    [ForeignKey("DepoNavigation")]
    public string DEPO_KODU { get; set; }

    /// <summary>TÄ±bbi aletlerin steril edilmeden Ã¶nce ve sterilizasyon aÅŸamasÄ±nda oluÅŸturulan se...</summary>
    [ForeignKey("SterilizasyonSetNavigation")]
    public string STERILIZASYON_SET_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [Required]
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sterilizasyon Ã¼nitesinden birime Ã§Ä±kÄ±lan setin miktar bilgisidir.</summary>
    public string STERILIZASYON_CIKIS_MIKTARI { get; set; }

    /// <summary>Setin sterilizasyon Ã¼nitesinden birime Ã§Ä±kÄ±ldÄ±ÄŸÄ± zaman bilgisidir</summary>
    public DateTime? STERILIZASYON_CIKIS_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan ilaÃ§, malzeme, set gibi Ã¼rÃ¼nlerin gÃ¶nderildiÄŸi birim iÃ§...</summary>
    [Required]
    [ForeignKey("CikisYapilanBirimNavigation")]
    public string CIKIS_YAPILAN_BIRIM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [ForeignKey("TeslimEdenPersonelNavigation")]
    public string TESLIM_EDEN_PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [ForeignKey("TeslimAlanPersonelNavigation")]
    public string TESLIM_ALAN_PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual DEPO? DepoNavigation { get; set; }
    public virtual STERILIZASYON_SET? SterilizasyonSetNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual BIRIM? CikisYapilanBirimNavigation { get; set; }
    public virtual PERSONEL? TeslimEdenPersonelNavigation { get; set; }
    public virtual PERSONEL? TeslimAlanPersonelNavigation { get; set; }
    #endregion

}
