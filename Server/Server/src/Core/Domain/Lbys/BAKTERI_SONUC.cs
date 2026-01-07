using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// BAKTERI_SONUC tablosu - 12 kolon
/// </summary>
[Table("BAKTERI_SONUC")]
public class BAKTERI_SONUC : VemEntity
{
    /// <summary>SBYS tarafÄ±ndan Ã¼retilen tekil kod bilgisidir.</summary>
    [Key]
    public string BAKTERI_SONUC_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan tetkiklerin sonuÃ§larÄ± iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi...</summary>
    [ForeignKey("TetkikSonucNavigation")]
    public string TETKIK_SONUC_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde laboratuvarda yapÄ±lan testler sonucunda numunede Ã¼reyebilecek b...</summary>
    [ForeignKey("BakteriNavigation")]
    public string BAKTERI_KODU { get; set; }

    /// <summary>Koloni sayÄ±sÄ± bilgisidir.</summary>
    [Required]
    public string KOLONI_SAYISI { get; set; }

    /// <summary>Hastaya verilen tetkik sonuÃ§ raporunda tetkik veya parametrenin bulunduÄŸu sÄ±ra b...</summary>
    [Required]
    public string RAPOR_SONUC_SIRASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual TETKIK_SONUC? TetkikSonucNavigation { get; set; }
    public virtual REFERANS_KODLAR? BakteriNavigation { get; set; }
    #endregion

}
