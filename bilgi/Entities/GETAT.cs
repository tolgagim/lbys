using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// GETAT tablosu - 15 kolon
/// </summary>
[Table("GETAT")]
public class GETAT
{
    /// <summary>Geleneksel ve Tamamlayıcı Tıp Tedavisi (GETAT) kayıtları için Sağlık Bilgi Yönet...</summary>
    [Key]
    public string GETAT_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı tablo adı bilgisidir.</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık tesisinde Geleneksel ve Tamamlayıcı Tıp Uygulamaları (GETAT) uygulamasını...</summary>
    [ForeignKey("GetatUygulamaBirimiNavigation")]
    public string GETAT_UYGULAMA_BIRIMI { get; set; }

    /// <summary>Geleneksel ve tamamlayıcı tıp tedavisinde oluşan komplikasyon tanı bilgisini ifa...</summary>
    [Required]
    [ForeignKey("KomplikasyonTanisiNavigation")]
    public string KOMPLIKASYON_TANISI { get; set; }

    /// <summary>Sağlık tesisinde Geleneksel ve Tamamlayıcı Tıp Uygulamaları (GETAT) uygulamasını...</summary>
    [Required]
    [ForeignKey("GetatTedaviSonucuNavigation")]
    public string GETAT_TEDAVI_SONUCU { get; set; }

    /// <summary>Geleneksel ve Tamamlayıcı Tıp Uygulamaları (GETAT) işleminin tür bilgisidir. Örn...</summary>
    [ForeignKey("GetatUygulamaTuruNavigation")]
    public string GETAT_UYGULAMA_TURU { get; set; }

    /// <summary>Sağlık tesisinde Geleneksel ve Tamamlayıcı Tıp Uygulamaları (GETAT) uygulamasını...</summary>
    [ForeignKey("GetatUygulandigiDurumlarNavigation")]
    public string GETAT_UYGULANDIGI_DURUMLAR { get; set; }

    /// <summary>Geleneksel ve Tamamlayıcı Tıp Uygulamaları (GETAT) işleminin sağlık hizmetini al...</summary>
    [ForeignKey("GetatUygulamaBolgesiNavigation")]
    public string GETAT_UYGULAMA_BOLGESI { get; set; }

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
    public virtual REFERANS_KODLAR? GetatUygulamaBirimiNavigation { get; set; }
    public virtual REFERANS_KODLAR? KomplikasyonTanisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? GetatTedaviSonucuNavigation { get; set; }
    public virtual REFERANS_KODLAR? GetatUygulamaTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? GetatUygulandigiDurumlarNavigation { get; set; }
    public virtual REFERANS_KODLAR? GetatUygulamaBolgesiNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}