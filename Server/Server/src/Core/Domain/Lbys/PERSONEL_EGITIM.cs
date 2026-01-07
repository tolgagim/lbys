using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// PERSONEL_EGITIM tablosu - 16 kolon
/// </summary>
[Table("PERSONEL_EGITIM")]
public class PERSONEL_EGITIM : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin almÄ±ÅŸ olduÄŸu eÄŸitim bilgileri iÃ§in SaÄŸlÄ±k Bi...</summary>
    [Key]
    public string PERSONEL_EGITIM_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin almÄ±ÅŸ olduÄŸu eÄŸitim bilgileri iÃ§in SaÄŸlÄ±k Bi...</summary>
    [ForeignKey("PersonelEgitimTuruNavigation")]
    public string PERSONEL_EGITIM_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele ait sertifikalara iliÅŸkin detaylÄ± bilgiyi ifa...</summary>
    [Required]
    [ForeignKey("SertifikaTipiNavigation")]
    public string SERTIFIKA_TIPI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele ait sertifikalarÄ±n puan bilgisini ifade eder.</summary>
    [Required]
    public string SERTIFIKA_PUANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin eÄŸitim veya Ã¶ÄŸrenim iÃ§in aldÄ±ÄŸÄ± belgenin num...</summary>
    [Required]
    public string BELGE_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin aldÄ±ÄŸÄ± eÄŸitimin baÅŸladÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime? EGITIM_BASLANGIC_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin aldÄ±ÄŸÄ± eÄŸitimin bittiÄŸi zaman bilgisidir.</summary>
    public DateTime EGITIM_BITIS_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin aldÄ±ÄŸÄ± eÄŸitimi veren kiÅŸinin ad soyadÄ± bilgi...</summary>
    [Required]
    public string EGITIM_VEREN_KISI_BILGISI { get; set; }

    /// <summary>EÄŸitimin verildiÄŸi yer bilgisidir.</summary>
    [Required]
    public string EGITIM_YERI { get; set; }

    /// <summary>YapÄ±lan bir iÅŸlemi onaylayan personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±nd...</summary>
    [Required]
    [ForeignKey("OnaylayanPersonelNavigation")]
    public string ONAYLAYAN_PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual PERSONEL? PersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? PersonelEgitimTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? SertifikaTipiNavigation { get; set; }
    public virtual PERSONEL? OnaylayanPersonelNavigation { get; set; }
    #endregion

}
