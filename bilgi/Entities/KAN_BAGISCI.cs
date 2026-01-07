using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// KAN_BAGISCI tablosu - 33 kolon
/// </summary>
[Table("KAN_BAGISCI")]
public class KAN_BAGISCI
{
    /// <summary>Kan bağışında bulunan kişi için Sağlık Bilgi Yönetim Sistemi tarafından üretilen...</summary>
    [Key]
    public string KAN_BAGISCI_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Kanı bağışlayan kişinin sağlık tesisine başvurusu için Sağlık Bilgi Yönetim Sist...</summary>
    [ForeignKey("BagisciHastaBasvuruNavigation")]
    public string BAGISCI_HASTA_BASVURU_KODU { get; set; }

    /// <summary>Kanı bağışlayan kişi için Sağlık Bilgi Yönetim Sistemi tarafından üretilen tekil...</summary>
    [ForeignKey("BagisciHastaNavigation")]
    public string BAGISCI_HASTA_KODU { get; set; }

    /// <summary>Kan bağışı işleminin yapıldığı zaman bilgisidir.</summary>
    public DateTime? KAN_BAGIS_ZAMANI { get; set; }

    /// <summary>Kişinin kan grubunu ifade eder</summary>
    [ForeignKey("KanGrubuNavigation")]
    public string KAN_GRUBU { get; set; }

    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>Sağlık tesisinde bağışı yapılan kan ürününün hangi hasta için rezerve edildiği b...</summary>
    [Required]
    [ForeignKey("RezervHastaNavigation")]
    public string REZERV_HASTA_KODU { get; set; }

    /// <summary>Bağışlanan kan türünü ifade eder. Örneğin tam kan, aferez trombosit, aferez gran...</summary>
    [ForeignKey("BagislananKanTuruNavigation")]
    public string BAGISLANAN_KAN_TURU { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanan tıbbi işlem sonucunda hastada reaksiyon oluşm...</summary>
    [Required]
    public string REAKSIYON_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanan tıbbi işlem sonucunda hastada gelişen reaksiy...</summary>
    [Required]
    [ForeignKey("ReaksiyonTuruNavigation")]
    public string REAKSIYON_TURU { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanan tıbbi işlem sonucunda hastada oluşan reaksiyo...</summary>
    [Required]
    public string REAKSIYON_ACIKLAMA { get; set; }

    /// <summary>Sağlık tesisinde kan bağışı yapılan hasta için Kızılay’dan alınan izin numarası ...</summary>
    [Required]
    public string KIZILAY_IZIN_NUMARASI { get; set; }

    /// <summary>Sistolik kan basıncı (büyük tansiyon) bilgisini ifade eder.</summary>
    [Required]
    public string SISTOLIK_KAN_BASINCI_DEGERI { get; set; }

    /// <summary>Kan basıncı ölçme protokolüne uygun olarak "mm Hg" birimi ile ölçülen diastolik ...</summary>
    [Required]
    public string DIASTOLIK_KAN_BASINCI_DEGERI { get; set; }

    /// <summary>Kişinin santigrat cinsinden vücut ısısı bilgisidir.</summary>
    [Required]
    public string ATES { get; set; }

    /// <summary>Kişinin santimetre cinsinden boy bilgisidir.</summary>
    [Required]
    public string BOY { get; set; }

    /// <summary>Kişinin (gram cinsinden) ağırlığıdır.</summary>
    [Required]
    public string AGIRLIK { get; set; }

    /// <summary>Kan bağışında bulunan kişinin muayenesi için uzman düşüncelerini ifade eder.</summary>
    [Required]
    public string UZMAN_DEGERLENDIRME { get; set; }

    /// <summary>Sağlık tesisi depolarında hareket gören malzemelerin üretimi ile bilgileri içere...</summary>
    [Required]
    public string LOT_NUMARASI { get; set; }

    /// <summary>Kan ürününün mililitre cinsinden hacim bilgisidir.</summary>
    [Required]
    public string KAN_HACIM { get; set; }

    /// <summary>Kan ürünü torbası üzerine Kızılay tarafından yazılan numara bilgisidir.</summary>
    [Required]
    public string SEGMENT_NUMARASI { get; set; }

    /// <summary>Kan bağışında bulunan kişinin kan bağışında bulunma nedenine ilişkin bilgiyi ifa...</summary>
    [ForeignKey("BagisciTuruNavigation")]
    public string BAGISCI_TURU { get; set; }

    /// <summary>Bağış yapılan kan ürününün değerlendirme sonuç bilgisidir. Örneğin onaylı, geçic...</summary>
    [Required]
    [ForeignKey("KanBagisDegerlendirmeSonucuNavigation")]
    public string KAN_BAGIS_DEGERLENDIRME_SONUCU { get; set; }

    /// <summary>Sağlık tesisinde kan ürününü değerlendiren personel için Sağlık Bilgi Yönetim Si...</summary>
    [Required]
    [ForeignKey("DegerlendirenPersonelNavigation")]
    public string DEGERLENDIREN_PERSONEL_KODU { get; set; }

    /// <summary>Sağlık tesisine yapılan kan bağışı sonucunun değerlendirildiği zaman bilgisidir.</summary>
    public DateTime KAN_BAGIS_DEGERLENDIRME_ZAMANI { get; set; }

    /// <summary>Kan bağışçısı ret nedenlerini ifade eder.</summary>
    [Required]
    [ForeignKey("KanBagiscisiRetNedenleriNavigation")]
    public string KAN_BAGISCISI_RET_NEDENLERI { get; set; }

    /// <summary>Ret süresinin gün cinsinden bilgisidir.</summary>
    [Required]
    public string RET_SURESI { get; set; }

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
    public virtual HASTA_BASVURU? BagisciHastaBasvuruNavigation { get; set; }
    public virtual HASTA? BagisciHastaNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanGrubuNavigation { get; set; }
    public virtual HASTA? RezervHastaNavigation { get; set; }
    public virtual REFERANS_KODLAR? BagislananKanTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? ReaksiyonTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? BagisciTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanBagisDegerlendirmeSonucuNavigation { get; set; }
    public virtual PERSONEL? DegerlendirenPersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanBagiscisiRetNedenleriNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}