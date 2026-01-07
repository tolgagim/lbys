using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// HASTA_SEVK tablosu - 25 kolon
/// </summary>
[Table("HASTA_SEVK")]
public class HASTA_SEVK
{
    /// <summary>Sağlık tesisinden başka bir sağlık tesisine sevk edilen hastanın sevk bilgileri ...</summary>
    [Key]
    public string HASTA_SEVK_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>HASTA görüntüsündeki HASTA_KODU bilgisidir.</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sevk edilen hastanın MEDULA sisteminden Sağlık Bilgi Yönetim Sistemine iletilen ...</summary>
    [Required]
    public string SEVK_TAKIP_NUMARASI { get; set; }

    /// <summary>Sağlık tesisine sevk edilerek gelen hastanın sevk nedeni bilgisidir.</summary>
    [Required]
    [ForeignKey("SevkNedeniNavigation")]
    public string SEVK_NEDENI { get; set; }

    /// <summary>Sağlık tesisindeki hastanın sevk edildiği kliniğin MEDULA’daki branş kodu bilgis...</summary>
    [Required]
    public string SEVK_EDILEN_BRANS_KODU { get; set; }

    /// <summary>Sağlık tesisindeki hastanın sevk edildiği kurum bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("SevkEdilenKurumNavigation")]
    public string SEVK_EDILEN_KURUM_KODU { get; set; }

    /// <summary>Hastanın ilk başvurduğu sağlık tesisinin (sevk edildiği sağlık tesisi) hastayı b...</summary>
    public DateTime? SEVK_ZAMANI { get; set; }

    /// <summary>Hastanın sevk gerekçesi olan hastalık tanı (ları) dır.</summary>
    [Required]
    [ForeignKey("SevkTanisiNavigation")]
    public string SEVK_TANISI { get; set; }

    /// <summary>Sevk edilen hastaya eşlik eden kişi bilgisini ifade eder. Örneğin refakatli, pol...</summary>
    [Required]
    [ForeignKey("SevkSekliNavigation")]
    public string SEVK_SEKLI { get; set; }

    /// <summary>Hastanın sevk edildiği araç için Sağlık Bilgi Yönetim Sistemi tarafından üretile...</summary>
    [Required]
    [ForeignKey("SevkVasitasiNavigation")]
    public string SEVK_VASITASI_KODU { get; set; }

    /// <summary>Sağlık tesisinden sevk edilen hastanın, sevk edildiği yerde uygulanacak tedavi b...</summary>
    [Required]
    [ForeignKey("SevkTedaviTipiNavigation")]
    public string SEVK_TEDAVI_TIPI { get; set; }

    /// <summary>Sağlık tesisinde sevk edilen hasta için yapılan açıklama bilgisini ifade eder.</summary>
    [Required]
    public string SEVK_ACIKLAMA { get; set; }

    /// <summary>Sağlık tesisindeki hastanın sevk kararını veren hekime ait Sağlık Bilgi Yönetim ...</summary>
    [ForeignKey("SevkEden1PersonelNavigation")]
    public string SEVK_EDEN_1_PERSONEL_KODU { get; set; }

    /// <summary>Sağlık tesisindeki hastanın sevk kararını veren hekime ait Sağlık Bilgi Yönetim ...</summary>
    [Required]
    [ForeignKey("SevkEden2PersonelNavigation")]
    public string SEVK_EDEN_2_PERSONEL_KODU { get; set; }

    /// <summary>Sağlık tesisindeki hastanın sevk kararını veren hekime ait Sağlık Bilgi Yönetim ...</summary>
    [Required]
    [ForeignKey("SevkEden3PersonelNavigation")]
    public string SEVK_EDEN_3_PERSONEL_KODU { get; set; }

    /// <summary>Sağlık tesisinde yatan hastanın refakatçisinin olup olmadığına ilişkin bilgiyi i...</summary>
    [Required]
    public string REFAKATCI_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde tedavi gören hastanın başka bir sağlık tesisine sevk edilmesi d...</summary>
    [Required]
    public string MEDULA_E_SEVK_NUMARASI { get; set; }

    /// <summary>Ambulans ile sevk edilen hasta için oluşturulmuş protokol numarası bilgisidir.</summary>
    [Required]
    public string AMBULANS_PROTOKOL_NUMARASI { get; set; }

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
    public virtual REFERANS_KODLAR? SevkNedeniNavigation { get; set; }
    public virtual KURUM? SevkEdilenKurumNavigation { get; set; }
    public virtual REFERANS_KODLAR? SevkTanisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SevkSekliNavigation { get; set; }
    public virtual REFERANS_KODLAR? SevkVasitasiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SevkTedaviTipiNavigation { get; set; }
    public virtual PERSONEL? SevkEden1PersonelNavigation { get; set; }
    public virtual PERSONEL? SevkEden2PersonelNavigation { get; set; }
    public virtual PERSONEL? SevkEden3PersonelNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}