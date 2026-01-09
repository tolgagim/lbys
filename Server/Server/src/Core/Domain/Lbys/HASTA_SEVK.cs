using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// HASTA_SEVK tablosu - 25 kolon
/// </summary>
[Table("HASTA_SEVK")]
public class HASTA_SEVK : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinden baÅŸka bir saÄŸlÄ±k tesisine sevk edilen hastanÄ±n sevk bilgileri ...</summary>
    [Key]
    public string HASTA_SEVK_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>HASTA gÃ¶rÃ¼ntÃ¼sÃ¼ndeki HASTA_KODU bilgisidir.</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sevk edilen hastanÄ±n MEDULA sisteminden SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine iletilen ...</summary>
    [Required]
    public string SEVK_TAKIP_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine sevk edilerek gelen hastanÄ±n sevk nedeni bilgisidir.</summary>
    [Required]
    [ForeignKey("SevkNedeniNavigation")]
    public string SEVK_NEDENI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki hastanÄ±n sevk edildiÄŸi kliniÄŸin MEDULAâ€™daki branÅŸ kodu bilgis...</summary>
    [Required]
    public string SEVK_EDILEN_BRANS_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki hastanÄ±n sevk edildiÄŸi kurum bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("SevkEdilenKurumNavigation")]
    public string SEVK_EDILEN_KURUM_KODU { get; set; }

    /// <summary>HastanÄ±n ilk baÅŸvurduÄŸu saÄŸlÄ±k tesisinin (sevk edildiÄŸi saÄŸlÄ±k tesisi) hastayÄ± b...</summary>
    public DateTime? SEVK_ZAMANI { get; set; }

    /// <summary>HastanÄ±n sevk gerekÃ§esi olan hastalÄ±k tanÄ± (larÄ±) dÄ±r.</summary>
    [Required]
    [ForeignKey("SevkTanisiNavigation")]
    public string SEVK_TANISI { get; set; }

    /// <summary>Sevk edilen hastaya eÅŸlik eden kiÅŸi bilgisini ifade eder. Ã–rneÄŸin refakatli, pol...</summary>
    [Required]
    [ForeignKey("SevkSekliNavigation")]
    public string SEVK_SEKLI { get; set; }

    /// <summary>HastanÄ±n sevk edildiÄŸi araÃ§ iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼retile...</summary>
    [Required]
    [ForeignKey("SevkVasitasiNavigation")]
    public string SEVK_VASITASI_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinden sevk edilen hastanÄ±n, sevk edildiÄŸi yerde uygulanacak tedavi b...</summary>
    [Required]
    [ForeignKey("SevkTedaviTipiNavigation")]
    public string SEVK_TEDAVI_TIPI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde sevk edilen hasta iÃ§in yapÄ±lan aÃ§Ä±klama bilgisini ifade eder.</summary>
    [Required]
    public string SEVK_ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki hastanÄ±n sevk kararÄ±nÄ± veren hekime ait SaÄŸlÄ±k Bilgi YÃ¶netim ...</summary>
    [ForeignKey("SevkEden1PersonelNavigation")]
    public string SEVK_EDEN_1_PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki hastanÄ±n sevk kararÄ±nÄ± veren hekime ait SaÄŸlÄ±k Bilgi YÃ¶netim ...</summary>
    [Required]
    [ForeignKey("SevkEden2PersonelNavigation")]
    public string SEVK_EDEN_2_PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki hastanÄ±n sevk kararÄ±nÄ± veren hekime ait SaÄŸlÄ±k Bilgi YÃ¶netim ...</summary>
    [Required]
    [ForeignKey("SevkEden3PersonelNavigation")]
    public string SEVK_EDEN_3_PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yatan hastanÄ±n refakatÃ§isinin olup olmadÄ±ÄŸÄ±na iliÅŸkin bilgiyi i...</summary>
    [Required]
    public string REFAKATCI_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavi gÃ¶ren hastanÄ±n baÅŸka bir saÄŸlÄ±k tesisine sevk edilmesi d...</summary>
    [Required]
    public string MEDULA_E_SEVK_NUMARASI { get; set; }

    /// <summary>Ambulans ile sevk edilen hasta iÃ§in oluÅŸturulmuÅŸ protokol numarasÄ± bilgisidir.</summary>
    [Required]
    public string AMBULANS_PROTOKOL_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? SevkNedeniNavigation { get; set; }
    public virtual KURUM? SevkEdilenKurumNavigation { get; set; }
    public virtual REFERANS_KODLAR? SevkTanisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SevkSekliNavigation { get; set; }
    public virtual REFERANS_KODLAR? SevkVasitasiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SevkTedaviTipiNavigation { get; set; }
    public virtual PERSONEL? SevkEden1PersonelNavigation { get; set; }
    public virtual PERSONEL? SevkEden2PersonelNavigation { get; set; }
    public virtual PERSONEL? SevkEden3PersonelNavigation { get; set; }
    #endregion

}
