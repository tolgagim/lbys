using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// KURUL_ASKERI tablosu - 17 kolon
/// </summary>
[Table("KURUL_ASKERI")]
public class KURUL_ASKERI : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde dÃ¼zenlenen saÄŸlÄ±k kurulu tarafÄ±ndan verilen raporlarÄ±n tanÄ±m bi...</summary>
    [Key]
    public string KURUL_ASKERI_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>Kurul adÄ± bilgisidir.</summary>
    public string KURUL_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde dÃ¼zenlenen heyet veya tek hekim raporlarÄ± iÃ§in MEDULA tarafÄ±nda...</summary>
    [ForeignKey("MedulaRaporTuruNavigation")]
    public string MEDULA_RAPOR_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavi olan hastalar iÃ§in dÃ¼zenlenmiÅŸ heyet veya tek hekim rapo...</summary>
    [Required]
    [ForeignKey("MedulaAltRaporTuruNavigation")]
    public string MEDULA_ALT_RAPOR_TURU { get; set; }

    /// <summary>KiÅŸinin alkol veya madde baÄŸÄ±mlÄ±sÄ± olup olmadÄ±ÄŸÄ±na iliÅŸkin bilgiyi ifade eder.</summary>
    [Required]
    [ForeignKey("AlkolMaddeBagimliligiNavigation")]
    public string ALKOL_MADDE_BAGIMLILIGI { get; set; }

    /// <summary>KiÅŸinin bedensel veya ruhsal ileri tetkik bulgusuna ait bilgiyi ifade eder.</summary>
    [Required]
    [ForeignKey("BedenRuhIleriTetkikBulgusuNavigation")]
    public string BEDEN_RUH_ILERI_TETKIK_BULGUSU { get; set; }

    /// <summary>KiÅŸinin geÃ§miÅŸ hastalÄ±ÄŸÄ±na dair kayÄ±t bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("GecmisHastaligaDairKayitNavigation")]
    public string GECMIS_HASTALIGA_DAIR_KAYIT { get; set; }

    /// <summary>KiÅŸinin gÃ¶rme veya iÅŸitme kaybÄ± olup olmadÄ±ÄŸÄ± bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("GormeIsitmeKaybiNavigation")]
    public string GORME_ISITME_KAYBI { get; set; }

    /// <summary>KiÅŸinin psikiyatrik rahatsÄ±zlÄ±k durumuna iliÅŸkin bilgiyi ifade eder.</summary>
    [Required]
    [ForeignKey("PsikiyatrikRahatsizlikNavigation")]
    public string PSIKIYATRIK_RAHATSIZLIK { get; set; }

    /// <summary>KiÅŸinin uzuv kaybÄ± veya ortopedik rahatsÄ±zlÄ±ÄŸÄ± olup olmadÄ±ÄŸÄ± bilgisini ifade ede...</summary>
    [ForeignKey("UzuvkaybiOrtopediRahatsizlikNavigation")]
    public string UZUVKAYBI_ORTOPEDI_RAHATSIZLIK { get; set; }

    /// <summary>KiÅŸinin asal hastalÄ±k bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("AsalHastalikNavigation")]
    public string ASAL_HASTALIK { get; set; }

    /// <summary>KiÅŸinin asal hastalÄ±k tipi bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("AsalHastalikTipiNavigation")]
    public string ASAL_HASTALIK_TIPI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual REFERANS_KODLAR? MedulaRaporTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? MedulaAltRaporTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? AlkolMaddeBagimliligiNavigation { get; set; }
    public virtual REFERANS_KODLAR? BedenRuhIleriTetkikBulgusuNavigation { get; set; }
    public virtual REFERANS_KODLAR? GecmisHastaligaDairKayitNavigation { get; set; }
    public virtual REFERANS_KODLAR? GormeIsitmeKaybiNavigation { get; set; }
    public virtual REFERANS_KODLAR? PsikiyatrikRahatsizlikNavigation { get; set; }
    public virtual REFERANS_KODLAR? UzuvkaybiOrtopediRahatsizlikNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsalHastalikNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsalHastalikTipiNavigation { get; set; }
    #endregion

}
