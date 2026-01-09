using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// KURUL_RAPOR tablosu - 31 kolon
/// </summary>
[Table("KURUL_RAPOR")]
public class KURUL_RAPOR : VemEntity
{
    /// <summary>Hastaya saÄŸlÄ±k raporu veren kurul iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [Key]
    public string KURUL_RAPOR_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde dÃ¼zenlenen saÄŸlÄ±k kurulu tarafÄ±ndan verilen raporlarÄ±n tanÄ±m bi...</summary>
    [ForeignKey("KurulNavigation")]
    public string KURUL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k kurulu tarafÄ±ndan verilen raporlar iÃ§in ad bilgisidir.</summary>
    [Required]
    public string RAPOR_ADI { get; set; }

    /// <summary>Rapor zamanÄ± bilgisidir.</summary>
    public DateTime? RAPOR_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k kurulu tarafÄ±ndan verilen raporlarÄ±n karar numarasÄ± bilgisidir.</summary>
    [Required]
    public string RAPOR_KARAR_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastaya verilen iÅŸ gÃ¶remezlik raporu iÃ§in MEDULA sistem...</summary>
    [Required]
    public string RAPOR_SIRA_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastaya verilen saÄŸlÄ±k kurulu raporu iÃ§in SaÄŸlÄ±k Bilgi ...</summary>
    [Required]
    public string RAPOR_TAKIP_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k kurulu tarafÄ±ndan verilen raporlar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tara...</summary>
    public string KURUL_RAPOR_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kiÅŸiye verilen raporun baÅŸlama tarihi bilgisidir.</summary>
    public DateTime? RAPOR_BASLAMA_TARIHI { get; set; }

    /// <summary>Raporun bitiÅŸ tarihi bilgisidir.</summary>
    public DateTime RAPOR_BITIS_TARIHI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde laboratuvarda yapÄ±lan tetkikler sonucunda elde edilen bulgularÄ±...</summary>
    [Required]
    public string LABORATUVAR_BULGU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine kurul raporu almak iÃ§in baÅŸvurmuÅŸ kiÅŸinin muayene bulgularÄ± bilg...</summary>
    [Required]
    public string KURUL_RAPOR_MUAYENE_BULGUSU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde dÃ¼zenlenen kurul raporlarÄ±nda hasta iÃ§in verilen tanÄ± bilgisini...</summary>
    [Required]
    public string KURUL_TANI_BILGISI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kiÅŸiye verilen kurul raporu iÃ§in kurul tarafÄ±ndan verilen karar...</summary>
    [Required]
    public string KURUL_RAPOR_KARARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kiÅŸiye verilen kurul raporunun iÃ§eriÄŸinin SaÄŸlÄ±k Bilgi YÃ¶netim ...</summary>
    [Required]
    [ForeignKey("KararIcerikFormatiNavigation")]
    public string KARAR_ICERIK_FORMATI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine rapor almak iÃ§in gelen kiÅŸinin saÄŸlÄ±k tesisine mÃ¼racaatÄ±na iliÅŸk...</summary>
    public string MURACAAT_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran kiÅŸi iÃ§in belirlenen engellilik oranÄ± bilgisidir.</summary>
    [Required]
    public string ENGELLILIK_ORANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde dÃ¼zenlenen onaylanmÄ±ÅŸ ilaÃ§ raporunda sonradan yapÄ±lan deÄŸiÅŸikli...</summary>
    [Required]
    public string ILAC_RAPOR_DUZELTME_ACIKLAMASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual KURUL? KurulNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? KararIcerikFormatiNavigation { get; set; }
    #endregion

}
