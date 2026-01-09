namespace Server.Application.Vem.SysPaket;

public class SysPaketDto
{
    public string? SYS_PAKET_KODU { get; set; }
public string? HASTA_BASVURU_KODU { get; set; }
    public string? HASTA_KODU { get; set; }
    public string? VERI_PAKETI_NUMARASI { get; set; }
    public DateTime VERI_PAKETI_GONDERILME_ZAMANI { get; set; }
    public string? VERI_PAKETI_GONDERIM_DURUMU { get; set; }
    public string? GONDERILEN_PAKET_BILGISI { get; set; }
    public string? GELEN_CEVAP_BILGISI { get; set; }
}

