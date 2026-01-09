using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// GETAT tablosu - 15 kolon
/// </summary>
[Table("GETAT")]
public class GETAT : VemEntity
{
    /// <summary>Geleneksel ve TamamlayÄ±cÄ± TÄ±p Tedavisi (GETAT) kayÄ±tlarÄ± iÃ§in SaÄŸlÄ±k Bilgi YÃ¶net...</summary>
    [Key]
    public string GETAT_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± tablo adÄ± bilgisidir.</summary>
/// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Geleneksel ve TamamlayÄ±cÄ± TÄ±p UygulamalarÄ± (GETAT) uygulamasÄ±nÄ±...</summary>
    [ForeignKey("GetatUygulamaBirimiNavigation")]
    public string GETAT_UYGULAMA_BIRIMI { get; set; }

    /// <summary>Geleneksel ve tamamlayÄ±cÄ± tÄ±p tedavisinde oluÅŸan komplikasyon tanÄ± bilgisini ifa...</summary>
    [Required]
    [ForeignKey("KomplikasyonTanisiNavigation")]
    public string KOMPLIKASYON_TANISI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Geleneksel ve TamamlayÄ±cÄ± TÄ±p UygulamalarÄ± (GETAT) uygulamasÄ±nÄ±...</summary>
    [Required]
    [ForeignKey("GetatTedaviSonucuNavigation")]
    public string GETAT_TEDAVI_SONUCU { get; set; }

    /// <summary>Geleneksel ve TamamlayÄ±cÄ± TÄ±p UygulamalarÄ± (GETAT) iÅŸleminin tÃ¼r bilgisidir. Ã–rn...</summary>
    [ForeignKey("GetatUygulamaTuruNavigation")]
    public string GETAT_UYGULAMA_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Geleneksel ve TamamlayÄ±cÄ± TÄ±p UygulamalarÄ± (GETAT) uygulamasÄ±nÄ±...</summary>
    [ForeignKey("GetatUygulandigiDurumlarNavigation")]
    public string GETAT_UYGULANDIGI_DURUMLAR { get; set; }

    /// <summary>Geleneksel ve TamamlayÄ±cÄ± TÄ±p UygulamalarÄ± (GETAT) iÅŸleminin saÄŸlÄ±k hizmetini al...</summary>
    [ForeignKey("GetatUygulamaBolgesiNavigation")]
    public string GETAT_UYGULAMA_BOLGESI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? GetatUygulamaBirimiNavigation { get; set; }
    public virtual REFERANS_KODLAR? KomplikasyonTanisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? GetatTedaviSonucuNavigation { get; set; }
    public virtual REFERANS_KODLAR? GetatUygulamaTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? GetatUygulandigiDurumlarNavigation { get; set; }
    public virtual REFERANS_KODLAR? GetatUygulamaBolgesiNavigation { get; set; }
    #endregion

}
