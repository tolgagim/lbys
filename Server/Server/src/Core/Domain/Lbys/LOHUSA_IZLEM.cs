using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// LOHUSA_IZLEM tablosu - 23 kolon
/// </summary>
[Table("LOHUSA_IZLEM")]
public class LOHUSA_IZLEM : VemEntity
{
    /// <summary>DoÄŸum yapmÄ±ÅŸ kadÄ±nlarÄ±n izlem bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±...</summary>
    [Key]
    public string LOHUSA_IZLEM_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Lohusada kaÃ§Ä±ncÄ± izlemin yapÄ±ldÄ±ÄŸÄ±nÄ± ifade eder.</summary>
    [ForeignKey("KacinciLohusaIzlemNavigation")]
    public string KACINCI_LOHUSA_IZLEM { get; set; }

    /// <summary>Ä°zlemin yapÄ±ldÄ±ÄŸÄ± kurum bilgisidir.</summary>
    [Required]
    [ForeignKey("IzleminYapildigiYerNavigation")]
    public string IZLEMIN_YAPILDIGI_YER { get; set; }

    /// <summary>Gebelikte dÄ±ÅŸarÄ±dan demir desteÄŸi; demirin uygulanmayacaÄŸÄ± durumlar hariÃ§, ayrÄ±m...</summary>
    [Required]
    [ForeignKey("DemirLojistigiVeDestegiNavigation")]
    public string DEMIR_LOJISTIGI_VE_DESTEGI { get; set; }

    /// <summary>Gebeler iÃ§in; gebeliÄŸin 12. haftasÄ±ndan baÅŸlanarak doÄŸumdan sonra 6. ayÄ±n sonuna...</summary>
    [Required]
    [ForeignKey("DvitaminiLojistigiVeDestegiNavigation")]
    public string DVITAMINI_LOJISTIGI_VE_DESTEGI { get; set; }

    /// <summary>GebeliÄŸin doÄŸum veya baÅŸka sebepler ile sonlandÄ±ÄŸÄ± tarih bilgisidir.</summary>
    public DateTime? GEBELIK_SONLANMA_TARIHI { get; set; }

    /// <summary>EDINBURGH Postpartum Depresyon Ã–lÃ§eÄŸi, doÄŸum sonrasÄ± dÃ¶nemdeki kadÄ±nlara uygulan...</summary>
    [Required]
    [ForeignKey("PostpartumDepresyonNavigation")]
    public string POSTPARTUM_DEPRESYON { get; set; }

    /// <summary>Uterus involusyon takibinin yapÄ±lma durumuna iliÅŸkin bilgidir. Ã–rneÄŸin uterus Ä±n...</summary>
    [ForeignKey("UterusInvolusyonNavigation")]
    public string UTERUS_INVOLUSYON { get; set; }

    /// <summary>Bilgi alÄ±nan kiÅŸinin ad ve soyadÄ± bilgisidir.</summary>
    [Required]
    public string BILGI_ALINAN_KISI_AD_SOYADI { get; set; }

    /// <summary>Bilgi alÄ±nan kiÅŸinin telefon numarasÄ± bilgisidir.</summary>
    [Required]
    public string BILGI_ALINAN_KISI_TELEFON { get; set; }

    /// <summary>KadÄ±nÄ±n 22. gebelik haftasÄ± ve sonrasÄ±nda veya 500 gram ve Ã¼zerinde konjenital a...</summary>
    [Required]
    [ForeignKey("KonjenitalAnomaliVarligiNavigation")]
    public string KONJENITAL_ANOMALI_VARLIGI { get; set; }

    /// <summary>KiÅŸinin hemoglobin deÄŸeri bilgisidir.</summary>
    [Required]
    public string HEMOGLOBIN_DEGERI { get; set; }

    /// <summary>Herhangi bir mÃ¼dahale (ameliyat, doÄŸum vb.) sonrasÄ± oluÅŸan karmaÅŸÄ±k ve olumsuz k...</summary>
    [Required]
    [ForeignKey("KomplikasyonTanisiNavigation")]
    public string KOMPLIKASYON_TANISI { get; set; }

    /// <summary>Gebelik/lohusalÄ±k seyrinde anne ve fetÃ¼s saÄŸlÄ±ÄŸÄ±nÄ± olumsuz yÃ¶nde etkileyen faktÃ¶...</summary>
    [Required]
    [ForeignKey("SeyirTehlikeIsaretiNavigation")]
    public string SEYIR_TEHLIKE_ISARETI { get; set; }

    /// <summary>Gebelik Ã¶ncesi, gebelik sÃ¼resi ve gebelik sonrasÄ± dÃ¶nemlerde kadÄ±n saÄŸlÄ±ÄŸÄ± aÃ§Ä±sÄ±...</summary>
    [Required]
    [ForeignKey("KadinSagligiIslemleriNavigation")]
    public string KADIN_SAGLIGI_ISLEMLERI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? KacinciLohusaIzlemNavigation { get; set; }
    public virtual REFERANS_KODLAR? IzleminYapildigiYerNavigation { get; set; }
    public virtual REFERANS_KODLAR? DemirLojistigiVeDestegiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DvitaminiLojistigiVeDestegiNavigation { get; set; }
    public virtual REFERANS_KODLAR? PostpartumDepresyonNavigation { get; set; }
    public virtual REFERANS_KODLAR? UterusInvolusyonNavigation { get; set; }
    public virtual REFERANS_KODLAR? KonjenitalAnomaliVarligiNavigation { get; set; }
    public virtual REFERANS_KODLAR? KomplikasyonTanisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SeyirTehlikeIsaretiNavigation { get; set; }
    public virtual REFERANS_KODLAR? KadinSagligiIslemleriNavigation { get; set; }
    #endregion

}
