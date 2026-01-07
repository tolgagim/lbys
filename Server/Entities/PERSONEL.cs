using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_PERSONEL tablosu - 146 kolon
/// </summary>
[Table("PERSONEL")]
public class PERSONEL
{
    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [Key]
    public string PERSONEL_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Kişinin adı bilgisidir.</summary>
    public string AD { get; set; }

    /// <summary>Sağlık hizmeti alan kişinin kimlik belgesinde yer alan soyadıdır.</summary>
    public string SOYADI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin önceki soyadı bilgisidir.</summary>
    [Required]
    public string ONCEKI_SOYADI { get; set; }

    /// <summary>Kişinin resmi doğum tarihini ifade eder.</summary>
    public DateTime DOGUM_TARIHI { get; set; }

    /// <summary>Kişinin doğum yeri bilgisidir.</summary>
    [Required]
    public string DOGUM_YERI { get; set; }

    /// <summary>Kişinin cinsiyetini ifade eder.</summary>
    [ForeignKey("CinsiyetNavigation")]
    public string CINSIYET { get; set; }

    /// <summary>Kişinin anne adı bilgisidir.</summary>
    [Required]
    public string ANNE_ADI { get; set; }

    /// <summary>Kişinin baba adı bilgisidir.</summary>
    [Required]
    public string BABA_ADI { get; set; }

    /// <summary>Kişinin ev telefonu bilgisidir.</summary>
    [Required]
    public string EV_TELEFONU { get; set; }

    /// <summary>Kişinin cep telefonu bilgisidir.</summary>
    [Required]
    public string CEP_TELEFONU { get; set; }

    /// <summary>Kişinin elektronik posta adresidir.</summary>
    [Required]
    public string EPOSTA_ADRESI { get; set; }

    /// <summary>Kişinin en son bitirdiği okul seviyesini veya okuryazarlık durumunu ifade eder. ...</summary>
    [Required]
    [ForeignKey("OgrenimDurumuNavigation")]
    public string OGRENIM_DURUMU { get; set; }

    /// <summary>Kişiyi niteleyen eşsiz numaradır.</summary>
    [Required]
    public string TC_KIMLIK_NUMARASI { get; set; }

    /// <summary>Kişinin kan grubunu ifade eder</summary>
    [Required]
    [ForeignKey("KanGrubuNavigation")]
    public string KAN_GRUBU { get; set; }

    /// <summary>Sağlık hizmetini almak için sağlık tesisine başvuran kişinin vatandaşı olduğu ül...</summary>
    [Required]
    [ForeignKey("UlkeNavigation")]
    public string ULKE_KODU { get; set; }

    /// <summary>Kişiye ait kayıt altına alınacak adresin tipini ifade eder.</summary>
    [Required]
    [ForeignKey("AdresTipiNavigation")]
    public string ADRES_TIPI { get; set; }

    /// <summary>Adres kodunun hangi seviyeden seçildiğini ifade eder.</summary>
    [Required]
    [ForeignKey("AdresSeviyesiNavigation")]
    public string ADRES_KODU_SEVIYESI { get; set; }

    /// <summary>Kişinin açık adresidir.</summary>
    [Required]
    public string ACIK_ADRES { get; set; }

    /// <summary>İl kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("IlNavigation")]
    public string IL_KODU { get; set; }

