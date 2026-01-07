using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_KAN_TALEP_DETAY tablosu - 20 kolon
/// </summary>
[Table("KAN_TALEP_DETAY")]
public class KAN_TALEP_DETAY
{
    /// <summary>Talep edilen kan ürünü detay bilgileri için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [Key]
    public string KAN_TALEP_DETAY_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Talep edilen kan ürünü bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("KanTalepNavigation")]
    public string KAN_TALEP_KODU { get; set; }

    /// <summary>Kan ürünü için Sağlık Bilgi Yönetim Sistemi tarafından üretilen tekil kod bilgis...</summary>
    [ForeignKey("KanUrunNavigation")]
    public string KAN_URUN_KODU { get; set; }

    /// <summary>Sağlık tesisinde tedavi olan hasta için istenen kan grubuna bilgisine ait Sağlık...</summary>
    [ForeignKey("IstenenKanGrubuNavigation")]
    public string ISTENEN_KAN_GRUBU { get; set; }

    /// <summary>Talebin reddedildiği tarih bilgisidir.</summary>
    public DateTime RET_TARIHI { get; set; }

    /// <summary>Ret işlemini gerçekleştiren Sağlık Bilgi Yönetim Sistemi kullanıcısı için Sağlık...</summary>
    [Required]
    [ForeignKey("RetEdenKullaniciNavigation")]
    public string RET_EDEN_KULLANICI_KODU { get; set; }

    /// <summary>Talep edilen kan ürününün reddedilmesi durumunda belirtilen ret bilgisidir. Örne...</summary>
    [Required]
    [ForeignKey("KanTalepRetNedeniNavigation")]
    public string KAN_TALEP_RET_NEDENI { get; set; }

    /// <summary>Talep edilen kan ürünü için miktar (torba adedi) bilgisidir.</summary>
    [Required]
    public string KAN_TALEP_MIKTARI { get; set; }

    /// <summary>Kan ürününün mililitre cinsinden hacim bilgisidir.</summary>
    [Required]
    public string KAN_HACIM { get; set; }

    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>Kan ürününe Buffy Coat uzaklaştırma işlemi uygulanma durumunu ifade eder.</summary>
    public string BUFFYCOAT_UZAKLASTIRMA_DURUMU { get; set; }

    /// <summary>Kan ürününe filtreleme işlemi uygulanıp uygulanmadığını ifade eden durum bilgisi...</summary>
    public string KAN_FILTRELEME_DURUMU { get; set; }

    /// <summary>Kan ürününün ışınlanma işleminin durumuna ilişkin bilgiyi ifade eder.</summary>
    public string KAN_ISINLAMA_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde kullanılacak ürüne yıkama işleminin uygulanmasına ilişkin bilgi...</summary>
    public string KAN_YIKAMA_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }

    /// <summary>İşlemin güncellemesinin yapıldığı tarih bilgisidir.</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }

    #region Navigation Properties
    public virtual KAN_TALEP? KanTalepNavigation { get; set; }
    public virtual KAN_URUN? KanUrunNavigation { get; set; }
    public virtual REFERANS_KODLAR? IstenenKanGrubuNavigation { get; set; }
    public virtual KULLANICI? RetEdenKullaniciNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanTalepRetNedeniNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}