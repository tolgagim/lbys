namespace Server.Application.Vem.PersonelEgitim;

public class PersonelEgitimDto
{
    public string? PERSONEL_EGITIM_KODU { get; set; }
    public string? REFERANS_TABLO_ADI { get; set; }
    public string? PERSONEL_KODU { get; set; }
    public string? PERSONEL_EGITIM_TURU { get; set; }
    public string? SERTIFIKA_TIPI { get; set; }
    public string? SERTIFIKA_PUANI { get; set; }
    public string? BELGE_NUMARASI { get; set; }
    public DateTime? EGITIM_BASLANGIC_ZAMANI { get; set; }
    public DateTime EGITIM_BITIS_ZAMANI { get; set; }
    public string? EGITIM_VEREN_KISI_BILGISI { get; set; }
    public string? EGITIM_YERI { get; set; }
    public string? ONAYLAYAN_PERSONEL_KODU { get; set; }
}

