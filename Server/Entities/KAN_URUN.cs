using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_KAN_URUN tablosu - 20 kolon
/// </summary>
[Table("KAN_URUN")]
public class KAN_URUN
{
    /// <summary>Kan ürünü için Sağlık Bilgi Yönetim Sistemi tarafından üretilen tekil kod bilgis...</summary>
    [Key]
    public string KAN_URUN_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Kan ürünün adı bilgisidir.</summary>
    public string KAN_URUN_ADI { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanan işlemler için Sağlık Bilgi Yönetim Sistemi ta...</summary>
    [ForeignKey("HizmetNavigation")]
    public string HIZMET_KODU { get; set; }

    /// <summary>Kan ürününün gün cinsinden miat süresi bilgisidir.</summary>
    public string KAN_MIAT_SURESI { get; set; }

    /// <summary>Kan ürününün gün, yıl, saat cinsinden miat periyot bilgisidir.</summary>
    [Required]
    public string KAN_MIAT_PERIYODU { get; set; }

    /// <summary>Kan ürünü için Kızılay entegrasyonu için Kızılay bileşen türü eşleştirmesinde ku...</summary>
    [Required]
    public string KIZILAY_BILESEN_TURU { get; set; }

    /// <summary>Kan ürününün filtreleme işlemi için uygun olup olmadığını ifade eden bilgidir.</summary>
    [Required]
    public string KAN_FILTRELEME_UYGUNLUK { get; set; }

    /// <summary>Sağlık tesisinde kullanılacak ürünün yıkama işlemi için uygun olma durumuna iliş...</summary>
    [Required]
    public string KAN_YIKAMA_UYGUNLUK_DURUMU { get; set; }

    /// <summary>Kan ürününün ışınlanma işlemine uygunluk durumuna ilişkin bilgiyi ifade eder.</summary>
    [Required]
    public string KAN_ISINLAMA_UYGUNLUK_DURUMU { get; set; }

    /// <summary>Kan ürününün havuzlama işlemi için uygunluk durumuna ilişkin bilgiyi ifade eder.</summary>
    [Required]
    public string KAN_HAVUZLAMA_UYGUNLUK { get; set; }

    /// <summary>Kan ürününün ayırma işlemine uygunluk durumunu ifade eder.</summary>
    [Required]
    public string KAN_AYIRMA_UYGUNLUK { get; set; }

    /// <summary>Kan ürününün bölme işlemi için uygunluk durumuna ilişkin bilgiyi ifade eder.</summary>
    [Required]
    public string KAN_BOLME_UYGUNLUK { get; set; }

    /// <summary>Kan ürününün Buffy Coat uzaklaştırma işlemi için uygunluk durumunu ifade eder.</summary>
    [Required]
    public string BUFFYCOAT_UZAKLASTIRMAYA_UYGUN { get; set; }

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
    public virtual HIZMET? HizmetNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}