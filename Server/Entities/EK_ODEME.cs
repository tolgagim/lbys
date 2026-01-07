using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_EK_ODEME tablosu - 25 kolon
/// </summary>
[Table("EK_ODEME")]
public class EK_ODEME
{
    /// <summary>SBYS tarafından üretilen tekil kod bilgisidir.</summary>
    [Key]
    public string EK_ODEME_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı veri tabanındaki tablo adı bilgisidir.</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele ödenecek ek ödeme için Sağlık Bilgi Yönetim S...</summary>
    [ForeignKey("EkOdemeDonemNavigation")]
    public string EK_ODEME_DONEM_KODU { get; set; }

    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }

    /// <summary>Sağlık tesisinde görevli personel için ilgili mevzuat kapsamında maaş hesaplama ...</summary>
    public string HESAPLAMA_YONTEMI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele ait maaş derece bilgisidir.</summary>
    public string MAAS_DERECESI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele ait maaş kademe bilgisidir.</summary>
    public string MAAS_KADEMESI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele ait maaş gösterge bilgisidir.</summary>
    public string MAAS_GOSTERGESI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele yapılan aylık ödeme bilgisidir.</summary>
    public string AYLIK_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele ait özel hizmet tutarı bilgisidir.</summary>
    [Required]
    public string OZEL_HIZMET_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin ek gösterge tutarı bilgisidir.</summary>
    [Required]
    public string EK_GOSTERGE_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele ait yan ödeme tutarı bilgisidir.</summary>
    [Required]
    public string YAN_ODEME_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin doğu tazminat tutarı bilgisidir.</summary>
    [Required]
    public string DOGU_TAZMINATI_TUTARI { get; set; }

    /// <summary>Personelin bir ayda alacağı aylık (ek gösterge dâhil), yan ödeme ve her türlü ta...</summary>
    public string EK_ODEME_MATRAHI { get; set; }

    /// <summary>Sağlık tesisinde geçici görevli personelin, kadrosunun olduğu kurumdan almış old...</summary>
    [Required]
    public string BASKA_KURUMDAKI_EKODEME_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personel için Döner Sermaye Sabit Ödemesi (DSSÖ) için h...</summary>
    [Required]
    public string DSSO_TUTARI { get; set; }

    /// <summary>Sağlık tesisinde görevli personel için yapılan ek ödeme hesaplanmasında kullanıl...</summary>
    [Required]
    public string ENGELLILIK_INDIRIM_ORANI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin komisyon görevi için elde edilen ek puan ora...</summary>
    [Required]
    public string KOMISYON_EK_PUANI_ORANI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin asil görevi dışında başka bir görev yapması ...</summary>
    [Required]
    public string EK_PUAN_ORANI { get; set; }

    /// <summary>Sağlık tesisinde görevli tüm uzman tabiplerin birim performans katsayılarının or...</summary>
    [Required]
    public string BIRIM_PERFORMANS_KATSAYISI { get; set; }

    /// <summary>Ek ödeme bilgisinin ilk kayıt edildiği zaman bilgisidir.</summary>
    public DateTime? KAYIT_ZAMANI { get; set; }

    /// <summary>İşlemi ekleyen kullanıcı kodu, VEM_KULLANICI görüntüsündeki KULLANICI_KODU bilgi...</summary>
    [ForeignKey("EkleyenKullaniciNavigation")]
    public string EKLEYEN_KULLANICI_KODU { get; set; }

    /// <summary>İşlemin güncellemesinin yapıldığı zaman bilgisidir.</summary>
    public DateTime GUNCELLEME_ZAMANI { get; set; }

    /// <summary>İşlemi güncelleyen kullanıcı kodu, VEM_KULLANICI görüntüsündeki KULLANICI_KODU b...</summary>
    [Required]
    [ForeignKey("GuncelleyenKullaniciNavigation")]
    public string GUNCELLEYEN_KULLANICI_KODU { get; set; }

    #region Navigation Properties
    public virtual EK_ODEME_DONEM? EkOdemeDonemNavigation { get; set; }
    public virtual PERSONEL? PersonelNavigation { get; set; }
    public virtual KULLANICI? EkleyenKullaniciNavigation { get; set; }
    public virtual KULLANICI? GuncelleyenKullaniciNavigation { get; set; }
    #endregion

}