using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// KURUL_ASKERI tablosu - 17 kolon
/// </summary>
[Table("KURUL_ASKERI")]
public class KURUL_ASKERI
{
    /// <summary>Sağlık tesisinde düzenlenen sağlık kurulu tarafından verilen raporların tanım bi...</summary>
    [Key]
    public string KURUL_ASKERI_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Kurul adı bilgisidir.</summary>
    public string KURUL_ADI { get; set; }

    /// <summary>Sağlık tesisinde düzenlenen heyet veya tek hekim raporları için MEDULA tarafında...</summary>
    [ForeignKey("MedulaRaporTuruNavigation")]
    public string MEDULA_RAPOR_TURU { get; set; }

    /// <summary>Sağlık tesisinde tedavi olan hastalar için düzenlenmiş heyet veya tek hekim rapo...</summary>
    [Required]
    [ForeignKey("MedulaAltRaporTuruNavigation")]
    public string MEDULA_ALT_RAPOR_TURU { get; set; }

    /// <summary>Kişinin alkol veya madde bağımlısı olup olmadığına ilişkin bilgiyi ifade eder.</summary>
    [Required]
    [ForeignKey("AlkolMaddeBagimliligiNavigation")]
    public string ALKOL_MADDE_BAGIMLILIGI { get; set; }

    /// <summary>Kişinin bedensel veya ruhsal ileri tetkik bulgusuna ait bilgiyi ifade eder.</summary>
    [Required]
    [ForeignKey("BedenRuhIleriTetkikBulgusuNavigation")]
    public string BEDEN_RUH_ILERI_TETKIK_BULGUSU { get; set; }

    /// <summary>Kişinin geçmiş hastalığına dair kayıt bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("GecmisHastaligaDairKayitNavigation")]
    public string GECMIS_HASTALIGA_DAIR_KAYIT { get; set; }

    /// <summary>Kişinin görme veya işitme kaybı olup olmadığı bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("GormeIsitmeKaybiNavigation")]
    public string GORME_ISITME_KAYBI { get; set; }

    /// <summary>Kişinin psikiyatrik rahatsızlık durumuna ilişkin bilgiyi ifade eder.</summary>
    [Required]
    [ForeignKey("PsikiyatrikRahatsizlikNavigation")]
    public string PSIKIYATRIK_RAHATSIZLIK { get; set; }

    /// <summary>Kişinin uzuv kaybı veya ortopedik rahatsızlığı olup olmadığı bilgisini ifade ede...</summary>
    [ForeignKey("UzuvkaybiOrtopediRahatsizlikNavigation")]
    public string UZUVKAYBI_ORTOPEDI_RAHATSIZLIK { get; set; }

    /// <summary>Kişinin asal hastalık bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("AsalHastalikNavigation")]
    public string ASAL_HASTALIK { get; set; }

    /// <summary>Kişinin asal hastalık tipi bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("AsalHastalikTipiNavigation")]
    public string ASAL_HASTALIK_TIPI { get; set; }

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
    public virtual REFERANS_KODLAR? MedulaRaporTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? MedulaAltRaporTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? AlkolMaddeBagimliligiNavigation { get; set; }
    public virtual REFERANS_KODLAR? BedenRuhIleriTetkikBulgusuNavigation { get; set; }
    public virtual REFERANS_KODLAR? GecmisHastaligaDairKayitNavigation { get; set; }
    public virtual REFERANS_KODLAR? GormeIsitmeKaybiNavigation { get; set; }
    public virtual REFERANS_KODLAR? PsikiyatrikRahatsizlikNavigation { get; set; }
    public virtual REFERANS_KODLAR? UzuvkaybiOrtopediRahatsizlikNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsalHastalikNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsalHastalikTipiNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}