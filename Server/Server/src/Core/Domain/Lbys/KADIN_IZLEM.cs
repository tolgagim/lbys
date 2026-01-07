using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// KADIN_IZLEM tablosu - 20 kolon
/// </summary>
[Table("KADIN_IZLEM")]
public class KADIN_IZLEM : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde muayene olan kadÄ±n hastalarÄ±n 15-49 yaÅŸ arasÄ± izlem bilgileri i...</summary>
    [Key]
    public string KADIN_IZLEM_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± tablo adÄ± bilgisidir.</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>KadÄ±nÄ±n 22. gebelik haftasÄ± ve sonrasÄ±nda veya 500 gram ve Ã¼zerinde konjenital a...</summary>
    [Required]
    [ForeignKey("KonjenitalAnomaliVarligiNavigation")]
    public string KONJENITAL_ANOMALI_VARLIGI { get; set; }

    /// <summary>GebeliÄŸin 22. haftasÄ± ve sonrasÄ±nda veya 500 gram ve Ã¼zerinde doÄŸmuÅŸ, doÄŸduÄŸunda...</summary>
    [Required]
    public string CANLI_DOGAN_BEBEK_SAYISI { get; set; }

    /// <summary>GebeliÄŸin 22. haftasÄ± ve sonrasÄ±nda veya 500 gram ve Ã¼zerinde dÃ¼nyaya gelmiÅŸ, hi...</summary>
    [Required]
    public string OLU_DOGAN_BEBEK_SAYISI { get; set; }

    /// <summary>KiÅŸinin hemoglobin deÄŸeri bilgisidir.</summary>
    [Required]
    public string HEMOGLOBIN_DEGERI { get; set; }

    /// <summary>DoÄŸum yapan kadÄ±nÄ±n bir Ã¶nceki doÄŸumuna iliÅŸkin doÄŸum durumu bilgisidir. Ã–rneÄŸin...</summary>
    [ForeignKey("OncekiDogumDurumuNavigation")]
    public string ONCEKI_DOGUM_DURUMU { get; set; }

    /// <summary>Ä°zlemin yapÄ±ldÄ±ÄŸÄ± kurum bilgisidir.</summary>
    public string IZLEMIN_YAPILDIGI_YER { get; set; }

    /// <summary>KadÄ±nÄ±n gebeliÄŸi Ã¶nlemek iÃ§in kullandÄ±ÄŸÄ± yÃ¶ntemi ifade eder.</summary>
    [Required]
    [ForeignKey("KullanilanApYontemiNavigation")]
    public string KULLANILAN_AP_YONTEMI { get; set; }

    /// <summary>Bir Ã¶nceki kullanÄ±lan Aile PlanlamasÄ± (AP) yÃ¶ntemlerini tanÄ±mlamaktadÄ±r.</summary>
    [Required]
    [ForeignKey("BirOnceKullanilanApYontemiNavigation")]
    public string BIR_ONCE_KULLANILAN_AP_YONTEMI { get; set; }

    /// <summary>Hekim tarafÄ±ndan verilen Aile PlanlamasÄ± (AP) YÃ¶nteminin verilme durumuna iliÅŸki...</summary>
    [Required]
    [ForeignKey("ApYontemiLojistigiNavigation")]
    public string AP_YONTEMI_LOJISTIGI { get; set; }

    /// <summary>Gebelik Ã¶ncesi, gebelik sÃ¼resi ve gebelik sonrasÄ± dÃ¶nemlerde kadÄ±n saÄŸlÄ±ÄŸÄ± aÃ§Ä±sÄ±...</summary>
    [Required]
    [ForeignKey("KadinSagligiIslemleriNavigation")]
    public string KADIN_SAGLIGI_ISLEMLERI { get; set; }

    /// <summary>KadÄ±nÄ±n, Aile PlanlamasÄ± (AP) YÃ¶ntemi kullanmama gerekÃ§esini ifade eder.</summary>
    [Required]
    public string AP_YONTEMI_KULLANMAMA_NEDENI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? KonjenitalAnomaliVarligiNavigation { get; set; }
    public virtual REFERANS_KODLAR? OncekiDogumDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? KullanilanApYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? BirOnceKullanilanApYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? ApYontemiLojistigiNavigation { get; set; }
    public virtual REFERANS_KODLAR? KadinSagligiIslemleriNavigation { get; set; }
    #endregion

}
