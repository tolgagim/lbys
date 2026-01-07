using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// TETKIK_CIHAZ_ESLESME tablosu - 12 kolon
/// </summary>
[Table("TETKIK_CIHAZ_ESLESME")]
public class TETKIK_CIHAZ_ESLESME
{
    /// <summary>Sağlık tesisinde yapılan tetkiklerin çalışıldığı tıbbi cihazlar ile eşleştirilme...</summary>
    [Key]
    public string TETKIK_CIHAZ_ESLESME_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde bulunan cihaz için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [ForeignKey("CihazNavigation")]
    public string CIHAZ_KODU { get; set; }

    /// <summary>Sağlık tesisinde yapılan tetkikler için Sağlık Bilgi Yönetim Sistemi tarafından ...</summary>
    [ForeignKey("TetkikNavigation")]
    public string TETKIK_KODU { get; set; }

    /// <summary>Sağlık tesisinde yapılan tetkiklerdeki parametreler için Sağlık Bilgi Yönetim Si...</summary>
    [Required]
    [ForeignKey("TetkikParametreNavigation")]
    public string TETKIK_PARAMETRE_KODU { get; set; }

    /// <summary>Sağlık tesisinde bulunan cihazların hangi tetkikler için çalışma yaptığına ilişk...</summary>
    [Required]
    public string CIHAZDAN_GELEN_TEST_KODU { get; set; }

    /// <summary>Cihaza gönderilen mesajın içerisindeki testin kodu bilgisidir.</summary>
    [Required]
    public string CIHAZA_GIDEN_TEST_KODU { get; set; }

    /// <summary>Sağlık tesisinde yapılan bir işlemin iptal edilip edilmediği bilgisidir.</summary>
    public string IPTAL_DURUMU { get; set; }

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
    public virtual CIHAZ? CihazNavigation { get; set; }
    public virtual TETKIK? TetkikNavigation { get; set; }
    public virtual TETKIK_PARAMETRE? TetkikParametreNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}