using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// STERILIZASYON_PAKET_DETAY tablosu - 11 kolon
/// </summary>
[Table("STERILIZASYON_PAKET_DETAY")]
public class STERILIZASYON_PAKET_DETAY : VemEntity
{
    /// <summary>Sterilizasyon Ã¼nitesinde kullanÄ±lan paketlerin detay bilgileri iÃ§in SaÄŸlÄ±k Bilgi...</summary>
    [Key]
    public string STERILIZASYON_PAKET_DETAY_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinin deposunda bulunan steril aletlerin paket bilgilerine iliÅŸkin ka...</summary>
    [ForeignKey("SterilizasyonPaketNavigation")]
    public string STERILIZASYON_PAKET_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan ilaÃ§, malzeme ve Ã¼rÃ¼nlerin bilgilerine eriÅŸim saÄŸlamak ...</summary>
    [ForeignKey("StokKartNavigation")]
    public string STOK_KART_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde sterilizasyon iÅŸlemine giren veya Ã§Ä±kan setlerde bulunan malzem...</summary>
    public string STERILIZASYON_MALZEME_MIKTARI { get; set; }

    /// <summary>Ä°laÃ§, malzeme, Ã¼rÃ¼n vb. iÃ§in saÄŸlÄ±k tesisinde kullanÄ±lan Ã¶lÃ§Ã¼ biriminin SaÄŸlÄ±k B...</summary>
    [ForeignKey("OlcuNavigation")]
    public string OLCU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual STERILIZASYON_PAKET? SterilizasyonPaketNavigation { get; set; }
    public virtual STOK_KART? StokKartNavigation { get; set; }
    public virtual REFERANS_KODLAR? OlcuNavigation { get; set; }
    #endregion

}
