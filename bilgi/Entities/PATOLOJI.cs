using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// PATOLOJI tablosu - 37 kolon
/// </summary>
[Table("PATOLOJI")]
public class PATOLOJI
{
    /// <summary>Patoloji tetkikleri için Sağlık Bilgi Yönetim Sistemi tarafından üretilen tekil ...</summary>
    [Key]
    public string PATOLOJI_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Patoloji biriminde hastaya yazılan rapor için Sağlık Bilgi Yönetim Sistemi taraf...</summary>
    [Required]
    [ForeignKey("PatolojiRaporTuruNavigation")]
    public string PATOLOJI_RAPOR_TURU { get; set; }

    /// <summary>Patoloji için hastadan alınan numunenin alındığı dokunun temel özellik bilgisidi...</summary>
    [Required]
    [ForeignKey("DokununTemelOzelligiNavigation")]
    public string DOKUNUN_TEMEL_OZELLIGI { get; set; }

    /// <summary>Sağlık tesisinde kişiden alınan numunenin nasıl alındığına ilişkin bilgiyi ifade...</summary>
    [Required]
    [ForeignKey("NumuneAlinmaSekliNavigation")]
    public string NUMUNE_ALINMA_SEKLI { get; set; }

    /// <summary>Patoloji tetkiki için alınan preparatın durum bilgidir. Örneğin materyal yeterli...</summary>
    [Required]
    [ForeignKey("PatolojiPreparatiDurumuNavigation")]
    public string PATOLOJI_PREPARATI_DURUMU { get; set; }

    /// <summary>Sağlık tesisindeki patoloji biriminde hasta bilgilerinin olduğu defter numarası ...</summary>
    [Required]
    public string PATOLOJI_DEFTER_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde yapılan tetkiklerde kullanılan numuneler için Sağlık Bilgi Yöne...</summary>
    [ForeignKey("TetkikNumuneNavigation")]
    public string TETKIK_NUMUNE_KODU { get; set; }

    /// <summary>Sağlık tesisinde incelenmek için hastadan alınan numunenin materyal bilgisidir.</summary>
    [Required]
    public string PATOLOJI_MATERYALI { get; set; }

    /// <summary>Parçanın alındığı organ bilgisidir.</summary>
    [Required]
    public string ORGAN { get; set; }

    /// <summary>Sağlık tesisinde kişiden alınan numunenin nasıl alındığına ilişkin bilgiyi ifade...</summary>
    [Required]
    [ForeignKey("NumuneAlinmaYeriNavigation")]
    public string NUMUNE_ALINMA_YERI { get; set; }

    /// <summary>Sağlık tesisine başvuran kişiden alınan materyalin patolojik incelemesi sonucu e...</summary>
    [Required]
    public string PATOLOJIK_BULGU { get; set; }

    /// <summary>ICD-O Morfoloji kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("PatolojikTaniMorfolojiNavigation")]
    public string PATOLOJIK_TANI_MORFOLOJI_KODU { get; set; }

    /// <summary>Hastadan alınan patolojik dokunun vücutta bulunduğu yer için ICD-O yerleşim yeri...</summary>
    [Required]
    [ForeignKey("PatolojikTaniYerlesimYeriNavigation")]
    public string PATOLOJIK_TANI_YERLESIM_YERI { get; set; }

    /// <summary>Makroskopi sonuç bilgisidir.</summary>
    [Required]
    public string MAKROSKOPI_SONUCU { get; set; }

    /// <summary>Mikroskopi işlemi sonuç bilgisidir.</summary>
    [Required]
    public string MIKROSKOPI_SONUCU { get; set; }

    /// <summary>Raporun içeriğinin türüne ilişkin DOC, RTF, HTML vb. bilgiyi ifade eder.</summary>
    [ForeignKey("SonucIcerikTuruNavigation")]
    public string SONUC_ICERIK_TURU { get; set; }

