using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// KAN_STOK tablosu - 30 kolon
/// </summary>
[Table("KAN_STOK")]
public class KAN_STOK : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisindeki depolarda bulunan kan Ã¼rÃ¼nÃ¼ iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi...</summary>
    [Key]
    public string KAN_STOK_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisisin kan bankasÄ±nda iÅŸlem gÃ¶ren kan Ã¼rÃ¼nÃ¼nÃ¼n, son durum bilgisini if...</summary>
    [ForeignKey("KanStokDurumuNavigation")]
    public string KAN_STOK_DURUMU { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼nÃ¼n saÄŸlÄ±k tesisinin deposuna giriÅŸ tarihi bilgisidir.</summary>
    public DateTime? KAN_STOK_GIRIS_TARIHI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki birimlerde hasta bilgilerinin olduÄŸu defter numarasÄ± bilgisid...</summary>
    public string DEFTER_NUMARASI { get; set; }

    /// <summary>KiÅŸinin kan grubunu ifade eder</summary>
    [ForeignKey("KanGrubuNavigation")]
    public string KAN_GRUBU { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼ iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼retilen tekil kod bilgis...</summary>
    [ForeignKey("KanUrunNavigation")]
    public string KAN_URUN_KODU { get; set; }

    /// <summary>Kan baÄŸÄ±ÅŸÄ±nda bulunan kiÅŸi iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼retilen...</summary>
    [Required]
    [ForeignKey("KanBagisciNavigation")]
    public string KAN_BAGISCI_KODU { get; set; }

    /// <summary>KiÅŸinin yararlandÄ±ÄŸÄ± saÄŸlÄ±k gÃ¼vencesinin kurumuna ait bilgiler iÃ§in SaÄŸlÄ±k Bilgi...</summary>
    [Required]
    [ForeignKey("KurumNavigation")]
    public string KURUM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan bÃ¶lÃ¼mler iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [Required]
    [ForeignKey("BirimNavigation")]
    public string BIRIM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde stokta kaydÄ± bulunan kan Ã¼rÃ¼nÃ¼ne uygulanan iÅŸlemler sonucunda e...</summary>
    [Required]
    [ForeignKey("BagliKanStokNavigation")]
    public string BAGLI_KAN_STOK_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisi tarafÄ±ndan hastaya takÄ±lan kan Ã¼rÃ¼nleri iÃ§in KÄ±zÄ±lay tarafÄ±ndan Ã¼r...</summary>
    [Required]
    public string ISBT_UNITE_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisi tarafÄ±ndan hastaya takÄ±lan kan Ã¼rÃ¼nleri iÃ§in KÄ±zÄ±lay tarafÄ±ndan Ã¼r...</summary>
    [Required]
    public string ISBT_BILESEN_NUMARASI { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼nÃ¼n mililitre cinsinden hacim bilgisidir.</summary>
    [Required]
    public string KAN_HACIM { get; set; }

    /// <summary>Kan baÄŸÄ±ÅŸÄ± iÅŸleminin yapÄ±ldÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime KAN_BAGIS_ZAMANI { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼ne filtreleme iÅŸleminin yapÄ±ldÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime KAN_FILTRELEME_ZAMANI { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼nÃ¼n Ä±ÅŸÄ±nlanma iÅŸleminin uygulandÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime KAN_ISINLAMA_ZAMANI { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼ne yÄ±kama iÅŸleminin uygulandÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime KAN_YIKAMA_ZAMANI { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼ne ayÄ±rma iÅŸleminin uygulandÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime KAN_AYIRMA_ZAMANI { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼ne bÃ¶lme iÅŸleminin uygulandÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime KAN_BOLME_ZAMANI { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼ne Buffy Coat uzaklaÅŸtÄ±rma iÅŸlemi uygulandÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime BUFFYCOAT_UZAKLASTIRMA_ZAMANI { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼ne havuzlama iÅŸleminin uygulandÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime KAN_HAVUZLAMA_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kullanÄ±lan ilaÃ§, aÅŸÄ±, tÄ±bbi alet vb. son kullanma tarihi bilgis...</summary>
    public DateTime SON_KULLANMA_TARIHI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual REFERANS_KODLAR? KanStokDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanGrubuNavigation { get; set; }
    public virtual KAN_URUN? KanUrunNavigation { get; set; }
    public virtual KAN_BAGISCI? KanBagisciNavigation { get; set; }
    public virtual KURUM? KurumNavigation { get; set; }
    public virtual BIRIM? BirimNavigation { get; set; }
    public virtual KAN_STOK? BagliKanStokNavigation { get; set; }
    #endregion

}
