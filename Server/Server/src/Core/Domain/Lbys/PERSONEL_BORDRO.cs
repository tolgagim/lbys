using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// PERSONEL_BORDRO tablosu - 85 kolon
/// </summary>
[Table("PERSONEL_BORDRO")]
public class PERSONEL_BORDRO : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin bordro bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim S...</summary>
    [Key]
    public string PERSONEL_BORDRO_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
/// <summary>YÄ±l bilgisini ifade eder.</summary>
    public string YIL { get; set; }

    /// <summary>YÄ±lÄ±n on iki bÃ¶lÃ¼mÃ¼nden her birini ifade eder.</summary>
    public string AY { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personel iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶rev yapan personel iÃ§in hesaplanan Ã¶demenin tÃ¼r bilgisidir.</summary>
    [ForeignKey("BordroTuruNavigation")]
    public string BORDRO_TURU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶rev yapan personel iÃ§in yapÄ±lan her tÃ¼rlÃ¼ Ã¶deme bilgisine ait...</summary>
    [Required]
    public string BORDRO_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele ait maaÅŸ derece bilgisidir.</summary>
    [Required]
    public string MAAS_DERECESI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele ait maaÅŸ kademe bilgisidir.</summary>
    [Required]
    public string MAAS_KADEMESI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele ait maaÅŸ gÃ¶sterge bilgisidir.</summary>
    [Required]
    public string MAAS_GOSTERGESI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli Personele ait maaÅŸ ek gÃ¶sterge bilgisidir.</summary>
    [Required]
    public string MAAS_EK_GOSTERGESI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele ait emekli derecesi bilgisidir.</summary>
    [Required]
    public string EMEKLI_DERECESI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele ait emekli kademe bilgisidir.</summary>
    [Required]
    public string EMEKLI_KADEMESI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin ait emekli gÃ¶sterge bilgisidir.</summary>
    [Required]
    public string EMEKLI_GOSTERGESI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele ait emekli ek gÃ¶stergesi bilgisidir.</summary>
    [Required]
    public string EMEKLI_EK_GOSTERGESI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele ait taban aylÄ±k tutar bilgisidir.</summary>
    [Required]
    public string TABAN_AYLIK_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisisinde gÃ¶revli personele yapÄ±lan aylÄ±k Ã¶deme bilgisidir.</summary>
    [Required]
    public string AYLIK_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele ait kÄ±dem tutarÄ± bilgisidir.</summary>
    [Required]
    public string KIDEM_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin ek gÃ¶sterge tutarÄ± bilgisidir.</summary>
    [Required]
    public string EK_GOSTERGE_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele ait yan Ã¶deme tutarÄ± bilgisidir.</summary>
    [Required]
    public string YAN_ODEME_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele ait Ã¶zel hizmet tutarÄ± bilgisidir.</summary>
    [Required]
    public string OZEL_HIZMET_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele yapÄ±lan aile yardÄ±mÄ± tutarÄ± bilgisidir.</summary>
    [Required]
    public string AILE_YARDIMI_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personele yapÄ±lan Ã§ocuk yardÄ±mÄ± tutarÄ± bilgisidir.</summary>
    [Required]
    public string COCUK_YARDIMI_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personelin 6 yaÅŸ altÄ±ndaki (yaÅŸ < 6) Ã§ocuk sayÄ±sÄ± bil...</summary>
    [Required]
    public string COCUK_SAYISI_6_YAS_ALTI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki gÃ¶revli personelin 6 yaÅŸ Ã¼stÃ¼ndeki (yaÅŸ > 6) Ã§ocuk sayÄ±sÄ± bil...</summary>
    [Required]
    public string COCUK_SAYISI_6_YAS_USTU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin Asgari GeÃ§im Ä°ndirimine (AGÄ°) esas Ã§ocuk say...</summary>
    [Required]
    public string AGI_ESAS_COCUK_SAYISI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin eÅŸinin herhangi bir iÅŸte Ã§alÄ±ÅŸma durumunu if...</summary>
    [Required]
    [ForeignKey("EsCalismaDurumuNavigation")]
    public string ES_CALISMA_DURUMU { get; set; }

    /// <summary>Bireysel Emeklilik SigortasÄ± (BES) kesintisinin aktarÄ±ldÄ±ÄŸÄ± sigorta firmasÄ± iÃ§in...</summary>
    [Required]
    [ForeignKey("BesFirmaNavigation")]
    public string BES_FIRMA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin maaÅŸÄ±ndan, Bireysel Emeklilik SigortasÄ± (BES...</summary>
    [Required]
    public string BES_ORANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin maaÅŸÄ±ndan, Bireysel Emeklilik SigortasÄ± (BES...</summary>
    [Required]
    public string BES_KESINTI_TUTARI { get; set; }

    /// <summary>Devlet tarafÄ±ndan saÄŸlÄ±k tesisinde gÃ¶revli personele Ã¶denen yabancÄ± dil tazminat...</summary>
    [Required]
    public string YABANCI_DIL_TAZMINATI_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin bildiÄŸi yabancÄ± dillerin bilgisidir. Ã–rneÄŸin...</summary>
    [Required]
    [ForeignKey("YabanciDilBilgisiNavigation")]
    public string YABANCI_DIL_BILGISI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin bildiÄŸi yabancÄ± dillerin derecesini gÃ¶steren...</summary>
    [Required]
    public string YABANCI_DIL_PUANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin bordrosunda bulunan sendika Ã¶deneÄŸi tutarÄ± b...</summary>
    [Required]
    public string SENDIKA_ODENEGI_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin bordrosunda hangi sendika iÃ§in kesinti yapÄ±l...</summary>
    [Required]
    [ForeignKey("SendikaBilgisiNavigation")]
    public string SENDIKA_BILGISI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin sendika listelerinde kiÅŸinin bilgilerinin bu...</summary>
    [Required]
    public string SENDIKA_SIRA_NUMARASI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin bordrosunda bulunan sendika kesinti oranÄ± bi...</summary>
    [Required]
    public string SENDIKA_KESINTI_ORANI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin sendika aidatÄ± tutar bilgisini ifade eder.</summary>
    [Required]
    public string SENDIKA_AIDATI_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele ait devlete kesilen emekli keseneÄŸi bilgisidi...</summary>
    [Required]
    public string DEVLET_EMEKLI_KESENEGI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele ait ÅŸahsa kesilen emekli keseneÄŸi bilgisidir.</summary>
    [Required]
    public string SAHIS_EMEKLI_KESENEGI { get; set; }

    /// <summary>Emekli keseneÄŸi primlerinin hesaplanmasÄ±nda kullanÄ±lan tutar bilgisidir.</summary>
    [Required]
    public string EMEKLI_KESENEGI_MATRAHI_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin maaÅŸÄ±na eklenen Ã¶zel saÄŸlÄ±k sigortasÄ± tutar ...</summary>
    [Required]
    public string OZEL_SIGORTA_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin vergi indirimi tutarÄ± bilgisidir.</summary>
    [Required]
    public string VERGI_INDIRIMI_TUTARI { get; set; }

    /// <summary>Damga vergisi tutar bilgisidir.</summary>
    [Required]
    public string DAMGA_VERGISI_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personel iÃ§in gelir vergisi tutar bilgisidir.</summary>
    [Required]
    public string GELIR_VERGISI_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personel iÃ§in gelir vergisi hesaplanmasÄ±nda kullanÄ±lan ...</summary>
    [Required]
    public string GELIR_VERGISI_MATRAHI_TUTARI { get; set; }

    /// <summary>KÃ¼mÃ¼latif gelir vergisi tutar bilgisidir.</summary>
    [Required]
    public string KUMULATIF_GELIR_VERGISI_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin maaÅŸÄ±ndan kesilen icra tutarÄ± bilgisidir.</summary>
    [Required]
    public string ICRA_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin maaÅŸÄ±ndan kesilen nafaka tutarÄ± bilgisidir.</summary>
    [Required]
    public string NAFAKA_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin terfisi nedeni ile maaÅŸÄ±na eklenen tutar bil...</summary>
    [Required]
    public string YUZDE_YUZ_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin doÄŸu tazminat tutarÄ± bilgisidir.</summary>
    [Required]
    public string DOGU_TAZMINATI_TUTARI { get; set; }

    /// <summary>Sosyal GÃ¼venlik Kurumu (SGK) ÅŸahÄ±s tutarÄ± bilgisidir.</summary>
    [Required]
    public string SGK_SAHIS_TUTARI { get; set; }

    /// <summary>Sosyal GÃ¼venlik Kurumu (SGK) iÅŸveren tutarÄ± bilgisidir.</summary>
    [Required]
    public string SGK_ISVEREN_TUTARI { get; set; }

    /// <summary>Sosyal GÃ¼venlik Kurumu (SGK) matrahÄ± tutarÄ± bilgisidir.</summary>
    [Required]
    public string SGK_MATRAHI_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin maaÅŸÄ±ndan kesilen kefalet tutarÄ± bilgisidir.</summary>
    [Required]
    public string KEFALET_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde sÃ¶zleÅŸmeli olarak gÃ¶rev yapan personelin sÃ¶zleÅŸme Ã¼cret tutarÄ± ...</summary>
    [Required]
    public string SOZLESME_UCRETI_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin lojmandan yararlanmasÄ± durumunda maaÅŸÄ±ndan y...</summary>
    [Required]
    public string LOJMAN_KESINTISI_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶rev yapan personelin asgari geÃ§im indirimi (AGÄ°) tutarÄ± bilgi...</summary>
    [Required]
    public string ASGARI_GECIM_INDIRIMI_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personel iÃ§in hesaplanan ay iÅŸsizlik ÅŸahÄ±s tutarÄ± bilgi...</summary>
    [Required]
    public string ISSIZLIK_SAHIS_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personel iÃ§in hesaplanan iÅŸsizlik iÅŸveren tutarÄ± bilgis...</summary>
    [Required]
    public string ISSIZLIK_ISVEREN_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personel iÃ§in hesaplanan ay iÃ§in toplam iÅŸsizlik primi ...</summary>
    [Required]
    public string ISSIZLIK_PRIMI_MATRAHI_TUTARI { get; set; }

    /// <summary>MalullÃ¼k devlet tutarÄ± bilgisidir.</summary>
    [Required]
    public string MALULLUK_DEVLET_TUTARI { get; set; }

    /// <summary>MalullÃ¼k ÅŸahÄ±s tutarÄ± bilgisidir.</summary>
    [Required]
    public string MALULLUK_SAHIS_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele yapÄ±lan giyecek yardÄ±mÄ± tutarÄ± bilgisidir.</summary>
    [Required]
    public string GIYECEK_YARDIMI_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele Ã¶denen fark tazminatÄ± tutar bilgisidir.</summary>
    [Required]
    public string FARK_TAZMINATI_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personel iÃ§in hizmet zammÄ± tutar bilgisidir.</summary>
    [Required]
    public string HIZMET_ZAMMI_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele yapÄ±lan vasÄ±ta yardÄ±mÄ± tutar bilgisidir.</summary>
    [Required]
    public string VASITA_YARDIMI_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele yapÄ±lan kira yardÄ±mÄ± tutarÄ± bilgisidir.</summary>
    [Required]
    public string KIRA_YARDIMI_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele yapÄ±lan yemek yardÄ±mÄ± tutarÄ± bilgisidir.</summary>
    [Required]
    public string YEMEK_YARDIMI_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele Ã¶denen fazla mesai tutarÄ± bilgisidir.</summary>
    [Required]
    public string FAZLA_MESAI_TUTARI { get; set; }

    /// <summary>NÃ¶bet hesaplamasÄ±nda kullanÄ±lan 1 saate karÅŸÄ±lÄ±k gelen tutar bilgisidir.</summary>
    [Required]
    public string NOBET_BIRIM_UCRET_TUTARI { get; set; }

    /// <summary>NÃ¶bet hesaplamasÄ±nda kullanÄ±lan 1 saate karÅŸÄ±lÄ±k gelen tutarÄ±n %20 fazlasÄ±dÄ±r.</summary>
    [Required]
    public string NOBET_BIRIM_UCRET_20_TUTARI { get; set; }

    /// <summary>NÃ¶bet hesaplamasÄ±nda kullanÄ±lan 1 saate karÅŸÄ±lÄ±k gelen tutarÄ±n %50 fazlasÄ±dÄ±r.</summary>
    [Required]
    public string NOBET_BIRIM_UCRET_50_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin nÃ¶bet hesaplamasÄ±nda kullanÄ±lan toplam nÃ¶bet...</summary>
    [Required]
    public string NOBET_SAATI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki personelin bir aylÄ±k sÃ¼re iÃ§erisinde dini bayramlarda tuttuÄŸu...</summary>
    [Required]
    public string NOBET_20_SAATI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki personelin bir aylÄ±k sÃ¼re iÃ§erisinde riskli birimlerde (yoÄŸun...</summary>
    [Required]
    public string NOBET_50_SAATI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele ait yevmiye tutarÄ± bilgisidir.</summary>
    [Required]
    public string YEVMIYE_TUTARI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personelin Ã§alÄ±ÅŸmÄ±ÅŸ olduÄŸu saat bilgisidir.</summary>
    [Required]
    public string CALISMA_SAATI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personel iÃ§in hesaplanan tahakkuk toplamÄ± bilgisidir.</summary>
    [Required]
    public string TAHAKKUK_TOPLAMI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisindeki personelin net tutar bilgisidir.</summary>
    [Required]
    public string NET_TUTAR { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli personele yapÄ±lan Ã¶demelerden (maaÅŸ, ek Ã¶deme, nÃ¶bet vb...</summary>
    [Required]
    public string KESINTI_TOPLAMI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual PERSONEL? PersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? BordroTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? EsCalismaDurumuNavigation { get; set; }
    public virtual FIRMA? BesFirmaNavigation { get; set; }
    public virtual REFERANS_KODLAR? YabanciDilBilgisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SendikaBilgisiNavigation { get; set; }
    #endregion

}
