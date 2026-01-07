using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_DIS_TAAHHUT tablosu - 23 kolon
/// </summary>
[Table("DIS_TAAHHUT")]
public class DIS_TAAHHUT
{
    /// <summary>Diş tedavisi yapılan hastalar için MEDULA sisteminden alınan taahhüt bilgilerini...</summary>
    [Key]
    public string DIS_TAAHHUT_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisinde görevli hekim için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }

    /// <summary>Sağlık tesisinde işlem yapılacak kişiye ait diş işlemleri için MEDULA sisteminde...</summary>
    [Required]
    public string DIS_TAAHHUT_NUMARASI { get; set; }

    /// <summary>Sağlık tesisine gelen hasta için MEDULA sisteminden Sağlık Bilgi Yönetim Sistemi...</summary>
    public string SGK_TAKIP_NUMARASI { get; set; }

    /// <summary>Kişinin adres bilgisinde bulunan cadde sokak bilgisidir.</summary>
    [Required]
    public string CADDE_SOKAK { get; set; }

    /// <summary>Adresin dış kapı numarası bilgisidir.</summary>
    [Required]
    public string DIS_KAPI_NUMARASI { get; set; }

    /// <summary>Kişinin elektronik posta adresidir.</summary>
    [Required]
    public string EPOSTA_ADRESI { get; set; }

    /// <summary>Adresin iç kapı numarası bilgisidir.</summary>
    [Required]
    public string IC_KAPI_NUMARASI { get; set; }

    /// <summary>İl kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("IlNavigation")]
    public string IL_KODU { get; set; }

    /// <summary>Telefon numarası bilgisini ifade eder.</summary>
    [Required]
    public string TELEFON_NUMARASI { get; set; }

    /// <summary>İlçe kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("IlceNavigation")]
    public string ILCE_KODU { get; set; }

    /// <summary>MEDULA sisteminden web servis aracılığı ile alınan cevapların kod numarası bilgi...</summary>
    [Required]
    public string MEDULA_SONUC_KODU { get; set; }

    /// <summary>MEDULA sisteminden web servis aracılığı ile alınan cevapların metin bilgisidir.</summary>
    [Required]
    public string MEDULA_SONUC_MESAJI { get; set; }

    /// <summary>Sağlık tesisinde yapılan bir işlemin iptal edilip edilmediği bilgisidir.</summary>
    [Required]
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
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlceNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}