using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// BEBEK_COCUK_IZLEM tablosu - 37 kolon
/// </summary>
[Table("BEBEK_COCUK_IZLEM")]
public class BEBEK_COCUK_IZLEM : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde muayene olan bebek ve/veya Ã§ocuklarÄ±n izlem bilgileri iÃ§in SaÄŸl...</summary>
    [Key]
    public string BEBEK_COCUK_IZLEM_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± tablo adÄ± bilgisidir.</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Bebek ve Ã§ocuklar iÃ§in SaÄŸlÄ±k BakanlÄ±ÄŸÄ± tarafÄ±ndan tanÄ±mlanan izlem protokolÃ¼ ka...</summary>
    [ForeignKey("KacinciIzlemNavigation")]
    public string KACINCI_IZLEM { get; set; }

    /// <summary>Ä°shal tanÄ±sÄ± alan 0-59 ay bebek ve Ã§ocuklarda AÄŸÄ±zdan SÄ±vÄ± Tedavisi (AST) bilgis...</summary>
    [Required]
    [ForeignKey("AgizdanSiviTedavisiNavigation")]
    public string AGIZDAN_SIVI_TEDAVISI { get; set; }

    /// <summary>Bebek veya Ã§ocuÄŸun baÅŸ Ã§evresinin (santimetre cinsinden) Ã¶lÃ§Ã¼sÃ¼dÃ¼r.</summary>
    [Required]
    public string BAS_CEVRESI { get; set; }

    /// <summary>Gebelikte dÄ±ÅŸarÄ±dan demir desteÄŸi; demirin uygulanmayacaÄŸÄ± durumlar hariÃ§, ayrÄ±m...</summary>
    [Required]
    [ForeignKey("DemirLojistigiVeDestegiNavigation")]
    public string DEMIR_LOJISTIGI_VE_DESTEGI { get; set; }

    /// <summary>BebeÄŸin doÄŸum aÄŸÄ±rlÄ±ÄŸÄ±nÄ± gram olarak ifade eder.</summary>
    [Required]
    public string DOGUM_AGIRLIGI { get; set; }

    /// <summary>Gebeler iÃ§in; gebeliÄŸin 12. haftasÄ±ndan baÅŸlanarak doÄŸumdan sonra 6. ayÄ±n sonuna...</summary>
    [Required]
    [ForeignKey("DvitaminiLojistigiVeDestegiNavigation")]
    public string DVITAMINI_LOJISTIGI_VE_DESTEGI { get; set; }

    /// <summary>GeliÅŸimsel KalÃ§a Displazisi (GKD) tarama sonucu bilgisidir.</summary>
    [ForeignKey("GkdTaramaSonucuNavigation")]
    public string GKD_TARAMA_SONUCU { get; set; }

    /// <summary>Bebek veya Ã§ocuÄŸun hematokrit deÄŸeri bilgisidir.</summary>
    [Required]
    public string HEMATOKRIT_DEGERI { get; set; }

    /// <summary>KiÅŸinin hemoglobin deÄŸeri bilgisidir.</summary>
    [Required]
    public string HEMOGLOBIN_DEGERI { get; set; }

    /// <summary>DoÄŸumdan sonraki gÃ¼nlerde bebeÄŸin topuÄŸundan alÄ±nan kanÄ±n alÄ±nma durumunu ifade ...</summary>
    [Required]
    [ForeignKey("TopukKaniNavigation")]
    public string TOPUK_KANI { get; set; }

    /// <summary>Yeni doÄŸan bebeÄŸin topuk kanÄ±nÄ±n alÄ±ndÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime TOPUK_KANI_ALINMA_ZAMANI { get; set; }

    /// <summary>Ä°zlemin yapÄ±ldÄ±ÄŸÄ± kurum bilgisidir.</summary>
    [Required]
    [ForeignKey("IzleminYapildigiYerNavigation")]
    public string IZLEMIN_YAPILDIGI_YER { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hastaya yapÄ±lan izlemleri (bebek Ã§ocuk izlem, gebe izlem vb.) y...</summary>
    [Required]
    [ForeignKey("IzlemiYapanPersonelNavigation")]
    public string IZLEMI_YAPAN_PERSONEL_KODU { get; set; }

    /// <summary>Bilgi alÄ±nan kiÅŸinin ad ve soyadÄ± bilgisidir.</summary>
    [Required]
    public string BILGI_ALINAN_KISI_AD_SOYADI { get; set; }

    /// <summary>Bilgi alÄ±nan kiÅŸinin telefon bilgisidir.</summary>
    [Required]
    public string BILGI_ALINAN_KISI_TELEFON { get; set; }

    /// <summary>Bebekte yapÄ±lan muayene ve risk faktÃ¶rlerinin belirlenmesi sonucu geliÅŸimsel kal...</summary>
    [Required]
    [ForeignKey("BebekteRiskFaktorleriNavigation")]
    public string BEBEKTE_RISK_FAKTORLERI { get; set; }

    /// <summary>Bebekte yapÄ±lan ve bebek saÄŸlÄ±ÄŸÄ± iÅŸlemleri veri elemanÄ±nda yer alan tarama testl...</summary>
    [Required]
    [ForeignKey("TaramaSonucuNavigation")]
    public string TARAMA_SONUCU { get; set; }

    /// <summary>BebeÄŸin anne sÃ¼tÃ¼nden tamamen kesildiÄŸi (ay cinsinden) yaÅŸÄ±nÄ± ifade eder.</summary>
    [Required]
    public string ANNE_SUTUNDEN_KESILDIGI_AY { get; set; }

    /// <summary>BebeÄŸin anne sÃ¼tÃ¼ ile beslenmesi durumuna iliÅŸkin bilgidir. Ã–rneÄŸin sadece anne ...</summary>
    [Required]
    [ForeignKey("BebeginBeslenmeDurumuNavigation")]
    public string BEBEGIN_BESLENME_DURUMU { get; set; }

    /// <summary>BebeÄŸin anne sÃ¼tÃ¼ dÄ±ÅŸÄ±nda gÄ±da almaya baÅŸladÄ±ÄŸÄ± (ay cinsinden) yaÅŸÄ±nÄ± ifade eder...</summary>
    [Required]
    public string EK_GIDAYA_BASLADIGI_AY { get; set; }

    /// <summary>BebeÄŸin veya Ã§ocuÄŸun anne sÃ¼tÃ¼ aldÄ±ÄŸÄ± sÃ¼renin ay cinsinden bilgisini ifade eder.</summary>
    [Required]
    public string SADECE_ANNE_SUTU_ALDIGI_SURE { get; set; }

    /// <summary>BebeÄŸin/Ã§ocuÄŸun geliÅŸim bilgilerinin sorgulanmasÄ±dÄ±r.</summary>
    [Required]
    [ForeignKey("GelisimTablosuBilgileriNavigation")]
    public string GELISIM_TABLOSU_BILGILERI { get; set; }

    [Required]
    [ForeignKey("NtpTakipBilgisiNavigation")]
    public string NTP_TAKIP_BILGISI { get; set; }

    /// <summary>0-6 yaÅŸ dÃ¶neminde, bebeÄŸin/Ã§ocuÄŸun beyin geliÅŸimini olumsuz yÃ¶nde etkileyebilece...</summary>
    [Required]
    [ForeignKey("BcBeyinGelisimRiskleriNavigation")]
    public string BC_BEYIN_GELISIM_RISKLERI { get; set; }

    /// <summary>Anne/babanÄ±n, bebeÄŸin veya Ã§ocuÄŸun psikolojik geliÅŸimini destekleyebilmek amacÄ± ...</summary>
    [Required]
    [ForeignKey("EbeveynDestekAktiviteleriNavigation")]
    public string EBEVEYN_DESTEK_AKTIVITELERI { get; set; }

    /// <summary>Anne karnÄ±ndaki dÃ¶nem dahil olmak Ã¼zere, Ã§ocuÄŸun 0-6 yaÅŸ dÃ¶neminde beyin geliÅŸim...</summary>
    [Required]
    [ForeignKey("BcPsikolojikRiskEgitimNavigation")]
    public string BC_PSIKOLOJIK_RISK_EGITIM { get; set; }

    /// <summary>0-6 yaÅŸ dÃ¶neminde, BebeÄŸin/Ã‡ocuÄŸun beyin geliÅŸimini olumsuz yÃ¶nde etkileyebilece...</summary>
    [Required]
    [ForeignKey("BcRiskYapilanMudahaleNavigation")]
    public string BC_RISK_YAPILAN_MUDAHALE { get; set; }

    /// <summary>Ã‡ocuÄŸun psikolojik geliÅŸiminin risk altÄ±nda olduÄŸu durumda, sÄ±k izleme alÄ±nan ol...</summary>
    [Required]
    [ForeignKey("BcRiskliOlguTakibiNavigation")]
    public string BC_RISKLI_OLGU_TAKIBI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? KacinciIzlemNavigation { get; set; }
    public virtual REFERANS_KODLAR? AgizdanSiviTedavisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DemirLojistigiVeDestegiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DvitaminiLojistigiVeDestegiNavigation { get; set; }
    public virtual REFERANS_KODLAR? GkdTaramaSonucuNavigation { get; set; }
    public virtual REFERANS_KODLAR? TopukKaniNavigation { get; set; }
    public virtual REFERANS_KODLAR? IzleminYapildigiYerNavigation { get; set; }
    public virtual PERSONEL? IzlemiYapanPersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? BebekteRiskFaktorleriNavigation { get; set; }
    public virtual REFERANS_KODLAR? TaramaSonucuNavigation { get; set; }
    public virtual REFERANS_KODLAR? BebeginBeslenmeDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? GelisimTablosuBilgileriNavigation { get; set; }
    public virtual REFERANS_KODLAR? NtpTakipBilgisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? BcBeyinGelisimRiskleriNavigation { get; set; }
    public virtual REFERANS_KODLAR? EbeveynDestekAktiviteleriNavigation { get; set; }
    public virtual REFERANS_KODLAR? BcPsikolojikRiskEgitimNavigation { get; set; }
    public virtual REFERANS_KODLAR? BcRiskYapilanMudahaleNavigation { get; set; }
    public virtual REFERANS_KODLAR? BcRiskliOlguTakibiNavigation { get; set; }
    #endregion

}
