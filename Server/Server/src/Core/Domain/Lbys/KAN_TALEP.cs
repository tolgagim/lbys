using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// KAN_TALEP tablosu - 30 kolon
/// </summary>
[Table("KAN_TALEP")]
public class KAN_TALEP : VemEntity
{
    /// <summary>Talep edilen kan Ã¼rÃ¼nÃ¼ bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [Key]
    public string KAN_TALEP_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kan Ã¼rÃ¼nÃ¼nÃ¼n talep edildiÄŸi zaman bilgisidir.</summary>
    public DateTime? KAN_TALEP_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kan talep edilen kiÅŸi iÃ§in yapÄ±lan aÃ§Ä±klama bilgisidir.</summary>
    [Required]
    public string KAN_TALEP_ACIKLAMA { get; set; }

    /// <summary>Talep edilen kan Ã¼rÃ¼nÃ¼ iÃ§in belirtilen talep nedeni bilgisidir. Ã–rneÄŸin ameliyat...</summary>
    [ForeignKey("KanTalepNedeniNavigation")]
    public string KAN_TALEP_NEDENI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kan Ã¼rÃ¼nÃ¼nÃ¼ talep eden birim iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi ...</summary>
    [ForeignKey("KanIsteyenBirimNavigation")]
    public string KAN_ISTEYEN_BIRIM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde ilaÃ§, malzeme, Ã¼rÃ¼n vb. istemini yapan hekim iÃ§in SaÄŸlÄ±k Bilgi ...</summary>
    [ForeignKey("IsteyenHekimNavigation")]
    public string ISTEYEN_HEKIM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavi olan hasta iÃ§in istenen kan grubuna bilgisine ait SaÄŸlÄ±k...</summary>
    [Required]
    [ForeignKey("IstenenKanGrubuNavigation")]
    public string ISTENEN_KAN_GRUBU { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼ iÃ§in planlanan transfÃ¼zyon zamanÄ± bilgisidir.</summary>
    public DateTime PLANLANAN_TRANSFUZYON_ZAMANI { get; set; }

    /// <summary>Planlanan kan Ã¼rÃ¼nÃ¼ transfÃ¼zyon sÃ¼resinin dakika cinsinden bilgisidir.</summary>
    [Required]
    public string PLANLANAN_TRANSFUZYON_SURESI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde talep edilen kan Ã¼rÃ¼nÃ¼nÃ¼n aciliyetinin seviyesine iliÅŸkin bilgi...</summary>
    [Required]
    [ForeignKey("KanTalepAciliyetSeviyesiNavigation")]
    public string KAN_TALEP_ACILIYET_SEVIYESI { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼ne cross-match iÅŸleminin uygulanÄ±p uygulanmayacaÄŸÄ±na iliÅŸkin bilgiyi if...</summary>
    public string CROSS_MATCH_YAPILMA_DURUMU { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼nÃ¼n acil olarak istenmesine iliÅŸkin aciliyet sebebi bilgisidir.</summary>
    [Required]
    public string KAN_ACIL_ACIKLAMA { get; set; }

    /// <summary>KiÅŸinin kanÄ±nda herhangi bir kan gurubuna karÅŸÄ± antikor varlÄ±ÄŸÄ±na iliÅŸkin bilgiy...</summary>
    public string KAN_ANTIKOR_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k hizmetini almak iÃ§in saÄŸlÄ±k tesisine baÅŸvuran kiÅŸinin tÄ±bbi Ã¶ykÃ¼sÃ¼nde tra...</summary>
    public string TRANSPLANTASYON_GECIRME_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k hizmetini almak iÃ§in saÄŸlÄ±k tesisine baÅŸvuran kiÅŸinin tÄ±bbi Ã¶ykÃ¼sÃ¼nde tra...</summary>
    public string TRANSFUZYON_GECIRME_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k hizmetini almak iÃ§in saÄŸlÄ±k tesisine baÅŸvuran kiÅŸinin tÄ±bbi Ã¶ykÃ¼sÃ¼nde tra...</summary>
    public string TRANSFUZYON_REAKSIYON_DURUMU { get; set; }

    /// <summary>Hasta Ã¶ykÃ¼sÃ¼nde gebelik olup olmadÄ±ÄŸÄ±na iliÅŸkin bilgiyi ifade eder.</summary>
    public string GEBELIK_GECIRME_DURUMU { get; set; }

    /// <summary>Fetusun (anne karnÄ±ndaki doÄŸmamÄ±ÅŸ bebek) anne ile olan kan uyuÅŸmazlÄ±ÄŸÄ± olup olma...</summary>
    public string FETOMATERNAL_UYUSMAZLIK_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kan talep edilen hasta iÃ§in Ã¶zel durum bilgisidir.</summary>
    [Required]
    public string KAN_TALEP_OZEL_DURUM { get; set; }

    /// <summary>Hematokrit (HCT) / Hemoglobin (HGB) oranÄ± bilgisidir.</summary>
    [Required]
    public string HEMATOKRIT_ORANI { get; set; }

    /// <summary>KiÅŸiden alÄ±nan kan Ã¶rneÄŸinde sayÄ±mÄ± yapÄ±lan trombosit sayÄ±sÄ± bilgisidir.</summary>
    [Required]
    public string TROMBOSIT_SAYISI { get; set; }

    /// <summary>KiÅŸiye kan transfÃ¼zyonu yapÄ±lacaÄŸÄ± zaman kanÄ±n hangi amaÃ§la kiÅŸiye verileceÄŸini ...</summary>
    [Required]
    [ForeignKey("KanEndikasyonTuruNavigation")]
    public string KAN_ENDIKASYON_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanTalepNedeniNavigation { get; set; }
    public virtual BIRIM? KanIsteyenBirimNavigation { get; set; }
    public virtual PERSONEL? IsteyenHekimNavigation { get; set; }
    public virtual REFERANS_KODLAR? IstenenKanGrubuNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanTalepAciliyetSeviyesiNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanEndikasyonTuruNavigation { get; set; }
    #endregion

}
