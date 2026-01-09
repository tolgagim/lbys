using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// HASTA_ARSIV_DETAY tablosu - 16 kolon
/// </summary>
[Table("HASTA_ARSIV_DETAY")]
public class HASTA_ARSIV_DETAY : VemEntity
{
    /// <summary>ArÅŸivde bulunan hasta dosyasÄ± detay bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi ...</summary>
    [Key]
    public string HASTA_ARSIV_DETAY_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>ArÅŸivde bulunan hasta dosyasÄ± bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±...</summary>
    [ForeignKey("HastaArsivNavigation")]
    public string HASTA_ARSIV_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki hasta dosyasÄ±nÄ± teslim alan birim iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim S...</summary>
    [Required]
    [ForeignKey("DosyaAlanBirimNavigation")]
    public string DOSYA_ALAN_BIRIM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan hasta dosyasÄ±nÄ±n arÅŸivden alÄ±ndÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime DOSYANIN_ALINDIGI_ZAMAN { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki hasta dosyasÄ±nÄ± teslim alan personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶neti...</summary>
    [Required]
    [ForeignKey("DosyaAlanPersonelNavigation")]
    public string DOSYA_ALAN_PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki hasta dosyasÄ±nÄ± arÅŸive veren birimler iÃ§in SaÄŸlÄ±k Bilgi YÃ¶net...</summary>
    [Required]
    [ForeignKey("DosyaVerenBirimNavigation")]
    public string DOSYA_VEREN_BIRIM_KODU { get; set; }

    /// <summary>DosyanÄ±n verildiÄŸi zaman bilgisidir.</summary>
    public DateTime DOSYANIN_VERILDIGI_ZAMAN { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta dosyasÄ±nÄ± arÅŸive veren kullanÄ±cÄ± iÃ§in SaÄŸlÄ±k Bilgi YÃ¶neti...</summary>
    [Required]
    [ForeignKey("DosyaVerenKullaniciNavigation")]
    public string DOSYA_VEREN_KULLANICI_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA_ARSIV? HastaArsivNavigation { get; set; }
    public virtual BIRIM? DosyaAlanBirimNavigation { get; set; }
    public virtual PERSONEL? DosyaAlanPersonelNavigation { get; set; }
    public virtual BIRIM? DosyaVerenBirimNavigation { get; set; }
    public virtual KULLANICI? DosyaVerenKullaniciNavigation { get; set; }
    #endregion

}
