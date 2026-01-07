using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// STOK_ISTEK tablosu - 16 kolon
/// </summary>
[Table("STOK_ISTEK")]
public class STOK_ISTEK
{
    /// <summary>Sağlık tesisindeki hekimin, hasta için istediği malzeme ve ilaçların sağlık tesi...</summary>
    [Key]
    public string STOK_ISTEK_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisinde tedavi gören hasta için hekim tarafından yapılan ilaç, malzeme ...</summary>
    public DateTime? ISTEK_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde bulunan stok depoları için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [ForeignKey("IstekDepoNavigation")]
    public string ISTEK_DEPO_KODU { get; set; }

    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }

    /// <summary>Sağlık tesisindeki depolardan yapılan isteklerin durumunu gösteren Sağlık Bilgi ...</summary>
    [ForeignKey("StokIstekDurumuNavigation")]
    public string STOK_ISTEK_DURUMU { get; set; }

    /// <summary>İstekle ilgili hekimin açıklama bilgisidir.</summary>
    [Required]
    public string STOK_ISTEK_HEKIM_ACIKLAMA { get; set; }

    /// <summary>Sağlık tesisinde yapılan ameliyatın bilgilerine erişim sağlamak için Sağlık Bilg...</summary>
    [Required]
    [ForeignKey("AmeliyatNavigation")]
    public string AMELIYAT_KODU { get; set; }

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
    public virtual DEPO? IstekDepoNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual REFERANS_KODLAR? StokIstekDurumuNavigation { get; set; }
    public virtual AMELIYAT? AmeliyatNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}