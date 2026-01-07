using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// DISPROTEZ tablosu - 29 kolon
/// </summary>
[Table("DISPROTEZ")]
public class DISPROTEZ
{
    /// <summary>Diş protez tedavisi yapılan hastalar için protez bilgilerini kayıt etmek için Sa...</summary>
    [Key]
    public string DISPROTEZ_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisinde başvuran hastaya yapılan diş protezinin başlama tarihini ifade ...</summary>
    public DateTime? DISPROTEZ_BASLAMA_TARIHI { get; set; }

    /// <summary>Sağlık tesisinde görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("TeknisyenNavigation")]
    public string TEKNISYEN_KODU { get; set; }

    /// <summary>Sağlık tesisinde görevli hekim için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }

    /// <summary>Sağlık tesisinde bulunan bölümler için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("BirimNavigation")]
    public string BIRIM_KODU { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanan diş protezinin türü için Sağlık Bilgi Yönetim...</summary>
    [ForeignKey("DisprotezIsTuruNavigation")]
    public string DISPROTEZ_IS_TURU_KODU { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanan diş protezi tedavisinin türü ile ilgili Sağlı...</summary>
    [Required]
    [ForeignKey("DisprotezIsTuruAltNavigation")]
    public string DISPROTEZ_IS_TURU_ALT_KODU { get; set; }

    /// <summary>Diş protezi tedavisinde kullanılan parça sayısı bilgisidir. Örneğin hareketli pr...</summary>
    [Required]
    public string PARCA_SAYISI { get; set; }

    /// <summary>Dişe takılan sabit protezlerdeki ayak sayısı bilgisidir.</summary>
    [Required]
    public string DISPROTEZ_AYAK_SAYISI { get; set; }

    /// <summary>Diş tedavisinde kullanılan sabit protezlerdeki gövde sayısı bilgisidir.</summary>
    [Required]
    public string DISPROTEZ_GOVDE_SAYISI { get; set; }

    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>Diş protezi işleminin sağlık tesisinde yapıldığı birim için Sağlık Bilgi Yönetim...</summary>
    [Required]
    [ForeignKey("DisprotezBirimNavigation")]
    public string DISPROTEZ_BIRIM_KODU { get; set; }

    /// <summary>Gerçekleştirilen iş tekrarlayan bir işlem (RPT) ise tekrarlanma sebebini ifade e...</summary>
    [Required]
    [ForeignKey("RptSebebiNavigation")]
    public string RPT_SEBEBI { get; set; }

    /// <summary>Tekrar edilen işin tekrar zamanını ifade eder.</summary>
    public DateTime RPT_ZAMANI { get; set; }

    /// <summary>RPT işlemini yapan personel için Sağlık Bilgi Yönetim Sistemi tarafından üretile...</summary>
    [Required]
    [ForeignKey("RptEdenPersonelNavigation")]
    public string RPT_EDEN_PERSONEL_KODU { get; set; }

    /// <summary>Barkodun basıldığı zaman bilgisidir.</summary>
    public DateTime BARKOD_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde diş tedavisi alan hasta için kalıbı çıkarılan tedavi bölgesini ...</summary>
    [Required]
    [ForeignKey("DisprotezKasikTuruNavigation")]
    public string DISPROTEZ_KASIK_TURU { get; set; }

    /// <summary>Diş protez tedavisinde kullanılan protez dişin vita skalasına göre değer bilgisi...</summary>
    [Required]
    [ForeignKey("DisprotezRengiNavigation")]
    public string DISPROTEZ_RENGI { get; set; }

    /// <summary>Protezi yapılan dişin boyut bilgisidir. Örneğin küçük, normal, büyük vb.</summary>
    [Required]
    [ForeignKey("DisBoyutBilgisiNavigation")]
    public string DIS_BOYUT_BILGISI { get; set; }

    /// <summary>Sağlık tesisinin hizmet aldığı dış laboratuvarda yapılan diş protezi işlemi için...</summary>
    [Required]
    public string DISPROTEZ_ACIKLAMA { get; set; }

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
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual PERSONEL? TeknisyenNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual BIRIM? BirimNavigation { get; set; }
    public virtual REFERANS_KODLAR? DisprotezIsTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? DisprotezIsTuruAltNavigation { get; set; }
    public virtual BIRIM? DisprotezBirimNavigation { get; set; }
    public virtual REFERANS_KODLAR? RptSebebiNavigation { get; set; }
    public virtual PERSONEL? RptEdenPersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? DisprotezKasikTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? DisprotezRengiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DisBoyutBilgisiNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}