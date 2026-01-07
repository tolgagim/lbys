using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// KAN_BAGISCI tablosu - 33 kolon
/// </summary>
[Table("KAN_BAGISCI")]
public class KAN_BAGISCI : VemEntity
{
    /// <summary>Kan baÄŸÄ±ÅŸÄ±nda bulunan kiÅŸi iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼retilen...</summary>
    [Key]
    public string KAN_BAGISCI_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>KanÄ± baÄŸÄ±ÅŸlayan kiÅŸinin saÄŸlÄ±k tesisine baÅŸvurusu iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sist...</summary>
    [ForeignKey("BagisciHastaBasvuruNavigation")]
    public string BAGISCI_HASTA_BASVURU_KODU { get; set; }

    /// <summary>KanÄ± baÄŸÄ±ÅŸlayan kiÅŸi iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼retilen tekil...</summary>
    [ForeignKey("BagisciHastaNavigation")]
    public string BAGISCI_HASTA_KODU { get; set; }

    /// <summary>Kan baÄŸÄ±ÅŸÄ± iÅŸleminin yapÄ±ldÄ±ÄŸÄ± zaman bilgisidir.</summary>
    public DateTime? KAN_BAGIS_ZAMANI { get; set; }

    /// <summary>KiÅŸinin kan grubunu ifade eder</summary>
    [ForeignKey("KanGrubuNavigation")]
    public string KAN_GRUBU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde baÄŸÄ±ÅŸÄ± yapÄ±lan kan Ã¼rÃ¼nÃ¼nÃ¼n hangi hasta iÃ§in rezerve edildiÄŸi b...</summary>
    [Required]
    [ForeignKey("RezervHastaNavigation")]
    public string REZERV_HASTA_KODU { get; set; }

    /// <summary>BaÄŸÄ±ÅŸlanan kan tÃ¼rÃ¼nÃ¼ ifade eder. Ã–rneÄŸin tam kan, aferez trombosit, aferez gran...</summary>
    [ForeignKey("BagislananKanTuruNavigation")]
    public string BAGISLANAN_KAN_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hastaya uygulanan tÄ±bbi iÅŸlem sonucunda hastada reaksiyon oluÅŸm...</summary>
    [Required]
    public string REAKSIYON_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hastaya uygulanan tÄ±bbi iÅŸlem sonucunda hastada geliÅŸen reaksiy...</summary>
    [Required]
    [ForeignKey("ReaksiyonTuruNavigation")]
    public string REAKSIYON_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hastaya uygulanan tÄ±bbi iÅŸlem sonucunda hastada oluÅŸan reaksiyo...</summary>
    [Required]
    public string REAKSIYON_ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kan baÄŸÄ±ÅŸÄ± yapÄ±lan hasta iÃ§in KÄ±zÄ±layâ€™dan alÄ±nan izin numarasÄ± ...</summary>
    [Required]
    public string KIZILAY_IZIN_NUMARASI { get; set; }

    /// <summary>Sistolik kan basÄ±ncÄ± (bÃ¼yÃ¼k tansiyon) bilgisini ifade eder.</summary>
    [Required]
    public string SISTOLIK_KAN_BASINCI_DEGERI { get; set; }

    /// <summary>Kan basÄ±ncÄ± Ã¶lÃ§me protokolÃ¼ne uygun olarak "mm Hg" birimi ile Ã¶lÃ§Ã¼len diastolik ...</summary>
    [Required]
    public string DIASTOLIK_KAN_BASINCI_DEGERI { get; set; }

    /// <summary>KiÅŸinin santigrat cinsinden vÃ¼cut Ä±sÄ±sÄ± bilgisidir.</summary>
    [Required]
    public string ATES { get; set; }

    /// <summary>KiÅŸinin santimetre cinsinden boy bilgisidir.</summary>
    [Required]
    public string BOY { get; set; }

    /// <summary>KiÅŸinin (gram cinsinden) aÄŸÄ±rlÄ±ÄŸÄ±dÄ±r.</summary>
    [Required]
    public string AGIRLIK { get; set; }

    /// <summary>Kan baÄŸÄ±ÅŸÄ±nda bulunan kiÅŸinin muayenesi iÃ§in uzman dÃ¼ÅŸÃ¼ncelerini ifade eder.</summary>
    [Required]
    public string UZMAN_DEGERLENDIRME { get; set; }

    /// <summary>SaÄŸlÄ±k tesisi depolarÄ±nda hareket gÃ¶ren malzemelerin Ã¼retimi ile bilgileri iÃ§ere...</summary>
    [Required]
    public string LOT_NUMARASI { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼nÃ¼n mililitre cinsinden hacim bilgisidir.</summary>
    [Required]
    public string KAN_HACIM { get; set; }

    /// <summary>Kan Ã¼rÃ¼nÃ¼ torbasÄ± Ã¼zerine KÄ±zÄ±lay tarafÄ±ndan yazÄ±lan numara bilgisidir.</summary>
    [Required]
    public string SEGMENT_NUMARASI { get; set; }

    /// <summary>Kan baÄŸÄ±ÅŸÄ±nda bulunan kiÅŸinin kan baÄŸÄ±ÅŸÄ±nda bulunma nedenine iliÅŸkin bilgiyi ifa...</summary>
    [ForeignKey("BagisciTuruNavigation")]
    public string BAGISCI_TURU { get; set; }

    /// <summary>BaÄŸÄ±ÅŸ yapÄ±lan kan Ã¼rÃ¼nÃ¼nÃ¼n deÄŸerlendirme sonuÃ§ bilgisidir. Ã–rneÄŸin onaylÄ±, geÃ§ic...</summary>
    [Required]
    [ForeignKey("KanBagisDegerlendirmeSonucuNavigation")]
    public string KAN_BAGIS_DEGERLENDIRME_SONUCU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kan Ã¼rÃ¼nÃ¼nÃ¼ deÄŸerlendiren personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Si...</summary>
    [Required]
    [ForeignKey("DegerlendirenPersonelNavigation")]
    public string DEGERLENDIREN_PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine yapÄ±lan kan baÄŸÄ±ÅŸÄ± sonucunun deÄŸerlendirildiÄŸi zaman bilgisidir.</summary>
    public DateTime KAN_BAGIS_DEGERLENDIRME_ZAMANI { get; set; }

    /// <summary>Kan baÄŸÄ±ÅŸÃ§Ä±sÄ± ret nedenlerini ifade eder.</summary>
    [Required]
    [ForeignKey("KanBagiscisiRetNedenleriNavigation")]
    public string KAN_BAGISCISI_RET_NEDENLERI { get; set; }

    /// <summary>Ret sÃ¼resinin gÃ¼n cinsinden bilgisidir.</summary>
    [Required]
    public string RET_SURESI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA_BASVURU? BagisciHastaBasvuruNavigation { get; set; }
    public virtual HASTA? BagisciHastaNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanGrubuNavigation { get; set; }
    public virtual HASTA? RezervHastaNavigation { get; set; }
    public virtual REFERANS_KODLAR? BagislananKanTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? ReaksiyonTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? BagisciTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanBagisDegerlendirmeSonucuNavigation { get; set; }
    public virtual PERSONEL? DegerlendirenPersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanBagiscisiRetNedenleriNavigation { get; set; }
    #endregion

}
