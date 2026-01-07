using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// RADYOLOJI tablosu - 22 kolon
/// </summary>
[Table("RADYOLOJI")]
public class RADYOLOJI
{
    /// <summary>SBYS tarafından üretilen tekil kod bilgisidir.</summary>
    [Key]
    public string RADYOLOJI_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık tesisinde bulunan bölümler için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("BirimNavigation")]
    public string BIRIM_KODU { get; set; }

    /// <summary>Radyolojik tetkik çekimi için hastanın kabulünün yapıldığı zamandır.</summary>
    public DateTime TETKIK_CEKIM_KABUL_ZAMANI { get; set; }

    /// <summary>Çubuk kod ya da çizgi im, verilerin görsel özellikli makinelerin okuyabilmesi iç...</summary>
    [Required]
    public string BARKOD { get; set; }

    /// <summary>Barkod yazdırma zamanı bilgisidir.</summary>
    public DateTime BARKOD_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde bulunan cihaz için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [Required]
    [ForeignKey("CihazNavigation")]
    public string CIHAZ_KODU { get; set; }

    /// <summary>Tetkikin tıbbi cihazda çalışılmaya başlandığı zaman bilgisidir.</summary>
    public DateTime CALISMA_BASLAMA_ZAMANI { get; set; }

    /// <summary>Tetkikin tıbbi cihazda çalışılmasının bittiği zaman bilgisidir.</summary>
    public DateTime CALISMA_BITIS_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde tedavi alan hastaya istenen tetkiklerin kabulünü yapan Sağlık B...</summary>
    [Required]
    [ForeignKey("KabulEdenKullaniciNavigation")]
    public string KABUL_EDEN_KULLANICI_KODU { get; set; }

    /// <summary>Radyolojik tetkik çekimini gerçekleştiren sağlık tesisinde görevli personel için...</summary>
    [Required]
    [ForeignKey("TetkikCekenTeknisyenNavigation")]
    public string TETKIK_CEKEN_TEKNISYEN_KODU { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanacak hizmetler için Sağlık Bilgi Yönetim Sistemi...</summary>
    [ForeignKey("HastaHizmetNavigation")]
    public string HASTA_HIZMET_KODU { get; set; }

    /// <summary>LOINC, Sağlık tesisinde laboratuvar veya radyolojik tetkik sonuçlarının sınıflan...</summary>
    [Required]
    public string LOINC_KODU { get; set; }

    /// <summary>Sağlık tesisinde yapılan tetkiklerin istenme durumuna ilişkin ön kabul, kabul, s...</summary>
    [Required]
    [ForeignKey("TetkikIstenmeDurumuNavigation")]
    public string TETKIK_ISTENME_DURUMU { get; set; }

    /// <summary>Radyolojik tetkik çekimine ait erişim numarası (Accession Number) bilgisidir.</summary>
    [Required]
    public string ERISIM_NUMARASI { get; set; }

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
    public virtual BIRIM? BirimNavigation { get; set; }
    public virtual CIHAZ? CihazNavigation { get; set; }
    public virtual KULLANICI? KabulEdenKullaniciNavigation { get; set; }
    public virtual PERSONEL? TetkikCekenTeknisyenNavigation { get; set; }
    public virtual HASTA_HIZMET? HastaHizmetNavigation { get; set; }
    public virtual REFERANS_KODLAR? TetkikIstenmeDurumuNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}