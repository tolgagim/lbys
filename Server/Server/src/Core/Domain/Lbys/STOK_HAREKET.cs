using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// STOK_HAREKET tablosu - 38 kolon
/// </summary>
[Table("STOK_HAREKET")]
public class STOK_HAREKET : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde kullanÄ±lan malzemelerin ayrÄ±ntÄ±lÄ± hareket bilgilerini takip etm...</summary>
    [Key]
    public string STOK_HAREKET_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinin deposuna giriÅŸi veya Ã§Ä±kÄ±ÅŸÄ± yapÄ±lan ilaÃ§, malzeme, Ã¼rÃ¼n vb. iÃ§i...</summary>
    [Required]
    [ForeignKey("BagliStokHareketNavigation")]
    public string BAGLI_STOK_HAREKET_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisi depolarÄ±na giriÅŸ iÅŸlemi yapÄ±lan ilaÃ§, malzeme, Ã¼rÃ¼n vb. bilgileri ...</summary>
    [Required]
    [ForeignKey("IlkGirisStokHareketNavigation")]
    public string ILK_GIRIS_STOK_HAREKET_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta iÃ§in depodan yapÄ±lan isteklerin detay bilgilerine eriÅŸim ...</summary>
    [Required]
    [ForeignKey("StokIstekHareketNavigation")]
    public string STOK_ISTEK_HAREKET_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kullanÄ±lan malzemelerin hareket bilgilerini takip etmek iÃ§in Sa...</summary>
    [ForeignKey("StokFisNavigation")]
    public string STOK_FIS_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan ilaÃ§, malzeme ve Ã¼rÃ¼nlerin bilgilerine eriÅŸim saÄŸlamak ...</summary>
    [ForeignKey("StokKartNavigation")]
    public string STOK_KART_KODU { get; set; }

    /// <summary>Ã‡ubuk kod ya da Ã§izgi im, verilerin gÃ¶rsel Ã¶zellikli makinelerin okuyabilmesi iÃ§...</summary>
    [Required]
    public string BARKOD { get; set; }

    /// <summary>SaÄŸlÄ±k tesisi depolarÄ±nda hareket gÃ¶ren malzemelerin Ã¼retimi ile bilgileri iÃ§ere...</summary>
    [Required]
    public string LOT_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan tÄ±bbi cihazlarÄ±n Ã¼rÃ¼nlere verilen grup numarasÄ± olan LO...</summary>
    [Required]
    public string SERI_SIRA_NUMARASI { get; set; }

    /// <summary>TÃ¼rkiye Ä°laÃ§ ve TÄ±bbi Cihaz Kurumu tarafÄ±ndan Ã¼retici firma numarasÄ± bilgisidir.</summary>
    [Required]
    public string FIRMA_TANIMLAYICI_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hastaya uygulanan malzemeler iÃ§in SUT'ta tanÄ±mlanmÄ±ÅŸ kod bilgis...</summary>
    [Required]
    public string MALZEME_SUT_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisi depolarÄ±na giriÅŸ veya Ã§Ä±kÄ±ÅŸ iÅŸlemi yapÄ±lan ilaÃ§, malzeme, Ã¼rÃ¼n vb....</summary>
    public string STOK_HAREKET_MIKTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan taÅŸÄ±nÄ±r malzemeler iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi ta...</summary>
    public string TASINIR_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinin deposuna alÄ±nan ilaÃ§, malzeme vb. birim fiyat bilgisidir.</summary>
    public string ALIS_BIRIM_FIYATI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine alÄ±nan malÄ±n satÄ±ÅŸ birim fiyat bilgisini ifade eder.</summary>
    public string SATIS_BIRIM_FIYATI { get; set; }

    /// <summary>Ä°laÃ§, malzeme, Ã¼rÃ¼n vb. iÃ§in saÄŸlÄ±k tesisinde kullanÄ±lan Ã¶lÃ§Ã¼ biriminin SaÄŸlÄ±k B...</summary>
    [ForeignKey("OlcuNavigation")]
    public string OLCU_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [Required]
    [ForeignKey("IslemiYapanPersonelNavigation")]
    public string ISLEMI_YAPAN_PERSONEL_KODU { get; set; }

    /// <summary>KDV oranÄ± bilgisidir.</summary>
    [Required]
    public string KDV_ORANI { get; set; }

    /// <summary>Ä°skonto oranÄ± bilgisidir.</summary>
    [Required]
    public string ISKONTO_ORANI { get; set; }

    /// <summary>Ä°skonto tutar bilgisidir.</summary>
    [Required]
    public string ISKONTO_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kullanÄ±lan ilaÃ§, aÅŸÄ±, tÄ±bbi alet vb. son kullanma tarihi bilgis...</summary>
    public DateTime SON_KULLANMA_TARIHI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinin stoklarÄ±na giriÅŸi yapÄ±lan Ä°laÃ§ ve malzeme iÃ§in Malzeme Kaynak Y...</summary>
    [Required]
    public string MKYS_STOK_HAREKET_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan bir iÅŸlemin iptal edilip edilmediÄŸi bilgisidir.</summary>
    [Required]
    public string IPTAL_DURUMU { get; set; }

    /// <summary>Ä°laÃ§ ve malzemenin saÄŸlÄ±k tesisinin stoklarÄ±na girmesinden sonra hareketlerini t...</summary>
    [Required]
    public string MKYS_KARSI_STOK_HAREKET_KODU { get; set; }

    /// <summary>Malzeme Kaynak YÃ¶netim Sistemi (MKYS) tarafÄ±ndan Ã¼retilen cihaz kÃ¼nye numarasÄ± b...</summary>
    [Required]
    public string MKYS_KUNYE_NUMARASI { get; set; }

    /// <summary>Ä°lgili Ã¼rÃ¼nÃ¼n ÃœTS sistemine kayÄ±t edilmesi durumunda dÃ¶nen UDI (Unique Device Id...</summary>
    [Required]
    public string UTS_KAYIT_UDI { get; set; }

    /// <summary>ÃœrÃ¼nÃ¼n alÄ±ndÄ±ÄŸÄ± bayinin numara bilgisidir.</summary>
    [Required]
    public string BAYILIK_NUMARASI { get; set; }

    /// <summary>ÃœrÃ¼nler iÃ§in ÃœrÃ¼n Takip Sisteminde (ÃœTS) tanÄ±mlanmÄ±ÅŸ Unique Device Identificatio...</summary>
    [Required]
    [ForeignKey("CihazNavigation")]
    public string CIHAZ_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kiÅŸiye aÅŸÄ± uygulanmadan Ã¶nce SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi taraf...</summary>
    [Required]
    public string ATS_SORGU_NUMARASI { get; set; }

    /// <summary>Vericinin uygun bir biÃ§imde tanÄ±mlanmÄ±ÅŸ ve baÄŸÄ±ÅŸlanan materyalin izlenebilirliÄŸi...</summary>
    [Required]
    public string ALLOGREFT_DONOR_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemine ilk defa kayÄ±t ...</summary>

    #region Navigation Properties
    public virtual STOK_HAREKET? BagliStokHareketNavigation { get; set; }
    public virtual STOK_HAREKET? IlkGirisStokHareketNavigation { get; set; }
    public virtual STOK_ISTEK_HAREKET? StokIstekHareketNavigation { get; set; }
    public virtual STOK_FIS? StokFisNavigation { get; set; }
    public virtual STOK_KART? StokKartNavigation { get; set; }
    public virtual REFERANS_KODLAR? OlcuNavigation { get; set; }
    public virtual PERSONEL? IslemiYapanPersonelNavigation { get; set; }
    public virtual CIHAZ? CihazNavigation { get; set; }
    #endregion

}
