using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_HASTA_SEANS tablosu - 35 kolon
/// </summary>
[Table("HASTA_SEANS")]
public class HASTA_SEANS
{
    /// <summary>Sağlık tesisinde tedavi kapsamında hastalara verilen seans bilgileri için Sağlık...</summary>
    [Key]
    public string HASTA_SEANS_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Hastanın sağlık tesisinde tedavisinin gereği olarak aldığı seansın hangi tedavi ...</summary>
    [ForeignKey("SeansIslemTuruNavigation")]
    public string SEANS_ISLEM_TURU { get; set; }

    /// <summary>Sağlık tesisinde bulunan cihaz için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [Required]
    [ForeignKey("CihazNavigation")]
    public string CIHAZ_KODU { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanan tedavi kapsamında yapılması planlanan seans t...</summary>
    public DateTime? PLANLANAN_SEANS_TARIHI { get; set; }

    /// <summary>Hastanın sağlık tesisinde tedavisinin gereği olarak aldığı seansa başladığı zama...</summary>
    public DateTime SEANS_BASLAMA_ZAMANI { get; set; }

    /// <summary>Hastanın sağlık tesisinde tedavisinin gereği olarak aldığı seansın bittiği zaman...</summary>
    public DateTime SEANS_BITIS_ZAMANI { get; set; }

    /// <summary>Kişinin kullandığı antihipertansif ilaç kullanım durumunu ifade eder.</summary>
    [Required]
    [ForeignKey("AntihipertansifIlacDurumuNavigation")]
    public string ANTIHIPERTANSIF_ILAC_DURUMU { get; set; }

    /// <summary>Kişinin Önceki Renal Replasman yöntemi bilgisidir.</summary>
    [ForeignKey("OncekiRrtYontemiNavigation")]
    public string ONCEKI_RRT_YONTEMI { get; set; }

    /// <summary>Kişinin hemodiyalize geçme nedenini ifade eder.</summary>
    [Required]
    [ForeignKey("HemodiyalizeGecmeNedenleriNavigation")]
    public string HEMODIYALIZE_GECME_NEDENLERI { get; set; }

    /// <summary>Hastanın tedavisi için ne tür damar erişim yolu kullanıldığını ifade eder.</summary>
    [Required]
    [ForeignKey("DamarErisimYoluNavigation")]
    public string DAMAR_ERISIM_YOLU { get; set; }

    /// <summary>Hastanın haftada kaç defa diyaliz tedavisi aldığını ifade eder.</summary>
    [Required]
    [ForeignKey("DiyalizeGirmeSikligiNavigation")]
    public string DIYALIZE_GIRME_SIKLIGI { get; set; }

    /// <summary>Diyaliz hastasının beden kitle endeksine göre kullanılacak olan metrekare cinsin...</summary>
    [Required]
    [ForeignKey("DiyalizorAlaniNavigation")]
    public string DIYALIZOR_ALANI { get; set; }

    /// <summary>Hastanın diyalizi için kullanılan diyalizör tipi bilgisidir.</summary>
    [Required]
    [ForeignKey("DiyalizorTipiNavigation")]
    public string DIYALIZOR_TIPI { get; set; }

    /// <summary>Hemodiyaliz tedavisi için kullanılan cihazda ayarlanan kan akım hızıdır.</summary>
    [Required]
    [ForeignKey("KanAkimHiziNavigation")]
    public string KAN_AKIM_HIZI { get; set; }

    /// <summary>Kişinin ağırlığının ölçüm zamanı bilgisidir.</summary>
    [Required]
    [ForeignKey("AgirlikOlcumZamaniNavigation")]
    public string AGIRLIK_OLCUM_ZAMANI { get; set; }

    /// <summary>Hastaya uygulanan tedavi yöntemini ifade eder.</summary>
    [Required]
    [ForeignKey("KullanilanDiyalizTedavisiNavigation")]
    public string KULLANILAN_DIYALIZ_TEDAVISI { get; set; }

    /// <summary>Hastanın peritoneal geçirgenlik durumunu ifade eder. Örneğin düşük, orta, yüksek...</summary>
    [Required]
    [ForeignKey("PeritonealGecirgenlikDurumuNavigation")]
    public string PERITONEAL_GECIRGENLIK_DURUMU { get; set; }

    /// <summary>Periton diyalizi gören hastanın kaçıncı kateteri olduğunu ifade eder.</summary>
    [Required]
    [ForeignKey("PeritonKacinciKateterNavigation")]
    public string PERITON_KACINCI_KATETER { get; set; }

    /// <summary>Periton diyalizinde kullanılan kateter tipini ifade eder. Örneğin curlet tenckho...</summary>
    [Required]
    [ForeignKey("PeritonKateterTipiNavigation")]
    public string PERITON_KATETER_TIPI { get; set; }

    /// <summary>Periton diyalizi tedavisi gören hastaya uygulanan kateter yerleştirme yöntemini ...</summary>
    [Required]
    [ForeignKey("PeritonKateterYontemiNavigation")]
    public string PERITON_KATETER_YONTEMI { get; set; }

    /// <summary>Periton diyalizi tedavisi uygulanan hastanın kateter için açılan tünel yönünü if...</summary>
    [Required]
    [ForeignKey("PeritonTunelYonuNavigation")]
    public string PERITON_TUNEL_YONU { get; set; }

    /// <summary>Hastanın sekonder hiperparatiroidizm tedavisine ihtiyacı olup olmadığını, ihtiya...</summary>
    [Required]
    [ForeignKey("SinekalsetNavigation")]
    public string SINEKALSET { get; set; }

    /// <summary>Sağlık tesisinde hastaya uygulanan tedavinin seyir bilgisidir. Örneğin diyaliz t...</summary>
    [Required]
    [ForeignKey("TedavininSeyriNavigation")]
    public string TEDAVININ_SEYRI { get; set; }

    /// <summary>Hastanın aktif Vitamin D kullanım ihtiyacını ve uygulama yolunu ifade eder.</summary>
    [Required]
    [ForeignKey("AktifVitaminDKullanimiNavigation")]
    public string AKTIF_VITAMIN_D_KULLANIMI { get; set; }

    /// <summary>Hastanın anemi tedavisine ihtiyacı olup olmadığını, ihtiyacı varsa hangi yönteml...</summary>
    [Required]
    [ForeignKey("AnemiTedavisiYontemiNavigation")]
    public string ANEMI_TEDAVISI_YONTEMI { get; set; }

    /// <summary>Hastanın fosfor bağlayıcı ajan ile tedavi ihtiyacı olup olmadığını, ihtiyacı var...</summary>
    [Required]
    [ForeignKey("FosforBaglayiciAjanNavigation")]
    public string FOSFOR_BAGLAYICI_AJAN { get; set; }

    /// <summary>Periton diyalizi tedavisi verilen hastada görülen komplikasyonları ifade eder. Ö...</summary>
    [Required]
    [ForeignKey("PeritonKomplikasyonNavigation")]
    public string PERITON_KOMPLIKASYON { get; set; }

    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

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
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? SeansIslemTuruNavigation { get; set; }
    public virtual CIHAZ? CihazNavigation { get; set; }
    public virtual REFERANS_KODLAR? AntihipertansifIlacDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? OncekiRrtYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? HemodiyalizeGecmeNedenleriNavigation { get; set; }
    public virtual REFERANS_KODLAR? DamarErisimYoluNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyalizeGirmeSikligiNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyalizorAlaniNavigation { get; set; }
    public virtual REFERANS_KODLAR? DiyalizorTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? KanAkimHiziNavigation { get; set; }
    public virtual REFERANS_KODLAR? AgirlikOlcumZamaniNavigation { get; set; }
    public virtual REFERANS_KODLAR? KullanilanDiyalizTedavisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? PeritonealGecirgenlikDurumuNavigation { get; set; }
    public virtual REFERANS_KODLAR? PeritonKacinciKateterNavigation { get; set; }
    public virtual REFERANS_KODLAR? PeritonKateterTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? PeritonKateterYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? PeritonTunelYonuNavigation { get; set; }
    public virtual REFERANS_KODLAR? SinekalsetNavigation { get; set; }
    public virtual REFERANS_KODLAR? TedavininSeyriNavigation { get; set; }
    public virtual REFERANS_KODLAR? AktifVitaminDKullanimiNavigation { get; set; }
    public virtual REFERANS_KODLAR? AnemiTedavisiYontemiNavigation { get; set; }
    public virtual REFERANS_KODLAR? FosforBaglayiciAjanNavigation { get; set; }
    public virtual REFERANS_KODLAR? PeritonKomplikasyonNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}