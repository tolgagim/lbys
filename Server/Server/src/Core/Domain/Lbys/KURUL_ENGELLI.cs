using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// KURUL_ENGELLI tablosu - 14 kolon
/// </summary>
[Table("KURUL_ENGELLI")]
public class KURUL_ENGELLI : VemEntity
{
    /// <summary>SaÄŸlÄ±k kurulunda dÃ¼zenlenen engelli raporlarÄ±na ait bilgiler iÃ§in SaÄŸlÄ±k Bilgi Y...</summary>
    [Key]
    public string KURUL_ENGELLI_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Hastaya saÄŸlÄ±k raporu veren kurul iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("KurulRaporNavigation")]
    public string KURUL_RAPOR_KODU { get; set; }

    /// <summary>Engelli raporu dÃ¼zenlenen kiÅŸinin, Ã§alÄ±ÅŸtÄ±rÄ±lamayacaÄŸÄ± iÅŸlerin niteliÄŸini ifade ...</summary>
    [Required]
    public string CALISTIRILAMAYACAK_ISNITELIGI { get; set; }

    /// <summary>Engelli raporu dÃ¼zenlenen kiÅŸiye ait raporun sÃ¼reklilik durumunu ifade eder.</summary>
    [Required]
    public string ENGELLI_SUREKLILIK_DURUMU { get; set; }

    /// <summary>Engel durumuna gÃ¶re engellilik oranÄ± %50 ve Ã¼zerinde olduÄŸu tespit edilenlerden ...</summary>
    [Required]
    public string AGIR_ENGELLI { get; set; }

    /// <summary>Engelli raporu dÃ¼zenlenen kiÅŸinin engellilik grubunu ifade eder.</summary>
    [Required]
    public string ENGELLI_GRUBU { get; set; }

    /// <summary>Engelli raporu dÃ¼zenlenen kiÅŸinin raporu kullanÄ±m amacÄ±nÄ± ifade eder.</summary>
    [Required]
    public string ENGELLI_RAPOR_KULLANIM_AMACI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual KURUL_RAPOR? KurulRaporNavigation { get; set; }
    #endregion

}
