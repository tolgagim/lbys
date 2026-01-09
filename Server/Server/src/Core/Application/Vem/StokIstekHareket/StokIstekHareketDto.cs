namespace Server.Application.Vem.StokIstekHareket;

public class StokIstekHareketDto
{
    public string? STOK_ISTEK_HAREKET_KODU { get; set; }
public string? STOK_ISTEK_KODU { get; set; }
    public string? ISTENEN_STOK_KART_KODU { get; set; }
    public string? ISTENEN_ILAC_JENERIK_KODU { get; set; }
    public string? VERILEN_STOK_KART_KODU { get; set; }
    public string? ISTEK_GEREKLILIK_DURUMU { get; set; }
    public string? TEDAVIDE_KULLANILAN_ILAC { get; set; }
    public string? ISTENEN_MIKTAR { get; set; }
    public string? ACIKLAMA { get; set; }
    public string? DEPODAN_VERILEN_MIKTAR { get; set; }
    public string? STOK_ISTEK_RET_NEDENI { get; set; }
    public DateTime STOK_ISTEK_RET_ZAMANI { get; set; }
    public string? STOK_ISTEK_RET_KULLANICI_KODU { get; set; }
}

