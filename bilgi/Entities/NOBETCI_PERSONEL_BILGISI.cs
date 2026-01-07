using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// NOBETCI_PERSONEL_BILGISI tablosu - 14 kolon
/// </summary>
[Table("NOBETCI_PERSONEL_BILGISI")]
public class NOBETCI_PERSONEL_BILGISI
{
    /// <summary>Sağlık tesisinde nöbetçi personelin bilgileri için Sağlık Bilgi Yönetim Sistemi ...</summary>
    [Key]
    public string NOBETCI_PERSONEL_BILGISI_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık Kodlama Referans Sunucusu (SKRS) kod sistemlerinde tanımlanan Kurum Kodu ...</summary>
    [ForeignKey("SkrsKurumNavigation")]
    public string SKRS_KURUM_KODU { get; set; }

    /// <summary>Personele ait TC Kimlik Numarası bilgisidir.</summary>
    public string PERSONEL_TC_KIMLIK_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde bulunan kliniklerin Sağlık Bilgi Yönetim Sistemi tarafından gru...</summary>
    [Required]
    [ForeignKey("KlinikNavigation")]
    public string KLINIK_KODU { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin yaptığı görev için Sağlık Bilgi Yönetim Sist...</summary>
    [Required]
    [ForeignKey("GorevTuruNavigation")]
    public string GOREV_TURU { get; set; }

    /// <summary>Sağlık tesisinde görevli personel için görevini tanımlayan kod bilgisidir.</summary>
    [Required]
    [ForeignKey("PersonelGorevNavigation")]
    public string PERSONEL_GOREV_KODU { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin nöbette başlama tarihi bilgisidir.</summary>
    public DateTime NOBET_BASLANGIC_TARIHI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin nöbetinin bitiş tarihi bilgisidir.</summary>
    public DateTime NOBET_BITIS_TARIHI { get; set; }

    /// <summary>Telefon numarası bilgisini ifade eder.</summary>
    [Required]
    public string TELEFON_NUMARASI { get; set; }

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
    public virtual REFERANS_KODLAR? SkrsKurumNavigation { get; set; }
    public virtual REFERANS_KODLAR? KlinikNavigation { get; set; }
    public virtual REFERANS_KODLAR? GorevTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? PersonelGorevNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}