using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// Tetkik Sonuc - Laboratuvar tetkik sonuclari
/// </summary>
[Table("TETKIK_SONUC")]
public class TETKIK_SONUC : VemEntity
{
    [Key]
    public string TETKIK_SONUC_KODU { get; set; } = default!;

    public string? TETKIK_NUMUNE_KODU { get; set; }
    public string? TETKIK_PARAMETRE_KODU { get; set; }
    public string? TETKIK_KODU { get; set; }
    public string? TETKIK_ADI { get; set; }
    public string? HASTA_HIZMET_KODU { get; set; }
    public string? TETKIK_SONUCU { get; set; }
    public DateTime? SONUC_ZAMANI { get; set; }
    public string? TETKIK_SONUC_GIZLENME_DURUMU { get; set; }
    public string? WEB_SONUC_GIZLENME_DURUMU { get; set; }
    public string? NUMUNE_RET_NEDENI { get; set; }
    public string? RET_EDEN_KULLANICI_KODU { get; set; }
    public DateTime? RET_ZAMANI { get; set; }
    public string? KRITIK_DEGER_ARALIGI { get; set; }
    public DateTime? CALISMA_BASLAMA_ZAMANI { get; set; }
    public DateTime? CALISMA_BITIS_ZAMANI { get; set; }
    public string? ONAYLAYAN_TEKNISYEN_KODU { get; set; }
    public DateTime? TEKNISYEN_ONAY_ZAMANI { get; set; }
    public string? ONAYLAYAN_HEKIM_KODU { get; set; }
    public DateTime? TETKIK_UZMAN_ONAY_ZAMANI { get; set; }
    public string? LOINC_KODU { get; set; }
    public string? TEKRAR_CALISMA_DURUMU { get; set; }
    public string? MANUEL_TETKIK_SONUC_DURUMU { get; set; }
    public string? UREME_DURUMU { get; set; }
    public string? CIHAZ_KODU { get; set; }
    public string? CIHAZ_TETKIK_SONUCU { get; set; }
    public string? TETKIK_SONUCU_BIRIMI { get; set; }
    public string? TETKIK_SONUCU_REFERANS_DEGERI { get; set; }
    public string? TETKIK_SONUCU_DURUMU { get; set; }
    public string? TETKIK_SONUC_ACIKLAMA { get; set; }
    public string? RAPOR_YAZAN_PERSONEL_KODU { get; set; }
    public string? SONUC_DIS_ERISIM_BILGISI { get; set; }

    // Navigation
    [ForeignKey("TETKIK_NUMUNE_KODU")]
    public virtual TETKIK_NUMUNE? TetkikNumuneNavigation { get; set; }

    [ForeignKey("TETKIK_PARAMETRE_KODU")]
    public virtual TETKIK_PARAMETRE? TetkikParametreNavigation { get; set; }

    [ForeignKey("TETKIK_KODU")]
    public virtual TETKIK? TetkikNavigation { get; set; }

    [ForeignKey("HASTA_HIZMET_KODU")]
    public virtual HASTA_HIZMET? HastaHizmetNavigation { get; set; }

    [ForeignKey("NUMUNE_RET_NEDENI")]
    public virtual REFERANS_KODLAR? NumuneRetNedeniNavigation { get; set; }

    [ForeignKey("RET_EDEN_KULLANICI_KODU")]
    public virtual KULLANICI? RetEdenKullaniciNavigation { get; set; }

    [ForeignKey("ONAYLAYAN_TEKNISYEN_KODU")]
    public virtual PERSONEL? OnaylayanTeknisyenNavigation { get; set; }

    [ForeignKey("ONAYLAYAN_HEKIM_KODU")]
    public virtual PERSONEL? OnaylayanHekimNavigation { get; set; }

    [ForeignKey("CIHAZ_KODU")]
    public virtual CIHAZ? CihazNavigation { get; set; }

    [ForeignKey("TETKIK_SONUCU_DURUMU")]
    public virtual REFERANS_KODLAR? TetkikSonucuDurumuNavigation { get; set; }

    [ForeignKey("RAPOR_YAZAN_PERSONEL_KODU")]
    public virtual PERSONEL? RaporYazanPersonelNavigation { get; set; }
}
