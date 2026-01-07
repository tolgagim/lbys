using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// BILDIRIMI_ZORUNLU tablosu - 53 kolon
/// </summary>
[Table("BILDIRIMI_ZORUNLU")]
public class BILDIRIMI_ZORUNLU : VemEntity
{
    /// <summary>Bildirimi zorunlu hastalÄ±k iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼retilen...</summary>
    [Key]
    public string BILDIRIMI_ZORUNLU_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Bildirimi zorunlu hastalÄ±klar veya durumlar kapsamÄ±nda yapÄ±lan bildirimin tÃ¼rÃ¼nÃ¼...</summary>
    [ForeignKey("BildirimTuruNavigation")]
    public string BILDIRIM_TURU { get; set; }

    /// <summary>Bildirimi zorunlu hastalÄ±ÄŸÄ±n veya durumlarÄ±n ilgili yerlere bildirildiÄŸi zaman b...</summary>
    public DateTime? BILDIRIM_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hastaya konulan tanÄ± iÃ§in ICD-10 kodlarÄ±ndan seÃ§ilen tanÄ± kodu ...</summary>
    [ForeignKey("TaniNavigation")]
    public string TANI_KODU { get; set; }

    /// <summary>Ä°ntihar giriÅŸiminde bulunan veya kriz geÃ§iren kiÅŸinin aile Ã¼yelerinin herhangi b...</summary>
    [Required]
    [ForeignKey("AilesindeIntiharGirisimiNavigation")]
    public string AILESINDE_INTIHAR_GIRISIMI { get; set; }

    /// <summary>Ä°ntihar giriÅŸiminde bulunan veya kriz geÃ§iren kiÅŸinin aile Ã¼yelerinin herhangi b...</summary>
    [Required]
    [ForeignKey("AilesindePsikiyatrikVakaNavigation")]
    public string AILESINDE_PSIKIYATRIK_VAKA { get; set; }

    /// <summary>VakanÄ±n intihar vakasÄ± ya da kriz vakasÄ± olma durumunu ifade eder.</summary>
    [Required]
    [ForeignKey("IntiharKrizVakaTuruNavigation")]
    public string INTIHAR_KRIZ_VAKA_TURU { get; set; }

    /// <summary>OlayÄ±n gerÃ§ekleÅŸtiÄŸi zaman bilgisidir.</summary>
    public DateTime OLAY_ZAMANI { get; set; }

    /// <summary>HastanÄ±n acil servise baÅŸvuru tarihinden Ã¶nceki son 6 aylÄ±k dÃ¶nemde psikiyatrik ...</summary>
    [Required]
    [ForeignKey("PsikiyatrikTedaviGecmisiNavigation")]
    public string PSIKIYATRIK_TEDAVI_GECMISI { get; set; }

    /// <summary>KiÅŸinin intihar giriÅŸimi ya da kriz nedenlerini ifade eder.</summary>
    [Required]
    [ForeignKey("IntiharGirisimKrizNedenleriNavigation")]
    public string INTIHAR_GIRISIM_KRIZ_NEDENLERI { get; set; }

    /// <summary>KiÅŸinin intihar giriÅŸimini gerÃ§ekleÅŸtirirken kullandÄ±ÄŸÄ± yÃ¶ntem/yÃ¶ntemleri ifade ...</summary>
    [Required]
    [ForeignKey("IntiharGirisimiYontemiNavigation")]
    public string INTIHAR_GIRISIMI_YONTEMI { get; set; }

    /// <summary>KiÅŸinin geÃ§miÅŸinde intihar giriÅŸimi olup olmadÄ±ÄŸÄ± bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("IntiharGirisimiGecmisiNavigation")]
    public string INTIHAR_GIRISIMI_GECMISI { get; set; }

    /// <summary>Ä°ntihar giriÅŸiminde bulunan ya da kriz geÃ§iren kiÅŸiye yapÄ±lan mÃ¼dahalenin nasÄ±l ...</summary>
    [Required]
    [ForeignKey("IntiharKrizVakaSonucuNavigation")]
    public string INTIHAR_KRIZ_VAKA_SONUCU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine adli muayene iÃ§in getirilmiÅŸ kiÅŸinin psikiyatrik tanÄ± geÃ§miÅŸi bi...</summary>
    [Required]
    [ForeignKey("PsikiyatrikTaniGecmisiNavigation")]
    public string PSIKIYATRIK_TANI_GECMISI { get; set; }

    /// <summary>Kuduz ÅŸÃ¼pheli temasa neden olan hayvanÄ±n mevcut durumunun ne olduÄŸunu ifade eder...</summary>
    [Required]
    [ForeignKey("HayvaninMevcutDurumuNavigation")]
    public string HAYVANIN_MEVCUT_DURUMU { get; set; }

