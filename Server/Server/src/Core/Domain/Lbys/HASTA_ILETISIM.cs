using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// HASTA_ILETISIM tablosu - 25 kolon
/// </summary>
[Table("HASTA_ILETISIM")]
public class HASTA_ILETISIM : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde hastadan alÄ±nan iletiÅŸim bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Si...</summary>
    [Key]
    public string HASTA_ILETISIM_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>KiÅŸiye ait kayÄ±t altÄ±na alÄ±nacak adresin tipini ifade eder.</summary>
    [Required]
    [ForeignKey("AdresTipiNavigation")]
    public string ADRES_TIPI { get; set; }

    /// <summary>Adres kodunun hangi seviyeden seÃ§ildiÄŸini ifade eder.</summary>
    [ForeignKey("AdresSeviyesiNavigation")]
    public string ADRES_KODU_SEVIYESI { get; set; }

    /// <summary>KiÅŸinin beyan ettiÄŸi adres bilgisidir.</summary>
    [Required]
    public string BEYAN_ADRESI { get; set; }

    /// <summary>NÃ¼fus ve VatandaÅŸlÄ±k Ä°ÅŸleri (NVÄ°) Genel MÃ¼dÃ¼rlÃ¼ÄŸÃ¼ tarafÄ±ndan SaÄŸlÄ±k Bilgi YÃ¶neti...</summary>
    [Required]
    public string NVI_ADRES { get; set; }

    /// <summary>Adres numarasÄ± bilgisidir.</summary>
    [Required]
    public string ADRES_NUMARASI { get; set; }

    /// <summary>Ä°l kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("IlNavigation")]
    public string IL_KODU { get; set; }

    /// <summary>Ä°lÃ§e kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("IlceNavigation")]
    public string ILCE_KODU { get; set; }

    /// <summary>NÃ¼fus ve VatandaÅŸlÄ±k Ä°ÅŸlerinden (NVÄ°) alÄ±nan Bucak kod bilgisidir. Ã–rneÄŸin Kemal...</summary>
    [Required]
    [ForeignKey("BucakNavigation")]
    public string BUCAK_KODU { get; set; }

    /// <summary>NÃ¼fus ve VatandaÅŸlÄ±k Ä°ÅŸlerinden (NVÄ°) alÄ±nan KÃ¶y kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("KoyNavigation")]
    public string KOY_KODU { get; set; }

    /// <summary>NÃ¼fus ve VatandaÅŸlÄ±k Ä°ÅŸlerinden (NVÄ°) alÄ±nan Mahalle kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("MahalleNavigation")]
    public string MAHALLE_KODU { get; set; }

    /// <summary>MERNÄ°S tarafÄ±ndan Ã¼retilen Cadde Sokak Bucak Mahalle (CSBM) kodu bilgisidir.</summary>
    [Required]
    public string CSBM_KODU { get; set; }

    /// <summary>Adresin dÄ±ÅŸ kapÄ± numarasÄ± bilgisidir.</summary>
    [Required]
    public string DIS_KAPI_NUMARASI { get; set; }

    /// <summary>Adresin iÃ§ kapÄ± numarasÄ± bilgisidir.</summary>
    [Required]
    public string IC_KAPI_NUMARASI { get; set; }

    /// <summary>KiÅŸinin ev telefonu bilgisidir.</summary>
    [Required]
    public string EV_TELEFONU { get; set; }

    /// <summary>KiÅŸinin cep telefonu bilgisidir.</summary>
    [Required]
    public string CEP_TELEFONU { get; set; }

    /// <summary>KiÅŸinin iÅŸ telefonu bilgisidir.</summary>
    [Required]
    public string IS_TELEFONU { get; set; }

    /// <summary>KiÅŸinin elektronik posta adresidir.</summary>
    [Required]
    public string EPOSTA_ADRESI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? AdresTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? AdresSeviyesiNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlceNavigation { get; set; }
    public virtual REFERANS_KODLAR? BucakNavigation { get; set; }
    public virtual REFERANS_KODLAR? KoyNavigation { get; set; }
    public virtual REFERANS_KODLAR? MahalleNavigation { get; set; }
    #endregion

}
