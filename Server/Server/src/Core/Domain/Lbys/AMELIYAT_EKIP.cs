using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// AMELIYAT_EKIP tablosu - 11 kolon
/// </summary>
[Table("AMELIYAT_EKIP")]
public class AMELIYAT_EKIP : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde ameliyatÄ± gerÃ§ekleÅŸtiren ekip (operatÃ¶r, anestezi uzmanÄ±, hemÅŸi...</summary>
    [Key]
    public string AMELIYAT_EKIP_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan ameliyatÄ±n bilgilerine eriÅŸim saÄŸlamak iÃ§in SaÄŸlÄ±k Bilg...</summary>
    [ForeignKey("AmeliyatNavigation")]
    public string AMELIYAT_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan ameliyatÄ±n iÅŸlem bilgilerine eriÅŸim saÄŸlamak iÃ§in SaÄŸlÄ±...</summary>
    [ForeignKey("AmeliyatIslemNavigation")]
    public string AMELIYAT_ISLEM_KODU { get; set; }

    /// <summary>AmeliyatÄ± yapan ekibe (hekim, hemÅŸire, anestezi uzmanÄ±, anestezi teknisyeni vb. ...</summary>
    [Required]
    public string EKIP_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }

    /// <summary>Ameliyat ekibinde bulunan personelin gÃ¶revlerine iliÅŸkin bilgiyi ifade eder.</summary>
    [Required]
    [ForeignKey("AmeliyatPersonelGorevNavigation")]
    public string AMELIYAT_PERSONEL_GOREV { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual AMELIYAT? AmeliyatNavigation { get; set; }
    public virtual AMELIYAT_ISLEM? AmeliyatIslemNavigation { get; set; }
    public virtual PERSONEL? PersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? AmeliyatPersonelGorevNavigation { get; set; }
    #endregion

}
