using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_OPTIK_RECETE tablosu - 46 kolon
/// </summary>
[Table("OPTIK_RECETE")]
public class OPTIK_RECETE
{
    /// <summary>Optik reçete bilgisi için Sağlık Bilgi Yönetim Sistemi tarafından üretilen tekil...</summary>
    [Key]
    public string OPTIK_RECETE_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Reçete edilen gözlük için normal, teleskopik, lens vb. tip bilgisidir.</summary>
    [ForeignKey("GozlukReceteTipiNavigation")]
    public string GOZLUK_RECETE_TIPI { get; set; }

    /// <summary>Sağlık tesisinde görevli hekim için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }

    /// <summary>Reçetenin yazıldığı zaman bilgisidir.</summary>
    public DateTime? RECETE_ZAMANI { get; set; }

    /// <summary>Kişinin kullandığı ya da kişiye reçete edilen gözlüğün türünü ifade eder. Örneği...</summary>
    [ForeignKey("GozlukTuruNavigation")]
    public string GOZLUK_TURU { get; set; }

    /// <summary>Gözlüğün sağ camının hangi tipte olduğunu ifade eder. Örneğin düz, organik, bifo...</summary>
    [Required]
    [ForeignKey("SagCamTipiNavigation")]
    public string SAG_CAM_TIPI { get; set; }

    /// <summary>Gözlüğün sağ camının renk bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("SagCamRengiNavigation")]
    public string SAG_CAM_RENGI { get; set; }

    /// <summary>Gözlüğün sağ camının sferik değer bilgisini ifade eder.</summary>
    [Required]
    public string SAG_CAM_SFERIK { get; set; }

    /// <summary>Gözlüğün sağ camının silindirik değer bilgisini ifade eder.</summary>
    [Required]
    public string SAG_CAM_SILINDIRIK { get; set; }

    /// <summary>Gözlüğün sağ camındaki astigmat açısının (Aks) değer bilgisini ifade eder.</summary>
    [Required]
    public string SAG_CAM_AKS { get; set; }

    /// <summary>Gözlüğün sol camının hangi tipte olduğunu ifade eder. Örneğin düz, organik, bifo...</summary>
    [Required]
    [ForeignKey("SolCamTipiNavigation")]
    public string SOL_CAM_TIPI { get; set; }

    /// <summary>Gözlüğün sol camının renk bilgisini ifade eder.</summary>
    [Required]
    [ForeignKey("SolCamRengiNavigation")]
    public string SOL_CAM_RENGI { get; set; }

    /// <summary>Gözlüğün sol camının sferik değer bilgisini ifade eder.</summary>
    [Required]
    public string SOL_CAM_SFERIK { get; set; }

    /// <summary>Gözlüğün sol camının silindirik değer bilgisini ifade eder.</summary>
    [Required]
    public string SOL_CAM_SILINDIRIK { get; set; }

    /// <summary>Gözlüğün sol camındaki astigmat açısının (Aks) değer bilgisini ifade eder.</summary>
    [Required]
    public string SOL_CAM_AKS { get; set; }

    /// <summary>Sağ lensin cam sferik değer bilgisini ifade eder.</summary>
    [Required]
    public string SAG_LENS_CAM_SFERIK { get; set; }

    /// <summary>Sağ lensin cam silindirik değer bilgisini ifade eder.</summary>
    [Required]
    public string SAG_LENS_CAM_SILINDIRIK { get; set; }

    /// <summary>Sağ lensin cam çap değer bilgisini ifade eder.</summary>
    [Required]
    public string SAG_LENS_CAM_CAP { get; set; }

    /// <summary>Sağ lensin cam eğim değer bilgisini ifade eder.</summary>
    [Required]
    public string SAG_LENS_CAM_EGIM { get; set; }

    /// <summary>Sağ lensin cam astigmat açısının (Aks) değer bilgisini ifade eder.</summary>
    [Required]
    public string SAG_LENS_CAM_AKS { get; set; }

    /// <summary>Sol lens cam sferik değer bilgisidir.</summary>
    [Required]
    public string SOL_LENS_CAM_SFERIK { get; set; }

