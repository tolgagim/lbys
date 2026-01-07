using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// KAN_TALEP tablosu - 30 kolon
/// </summary>
[Table("KAN_TALEP")]
public class KAN_TALEP
{
    /// <summary>Talep edilen kan ürünü bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [Key]
    public string KAN_TALEP_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık tesisinde kan ürününün talep edildiği zaman bilgisidir.</summary>
    public DateTime? KAN_TALEP_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde kan talep edilen kişi için yapılan açıklama bilgisidir.</summary>
    [Required]
    public string KAN_TALEP_ACIKLAMA { get; set; }

    /// <summary>Talep edilen kan ürünü için belirtilen talep nedeni bilgisidir. Örneğin ameliyat...</summary>
    [ForeignKey("KanTalepNedeniNavigation")]
    public string KAN_TALEP_NEDENI { get; set; }

    /// <summary>Sağlık tesisinde kan ürününü talep eden birim için Sağlık Bilgi Yönetim Sistemi ...</summary>
    [ForeignKey("KanIsteyenBirimNavigation")]
    public string KAN_ISTEYEN_BIRIM_KODU { get; set; }

    /// <summary>Sağlık tesisinde ilaç, malzeme, ürün vb. istemini yapan hekim için Sağlık Bilgi ...</summary>
    [ForeignKey("IsteyenHekimNavigation")]
    public string ISTEYEN_HEKIM_KODU { get; set; }

    /// <summary>Sağlık tesisinde tedavi olan hasta için istenen kan grubuna bilgisine ait Sağlık...</summary>
    [Required]
    [ForeignKey("IstenenKanGrubuNavigation")]
    public string ISTENEN_KAN_GRUBU { get; set; }

    /// <summary>Kan ürünü için planlanan transfüzyon zamanı bilgisidir.</summary>
    public DateTime PLANLANAN_TRANSFUZYON_ZAMANI { get; set; }

    /// <summary>Planlanan kan ürünü transfüzyon süresinin dakika cinsinden bilgisidir.</summary>
    [Required]
    public string PLANLANAN_TRANSFUZYON_SURESI { get; set; }

    /// <summary>Sağlık tesisinde talep edilen kan ürününün aciliyetinin seviyesine ilişkin bilgi...</summary>
    [Required]
    [ForeignKey("KanTalepAciliyetSeviyesiNavigation")]
    public string KAN_TALEP_ACILIYET_SEVIYESI { get; set; }

    /// <summary>Kan ürününe cross-match işleminin uygulanıp uygulanmayacağına ilişkin bilgiyi if...</summary>
    public string CROSS_MATCH_YAPILMA_DURUMU { get; set; }

    /// <summary>Kan ürününün acil olarak istenmesine ilişkin aciliyet sebebi bilgisidir.</summary>
    [Required]
    public string KAN_ACIL_ACIKLAMA { get; set; }

    /// <summary>Kişinin kanında herhangi bir kan gurubuna karşı antikor varlığına ilişkin bilgiy...</summary>
    public string KAN_ANTIKOR_DURUMU { get; set; }

    /// <summary>Sağlık hizmetini almak için sağlık tesisine başvuran kişinin tıbbi öyküsünde tra...</summary>
    public string TRANSPLANTASYON_GECIRME_DURUMU { get; set; }

    /// <summary>Sağlık hizmetini almak için sağlık tesisine başvuran kişinin tıbbi öyküsünde tra...</summary>
    public string TRANSFUZYON_GECIRME_DURUMU { get; set; }

    /// <summary>Sağlık hizmetini almak için sağlık tesisine başvuran kişinin tıbbi öyküsünde tra...</summary>
    public string TRANSFUZYON_REAKSIYON_DURUMU { get; set; }

    /// <summary>Hasta öyküsünde gebelik olup olmadığına ilişkin bilgiyi ifade eder.</summary>
    public string GEBELIK_GECIRME_DURUMU { get; set; }

    /// <summary>Fetusun (anne karnındaki doğmamış bebek) anne ile olan kan uyuşmazlığı olup olma...</summary>
    public string FETOMATERNAL_UYUSMAZLIK_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde kan talep edilen hasta için özel durum bilgisidir.</summary>
    [Required]
    public string KAN_TALEP_OZEL_DURUM { get; set; }

    /// <summary>Hematokrit (HCT) / Hemoglobin (HGB) oranı bilgisidir.</summary>
    [Required]
    public string HEMATOKRIT_ORANI { get; set; }

    /// <summary>Kişiden alınan kan örneğinde sayımı yapılan trombosit sayısı bilgisidir.</summary>
    [Required]
    public string TROMBOSIT_SAYISI { get; set; }

    /// <summary>Kişiye kan transfüzyonu yapılacağı zaman kanın hangi amaçla kişiye verileceğini ...</summary>
    [Required]
    [ForeignKey("KanEndikasyonTuruNavigation")]
    public string KAN_ENDIKASYON_TURU { get; set; }

    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanTalepNedeniNavigation { get; set; }
    public virtual BIRIM? KanIsteyenBirimNavigation { get; set; }
    public virtual PERSONEL? IsteyenHekimNavigation { get; set; }
    public virtual REFERANS_KODLAR? IstenenKanGrubuNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanTalepAciliyetSeviyesiNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanEndikasyonTuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}