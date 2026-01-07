using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// MEDULA_TAKIP tablosu - 30 kolon
/// </summary>
[Table("MEDULA_TAKIP")]
public class MEDULA_TAKIP
{
    /// <summary>Sağlık tesisinde tedavi gören hasta için, çeşitli kriterlere göre MEDULA tarafın...</summary>
    [Key]
    public string MEDULA_TAKIP_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine gelen hasta için MEDULA sisteminden Sağlık Bilgi Yönetim Sistemi...</summary>
    public string SGK_TAKIP_NUMARASI { get; set; }

    /// <summary>Sağlık tesisine gelen hasta için MEDULA sisteminden Sağlık Bilgi Yönetim Sistemi...</summary>
    [Required]
    public string SGK_ILKTAKIP_NUMARASI { get; set; }

    /// <summary>Sağlık tesisi için MEDULA tarafından tanımlanmış numara bilgisidir.</summary>
    public string MEDULA_TESIS_KODU { get; set; }

    /// <summary>Sağlık tesisinde bulunan klinik ve hekimler için MEDULA tarafından tanımlanmış b...</summary>
    public string MEDULA_BRANS_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastanın başvurusu için MEDULA sistemine iletilen provi...</summary>
    [ForeignKey("ProvizyonTuruNavigation")]
    public string PROVIZYON_TURU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastanın başvurusu için MEDULA sistemine iletilen provi...</summary>
    public DateTime? PROVIZYON_TARIHI { get; set; }

    /// <summary>Kişiyi niteleyen eşsiz numaradır.</summary>
    [Required]
    public string TC_KIMLIK_NUMARASI { get; set; }

    /// <summary>Kişinin cinsiyetini ifade eder.</summary>
    [Required]
    public string CINSIYET { get; set; }

    /// <summary>Sağlık tesisinde tedavi gören hastaya yapılan işlem için MEDULA sisteminin ödeme...</summary>
    [Required]
    public string MEDULA_TUTARI { get; set; }

    /// <summary>Sağlık tesisi tarafından hasta için kesilen faturanın MEDULA’ya gönderildikten s...</summary>
    [Required]
    public string FATURA_TESLIM_NUMARASI { get; set; }

    /// <summary>Sağlık tesisi tarafından hasta için kesilen faturanın web servis aracılığı ile M...</summary>
    public DateTime FATURA_TESLIM_TARIHI { get; set; }

    /// <summary>Hastaya uygulanan tedavinin ayaktan, günübirlik, yatan vb. olduğunu belirten Sağ...</summary>
    [ForeignKey("TedaviTuruNavigation")]
    public string TEDAVI_TURU { get; set; }

    /// <summary>Sağlık tesisine gelen hastanın emekli, çalışan vb. durumlarını belirten bilgiyi ...</summary>
    [Required]
    public string SIGORTALI_TURU { get; set; }

    /// <summary>Sağlık tesisinde muayene olan kişi için MEDULA tarafından Sağlık Bilgi Yönetim S...</summary>
    [Required]
    public string DEVREDILEN_KURUM { get; set; }

    /// <summary>Sağlık tesisinde hasta için yapılan tüm işlemler için MEDULA'dan Sağlık Bilgi Yö...</summary>
    [Required]
    public string SONUC_KODU { get; set; }

    /// <summary>Sağlık tesisinde hasta için yapılan tüm işlemler için MEDULA'dan Sağlık Bilgi Yö...</summary>
    [Required]
    public string SONUC_MESAJI { get; set; }

    /// <summary>Sağlık tesisinde tedavi gören hasta için normal, eşlik eden hastalık, uzayan yat...</summary>
    [Required]
    [ForeignKey("TakipTipiNavigation")]
    public string TAKIP_TIPI { get; set; }

    /// <summary>Sağlık tesisine başvuran kişi için MEDULA sisteminden Sağlık Bilgi Yönetim Siste...</summary>
    [Required]
    public string BASVURU_NUMARASI { get; set; }

    /// <summary>Hastaya uygulanan tedavinin normal, diş tedavisi, analık hali vb. olduğunu belir...</summary>
    [ForeignKey("TedaviTipiNavigation")]
    public string TEDAVI_TIPI { get; set; }

    /// <summary>Sağlık tesisindeki hastaya uygulanan tedaviye ilişkin bilgiyi ifade eder. Örneği...</summary>
    [Required]
    [ForeignKey("TedaviSekliNavigation")]
    public string TEDAVI_SEKLI { get; set; }

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
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual REFERANS_KODLAR? ProvizyonTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? TedaviTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? TakipTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? TedaviTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? TedaviSekliNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}