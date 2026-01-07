using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// HASTA_ARSIV tablosu - 14 kolon
/// </summary>
[Table("HASTA_ARSIV")]
public class HASTA_ARSIV : VemEntity
{
    /// <summary>ArÅŸivde bulunan hasta dosyasÄ± bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±...</summary>
    [Key]
    public string HASTA_ARSIV_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Hasta dosyasÄ±nÄ±n arÅŸiv numarasÄ± bilgisidir.</summary>
    public string ARSIV_NUMARASI { get; set; }

    /// <summary>HastanÄ±n herhangi bir saÄŸlÄ±k tesisinde bulunan saÄŸlÄ±k bilgilerinin yer aldÄ±ÄŸÄ± do...</summary>
    [Required]
    public string ESKI_ARSIV_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki birimlerde oluÅŸturulan, hasta bilgilerinin olduÄŸu dosyalarÄ±n ...</summary>
    [ForeignKey("ArsivDefterTuruNavigation")]
    public string ARSIV_DEFTER_TURU { get; set; }

    /// <summary>Hasta dosyanÄ±n arÅŸivdeki fiziksel yerinin bilgisidir. Ã–rneÄŸin bina/oda/raf bloÄŸu...</summary>
    [Required]
    public string ARSIV_YERI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>Hasta dosyasÄ±nÄ±n saÄŸlÄ±k tesisi arÅŸivine ilk kayÄ±t edilen tarih bilgisidir.</summary>
    public DateTime ARSIV_ILK_GIRIS_TARIHI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual REFERANS_KODLAR? ArsivDefterTuruNavigation { get; set; }
    #endregion

}
