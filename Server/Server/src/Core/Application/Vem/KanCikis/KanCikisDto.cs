namespace Server.Application.Vem.KanCikis;

public class KanCikisDto
{
    public string? KAN_CIKIS_KODU { get; set; }
    public string? REFERANS_TABLO_ADI { get; set; }
    public string? KAN_TALEP_DETAY_KODU { get; set; }
    public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? KAN_STOK_KODU { get; set; }
    public string? KANI_TESLIM_ALAN_KISI { get; set; }
    public DateTime? KAN_CIKIS_ZAMANI { get; set; }
    public string? KURUM_KODU { get; set; }
    public string? KAN_CIKIS_PERSONEL_KODU { get; set; }
    public DateTime REZERVE_ZAMANI { get; set; }
    public string? REZERVE_EDEN_KULLANICI_KODU { get; set; }
    public string? CROSS_MATCH_KULLANICI_KODU { get; set; }
    public DateTime CROSS_MATCH_CALISMA_ZAMANI { get; set; }
    public string? CROSS_MATCH_CALISMA_YONTEMI { get; set; }
    public string? CROSS_MATCH_SONUCU { get; set; }
}

