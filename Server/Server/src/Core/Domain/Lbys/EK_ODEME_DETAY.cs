using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// EK_ODEME_DETAY tablosu - 25 kolon
/// </summary>
[Table("EK_ODEME_DETAY")]
public class EK_ODEME_DETAY : VemEntity
{
    /// <summary>SBYS tarafÄ±ndan Ã¼retilen tekil kod bilgisidir.</summary>
    [Key]
    public string EK_ODEME_DETAY_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele Ã¶denecek ek Ã¶demeye ait kayÄ±tlara ulaÅŸÄ±labilm...</summary>
    [ForeignKey("EkOdemeNavigation")]
    public string EK_ODEME_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin aynÄ± ay iÃ§inde birden fazla kadroda gÃ¶rev ya...</summary>
    [Required]
    public string GOREV_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin kadrosuna iliÅŸkin kod bilgisidir.</summary>
    [Required]
    public string KADRO_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personel iÃ§in maaÅŸ hesaplamasÄ±nda kullanÄ±lacak kadrosun...</summary>
    [Required]
    public string KADRO_KATSAYISI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli hekimler tarafÄ±ndan, hastaya uygulanan tÄ±bbi iÅŸlem iÃ§in...</summary>
    public string GIRISIMSEL_ISLEM_PUANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin uyguladÄ±ÄŸÄ± tÄ±bbi iÅŸlemler iÃ§in aldÄ±ÄŸÄ± Ã¶zelli...</summary>
    [Required]
    public string OZELLIKLI_ISLEM_PUANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin kadrosu iÃ§in tavan katsayÄ±sÄ± bilgisidir.</summary>
    [Required]
    public string TAVAN_KATSAYISI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin ilgili kadroda Ã§alÄ±ÅŸmÄ±ÅŸ olduÄŸu toplam gÃ¼n sa...</summary>
    [Required]
    public string CALISILAN_GUN_TOPLAMI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin ilgili kadroda Ã§alÄ±ÅŸmÄ±ÅŸ olduÄŸu toplam saat b...</summary>
    [Required]
    public string CALISILAN_SAAT_TOPLAMI { get; set; }

    /// <summary>Belirli bir dÃ¶nem iÃ§indeki toplam gÃ¼n sayÄ±sÄ±ndan Ã§alÄ±ÅŸÄ±lmayan gÃ¼nlerin Ã§Ä±karÄ±lma...</summary>
    [Required]
    public string AKTIF_CALISILAN_GUN_KATSAYISI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele aylÄ±k Ã¶denen ek Ã¶deme iÃ§in hesaplanan hastane...</summary>
    public string HASTANE_PUAN_ORTALAMASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde bulunan kliniklerin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan gru...</summary>
    [Required]
    [ForeignKey("KlinikNavigation")]
    public string KLINIK_KODU { get; set; }

    /// <summary>Ä°lgili klinik iÃ§in ek Ã¶deme hesaplamasÄ±nda kullanÄ±lmÄ±ÅŸ puan ortalamasÄ± bilgisidi...</summary>
    [Required]
    public string KLINIK_PUAN_ORTALAMASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin kadro unvan katsayÄ±sÄ±na gÃ¶re hesaplanan puan...</summary>
    [Required]
    public string BRUT_PERFORMANS_PUANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin asil gÃ¶revi dÄ±ÅŸÄ±nda baÅŸka bir gÃ¶rev yapmasÄ± ...</summary>
    [Required]
    public string EK_PERFORMANS_PUANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki personelin tÃ¼m ek performans puanlarÄ±n ve brÃ¼t performans pua...</summary>
    [Required]
    public string NET_PERFORMANS_PUANI { get; set; }

    /// <summary>ÃœÃ§Ã¼ncÃ¼ basamak saÄŸlÄ±k tesislerinde, baÅŸhekimlik tarafÄ±ndan belirlenen usul Ã§erÃ§e...</summary>
    [Required]
    public string EGITICI_DESTEKLEME_PUANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin bilimsel Ã§alÄ±ÅŸma puan bilgisidir.</summary>
    [Required]
    public string BILIMSEL_CALISMA_PUANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin varsa serbest meslek katsayÄ±sÄ± bilgisini ifa...</summary>
    [Required]
    public string SERBEST_MESLEK_KATSAYISI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual EK_ODEME? EkOdemeNavigation { get; set; }
    public virtual REFERANS_KODLAR? KlinikNavigation { get; set; }
    #endregion

}
