using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// NOBETCI_PERSONEL_BILGISI tablosu - 14 kolon
/// </summary>
[Table("NOBETCI_PERSONEL_BILGISI")]
public class NOBETCI_PERSONEL_BILGISI : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde nÃ¶betÃ§i personelin bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi ...</summary>
    [Key]
    public string NOBETCI_PERSONEL_BILGISI_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k Kodlama Referans Sunucusu (SKRS) kod sistemlerinde tanÄ±mlanan Kurum Kodu ...</summary>
    [ForeignKey("SkrsKurumNavigation")]
    public string SKRS_KURUM_KODU { get; set; }

    /// <summary>Personele ait TC Kimlik NumarasÄ± bilgisidir.</summary>
    public string PERSONEL_TC_KIMLIK_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan kliniklerin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan gru...</summary>
    [Required]
    [ForeignKey("KlinikNavigation")]
    public string KLINIK_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin yaptÄ±ÄŸÄ± gÃ¶rev iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sist...</summary>
    [Required]
    [ForeignKey("GorevTuruNavigation")]
    public string GOREV_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personel iÃ§in gÃ¶revini tanÄ±mlayan kod bilgisidir.</summary>
    [Required]
    [ForeignKey("PersonelGorevNavigation")]
    public string PERSONEL_GOREV_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin nÃ¶bette baÅŸlama tarihi bilgisidir.</summary>
    public DateTime NOBET_BASLANGIC_TARIHI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin nÃ¶betinin bitiÅŸ tarihi bilgisidir.</summary>
    public DateTime NOBET_BITIS_TARIHI { get; set; }

    /// <summary>Telefon numarasÄ± bilgisini ifade eder.</summary>
    [Required]
    public string TELEFON_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual REFERANS_KODLAR? SkrsKurumNavigation { get; set; }
    public virtual REFERANS_KODLAR? KlinikNavigation { get; set; }
    public virtual REFERANS_KODLAR? GorevTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? PersonelGorevNavigation { get; set; }
    #endregion

}
