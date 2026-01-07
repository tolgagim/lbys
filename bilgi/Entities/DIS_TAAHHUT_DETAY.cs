using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// DIS_TAAHHUT_DETAY tablosu - 10 kolon
/// </summary>
[Table("DIS_TAAHHUT_DETAY")]
public class DIS_TAAHHUT_DETAY
{
    /// <summary>Diş tedavisi yapılan hastalar için MEDULA sisteminden alınan taahhüte ilişkin de...</summary>
    [Key]
    public string DIS_TAAHHUT_DETAY_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Diş tedavisi yapılan hastalar için MEDULA sisteminden alınan taahhüt bilgilerini...</summary>
    [ForeignKey("DisTaahhutNavigation")]
    public string DIS_TAAHHUT_KODU { get; set; }

    /// <summary>Ağızdaki dişler için Sağlık Bilgi Yönetim Sistemi tarafından verilmiş kod bilgis...</summary>
    [Required]
    [ForeignKey("DisNavigation")]
    public string DIS_KODU { get; set; }

    /// <summary>Sosyal Güvenlik Kurumu tarafından yayımlanan, hastaya uygulanan işlem veya hizme...</summary>
    public string SUT_KODU { get; set; }

    /// <summary>Kişinin diş tedavisi için işlem yapılan çene bölgesi için Sağlık Bilgi Yönetim S...</summary>
    [Required]
    [ForeignKey("CeneNavigation")]
    public string CENE_KODU { get; set; }

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
    public virtual DIS_TAAHHUT? DisTaahhutNavigation { get; set; }
    public virtual REFERANS_KODLAR? DisNavigation { get; set; }
    public virtual REFERANS_KODLAR? CeneNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}