    /// <summary>Sol lensin cam silindirik değer bilgisini ifade eder.</summary>
    [Required]
    public string SOL_LENS_CAM_SILINDIRIK { get; set; }

    /// <summary>Sol lensin cam çap değer bilgisini ifade eder.</summary>
    [Required]
    public string SOL_LENS_CAM_CAP { get; set; }

    /// <summary>Sol lensin cam eğim değer bilgisini ifade eder.</summary>
    [Required]
    public string SOL_LENS_CAM_EGIM { get; set; }

    /// <summary>Sol lensin cam astigmat açısının (Aks) değer bilgisini ifade eder.</summary>
    [Required]
    public string SOL_LENS_CAM_AKS { get; set; }

    /// <summary>Gözlüğün sağ camının keratakonus cam sferik bilgisini ifade eder.</summary>
    [Required]
    public string SAG_KERATAKONUS_CAM_SFERIK { get; set; }

    /// <summary>Gözlüğün sağ camının keratakonus cam silindirik bilgisini ifade eder.</summary>
    [Required]
    public string SAG_KERATAKONUS_CAM_SILINDIR { get; set; }

    /// <summary>Gözlüğün sağ camının keratakonus cam çap bilgisini ifade eder.</summary>
    [Required]
    public string SAG_KERATAKONUS_CAM_CAP { get; set; }

    /// <summary>Gözlüğün sağ camının keratakonus cam eğim bilgisini ifade eder.</summary>
    [Required]
    public string SAG_KERATAKONUS_CAM_EGIM { get; set; }

    /// <summary>Gözlüğün sağ camının keratakonus astigmat açısının (Aks) değer bilgisini ifade e...</summary>
    [Required]
    public string SAG_KERATAKONUS_CAM_AKS { get; set; }

    /// <summary>Gözlüğün sol camının keratakonus cam sferik bilgisini ifade eder.</summary>
    [Required]
    public string SOL_KERATAKONUS_CAM_SFERIK { get; set; }

    /// <summary>Gözlüğün sol camının keratakonus cam silindirik bilgisini ifade eder.</summary>
    [Required]
    public string SOL_KERATAKONUS_CAM_SILINDIR { get; set; }

    /// <summary>Gözlüğün sol camının keratakonus cam çap bilgisini ifade eder.</summary>
    [Required]
    public string SOL_KERATAKONUS_CAM_CAP { get; set; }

    /// <summary>Gözlüğün sol camının keratakonus cam eğim bilgisini ifade eder.</summary>
    [Required]
    public string SOL_KERATAKONUS_CAM_EGIM { get; set; }

    /// <summary>Gözlüğün sol camının keratakonus astigmat açısının (Aks) değer bilgisini ifade e...</summary>
    [Required]
    public string SOL_KERATAKONUS_CAM_AKS { get; set; }

    /// <summary>Teleskopik gözlük tipi değer bilgisidir. Örneğin tek, çift, tek karekod vb.</summary>
    [Required]
    [ForeignKey("TeleskopikGozlukTipiNavigation")]
    public string TELESKOPIK_GOZLUK_TIPI { get; set; }

    /// <summary>Teleskopik gözlük türü değer bilgisidir. Örneğin uzak-daimi, yakın vb.</summary>
    [Required]
    [ForeignKey("TeleskopikGozlukTuruNavigation")]
    public string TELESKOPIK_GOZLUK_TURU { get; set; }

    /// <summary>Sağlık tesisinde düzenlenen gözlük reçetesinin sağ camında teleskobik özelliğine...</summary>
    [Required]
    public string TELESKOPIK_SAG_CAM { get; set; }

    /// <summary>Sağlık tesisinde düzenlenen gözlük reçetesinin sol camında teleskobik özelliğine...</summary>
    [Required]
    public string TELESKOPIK_SOL_CAM { get; set; }

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
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual REFERANS_KODLAR? GozlukReceteTipiNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual REFERANS_KODLAR? GozlukTuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? SagCamTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SagCamRengiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SolCamTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? SolCamRengiNavigation { get; set; }
    public virtual REFERANS_KODLAR? TeleskopikGozlukTipiNavigation { get; set; }
    public virtual REFERANS_KODLAR? TeleskopikGozlukTuruNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}