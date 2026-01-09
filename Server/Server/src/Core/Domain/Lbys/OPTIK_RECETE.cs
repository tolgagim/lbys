using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// OPTIK_RECETE tablosu - 46 kolon
/// </summary>
[Table("OPTIK_RECETE")]
public class OPTIK_RECETE : VemEntity
{
    /// <summary>Optik reÃ§ete bilgisi iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼retilen tekil...</summary>
    [Key]
    public string OPTIK_RECETE_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>ReÃ§ete edilen gÃ¶zlÃ¼k iÃ§in normal, teleskopik, lens vb. tip bilgisidir.</summary>
    [ForeignKey("GozlukReceteTipiNavigation")]
    public string GOZLUK_RECETE_TIPI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli hekim iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼ret...</summary>
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }

    /// <summary>ReÃ§etenin yazÄ±ldÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime? RECETE_ZAMANI { get; set; }

    /// <summary>KiÅŸinin kullandÄ±ÄŸÄ± ya da kiÅŸiye reÃ§ete edilen gÃ¶zlÃ¼ÄŸÃ¼n tÃ¼rÃ¼nÃ¼ ifade eder. Ã–rneÄŸi...</summary>
    [ForeignKey("GozlukTuruNavigation")]
    public string GOZLUK_TURU { get; set; }

    /// <summary>GÃ¶zlÃ¼ÄŸÃ¼n saÄŸ camÄ±nÄ±n hangi tipte olduÄŸunu ifade eder. Ã–rneÄŸin dÃ¼z, organik, bifo...</summary>
    [Required]
    [ForeignKey("SagCamTipiNavigation")]
    public string SAG_CAM_TIPI { get; set; }

    /// <summary>GÃ¶zlÃ¼ÄŸÃ¼n saÄŸ camÄ±nÄ±n renk bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("SagCamRengiNavigation")]
    public string SAG_CAM_RENGI { get; set; }

    /// <summary>GÃ¶zlÃ¼ÄŸÃ¼n saÄŸ camÄ±nÄ±n sferik deÄŸer bilgisini ifade eder.</summary>
    [Required]
    public string SAG_CAM_SFERIK { get; set; }

    /// <summary>GÃ¶zlÃ¼ÄŸÃ¼n saÄŸ camÄ±nÄ±n silindirik deÄŸer bilgisini ifade eder.</summary>
    [Required]
    public string SAG_CAM_SILINDIRIK { get; set; }

    /// <summary>GÃ¶zlÃ¼ÄŸÃ¼n saÄŸ camÄ±ndaki astigmat aÃ§Ä±sÄ±nÄ±n (Aks) deÄŸer bilgisini ifade eder.</summary>
    [Required]
    public string SAG_CAM_AKS { get; set; }

    /// <summary>GÃ¶zlÃ¼ÄŸÃ¼n sol camÄ±nÄ±n hangi tipte olduÄŸunu ifade eder. Ã–rneÄŸin dÃ¼z, organik, bifo...</summary>
    [Required]
    [ForeignKey("SolCamTipiNavigation")]
    public string SOL_CAM_TIPI { get; set; }

    /// <summary>GÃ¶zlÃ¼ÄŸÃ¼n sol camÄ±nÄ±n renk bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("SolCamRengiNavigation")]
    public string SOL_CAM_RENGI { get; set; }

    /// <summary>GÃ¶zlÃ¼ÄŸÃ¼n sol camÄ±nÄ±n sferik deÄŸer bilgisini ifade eder.</summary>
    [Required]
    public string SOL_CAM_SFERIK { get; set; }

    /// <summary>GÃ¶zlÃ¼ÄŸÃ¼n sol camÄ±nÄ±n silindirik deÄŸer bilgisini ifade eder.</summary>
    [Required]
    public string SOL_CAM_SILINDIRIK { get; set; }

    /// <summary>GÃ¶zlÃ¼ÄŸÃ¼n sol camÄ±ndaki astigmat aÃ§Ä±sÄ±nÄ±n (Aks) deÄŸer bilgisini ifade eder.</summary>
    [Required]
    public string SOL_CAM_AKS { get; set; }

    /// <summary>SaÄŸ lensin cam sferik deÄŸer bilgisini ifade eder.</summary>
    [Required]
    public string SAG_LENS_CAM_SFERIK { get; set; }

    /// <summary>SaÄŸ lensin cam silindirik deÄŸer bilgisini ifade eder.</summary>
    [Required]
    public string SAG_LENS_CAM_SILINDIRIK { get; set; }

    /// <summary>SaÄŸ lensin cam Ã§ap deÄŸer bilgisini ifade eder.</summary>
    [Required]
    public string SAG_LENS_CAM_CAP { get; set; }

    /// <summary>SaÄŸ lensin cam eÄŸim deÄŸer bilgisini ifade eder.</summary>
    [Required]
    public string SAG_LENS_CAM_EGIM { get; set; }

    /// <summary>SaÄŸ lensin cam astigmat aÃ§Ä±sÄ±nÄ±n (Aks) deÄŸer bilgisini ifade eder.</summary>
    [Required]
    public string SAG_LENS_CAM_AKS { get; set; }

    /// <summary>Sol lens cam sferik deÄŸer bilgisidir.</summary>
    [Required]
    public string SOL_LENS_CAM_SFERIK { get; set; }

    /// <summary>Sol lensin cam silindirik deÄŸer bilgisini ifade eder.</summary>
    [Required]
    public string SOL_LENS_CAM_SILINDIRIK { get; set; }

    /// <summary>Sol lensin cam Ã§ap deÄŸer bilgisini ifade eder.</summary>
    [Required]
    public string SOL_LENS_CAM_CAP { get; set; }

    /// <summary>Sol lensin cam eÄŸim deÄŸer bilgisini ifade eder.</summary>
    [Required]
    public string SOL_LENS_CAM_EGIM { get; set; }

    /// <summary>Sol lensin cam astigmat aÃ§Ä±sÄ±nÄ±n (Aks) deÄŸer bilgisini ifade eder.</summary>
    [Required]
    public string SOL_LENS_CAM_AKS { get; set; }

    /// <summary>GÃ¶zlÃ¼ÄŸÃ¼n saÄŸ camÄ±nÄ±n keratakonus cam sferik bilgisini ifade eder.</summary>
    [Required]
    public string SAG_KERATAKONUS_CAM_SFERIK { get; set; }

    /// <summary>GÃ¶zlÃ¼ÄŸÃ¼n saÄŸ camÄ±nÄ±n keratakonus cam silindirik bilgisini ifade eder.</summary>
    [Required]
    public string SAG_KERATAKONUS_CAM_SILINDIR { get; set; }

    /// <summary>GÃ¶zlÃ¼ÄŸÃ¼n saÄŸ camÄ±nÄ±n keratakonus cam Ã§ap bilgisini ifade eder.</summary>
    [Required]
    public string SAG_KERATAKONUS_CAM_CAP { get; set; }

    /// <summary>GÃ¶zlÃ¼ÄŸÃ¼n saÄŸ camÄ±nÄ±n keratakonus cam eÄŸim bilgisini ifade eder.</summary>
    [Required]
    public string SAG_KERATAKONUS_CAM_EGIM { get; set; }

    /// <summary>GÃ¶zlÃ¼ÄŸÃ¼n saÄŸ camÄ±nÄ±n keratakonus astigmat aÃ§Ä±sÄ±nÄ±n (Aks) deÄŸer bilgisini ifade e...</summary>
    [Required]
    public string SAG_KERATAKONUS_CAM_AKS { get; set; }

    /// <summary>GÃ¶zlÃ¼ÄŸÃ¼n sol camÄ±nÄ±n keratakonus cam sferik bilgisini ifade eder.</summary>
    [Required]
    public string SOL_KERATAKONUS_CAM_SFERIK { get; set; }

    /// <summary>GÃ¶zlÃ¼ÄŸÃ¼n sol camÄ±nÄ±n keratakonus cam silindirik bilgisini ifade eder.</summary>
    [Required]
    public string SOL_KERATAKONUS_CAM_SILINDIR { get; set; }

    /// <summary>GÃ¶zlÃ¼ÄŸÃ¼n sol camÄ±nÄ±n keratakonus cam Ã§ap bilgisini ifade eder.</summary>
    [Required]
    public string SOL_KERATAKONUS_CAM_CAP { get; set; }

    /// <summary>GÃ¶zlÃ¼ÄŸÃ¼n sol camÄ±nÄ±n keratakonus cam eÄŸim bilgisini ifade eder.</summary>
    [Required]
    public string SOL_KERATAKONUS_CAM_EGIM { get; set; }

    /// <summary>GÃ¶zlÃ¼ÄŸÃ¼n sol camÄ±nÄ±n keratakonus astigmat aÃ§Ä±sÄ±nÄ±n (Aks) deÄŸer bilgisini ifade e...</summary>
    [Required]
    public string SOL_KERATAKONUS_CAM_AKS { get; set; }

    /// <summary>Teleskopik gÃ¶zlÃ¼k tipi deÄŸer bilgisidir. Ã–rneÄŸin tek, Ã§ift, tek karekod vb.</summary>
    [Required]
    [ForeignKey("TeleskopikGozlukTipiNavigation")]
    public string TELESKOPIK_GOZLUK_TIPI { get; set; }

    /// <summary>Teleskopik gÃ¶zlÃ¼k tÃ¼rÃ¼ deÄŸer bilgisidir. Ã–rneÄŸin uzak-daimi, yakÄ±n vb.</summary>
    [Required]
    [ForeignKey("TeleskopikGozlukTuruNavigation")]
    public string TELESKOPIK_GOZLUK_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde dÃ¼zenlenen gÃ¶zlÃ¼k reÃ§etesinin saÄŸ camÄ±nda teleskobik Ã¶zelliÄŸine...</summary>
    [Required]
    public string TELESKOPIK_SAG_CAM { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde dÃ¼zenlenen gÃ¶zlÃ¼k reÃ§etesinin sol camÄ±nda teleskobik Ã¶zelliÄŸine...</summary>
    [Required]
    public string TELESKOPIK_SOL_CAM { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual REFERANS_KODLAR? GozlukReceteTipiNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual REFERANS_KODLAR? GozlukTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? SagCamTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SagCamRengiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SolCamTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SolCamRengiNavigation { get; set; }
    public virtual REFERANS_KODLAR? TeleskopikGozlukTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? TeleskopikGozlukTuruNavigation { get; set; }
    #endregion

}
