using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// STOK_ISTEK_HAREKET tablosu - 21 kolon
/// </summary>
[Table("STOK_ISTEK_HAREKET")]
public class STOK_ISTEK_HAREKET
{
    /// <summary>Sağlık tesisinde hasta için depodan yapılan isteklerin detay bilgilerine erişim ...</summary>
    [Key]
    public string STOK_ISTEK_HAREKET_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisindeki hekimin, hasta için istediği malzeme ve ilaçların sağlık tesi...</summary>
    [ForeignKey("StokIstekNavigation")]
    public string STOK_ISTEK_KODU { get; set; }

    /// <summary>Sağlık tesisi deposundan istemi yapılan ilaç, malzeme, ürün vb. için Sağlık Bilg...</summary>
    [Required]
    [ForeignKey("IstenenStokKartNavigation")]
    public string ISTENEN_STOK_KART_KODU { get; set; }

    /// <summary>Sağlık tesisinin deposunda bulunan ilacın jeneriği için Sağlık Bilgi Yönetim Sis...</summary>
    [Required]
    [ForeignKey("IstenenIlacJenerikNavigation")]
    public string ISTENEN_ILAC_JENERIK_KODU { get; set; }

    /// <summary>Sağlık tesisinde ilgili stok depo görevlisi tarafından teslim edilen ilaç, malze...</summary>
    [Required]
    [ForeignKey("VerilenStokKartNavigation")]
    public string VERILEN_STOK_KART_KODU { get; set; }

    /// <summary>Sağlık tesisinde tedavi gören hastaya ait ilaç, malzeme isteğinin hekim tarafınd...</summary>
    public string ISTEK_GEREKLILIK_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanacak tedavi için kullanılacak ilacın, hastanın y...</summary>
    public string TEDAVIDE_KULLANILAN_ILAC { get; set; }

    /// <summary>Sağlık tesisinden tedavi gören hasta için hekim tarafından istenen ilaç, malzeme...</summary>
    public string ISTENEN_MIKTAR { get; set; }

    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>İlaç, malzeme, ürün vb. isteklerinden sağlık tesisi deposundan karşılanan miktar...</summary>
    [Required]
    public string DEPODAN_VERILEN_MIKTAR { get; set; }

    /// <summary>Sağlık tesisinde ürün, ilaç veya malzemeye ilişkin yapılan isteğin ret edilmesin...</summary>
    [Required]
    [ForeignKey("StokIstekRetNedeniNavigation")]
    public string STOK_ISTEK_RET_NEDENI { get; set; }

    /// <summary>Stoktan yapılan isteğin reddedildiği zaman bilgisidir.</summary>
    public DateTime STOK_ISTEK_RET_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde ürün, ilaç veya malzemeye ilişkin yapılan isteğin reddedildiği ...</summary>
    [Required]
    [ForeignKey("StokIstekRetKullaniciNavigation")]
    public string STOK_ISTEK_RET_KULLANICI_KODU { get; set; }

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
    public virtual STOK_ISTEK? StokIstekNavigation { get; set; }
    public virtual STOK_KART? IstenenStokKartNavigation { get; set; }
    public virtual REFERANS_KODLAR? IstenenIlacJenerikNavigation { get; set; }
    public virtual STOK_KART? VerilenStokKartNavigation { get; set; }
    public virtual REFERANS_KODLAR? StokIstekRetNedeniNavigation { get; set; }
    public virtual KULLANICI? StokIstekRetKullaniciNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}