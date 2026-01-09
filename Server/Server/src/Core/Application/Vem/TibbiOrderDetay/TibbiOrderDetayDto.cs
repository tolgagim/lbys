namespace Server.Application.Vem.TibbiOrderDetay;

public class TibbiOrderDetayDto
{
    public string? TIBBI_ORDER_DETAY_KODU { get; set; }
public string? TIBBI_ORDER_KODU { get; set; }
    public DateTime? PLANLANAN_UYGULANMA_ZAMANI { get; set; }
    public string? UYGULAYAN_HEMSIRE_KODU { get; set; }
    public DateTime UYGULAMA_ZAMANI { get; set; }
    public string? UYGULANMA_DURUMU { get; set; }
    public string? TIBBI_ORDER_IPTAL_NEDENI { get; set; }
    public string? IPTAL_EDEN_HEMSIRE_KODU { get; set; }
    public DateTime IPTAL_ZAMANI { get; set; }
    public string? ACIKLAMA { get; set; }
}

