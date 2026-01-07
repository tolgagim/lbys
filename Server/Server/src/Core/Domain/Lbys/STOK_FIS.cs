using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// STOK_FIS tablosu - 37 kolon
/// </summary>
[Table("STOK_FIS")]
public class STOK_FIS : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde kullanÄ±lan malzemelerin hareket bilgilerini takip etmek iÃ§in Sa...</summary>
    [Key]
    public string STOK_FIS_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [Required]
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinin deposuna giriÅŸi veya Ã§Ä±kÄ±ÅŸÄ± yapÄ±lan ilaÃ§, malzeme, Ã¼rÃ¼n vb. iÃ§i...</summary>
    [Required]
    [ForeignKey("BagliStokFisNavigation")]
    public string BAGLI_STOK_FIS_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan stok depolarÄ± iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±n...</summary>
    [ForeignKey("DepoNavigation")]
    public string DEPO_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki depolarda yapÄ±lan iÅŸlem hareketinin depoya giriÅŸ veya Ã§Ä±kÄ±ÅŸ i...</summary>
    public string HAREKET_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinin depolarÄ±na giriÅŸi yapÄ±lan ilaÃ§, Ã¼rÃ¼n TaÅŸÄ±nÄ±r iÅŸlem fiÅŸi iÃ§in Ma...</summary>
    [Required]
    public string MKYS_AYNIYAT_MAKBUZ_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki depolarda yapÄ±lan iÅŸlem hareketinin tarih bilgisidir.</summary>
    public DateTime? HAREKET_TARIHI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinin deposundan baÅŸka saÄŸlÄ±k tesisinin deposuna ilaÃ§, malzeme, Ã¼rÃ¼n ...</summary>
    [Required]
    public string SHCEK_PAYI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kesilen fiÅŸin hazine kurumu iÃ§in (%) cinsinden pay bilgisidir. ...</summary>
    [Required]
    public string HAZINE_PAYI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan hizmet iÃ§in kesilen fiÅŸin SaÄŸlÄ±k BakanlÄ±ÄŸÄ± (SB) payÄ± iÃ§...</summary>
    [Required]
    public string SAGLIK_BAKANLIGI_PAYI { get; set; }

    [Required]
    public string BEDELSIZ_FIS { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine Ã¼cretsiz yapÄ±lan ilaÃ§, malzeme, Ã¼rÃ¼n vb. giriÅŸlerinin bilgisini ...</summary>
    public string FIS_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki depolarda yapÄ±lan iÅŸlem hareketinin tÃ¼rÃ¼nÃ¼ ifade eden bilgidi...</summary>
    [ForeignKey("HareketSekliNavigation")]
    public string HAREKET_SEKLI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [Required]
    [ForeignKey("IslemiYapanPersonelNavigation")]
    public string ISLEMI_YAPAN_PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan iÅŸlemlerin, uygulanmaya baÅŸladÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime? ISLEM_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinin mal veya hizmet alÄ±mÄ± yaptÄ±ÄŸÄ± firma iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim S...</summary>
    [Required]
    [ForeignKey("FirmaNavigation")]
    public string FIRMA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde mal veya hizmet alÄ±mÄ± kapsamÄ±nda gerÃ§ekleÅŸtirilen ihalenin numa...</summary>
    [Required]
    public string IHALE_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde mal veya hizmet alÄ±mÄ± kapsamÄ±nda gerÃ§ekleÅŸtirilen ihalenin tari...</summary>
    public DateTime IHALE_TARIHI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde mal veya hizmet alÄ±mÄ± iÃ§in gerÃ§ekleÅŸtirilen ihalenin kapsamÄ±na ...</summary>
    [Required]
    [ForeignKey("IhaleTuruNavigation")]
    public string IHALE_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde alÄ±mÄ± yapÄ±lan ilaÃ§, malzeme, Ã¼rÃ¼n vb. kabul aÅŸamasÄ±nda saÄŸlÄ±k t...</summary>
    [Required]
    public string MUAYENE_KABUL_NUMARASI { get; set; }

    /// <summary>HastanÄ±n muayene tarihi bilgisidir.</summary>
    public DateTime MUAYENE_TARIHI { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼, numune, adli rapor, nÃ¼fus cÃ¼zdanÄ±, malzeme vb. ilgili kiÅŸiye teslim e...</summary>
    [Required]
    public string TESLIM_EDEN_KISI { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼, numune, adli rapor, nÃ¼fus cÃ¼zdanÄ±, malzeme vb. ilgili kiÅŸiye teslim e...</summary>
    [Required]
    public string TESLIM_EDEN_KISI_UNVANI { get; set; }

    /// <summary>BÃ¼tÃ§e tÃ¼rÃ¼ bilgisidir. Ã–rneÄŸin dÃ¶ner sermaye bÃ¼tÃ§esi, genel bÃ¼tÃ§e vb.</summary>
    [ForeignKey("ButceTuruNavigation")]
    public string BUTCE_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisi tarafÄ±ndan kesilen faturanÄ±n numara bilgisidir.</summary>
    [Required]
    public string FATURA_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisi tarafÄ±ndan kesilen faturanÄ±n zaman bilgisidir.</summary>
    public DateTime FATURA_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisi tarafÄ±ndan temin edilen ilaÃ§, malzeme veya Ã¼rÃ¼nlere ait fiÅŸin irsa...</summary>
    [Required]
    public string IRSALIYE_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisi tarafÄ±ndan temin edilen ilaÃ§, malzeme veya Ã¼rÃ¼nlere ait fiÅŸin irsa...</summary>
    public DateTime IRSALIYE_TARIHI { get; set; }

    /// <summary>Kurumlar arasÄ±ndaki devir iÅŸlerinde geÃ§erli olan ve Malzeme Kaynak YÃ¶netim Siste...</summary>
    [Required]
    public string MKYS_KURUM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual STOK_FIS? BagliStokFisNavigation { get; set; }
    public virtual DEPO? DepoNavigation { get; set; }
    public virtual REFERANS_KODLAR? HareketSekliNavigation { get; set; }
    public virtual PERSONEL? IslemiYapanPersonelNavigation { get; set; }
    public virtual FIRMA? FirmaNavigation { get; set; }
    public virtual REFERANS_KODLAR? IhaleTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? ButceTuruNavigation { get; set; }
    #endregion

}
