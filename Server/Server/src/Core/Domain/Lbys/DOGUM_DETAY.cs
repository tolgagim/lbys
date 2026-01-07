using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// DOGUM_DETAY tablosu - 34 kolon
/// </summary>
[Table("DOGUM_DETAY")]
public class DOGUM_DETAY : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde doÄŸum yapan hastaya ait detay bilgilerinin kayÄ±t edilmesi iÃ§in ...</summary>
    [Key]
    public string DOGUM_DETAY_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde doÄŸum yapan hastaya ait bilgilerin kayÄ±t edilmesi iÃ§in SaÄŸlÄ±k B...</summary>
    [ForeignKey("DogumNavigation")]
    public string DOGUM_KODU { get; set; }

    /// <summary>Yeni doÄŸan bebeÄŸin doÄŸum zamanÄ± bilgisidir.</summary>
    public DateTime? DOGUM_ZAMANI { get; set; }

    /// <summary>KiÅŸinin cinsiyetini ifade eder.</summary>
    [ForeignKey("CinsiyetNavigation")]
    public string CINSIYET { get; set; }

    /// <summary>GebeliÄŸin 22. haftasÄ± ve sonrasÄ±nda veya 500 gram ve Ã¼zerinde olarak gerÃ§ekleÅŸen...</summary>
    [ForeignKey("DogumYontemiNavigation")]
    public string DOGUM_YONTEMI { get; set; }

    /// <summary>KiÅŸinin (gram cinsinden) aÄŸÄ±rlÄ±ÄŸÄ±dÄ±r.</summary>
    [Required]
    public string AGIRLIK { get; set; }

    /// <summary>KiÅŸinin santimetre cinsinden boy bilgisidir.</summary>
    [Required]
    public string BOY { get; set; }

    /// <summary>Bebek veya Ã§ocuÄŸun baÅŸ Ã§evresinin (santimetre cinsinden) Ã¶lÃ§Ã¼sÃ¼dÃ¼r.</summary>
    [Required]
    public string BAS_CEVRESI { get; set; }

    /// <summary>DoÄŸumdan 1 dakika sonra bebeÄŸin durumunu deÄŸerlendirmek iÃ§in kullanÄ±lan NÃ¼merik ...</summary>
    [Required]
    public string APGAR_1 { get; set; }

    /// <summary>DoÄŸumdan 5 dakika sonra, bebeÄŸin durumunu deÄŸerlendirmek iÃ§in kullanÄ±lan nÃ¼merik...</summary>
    [Required]
    public string APGAR_5 { get; set; }

    /// <summary>APGAR sonuÃ§larÄ±na iliÅŸkin hekim tarafÄ±ndan yazÄ±lan deÄŸerlendirme bilgisidir.</summary>
    [Required]
    public string APGAR_NOTU { get; set; }

    /// <summary>Herhangi bir mÃ¼dahale (ameliyat, doÄŸum vb.) sonrasÄ± oluÅŸan karmaÅŸÄ±k ve olumsuz k...</summary>
    [Required]
    [ForeignKey("KomplikasyonTanisiNavigation")]
    public string KOMPLIKASYON_TANISI { get; set; }

    /// <summary>Yeni doÄŸan bebeÄŸin aynÄ± gÃ¼n aynÄ± anneden doÄŸan kaÃ§Ä±ncÄ± bebek olduÄŸu bilgisidir.</summary>
    public string DOGUM_SIRASI { get; set; }

    /// <summary>Bebek veya Ã§ocuÄŸun santimetre cinsinden gÃ¶ÄŸÃ¼s Ã§evresi bilgisidir.</summary>
    [Required]
    public string GOGUS_CEVRESI { get; set; }

    /// <summary>Prognoz, tedavinin olasÄ± seyri ve sonuÃ§larÄ±na iliÅŸkin hekim tarafÄ±ndan verilen b...</summary>
    [Required]
    [ForeignKey("PrognozBilgisiNavigation")]
    public string PROGNOZ_BILGISI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde doÄŸum yapmÄ±ÅŸ hastalar iÃ§in gÃ¼n cinsinden sÃ¼rmaturasyon (GÃ¼n AÅŸÄ±...</summary>
    [Required]
    [ForeignKey("SurmatureBilgisiNavigation")]
    public string SURMATURE_BILGISI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yenidoÄŸan bebeÄŸe doÄŸduktan sonra K vitamini uygulanma durumu il...</summary>
    [Required]
    [ForeignKey("KVitaminiUygulanmaDurumuNavigation")]
    public string K_VITAMINI_UYGULANMA_DURUMU { get; set; }

    /// <summary>Saglik tesisinde yenidogan bebege dogduktan sonra Hepatit-B Asisinin yapilma dur...</summary>
    [Required]
    [ForeignKey("BebeginHepatitAsiDurumuNavigation")]
    public string BEBEGIN_HEPATIT_ASI_DURUMU { get; set; }

    /// <summary>Saglik tesisinde yenidogan bebege dogduktan sonra isitme tarama yapilma durumu i...</summary>
    [Required]
    [ForeignKey("YenidoganIsitmeTaramaDurumuNavigation")]
    public string YENIDOGAN_ISITME_TARAMA_DURUMU { get; set; }

    /// <summary>YenidoÄŸan bebeÄŸin ilk beslenme zamanÄ± bilgisidir.</summary>
    public DateTime ILK_BESLENME_ZAMANI { get; set; }

    /// <summary>DoÄŸumdan sonraki gÃ¼nlerde bebeÄŸin topuÄŸundan alÄ±nan kanÄ±n alÄ±nma durumunu ifade ...</summary>
    [Required]
    [ForeignKey("TopukKaniNavigation")]
    public string TOPUK_KANI { get; set; }

    /// <summary>Yeni doÄŸan bebeÄŸin topuk kanÄ±nÄ±n alÄ±ndÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime TOPUK_KANI_ALINMA_ZAMANI { get; set; }

    /// <summary>YenidoÄŸan bebeÄŸin adÄ± bilgisidir.</summary>
    [Required]
    public string BEBEK_ADI { get; set; }

    /// <summary>YenidoÄŸan bebeÄŸin baba T.C. Kimlik NumarasÄ± bilgisidir.</summary>
    [Required]
    public string BABA_TC_KIMLIK_NUMARASI { get; set; }

    /// <summary>Yeni doÄŸan bebeÄŸin yaÅŸam durumuna iliÅŸkin bilgiyi ifade eder. Ã–rneÄŸin canlÄ± (saÄŸ...</summary>
    [ForeignKey("BebeginYasamDurumuNavigation")]
    public string BEBEGIN_YASAM_DURUMU { get; set; }

    /// <summary>Hastaya sezaryen yapÄ±lma nedenini ifade eder.</summary>
    [Required]
    [ForeignKey("SezaryenEndikasyonlarNavigation")]
    public string SEZARYEN_ENDIKASYONLAR { get; set; }

    /// <summary>Robson On Gruplu SÄ±nÄ±flandÄ±rma Sistemi, sezaryen endikasyonlarÄ± bakÄ±mÄ±ndan objek...</summary>
    [Required]
    [ForeignKey("RobsonGrubuNavigation")]
    public string ROBSON_GRUBU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual DOGUM? DogumNavigation { get; set; }
    public virtual REFERANS_KODLAR? CinsiyetNavigation { get; set; }
    public virtual REFERANS_KODLAR? DogumYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? KomplikasyonTanisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? PrognozBilgisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SurmatureBilgisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? KVitaminiUygulanmaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? BebeginHepatitAsiDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? YenidoganIsitmeTaramaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? TopukKaniNavigation { get; set; }
    public virtual REFERANS_KODLAR? BebeginYasamDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? SezaryenEndikasyonlarNavigation { get; set; }
    public virtual REFERANS_KODLAR? RobsonGrubuNavigation { get; set; }
    #endregion

}
