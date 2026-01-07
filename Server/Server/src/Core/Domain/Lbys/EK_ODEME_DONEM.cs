using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// EK_ODEME_DONEM tablosu - 16 kolon
/// </summary>
[Table("EK_ODEME_DONEM")]
public class EK_ODEME_DONEM : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele Ã¶denecek ek Ã¶deme iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim S...</summary>
    [Key]
    public string EK_ODEME_DONEM_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>YÄ±l bilgisini ifade eder.</summary>
    public string YIL { get; set; }

    /// <summary>YÄ±lÄ±n on iki bÃ¶lÃ¼mÃ¼nden her birini ifade eder.</summary>
    public string AY { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶rev yapan personel iÃ§in yapÄ±lan her tÃ¼rlÃ¼ Ã¶deme bilgisine ait...</summary>
    [Required]
    public string BORDRO_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli hekimler tarafÄ±ndan, hastaya uygulanan tÄ±bbi iÅŸlemler i...</summary>
    public string GIRISIMSEL_ISLEM_PUAN_TOPLAMI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin uyguladÄ±ÄŸÄ± tÄ±bbi iÅŸlemler iÃ§in aldÄ±ÄŸÄ± Ã¶zelli...</summary>
    public string OZELLIKLI_ISLEM_PUAN_TOPLAMI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli tÃ¼m personelin mevcut kadrosundaki aktif Ã§alÄ±ÅŸtÄ±ÄŸÄ± gÃ¼n ...</summary>
    public string ACGK_TOPLAMI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personel iÃ§in ek Ã¶deme dÃ¶nemi iÃ§in daÄŸÄ±tÄ±lmasÄ± planlana...</summary>
    public string DAGITILACAK_EKODEME_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele ait bordro iÃ§in hesaplanan ek Ã¶deme katsayÄ±sÄ±...</summary>
    public string EK_ODEME_KATSAYISI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele aylÄ±k Ã¶denen ek Ã¶deme iÃ§in hesaplanan hastane...</summary>
    public string HASTANE_PUAN_ORTALAMASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    #endregion

}
