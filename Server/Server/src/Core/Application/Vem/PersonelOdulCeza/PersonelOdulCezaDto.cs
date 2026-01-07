namespace Server.Application.Vem.PersonelOdulCeza;

public class PersonelOdulCezaDto
{
    public string? PERSONEL_ODUL_CEZA_KODU { get; set; }
    public string? REFERANS_TABLO_ADI { get; set; }
    public string? PERSONEL_KODU { get; set; }
    public string? ODUL_CEZA_DURUMU { get; set; }
    public string? ODUL_CEZA_TURU { get; set; }
    public DateTime CEZA_BASLANGIC_TARIHI { get; set; }
    public DateTime CEZA_BITIS_TARIHI { get; set; }
    public string? ODUL_CEZA_VEREN_KURUM_KODU { get; set; }
    public string? ODUL_CEZA_ACIKLAMA { get; set; }
    public DateTime? TEBLIG_TARIHI { get; set; }
    public DateTime TEBLIG_EVRAK_TARIHI { get; set; }
    public string? TEBLIG_EVRAK_NUMARASI { get; set; }
}

