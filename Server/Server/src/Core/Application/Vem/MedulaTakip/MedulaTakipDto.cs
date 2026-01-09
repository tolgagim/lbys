namespace Server.Application.Vem.MedulaTakip;

public class MedulaTakipDto
{
    public string? MEDULA_TAKIP_KODU { get; set; }
public string? HASTA_BASVURU_KODU { get; set; }
    public string? HASTA_KODU { get; set; }
    public string? SGK_TAKIP_NUMARASI { get; set; }
    public string? SGK_ILKTAKIP_NUMARASI { get; set; }
    public string? MEDULA_TESIS_KODU { get; set; }
    public string? MEDULA_BRANS_KODU { get; set; }
    public string? PROVIZYON_TURU { get; set; }
    public DateTime? PROVIZYON_TARIHI { get; set; }
    public string? TC_KIMLIK_NUMARASI { get; set; }
    public string? CINSIYET { get; set; }
    public string? MEDULA_TUTARI { get; set; }
    public string? FATURA_TESLIM_NUMARASI { get; set; }
    public DateTime FATURA_TESLIM_TARIHI { get; set; }
    public string? TEDAVI_TURU { get; set; }
    public string? SIGORTALI_TURU { get; set; }
    public string? DEVREDILEN_KURUM { get; set; }
    public string? SONUC_KODU { get; set; }
    public string? SONUC_MESAJI { get; set; }
    public string? TAKIP_TIPI { get; set; }
    public string? BASVURU_NUMARASI { get; set; }
    public string? TEDAVI_TIPI { get; set; }
    public string? TEDAVI_SEKLI { get; set; }
}

