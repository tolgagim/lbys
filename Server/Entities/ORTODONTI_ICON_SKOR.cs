using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_ORTODONTI_ICON_SKOR tablosu - 39 kolon
/// </summary>
[Table("ORTODONTI_ICON_SKOR")]
public class ORTODONTI_ICON_SKOR
{
    /// <summary>Ortodonti Icon Skor bilgisi için Sağlık Bilgi Yönetim Sistemi tarafından üretile...</summary>
    [Key]
    public string ORTODONTI_ICON_SKOR_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Diş tedavisi yapılan hastalar için Ortodonti Icon Skor (OIS) formunun değerlendi...</summary>
    public DateTime? OIS_DEGERLENDIRME_ZAMANI { get; set; }

    /// <summary>Hastanın dişlerindeki estetik bozukluğun Ortodonti Icon Skor (OIS) standartların...</summary>
    [Required]
    public string OIS_ESTETIK_BOZUKLUK_BILGISI { get; set; }

    /// <summary>Ortodonti Icon Skor (OIS) standartlarına göre belirlenmiş estetik puanının hesap...</summary>
    [Required]
    public string OIS_ESTETIK_PUAN_KATSAYISI { get; set; }

    /// <summary>Ortodonti Icon Skor (OIS) standartlarına göre belirlenmiş estetik bozukluk derec...</summary>
    [Required]
    public string OIS_ESTETIK_PUANI { get; set; }

    /// <summary>Üst çene dişlerindeki çapraşıklığın derecesinin bilgisidir.</summary>
    [Required]
    public string UST_DIS_ARKA_CAPRASIKLIK { get; set; }

    /// <summary>Üst çene dişlerindeki çapraşıklık puanının hesaplanması için gerekli olan katsay...</summary>
    [Required]
    public string UST_ARKA_CAPRASIKLIK_KATSAYISI { get; set; }

    /// <summary>Üst çapraşıklık derecesi ile katsayısının çarpımı ile hesaplanan puan bilgisidir...</summary>
    [Required]
    public string UST_ARKA_CAPRASIKLIK_PUANI { get; set; }

    /// <summary>Üst çene dişlerindeki boşluk derecesinin bilgisidir.</summary>
    [Required]
    public string UST_DIS_ARKA_BOSLUK { get; set; }

    /// <summary>Üst çene dişlerindeki boşluk puanının hesaplanması için gerekli olan katsayı bil...</summary>
    [Required]
    public string UST_ARKA_BOSLUK_KATSAYISI { get; set; }

    /// <summary>Üst çene dişlerindeki boşluk derecesi ve katsayısının çarpımı ile hesaplanan pua...</summary>
    [Required]
    public string UST_ARKA_BOSLUK_PUANI { get; set; }

    /// <summary>Kişinin dişlerinde çaprazlık olup olmadığı bilgisidir.</summary>
    [Required]
    public string DIS_CAPRAZLIK_DURUMU { get; set; }

    /// <summary>Ortodonti Icon Skorlamasında kullanılan çaprazlık puanının hesaplanması için ger...</summary>
    [Required]
    public string DIS_CAPRAZLIK_KATSAYISI { get; set; }

    /// <summary>Ortodonti Icon Skorlaması için dişlerde çaprazlık katsayısı kullanılarak hesapla...</summary>
    [Required]
    public string DIS_CAPRAZLIK_PUANI { get; set; }

    /// <summary>Kişinin dişlerinde, ön açık kapanış bozukluğu için milimetre cinsinden derece bi...</summary>
    [Required]
    public string ON_ACIK_KAPANIS { get; set; }

    /// <summary>Kişinin dişlerinde, ön açık kapanış puanının hesaplanması için katsayı bilgisidi...</summary>
    [Required]
    public string ON_ACIK_KAPANIS_KATSAYISI { get; set; }

    /// <summary>Kişinin dişlerinde, ön açık kapanış katsayısı ve ön açık kapanış derecesinin çar...</summary>
    [Required]
    public string ON_ACIK_KAPANIS_PUANI { get; set; }

    /// <summary>Kişinin dişlerinde, ön derin kapanış bozukluğu için milimetre cinsinden derece b...</summary>
    [Required]
    public string ON_DERIN_KAPANIS { get; set; }

    /// <summary>Kişinin dişlerinde, ön derin kapanış puanının hesaplanması için katsayı bilgisid...</summary>
    [Required]
    public string ON_DERIN_KAPANIS_KATSAYISI { get; set; }

    /// <summary>Kişinin dişlerinde, ön derin kapanış katsayısı ve ön derin kapanış derecesinin ç...</summary>
    [Required]
    public string ON_DERIN_KAPANIS_PUANI { get; set; }

    /// <summary>Sağ bukkal (yanak) bölgesinde bulunan dişlerin ön-arka yön ilişki derecesi bilgi...</summary>
    [Required]
    public string BUKKAL_BOLGE_SAG { get; set; }

    /// <summary>Sağ bukkal (yanak) bölge puanının hesaplanması için gerekli katsayı bilgisidir.</summary>
    [Required]
    public string BUKKAL_BOLGE_SAG_KATSAYISI { get; set; }

    /// <summary>Sağ bukkal (yanak) bölge puanı bilgisidir.</summary>
    [Required]
    public string BUKKAL_BOLGE_SAG_PUANI { get; set; }

    /// <summary>Sol bukkal (yanak) bölgesinde bulunan dişlerin ön-arka yön ilişki derecesi bilgi...</summary>
    [Required]
    public string BUKKAL_BOLGE_SOL { get; set; }

    /// <summary>Sol bukkal (yanak) bölge puanının hesaplanması için gerekli katsayı bilgisidir.</summary>
    [Required]
    public string BUKKAL_BOLGE_SOL_KATSAYISI { get; set; }

    /// <summary>Sol bukkal (yanak) bölge puanı bilgisidir.</summary>
    [Required]
    public string BUKKAL_BOLGE_SOL_PUANI { get; set; }

    /// <summary>Bukkal (yanak) bölge sağ ve sol puanlarının toplanarak elde edildiği toplam bukk...</summary>
    [Required]
    public string BUKKAL_TOPLAM_PUANI { get; set; }

    /// <summary>Ortodonti için tüm kriterlerin puanlarının toplandığı toplam puan bilgisidir.</summary>
    [Required]
    public string TOPLAM_ICON_SKOR_PUANI { get; set; }

    /// <summary>Diş tedavisi yapılan hastalar için Ortodonti Icon Skoru (OIS) form bilgilerini d...</summary>
    [Required]
    [ForeignKey("OisDegerlendiren1HekimNavigation")]
    public string OIS_DEGERLENDIREN_1_HEKIM_KODU { get; set; }

    /// <summary>Diş tedavisi yapılan hastalar için Ortodonti Icon Skoru (OIS) form bilgilerini d...</summary>
    [Required]
    [ForeignKey("OisDegerlendiren2HekimNavigation")]
    public string OIS_DEGERLENDIREN_2_HEKIM_KODU { get; set; }

    /// <summary>Diş tedavisi yapılan hastalar için Ortodonti Icon Skoru (OIS) form bilgilerini d...</summary>
    [Required]
    [ForeignKey("OisDegerlendiren3HekimNavigation")]
    public string OIS_DEGERLENDIREN_3_HEKIM_KODU { get; set; }

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
    public virtual PERSONEL? OisDegerlendiren1HekimNavigation { get; set; }
    public virtual PERSONEL? OisDegerlendiren2HekimNavigation { get; set; }
    public virtual PERSONEL? OisDegerlendiren3HekimNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}