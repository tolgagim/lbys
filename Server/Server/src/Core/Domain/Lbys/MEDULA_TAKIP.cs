using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// MEDULA_TAKIP tablosu - 30 kolon
/// </summary>
[Table("MEDULA_TAKIP")]
public class MEDULA_TAKIP : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde tedavi gÃ¶ren hasta iÃ§in, Ã§eÅŸitli kriterlere gÃ¶re MEDULA tarafÄ±n...</summary>
    [Key]
    public string MEDULA_TAKIP_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine gelen hasta iÃ§in MEDULA sisteminden SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi...</summary>
    public string SGK_TAKIP_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine gelen hasta iÃ§in MEDULA sisteminden SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi...</summary>
    [Required]
    public string SGK_ILKTAKIP_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisi iÃ§in MEDULA tarafÄ±ndan tanÄ±mlanmÄ±ÅŸ numara bilgisidir.</summary>
    public string MEDULA_TESIS_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan klinik ve hekimler iÃ§in MEDULA tarafÄ±ndan tanÄ±mlanmÄ±ÅŸ b...</summary>
    public string MEDULA_BRANS_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastanÄ±n baÅŸvurusu iÃ§in MEDULA sistemine iletilen provi...</summary>
    [ForeignKey("ProvizyonTuruNavigation")]
    public string PROVIZYON_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastanÄ±n baÅŸvurusu iÃ§in MEDULA sistemine iletilen provi...</summary>
    public DateTime? PROVIZYON_TARIHI { get; set; }

    /// <summary>KiÅŸiyi niteleyen eÅŸsiz numaradÄ±r.</summary>
    [Required]
    public string TC_KIMLIK_NUMARASI { get; set; }

    /// <summary>KiÅŸinin cinsiyetini ifade eder.</summary>
    [Required]
    public string CINSIYET { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavi gÃ¶ren hastaya yapÄ±lan iÅŸlem iÃ§in MEDULA sisteminin Ã¶deme...</summary>
    [Required]
    public string MEDULA_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisi tarafÄ±ndan hasta iÃ§in kesilen faturanÄ±n MEDULAâ€™ya gÃ¶nderildikten s...</summary>
    [Required]
    public string FATURA_TESLIM_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisi tarafÄ±ndan hasta iÃ§in kesilen faturanÄ±n web servis aracÄ±lÄ±ÄŸÄ± ile M...</summary>
    public DateTime FATURA_TESLIM_TARIHI { get; set; }

    /// <summary>Hastaya uygulanan tedavinin ayaktan, gÃ¼nÃ¼birlik, yatan vb. olduÄŸunu belirten SaÄŸ...</summary>
    [ForeignKey("TedaviTuruNavigation")]
    public string TEDAVI_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine gelen hastanÄ±n emekli, Ã§alÄ±ÅŸan vb. durumlarÄ±nÄ± belirten bilgiyi ...</summary>
    [Required]
    public string SIGORTALI_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde muayene olan kiÅŸi iÃ§in MEDULA tarafÄ±ndan SaÄŸlÄ±k Bilgi YÃ¶netim S...</summary>
    [Required]
    public string DEVREDILEN_KURUM { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta iÃ§in yapÄ±lan tÃ¼m iÅŸlemler iÃ§in MEDULA'dan SaÄŸlÄ±k Bilgi YÃ¶...</summary>
    [Required]
    public string SONUC_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta iÃ§in yapÄ±lan tÃ¼m iÅŸlemler iÃ§in MEDULA'dan SaÄŸlÄ±k Bilgi YÃ¶...</summary>
    [Required]
    public string SONUC_MESAJI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavi gÃ¶ren hasta iÃ§in normal, eÅŸlik eden hastalÄ±k, uzayan yat...</summary>
    [Required]
    [ForeignKey("TakipTipiNavigation")]
    public string TAKIP_TIPI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran kiÅŸi iÃ§in MEDULA sisteminden SaÄŸlÄ±k Bilgi YÃ¶netim Siste...</summary>
    [Required]
    public string BASVURU_NUMARASI { get; set; }

    /// <summary>Hastaya uygulanan tedavinin normal, diÅŸ tedavisi, analÄ±k hali vb. olduÄŸunu belir...</summary>
    [ForeignKey("TedaviTipiNavigation")]
    public string TEDAVI_TIPI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki hastaya uygulanan tedaviye iliÅŸkin bilgiyi ifade eder. Ã–rneÄŸi...</summary>
    [Required]
    [ForeignKey("TedaviSekliNavigation")]
    public string TEDAVI_SEKLI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual REFERANS_KODLAR? ProvizyonTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? TedaviTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? TakipTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? TedaviTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? TedaviSekliNavigation { get; set; }
    #endregion

}
