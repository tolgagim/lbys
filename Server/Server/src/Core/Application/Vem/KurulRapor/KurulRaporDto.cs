namespace Server.Application.Vem.KurulRapor;

public class KurulRaporDto
{
    public string? KURUL_RAPOR_KODU { get; set; }
public string? KURUL_KODU { get; set; }
    public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? RAPOR_ADI { get; set; }
    public DateTime? RAPOR_ZAMANI { get; set; }
    public string? ACIKLAMA { get; set; }
    public string? RAPOR_KARAR_NUMARASI { get; set; }
    public string? RAPOR_SIRA_NUMARASI { get; set; }
    public string? RAPOR_TAKIP_NUMARASI { get; set; }
    public string? KURUL_RAPOR_NUMARASI { get; set; }
    public DateTime? RAPOR_BASLAMA_TARIHI { get; set; }
    public DateTime RAPOR_BITIS_TARIHI { get; set; }
    public string? LABORATUVAR_BULGU { get; set; }
    public string? KURUL_RAPOR_MUAYENE_BULGUSU { get; set; }
    public string? KURUL_TANI_BILGISI { get; set; }
    public string? KURUL_RAPOR_KARARI { get; set; }
    public string? KARAR_ICERIK_FORMATI { get; set; }
    public string? MURACAAT_DURUMU { get; set; }
    public string? ENGELLILIK_ORANI { get; set; }
    public string? ILAC_RAPOR_DUZELTME_ACIKLAMASI { get; set; }
}

