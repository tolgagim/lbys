using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_RECETE tablosu - 20 kolon
/// </summary>
[Table("RECETE")]
public class RECETE
{
    /// <summary>SBYS tarafından üretilen tekil kod bilgisidir.</summary>
    [Key]
    public string RECETE_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Reçetenin yazıldığı zaman bilgisidir.</summary>
    public DateTime? RECETE_ZAMANI { get; set; }

    /// <summary>Reçetenin, içerdiği ilaç cinsine göre belirlenen türünü ifade etmektedir. Örneği...</summary>
    [ForeignKey("ReceteTuruNavigation")]
    public string RECETE_TURU { get; set; }

    /// <summary>Sağlık tesisinde tedavi gören hasta için düzenlenen reçetenin alt türü bilgisidi...</summary>
    [Required]
    [ForeignKey("ReceteAltTuruNavigation")]
    public string RECETE_ALT_TURU { get; set; }

    /// <summary>Sağlık tesisinde görevli hekim için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }

    /// <summary>Sağlık tesisindeki birimlerde hasta bilgilerinin olduğu defter numarası bilgisid...</summary>
    [Required]
    public string DEFTER_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde düzenlenen reçete için MEDULA tarafından Sağlık Bilgi Yönetim S...</summary>
    [Required]
    public string MEDULA_E_RECETE_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde hastaya düzenlenen reçete için Renkli Reçete Sistemi tarafından...</summary>
    [Required]
    public string RENKLI_RECETE_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde bulunan tıbbi cihazların seri numarası bilgisini ifade eder.</summary>
    [Required]
    public string SERI_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde tedavi gören hasta için düzenlenen reçetenin e-İmza imzalanma d...</summary>
    [Required]
    public string RECETE_E_IMZA_DURUMU { get; set; }

    /// <summary>Sağlık tesisine gelen hasta için MEDULA sisteminden Sağlık Bilgi Yönetim Sistemi...</summary>
    [Required]
    public string SGK_TAKIP_NUMARASI { get; set; }

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
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual REFERANS_KODLAR? ReceteTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? ReceteAltTuruNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}