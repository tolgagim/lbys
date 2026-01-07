using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;

/// <summary>
/// Randevu - Hasta randevu kayitlari
/// </summary>
[Table("RANDEVU")]
public class RANDEVU : VemEntity
{
    [Key]
    public string RANDEVU_KODU { get; set; } = default!;

    public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? RANDEVU_TURU { get; set; }
    public string? RANDEVU_ALT_TURU { get; set; }
    public DateTime? RANDEVU_ZAMANI { get; set; }
    public DateTime? RANDEVU_KAYIT_ZAMANI { get; set; }
    public string? HASTA_HIZMET_KODU { get; set; }
    public string? BIRIM_KODU { get; set; }
    public string? HEKIM_KODU { get; set; }
    public string? MHRS_HRN_KODU { get; set; }
    public string? MHRS_RANDEVU_NOTU { get; set; }
    public string? RANDEVU_GELME_DURUMU { get; set; }
    public string? CIHAZ_KODU { get; set; }
    public string? TC_KIMLIK_NUMARASI { get; set; }
    public string? AD { get; set; }
    public string? SOYADI { get; set; }
    public string? CINSIYET { get; set; }
    public string? TELEFON_NUMARASI { get; set; }
    public string? IPTAL_DURUMU { get; set; }
    public string? IPTAL_EDEN_KULLANICI_KODU { get; set; }
    public DateTime? IPTAL_ZAMANI { get; set; }
    public string? IPTAL_ACIKLAMA { get; set; }

    // Navigation
    [ForeignKey("HASTA_KODU")]
    public virtual HASTA? HastaNavigation { get; set; }

    [ForeignKey("HASTA_BASVURU_KODU")]
    public virtual HASTA_BASVURU? HastaBasvuruNavigation { get; set; }

    [ForeignKey("RANDEVU_TURU")]
    public virtual REFERANS_KODLAR? RandevuTuruNavigation { get; set; }

    [ForeignKey("RANDEVU_ALT_TURU")]
    public virtual REFERANS_KODLAR? RandevuAltTuruNavigation { get; set; }

    [ForeignKey("BIRIM_KODU")]
    public virtual BIRIM? BirimNavigation { get; set; }

    [ForeignKey("HEKIM_KODU")]
    public virtual PERSONEL? HekimNavigation { get; set; }

    [ForeignKey("RANDEVU_GELME_DURUMU")]
    public virtual REFERANS_KODLAR? RandevuGelmeDurumuNavigation { get; set; }

    [ForeignKey("CIHAZ_KODU")]
    public virtual CIHAZ? CihazNavigation { get; set; }

    [ForeignKey("CINSIYET")]
    public virtual REFERANS_KODLAR? CinsiyetNavigation { get; set; }

    [ForeignKey("IPTAL_EDEN_KULLANICI_KODU")]
    public virtual KULLANICI? IptalEdenKullaniciNavigation { get; set; }
}
