using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// HEMSIRE_BAKIM tablosu - 17 kolon
/// </summary>
[Table("HEMSIRE_BAKIM")]
public class HEMSIRE_BAKIM : VemEntity
{
    /// <summary>SaÄŸlÄ±k tesisinde tedavi olan hastaya hemÅŸire tarafÄ±ndan uygulanan bakÄ±m bilgiler...</summary>
    [Key]
    public string HEMSIRE_BAKIM_KODU { get; set; } = default!;
    /// <summary>GÃ¶rÃ¼ntÃ¼nÃ¼n tekil kod bilgisinin alÄ±ndÄ±ÄŸÄ± SBYS veri tabanÄ±ndaki tablo adÄ±nÄ±n bilg...</summary>
    public string REFERANS_TABLO_ADI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde hasta bilgileri iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [ForeignKey("HastaNavigation")]
    public string HASTA_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisine baÅŸvuran hastalar iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼...</summary>
    [ForeignKey("HastaBasvuruNavigation")]
    public string HASTA_BASVURU_KODU { get; set; }

    /// <summary>HemÅŸirenin hastayÄ± deÄŸerlendirdiÄŸi zaman bilgisidir.</summary>
    public DateTime? HEMSIRE_DEGERLENDIRME_ZAMANI { get; set; }

    /// <summary>HemÅŸirelik bakÄ±m planÄ± kapsamÄ±nda hemÅŸire tarafÄ±ndan hastaya konulan hemÅŸirelik ...</summary>
    [ForeignKey("HemsirelikTaniNavigation")]
    public string HEMSIRELIK_TANI_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavi olan hastalara hemÅŸire tarafÄ±ndan uygulanan bakÄ±ma iliÅŸk...</summary>
    [Required]
    [ForeignKey("BakimNedeniNavigation")]
    public string BAKIM_NEDENI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavi olan hastaya hemÅŸire tarafÄ±ndan uygulanan bakÄ±m tedavisi...</summary>
    [Required]
    [ForeignKey("HemsireBakimHedefSonucNavigation")]
    public string HEMSIRE_BAKIM_HEDEF_SONUC { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavi alan hasta iÃ§in hemÅŸire tarafÄ±ndan uygulanan giriÅŸim bil...</summary>
    [Required]
    [ForeignKey("HemsirelikGirisimiNavigation")]
    public string HEMSIRELIK_GIRISIMI { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavi olan hastaya hemÅŸire tarafÄ±ndan uygulanan bakÄ±m iÃ§in hem...</summary>
    [Required]
    [ForeignKey("HemsireDegerlendirmeDurumuNavigation")]
    public string HEMSIRE_DEGERLENDIRME_DURUMU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde tedavi gÃ¶ren hastaya, hemÅŸire tarafÄ±ndan uygulanan iÅŸlemlere il...</summary>
    [Required]
    public string HEMSIRE_DEGERLENDIRME_NOTU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde gÃ¶revli hemÅŸire iÃ§in SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi tarafÄ±ndan Ã¼r...</summary>
    [Required]
    [ForeignKey("HemsireNavigation")]
    public string HEMSIRE_KODU { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde verilen hizmete, yapÄ±lan iÅŸleme, kullanÄ±lan malzemelere vb. ili...</summary>
    [Required]
    public string ACIKLAMA { get; set; }

    /// <summary>SaÄŸlÄ±k tesisinde Ã¼retilen verinin SaÄŸlÄ±k Bilgi YÃ¶netim Sistemi'ne ilk defa kayÄ±t...</summary>

    #region Navigation Properties
    public virtual HASTA? HastaNavigation { get; set; }
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }
    public virtual REFERANS_KODLAR? HemsirelikTaniNavigation { get; set; }
    public virtual REFERANS_KODLAR? BakimNedeniNavigation { get; set; }
    public virtual REFERANS_KODLAR? HemsireBakimHedefSonucNavigation { get; set; }
    public virtual REFERANS_KODLAR? HemsirelikGirisimiNavigation { get; set; }
    public virtual REFERANS_KODLAR? HemsireDegerlendirmeDurumuNavigation { get; set; }
    public virtual PERSONEL? HemsireNavigation { get; set; }
    #endregion

}
