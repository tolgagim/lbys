namespace Server.Application.Vem.Radyoloji;

public class RadyolojiDto
{
    public string? RADYOLOJI_KODU { get; set; }
public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? BIRIM_KODU { get; set; }
    public DateTime TETKIK_CEKIM_KABUL_ZAMANI { get; set; }
    public string? BARKOD { get; set; }
    public DateTime BARKOD_ZAMANI { get; set; }
    public string? CIHAZ_KODU { get; set; }
    public DateTime CALISMA_BASLAMA_ZAMANI { get; set; }
    public DateTime CALISMA_BITIS_ZAMANI { get; set; }
    public string? KABUL_EDEN_KULLANICI_KODU { get; set; }
    public string? TETKIK_CEKEN_TEKNISYEN_KODU { get; set; }
    public string? HASTA_HIZMET_KODU { get; set; }
    public string? LOINC_KODU { get; set; }
    public string? TETKIK_ISTENME_DURUMU { get; set; }
    public string? ERISIM_NUMARASI { get; set; }
}

