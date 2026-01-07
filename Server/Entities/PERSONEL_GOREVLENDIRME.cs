using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_PERSONEL_GOREVLENDIRME tablosu - 13 kolon
/// </summary>
[Table("PERSONEL_GOREVLENDIRME")]
public class PERSONEL_GOREVLENDIRME
{
    /// <summary>Sağlık tesisinde görevli personelin görevlendirilme bilgileri için Sağlık Bilgi ...</summary>
    [Key]
    public string PERSONEL_GOREVLENDIRME_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin yaptığı görev için Sağlık Bilgi Yönetim Sist...</summary>
    [ForeignKey("GorevTuruNavigation")]
    public string GOREV_TURU { get; set; }

    /// <summary>Sağlık tesisindeki personelin görevlendirildiği kurumda göreve başladığı tarih b...</summary>
    public DateTime? GOREVLENDIRME_BASLAMA_TARIHI { get; set; }

    /// <summary>Sağlık tesisindeki personelin görevlendirildiği kurumda görevinin bittiği tarih ...</summary>
    public DateTime GOREVLENDIRME_BITIS_TARIHI { get; set; }

    /// <summary>Sağlık tesisindeki personelin görevlendirildiği ilin, il kodunu ifade eder.</summary>
    [Required]
    [ForeignKey("GorevlendirmeIlNavigation")]
    public string GOREVLENDIRME_IL_KODU { get; set; }

    /// <summary>Sağlık tesisindeki personelin görevlendirildiği ilçenin, ilçe kodunu ifade eder.</summary>
    [Required]
    [ForeignKey("GorevlendirmeIlceNavigation")]
    public string GOREVLENDIRME_ILCE_KODU { get; set; }

    /// <summary>Sağlık tesisindeki personelin görevlendirildiği kurum için Sağlık Bilgi Yönetim ...</summary>
    [Required]
    [ForeignKey("GorevlendirildigiKurumNavigation")]
    public string GOREVLENDIRILDIGI_KURUM_KODU { get; set; }

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
    public virtual PERSONEL? PersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? GorevTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? GorevlendirmeIlNavigation { get; set; }
    public virtual REFERANS_KODLAR? GorevlendirmeIlceNavigation { get; set; }
    public virtual KURUM? GorevlendirildigiKurumNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}