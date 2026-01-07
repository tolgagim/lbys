namespace Server.Application.Vem.SterilizasyonGiris;

public class SterilizasyonGirisDto
{
    public string? STERILIZASYON_GIRIS_KODU { get; set; }
    public string? REFERANS_TABLO_ADI { get; set; }
    public string? DEPO_KODU { get; set; }
    public string? STOK_KART_KODU { get; set; }
    public string? STERILIZASYON_GIRIS_MIKTARI { get; set; }
    public string? TESLIM_EDEN_BIRIM_KODU { get; set; }
    public string? TESLIM_EDEN_PERSONEL_KODU { get; set; }
    public DateTime? TESLIM_ZAMANI { get; set; }
    public string? TESLIM_ALAN_PERSONEL_KODU { get; set; }
}

