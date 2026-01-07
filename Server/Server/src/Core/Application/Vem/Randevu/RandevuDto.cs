namespace Server.Application.Vem.Randevu;

public class RandevuDto
{
    public string? RANDEVU_KODU { get; set; }
    public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? RANDEVU_TURU { get; set; }
    public string? RANDEVU_ALT_TURU { get; set; }
    public DateTime? RANDEVU_ZAMANI { get; set; }
    public DateTime? RANDEVU_KAYIT_ZAMANI { get; set; }
    public string? HASTA_HIZMET_KODU { get; set; }
    public string? BIRIM_KODU { get; set; }
    public string? HEKIM_KODU { get; set; }
    public string? MHRS_HRN_KODU { get; set; }
    public string? MHRS_RANDEVU_NOTU { get; set; }
    public string? RANDEVU_GELME_DURUMU { get; set; }
    public string? CIHAZ_KODU { get; set; }
    public string? TC_KIMLIK_NUMARASI { get; set; }
    public string? AD { get; set; }
    public string? SOYADI { get; set; }
    public string? CINSIYET { get; set; }
    public string? TELEFON_NUMARASI { get; set; }
    public string? IPTAL_DURUMU { get; set; }
    public string? IPTAL_EDEN_KULLANICI_KODU { get; set; }
    public DateTime? IPTAL_ZAMANI { get; set; }
    public string? IPTAL_ACIKLAMA { get; set; }
}

