using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// HASTA_ILETISIM tablosu - 25 kolon
/// </summary>
[Table("HASTA_ILETISIM")]
public class HASTA_ILETISIM
{
    /// <summary>Sağlık tesisinde hastadan alınan iletişim bilgileri için Sağlık Bilgi Yönetim Si...</summary>
    [Key]
    public string HASTA_ILETISIM_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Kişiye ait kayıt altına alınacak adresin tipini ifade eder.</summary>
    [Required]
    [ForeignKey("AdresTipiNavigation")]
    public string ADRES_TIPI { get; set; }

    /// <summary>Adres kodunun hangi seviyeden seçildiğini ifade eder.</summary>
    [ForeignKey("AdresSeviyesiNavigation")]
    public string ADRES_KODU_SEVIYESI { get; set; }

    /// <summary>Kişinin beyan ettiği adres bilgisidir.</summary>
    [Required]
    public string BEYAN_ADRESI { get; set; }

    /// <summary>Nüfus ve Vatandaşlık İşleri (NVİ) Genel Müdürlüğü tarafından Sağlık Bilgi Yöneti...</summary>
    [Required]
    public string NVI_ADRES { get; set; }

    /// <summary>Adres numarası bilgisidir.</summary>
    [Required]
    public string ADRES_NUMARASI { get; set; }

    /// <summary>İl kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("IlNavigation")]
    public string IL_KODU { get; set; }

    /// <summary>İlçe kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("IlceNavigation")]
    public string ILCE_KODU { get; set; }

    /// <summary>Nüfus ve Vatandaşlık İşlerinden (NVİ) alınan Bucak kod bilgisidir. Örneğin Kemal...</summary>
    [Required]
    [ForeignKey("BucakNavigation")]
    public string BUCAK_KODU { get; set; }

    /// <summary>Nüfus ve Vatandaşlık İşlerinden (NVİ) alınan Köy kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("KoyNavigation")]
    public string KOY_KODU { get; set; }

    /// <summary>Nüfus ve Vatandaşlık İşlerinden (NVİ) alınan Mahalle kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("MahalleNavigation")]
    public string MAHALLE_KODU { get; set; }

    /// <summary>MERNİS tarafından üretilen Cadde Sokak Bucak Mahalle (CSBM) kodu bilgisidir.</summary>
    [Required]
    public string CSBM_KODU { get; set; }

    /// <summary>Adresin dış kapı numarası bilgisidir.</summary>
    [Required]
    public string DIS_KAPI_NUMARASI { get; set; }

    /// <summary>Adresin iç kapı numarası bilgisidir.</summary>
    [Required]
    public string IC_KAPI_NUMARASI { get; set; }

    /// <summary>Kişinin ev telefonu bilgisidir.</summary>
    [Required]
    public string EV_TELEFONU { get; set; }

    /// <summary>Kişinin cep telefonu bilgisidir.</summary>
    [Required]
    public string CEP_TELEFONU { get; set; }

    /// <summary>Kişinin iş telefonu bilgisidir.</summary>
    [Required]
    public string IS_TELEFONU { get; set; }

    /// <summary>Kişinin elektronik posta adresidir.</summary>
    [Required]
    public string EPOSTA_ADRESI { get; set; }

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
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? AdresTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? AdresSeviyesiNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlceNavigation { get; set; }
    public virtual REFERANS_KODLAR? BucakNavigation { get; set; }
    public virtual REFERANS_KODLAR? KoyNavigation { get; set; }
    public virtual REFERANS_KODLAR? MahalleNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}