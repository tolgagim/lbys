using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// PATOLOJI tablosu - 37 kolon
/// </summary>
[Table("PATOLOJI")]
public class PATOLOJI : VemEntity
{
    /// <summary>Patoloji tetkikleri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼retilen tekil ...</summary>
    [Key]
    public string PATOLOJI_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Patoloji biriminde hastaya yazÄ±lan rapor iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi taraf...</summary>
    [Required]
    [ForeignKey("PatolojiRaporTuruNavigation")]
    public string PATOLOJI_RAPOR_TURU { get; set; }

    /// <summary>Patoloji iÃ§in hastadan alÄ±nan numunenin alÄ±ndÄ±ÄŸÄ± dokunun temel Ã¶zellik bilgisidi...</summary>
    [Required]
    [ForeignKey("DokununTemelOzelligiNavigation")]
    public string DOKUNUN_TEMEL_OZELLIGI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kiÅŸiden alÄ±nan numunenin nasÄ±l alÄ±ndÄ±ÄŸÄ±na iliÅŸkin bilgiyi ifade...</summary>
    [Required]
    [ForeignKey("NumuneAlinmaSekliNavigation")]
    public string NUMUNE_ALINMA_SEKLI { get; set; }

    /// <summary>Patoloji tetkiki iÃ§in alÄ±nan preparatÄ±n durum bilgidir. Ã–rneÄŸin materyal yeterli...</summary>
    [Required]
    [ForeignKey("PatolojiPreparatiDurumuNavigation")]
    public string PATOLOJI_PREPARATI_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki patoloji biriminde hasta bilgilerinin olduÄŸu defter numarasÄ± ...</summary>
    [Required]
    public string PATOLOJI_DEFTER_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde yapÄ±lan tetkiklerde kullanÄ±lan numuneler iÃ§in SaÄŸlÄ±k Bilgi YÃ¶ne...</summary>
    [ForeignKey("TetkikNumuneNavigation")]
    public string TETKIK_NUMUNE_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde incelenmek iÃ§in hastadan alÄ±nan numunenin materyal bilgisidir.</summary>
    [Required]
    public string PATOLOJI_MATERYALI { get; set; }

