using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// BEBEK_COCUK_IZLEM tablosu - 37 kolon
/// </summary>
[Table("BEBEK_COCUK_IZLEM")]
public class BEBEK_COCUK_IZLEM
{
    /// <summary>Sağlık tesisinde muayene olan bebek ve/veya çocukların izlem bilgileri için Sağl...</summary>
    [Key]
    public string BEBEK_COCUK_IZLEM_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı tablo adı bilgisidir.</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Bebek ve çocuklar için Sağlık Bakanlığı tarafından tanımlanan izlem protokolü ka...</summary>
    [ForeignKey("KacinciIzlemNavigation")]
    public string KACINCI_IZLEM { get; set; }

    /// <summary>İshal tanısı alan 0-59 ay bebek ve çocuklarda Ağızdan Sıvı Tedavisi (AST) bilgis...</summary>
    [Required]
    [ForeignKey("AgizdanSiviTedavisiNavigation")]
    public string AGIZDAN_SIVI_TEDAVISI { get; set; }

    /// <summary>Bebek veya çocuğun baş çevresinin (santimetre cinsinden) ölçüsüdür.</summary>
    [Required]
    public string BAS_CEVRESI { get; set; }

    /// <summary>Gebelikte dışarıdan demir desteği; demirin uygulanmayacağı durumlar hariç, ayrım...</summary>
    [Required]
    [ForeignKey("DemirLojistigiVeDestegiNavigation")]
    public string DEMIR_LOJISTIGI_VE_DESTEGI { get; set; }

    /// <summary>Bebeğin doğum ağırlığını gram olarak ifade eder.</summary>
    [Required]
    public string DOGUM_AGIRLIGI { get; set; }

    /// <summary>Gebeler için; gebeliğin 12. haftasından başlanarak doğumdan sonra 6. ayın sonuna...</summary>
    [Required]
    [ForeignKey("DvitaminiLojistigiVeDestegiNavigation")]
    public string DVITAMINI_LOJISTIGI_VE_DESTEGI { get; set; }

    /// <summary>Gelişimsel Kalça Displazisi (GKD) tarama sonucu bilgisidir.</summary>
    [ForeignKey("GkdTaramaSonucuNavigation")]
    public string GKD_TARAMA_SONUCU { get; set; }

    /// <summary>Bebek veya çocuğun hematokrit değeri bilgisidir.</summary>
    [Required]
    public string HEMATOKRIT_DEGERI { get; set; }

    /// <summary>Kişinin hemoglobin değeri bilgisidir.</summary>
    [Required]
    public string HEMOGLOBIN_DEGERI { get; set; }

    /// <summary>Doğumdan sonraki günlerde bebeğin topuğundan alınan kanın alınma durumunu ifade ...</summary>
    [Required]
    [ForeignKey("TopukKaniNavigation")]
    public string TOPUK_KANI { get; set; }

    /// <summary>Yeni doğan bebeğin topuk kanının alındığı zaman bilgisidir.</summary>
    public DateTime TOPUK_KANI_ALINMA_ZAMANI { get; set; }

    /// <summary>İzlemin yapıldığı kurum bilgisidir.</summary>
    [Required]
    [ForeignKey("IzleminYapildigiYerNavigation")]
    public string IZLEMIN_YAPILDIGI_YER { get; set; }

    /// <summary>Sağlık tesisinde hastaya yapılan izlemleri (bebek çocuk izlem, gebe izlem vb.) y...</summary>
    [Required]
    [ForeignKey("IzlemiYapanPersonelNavigation")]
    public string IZLEMI_YAPAN_PERSONEL_KODU { get; set; }

    /// <summary>Bilgi alınan kişinin ad ve soyadı bilgisidir.</summary>
    [Required]
    public string BILGI_ALINAN_KISI_AD_SOYADI { get; set; }

    /// <summary>Bilgi alınan kişinin telefon bilgisidir.</summary>
    [Required]
    public string BILGI_ALINAN_KISI_TELEFON { get; set; }

    /// <summary>Bebekte yapılan muayene ve risk faktörlerinin belirlenmesi sonucu gelişimsel kal...</summary>
    [Required]
    [ForeignKey("BebekteRiskFaktorleriNavigation")]
    public string BEBEKTE_RISK_FAKTORLERI { get; set; }

    /// <summary>Bebekte yapılan ve bebek sağlığı işlemleri veri elemanında yer alan tarama testl...</summary>
    [Required]
    [ForeignKey("TaramaSonucuNavigation")]
    public string TARAMA_SONUCU { get; set; }

