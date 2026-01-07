namespace Server.Application.Vem.TibbiOrder;

public class TibbiOrderDto
{
    public string? TIBBI_ORDER_KODU { get; set; }
    public string? REFERANS_TABLO_ADI { get; set; }
    public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? TIBBI_ORDER_TURU { get; set; }
    public DateTime? ORDER_ZAMANI { get; set; }
    public string? HEKIM_KODU { get; set; }
    public string? ACIKLAMA { get; set; }
}

