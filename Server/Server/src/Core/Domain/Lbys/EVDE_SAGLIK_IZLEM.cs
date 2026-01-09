using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// EVDE_SAGLIK_IZLEM tablosu - 31 kolon
/// </summary>
[Table("EVDE_SAGLIK_IZLEM")]
public class EVDE_SAGLIK_IZLEM : VemEntity
{
    /// <summary>Evde saÄŸlÄ±k hizmeti alan kiÅŸilerin izlem bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sis...</summary>
    [Key]
    public string EVDE_SAGLIK_IZLEM_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± tablo adÄ± bilgisidir.</summary>
/// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>KiÅŸinin aÄŸrÄ± hissedip hissetmediÄŸini gÃ¶sterir.</summary>
    [Required]
    [ForeignKey("AgriNavigation")]
    public string AGRI { get; set; }

    /// <summary>YaÅŸanÄ±lan alanÄ±n aydÄ±nlanma durumunu tanÄ±mlar.</summary>
    [Required]
    [ForeignKey("AydinlatmaNavigation")]
    public string AYDINLATMA { get; set; }

    /// <summary>Evde saÄŸlÄ±k hizmeti almak iÃ§in, kiÅŸinin tÄ±bbi bakÄ±m, sosyal hizmet, destek ve ya...</summary>
    [Required]
    [ForeignKey("BakimVeDestekIhtiyaciNavigation")]
    public string BAKIM_VE_DESTEK_IHTIYACI { get; set; }

    /// <summary>Braden skalasÄ±na gÃ¶re hastada basÄ± durumunu gÃ¶sterir.</summary>
    [Required]
    [ForeignKey("BasiDegerlendirmesiNavigation")]
    public string BASI_DEGERLENDIRMESI { get; set; }

    /// <summary>Evde saÄŸlÄ±k hizmetinden yararlanmak amacÄ± ile baÅŸvurulan kurumu tanÄ±mlar.</summary>
    [ForeignKey("BasvuruTuruNavigation")]
    public string BASVURU_TURU { get; set; }

    /// <summary>KiÅŸinin beslenme durumunu tanÄ±mlar.</summary>
    [Required]
    [ForeignKey("BeslenmeNavigation")]
    public string BESLENME { get; set; }

    /// <summary>Evde SaÄŸlÄ±k Hizmeti (ESH) verilen hastalarÄ±n, hastalÄ±k gruplarÄ±nÄ± ifade eder.</summary>
    [Required]
    [ForeignKey("EshEsasHastalikGrubuNavigation")]
    public string ESH_ESAS_HASTALIK_GRUBU { get; set; }

    /// <summary>KiÅŸinin yaÅŸadÄ±ÄŸÄ± alanÄ±n hijyen ÅŸartlarÄ±nÄ± tanÄ±mlar.</summary>
    [Required]
    [ForeignKey("EvHijyeniNavigation")]
    public string EV_HIJYENI { get; set; }

    /// <summary>Evde saÄŸlÄ±k hizmetini alan kiÅŸiler iÃ§in alÄ±nan gÃ¼venlik Ã¶nlemlerinin yeterli olu...</summary>
    [Required]
    [ForeignKey("GuvenlikNavigation")]
    public string GUVENLIK { get; set; }

    /// <summary>KiÅŸinin barÄ±ndÄ±ÄŸÄ± alandaki Ä±sÄ±nma tipini ifade eder.</summary>
    [Required]
    [ForeignKey("IsinmaNavigation")]
    public string ISINMA { get; set; }

    /// <summary>KiÅŸinin kendi ihtiyaÃ§larÄ±nÄ± karÅŸÄ±lama durumunu tanÄ±mlar.</summary>
    [Required]
    [ForeignKey("KisiselBakimNavigation")]
    public string KISISEL_BAKIM { get; set; }

    /// <summary>KiÅŸinin kendine bakÄ±m durumunu ifade eder.</summary>
    [Required]
    [ForeignKey("KisiselHijyenNavigation")]
    public string KISISEL_HIJYEN { get; set; }

    /// <summary>KiÅŸinin ikamet ettiÄŸi alanÄ± tanÄ±mlar.</summary>
    [Required]
    [ForeignKey("KonutTipiNavigation")]
    public string KONUT_TIPI { get; set; }

    /// <summary>Meskenin hela tipini tanÄ±mlar.</summary>
    [Required]
    [ForeignKey("KullanilanHelaTipiNavigation")]
    public string KULLANILAN_HELA_TIPI { get; set; }

