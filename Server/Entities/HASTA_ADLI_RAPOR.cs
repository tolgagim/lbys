using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_HASTA_ADLI_RAPOR tablosu - 68 kolon
/// </summary>
[Table("HASTA_ADLI_RAPOR")]
public class HASTA_ADLI_RAPOR
{
    /// <summary>Adli rapor düzenlenen hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafınd...</summary>
    [Key]
    public string HASTA_ADLI_RAPOR_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Kişiye verilen adli raporun tür bilgisidir. Örneğin giriş raporu, çıkış raporu, ...</summary>
    [ForeignKey("AdliRaporTuruNavigation")]
    public string ADLI_RAPOR_TURU { get; set; }

    /// <summary>Rapor zamanı bilgisidir.</summary>
    public DateTime? RAPOR_ZAMANI { get; set; }

    /// <summary>Kişiyi adli muayene için sağlık tesisine gönderen kurum bilgisidir.</summary>
    [Required]
    public string ADLI_MUAYENEYE_GONDEREN_KURUM { get; set; }

    /// <summary>Adli merciler tarafından, sağlık tesisine gönderilen kişinin muayeneye gönderilm...</summary>
    [Required]
    public string RESMI_YAZI_NUMARASI { get; set; }

    /// <summary>Adli merciler tarafından, sağlık tesisine gönderilen kişinin muayeneye gönderilm...</summary>
    public DateTime RESMI_YAZI_TARIHI { get; set; }

    /// <summary>Adli raporu isteyen kurumun hastayı muayeneye gönderme nedeni bilgisidir.</summary>
    [Required]
    public string ADLI_MUAYENE_EDILME_NEDENI { get; set; }

    /// <summary>Kolluk kuvvetinin sicil numarası bilgisidir.</summary>
    [Required]
    public string GUVENLIK_SICIL_NUMARASI { get; set; }

    /// <summary>Kolluk kuvvetinin ad soyadı bilgisidir.</summary>
    [Required]
    public string GUVENLIK_ADI_SOYADI { get; set; }

    /// <summary>Olayın gerçekleştiği zaman bilgisidir.</summary>
    public DateTime OLAY_ZAMANI { get; set; }

    /// <summary>Adli vakalarda meydana gelen olayın öyküsü bilgisidir.</summary>
    [Required]
    public string ADLI_OLAY_OYKUSU { get; set; }

    /// <summary>Hastanın sağlık tesisine başvurmasına neden olan şikayet bilgisini ifade eder.</summary>
    [Required]
    public string SIKAYET { get; set; }

    /// <summary>Kişinin özgeçmiş bilgisidir.</summary>
    [Required]
    public string OZGECMISI { get; set; }

    /// <summary>Sağlık hizmeti alan kişinin soy geçmiş bilgisidir.</summary>
    [Required]
    public string SOYGECMISI { get; set; }

