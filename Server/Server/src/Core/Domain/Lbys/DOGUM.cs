using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// DOGUM tablosu - 21 kolon
/// </summary>
[Table("DOGUM")]
public class DOGUM : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde doÄŸum yapan hastaya ait bilgilerin kayÄ±t edilmesi iÃ§in SaÄŸlÄ±k B...</summary>
    [Key]
    public string DOGUM_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hastaya uygulanacak hizmetler iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi...</summary>
    [ForeignKey("HastaHizmetNavigation")]
    public string HASTA_HIZMET_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan ameliyatÄ±n bilgilerine eriÅŸim saÄŸlamak iÃ§in SaÄŸlÄ±k Bilg...</summary>
    [Required]
    [ForeignKey("AmeliyatNavigation")]
    public string AMELIYAT_KODU { get; set; }

    /// <summary>Yenidogan bebegin baba T.C. Kimlik Numarasi bilgisidir.</summary>
    [Required]
    public string BABA_TC_KIMLIK_NUMARASI { get; set; }

    /// <summary>Herhangi bir mÃ¼dahale (ameliyat, doÄŸum vb.) sonrasÄ± oluÅŸan karmaÅŸÄ±k ve olumsuz k...</summary>
    [Required]
    [ForeignKey("KomplikasyonTanisiNavigation")]
    public string KOMPLIKASYON_TANISI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde doÄŸum yapan hasta iÃ§in hekim tarafÄ±ndan yazÄ±lan, doÄŸuma iliÅŸkin...</summary>
    [Required]
    public string DOGUM_NOTU { get; set; }

    /// <summary>DoÄŸum baÅŸlama zamanÄ± bilgisidir.</summary>
    public DateTime? DOGUM_BASLAMA_ZAMANI { get; set; }

    /// <summary>DoÄŸum bitiÅŸ zamanÄ± bilgisidir.</summary>
    public DateTime DOGUM_BITIS_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli hekim iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼ret...</summary>
    [Required]
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde doÄŸumu gerÃ§ekleÅŸtiren ebe iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tar...</summary>
    [Required]
    [ForeignKey("EbeNavigation")]
    public string EBE_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan bÃ¶lÃ¼mler iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("BirimNavigation")]
    public string BIRIM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki birimlerde hasta bilgilerinin olduÄŸu defter numarasÄ± bilgisid...</summary>
    [Required]
    public string DEFTER_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA_HIZMET? HastaHizmetNavigation { get; set; }
    public virtual AMELIYAT? AmeliyatNavigation { get; set; }
    public virtual REFERANS_KODLAR? KomplikasyonTanisiNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual PERSONEL? EbeNavigation { get; set; }
    public virtual BIRIM? BirimNavigation { get; set; }
    #endregion

}
