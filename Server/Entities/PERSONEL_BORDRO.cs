using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_PERSONEL_BORDRO tablosu - 85 kolon
/// </summary>
[Table("PERSONEL_BORDRO")]
public class PERSONEL_BORDRO
{
    /// <summary>Sağlık tesisinde görevli personelin bordro bilgileri için Sağlık Bilgi Yönetim S...</summary>
    [Key]
    public string PERSONEL_BORDRO_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Yıl bilgisini ifade eder.</summary>
    public string YIL { get; set; }

    /// <summary>Yılın on iki bölümünden her birini ifade eder.</summary>
    public string AY { get; set; }

    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }

    /// <summary>Sağlık tesisinde görev yapan personel için hesaplanan ödemenin tür bilgisidir.</summary>
    [ForeignKey("BordroTuruNavigation")]
    public string BORDRO_TURU { get; set; }

    /// <summary>Sağlık tesisinde görev yapan personel için yapılan her türlü ödeme bilgisine ait...</summary>
    [Required]
    public string BORDRO_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele ait maaş derece bilgisidir.</summary>
    [Required]
    public string MAAS_DERECESI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele ait maaş kademe bilgisidir.</summary>
    [Required]
    public string MAAS_KADEMESI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele ait maaş gösterge bilgisidir.</summary>
    [Required]
    public string MAAS_GOSTERGESI { get; set; }

    /// <summary>Sağlık tesisinde görevli Personele ait maaş ek gösterge bilgisidir.</summary>
    [Required]
    public string MAAS_EK_GOSTERGESI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele ait emekli derecesi bilgisidir.</summary>
    [Required]
    public string EMEKLI_DERECESI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele ait emekli kademe bilgisidir.</summary>
    [Required]
    public string EMEKLI_KADEMESI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin ait emekli gösterge bilgisidir.</summary>
    [Required]
    public string EMEKLI_GOSTERGESI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele ait emekli ek göstergesi bilgisidir.</summary>
    [Required]
    public string EMEKLI_EK_GOSTERGESI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele ait taban aylık tutar bilgisidir.</summary>
    [Required]
    public string TABAN_AYLIK_TUTARI { get; set; }

    /// <summary>Sağlık tesisisinde görevli personele yapılan aylık ödeme bilgisidir.</summary>
    [Required]
    public string AYLIK_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele ait kıdem tutarı bilgisidir.</summary>
    [Required]
    public string KIDEM_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin ek gösterge tutarı bilgisidir.</summary>
    [Required]
    public string EK_GOSTERGE_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele ait yan ödeme tutarı bilgisidir.</summary>
    [Required]
    public string YAN_ODEME_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele ait özel hizmet tutarı bilgisidir.</summary>
    [Required]
    public string OZEL_HIZMET_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele yapılan aile yardımı tutarı bilgisidir.</summary>
    [Required]
    public string AILE_YARDIMI_TUTARI { get; set; }

    /// <summary>Sağlık tesisindeki görevli personele yapılan çocuk yardımı tutarı bilgisidir.</summary>
    [Required]
    public string COCUK_YARDIMI_TUTARI { get; set; }

    /// <summary>Sağlık tesisindeki görevli personelin 6 yaş altındaki (yaş < 6) çocuk sayısı bil...</summary>
    [Required]
    public string COCUK_SAYISI_6_YAS_ALTI { get; set; }

    /// <summary>Sağlık tesisindeki görevli personelin 6 yaş üstündeki (yaş > 6) çocuk sayısı bil...</summary>
    [Required]
    public string COCUK_SAYISI_6_YAS_USTU { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin Asgari Geçim İndirimine (AGİ) esas çocuk say...</summary>
    [Required]
    public string AGI_ESAS_COCUK_SAYISI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin eşinin herhangi bir işte çalışma durumunu if...</summary>
    [Required]
    [ForeignKey("EsCalismaDurumuNavigation")]
    public string ES_CALISMA_DURUMU { get; set; }

    /// <summary>Bireysel Emeklilik Sigortası (BES) kesintisinin aktarıldığı sigorta firması için...</summary>
    [Required]
    [ForeignKey("BesFirmaNavigation")]
    public string BES_FIRMA_KODU { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin maaşından, Bireysel Emeklilik Sigortası (BES...</summary>
    [Required]
    public string BES_ORANI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin maaşından, Bireysel Emeklilik Sigortası (BES...</summary>
    [Required]
    public string BES_KESINTI_TUTARI { get; set; }

    /// <summary>Devlet tarafından sağlık tesisinde görevli personele ödenen yabancı dil tazminat...</summary>
    [Required]
    public string YABANCI_DIL_TAZMINATI_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin bildiği yabancı dillerin bilgisidir. Örneğin...</summary>
    [Required]
    [ForeignKey("YabanciDilBilgisiNavigation")]
    public string YABANCI_DIL_BILGISI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin bildiği yabancı dillerin derecesini gösteren...</summary>
    [Required]
    public string YABANCI_DIL_PUANI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin bordrosunda bulunan sendika ödeneği tutarı b...</summary>
    [Required]
    public string SENDIKA_ODENEGI_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin bordrosunda hangi sendika için kesinti yapıl...</summary>
    [Required]
    [ForeignKey("SendikaBilgisiNavigation")]
    public string SENDIKA_BILGISI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin sendika listelerinde kişinin bilgilerinin bu...</summary>
    [Required]
    public string SENDIKA_SIRA_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin bordrosunda bulunan sendika kesinti oranı bi...</summary>
    [Required]
    public string SENDIKA_KESINTI_ORANI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin sendika aidatı tutar bilgisini ifade eder.</summary>
    [Required]
    public string SENDIKA_AIDATI_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele ait devlete kesilen emekli keseneği bilgisidi...</summary>
    [Required]
    public string DEVLET_EMEKLI_KESENEGI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele ait şahsa kesilen emekli keseneği bilgisidir.</summary>
    [Required]
    public string SAHIS_EMEKLI_KESENEGI { get; set; }

    /// <summary>Emekli keseneği primlerinin hesaplanmasında kullanılan tutar bilgisidir.</summary>
    [Required]
    public string EMEKLI_KESENEGI_MATRAHI_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin maaşına eklenen özel sağlık sigortası tutar ...</summary>
    [Required]
    public string OZEL_SIGORTA_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin vergi indirimi tutarı bilgisidir.</summary>
    [Required]
    public string VERGI_INDIRIMI_TUTARI { get; set; }

    /// <summary>Damga vergisi tutar bilgisidir.</summary>
    [Required]
    public string DAMGA_VERGISI_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personel için gelir vergisi tutar bilgisidir.</summary>
    [Required]
    public string GELIR_VERGISI_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personel için gelir vergisi hesaplanmasında kullanılan ...</summary>
    [Required]
    public string GELIR_VERGISI_MATRAHI_TUTARI { get; set; }

    /// <summary>Kümülatif gelir vergisi tutar bilgisidir.</summary>
    [Required]
    public string KUMULATIF_GELIR_VERGISI_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin maaşından kesilen icra tutarı bilgisidir.</summary>
    [Required]
    public string ICRA_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin maaşından kesilen nafaka tutarı bilgisidir.</summary>
    [Required]
    public string NAFAKA_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin terfisi nedeni ile maaşına eklenen tutar bil...</summary>
    [Required]
    public string YUZDE_YUZ_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin doğu tazminat tutarı bilgisidir.</summary>
    [Required]
    public string DOGU_TAZMINATI_TUTARI { get; set; }

    /// <summary>Sosyal Güvenlik Kurumu (SGK) şahıs tutarı bilgisidir.</summary>
    [Required]
    public string SGK_SAHIS_TUTARI { get; set; }

    /// <summary>Sosyal Güvenlik Kurumu (SGK) işveren tutarı bilgisidir.</summary>
    [Required]
    public string SGK_ISVEREN_TUTARI { get; set; }

    /// <summary>Sosyal Güvenlik Kurumu (SGK) matrahı tutarı bilgisidir.</summary>
    [Required]
    public string SGK_MATRAHI_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin maaşından kesilen kefalet tutarı bilgisidir.</summary>
    [Required]
    public string KEFALET_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde sözleşmeli olarak görev yapan personelin sözleşme ücret tutarı ...</summary>
    [Required]
    public string SOZLESME_UCRETI_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin lojmandan yararlanması durumunda maaşından y...</summary>
    [Required]
    public string LOJMAN_KESINTISI_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görev yapan personelin asgari geçim indirimi (AGİ) tutarı bilgi...</summary>
    [Required]
    public string ASGARI_GECIM_INDIRIMI_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personel için hesaplanan ay işsizlik şahıs tutarı bilgi...</summary>
    [Required]
    public string ISSIZLIK_SAHIS_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personel için hesaplanan işsizlik işveren tutarı bilgis...</summary>
    [Required]
    public string ISSIZLIK_ISVEREN_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personel için hesaplanan ay için toplam işsizlik primi ...</summary>
    [Required]
    public string ISSIZLIK_PRIMI_MATRAHI_TUTARI { get; set; }

    /// <summary>Malullük devlet tutarı bilgisidir.</summary>
    [Required]
    public string MALULLUK_DEVLET_TUTARI { get; set; }

    /// <summary>Malullük şahıs tutarı bilgisidir.</summary>
    [Required]
    public string MALULLUK_SAHIS_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele yapılan giyecek yardımı tutarı bilgisidir.</summary>
    [Required]
    public string GIYECEK_YARDIMI_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele ödenen fark tazminatı tutar bilgisidir.</summary>
    [Required]
    public string FARK_TAZMINATI_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personel için hizmet zammı tutar bilgisidir.</summary>
    [Required]
    public string HIZMET_ZAMMI_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele yapılan vasıta yardımı tutar bilgisidir.</summary>
    [Required]
    public string VASITA_YARDIMI_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele yapılan kira yardımı tutarı bilgisidir.</summary>
    [Required]
    public string KIRA_YARDIMI_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele yapılan yemek yardımı tutarı bilgisidir.</summary>
    [Required]
    public string YEMEK_YARDIMI_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele ödenen fazla mesai tutarı bilgisidir.</summary>
    [Required]
    public string FAZLA_MESAI_TUTARI { get; set; }

    /// <summary>Nöbet hesaplamasında kullanılan 1 saate karşılık gelen tutar bilgisidir.</summary>
    [Required]
    public string NOBET_BIRIM_UCRET_TUTARI { get; set; }

    /// <summary>Nöbet hesaplamasında kullanılan 1 saate karşılık gelen tutarın %20 fazlasıdır.</summary>
    [Required]
    public string NOBET_BIRIM_UCRET_20_TUTARI { get; set; }

    /// <summary>Nöbet hesaplamasında kullanılan 1 saate karşılık gelen tutarın %50 fazlasıdır.</summary>
    [Required]
    public string NOBET_BIRIM_UCRET_50_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin nöbet hesaplamasında kullanılan toplam nöbet...</summary>
    [Required]
    public string NOBET_SAATI { get; set; }

    /// <summary>Sağlık tesisindeki personelin bir aylık süre içerisinde dini bayramlarda tuttuğu...</summary>
    [Required]
    public string NOBET_20_SAATI { get; set; }

    /// <summary>Sağlık tesisindeki personelin bir aylık süre içerisinde riskli birimlerde (yoğun...</summary>
    [Required]
    public string NOBET_50_SAATI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele ait yevmiye tutarı bilgisidir.</summary>
    [Required]
    public string YEVMIYE_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin çalışmış olduğu saat bilgisidir.</summary>
    [Required]
    public string CALISMA_SAATI { get; set; }

    /// <summary>Sağlık tesisinde görevli personel için hesaplanan tahakkuk toplamı bilgisidir.</summary>
    [Required]
    public string TAHAKKUK_TOPLAMI { get; set; }

    /// <summary>Sağlık tesisindeki personelin net tutar bilgisidir.</summary>
    [Required]
    public string NET_TUTAR { get; set; }

    /// <summary>Sağlık tesisinde görevli personele yapılan ödemelerden (maaş, ek ödeme, nöbet vb...</summary>
    [Required]
    public string KESINTI_TOPLAMI { get; set; }

    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemi'ne ilk defa kayıt...</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıt edilen bilgilere ilişkin kayıt işlem...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi üzerinde kayıtlı bilgilere ilişkin güncelleme işlem...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }

    #region Navigation Properties
    public virtual PERSONEL? PersonelNavigation { get; set; }
    public virtual REFERANS_KODLAR? BordroTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? EsCalismaDurumuNavigation { get; set; }
    public virtual FIRMA? BesFirmaNavigation { get; set; }
    public virtual REFERANS_KODLAR? YabanciDilBilgisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SendikaBilgisiNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}