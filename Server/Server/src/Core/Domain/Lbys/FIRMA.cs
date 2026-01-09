using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// FIRMA tablosu - 19 kolon
/// </summary>
[Table("FIRMA")]
public class FIRMA : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinin mal veya hizmet alÄ±mÄ± yaptÄ±ÄŸÄ± firma iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim S...</summary>
    [Key]
    public string FIRMA_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinin mal veya hizmet alÄ±mÄ± yaptÄ±ÄŸÄ± firma iÃ§in ad bilgisidir.</summary>
    public string FIRMA_ADI { get; set; }

    /// <summary>Telefon numarasÄ± bilgisini ifade eder.</summary>
    [Required]
    public string TELEFON_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine hizmet veren firma yetkilisinin ad ve soyadÄ± bilgisidir.</summary>
    [Required]
    public string YETKILI_KISI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinin mal veya hizmet alÄ±mÄ± yaptÄ±ÄŸÄ± firmanÄ±n adres bilgisidir.</summary>
    [Required]
    public string FIRMA_ADRESI { get; set; }

    /// <summary>SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi veri tabanÄ±nda bulunan bir kayÄ±tÄ±n aktif olup olmad...</summary>
    [Required]
    public string AKTIFLIK_BILGISI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinin hizmet aldÄ±ÄŸÄ± firmanÄ±n baÄŸlÄ± olduÄŸu vergi dairesi bilgisidir.</summary>
    [Required]
    public string VERGI_DAIRESI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinin hizmet aldÄ±ÄŸÄ± firmaya ait vergi numarasÄ± bilgisidir.</summary>
    [Required]
    public string VERGI_NUMARASI { get; set; }

    /// <summary>Firma e-posta adresi bilgisidir.</summary>
    [Required]
    public string EPOSTA_ADRESI { get; set; }

    /// <summary>Firmaya ait IBAN numarasÄ± bilgisidir.</summary>
    [Required]
    public string IBAN_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    #endregion

}
