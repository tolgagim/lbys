using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_MADDE_BAGIMLILIGI tablosu - 31 kolon
/// </summary>
[Table("MADDE_BAGIMLILIGI")]
public class MADDE_BAGIMLILIGI
{
    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Key]
    public string MADDE_BAGIMLILIGI_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Madde bağımlısı için bilgi alınan kişi bilgisidir.</summary>
    [ForeignKey("BilgiAlinanKaynakNavigation")]
    public string BILGI_ALINAN_KAYNAK { get; set; }

    /// <summary>Kişinin danışma/tedavi hizmet alma durumu bilgisidir.</summary>
    [ForeignKey("DanismaTedaviHizmetDurumuNavigation")]
    public string DANISMA_TEDAVI_HIZMET_DURUMU { get; set; }

    /// <summary>Kişinin danışma/tedavi hizmet alma zaman bilgisidir.</summary>
    public DateTime DANISMA_TEDAVI_HIZMET_ZAMANI { get; set; }

    /// <summary>Kişinin ikame tedavisi görme durumu bilgisidir.</summary>
    [ForeignKey("IkameTedaviDurumuNavigation")]
    public string IKAME_TEDAVI_DURUMU { get; set; }

    /// <summary>Kişinin en son ikame tedavisi görme zaman bilgisidir.</summary>
    public DateTime SON_IKAME_TEDAVI_ZAMANI { get; set; }

    /// <summary>Kişinin cezaevinde kalmış olma durumuna ilişkin bilgiyi ifade eder.</summary>
    [ForeignKey("CezaeviOykusuNavigation")]
    public string CEZAEVI_OYKUSU { get; set; }

    /// <summary>Kişinin sosyal yardım alma durumu bilgisidir.</summary>
    [ForeignKey("SosyalYardimAlmaDurumuNavigation")]
    public string SOSYAL_YARDIM_ALMA_DURUMU { get; set; }

    /// <summary>Hastanın yaşam yerinin kırsal ve kentsel durumunu ifade eder.</summary>
    [ForeignKey("YasadigiBolgeNavigation")]
    public string YASADIGI_BOLGE { get; set; }

    /// <summary>Alkol veya madde kullanan hastanın nerede ve kimlerle birlikte yaşadığını ifade ...</summary>
    [ForeignKey("YasamBicimiNavigation")]
    public string YASAM_BICIMI { get; set; }

    /// <summary>Kişinin çocuklarıyla yaşama durumu bilgisidir.</summary>
    [ForeignKey("CocuklariylaYasamaDurumuNavigation")]
    public string COCUKLARIYLA_YASAMA_DURUMU { get; set; }

    /// <summary>Kişinin enjeksiyon yolu ile madde kullanımına ilişkin bilgiyi ifade eder.</summary>
    [Required]
    [ForeignKey("EnjeksiyonIleMaddeKullanimiNavigation")]
    public string ENJEKSIYON_ILE_MADDE_KULLANIMI { get; set; }

    /// <summary>Madde bağımlısı olan kişinin enjeksiyon ile ilk defa madde kullandığı yaş bilgis...</summary>
    [Required]
    public string ENJEKSIYON_ILK_KULLANIM_YASI { get; set; }

    /// <summary>Enjeksiyon yolu ile madde kullanan hastanın enjektör paylaşımı durumunu ifade ed...</summary>
    [Required]
    [ForeignKey("EnjektorPaylasimDurumuNavigation")]
    public string ENJEKTOR_PAYLASIM_DURUMU { get; set; }

    /// <summary>Madde bağımlısı olan kişinin ilk defa enjektör paylaştığı yaş bilgisidir</summary>
    [Required]
    public string ILK_ENJEKTOR_PAYLASIM_YASI { get; set; }

    /// <summary>Kişinin HIV test yapılma durumu bilgisidir.</summary>
    [Required]
    [ForeignKey("HivTestYapilmaDurumuNavigation")]
    public string HIV_TEST_YAPILMA_DURUMU { get; set; }

    /// <summary>Kişinin HCV test yapılma durumu bilgisidir.</summary>
    [Required]
    [ForeignKey("HcvTestYapilmaDurumuNavigation")]
    public string HCV_TEST_YAPILMA_DURUMU { get; set; }

    /// <summary>Kişinin HBV test yapılma durumu bilgisidir.</summary>
    [Required]
    [ForeignKey("HbvTestYapilmaDurumuNavigation")]
    public string HBV_TEST_YAPILMA_DURUMU { get; set; }

    /// <summary>Sağlık hizmeti alan kişiye tedavi/danışmanlık hizmetinin sonucunda hangi hizmeti...</summary>
    [ForeignKey("GorusmeSonucuNavigation")]
    public string GORUSME_SONUCU { get; set; }

    /// <summary>Hastanın tedavi merkezine kim tarafından gönderildiğini ifade eder.</summary>
    [ForeignKey("GonderenBirimNavigation")]
    public string GONDEREN_BIRIM { get; set; }

    /// <summary>Uyuşturucu madde kullanan kişinin ikametinin sabit olup olmadığı bilgisidir.</summary>
    [ForeignKey("YasamOrtamiNavigation")]
    public string YASAM_ORTAMI { get; set; }

    /// <summary>Madde kullanan hastanın madde kullanımı ile birlikte sık görülen bulaşıcı hastal...</summary>
    [Required]
    [ForeignKey("BulasiciHastalikDurumuNavigation")]
    public string BULASICI_HASTALIK_DURUMU { get; set; }

    /// <summary>Sağlık hizmeti alan kişiye ne tür tedavi başlandığı bilgisidir.</summary>
    [Required]
    [ForeignKey("BaslananTedaviTipiBilgisiNavigation")]
    public string BASLANAN_TEDAVI_TIPI_BILGISI { get; set; }

    /// <summary>Madde bağımlısı olan kişinin en çok kullandığı esas madde bilgisidir.</summary>
    [Required]
    [ForeignKey("BirincilKullanilanEsasMaddeNavigation")]
    public string BIRINCIL_KULLANILAN_ESAS_MADDE { get; set; }

    /// <summary>Kişinin bağımlısı olduğu madde dışında kullandığı diğer madde bilgisidir.</summary>
    [Required]
    [ForeignKey("KullanilanDigerMaddeNavigation")]
    public string KULLANILAN_DIGER_MADDE { get; set; }

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
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}