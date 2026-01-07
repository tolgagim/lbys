using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_TETKIK_NUMUNE tablosu - 24 kolon
/// </summary>
[Table("TETKIK_NUMUNE")]
public class TETKIK_NUMUNE
{
    /// <summary>Sağlık tesisinde yapılan tetkiklerde kullanılan numuneler için Sağlık Bilgi Yöne...</summary>
    [Key]
    public string TETKIK_NUMUNE_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık tesisinde kişiden alınan numune için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [Required]
    public string NUMUNE_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde kişiden alınan numune için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [ForeignKey("NumuneTuruNavigation")]
    public string NUMUNE_TURU { get; set; }

    /// <summary>Sağlık tesisinde bulunan bölümler için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("BirimNavigation")]
    public string BIRIM_KODU { get; set; }

    /// <summary>Sağlık tesisinde kişiden alınan numunenin alınma zamanı bilgisidir.</summary>
    public DateTime NUMUNE_ALMA_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde kişiden alınan numunenin laboratuvara kabul edildiği zaman bilg...</summary>
    public DateTime NUMUNE_KABUL_ZAMANI { get; set; }

    /// <summary>Çubuk kod ya da çizgi im, verilerin görsel özellikli makinelerin okuyabilmesi iç...</summary>
    [Required]
    public string BARKOD { get; set; }

    /// <summary>Barkodun basıldığı zaman bilgisidir.</summary>
    public DateTime BARKOD_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde numune alan kullanıcı için Sağlık Bilgi Yönetim Sistemi tarafın...</summary>
    [Required]
    [ForeignKey("NumuneAlanKullaniciNavigation")]
    public string NUMUNE_ALAN_KULLANICI_KODU { get; set; }

    /// <summary>Sağlık tesisinde tedavi alan hastaya istenen tetkiklerin kabulünü yapan Sağlık B...</summary>
    [Required]
    [ForeignKey("KabulEdenKullaniciNavigation")]
    public string KABUL_EDEN_KULLANICI_KODU { get; set; }

    /// <summary>Numunenin ret edilmesine ilişkin neden bilgisidir.</summary>
    [Required]
    [ForeignKey("NumuneRetNedeniNavigation")]
    public string NUMUNE_RET_NEDENI { get; set; }

    /// <summary>Ret işlemini gerçekleştiren Sağlık Bilgi Yönetim Sistemi kullanıcısı için Sağlık...</summary>
    [Required]
    [ForeignKey("RetEdenKullaniciNavigation")]
    public string RET_EDEN_KULLANICI_KODU { get; set; }

    /// <summary>Numunenin ret edildiği zaman bilgisidir.</summary>
    public DateTime RET_ZAMANI { get; set; }

    /// <summary>Sağlık tesisinde laboratuvarda tetkiki yapılacak numunenin öncelik durumuna iliş...</summary>
    [Required]
    public string NUMUNE_ACILIYET_DURUMU { get; set; }

    /// <summary>Kişinin sağlık tesisi dışında başka bir laboratuvarda yaptırmış olduğu tahliller...</summary>
    [Required]
    public string ENTEGRASYON_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? NumuneTuruNavigation { get; set; }
    public virtual BIRIM? BirimNavigation { get; set; }
    public virtual KULLANICI? NumuneAlanKullaniciNavigation { get; set; }
    public virtual KULLANICI? KabulEdenKullaniciNavigation { get; set; }
    public virtual REFERANS_KODLAR? NumuneRetNedeniNavigation { get; set; }
    public virtual KULLANICI? RetEdenKullaniciNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}