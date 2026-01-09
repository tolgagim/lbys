namespace Server.Application.Vem.KlinikSeyir;

public class KlinikSeyirDto
{
    public string? KLINIK_SEYIR_KODU { get; set; }
public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? SEYIR_TIPI { get; set; }
    public DateTime? SEYIR_ZAMANI { get; set; }
    public string? SEYIR_BILGISI { get; set; }
    public string? SEPTIK_SOK { get; set; }
    public string? SEPSIS_DURUMU { get; set; }
    public string? HEKIM_KODU { get; set; }
}

