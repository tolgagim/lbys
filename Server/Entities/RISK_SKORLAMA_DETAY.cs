using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_RISK_SKORLAMA_DETAY tablosu - 11 kolon
/// </summary>
[Table("RISK_SKORLAMA_DETAY")]
public class RISK_SKORLAMA_DETAY
{
    /// <summary>Sağlık tesisinde kullanılan Risk Skorlama detay bilgileri için Sağlık Bilgi Yöne...</summary>
    [Key]
    public string RISK_SKORLAMA_DETAY_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde kullanılan Risk Skorlama bilgileri için Sağlık Bilgi Yönetim Si...</summary>
    [ForeignKey("RiskSkorlamaNavigation")]
    public string RISK_SKORLAMA_KODU { get; set; }

    /// <summary>Hastanin bilinç durumunun degerlendirilmesinde kullanilan güvenilir ve objektif ...</summary>
    [Required]
    public string GLASGOW_SKALASI { get; set; }

    /// <summary>Seçilen risk skorlama türünde bulunan alt tür bilgisidir. Örneğin risk skorlama ...</summary>
    [ForeignKey("RiskSkorlamaAltTuruNavigation")]
    public string RISK_SKORLAMA_ALT_TURU { get; set; }

    /// <summary>Risk skorlama alt türüne göre aldığı değer bilgisidir.</summary>
    [Required]
    public string RISK_SKOR_DEGERI { get; set; }

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
    public virtual RISK_SKORLAMA? RiskSkorlamaNavigation { get; set; }
    public virtual REFERANS_KODLAR? RiskSkorlamaAltTuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}