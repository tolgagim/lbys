using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// HASTA_MALZEME tablosu - 32 kolon
/// </summary>
[Table("HASTA_MALZEME")]
public class HASTA_MALZEME : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde hasta iÃ§in kullanÄ±lan ilaÃ§, malzeme, Ã¼rÃ¼n vb. bilgiler iÃ§in SaÄŸ...</summary>
    [Key]
    public string HASTA_MALZEME_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan ilaÃ§, malzeme ve Ã¼rÃ¼nlerin bilgilerine eriÅŸim saÄŸlamak ...</summary>
    [ForeignKey("StokKartNavigation")]
    public string STOK_KART_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kullanÄ±lan malzemelerin ayrÄ±ntÄ±lÄ± hareket bilgilerini takip etm...</summary>
    [ForeignKey("StokHareketNavigation")]
    public string STOK_HAREKET_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hastaya uygulanan malzemeler iÃ§in fatura kesilip kesilmediÄŸine ...</summary>
    [ForeignKey("MalzemeFaturaDurumuNavigation")]
    public string MALZEME_FATURA_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan iÅŸlemlerin, uygulanmaya baÅŸladÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime? ISLEM_ZAMANI { get; set; }

    /// <summary>Hastaya uygulanan iÅŸlemin gerÃ§ekleÅŸme zamanÄ± bilgisidir.</summary>
    public DateTime? ISLEM_GERCEKLESME_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kiÅŸiye aÅŸÄ± uygulanmadan Ã¶nce SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi taraf...</summary>
    [Required]
    public string ATS_SORGU_NUMARASI { get; set; }

    /// <summary>Vericinin uygun bir biÃ§imde tanÄ±mlanmÄ±ÅŸ ve baÄŸÄ±ÅŸlanan materyalin izlenebilirliÄŸi...</summary>
    [Required]
    public string ALLOGREFT_DONOR_KODU { get; set; }

    /// <summary>KiÅŸiye saÄŸlÄ±k tesisinde kullanÄ±lan ilaÃ§/sarf malzeme miktar bilgisidir.</summary>
    public string MALZEME_ADETI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde fatura edilen iÅŸlemler iÃ§in adet bilgisidir.</summary>
    [Required]
    public string FATURA_ADET { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kesilen fatura kayÄ±tlarÄ±na eriÅŸim iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sis...</summary>
    [Required]
    [ForeignKey("FaturaNavigation")]
    public string FATURA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisi tarafÄ±ndan kesilen faturanÄ±n toplam tutar bilgisidir.</summary>
    [Required]
    public string FATURA_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hastaya uygulanan hizmetler iÃ§in hasta dosyasÄ±na kayÄ±t edilen h...</summary>
    [Required]
    public string HASTA_TUTARI { get; set; }

    /// <summary>Hasta dosyasÄ±na iÅŸlenen iÅŸlemin hastanÄ±n sosyal gÃ¼vencesinin bulunduÄŸu kuruma ya...</summary>
    [Required]
    public string KURUM_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavi gÃ¶ren hastaya yapÄ±lan iÅŸlem iÃ§in MEDULA sisteminin Ã¶deme...</summary>
    [Required]
    public string MEDULA_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavi gÃ¶ren hastalarÄ±n iÅŸlemlerine ait MEDULA tarafÄ±ndan SaÄŸlÄ±...</summary>
    [Required]
    public string MEDULA_ISLEM_SIRA_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavi gÃ¶ren hastalarÄ±n iÅŸlemlerine ait SaÄŸlÄ±k Bilgi YÃ¶netim Si...</summary>
    [Required]
    public string MEDULA_HIZMET_REF_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k YÃ¶netim Sistemi (SYS) Referans NumarasÄ±, saÄŸlÄ±k tesisine baÅŸvuran hastala...</summary>
    [Required]
    public string SYS_REFERANS_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavi gÃ¶ren hasta iÃ§in, Ã§eÅŸitli kriterlere gÃ¶re MEDULA tarafÄ±n...</summary>
    [Required]
    [ForeignKey("MedulaTakipNavigation")]
    public string MEDULA_TAKIP_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavi gÃ¶ren hastalarÄ±n iÅŸlemlerine ait MEDULA tarafÄ±ndan tanÄ±m...</summary>
    [Required]
    public string MEDULA_OZEL_DURUM { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan ameliyatÄ±n bilgilerine eriÅŸim saÄŸlamak iÃ§in SaÄŸlÄ±k Bilg...</summary>
    [Required]
    [ForeignKey("AmeliyatNavigation")]
    public string AMELIYAT_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde ilaÃ§, malzeme, Ã¼rÃ¼n vb. istemini yapan hekim iÃ§in SaÄŸlÄ±k Bilgi ...</summary>
    [ForeignKey("IsteyenHekimNavigation")]
    public string ISTEYEN_HEKIM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan stok depolarÄ± iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±n...</summary>
    [ForeignKey("DepoNavigation")]
    public string DEPO_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan bir iÅŸlemin iptal edilip edilmediÄŸi bilgisidir.</summary>
    public string IPTAL_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual STOK_KART? StokKartNavigation { get; set; }
    public virtual STOK_HAREKET? StokHareketNavigation { get; set; }
    public virtual REFERANS_KODLAR? MalzemeFaturaDurumuNavigation { get; set; }
    public virtual FATURA? FaturaNavigation { get; set; }
    public virtual MEDULA_TAKIP? MedulaTakipNavigation { get; set; }
    public virtual AMELIYAT? AmeliyatNavigation { get; set; }
    public virtual PERSONEL? IsteyenHekimNavigation { get; set; }
    public virtual DEPO? DepoNavigation { get; set; }
    #endregion

}
