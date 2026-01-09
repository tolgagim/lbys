using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// HASTA_ADLI_RAPOR tablosu - 68 kolon
/// </summary>
[Table("HASTA_ADLI_RAPOR")]
public class HASTA_ADLI_RAPOR : VemEntity
{
    /// <summary>Adli rapor dÃ¼zenlenen hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±nd...</summary>
    [Key]
    public string HASTA_ADLI_RAPOR_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>KiÅŸiye verilen adli raporun tÃ¼r bilgisidir. Ã–rneÄŸin giriÅŸ raporu, Ã§Ä±kÄ±ÅŸ raporu, ...</summary>
    [ForeignKey("AdliRaporTuruNavigation")]
    public string ADLI_RAPOR_TURU { get; set; }

    /// <summary>Rapor zamanÄ± bilgisidir.</summary>
    public DateTime? RAPOR_ZAMANI { get; set; }

    /// <summary>KiÅŸiyi adli muayene iÃ§in saÄŸlÄ±k tesisine gÃ¶nderen kurum bilgisidir.</summary>
    [Required]
    public string ADLI_MUAYENEYE_GONDEREN_KURUM { get; set; }

    /// <summary>Adli merciler tarafÄ±ndan, saÄŸlÄ±k tesisine gÃ¶nderilen kiÅŸinin muayeneye gÃ¶nderilm...</summary>
    [Required]
    public string RESMI_YAZI_NUMARASI { get; set; }

    /// <summary>Adli merciler tarafÄ±ndan, saÄŸlÄ±k tesisine gÃ¶nderilen kiÅŸinin muayeneye gÃ¶nderilm...</summary>
    public DateTime RESMI_YAZI_TARIHI { get; set; }

    /// <summary>Adli raporu isteyen kurumun hastayÄ± muayeneye gÃ¶nderme nedeni bilgisidir.</summary>
    [Required]
    public string ADLI_MUAYENE_EDILME_NEDENI { get; set; }

    /// <summary>Kolluk kuvvetinin sicil numarasÄ± bilgisidir.</summary>
    [Required]
    public string GUVENLIK_SICIL_NUMARASI { get; set; }

    /// <summary>Kolluk kuvvetinin ad soyadÄ± bilgisidir.</summary>
    [Required]
    public string GUVENLIK_ADI_SOYADI { get; set; }

    /// <summary>OlayÄ±n gerÃ§ekleÅŸtiÄŸi zaman bilgisidir.</summary>
    public DateTime OLAY_ZAMANI { get; set; }

    /// <summary>Adli vakalarda meydana gelen olayÄ±n Ã¶ykÃ¼sÃ¼ bilgisidir.</summary>
    [Required]
    public string ADLI_OLAY_OYKUSU { get; set; }

    /// <summary>HastanÄ±n saÄŸlÄ±k tesisine baÅŸvurmasÄ±na neden olan ÅŸikayet bilgisini ifade eder.</summary>
    [Required]
    public string SIKAYET { get; set; }

    /// <summary>KiÅŸinin Ã¶zgeÃ§miÅŸ bilgisidir.</summary>
    [Required]
    public string OZGECMISI { get; set; }

    /// <summary>SaÄŸlÄ±k hizmeti alan kiÅŸinin soy geÃ§miÅŸ bilgisidir.</summary>
    [Required]
    public string SOYGECMISI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran kiÅŸinin hekim tarafÄ±ndan ilk muayene edildiÄŸi zaman bil...</summary>
    public DateTime MUAYENE_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli hekim iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼ret...</summary>
    [Required]
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde saÄŸlÄ±k hizmetini alan kiÅŸi iÃ§in uygulanan tÄ±bbi mÃ¼dahale bilgis...</summary>
    [Required]
    public string TIBBI_MUDAHALE { get; set; }

    /// <summary>SaÄŸlÄ±k hizmetini almak isteyen kiÅŸiyi muayene etmek iÃ§in uygun ÅŸartlarÄ±n saÄŸlanm...</summary>
    public string UYGUN_SART_SAGLANMA_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k hizmetini almak isteyen kiÅŸiyi muayene etmek iÃ§in uygun ÅŸartlarÄ±n saÄŸlanm...</summary>
    [Required]
    public string UYGUN_SART_ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine adli muayene iÃ§in getirilmiÅŸ kiÅŸinin Ã¼zerinde bulunan kÄ±yafetler...</summary>
    [Required]
    [ForeignKey("ElbiseDurumuNavigation")]
    public string ELBISE_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hekim tarafÄ±ndan yapÄ±lan konsÃ¼ltasyon bilgisidir.</summary>
    [Required]
    public string KONSULTASYON_BILGISI { get; set; }