    /// <summary>Kuduz ÅŸÃ¼pheli temasa neden olan hayvanÄ±n sahiplik durumu bilgisidir.</summary>
    [Required]
    [ForeignKey("HayvaninSahiplikDurumuNavigation")]
    public string HAYVANIN_SAHIPLIK_DURUMU { get; set; }

    /// <summary>Uygulanan immÃ¼nglobilinin tÃ¼r bilgisidir. Ã–rneÄŸin at kaynaklÄ±, insan kaynaklÄ± vb...</summary>
    [Required]
    [ForeignKey("ImmunglobulinTuruNavigation")]
    public string IMMUNGLOBULIN_TURU { get; set; }

    /// <summary>Uygulanan immÃ¼nglobilinin IU cinsinden miktar bilgisidir.</summary>
    [Required]
    public string IMMUNGLOBULIN_MIKTARI { get; set; }

    /// <summary>Kuduz riskli temas sonrasÄ±, temas ÅŸekline ve temas eden hayvanÄ±n durumuna gÃ¶re p...</summary>
    [Required]
    [ForeignKey("KategorizasyonNavigation")]
    public string KATEGORIZASYON { get; set; }

    /// <summary>Bildirimi zorunlu hastalÄ±klarda hasta iÃ§in temas olgusunun deÄŸerlendirilmesi ile...</summary>
    [Required]
    [ForeignKey("TemasDegerlendirmeDurumuNavigation")]
    public string TEMAS_DEGERLENDIRME_DURUMU { get; set; }

    /// <summary>Kuduz ÅŸÃ¼pheli temasa sebep olan hayvan tÃ¼rÃ¼nÃ¼ ifade eder.</summary>
    [Required]
    [ForeignKey("KuduzSebepOlanHayvanNavigation")]
    public string KUDUZ_SEBEP_OLAN_HAYVAN { get; set; }

    /// <summary>KiÅŸinin kendi saÄŸlÄ±ÄŸÄ± ile ilgili bir iÅŸlem yaptÄ±racaÄŸÄ±na iliÅŸkin beyan ettiÄŸi To...</summary>
    [Required]
    [ForeignKey("YaptiracaginiBeyanEttigiTsmNavigation")]
    public string YAPTIRACAGINI_BEYAN_ETTIGI_TSM { get; set; }

    /// <summary>Riskli temas tipi bilgisini ifade eder. Ã–rneÄŸin hayvana dokunma veya besleme, sa...</summary>
    [Required]
    [ForeignKey("RiskliTemasTipiNavigation")]
    public string RISKLI_TEMAS_TIPI { get; set; }

    /// <summary>KiÅŸinin ev telefonu bilgisidir.</summary>
    [Required]
    public string EV_TELEFONU { get; set; }

    /// <summary>KiÅŸinin cep telefonu bilgisidir.</summary>
    [Required]
    public string CEP_TELEFONU { get; set; }

    /// <summary>KiÅŸinin ev adresi bilgisidir.</summary>
    [Required]
    public string EV_ADRESI { get; set; }

    /// <summary>Ä°l kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("IlNavigation")]
    public string IL_KODU { get; set; }

    /// <summary>Ä°lÃ§e kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("IlceNavigation")]
    public string ILCE_KODU { get; set; }

    /// <summary>Verem hastalÄ±ÄŸÄ±ndan korunmada kullanÄ±lan BCG (Bacille Calmette-GuÃ©rin) aÅŸÄ±sÄ±na a...</summary>
    [Required]
    public string BCG_SKAR_SAYISI { get; set; }

    /// <summary>DoÄŸrudan GÃ¶zetimli Tedavi (DGT) uygulamasÄ±nÄ± yapan, hastanÄ±n tedavisi sÃ¼resince ...</summary>
    [Required]
    [ForeignKey("DgtUygulamasiniYapanKisiNavigation")]
    public string DGT_UYGULAMASINI_YAPAN_KISI { get; set; }

    /// <summary>KiÅŸiye DoÄŸrudan GÃ¶zetimli Tedavi (DGT) uygulamasÄ±nÄ±n yapÄ±ldÄ±ÄŸÄ± yeri ifade eder.</summary>
    [Required]
    [ForeignKey("DgtUygulamaYeriNavigation")]
    public string DGT_UYGULAMA_YERI { get; set; }

    /// <summary>HastanÄ±n kendisine uygulanan tedaviye uyum gÃ¶sterme durumunu ifade eder.</summary>
    [Required]
    [ForeignKey("HastaninTedaviyeUyumuNavigation")]
    public string HASTANIN_TEDAVIYE_UYUMU { get; set; }

