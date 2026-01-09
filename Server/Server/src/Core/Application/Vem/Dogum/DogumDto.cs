namespace Server.Application.Vem.Dogum;

public class DogumDto
{
    public string? DOGUM_KODU { get; set; }
public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? HASTA_HIZMET_KODU { get; set; }
    public string? AMELIYAT_KODU { get; set; }
    public string? BABA_TC_KIMLIK_NUMARASI { get; set; }
    public string? KOMPLIKASYON_TANISI { get; set; }
    public string? DOGUM_NOTU { get; set; }
    public DateTime? DOGUM_BASLAMA_ZAMANI { get; set; }
    public DateTime DOGUM_BITIS_ZAMANI { get; set; }
    public string? HEKIM_KODU { get; set; }
    public string? EBE_KODU { get; set; }
    public string? BIRIM_KODU { get; set; }
    public string? DEFTER_NUMARASI { get; set; }
    public string? GUNCELLEYEN_KULLANICI_KODU { get; set; }
}