    /// <summary>KiÅŸinin vÃ¼cudunda tespit edilen lezyonlara iliÅŸkin bilgidir.</summary>
    [Required]
    public string LEZYON_BULGULARI { get; set; }

    /// <summary>Sistem bulgularÄ± bilgisidir.</summary>
    [Required]
    public string SISTEM_BULGULARI { get; set; }

    /// <summary>KiÅŸinin bilinÃ§ durumu bilgisidir.</summary>
    [Required]
    public string BILINC_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde muayene olan kiÅŸinin pupilla (gÃ¶zbebeÄŸi) refleksi deÄŸerlendirme...</summary>
    [Required]
    [ForeignKey("PupillaDegerlendirmesiNavigation")]
    public string PUPILLA_DEGERLENDIRMESI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine adli muayene iÃ§in gelen hastanÄ±n gÃ¶z muayenesinde bakÄ±lan Ä±ÅŸÄ±k r...</summary>
    [Required]
    [ForeignKey("IsikRefleksiNavigation")]
    public string ISIK_REFLEKSI { get; set; }

    /// <summary>HastanÄ±n 1 dakikadaki atÄ±m sayÄ±sÄ± cinsinden nabÄ±z bilgisidir.</summary>
    [Required]
    public string NABIZ { get; set; }

