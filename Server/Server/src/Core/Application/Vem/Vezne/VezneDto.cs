namespace Server.Application.Vem.Vezne;

public class VezneDto
{
    public string? VEZNE_KODU { get; set; }
    public string? REFERANS_TABLO_ADI { get; set; }
    public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? MAKBUZ_NUMARASI { get; set; }
    public string? VEZNE_OZEL_NUMARASI { get; set; }
    public string? VEZNE_GIRIS_CIKIS_BILGISI { get; set; }
    public DateTime? MAKBUZ_ZAMANI { get; set; }
    public string? VEZNE_BIRIM_KODU { get; set; }
    public string? MAKBUZ_SERI_NUMARASI { get; set; }
    public string? IPTAL_DURUMU { get; set; }
    public DateTime IPTAL_ZAMANI { get; set; }
    public string? IPTAL_ACIKLAMA { get; set; }
    public string? TAHSIL_TURU { get; set; }
    public string? MAKBUZ_TUTARI { get; set; }
    public string? ACIKLAMA { get; set; }
    public string? MAKBUZ_SAHIBI_ADRESI { get; set; }
    public string? FIRMA_ADI { get; set; }
    public string? FIRMA_KODU { get; set; }
}

