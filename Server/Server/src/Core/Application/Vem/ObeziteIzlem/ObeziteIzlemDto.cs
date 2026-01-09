namespace Server.Application.Vem.ObeziteIzlem;

public class ObeziteIzlemDto
{
    public string? OBEZITE_IZLEM_KODU { get; set; }
public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? DIYET_TIBBI_BESLENME_TEDAVISI { get; set; }
    public DateTime ILK_TANI_TARIHI { get; set; }
    public string? MORBIT_OBEZ_LENFATIK_ODEM { get; set; }
    public string? OBEZITE_ILAC_TEDAVISI { get; set; }
    public string? PSIKOLOJIK_TEDAVI { get; set; }
    public string? BIRLIKTE_GORULEN_EK_HASTALIK { get; set; }
    public string? EGZERSIZ { get; set; }
    public string? ACIKLAMA { get; set; }
}

