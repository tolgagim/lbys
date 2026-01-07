using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// SILINEN_KAYITLAR tablosu - 6 kolon
/// </summary>
[Table("SILINEN_KAYITLAR")]
public class SILINEN_KAYITLAR
{
    /// <summary>Silinen kayitlar için Saglik Bilgi Yönetim Sistemi tarafindan üretilen tekil kod...</summary>
    [Key]
    public string SILINEN_KAYITLAR_KODU { get; set; }

    /// <summary>Kaydın silinmeden önce bulunduğu VEM Görüntü Adı bilgisidir.</summary>
    public string REFERANS_GORUNTU_ADI { get; set; }

    /// <summary>Kaydın silinme zamanı bilgisidir.</summary>
    public DateTime? SILINME_ZAMANI { get; set; }

    /// <summary>Kaydin silinmeden önce bulundugu VEM Görüntüsü içerisindeki SBYS tarafindan üret...</summary>
    public string SILINEN_KAYDIN_KODU { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime? GUNCELLEME_ZAMANI { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }

    #region Navigation Properties
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}