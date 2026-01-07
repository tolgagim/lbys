namespace Server.Application.Vem.AnlikYatanHasta;

public class AnlikYatanHastaDto
{
    public string? ANLIK_YATAN_HASTA_KODU { get; set; }
    public string? REFERANS_TABLO_ADI { get; set; }
    public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? HEKIM_KODU { get; set; }
    public string? YATIS_PROTOKOL_NUMARASI { get; set; }
    public string? BIRIM_KODU { get; set; }
    public string? YATAK_KODU { get; set; }
    public string? ODA_KODU { get; set; }
    public DateTime? YATIS_ZAMANI { get; set; }
}

