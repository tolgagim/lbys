namespace Server.Application.Vem.SterilizasyonSet;

public class SterilizasyonSetDto
{
    public string? STERILIZASYON_SET_KODU { get; set; }
public string? DEPO_KODU { get; set; }
    public string? STERILIZASYON_PAKET_KODU { get; set; }
    public string? BARKOD { get; set; }
    public string? BARKOD_BASAN_KULLANICI_KODU { get; set; }
    public DateTime BARKOD_ZAMANI { get; set; }
    public string? CIHAZ_KODU { get; set; }
    public string? STERILIZASYON_CEVRIM_NUMARASI { get; set; }
    public string? SET_IADE_DURUMU { get; set; }
    public DateTime SET_IADE_ZAMANI { get; set; }
    public string? SET_IADE_EDEN_PERSONEL_KODU { get; set; }
    public string? SET_IADE_ALAN_PERSONEL_KODU { get; set; }
    public DateTime PAKET_RAF_OMRU_BITIS_TARIHI { get; set; }
    public string? PAKETLEYEN_PERSONEL_KODU { get; set; }
    public DateTime? ISLEM_ZAMANI { get; set; }
    public DateTime? STERILIZASYON_BASLAMA_ZAMANI { get; set; }
    public DateTime STERILIZASYON_BITIS_ZAMANI { get; set; }
    public string? STERILIZASYON_PERSONEL_KODU { get; set; }
    public string? ACIKLAMA { get; set; }
}

