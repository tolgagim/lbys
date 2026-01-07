using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_KAN_CIKIS tablosu - 20 kolon
/// </summary>
[Table("KAN_CIKIS")]
public class KAN_CIKIS
{
    /// <summary>Kan ürününün sağlık tesisi deposundan çıkış işlemi için Sağlık Bilgi Yönetim Sis...</summary>
    [Key]
    public string KAN_CIKIS_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Talep edilen kan ürünü detay bilgileri için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [Required]
    [ForeignKey("KanTalepDetayNavigation")]
    public string KAN_TALEP_DETAY_KODU { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [Required]
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık tesisindeki depolarda bulunan kan ürünü için Sağlık Bilgi Yönetim Sistemi...</summary>
    [ForeignKey("KanStokNavigation")]
    public string KAN_STOK_KODU { get; set; }

    /// <summary>Sağlık tesisinde kan ürününü teslim alan kişi bilgisidir.</summary>
    public string KANI_TESLIM_ALAN_KISI { get; set; }

    /// <summary>Kan ürününün bulunduğu birimden çıkış zamanı bilgisidir.</summary>
    public DateTime? KAN_CIKIS_ZAMANI { get; set; }

    /// <summary>Kişinin yararlandığı sağlık güvencesinin kurumuna ait bilgiler için Sağlık Bilgi...</summary>
    [Required]
    [ForeignKey("KurumNavigation")]
    public string KURUM_KODU { get; set; }

    /// <summary>Sağlık tesisinde kan ürününün diğer birimlere gönderilmesini onaylayan personel ...</summary>
    [ForeignKey("KanCikisPersonelNavigation")]
    public string KAN_CIKIS_PERSONEL_KODU { get; set; }

    /// <summary>Kan ürünün rezerve edildiği zaman bilgisidir.</summary>
    public DateTime REZERVE_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde bağışı yapılan kan ürününü rezerve eden kullanıcı için Sağlık B...</summary>
    [Required]
    [ForeignKey("RezerveEdenKullaniciNavigation")]
    public string REZERVE_EDEN_KULLANICI_KODU { get; set; }

    /// <summary>Kan ürünü için yapılan cross-match işlem sonucunu Sağlık Bilgi Yönetim Sistemine...</summary>
    [Required]
    [ForeignKey("CrossMatchKullaniciNavigation")]
    public string CROSS_MATCH_KULLANICI_KODU { get; set; }

    /// <summary>Kan ürünü için yapılan cross-match işleminin uygulanma zamanı bilgisidir.</summary>
    public DateTime CROSS_MATCH_CALISMA_ZAMANI { get; set; }

    /// <summary>Kan ürünü için yapılan cross-match işlemi için çalışma yöntemini ifade eder. Örn...</summary>
    [Required]
    [ForeignKey("CrossMatchCalismaYontemiNavigation")]
    public string CROSS_MATCH_CALISMA_YONTEMI { get; set; }

    /// <summary>Kan ürünü için yapılan cross-match işleminin sonuç bilgisidir.</summary>
    [Required]
    [ForeignKey("CrossMatchSonucuNavigation")]
    public string CROSS_MATCH_SONUCU { get; set; }

    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }

    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }

    /// <summary>İşlemin güncellemesinin yapıldığı tarih bilgisidir.</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }

    #region Navigation Properties
    public virtual KAN_TALEP_DETAY? KanTalepDetayNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual KAN_STOK? KanStokNavigation { get; set; }
    public virtual KURUM? KurumNavigation { get; set; }
    public virtual PERSONEL? KanCikisPersonelNavigation { get; set; }
    public virtual KULLANICI? RezerveEdenKullaniciNavigation { get; set; }
    public virtual KULLANICI? CrossMatchKullaniciNavigation { get; set; }
    public virtual REFERANS_KODLAR? CrossMatchCalismaYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? CrossMatchSonucuNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}