using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_HASTA tablosu - 103 kolon
/// </summary>
[Table("HASTA")]
public class HASTA
{
    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [Key]
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Hastanın T.C. Kimlik Numarası bilgisidir.</summary>
    [Required]
    public string TC_KIMLIK_NUMARASI { get; set; }

    /// <summary>Herhangi bir tanımlayıcı bilgisi bulunmayan, yabancı hasta kimlik numarası veya ...</summary>
    [Required]
    public string KIMLIKSIZ_HASTA_BILGISI { get; set; }

    /// <summary>Sağlık hizmetini almak için sağlık tesisine başvuran kişinin uyruk bilgisidir. Ö...</summary>
    [Required]
    [ForeignKey("UyrukNavigation")]
    public string UYRUK { get; set; }

    /// <summary>Sağlık tesisine gelen kişinin vatandaşlık durumunu ifade eder. Örneğin vatandaş ...</summary>
    [ForeignKey("HastaTipiNavigation")]
    public string HASTA_TIPI { get; set; }

    /// <summary>Kişinin adı bilgisidir.</summary>
    public string AD { get; set; }

    /// <summary>Kişinin soyadı bilgisidir.</summary>
    public string SOYADI { get; set; }

    /// <summary>Hastanın doğum tarihi bilgisidir.</summary>
    public DateTime DOGUM_TARIHI { get; set; }

    /// <summary>Kişinin beyan doğum tarihini ifade eder.</summary>
    public DateTime BEYAN_DOGUM_TARIHI { get; set; }

    /// <summary>Kişinin doğum yeri bilgisidir.</summary>
    [Required]
    public string DOGUM_YERI { get; set; }

    /// <summary>Kişinin cinsiyetini ifade eder.</summary>
    [ForeignKey("CinsiyetNavigation")]
    public string CINSIYET { get; set; }

    /// <summary>Yeni doğanlar için anne T.C. Kimlik Numarası bilgisidir.</summary>
    [Required]
    public string ANNE_TC_KIMLIK_NUMARASI { get; set; }

    /// <summary>Yeni doğanlar için baba T.C. Kimlik Numarası bilgisidir.</summary>
    [Required]
    public string BABA_TC_KIMLIK_NUMARASI { get; set; }

    /// <summary>Kişinin annesinin daha önceden sağlık tesisine başvurduğunu gösterir Sağlık Bilg...</summary>
    [Required]
    [ForeignKey("AnneHastaNavigation")]
    public string ANNE_HASTA_KODU { get; set; }

    /// <summary>Kişinin babasının daha önceden sağlık tesisine başvurduğunu gösterir Sağlık Bilg...</summary>
    [Required]
    [ForeignKey("BabaHastaNavigation")]
    public string BABA_HASTA_KODU { get; set; }

    /// <summary>Yeni doğan bebeğin aynı gün aynı anneden doğan kaçıncı bebek olduğu bilgisidir.</summary>
    [Required]
    public string DOGUM_SIRASI { get; set; }

    /// <summary>Kişinin anne adı bilgisidir.</summary>
    [Required]
    public string ANNE_ADI { get; set; }

    /// <summary>Kişinin baba adı bilgisidir.</summary>
    [Required]
    public string BABA_ADI { get; set; }

    /// <summary>Kişinin medeni hâlini ifade eder.</summary>
    [Required]
    [ForeignKey("MedeniHaliNavigation")]
    public string MEDENI_HALI { get; set; }

    /// <summary>Kişinin meşgul olduğu işi veya görevi ifade eder.</summary>
    [Required]
    [ForeignKey("MeslekNavigation")]
    public string MESLEK { get; set; }

    /// <summary>Kişinin en son bitirdiği okul seviyesini veya okuryazarlık durumunu ifade eder. ...</summary>
    [Required]
    [ForeignKey("OgrenimDurumuNavigation")]
    public string OGRENIM_DURUMU { get; set; }

    /// <summary>Kişinin kan grubunu ifade eder.</summary>
    [Required]
    [ForeignKey("KanGrubuNavigation")]
    public string KAN_GRUBU { get; set; }

    /// <summary>Sağlık tesisine muayene olmak için gelen kişinin, Sağlık Bakanlığı tarafından be...</summary>
    [Required]
    [ForeignKey("MuayeneOncelikSirasiNavigation")]
    public string MUAYENE_ONCELIK_SIRASI { get; set; }

    /// <summary>Sağlık tesisine başvuran kişinin engellilik durumunu ifade eder. Örneğin bedense...</summary>
    [Required]
    [ForeignKey("EngellilikDurumuNavigation")]
    public string ENGELLILIK_DURUMU { get; set; }

    /// <summary>Kişinin ölüm tarihi bilgisidir.</summary>
    public DateTime OLUM_TARIHI { get; set; }

    /// <summary>Ölümün gerçekleştiği yeri ifade eder. Örneğin ev, iş, birinci basamak sağlık kur...</summary>
    [Required]
    [ForeignKey("OlumYeriNavigation")]
    public string OLUM_YERI { get; set; }

    /// <summary>Pasaport numarası bilgisidir.</summary>
    [Required]
    public string PASAPORT_NUMARASI { get; set; }

    /// <summary>Kişinin Yurtdışı Provizyon Aktivasyon ve Sağlık Sistemi (YUPASS) numarası bilgis...</summary>
    [Required]
    public string YUPASS_NUMARASI { get; set; }

    /// <summary>Hastanın son başvurduğu kurumu ifade eden Sağlık Bilgi Yönetim Sistemi tarafında...</summary>
    [ForeignKey("SonKurumNavigation")]
    public string SON_KURUM_KODU { get; set; }

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
    public virtual REFERANS_KODLAR? UyrukNavigation { get; set; }
    public virtual REFERANS_KODLAR? HastaTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? CinsiyetNavigation { get; set; }
    public virtual HASTA? AnneHastaNavigation { get; set; }
    public virtual HASTA? BabaHastaNavigation { get; set; }
    public virtual REFERANS_KODLAR? MedeniHaliNavigation { get; set; }
    public virtual REFERANS_KODLAR? MeslekNavigation { get; set; }
    public virtual REFERANS_KODLAR? OgrenimDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanGrubuNavigation { get; set; }
    public virtual REFERANS_KODLAR? MuayeneOncelikSirasiNavigation { get; set; }
    public virtual REFERANS_KODLAR? EngellilikDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? OlumYeriNavigation { get; set; }
    public virtual KURUM? SonKurumNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}