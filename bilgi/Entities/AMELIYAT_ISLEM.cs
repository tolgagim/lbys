using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// AMELIYAT_ISLEM tablosu - 21 kolon
/// </summary>
[Table("AMELIYAT_ISLEM")]
public class AMELIYAT_ISLEM
{
    /// <summary>Sağlık tesisinde yapılan ameliyatın işlem bilgilerine erişim sağlamak için Sağlı...</summary>
    [Key]
    public string AMELIYAT_ISLEM_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde yapılan ameliyatın bilgilerine erişim sağlamak için Sağlık Bilg...</summary>
    [ForeignKey("AmeliyatNavigation")]
    public string AMELIYAT_KODU { get; set; }

    /// <summary>Tıbbi İşlemler Listesinde yayımlanan ameliyat grubu bilgisidir. Örneğin A1, A2, ...</summary>
    [Required]
    public string AMELIYAT_GRUBU { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanacak hizmetler için Sağlık Bilgi Yönetim Sistemi...</summary>
    [ForeignKey("HastaHizmetNavigation")]
    public string HASTA_HIZMET_KODU { get; set; }

    /// <summary>Cerrahi uygulama sırasında yapılan kesi sayısı bilgisidir.</summary>
    public string KESI_SAYISI { get; set; }

    /// <summary>Cerrahi uygulama sırasında yapılan kesi için belirlenen oran bilgisidir. Örneğin...</summary>
    [Required]
    [ForeignKey("KesiOraniNavigation")]
    public string KESI_ORANI { get; set; }

    /// <summary>Hastaya uygulanan cerrahi girişimde seans ve kesi arasındaki ilişkiyi ifade eden...</summary>
    [Required]
    [ForeignKey("KesiSeansBilgisiNavigation")]
    public string KESI_SEANS_BILGISI { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanan işlemin vücudun hangi tarafına yapıldığına il...</summary>
    [Required]
    [ForeignKey("TarafBilgisiNavigation")]
    public string TARAF_BILGISI { get; set; }

    /// <summary>Sağlık tesisinde tedavi alan hastaya uygulanan cerrahi girişim sonrasında hastad...</summary>
    [Required]
    public string KOMPLIKASYON { get; set; }

    /// <summary>Sağlık tesisinde yapılan ameliyatın sonuç bilgisini ifade eder.</summary>
    [Required]
    public string AMELIYAT_SONUCU { get; set; }

    /// <summary>Sağlık tesisinde yapılan ameliyatın tüm süreçlerine ilişkin operatör tarafından ...</summary>
    [Required]
    public string AMELIYAT_NOTU { get; set; }

    /// <summary>Sağlık tesisinde ameliyat olacak hastanın ameliyat öncesi fiziki sağlık durumunu...</summary>
    [Required]
    [ForeignKey("AsaSkoruNavigation")]
    public string ASA_SKORU { get; set; }

    /// <summary>Avrupa Kardiyak Operasyonel Risk Değerlendirme Sistemi (EuroSCORE), kalp ameliya...</summary>
    [Required]
    [ForeignKey("EuroscoreNavigation")]
    public string EUROSCORE { get; set; }

    /// <summary>Sağlık hizmetini alan kişinin vücudunda bulunan/oluşan yaraların sınıfına ilişki...</summary>
    [Required]
    [ForeignKey("YaraSinifiNavigation")]
    public string YARA_SINIFI { get; set; }

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
    public virtual AMELIYAT? AmeliyatNavigation { get; set; }
    public virtual HASTA_HIZMET? HastaHizmetNavigation { get; set; }
    public virtual REFERANS_KODLAR? KesiOraniNavigation { get; set; }
    public virtual REFERANS_KODLAR? KesiSeansBilgisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? TarafBilgisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsaSkoruNavigation { get; set; }
    public virtual REFERANS_KODLAR? EuroscoreNavigation { get; set; }
    public virtual REFERANS_KODLAR? YaraSinifiNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}