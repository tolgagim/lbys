using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// DOGUM tablosu - 21 kolon
/// </summary>
[Table("DOGUM")]
public class DOGUM
{
    /// <summary>Sağlık tesisinde doğum yapan hastaya ait bilgilerin kayıt edilmesi için Sağlık B...</summary>
    [Key]
    public string DOGUM_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanacak hizmetler için Sağlık Bilgi Yönetim Sistemi...</summary>
    [ForeignKey("HastaHizmetNavigation")]
    public string HASTA_HIZMET_KODU { get; set; }

    /// <summary>Sağlık tesisinde yapılan ameliyatın bilgilerine erişim sağlamak için Sağlık Bilg...</summary>
    [Required]
    [ForeignKey("AmeliyatNavigation")]
    public string AMELIYAT_KODU { get; set; }

    /// <summary>Yenidogan bebegin baba T.C. Kimlik Numarasi bilgisidir.</summary>
    [Required]
    public string BABA_TC_KIMLIK_NUMARASI { get; set; }

    /// <summary>Herhangi bir müdahale (ameliyat, doğum vb.) sonrası oluşan karmaşık ve olumsuz k...</summary>
    [Required]
    [ForeignKey("KomplikasyonTanisiNavigation")]
    public string KOMPLIKASYON_TANISI { get; set; }

    /// <summary>Sağlık tesisinde doğum yapan hasta için hekim tarafından yazılan, doğuma ilişkin...</summary>
    [Required]
    public string DOGUM_NOTU { get; set; }

    /// <summary>Doğum başlama zamanı bilgisidir.</summary>
    public DateTime? DOGUM_BASLAMA_ZAMANI { get; set; }

    /// <summary>Doğum bitiş zamanı bilgisidir.</summary>
    public DateTime DOGUM_BITIS_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde görevli hekim için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [Required]
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }

    /// <summary>Sağlık tesisinde doğumu gerçekleştiren ebe için Sağlık Bilgi Yönetim Sistemi tar...</summary>
    [Required]
    [ForeignKey("EbeNavigation")]
    public string EBE_KODU { get; set; }

    /// <summary>Sağlık tesisinde bulunan bölümler için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("BirimNavigation")]
    public string BIRIM_KODU { get; set; }

    /// <summary>Sağlık tesisindeki birimlerde hasta bilgilerinin olduğu defter numarası bilgisid...</summary>
    [Required]
    public string DEFTER_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA_HIZMET? HastaHizmetNavigation { get; set; }
    public virtual AMELIYAT? AmeliyatNavigation { get; set; }
    public virtual REFERANS_KODLAR? KomplikasyonTanisiNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual PERSONEL? EbeNavigation { get; set; }
    public virtual BIRIM? BirimNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}