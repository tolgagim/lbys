using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// HASTA_DIS tablosu - 18 kolon
/// </summary>
[Table("HASTA_DIS")]
public class HASTA_DIS
{
    /// <summary>Hastaya uygulanan diş tedavi bilgileri için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [Key]
    public string HASTA_DIS_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Dişe uygulanan işlem türüdür. Örneğin diagnoz, tedavi, planlama vb.</summary>
    [ForeignKey("DisIslemTuruNavigation")]
    public string DIS_ISLEM_TURU { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanacak hizmetler için Sağlık Bilgi Yönetim Sistemi...</summary>
    [Required]
    [ForeignKey("HastaHizmetNavigation")]
    public string HASTA_HIZMET_KODU { get; set; }

    /// <summary>Diş tedavisi yapılan hastalar için MEDULA sisteminden alınan taahhüt bilgilerini...</summary>
    [Required]
    [ForeignKey("DisTaahhutNavigation")]
    public string DIS_TAAHHUT_KODU { get; set; }

    /// <summary>Hastanın mevcut diş durumunu ifade eder.</summary>
    [Required]
    [ForeignKey("MevcutDisDurumuNavigation")]
    public string MEVCUT_DIS_DURUMU { get; set; }

    /// <summary>Ağızdaki dişler için Sağlık Bilgi Yönetim Sistemi tarafından verilmiş kod bilgis...</summary>
    [Required]
    [ForeignKey("DisNavigation")]
    public string DIS_KODU { get; set; }

    /// <summary>Kişinin diş tedavisi için işlem yapılan bölge bilgisidir. Örneğin tüm çene bölge...</summary>
    [Required]
    [ForeignKey("CeneBolgesiNavigation")]
    public string CENE_BOLGESI { get; set; }

    /// <summary>Kişinin diş tedavisi için işlem yapılan çene bölgesinde bulunan diş bilgisidir.</summary>
    [Required]
    public string CENE_BOLGESI_DISLERI { get; set; }

    /// <summary>Diş protez tedavisi yapılan hastalar için protez bilgilerini kayıt etmek için Sa...</summary>
    [Required]
    [ForeignKey("DisprotezNavigation")]
    public string DISPROTEZ_KODU { get; set; }

    /// <summary>Sağlık tesisinde hasta için yapılan tüm işlemler için MEDULA'dan Sağlık Bilgi Yö...</summary>
    [Required]
    public string SONUC_KODU { get; set; }

    /// <summary>Sağlık tesisinde hasta için yapılan tüm işlemler için MEDULA'dan Sağlık Bilgi Yö...</summary>
    [Required]
    public string SONUC_MESAJI { get; set; }

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
    public virtual REFERANS_KODLAR? DisIslemTuruNavigation { get; set; }
    public virtual HASTA_HIZMET? HastaHizmetNavigation { get; set; }
    public virtual DIS_TAAHHUT? DisTaahhutNavigation { get; set; }
    public virtual REFERANS_KODLAR? MevcutDisDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? DisNavigation { get; set; }
    public virtual REFERANS_KODLAR? CeneBolgesiNavigation { get; set; }
    public virtual DISPROTEZ? DisprotezNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}