using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// KURUL tablosu - 11 kolon
/// </summary>
[Table("KURUL")]
public class KURUL
{
    /// <summary>Sağlık tesisinde düzenlenen sağlık kurulu tarafından verilen raporların tanım bi...</summary>
    [Key]
    public string KURUL_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Kurul adı bilgisidir.</summary>
    public string KURUL_ADI { get; set; }

    /// <summary>Hastaya verilen rapor türünü ifade eder.</summary>
    [ForeignKey("RaporTuruNavigation")]
    public string RAPOR_TURU { get; set; }

    /// <summary>Sağlık tesisinde düzenlenen heyet veya tek hekim raporları için MEDULA tarafında...</summary>
    [Required]
    [ForeignKey("MedulaRaporTuruNavigation")]
    public string MEDULA_RAPOR_TURU { get; set; }

    /// <summary>Sağlık tesisinde tedavi olan hastalar için düzenlenmiş heyet veya tek hekim rapo...</summary>
    [Required]
    [ForeignKey("MedulaAltRaporTuruNavigation")]
    public string MEDULA_ALT_RAPOR_TURU { get; set; }

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
    public virtual REFERANS_KODLAR? RaporTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? MedulaRaporTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? MedulaAltRaporTuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}