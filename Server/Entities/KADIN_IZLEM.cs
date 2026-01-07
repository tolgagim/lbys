using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_KADIN_IZLEM tablosu - 20 kolon
/// </summary>
[Table("KADIN_IZLEM")]
public class KADIN_IZLEM
{
    /// <summary>Sağlık tesisinde muayene olan kadın hastaların 15-49 yaş arası izlem bilgileri i...</summary>
    [Key]
    public string KADIN_IZLEM_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı tablo adı bilgisidir.</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Kadının 22. gebelik haftası ve sonrasında veya 500 gram ve üzerinde konjenital a...</summary>
    [Required]
    [ForeignKey("KonjenitalAnomaliVarligiNavigation")]
    public string KONJENITAL_ANOMALI_VARLIGI { get; set; }

    /// <summary>Gebeliğin 22. haftası ve sonrasında veya 500 gram ve üzerinde doğmuş, doğduğunda...</summary>
    [Required]
    public string CANLI_DOGAN_BEBEK_SAYISI { get; set; }

    /// <summary>Gebeliğin 22. haftası ve sonrasında veya 500 gram ve üzerinde dünyaya gelmiş, hi...</summary>
    [Required]
    public string OLU_DOGAN_BEBEK_SAYISI { get; set; }

    /// <summary>Kişinin hemoglobin değeri bilgisidir.</summary>
    [Required]
    public string HEMOGLOBIN_DEGERI { get; set; }

    /// <summary>Doğum yapan kadının bir önceki doğumuna ilişkin doğum durumu bilgisidir. Örneğin...</summary>
    [ForeignKey("OncekiDogumDurumuNavigation")]
    public string ONCEKI_DOGUM_DURUMU { get; set; }

    /// <summary>İzlemin yapıldığı kurum bilgisidir.</summary>
    public string IZLEMIN_YAPILDIGI_YER { get; set; }

    /// <summary>Kadının gebeliği önlemek için kullandığı yöntemi ifade eder.</summary>
    [Required]
    [ForeignKey("KullanilanApYontemiNavigation")]
    public string KULLANILAN_AP_YONTEMI { get; set; }

    /// <summary>Bir önceki kullanılan Aile Planlaması (AP) yöntemlerini tanımlamaktadır.</summary>
    [Required]
    [ForeignKey("BirOnceKullanilanApYontemiNavigation")]
    public string BIR_ONCE_KULLANILAN_AP_YONTEMI { get; set; }

    /// <summary>Hekim tarafından verilen Aile Planlaması (AP) Yönteminin verilme durumuna ilişki...</summary>
    [Required]
    [ForeignKey("ApYontemiLojistigiNavigation")]
    public string AP_YONTEMI_LOJISTIGI { get; set; }

    /// <summary>Gebelik öncesi, gebelik süresi ve gebelik sonrası dönemlerde kadın sağlığı açısı...</summary>
    [Required]
    [ForeignKey("KadinSagligiIslemleriNavigation")]
    public string KADIN_SAGLIGI_ISLEMLERI { get; set; }

    /// <summary>Kadının, Aile Planlaması (AP) Yöntemi kullanmama gerekçesini ifade eder.</summary>
    [Required]
    public string AP_YONTEMI_KULLANMAMA_NEDENI { get; set; }

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
    public virtual REFERANS_KODLAR? KonjenitalAnomaliVarligiNavigation { get; set; }
    public virtual REFERANS_KODLAR? OncekiDogumDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? KullanilanApYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? BirOnceKullanilanApYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? ApYontemiLojistigiNavigation { get; set; }
    public virtual REFERANS_KODLAR? KadinSagligiIslemleriNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}