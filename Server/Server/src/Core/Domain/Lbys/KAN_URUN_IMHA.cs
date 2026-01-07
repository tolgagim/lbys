using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// KAN_URUN_IMHA tablosu - 12 kolon
/// </summary>
[Table("KAN_URUN_IMHA")]
public class KAN_URUN_IMHA : VemEntity
{
    /// <summary>Ä°mha edilen kan Ã¼rÃ¼nÃ¼ iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼retilen teki...</summary>
    [Key]
    public string KAN_URUN_IMHA_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki depolarda bulunan kan Ã¼rÃ¼nÃ¼ iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi...</summary>
    [ForeignKey("KanStokNavigation")]
    public string KAN_STOK_KODU { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼nÃ¼n imha edilmesi durumunda belirtilen neden bilgisidir. Ã–rneÄŸin son ku...</summary>
    [ForeignKey("KanImhaNedeniNavigation")]
    public string KAN_IMHA_NEDENI { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼nÃ¼n imha edildiÄŸi zaman bilgisidir.</summary>
    public DateTime? KAN_IMHA_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kan Ã¼rÃ¼nÃ¼nÃ¼n imha edilmesini onaylayan hekim bilgileri iÃ§in SaÄŸ...</summary>
    [Required]
    [ForeignKey("KanImhaOnaylayanHekimNavigation")]
    public string KAN_IMHA_ONAYLAYAN_HEKIM { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kan Ã¼rÃ¼nÃ¼nÃ¼n imha edilmesini onaylayan teknisyen bilgileri iÃ§in...</summary>
    [Required]
    [ForeignKey("KanImhaOnaylayanTeknisyenNavigation")]
    public string KAN_IMHA_ONAYLAYAN_TEKNISYEN { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kan Ã¼rÃ¼nÃ¼nÃ¼ imha eden personel bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶ne...</summary>
    [Required]
    [ForeignKey("KanImhaEdenPersonelNavigation")]
    public string KAN_IMHA_EDEN_PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual KAN_STOK? KanStokNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanImhaNedeniNavigation { get; set; }
    public virtual PERSONEL? KanImhaOnaylayanHekimNavigation { get; set; }
    public virtual PERSONEL? KanImhaOnaylayanTeknisyenNavigation { get; set; }
    public virtual PERSONEL? KanImhaEdenPersonelNavigation { get; set; }
    #endregion

}
