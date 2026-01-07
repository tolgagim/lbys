namespace Server.Application.Vem.Recete;

public class ReceteDto
{
    public string? RECETE_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? HASTA_KODU { get; set; }
    public DateTime? RECETE_ZAMANI { get; set; }
    public string? RECETE_TURU { get; set; }
    public string? RECETE_ALT_TURU { get; set; }
    public string? HEKIM_KODU { get; set; }
    public string? DEFTER_NUMARASI { get; set; }
    public string? MEDULA_E_RECETE_NUMARASI { get; set; }
    public string? RENKLI_RECETE_NUMARASI { get; set; }
    public string? SERI_NUMARASI { get; set; }
    public string? RECETE_E_IMZA_DURUMU { get; set; }
    public string? SGK_TAKIP_NUMARASI { get; set; }
}

