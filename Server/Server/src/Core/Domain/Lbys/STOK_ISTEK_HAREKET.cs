using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// STOK_ISTEK_HAREKET tablosu - 21 kolon
/// </summary>
[Table("STOK_ISTEK_HAREKET")]
public class STOK_ISTEK_HAREKET : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde hasta iÃ§in depodan yapÄ±lan isteklerin detay bilgilerine eriÅŸim ...</summary>
    [Key]
    public string STOK_ISTEK_HAREKET_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisindeki hekimin, hasta iÃ§in istediÄŸi malzeme ve ilaÃ§larÄ±n saÄŸlÄ±k tesi...</summary>
    [ForeignKey("StokIstekNavigation")]
    public string STOK_ISTEK_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisi deposundan istemi yapÄ±lan ilaÃ§, malzeme, Ã¼rÃ¼n vb. iÃ§in SaÄŸlÄ±k Bilg...</summary>
    [Required]
    [ForeignKey("IstenenStokKartNavigation")]
    public string ISTENEN_STOK_KART_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinin deposunda bulunan ilacÄ±n jeneriÄŸi iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sis...</summary>
    [Required]
    [ForeignKey("IstenenIlacJenerikNavigation")]
    public string ISTENEN_ILAC_JENERIK_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde ilgili stok depo gÃ¶revlisi tarafÄ±ndan teslim edilen ilaÃ§, malze...</summary>
    [Required]
    [ForeignKey("VerilenStokKartNavigation")]
    public string VERILEN_STOK_KART_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavi gÃ¶ren hastaya ait ilaÃ§, malzeme isteÄŸinin hekim tarafÄ±nd...</summary>
    public string ISTEK_GEREKLILIK_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hastaya uygulanacak tedavi iÃ§in kullanÄ±lacak ilacÄ±n, hastanÄ±n y...</summary>
    public string TEDAVIDE_KULLANILAN_ILAC { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinden tedavi gÃ¶ren hasta iÃ§in hekim tarafÄ±ndan istenen ilaÃ§, malzeme...</summary>
    public string ISTENEN_MIKTAR { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>Ä°laÃ§, malzeme, Ã¼rÃ¼n vb. isteklerinden saÄŸlÄ±k tesisi deposundan karÅŸÄ±lanan miktar...</summary>
    [Required]
    public string DEPODAN_VERILEN_MIKTAR { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼rÃ¼n, ilaÃ§ veya malzemeye iliÅŸkin yapÄ±lan isteÄŸin ret edilmesin...</summary>
    [Required]
    [ForeignKey("StokIstekRetNedeniNavigation")]
    public string STOK_ISTEK_RET_NEDENI { get; set; }

    /// <summary>Stoktan yapÄ±lan isteÄŸin reddedildiÄŸi zaman bilgisidir.</summary>
    public DateTime STOK_ISTEK_RET_ZAMANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼rÃ¼n, ilaÃ§ veya malzemeye iliÅŸkin yapÄ±lan isteÄŸin reddedildiÄŸi ...</summary>
    [Required]
    [ForeignKey("StokIstekRetKullaniciNavigation")]
    public string STOK_ISTEK_RET_KULLANICI_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual STOK_ISTEK? StokIstekNavigation { get; set; }
    public virtual STOK_KART? IstenenStokKartNavigation { get; set; }
    public virtual REFERANS_KODLAR? IstenenIlacJenerikNavigation { get; set; }
    public virtual STOK_KART? VerilenStokKartNavigation { get; set; }
    public virtual REFERANS_KODLAR? StokIstekRetNedeniNavigation { get; set; }
    public virtual KULLANICI? StokIstekRetKullaniciNavigation { get; set; }
    #endregion

}
