using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_RECETE_ILAC_ACIKLAMA tablosu - 10 kolon
/// </summary>
[Table("RECETE_ILAC_ACIKLAMA")]
public class RECETE_ILAC_ACIKLAMA
{
    /// <summary>Sağlık tesisinde tedavi gören hasta için düzenlenen reçetede bulunan ilaç açıkla...</summary>
    [Key]
    public string RECETE_ILAC_ACIKLAMA_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde tedavi gören hasta için düzenlenen reçetede bulunan ilaç bilgil...</summary>
    [Required]
    [ForeignKey("ReceteIlacNavigation")]
    public string RECETE_ILAC_KODU { get; set; }

    /// <summary>Sağlık tesisinde tedavi gören hasta için düzenlenen reçetede bilgileri için Sağl...</summary>
    [ForeignKey("ReceteNavigation")]
    public string RECETE_KODU { get; set; }

    /// <summary>Sağlık hizmetini alan kişi için yazılmış reçete ve/veya ilaç için yapılmış açıkl...</summary>
    [ForeignKey("IlacAciklamaTuruNavigation")]
    public string ILAC_ACIKLAMA_TURU { get; set; }

    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    public string ACIKLAMA { get; set; }

    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
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
    public virtual RECETE_ILAC? ReceteIlacNavigation { get; set; }
    public virtual RECETE? ReceteNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlacAciklamaTuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}