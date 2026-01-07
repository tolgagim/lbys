using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_BAKTERI_SONUC tablosu - 12 kolon
/// </summary>
[Table("BAKTERI_SONUC")]
public class BAKTERI_SONUC
{
    /// <summary>SBYS tarafından üretilen tekil kod bilgisidir.</summary>
    [Key]
    public string BAKTERI_SONUC_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde yapılan tetkiklerin sonuçları için Sağlık Bilgi Yönetim Sistemi...</summary>
    [ForeignKey("TetkikSonucNavigation")]
    public string TETKIK_SONUC_KODU { get; set; }

    /// <summary>Sağlık tesisinde laboratuvarda yapılan testler sonucunda numunede üreyebilecek b...</summary>
    [ForeignKey("BakteriNavigation")]
    public string BAKTERI_KODU { get; set; }

    /// <summary>Koloni sayısı bilgisidir.</summary>
    [Required]
    public string KOLONI_SAYISI { get; set; }

    /// <summary>Hastaya verilen tetkik sonuç raporunda tetkik veya parametrenin bulunduğu sıra b...</summary>
    [Required]
    public string RAPOR_SONUC_SIRASI { get; set; }

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
    public virtual TETKIK_SONUC? TetkikSonucNavigation { get; set; }
    public virtual REFERANS_KODLAR? BakteriNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}