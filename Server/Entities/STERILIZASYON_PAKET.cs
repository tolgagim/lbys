using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_STERILIZASYON_PAKET tablosu - 14 kolon
/// </summary>
[Table("STERILIZASYON_PAKET")]
public class STERILIZASYON_PAKET
{
    /// <summary>Sağlık tesisinin deposunda bulunan steril aletlerin paket bilgilerine ilişkin ka...</summary>
    [Key]
    public string STERILIZASYON_PAKET_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sterilizasyon ünitesinde kullanılan paketler için tanımlanan ad bilgisidir.</summary>
    public string STERILIZASYON_PAKET_ADI { get; set; }

    /// <summary>Sterilizasyon ünitesinde kullanılan paketin barkod bilgisidir. Barkod bilgisi yo...</summary>
    public string PAKET_KODU { get; set; }

    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>Tıbbi aletler için sterilizasyon işleminin yapıldığı yöntem bilgisini ifade eder...</summary>
    [Required]
    [ForeignKey("SterilizasyonYontemiNavigation")]
    public string STERILIZASYON_YONTEMI { get; set; }

    /// <summary>Sterilizasyon ünitesinde kullanılan paketler için tanımlanan grup bilgisidir. Ör...</summary>
    [Required]
    [ForeignKey("SterilizasyonPaketGrubuNavigation")]
    public string STERILIZASYON_PAKET_GRUBU { get; set; }

    /// <summary>Steril edilmiş setin raf ömrünün gün olarak değer bilgisidir. Örneğin 30 gün, 60...</summary>
    [Required]
    public string PAKET_RAF_OMRU_BITIS_GUN { get; set; }

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
    public virtual REFERANS_KODLAR? SterilizasyonYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SterilizasyonPaketGrubuNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}