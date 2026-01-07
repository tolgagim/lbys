namespace Server.Application.Vem.Personel;

public class PersonelDto
{
    public string? PERSONEL_KODU { get; set; }
    public string? TC_KIMLIK_NO { get; set; }
    public string? AD { get; set; }
    public string? SOYAD { get; set; }
    public string? UNVAN { get; set; }
    public string? UZMANLIK_KODU { get; set; }
    public string? BIRIM_KODU { get; set; }
    public string? CINSIYET { get; set; }
    public DateTime? DOGUM_TARIHI { get; set; }
    public string? TELEFON { get; set; }
    public string? EMAIL { get; set; }
    public string? DIPLOMA_NO { get; set; }
    public string? DIPLOMA_TESCIL_NO { get; set; }
    public DateTime? ISE_BASLAMA_TARIHI { get; set; }
    public bool AKTIF { get; set; }
}

