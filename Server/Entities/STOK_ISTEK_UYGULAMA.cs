using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_STOK_ISTEK_UYGULAMA tablosu - 15 kolon
/// </summary>
[Table("STOK_ISTEK_UYGULAMA")]
public class STOK_ISTEK_UYGULAMA
{
    /// <summary>Sağlık tesisinde hekim tarafından yapılan istemin (order) uygulama bilgilerine e...</summary>
    [Key]
    public string STOK_ISTEK_UYGULAMA_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta için depodan yapılan isteklerin detay bilgilerine erişim ...</summary>
    [ForeignKey("StokIstekHareketNavigation")]
    public string STOK_ISTEK_HAREKET_KODU { get; set; }

    /// <summary>Order'ın hastaya uygulanma zamanına ilişkin planlanan zaman bilgisidir.</summary>
    public DateTime? ORDER_PLANLANAN_ZAMAN { get; set; }

    /// <summary>Order’ın hastaya uygulandığı zaman bilgisidir.</summary>
    public DateTime ORDER_UYGULANAN_ZAMAN { get; set; }

    /// <summary>Hekim tarafından yapılan istemi (order) uygulayan hemşireye ait Sağlık Bilgi Yön...</summary>
    [Required]
    [ForeignKey("UygulayanHemsireNavigation")]
    public string UYGULAYAN_HEMSIRE_KODU { get; set; }

    /// <summary>Sağlık tesisinde tedavi gören hastaya ait istemin iptal edilmesine ilişkin bilgi...</summary>
    [Required]
    [ForeignKey("IstekIptalNedeniNavigation")]
    public string ISTEK_IPTAL_NEDENI { get; set; }

    /// <summary>Sağlık tesisinde yapılması planlanan bir tedavi işlemini iptal eden hemşire bilg...</summary>
    [Required]
    [ForeignKey("IptalEdenHemsireNavigation")]
    public string IPTAL_EDEN_HEMSIRE_KODU { get; set; }

    /// <summary>Sağlık tesisinde üretilen verinin iptal edildiği zaman bilgisidir.</summary>
    public DateTime IPTAL_ZAMANI { get; set; }

    /// <summary>Hekim tarafından yapılan istemde (order’ın) miktar bilgisi olması durumunda iste...</summary>
    [Required]
    public string UYGULANAN_MIKTAR { get; set; }

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
    public virtual STOK_ISTEK_HAREKET? StokIstekHareketNavigation { get; set; }
    public virtual PERSONEL? UygulayanHemsireNavigation { get; set; }
    public virtual REFERANS_KODLAR? IstekIptalNedeniNavigation { get; set; }
    public virtual PERSONEL? IptalEdenHemsireNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}