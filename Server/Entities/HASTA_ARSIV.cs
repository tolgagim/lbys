using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_HASTA_ARSIV tablosu - 14 kolon
/// </summary>
[Table("HASTA_ARSIV")]
public class HASTA_ARSIV
{
    /// <summary>Arşivde bulunan hasta dosyası bilgileri için Sağlık Bilgi Yönetim Sistemi tarafı...</summary>
    [Key]
    public string HASTA_ARSIV_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Hasta dosyasının arşiv numarası bilgisidir.</summary>
    public string ARSIV_NUMARASI { get; set; }

    /// <summary>Hastanın herhangi bir sağlık tesisinde bulunan sağlık bilgilerinin yer aldığı do...</summary>
    [Required]
    public string ESKI_ARSIV_NUMARASI { get; set; }

    /// <summary>Sağlık tesisindeki birimlerde oluşturulan, hasta bilgilerinin olduğu dosyaların ...</summary>
    [ForeignKey("ArsivDefterTuruNavigation")]
    public string ARSIV_DEFTER_TURU { get; set; }

    /// <summary>Hasta dosyanın arşivdeki fiziksel yerinin bilgisidir. Örneğin bina/oda/raf bloğu...</summary>
    [Required]
    public string ARSIV_YERI { get; set; }

    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>Hasta dosyasının sağlık tesisi arşivine ilk kayıt edilen tarih bilgisidir.</summary>
    public DateTime ARSIV_ILK_GIRIS_TARIHI { get; set; }

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
    public virtual REFERANS_KODLAR? ArsivDefterTuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}