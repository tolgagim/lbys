using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// ICMAL tablosu - 13 kolon
/// </summary>
[Table("ICMAL")]
public class ICMAL
{
    /// <summary>Sağlık tesisinde kesilen faturaları gruplandırmak için tanımlanan icmal için Sağ...</summary>
    [Key]
    public string ICMAL_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>İcmalin ait olduğu dönem bilgisidir.</summary>
    public string ICMAL_DONEMI { get; set; }

    /// <summary>Sağlık tesisinde kesilen faturaları gruplandırmak için tanımlanan icmal için Sağ...</summary>
    public string ICMAL_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinde kesilen faturaları gruplandırmak için tanımlanan icmal adı bilg...</summary>
    [Required]
    public string ICMAL_ADI { get; set; }

    /// <summary>Kişinin yararlandığı sağlık güvencesinin kurumuna ait bilgiler için Sağlık Bilgi...</summary>
    [Required]
    [ForeignKey("KurumNavigation")]
    public string KURUM_KODU { get; set; }

    /// <summary>İcmalin kullanıcı tarafından oluşturulduğu zaman bilgisidir.</summary>
    public DateTime? ICMAL_ZAMANI { get; set; }

    /// <summary>İcmal tutarı bilgisidir.</summary>
    public string ICMAL_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde üretilen verinin Sağlık Bilgi Yönetim Sistemine ilk defa kayıt ...</summary>
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
    public virtual KURUM? KurumNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}