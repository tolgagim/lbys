namespace Server.Application.Vem.HastaGizlilik;

public class HastaGizlilikDto
{
    public string? HASTA_GIZLILIK_KODU { get; set; }
    public string? REFERANS_TABLO_ADI { get; set; }
    public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? GIZLILIK_NEDENI { get; set; }
    public string? GORUNECEK_HASTA_ADI { get; set; }
    public string? GORUNECEK_HASTA_SOYADI { get; set; }
    public string? GIZLILIK_TURU { get; set; }
    public DateTime? GIZLILIK_BASLAMA_ZAMANI { get; set; }
    public DateTime GIZLILIK_BITIS_ZAMANI { get; set; }
    public string? ACIKLAMA { get; set; }
}

