using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// GRUP_UYELIK tablosu - 8 kolon
/// </summary>
[Table("GRUP_UYELIK")]
public class GRUP_UYELIK
{
    /// <summary>Sağlık tesisinde görevli personel arasından Sağlık Bilgi Yönetim Sistemini kulla...</summary>
    [Key]
    public string GRUP_UYELIK_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi kullanıcıları için tanımlanmış Sağlık Bilgi Yönetim...</summary>
    [ForeignKey("KullaniciGrupNavigation")]
    public string KULLANICI_GRUP_KODU { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemini kullanan personel için Sağlık Bilgi Yönetim Siste...</summary>
    [ForeignKey("KullaniciNavigation")]
    public string KULLANICI_KODU { get; set; }

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
    public virtual KULLANICI_GRUP? KullaniciGrupNavigation { get; set; }
    public virtual KULLANICI? KullaniciNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}