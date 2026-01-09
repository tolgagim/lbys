using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// PERSONEL_IZIN tablosu - 21 kolon
/// </summary>
[Table("PERSONEL_IZIN")]
public class PERSONEL_IZIN : VemEntity
{
    /// <summary>SBYS tarafÄ±ndan Ã¼retilen tekil kod bilgisidir.</summary>
    [Key]
    public string PERSONEL_IZIN_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin kullandÄ±ÄŸÄ± iznin tÃ¼rÃ¼ (doÄŸum izni, yÄ±llÄ±k iz...</summary>
    [ForeignKey("PersonelIzinTuruNavigation")]
    public string PERSONEL_IZIN_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin kullandÄ±ÄŸÄ± iznin gÃ¼n sayÄ±sÄ± bilgisidir.</summary>
    public string KULLANILAN_IZIN { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin bir Ã¶nceki yÄ±ldan kalan izninden kullandÄ±ÄŸÄ± ...</summary>
    [Required]
    public string GECEN_YILDAN_KULLANILAN_IZIN { get; set; }

    /// <summary>SaÄŸlÄ±k tesisi personelinin iÃ§inde bulunduÄŸu yÄ±ldan kullanÄ±lan yÄ±llÄ±k izin gÃ¼n sa...</summary>
    [Required]
    public string AKTIF_YILDAN_KULLANILAN_IZIN { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin izin baÅŸlama tarihi bilgisidir.</summary>
    public DateTime? IZIN_BASLAMA_TARIHI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin izninin bitiÅŸ tarihi bilgisidir.</summary>
    public DateTime IZIN_BITIS_TARIHI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin kullandÄ±ÄŸÄ± iznin hangi yÄ±la ait olduÄŸu bilgi...</summary>
    public string PERSONEL_IZIN_YILI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin gÃ¶reve baÅŸladÄ±ÄŸÄ± tarih bilgisidir.</summary>
    public DateTime PERSONEL_DONUS_TARIHI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶rev yapan personelin izne Ã§Ä±ktÄ±ÄŸÄ± adres bilgisidir.</summary>
    [Required]
    public string IZIN_ADRESI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin izin dÃ¶neminde SaÄŸlÄ±k Bilgi YÃ¶netim Sistemin...</summary>
    [Required]
    public string SBYS_ENGELLENME_DURUMU { get; set; }

    /// <summary>SBYS kullanÄ±mÄ±nÄ±n engellendiÄŸi zaman bilgisidir.</summary>
    public DateTime SBYS_KULLANIM_ENGELLEME_ZAMANI { get; set; }

    /// <summary>SBYS kullanÄ±mÄ±nÄ± engelleyen kullanÄ±cÄ±nÄ±n</summary>
    [Required]
    [ForeignKey("SbysEngelleyenKullaniciNavigation")]
    public string SBYS_ENGELLEYEN_KULLANICI_KODU { get; set; }

    /// <summary>YapÄ±lan bir iÅŸlemi onaylayan personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±nd...</summary>
    [Required]
    [ForeignKey("OnaylayanPersonelNavigation")]
    public string ONAYLAYAN_PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual PERSONEL? PersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? PersonelIzinTuruNavigation { get; set; }
    public virtual KULLANICI? SbysEngelleyenKullaniciNavigation { get; set; }
    public virtual PERSONEL? OnaylayanPersonelNavigation { get; set; }
    #endregion

}
