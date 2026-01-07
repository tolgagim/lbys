using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// KUDUZ_IZLEM tablosu - 13 kolon
/// </summary>
[Table("KUDUZ_IZLEM")]
public class KUDUZ_IZLEM : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde tedavi olan hastalarÄ±n kuduz izlem bilgileri iÃ§in SaÄŸlÄ±k Bilgi ...</summary>
    [Key]
    public string KUDUZ_IZLEM_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Kuduz ÅŸÃ¼pheli temaslÄ±lar ve risk grubunda yer alan ve temas Ã¶ncesi profilaksi ih...</summary>
    [Required]
    [ForeignKey("ProfilaksiTamamlanmaDurumuNavigation")]
    public string PROFILAKSI_TAMAMLANMA_DURUMU { get; set; }

    /// <summary>Kuduz ÅŸÃ¼pheli temasa maruz kalan kiÅŸiye kuduz profilaksisi programÄ± Ã§erÃ§evesinde...</summary>
    [Required]
    [ForeignKey("UygulananKuduzProfilaksisiNavigation")]
    public string UYGULANAN_KUDUZ_PROFILAKSISI { get; set; }

    /// <summary>KiÅŸinin kuduz aÅŸÄ±sÄ±nÄ± yaptÄ±rdÄ±ÄŸÄ± veya yaptÄ±racaÄŸÄ±nÄ± beyan ettiÄŸi Toplum SaÄŸlÄ±ÄŸÄ± ...</summary>
    [Required]
    [ForeignKey("BeyanTsmKurumNavigation")]
    public string BEYAN_TSM_KURUM_KODU { get; set; }

    /// <summary>Uygulanan immÃ¼nglobilinin IU cinsinden miktar bilgisidir.</summary>
    [Required]
    public string IMMUNGLOBULIN_MIKTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? ProfilaksiTamamlanmaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? UygulananKuduzProfilaksisiNavigation { get; set; }
    public virtual KURUM? BeyanTsmKurumNavigation { get; set; }
    #endregion

}
