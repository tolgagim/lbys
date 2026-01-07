using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// TETKIK_SONUC tablosu - 38 kolon
/// </summary>
[Table("TETKIK_SONUC")]
public class TETKIK_SONUC
{
    /// <summary>Sağlık tesisinde yapılan tetkiklerin sonuçları için Sağlık Bilgi Yönetim Sistemi...</summary>
    [Key]
    public string TETKIK_SONUC_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde yapılan tetkiklerde kullanılan numuneler için Sağlık Bilgi Yöne...</summary>
    [ForeignKey("TetkikNumuneNavigation")]
    public string TETKIK_NUMUNE_KODU { get; set; }

    /// <summary>Sağlık tesisinde yapılan tetkiklerdeki parametreler için Sağlık Bilgi Yönetim Si...</summary>
    [Required]
    [ForeignKey("TetkikParametreNavigation")]
    public string TETKIK_PARAMETRE_KODU { get; set; }

    /// <summary>Sağlık tesisinde yapılan tetkikler için Sağlık Bilgi Yönetim Sistemi tarafından ...</summary>
    [ForeignKey("TetkikNavigation")]
    public string TETKIK_KODU { get; set; }

    /// <summary>Kişinin hastalığı veya durumu ile ilgili tanı ve tedaviye karar verme amacıyla y...</summary>
    public string TETKIK_ADI { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanacak hizmetler için Sağlık Bilgi Yönetim Sistemi...</summary>
    [ForeignKey("HastaHizmetNavigation")]
    public string HASTA_HIZMET_KODU { get; set; }

    /// <summary>Saglik tesisinde çalisilan tetkikler için tetkik sonuç degeri bilgisidir.</summary>
    public string TETKIK_SONUCU { get; set; }

    /// <summary>Sağlık tesisinde yapılan tetkikler için laboratuvar tetkik sonucunun, laboratuva...</summary>
    public DateTime SONUC_ZAMANI { get; set; }

    /// <summary>Hastaya ait tetkik sonucunun gizlenmesine ilişkin bilgiyi ifade eder.</summary>
    public string TETKIK_SONUC_GIZLENME_DURUMU { get; set; }

    /// <summary>Hastaya ait tetkik sonucunun web portallarında gizlenme durumu ifade eden bilgid...</summary>
    public string WEB_SONUC_GIZLENME_DURUMU { get; set; }

    /// <summary>Numunenin ret edilmesine ilişkin neden bilgisidir.</summary>
    [Required]
    [ForeignKey("NumuneRetNedeniNavigation")]
    public string NUMUNE_RET_NEDENI { get; set; }

    /// <summary>Ret işlemini gerçekleştiren Sağlık Bilgi Yönetim Sistemi kullanıcısı için Sağlık...</summary>
    [Required]
    [ForeignKey("RetEdenKullaniciNavigation")]
    public string RET_EDEN_KULLANICI_KODU { get; set; }

    /// <summary>Numunenin ret edildiği zaman bilgisidir.</summary>
    public DateTime RET_ZAMANI { get; set; }

    /// <summary>Kritik değer, tıbbi laboratuvar testinde, hasta için risk oluşturabilecek duruml...</summary>
    [Required]
    public string KRITIK_DEGER_ARALIGI { get; set; }

    /// <summary>Tetkikin tıbbi cihazda çalışılmaya başlandığı zaman bilgisidir.</summary>
    public DateTime CALISMA_BASLAMA_ZAMANI { get; set; }

    /// <summary>Tetkikin tıbbi cihazda çalışılmasının bittiği zaman bilgisidir.</summary>
    public DateTime CALISMA_BITIS_ZAMANI { get; set; }

    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [Required]
    [ForeignKey("OnaylayanTeknisyenNavigation")]
    public string ONAYLAYAN_TEKNISYEN_KODU { get; set; }

    /// <summary>Sağlık tesisinde teknisyenin tetkik sonucunu onayladığı zaman bilgisidir.</summary>
    public DateTime TEKNISYEN_ONAY_ZAMANI { get; set; }

    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [Required]
    [ForeignKey("OnaylayanHekimNavigation")]
    public string ONAYLAYAN_HEKIM_KODU { get; set; }

    /// <summary>Laboratuvarda yapılan tetkikin sonucunun uzman tarafından onaylandığı zaman bilg...</summary>
    public DateTime TETKIK_UZMAN_ONAY_ZAMANI { get; set; }

    /// <summary>LOINC, Sağlık tesisinde laboratuvar veya radyolojik tetkik sonuçlarının sınıflan...</summary>
    [Required]
    public string LOINC_KODU { get; set; }

    /// <summary>Tetkiki yapılan numunenin tekrar çalışılma (ReRun) durumuna ilişkin bilgiyi ifad...</summary>
    [Required]
    public string TEKRAR_CALISMA_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde çalışılan tetkikin sonuç bilgisinin Sağlık Bilgi Yönetim Sistem...</summary>
    [Required]
    public string MANUEL_TETKIK_SONUC_DURUMU { get; set; }

    /// <summary>Kültür tetkiklerinde bakteri üreme durumuna ilişkin bilgiyi ifade eder.</summary>
    [Required]
    public string UREME_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde bulunan cihaz için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [Required]
    [ForeignKey("CihazNavigation")]
    public string CIHAZ_KODU { get; set; }

    /// <summary>Sağlık tesisinde yapılan tetkikler için cihazlardan Sağlık Bilgi Yönetim Sistemi...</summary>
    [Required]
    public string CIHAZ_TETKIK_SONUCU { get; set; }

    /// <summary>Sağlık tesisinde yapılan tetkiklerin sonuç değerinin birim bilgisidir. Örneğin m...</summary>
    [Required]
    public string TETKIK_SONUCU_BIRIMI { get; set; }

    /// <summary>Sağlık tesisinde yapılan tetkiklerin sonucu için beklenen değer aralığı bilgisid...</summary>
    [Required]
    public string TETKIK_SONUCU_REFERANS_DEGERI { get; set; }

    /// <summary>Sağlık tesisinde yapılan tetkiklerin sonuç durumunu yüksek, alçak, panik durumu,...</summary>
    [Required]
    [ForeignKey("TetkikSonucuDurumuNavigation")]
    public string TETKIK_SONUCU_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde yapılan tetkiklerin sonucu ile ilgili açıklama bilgisidir.</summary>
    [Required]
    public string TETKIK_SONUC_ACIKLAMA { get; set; }

    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [Required]
    [ForeignKey("RaporYazanPersonelNavigation")]
    public string RAPOR_YAZAN_PERSONEL_KODU { get; set; }

    /// <summary>Laboratuvar sonuçlari için sonuç PDF erisim Linki, Görüntülü islem sonuçlari içi...</summary>
    [Required]
    public string SONUC_DIS_ERISIM_BILGISI { get; set; }

    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
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
    public virtual TETKIK_NUMUNE? TetkikNumuneNavigation { get; set; }
    public virtual TETKIK_PARAMETRE? TetkikParametreNavigation { get; set; }
    public virtual TETKIK? TetkikNavigation { get; set; }
    public virtual HASTA_HIZMET? HastaHizmetNavigation { get; set; }
    public virtual REFERANS_KODLAR? NumuneRetNedeniNavigation { get; set; }
    public virtual KULLANICI? RetEdenKullaniciNavigation { get; set; }
    public virtual PERSONEL? OnaylayanTeknisyenNavigation { get; set; }
    public virtual PERSONEL? OnaylayanHekimNavigation { get; set; }
    public virtual CIHAZ? CihazNavigation { get; set; }
    public virtual REFERANS_KODLAR? TetkikSonucuDurumuNavigation { get; set; }
    public virtual PERSONEL? RaporYazanPersonelNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}