namespace Server.Application.Vem.HastaYatak;

public class HastaYatakDto
{
    public string? HASTA_YATAK_KODU { get; set; }
    public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? YATAK_KODU { get; set; }
    public DateTime? YATIS_BASLAMA_ZAMANI { get; set; }
    public DateTime? YATIS_BITIS_ZAMANI { get; set; }
}

