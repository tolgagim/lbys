using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// AMELIYAT_ISLEM tablosu - 21 kolon
/// </summary>
[Table("AMELIYAT_ISLEM")]
public class AMELIYAT_ISLEM : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan ameliyatÄ±n iÅŸlem bilgilerine eriÅŸim saÄŸlamak iÃ§in SaÄŸlÄ±...</summary>
    [Key]
    public string AMELIYAT_ISLEM_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan ameliyatÄ±n bilgilerine eriÅŸim saÄŸlamak iÃ§in SaÄŸlÄ±k Bilg...</summary>
    [ForeignKey("AmeliyatNavigation")]
    public string AMELIYAT_KODU { get; set; }

    /// <summary>TÄ±bbi Ä°ÅŸlemler Listesinde yayÄ±mlanan ameliyat grubu bilgisidir. Ã–rneÄŸin A1, A2, ...</summary>
    [Required]
    public string AMELIYAT_GRUBU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hastaya uygulanacak hizmetler iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi...</summary>
    [ForeignKey("HastaHizmetNavigation")]
    public string HASTA_HIZMET_KODU { get; set; }

    /// <summary>Cerrahi uygulama sÄ±rasÄ±nda yapÄ±lan kesi sayÄ±sÄ± bilgisidir.</summary>
    public string KESI_SAYISI { get; set; }

    /// <summary>Cerrahi uygulama sÄ±rasÄ±nda yapÄ±lan kesi iÃ§in belirlenen oran bilgisidir. Ã–rneÄŸin...</summary>
    [Required]
    [ForeignKey("KesiOraniNavigation")]
    public string KESI_ORANI { get; set; }

    /// <summary>Hastaya uygulanan cerrahi giriÅŸimde seans ve kesi arasÄ±ndaki iliÅŸkiyi ifade eden...</summary>
    [Required]
    [ForeignKey("KesiSeansBilgisiNavigation")]
    public string KESI_SEANS_BILGISI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hastaya uygulanan iÅŸlemin vÃ¼cudun hangi tarafÄ±na yapÄ±ldÄ±ÄŸÄ±na il...</summary>
    [Required]
    [ForeignKey("TarafBilgisiNavigation")]
    public string TARAF_BILGISI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavi alan hastaya uygulanan cerrahi giriÅŸim sonrasÄ±nda hastad...</summary>
    [Required]
    public string KOMPLIKASYON { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan ameliyatÄ±n sonuÃ§ bilgisini ifade eder.</summary>
    [Required]
    public string AMELIYAT_SONUCU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan ameliyatÄ±n tÃ¼m sÃ¼reÃ§lerine iliÅŸkin operatÃ¶r tarafÄ±ndan ...</summary>
    [Required]
    public string AMELIYAT_NOTU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde ameliyat olacak hastanÄ±n ameliyat Ã¶ncesi fiziki saÄŸlÄ±k durumunu...</summary>
    [Required]
    [ForeignKey("AsaSkoruNavigation")]
    public string ASA_SKORU { get; set; }

    /// <summary>Avrupa Kardiyak Operasyonel Risk DeÄŸerlendirme Sistemi (EuroSCORE), kalp ameliya...</summary>
    [Required]
    [ForeignKey("EuroscoreNavigation")]
    public string EUROSCORE { get; set; }

    /// <summary>SaÄŸlÄ±k hizmetini alan kiÅŸinin vÃ¼cudunda bulunan/oluÅŸan yaralarÄ±n sÄ±nÄ±fÄ±na iliÅŸki...</summary>
    [Required]
    [ForeignKey("YaraSinifiNavigation")]
    public string YARA_SINIFI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual AMELIYAT? AmeliyatNavigation { get; set; }
    public virtual HASTA_HIZMET? HastaHizmetNavigation { get; set; }
    public virtual REFERANS_KODLAR? KesiOraniNavigation { get; set; }
    public virtual REFERANS_KODLAR? KesiSeansBilgisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? TarafBilgisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? AsaSkoruNavigation { get; set; }
    public virtual REFERANS_KODLAR? EuroscoreNavigation { get; set; }
    public virtual REFERANS_KODLAR? YaraSinifiNavigation { get; set; }
    #endregion

}
