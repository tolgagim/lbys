using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_FATURA tablosu - 20 kolon
/// </summary>
[Table("FATURA")]
public class FATURA
{
    /// <summary>SBYS tarafından üretilen tekil kod bilgisidir.</summary>
    [Key]
    public string FATURA_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisine başvuran hastalar için Sağlık Bilgi Yönetim Sistemi tarafından ü...</summary>
    [Required]
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>Sağlık tesisinde hasta bilgileri için Sağlık Bilgi Yönetim Sistemi tarafından ür...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>Sağlık tesisinde kesilen faturanın ait olduğu dönem bilgisidir.</summary>
    public string FATURA_DONEMI { get; set; }

    /// <summary>Sağlık tesisinde kesilen faturaları gruplandırmak için tanımlanan icmal için Sağ...</summary>
    [Required]
    [ForeignKey("IcmalNavigation")]
    public string ICMAL_KODU { get; set; }

    /// <summary>Sağlık tesisi tarafından kesilen fatura için Sağlık Bilgi Yönetim Sistemi tarafı...</summary>
    [ForeignKey("FaturaTuruNavigation")]
    public string FATURA_TURU { get; set; }

    /// <summary>Sağlık tesisinde kesilen fatura için ad bilgisidir.</summary>
    [Required]
    public string FATURA_ADI { get; set; }

    /// <summary>Sağlık tesisi tarafından kesilen faturanın zaman bilgisidir.</summary>
    public DateTime? FATURA_ZAMANI { get; set; }

    /// <summary>Sağlık tesisi tarafından kesilen faturanın toplam tutar bilgisidir.</summary>
    public string FATURA_TUTARI { get; set; }

    /// <summary>Sağlık tesisi tarafından kesilen faturanın numara bilgisidir.</summary>
    public string FATURA_NUMARASI { get; set; }

    /// <summary>Sağlık tesisinden tedavi gören hasta için MEDULA sistemine gönderilen faturalar ...</summary>
    [Required]
    public string MEDULA_TESLIM_NUMARASI { get; set; }

    /// <summary>Sağlık tesisi tarafından fatura kesilen kurum için Sağlık Bilgi Yönetim Sistemi ...</summary>
    [ForeignKey("FaturaKesilenKurumNavigation")]
    public string FATURA_KESILEN_KURUM_KODU { get; set; }

    /// <summary>Tek Düzen Muhasebe Sisteminde tanımlanan, yerine göre “Alıcılar Hesabı” veya "Gi...</summary>
    [Required]
    public string BUTCE_KODU { get; set; }

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
    public virtual ICMAL? IcmalNavigation { get; set; }
    public virtual REFERANS_KODLAR? FaturaTuruNavigation { get; set; }
    public virtual KURUM? FaturaKesilenKurumNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}