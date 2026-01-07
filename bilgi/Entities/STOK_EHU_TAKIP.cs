using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// STOK_EHU_TAKIP tablosu - 19 kolon
/// </summary>
[Table("STOK_EHU_TAKIP")]
public class STOK_EHU_TAKIP
{
    /// <summary>Enfeksiyon Hastalıkları Uzmanının (EHU) onayını gerektiren isteklerin takip bilg...</summary>
    [Key]
    public string STOK_EHU_TAKIP_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisindeki hekimin, hasta için istediği malzeme ve ilaçların sağlık tesi...</summary>
    [ForeignKey("StokIstekNavigation")]
    public string STOK_ISTEK_KODU { get; set; }

    /// <summary>Sağlık tesisinde hasta için depodan yapılan isteklerin detay bilgilerine erişim ...</summary>
    [ForeignKey("StokIstekHareketNavigation")]
    public string STOK_ISTEK_HAREKET_KODU { get; set; }

    /// <summary>Sağlık tesisinde bulunan ilaç, malzeme ve ürünlerin bilgilerine erişim sağlamak ...</summary>
    [ForeignKey("StokKartNavigation")]
    public string STOK_KART_KODU { get; set; }

    /// <summary>Enfeksiyon Hastalıkları Uzmanı (EHU) tarafından hekim isteminin (order) hastaya ...</summary>
    public DateTime? EHU_ONAY_BASLAMA_ZAMANI { get; set; }

    /// <summary>Enfeksiyon Hastalıkları Uzmanı (EHU) tarafından hekim isteminin (order) hastaya ...</summary>
    public DateTime? EHU_ONAY_BITIS_ZAMANI { get; set; }

    /// <summary>Enfeksiyon Hastalıkları Uzmanı (EHU) tarafından onaylanan ilacın hastaya uygulan...</summary>
    public string EHU_ILAC_MAKSIMUM_MIKTAR { get; set; }

    /// <summary>Sağlık tesisinde verilen hizmete, yapılan işleme, kullanılan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>EHU onay zamanı bilgisidir.</summary>
    public DateTime EHU_ONAYLAMA_ZAMANI { get; set; }

    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("OnaylayanHekimNavigation")]
    public string ONAYLAYAN_HEKIM_KODU { get; set; }

    /// <summary>Enfeksiyon Hastalıkları Uzmanı (EHU) tarafından ilaç isteğinin ret edilme nedeni...</summary>
    [Required]
    [ForeignKey("EhuRetNedeniNavigation")]
    public string EHU_RET_NEDENI { get; set; }

    /// <summary>Enfeksiyon Hastalıkları Uzmanı (EHU) tarafından ilaç isteğinin ret edilme zamanı...</summary>
    public DateTime EHU_RET_ZAMANI { get; set; }

    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [Required]
    [ForeignKey("EhuRetPersonelNavigation")]
    public string EHU_RET_PERSONEL_KODU { get; set; }

    /// <summary>Sağlık tesisinde hastaya istenen ilacın Enfeksiyon Hastalıkları Uzmanı (EHU) tar...</summary>
    [Required]
    public string EHU_RET_ACIKLAMA { get; set; }

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
    public virtual STOK_ISTEK? StokIstekNavigation { get; set; }
    public virtual STOK_ISTEK_HAREKET? StokIstekHareketNavigation { get; set; }
    public virtual STOK_KART? StokKartNavigation { get; set; }
    public virtual PERSONEL? OnaylayanHekimNavigation { get; set; }
    public virtual REFERANS_KODLAR? EhuRetNedeniNavigation { get; set; }
    public virtual PERSONEL? EhuRetPersonelNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}