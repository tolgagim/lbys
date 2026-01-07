using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// RADYOLOJI_SONUC tablosu - 17 kolon
/// </summary>
[Table("RADYOLOJI_SONUC")]
public class RADYOLOJI_SONUC
{
    /// <summary>Sağlık tesisinde çalışılan radyoloji tetkikinin sonucu için Sağlık Bilgi Yönetim...</summary>
    [Key]
    public string RADYOLOJI_SONUC_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde çalışılan radyoloji tetkileri için Sağlık Bilgi Yönetim Sistemi...</summary>
    [ForeignKey("RadyolojiNavigation")]
    public string RADYOLOJI_KODU { get; set; }

    /// <summary>Radyoloji tetkikleri için rapora yazılan sonuç bilgisinin metin (text) bilgisidi...</summary>
    [Required]
    public string TETKIK_SONUCU_METIN { get; set; }

    /// <summary>Radyoloji tetkikleri için rapora yazılan sonuç bilgisinin raporda yazıldığı hali...</summary>
    [Required]
    public string RADYOLOJI_TETKIK_SONUCU { get; set; }

    /// <summary>Radyoloji raporları için Sağlık Bilgi Yönetim Sistemi tarafından kayıt edilen do...</summary>
    [ForeignKey("RadyolojiRaporFormatiNavigation")]
    public string RADYOLOJI_RAPOR_FORMATI { get; set; }

    /// <summary>Raporun ana rapor, ek rapor, konsültasyon raporu vb. olma durumuna ilişkin bilgi...</summary>
    [ForeignKey("RaporTipiNavigation")]
    public string RAPOR_TIPI { get; set; }

    /// <summary>Raporu bilgisayar ortamına aktaran personel için Sağlık Bilgi Yönetim Sistemi ta...</summary>
    [Required]
    [ForeignKey("RaporYazanPersonelNavigation")]
    public string RAPOR_YAZAN_PERSONEL_KODU { get; set; }

    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [Required]
    [ForeignKey("OnaylayanPersonel1Navigation")]
    public string ONAYLAYAN_PERSONEL_KODU_1 { get; set; }

    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [Required]
    [ForeignKey("OnaylayanPersonel2Navigation")]
    public string ONAYLAYAN_PERSONEL_KODU_2 { get; set; }

    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [Required]
    [ForeignKey("OnaylayanPersonel3Navigation")]
    public string ONAYLAYAN_PERSONEL_KODU_3 { get; set; }

    /// <summary>Sağlık tesisinde üretilen tıbbi raporun uzman hekim tarafından onaylandığı zaman...</summary>
    public DateTime RAPOR_UZMAN_ONAY_ZAMANI { get; set; }

    /// <summary>Raporun kaydedildiği zaman bilgisidir.</summary>
    public DateTime? RAPOR_KAYIT_ZAMANI { get; set; }

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
    public virtual RADYOLOJI? RadyolojiNavigation { get; set; }
    public virtual REFERANS_KODLAR? RadyolojiRaporFormatiNavigation { get; set; }
    public virtual REFERANS_KODLAR? RaporTipiNavigation { get; set; }
    public virtual PERSONEL? RaporYazanPersonelNavigation { get; set; }
    public virtual PERSONEL? OnaylayanPersonel1Navigation { get; set; }
    public virtual PERSONEL? OnaylayanPersonel2Navigation { get; set; }
    public virtual PERSONEL? OnaylayanPersonel3Navigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}