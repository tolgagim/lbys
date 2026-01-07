using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_TETKIK_REFERANS_ARALIK tablosu - 17 kolon
/// </summary>
[Table("TETKIK_REFERANS_ARALIK")]
public class TETKIK_REFERANS_ARALIK
{
    /// <summary>Sağlık tesisinde yapılan tetkiklerdeki referans aralığı değerleri için Sağlık Bi...</summary>
    [Key]
    public string TETKIK_REFERANS_ARALIK_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde yapılan tetkiklerdeki parametreler için Sağlık Bilgi Yönetim Si...</summary>
    [ForeignKey("TetkikParametreNavigation")]
    public string TETKIK_PARAMETRE_KODU { get; set; }

    /// <summary>Sağlık tesisinde yapılan tetkikler için Sağlık Bilgi Yönetim Sistemi tarafından ...</summary>
    [ForeignKey("TetkikNavigation")]
    public string TETKIK_KODU { get; set; }

    /// <summary>Sağlık tesisinde bulunan cihaz için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [Required]
    [ForeignKey("CihazNavigation")]
    public string CIHAZ_KODU { get; set; }

    /// <summary>Laboratuvar tetkiklerinin karar sınırı değerlerinin hangi cinsiyete göre yapıldı...</summary>
    [ForeignKey("TetkikCinsiyetNavigation")]
    public string TETKIK_CINSIYET { get; set; }

    /// <summary>Tetkik sonuç aralığının geçerli olduğu yaş aralığının gün cinsinden başlangıç bi...</summary>
    public string YAS_ARALIGI_BASLANGIC_GUN { get; set; }

    /// <summary>Tetkik sonuç aralığının geçerli olduğu yaş aralığının gün cinsinden bitiş bilgis...</summary>
    public string YAS_ARALIGI_BITIS_GUN { get; set; }

    /// <summary>Tetkik sonuçları için referans aralığının başlangıç değeri (minimum) bilgisidir.</summary>
    [Required]
    public string REFERANS_BASLANGIC_DEGERI { get; set; }

    /// <summary>Tetkik sonuçlari için referans araliginin bitis degeri bilgisidir.</summary>
    [Required]
    public string REFERANS_BITIS_DEGERI { get; set; }

    /// <summary>Tıbbi laboratuvar testinde, hasta için risk oluşturabilecek durumlarda en kısa z...</summary>
    [Required]
    public string ALT_KRITIK_DEGER { get; set; }

    /// <summary>Tıbbi laboratuvar testinde, hasta için risk oluşturabilecek durumlarda en kısa z...</summary>
    [Required]
    public string UST_KRITIK_DEGER { get; set; }

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
    public virtual TETKIK_PARAMETRE? TetkikParametreNavigation { get; set; }
    public virtual TETKIK? TetkikNavigation { get; set; }
    public virtual CIHAZ? CihazNavigation { get; set; }
    public virtual REFERANS_KODLAR? TetkikCinsiyetNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}