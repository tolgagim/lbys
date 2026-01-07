using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// STOK_FIS tablosu - 37 kolon
/// </summary>
[Table("STOK_FIS")]
public class STOK_FIS
{
    /// <summary>Sağlık tesisinde kullanılan malzemelerin hareket bilgilerini takip etmek için Sa...</summary>
    [Key]
    public string STOK_FIS_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [Required]
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık tesisinin deposuna girişi veya çıkışı yapılan ilaç, malzeme, ürün vb. içi...</summary>
    [Required]
    [ForeignKey("BagliStokFisNavigation")]
    public string BAGLI_STOK_FIS_KODU { get; set; }

    /// <summary>Sağlık tesisinde bulunan stok depoları için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [ForeignKey("DepoNavigation")]
    public string DEPO_KODU { get; set; }

    /// <summary>Sağlık tesisindeki depolarda yapılan işlem hareketinin depoya giriş veya çıkış i...</summary>
    public string HAREKET_TURU { get; set; }

    /// <summary>Sağlık tesisinin depolarına girişi yapılan ilaç, ürün Taşınır işlem fişi için Ma...</summary>
    [Required]
    public string MKYS_AYNIYAT_MAKBUZ_KODU { get; set; }

    /// <summary>Sağlık tesisindeki depolarda yapılan işlem hareketinin tarih bilgisidir.</summary>
    public DateTime? HAREKET_TARIHI { get; set; }

    /// <summary>Sağlık tesisinin deposundan başka sağlık tesisinin deposuna ilaç, malzeme, ürün ...</summary>
    [Required]
    public string SHCEK_PAYI { get; set; }

    /// <summary>Sağlık tesisinde kesilen fişin hazine kurumu için (%) cinsinden pay bilgisidir. ...</summary>
    [Required]
    public string HAZINE_PAYI { get; set; }

    /// <summary>Sağlık tesisinde yapılan hizmet için kesilen fişin Sağlık Bakanlığı (SB) payı iç...</summary>
    [Required]
    public string SAGLIK_BAKANLIGI_PAYI { get; set; }

    [Required]
    public string BEDELSIZ_FIS { get; set; }

    /// <summary>Sağlık tesisine ücretsiz yapılan ilaç, malzeme, ürün vb. girişlerinin bilgisini ...</summary>
    public string FIS_TUTARI { get; set; }

    /// <summary>Sağlık tesisindeki depolarda yapılan işlem hareketinin türünü ifade eden bilgidi...</summary>
    [ForeignKey("HareketSekliNavigation")]
    public string HAREKET_SEKLI { get; set; }

    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [Required]
    [ForeignKey("IslemiYapanPersonelNavigation")]
    public string ISLEMI_YAPAN_PERSONEL_KODU { get; set; }

    /// <summary>Sağlık tesisinde yapılan işlemlerin, uygulanmaya başladığı zaman bilgisidir.</summary>
    public DateTime? ISLEM_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinin mal veya hizmet alımı yaptığı firma için Sağlık Bilgi Yönetim S...</summary>
    [Required]
    [ForeignKey("FirmaNavigation")]
    public string FIRMA_KODU { get; set; }

    /// <summary>Sağlık tesisinde mal veya hizmet alımı kapsamında gerçekleştirilen ihalenin numa...</summary>
    [Required]
    public string IHALE_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde mal veya hizmet alımı kapsamında gerçekleştirilen ihalenin tari...</summary>
    public DateTime IHALE_TARIHI { get; set; }

    /// <summary>Sağlık tesisinde mal veya hizmet alımı için gerçekleştirilen ihalenin kapsamına ...</summary>
    [Required]
    [ForeignKey("IhaleTuruNavigation")]
    public string IHALE_TURU { get; set; }

    /// <summary>Sağlık tesisinde alımı yapılan ilaç, malzeme, ürün vb. kabul aşamasında sağlık t...</summary>
    [Required]
    public string MUAYENE_KABUL_NUMARASI { get; set; }

    /// <summary>Hastanın muayene tarihi bilgisidir.</summary>
    public DateTime MUAYENE_TARIHI { get; set; }

    /// <summary>Kan ürünü, numune, adli rapor, nüfus cüzdanı, malzeme vb. ilgili kişiye teslim e...</summary>
    [Required]
    public string TESLIM_EDEN_KISI { get; set; }

    /// <summary>Kan ürünü, numune, adli rapor, nüfus cüzdanı, malzeme vb. ilgili kişiye teslim e...</summary>
    [Required]
    public string TESLIM_EDEN_KISI_UNVANI { get; set; }

    /// <summary>Bütçe türü bilgisidir. Örneğin döner sermaye bütçesi, genel bütçe vb.</summary>
    [ForeignKey("ButceTuruNavigation")]
    public string BUTCE_TURU { get; set; }

    /// <summary>Sağlık tesisi tarafından kesilen faturanın numara bilgisidir.</summary>
    [Required]
    public string FATURA_NUMARASI { get; set; }

    /// <summary>Sağlık tesisi tarafından kesilen faturanın zaman bilgisidir.</summary>
    public DateTime FATURA_ZAMANI { get; set; }

    /// <summary>Sağlık tesisi tarafından temin edilen ilaç, malzeme veya ürünlere ait fişin irsa...</summary>
    [Required]
    public string IRSALIYE_NUMARASI { get; set; }

    /// <summary>Sağlık tesisi tarafından temin edilen ilaç, malzeme veya ürünlere ait fişin irsa...</summary>
    public DateTime IRSALIYE_TARIHI { get; set; }

    /// <summary>Kurumlar arasındaki devir işlerinde geçerli olan ve Malzeme Kaynak Yönetim Siste...</summary>
    [Required]
    public string MKYS_KURUM_KODU { get; set; }

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
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual STOK_FIS? BagliStokFisNavigation { get; set; }
    public virtual DEPO? DepoNavigation { get; set; }
    public virtual REFERANS_KODLAR? HareketSekliNavigation { get; set; }
    public virtual PERSONEL? IslemiYapanPersonelNavigation { get; set; }
    public virtual FIRMA? FirmaNavigation { get; set; }
    public virtual REFERANS_KODLAR? IhaleTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? ButceTuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}