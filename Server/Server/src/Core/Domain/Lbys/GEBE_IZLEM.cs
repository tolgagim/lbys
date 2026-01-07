using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// GEBE_IZLEM tablosu - 27 kolon
/// </summary>
[Table("GEBE_IZLEM")]
public class GEBE_IZLEM : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde muayene olan kadÄ±n hastalarÄ±n gebelik izlem bilgileri iÃ§in SaÄŸl...</summary>
    [Key]
    public string GEBE_IZLEM_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± tablo adÄ± bilgisidir.</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Gebede kaÃ§Ä±ncÄ± izlemin yapÄ±ldÄ±ÄŸÄ±nÄ± ifade eder</summary>
    [ForeignKey("KacinciGebeIzlemNavigation")]
    public string KACINCI_GEBE_IZLEM { get; set; }

    /// <summary>KadÄ±nÄ±n gebe kalmadan Ã¶nceki son Ã¢det dÃ¶neminin ilk gÃ¼nÃ¼dÃ¼r.</summary>
    public DateTime? SON_ADET_TARIHI { get; set; }

    /// <summary>KadÄ±nÄ±n bir Ã¶nceki doÄŸum durumu bilgisidir.</summary>
    [Required]
    [ForeignKey("OncekiDogumDurumuNavigation")]
    public string ONCEKI_DOGUM_DURUMU { get; set; }

    /// <summary>Gebe iÃ§in kaydÄ± tutulan izlemin saÄŸlÄ±k tesisinde yapÄ±lma bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("GebeIzlemIslemTuruNavigation")]
    public string GEBE_IZLEM_ISLEM_TURU { get; set; }

    /// <summary>Gestasyonel Diyabetes iÃ§in; OGTT gebeliÄŸin 2. trimestirinde 75 gram glukoz veril...</summary>
    [Required]
    [ForeignKey("GestasyonelDiyabetTaramasiNavigation")]
    public string GESTASYONEL_DIYABET_TARAMASI { get; set; }

    /// <summary>Gebenin izlem esnasÄ±nda idrarÄ±nda kalitatif olarak protein varlÄ±ÄŸÄ±nÄ±n deÄŸerlendi...</summary>
    [Required]
    [ForeignKey("IdrardaProteinNavigation")]
    public string IDRARDA_PROTEIN { get; set; }

    /// <summary>KiÅŸinin hemoglobin deÄŸeri bilgisidir.</summary>
    [Required]
    public string HEMOGLOBIN_DEGERI { get; set; }

    /// <summary>Gebelikte dÄ±ÅŸarÄ±dan demir desteÄŸi; demirin uygulanmayacaÄŸÄ± durumlar hariÃ§, ayrÄ±m...</summary>
    [Required]
    [ForeignKey("DemirLojistigiVeDestegiNavigation")]
    public string DEMIR_LOJISTIGI_VE_DESTEGI { get; set; }

    /// <summary>Gebeler iÃ§in; gebeliÄŸin 12. haftasÄ±ndan baÅŸlanarak doÄŸumdan sonra 6. ayÄ±n sonuna...</summary>
    [Required]
    [ForeignKey("DvitaminiLojistigiVeDestegiNavigation")]
    public string DVITAMINI_LOJISTIGI_VE_DESTEGI { get; set; }

    /// <summary>KadÄ±nÄ±n 22. gebelik haftasÄ± ve sonrasÄ±nda veya 500 gram ve Ã¼zerinde konjenital a...</summary>
    [Required]
    [ForeignKey("KonjenitalAnomaliVarligiNavigation")]
    public string KONJENITAL_ANOMALI_VARLIGI { get; set; }

    /// <summary>Gebe izlem muayenesinde tespit edilen fetusa ait kalp sesinin varlÄ±ÄŸÄ± ve sayÄ±sÄ±n...</summary>
    [Required]
    public string FETUS_KALP_SESI { get; set; }

    /// <summary>Kan basÄ±ncÄ± Ã¶lÃ§me protokolÃ¼ne uygun olarak "mm Hg" birimi ile Ã¶lÃ§Ã¼len diastolik ...</summary>
    [Required]
    public string DIASTOLIK_KAN_BASINCI_DEGERI { get; set; }

    /// <summary>Sistolik kan basÄ±ncÄ± (bÃ¼yÃ¼k tansiyon) bilgisini ifade eder.</summary>
    [Required]
    public string SISTOLIK_KAN_BASINCI_DEGERI { get; set; }

    /// <summary>Gebenin Ã¶nceki ve mevcut gebelikleri ile genel tÄ±bbi durumu deÄŸerlendirilerek be...</summary>
    [Required]
    [ForeignKey("GebelikteRiskFaktorleriNavigation")]
    public string GEBELIKTE_RISK_FAKTORLERI { get; set; }

    /// <summary>0-6 yaÅŸ dÃ¶neminde, bebeÄŸin/Ã§ocuÄŸun beyin geliÅŸimini olumsuz yÃ¶nde etkileyebilece...</summary>
    [Required]
    [ForeignKey("BcBeyinGelisimRiskleriNavigation")]
    public string BC_BEYIN_GELISIM_RISKLERI { get; set; }

    /// <summary>Anne karnÄ±ndaki dÃ¶nem dahil olmak Ã¼zere, Ã§ocuÄŸun 0-6 yaÅŸ dÃ¶neminde beyin geliÅŸim...</summary>
    [Required]
    [ForeignKey("PsikolojikGelisimRiskEgitimNavigation")]
    public string PSIKOLOJIK_GELISIM_RISK_EGITIM { get; set; }

    /// <summary>0-6 yaÅŸ dÃ¶neminde, BebeÄŸin/Ã‡ocuÄŸun beyin geliÅŸimini olumsuz yÃ¶nde etkileyebilece...</summary>
    [Required]
    [ForeignKey("RiskFaktorlerineMudahaleNavigation")]
    public string RISK_FAKTORLERINE_MUDAHALE { get; set; }

    /// <summary>Ã‡ocuÄŸun psikolojik geliÅŸiminin risk altÄ±nda olduÄŸu durumda, sÄ±k izleme alÄ±nan ol...</summary>
    [Required]
    [ForeignKey("RiskAltindakiOlguTakibiNavigation")]
    public string RISK_ALTINDAKI_OLGU_TAKIBI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? KacinciGebeIzlemNavigation { get; set; }
    public virtual REFERANS_KODLAR? OncekiDogumDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? GebeIzlemIslemTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? GestasyonelDiyabetTaramasiNavigation { get; set; }
    public virtual REFERANS_KODLAR? IdrardaProteinNavigation { get; set; }
    public virtual REFERANS_KODLAR? DemirLojistigiVeDestegiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DvitaminiLojistigiVeDestegiNavigation { get; set; }
    public virtual REFERANS_KODLAR? KonjenitalAnomaliVarligiNavigation { get; set; }
    public virtual REFERANS_KODLAR? GebelikteRiskFaktorleriNavigation { get; set; }
    public virtual REFERANS_KODLAR? BcBeyinGelisimRiskleriNavigation { get; set; }
    public virtual REFERANS_KODLAR? PsikolojikGelisimRiskEgitimNavigation { get; set; }
    public virtual REFERANS_KODLAR? RiskFaktorlerineMudahaleNavigation { get; set; }
    public virtual REFERANS_KODLAR? RiskAltindakiOlguTakibiNavigation { get; set; }
    #endregion

}
