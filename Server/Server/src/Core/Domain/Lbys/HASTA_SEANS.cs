using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// HASTA_SEANS tablosu - 35 kolon
/// </summary>
[Table("HASTA_SEANS")]
public class HASTA_SEANS : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde tedavi kapsamÄ±nda hastalara verilen seans bilgileri iÃ§in SaÄŸlÄ±k...</summary>
    [Key]
    public string HASTA_SEANS_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>HastanÄ±n saÄŸlÄ±k tesisinde tedavisinin gereÄŸi olarak aldÄ±ÄŸÄ± seansÄ±n hangi tedavi ...</summary>
    [ForeignKey("SeansIslemTuruNavigation")]
    public string SEANS_ISLEM_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan cihaz iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼ret...</summary>
    [Required]
    [ForeignKey("CihazNavigation")]
    public string CIHAZ_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hastaya uygulanan tedavi kapsamÄ±nda yapÄ±lmasÄ± planlanan seans t...</summary>
    public DateTime? PLANLANAN_SEANS_TARIHI { get; set; }

    /// <summary>HastanÄ±n saÄŸlÄ±k tesisinde tedavisinin gereÄŸi olarak aldÄ±ÄŸÄ± seansa baÅŸladÄ±ÄŸÄ± zama...</summary>
    public DateTime SEANS_BASLAMA_ZAMANI { get; set; }

    /// <summary>HastanÄ±n saÄŸlÄ±k tesisinde tedavisinin gereÄŸi olarak aldÄ±ÄŸÄ± seansÄ±n bittiÄŸi zaman...</summary>
    public DateTime SEANS_BITIS_ZAMANI { get; set; }

    /// <summary>KiÅŸinin kullandÄ±ÄŸÄ± antihipertansif ilaÃ§ kullanÄ±m durumunu ifade eder.</summary>
    [Required]
    [ForeignKey("AntihipertansifIlacDurumuNavigation")]
    public string ANTIHIPERTANSIF_ILAC_DURUMU { get; set; }

    /// <summary>KiÅŸinin Ã–nceki Renal Replasman yÃ¶ntemi bilgisidir.</summary>
    [ForeignKey("OncekiRrtYontemiNavigation")]
    public string ONCEKI_RRT_YONTEMI { get; set; }

    /// <summary>KiÅŸinin hemodiyalize geÃ§me nedenini ifade eder.</summary>
    [Required]
    [ForeignKey("HemodiyalizeGecmeNedenleriNavigation")]
    public string HEMODIYALIZE_GECME_NEDENLERI { get; set; }

    /// <summary>HastanÄ±n tedavisi iÃ§in ne tÃ¼r damar eriÅŸim yolu kullanÄ±ldÄ±ÄŸÄ±nÄ± ifade eder.</summary>
    [Required]
    [ForeignKey("DamarErisimYoluNavigation")]
    public string DAMAR_ERISIM_YOLU { get; set; }

    /// <summary>HastanÄ±n haftada kaÃ§ defa diyaliz tedavisi aldÄ±ÄŸÄ±nÄ± ifade eder.</summary>
    [Required]
    [ForeignKey("DiyalizeGirmeSikligiNavigation")]
    public string DIYALIZE_GIRME_SIKLIGI { get; set; }

    /// <summary>Diyaliz hastasÄ±nÄ±n beden kitle endeksine gÃ¶re kullanÄ±lacak olan metrekare cinsin...</summary>
    [Required]
    [ForeignKey("DiyalizorAlaniNavigation")]
    public string DIYALIZOR_ALANI { get; set; }

    /// <summary>HastanÄ±n diyalizi iÃ§in kullanÄ±lan diyalizÃ¶r tipi bilgisidir.</summary>
    [Required]
    [ForeignKey("DiyalizorTipiNavigation")]
    public string DIYALIZOR_TIPI { get; set; }

    /// <summary>Hemodiyaliz tedavisi iÃ§in kullanÄ±lan cihazda ayarlanan kan akÄ±m hÄ±zÄ±dÄ±r.</summary>
    [Required]
    [ForeignKey("KanAkimHiziNavigation")]
    public string KAN_AKIM_HIZI { get; set; }

    /// <summary>KiÅŸinin aÄŸÄ±rlÄ±ÄŸÄ±nÄ±n Ã¶lÃ§Ã¼m zamanÄ± bilgisidir.</summary>
    [Required]
    [ForeignKey("AgirlikOlcumZamaniNavigation")]
    public string AGIRLIK_OLCUM_ZAMANI { get; set; }

    /// <summary>Hastaya uygulanan tedavi yÃ¶ntemini ifade eder.</summary>
    [Required]
    [ForeignKey("KullanilanDiyalizTedavisiNavigation")]
    public string KULLANILAN_DIYALIZ_TEDAVISI { get; set; }

    /// <summary>HastanÄ±n peritoneal geÃ§irgenlik durumunu ifade eder. Ã–rneÄŸin dÃ¼ÅŸÃ¼k, orta, yÃ¼ksek...</summary>
    [Required]
    [ForeignKey("PeritonealGecirgenlikDurumuNavigation")]
    public string PERITONEAL_GECIRGENLIK_DURUMU { get; set; }

    /// <summary>Periton diyalizi gÃ¶ren hastanÄ±n kaÃ§Ä±ncÄ± kateteri olduÄŸunu ifade eder.</summary>
    [Required]
    [ForeignKey("PeritonKacinciKateterNavigation")]
    public string PERITON_KACINCI_KATETER { get; set; }

    /// <summary>Periton diyalizinde kullanÄ±lan kateter tipini ifade eder. Ã–rneÄŸin curlet tenckho...</summary>
    [Required]
    [ForeignKey("PeritonKateterTipiNavigation")]
    public string PERITON_KATETER_TIPI { get; set; }

    /// <summary>Periton diyalizi tedavisi gÃ¶ren hastaya uygulanan kateter yerleÅŸtirme yÃ¶ntemini ...</summary>
    [Required]
    [ForeignKey("PeritonKateterYontemiNavigation")]
    public string PERITON_KATETER_YONTEMI { get; set; }

    /// <summary>Periton diyalizi tedavisi uygulanan hastanÄ±n kateter iÃ§in aÃ§Ä±lan tÃ¼nel yÃ¶nÃ¼nÃ¼ if...</summary>
    [Required]
    [ForeignKey("PeritonTunelYonuNavigation")]
    public string PERITON_TUNEL_YONU { get; set; }

    /// <summary>HastanÄ±n sekonder hiperparatiroidizm tedavisine ihtiyacÄ± olup olmadÄ±ÄŸÄ±nÄ±, ihtiya...</summary>
    [Required]
    [ForeignKey("SinekalsetNavigation")]
    public string SINEKALSET { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hastaya uygulanan tedavinin seyir bilgisidir. Ã–rneÄŸin diyaliz t...</summary>
    [Required]
    [ForeignKey("TedavininSeyriNavigation")]
    public string TEDAVININ_SEYRI { get; set; }

    /// <summary>HastanÄ±n aktif Vitamin D kullanÄ±m ihtiyacÄ±nÄ± ve uygulama yolunu ifade eder.</summary>
    [Required]
    [ForeignKey("AktifVitaminDKullanimiNavigation")]
    public string AKTIF_VITAMIN_D_KULLANIMI { get; set; }

    /// <summary>HastanÄ±n anemi tedavisine ihtiyacÄ± olup olmadÄ±ÄŸÄ±nÄ±, ihtiyacÄ± varsa hangi yÃ¶nteml...</summary>
    [Required]
    [ForeignKey("AnemiTedavisiYontemiNavigation")]
    public string ANEMI_TEDAVISI_YONTEMI { get; set; }

    /// <summary>HastanÄ±n fosfor baÄŸlayÄ±cÄ± ajan ile tedavi ihtiyacÄ± olup olmadÄ±ÄŸÄ±nÄ±, ihtiyacÄ± var...</summary>
    [Required]
    [ForeignKey("FosforBaglayiciAjanNavigation")]
    public string FOSFOR_BAGLAYICI_AJAN { get; set; }

    /// <summary>Periton diyalizi tedavisi verilen hastada gÃ¶rÃ¼len komplikasyonlarÄ± ifade eder. Ã–...</summary>
    [Required]
    [ForeignKey("PeritonKomplikasyonNavigation")]
    public string PERITON_KOMPLIKASYON { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? SeansIslemTuruNavigation { get; set; }
    public virtual CIHAZ? CihazNavigation { get; set; }
    public virtual REFERANS_KODLAR? AntihipertansifIlacDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? OncekiRrtYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? HemodiyalizeGecmeNedenleriNavigation { get; set; }
    public virtual REFERANS_KODLAR? DamarErisimYoluNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyalizeGirmeSikligiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyalizorAlaniNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyalizorTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanAkimHiziNavigation { get; set; }
    public virtual REFERANS_KODLAR? AgirlikOlcumZamaniNavigation { get; set; }
    public virtual REFERANS_KODLAR? KullanilanDiyalizTedavisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? PeritonealGecirgenlikDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? PeritonKacinciKateterNavigation { get; set; }
    public virtual REFERANS_KODLAR? PeritonKateterTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? PeritonKateterYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? PeritonTunelYonuNavigation { get; set; }
    public virtual REFERANS_KODLAR? SinekalsetNavigation { get; set; }
    public virtual REFERANS_KODLAR? TedavininSeyriNavigation { get; set; }
    public virtual REFERANS_KODLAR? AktifVitaminDKullanimiNavigation { get; set; }
    public virtual REFERANS_KODLAR? AnemiTedavisiYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? FosforBaglayiciAjanNavigation { get; set; }
    public virtual REFERANS_KODLAR? PeritonKomplikasyonNavigation { get; set; }
    #endregion

}
