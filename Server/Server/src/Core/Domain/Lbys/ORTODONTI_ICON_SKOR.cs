using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// ORTODONTI_ICON_SKOR tablosu - 39 kolon
/// </summary>
[Table("ORTODONTI_ICON_SKOR")]
public class ORTODONTI_ICON_SKOR : VemEntity
{
    /// <summary>Ortodonti Icon Skor bilgisi iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼retile...</summary>
    [Key]
    public string ORTODONTI_ICON_SKOR_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>DiÅŸ tedavisi yapÄ±lan hastalar iÃ§in Ortodonti Icon Skor (OIS) formunun deÄŸerlendi...</summary>
    public DateTime? OIS_DEGERLENDIRME_ZAMANI { get; set; }

    /// <summary>HastanÄ±n diÅŸlerindeki estetik bozukluÄŸun Ortodonti Icon Skor (OIS) standartlarÄ±n...</summary>
    [Required]
    public string OIS_ESTETIK_BOZUKLUK_BILGISI { get; set; }

    /// <summary>Ortodonti Icon Skor (OIS) standartlarÄ±na gÃ¶re belirlenmiÅŸ estetik puanÄ±nÄ±n hesap...</summary>
    [Required]
    public string OIS_ESTETIK_PUAN_KATSAYISI { get; set; }

    /// <summary>Ortodonti Icon Skor (OIS) standartlarÄ±na gÃ¶re belirlenmiÅŸ estetik bozukluk derec...</summary>
    [Required]
    public string OIS_ESTETIK_PUANI { get; set; }

    /// <summary>Ãœst Ã§ene diÅŸlerindeki Ã§apraÅŸÄ±klÄ±ÄŸÄ±n derecesinin bilgisidir.</summary>
    [Required]
    public string UST_DIS_ARKA_CAPRASIKLIK { get; set; }

    /// <summary>Ãœst Ã§ene diÅŸlerindeki Ã§apraÅŸÄ±klÄ±k puanÄ±nÄ±n hesaplanmasÄ± iÃ§in gerekli olan katsay...</summary>
    [Required]
    public string UST_ARKA_CAPRASIKLIK_KATSAYISI { get; set; }

    /// <summary>Ãœst Ã§apraÅŸÄ±klÄ±k derecesi ile katsayÄ±sÄ±nÄ±n Ã§arpÄ±mÄ± ile hesaplanan puan bilgisidir...</summary>
    [Required]
    public string UST_ARKA_CAPRASIKLIK_PUANI { get; set; }

    /// <summary>Ãœst Ã§ene diÅŸlerindeki boÅŸluk derecesinin bilgisidir.</summary>
    [Required]
    public string UST_DIS_ARKA_BOSLUK { get; set; }

    /// <summary>Ãœst Ã§ene diÅŸlerindeki boÅŸluk puanÄ±nÄ±n hesaplanmasÄ± iÃ§in gerekli olan katsayÄ± bil...</summary>
    [Required]
    public string UST_ARKA_BOSLUK_KATSAYISI { get; set; }

    /// <summary>Ãœst Ã§ene diÅŸlerindeki boÅŸluk derecesi ve katsayÄ±sÄ±nÄ±n Ã§arpÄ±mÄ± ile hesaplanan pua...</summary>
    [Required]
    public string UST_ARKA_BOSLUK_PUANI { get; set; }

    /// <summary>KiÅŸinin diÅŸlerinde Ã§aprazlÄ±k olup olmadÄ±ÄŸÄ± bilgisidir.</summary>
    [Required]
    public string DIS_CAPRAZLIK_DURUMU { get; set; }

    /// <summary>Ortodonti Icon SkorlamasÄ±nda kullanÄ±lan Ã§aprazlÄ±k puanÄ±nÄ±n hesaplanmasÄ± iÃ§in ger...</summary>
    [Required]
    public string DIS_CAPRAZLIK_KATSAYISI { get; set; }

    /// <summary>Ortodonti Icon SkorlamasÄ± iÃ§in diÅŸlerde Ã§aprazlÄ±k katsayÄ±sÄ± kullanÄ±larak hesapla...</summary>
    [Required]
    public string DIS_CAPRAZLIK_PUANI { get; set; }

    /// <summary>KiÅŸinin diÅŸlerinde, Ã¶n aÃ§Ä±k kapanÄ±ÅŸ bozukluÄŸu iÃ§in milimetre cinsinden derece bi...</summary>
    [Required]
    public string ON_ACIK_KAPANIS { get; set; }

    /// <summary>KiÅŸinin diÅŸlerinde, Ã¶n aÃ§Ä±k kapanÄ±ÅŸ puanÄ±nÄ±n hesaplanmasÄ± iÃ§in katsayÄ± bilgisidi...</summary>
    [Required]
    public string ON_ACIK_KAPANIS_KATSAYISI { get; set; }

