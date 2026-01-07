using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_RECETE_ILAC tablosu - 18 kolon
/// </summary>
[Table("RECETE_ILAC")]
public class RECETE_ILAC
{
    /// <summary>Sağlık tesisinde tedavi gören hasta için düzenlenen reçetede bulunan ilaç bilgil...</summary>
    [Key]
    public string RECETE_ILAC_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde tedavi gören hasta için düzenlenen reçetede bilgileri için Sağl...</summary>
    [ForeignKey("ReceteNavigation")]
    public string RECETE_KODU { get; set; }

    /// <summary>Bir ilacın, hastaya tek seferde verilebilecek miktarı için ölçü bilgisidir. Örne...</summary>
    [Required]
    [ForeignKey("DozBirimNavigation")]
    public string DOZ_BIRIM { get; set; }

    /// <summary>Çubuk kod ya da çizgi im, verilerin görsel özellikli makinelerin okuyabilmesi iç...</summary>
    public string BARKOD { get; set; }

    /// <summary>İlacın ad bilgisidir.</summary>
    [Required]
    public string ILAC_ADI { get; set; }

    /// <summary>İlacın kutu adeti bilgisidir.</summary>
    public string KUTU_ADETI { get; set; }

    /// <summary>İlacın uygulanma yöntemini ifade eder. Örneğin göz üzerine, ağızdan, burun içi v...</summary>
    [Required]
    [ForeignKey("IlacKullanimSekliNavigation")]
    public string ILAC_KULLANIM_SEKLI { get; set; }

    /// <summary>İlacın kullanım sayısı bilgisidir.</summary>
    [Required]
    public string ILAC_KULLANIM_SAYISI { get; set; }

    /// <summary>İlacın kullanılması gereken miktar bilgisini ifade eder.</summary>
    [Required]
    public string ILAC_KULLANIM_DOZU { get; set; }

    /// <summary>İlacın kullanım periyodunu ifade eder.</summary>
    [Required]
    public string ILAC_KULLANIM_PERIYODU { get; set; }

    /// <summary>İlacın hangi periyot biriminde kullanılacağını ifade eder. Örneğin ay, dakika, g...</summary>
    [Required]
    [ForeignKey("IlacKullanimPeriyoduBirimiNavigation")]
    public string ILAC_KULLANIM_PERIYODU_BIRIMI { get; set; }

    /// <summary>İlaç ile ilgili açıklama bilgisidir.</summary>
    [Required]
    public string ILAC_ACIKLAMA { get; set; }

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
    public virtual RECETE? ReceteNavigation { get; set; }
    public virtual REFERANS_KODLAR? DozBirimNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlacKullanimSekliNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlacKullanimPeriyoduBirimiNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}