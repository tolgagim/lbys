using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// HASTA_OLUM tablosu - 24 kolon
/// </summary>
[Table("HASTA_OLUM")]
public class HASTA_OLUM
{
    /// <summary>Hasta ölüm bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından üretilen tekil...</summary>
    [Key]
    public string HASTA_OLUM_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Kişinin ölüm zamanı bilgisidir.</summary>
    public DateTime? OLUM_ZAMANI { get; set; }

    /// <summary>Ölümün gerçeklestigi yeri ifade eder. Örnegin ev, is, birinci basamak saglik kur...</summary>
    [Required]
    [ForeignKey("OlumYeriNavigation")]
    public string OLUM_YERI { get; set; }

    /// <summary>Bir kadının, gebelik sırasında ya da gebeliğin sonlanmasından sonraki 42 gün içi...</summary>
    [Required]
    [ForeignKey("AnneOlumNedeniNavigation")]
    public string ANNE_OLUM_NEDENI { get; set; }

    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>Ölümden sonra hastalıktan kaynaklanan bir değişimin özellikle boyutunu ya da ölü...</summary>
    [Required]
    [ForeignKey("OtopsiDurumuNavigation")]
    public string OTOPSI_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde ölüm belgesini düzenleyen personel için Sağlık Bilgi Yönetim Si...</summary>
    [Required]
    [ForeignKey("OlumBelgesiPersonelNavigation")]
    public string OLUM_BELGESI_PERSONEL_KODU { get; set; }

    /// <summary>Ölüm nedeni, ölüme katkıda bulunmuş ya da ölümle sonuçlanmış tüm hastalıklar, mo...</summary>
    [Required]
    [ForeignKey("OlumNedeniTaniNavigation")]
    public string OLUM_NEDENI_TANI_KODU { get; set; }

    /// <summary>Ölüm nedenlerinin sınıflandırılmasını ifade eder. Örneğin son neden, ara neden v...</summary>
    [Required]
    [ForeignKey("OlumNedeniTuruNavigation")]
    public string OLUM_NEDENI_TURU { get; set; }

    /// <summary>Ölümün ne şekilde gerçekleştiğini ifade eder. Örneğin doğal ölüm, iş kazası, cin...</summary>
    [ForeignKey("OlumSekliNavigation")]
    public string OLUM_SEKLI { get; set; }

    /// <summary>Kişinin öldüğüne dair ölüm kararını veren hekim için Sağlık Bilgi Yönetim Sistem...</summary>
    [Required]
    [ForeignKey("ExKarariniVerenHekimNavigation")]
    public string EX_KARARINI_VEREN_HEKIM_KODU { get; set; }

    /// <summary>Sağlık tesisinde ölüm gibi olaylar esnasında tutulan tutanağın zaman bilgisidir.</summary>
    public DateTime TUTANAK_ZAMANI { get; set; }

    /// <summary>Kan ürünü, numune, adli rapor, nüfus cüzdanı, malzeme vb. teslim alan kişinin T....</summary>
    [Required]
    public string TESLIM_ALAN_TC_KIMLIK_NUMARASI { get; set; }

    /// <summary>Kan ürünü, numune, adli rapor, nüfus cüzdanı, malzeme vb. teslim alan kişinin ad...</summary>
    [Required]
    public string TESLIM_ALAN_ADI_SOYADI { get; set; }

    /// <summary>Kan ürünü, numune, adli rapor, nüfus cüzdanı, malzeme vb. teslim alan kişinin te...</summary>
    [Required]
    public string TESLIM_ALAN_TELEFON_BILGISI { get; set; }

    /// <summary>Kan ürünü, numune, adli rapor, nüfus cüzdanı, malzeme vb. teslim alan kişinin ad...</summary>
    [Required]
    public string TESLIM_ALAN_ADRESI { get; set; }

    /// <summary>Kan ürünü, numune, adli rapor, nüfus cüzdanı, malzeme vb. ilgili kişiye teslim e...</summary>
    [Required]
    [ForeignKey("TeslimEdenPersonelNavigation")]
    public string TESLIM_EDEN_PERSONEL_KODU { get; set; }

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
    public virtual REFERANS_KODLAR? OlumYeriNavigation { get; set; }
    public virtual REFERANS_KODLAR? AnneOlumNedeniNavigation { get; set; }
    public virtual REFERANS_KODLAR? OtopsiDurumuNavigation { get; set; }
    public virtual PERSONEL? OlumBelgesiPersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? OlumNedeniTaniNavigation { get; set; }
    public virtual REFERANS_KODLAR? OlumNedeniTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? OlumSekliNavigation { get; set; }
    public virtual PERSONEL? ExKarariniVerenHekimNavigation { get; set; }
    public virtual PERSONEL? TeslimEdenPersonelNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}