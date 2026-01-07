namespace Server.Application.Vem.Fatura;

public class FaturaDto
{
    public string? FATURA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? HASTA_KODU { get; set; }
    public string? FATURA_DONEMI { get; set; }
    public string? ICMAL_KODU { get; set; }
    public string? FATURA_TURU { get; set; }
    public string? FATURA_ADI { get; set; }
    public DateTime? FATURA_ZAMANI { get; set; }
    public decimal? FATURA_TUTARI { get; set; }
    public string? FATURA_NUMARASI { get; set; }
    public string? MEDULA_TESLIM_NUMARASI { get; set; }
    public string? FATURA_KESILEN_KURUM_KODU { get; set; }
    public string? BUTCE_KODU { get; set; }
}

