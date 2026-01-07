using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// MADDE_BAGIMLILIGI tablosu - 31 kolon
/// </summary>
[Table("MADDE_BAGIMLILIGI")]
public class MADDE_BAGIMLILIGI : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [Key]
    public string MADDE_BAGIMLILIGI_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Madde baÄŸÄ±mlÄ±sÄ± iÃ§in bilgi alÄ±nan kiÅŸi bilgisidir.</summary>
    [ForeignKey("BilgiAlinanKaynakNavigation")]
    public string BILGI_ALINAN_KAYNAK { get; set; }

    /// <summary>KiÅŸinin danÄ±ÅŸma/tedavi hizmet alma durumu bilgisidir.</summary>
    [ForeignKey("DanismaTedaviHizmetDurumuNavigation")]
    public string DANISMA_TEDAVI_HIZMET_DURUMU { get; set; }

    /// <summary>KiÅŸinin danÄ±ÅŸma/tedavi hizmet alma zaman bilgisidir.</summary>
    public DateTime DANISMA_TEDAVI_HIZMET_ZAMANI { get; set; }

    /// <summary>KiÅŸinin ikame tedavisi gÃ¶rme durumu bilgisidir.</summary>
    [ForeignKey("IkameTedaviDurumuNavigation")]
    public string IKAME_TEDAVI_DURUMU { get; set; }

    /// <summary>KiÅŸinin en son ikame tedavisi gÃ¶rme zaman bilgisidir.</summary>
    public DateTime SON_IKAME_TEDAVI_ZAMANI { get; set; }

    /// <summary>KiÅŸinin cezaevinde kalmÄ±ÅŸ olma durumuna iliÅŸkin bilgiyi ifade eder.</summary>
    [ForeignKey("CezaeviOykusuNavigation")]
    public string CEZAEVI_OYKUSU { get; set; }

    /// <summary>KiÅŸinin sosyal yardÄ±m alma durumu bilgisidir.</summary>
    [ForeignKey("SosyalYardimAlmaDurumuNavigation")]
    public string SOSYAL_YARDIM_ALMA_DURUMU { get; set; }

    /// <summary>HastanÄ±n yaÅŸam yerinin kÄ±rsal ve kentsel durumunu ifade eder.</summary>
    [ForeignKey("YasadigiBolgeNavigation")]
    public string YASADIGI_BOLGE { get; set; }

    /// <summary>Alkol veya madde kullanan hastanÄ±n nerede ve kimlerle birlikte yaÅŸadÄ±ÄŸÄ±nÄ± ifade ...</summary>
    [ForeignKey("YasamBicimiNavigation")]
    public string YASAM_BICIMI { get; set; }

    /// <summary>KiÅŸinin Ã§ocuklarÄ±yla yaÅŸama durumu bilgisidir.</summary>
    [ForeignKey("CocuklariylaYasamaDurumuNavigation")]
    public string COCUKLARIYLA_YASAMA_DURUMU { get; set; }

    /// <summary>KiÅŸinin enjeksiyon yolu ile madde kullanÄ±mÄ±na iliÅŸkin bilgiyi ifade eder.</summary>
    [Required]
    [ForeignKey("EnjeksiyonIleMaddeKullanimiNavigation")]
    public string ENJEKSIYON_ILE_MADDE_KULLANIMI { get; set; }

    /// <summary>Madde baÄŸÄ±mlÄ±sÄ± olan kiÅŸinin enjeksiyon ile ilk defa madde kullandÄ±ÄŸÄ± yaÅŸ bilgis...</summary>
    [Required]
    public string ENJEKSIYON_ILK_KULLANIM_YASI { get; set; }

    /// <summary>Enjeksiyon yolu ile madde kullanan hastanÄ±n enjektÃ¶r paylaÅŸÄ±mÄ± durumunu ifade ed...</summary>
    [Required]
    [ForeignKey("EnjektorPaylasimDurumuNavigation")]
    public string ENJEKTOR_PAYLASIM_DURUMU { get; set; }

    /// <summary>Madde baÄŸÄ±mlÄ±sÄ± olan kiÅŸinin ilk defa enjektÃ¶r paylaÅŸtÄ±ÄŸÄ± yaÅŸ bilgisidir</summary>
    [Required]
    public string ILK_ENJEKTOR_PAYLASIM_YASI { get; set; }

    /// <summary>KiÅŸinin HIV test yapÄ±lma durumu bilgisidir.</summary>
    [Required]
    [ForeignKey("HivTestYapilmaDurumuNavigation")]
    public string HIV_TEST_YAPILMA_DURUMU { get; set; }

    /// <summary>KiÅŸinin HCV test yapÄ±lma durumu bilgisidir.</summary>
    [Required]
    [ForeignKey("HcvTestYapilmaDurumuNavigation")]
    public string HCV_TEST_YAPILMA_DURUMU { get; set; }

    /// <summary>KiÅŸinin HBV test yapÄ±lma durumu bilgisidir.</summary>
    [Required]
    [ForeignKey("HbvTestYapilmaDurumuNavigation")]
    public string HBV_TEST_YAPILMA_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k hizmeti alan kiÅŸiye tedavi/danÄ±ÅŸmanlÄ±k hizmetinin sonucunda hangi hizmeti...</summary>
    [ForeignKey("GorusmeSonucuNavigation")]
    public string GORUSME_SONUCU { get; set; }

    /// <summary>HastanÄ±n tedavi merkezine kim tarafÄ±ndan gÃ¶nderildiÄŸini ifade eder.</summary>
    [ForeignKey("GonderenBirimNavigation")]
    public string GONDEREN_BIRIM { get; set; }

    /// <summary>UyuÅŸturucu madde kullanan kiÅŸinin ikametinin sabit olup olmadÄ±ÄŸÄ± bilgisidir.</summary>
    [ForeignKey("YasamOrtamiNavigation")]
    public string YASAM_ORTAMI { get; set; }

    /// <summary>Madde kullanan hastanÄ±n madde kullanÄ±mÄ± ile birlikte sÄ±k gÃ¶rÃ¼len bulaÅŸÄ±cÄ± hastal...</summary>
    [Required]
    [ForeignKey("BulasiciHastalikDurumuNavigation")]
    public string BULASICI_HASTALIK_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k hizmeti alan kiÅŸiye ne tÃ¼r tedavi baÅŸlandÄ±ÄŸÄ± bilgisidir.</summary>
    [Required]
    [ForeignKey("BaslananTedaviTipiBilgisiNavigation")]
    public string BASLANAN_TEDAVI_TIPI_BILGISI { get; set; }

    /// <summary>Madde baÄŸÄ±mlÄ±sÄ± olan kiÅŸinin en Ã§ok kullandÄ±ÄŸÄ± esas madde bilgisidir.</summary>
    [Required]
    [ForeignKey("BirincilKullanilanEsasMaddeNavigation")]
    public string BIRINCIL_KULLANILAN_ESAS_MADDE { get; set; }

    /// <summary>KiÅŸinin baÄŸÄ±mlÄ±sÄ± olduÄŸu madde dÄ±ÅŸÄ±nda kullandÄ±ÄŸÄ± diÄŸer madde bilgisidir.</summary>
    [Required]
    [ForeignKey("KullanilanDigerMaddeNavigation")]
    public string KULLANILAN_DIGER_MADDE { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? BilgiAlinanKaynakNavigation { get; set; }
    public virtual REFERANS_KODLAR? DanismaTedaviHizmetDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? IkameTedaviDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? CezaeviOykusuNavigation { get; set; }
    public virtual REFERANS_KODLAR? SosyalYardimAlmaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? YasadigiBolgeNavigation { get; set; }
    public virtual REFERANS_KODLAR? YasamBicimiNavigation { get; set; }
    public virtual REFERANS_KODLAR? CocuklariylaYasamaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? EnjeksiyonIleMaddeKullanimiNavigation { get; set; }
    public virtual REFERANS_KODLAR? EnjektorPaylasimDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? HivTestYapilmaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? HcvTestYapilmaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? HbvTestYapilmaDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? GorusmeSonucuNavigation { get; set; }
    public virtual REFERANS_KODLAR? GonderenBirimNavigation { get; set; }
    public virtual REFERANS_KODLAR? YasamOrtamiNavigation { get; set; }
    public virtual REFERANS_KODLAR? BulasiciHastalikDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? BaslananTedaviTipiBilgisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? BirincilKullanilanEsasMaddeNavigation { get; set; }
    public virtual REFERANS_KODLAR? KullanilanDigerMaddeNavigation { get; set; }
    #endregion

}
