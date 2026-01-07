using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// DIS_TAAHHUT tablosu - 23 kolon
/// </summary>
[Table("DIS_TAAHHUT")]
public class DIS_TAAHHUT : VemEntity
{
    /// <summary>DiÅŸ tedavisi yapÄ±lan hastalar iÃ§in MEDULA sisteminden alÄ±nan taahhÃ¼t bilgilerini...</summary>
    [Key]
    public string DIS_TAAHHUT_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli hekim iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼ret...</summary>
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde iÅŸlem yapÄ±lacak kiÅŸiye ait diÅŸ iÅŸlemleri iÃ§in MEDULA sisteminde...</summary>
    [Required]
    public string DIS_TAAHHUT_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine gelen hasta iÃ§in MEDULA sisteminden SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi...</summary>
    public string SGK_TAKIP_NUMARASI { get; set; }

    /// <summary>KiÅŸinin adres bilgisinde bulunan cadde sokak bilgisidir.</summary>
    [Required]
    public string CADDE_SOKAK { get; set; }

    /// <summary>Adresin dÄ±ÅŸ kapÄ± numarasÄ± bilgisidir.</summary>
    [Required]
    public string DIS_KAPI_NUMARASI { get; set; }

    /// <summary>KiÅŸinin elektronik posta adresidir.</summary>
    [Required]
    public string EPOSTA_ADRESI { get; set; }

    /// <summary>Adresin iÃ§ kapÄ± numarasÄ± bilgisidir.</summary>
    [Required]
    public string IC_KAPI_NUMARASI { get; set; }

    /// <summary>Ä°l kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("IlNavigation")]
    public string IL_KODU { get; set; }

    /// <summary>Telefon numarasÄ± bilgisini ifade eder.</summary>
    [Required]
    public string TELEFON_NUMARASI { get; set; }

    /// <summary>Ä°lÃ§e kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("IlceNavigation")]
    public string ILCE_KODU { get; set; }

    /// <summary>MEDULA sisteminden web servis aracÄ±lÄ±ÄŸÄ± ile alÄ±nan cevaplarÄ±n kod numarasÄ± bilgi...</summary>
    [Required]
    public string MEDULA_SONUC_KODU { get; set; }

    /// <summary>MEDULA sisteminden web servis aracÄ±lÄ±ÄŸÄ± ile alÄ±nan cevaplarÄ±n metin bilgisidir.</summary>
    [Required]
    public string MEDULA_SONUC_MESAJI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan bir iÅŸlemin iptal edilip edilmediÄŸi bilgisidir.</summary>
    [Required]
    public string IPTAL_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlNavigation { get; set; }
    public virtual REFERANS_KODLAR? IlceNavigation { get; set; }
    #endregion

}
