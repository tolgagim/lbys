using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// KURUL_TESHIS tablosu - 11 kolon
/// </summary>
[Table("KURUL_TESHIS")]
public class KURUL_TESHIS
{
    /// <summary>Hasta için verilen sağlık raporunda kurul tarafından onaylanan teşhis bilgileri ...</summary>
    [Key]
    public string KURUL_TESHIS_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Hastaya sağlık raporu veren kurul için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("KurulRaporNavigation")]
    public string KURUL_RAPOR_KODU { get; set; }

    /// <summary>Sağlık tesisinde tedavi alan hastaya düzenlenen rapordaki ilaçlar için MEDULA ta...</summary>
    [Required]
    public string ILAC_TESHIS_KODU { get; set; }

    /// <summary>Sağlık tesisinde hastaya konulan tanı için ICD-10 kodlarından seçilen tanı kodu ...</summary>
    [Required]
    [ForeignKey("TaniNavigation")]
    public string TANI_KODU { get; set; }

    /// <summary>Sağlık tesisinde kişiye verilen raporun başlama tarihi bilgisidir.</summary>
    public DateTime RAPOR_BASLAMA_TARIHI { get; set; }

    /// <summary>Sağlık tesisinde hekim tarafından kişiye konulan tanıya ait yazılan raporun biti...</summary>
    public DateTime RAPOR_BITIS_TARIHI { get; set; }

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
    public virtual KURUL_RAPOR? KurulRaporNavigation { get; set; }
    public virtual REFERANS_KODLAR? TaniNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}