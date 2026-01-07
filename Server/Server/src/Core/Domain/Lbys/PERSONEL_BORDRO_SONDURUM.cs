using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// PERSONEL_BORDRO_SONDURUM tablosu - 17 kolon
/// </summary>
[Table("PERSONEL_BORDRO_SONDURUM")]
public class PERSONEL_BORDRO_SONDURUM : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin bordrosuna ait son durum bilgileri iÃ§in SaÄŸl...</summary>
    [Key]
    public string PERSONEL_SONDURUM_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin kademe bilgisidir.</summary>
    [Required]
    public string PERSONEL_KADEMESI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personel iÃ§in kÄ±dem derece bilgisidir.</summary>
    [Required]
    public string PERSONEL_DERECESI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele ait emekli derecesi bilgisidir.</summary>
    [Required]
    public string EMEKLI_DERECESI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele ait emekli kademe bilgisidir.</summary>
    [Required]
    public string EMEKLI_KADEMESI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin bordrosunda hangi sendika iÃ§in kesinti yapÄ±l...</summary>
    [Required]
    public string SENDIKA_BILGISI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin kÄ±dem yÄ±lÄ± bilgisidir.</summary>
    [Required]
    public string KIDEM_YILI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin kÄ±dem ayÄ± bilgisidir.</summary>
    [Required]
    public string KIDEM_AYI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin kÄ±dem gÃ¼nÃ¼ bilgisidir.</summary>
    [Required]
    public string KIDEM_GUNU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin ek gÃ¶sterge bilgisidir.</summary>
    [Required]
    public string EK_GOSTERGE { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele ait emekli ek gÃ¶stergesi bilgisidir.</summary>
    [Required]
    public string EMEKLI_EK_GOSTERGESI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde 657 sayÄ±lÄ± Devlet MemurlarÄ± Kanunu kapsamÄ±nda gÃ¶revli personeli...</summary>
    [Required]
    public string GOSTERGE { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin ait emekli gÃ¶sterge bilgisidir.</summary>
    [Required]
    public string EMEKLI_GOSTERGESI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin yan Ã¶deme puan bilgisidir.</summary>
    [Required]
    public string YAN_ODEME_PUANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin Ã¶zel hizmet puanÄ± bilgisidir.</summary>
    [Required]
    public string OZEL_HIZMET_PUANI { get; set; }

    #region Navigation Properties
    public virtual PERSONEL? PersonelNavigation { get; set; }
    #endregion

}
