using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// KAN_CIKIS tablosu - 20 kolon
/// </summary>
[Table("KAN_CIKIS")]
public class KAN_CIKIS : VemEntity
{
    /// <summary>Kan Ã¼rÃ¼nÃ¼nÃ¼n saÄŸlÄ±k tesisi deposundan Ã§Ä±kÄ±ÅŸ iÅŸlemi iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sis...</summary>
    [Key]
    public string KAN_CIKIS_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Talep edilen kan Ã¼rÃ¼nÃ¼ detay bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±n...</summary>
    [Required]
    [ForeignKey("KanTalepDetayNavigation")]
    public string KAN_TALEP_DETAY_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [Required]
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki depolarda bulunan kan Ã¼rÃ¼nÃ¼ iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi...</summary>
    [ForeignKey("KanStokNavigation")]
    public string KAN_STOK_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kan Ã¼rÃ¼nÃ¼nÃ¼ teslim alan kiÅŸi bilgisidir.</summary>
    public string KANI_TESLIM_ALAN_KISI { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼nÃ¼n bulunduÄŸu birimden Ã§Ä±kÄ±ÅŸ zamanÄ± bilgisidir.</summary>
    public DateTime? KAN_CIKIS_ZAMANI { get; set; }

    /// <summary>KiÅŸinin yararlandÄ±ÄŸÄ± saÄŸlÄ±k gÃ¼vencesinin kurumuna ait bilgiler iÃ§in SaÄŸlÄ±k Bilgi...</summary>
    [Required]
    [ForeignKey("KurumNavigation")]
    public string KURUM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kan Ã¼rÃ¼nÃ¼nÃ¼n diÄŸer birimlere gÃ¶nderilmesini onaylayan personel ...</summary>
    [ForeignKey("KanCikisPersonelNavigation")]
    public string KAN_CIKIS_PERSONEL_KODU { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼n rezerve edildiÄŸi zaman bilgisidir.</summary>
    public DateTime REZERVE_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde baÄŸÄ±ÅŸÄ± yapÄ±lan kan Ã¼rÃ¼nÃ¼nÃ¼ rezerve eden kullanÄ±cÄ± iÃ§in SaÄŸlÄ±k B...</summary>
    [Required]
    [ForeignKey("RezerveEdenKullaniciNavigation")]
    public string REZERVE_EDEN_KULLANICI_KODU { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼ iÃ§in yapÄ±lan cross-match iÅŸlem sonucunu SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine...</summary>
    [Required]
    [ForeignKey("CrossMatchKullaniciNavigation")]
    public string CROSS_MATCH_KULLANICI_KODU { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼ iÃ§in yapÄ±lan cross-match iÅŸleminin uygulanma zamanÄ± bilgisidir.</summary>
    public DateTime CROSS_MATCH_CALISMA_ZAMANI { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼ iÃ§in yapÄ±lan cross-match iÅŸlemi iÃ§in Ã§alÄ±ÅŸma yÃ¶ntemini ifade eder. Ã–rn...</summary>
    [Required]
    [ForeignKey("CrossMatchCalismaYontemiNavigation")]
    public string CROSS_MATCH_CALISMA_YONTEMI { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼ iÃ§in yapÄ±lan cross-match iÅŸleminin sonuÃ§ bilgisidir.</summary>
    [Required]
    [ForeignKey("CrossMatchSonucuNavigation")]
    public string CROSS_MATCH_SONUCU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    /// <summary>Ä°ÅŸlemin gÃ¼ncellemesinin yapÄ±ldÄ±ÄŸÄ± tarih bilgisidir.</summary>

    #region Navigation Properties
    public virtual KAN_TALEP_DETAY? KanTalepDetayNavigation { get; set; }
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual KAN_STOK? KanStokNavigation { get; set; }
    public virtual KURUM? KurumNavigation { get; set; }
    public virtual PERSONEL? KanCikisPersonelNavigation { get; set; }
    public virtual KULLANICI? RezerveEdenKullaniciNavigation { get; set; }
    public virtual KULLANICI? CrossMatchKullaniciNavigation { get; set; }
    public virtual REFERANS_KODLAR? CrossMatchCalismaYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? CrossMatchSonucuNavigation { get; set; }
    #endregion

}
