using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_DISPROTEZ_DETAY tablosu - 21 kolon
/// </summary>
[Table("DISPROTEZ_DETAY")]
public class DISPROTEZ_DETAY
{
    /// <summary>Diş protez tedavisi yapılan hastalar için protez aşamalarına ilişkin detaylı bil...</summary>
    [Key]
    public string DISPROTEZ_DETAY_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Diş protez tedavisi yapılan hastalar için protez bilgilerini kayıt etmek için Sa...</summary>
    [ForeignKey("DisprotezNavigation")]
    public string DISPROTEZ_KODU { get; set; }

    /// <summary>Diş protezi tedavisinin ne zaman uygulanacağına ilişkin planlanan zaman bilgisid...</summary>
    public DateTime? DISPROTEZ_PLANLAMA_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanan diş protezinin aşamalarını belirten Sağlık Bi...</summary>
    [ForeignKey("DisprotezIsTuruAsamaNavigation")]
    public string DISPROTEZ_IS_TURU_ASAMA_KODU { get; set; }

    /// <summary>Hastaya uygulanan protez işleminin ilgili aşamasının tamamlanma zamanı bilgisidi...</summary>
    public DateTime DISPROTEZ_ASAMA_BITIS_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinin mal veya hizmet alımı yaptığı firma için Sağlık Bilgi Yönetim S...</summary>
    [Required]
    [ForeignKey("FirmaNavigation")]
    public string FIRMA_KODU { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanan diş protez tedavisi sürecinde, sağlık tesisi ...</summary>
    public DateTime FIRMA_DISPROTEZ_ALIM_ZAMANI { get; set; }

    /// <summary>Hasta tedavi sürecinde yapılması planlanan tedavi uygulamasının bitirilmesi için...</summary>
    public DateTime PLANLANAN_BITIS_TARIHI { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanan diş protez tedavisi sürecinde, sağlık tesisi ...</summary>
    public DateTime FIRMA_TESLIM_ZAMANI { get; set; }

    /// <summary>Diş protezi aşamaları için sürecin tamamlandığına ilişkin verilen onay zamanı bi...</summary>
    public DateTime DISPROTEZ_ASAMA_ONAY_ZAMANI { get; set; }

    /// <summary>Rise Per Tooth (RPT); Teslim aşamasına gelmiş protezin kabul kriterlerine uymama...</summary>
    [Required]
    public string RPT_ONAY_DURUMU { get; set; }

    /// <summary>Kişi için düzenlenen randevu bilgisi için Sağlık Bilgi Yönetim Sistemi tarafında...</summary>
    [Required]
    [ForeignKey("RandevuNavigation")]
    public string RANDEVU_KODU { get; set; }

    /// <summary>Protez dişin herhangi bir aşamasında kabul kriterlerine uymaması sonucu, protez ...</summary>
    public DateTime ASAMA_RPT_ZAMANI { get; set; }

    /// <summary>Protez dişin herhangi bir aşamasında kabul kriterlerine uymaması bilgisidir. Örn...</summary>
    [Required]
    [ForeignKey("AsamaRptSebebiNavigation")]
    public string ASAMA_RPT_SEBEBI { get; set; }

    /// <summary>Protez dişin herhangi bir aşamasında kabul kriterlerine uymaması sonucu, protez ...</summary>
    [Required]
    [ForeignKey("AsamaRptKullaniciNavigation")]
    public string ASAMA_RPT_KULLANICI_KODU { get; set; }

    /// <summary>Diş protezi tedavisinde hastadan ölçü alınma aşamasında, ölçü döküm zamanı bilgi...</summary>
    public DateTime OLCU_DOKUM_ZAMANI { get; set; }

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
    public virtual DISPROTEZ? DisprotezNavigation { get; set; }
    public virtual REFERANS_KODLAR? DisprotezIsTuruAsamaNavigation { get; set; }
    public virtual FIRMA? FirmaNavigation { get; set; }
    public virtual RANDEVU? RandevuNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsamaRptSebebiNavigation { get; set; }
    public virtual KULLANICI? AsamaRptKullaniciNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}