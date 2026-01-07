using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// PERSONEL_OGRENIM tablosu - 13 kolon
/// </summary>
[Table("PERSONEL_OGRENIM")]
public class PERSONEL_OGRENIM : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin Ã¶ÄŸrenim bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim ...</summary>
    [Key]
    public string PERSONEL_OGRENIM_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }

    /// <summary>KiÅŸinin en son bitirdiÄŸi okul seviyesini veya okuryazarlÄ±k durumunu ifade eder. ...</summary>
    [ForeignKey("OgrenimDurumuNavigation")]
    public string OGRENIM_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin Ã¶ÄŸrenim gÃ¶rdÃ¼ÄŸÃ¼ okul bilgisidir.</summary>
    [Required]
    public string OKUL_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin Ã¶ÄŸrenim gÃ¶rdÃ¼ÄŸÃ¼ okula baÅŸlama tarihi bilgisi...</summary>
    public DateTime OKULA_BASLANGIC_TARIHI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin Ã¶ÄŸrenim gÃ¶rdÃ¼ÄŸÃ¼ okuldan mezun olduÄŸu tarih b...</summary>
    public DateTime MEZUNIYET_TARIHI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin eÄŸitim veya Ã¶ÄŸrenim iÃ§in aldÄ±ÄŸÄ± belgenin num...</summary>
    [Required]
    public string BELGE_NUMARASI { get; set; }

    /// <summary>YapÄ±lan bir iÅŸlemi onaylayan personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±nd...</summary>
    [Required]
    [ForeignKey("OnaylayanPersonelNavigation")]
    public string ONAYLAYAN_PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual PERSONEL? PersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? OgrenimDurumuNavigation { get; set; }
    public virtual PERSONEL? OnaylayanPersonelNavigation { get; set; }
    #endregion

}
