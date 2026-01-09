namespace Server.Application.Vem.HastaVentilator;

public class HastaVentilatorDto
{
    public string? HASTA_VENTILATOR_KODU { get; set; }
public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? VENTILATOR_CIHAZ_KODU { get; set; }
    public string? YOGUN_BAKIM_SEVIYE_BILGISI { get; set; }
    public DateTime? VENTILATOR_BAGLAMA_ZAMANI { get; set; }
    public DateTime VENTILATOR_AYRILMA_ZAMANI { get; set; }
}

