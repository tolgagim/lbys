using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// STERILIZASYON_SET tablosu - 26 kolon
/// </summary>
[Table("STERILIZASYON_SET")]
public class STERILIZASYON_SET : VemEntity
{
    /// <summary>TÄ±bbi aletlerin steril edilmeden Ã¶nce ve sterilizasyon aÅŸamasÄ±nda oluÅŸturulan se...</summary>
    [Key]
    public string STERILIZASYON_SET_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan stok depolarÄ± iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±n...</summary>
    [ForeignKey("DepoNavigation")]
    public string DEPO_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinin deposunda bulunan steril aletlerin paket bilgilerine iliÅŸkin ka...</summary>
    [ForeignKey("SterilizasyonPaketNavigation")]
    public string STERILIZASYON_PAKET_KODU { get; set; }

    /// <summary>Ã‡ubuk kod ya da Ã§izgi im, verilerin gÃ¶rsel Ã¶zellikli makinelerin okuyabilmesi iÃ§...</summary>
    [Required]
    public string BARKOD { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen barkodlarÄ±, barkod yazÄ±cÄ±dan bastÄ±ran SaÄŸlÄ±k Bilgi YÃ¶n...</summary>
    [Required]
    [ForeignKey("BarkodBasanKullaniciNavigation")]
    public string BARKOD_BASAN_KULLANICI_KODU { get; set; }

    /// <summary>Barkodun basÄ±ldÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime BARKOD_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan cihaz iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼ret...</summary>
    [ForeignKey("CihazNavigation")]
    public string CIHAZ_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde sterilizasyon iÅŸlemi uygulanan alet, malzeme veya setler iÃ§in s...</summary>
    [Required]
    public string STERILIZASYON_CEVRIM_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavide kullanÄ±lan setin iade edilip edilmediÄŸine iliÅŸkin bilg...</summary>
    public string SET_IADE_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavide kullanÄ±lan setin kullanÄ±lmayÄ±p ilgili birime iade edil...</summary>
    public DateTime SET_IADE_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [Required]
    [ForeignKey("SetIadeEdenPersonelNavigation")]
    public string SET_IADE_EDEN_PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [Required]
    [ForeignKey("SetIadeAlanPersonelNavigation")]
    public string SET_IADE_ALAN_PERSONEL_KODU { get; set; }

    /// <summary>Steril edilmiÅŸ setin raf Ã¶mrÃ¼nÃ¼n bitiÅŸ tarihi bilgisidir.</summary>
    public DateTime PAKET_RAF_OMRU_BITIS_TARIHI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [ForeignKey("PaketleyenPersonelNavigation")]
    public string PAKETLEYEN_PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan iÅŸlemlerin, uygulanmaya baÅŸladÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime? ISLEM_ZAMANI { get; set; }

    /// <summary>Sterilizasyon iÅŸleminin baÅŸladÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime? STERILIZASYON_BASLAMA_ZAMANI { get; set; }

    /// <summary>Sterilizasyon iÅŸleminin bittiÄŸi zaman bilgisidir.</summary>
    public DateTime STERILIZASYON_BITIS_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [Required]
    [ForeignKey("SterilizasyonPersonelNavigation")]
    public string STERILIZASYON_PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual DEPO? DepoNavigation { get; set; }
    public virtual STERILIZASYON_PAKET? SterilizasyonPaketNavigation { get; set; }
    public virtual KULLANICI? BarkodBasanKullaniciNavigation { get; set; }
    public virtual CIHAZ? CihazNavigation { get; set; }
    public virtual PERSONEL? SetIadeEdenPersonelNavigation { get; set; }
    public virtual PERSONEL? SetIadeAlanPersonelNavigation { get; set; }
    public virtual PERSONEL? PaketleyenPersonelNavigation { get; set; }
    public virtual PERSONEL? SterilizasyonPersonelNavigation { get; set; }
    #endregion

}