    /// <summary>Raporu bilgisayar ortamına aktaran personel için Sağlık Bilgi Yönetim Sistemi ta...</summary>
    [Required]
    [ForeignKey("RaporYazanPersonelNavigation")]
    public string RAPOR_YAZAN_PERSONEL_KODU { get; set; }

    /// <summary>Hastadan alınan numunenin tetkikinin yapılması için laboratuvara kabul edildiği ...</summary>
    public DateTime PARCA_KABUL_ZAMANI { get; set; }

    /// <summary>Rapor zamanı bilgisidir.</summary>
    public DateTime RAPOR_ZAMANI { get; set; }

    /// <summary>Patoloji tetkiki için açıklama bilgisidir.</summary>
    [Required]
    public string PATOLOJI_ACIKLAMA { get; set; }

    /// <summary>Patoloji uzmanı tarafından yazılan tanı bilgisidir.</summary>
    [Required]
    public string HISTOPATOLOJIK_TANI { get; set; }

    /// <summary>Patoloji uzmanı tarafından yazılan tanı bilgisidir.</summary>
    [Required]
    public string SITOPATOLOJIK_TANI { get; set; }

    /// <summary>Patoloji numunesine uygulanan histokimyasal boyama yöntemi için uzman tarafından...</summary>
    [Required]
    public string HISTOKIMYASAL_BOYAMA { get; set; }

    /// <summary>Patoloji numunesinin immünhistokimya boyama işlemine göre elde edilen bilgidir.</summary>
    [Required]
    public string IMMUNHISTOKIMYA_BOYAMA { get; set; }

    /// <summary>Kişiden ameliyat sırasında alınan doku örneğine kısa süre içerisinde tanı koymak...</summary>
    [Required]
    public string FROZEN_TANI { get; set; }

    /// <summary>Numunenin hangi yöntemle boyandığı bilgisidir.</summary>
    [Required]
    public string NUMUNE_BOYAMA_YONTEMI { get; set; }

    /// <summary>Sağlık tesisinde işlemi gerçekleştiren veya işlemin sonucunu onaylayan hekim içi...</summary>
    [Required]
    [ForeignKey("OnaylayanHekimNavigation")]
    public string ONAYLAYAN_HEKIM_KODU { get; set; }

    /// <summary>Sağlık tesisinde sağlık hizmetini alan kişiyi muayene eden asistan hekimin Sağlı...</summary>
    [Required]
    [ForeignKey("AsistanHekimNavigation")]
    public string ASISTAN_HEKIM_KODU { get; set; }

    /// <summary>Patoloji tetkik sonucunu değerlendiren diğer hekim için Sağlık Bilgi Yönetim Sis...</summary>
    [Required]
    [ForeignKey("PatolojiDigerHekimNavigation")]
    public string PATOLOJI_DIGER_HEKIM_KODU { get; set; }

    /// <summary>Sağlık tesisinde uzman hekimin yazdığı yorum bilgisidir.</summary>
    [Required]
    public string YORUM { get; set; }

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
    public virtual REFERANS_KODLAR? PatolojiRaporTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? DokununTemelOzelligiNavigation { get; set; }
    public virtual REFERANS_KODLAR? NumuneAlinmaSekliNavigation { get; set; }
    public virtual REFERANS_KODLAR? PatolojiPreparatiDurumuNavigation { get; set; }
    public virtual TETKIK_NUMUNE? TetkikNumuneNavigation { get; set; }
    public virtual REFERANS_KODLAR? NumuneAlinmaYeriNavigation { get; set; }
    public virtual REFERANS_KODLAR? PatolojikTaniMorfolojiNavigation { get; set; }
    public virtual REFERANS_KODLAR? PatolojikTaniYerlesimYeriNavigation { get; set; }
    public virtual REFERANS_KODLAR? SonucIcerikTuruNavigation { get; set; }
    public virtual PERSONEL? RaporYazanPersonelNavigation { get; set; }
    public virtual PERSONEL? OnaylayanHekimNavigation { get; set; }
    public virtual PERSONEL? AsistanHekimNavigation { get; set; }
    public virtual PERSONEL? PatolojiDigerHekimNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}