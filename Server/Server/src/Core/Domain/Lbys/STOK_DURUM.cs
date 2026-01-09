using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// STOK_DURUM tablosu - 11 kolon
/// </summary>
[Table("STOK_DURUM")]
public class STOK_DURUM : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinin deposunda bulunan malzemelerin son durumuna iliÅŸkin kayÄ±tlara e...</summary>
    [Key]
    public string STOK_DURUM_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde bulunan stok depolarÄ± iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±n...</summary>
    [ForeignKey("DepoNavigation")]
    public string DEPO_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan ilaÃ§, malzeme ve Ã¼rÃ¼nlerin bilgilerine eriÅŸim saÄŸlamak ...</summary>
    [ForeignKey("StokKartNavigation")]
    public string STOK_KART_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinin depolarÄ±nda bulunan ilaÃ§, malzeme ve Ã¼rÃ¼n vb. iÃ§in maksimum mik...</summary>
    [Required]
    public string MAKSIMUM_STOK { get; set; }

    /// <summary>Ä°laÃ§, malzeme, Ã¼rÃ¼n vb. iÃ§in saÄŸlÄ±k tesisinin depolarÄ±nda bulunmasÄ± gereken mini...</summary>
    [Required]
    public string MINIMUM_STOK { get; set; }

    /// <summary>SaÄŸlÄ±k tesisi depolarÄ±nda kalan ilaÃ§, malzeme Ã¼rÃ¼n vb. iÃ§in kritik miktar bilgis...</summary>
    [Required]
    public string KRITIK_STOK { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinin depolarÄ±na giriÅŸi yapÄ±lan toplam ilaÃ§, malzeme, Ã¼rÃ¼n vb. miktar...</summary>
    public string TOPLAM_GIRIS_MIKTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinin depolarÄ±ndan Ã§Ä±kÄ±ÅŸÄ± yapÄ±lan toplam ilaÃ§, malzeme, Ã¼rÃ¼n vb. mikt...</summary>
    public string TOPLAM_CIKIS_MIKTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisi depolarÄ±ndaki toplam stok miktarÄ± bilgisidir.</summary>
    public string STOK_MIKTARI { get; set; }

    /// <summary>Ä°laÃ§, malzeme, Ã¼rÃ¼n vb. iÃ§in saÄŸlÄ±k tesisinde kullanÄ±lan Ã¶lÃ§Ã¼ biriminin SaÄŸlÄ±k B...</summary>
    [ForeignKey("OlcuNavigation")]
    public string OLCU_KODU { get; set; }

    #region Navigation Properties
    public virtual DEPO? DepoNavigation { get; set; }
    public virtual STOK_KART? StokKartNavigation { get; set; }
    public virtual REFERANS_KODLAR? OlcuNavigation { get; set; }
    #endregion

}
