namespace Server.Application.Vem.StokIstek;

public class StokIstekDto
{
    public string? STOK_ISTEK_KODU { get; set; }
    public string? REFERANS_TABLO_ADI { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? HASTA_KODU { get; set; }
    public DateTime? ISTEK_ZAMANI { get; set; }
    public string? ISTEK_DEPO_KODU { get; set; }
    public string? HEKIM_KODU { get; set; }
    public string? STOK_ISTEK_DURUMU { get; set; }
    public string? STOK_ISTEK_HEKIM_ACIKLAMA { get; set; }
    public string? AMELIYAT_KODU { get; set; }
}

