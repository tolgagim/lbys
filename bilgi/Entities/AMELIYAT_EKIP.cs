using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// AMELIYAT_EKIP tablosu - 11 kolon
/// </summary>
[Table("AMELIYAT_EKIP")]
public class AMELIYAT_EKIP
{
    /// <summary>Sağlık tesisinde ameliyatı gerçekleştiren ekip (operatör, anestezi uzmanı, hemşi...</summary>
    [Key]
    public string AMELIYAT_EKIP_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde yapılan ameliyatın bilgilerine erişim sağlamak için Sağlık Bilg...</summary>
    [ForeignKey("AmeliyatNavigation")]
    public string AMELIYAT_KODU { get; set; }

    /// <summary>Sağlık tesisinde yapılan ameliyatın işlem bilgilerine erişim sağlamak için Sağlı...</summary>
    [ForeignKey("AmeliyatIslemNavigation")]
    public string AMELIYAT_ISLEM_KODU { get; set; }

    /// <summary>Ameliyatı yapan ekibe (hekim, hemşire, anestezi uzmanı, anestezi teknisyeni vb. ...</summary>
    [Required]
    public string EKIP_NUMARASI { get; set; }

    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }

    /// <summary>Ameliyat ekibinde bulunan personelin görevlerine ilişkin bilgiyi ifade eder.</summary>
    [Required]
    [ForeignKey("AmeliyatPersonelGorevNavigation")]
    public string AMELIYAT_PERSONEL_GOREV { get; set; }

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
    public virtual AMELIYAT? AmeliyatNavigation { get; set; }
    public virtual AMELIYAT_ISLEM? AmeliyatIslemNavigation { get; set; }
    public virtual PERSONEL? PersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? AmeliyatPersonelGorevNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}