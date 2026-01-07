using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_YATAK tablosu - 13 kolon
/// </summary>
[Table("YATAK")]
public class YATAK
{
    /// <summary>Sağlık Bilgi Yönetim Sistemi tarafından sağlık tesisindeki yataklar için üretile...</summary>
    [Key]
    public string YATAK_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde bulunan yatağın ad bilgisidir.</summary>
    public string YATAK_ADI { get; set; }

    /// <summary>Sağlık tesisinde bulunan oda için Sağlık Bilgi Yönetim Sistemi tarafından üretil...</summary>
    [ForeignKey("OdaNavigation")]
    public string ODA_KODU { get; set; }

    /// <summary>Sağlık tesisinde hasta yatağı olarak tanımlanan yatakların tür bilgisidir. Örneğ...</summary>
    [ForeignKey("YatakTuruNavigation")]
    public string YATAK_TURU { get; set; }

    /// <summary>Sağlık tesisinde bulunan yoğun bakım yatak seviyesi bilgisidir. Örneğin 1.seviye...</summary>
    [Required]
    [ForeignKey("YogunBakimYatakSeviyesiNavigation")]
    public string YOGUN_BAKIM_YATAK_SEVIYESI { get; set; }

    /// <summary>Sağlık tesisindeki tıbbi cihazlar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("VentilatorCihazNavigation")]
    public string VENTILATOR_CIHAZ_KODU { get; set; }

    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }

    #region Navigation Properties
    public virtual ODA? OdaNavigation { get; set; }
    public virtual REFERANS_KODLAR? YatakTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? YogunBakimYatakSeviyesiNavigation { get; set; }
    public virtual CIHAZ? VentilatorCihazNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}