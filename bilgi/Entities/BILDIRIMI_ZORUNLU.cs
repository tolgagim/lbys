using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// BILDIRIMI_ZORUNLU tablosu - 53 kolon
/// </summary>
[Table("BILDIRIMI_ZORUNLU")]
public class BILDIRIMI_ZORUNLU
{
    /// <summary>Bildirimi zorunlu hastalık için Sağlık Bilgi Yönetim Sistemi tarafından üretilen...</summary>
    [Key]
    public string BILDIRIMI_ZORUNLU_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Bildirimi zorunlu hastalıklar veya durumlar kapsamında yapılan bildirimin türünü...</summary>
    [ForeignKey("BildirimTuruNavigation")]
    public string BILDIRIM_TURU { get; set; }

    /// <summary>Bildirimi zorunlu hastalığın veya durumların ilgili yerlere bildirildiği zaman b...</summary>
    public DateTime? BILDIRIM_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde hastaya konulan tanı için ICD-10 kodlarından seçilen tanı kodu ...</summary>
    [ForeignKey("TaniNavigation")]
    public string TANI_KODU { get; set; }

    /// <summary>İntihar girişiminde bulunan veya kriz geçiren kişinin aile üyelerinin herhangi b...</summary>
    [Required]
    [ForeignKey("AilesindeIntiharGirisimiNavigation")]
    public string AILESINDE_INTIHAR_GIRISIMI { get; set; }

    /// <summary>İntihar girişiminde bulunan veya kriz geçiren kişinin aile üyelerinin herhangi b...</summary>
    [Required]
    [ForeignKey("AilesindePsikiyatrikVakaNavigation")]
    public string AILESINDE_PSIKIYATRIK_VAKA { get; set; }

    /// <summary>Vakanın intihar vakası ya da kriz vakası olma durumunu ifade eder.</summary>
    [Required]
    [ForeignKey("IntiharKrizVakaTuruNavigation")]
    public string INTIHAR_KRIZ_VAKA_TURU { get; set; }

    /// <summary>Olayın gerçekleştiği zaman bilgisidir.</summary>
    public DateTime OLAY_ZAMANI { get; set; }

    /// <summary>Hastanın acil servise başvuru tarihinden önceki son 6 aylık dönemde psikiyatrik ...</summary>
    [Required]
    [ForeignKey("PsikiyatrikTedaviGecmisiNavigation")]
    public string PSIKIYATRIK_TEDAVI_GECMISI { get; set; }

    /// <summary>Kişinin intihar girişimi ya da kriz nedenlerini ifade eder.</summary>
    [Required]
    [ForeignKey("IntiharGirisimKrizNedenleriNavigation")]
    public string INTIHAR_GIRISIM_KRIZ_NEDENLERI { get; set; }

    /// <summary>Kişinin intihar girişimini gerçekleştirirken kullandığı yöntem/yöntemleri ifade ...</summary>
    [Required]
    [ForeignKey("IntiharGirisimiYontemiNavigation")]
    public string INTIHAR_GIRISIMI_YONTEMI { get; set; }

    /// <summary>Kişinin geçmişinde intihar girişimi olup olmadığı bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("IntiharGirisimiGecmisiNavigation")]
    public string INTIHAR_GIRISIMI_GECMISI { get; set; }

    /// <summary>İntihar girişiminde bulunan ya da kriz geçiren kişiye yapılan müdahalenin nasıl ...</summary>
    [Required]
    [ForeignKey("IntiharKrizVakaSonucuNavigation")]
    public string INTIHAR_KRIZ_VAKA_SONUCU { get; set; }

    /// <summary>Sağlık tesisine adli muayene için getirilmiş kişinin psikiyatrik tanı geçmişi bi...</summary>
    [Required]
    [ForeignKey("PsikiyatrikTaniGecmisiNavigation")]
    public string PSIKIYATRIK_TANI_GECMISI { get; set; }

    /// <summary>Kuduz şüpheli temasa neden olan hayvanın mevcut durumunun ne olduğunu ifade eder...</summary>
    [Required]
    [ForeignKey("HayvaninMevcutDurumuNavigation")]
    public string HAYVANIN_MEVCUT_DURUMU { get; set; }

    /// <summary>Kuduz şüpheli temasa neden olan hayvanın sahiplik durumu bilgisidir.</summary>
    [Required]
    [ForeignKey("HayvaninSahiplikDurumuNavigation")]
    public string HAYVANIN_SAHIPLIK_DURUMU { get; set; }

    /// <summary>Uygulanan immünglobilinin tür bilgisidir. Örneğin at kaynaklı, insan kaynaklı vb...</summary>
    [Required]
    [ForeignKey("ImmunglobulinTuruNavigation")]
    public string IMMUNGLOBULIN_TURU { get; set; }

