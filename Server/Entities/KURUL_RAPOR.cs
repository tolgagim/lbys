using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_KURUL_RAPOR tablosu - 31 kolon
/// </summary>
[Table("KURUL_RAPOR")]
public class KURUL_RAPOR
{
    /// <summary>Hastaya sağlık raporu veren kurul için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Key]
    public string KURUL_RAPOR_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde düzenlenen sağlık kurulu tarafından verilen raporların tanım bi...</summary>
    [ForeignKey("KurulNavigation")]
    public string KURUL_KODU { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık kurulu tarafından verilen raporlar için ad bilgisidir.</summary>
    [Required]
    public string RAPOR_ADI { get; set; }

    /// <summary>Rapor zamanı bilgisidir.</summary>
    public DateTime? RAPOR_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>Sağlık kurulu tarafından verilen raporların karar numarası bilgisidir.</summary>
    [Required]
    public string RAPOR_KARAR_NUMARASI { get; set; }

    /// <summary>Sağlık tesisine başvuran hastaya verilen iş göremezlik raporu için MEDULA sistem...</summary>
    [Required]
    public string RAPOR_SIRA_NUMARASI { get; set; }

    /// <summary>Sağlık tesisine başvuran hastaya verilen sağlık kurulu raporu için Sağlık Bilgi ...</summary>
    [Required]
    public string RAPOR_TAKIP_NUMARASI { get; set; }

    /// <summary>Sağlık kurulu tarafından verilen raporlar için Sağlık Bilgi Yönetim Sistemi tara...</summary>
    public string KURUL_RAPOR_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde kişiye verilen raporun başlama tarihi bilgisidir.</summary>
    public DateTime? RAPOR_BASLAMA_TARIHI { get; set; }

    /// <summary>Raporun bitiş tarihi bilgisidir.</summary>
    public DateTime RAPOR_BITIS_TARIHI { get; set; }

    /// <summary>Sağlık tesisinde laboratuvarda yapılan tetkikler sonucunda elde edilen bulguları...</summary>
    [Required]
    public string LABORATUVAR_BULGU { get; set; }

    /// <summary>Sağlık tesisine kurul raporu almak için başvurmuş kişinin muayene bulguları bilg...</summary>
    [Required]
    public string KURUL_RAPOR_MUAYENE_BULGUSU { get; set; }

    /// <summary>Sağlık tesisinde düzenlenen kurul raporlarında hasta için verilen tanı bilgisini...</summary>
    [Required]
    public string KURUL_TANI_BILGISI { get; set; }

    /// <summary>Sağlık tesisinde kişiye verilen kurul raporu için kurul tarafından verilen karar...</summary>
    [Required]
    public string KURUL_RAPOR_KARARI { get; set; }

    /// <summary>Sağlık tesisinde kişiye verilen kurul raporunun içeriğinin Sağlık Bilgi Yönetim ...</summary>
    [Required]
    [ForeignKey("KararIcerikFormatiNavigation")]
    public string KARAR_ICERIK_FORMATI { get; set; }

    /// <summary>Sağlık tesisine rapor almak için gelen kişinin sağlık tesisine müracaatına ilişk...</summary>
    public string MURACAAT_DURUMU { get; set; }

    /// <summary>Sağlık tesisine başvuran kişi için belirlenen engellilik oranı bilgisidir.</summary>
    [Required]
    public string ENGELLILIK_ORANI { get; set; }

    /// <summary>Sağlık tesisinde düzenlenen onaylanmış ilaç raporunda sonradan yapılan değişikli...</summary>
    [Required]
    public string ILAC_RAPOR_DUZELTME_ACIKLAMASI { get; set; }

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
    public virtual KURUL? KurulNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? KararIcerikFormatiNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}