    /// <summary>Hastadan alÄ±nan numunenin kÃ¼ltÃ¼r sonucunu ifade eder. Ã–rneÄŸin pozitif, negatif, ...</summary>
    [Required]
    [ForeignKey("KulturSonucuNavigation")]
    public string KULTUR_SONUCU { get; set; }

    /// <summary>Verem ÅŸÃ¼pheli bireylerde tarama amacÄ±yla kullanÄ±lan deri testinin sonucunu tanÄ±m...</summary>
    [Required]
    [ForeignKey("TuberkulinDeriTestiSonucuNavigation")]
    public string TUBERKULIN_DERI_TESTI_SONUCU { get; set; }

    /// <summary>Verem hastasÄ±nÄ±n tedavisinde seÃ§ilen yÃ¶ntem bilgisidir. Ã–rneÄŸin doÄŸrudan gÃ¶zetim...</summary>
    [Required]
    [ForeignKey("VeremHastasiTedaviYontemiNavigation")]
    public string VEREM_HASTASI_TEDAVI_YONTEMI { get; set; }

    /// <summary>Verem tanÄ±sÄ± konulan hastada tedavi rejiminin belirlenmesinde ve hastaya yapÄ±lac...</summary>
    [Required]
    [ForeignKey("VeremOlguTanimiNavigation")]
    public string VEREM_OLGU_TANIMI { get; set; }

    /// <summary>KiÅŸiden alÄ±nan kan, idrar, gaita vb. numuneleri iÃ§in laboratuvarda yapÄ±lan yayma...</summary>
    [Required]
    [ForeignKey("YaymaSonucuNavigation")]
    public string YAYMA_SONUCU { get; set; }

    /// <summary>Verem HastalÄ±ÄŸÄ±nÄ±n vÃ¼cutta yerleÅŸtiÄŸi organ/sistemi ifade eder. Ã–rneÄŸin akciÄŸer,...</summary>
    [Required]
    [ForeignKey("VeremHastaligiTutulumYeriNavigation")]
    public string VEREM_HASTALIGI_TUTULUM_YERI { get; set; }

    /// <summary>Verem hastalÄ±ÄŸÄ±nÄ±n teÅŸhisinde yapÄ±lan yayma ve kÃ¼ltÃ¼r iÃ§in kullanÄ±lan hastaya ai...</summary>
    [Required]
    [ForeignKey("VeremHastasiKlinikOrnegiNavigation")]
    public string VEREM_HASTASI_KLINIK_ORNEGI { get; set; }

    /// <summary>Verem hastalÄ±ÄŸÄ± iÃ§in duyarlÄ±lÄ±k testi yapÄ±lan ilaÃ§ tÃ¼rleridir. Ã–rneÄŸin amikasin,...</summary>
    [Required]
    [ForeignKey("VeremIlacAdiNavigation")]
    public string VEREM_ILAC_ADI { get; set; }

    /// <summary>Verem hastasÄ±nÄ±n tedavi sonucunu ifade eder. Ã–rneÄŸin kÃ¼r, tedavi tamamlama, Ã¶lÃ¼m...</summary>
    [Required]
    [ForeignKey("VeremTedaviSonucuNavigation")]
    public string VEREM_TEDAVI_SONUCU { get; set; }

    /// <summary>Bildirimi zorunlu bulaÅŸÄ±cÄ± hastalÄ±klarÄ±n bildirimi yapÄ±lÄ±rken teÅŸhis edilen hast...</summary>
    [Required]
    [ForeignKey("BulasiciHastalikVakaTipiNavigation")]
    public string BULASICI_HASTALIK_VAKA_TIPI { get; set; }

    /// <summary>Klinik belirtilerin baÅŸladÄ±ÄŸÄ± tarih bilgisidir.</summary>
    public DateTime BELIRTILERIN_BASLADIGI_TARIH { get; set; }

    /// <summary>GÃ¼Ã§ ve baskÄ± uygulayarak insanÄ±n bedensel ve ruhsal aÃ§Ä±dan zarar gÃ¶rmesine neden...</summary>
    [Required]
    [ForeignKey("SiddetTuruNavigation")]
    public string SIDDET_TURU { get; set; }

    /// <summary>Åžiddet gÃ¶rmÃ¼ÅŸ hastaya saÄŸlÄ±k tesisinde yapÄ±lan muayene sonucunu ifade eden bilgi...</summary>
    [Required]
    [ForeignKey("SiddetDegerlendirmeSonucuNavigation")]
    public string SIDDET_DEGERLENDIRME_SONUCU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

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
    #endregion

}
