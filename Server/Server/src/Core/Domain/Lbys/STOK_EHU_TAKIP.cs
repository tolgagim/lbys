using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// STOK_EHU_TAKIP tablosu - 19 kolon
/// </summary>
[Table("STOK_EHU_TAKIP")]
public class STOK_EHU_TAKIP : VemEntity
{
    /// <summary>Enfeksiyon HastalÄ±klarÄ± UzmanÄ±nÄ±n (EHU) onayÄ±nÄ± gerektiren isteklerin takip bilg...</summary>
    [Key]
    public string STOK_EHU_TAKIP_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki hekimin, hasta iÃ§in istediÄŸi malzeme ve ilaÃ§larÄ±n saÄŸlÄ±k tesi...</summary>
    [ForeignKey("StokIstekNavigation")]
    public string STOK_ISTEK_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta iÃ§in depodan yapÄ±lan isteklerin detay bilgilerine eriÅŸim ...</summary>
    [ForeignKey("StokIstekHareketNavigation")]
    public string STOK_ISTEK_HAREKET_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan ilaÃ§, malzeme ve Ã¼rÃ¼nlerin bilgilerine eriÅŸim saÄŸlamak ...</summary>
    [ForeignKey("StokKartNavigation")]
    public string STOK_KART_KODU { get; set; }

    /// <summary>Enfeksiyon HastalÄ±klarÄ± UzmanÄ± (EHU) tarafÄ±ndan hekim isteminin (order) hastaya ...</summary>
    public DateTime? EHU_ONAY_BASLAMA_ZAMANI { get; set; }

    /// <summary>Enfeksiyon HastalÄ±klarÄ± UzmanÄ± (EHU) tarafÄ±ndan hekim isteminin (order) hastaya ...</summary>
    public DateTime? EHU_ONAY_BITIS_ZAMANI { get; set; }

    /// <summary>Enfeksiyon HastalÄ±klarÄ± UzmanÄ± (EHU) tarafÄ±ndan onaylanan ilacÄ±n hastaya uygulan...</summary>
    public string EHU_ILAC_MAKSIMUM_MIKTAR { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>EHU onay zamanÄ± bilgisidir.</summary>
    public DateTime EHU_ONAYLAMA_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [ForeignKey("OnaylayanHekimNavigation")]
    public string ONAYLAYAN_HEKIM_KODU { get; set; }

    /// <summary>Enfeksiyon HastalÄ±klarÄ± UzmanÄ± (EHU) tarafÄ±ndan ilaÃ§ isteÄŸinin ret edilme nedeni...</summary>
    [Required]
    [ForeignKey("EhuRetNedeniNavigation")]
    public string EHU_RET_NEDENI { get; set; }

    /// <summary>Enfeksiyon HastalÄ±klarÄ± UzmanÄ± (EHU) tarafÄ±ndan ilaÃ§ isteÄŸinin ret edilme zamanÄ±...</summary>
    public DateTime EHU_RET_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [Required]
    [ForeignKey("EhuRetPersonelNavigation")]
    public string EHU_RET_PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hastaya istenen ilacÄ±n Enfeksiyon HastalÄ±klarÄ± UzmanÄ± (EHU) tar...</summary>
    [Required]
    public string EHU_RET_ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual STOK_ISTEK? StokIstekNavigation { get; set; }
    public virtual STOK_ISTEK_HAREKET? StokIstekHareketNavigation { get; set; }
    public virtual STOK_KART? StokKartNavigation { get; set; }
    public virtual PERSONEL? OnaylayanHekimNavigation { get; set; }
    public virtual REFERANS_KODLAR? EhuRetNedeniNavigation { get; set; }
    public virtual PERSONEL? EhuRetPersonelNavigation { get; set; }
    #endregion

}
