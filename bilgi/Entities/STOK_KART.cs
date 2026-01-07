using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// STOK_KART tablosu - 28 kolon
/// </summary>
[Table("STOK_KART")]
public class STOK_KART
{
    /// <summary>Sağlık tesisinde bulunan ilaç, malzeme ve ürünlerin bilgilerine erişim sağlamak ...</summary>
    [Key]
    public string STOK_KART_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde kullanılan malzemenin ad bilgisidir.</summary>
    public string MALZEME_ADI { get; set; }

    /// <summary>Malzeme Kaynak Yönetim Sistemi (MKYS) tarafından ilaç ve malzeme için üretilen k...</summary>
    [Required]
    public string MKYS_MALZEME_KODU { get; set; }

    /// <summary>Sağlık tesisinde bulunan taşınır malzemeler için Sağlık Bilgi Yönetim Sistemi ta...</summary>
    [Required]
    public string TASINIR_KODU { get; set; }

    /// <summary>Sağlık tesisi depolarında bulunan ilaç, malzeme, ürün vb. leri gruplandırmak içi...</summary>
    [ForeignKey("MalzemeTipiNavigation")]
    public string MALZEME_TIPI { get; set; }

    /// <summary>Çubuk kod ya da çizgi im, verilerin görsel özellikli makinelerin okuyabilmesi iç...</summary>
    [Required]
    public string BARKOD { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanan malzemeler için SUT'ta tanımlanmış kod bilgis...</summary>
    [Required]
    public string MALZEME_SUT_KODU { get; set; }

    /// <summary>Reçetenin, içerdiği ilaç cinsine göre belirlenen türünü ifade etmektedir. Örneği...</summary>
    [Required]
    [ForeignKey("ReceteTuruNavigation")]
    public string RECETE_TURU { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanan ilacın ölçülebilir en alt seviyede miligram, ...</summary>
    [Required]
    public string MEDULA_CARPANI { get; set; }

    /// <summary>Enfeksiyon Hastalıkları Uzmanı (EHU) tarafından onaylanan, ilacın hastaya uygula...</summary>
    [Required]
    public string EHU_ILAC_GUN_MIKTARI { get; set; }

    /// <summary>Enfeksiyon Hastalıkları Uzmanı (EHU) tarafından onaylanan, ilacın hastaya uygula...</summary>
    [Required]
    public string EHU_ILAC_MAKSIMUM_ADET { get; set; }

    /// <summary>Sağlık tesisinde istem yapılan bir ilaç için Enfeksiyon Hastalıkları Uzmanı (EHU...</summary>
    public string EHU_ONAY_DURUMU { get; set; }

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
    public virtual REFERANS_KODLAR? MalzemeTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? ReceteTuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}