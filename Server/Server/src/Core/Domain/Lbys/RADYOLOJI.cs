using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// RADYOLOJI tablosu - 22 kolon
/// </summary>
[Table("RADYOLOJI")]
public class RADYOLOJI : VemEntity
{
    /// <summary>SBYS tarafÄ±ndan Ã¼retilen tekil kod bilgisidir.</summary>
    [Key]
    public string RADYOLOJI_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan bÃ¶lÃ¼mler iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("BirimNavigation")]
    public string BIRIM_KODU { get; set; }

    /// <summary>Radyolojik tetkik Ã§ekimi iÃ§in hastanÄ±n kabulÃ¼nÃ¼n yapÄ±ldÄ±ÄŸÄ± zamandÄ±r.</summary>
    public DateTime TETKIK_CEKIM_KABUL_ZAMANI { get; set; }

    /// <summary>Ã‡ubuk kod ya da Ã§izgi im, verilerin gÃ¶rsel Ã¶zellikli makinelerin okuyabilmesi iÃ§...</summary>
    [Required]
    public string BARKOD { get; set; }

    /// <summary>Barkod yazdÄ±rma zamanÄ± bilgisidir.</summary>
    public DateTime BARKOD_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan cihaz iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼ret...</summary>
    [Required]
    [ForeignKey("CihazNavigation")]
    public string CIHAZ_KODU { get; set; }

    /// <summary>Tetkikin tÄ±bbi cihazda Ã§alÄ±ÅŸÄ±lmaya baÅŸlandÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime CALISMA_BASLAMA_ZAMANI { get; set; }

    /// <summary>Tetkikin tÄ±bbi cihazda Ã§alÄ±ÅŸÄ±lmasÄ±nÄ±n bittiÄŸi zaman bilgisidir.</summary>
    public DateTime CALISMA_BITIS_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavi alan hastaya istenen tetkiklerin kabulÃ¼nÃ¼ yapan SaÄŸlÄ±k B...</summary>
    [Required]
    [ForeignKey("KabulEdenKullaniciNavigation")]
    public string KABUL_EDEN_KULLANICI_KODU { get; set; }

    /// <summary>Radyolojik tetkik Ã§ekimini gerÃ§ekleÅŸtiren saÄŸlÄ±k tesisinde gÃ¶revli personel iÃ§in...</summary>
    [Required]
    [ForeignKey("TetkikCekenTeknisyenNavigation")]
    public string TETKIK_CEKEN_TEKNISYEN_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hastaya uygulanacak hizmetler iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi...</summary>
    [ForeignKey("HastaHizmetNavigation")]
    public string HASTA_HIZMET_KODU { get; set; }

    /// <summary>LOINC, SaÄŸlÄ±k tesisinde laboratuvar veya radyolojik tetkik sonuÃ§larÄ±nÄ±n sÄ±nÄ±flan...</summary>
    [Required]
    public string LOINC_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan tetkiklerin istenme durumuna iliÅŸkin Ã¶n kabul, kabul, s...</summary>
    [Required]
    [ForeignKey("TetkikIstenmeDurumuNavigation")]
    public string TETKIK_ISTENME_DURUMU { get; set; }

    /// <summary>Radyolojik tetkik Ã§ekimine ait eriÅŸim numarasÄ± (Accession Number) bilgisidir.</summary>
    [Required]
    public string ERISIM_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual BIRIM? BirimNavigation { get; set; }
    public virtual CIHAZ? CihazNavigation { get; set; }
    public virtual KULLANICI? KabulEdenKullaniciNavigation { get; set; }
    public virtual PERSONEL? TetkikCekenTeknisyenNavigation { get; set; }
    public virtual HASTA_HIZMET? HastaHizmetNavigation { get; set; }
    public virtual REFERANS_KODLAR? TetkikIstenmeDurumuNavigation { get; set; }
    #endregion

}
