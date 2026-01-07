using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_STERILIZASYON_YIKAMA tablosu - 13 kolon
/// </summary>
[Table("STERILIZASYON_YIKAMA")]
public class STERILIZASYON_YIKAMA
{
    /// <summary>Sağlık tesisinin sterilizasyon ünitesinde yıkama işlemi yapılan tıbbi aletler iç...</summary>
    [Key]
    public string STERILIZASYON_YIKAMA_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde bulunan stok depoları için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [ForeignKey("DepoNavigation")]
    public string DEPO_KODU { get; set; }

    /// <summary>Sağlık tesisinde bulunan ilaç, malzeme ve ürünlerin bilgilerine erişim sağlamak ...</summary>
    [ForeignKey("StokKartNavigation")]
    public string STOK_KART_KODU { get; set; }

    /// <summary>Sağlık tesisinde sterilizasyon öncesi yıkanan alet miktarı bilgisidir.</summary>
    public string YIKANAN_ALET_MIKTARI { get; set; }

    /// <summary>Sağlık tesisinde yıkama işleminden geçmiş ürün, malzeme vb. için yıkamanın makin...</summary>
    [ForeignKey("SterilizasyonYikamaTuruNavigation")]
    public string STERILIZASYON_YIKAMA_TURU { get; set; }

    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("YikamaYapanPersonelNavigation")]
    public string YIKAMA_YAPAN_PERSONEL_KODU { get; set; }

    /// <summary>Sağlık tesisinde steril edilecek malzemelerin yıkama işleminin başladığı zaman b...</summary>
    public DateTime? YIKAMA_BASLAMA_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde steril edilecek malzemelerin yıkama işleminin bittiği zaman bil...</summary>
    public DateTime YIKAMA_BITIS_ZAMANI { get; set; }

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
    public virtual DEPO? DepoNavigation { get; set; }
    public virtual STOK_KART? StokKartNavigation { get; set; }
    public virtual REFERANS_KODLAR? SterilizasyonYikamaTuruNavigation { get; set; }
    public virtual PERSONEL? YikamaYapanPersonelNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}