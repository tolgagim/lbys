using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_HASTA_EPIKRIZ tablosu - 12 kolon
/// </summary>
[Table("HASTA_EPIKRIZ")]
public class HASTA_EPIKRIZ
{
    /// <summary>Hekimin muayene yaptıktan sonra hasta için yazdığı epikriz bilgileri için Sağlık...</summary>
    [Key]
    public string HASTA_EPIKRIZ_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Epikrizin yazıldığı zaman bilgisidir.</summary>
    public DateTime? EPIKRIZ_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde hastaya hekimi tarafından yazılan epikrizin başlık bilgisidir.</summary>
    [ForeignKey("EpikrizBaslikBilgisiNavigation")]
    public string EPIKRIZ_BASLIK_BILGISI { get; set; }

    /// <summary>Sağlık tesisine gelen, ayaktan ve yatan hastalar için hekimlerin yazdığı epikriz...</summary>
    [Required]
    public string EPIKRIZ_BILGISI_ACIKLAMA { get; set; }

    /// <summary>Sağlık tesisinde görevli hekim için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [Required]
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }

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
    public virtual REFERANS_KODLAR? EpikrizBaslikBilgisiNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}