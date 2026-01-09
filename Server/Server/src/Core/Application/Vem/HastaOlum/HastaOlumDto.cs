namespace Server.Application.Vem.HastaOlum;

public class HastaOlumDto
{
    public string? HASTA_OLUM_KODU { get; set; }
public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public DateTime? OLUM_ZAMANI { get; set; }
    public string? OLUM_YERI { get; set; }
    public string? ANNE_OLUM_NEDENI { get; set; }
    public string? ACIKLAMA { get; set; }
    public string? OTOPSI_DURUMU { get; set; }
    public string? OLUM_BELGESI_PERSONEL_KODU { get; set; }
    public string? OLUM_NEDENI_TANI_KODU { get; set; }
    public string? OLUM_NEDENI_TURU { get; set; }
    public string? OLUM_SEKLI { get; set; }
    public string? EX_KARARINI_VEREN_HEKIM_KODU { get; set; }
    public DateTime TUTANAK_ZAMANI { get; set; }
    public string? TESLIM_ALAN_TC_KIMLIK_NUMARASI { get; set; }
    public string? TESLIM_ALAN_ADI_SOYADI { get; set; }
    public string? TESLIM_ALAN_TELEFON_BILGISI { get; set; }
    public string? TESLIM_ALAN_ADRESI { get; set; }
    public string? TESLIM_EDEN_PERSONEL_KODU { get; set; }
}

