namespace Server.Application.Vem.DisprotezDetay;

public class DisprotezDetayDto
{
    public string? DISPROTEZ_DETAY_KODU { get; set; }
    public string? REFERANS_TABLO_ADI { get; set; }
    public string? DISPROTEZ_KODU { get; set; }
    public DateTime? DISPROTEZ_PLANLAMA_ZAMANI { get; set; }
    public string? DISPROTEZ_IS_TURU_ASAMA_KODU { get; set; }
    public DateTime DISPROTEZ_ASAMA_BITIS_ZAMANI { get; set; }
    public string? FIRMA_KODU { get; set; }
    public DateTime FIRMA_DISPROTEZ_ALIM_ZAMANI { get; set; }
    public DateTime PLANLANAN_BITIS_TARIHI { get; set; }
    public DateTime FIRMA_TESLIM_ZAMANI { get; set; }
    public DateTime DISPROTEZ_ASAMA_ONAY_ZAMANI { get; set; }
    public string? RPT_ONAY_DURUMU { get; set; }
    public string? RANDEVU_KODU { get; set; }
    public DateTime ASAMA_RPT_ZAMANI { get; set; }
    public string? ASAMA_RPT_SEBEBI { get; set; }
    public string? ASAMA_RPT_KULLANICI_KODU { get; set; }
    public DateTime OLCU_DOKUM_ZAMANI { get; set; }
}

