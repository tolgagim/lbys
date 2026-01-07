using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_HASTA_MALZEME tablosu - 32 kolon
/// </summary>
[Table("HASTA_MALZEME")]
public class HASTA_MALZEME
{
    /// <summary>Sağlık tesisinde hasta için kullanılan ilaç, malzeme, ürün vb. bilgiler için Sağ...</summary>
    [Key]
    public string HASTA_MALZEME_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık tesisinde bulunan ilaç, malzeme ve ürünlerin bilgilerine erişim sağlamak ...</summary>
    [ForeignKey("StokKartNavigation")]
    public string STOK_KART_KODU { get; set; }

    /// <summary>Sağlık tesisinde kullanılan malzemelerin ayrıntılı hareket bilgilerini takip etm...</summary>
    [ForeignKey("StokHareketNavigation")]
    public string STOK_HAREKET_KODU { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanan malzemeler için fatura kesilip kesilmediğine ...</summary>
    [ForeignKey("MalzemeFaturaDurumuNavigation")]
    public string MALZEME_FATURA_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde yapılan işlemlerin, uygulanmaya başladığı zaman bilgisidir.</summary>
    public DateTime? ISLEM_ZAMANI { get; set; }

    /// <summary>Hastaya uygulanan işlemin gerçekleşme zamanı bilgisidir.</summary>
    public DateTime? ISLEM_GERCEKLESME_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde kişiye aşı uygulanmadan önce Sağlık Bilgi Yönetim Sistemi taraf...</summary>
    [Required]
    public string ATS_SORGU_NUMARASI { get; set; }

    /// <summary>Vericinin uygun bir biçimde tanımlanmış ve bağışlanan materyalin izlenebilirliği...</summary>
    [Required]
    public string ALLOGREFT_DONOR_KODU { get; set; }

    /// <summary>Kişiye sağlık tesisinde kullanılan ilaç/sarf malzeme miktar bilgisidir.</summary>
    public string MALZEME_ADETI { get; set; }

    /// <summary>Sağlık tesisinde fatura edilen işlemler için adet bilgisidir.</summary>
    [Required]
    public string FATURA_ADET { get; set; }

    /// <summary>Sağlık tesisinde kesilen fatura kayıtlarına erişim için Sağlık Bilgi Yönetim Sis...</summary>
    [Required]
    [ForeignKey("FaturaNavigation")]
    public string FATURA_KODU { get; set; }

    /// <summary>Sağlık tesisi tarafından kesilen faturanın toplam tutar bilgisidir.</summary>
    [Required]
    public string FATURA_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanan hizmetler için hasta dosyasına kayıt edilen h...</summary>
    [Required]
    public string HASTA_TUTARI { get; set; }

    /// <summary>Hasta dosyasına işlenen işlemin hastanın sosyal güvencesinin bulunduğu kuruma ya...</summary>
    [Required]
    public string KURUM_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde tedavi gören hastaya yapılan işlem için MEDULA sisteminin ödeme...</summary>
    [Required]
    public string MEDULA_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde tedavi gören hastaların işlemlerine ait MEDULA tarafından Sağlı...</summary>
    [Required]
    public string MEDULA_ISLEM_SIRA_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde tedavi gören hastaların işlemlerine ait Sağlık Bilgi Yönetim Si...</summary>
    [Required]
    public string MEDULA_HIZMET_REF_NUMARASI { get; set; }

    /// <summary>Sağlık Yönetim Sistemi (SYS) Referans Numarası, sağlık tesisine başvuran hastala...</summary>
    [Required]
    public string SYS_REFERANS_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde tedavi gören hasta için, çeşitli kriterlere göre MEDULA tarafın...</summary>
    [Required]
    [ForeignKey("MedulaTakipNavigation")]
    public string MEDULA_TAKIP_KODU { get; set; }

    /// <summary>Sağlık tesisinde tedavi gören hastaların işlemlerine ait MEDULA tarafından tanım...</summary>
    [Required]
    public string MEDULA_OZEL_DURUM { get; set; }

    /// <summary>Sağlık tesisinde yapılan ameliyatın bilgilerine erişim sağlamak için Sağlık Bilg...</summary>
    [Required]
    [ForeignKey("AmeliyatNavigation")]
    public string AMELIYAT_KODU { get; set; }

    /// <summary>Sağlık tesisinde ilaç, malzeme, ürün vb. istemini yapan hekim için Sağlık Bilgi ...</summary>
    [ForeignKey("IsteyenHekimNavigation")]
    public string ISTEYEN_HEKIM_KODU { get; set; }

    /// <summary>Sağlık tesisinde bulunan stok depoları için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [ForeignKey("DepoNavigation")]
    public string DEPO_KODU { get; set; }

    /// <summary>Sağlık tesisinde yapılan bir işlemin iptal edilip edilmediği bilgisidir.</summary>
    public string IPTAL_DURUMU { get; set; }

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
    public virtual STOK_KART? StokKartNavigation { get; set; }
    public virtual STOK_HAREKET? StokHareketNavigation { get; set; }
    public virtual REFERANS_KODLAR? MalzemeFaturaDurumuNavigation { get; set; }
    public virtual FATURA? FaturaNavigation { get; set; }
    public virtual MEDULA_TAKIP? MedulaTakipNavigation { get; set; }
    public virtual AMELIYAT? AmeliyatNavigation { get; set; }
    public virtual PERSONEL? IsteyenHekimNavigation { get; set; }
    public virtual DEPO? DepoNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}