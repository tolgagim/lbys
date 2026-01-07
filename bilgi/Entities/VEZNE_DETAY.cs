using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEZNE_DETAY tablosu - 11 kolon
/// </summary>
[Table("VEZNE_DETAY")]
public class VEZNE_DETAY
{
    /// <summary>Veznede yapılan işlemlerin ayrıntılı bilgisine erişim sağlamak için Sağlık Bilgi...</summary>
    [Key]
    public string VEZNE_DETAY_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisi veznesinde yapılan işlemlerin bilgisi için Sağlık Bilgi Yönetim Si...</summary>
    [ForeignKey("VezneNavigation")]
    public string VEZNE_KODU { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanacak hizmetler için Sağlık Bilgi Yönetim Sistemi...</summary>
    [Required]
    [ForeignKey("HastaHizmetNavigation")]
    public string HASTA_HIZMET_KODU { get; set; }

    /// <summary>Sağlık tesisinde hasta için kullanılan ilaç, malzeme, ürün vb. bilgiler için Sağ...</summary>
    [Required]
    [ForeignKey("HastaMalzemeNavigation")]
    public string HASTA_MALZEME_KODU { get; set; }

    /// <summary>Tek Düzen Muhasebe Sisteminde tanımlanan, yerine göre “Alıcılar Hesabı” veya "Gi...</summary>
    public string BUTCE_KODU { get; set; }

    /// <summary>Sağlık tesisinin veznesinde işlem yapılan makbuzdaki her bir satırda (kalem) bul...</summary>
    public string MAKBUZ_KALEM_TUTARI { get; set; }

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
    public virtual VEZNE? VezneNavigation { get; set; }
    public virtual HASTA_HIZMET? HastaHizmetNavigation { get; set; }
    public virtual HASTA_MALZEME? HastaMalzemeNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}