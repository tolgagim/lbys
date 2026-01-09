namespace Server.Application.Vem.KanUrunImha;

public class KanUrunImhaDto
{
    public string? KAN_URUN_IMHA_KODU { get; set; }
public string? KAN_STOK_KODU { get; set; }
    public string? KAN_IMHA_NEDENI { get; set; }
    public DateTime? KAN_IMHA_ZAMANI { get; set; }
    public string? KAN_IMHA_ONAYLAYAN_HEKIM { get; set; }
    public string? KAN_IMHA_ONAYLAYAN_TEKNISYEN { get; set; }
    public string? KAN_IMHA_EDEN_PERSONEL_KODU { get; set; }
}

