using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// DIYABET tablosu - 12 kolon
/// </summary>
[Table("DIYABET")]
public class DIYABET : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde bulunan cihaz iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼ret...</summary>
    [Key]
    public string DIYABET_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Hastaya izlem ve tedavi uygulanacak olan hastalÄ±k (diyabetis mellitus, kanser, H...</summary>
    public DateTime? ILK_TANI_TARIHI { get; set; }

    /// <summary>KiÅŸinin (gram cinsinden) aÄŸÄ±rlÄ±ÄŸÄ± bilgisidir.</summary>
    public string AGIRLIK { get; set; }

    /// <summary>KiÅŸinin santimetre cinsinden boy bilgisidir.</summary>
    public string BOY { get; set; }

    /// <summary>Diabetes Mellitus (Åžeker HastalÄ±ÄŸÄ±) tanÄ±sÄ± alan hastanÄ±n ve /veya ailesinin hast...</summary>
    [Required]
    [ForeignKey("DiyabetEgitimiNavigation")]
    public string DIYABET_EGITIMI { get; set; }

    /// <summary>KiÅŸide geliÅŸen diyabet komplikasyonlarÄ± bilgisidir.</summary>
    [ForeignKey("DiyabetKomplikasyonlariNavigation")]
    public string DIYABET_KOMPLIKASYONLARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyabetEgitimiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyabetKomplikasyonlariNavigation { get; set; }
    #endregion

}
