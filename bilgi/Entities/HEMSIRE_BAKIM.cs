using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// HEMSIRE_BAKIM tablosu - 17 kolon
/// </summary>
[Table("HEMSIRE_BAKIM")]
public class HEMSIRE_BAKIM
{
    /// <summary>Sağlık tesisinde tedavi olan hastaya hemşire tarafından uygulanan bakım bilgiler...</summary>
    [Key]
    public string HEMSIRE_BAKIM_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Hemşirenin hastayı değerlendirdiği zaman bilgisidir.</summary>
    public DateTime? HEMSIRE_DEGERLENDIRME_ZAMANI { get; set; }

    /// <summary>Hemşirelik bakım planı kapsamında hemşire tarafından hastaya konulan hemşirelik ...</summary>
    [ForeignKey("HemsirelikTaniNavigation")]
    public string HEMSIRELIK_TANI_KODU { get; set; }

    /// <summary>Sağlık tesisinde tedavi olan hastalara hemşire tarafından uygulanan bakıma ilişk...</summary>
    [Required]
    [ForeignKey("BakimNedeniNavigation")]
    public string BAKIM_NEDENI { get; set; }

    /// <summary>Sağlık tesisinde tedavi olan hastaya hemşire tarafından uygulanan bakım tedavisi...</summary>
    [Required]
    [ForeignKey("HemsireBakimHedefSonucNavigation")]
    public string HEMSIRE_BAKIM_HEDEF_SONUC { get; set; }

    /// <summary>Sağlık tesisinde tedavi alan hasta için hemşire tarafından uygulanan girişim bil...</summary>
    [Required]
    [ForeignKey("HemsirelikGirisimiNavigation")]
    public string HEMSIRELIK_GIRISIMI { get; set; }

    /// <summary>Sağlık tesisinde tedavi olan hastaya hemşire tarafından uygulanan bakım için hem...</summary>
    [Required]
    [ForeignKey("HemsireDegerlendirmeDurumuNavigation")]
    public string HEMSIRE_DEGERLENDIRME_DURUMU { get; set; }

    /// <summary>Sağlık tesisinde tedavi gören hastaya, hemşire tarafından uygulanan işlemlere il...</summary>
    [Required]
    public string HEMSIRE_DEGERLENDIRME_NOTU { get; set; }

    /// <summary>Sağlık tesisinde görevli hemşire için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [Required]
    [ForeignKey("HemsireNavigation")]
    public string HEMSIRE_KODU { get; set; }

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
    public virtual REFERANS_KODLAR? HemsirelikTaniNavigation { get; set; }
    public virtual REFERANS_KODLAR? BakimNedeniNavigation { get; set; }
    public virtual REFERANS_KODLAR? HemsireBakimHedefSonucNavigation { get; set; }
    public virtual REFERANS_KODLAR? HemsirelikGirisimiNavigation { get; set; }
    public virtual REFERANS_KODLAR? HemsireDegerlendirmeDurumuNavigation { get; set; }
    public virtual PERSONEL? HemsireNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}