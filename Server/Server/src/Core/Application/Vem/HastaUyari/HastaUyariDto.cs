namespace Server.Application.Vem.HastaUyari;

public class HastaUyariDto
{
    public string? HASTA_UYARI_KODU { get; set; }
    public string? REFERANS_TABLO_ADI { get; set; }
    public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? UYARI_TURU { get; set; }
    public string? ISLEME_IZIN_VERME_DURUMU { get; set; }
    public DateTime? HASTA_UYARI_BASLAMA_ZAMANI { get; set; }
    public DateTime HASTA_UYARI_BITIS_ZAMANI { get; set; }
    public string? ACIKLAMA { get; set; }
}

