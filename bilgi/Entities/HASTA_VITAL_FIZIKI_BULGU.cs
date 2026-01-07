using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// HASTA_VITAL_FIZIKI_BULGU tablosu - 23 kolon
/// </summary>
[Table("HASTA_VITAL_FIZIKI_BULGU")]
public class HASTA_VITAL_FIZIKI_BULGU
{
    /// <summary>Sağlık tesisinde tedavi olan hastanın vital bulguları için Sağlık Bilgi Yönetim ...</summary>
    [Key]
    public string HASTA_VITAL_FIZIKI_BULGU_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık tesisinde yapılan işlemlerin, uygulanmaya başladığı zaman bilgisidir.</summary>
    public DateTime? ISLEM_ZAMANI { get; set; }

    /// <summary>Sistolik kan basıncı (büyük tansiyon) bilgisini ifade eder.</summary>
    [Required]
    public string SISTOLIK_KAN_BASINCI_DEGERI { get; set; }

    /// <summary>Kan basıncı ölçme protokolüne uygun olarak "mm Hg" birimi ile ölçülen diastolik ...</summary>
    [Required]
    public string DIASTOLIK_KAN_BASINCI_DEGERI { get; set; }

    /// <summary>Hastanın 1 dakikadaki atım sayısı cinsinden nabız bilgisidir.</summary>
    [Required]
    public string NABIZ { get; set; }

    /// <summary>Hastanın solunum bilgisidir.</summary>
    [Required]
    public string SOLUNUM { get; set; }

    /// <summary>Kişinin santigrat cinsinden vücut ısısı bilgisidir.</summary>
    [Required]
    public string ATES { get; set; }

    /// <summary>Bebek veya çocuğun baş çevresinin (santimetre cinsinden) ölçüsüdür.</summary>
    [Required]
    public string BAS_CEVRESI { get; set; }

    /// <summary>Kişinin santimetre cinsinden boy bilgisidir.</summary>
    [Required]
    public string BOY { get; set; }

    /// <summary>Kişinin (gram cinsinden) ağırlığıdır.</summary>
    [Required]
    public string AGIRLIK { get; set; }

    /// <summary>Kişinin yüzde cinsinden oksijen saturasyonu bilgisini ifade eder.</summary>
    [Required]
    public string SATURASYON { get; set; }

    /// <summary>Hastanın (santimetre cinsinden) bel çevresidir.</summary>
    [Required]
    public string BEL_CEVRESI { get; set; }

    /// <summary>Hastanın (santimetre cinsinden) kalça çevresidir</summary>
    [Required]
    public string KALCA_CEVRESI { get; set; }

    /// <summary>Hastanın santimetre cinsinden kol çevresi ölçüsü bilgisidir.</summary>
    [Required]
    public string KOL_CEVRESI { get; set; }

    /// <summary>Hastanın santimetre cinsinden karın çevresi ölçüsü bilgisidir.</summary>
    [Required]
    public string KARIN_CEVRESI { get; set; }

    /// <summary>Sağlık tesisinde görevli hemşire için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [Required]
    [ForeignKey("HemsireNavigation")]
    public string HEMSIRE_KODU { get; set; }

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
    public virtual PERSONEL? HemsireNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}