    /// <summary>KiÅŸinin diÅŸlerinde, Ã¶n aÃ§Ä±k kapanÄ±ÅŸ katsayÄ±sÄ± ve Ã¶n aÃ§Ä±k kapanÄ±ÅŸ derecesinin Ã§ar...</summary>
    [Required]
    public string ON_ACIK_KAPANIS_PUANI { get; set; }

    /// <summary>KiÅŸinin diÅŸlerinde, Ã¶n derin kapanÄ±ÅŸ bozukluÄŸu iÃ§in milimetre cinsinden derece b...</summary>
    [Required]
    public string ON_DERIN_KAPANIS { get; set; }

    /// <summary>KiÅŸinin diÅŸlerinde, Ã¶n derin kapanÄ±ÅŸ puanÄ±nÄ±n hesaplanmasÄ± iÃ§in katsayÄ± bilgisid...</summary>
    [Required]
    public string ON_DERIN_KAPANIS_KATSAYISI { get; set; }

    /// <summary>KiÅŸinin diÅŸlerinde, Ã¶n derin kapanÄ±ÅŸ katsayÄ±sÄ± ve Ã¶n derin kapanÄ±ÅŸ derecesinin Ã§...</summary>
    [Required]
    public string ON_DERIN_KAPANIS_PUANI { get; set; }

    /// <summary>SaÄŸ bukkal (yanak) bÃ¶lgesinde bulunan diÅŸlerin Ã¶n-arka yÃ¶n iliÅŸki derecesi bilgi...</summary>
    [Required]
    public string BUKKAL_BOLGE_SAG { get; set; }

    /// <summary>SaÄŸ bukkal (yanak) bÃ¶lge puanÄ±nÄ±n hesaplanmasÄ± iÃ§in gerekli katsayÄ± bilgisidir.</summary>
    [Required]
    public string BUKKAL_BOLGE_SAG_KATSAYISI { get; set; }

    /// <summary>SaÄŸ bukkal (yanak) bÃ¶lge puanÄ± bilgisidir.</summary>
    [Required]
    public string BUKKAL_BOLGE_SAG_PUANI { get; set; }

    /// <summary>Sol bukkal (yanak) bÃ¶lgesinde bulunan diÅŸlerin Ã¶n-arka yÃ¶n iliÅŸki derecesi bilgi...</summary>
    [Required]
    public string BUKKAL_BOLGE_SOL { get; set; }

    /// <summary>Sol bukkal (yanak) bÃ¶lge puanÄ±nÄ±n hesaplanmasÄ± iÃ§in gerekli katsayÄ± bilgisidir.</summary>
    [Required]
    public string BUKKAL_BOLGE_SOL_KATSAYISI { get; set; }

    /// <summary>Sol bukkal (yanak) bÃ¶lge puanÄ± bilgisidir.</summary>
    [Required]
    public string BUKKAL_BOLGE_SOL_PUANI { get; set; }

    /// <summary>Bukkal (yanak) bÃ¶lge saÄŸ ve sol puanlarÄ±nÄ±n toplanarak elde edildiÄŸi toplam bukk...</summary>
    [Required]
    public string BUKKAL_TOPLAM_PUANI { get; set; }

    /// <summary>Ortodonti iÃ§in tÃ¼m kriterlerin puanlarÄ±nÄ±n toplandÄ±ÄŸÄ± toplam puan bilgisidir.</summary>
    [Required]
    public string TOPLAM_ICON_SKOR_PUANI { get; set; }

    /// <summary>DiÅŸ tedavisi yapÄ±lan hastalar iÃ§in Ortodonti Icon Skoru (OIS) form bilgilerini d...</summary>
    [Required]
    [ForeignKey("OisDegerlendiren1HekimNavigation")]
    public string OIS_DEGERLENDIREN_1_HEKIM_KODU { get; set; }

    /// <summary>DiÅŸ tedavisi yapÄ±lan hastalar iÃ§in Ortodonti Icon Skoru (OIS) form bilgilerini d...</summary>
    [Required]
    [ForeignKey("OisDegerlendiren2HekimNavigation")]
    public string OIS_DEGERLENDIREN_2_HEKIM_KODU { get; set; }

    /// <summary>DiÅŸ tedavisi yapÄ±lan hastalar iÃ§in Ortodonti Icon Skoru (OIS) form bilgilerini d...</summary>
    [Required]
    [ForeignKey("OisDegerlendiren3HekimNavigation")]
    public string OIS_DEGERLENDIREN_3_HEKIM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual PERSONEL? OisDegerlendiren1HekimNavigation { get; set; }
    public virtual PERSONEL? OisDegerlendiren2HekimNavigation { get; set; }
    public virtual PERSONEL? OisDegerlendiren3HekimNavigation { get; set; }
    #endregion

}
