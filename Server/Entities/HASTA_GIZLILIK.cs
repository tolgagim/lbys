using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_HASTA_GIZLILIK tablosu - 15 kolon
/// </summary>
[Table("HASTA_GIZLILIK")]
public class HASTA_GIZLILIK
{
    /// <summary>Sağlık tesisinde gizlenen hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tara...</summary>
    [Key]
    public string HASTA_GIZLILIK_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Kişinin, sağlık tesisindeki verilerinin gizli olması durumunda verilerin gizlenm...</summary>
    [ForeignKey("GizlilikNedeniNavigation")]
    public string GIZLILIK_NEDENI { get; set; }

    /// <summary>Hastanın tıbbi işlemleri ile ilgili ekranlarda (arayüzlerde) kullanılacak ad bil...</summary>
    [Required]
    public string GORUNECEK_HASTA_ADI { get; set; }

    /// <summary>Hastanın tıbbi işlemleri ile ilgili ekranlarda (arayüzlerde) kullanılacak soyadı...</summary>
    [Required]
    public string GORUNECEK_HASTA_SOYADI { get; set; }

    /// <summary>Kişinin, sağlık tesisindeki hangi verilerinin gizlendiğini ifade eder. Örneğin h...</summary>
    [ForeignKey("GizlilikTuruNavigation")]
    public string GIZLILIK_TURU { get; set; }

    /// <summary>Kişinin, sağlık tesisindeki verilerinin gizlenmesi talebine ilişkin olarak kişin...</summary>
    public DateTime? GIZLILIK_BASLAMA_ZAMANI { get; set; }

    /// <summary>Kişinin, sağlık tesisindeki verilerinin gizlilik durumunun bittiği zaman bilgisi...</summary>
    public DateTime GIZLILIK_BITIS_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

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
    public virtual REFERANS_KODLAR? GizlilikNedeniNavigation { get; set; }
    public virtual REFERANS_KODLAR? GizlilikTuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}