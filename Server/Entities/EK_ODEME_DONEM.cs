using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_EK_ODEME_DONEM tablosu - 16 kolon
/// </summary>
[Table("EK_ODEME_DONEM")]
public class EK_ODEME_DONEM
{
    /// <summary>Sağlık tesisinde görevli personele ödenecek ek ödeme için Sağlık Bilgi Yönetim S...</summary>
    [Key]
    public string EK_ODEME_DONEM_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Yıl bilgisini ifade eder.</summary>
    public string YIL { get; set; }

    /// <summary>Yılın on iki bölümünden her birini ifade eder.</summary>
    public string AY { get; set; }

    /// <summary>Sağlık tesisinde görev yapan personel için yapılan her türlü ödeme bilgisine ait...</summary>
    [Required]
    public string BORDRO_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde görevli hekimler tarafından, hastaya uygulanan tıbbi işlemler i...</summary>
    public string GIRISIMSEL_ISLEM_PUAN_TOPLAMI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin uyguladığı tıbbi işlemler için aldığı özelli...</summary>
    public string OZELLIKLI_ISLEM_PUAN_TOPLAMI { get; set; }

    /// <summary>Sağlık tesisinde görevli tüm personelin mevcut kadrosundaki aktif çalıştığı gün ...</summary>
    public string ACGK_TOPLAMI { get; set; }

    /// <summary>Sağlık tesisinde görevli personel için ek ödeme dönemi için dağıtılması planlana...</summary>
    public string DAGITILACAK_EKODEME_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele ait bordro için hesaplanan ek ödeme katsayısı...</summary>
    public string EK_ODEME_KATSAYISI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele aylık ödenen ek ödeme için hesaplanan hastane...</summary>
    public string HASTANE_PUAN_ORTALAMASI { get; set; }

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
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}