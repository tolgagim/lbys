using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_EK_ODEME_DETAY tablosu - 25 kolon
/// </summary>
[Table("EK_ODEME_DETAY")]
public class EK_ODEME_DETAY
{
    /// <summary>SBYS tarafından üretilen tekil kod bilgisidir.</summary>
    [Key]
    public string EK_ODEME_DETAY_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele ödenecek ek ödemeye ait kayıtlara ulaşılabilm...</summary>
    [ForeignKey("EkOdemeNavigation")]
    public string EK_ODEME_KODU { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin aynı ay içinde birden fazla kadroda görev ya...</summary>
    [Required]
    public string GOREV_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin kadrosuna ilişkin kod bilgisidir.</summary>
    [Required]
    public string KADRO_KODU { get; set; }

    /// <summary>Sağlık tesisinde görevli personel için maaş hesaplamasında kullanılacak kadrosun...</summary>
    [Required]
    public string KADRO_KATSAYISI { get; set; }

    /// <summary>Sağlık tesisinde görevli hekimler tarafından, hastaya uygulanan tıbbi işlem için...</summary>
    public string GIRISIMSEL_ISLEM_PUANI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin uyguladığı tıbbi işlemler için aldığı özelli...</summary>
    [Required]
    public string OZELLIKLI_ISLEM_PUANI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin kadrosu için tavan katsayısı bilgisidir.</summary>
    [Required]
    public string TAVAN_KATSAYISI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin ilgili kadroda çalışmış olduğu toplam gün sa...</summary>
    [Required]
    public string CALISILAN_GUN_TOPLAMI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin ilgili kadroda çalışmış olduğu toplam saat b...</summary>
    [Required]
    public string CALISILAN_SAAT_TOPLAMI { get; set; }

    /// <summary>Belirli bir dönem içindeki toplam gün sayısından çalışılmayan günlerin çıkarılma...</summary>
    [Required]
    public string AKTIF_CALISILAN_GUN_KATSAYISI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele aylık ödenen ek ödeme için hesaplanan hastane...</summary>
    public string HASTANE_PUAN_ORTALAMASI { get; set; }

    /// <summary>Sağlık tesisinde bulunan kliniklerin Sağlık Bilgi Yönetim Sistemi tarafından gru...</summary>
    [Required]
    [ForeignKey("KlinikNavigation")]
    public string KLINIK_KODU { get; set; }

    /// <summary>İlgili klinik için ek ödeme hesaplamasında kullanılmış puan ortalaması bilgisidi...</summary>
    [Required]
    public string KLINIK_PUAN_ORTALAMASI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin kadro unvan katsayısına göre hesaplanan puan...</summary>
    [Required]
    public string BRUT_PERFORMANS_PUANI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin asil görevi dışında başka bir görev yapması ...</summary>
    [Required]
    public string EK_PERFORMANS_PUANI { get; set; }

    /// <summary>Sağlık tesisindeki personelin tüm ek performans puanların ve brüt performans pua...</summary>
    [Required]
    public string NET_PERFORMANS_PUANI { get; set; }

    /// <summary>Üçüncü basamak sağlık tesislerinde, başhekimlik tarafından belirlenen usul çerçe...</summary>
    [Required]
    public string EGITICI_DESTEKLEME_PUANI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin bilimsel çalışma puan bilgisidir.</summary>
    [Required]
    public string BILIMSEL_CALISMA_PUANI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin varsa serbest meslek katsayısı bilgisini ifa...</summary>
    [Required]
    public string SERBEST_MESLEK_KATSAYISI { get; set; }

    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
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
    public virtual EK_ODEME? EkOdemeNavigation { get; set; }
    public virtual REFERANS_KODLAR? KlinikNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}