    /// <summary>İlçe kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("IlceNavigation")]
    public string ILCE_KODU { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin sicil numarasını ifade eder.</summary>
    [Required]
    public string PERSONEL_SICIL_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin emekli sicil numarası bilgisidir.</summary>
    [Required]
    public string EMEKLI_SICIL_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin askerlik durumuna ilişkin bilgiyi ifade eder...</summary>
    [Required]
    [ForeignKey("AskerlikDurumuNavigation")]
    public string ASKERLIK_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde bulunan kliniklerin Sağlık Bilgi Yönetim Sistemi tarafından gru...</summary>
    [Required]
    [ForeignKey("KlinikNavigation")]
    public string KLINIK_KODU { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin tescil numarası bilgisidir.</summary>
    [Required]
    public string TESCIL_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin diploma numarası bilgisidir.</summary>
    [Required]
    public string DIPLOMA_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde bulunan klinik ve hekimler için MEDULA tarafından tanımlanmış b...</summary>
    [Required]
    public string MEDULA_BRANS_KODU { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin anlık olarak çalışma durumunu ifade eder. Ör...</summary>
    [Required]
    [ForeignKey("CalismaDurumuNavigation")]
    public string CALISMA_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin biyolog, çevre sağlık teknisyeni, uzman heki...</summary>
    [ForeignKey("UnvanNavigation")]
    public string UNVAN_KODU { get; set; }

    /// <summary>Sağlık tesisinde görevli personel için görevini tanımlayan kod bilgisidir.</summary>
    [Required]
    [ForeignKey("PersonelGorevNavigation")]
    public string PERSONEL_GOREV_KODU { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin sağlık tesisinde çalışma şeklini ifade eder....</summary>
    [Required]
    [ForeignKey("IsDurumuNavigation")]
    public string IS_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin kadro türünü belirleyen bilgiyi ifade eder. ...</summary>
    [ForeignKey("MemuriyetTipiNavigation")]
    public string MEMURIYET_TIPI { get; set; }

    /// <summary>Personelin sağlık tesisinde işe başladığı tarih bilgisidir.</summary>
    public DateTime? SAGLIK_TESISINE_BASLAMA_TARIHI { get; set; }

    /// <summary>Sağlık tesisinde görev yapan personelin asaletini aldığı tarih bilgisidir.</summary>
    public DateTime ASALET_ALMA_TARIHI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin terfi aldığı tarih bilgisidir.</summary>
    public DateTime TERFI_TARIHI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin emekli terfi tarihi bilgisidir.</summary>
    public DateTime EMEKLI_TERFI_TARIHI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin ilk işe başlama tarihi bilgisidir.</summary>
    public DateTime? ILK_ISE_BASLAMA_TARIHI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin işten ayrılma açıklama bilgisidir.</summary>
    public DateTime ISTEN_AYRILMA_TARIHI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin işten ayrılma nedenine ait Sağlık Bilgi Yöne...</summary>
    [Required]
    [ForeignKey("IstenAyrilmaNedeniNavigation")]
    public string ISTEN_AYRILMA_NEDENI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin işten ayrılma açıklama bilgisidir.</summary>
    [Required]
    public string ISTEN_AYRILMA_ACIKLAMASI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin memuriyete başlama tarihi bilgisidir.</summary>
    public DateTime MEMURIYETE_BASLAMA_TARIHI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin kadro unvan bilgisidir.</summary>
    [Required]
    [ForeignKey("KadroUnvanNavigation")]
    public string KADRO_UNVAN_KODU { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin imzasında bulunan unvanının Sağlık Bilgi Yön...</summary>
    [Required]
    [ForeignKey("ImzaUnvanNavigation")]
    public string IMZA_UNVAN_KODU { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin akademik unvanını belirten bilgidir. Örneğin...</summary>
    [Required]
    [ForeignKey("AkademikUnvanNavigation")]
    public string AKADEMIK_UNVAN { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin görev yaptığı birimi ifade eden Sağlık Bilgi...</summary>
    [Required]
    [ForeignKey("CalistigiBirimNavigation")]
    public string CALISTIGI_BIRIM_KODU { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin kadrosunun bulunduğu kurum bilgisidir.</summary>
    [Required]
    [ForeignKey("KadroluGorevYeriNavigation")]
    public string KADROLU_GOREV_YERI { get; set; }

    /// <summary>Sağlık tesisine başvuran kişinin engellilik durumunu ifade eder. Örneğin bedense...</summary>
    [Required]
    [ForeignKey("EngellilikDurumuNavigation")]
    public string ENGELLILIK_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde devlet hizmet yükümlüsü olarak çalışan personel için Sağlık Bil...</summary>
    [Required]
    public string DEVLET_HIZMET_YUKUMLULUK_KODU { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi veri tabanında bulunan bir kayıtın aktif olup olmad...</summary>
    [Required]
    public string AKTIFLIK_BILGISI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin dosyası için veya sağlık tesisine müracat et...</summary>
    [Required]
    public string FOTOGRAF_BILGISI { get; set; }

    /// <summary>Kişiye ait fotoğrafın Sağlık Bilgi Yönetim Sistemi'ne kayıt edildiği dosyanın ad...</summary>
    [Required]
    public string FOTOGRAF_DOSYA_YOLU { get; set; }

    /// <summary>Sağlık tesisinde görevli hekim için MEDULA sisteminde tanımlanmış kullanıcı şifr...</summary>
    [Required]
    public string HEKIM_MEDULA_SIFRESI { get; set; }

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
    public virtual REFERANS_KODLAR? CinsiyetNavigation { get; set; }
    public virtual REFERANS_KODLAR? OgrenimDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanGrubuNavigation { get; set; }
    public virtual REFERANS_KODLAR? UlkeNavigation { get; set; }
    public virtual REFERANS_KODLAR? AdresTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? AdresSeviyesiNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlceNavigation { get; set; }
    public virtual REFERANS_KODLAR? AskerlikDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? KlinikNavigation { get; set; }
    public virtual REFERANS_KODLAR? CalismaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? UnvanNavigation { get; set; }
    public virtual REFERANS_KODLAR? PersonelGorevNavigation { get; set; }
    public virtual REFERANS_KODLAR? IsDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? MemuriyetTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? IstenAyrilmaNedeniNavigation { get; set; }
    public virtual REFERANS_KODLAR? KadroUnvanNavigation { get; set; }
    public virtual REFERANS_KODLAR? ImzaUnvanNavigation { get; set; }
    public virtual REFERANS_KODLAR? AkademikUnvanNavigation { get; set; }
    public virtual BIRIM? CalistigiBirimNavigation { get; set; }
    public virtual REFERANS_KODLAR? KadroluGorevYeriNavigation { get; set; }
    public virtual REFERANS_KODLAR? EngellilikDurumuNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}