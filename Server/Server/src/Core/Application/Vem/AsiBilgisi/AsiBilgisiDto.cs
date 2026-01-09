namespace Server.Application.Vem.AsiBilgisi;

public class AsiBilgisiDto
{
    public string? ASI_BILGISI_KODU { get; set; }
public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? ASI_KODU { get; set; }
    public string? ASININ_DOZU { get; set; }
    public string? ASININ_UYGULAMA_SEKLI { get; set; }
    public string? ASI_UYGULAMA_YERI { get; set; }
    public string? ASI_SORGU_NUMARASI { get; set; }
    public string? ASI_ISLEM_TURU { get; set; }
    public string? BILGI_ALINAN_KISI_AD_SOYADI { get; set; }
    public string? BILGI_ALINAN_KISI_TELEFON { get; set; }
    public DateTime? ASI_YAPILMA_ZAMANI { get; set; }
    public string? ASI_OZEL_DURUM_NEDENI { get; set; }
    public DateTime ASIE_ORTAYA_CIKIS_ZAMANI { get; set; }
    public string? ASIE_NEDENLERI { get; set; }
    public string? ASI_ERTELEME_SURESI { get; set; }
    public string? ASI_YAPILMAMA_DURUMU { get; set; }
    public string? ASI_YAPILMAMA_NEDENI { get; set; }
    public string? ALTTA_YATAN_HASTALIK { get; set; }
    public string? ACIKLAMA { get; set; }
}

