using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_KONSULTASYON tablosu - 15 kolon
/// </summary>
[Table("KONSULTASYON")]
public class KONSULTASYON
{
    /// <summary>Sağlık tesisinde tedavi alan hastanın konsültasyon bilgileri için Sağlık Bilgi Y...</summary>
    [Key]
    public string KONSULTASYON_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanacak hizmetler için Sağlık Bilgi Yönetim Sistemi...</summary>
    [ForeignKey("HastaHizmetNavigation")]
    public string HASTA_HIZMET_KODU { get; set; }

    /// <summary>Sağlık tesisinde konsültasyon yapılması amacıyla açılan yeni bir hasta başvuru k...</summary>
    [Required]
    [ForeignKey("KonsultasyonBasvuruNavigation")]
    public string KONSULTASYON_BASVURU_KODU { get; set; }

    /// <summary>Konsültasyon isteğinde bulunan hekimin yazdığı istek notu bilgisidir.</summary>
    [Required]
    public string KONSULTASYON_ISTEK_NOTU { get; set; }

    /// <summary>Sağlık tesisinde konsültasyon yapan hekimin yazdığı cevap notu bilgisidir.</summary>
    [Required]
    public string KONSULTASYON_CEVAP_NOTU { get; set; }

    /// <summary>Hekimin konsültasyon için, diğer bir hekim tarafından Sağlık Bilgi Yönetim Siste...</summary>
    public DateTime KONSULTASYONA_CAGRILMA_ZAMANI { get; set; }

    /// <summary>Hekimin konsültasyona geliş zamanı bilgisidir.</summary>
    public DateTime KONSULTASYONA_GELIS_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde tedavi olan hastaya konsültasyonun nerede yapıldığı bilgisidir....</summary>
    [ForeignKey("KonsultasyonYeriNavigation")]
    public string KONSULTASYON_YERI { get; set; }

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
    public virtual HASTA_HIZMET? HastaHizmetNavigation { get; set; }
    public virtual HASTA_BASVURU? KonsultasyonBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? KonsultasyonYeriNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}