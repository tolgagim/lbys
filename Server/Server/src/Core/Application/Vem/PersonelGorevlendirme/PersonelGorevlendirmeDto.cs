namespace Server.Application.Vem.PersonelGorevlendirme;

public class PersonelGorevlendirmeDto
{
    public string? PERSONEL_GOREVLENDIRME_KODU { get; set; }
    public string? REFERANS_TABLO_ADI { get; set; }
    public string? PERSONEL_KODU { get; set; }
    public string? GOREV_TURU { get; set; }
    public DateTime? GOREVLENDIRME_BASLAMA_TARIHI { get; set; }
    public DateTime GOREVLENDIRME_BITIS_TARIHI { get; set; }
    public string? GOREVLENDIRME_IL_KODU { get; set; }
    public string? GOREVLENDIRME_ILCE_KODU { get; set; }
    public string? GOREVLENDIRILDIGI_KURUM_KODU { get; set; }
}

