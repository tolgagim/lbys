namespace Server.Application.Vem.StokIstekUygulama;

public class StokIstekUygulamaDto
{
    public string? STOK_ISTEK_UYGULAMA_KODU { get; set; }
    public string? REFERANS_TABLO_ADI { get; set; }
    public string? STOK_ISTEK_HAREKET_KODU { get; set; }
    public DateTime? ORDER_PLANLANAN_ZAMAN { get; set; }
    public DateTime ORDER_UYGULANAN_ZAMAN { get; set; }
    public string? UYGULAYAN_HEMSIRE_KODU { get; set; }
    public string? ISTEK_IPTAL_NEDENI { get; set; }
    public string? IPTAL_EDEN_HEMSIRE_KODU { get; set; }
    public DateTime IPTAL_ZAMANI { get; set; }
    public string? UYGULANAN_MIKTAR { get; set; }
    public string? ACIKLAMA { get; set; }
}

