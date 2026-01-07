using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_VEZNE tablosu - 24 kolon
/// </summary>
[Table("VEZNE")]
public class VEZNE
{
    /// <summary>Sağlık tesisi veznesinde yapılan işlemlerin bilgisi için Sağlık Bilgi Yönetim Si...</summary>
    [Key]
    public string VEZNE_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [Required]
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık tesisindeki vezne birimi tarafından kesilen tahsilat veya ödemelerin yıl ...</summary>
    public string MAKBUZ_NUMARASI { get; set; }

    /// <summary>Sağlık tesisi veznesinde yapılan tahsilat veya ödemelerle ilgili Sağlık Bilgi Yö...</summary>
    [Required]
    public string VEZNE_OZEL_NUMARASI { get; set; }

    /// <summary>Sağlık tesisi veznesinin yaptığı işlemin tahsilat veya ödeme işlemine ilişkin bi...</summary>
    public string VEZNE_GIRIS_CIKIS_BILGISI { get; set; }

    /// <summary>Sağlık tesisindeki vezne birimi tarafından kesilen tahsilat veya ödemelerin yapı...</summary>
    public DateTime? MAKBUZ_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde bulunan vezne birimleri için Sağlık Bilgi Yönetim Sistemi taraf...</summary>
    [ForeignKey("VezneBirimNavigation")]
    public string VEZNE_BIRIM_KODU { get; set; }

    /// <summary>Sağlık tesisinde üretilen makbuzun seri numarası bilgisini ifade eder.</summary>
    [Required]
    public string MAKBUZ_SERI_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde yapılan bir işlemin iptal edilip edilmediği bilgisidir.</summary>
    public string IPTAL_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde üretilen verinin iptal edildiği zaman bilgisidir.</summary>
    public DateTime IPTAL_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde yapılan bir işlemin iptal edilmesi durumunda Sağlık Bilgi Yönet...</summary>
    [Required]
    public string IPTAL_ACIKLAMA { get; set; }

    /// <summary>Sağlık tesisindeki vezne tarafından yapılan tahsilat ve ödemelerin türünü ifade ...</summary>
    [Required]
    [ForeignKey("TahsilTuruNavigation")]
    public string TAHSIL_TURU { get; set; }

    /// <summary>Sağlık tesisinin veznesinde işlem yapılan makbuz tutarı bilgisidir.</summary>
    public string MAKBUZ_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>Makbuz sahibinin adres bilgisidir.</summary>
    [Required]
    public string MAKBUZ_SAHIBI_ADRESI { get; set; }

    /// <summary>Sağlık tesisinin mal veya hizmet alımı yaptığı firma için ad bilgisidir.</summary>
    [Required]
    public string FIRMA_ADI { get; set; }

    /// <summary>Sağlık tesisinin mal veya hizmet alımı yaptığı firma için Sağlık Bilgi Yönetim S...</summary>
    [Required]
    [ForeignKey("FirmaNavigation")]
    public string FIRMA_KODU { get; set; }

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
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual BIRIM? VezneBirimNavigation { get; set; }
    public virtual REFERANS_KODLAR? TahsilTuruNavigation { get; set; }
    public virtual FIRMA? FirmaNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}