    /// <summary>Uygulanan immünglobilinin IU cinsinden miktar bilgisidir.</summary>
    [Required]
    public string IMMUNGLOBULIN_MIKTARI { get; set; }

    /// <summary>Kuduz riskli temas sonrası, temas şekline ve temas eden hayvanın durumuna göre p...</summary>
    [Required]
    [ForeignKey("KategorizasyonNavigation")]
    public string KATEGORIZASYON { get; set; }

    /// <summary>Bildirimi zorunlu hastalıklarda hasta için temas olgusunun değerlendirilmesi ile...</summary>
    [Required]
    [ForeignKey("TemasDegerlendirmeDurumuNavigation")]
    public string TEMAS_DEGERLENDIRME_DURUMU { get; set; }

    /// <summary>Kuduz şüpheli temasa sebep olan hayvan türünü ifade eder.</summary>
    [Required]
    [ForeignKey("KuduzSebepOlanHayvanNavigation")]
    public string KUDUZ_SEBEP_OLAN_HAYVAN { get; set; }

    /// <summary>Kişinin kendi sağlığı ile ilgili bir işlem yaptıracağına ilişkin beyan ettiği To...</summary>
    [Required]
    [ForeignKey("YaptiracaginiBeyanEttigiTsmNavigation")]
    public string YAPTIRACAGINI_BEYAN_ETTIGI_TSM { get; set; }

    /// <summary>Riskli temas tipi bilgisini ifade eder. Örneğin hayvana dokunma veya besleme, sa...</summary>
    [Required]
    [ForeignKey("RiskliTemasTipiNavigation")]
    public string RISKLI_TEMAS_TIPI { get; set; }

    /// <summary>Kişinin ev telefonu bilgisidir.</summary>
    [Required]
    public string EV_TELEFONU { get; set; }

    /// <summary>Kişinin cep telefonu bilgisidir.</summary>
    [Required]
    public string CEP_TELEFONU { get; set; }

    /// <summary>Kişinin ev adresi bilgisidir.</summary>
    [Required]
    public string EV_ADRESI { get; set; }

    /// <summary>İl kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("IlNavigation")]
    public string IL_KODU { get; set; }

    /// <summary>İlçe kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("IlceNavigation")]
    public string ILCE_KODU { get; set; }

    /// <summary>Verem hastalığından korunmada kullanılan BCG (Bacille Calmette-Guérin) aşısına a...</summary>
    [Required]
    public string BCG_SKAR_SAYISI { get; set; }

    /// <summary>Doğrudan Gözetimli Tedavi (DGT) uygulamasını yapan, hastanın tedavisi süresince ...</summary>
    [Required]
    [ForeignKey("DgtUygulamasiniYapanKisiNavigation")]
    public string DGT_UYGULAMASINI_YAPAN_KISI { get; set; }

    /// <summary>Kişiye Doğrudan Gözetimli Tedavi (DGT) uygulamasının yapıldığı yeri ifade eder.</summary>
    [Required]
    [ForeignKey("DgtUygulamaYeriNavigation")]
    public string DGT_UYGULAMA_YERI { get; set; }

    /// <summary>Hastanın kendisine uygulanan tedaviye uyum gösterme durumunu ifade eder.</summary>
    [Required]
    [ForeignKey("HastaninTedaviyeUyumuNavigation")]
    public string HASTANIN_TEDAVIYE_UYUMU { get; set; }

    /// <summary>Hastadan alınan numunenin kültür sonucunu ifade eder. Örneğin pozitif, negatif, ...</summary>
    [Required]
    [ForeignKey("KulturSonucuNavigation")]
    public string KULTUR_SONUCU { get; set; }

    /// <summary>Verem şüpheli bireylerde tarama amacıyla kullanılan deri testinin sonucunu tanım...</summary>
    [Required]
    [ForeignKey("TuberkulinDeriTestiSonucuNavigation")]
    public string TUBERKULIN_DERI_TESTI_SONUCU { get; set; }

    /// <summary>Verem hastasının tedavisinde seçilen yöntem bilgisidir. Örneğin doğrudan gözetim...</summary>
    [Required]
    [ForeignKey("VeremHastasiTedaviYontemiNavigation")]
    public string VEREM_HASTASI_TEDAVI_YONTEMI { get; set; }

    /// <summary>Verem tanısı konulan hastada tedavi rejiminin belirlenmesinde ve hastaya yapılac...</summary>
    [Required]
    [ForeignKey("VeremOlguTanimiNavigation")]
    public string VEREM_OLGU_TANIMI { get; set; }

    /// <summary>Kişiden alınan kan, idrar, gaita vb. numuneleri için laboratuvarda yapılan yayma...</summary>
    [Required]
    [ForeignKey("YaymaSonucuNavigation")]
    public string YAYMA_SONUCU { get; set; }

