using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_STERILIZASYON_SET tablosu - 26 kolon
/// </summary>
[Table("STERILIZASYON_SET")]
public class STERILIZASYON_SET
{
    /// <summary>Tıbbi aletlerin steril edilmeden önce ve sterilizasyon aşamasında oluşturulan se...</summary>
    [Key]
    public string STERILIZASYON_SET_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde bulunan stok depoları için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [ForeignKey("DepoNavigation")]
    public string DEPO_KODU { get; set; }

    /// <summary>Sağlık tesisinin deposunda bulunan steril aletlerin paket bilgilerine ilişkin ka...</summary>
    [ForeignKey("SterilizasyonPaketNavigation")]
    public string STERILIZASYON_PAKET_KODU { get; set; }

    /// <summary>Çubuk kod ya da çizgi im, verilerin görsel özellikli makinelerin okuyabilmesi iç...</summary>
    [Required]
    public string BARKOD { get; set; }

    /// <summary>Sağlık tesisinde üretilen barkodları, barkod yazıcıdan bastıran Sağlık Bilgi Yön...</summary>
    [Required]
    [ForeignKey("BarkodBasanKullaniciNavigation")]
    public string BARKOD_BASAN_KULLANICI_KODU { get; set; }

    /// <summary>Barkodun basıldığı zaman bilgisidir.</summary>
    public DateTime BARKOD_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde bulunan cihaz için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [ForeignKey("CihazNavigation")]
    public string CIHAZ_KODU { get; set; }

    /// <summary>Sağlık tesisinde sterilizasyon işlemi uygulanan alet, malzeme veya setler için s...</summary>
    [Required]
    public string STERILIZASYON_CEVRIM_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde tedavide kullanılan setin iade edilip edilmediğine ilişkin bilg...</summary>
    public string SET_IADE_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde tedavide kullanılan setin kullanılmayıp ilgili birime iade edil...</summary>
    public DateTime SET_IADE_ZAMANI { get; set; }

    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [Required]
    [ForeignKey("SetIadeEdenPersonelNavigation")]
    public string SET_IADE_EDEN_PERSONEL_KODU { get; set; }

    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [Required]
    [ForeignKey("SetIadeAlanPersonelNavigation")]
    public string SET_IADE_ALAN_PERSONEL_KODU { get; set; }

    /// <summary>Steril edilmiş setin raf ömrünün bitiş tarihi bilgisidir.</summary>
    public DateTime PAKET_RAF_OMRU_BITIS_TARIHI { get; set; }

    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("PaketleyenPersonelNavigation")]
    public string PAKETLEYEN_PERSONEL_KODU { get; set; }

    /// <summary>Sağlık tesisinde yapılan işlemlerin, uygulanmaya başladığı zaman bilgisidir.</summary>
    public DateTime? ISLEM_ZAMANI { get; set; }

    /// <summary>Sterilizasyon işleminin başladığı zaman bilgisidir.</summary>
    public DateTime? STERILIZASYON_BASLAMA_ZAMANI { get; set; }

    /// <summary>Sterilizasyon işleminin bittiği zaman bilgisidir.</summary>
    public DateTime STERILIZASYON_BITIS_ZAMANI { get; set; }

    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [Required]
    [ForeignKey("SterilizasyonPersonelNavigation")]
    public string STERILIZASYON_PERSONEL_KODU { get; set; }

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
    public virtual DEPO? DepoNavigation { get; set; }
    public virtual STERILIZASYON_PAKET? SterilizasyonPaketNavigation { get; set; }
    public virtual KULLANICI? BarkodBasanKullaniciNavigation { get; set; }
    public virtual CIHAZ? CihazNavigation { get; set; }
    public virtual PERSONEL? SetIadeEdenPersonelNavigation { get; set; }
    public virtual PERSONEL? SetIadeAlanPersonelNavigation { get; set; }
    public virtual PERSONEL? PaketleyenPersonelNavigation { get; set; }
    public virtual PERSONEL? SterilizasyonPersonelNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}