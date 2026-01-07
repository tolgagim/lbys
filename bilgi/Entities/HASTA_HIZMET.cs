using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// HASTA_HIZMET tablosu - 46 kolon
/// </summary>
[Table("HASTA_HIZMET")]
public class HASTA_HIZMET
{
    /// <summary>Sağlık tesisinde hastaya uygulanacak hizmetler için Sağlık Bilgi Yönetim Sistemi...</summary>
    [Key]
    public string HASTA_HIZMET_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanan işlemler için Sağlık Bilgi Yönetim Sistemi ta...</summary>
    [ForeignKey("HizmetNavigation")]
    public string HIZMET_KODU { get; set; }

    /// <summary>Sağlık tesisinde doğum yapan hastaya ait bilgilerin kayıt edilmesi için Sağlık B...</summary>
    [Required]
    [ForeignKey("DogumNavigation")]
    public string DOGUM_KODU { get; set; }

    /// <summary>Sağlık tesisinde yapılan ameliyatın işlem bilgilerine erişim sağlamak için Sağlı...</summary>
    [Required]
    [ForeignKey("AmeliyatIslemNavigation")]
    public string AMELIYAT_ISLEM_KODU { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanacak hizmetlerin anlık durum bilgisini ifade ede...</summary>
    [ForeignKey("HastaHizmetDurumuNavigation")]
    public string HASTA_HIZMET_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanan işlemler için fatura kesilip kesilmediğine il...</summary>
    [ForeignKey("HizmetFaturaDurumuNavigation")]
    public string HIZMET_FATURA_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde sağlık hizmetini alan kişi için yapılan işlemlere ilişkin puan ...</summary>
    [Required]
    [ForeignKey("TibbiIslemPuanBilgisiNavigation")]
    public string TIBBI_ISLEM_PUAN_BILGISI { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanan işlemin vücudun hangi tarafına yapıldığına il...</summary>
    [Required]
    [ForeignKey("TarafBilgisiNavigation")]
    public string TARAF_BILGISI { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanan işlemler için hasta dosyasına işlenen işlemin...</summary>
    [Required]
    public string HIZMET_PUAN_BILGISI { get; set; }

    /// <summary>Hastaya uygulanan işlemin gerçekleşme zamanı bilgisidir.</summary>
    public DateTime ISLEM_GERCEKLESME_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde uygulanan tetkik ve tedaviye ilişkin puanların hekimin performa...</summary>
    public DateTime PUAN_HAKEDIS_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde yapılan işlemlerin, uygulanmaya başladığı zaman bilgisidir.</summary>
    public DateTime? ISLEM_ZAMANI { get; set; }

    /// <summary>Kişinin randevu zamanı bilgisidir.</summary>
    public DateTime RANDEVU_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde bulunan cihaza Malzeme Kaynak Yönetim Sisteminde tanımlanmış ol...</summary>
    [Required]
    public string CIHAZ_KUNYE_NUMARASI { get; set; }

    /// <summary>Kişiye sağlık tesisinde uygulanan hizmetlerin sayı bilgisidir.</summary>
    public string HIZMET_ADETI { get; set; }

    /// <summary>Sağlık tesisinde fatura edilen işlemler için adet bilgisidir.</summary>
    [Required]
    public string FATURA_ADET { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanan hizmetler için hasta dosyasına kayıt edilen h...</summary>
    [Required]
    public string HASTA_TUTARI { get; set; }

    /// <summary>Hasta dosyasına işlenen işlemin hastanın sosyal güvencesinin bulunduğu kuruma ya...</summary>
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

    /// <summary>Sağlık tesisinde işlemi gerçekleştiren veya işlemin sonucunu onaylayan hekim içi...</summary>
    [Required]
    [ForeignKey("OnaylayanHekimNavigation")]
    public string ONAYLAYAN_HEKIM_KODU { get; set; }

    /// <summary>Sağlık tesisinde ilaç, malzeme, ürün vb. istemini yapan hekim için Sağlık Bilgi ...</summary>
    [Required]
    [ForeignKey("IsteyenHekimNavigation")]
    public string ISTEYEN_HEKIM_KODU { get; set; }

    /// <summary>Sağlık tesisinde kesilen fatura kayıtlarına erişim için Sağlık Bilgi Yönetim Sis...</summary>
    [Required]
    [ForeignKey("FaturaNavigation")]
    public string FATURA_KODU { get; set; }

    /// <summary>Sağlık tesisi tarafından kesilen faturanın toplam tutar bilgisidir.</summary>
    [Required]
    public string FATURA_TUTARI { get; set; }

    /// <summary>Sağlık tesisi tarafından hastaya takılan kan ürünleri için Kızılay tarafından ür...</summary>
    [Required]
    public string ISBT_UNITE_NUMARASI { get; set; }

    /// <summary>Sağlık tesisi tarafından hastaya takılan kan ürünleri için Kızılay tarafından ür...</summary>
    [Required]
    public string ISBT_BILESEN_NUMARASI { get; set; }

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
    public virtual HIZMET? HizmetNavigation { get; set; }
    public virtual DOGUM? DogumNavigation { get; set; }
    public virtual AMELIYAT_ISLEM? AmeliyatIslemNavigation { get; set; }
    public virtual REFERANS_KODLAR? HastaHizmetDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? HizmetFaturaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? TibbiIslemPuanBilgisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? TarafBilgisiNavigation { get; set; }
    public virtual MEDULA_TAKIP? MedulaTakipNavigation { get; set; }
    public virtual PERSONEL? OnaylayanHekimNavigation { get; set; }
    public virtual PERSONEL? IsteyenHekimNavigation { get; set; }
    public virtual FATURA? FaturaNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}