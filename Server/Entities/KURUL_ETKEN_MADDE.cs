using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_KURUL_ETKEN_MADDE tablosu - 13 kolon
/// </summary>
[Table("KURUL_ETKEN_MADDE")]
public class KURUL_ETKEN_MADDE
{
    /// <summary>Hasta için verilen sağlık raporunda bulunan ilaçların etken madde bilgileri için...</summary>
    [Key]
    public string KURUL_ETKEN_MADDE_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Hastaya sağlık raporu veren kurul için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("KurulRaporNavigation")]
    public string KURUL_RAPOR_KODU { get; set; }

    /// <summary>İlacın içeriğinde bulunan etken maddeler için Sağlık Bilgi Yönetim Sistemi taraf...</summary>
    public string ILAC_ETKEN_MADDE_KODU { get; set; }

    /// <summary>İlacın günde kaç kez kullanılacağı bilgisidir. Örneğin 3 yazılmışsa periyot biri...</summary>
    [Required]
    public string DOZ_SAYISI { get; set; }

    /// <summary>Hastanın bir seferde kullanılacağı ilacın miktar bilgisidir.</summary>
    [Required]
    public string DOZ_MIKTARI { get; set; }

    /// <summary>Bir ilacın, hastaya tek seferde verilebilecek miktarı için ölçü bilgisidir.</summary>
    [Required]
    [ForeignKey("DozBirimNavigation")]
    public string DOZ_BIRIM { get; set; }

    /// <summary>İlacın kullanım periyodunu ifade eder.</summary>
    [Required]
    public string ILAC_KULLANIM_PERIYODU { get; set; }

    /// <summary>İlacın hangi periyot biriminde kullanılacağını ifade eder.</summary>
    [Required]
    [ForeignKey("IlacPeriyotBirimiNavigation")]
    public string ILAC_PERIYOT_BIRIMI { get; set; }

    /// <summary>Kurul etken madde bilgisinin ilk kayıt edildiği zaman bilgisidir.</summary>
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
    public virtual KURUL_RAPOR? KurulRaporNavigation { get; set; }
    public virtual REFERANS_KODLAR? DozBirimNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlacPeriyotBirimiNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}