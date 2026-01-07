using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_LOHUSA_IZLEM tablosu - 23 kolon
/// </summary>
[Table("LOHUSA_IZLEM")]
public class LOHUSA_IZLEM
{
    /// <summary>Doğum yapmış kadınların izlem bilgileri için Sağlık Bilgi Yönetim Sistemi tarafı...</summary>
    [Key]
    public string LOHUSA_IZLEM_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Lohusada kaçıncı izlemin yapıldığını ifade eder.</summary>
    [ForeignKey("KacinciLohusaIzlemNavigation")]
    public string KACINCI_LOHUSA_IZLEM { get; set; }

    /// <summary>İzlemin yapıldığı kurum bilgisidir.</summary>
    [Required]
    [ForeignKey("IzleminYapildigiYerNavigation")]
    public string IZLEMIN_YAPILDIGI_YER { get; set; }

    /// <summary>Gebelikte dışarıdan demir desteği; demirin uygulanmayacağı durumlar hariç, ayrım...</summary>
    [Required]
    [ForeignKey("DemirLojistigiVeDestegiNavigation")]
    public string DEMIR_LOJISTIGI_VE_DESTEGI { get; set; }

    /// <summary>Gebeler için; gebeliğin 12. haftasından başlanarak doğumdan sonra 6. ayın sonuna...</summary>
    [Required]
    [ForeignKey("DvitaminiLojistigiVeDestegiNavigation")]
    public string DVITAMINI_LOJISTIGI_VE_DESTEGI { get; set; }

    /// <summary>Gebeliğin doğum veya başka sebepler ile sonlandığı tarih bilgisidir.</summary>
    public DateTime? GEBELIK_SONLANMA_TARIHI { get; set; }

    /// <summary>EDINBURGH Postpartum Depresyon Ölçeği, doğum sonrası dönemdeki kadınlara uygulan...</summary>
    [Required]
    [ForeignKey("PostpartumDepresyonNavigation")]
    public string POSTPARTUM_DEPRESYON { get; set; }

    /// <summary>Uterus involusyon takibinin yapılma durumuna ilişkin bilgidir. Örneğin uterus ın...</summary>
    [ForeignKey("UterusInvolusyonNavigation")]
    public string UTERUS_INVOLUSYON { get; set; }

    /// <summary>Bilgi alınan kişinin ad ve soyadı bilgisidir.</summary>
    [Required]
    public string BILGI_ALINAN_KISI_AD_SOYADI { get; set; }

    /// <summary>Bilgi alınan kişinin telefon numarası bilgisidir.</summary>
    [Required]
    public string BILGI_ALINAN_KISI_TELEFON { get; set; }

    /// <summary>Kadının 22. gebelik haftası ve sonrasında veya 500 gram ve üzerinde konjenital a...</summary>
    [Required]
    [ForeignKey("KonjenitalAnomaliVarligiNavigation")]
    public string KONJENITAL_ANOMALI_VARLIGI { get; set; }

    /// <summary>Kişinin hemoglobin değeri bilgisidir.</summary>
    [Required]
    public string HEMOGLOBIN_DEGERI { get; set; }

    /// <summary>Herhangi bir müdahale (ameliyat, doğum vb.) sonrası oluşan karmaşık ve olumsuz k...</summary>
    [Required]
    [ForeignKey("KomplikasyonTanisiNavigation")]
    public string KOMPLIKASYON_TANISI { get; set; }

    /// <summary>Gebelik/lohusalık seyrinde anne ve fetüs sağlığını olumsuz yönde etkileyen faktö...</summary>
    [Required]
    [ForeignKey("SeyirTehlikeIsaretiNavigation")]
    public string SEYIR_TEHLIKE_ISARETI { get; set; }

    /// <summary>Gebelik öncesi, gebelik süresi ve gebelik sonrası dönemlerde kadın sağlığı açısı...</summary>
    [Required]
    [ForeignKey("KadinSagligiIslemleriNavigation")]
    public string KADIN_SAGLIGI_ISLEMLERI { get; set; }

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
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? KacinciLohusaIzlemNavigation { get; set; }
    public virtual REFERANS_KODLAR? IzleminYapildigiYerNavigation { get; set; }
    public virtual REFERANS_KODLAR? DemirLojistigiVeDestegiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DvitaminiLojistigiVeDestegiNavigation { get; set; }
    public virtual REFERANS_KODLAR? PostpartumDepresyonNavigation { get; set; }
    public virtual REFERANS_KODLAR? UterusInvolusyonNavigation { get; set; }
    public virtual REFERANS_KODLAR? KonjenitalAnomaliVarligiNavigation { get; set; }
    public virtual REFERANS_KODLAR? KomplikasyonTanisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SeyirTehlikeIsaretiNavigation { get; set; }
    public virtual REFERANS_KODLAR? KadinSagligiIslemleriNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}