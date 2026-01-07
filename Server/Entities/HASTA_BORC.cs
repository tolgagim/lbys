using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_HASTA_BORC tablosu - 7 kolon
/// </summary>
[Table("HASTA_BORC")]
public class HASTA_BORC
{
    /// <summary>Hastaların borç bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından üretilen ...</summary>
    [Key]
    public string HASTA_BORC_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Hastanın ödemiş olduğu borç bilgisidir.</summary>
    public string ODENEN_BORC { get; set; }

    /// <summary>Sağlık tesisinde sağlık hizmetini alan kişinin kendisine uygulanan tanı ve tedav...</summary>
    public string TOPLAM_BORC { get; set; }

    /// <summary>Sağlık tesisinde tedavisi yapılan hastanın kalan borç bilgisidir.</summary>
    public string KALAN_BORC { get; set; }

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    #endregion

}