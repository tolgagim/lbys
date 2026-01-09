namespace Server.Application.Vem.SterilizasyonCikis;

public class SterilizasyonCikisDto
{
    public string? STERILIZASYON_CIKIS_KODU { get; set; }
public string? DEPO_KODU { get; set; }
    public string? STERILIZASYON_SET_KODU { get; set; }
    public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? STERILIZASYON_CIKIS_MIKTARI { get; set; }
    public DateTime? STERILIZASYON_CIKIS_ZAMANI { get; set; }
    public string? CIKIS_YAPILAN_BIRIM_KODU { get; set; }
    public string? TESLIM_EDEN_PERSONEL_KODU { get; set; }
    public string? TESLIM_ALAN_PERSONEL_KODU { get; set; }
}

