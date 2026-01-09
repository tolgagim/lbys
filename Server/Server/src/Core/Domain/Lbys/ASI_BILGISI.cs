using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// ASI_BILGISI tablosu - 27 kolon
/// </summary>
[Table("ASI_BILGISI")]
public class ASI_BILGISI : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde aÅŸÄ±lar ile ilgili iÅŸlemler (yapÄ±lan, ertelenen, iptal edilen aÅŸ...</summary>
    [Key]
    public string ASI_BILGISI_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± tablo adÄ± bilgisidir.</summary>
/// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>AÅŸÄ±, aktif ve kazanÄ±lmÄ±ÅŸ baÄŸÄ±ÅŸÄ±klÄ±ÄŸÄ±n saÄŸlanmasÄ± amacÄ± ile canlÄ± veya Ã¶lÃ¼ mikroo...</summary>
    [ForeignKey("AsiNavigation")]
    public string ASI_KODU { get; set; }

    /// <summary>AÅŸÄ±nÄ±n (antijenin) kaÃ§Ä±ncÄ± kez yapÄ±ldÄ±ÄŸÄ±nÄ± ifade eder.</summary>
    [ForeignKey("AsininDozuNavigation")]
    public string ASININ_DOZU { get; set; }

    /// <summary>AÅŸÄ±nÄ±n uygulandÄ±ÄŸÄ± yolu ifade eder.</summary>
    [ForeignKey("AsininUygulamaSekliNavigation")]
    public string ASININ_UYGULAMA_SEKLI { get; set; }

    /// <summary>AÅŸÄ±nÄ±n uygulandÄ±ÄŸÄ± anatomik bÃ¶lgeyi ifade eder.</summary>
    [ForeignKey("AsiUygulamaYeriNavigation")]
    public string ASI_UYGULAMA_YERI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kiÅŸiye aÅŸÄ± uygulanmadan Ã¶nce SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi taraf...</summary>
    [Required]
    public string ASI_SORGU_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kayÄ±t altÄ±na alÄ±nan aÅŸÄ± bilgisinin saÄŸlÄ±k tesisinde yapÄ±lma bil...</summary>
    [ForeignKey("AsiIslemTuruNavigation")]
    public string ASI_ISLEM_TURU { get; set; }

    /// <summary>Bilgi alÄ±nan kiÅŸinin ad soyadÄ± bilgisidir.</summary>
    [Required]
    public string BILGI_ALINAN_KISI_AD_SOYADI { get; set; }

    /// <summary>Bilgi alÄ±nan kiÅŸinin telefon numarasÄ± bilgisidir.</summary>
    [Required]
    public string BILGI_ALINAN_KISI_TELEFON { get; set; }

    /// <summary>AÅŸÄ± yapÄ±lma zamanÄ± bilgisidir.</summary>
    public DateTime? ASI_YAPILMA_ZAMANI { get; set; }

    /// <summary>Bir aÅŸÄ± takvime dahil olsa dahi kiÅŸinin saÄŸlÄ±k sorunlarÄ±ndan dolayÄ± aynÄ± dozun b...</summary>
    [Required]
    [ForeignKey("AsiOzelDurumNedeniNavigation")]
    public string ASI_OZEL_DURUM_NEDENI { get; set; }

    /// <summary>AÅŸÄ± SonrasÄ± Ä°stenmeyen Etki (ASÄ°E) 'nin baÅŸladÄ±ÄŸÄ± zamanÄ± ifade eder.</summary>
    public DateTime ASIE_ORTAYA_CIKIS_ZAMANI { get; set; }

    /// <summary>Bildirimi Zorunlu AÅŸÄ± SonrasÄ± Ä°stenmeyen Etki (ASÄ°E) saptanmasÄ± durumunda bunun ...</summary>
    [Required]
    [ForeignKey("AsieNedenleriNavigation")]
    public string ASIE_NEDENLERI { get; set; }

    /// <summary>KiÅŸinin planlÄ± aÅŸÄ±sÄ±nÄ±n kaÃ§ gÃ¼n sÃ¼re ile ertelendiÄŸi bilgisidir.</summary>
    [Required]
    public string ASI_ERTELEME_SURESI { get; set; }

    /// <summary>AÅŸÄ±nÄ±n ertelenme/iptal edilme durumunu tanÄ±mlar. Ã–rneÄŸin ertelendi, iptal edildi...</summary>
    [Required]
    [ForeignKey("AsiYapilmamaDurumuNavigation")]
    public string ASI_YAPILMAMA_DURUMU { get; set; }

    /// <summary>BebeÄŸe/Ã‡ocuÄŸa yapÄ±lmasÄ± gereken ama ertelenen/iptal edilen aÅŸÄ±nÄ±n neden ertelend...</summary>
    [Required]
    [ForeignKey("AsiYapilmamaNedeniNavigation")]
    public string ASI_YAPILMAMA_NEDENI { get; set; }

    /// <summary>AÅŸÄ±nÄ±n planlanan zamanda yapÄ±lmamasÄ±na neden olan hastalÄ±k bilgisidir.</summary>
    [Required]
    [ForeignKey("AlttaYatanHastalikNavigation")]
    public string ALTTA_YATAN_HASTALIK { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsiNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsininDozuNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsininUygulamaSekliNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsiUygulamaYeriNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsiIslemTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsiOzelDurumNedeniNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsieNedenleriNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsiYapilmamaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsiYapilmamaNedeniNavigation { get; set; }
    public virtual REFERANS_KODLAR? AlttaYatanHastalikNavigation { get; set; }
    #endregion

}
