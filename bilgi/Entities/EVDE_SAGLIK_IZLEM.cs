using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// EVDE_SAGLIK_IZLEM tablosu - 31 kolon
/// </summary>
[Table("EVDE_SAGLIK_IZLEM")]
public class EVDE_SAGLIK_IZLEM
{
    /// <summary>Evde sağlık hizmeti alan kişilerin izlem bilgileri için Sağlık Bilgi Yönetim Sis...</summary>
    [Key]
    public string EVDE_SAGLIK_IZLEM_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı tablo adı bilgisidir.</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Kişinin ağrı hissedip hissetmediğini gösterir.</summary>
    [Required]
    [ForeignKey("AgriNavigation")]
    public string AGRI { get; set; }

    /// <summary>Yaşanılan alanın aydınlanma durumunu tanımlar.</summary>
    [Required]
    [ForeignKey("AydinlatmaNavigation")]
    public string AYDINLATMA { get; set; }

    /// <summary>Evde sağlık hizmeti almak için, kişinin tıbbi bakım, sosyal hizmet, destek ve ya...</summary>
    [Required]
    [ForeignKey("BakimVeDestekIhtiyaciNavigation")]
    public string BAKIM_VE_DESTEK_IHTIYACI { get; set; }

    /// <summary>Braden skalasına göre hastada bası durumunu gösterir.</summary>
    [Required]
    [ForeignKey("BasiDegerlendirmesiNavigation")]
    public string BASI_DEGERLENDIRMESI { get; set; }

    /// <summary>Evde sağlık hizmetinden yararlanmak amacı ile başvurulan kurumu tanımlar.</summary>
    [ForeignKey("BasvuruTuruNavigation")]
    public string BASVURU_TURU { get; set; }

    /// <summary>Kişinin beslenme durumunu tanımlar.</summary>
    [Required]
    [ForeignKey("BeslenmeNavigation")]
    public string BESLENME { get; set; }

    /// <summary>Evde Sağlık Hizmeti (ESH) verilen hastaların, hastalık gruplarını ifade eder.</summary>
    [Required]
    [ForeignKey("EshEsasHastalikGrubuNavigation")]
    public string ESH_ESAS_HASTALIK_GRUBU { get; set; }

    /// <summary>Kişinin yaşadığı alanın hijyen şartlarını tanımlar.</summary>
    [Required]
    [ForeignKey("EvHijyeniNavigation")]
    public string EV_HIJYENI { get; set; }

    /// <summary>Evde sağlık hizmetini alan kişiler için alınan güvenlik önlemlerinin yeterli olu...</summary>
    [Required]
    [ForeignKey("GuvenlikNavigation")]
    public string GUVENLIK { get; set; }

    /// <summary>Kişinin barındığı alandaki ısınma tipini ifade eder.</summary>
    [Required]
    [ForeignKey("IsinmaNavigation")]
    public string ISINMA { get; set; }

    /// <summary>Kişinin kendi ihtiyaçlarını karşılama durumunu tanımlar.</summary>
    [Required]
    [ForeignKey("KisiselBakimNavigation")]
    public string KISISEL_BAKIM { get; set; }

    /// <summary>Kişinin kendine bakım durumunu ifade eder.</summary>
    [Required]
    [ForeignKey("KisiselHijyenNavigation")]
    public string KISISEL_HIJYEN { get; set; }

    /// <summary>Kişinin ikamet ettiği alanı tanımlar.</summary>
    [Required]
    [ForeignKey("KonutTipiNavigation")]
    public string KONUT_TIPI { get; set; }

    /// <summary>Meskenin hela tipini tanımlar.</summary>
    [Required]
    [ForeignKey("KullanilanHelaTipiNavigation")]
    public string KULLANILAN_HELA_TIPI { get; set; }

    /// <summary>Hizmet alan kişinin yatağa bağımlılık durumunu tanımlar.</summary>
    [Required]
    [ForeignKey("YatagaBagimlilikNavigation")]
    public string YATAGA_BAGIMLILIK { get; set; }

