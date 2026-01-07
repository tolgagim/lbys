using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_KURUM tablosu - 27 kolon
/// </summary>
[Table("KURUM")]
public class KURUM
{
    /// <summary>Kişinin yararlandığı sağlık güvencesinin kurumuna ait bilgiler için Sağlık Bilgi...</summary>
    [Key]
    public string KURUM_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Kişinin yararlandığı sağlık güvencesinin kurumuna ait ad bilgisidir.</summary>
    public string KURUM_ADI { get; set; }

    /// <summary>Hastanın sosyal güvencesinin bulunduğu kurumların gruplandırılma bilgisidir. Örn...</summary>
    [Required]
    [ForeignKey("HastaKurumTuruNavigation")]
    public string HASTA_KURUM_TURU { get; set; }

    /// <summary>Sağlık tesisinde muayene olan kişi için MEDULA tarafından Sağlık Bilgi Yönetim S...</summary>
    [Required]
    public string DEVREDILEN_KURUM { get; set; }

    /// <summary>Sağlık Kodlama Referans Sunucusu (SKRS) kod sistemlerinde tanımlanan Kurum Kodu ...</summary>
    [Required]
    [ForeignKey("SkrsKurumNavigation")]
    public string SKRS_KURUM_KODU { get; set; }

    /// <summary>Kişinin yararlandığı sağlık güvencesinin kurumuna ait adres bilgisidir.</summary>
    [Required]
    public string KURUM_ADRESI { get; set; }

    /// <summary>Sağlık tesisine ayaktan tedavi için başvuran hastalara yapılan işlemlerin geliri...</summary>
    [Required]
    public string AYAKTAN_BUTCE_KODU { get; set; }

    /// <summary>Sağlık tesisine yatarak tedavi için başvuran hastalara yapılan işlemlerin geliri...</summary>
    [Required]
    public string YATAN_BUTCE_KODU { get; set; }

    /// <summary>Sağlık tesisine günübirlik tedavi için başvuran hastalara yapılan işlemlerin gel...</summary>
    [Required]
    public string GUNUBIRLIK_BUTCE_KODU { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi veri tabanında bulunan bir kayıtın aktif olup olmad...</summary>
    [Required]
    public string AKTIFLIK_BILGISI { get; set; }

    /// <summary>Kurum bilgisinin ilk kayıt edildiği zaman bilgisidir.</summary>
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
    public virtual REFERANS_KODLAR? HastaKurumTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? SkrsKurumNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}