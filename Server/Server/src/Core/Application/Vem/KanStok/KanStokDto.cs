namespace Server.Application.Vem.KanStok;

public class KanStokDto
{
    public string? KAN_STOK_KODU { get; set; }
    public string? REFERANS_TABLO_ADI { get; set; }
    public string? KAN_STOK_DURUMU { get; set; }
    public DateTime? KAN_STOK_GIRIS_TARIHI { get; set; }
    public string? DEFTER_NUMARASI { get; set; }
    public string? KAN_GRUBU { get; set; }
    public string? KAN_URUN_KODU { get; set; }
    public string? KAN_BAGISCI_KODU { get; set; }
    public string? KURUM_KODU { get; set; }
    public string? BIRIM_KODU { get; set; }
    public string? BAGLI_KAN_STOK_KODU { get; set; }
    public string? ISBT_UNITE_NUMARASI { get; set; }
    public string? ISBT_BILESEN_NUMARASI { get; set; }
    public string? KAN_HACIM { get; set; }
    public DateTime KAN_BAGIS_ZAMANI { get; set; }
    public DateTime KAN_FILTRELEME_ZAMANI { get; set; }
    public DateTime KAN_ISINLAMA_ZAMANI { get; set; }
    public DateTime KAN_YIKAMA_ZAMANI { get; set; }
    public DateTime KAN_AYIRMA_ZAMANI { get; set; }
    public DateTime KAN_BOLME_ZAMANI { get; set; }
    public DateTime BUFFYCOAT_UZAKLASTIRMA_ZAMANI { get; set; }
    public DateTime KAN_HAVUZLAMA_ZAMANI { get; set; }
    public DateTime SON_KULLANMA_TARIHI { get; set; }
}

