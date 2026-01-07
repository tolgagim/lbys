using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// STOK_ISTEK tablosu - 16 kolon
/// </summary>
[Table("STOK_ISTEK")]
public class STOK_ISTEK : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisindeki hekimin, hasta iÃ§in istediÄŸi malzeme ve ilaÃ§larÄ±n saÄŸlÄ±k tesi...</summary>
    [Key]
    public string STOK_ISTEK_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavi gÃ¶ren hasta iÃ§in hekim tarafÄ±ndan yapÄ±lan ilaÃ§, malzeme ...</summary>
    public DateTime? ISTEK_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan stok depolarÄ± iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±n...</summary>
    [ForeignKey("IstekDepoNavigation")]
    public string ISTEK_DEPO_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki depolardan yapÄ±lan isteklerin durumunu gÃ¶steren SaÄŸlÄ±k Bilgi ...</summary>
    [ForeignKey("StokIstekDurumuNavigation")]
    public string STOK_ISTEK_DURUMU { get; set; }

    /// <summary>Ä°stekle ilgili hekimin aÃ§Ä±klama bilgisidir.</summary>
    [Required]
    public string STOK_ISTEK_HEKIM_ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan ameliyatÄ±n bilgilerine eriÅŸim saÄŸlamak iÃ§in SaÄŸlÄ±k Bilg...</summary>
    [Required]
    [ForeignKey("AmeliyatNavigation")]
    public string AMELIYAT_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual DEPO? IstekDepoNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual REFERANS_KODLAR? StokIstekDurumuNavigation { get; set; }
    public virtual AMELIYAT? AmeliyatNavigation { get; set; }
    #endregion

}
