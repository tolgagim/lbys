using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_ASI_BILGISI tablosu - 27 kolon
/// </summary>
[Table("ASI_BILGISI")]
public class ASI_BILGISI
{
    /// <summary>Sağlık tesisinde aşılar ile ilgili işlemler (yapılan, ertelenen, iptal edilen aş...</summary>
    [Key]
    public string ASI_BILGISI_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı tablo adı bilgisidir.</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Aşı, aktif ve kazanılmış bağışıklığın sağlanması amacı ile canlı veya ölü mikroo...</summary>
    [ForeignKey("AsiNavigation")]
    public string ASI_KODU { get; set; }

    /// <summary>Aşının (antijenin) kaçıncı kez yapıldığını ifade eder.</summary>
    [ForeignKey("AsininDozuNavigation")]
    public string ASININ_DOZU { get; set; }

    /// <summary>Aşının uygulandığı yolu ifade eder.</summary>
    [ForeignKey("AsininUygulamaSekliNavigation")]
    public string ASININ_UYGULAMA_SEKLI { get; set; }

    /// <summary>Aşının uygulandığı anatomik bölgeyi ifade eder.</summary>
    [ForeignKey("AsiUygulamaYeriNavigation")]
    public string ASI_UYGULAMA_YERI { get; set; }

    /// <summary>Sağlık tesisinde kişiye aşı uygulanmadan önce Sağlık Bilgi Yönetim Sistemi taraf...</summary>
    [Required]
    public string ASI_SORGU_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde kayıt altına alınan aşı bilgisinin sağlık tesisinde yapılma bil...</summary>
    [ForeignKey("AsiIslemTuruNavigation")]
    public string ASI_ISLEM_TURU { get; set; }

    /// <summary>Bilgi alınan kişinin ad soyadı bilgisidir.</summary>
    [Required]
    public string BILGI_ALINAN_KISI_AD_SOYADI { get; set; }

    /// <summary>Bilgi alınan kişinin telefon numarası bilgisidir.</summary>
    [Required]
    public string BILGI_ALINAN_KISI_TELEFON { get; set; }

    /// <summary>Aşı yapılma zamanı bilgisidir.</summary>
    public DateTime? ASI_YAPILMA_ZAMANI { get; set; }

    /// <summary>Bir aşı takvime dahil olsa dahi kişinin sağlık sorunlarından dolayı aynı dozun b...</summary>
    [Required]
    [ForeignKey("AsiOzelDurumNedeniNavigation")]
    public string ASI_OZEL_DURUM_NEDENI { get; set; }

    /// <summary>Aşı Sonrası İstenmeyen Etki (ASİE) 'nin başladığı zamanı ifade eder.</summary>
    public DateTime ASIE_ORTAYA_CIKIS_ZAMANI { get; set; }

    /// <summary>Bildirimi Zorunlu Aşı Sonrası İstenmeyen Etki (ASİE) saptanması durumunda bunun ...</summary>
    [Required]
    [ForeignKey("AsieNedenleriNavigation")]
    public string ASIE_NEDENLERI { get; set; }

    /// <summary>Kişinin planlı aşısının kaç gün süre ile ertelendiği bilgisidir.</summary>
    [Required]
    public string ASI_ERTELEME_SURESI { get; set; }

    /// <summary>Aşının ertelenme/iptal edilme durumunu tanımlar. Örneğin ertelendi, iptal edildi...</summary>
    [Required]
    [ForeignKey("AsiYapilmamaDurumuNavigation")]
    public string ASI_YAPILMAMA_DURUMU { get; set; }

    /// <summary>Bebeğe/Çocuğa yapılması gereken ama ertelenen/iptal edilen aşının neden ertelend...</summary>
    [Required]
    [ForeignKey("AsiYapilmamaNedeniNavigation")]
    public string ASI_YAPILMAMA_NEDENI { get; set; }

    /// <summary>Aşının planlanan zamanda yapılmamasına neden olan hastalık bilgisidir.</summary>
    [Required]
    [ForeignKey("AlttaYatanHastalikNavigation")]
    public string ALTTA_YATAN_HASTALIK { get; set; }

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
    public virtual REFERANS_KODLAR? AsiNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsininDozuNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsininUygulamaSekliNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsiUygulamaYeriNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsiIslemTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsiOzelDurumNedeniNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsieNedenleriNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsiYapilmamaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsiYapilmamaNedeniNavigation { get; set; }
    public virtual REFERANS_KODLAR? AlttaYatanHastalikNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}