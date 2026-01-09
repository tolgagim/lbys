using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// HASTA_FOTOGRAF tablosu - 12 kolon
/// </summary>
[Table("HASTA_FOTOGRAF")]
public class HASTA_FOTOGRAF : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde hastanÄ±n tedavisine yardÄ±mcÄ± olmak amacÄ± ile kaydedilen fotoÄŸra...</summary>
    [Key]
    public string HASTA_FOTOGRAF_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Saglik Bilgi YÃ¶netim Sistemine kayit edilmis fotograflar iÃ§in Saglik Bilgi YÃ¶net...</summary>
    [Required]
    [ForeignKey("FotografTuruNavigation")]
    public string FOTOGRAF_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin dosyasÄ± iÃ§in veya saÄŸlÄ±k tesisine mÃ¼racaat e...</summary>
    [Required]
    public string FOTOGRAF_BILGISI { get; set; }

    /// <summary>KiÅŸiye ait fotoÄŸrafÄ±n SaÄŸlÄ±k Bilgi YÃ¶netim Sistemiâ€™nde kayÄ±t edildiÄŸi dosyanÄ±n a...</summary>
    [Required]
    public string FOTOGRAF_DOSYA_YOLU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? FotografTuruNavigation { get; set; }
    #endregion

}
