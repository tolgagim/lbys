using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// COCUK_DIYABET tablosu - 29 kolon
/// </summary>
[Table("COCUK_DIYABET")]
public class COCUK_DIYABET : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde bulunan cihaz iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼ret...</summary>
    [Key]
    public string COCUK_DIYABET_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Hastaya izlem ve tedavi uygulanacak olan hastalÄ±k (diyabetis mellitus, kanser, H...</summary>
    public DateTime? ILK_TANI_TARIHI { get; set; }

    /// <summary>KiÅŸinin (gram cinsinden) aÄŸÄ±rlÄ±ÄŸÄ± bilgisidir.</summary>
    [Required]
    public string AGIRLIK { get; set; }

    /// <summary>KiÅŸinin santimetre cinsinden boy bilgisidir.</summary>
    [Required]
    public string BOY { get; set; }

    /// <summary>KiÅŸinin diyabet tipi bilgisidir.</summary>
    [ForeignKey("DiyabetTipiNavigation")]
    public string DIYABET_TIPI { get; set; }

    /// <summary>KÄ±z Ã§ocuÄŸuna ait menarÅŸ yaÅŸÄ± bilgisidir.</summary>
    [Required]
    public string KIZ_COCUKLARDA_MENARS_YASI { get; set; }

    /// <summary>KiÅŸide beyin Ã¶demi olup olmadÄ±ÄŸÄ±na iliÅŸkin bilgiyi ifade eder.</summary>
    [ForeignKey("BeyinOdemiDurumuNavigation")]
    public string BEYIN_ODEMI_DURUMU { get; set; }

    /// <summary>KiÅŸide son 3 ay iÃ§erisinde ketoasidoz geliÅŸip geliÅŸmediÄŸine ait bilgidir.</summary>
    [ForeignKey("KetoasidozDurumuNavigation")]
    public string KETOASIDOZ_DURUMU { get; set; }

    /// <summary>Ã‡ocuÄŸun diyabet hastalÄ±ÄŸÄ±na iliÅŸkin ÅŸikayet bilgilerini ifade eder.</summary>
    [Required]
    [ForeignKey("DiyabetSikayetNavigation")]
    public string DIYABET_SIKAYET { get; set; }

    /// <summary>Ã‡ocuÄŸun diyabet ÅŸikayetlerine iliÅŸkin sÃ¼re bilgisidir.</summary>
    [Required]
    public string SIKAYETIN_SURESI { get; set; }

    /// <summary>Ã‡ocuÄŸun aksiller kÄ±llanmasÄ±na ait durum bilgisidir.</summary>
    [Required]
    [ForeignKey("AksillerKillanmaDurumuNavigation")]
    public string AKSILLER_KILLANMA_DURUMU { get; set; }

    /// <summary>Ã‡ocuÄŸun pubik kÄ±llanmasÄ±na ait durum bilgisidir.</summary>
    [Required]
    [ForeignKey("PubikKillanmaDurumuNavigation")]
    public string PUBIK_KILLANMA_DURUMU { get; set; }

    /// <summary>Ã‡ocuÄŸun meme geliÅŸim evresine ait durum bilgisidir.</summary>
    [Required]
    [ForeignKey("MemeEvreNavigation")]
    public string MEME_EVRE { get; set; }

    /// <summary>SaÄŸ testisin ml cinsinden hacim bilgisini ifade eder.</summary>
    [Required]
    public string TESTIS_VOLUM_SAG { get; set; }

    /// <summary>Sol testisin ml cinsinden hacim bilgisini ifade eder.</summary>
    [Required]
    public string TESTIS_VOLUM_SOL { get; set; }

    /// <summary>Ã‡ocuÄŸun eÅŸlik eden baÅŸka hastalÄ±k bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("EslikedenHastalikNavigation")]
    public string ESLIKEDEN_HASTALIK { get; set; }

    /// <summary>Ã‡ocuÄŸun eÅŸlik eden baÅŸka hastalÄ±k tanÄ± tarihi bilgisini ifade eder.</summary>
    public DateTime ESLIKEDEN_HASTALIK_TANI_TARIHI { get; set; }

    /// <summary>Ã‡ocuÄŸa uygulanan ilaÃ§ tedavi ÅŸekline ait bilgiyi ifade eder.</summary>
    [ForeignKey("DiyabetIlacTedaviSekliNavigation")]
    public string DIYABET_ILAC_TEDAVI_SEKLI { get; set; }

    /// <summary>Ã‡ocuÄŸun diyet tedavisi durum bilgisini ifade eder.</summary>
    [ForeignKey("DiyetTibbiBeslenmeTedavisiNavigation")]
    public string DIYET_TIBBI_BESLENME_TEDAVISI { get; set; }

    /// <summary>Ã‡ocuÄŸun diyabet hastasÄ± olan aile bireyi bilgisidir.</summary>
    [ForeignKey("DiyabetliHastaAileOykusuNavigation")]
    public string DIYABETLI_HASTA_AILE_OYKUSU { get; set; }

    /// <summary>Hastaya diyabet eÄŸitim verilip verilmediÄŸi bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("DiyabetEgitimiVerilmeDurumuNavigation")]
    public string DIYABET_EGITIMI_VERILME_DURUMU { get; set; }

    /// <summary>Tiroid muayenesi sonucuna iliÅŸkin ait bilgiyi ifade eder.</summary>
    [ForeignKey("TiroidMuayenesiNavigation")]
    public string TIROID_MUAYENESI { get; set; }

    /// <summary>Diyabet hastaliginin mikro ve makrovaskÃ¼ler komplikasyonlarini ifade eder.</summary>
    [Required]
    [ForeignKey("DiyabetKomplikasyonlariNavigation")]
    public string DIYABET_KOMPLIKASYONLARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyabetTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? BeyinOdemiDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? KetoasidozDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyabetSikayetNavigation { get; set; }
    public virtual REFERANS_KODLAR? AksillerKillanmaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? PubikKillanmaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? MemeEvreNavigation { get; set; }
    public virtual REFERANS_KODLAR? EslikedenHastalikNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyabetIlacTedaviSekliNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyetTibbiBeslenmeTedavisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyabetliHastaAileOykusuNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyabetEgitimiVerilmeDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? TiroidMuayenesiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyabetKomplikasyonlariNavigation { get; set; }
    #endregion

}
