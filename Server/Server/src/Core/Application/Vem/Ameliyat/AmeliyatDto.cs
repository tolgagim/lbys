namespace Server.Application.Vem.Ameliyat;

public class AmeliyatDto
{
    public string? AMELIYAT_KODU { get; set; }
    public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? AMELIYAT_ADI { get; set; }
    public string? AMELIYAT_TURU { get; set; }
    public DateTime? AMELIYAT_BASLAMA_ZAMANI { get; set; }
    public DateTime? AMELIYAT_BITIS_ZAMANI { get; set; }
    public string? MASA_CIHAZ_KODU { get; set; }
    public string? BIRIM_KODU { get; set; }
    public string? DEFTER_NUMARASI { get; set; }
    public string? AMELIYAT_DURUMU { get; set; }
    public string? ANESTEZI_TURU { get; set; }
    public string? ANESTEZI_NOTU { get; set; }
    public DateTime? ANESTEZI_BASLAMA_ZAMANI { get; set; }
    public DateTime? ANESTEZI_BITIS_ZAMANI { get; set; }
    public string? AMELIYAT_TIPI { get; set; }
    public string? SKOPI_SURESI { get; set; }
    public string? PROFILAKSI_PERIYODU { get; set; }
    public string? PROFILAKSI_KODU { get; set; }
}

