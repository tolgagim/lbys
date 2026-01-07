using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_COCUK_DIYABET tablosu - 29 kolon
/// </summary>
[Table("COCUK_DIYABET")]
public class COCUK_DIYABET
{
    /// <summary>Sağlık tesisinde bulunan cihaz için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [Key]
    public string COCUK_DIYABET_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Hastaya izlem ve tedavi uygulanacak olan hastalık (diyabetis mellitus, kanser, H...</summary>
    public DateTime? ILK_TANI_TARIHI { get; set; }

    /// <summary>Kişinin (gram cinsinden) ağırlığı bilgisidir.</summary>
    [Required]
    public string AGIRLIK { get; set; }

    /// <summary>Kişinin santimetre cinsinden boy bilgisidir.</summary>
    [Required]
    public string BOY { get; set; }

    /// <summary>Kişinin diyabet tipi bilgisidir.</summary>
    [ForeignKey("DiyabetTipiNavigation")]
    public string DIYABET_TIPI { get; set; }

    /// <summary>Kız çocuğuna ait menarş yaşı bilgisidir.</summary>
    [Required]
    public string KIZ_COCUKLARDA_MENARS_YASI { get; set; }

    /// <summary>Kişide beyin ödemi olup olmadığına ilişkin bilgiyi ifade eder.</summary>
    [ForeignKey("BeyinOdemiDurumuNavigation")]
    public string BEYIN_ODEMI_DURUMU { get; set; }

    /// <summary>Kişide son 3 ay içerisinde ketoasidoz gelişip gelişmediğine ait bilgidir.</summary>
    [ForeignKey("KetoasidozDurumuNavigation")]
    public string KETOASIDOZ_DURUMU { get; set; }

    /// <summary>Çocuğun diyabet hastalığına ilişkin şikayet bilgilerini ifade eder.</summary>
    [Required]
    [ForeignKey("DiyabetSikayetNavigation")]
    public string DIYABET_SIKAYET { get; set; }

    /// <summary>Çocuğun diyabet şikayetlerine ilişkin süre bilgisidir.</summary>
    [Required]
    public string SIKAYETIN_SURESI { get; set; }

    /// <summary>Çocuğun aksiller kıllanmasına ait durum bilgisidir.</summary>
    [Required]
    [ForeignKey("AksillerKillanmaDurumuNavigation")]
    public string AKSILLER_KILLANMA_DURUMU { get; set; }

    /// <summary>Çocuğun pubik kıllanmasına ait durum bilgisidir.</summary>
    [Required]
    [ForeignKey("PubikKillanmaDurumuNavigation")]
    public string PUBIK_KILLANMA_DURUMU { get; set; }

    /// <summary>Çocuğun meme gelişim evresine ait durum bilgisidir.</summary>
    [Required]
    [ForeignKey("MemeEvreNavigation")]
    public string MEME_EVRE { get; set; }

    /// <summary>Sağ testisin ml cinsinden hacim bilgisini ifade eder.</summary>
    [Required]
    public string TESTIS_VOLUM_SAG { get; set; }

    /// <summary>Sol testisin ml cinsinden hacim bilgisini ifade eder.</summary>
    [Required]
    public string TESTIS_VOLUM_SOL { get; set; }

    /// <summary>Çocuğun eşlik eden başka hastalık bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("EslikedenHastalikNavigation")]
    public string ESLIKEDEN_HASTALIK { get; set; }

    /// <summary>Çocuğun eşlik eden başka hastalık tanı tarihi bilgisini ifade eder.</summary>
    public DateTime ESLIKEDEN_HASTALIK_TANI_TARIHI { get; set; }

    /// <summary>Çocuğa uygulanan ilaç tedavi şekline ait bilgiyi ifade eder.</summary>
    [ForeignKey("DiyabetIlacTedaviSekliNavigation")]
    public string DIYABET_ILAC_TEDAVI_SEKLI { get; set; }

    /// <summary>Çocuğun diyet tedavisi durum bilgisini ifade eder.</summary>
    [ForeignKey("DiyetTibbiBeslenmeTedavisiNavigation")]
    public string DIYET_TIBBI_BESLENME_TEDAVISI { get; set; }

    /// <summary>Çocuğun diyabet hastası olan aile bireyi bilgisidir.</summary>
    [ForeignKey("DiyabetliHastaAileOykusuNavigation")]
    public string DIYABETLI_HASTA_AILE_OYKUSU { get; set; }

    /// <summary>Hastaya diyabet eğitim verilip verilmediği bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("DiyabetEgitimiVerilmeDurumuNavigation")]
    public string DIYABET_EGITIMI_VERILME_DURUMU { get; set; }

    /// <summary>Tiroid muayenesi sonucuna ilişkin ait bilgiyi ifade eder.</summary>
    [ForeignKey("TiroidMuayenesiNavigation")]
    public string TIROID_MUAYENESI { get; set; }

    /// <summary>Diyabet hastaliginin mikro ve makrovasküler komplikasyonlarini ifade eder.</summary>
    [Required]
    [ForeignKey("DiyabetKomplikasyonlariNavigation")]
    public string DIYABET_KOMPLIKASYONLARI { get; set; }

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
    public virtual REFERANS_KODLAR? DiyabetTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? BeyinOdemiDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? KetoasidozDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyabetSikayetNavigation { get; set; }
    public virtual REFERANS_KODLAR? AksillerKillanmaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? PubikKillanmaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? MemeEvreNavigation { get; set; }
    public virtual REFERANS_KODLAR? EslikedenHastalikNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyabetIlacTedaviSekliNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyetTibbiBeslenmeTedavisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyabetliHastaAileOykusuNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyabetEgitimiVerilmeDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? TiroidMuayenesiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyabetKomplikasyonlariNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}