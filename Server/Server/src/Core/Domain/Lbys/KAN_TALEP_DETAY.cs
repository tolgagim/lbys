using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// KAN_TALEP_DETAY tablosu - 20 kolon
/// </summary>
[Table("KAN_TALEP_DETAY")]
public class KAN_TALEP_DETAY : VemEntity
{
    /// <summary>Talep edilen kan Ã¼rÃ¼nÃ¼ detay bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±n...</summary>
    [Key]
    public string KAN_TALEP_DETAY_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Talep edilen kan Ã¼rÃ¼nÃ¼ bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("KanTalepNavigation")]
    public string KAN_TALEP_KODU { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼ iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼retilen tekil kod bilgis...</summary>
    [ForeignKey("KanUrunNavigation")]
    public string KAN_URUN_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavi olan hasta iÃ§in istenen kan grubuna bilgisine ait SaÄŸlÄ±k...</summary>
    [ForeignKey("IstenenKanGrubuNavigation")]
    public string ISTENEN_KAN_GRUBU { get; set; }

    /// <summary>Talebin reddedildiÄŸi tarih bilgisidir.</summary>
    public DateTime RET_TARIHI { get; set; }

    /// <summary>Ret iÅŸlemini gerÃ§ekleÅŸtiren SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi kullanÄ±cÄ±sÄ± iÃ§in SaÄŸlÄ±k...</summary>
    [Required]
    [ForeignKey("RetEdenKullaniciNavigation")]
    public string RET_EDEN_KULLANICI_KODU { get; set; }

    /// <summary>Talep edilen kan Ã¼rÃ¼nÃ¼nÃ¼n reddedilmesi durumunda belirtilen ret bilgisidir. Ã–rne...</summary>
    [Required]
    [ForeignKey("KanTalepRetNedeniNavigation")]
    public string KAN_TALEP_RET_NEDENI { get; set; }

    /// <summary>Talep edilen kan Ã¼rÃ¼nÃ¼ iÃ§in miktar (torba adedi) bilgisidir.</summary>
    [Required]
    public string KAN_TALEP_MIKTARI { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼nÃ¼n mililitre cinsinden hacim bilgisidir.</summary>
    [Required]
    public string KAN_HACIM { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼ne Buffy Coat uzaklaÅŸtÄ±rma iÅŸlemi uygulanma durumunu ifade eder.</summary>
    public string BUFFYCOAT_UZAKLASTIRMA_DURUMU { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼ne filtreleme iÅŸlemi uygulanÄ±p uygulanmadÄ±ÄŸÄ±nÄ± ifade eden durum bilgisi...</summary>
    public string KAN_FILTRELEME_DURUMU { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼nÃ¼n Ä±ÅŸÄ±nlanma iÅŸleminin durumuna iliÅŸkin bilgiyi ifade eder.</summary>
    public string KAN_ISINLAMA_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kullanÄ±lacak Ã¼rÃ¼ne yÄ±kama iÅŸleminin uygulanmasÄ±na iliÅŸkin bilgi...</summary>
    public string KAN_YIKAMA_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    /// <summary>Ä°ÅŸlemin gÃ¼ncellemesinin yapÄ±ldÄ±ÄŸÄ± tarih bilgisidir.</summary>

    #region Navigation Properties
    public virtual KAN_TALEP? KanTalepNavigation { get; set; }
    public virtual KAN_URUN? KanUrunNavigation { get; set; }
    public virtual REFERANS_KODLAR? IstenenKanGrubuNavigation { get; set; }
    public virtual KULLANICI? RetEdenKullaniciNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanTalepRetNedeniNavigation { get; set; }
    #endregion

}
