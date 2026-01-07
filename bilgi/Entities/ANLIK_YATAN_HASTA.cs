using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// ANLIK_YATAN_HASTA tablosu - 10 kolon
/// </summary>
[Table("ANLIK_YATAN_HASTA")]
public class ANLIK_YATAN_HASTA
{
    /// <summary>Sağlık tesisinde anlık yatan hastaların bilgisine erişim sağlamak için Sağlık Bi...</summary>
    [Key]
    public string ANLIK_YATAN_HASTA_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık tesisinde görevli hekim için Sağlık Bilgi Yönetim Sistemi tarafından üret...</summary>
    [ForeignKey("HekimNavigation")]
    public string HEKIM_KODU { get; set; }

    /// <summary>Hasta yatış işlemi yapılırken Sağlık Bilgi Yönetim Sistemi tarafından online pro...</summary>
    public string YATIS_PROTOKOL_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde bulunan bölümler için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("BirimNavigation")]
    public string BIRIM_KODU { get; set; }

    /// <summary>Sağlık Bilgi Yönetim Sistemi tarafından sağlık tesisindeki yataklar için üretile...</summary>
    [Required]
    [ForeignKey("YatakNavigation")]
    public string YATAK_KODU { get; set; }

    /// <summary>Sağlık tesisinde bulunan oda için Sağlık Bilgi Yönetim Sistemi tarafından üretil...</summary>
    [Required]
    [ForeignKey("OdaNavigation")]
    public string ODA_KODU { get; set; }

    /// <summary>Hastanın sağlık tesisinde yatağa yattığı zaman bilgisidir.</summary>
    public DateTime? YATIS_ZAMANI { get; set; }

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual PERSONEL? HekimNavigation { get; set; }
    public virtual BIRIM? BirimNavigation { get; set; }
    public virtual YATAK? YatakNavigation { get; set; }
    public virtual ODA? OdaNavigation { get; set; }
    #endregion

}