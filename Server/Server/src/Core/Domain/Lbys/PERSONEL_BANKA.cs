using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// PERSONEL_BANKA tablosu - 14 kolon
/// </summary>
[Table("PERSONEL_BANKA")]
public class PERSONEL_BANKA : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin banka bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Si...</summary>
    [Key]
    public string PERSONEL_BANKA_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinin hizmet aldÄ±ÄŸÄ± banka isim bilgisidir. Ã–rneÄŸin T.C Ziraat BankasÄ±...</summary>
    [ForeignKey("BankaNavigation")]
    public string BANKA { get; set; }

    /// <summary>KiÅŸinin banka hesap numarasÄ± bilgisidir.</summary>
    [Required]
    public string HESAP_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin hesap numarasÄ±nÄ±n ÅŸube kodu bilgisidir.</summary>
    [Required]
    public string SUBE_KODU { get; set; }

    /// <summary>Firmaya ait IBAN numarasÄ± bilgisidir.</summary>
    [Required]
    public string IBAN_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶rev yapan personel iÃ§in hesaplanan Ã¶demenin tÃ¼r bilgisidir.</summary>
    [Required]
    [ForeignKey("BordroTuruNavigation")]
    public string BORDRO_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi' de kayÄ±tlÄ± ban...</summary>
    public string HESAP_AKTIFLIK_BILGISI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual PERSONEL? PersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? BankaNavigation { get; set; }
    public virtual REFERANS_KODLAR? BordroTuruNavigation { get; set; }
    #endregion

}
