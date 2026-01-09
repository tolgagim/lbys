namespace Server.Application.Vem.RiskSkorlama;

public class RiskSkorlamaDto
{
    public string? RISK_SKORLAMA_KODU { get; set; }
public string? HASTA_BASVURU_KODU { get; set; }
    public string? HASTA_KODU { get; set; }
    public string? RISK_SKORLAMA_TURU { get; set; }
    public DateTime? ISLEM_ZAMANI { get; set; }
    public string? RISK_SKORLAMA_TOPLAM_PUANI { get; set; }
    public string? BEKLENEN_OLUM_ORANI { get; set; }
    public string? GLASGOW_SKALASI { get; set; }
    public string? DUZELTILMISBEKLENEN_OLUM_ORANI { get; set; }
    public string? TIBBI_ORDER_DETAY_KODU { get; set; }
    public string? ACIKLAMA { get; set; }
}

