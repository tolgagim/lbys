namespace Server.Application.Vem.TetkikNumune;

public class TetkikNumuneDto
{
    public string? TETKIK_NUMUNE_KODU { get; set; }
    public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? NUMUNE_NUMARASI { get; set; }
    public string? NUMUNE_TURU { get; set; }
    public string? BIRIM_KODU { get; set; }
    public DateTime? NUMUNE_ALMA_ZAMANI { get; set; }
    public DateTime? NUMUNE_KABUL_ZAMANI { get; set; }
    public string? BARKOD { get; set; }
    public DateTime? BARKOD_ZAMANI { get; set; }
    public string? NUMUNE_ALAN_KULLANICI_KODU { get; set; }
    public string? KABUL_EDEN_KULLANICI_KODU { get; set; }
    public string? NUMUNE_RET_NEDENI { get; set; }
    public string? RET_EDEN_KULLANICI_KODU { get; set; }
    public DateTime? RET_ZAMANI { get; set; }
    public string? NUMUNE_ACILIYET_DURUMU { get; set; }
    public string? ENTEGRASYON_NUMARASI { get; set; }
}

