namespace Server.Application.Vem.BasvuruYemek;

public class BasvuruYemekDto
{
    public string? BASVURU_YEMEK_KODU { get; set; }
public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? YEMEK_TURU { get; set; }
    public string? YEMEK_ZAMANI_TURU { get; set; }
    public DateTime? YEMEK_ZAMANI { get; set; }
    public string? ACIKLAMA { get; set; }
}

