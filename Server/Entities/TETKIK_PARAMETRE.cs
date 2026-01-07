using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_TETKIK_PARAMETRE tablosu - 17 kolon
/// </summary>
[Table("TETKIK_PARAMETRE")]
public class TETKIK_PARAMETRE
{
    /// <summary>Sağlık tesisinde yapılan tetkiklerdeki parametreler için Sağlık Bilgi Yönetim Si...</summary>
    [Key]
    public string TETKIK_PARAMETRE_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde yapılan tetkiklerde varsa parametre ad bilgisidir.</summary>
    public string TETKIK_PARAMETRE_ADI { get; set; }

    /// <summary>Sağlık tesisinde yapılan tetkiklerin parametresinin birim bilgisidir. Örneğin mg...</summary>
    [Required]
    public string TETKIK_PARAMETRE_BIRIMI { get; set; }

    /// <summary>Sağlık tesisinde yapılan tetkikler için Sağlık Bilgi Yönetim Sistemi tarafından ...</summary>
    [ForeignKey("TetkikNavigation")]
    public string TETKIK_KODU { get; set; }

    /// <summary>Sağlık tesisinde bulunan cihaz için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [Required]
    [ForeignKey("CihazNavigation")]
    public string CIHAZ_KODU { get; set; }

    /// <summary>Sağlık tesisinde tedavi gören hastalara laboratuvar tarafından girilen test para...</summary>
    [Required]
    public string MEDULA_PARAMETRE_KODU { get; set; }

    /// <summary>LOINC, Sağlık tesisinde laboratuvar veya radyolojik tetkik sonuçlarının sınıflan...</summary>
    [Required]
    public string LOINC_KODU { get; set; }

    /// <summary>Hastaya verilen tetkik sonuç raporunda tetkik veya parametrenin bulunduğu sıra b...</summary>
    public string RAPOR_SONUC_SIRASI { get; set; }

    /// <summary>Sağlık tesisinde yapılan bir işlemin iptal edilip edilmediği bilgisidir.</summary>
    public string IPTAL_DURUMU { get; set; }

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
    public virtual TETKIK? TetkikNavigation { get; set; }
    public virtual CIHAZ? CihazNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}