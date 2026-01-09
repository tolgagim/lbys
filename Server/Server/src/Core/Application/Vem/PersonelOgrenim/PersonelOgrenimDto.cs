namespace Server.Application.Vem.PersonelOgrenim;

public class PersonelOgrenimDto
{
    public string? PERSONEL_OGRENIM_KODU { get; set; }
public string? PERSONEL_KODU { get; set; }
    public string? OGRENIM_DURUMU { get; set; }
    public string? OKUL_ADI { get; set; }
    public DateTime OKULA_BASLANGIC_TARIHI { get; set; }
    public DateTime MEZUNIYET_TARIHI { get; set; }
    public string? BELGE_NUMARASI { get; set; }
    public string? ONAYLAYAN_PERSONEL_KODU { get; set; }
}

