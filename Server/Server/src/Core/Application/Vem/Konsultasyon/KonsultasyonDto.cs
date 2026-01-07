namespace Server.Application.Vem.Konsultasyon;

public class KonsultasyonDto
{
    public string? KONSULTASYON_KODU { get; set; }
    public string? REFERANS_TABLO_ADI { get; set; }
    public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? HASTA_HIZMET_KODU { get; set; }
    public string? KONSULTASYON_BASVURU_KODU { get; set; }
    public string? KONSULTASYON_ISTEK_NOTU { get; set; }
    public string? KONSULTASYON_CEVAP_NOTU { get; set; }
    public DateTime KONSULTASYONA_CAGRILMA_ZAMANI { get; set; }
    public DateTime KONSULTASYONA_GELIS_ZAMANI { get; set; }
    public string? KONSULTASYON_YERI { get; set; }
}