    /// <summary>Verem Hastalığının vücutta yerleştiği organ/sistemi ifade eder. Örneğin akciğer,...</summary>
    [Required]
    [ForeignKey("VeremHastaligiTutulumYeriNavigation")]
    public string VEREM_HASTALIGI_TUTULUM_YERI { get; set; }

    /// <summary>Verem hastalığının teşhisinde yapılan yayma ve kültür için kullanılan hastaya ai...</summary>
    [Required]
    [ForeignKey("VeremHastasiKlinikOrnegiNavigation")]
    public string VEREM_HASTASI_KLINIK_ORNEGI { get; set; }

    /// <summary>Verem hastalığı için duyarlılık testi yapılan ilaç türleridir. Örneğin amikasin,...</summary>
    [Required]
    [ForeignKey("VeremIlacAdiNavigation")]
    public string VEREM_ILAC_ADI { get; set; }

    /// <summary>Verem hastasının tedavi sonucunu ifade eder. Örneğin kür, tedavi tamamlama, ölüm...</summary>
    [Required]
    [ForeignKey("VeremTedaviSonucuNavigation")]
    public string VEREM_TEDAVI_SONUCU { get; set; }

    /// <summary>Bildirimi zorunlu bulaşıcı hastalıkların bildirimi yapılırken teşhis edilen hast...</summary>
    [Required]
    [ForeignKey("BulasiciHastalikVakaTipiNavigation")]
    public string BULASICI_HASTALIK_VAKA_TIPI { get; set; }

    /// <summary>Klinik belirtilerin başladığı tarih bilgisidir.</summary>
    public DateTime BELIRTILERIN_BASLADIGI_TARIH { get; set; }

    /// <summary>Güç ve baskı uygulayarak insanın bedensel ve ruhsal açıdan zarar görmesine neden...</summary>
    [Required]
    [ForeignKey("SiddetTuruNavigation")]
    public string SIDDET_TURU { get; set; }

    /// <summary>Şiddet görmüş hastaya sağlık tesisinde yapılan muayene sonucunu ifade eden bilgi...</summary>
    [Required]
    [ForeignKey("SiddetDegerlendirmeSonucuNavigation")]
    public string SIDDET_DEGERLENDIRME_SONUCU { get; set; }

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
    public virtual REFERANS_KODLAR? BildirimTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? TaniNavigation { get; set; }
    public virtual REFERANS_KODLAR? AilesindeIntiharGirisimiNavigation { get; set; }
    public virtual REFERANS_KODLAR? AilesindePsikiyatrikVakaNavigation { get; set; }
    public virtual REFERANS_KODLAR? IntiharKrizVakaTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? PsikiyatrikTedaviGecmisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? IntiharGirisimKrizNedenleriNavigation { get; set; }
    public virtual REFERANS_KODLAR? IntiharGirisimiYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? IntiharGirisimiGecmisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? IntiharKrizVakaSonucuNavigation { get; set; }
    public virtual REFERANS_KODLAR? PsikiyatrikTaniGecmisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? HayvaninMevcutDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? HayvaninSahiplikDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? ImmunglobulinTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? KategorizasyonNavigation { get; set; }
    public virtual REFERANS_KODLAR? TemasDegerlendirmeDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? KuduzSebepOlanHayvanNavigation { get; set; }
    public virtual KURUM? YaptiracaginiBeyanEttigiTsmNavigation { get; set; }
    public virtual REFERANS_KODLAR? RiskliTemasTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlceNavigation { get; set; }
    public virtual REFERANS_KODLAR? DgtUygulamasiniYapanKisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DgtUygulamaYeriNavigation { get; set; }
    public virtual REFERANS_KODLAR? HastaninTedaviyeUyumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? KulturSonucuNavigation { get; set; }
    public virtual REFERANS_KODLAR? TuberkulinDeriTestiSonucuNavigation { get; set; }
    public virtual REFERANS_KODLAR? VeremHastasiTedaviYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? VeremOlguTanimiNavigation { get; set; }
    public virtual REFERANS_KODLAR? YaymaSonucuNavigation { get; set; }
    public virtual REFERANS_KODLAR? VeremHastaligiTutulumYeriNavigation { get; set; }
    public virtual REFERANS_KODLAR? VeremHastasiKlinikOrnegiNavigation { get; set; }
    public virtual REFERANS_KODLAR? VeremIlacAdiNavigation { get; set; }
    public virtual REFERANS_KODLAR? VeremTedaviSonucuNavigation { get; set; }
    public virtual REFERANS_KODLAR? BulasiciHastalikVakaTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SiddetTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? SiddetDegerlendirmeSonucuNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}