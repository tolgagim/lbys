using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_TETKIK tablosu - 17 kolon
/// </summary>
[Table("TETKIK")]
public class TETKIK
{
    /// <summary>Sağlık tesisinde yapılan tetkikler için Sağlık Bilgi Yönetim Sistemi tarafından ...</summary>
    [Key]
    public string TETKIK_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Kişinin hastalığı veya durumu ile ilgili tanı ve tedaviye karar verme amacıyla y...</summary>
    public string TETKIK_ADI { get; set; }

    /// <summary>LOINC, Sağlık tesisinde laboratuvar veya radyolojik tetkik sonuçlarının sınıflan...</summary>
    [Required]
    public string LOINC_KODU { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanan işlemler için Sağlık Bilgi Yönetim Sistemi ta...</summary>
    [ForeignKey("HizmetNavigation")]
    public string HIZMET_KODU { get; set; }

    /// <summary>Hastaya verilen tetkik sonuç raporunda tetkik veya parametrenin bulunduğu sıra b...</summary>
    public string RAPOR_SONUC_SIRASI { get; set; }

    /// <summary>Sağlık tesisinde yapılan bir işlemin iptal edilip edilmediği bilgisidir.</summary>
    public string IPTAL_DURUMU { get; set; }

    /// <summary>Laboratuvarda yapılan tetkikler için özel bir hesaplama yöntemi kullanılıp kulla...</summary>
    public string HESAPLAMALI_TETKIK_BILGISI { get; set; }

    /// <summary>Laboratuvarda yapılan tetkikler için özel bir hesaplama yöntemi kullanılması dur...</summary>
    [Required]
    public string HESAPLAMALI_TETKIK_FORMULU { get; set; }

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
    public virtual HIZMET? HizmetNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}