using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_BASVURU_TANI tablosu - 15 kolon
/// </summary>
[Table("BASVURU_TANI")]
public class BASVURU_TANI
{
    /// <summary>Sağlık tesisine başvuran kişinin tanı bilgileri için Sağlık Bilgi Yönetim Sistem...</summary>
    [Key]
    public string BASVURU_TANI_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık tesisinde hastaya konulan tanı için ICD-10 kodlarından seçilen tanı kodu ...</summary>
    [ForeignKey("TaniNavigation")]
    public string TANI_KODU { get; set; }

    /// <summary>Sağlık tesisinde tanı konulan bir hasta için hekim tarafından seçilen tanı tipi ...</summary>
    [ForeignKey("TaniTuruNavigation")]
    public string TANI_TURU { get; set; }

    /// <summary>Sağlık tesisinde başvuran kişiye hekim tarafından ana tanı konulma durumunu ifad...</summary>
    public string BIRINCIL_TANI { get; set; }

    /// <summary>Sağlık tesisinde hastanın hastalığına ilişkin belirlenen tanının Sağlık Bilgi Yö...</summary>
    public DateTime TANI_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde görevli hekim için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [Required]
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }

    /// <summary>Hastaya sağlık raporu veren kurul için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("KurulRaporNavigation")]
    public string KURUL_RAPOR_KODU { get; set; }

    /// <summary>Sağlık tesisinden başka bir sağlık tesisine sevk edilen hastanın sevk bilgileri ...</summary>
    [Required]
    [ForeignKey("HastaSevkNavigation")]
    public string HASTA_SEVK_KODU { get; set; }

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
    public virtual REFERANS_KODLAR? TaniNavigation { get; set; }
    public virtual REFERANS_KODLAR? TaniTuruNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual KURUL_RAPOR? KurulRaporNavigation { get; set; }
    public virtual HASTA_SEVK? HastaSevkNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}