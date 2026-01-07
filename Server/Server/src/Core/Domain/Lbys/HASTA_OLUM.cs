using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// HASTA_OLUM tablosu - 24 kolon
/// </summary>
[Table("HASTA_OLUM")]
public class HASTA_OLUM : VemEntity
{
    /// <summary>Hasta Ã¶lÃ¼m bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼retilen tekil...</summary>
    [Key]
    public string HASTA_OLUM_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>KiÅŸinin Ã¶lÃ¼m zamanÄ± bilgisidir.</summary>
    public DateTime? OLUM_ZAMANI { get; set; }

    /// <summary>Ã–lÃ¼mÃ¼n gerÃ§eklestigi yeri ifade eder. Ã–rnegin ev, is, birinci basamak saglik kur...</summary>
    [Required]
    [ForeignKey("OlumYeriNavigation")]
    public string OLUM_YERI { get; set; }

    /// <summary>Bir kadÄ±nÄ±n, gebelik sÄ±rasÄ±nda ya da gebeliÄŸin sonlanmasÄ±ndan sonraki 42 gÃ¼n iÃ§i...</summary>
    [Required]
    [ForeignKey("AnneOlumNedeniNavigation")]
    public string ANNE_OLUM_NEDENI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>Ã–lÃ¼mden sonra hastalÄ±ktan kaynaklanan bir deÄŸiÅŸimin Ã¶zellikle boyutunu ya da Ã¶lÃ¼...</summary>
    [Required]
    [ForeignKey("OtopsiDurumuNavigation")]
    public string OTOPSI_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¶lÃ¼m belgesini dÃ¼zenleyen personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Si...</summary>
    [Required]
    [ForeignKey("OlumBelgesiPersonelNavigation")]
    public string OLUM_BELGESI_PERSONEL_KODU { get; set; }

    /// <summary>Ã–lÃ¼m nedeni, Ã¶lÃ¼me katkÄ±da bulunmuÅŸ ya da Ã¶lÃ¼mle sonuÃ§lanmÄ±ÅŸ tÃ¼m hastalÄ±klar, mo...</summary>
    [Required]
    [ForeignKey("OlumNedeniTaniNavigation")]
    public string OLUM_NEDENI_TANI_KODU { get; set; }

    /// <summary>Ã–lÃ¼m nedenlerinin sÄ±nÄ±flandÄ±rÄ±lmasÄ±nÄ± ifade eder. Ã–rneÄŸin son neden, ara neden v...</summary>
    [Required]
    [ForeignKey("OlumNedeniTuruNavigation")]
    public string OLUM_NEDENI_TURU { get; set; }

    /// <summary>Ã–lÃ¼mÃ¼n ne ÅŸekilde gerÃ§ekleÅŸtiÄŸini ifade eder. Ã–rneÄŸin doÄŸal Ã¶lÃ¼m, iÅŸ kazasÄ±, cin...</summary>
    [ForeignKey("OlumSekliNavigation")]
    public string OLUM_SEKLI { get; set; }

    /// <summary>KiÅŸinin Ã¶ldÃ¼ÄŸÃ¼ne dair Ã¶lÃ¼m kararÄ±nÄ± veren hekim iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistem...</summary>
    [Required]
    [ForeignKey("ExKarariniVerenHekimNavigation")]
    public string EX_KARARINI_VEREN_HEKIM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¶lÃ¼m gibi olaylar esnasÄ±nda tutulan tutanaÄŸÄ±n zaman bilgisidir.</summary>
    public DateTime TUTANAK_ZAMANI { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼, numune, adli rapor, nÃ¼fus cÃ¼zdanÄ±, malzeme vb. teslim alan kiÅŸinin T....</summary>
    [Required]
    public string TESLIM_ALAN_TC_KIMLIK_NUMARASI { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼, numune, adli rapor, nÃ¼fus cÃ¼zdanÄ±, malzeme vb. teslim alan kiÅŸinin ad...</summary>
    [Required]
    public string TESLIM_ALAN_ADI_SOYADI { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼, numune, adli rapor, nÃ¼fus cÃ¼zdanÄ±, malzeme vb. teslim alan kiÅŸinin te...</summary>
    [Required]
    public string TESLIM_ALAN_TELEFON_BILGISI { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼, numune, adli rapor, nÃ¼fus cÃ¼zdanÄ±, malzeme vb. teslim alan kiÅŸinin ad...</summary>
    [Required]
    public string TESLIM_ALAN_ADRESI { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼, numune, adli rapor, nÃ¼fus cÃ¼zdanÄ±, malzeme vb. ilgili kiÅŸiye teslim e...</summary>
    [Required]
    [ForeignKey("TeslimEdenPersonelNavigation")]
    public string TESLIM_EDEN_PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? OlumYeriNavigation { get; set; }
    public virtual REFERANS_KODLAR? AnneOlumNedeniNavigation { get; set; }
    public virtual REFERANS_KODLAR? OtopsiDurumuNavigation { get; set; }
    public virtual PERSONEL? OlumBelgesiPersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? OlumNedeniTaniNavigation { get; set; }
    public virtual REFERANS_KODLAR? OlumNedeniTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? OlumSekliNavigation { get; set; }
    public virtual PERSONEL? ExKarariniVerenHekimNavigation { get; set; }
    public virtual PERSONEL? TeslimEdenPersonelNavigation { get; set; }
    #endregion

}