    /// <summary>HastanÄ±n refleks Ã¶lÃ§Ã¼mÃ¼nde elde edilen sonuÃ§ bilgisidir. Ã–rneÄŸin normoaktif, hip...</summary>
    [Required]
    [ForeignKey("TendonRefleksiNavigation")]
    public string TENDON_REFLEKSI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine adli muayene iÃ§in getirilmiÅŸ kiÅŸinin psikiyatrik muayene bilgisi...</summary>
    [Required]
    public string PSIKIYATRIK_MUAYENE { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine adli muayene iÃ§in getirilmiÅŸ kiÅŸinin psikiyatrik muayene sonuÃ§ b...</summary>
    [Required]
    public string PSIKIYATRIK_SONUC { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hastaya uygulanan iÅŸlemler iÃ§in yapÄ±lan aÃ§Ä±klama bilgisidir.</summary>
    [Required]
    public string HIZMET_ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki hastanÄ±n sevk edilip edilmediÄŸine iliÅŸkin bilgiyi ifade eder.</summary>
    [Required]
    public string SEVK_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde sevk edilen hasta iÃ§in yapÄ±lan aÃ§Ä±klama bilgisini ifade eder.</summary>
    [Required]
    public string SEVK_ACIKLAMA { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼, numune, adli rapor, nÃ¼fus cÃ¼zdanÄ±, malzeme vb. teslim alan kiÅŸinin ad...</summary>
    [Required]
    public string TESLIM_ALAN_ADI_SOYADI { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼, numune, adli rapor, nÃ¼fus cÃ¼zdanÄ±, malzeme vb. teslim alan kiÅŸinin TC...</summary>
    [Required]
    public string TESLIM_ALAN_TC_KIMLIK_NUMARASI { get; set; }

    /// <summary>Muayene edilen kiÅŸinin vÃ¼cudunda tespit edilen tÄ±bbi bulgularÄ±n vÃ¼cut diyagramÄ±n...</summary>
    [Required]
    public string VUCUT_DIYAGRAMI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine adli muayene iÃ§in getirilmiÅŸ kiÅŸinin yapÄ±lacak olan muayene iÃ§in...</summary>
    [Required]
    [ForeignKey("AdliMuayeneRizaDurumuNavigation")]
    public string ADLI_MUAYENE_RIZA_DURUMU { get; set; }

    /// <summary>Adli muayeneye rÄ±za veren kiÅŸinin adÄ± ve soyadÄ± bilgisini ifade eder.</summary>
    [Required]
    public string RIZA_VEREN_KISI { get; set; }

    /// <summary>Adli muayeneye rÄ±za veren kiÅŸinin muayene olan kiÅŸiye yakÄ±nlÄ±k durumunu ifade ed...</summary>
    [Required]
    [ForeignKey("RizaVereninYakinlikDerecesiNavigation")]
    public string RIZA_VERENIN_YAKINLIK_DERECESI { get; set; }

    /// <summary>Muayene edilen kiÅŸinin son cinsel iliÅŸki tarihidir.</summary>
    public DateTime SON_CINSEL_ILISKI_TARIHI { get; set; }

    /// <summary>KadÄ±nÄ±n hamile olup olmadÄ±ÄŸÄ±nÄ± ifade eder.</summary>
    [Required]
    public string HAMILELIK_DURUMU { get; set; }

    /// <summary>KadÄ±nÄ±n hamilelik Ã¶ykÃ¼sÃ¼ aÃ§Ä±klama bilgisidir.</summary>
    [Required]
    public string HAMILELIK_OYKUSU_ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k hizmeti almak isteyen kiÅŸinin veneryal hastalÄ±k (cinsel yolla bulaÅŸan has...</summary>
    [Required]
    public string VENERYAL_HASTALIK_OYKUSU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine adli muayene iÃ§in getirilmiÅŸ kiÅŸinin emosyonel (duygu durumu) du...</summary>
    [Required]
    public string EMOSYONEL_HASTALIK_OYKUSU { get; set; }

    /// <summary>HastanÄ±n solunum bilgisidir.</summary>
    [Required]
    public string SOLUNUM { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine adli muayene iÃ§in getirilmiÅŸ kiÅŸiye hekim tarafÄ±ndan yazÄ±lan mua...</summary>
    [Required]
    public string ADLI_MUAYENE_NOTU { get; set; }

    /// <summary>Hastadan alÄ±nan materyal bilgisidir.</summary>
    [Required]
    public string ALINAN_MATERYAL { get; set; }

    /// <summary>Muayene sÄ±rasÄ±nda muayene odasÄ±nda bulunan hekim dÄ±ÅŸÄ±ndaki kiÅŸi bilgisidir.</summary>
    [Required]
    public string MUAYENEDEKI_KISI_BILGISI { get; set; }

    /// <summary>Muayene sÄ±rasÄ±nda muayene odasÄ±nda bulunan hekim dÄ±ÅŸÄ±ndaki kiÅŸiler ile ilgili aÃ§...</summary>
    [Required]
    public string MUAYENEDEKI_KISI_ACIKLAMA { get; set; }

    /// <summary>KiÅŸinin alkol kullanma durumunu ifade eder.</summary>
    [Required]
    public string ALKOL_KULLANIMI { get; set; }

    /// <summary>HastanÄ±n ÅŸiddet veya tehdide maruz kalÄ±p kalmadÄ±ÄŸÄ±na iliÅŸkin saÄŸlÄ±k tesisinde ve...</summary>
    [Required]
    public string SIDDET_TEHDIT_BILGISI { get; set; }

    /// <summary>HastanÄ±n silah, alet vb. maruz kalma bilgisini ifade eder.</summary>
    [Required]
    public string SILAH_ALET_BILGISI { get; set; }

    /// <summary>HastanÄ±n hayati tehlikesinin olup olmadÄ±ÄŸÄ±na iliÅŸkin bilgiyi ifade eder.</summary>
    [Required]
    public string HAYATI_TEHLIKE_DURUMU { get; set; }

    /// <summary>Sistolik kan basÄ±ncÄ± (bÃ¼yÃ¼k tansiyon) bilgisini ifade eder.</summary>
    [Required]
    public string SISTOLIK_KAN_BASINCI_DEGERI { get; set; }

    /// <summary>Diastolik kan basÄ±ncÄ± (kÃ¼Ã§Ã¼k tansiyon) bilgisini ifade eder.</summary>
    [Required]
    public string DIASTOLIK_KAN_BASINCI_DEGERI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin iptal edildiÄŸi zaman bilgisidir.</summary>
    public DateTime IPTAL_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan bir iÅŸlemi iptal eden SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi kull...</summary>
    [Required]
    [ForeignKey("IptalEdenKullaniciNavigation")]
    public string IPTAL_EDEN_KULLANICI_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde dÃ¼zenlenen adli raporun iptal edilmesi durumunda, belirtilen ip...</summary>
    [Required]
    public string ADLI_RAPOR_IPTAL_GEREKCESI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde iÅŸlemi gerÃ§ekleÅŸtiren veya iÅŸlemin sonucunu onaylayan kullanÄ±cÄ±...</summary>
    [Required]
    [ForeignKey("OnaylayanKullaniciNavigation")]
    public string ONAYLAYAN_KULLANICI_KODU { get; set; }

    /// <summary>Adli raporun onaylandÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime ADLI_RAPOR_ONAYLANMA_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual REFERANS_KODLAR? AdliRaporTuruNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual REFERANS_KODLAR? ElbiseDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? PupillaDegerlendirmesiNavigation { get; set; }
    public virtual REFERANS_KODLAR? IsikRefleksiNavigation { get; set; }
    public virtual REFERANS_KODLAR? TendonRefleksiNavigation { get; set; }
    public virtual REFERANS_KODLAR? AdliMuayeneRizaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? RizaVereninYakinlikDerecesiNavigation { get; set; }
    public virtual KULLANICI? IptalEdenKullaniciNavigation { get; set; }
    public virtual KULLANICI? OnaylayanKullaniciNavigation { get; set; }
    #endregion

}
