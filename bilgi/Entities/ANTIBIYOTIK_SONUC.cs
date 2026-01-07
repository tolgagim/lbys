using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// ANTIBIYOTIK_SONUC tablosu - 12 kolon
/// </summary>
[Table("ANTIBIYOTIK_SONUC")]
public class ANTIBIYOTIK_SONUC
{
    /// <summary>Sağlık tesisinde laboratuvarda hastadan alınan materyallerde antibiyotik direnç ...</summary>
    [Key]
    public string ANTIBIYOTIK_SONUC_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde laboratuvarda yapılan testler sonucunda numunede üreyen bakteri...</summary>
    [ForeignKey("BakteriSonucNavigation")]
    public string BAKTERI_SONUC_KODU { get; set; }

    /// <summary>Penisilin, amikasin, gentamisin vb. antibiyotikler için Sağlık Bilgi Yönetim Sis...</summary>
    [ForeignKey("AntibiyotikNavigation")]
    public string ANTIBIYOTIK_KODU { get; set; }

    /// <summary>Sağlık tesisinde yapılan tetkiklerin sonuç bilgisidir.</summary>
    [ForeignKey("TetkikSonucuNavigation")]
    public string TETKIK_SONUCU { get; set; }

    /// <summary>Disk etrafında bakterinin üremediği bölgenin milimetrik olarak çap bilgisidir.</summary>
    [Required]
    public string ZON_CAPI { get; set; }

    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>Hastaya verilen tetkik sonuç raporunda tetkik, parametre, antibiyotik vb. sonucu...</summary>
    public string RAPORDA_GORULME_DURUMU { get; set; }

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
    public virtual BAKTERI_SONUC? BakteriSonucNavigation { get; set; }
    public virtual REFERANS_KODLAR? AntibiyotikNavigation { get; set; }
    public virtual REFERANS_KODLAR? TetkikSonucuNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}