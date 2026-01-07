using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_AMELIYAT tablosu - 29 kolon
/// </summary>
[Table("AMELIYAT")]
public class AMELIYAT
{
    /// <summary>Sağlık tesisinde yapılan ameliyatın bilgilerine erişim sağlamak için Sağlık Bilg...</summary>
    [Key]
    public string AMELIYAT_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık tesisinde yapılan ameliyatın adı bilgisidir.</summary>
    [Required]
    public string AMELIYAT_ADI { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanan cerrahi girişimin bilgisidir.</summary>
    [Required]
    [ForeignKey("AmeliyatTuruNavigation")]
    public string AMELIYAT_TURU { get; set; }

    /// <summary>Sağlık tesisinde yapılan ameliyatın başlama zamanı bilgisidir.</summary>
    public DateTime? AMELIYAT_BASLAMA_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde yapılan ameliyatın bitiş zamanı bilgisidir.</summary>
    public DateTime AMELIYAT_BITIS_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde ameliyathanede bulunan ameliyat masaları tanımları için Sağlık ...</summary>
    [Required]
    [ForeignKey("MasaCihazNavigation")]
    public string MASA_CIHAZ_KODU { get; set; }

    /// <summary>Sağlık tesisinde bulunan bölümler için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("BirimNavigation")]
    public string BIRIM_KODU { get; set; }

    /// <summary>Sağlık tesisindeki birimlerde hasta bilgilerinin olduğu defter numarası bilgisid...</summary>
    public string DEFTER_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde yapılan ameliyata ilişkin anlık durum bilgisidir.</summary>
    [Required]
    [ForeignKey("AmeliyatDurumuNavigation")]
    public string AMELIYAT_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanan anestezi işleminin tür bilgisidir.</summary>
    [Required]
    [ForeignKey("AnesteziTuruNavigation")]
    public string ANESTEZI_TURU { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanan anestezi işleminin tüm süreçlerine ilişkin an...</summary>
    [Required]
    public string ANESTEZI_NOTU { get; set; }

    /// <summary>Sağlık tesisinde hastaya anestezinin verilmeye başlama zamanı bilgisidir.</summary>
    public DateTime ANESTEZI_BASLAMA_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde hastaya verilen anestezinin kesildiği zamanı bilgisidir.</summary>
    public DateTime ANESTEZI_BITIS_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde yapılan ameliyatın acil, elektif vb. olma durumuna ilişkin bilg...</summary>
    [Required]
    [ForeignKey("AmeliyatTipiNavigation")]
    public string AMELIYAT_TIPI { get; set; }

    /// <summary>Skopi cihazının kullanım süresi bilgisini ifade eder.</summary>
    [Required]
    public string SKOPI_SURESI { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanacak cerrahi işlem öncesinde/sırasında/sonrasınd...</summary>
    [Required]
    [ForeignKey("ProfilaksiPeriyoduNavigation")]
    public string PROFILAKSI_PERIYODU { get; set; }

    /// <summary>Referans kodlar tablosunda kod türü olarak “PROFILAKSI_KODU” alanina karsilik ge...</summary>
    [Required]
    [ForeignKey("ProfilaksiNavigation")]
    public string PROFILAKSI_KODU { get; set; }

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
    public virtual REFERANS_KODLAR? AmeliyatTuruNavigation { get; set; }
    public virtual CIHAZ? MasaCihazNavigation { get; set; }
    public virtual BIRIM? BirimNavigation { get; set; }
    public virtual REFERANS_KODLAR? AmeliyatDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? AnesteziTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? AmeliyatTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? ProfilaksiPeriyoduNavigation { get; set; }
    public virtual REFERANS_KODLAR? ProfilaksiNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}