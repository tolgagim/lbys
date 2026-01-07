using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// CIHAZ tablosu - 26 kolon
/// </summary>
[Table("CIHAZ")]
public class CIHAZ
{
    /// <summary>Sağlık tesisinde bulunan cihaz için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [Key]
    public string CIHAZ_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde bulunan cihaz adı bilgisidir.</summary>
    public string CIHAZ_ADI { get; set; }

    /// <summary>Sağlık tesisinde bulunan cihazları gruplandırmak için Sağlık Bilgi Yönetim Siste...</summary>
    [Required]
    [ForeignKey("CihazGrubuNavigation")]
    public string CIHAZ_GRUBU { get; set; }

    /// <summary>Sağlık tesisinde bulunan bölümler için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("BirimNavigation")]
    public string BIRIM_KODU { get; set; }

    /// <summary>Sağlık tesisinde kullanılan cihazın model bilgisidir.</summary>
    [Required]
    public string CIHAZ_MODELI { get; set; }

    /// <summary>Sağlık tesisinde kullanılan cihazın marka bilgisidir.</summary>
    [Required]
    public string CIHAZ_MARKASI { get; set; }

    /// <summary>Sağlık tesisinde bulunan tıbbi cihazların seri numarası bilgisini ifade eder.</summary>
    [Required]
    public string SERI_NUMARASI { get; set; }

    /// <summary>Malzeme Kaynak Yönetim Sistemi (MKYS) tarafından üretilen cihaz künye numarası b...</summary>
    [Required]
    public string MKYS_KUNYE_NUMARASI { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi veri tabanında bulunan bir kayıtın aktif olup olmad...</summary>
    public string AKTIFLIK_BILGISI { get; set; }

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
    public virtual REFERANS_KODLAR? CihazGrubuNavigation { get; set; }
    public virtual BIRIM? BirimNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}