    /// <summary>Hizmet alan kiÅŸinin yataÄŸa baÄŸÄ±mlÄ±lÄ±k durumunu tanÄ±mlar.</summary>
    [Required]
    [ForeignKey("YatagaBagimlilikNavigation")]
    public string YATAGA_BAGIMLILIK { get; set; }

    /// <summary>KiÅŸinin hareketi iÃ§in kullanÄ±lan yardÄ±mcÄ± araÃ§larÄ± ifade eder.</summary>
    [Required]
    [ForeignKey("KullandigiYardimciAraclarNavigation")]
    public string KULLANDIGI_YARDIMCI_ARACLAR { get; set; }

    /// <summary>KiÅŸinin psikolojik durumu hakkÄ±nda genel bilgi verir.</summary>
    [Required]
    [ForeignKey("PsikolojikDurumDegerlendirmeNavigation")]
    public string PSIKOLOJIK_DURUM_DEGERLENDIRME { get; set; }

    /// <summary>Evde SaÄŸlÄ±k Hizmeti (ESH) verilen hastalarda, saÄŸlÄ±k hizmetinin herhangi bir ned...</summary>
    [Required]
    [ForeignKey("EshSonlandirilmasiNavigation")]
    public string ESH_SONLANDIRILMASI { get; set; }

    /// <summary>Evde SaÄŸlÄ±k Hizmeti (ESH) verilen hastalarÄ±n herhangi bir saÄŸlÄ±k tesisine nakil ...</summary>
    [Required]
    [ForeignKey("EshHastaNakliNavigation")]
    public string ESH_HASTA_NAKLI { get; set; }

    /// <summary>Evde saÄŸlÄ±k hizmetinin alÄ±ndÄ±ÄŸÄ± il bilgisidir.</summary>
    [Required]
    [ForeignKey("EshAlinacakIlNavigation")]
    public string ESH_ALINACAK_IL { get; set; }

    /// <summary>KiÅŸiye verilmesi planlanan hizmet tÃ¼rÃ¼ bilgisidir. Ã–rneÄŸin aile hekimi deÄŸerlend...</summary>
    [Required]
    [ForeignKey("BirSonrakiHizmetIhtiyaciNavigation")]
    public string BIR_SONRAKI_HIZMET_IHTIYACI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personel tarafÄ±ndan verilen eÄŸitimin bilgisidir. Ã–rneÄŸi...</summary>
    [Required]
    [ForeignKey("VerilenEgitimlerNavigation")]
    public string VERILEN_EGITIMLER { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? AgriNavigation { get; set; }
    public virtual REFERANS_KODLAR? AydinlatmaNavigation { get; set; }
    public virtual REFERANS_KODLAR? BakimVeDestekIhtiyaciNavigation { get; set; }
    public virtual REFERANS_KODLAR? BasiDegerlendirmesiNavigation { get; set; }
    public virtual REFERANS_KODLAR? BasvuruTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? BeslenmeNavigation { get; set; }
    public virtual REFERANS_KODLAR? EshEsasHastalikGrubuNavigation { get; set; }
    public virtual REFERANS_KODLAR? EvHijyeniNavigation { get; set; }
    public virtual REFERANS_KODLAR? GuvenlikNavigation { get; set; }
    public virtual REFERANS_KODLAR? IsinmaNavigation { get; set; }
    public virtual REFERANS_KODLAR? KisiselBakimNavigation { get; set; }
    public virtual REFERANS_KODLAR? KisiselHijyenNavigation { get; set; }
    public virtual REFERANS_KODLAR? KonutTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? KullanilanHelaTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? YatagaBagimlilikNavigation { get; set; }
    public virtual REFERANS_KODLAR? KullandigiYardimciAraclarNavigation { get; set; }
    public virtual REFERANS_KODLAR? PsikolojikDurumDegerlendirmeNavigation { get; set; }
    public virtual REFERANS_KODLAR? EshSonlandirilmasiNavigation { get; set; }
    public virtual REFERANS_KODLAR? EshHastaNakliNavigation { get; set; }
    public virtual REFERANS_KODLAR? EshAlinacakIlNavigation { get; set; }
    public virtual REFERANS_KODLAR? BirSonrakiHizmetIhtiyaciNavigation { get; set; }
    public virtual REFERANS_KODLAR? VerilenEgitimlerNavigation { get; set; }
    #endregion

}
