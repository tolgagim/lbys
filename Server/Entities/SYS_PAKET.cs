using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_SYS_PAKET tablosu - 13 kolon
/// </summary>
[Table("SYS_PAKET")]
public class SYS_PAKET
{
    /// <summary>Sağlık Yönetim Sistemi (SYS) Paket Kodu, Sağlık Bilgi Yönetim Sistemi yazılımlar...</summary>
    [Key]
    public string SYS_PAKET_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alindigi SBYS veri tabanindaki tablo adinin bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık Bakanlığı Merkezi Veri Sistemine iletilmesi gereken veri paketleri için B...</summary>
    [Required]
    public string VERI_PAKETI_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinden veri paketinin e-Nabız sistemine iletildiği zaman bilgisidir.</summary>
    public DateTime VERI_PAKETI_GONDERILME_ZAMANI { get; set; }

    /// <summary>Saglik tesisinden veri paketinin e-Nabiz sistemine gönderilip gönderilmedigi bil...</summary>
    public string VERI_PAKETI_GONDERIM_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde kullanılan Sağlık Bilgi Yönetim Sistemi ile diğer bilgi sisteml...</summary>
    [Required]
    public string GONDERILEN_PAKET_BILGISI { get; set; }

    /// <summary>Sağlık tesisinde kullanılan Sağlık Bilgi Yönetim Sistemi ile diğer bilgi sisteml...</summary>
    [Required]
    public string GELEN_CEVAP_BILGISI { get; set; }

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
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}