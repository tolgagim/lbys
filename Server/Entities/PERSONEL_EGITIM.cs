using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_PERSONEL_EGITIM tablosu - 16 kolon
/// </summary>
[Table("PERSONEL_EGITIM")]
public class PERSONEL_EGITIM
{
    /// <summary>Sağlık tesisinde görevli personelin almış olduğu eğitim bilgileri için Sağlık Bi...</summary>
    [Key]
    public string PERSONEL_EGITIM_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin almış olduğu eğitim bilgileri için Sağlık Bi...</summary>
    [ForeignKey("PersonelEgitimTuruNavigation")]
    public string PERSONEL_EGITIM_TURU { get; set; }

    /// <summary>Sağlık tesisinde görevli personele ait sertifikalara ilişkin detaylı bilgiyi ifa...</summary>
    [Required]
    [ForeignKey("SertifikaTipiNavigation")]
    public string SERTIFIKA_TIPI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele ait sertifikaların puan bilgisini ifade eder.</summary>
    [Required]
    public string SERTIFIKA_PUANI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin eğitim veya öğrenim için aldığı belgenin num...</summary>
    [Required]
    public string BELGE_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin aldığı eğitimin başladığı zaman bilgisidir.</summary>
    public DateTime? EGITIM_BASLANGIC_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin aldığı eğitimin bittiği zaman bilgisidir.</summary>
    public DateTime EGITIM_BITIS_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin aldığı eğitimi veren kişinin ad soyadı bilgi...</summary>
    [Required]
    public string EGITIM_VEREN_KISI_BILGISI { get; set; }

    /// <summary>Eğitimin verildiği yer bilgisidir.</summary>
    [Required]
    public string EGITIM_YERI { get; set; }

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
    public virtual REFERANS_KODLAR? PersonelEgitimTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? SertifikaTipiNavigation { get; set; }
    public virtual PERSONEL? OnaylayanPersonelNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}