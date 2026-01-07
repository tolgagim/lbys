using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// HASTA_GIZLILIK tablosu - 15 kolon
/// </summary>
[Table("HASTA_GIZLILIK")]
public class HASTA_GIZLILIK : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde gizlenen hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tara...</summary>
    [Key]
    public string HASTA_GIZLILIK_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>KiÅŸinin, saÄŸlÄ±k tesisindeki verilerinin gizli olmasÄ± durumunda verilerin gizlenm...</summary>
    [ForeignKey("GizlilikNedeniNavigation")]
    public string GIZLILIK_NEDENI { get; set; }

    /// <summary>HastanÄ±n tÄ±bbi iÅŸlemleri ile ilgili ekranlarda (arayÃ¼zlerde) kullanÄ±lacak ad bil...</summary>
    [Required]
    public string GORUNECEK_HASTA_ADI { get; set; }

    /// <summary>HastanÄ±n tÄ±bbi iÅŸlemleri ile ilgili ekranlarda (arayÃ¼zlerde) kullanÄ±lacak soyadÄ±...</summary>
    [Required]
    public string GORUNECEK_HASTA_SOYADI { get; set; }

    /// <summary>KiÅŸinin, saÄŸlÄ±k tesisindeki hangi verilerinin gizlendiÄŸini ifade eder. Ã–rneÄŸin h...</summary>
    [ForeignKey("GizlilikTuruNavigation")]
    public string GIZLILIK_TURU { get; set; }

    /// <summary>KiÅŸinin, saÄŸlÄ±k tesisindeki verilerinin gizlenmesi talebine iliÅŸkin olarak kiÅŸin...</summary>
    public DateTime? GIZLILIK_BASLAMA_ZAMANI { get; set; }

    /// <summary>KiÅŸinin, saÄŸlÄ±k tesisindeki verilerinin gizlilik durumunun bittiÄŸi zaman bilgisi...</summary>
    public DateTime GIZLILIK_BITIS_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? GizlilikNedeniNavigation { get; set; }
    public virtual REFERANS_KODLAR? GizlilikTuruNavigation { get; set; }
    #endregion

}
