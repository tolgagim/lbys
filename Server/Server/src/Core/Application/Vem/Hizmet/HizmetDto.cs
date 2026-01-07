namespace Server.Application.Vem.Hizmet;

public class HizmetDto
{
    public string? HIZMET_KODU { get; set; }
    public string? HIZMET_ISLEM_GRUBU { get; set; }
    public string? HIZMET_ISLEM_TURU { get; set; }
    public string? SUT_KODU { get; set; }
    public string? HIZMET_ADI { get; set; }
    public string? TIBBI_ISLEM_PUAN_BILGISI { get; set; }
    public bool AKTIF { get; set; }
}

