using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_STOK_HAREKET tablosu - 38 kolon
/// </summary>
[Table("STOK_HAREKET")]
public class STOK_HAREKET
{
    /// <summary>Sağlık tesisinde kullanılan malzemelerin ayrıntılı hareket bilgilerini takip etm...</summary>
    [Key]
    public string STOK_HAREKET_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinin deposuna girişi veya çıkışı yapılan ilaç, malzeme, ürün vb. içi...</summary>
    [Required]
    [ForeignKey("BagliStokHareketNavigation")]
    public string BAGLI_STOK_HAREKET_KODU { get; set; }

    /// <summary>Sağlık tesisi depolarına giriş işlemi yapılan ilaç, malzeme, ürün vb. bilgileri ...</summary>
    [Required]
    [ForeignKey("IlkGirisStokHareketNavigation")]
    public string ILK_GIRIS_STOK_HAREKET_KODU { get; set; }

    /// <summary>Sağlık tesisinde hasta için depodan yapılan isteklerin detay bilgilerine erişim ...</summary>
    [Required]
    [ForeignKey("StokIstekHareketNavigation")]
    public string STOK_ISTEK_HAREKET_KODU { get; set; }

    /// <summary>Sağlık tesisinde kullanılan malzemelerin hareket bilgilerini takip etmek için Sa...</summary>
    [ForeignKey("StokFisNavigation")]
    public string STOK_FIS_KODU { get; set; }

    /// <summary>Sağlık tesisinde bulunan ilaç, malzeme ve ürünlerin bilgilerine erişim sağlamak ...</summary>
    [ForeignKey("StokKartNavigation")]
    public string STOK_KART_KODU { get; set; }

    /// <summary>Çubuk kod ya da çizgi im, verilerin görsel özellikli makinelerin okuyabilmesi iç...</summary>
    [Required]
    public string BARKOD { get; set; }

    /// <summary>Sağlık tesisi depolarında hareket gören malzemelerin üretimi ile bilgileri içere...</summary>
    [Required]
    public string LOT_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde bulunan tıbbi cihazların ürünlere verilen grup numarası olan LO...</summary>
    [Required]
    public string SERI_SIRA_NUMARASI { get; set; }

    /// <summary>Türkiye İlaç ve Tıbbi Cihaz Kurumu tarafından üretici firma numarası bilgisidir.</summary>
    [Required]
    public string FIRMA_TANIMLAYICI_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanan malzemeler için SUT'ta tanımlanmış kod bilgis...</summary>
    [Required]
    public string MALZEME_SUT_KODU { get; set; }

    /// <summary>Sağlık tesisi depolarına giriş veya çıkış işlemi yapılan ilaç, malzeme, ürün vb....</summary>
    public string STOK_HAREKET_MIKTARI { get; set; }

    /// <summary>Sağlık tesisinde bulunan taşınır malzemeler için Sağlık Bilgi Yönetim Sistemi ta...</summary>
    public string TASINIR_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinin deposuna alınan ilaç, malzeme vb. birim fiyat bilgisidir.</summary>
    public string ALIS_BIRIM_FIYATI { get; set; }

    /// <summary>Sağlık tesisine alınan malın satış birim fiyat bilgisini ifade eder.</summary>
    public string SATIS_BIRIM_FIYATI { get; set; }

    /// <summary>İlaç, malzeme, ürün vb. için sağlık tesisinde kullanılan ölçü biriminin Sağlık B...</summary>
    [ForeignKey("OlcuNavigation")]
    public string OLCU_KODU { get; set; }

    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [Required]
    [ForeignKey("IslemiYapanPersonelNavigation")]
    public string ISLEMI_YAPAN_PERSONEL_KODU { get; set; }

    /// <summary>KDV oranı bilgisidir.</summary>
    [Required]
    public string KDV_ORANI { get; set; }

    /// <summary>İskonto oranı bilgisidir.</summary>
    [Required]
    public string ISKONTO_ORANI { get; set; }

    /// <summary>İskonto tutar bilgisidir.</summary>
    [Required]
    public string ISKONTO_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde kullanılan ilaç, aşı, tıbbi alet vb. son kullanma tarihi bilgis...</summary>
    public DateTime SON_KULLANMA_TARIHI { get; set; }

    /// <summary>Sağlık tesisinin stoklarına girişi yapılan İlaç ve malzeme için Malzeme Kaynak Y...</summary>
    [Required]
    public string MKYS_STOK_HAREKET_KODU { get; set; }

    /// <summary>Sağlık tesisinde yapılan bir işlemin iptal edilip edilmediği bilgisidir.</summary>
    [Required]
    public string IPTAL_DURUMU { get; set; }

    /// <summary>İlaç ve malzemenin sağlık tesisinin stoklarına girmesinden sonra hareketlerini t...</summary>
    [Required]
    public string MKYS_KARSI_STOK_HAREKET_KODU { get; set; }

    /// <summary>Malzeme Kaynak Yönetim Sistemi (MKYS) tarafından üretilen cihaz künye numarası b...</summary>
    [Required]
    public string MKYS_KUNYE_NUMARASI { get; set; }

    /// <summary>İlgili ürünün ÜTS sistemine kayıt edilmesi durumunda dönen UDI (Unique Device Id...</summary>
    [Required]
    public string UTS_KAYIT_UDI { get; set; }

    /// <summary>Ürünün alındığı bayinin numara bilgisidir.</summary>
    [Required]
    public string BAYILIK_NUMARASI { get; set; }

    /// <summary>Ürünler için Ürün Takip Sisteminde (ÜTS) tanımlanmış Unique Device Identificatio...</summary>
    [Required]
    [ForeignKey("CihazNavigation")]
    public string CIHAZ_KODU { get; set; }

    /// <summary>Sağlık tesisinde kişiye aşı uygulanmadan önce Sağlık Bilgi Yönetim Sistemi taraf...</summary>
    [Required]
    public string ATS_SORGU_NUMARASI { get; set; }

    /// <summary>Vericinin uygun bir biçimde tanımlanmış ve bağışlanan materyalin izlenebilirliği...</summary>
    [Required]
    public string ALLOGREFT_DONOR_KODU { get; set; }

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
    public virtual STOK_HAREKET? BagliStokHareketNavigation { get; set; }
    public virtual STOK_HAREKET? IlkGirisStokHareketNavigation { get; set; }
    public virtual STOK_ISTEK_HAREKET? StokIstekHareketNavigation { get; set; }
    public virtual STOK_FIS? StokFisNavigation { get; set; }
    public virtual STOK_KART? StokKartNavigation { get; set; }
    public virtual REFERANS_KODLAR? OlcuNavigation { get; set; }
    public virtual PERSONEL? IslemiYapanPersonelNavigation { get; set; }
    public virtual CIHAZ? CihazNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}