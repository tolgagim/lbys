using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_BASVURU_YEMEK tablosu - 12 kolon
/// </summary>
[Table("BASVURU_YEMEK")]
public class BASVURU_YEMEK
{
    /// <summary>Sağlık tesisinde yatan hastaya verilen yemek bilgileri için Sağlık Bilgi Yönetim...</summary>
    [Key]
    public string BASVURU_YEMEK_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı tablo adı bilgisidir.</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık tesisinde yatan hastaya verilen yemeğin normal yemek, diyet yemeği, diyab...</summary>
    [ForeignKey("YemekTuruNavigation")]
    public string YEMEK_TURU { get; set; }

    /// <summary>Sağlık tesisinde yatan hastalara verilen yemeğin tür bilgisini ifade eder. Örneğ...</summary>
    [ForeignKey("YemekZamaniTuruNavigation")]
    public string YEMEK_ZAMANI_TURU { get; set; }

    /// <summary>Sağlık tesisinde yatan hastaya yemeğin verildiği zaman bilgisidir.</summary>
    public DateTime? YEMEK_ZAMANI { get; set; }

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
    public virtual REFERANS_KODLAR? YemekTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? YemekZamaniTuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}