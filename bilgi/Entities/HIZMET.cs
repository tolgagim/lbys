using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// HIZMET tablosu - 15 kolon
/// </summary>
[Table("HIZMET")]
public class HIZMET
{
    /// <summary>Sağlık tesisinde hastaya uygulanan işlemler için Sağlık Bilgi Yönetim Sistemi ta...</summary>
    [Key]
    public string HIZMET_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde kullanılan tetkik, tedavi vb. işlemlerinin gruplandırılması içi...</summary>
    [Required]
    [ForeignKey("HizmetIslemGrubuNavigation")]
    public string HIZMET_ISLEM_GRUBU { get; set; }

    /// <summary>Sağlık tesisinde kullanılan tetkik, tedavi vb. işlemleri için Sağlık Bilgi Yönet...</summary>
    [Required]
    [ForeignKey("HizmetIslemTuruNavigation")]
    public string HIZMET_ISLEM_TURU { get; set; }

    /// <summary>Sosyal Güvenlik Kurumu tarafından yayımlanan, hastaya uygulanan işlem veya hizme...</summary>
    [Required]
    public string SUT_KODU { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanan işlemler için Sağlık Bilgi Yönetim Sisteminde...</summary>
    public string HIZMET_ADI { get; set; }

    /// <summary>Sağlık tesisinde sağlık hizmetini alan kişi için yapılan işlemlere ilişkin puan ...</summary>
    [Required]
    [ForeignKey("TibbiIslemPuanBilgisiNavigation")]
    public string TIBBI_ISLEM_PUAN_BILGISI { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi veri tabanında bulunan bir kayıtın aktif olup olmad...</summary>
    public string AKTIFLIK_BILGISI { get; set; }

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
    public virtual REFERANS_KODLAR? HizmetIslemGrubuNavigation { get; set; }
    public virtual REFERANS_KODLAR? HizmetIslemTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? TibbiIslemPuanBilgisiNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}