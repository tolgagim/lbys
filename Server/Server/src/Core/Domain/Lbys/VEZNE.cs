using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// VEZNE tablosu - 24 kolon
/// </summary>
[Table("VEZNE")]
public class VEZNE : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisi veznesinde yapÄ±lan iÅŸlemlerin bilgisi iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Si...</summary>
    [Key]
    public string VEZNE_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [Required]
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki vezne birimi tarafÄ±ndan kesilen tahsilat veya Ã¶demelerin yÄ±l ...</summary>
    public string MAKBUZ_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisi veznesinde yapÄ±lan tahsilat veya Ã¶demelerle ilgili SaÄŸlÄ±k Bilgi YÃ¶...</summary>
    [Required]
    public string VEZNE_OZEL_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisi veznesinin yaptÄ±ÄŸÄ± iÅŸlemin tahsilat veya Ã¶deme iÅŸlemine iliÅŸkin bi...</summary>
    public string VEZNE_GIRIS_CIKIS_BILGISI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki vezne birimi tarafÄ±ndan kesilen tahsilat veya Ã¶demelerin yapÄ±...</summary>
    public DateTime? MAKBUZ_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan vezne birimleri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi taraf...</summary>
    [ForeignKey("VezneBirimNavigation")]
    public string VEZNE_BIRIM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen makbuzun seri numarasÄ± bilgisini ifade eder.</summary>
    [Required]
    public string MAKBUZ_SERI_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan bir iÅŸlemin iptal edilip edilmediÄŸi bilgisidir.</summary>
    public string IPTAL_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin iptal edildiÄŸi zaman bilgisidir.</summary>
    public DateTime IPTAL_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan bir iÅŸlemin iptal edilmesi durumunda SaÄŸlÄ±k Bilgi YÃ¶net...</summary>
    [Required]
    public string IPTAL_ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki vezne tarafÄ±ndan yapÄ±lan tahsilat ve Ã¶demelerin tÃ¼rÃ¼nÃ¼ ifade ...</summary>
    [Required]
    [ForeignKey("TahsilTuruNavigation")]
    public string TAHSIL_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinin veznesinde iÅŸlem yapÄ±lan makbuz tutarÄ± bilgisidir.</summary>
    public string MAKBUZ_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>Makbuz sahibinin adres bilgisidir.</summary>
    [Required]
    public string MAKBUZ_SAHIBI_ADRESI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinin mal veya hizmet alÄ±mÄ± yaptÄ±ÄŸÄ± firma iÃ§in ad bilgisidir.</summary>
    [Required]
    public string FIRMA_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinin mal veya hizmet alÄ±mÄ± yaptÄ±ÄŸÄ± firma iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim S...</summary>
    [Required]
    [ForeignKey("FirmaNavigation")]
    public string FIRMA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual BIRIM? VezneBirimNavigation { get; set; }
    public virtual REFERANS_KODLAR? TahsilTuruNavigation { get; set; }
    public virtual FIRMA? FirmaNavigation { get; set; }
    #endregion

}
