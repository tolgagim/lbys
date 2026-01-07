using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// PERSONEL_IZIN tablosu - 21 kolon
/// </summary>
[Table("PERSONEL_IZIN")]
public class PERSONEL_IZIN
{
    /// <summary>SBYS tarafından üretilen tekil kod bilgisidir.</summary>
    [Key]
    public string PERSONEL_IZIN_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin kullandığı iznin türü (doğum izni, yıllık iz...</summary>
    [ForeignKey("PersonelIzinTuruNavigation")]
    public string PERSONEL_IZIN_TURU { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin kullandığı iznin gün sayısı bilgisidir.</summary>
    public string KULLANILAN_IZIN { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin bir önceki yıldan kalan izninden kullandığı ...</summary>
    [Required]
    public string GECEN_YILDAN_KULLANILAN_IZIN { get; set; }

    /// <summary>Sağlık tesisi personelinin içinde bulunduğu yıldan kullanılan yıllık izin gün sa...</summary>
    [Required]
    public string AKTIF_YILDAN_KULLANILAN_IZIN { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin izin başlama tarihi bilgisidir.</summary>
    public DateTime? IZIN_BASLAMA_TARIHI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin izninin bitiş tarihi bilgisidir.</summary>
    public DateTime IZIN_BITIS_TARIHI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin kullandığı iznin hangi yıla ait olduğu bilgi...</summary>
    public string PERSONEL_IZIN_YILI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin göreve başladığı tarih bilgisidir.</summary>
    public DateTime PERSONEL_DONUS_TARIHI { get; set; }

    /// <summary>Sağlık tesisinde görev yapan personelin izne çıktığı adres bilgisidir.</summary>
    [Required]
    public string IZIN_ADRESI { get; set; }

    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin izin döneminde Sağlık Bilgi Yönetim Sistemin...</summary>
    [Required]
    public string SBYS_ENGELLENME_DURUMU { get; set; }

    /// <summary>SBYS kullanımının engellendiği zaman bilgisidir.</summary>
    public DateTime SBYS_KULLANIM_ENGELLEME_ZAMANI { get; set; }

    /// <summary>SBYS kullanımını engelleyen kullanıcının</summary>
    [Required]
    [ForeignKey("SbysEngelleyenKullaniciNavigation")]
    public string SBYS_ENGELLEYEN_KULLANICI_KODU { get; set; }

    /// <summary>Yapılan bir işlemi onaylayan personel için Sağlık Bilgi Yönetim Sistemi tarafınd...</summary>
    [Required]
    [ForeignKey("OnaylayanPersonelNavigation")]
    public string ONAYLAYAN_PERSONEL_KODU { get; set; }

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
    public virtual PERSONEL? PersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? PersonelIzinTuruNavigation { get; set; }
    public virtual KULLANICI? SbysEngelleyenKullaniciNavigation { get; set; }
    public virtual PERSONEL? OnaylayanPersonelNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}