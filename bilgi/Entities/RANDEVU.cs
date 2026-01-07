using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// RANDEVU tablosu - 29 kolon
/// </summary>
[Table("RANDEVU")]
public class RANDEVU
{
    /// <summary>Kişi için düzenlenen randevu bilgisi için Sağlık Bilgi Yönetim Sistemi tarafında...</summary>
    [Key]
    public string RANDEVU_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Kişinin almış olduğu randevu için Sağlık Bilgi Yönetim Sistemi tarafından tanıml...</summary>
    [ForeignKey("RandevuTuruNavigation")]
    public string RANDEVU_TURU { get; set; }

    /// <summary>Kişinin diş tedavisi için aldığı randevunun dolgu, kanal tedavisi, diş çekimi vb...</summary>
    [Required]
    [ForeignKey("RandevuAltTuruNavigation")]
    public string RANDEVU_ALT_TURU { get; set; }

    /// <summary>Kişinin randevu zamanı bilgisidir.</summary>
    public DateTime? RANDEVU_ZAMANI { get; set; }

    /// <summary>Randevunun kayıt edildiği zaman bilgisidir.</summary>
    public DateTime? RANDEVU_KAYIT_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanacak hizmetler için Sağlık Bilgi Yönetim Sistemi...</summary>
    [Required]
    [ForeignKey("HastaHizmetNavigation")]
    public string HASTA_HIZMET_KODU { get; set; }

    /// <summary>Sağlık tesisinde bulunan bölümler için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("BirimNavigation")]
    public string BIRIM_KODU { get; set; }

    /// <summary>Sağlık tesisinde görevli hekim için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [Required]
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }

    /// <summary>Sağlık tesisindeki muayeneye MHRS sisteminden randevu alarak gelen hastalara, mu...</summary>
    [Required]
    public string MHRS_HRN_KODU { get; set; }

    /// <summary>Sağlık tesisinde yapılacak muayeneler için MHRS sisteminden randevu alan hastala...</summary>
    [Required]
    public string MHRS_RANDEVU_NOTU { get; set; }

    /// <summary>Kişinin sağlık tesisinden aldığı randevuya gelip gelmediğine ilişkin bilgiyi ifa...</summary>
    [ForeignKey("RandevuGelmeDurumuNavigation")]
    public string RANDEVU_GELME_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde bulunan cihaz için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [Required]
    [ForeignKey("CihazNavigation")]
    public string CIHAZ_KODU { get; set; }

    /// <summary>Kişiyi niteleyen eşsiz numaradır.</summary>
    [Required]
    public string TC_KIMLIK_NUMARASI { get; set; }

    /// <summary>Kişinin adı bilgisidir.</summary>
    [Required]
    public string AD { get; set; }

    /// <summary>Kişinin soyadı bilgisidir.</summary>
    [Required]
    public string SOYADI { get; set; }

    /// <summary>Kişinin cinsiyetini ifade eder.</summary>
    [Required]
    [ForeignKey("CinsiyetNavigation")]
    public string CINSIYET { get; set; }

    /// <summary>Telefon numarası bilgisini ifade eder.</summary>
    [Required]
    public string TELEFON_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde yapılan bir işlemin iptal edilip edilmediği bilgisidir.</summary>
    public string IPTAL_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde yapılan bir işlemi iptal eden Sağlık Bilgi Yönetim Sistemi kull...</summary>
    [Required]
    [ForeignKey("IptalEdenKullaniciNavigation")]
    public string IPTAL_EDEN_KULLANICI_KODU { get; set; }

    /// <summary>Sağlık tesisinde üretilen verinin iptal edildiği zaman bilgisidir.</summary>
    public DateTime IPTAL_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde yapılan bir işlemin iptal edilmesi durumunda Sağlık Bilgi Yönet...</summary>
    [Required]
    public string IPTAL_ACIKLAMA { get; set; }

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
    public virtual REFERANS_KODLAR? RandevuTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? RandevuAltTuruNavigation { get; set; }
    public virtual HASTA_HIZMET? HastaHizmetNavigation { get; set; }
    public virtual BIRIM? BirimNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual REFERANS_KODLAR? RandevuGelmeDurumuNavigation { get; set; }
    public virtual CIHAZ? CihazNavigation { get; set; }
    public virtual REFERANS_KODLAR? CinsiyetNavigation { get; set; }
    public virtual KULLANICI? IptalEdenKullaniciNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}