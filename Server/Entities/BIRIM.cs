using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_BIRIM tablosu - 35 kolon
/// </summary>
[Table("BIRIM")]
public class BIRIM
{
    /// <summary>Sağlık tesisinde bulunan bölümler için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Key]
    public string BIRIM_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde bulunan kliniklerin Sağlık Bilgi Yönetim Sistemi tarafından gru...</summary>
    [ForeignKey("KlinikNavigation")]
    public string KLINIK_KODU { get; set; }

    /// <summary>Sağlık tesisinde bulunan bölümlerin Sağlık Bilgi Yönetim Sistemi tarafından yapı...</summary>
    [ForeignKey("BirimTuruNavigation")]
    public string BIRIM_TURU { get; set; }

    /// <summary>Sağlık tesisinin her binası için Sağlık Bilgi Yönetim Sistemi tarafından üretile...</summary>
    [Required]
    [ForeignKey("BinaNavigation")]
    public string BINA_KODU { get; set; }

    /// <summary>Sağlık tesisinde bulunan bölümlerin isim bilgisidir. Örneğin poliklinik1, polikl...</summary>
    public string BIRIM_ADI { get; set; }

    /// <summary>Sağlık tesisinde veya sağlık tesisindeki birimlerde bulunan yatak sayısı bilgisi...</summary>
    [Required]
    public string YATAK_SAYISI { get; set; }

    /// <summary>Sağlık tesisinde tanımlanmış muayene eden birimler için MHRS tarafından üretilen...</summary>
    [Required]
    public string MHRS_KODU { get; set; }

    /// <summary>Sağlık tesisinde tanımlı olan poliklinik biriminin MHRS sistemine tanımlanmış ad...</summary>
    [Required]
    public string MHRS_ADI { get; set; }

    /// <summary>Malzeme Kaynak Yönetim Sistemi (MKYS) tarafından depo ve birimler için üretilen ...</summary>
    [Required]
    public string MKYS_KODU { get; set; }

    /// <summary>Sağlık tesisinde bulunan klinik ve hekimler için MEDULA tarafından tanımlanmış b...</summary>
    [Required]
    public string MEDULA_BRANS_KODU { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi veri tabanında bulunan bir kayıtın aktif olup olmad...</summary>
    [Required]
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
    public virtual REFERANS_KODLAR? KlinikNavigation { get; set; }
    public virtual REFERANS_KODLAR? BirimTuruNavigation { get; set; }
    public virtual BINA? BinaNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}