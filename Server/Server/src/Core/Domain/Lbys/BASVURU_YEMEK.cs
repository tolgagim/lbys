using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// BASVURU_YEMEK tablosu - 12 kolon
/// </summary>
[Table("BASVURU_YEMEK")]
public class BASVURU_YEMEK : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde yatan hastaya verilen yemek bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim...</summary>
    [Key]
    public string BASVURU_YEMEK_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± tablo adÄ± bilgisidir.</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yatan hastaya verilen yemeÄŸin normal yemek, diyet yemeÄŸi, diyab...</summary>
    [ForeignKey("YemekTuruNavigation")]
    public string YEMEK_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yatan hastalara verilen yemeÄŸin tÃ¼r bilgisini ifade eder. Ã–rneÄŸ...</summary>
    [ForeignKey("YemekZamaniTuruNavigation")]
    public string YEMEK_ZAMANI_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yatan hastaya yemeÄŸin verildiÄŸi zaman bilgisidir.</summary>
    public DateTime? YEMEK_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? YemekTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? YemekZamaniTuruNavigation { get; set; }
    #endregion

}
