using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_HASTA_UYARI tablosu - 13 kolon
/// </summary>
[Table("HASTA_UYARI")]
public class HASTA_UYARI
{
    /// <summary>Sağlık tesisine başvuran hasta için personele yapılması gereken uyarılar için Sa...</summary>
    [Key]
    public string HASTA_UYARI_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık tesisinde yapılan bir işlem, kişiye uygulanan tedavi, verilen ilaç vb. du...</summary>
    [ForeignKey("UyariTuruNavigation")]
    public string UYARI_TURU { get; set; }

    /// <summary>Sağlık tesisinde tedavi olan hastaya yapılacak her hangi bir işlemin yapılması i...</summary>
    public string ISLEME_IZIN_VERME_DURUMU { get; set; }

    /// <summary>Sağlık tesisine başvuran kişi için yapılması planlanan uyarıların başlaması gere...</summary>
    public DateTime? HASTA_UYARI_BASLAMA_ZAMANI { get; set; }

    /// <summary>Sağlık tesisine başvuran kişi için yapılması planlanan uyarıların bitmesi gereke...</summary>
    public DateTime HASTA_UYARI_BITIS_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
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
    public virtual REFERANS_KODLAR? UyariTuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}