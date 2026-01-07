using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_OBEZITE_IZLEM tablosu - 16 kolon
/// </summary>
[Table("OBEZITE_IZLEM")]
public class OBEZITE_IZLEM
{
    /// <summary>Sağlık tesisinde muayene olan hastaların obezite izlem bilgileri için Sağlık Bil...</summary>
    [Key]
    public string OBEZITE_IZLEM_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Hastalara diyetisyen tarafından verilen diyet programının varlığını ve hastanın ...</summary>
    [Required]
    [ForeignKey("DiyetTibbiBeslenmeTedavisiNavigation")]
    public string DIYET_TIBBI_BESLENME_TEDAVISI { get; set; }

    /// <summary>Hastaya izlem ve tedavi uygulanacak olan hastalık (diyabetis mellitus, kanser, H...</summary>
    public DateTime ILK_TANI_TARIHI { get; set; }

    /// <summary>Morbid obez tanısı olan (BKI 40 kg/m2 ve üstü) hastalarda lenfatik ödem olup olm...</summary>
    [Required]
    [ForeignKey("MorbitObezLenfatikOdemNavigation")]
    public string MORBIT_OBEZ_LENFATIK_ODEM { get; set; }

    /// <summary>Diyet (tıbbi beslenme) ve egzersizi içeren davranış tedavisine yanıt alınamayan ...</summary>
    [Required]
    [ForeignKey("ObeziteIlacTedavisiNavigation")]
    public string OBEZITE_ILAC_TEDAVISI { get; set; }

    /// <summary>Obezite ve diyabet ile ilişkili tutum ve davranışlara yönelik farkındalığın bili...</summary>
    [Required]
    [ForeignKey("PsikolojikTedaviNavigation")]
    public string PSIKOLOJIK_TEDAVI { get; set; }

    /// <summary>Hastaya konulan tanıya eşlik eden hastalıklardır.</summary>
    [Required]
    [ForeignKey("BirlikteGorulenEkHastalikNavigation")]
    public string BIRLIKTE_GORULEN_EK_HASTALIK { get; set; }

    /// <summary>Hastanın günlük fiziksel aktivite düzeyini ifade eder.</summary>
    [Required]
    [ForeignKey("EgzersizNavigation")]
    public string EGZERSIZ { get; set; }

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
    public virtual REFERANS_KODLAR? DiyetTibbiBeslenmeTedavisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? MorbitObezLenfatikOdemNavigation { get; set; }
    public virtual REFERANS_KODLAR? ObeziteIlacTedavisiNavigation { get; set; }
    public virtual REFERANS_KODLAR? PsikolojikTedaviNavigation { get; set; }
    public virtual REFERANS_KODLAR? BirlikteGorulenEkHastalikNavigation { get; set; }
    public virtual REFERANS_KODLAR? EgzersizNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}