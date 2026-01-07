namespace Server.Application.Vem.KurulTeshis;

public class KurulTeshisDto
{
    public string? KURUL_TESHIS_KODU { get; set; }
    public string? REFERANS_TABLO_ADI { get; set; }
    public string? KURUL_RAPOR_KODU { get; set; }
    public string? ILAC_TESHIS_KODU { get; set; }
    public string? TANI_KODU { get; set; }
    public DateTime RAPOR_BASLAMA_TARIHI { get; set; }
    public DateTime RAPOR_BITIS_TARIHI { get; set; }
}

