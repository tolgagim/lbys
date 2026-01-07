namespace Server.Application.Vem.Yatak;

public class YatakDto
{
    public string? YATAK_KODU { get; set; }
    public string? YATAK_ADI { get; set; }
    public string? ODA_KODU { get; set; }
    public string? YATAK_TURU { get; set; }
    public string? YOGUN_BAKIM_YATAK_SEVIYESI { get; set; }
    public string? VENTILATOR_CIHAZ_KODU { get; set; }
    public bool AKTIF { get; set; }
}

