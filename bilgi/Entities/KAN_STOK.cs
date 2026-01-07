using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// KAN_STOK tablosu - 30 kolon
/// </summary>
[Table("KAN_STOK")]
public class KAN_STOK
{
    /// <summary>Sağlık tesisindeki depolarda bulunan kan ürünü için Sağlık Bilgi Yönetim Sistemi...</summary>
    [Key]
    public string KAN_STOK_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisisin kan bankasında işlem gören kan ürününün, son durum bilgisini if...</summary>
    [ForeignKey("KanStokDurumuNavigation")]
    public string KAN_STOK_DURUMU { get; set; }

    /// <summary>Kan ürününün sağlık tesisinin deposuna giriş tarihi bilgisidir.</summary>
    public DateTime? KAN_STOK_GIRIS_TARIHI { get; set; }

    /// <summary>Sağlık tesisindeki birimlerde hasta bilgilerinin olduğu defter numarası bilgisid...</summary>
    public string DEFTER_NUMARASI { get; set; }

    /// <summary>Kişinin kan grubunu ifade eder</summary>
    [ForeignKey("KanGrubuNavigation")]
    public string KAN_GRUBU { get; set; }

    /// <summary>Kan ürünü için Sağlık Bilgi Yönetim Sistemi tarafından üretilen tekil kod bilgis...</summary>
    [ForeignKey("KanUrunNavigation")]
    public string KAN_URUN_KODU { get; set; }

    /// <summary>Kan bağışında bulunan kişi için Sağlık Bilgi Yönetim Sistemi tarafından üretilen...</summary>
    [Required]
    [ForeignKey("KanBagisciNavigation")]
    public string KAN_BAGISCI_KODU { get; set; }

    /// <summary>Kişinin yararlandığı sağlık güvencesinin kurumuna ait bilgiler için Sağlık Bilgi...</summary>
    [Required]
    [ForeignKey("KurumNavigation")]
    public string KURUM_KODU { get; set; }

    /// <summary>Sağlık tesisinde bulunan bölümler için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("BirimNavigation")]
    public string BIRIM_KODU { get; set; }

    /// <summary>Sağlık tesisinde stokta kaydı bulunan kan ürününe uygulanan işlemler sonucunda e...</summary>
    [Required]
    [ForeignKey("BagliKanStokNavigation")]
    public string BAGLI_KAN_STOK_KODU { get; set; }

    /// <summary>Sağlık tesisi tarafından hastaya takılan kan ürünleri için Kızılay tarafından ür...</summary>
    [Required]
    public string ISBT_UNITE_NUMARASI { get; set; }

    /// <summary>Sağlık tesisi tarafından hastaya takılan kan ürünleri için Kızılay tarafından ür...</summary>
    [Required]
    public string ISBT_BILESEN_NUMARASI { get; set; }

    /// <summary>Kan ürününün mililitre cinsinden hacim bilgisidir.</summary>
    [Required]
    public string KAN_HACIM { get; set; }

    /// <summary>Kan bağışı işleminin yapıldığı zaman bilgisidir.</summary>
    public DateTime KAN_BAGIS_ZAMANI { get; set; }

    /// <summary>Kan ürününe filtreleme işleminin yapıldığı zaman bilgisidir.</summary>
    public DateTime KAN_FILTRELEME_ZAMANI { get; set; }

    /// <summary>Kan ürününün ışınlanma işleminin uygulandığı zaman bilgisidir.</summary>
    public DateTime KAN_ISINLAMA_ZAMANI { get; set; }

    /// <summary>Kan ürününe yıkama işleminin uygulandığı zaman bilgisidir.</summary>
    public DateTime KAN_YIKAMA_ZAMANI { get; set; }

    /// <summary>Kan ürününe ayırma işleminin uygulandığı zaman bilgisidir.</summary>
    public DateTime KAN_AYIRMA_ZAMANI { get; set; }

    /// <summary>Kan ürününe bölme işleminin uygulandığı zaman bilgisidir.</summary>
    public DateTime KAN_BOLME_ZAMANI { get; set; }

    /// <summary>Kan ürününe Buffy Coat uzaklaştırma işlemi uygulandığı zaman bilgisidir.</summary>
    public DateTime BUFFYCOAT_UZAKLASTIRMA_ZAMANI { get; set; }

    /// <summary>Kan ürününe havuzlama işleminin uygulandığı zaman bilgisidir.</summary>
    public DateTime KAN_HAVUZLAMA_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde kullanılan ilaç, aşı, tıbbi alet vb. son kullanma tarihi bilgis...</summary>
    public DateTime SON_KULLANMA_TARIHI { get; set; }

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
    public virtual REFERANS_KODLAR? KanStokDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanGrubuNavigation { get; set; }
    public virtual KAN_URUN? KanUrunNavigation { get; set; }
    public virtual KAN_BAGISCI? KanBagisciNavigation { get; set; }
    public virtual KURUM? KurumNavigation { get; set; }
    public virtual BIRIM? BirimNavigation { get; set; }
    public virtual KAN_STOK? BagliKanStokNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}