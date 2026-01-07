namespace Server.Application.Vem.PersonelIzin;

public class PersonelIzinDto
{
    public string? PERSONEL_IZIN_KODU { get; set; }
    public string? REFERANS_TABLO_ADI { get; set; }
    public string? PERSONEL_KODU { get; set; }
    public string? PERSONEL_IZIN_TURU { get; set; }
    public string? KULLANILAN_IZIN { get; set; }
    public string? GECEN_YILDAN_KULLANILAN_IZIN { get; set; }
    public string? AKTIF_YILDAN_KULLANILAN_IZIN { get; set; }
    public DateTime? IZIN_BASLAMA_TARIHI { get; set; }
    public DateTime IZIN_BITIS_TARIHI { get; set; }
    public string? PERSONEL_IZIN_YILI { get; set; }
    public DateTime PERSONEL_DONUS_TARIHI { get; set; }
    public string? IZIN_ADRESI { get; set; }
    public string? ACIKLAMA { get; set; }
    public string? SBYS_ENGELLENME_DURUMU { get; set; }
    public DateTime SBYS_KULLANIM_ENGELLEME_ZAMANI { get; set; }
    public string? SBYS_ENGELLEYEN_KULLANICI_KODU { get; set; }
    public string? ONAYLAYAN_PERSONEL_KODU { get; set; }
}

