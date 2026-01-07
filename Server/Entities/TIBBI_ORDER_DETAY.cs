using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_TIBBI_ORDER_DETAY tablosu - 16 kolon
/// </summary>
[Table("TIBBI_ORDER_DETAY")]
public class TIBBI_ORDER_DETAY
{
    /// <summary>Sağlık tesisinde sağlık hizmetini alan kişi için hekim isteminin (order) detay b...</summary>
    [Key]
    public string TIBBI_ORDER_DETAY_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde sağlık hizmetini alan kişi için hekim istemi (order) için Sağlı...</summary>
    [ForeignKey("TibbiOrderNavigation")]
    public string TIBBI_ORDER_KODU { get; set; }

    /// <summary>Order’ın hastaya hangi saatte uygulanacağını belirten zaman bilgisidir.</summary>
    public DateTime? PLANLANAN_UYGULANMA_ZAMANI { get; set; }

    /// <summary>Hekim tarafından yapılan istemi (order) uygulayan hemşireye ait Sağlık Bilgi Yön...</summary>
    [Required]
    [ForeignKey("UygulayanHemsireNavigation")]
    public string UYGULAYAN_HEMSIRE_KODU { get; set; }

    /// <summary>Hekim tarafından yapılan istemin (order’ın) uygulandığı zaman bilgisidir.</summary>
    public DateTime UYGULAMA_ZAMANI { get; set; }

    /// <summary>Hekim tarafından yapılan istem (order) için gereken işlemin hastaya uygulanma du...</summary>
    public string UYGULANMA_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde sağlık hizmetini alan kişi için hekim istemi (order) iptal edil...</summary>
    [Required]
    [ForeignKey("TibbiOrderIptalNedeniNavigation")]
    public string TIBBI_ORDER_IPTAL_NEDENI { get; set; }

    /// <summary>Sağlık tesisinde yapılması planlanan bir tedavi işlemini iptal eden hemşire bilg...</summary>
    [Required]
    [ForeignKey("IptalEdenHemsireNavigation")]
    public string IPTAL_EDEN_HEMSIRE_KODU { get; set; }

    /// <summary>Sağlık tesisinde üretilen verinin iptal edildiği zaman bilgisidir.</summary>
    public DateTime IPTAL_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

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
    public virtual TIBBI_ORDER? TibbiOrderNavigation { get; set; }
    public virtual PERSONEL? UygulayanHemsireNavigation { get; set; }
    public virtual REFERANS_KODLAR? TibbiOrderIptalNedeniNavigation { get; set; }
    public virtual PERSONEL? IptalEdenHemsireNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}