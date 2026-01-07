using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_PERSONEL_ODUL_CEZA tablosu - 16 kolon
/// </summary>
[Table("PERSONEL_ODUL_CEZA")]
public class PERSONEL_ODUL_CEZA
{
    /// <summary>Sağlık tesisinde görevli personel için sağlık tesisi idaresi tarafından verilen ...</summary>
    [Key]
    public string PERSONEL_ODUL_CEZA_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }

    /// <summary>Sağlık tesisi idaresi tarafından personele verilen ödül veya ceza için durum bil...</summary>
    public string ODUL_CEZA_DURUMU { get; set; }

    /// <summary>Sağlık tesisi idaresi tarafından personele verilen ödül veya cezanın ikramiye, k...</summary>
    [ForeignKey("OdulCezaTuruNavigation")]
    public string ODUL_CEZA_TURU { get; set; }

    /// <summary>Sağlık tesisinde görevli personele verilen cezanın başladığı tarih bilgisidir.</summary>
    public DateTime CEZA_BASLANGIC_TARIHI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele verilen cezanın bittiği tarih bilgisidir.</summary>
    public DateTime CEZA_BITIS_TARIHI { get; set; }

    /// <summary>Sağlık personeline ödül veya ceza veren kurum kodu bilgisidir.</summary>
    [ForeignKey("OdulCezaVerenKurumNavigation")]
    public string ODUL_CEZA_VEREN_KURUM_KODU { get; set; }

    /// <summary>Sağlık tesisi idaresi tarafından personele verilen ödül veya cezaya ait açıklama...</summary>
    [Required]
    public string ODUL_CEZA_ACIKLAMA { get; set; }

    /// <summary>Sağlık tesisinde personele verilen ödül veya cezanın personele tebliğ edildiği t...</summary>
    public DateTime? TEBLIG_TARIHI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele tebliğ edilen evrakın düzenlendiği tarih bilg...</summary>
    public DateTime TEBLIG_EVRAK_TARIHI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele tebliğ edilen evrakın numara bilgisidir.</summary>
    [Required]
    public string TEBLIG_EVRAK_NUMARASI { get; set; }

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
    public virtual PERSONEL? PersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? OdulCezaTuruNavigation { get; set; }
    public virtual KURUM? OdulCezaVerenKurumNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}