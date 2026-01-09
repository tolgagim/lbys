using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// OBEZITE_IZLEM tablosu - 16 kolon
/// </summary>
[Table("OBEZITE_IZLEM")]
public class OBEZITE_IZLEM : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde muayene olan hastalarÄ±n obezite izlem bilgileri iÃ§in SaÄŸlÄ±k Bil...</summary>
    [Key]
    public string OBEZITE_IZLEM_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Hastalara diyetisyen tarafÄ±ndan verilen diyet programÄ±nÄ±n varlÄ±ÄŸÄ±nÄ± ve hastanÄ±n ...</summary>
    [Required]
    [ForeignKey("DiyetTibbiBeslenmeTedavisiNavigation")]
    public string DIYET_TIBBI_BESLENME_TEDAVISI { get; set; }

    /// <summary>Hastaya izlem ve tedavi uygulanacak olan hastalÄ±k (diyabetis mellitus, kanser, H...</summary>
    public DateTime ILK_TANI_TARIHI { get; set; }

    /// <summary>Morbid obez tanÄ±sÄ± olan (BKI 40 kg/m2 ve Ã¼stÃ¼) hastalarda lenfatik Ã¶dem olup olm...</summary>
    [Required]
    [ForeignKey("MorbitObezLenfatikOdemNavigation")]
    public string MORBIT_OBEZ_LENFATIK_ODEM { get; set; }

    /// <summary>Diyet (tÄ±bbi beslenme) ve egzersizi iÃ§eren davranÄ±ÅŸ tedavisine yanÄ±t alÄ±namayan ...</summary>
    [Required]
    [ForeignKey("ObeziteIlacTedavisiNavigation")]
    public string OBEZITE_ILAC_TEDAVISI { get; set; }

    /// <summary>Obezite ve diyabet ile iliÅŸkili tutum ve davranÄ±ÅŸlara yÃ¶nelik farkÄ±ndalÄ±ÄŸÄ±n bili...</summary>
    [Required]
    [ForeignKey("PsikolojikTedaviNavigation")]
    public string PSIKOLOJIK_TEDAVI { get; set; }

    /// <summary>Hastaya konulan tanÄ±ya eÅŸlik eden hastalÄ±klardÄ±r.</summary>
    [Required]
    [ForeignKey("BirlikteGorulenEkHastalikNavigation")]
    public string BIRLIKTE_GORULEN_EK_HASTALIK { get; set; }

    /// <summary>HastanÄ±n gÃ¼nlÃ¼k fiziksel aktivite dÃ¼zeyini ifade eder.</summary>
    [Required]
    [ForeignKey("EgzersizNavigation")]
    public string EGZERSIZ { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyetTibbiBeslenmeTedavisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? MorbitObezLenfatikOdemNavigation { get; set; }
    public virtual REFERANS_KODLAR? ObeziteIlacTedavisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? PsikolojikTedaviNavigation { get; set; }
    public virtual REFERANS_KODLAR? BirlikteGorulenEkHastalikNavigation { get; set; }
    public virtual REFERANS_KODLAR? EgzersizNavigation { get; set; }
    #endregion

}
