using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_HASTA_VENTILATOR tablosu - 12 kolon
/// </summary>
[Table("HASTA_VENTILATOR")]
public class HASTA_VENTILATOR
{
    /// <summary>Sağlık tesisinde bulunan ventilatörlerin kullanım bilgisi için Sağlık Bilgi Yöne...</summary>
    [Key]
    public string HASTA_VENTILATOR_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık tesisindeki tıbbi cihazlar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("VentilatorCihazNavigation")]
    public string VENTILATOR_CIHAZ_KODU { get; set; }

    /// <summary>Sağlık tesisinde bulunan yoğun bakım yatak seviyesi bilgisidir. Örneğin 1.seviye...</summary>
    [Required]
    [ForeignKey("YogunBakimSeviyeBilgisiNavigation")]
    public string YOGUN_BAKIM_SEVIYE_BILGISI { get; set; }

    /// <summary>Hastanın ventilatöre ilk bağlandığı zaman bilgisidir.</summary>
    public DateTime? VENTILATOR_BAGLAMA_ZAMANI { get; set; }

    /// <summary>Hastanın ventilatörden ayrıldığı zaman bilgisidir.</summary>
    public DateTime VENTILATOR_AYRILMA_ZAMANI { get; set; }

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
    public virtual CIHAZ? VentilatorCihazNavigation { get; set; }
    public virtual REFERANS_KODLAR? YogunBakimSeviyeBilgisiNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}