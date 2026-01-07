using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lbys.Entities;

/// <summary>
/// VEM_PERSONEL_BORDRO_SONDURUM tablosu - 17 kolon
/// </summary>
[Table("PERSONEL_BORDRO_SONDURUM")]
public class PERSONEL_BORDRO_SONDURUM
{
    /// <summary>Sağlık tesisinde görevli personelin bordrosuna ait son durum bilgileri için Sağl...</summary>
    [Key]
    public string PERSONEL_SONDURUM_KODU { get; set; }

    /// <summary>Görüntünün tekil kod bilgisinin alındığı SBYS veri tabanındaki tablo adının bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>Sağlık tesisindeki görevli personel için Sağlık Bilgi Yönetim Sistemi tarafından...</summary>
    [ForeignKey("PersonelNavigation")]
    public string PERSONEL_KODU { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin kademe bilgisidir.</summary>
    [Required]
    public string PERSONEL_KADEMESI { get; set; }

    /// <summary>Sağlık tesisinde görevli personel için kıdem derece bilgisidir.</summary>
    [Required]
    public string PERSONEL_DERECESI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele ait emekli derecesi bilgisidir.</summary>
    [Required]
    public string EMEKLI_DERECESI { get; set; }

    /// <summary>Sağlık tesisinde görevli personele ait emekli kademe bilgisidir.</summary>
    [Required]
    public string EMEKLI_KADEMESI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin bordrosunda hangi sendika için kesinti yapıl...</summary>
    [Required]
    public string SENDIKA_BILGISI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin kıdem yılı bilgisidir.</summary>
    [Required]
    public string KIDEM_YILI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin kıdem ayı bilgisidir.</summary>
    [Required]
    public string KIDEM_AYI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin kıdem günü bilgisidir.</summary>
    [Required]
    public string KIDEM_GUNU { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin ek gösterge bilgisidir.</summary>
    [Required]
    public string EK_GOSTERGE { get; set; }

    /// <summary>Sağlık tesisinde görevli personele ait emekli ek göstergesi bilgisidir.</summary>
    [Required]
    public string EMEKLI_EK_GOSTERGESI { get; set; }

    /// <summary>Sağlık tesisinde 657 sayılı Devlet Memurları Kanunu kapsamında görevli personeli...</summary>
    [Required]
    public string GOSTERGE { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin ait emekli gösterge bilgisidir.</summary>
    [Required]
    public string EMEKLI_GOSTERGESI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin yan ödeme puan bilgisidir.</summary>
    [Required]
    public string YAN_ODEME_PUANI { get; set; }

    /// <summary>Sağlık tesisinde görevli personelin özel hizmet puanı bilgisidir.</summary>
    [Required]
    public string OZEL_HIZMET_PUANI { get; set; }

    #region Navigation Properties
    public virtual PERSONEL? PersonelNavigation { get; set; }
    #endregion

}