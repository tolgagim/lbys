namespace Server.Application.Vem.NobetciPersonelBilgisi;

public class NobetciPersonelBilgisiDto
{
    public string? NOBETCI_PERSONEL_BILGISI_KODU { get; set; }
public string? SKRS_KURUM_KODU { get; set; }
    public string? PERSONEL_TC_KIMLIK_NUMARASI { get; set; }
    public string? KLINIK_KODU { get; set; }
    public string? GOREV_TURU { get; set; }
    public string? PERSONEL_GOREV_KODU { get; set; }
    public DateTime NOBET_BASLANGIC_TARIHI { get; set; }
    public DateTime NOBET_BITIS_TARIHI { get; set; }
    public string? TELEFON_NUMARASI { get; set; }
}

