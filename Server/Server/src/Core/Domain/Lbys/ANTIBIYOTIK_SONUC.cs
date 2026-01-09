using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// ANTIBIYOTIK_SONUC tablosu - 12 kolon
/// </summary>
[Table("ANTIBIYOTIK_SONUC")]
public class ANTIBIYOTIK_SONUC : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde laboratuvarda hastadan alÄ±nan materyallerde antibiyotik direnÃ§ ...</summary>
    [Key]
    public string ANTIBIYOTIK_SONUC_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde laboratuvarda yapÄ±lan testler sonucunda numunede Ã¼reyen bakteri...</summary>
    [ForeignKey("BakteriSonucNavigation")]
    public string BAKTERI_SONUC_KODU { get; set; }

    /// <summary>Penisilin, amikasin, gentamisin vb. antibiyotikler iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sis...</summary>
    [ForeignKey("AntibiyotikNavigation")]
    public string ANTIBIYOTIK_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan tetkiklerin sonuÃ§ bilgisidir.</summary>
    [ForeignKey("TetkikSonucuNavigation")]
    public string TETKIK_SONUCU { get; set; }

    /// <summary>Disk etrafÄ±nda bakterinin Ã¼remediÄŸi bÃ¶lgenin milimetrik olarak Ã§ap bilgisidir.</summary>
    [Required]
    public string ZON_CAPI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>Hastaya verilen tetkik sonuÃ§ raporunda tetkik, parametre, antibiyotik vb. sonucu...</summary>
    public string RAPORDA_GORULME_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual BAKTERI_SONUC? BakteriSonucNavigation { get; set; }
    public virtual REFERANS_KODLAR? AntibiyotikNavigation { get; set; }
    public virtual REFERANS_KODLAR? TetkikSonucuNavigation { get; set; }
    #endregion

}
