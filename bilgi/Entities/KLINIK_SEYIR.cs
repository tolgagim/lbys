using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// KLINIK_SEYIR tablosu - 14 kolon
/// </summary>
[Table("KLINIK_SEYIR")]
public class KLINIK_SEYIR
{
    /// <summary>Sağlık tesisinde tedavi alan hastanın seyir bilgileri (günlük epikriz bilgileri)...</summary>
    [Key]
    public string KLINIK_SEYIR_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Hastanın tedavisinin seyiri için Sağlık Bilgi Yönetim Sistemi tarafından yapılan...</summary>
    [ForeignKey("SeyirTipiNavigation")]
    public string SEYIR_TIPI { get; set; }

    /// <summary>Hastanın tedavisinin seyir bilgisinin Sağlık Bilgi Yönetim Sistemine girildiği z...</summary>
    public DateTime? SEYIR_ZAMANI { get; set; }

    /// <summary>Hastanın tedavisi için hekimlerin yazdığı günlük seyir bilgisini ifade eder.</summary>
    [Required]
    public string SEYIR_BILGISI { get; set; }

    /// <summary>Hastanın septik şok durumuna ilişkin bilgidir.</summary>
    [Required]
    [ForeignKey("SeptikSokNavigation")]
    public string SEPTIK_SOK { get; set; }

    /// <summary>Hastanın sepsis durumuna ilişkin bilgidir.</summary>
    [Required]
    [ForeignKey("SepsisDurumuNavigation")]
    public string SEPSIS_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde görevli hekim için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
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
    public virtual REFERANS_KODLAR? SeyirTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SeptikSokNavigation { get; set; }
    public virtual REFERANS_KODLAR? SepsisDurumuNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}