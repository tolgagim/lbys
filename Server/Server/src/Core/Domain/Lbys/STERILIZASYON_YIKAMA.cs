using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// STERILIZASYON_YIKAMA tablosu - 13 kolon
/// </summary>
[Table("STERILIZASYON_YIKAMA")]
public class STERILIZASYON_YIKAMA : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinin sterilizasyon Ã¼nitesinde yÄ±kama iÅŸlemi yapÄ±lan tÄ±bbi aletler iÃ§...</summary>
    [Key]
    public string STERILIZASYON_YIKAMA_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde bulunan stok depolarÄ± iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±n...</summary>
    [ForeignKey("DepoNavigation")]
    public string DEPO_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan ilaÃ§, malzeme ve Ã¼rÃ¼nlerin bilgilerine eriÅŸim saÄŸlamak ...</summary>
    [ForeignKey("StokKartNavigation")]
    public string STOK_KART_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde sterilizasyon Ã¶ncesi yÄ±kanan alet miktarÄ± bilgisidir.</summary>
    public string YIKANAN_ALET_MIKTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yÄ±kama iÅŸleminden geÃ§miÅŸ Ã¼rÃ¼n, malzeme vb. iÃ§in yÄ±kamanÄ±n makin...</summary>
    [ForeignKey("SterilizasyonYikamaTuruNavigation")]
    public string STERILIZASYON_YIKAMA_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [ForeignKey("YikamaYapanPersonelNavigation")]
    public string YIKAMA_YAPAN_PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde steril edilecek malzemelerin yÄ±kama iÅŸleminin baÅŸladÄ±ÄŸÄ± zaman b...</summary>
    public DateTime? YIKAMA_BASLAMA_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde steril edilecek malzemelerin yÄ±kama iÅŸleminin bittiÄŸi zaman bil...</summary>
    public DateTime YIKAMA_BITIS_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual DEPO? DepoNavigation { get; set; }
    public virtual STOK_KART? StokKartNavigation { get; set; }
    public virtual REFERANS_KODLAR? SterilizasyonYikamaTuruNavigation { get; set; }
    public virtual PERSONEL? YikamaYapanPersonelNavigation { get; set; }
    #endregion

}