    /// <summary>Kişinin hareketi için kullanılan yardımcı araçları ifade eder.</summary>
    [Required]
    [ForeignKey("KullandigiYardimciAraclarNavigation")]
    public string KULLANDIGI_YARDIMCI_ARACLAR { get; set; }

    /// <summary>Kişinin psikolojik durumu hakkında genel bilgi verir.</summary>
    [Required]
    [ForeignKey("PsikolojikDurumDegerlendirmeNavigation")]
    public string PSIKOLOJIK_DURUM_DEGERLENDIRME { get; set; }

    /// <summary>Evde Sağlık Hizmeti (ESH) verilen hastalarda, sağlık hizmetinin herhangi bir ned...</summary>
    [Required]
    [ForeignKey("EshSonlandirilmasiNavigation")]
    public string ESH_SONLANDIRILMASI { get; set; }

    /// <summary>Evde Sağlık Hizmeti (ESH) verilen hastaların herhangi bir sağlık tesisine nakil ...</summary>
    [Required]
    [ForeignKey("EshHastaNakliNavigation")]
    public string ESH_HASTA_NAKLI { get; set; }

    /// <summary>Evde sağlık hizmetinin alındığı il bilgisidir.</summary>
    [Required]
    [ForeignKey("EshAlinacakIlNavigation")]
    public string ESH_ALINACAK_IL { get; set; }

    /// <summary>Kişiye verilmesi planlanan hizmet türü bilgisidir. Örneğin aile hekimi değerlend...</summary>
    [Required]
    [ForeignKey("BirSonrakiHizmetIhtiyaciNavigation")]
    public string BIR_SONRAKI_HIZMET_IHTIYACI { get; set; }

    /// <summary>Sağlık tesisinde görevli personel tarafından verilen eğitimin bilgisidir. Örneği...</summary>
    [Required]
    [ForeignKey("VerilenEgitimlerNavigation")]
    public string VERILEN_EGITIMLER { get; set; }

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
    public virtual REFERANS_KODLAR? AgriNavigation { get; set; }
    public virtual REFERANS_KODLAR? AydinlatmaNavigation { get; set; }
    public virtual REFERANS_KODLAR? BakimVeDestekIhtiyaciNavigation { get; set; }
    public virtual REFERANS_KODLAR? BasiDegerlendirmesiNavigation { get; set; }
    public virtual REFERANS_KODLAR? BasvuruTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? BeslenmeNavigation { get; set; }
    public virtual REFERANS_KODLAR? EshEsasHastalikGrubuNavigation { get; set; }
    public virtual REFERANS_KODLAR? EvHijyeniNavigation { get; set; }
    public virtual REFERANS_KODLAR? GuvenlikNavigation { get; set; }
    public virtual REFERANS_KODLAR? IsinmaNavigation { get; set; }
    public virtual REFERANS_KODLAR? KisiselBakimNavigation { get; set; }
    public virtual REFERANS_KODLAR? KisiselHijyenNavigation { get; set; }
    public virtual REFERANS_KODLAR? KonutTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? KullanilanHelaTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? YatagaBagimlilikNavigation { get; set; }
    public virtual REFERANS_KODLAR? KullandigiYardimciAraclarNavigation { get; set; }
    public virtual REFERANS_KODLAR? PsikolojikDurumDegerlendirmeNavigation { get; set; }
    public virtual REFERANS_KODLAR? EshSonlandirilmasiNavigation { get; set; }
    public virtual REFERANS_KODLAR? EshHastaNakliNavigation { get; set; }
    public virtual REFERANS_KODLAR? EshAlinacakIlNavigation { get; set; }
    public virtual REFERANS_KODLAR? BirSonrakiHizmetIhtiyaciNavigation { get; set; }
    public virtual REFERANS_KODLAR? VerilenEgitimlerNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}