using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// PERSONEL_IZIN_DURUMU tablosu - 6 kolon
/// </summary>
[Table("PERSONEL_IZIN_DURUMU")]
public class PERSONEL_IZIN_DURUMU
{
    /// <summary>Sağlık tesisinde görevli personelin izin durumu bilgileri için Sağlık Bilgi Yöne...</summary>
    [Key]
    public string PERSONEL_IZIN_DURUMU_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin kalan izin gün sayısı bilgisidir.</summary>
    public string KALAN_IZIN { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin çalıştığı yıl için hak ettiği izin gün sayıs...</summary>
    public string YILLIK_IZIN_HAKKI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin kullandığı iznin hangi yıla ait olduğu bilgi...</summary>
    public string PERSONEL_IZIN_YILI { get; set; }

    #region Navigation Properties
    public virtual PERSONEL? PersonelNavigation { get; set; }
    #endregion

}