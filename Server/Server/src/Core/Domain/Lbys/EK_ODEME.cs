using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// EK_ODEME tablosu - 25 kolon
/// </summary>
[Table("EK_ODEME")]
public class EK_ODEME : VemEntity
{
    /// <summary>SBYS tarafÄ±ndan Ã¼retilen tekil kod bilgisidir.</summary>
    [Key]
    public string EK_ODEME_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± veri tabanÄ±ndaki tablo adÄ± bilgisidir.</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele Ã¶denecek ek Ã¶deme iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim S...</summary>
    [ForeignKey("EkOdemeDonemNavigation")]
    public string EK_ODEME_DONEM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personel iÃ§in ilgili mevzuat kapsamÄ±nda maaÅŸ hesaplama ...</summary>
    public string HESAPLAMA_YONTEMI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele ait maaÅŸ derece bilgisidir.</summary>
    public string MAAS_DERECESI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele ait maaÅŸ kademe bilgisidir.</summary>
    public string MAAS_KADEMESI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele ait maaÅŸ gÃ¶sterge bilgisidir.</summary>
    public string MAAS_GOSTERGESI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele yapÄ±lan aylÄ±k Ã¶deme bilgisidir.</summary>
    public string AYLIK_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele ait Ã¶zel hizmet tutarÄ± bilgisidir.</summary>
    [Required]
    public string OZEL_HIZMET_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin ek gÃ¶sterge tutarÄ± bilgisidir.</summary>
    [Required]
    public string EK_GOSTERGE_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele ait yan Ã¶deme tutarÄ± bilgisidir.</summary>
    [Required]
    public string YAN_ODEME_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin doÄŸu tazminat tutarÄ± bilgisidir.</summary>
    [Required]
    public string DOGU_TAZMINATI_TUTARI { get; set; }

    /// <summary>Personelin bir ayda alacaÄŸÄ± aylÄ±k (ek gÃ¶sterge dÃ¢hil), yan Ã¶deme ve her tÃ¼rlÃ¼ ta...</summary>
    public string EK_ODEME_MATRAHI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde geÃ§ici gÃ¶revli personelin, kadrosunun olduÄŸu kurumdan almÄ±ÅŸ old...</summary>
    [Required]
    public string BASKA_KURUMDAKI_EKODEME_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personel iÃ§in DÃ¶ner Sermaye Sabit Ã–demesi (DSSÃ–) iÃ§in h...</summary>
    [Required]
    public string DSSO_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personel iÃ§in yapÄ±lan ek Ã¶deme hesaplanmasÄ±nda kullanÄ±l...</summary>
    [Required]
    public string ENGELLILIK_INDIRIM_ORANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin komisyon gÃ¶revi iÃ§in elde edilen ek puan ora...</summary>
    [Required]
    public string KOMISYON_EK_PUANI_ORANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin asil gÃ¶revi dÄ±ÅŸÄ±nda baÅŸka bir gÃ¶rev yapmasÄ± ...</summary>
    [Required]
    public string EK_PUAN_ORANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli tÃ¼m uzman tabiplerin birim performans katsayÄ±larÄ±nÄ±n or...</summary>
    [Required]
    public string BIRIM_PERFORMANS_KATSAYISI { get; set; }

    /// <summary>Ek Ã¶deme bilgisinin ilk kayÄ±t edildiÄŸi zaman bilgisidir.</summary>

    /// <summary>Ä°ÅŸlemi ekleyen kullanÄ±cÄ± kodu, KULLANICI gÃ¶rÃ¼ntÃ¼sÃ¼ndeki KULLANICI_KODU bilgi...</summary>

    /// <summary>Ä°ÅŸlemin gÃ¼ncellemesinin yapÄ±ldÄ±ÄŸÄ± zaman bilgisidir.</summary>

    /// <summary>Ä°ÅŸlemi gÃ¼ncelleyen kullanÄ±cÄ± kodu, KULLANICI gÃ¶rÃ¼ntÃ¼sÃ¼ndeki KULLANICI_KODU b...</summary>

    #region Navigation Properties
    public virtual EK_ODEME_DONEM? EkOdemeDonemNavigation { get; set; }
    public virtual PERSONEL? PersonelNavigation { get; set; }
    #endregion

}
