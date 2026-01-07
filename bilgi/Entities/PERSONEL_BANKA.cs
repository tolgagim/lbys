using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// PERSONEL_BANKA tablosu - 14 kolon
/// </summary>
[Table("PERSONEL_BANKA")]
public class PERSONEL_BANKA
{
    /// <summary>Sağlık tesisinde görevli personelin banka bilgileri için Sağlık Bilgi Yönetim Si...</summary>
    [Key]
    public string PERSONEL_BANKA_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }

    /// <summary>Sağlık tesisinin hizmet aldığı banka isim bilgisidir. Örneğin T.C Ziraat Bankası...</summary>
    [ForeignKey("BankaNavigation")]
    public string BANKA { get; set; }

    /// <summary>Kişinin banka hesap numarası bilgisidir.</summary>
    [Required]
    public string HESAP_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin hesap numarasının şube kodu bilgisidir.</summary>
    [Required]
    public string SUBE_KODU { get; set; }

    /// <summary>Firmaya ait IBAN numarası bilgisidir.</summary>
    [Required]
    public string IBAN_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde görev yapan personel için hesaplanan ödemenin tür bilgisidir.</summary>
    [Required]
    [ForeignKey("BordroTuruNavigation")]
    public string BORDRO_TURU { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin Sağlık Bilgi Yönetim Sistemi' de kayıtlı ban...</summary>
    public string HESAP_AKTIFLIK_BILGISI { get; set; }

    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

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
    public virtual PERSONEL? PersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? BankaNavigation { get; set; }
    public virtual REFERANS_KODLAR? BordroTuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}