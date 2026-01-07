using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// DISPROTEZ tablosu - 29 kolon
/// </summary>
[Table("DISPROTEZ")]
public class DISPROTEZ : VemEntity
{
    /// <summary>DiÅŸ protez tedavisi yapÄ±lan hastalar iÃ§in protez bilgilerini kayÄ±t etmek iÃ§in Sa...</summary>
    [Key]
    public string DISPROTEZ_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde baÅŸvuran hastaya yapÄ±lan diÅŸ protezinin baÅŸlama tarihini ifade ...</summary>
    public DateTime? DISPROTEZ_BASLAMA_TARIHI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [Required]
    [ForeignKey("TeknisyenNavigation")]
    public string TEKNISYEN_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli hekim iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼ret...</summary>
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan bÃ¶lÃ¼mler iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("BirimNavigation")]
    public string BIRIM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hastaya uygulanan diÅŸ protezinin tÃ¼rÃ¼ iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim...</summary>
    [ForeignKey("DisprotezIsTuruNavigation")]
    public string DISPROTEZ_IS_TURU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hastaya uygulanan diÅŸ protezi tedavisinin tÃ¼rÃ¼ ile ilgili SaÄŸlÄ±...</summary>
    [Required]
    [ForeignKey("DisprotezIsTuruAltNavigation")]
    public string DISPROTEZ_IS_TURU_ALT_KODU { get; set; }

    /// <summary>DiÅŸ protezi tedavisinde kullanÄ±lan parÃ§a sayÄ±sÄ± bilgisidir. Ã–rneÄŸin hareketli pr...</summary>
    [Required]
    public string PARCA_SAYISI { get; set; }

    /// <summary>DiÅŸe takÄ±lan sabit protezlerdeki ayak sayÄ±sÄ± bilgisidir.</summary>
    [Required]
    public string DISPROTEZ_AYAK_SAYISI { get; set; }

    /// <summary>DiÅŸ tedavisinde kullanÄ±lan sabit protezlerdeki gÃ¶vde sayÄ±sÄ± bilgisidir.</summary>
    [Required]
    public string DISPROTEZ_GOVDE_SAYISI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>DiÅŸ protezi iÅŸleminin saÄŸlÄ±k tesisinde yapÄ±ldÄ±ÄŸÄ± birim iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim...</summary>
    [Required]
    [ForeignKey("DisprotezBirimNavigation")]
    public string DISPROTEZ_BIRIM_KODU { get; set; }

    /// <summary>GerÃ§ekleÅŸtirilen iÅŸ tekrarlayan bir iÅŸlem (RPT) ise tekrarlanma sebebini ifade e...</summary>
    [Required]
    [ForeignKey("RptSebebiNavigation")]
    public string RPT_SEBEBI { get; set; }

    /// <summary>Tekrar edilen iÅŸin tekrar zamanÄ±nÄ± ifade eder.</summary>
    public DateTime RPT_ZAMANI { get; set; }

    /// <summary>RPT iÅŸlemini yapan personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼retile...</summary>
    [Required]
    [ForeignKey("RptEdenPersonelNavigation")]
    public string RPT_EDEN_PERSONEL_KODU { get; set; }

    /// <summary>Barkodun basÄ±ldÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime BARKOD_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde diÅŸ tedavisi alan hasta iÃ§in kalÄ±bÄ± Ã§Ä±karÄ±lan tedavi bÃ¶lgesini ...</summary>
    [Required]
    [ForeignKey("DisprotezKasikTuruNavigation")]
    public string DISPROTEZ_KASIK_TURU { get; set; }

    /// <summary>DiÅŸ protez tedavisinde kullanÄ±lan protez diÅŸin vita skalasÄ±na gÃ¶re deÄŸer bilgisi...</summary>
    [Required]
    [ForeignKey("DisprotezRengiNavigation")]
    public string DISPROTEZ_RENGI { get; set; }

    /// <summary>Protezi yapÄ±lan diÅŸin boyut bilgisidir. Ã–rneÄŸin kÃ¼Ã§Ã¼k, normal, bÃ¼yÃ¼k vb.</summary>
    [Required]
    [ForeignKey("DisBoyutBilgisiNavigation")]
    public string DIS_BOYUT_BILGISI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinin hizmet aldÄ±ÄŸÄ± dÄ±ÅŸ laboratuvarda yapÄ±lan diÅŸ protezi iÅŸlemi iÃ§in...</summary>
    [Required]
    public string DISPROTEZ_ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual PERSONEL? TeknisyenNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual BIRIM? BirimNavigation { get; set; }
    public virtual REFERANS_KODLAR? DisprotezIsTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? DisprotezIsTuruAltNavigation { get; set; }
    public virtual BIRIM? DisprotezBirimNavigation { get; set; }
    public virtual REFERANS_KODLAR? RptSebebiNavigation { get; set; }
    public virtual PERSONEL? RptEdenPersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? DisprotezKasikTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? DisprotezRengiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DisBoyutBilgisiNavigation { get; set; }
    #endregion

}
