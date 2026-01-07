using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_KUDUZ_IZLEM tablosu - 13 kolon
/// </summary>
[Table("KUDUZ_IZLEM")]
public class KUDUZ_IZLEM
{
    /// <summary>Sağlık tesisinde tedavi olan hastaların kuduz izlem bilgileri için Sağlık Bilgi ...</summary>
    [Key]
    public string KUDUZ_IZLEM_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Kuduz şüpheli temaslılar ve risk grubunda yer alan ve temas öncesi profilaksi ih...</summary>
    [Required]
    [ForeignKey("ProfilaksiTamamlanmaDurumuNavigation")]
    public string PROFILAKSI_TAMAMLANMA_DURUMU { get; set; }

    /// <summary>Kuduz şüpheli temasa maruz kalan kişiye kuduz profilaksisi programı çerçevesinde...</summary>
    [Required]
    [ForeignKey("UygulananKuduzProfilaksisiNavigation")]
    public string UYGULANAN_KUDUZ_PROFILAKSISI { get; set; }

    /// <summary>Kişinin kuduz aşısını yaptırdığı veya yaptıracağını beyan ettiği Toplum Sağlığı ...</summary>
    [Required]
    [ForeignKey("BeyanTsmKurumNavigation")]
    public string BEYAN_TSM_KURUM_KODU { get; set; }

    /// <summary>Uygulanan immünglobilinin IU cinsinden miktar bilgisidir.</summary>
    [Required]
    public string IMMUNGLOBULIN_MIKTARI { get; set; }

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
    public virtual REFERANS_KODLAR? ProfilaksiTamamlanmaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? UygulananKuduzProfilaksisiNavigation { get; set; }
    public virtual KURUM? BeyanTsmKurumNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}