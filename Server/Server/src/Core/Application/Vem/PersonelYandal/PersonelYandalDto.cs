namespace Server.Application.Vem.PersonelYandal;

public class PersonelYandalDto
{
    public string? PERSONEL_YANDAL_KODU { get; set; }
    public string? REFERANS_TABLO_ADI { get; set; }
    public string? PERSONEL_KODU { get; set; }
    public DateTime? YANDAL_BASLANGIC_TARIHI { get; set; }
    public DateTime YANDAL_BITIS_TARIHI { get; set; }
    public string? MEDULA_BRANS_KODU { get; set; }
}

