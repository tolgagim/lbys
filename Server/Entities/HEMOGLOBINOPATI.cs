using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_HEMOGLOBINOPATI tablosu - 14 kolon
/// </summary>
[Table("HEMOGLOBINOPATI")]
public class HEMOGLOBINOPATI
{
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Key]
    public string HEMOGLOBINOPATI_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Kişinin hemoglobinopati tarama sonucuna ilişkin bilgiyi ifade eder.</summary>
    [Required]
    [ForeignKey("HemoglobinopatiTaramaSonucuNavigation")]
    public string HEMOGLOBINOPATI_TARAMA_SONUCU { get; set; }

    /// <summary>Kişinin eş adayının T.C. Kimlik Numarası bilgisidir.</summary>
    [Required]
    public string ES_ADAYI_TC_KIMLIK_NUMARASI { get; set; }

    /// <summary>Kişinin eş adayının telefon numarası bilgisidir.</summary>
    [Required]
    public string ES_ADAYI_TELEFON_NUMARASI { get; set; }

    /// <summary>Kişinin hemoglobinopati tarama testinin sonuç bilgisidir.</summary>
    [ForeignKey("HemoglobinopatiTestiSonucuNavigation")]
    public string HEMOGLOBINOPATI_TESTI_SONUCU { get; set; }

    /// <summary>Kişiye yapılan hemoglobinopati tarama testinin yapılma amacına ilişkin işlem bil...</summary>
    public string HEMOGLOBINOPATI_ISLEM_TIPI { get; set; }

    /// <summary>Kişinin hemoglobinopati test sonucu hastalık türü bilgisidir.</summary>
    [Required]
    [ForeignKey("HemoglobinopatiSonucHastalikNavigation")]
    public string HEMOGLOBINOPATI_SONUC_HASTALIK { get; set; }

    /// <summary>Kişinin hemoglobinopati test sonucu taşıyıcılık türü bilgisidir.</summary>
    [Required]
    [ForeignKey("HemoglobinopatiTasiyicilikNavigation")]
    public string HEMOGLOBINOPATI_TASIYICILIK { get; set; }

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
    public virtual REFERANS_KODLAR? HemoglobinopatiTaramaSonucuNavigation { get; set; }
    public virtual REFERANS_KODLAR? HemoglobinopatiTestiSonucuNavigation { get; set; }
    public virtual REFERANS_KODLAR? HemoglobinopatiSonucHastalikNavigation { get; set; }
    public virtual REFERANS_KODLAR? HemoglobinopatiTasiyicilikNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}