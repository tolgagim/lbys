using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// Hasta Hizmet - Hastaya uygulanan hizmetler
/// </summary>
[Table("HASTA_HIZMET")]
public class HASTA_HIZMET : VemEntity
{
    [Key]
    public string HASTA_HIZMET_KODU { get; set; } = default!;

    public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? HIZMET_KODU { get; set; }
    public string? DOGUM_KODU { get; set; }
    public string? AMELIYAT_ISLEM_KODU { get; set; }
    public string? HASTA_HIZMET_DURUMU { get; set; }
    public string? HIZMET_FATURA_DURUMU { get; set; }
    public string? TIBBI_ISLEM_PUAN_BILGISI { get; set; }
    public string? TARAF_BILGISI { get; set; }
    public string? HIZMET_PUAN_BILGISI { get; set; }
    public DateTime? ISLEM_GERCEKLESME_ZAMANI { get; set; }
    public DateTime? PUAN_HAKEDIS_ZAMANI { get; set; }
    public DateTime? ISLEM_ZAMANI { get; set; }
    public DateTime? RANDEVU_ZAMANI { get; set; }
    public string? CIHAZ_KUNYE_NUMARASI { get; set; }
    public int? HIZMET_ADETI { get; set; }
    public int? FATURA_ADET { get; set; }
    public decimal? HASTA_TUTARI { get; set; }
    public decimal? KURUM_TUTARI { get; set; }
    public decimal? MEDULA_TUTARI { get; set; }
    public string? MEDULA_ISLEM_SIRA_NUMARASI { get; set; }
    public string? MEDULA_HIZMET_REF_NUMARASI { get; set; }
    public string? SYS_REFERANS_NUMARASI { get; set; }
    public string? MEDULA_TAKIP_KODU { get; set; }
    public string? MEDULA_OZEL_DURUM { get; set; }
    public string? ONAYLAYAN_HEKIM_KODU { get; set; }
    public string? ISTEYEN_HEKIM_KODU { get; set; }
    public string? FATURA_KODU { get; set; }
    public decimal? FATURA_TUTARI { get; set; }
    public string? ISBT_UNITE_NUMARASI { get; set; }
    public string? ISBT_BILESEN_NUMARASI { get; set; }
    public string? IPTAL_DURUMU { get; set; }

    // Navigation
    [ForeignKey("HASTA_KODU")]
    public virtual HASTA? HastaNavigation { get; set; }

    [ForeignKey("HASTA_BASVURU_KODU")]
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }

    [ForeignKey("HIZMET_KODU")]
    public virtual HIZMET? HizmetNavigation { get; set; }

    [ForeignKey("HASTA_HIZMET_DURUMU")]
    public virtual REFERANS_KODLAR? HastaHizmetDurumuNavigation { get; set; }

    [ForeignKey("HIZMET_FATURA_DURUMU")]
    public virtual REFERANS_KODLAR? HizmetFaturaDurumuNavigation { get; set; }

    [ForeignKey("TIBBI_ISLEM_PUAN_BILGISI")]
    public virtual REFERANS_KODLAR? TibbiIslemPuanBilgisiNavigation { get; set; }

    [ForeignKey("TARAF_BILGISI")]
    public virtual REFERANS_KODLAR? TarafBilgisiNavigation { get; set; }

    [ForeignKey("ONAYLAYAN_HEKIM_KODU")]
    public virtual PERSONEL? OnaylayanHekimNavigation { get; set; }

    [ForeignKey("ISTEYEN_HEKIM_KODU")]
    public virtual PERSONEL? IsteyenHekimNavigation { get; set; }

    [ForeignKey("FATURA_KODU")]
    public virtual FATURA? FaturaNavigation { get; set; }
}
