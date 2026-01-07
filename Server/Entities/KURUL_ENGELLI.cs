using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_KURUL_ENGELLI tablosu - 14 kolon
/// </summary>
[Table("KURUL_ENGELLI")]
public class KURUL_ENGELLI
{
    /// <summary>Sağlık kurulunda düzenlenen engelli raporlarına ait bilgiler için Sağlık Bilgi Y...</summary>
    [Key]
    public string KURUL_ENGELLI_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Hastaya sağlık raporu veren kurul için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("KurulRaporNavigation")]
    public string KURUL_RAPOR_KODU { get; set; }

    /// <summary>Engelli raporu düzenlenen kişinin, çalıştırılamayacağı işlerin niteliğini ifade ...</summary>
    [Required]
    public string CALISTIRILAMAYACAK_ISNITELIGI { get; set; }

    /// <summary>Engelli raporu düzenlenen kişiye ait raporun süreklilik durumunu ifade eder.</summary>
    [Required]
    public string ENGELLI_SUREKLILIK_DURUMU { get; set; }

    /// <summary>Engel durumuna göre engellilik oranı %50 ve üzerinde olduğu tespit edilenlerden ...</summary>
    [Required]
    public string AGIR_ENGELLI { get; set; }

    /// <summary>Engelli raporu düzenlenen kişinin engellilik grubunu ifade eder.</summary>
    [Required]
    public string ENGELLI_GRUBU { get; set; }

    /// <summary>Engelli raporu düzenlenen kişinin raporu kullanım amacını ifade eder.</summary>
    [Required]
    public string ENGELLI_RAPOR_KULLANIM_AMACI { get; set; }

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
    public virtual KURUL_RAPOR? KurulRaporNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}