    /// <summary>Sağlık tesisine başvuran kişinin hekim tarafından ilk muayene edildiği zaman bil...</summary>
    public DateTime MUAYENE_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde görevli hekim için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [Required]
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }

    /// <summary>Sağlık tesisinde sağlık hizmetini alan kişi için uygulanan tıbbi müdahale bilgis...</summary>
    [Required]
    public string TIBBI_MUDAHALE { get; set; }

    /// <summary>Sağlık hizmetini almak isteyen kişiyi muayene etmek için uygun şartların sağlanm...</summary>
    public string UYGUN_SART_SAGLANMA_DURUMU { get; set; }

    /// <summary>Sağlık hizmetini almak isteyen kişiyi muayene etmek için uygun şartların sağlanm...</summary>
    [Required]
    public string UYGUN_SART_ACIKLAMA { get; set; }

    /// <summary>Sağlık tesisine adli muayene için getirilmiş kişinin üzerinde bulunan kıyafetler...</summary>
    [Required]
    [ForeignKey("ElbiseDurumuNavigation")]
    public string ELBISE_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde hekim tarafından yapılan konsültasyon bilgisidir.</summary>
    [Required]
    public string KONSULTASYON_BILGISI { get; set; }

    /// <summary>Kişinin vücudunda tespit edilen lezyonlara ilişkin bilgidir.</summary>
    [Required]
    public string LEZYON_BULGULARI { get; set; }

    /// <summary>Sistem bulguları bilgisidir.</summary>
    [Required]
    public string SISTEM_BULGULARI { get; set; }

    /// <summary>Kişinin bilinç durumu bilgisidir.</summary>
    [Required]
    public string BILINC_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde muayene olan kişinin pupilla (gözbebeği) refleksi değerlendirme...</summary>
    [Required]
    [ForeignKey("PupillaDegerlendirmesiNavigation")]
    public string PUPILLA_DEGERLENDIRMESI { get; set; }

    /// <summary>Sağlık tesisine adli muayene için gelen hastanın göz muayenesinde bakılan ışık r...</summary>
    [Required]
    [ForeignKey("IsikRefleksiNavigation")]
    public string ISIK_REFLEKSI { get; set; }

    /// <summary>Hastanın 1 dakikadaki atım sayısı cinsinden nabız bilgisidir.</summary>
    [Required]
    public string NABIZ { get; set; }

    /// <summary>Hastanın refleks ölçümünde elde edilen sonuç bilgisidir. Örneğin normoaktif, hip...</summary>
    [Required]
    [ForeignKey("TendonRefleksiNavigation")]
    public string TENDON_REFLEKSI { get; set; }

    /// <summary>Sağlık tesisine adli muayene için getirilmiş kişinin psikiyatrik muayene bilgisi...</summary>
    [Required]
    public string PSIKIYATRIK_MUAYENE { get; set; }

    /// <summary>Sağlık tesisine adli muayene için getirilmiş kişinin psikiyatrik muayene sonuç b...</summary>
    [Required]
    public string PSIKIYATRIK_SONUC { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanan işlemler için yapılan açıklama bilgisidir.</summary>
    [Required]
    public string HIZMET_ACIKLAMA { get; set; }

    /// <summary>Sağlık tesisindeki hastanın sevk edilip edilmediğine ilişkin bilgiyi ifade eder.</summary>
    [Required]
    public string SEVK_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde sevk edilen hasta için yapılan açıklama bilgisini ifade eder.</summary>
    [Required]
    public string SEVK_ACIKLAMA { get; set; }

    /// <summary>Kan ürünü, numune, adli rapor, nüfus cüzdanı, malzeme vb. teslim alan kişinin ad...</summary>
    [Required]
    public string TESLIM_ALAN_ADI_SOYADI { get; set; }

    /// <summary>Kan ürünü, numune, adli rapor, nüfus cüzdanı, malzeme vb. teslim alan kişinin TC...</summary>
    [Required]
    public string TESLIM_ALAN_TC_KIMLIK_NUMARASI { get; set; }

    /// <summary>Muayene edilen kişinin vücudunda tespit edilen tıbbi bulguların vücut diyagramın...</summary>
    [Required]
    public string VUCUT_DIYAGRAMI { get; set; }

    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>Sağlık tesisine adli muayene için getirilmiş kişinin yapılacak olan muayene için...</summary>
    [Required]
    [ForeignKey("AdliMuayeneRizaDurumuNavigation")]
    public string ADLI_MUAYENE_RIZA_DURUMU { get; set; }

    /// <summary>Adli muayeneye rıza veren kişinin adı ve soyadı bilgisini ifade eder.</summary>
    [Required]
    public string RIZA_VEREN_KISI { get; set; }

    /// <summary>Adli muayeneye rıza veren kişinin muayene olan kişiye yakınlık durumunu ifade ed...</summary>
    [Required]
    [ForeignKey("RizaVereninYakinlikDerecesiNavigation")]
    public string RIZA_VERENIN_YAKINLIK_DERECESI { get; set; }

    /// <summary>Muayene edilen kişinin son cinsel ilişki tarihidir.</summary>
    public DateTime SON_CINSEL_ILISKI_TARIHI { get; set; }

    /// <summary>Kadının hamile olup olmadığını ifade eder.</summary>
    [Required]
    public string HAMILELIK_DURUMU { get; set; }

    /// <summary>Kadının hamilelik öyküsü açıklama bilgisidir.</summary>
    [Required]
    public string HAMILELIK_OYKUSU_ACIKLAMA { get; set; }

    /// <summary>Sağlık hizmeti almak isteyen kişinin veneryal hastalık (cinsel yolla bulaşan has...</summary>
    [Required]
    public string VENERYAL_HASTALIK_OYKUSU { get; set; }

    /// <summary>Sağlık tesisine adli muayene için getirilmiş kişinin emosyonel (duygu durumu) du...</summary>
    [Required]
    public string EMOSYONEL_HASTALIK_OYKUSU { get; set; }

    /// <summary>Hastanın solunum bilgisidir.</summary>
    [Required]
    public string SOLUNUM { get; set; }

    /// <summary>Sağlık tesisine adli muayene için getirilmiş kişiye hekim tarafından yazılan mua...</summary>
    [Required]
    public string ADLI_MUAYENE_NOTU { get; set; }

    /// <summary>Hastadan alınan materyal bilgisidir.</summary>
    [Required]
    public string ALINAN_MATERYAL { get; set; }

    /// <summary>Muayene sırasında muayene odasında bulunan hekim dışındaki kişi bilgisidir.</summary>
    [Required]
    public string MUAYENEDEKI_KISI_BILGISI { get; set; }

    /// <summary>Muayene sırasında muayene odasında bulunan hekim dışındaki kişiler ile ilgili aç...</summary>
    [Required]
    public string MUAYENEDEKI_KISI_ACIKLAMA { get; set; }

    /// <summary>Kişinin alkol kullanma durumunu ifade eder.</summary>
    [Required]
    public string ALKOL_KULLANIMI { get; set; }

    /// <summary>Hastanın şiddet veya tehdide maruz kalıp kalmadığına ilişkin sağlık tesisinde ve...</summary>
    [Required]
    public string SIDDET_TEHDIT_BILGISI { get; set; }

    /// <summary>Hastanın silah, alet vb. maruz kalma bilgisini ifade eder.</summary>
    [Required]
    public string SILAH_ALET_BILGISI { get; set; }

    /// <summary>Hastanın hayati tehlikesinin olup olmadığına ilişkin bilgiyi ifade eder.</summary>
    [Required]
    public string HAYATI_TEHLIKE_DURUMU { get; set; }

    /// <summary>Sistolik kan basıncı (büyük tansiyon) bilgisini ifade eder.</summary>
    [Required]
    public string SISTOLIK_KAN_BASINCI_DEGERI { get; set; }

    /// <summary>Diastolik kan basıncı (küçük tansiyon) bilgisini ifade eder.</summary>
    [Required]
    public string DIASTOLIK_KAN_BASINCI_DEGERI { get; set; }

    /// <summary>Sağlık tesisinde üretilen verinin iptal edildiği zaman bilgisidir.</summary>
    public DateTime IPTAL_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde yapılan bir işlemi iptal eden Sağlık Bilgi Yönetim Sistemi kull...</summary>
    [Required]
    [ForeignKey("IptalEdenKullaniciNavigation")]
    public string IPTAL_EDEN_KULLANICI_KODU { get; set; }

    /// <summary>Sağlık tesisinde düzenlenen adli raporun iptal edilmesi durumunda, belirtilen ip...</summary>
    [Required]
    public string ADLI_RAPOR_IPTAL_GEREKCESI { get; set; }

    /// <summary>Sağlık tesisinde işlemi gerçekleştiren veya işlemin sonucunu onaylayan kullanıcı...</summary>
    [Required]
    [ForeignKey("OnaylayanKullaniciNavigation")]
    public string ONAYLAYAN_KULLANICI_KODU { get; set; }

    /// <summary>Adli raporun onaylandığı zaman bilgisidir.</summary>
    public DateTime ADLI_RAPOR_ONAYLANMA_ZAMANI { get; set; }

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
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}