    /// <summary>ParÃ§anÄ±n alÄ±ndÄ±ÄŸÄ± organ bilgisidir.</summary>
    [Required]
    public string ORGAN { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde kiÅŸiden alÄ±nan numunenin nasÄ±l alÄ±ndÄ±ÄŸÄ±na iliÅŸkin bilgiyi ifade...</summary>
    [Required]
    [ForeignKey("NumuneAlinmaYeriNavigation")]
    public string NUMUNE_ALINMA_YERI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran kiÅŸiden alÄ±nan materyalin patolojik incelemesi sonucu e...</summary>
    [Required]
    public string PATOLOJIK_BULGU { get; set; }

    /// <summary>ICD-O Morfoloji kodu bilgisidir.</summary>
    [Required]
    [ForeignKey("PatolojikTaniMorfolojiNavigation")]
    public string PATOLOJIK_TANI_MORFOLOJI_KODU { get; set; }

    /// <summary>Hastadan alÄ±nan patolojik dokunun vÃ¼cutta bulunduÄŸu yer iÃ§in ICD-O yerleÅŸim yeri...</summary>
    [Required]
    [ForeignKey("PatolojikTaniYerlesimYeriNavigation")]
    public string PATOLOJIK_TANI_YERLESIM_YERI { get; set; }

    /// <summary>Makroskopi sonuÃ§ bilgisidir.</summary>
    [Required]
    public string MAKROSKOPI_SONUCU { get; set; }

    /// <summary>Mikroskopi iÅŸlemi sonuÃ§ bilgisidir.</summary>
    [Required]
    public string MIKROSKOPI_SONUCU { get; set; }

    /// <summary>Raporun iÃ§eriÄŸinin tÃ¼rÃ¼ne iliÅŸkin DOC, RTF, HTML vb. bilgiyi ifade eder.</summary>
    [ForeignKey("SonucIcerikTuruNavigation")]
    public string SONUC_ICERIK_TURU { get; set; }

    /// <summary>Raporu bilgisayar ortamÄ±na aktaran personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi ta...</summary>
    [Required]
    [ForeignKey("RaporYazanPersonelNavigation")]
    public string RAPOR_YAZAN_PERSONEL_KODU { get; set; }

    /// <summary>Hastadan alÄ±nan numunenin tetkikinin yapÄ±lmasÄ± iÃ§in laboratuvara kabul edildiÄŸi ...</summary>
    public DateTime PARCA_KABUL_ZAMANI { get; set; }

    /// <summary>Rapor zamanÄ± bilgisidir.</summary>
    public DateTime RAPOR_ZAMANI { get; set; }

    /// <summary>Patoloji tetkiki iÃ§in aÃ§Ä±klama bilgisidir.</summary>
    [Required]
    public string PATOLOJI_ACIKLAMA { get; set; }

    /// <summary>Patoloji uzmanÄ± tarafÄ±ndan yazÄ±lan tanÄ± bilgisidir.</summary>
    [Required]
    public string HISTOPATOLOJIK_TANI { get; set; }

    /// <summary>Patoloji uzmanÄ± tarafÄ±ndan yazÄ±lan tanÄ± bilgisidir.</summary>
    [Required]
    public string SITOPATOLOJIK_TANI { get; set; }

    /// <summary>Patoloji numunesine uygulanan histokimyasal boyama yÃ¶ntemi iÃ§in uzman tarafÄ±ndan...</summary>
    [Required]
    public string HISTOKIMYASAL_BOYAMA { get; set; }

    /// <summary>Patoloji numunesinin immÃ¼nhistokimya boyama iÅŸlemine gÃ¶re elde edilen bilgidir.</summary>
    [Required]
    public string IMMUNHISTOKIMYA_BOYAMA { get; set; }

    /// <summary>KiÅŸiden ameliyat sÄ±rasÄ±nda alÄ±nan doku Ã¶rneÄŸine kÄ±sa sÃ¼re iÃ§erisinde tanÄ± koymak...</summary>
    [Required]
    public string FROZEN_TANI { get; set; }

    /// <summary>Numunenin hangi yÃ¶ntemle boyandÄ±ÄŸÄ± bilgisidir.</summary>
    [Required]
    public string NUMUNE_BOYAMA_YONTEMI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde iÅŸlemi gerÃ§ekleÅŸtiren veya iÅŸlemin sonucunu onaylayan hekim iÃ§i...</summary>
    [Required]
    [ForeignKey("OnaylayanHekimNavigation")]
    public string ONAYLAYAN_HEKIM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde saÄŸlÄ±k hizmetini alan kiÅŸiyi muayene eden asistan hekimin SaÄŸlÄ±...</summary>
    [Required]
    [ForeignKey("AsistanHekimNavigation")]
    public string ASISTAN_HEKIM_KODU { get; set; }

    /// <summary>Patoloji tetkik sonucunu deÄŸerlendiren diÄŸer hekim iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sis...</summary>
    [Required]
    [ForeignKey("PatolojiDigerHekimNavigation")]
    public string PATOLOJI_DIGER_HEKIM_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde uzman hekimin yazdÄ±ÄŸÄ± yorum bilgisidir.</summary>
    [Required]
    public string YORUM { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? PatolojiRaporTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? DokununTemelOzelligiNavigation { get; set; }
    public virtual REFERANS_KODLAR? NumuneAlinmaSekliNavigation { get; set; }
    public virtual REFERANS_KODLAR? PatolojiPreparatiDurumuNavigation { get; set; }
    public virtual TETKIK_NUMUNE? TetkikNumuneNavigation { get; set; }
    public virtual REFERANS_KODLAR? NumuneAlinmaYeriNavigation { get; set; }
    public virtual REFERANS_KODLAR? PatolojikTaniMorfolojiNavigation { get; set; }
    public virtual REFERANS_KODLAR? PatolojikTaniYerlesimYeriNavigation { get; set; }
    public virtual REFERANS_KODLAR? SonucIcerikTuruNavigation { get; set; }
    public virtual PERSONEL? RaporYazanPersonelNavigation { get; set; }
    public virtual PERSONEL? OnaylayanHekimNavigation { get; set; }
    public virtual PERSONEL? AsistanHekimNavigation { get; set; }
    public virtual PERSONEL? PatolojiDigerHekimNavigation { get; set; }
    #endregion

}
