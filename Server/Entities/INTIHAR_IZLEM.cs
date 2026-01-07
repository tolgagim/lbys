using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_INTIHAR_IZLEM tablosu - 13 kolon
/// </summary>
[Table("INTIHAR_IZLEM")]
public class INTIHAR_IZLEM
{
    /// <summary>Sağlık tesisinde tedavi olan hastaların intihar/kriz izlem bilgileri için Sağlık...</summary>
    [Key]
    public string INTIHAR_IZLEM_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Vakanın intihar vakası ya da kriz vakası olma durumunu ifade eder.</summary>
    [ForeignKey("IntiharKrizVakaTuruNavigation")]
    public string INTIHAR_KRIZ_VAKA_TURU { get; set; }

    /// <summary>Kişinin intihar girişimi ya da kriz nedenlerini ifade eder.</summary>
    [Required]
    [ForeignKey("IntiharGirisimKrizNedenleriNavigation")]
    public string INTIHAR_GIRISIM_KRIZ_NEDENLERI { get; set; }

    /// <summary>Kişinin intihar girişimini gerçekleştirirken kullandığı yöntem/yöntemleri ifade ...</summary>
    [ForeignKey("IntiharGirisimiYontemiNavigation")]
    public string INTIHAR_GIRISIMI_YONTEMI { get; set; }

    /// <summary>İntihar girişiminde bulunan ya da kriz geçiren kişiye yapılan müdahalenin nasıl ...</summary>
    [ForeignKey("IntiharKrizVakaSonucuNavigation")]
    public string INTIHAR_KRIZ_VAKA_SONUCU { get; set; }

    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }

    /// <summary>İşlemin güncellemesinin yapıldığı tarih bilgisidir.</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? IntiharKrizVakaTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? IntiharGirisimKrizNedenleriNavigation { get; set; }
    public virtual REFERANS_KODLAR? IntiharGirisimiYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? IntiharKrizVakaSonucuNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}