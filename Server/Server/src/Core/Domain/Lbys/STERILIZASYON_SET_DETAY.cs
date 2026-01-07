using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// STERILIZASYON_SET_DETAY tablosu - 9 kolon
/// </summary>
[Table("STERILIZASYON_SET_DETAY")]
public class STERILIZASYON_SET_DETAY : VemEntity
{
    /// <summary>TÄ±bbi aletlerin steril edilmeden Ã¶nce ve sterilizasyon aÅŸamasÄ±nda oluÅŸturulan se...</summary>
    [Key]
    public string STERILIZASYON_SET_DETAY_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>TÄ±bbi aletlerin steril edilmeden Ã¶nce ve sterilizasyon aÅŸamasÄ±nda oluÅŸturulan se...</summary>
    [ForeignKey("SterilizasyonSetNavigation")]
    public string STERILIZASYON_SET_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan ilaÃ§, malzeme ve Ã¼rÃ¼nlerin bilgilerine eriÅŸim saÄŸlamak ...</summary>
    [ForeignKey("StokKartNavigation")]
    public string STOK_KART_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde sterilizasyon iÅŸlemine giren veya Ã§Ä±kan setlerde bulunan malzem...</summary>
    public string STERILIZASYON_MALZEME_MIKTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual STERILIZASYON_SET? SterilizasyonSetNavigation { get; set; }
    public virtual STOK_KART? StokKartNavigation { get; set; }
    #endregion

}
