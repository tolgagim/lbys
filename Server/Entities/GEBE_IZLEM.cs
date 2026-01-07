using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_GEBE_IZLEM tablosu - 27 kolon
/// </summary>
[Table("GEBE_IZLEM")]
public class GEBE_IZLEM
{
    /// <summary>Sağlık tesisinde muayene olan kadın hastaların gebelik izlem bilgileri için Sağl...</summary>
    [Key]
    public string GEBE_IZLEM_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı tablo adı bilgisidir.</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Gebede kaçıncı izlemin yapıldığını ifade eder</summary>
    [ForeignKey("KacinciGebeIzlemNavigation")]
    public string KACINCI_GEBE_IZLEM { get; set; }

    /// <summary>Kadının gebe kalmadan önceki son âdet döneminin ilk günüdür.</summary>
    public DateTime? SON_ADET_TARIHI { get; set; }

    /// <summary>Kadının bir önceki doğum durumu bilgisidir.</summary>
    [Required]
    [ForeignKey("OncekiDogumDurumuNavigation")]
    public string ONCEKI_DOGUM_DURUMU { get; set; }

    /// <summary>Gebe için kaydı tutulan izlemin sağlık tesisinde yapılma bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("GebeIzlemIslemTuruNavigation")]
    public string GEBE_IZLEM_ISLEM_TURU { get; set; }

    /// <summary>Gestasyonel Diyabetes için; OGTT gebeliğin 2. trimestirinde 75 gram glukoz veril...</summary>
    [Required]
    [ForeignKey("GestasyonelDiyabetTaramasiNavigation")]
    public string GESTASYONEL_DIYABET_TARAMASI { get; set; }

    /// <summary>Gebenin izlem esnasında idrarında kalitatif olarak protein varlığının değerlendi...</summary>
    [Required]
    [ForeignKey("IdrardaProteinNavigation")]
    public string IDRARDA_PROTEIN { get; set; }

    /// <summary>Kişinin hemoglobin değeri bilgisidir.</summary>
    [Required]
    public string HEMOGLOBIN_DEGERI { get; set; }

    /// <summary>Gebelikte dışarıdan demir desteği; demirin uygulanmayacağı durumlar hariç, ayrım...</summary>
    [Required]
    [ForeignKey("DemirLojistigiVeDestegiNavigation")]
    public string DEMIR_LOJISTIGI_VE_DESTEGI { get; set; }

    /// <summary>Gebeler için; gebeliğin 12. haftasından başlanarak doğumdan sonra 6. ayın sonuna...</summary>
    [Required]
    [ForeignKey("DvitaminiLojistigiVeDestegiNavigation")]
    public string DVITAMINI_LOJISTIGI_VE_DESTEGI { get; set; }

    /// <summary>Kadının 22. gebelik haftası ve sonrasında veya 500 gram ve üzerinde konjenital a...</summary>
    [Required]
    [ForeignKey("KonjenitalAnomaliVarligiNavigation")]
    public string KONJENITAL_ANOMALI_VARLIGI { get; set; }

    /// <summary>Gebe izlem muayenesinde tespit edilen fetusa ait kalp sesinin varlığı ve sayısın...</summary>
    [Required]
    public string FETUS_KALP_SESI { get; set; }

    /// <summary>Kan basıncı ölçme protokolüne uygun olarak "mm Hg" birimi ile ölçülen diastolik ...</summary>
    [Required]
    public string DIASTOLIK_KAN_BASINCI_DEGERI { get; set; }

    /// <summary>Sistolik kan basıncı (büyük tansiyon) bilgisini ifade eder.</summary>
    [Required]
    public string SISTOLIK_KAN_BASINCI_DEGERI { get; set; }

    /// <summary>Gebenin önceki ve mevcut gebelikleri ile genel tıbbi durumu değerlendirilerek be...</summary>
    [Required]
    [ForeignKey("GebelikteRiskFaktorleriNavigation")]
    public string GEBELIKTE_RISK_FAKTORLERI { get; set; }

    /// <summary>0-6 yaş döneminde, bebeğin/çocuğun beyin gelişimini olumsuz yönde etkileyebilece...</summary>
    [Required]
    [ForeignKey("BcBeyinGelisimRiskleriNavigation")]
    public string BC_BEYIN_GELISIM_RISKLERI { get; set; }

    /// <summary>Anne karnındaki dönem dahil olmak üzere, çocuğun 0-6 yaş döneminde beyin gelişim...</summary>
    [Required]
    [ForeignKey("PsikolojikGelisimRiskEgitimNavigation")]
    public string PSIKOLOJIK_GELISIM_RISK_EGITIM { get; set; }

    /// <summary>0-6 yaş döneminde, Bebeğin/Çocuğun beyin gelişimini olumsuz yönde etkileyebilece...</summary>
    [Required]
    [ForeignKey("RiskFaktorlerineMudahaleNavigation")]
    public string RISK_FAKTORLERINE_MUDAHALE { get; set; }

    /// <summary>Çocuğun psikolojik gelişiminin risk altında olduğu durumda, sık izleme alınan ol...</summary>
    [Required]
    [ForeignKey("RiskAltindakiOlguTakibiNavigation")]
    public string RISK_ALTINDAKI_OLGU_TAKIBI { get; set; }

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
    public virtual REFERANS_KODLAR? KacinciGebeIzlemNavigation { get; set; }
    public virtual REFERANS_KODLAR? OncekiDogumDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? GebeIzlemIslemTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? GestasyonelDiyabetTaramasiNavigation { get; set; }
    public virtual REFERANS_KODLAR? IdrardaProteinNavigation { get; set; }
    public virtual REFERANS_KODLAR? DemirLojistigiVeDestegiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DvitaminiLojistigiVeDestegiNavigation { get; set; }
    public virtual REFERANS_KODLAR? KonjenitalAnomaliVarligiNavigation { get; set; }
    public virtual REFERANS_KODLAR? GebelikteRiskFaktorleriNavigation { get; set; }
    public virtual REFERANS_KODLAR? BcBeyinGelisimRiskleriNavigation { get; set; }
    public virtual REFERANS_KODLAR? PsikolojikGelisimRiskEgitimNavigation { get; set; }
    public virtual REFERANS_KODLAR? RiskFaktorlerineMudahaleNavigation { get; set; }
    public virtual REFERANS_KODLAR? RiskAltindakiOlguTakibiNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}