    /// <summary>Bebeğin anne sütünden tamamen kesildiği (ay cinsinden) yaşını ifade eder.</summary>
    [Required]
    public string ANNE_SUTUNDEN_KESILDIGI_AY { get; set; }

    /// <summary>Bebeğin anne sütü ile beslenmesi durumuna ilişkin bilgidir. Örneğin sadece anne ...</summary>
    [Required]
    [ForeignKey("BebeginBeslenmeDurumuNavigation")]
    public string BEBEGIN_BESLENME_DURUMU { get; set; }

    /// <summary>Bebeğin anne sütü dışında gıda almaya başladığı (ay cinsinden) yaşını ifade eder...</summary>
    [Required]
    public string EK_GIDAYA_BASLADIGI_AY { get; set; }

    /// <summary>Bebeğin veya çocuğun anne sütü aldığı sürenin ay cinsinden bilgisini ifade eder.</summary>
    [Required]
    public string SADECE_ANNE_SUTU_ALDIGI_SURE { get; set; }

    /// <summary>Bebeğin/çocuğun gelişim bilgilerinin sorgulanmasıdır.</summary>
    [Required]
    [ForeignKey("GelisimTablosuBilgileriNavigation")]
    public string GELISIM_TABLOSU_BILGILERI { get; set; }

    [Required]
    [ForeignKey("NtpTakipBilgisiNavigation")]
    public string NTP_TAKIP_BILGISI { get; set; }

    /// <summary>0-6 yaş döneminde, bebeğin/çocuğun beyin gelişimini olumsuz yönde etkileyebilece...</summary>
    [Required]
    [ForeignKey("BcBeyinGelisimRiskleriNavigation")]
    public string BC_BEYIN_GELISIM_RISKLERI { get; set; }

    /// <summary>Anne/babanın, bebeğin veya çocuğun psikolojik gelişimini destekleyebilmek amacı ...</summary>
    [Required]
    [ForeignKey("EbeveynDestekAktiviteleriNavigation")]
    public string EBEVEYN_DESTEK_AKTIVITELERI { get; set; }

    /// <summary>Anne karnındaki dönem dahil olmak üzere, çocuğun 0-6 yaş döneminde beyin gelişim...</summary>
    [Required]
    [ForeignKey("BcPsikolojikRiskEgitimNavigation")]
    public string BC_PSIKOLOJIK_RISK_EGITIM { get; set; }

    /// <summary>0-6 yaş döneminde, Bebeğin/Çocuğun beyin gelişimini olumsuz yönde etkileyebilece...</summary>
    [Required]
    [ForeignKey("BcRiskYapilanMudahaleNavigation")]
    public string BC_RISK_YAPILAN_MUDAHALE { get; set; }

    /// <summary>Çocuğun psikolojik gelişiminin risk altında olduğu durumda, sık izleme alınan ol...</summary>
    [Required]
    [ForeignKey("BcRiskliOlguTakibiNavigation")]
    public string BC_RISKLI_OLGU_TAKIBI { get; set; }

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
    public virtual REFERANS_KODLAR? KacinciIzlemNavigation { get; set; }
    public virtual REFERANS_KODLAR? AgizdanSiviTedavisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DemirLojistigiVeDestegiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DvitaminiLojistigiVeDestegiNavigation { get; set; }
    public virtual REFERANS_KODLAR? GkdTaramaSonucuNavigation { get; set; }
    public virtual REFERANS_KODLAR? TopukKaniNavigation { get; set; }
    public virtual REFERANS_KODLAR? IzleminYapildigiYerNavigation { get; set; }
    public virtual PERSONEL? IzlemiYapanPersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? BebekteRiskFaktorleriNavigation { get; set; }
    public virtual REFERANS_KODLAR? TaramaSonucuNavigation { get; set; }
    public virtual REFERANS_KODLAR? BebeginBeslenmeDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? GelisimTablosuBilgileriNavigation { get; set; }
    public virtual REFERANS_KODLAR? NtpTakipBilgisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? BcBeyinGelisimRiskleriNavigation { get; set; }
    public virtual REFERANS_KODLAR? EbeveynDestekAktiviteleriNavigation { get; set; }
    public virtual REFERANS_KODLAR? BcPsikolojikRiskEgitimNavigation { get; set; }
    public virtual REFERANS_KODLAR? BcRiskYapilanMudahaleNavigation { get; set; }
    public virtual REFERANS_KODLAR? BcRiskliOlguTakibiNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}