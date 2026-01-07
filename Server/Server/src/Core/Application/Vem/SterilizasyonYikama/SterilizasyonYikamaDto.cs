namespace Server.Application.Vem.SterilizasyonYikama;

public class SterilizasyonYikamaDto
{
    public string? STERILIZASYON_YIKAMA_KODU { get; set; }
    public string? REFERANS_TABLO_ADI { get; set; }
    public string? DEPO_KODU { get; set; }
    public string? STOK_KART_KODU { get; set; }
    public string? YIKANAN_ALET_MIKTARI { get; set; }
    public string? STERILIZASYON_YIKAMA_TURU { get; set; }
    public string? YIKAMA_YAPAN_PERSONEL_KODU { get; set; }
    public DateTime? YIKAMA_BASLAMA_ZAMANI { get; set; }
    public DateTime YIKAMA_BITIS_ZAMANI { get; set; }
}

