namespace Server.Application.Vem.KanTalepDetay;

public class KanTalepDetayDto
{
    public string? KAN_TALEP_DETAY_KODU { get; set; }
    public string? REFERANS_TABLO_ADI { get; set; }
    public string? KAN_TALEP_KODU { get; set; }
    public string? KAN_URUN_KODU { get; set; }
    public string? ISTENEN_KAN_GRUBU { get; set; }
    public DateTime RET_TARIHI { get; set; }
    public string? RET_EDEN_KULLANICI_KODU { get; set; }
    public string? KAN_TALEP_RET_NEDENI { get; set; }
    public string? KAN_TALEP_MIKTARI { get; set; }
    public string? KAN_HACIM { get; set; }
    public string? ACIKLAMA { get; set; }
    public string? BUFFYCOAT_UZAKLASTIRMA_DURUMU { get; set; }
    public string? KAN_FILTRELEME_DURUMU { get; set; }
    public string? KAN_ISINLAMA_DURUMU { get; set; }
    public string? KAN_YIKAMA_DURUMU { get; set; }
}

