using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_RISK_SKORLAMA tablosu - 17 kolon
/// </summary>
[Table("RISK_SKORLAMA")]
public class RISK_SKORLAMA
{
    /// <summary>Sağlık tesisinde kullanılan Risk Skorlama bilgileri için Sağlık Bilgi Yönetim Si...</summary>
    [Key]
    public string RISK_SKORLAMA_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisinde kullanılan APACHE, SNAP, SAPS, İtaki, Harizmi vb. gibi risk sko...</summary>
    [ForeignKey("RiskSkorlamaTuruNavigation")]
    public string RISK_SKORLAMA_TURU { get; set; }

    /// <summary>Sağlık tesisinde yapılan işlemlerin, uygulanmaya başladığı zaman bilgisidir.</summary>
    public DateTime? ISLEM_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde tedavi gören hastanın ölüm oranı riskini belirleyebilmek için k...</summary>
    [Required]
    public string RISK_SKORLAMA_TOPLAM_PUANI { get; set; }

    /// <summary>Sağlık tesisinde kullanılan risk skorlama sistemi ile belirlenen, hastanın bekle...</summary>
    [Required]
    public string BEKLENEN_OLUM_ORANI { get; set; }

    /// <summary>Hastanin bilinç durumunun degerlendirilmesinde kullanilan güvenilir ve objektif ...</summary>
    [Required]
    public string GLASGOW_SKALASI { get; set; }

    /// <summary>Sağlık tesisinde kullanılan risk skorlama sistemi ile belirlenen düzeltilmiş bek...</summary>
    [Required]
    public string DUZELTILMISBEKLENEN_OLUM_ORANI { get; set; }

    /// <summary>Sağlık tesisinde sağlık hizmetini alan kişi için hekim isteminin (order) detay b...</summary>
    [Required]
    [ForeignKey("TibbiOrderDetayNavigation")]
    public string TIBBI_ORDER_DETAY_KODU { get; set; }

    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
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
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual REFERANS_KODLAR? RiskSkorlamaTuruNavigation { get; set; }
    public virtual TIBBI_ORDER_DETAY? TibbiOrderDetayNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}