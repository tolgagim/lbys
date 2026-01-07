using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// ILAC_UYUM tablosu - 17 kolon
/// </summary>
[Table("ILAC_UYUM")]
public class ILAC_UYUM
{
    /// <summary>Hastaya verilen ilaçlar arasında uyum bilgisi için Sağlık Bilgi Yönetim Sistemi ...</summary>
    [Key]
    public string ILAC_UYUM_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Hastaya verilen ilaçlar arasında tespit edilen uyumsuzluk için yapılan sınıfland...</summary>
    [ForeignKey("IlacUyumsuzlukTuruNavigation")]
    public string ILAC_UYUMSUZLUK_TURU { get; set; }

    /// <summary>Sağlık tesisinde birlikte kullanılan ilaçlar arasında etkileşim durumu sorgulama...</summary>
    [Required]
    [ForeignKey("BirinciIlacBarkoduNavigation")]
    public string BIRINCI_ILAC_BARKODU { get; set; }

    /// <summary>İlacın içeriğinde bulunan etken maddeler için Sağlık Bilgi Yönetim Sistemi taraf...</summary>
    [Required]
    [ForeignKey("BirinciEtkenMaddeNavigation")]
    public string BIRINCI_ETKEN_MADDE_KODU { get; set; }

    /// <summary>Sağlık tesisinde birlikte kullanılan ilaçlar arasında etkileşim durumu sorgulama...</summary>
    [Required]
    [ForeignKey("IkinciIlacBarkoduNavigation")]
    public string IKINCI_ILAC_BARKODU { get; set; }

    /// <summary>İlacın içeriğinde bulunan etken maddeler için Sağlık Bilgi Yönetim Sistemi taraf...</summary>
    [Required]
    [ForeignKey("IkinciEtkenMaddeNavigation")]
    public string IKINCI_ETKEN_MADDE_KODU { get; set; }

    /// <summary>İlaçlarla, besinlerle etkileşebilecek veya alerji yapabilecek besin tanımları iç...</summary>
    [Required]
    [ForeignKey("BesinNavigation")]
    public string BESIN_KODU { get; set; }

    /// <summary>Yaş başlangıcının gün cinsinden değer bilgisidir.</summary>
    [Required]
    public string YAS_BASLANGIC { get; set; }

    /// <summary>Yaş bitişinin gün cinsinden değer bilgisidir</summary>
    [Required]
    public string YAS_BITIS { get; set; }

    /// <summary>Kişinin cinsiyetini ifade eder.</summary>
    [Required]
    [ForeignKey("CinsiyetNavigation")]
    public string CINSIYET { get; set; }

    /// <summary>İlaç ile ilgili uyarıları verebilmek için Sağlık Bilgi Yönetim Sistemi tarafında...</summary>
    [ForeignKey("RenkSeviyeNavigation")]
    public string RENK_SEVIYE_KODU { get; set; }

    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

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
    public virtual REFERANS_KODLAR? IlacUyumsuzlukTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? BirinciIlacBarkoduNavigation { get; set; }
    public virtual REFERANS_KODLAR? BirinciEtkenMaddeNavigation { get; set; }
    public virtual REFERANS_KODLAR? IkinciIlacBarkoduNavigation { get; set; }
    public virtual REFERANS_KODLAR? IkinciEtkenMaddeNavigation { get; set; }
    public virtual REFERANS_KODLAR? BesinNavigation { get; set; }
    public virtual REFERANS_KODLAR? CinsiyetNavigation { get; set; }
    public virtual REFERANS_KODLAR? RenkSeviyeNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}