using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// HASTA_ARSIV_DETAY tablosu - 16 kolon
/// </summary>
[Table("HASTA_ARSIV_DETAY")]
public class HASTA_ARSIV_DETAY
{
    /// <summary>Arşivde bulunan hasta dosyası detay bilgileri için Sağlık Bilgi Yönetim Sistemi ...</summary>
    [Key]
    public string HASTA_ARSIV_DETAY_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Arşivde bulunan hasta dosyası bilgileri için Sağlık Bilgi Yönetim Sistemi tarafı...</summary>
    [ForeignKey("HastaArsivNavigation")]
    public string HASTA_ARSIV_KODU { get; set; }

    /// <summary>Sağlık tesisindeki hasta dosyasını teslim alan birim için Sağlık Bilgi Yönetim S...</summary>
    [Required]
    [ForeignKey("DosyaAlanBirimNavigation")]
    public string DOSYA_ALAN_BIRIM_KODU { get; set; }

    /// <summary>Sağlık tesisinde bulunan hasta dosyasının arşivden alındığı zaman bilgisidir.</summary>
    public DateTime DOSYANIN_ALINDIGI_ZAMAN { get; set; }

    /// <summary>Sağlık tesisindeki hasta dosyasını teslim alan personel için Sağlık Bilgi Yöneti...</summary>
    [Required]
    [ForeignKey("DosyaAlanPersonelNavigation")]
    public string DOSYA_ALAN_PERSONEL_KODU { get; set; }

    /// <summary>Sağlık tesisindeki hasta dosyasını arşive veren birimler için Sağlık Bilgi Yönet...</summary>
    [Required]
    [ForeignKey("DosyaVerenBirimNavigation")]
    public string DOSYA_VEREN_BIRIM_KODU { get; set; }

    /// <summary>Dosyanın verildiği zaman bilgisidir.</summary>
    public DateTime DOSYANIN_VERILDIGI_ZAMAN { get; set; }

    /// <summary>Sağlık tesisinde hasta dosyasını arşive veren kullanıcı için Sağlık Bilgi Yöneti...</summary>
    [Required]
    [ForeignKey("DosyaVerenKullaniciNavigation")]
    public string DOSYA_VEREN_KULLANICI_KODU { get; set; }

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
    public virtual HASTA_ARSIV? HastaArsivNavigation { get; set; }
    public virtual BIRIM? DosyaAlanBirimNavigation { get; set; }
    public virtual PERSONEL? DosyaAlanPersonelNavigation { get; set; }
    public virtual BIRIM? DosyaVerenBirimNavigation { get; set; }
    public virtual KULLANICI? DosyaVerenKullaniciNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}