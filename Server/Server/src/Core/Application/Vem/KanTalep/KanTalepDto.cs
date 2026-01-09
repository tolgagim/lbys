namespace Server.Application.Vem.KanTalep;

public class KanTalepDto
{
    public string? KAN_TALEP_KODU { get; set; }
public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public DateTime? KAN_TALEP_ZAMANI { get; set; }
    public string? KAN_TALEP_ACIKLAMA { get; set; }
    public string? KAN_TALEP_NEDENI { get; set; }
    public string? KAN_ISTEYEN_BIRIM_KODU { get; set; }
    public string? ISTEYEN_HEKIM_KODU { get; set; }
    public string? ISTENEN_KAN_GRUBU { get; set; }
    public DateTime PLANLANAN_TRANSFUZYON_ZAMANI { get; set; }
    public string? PLANLANAN_TRANSFUZYON_SURESI { get; set; }
    public string? KAN_TALEP_ACILIYET_SEVIYESI { get; set; }
    public string? CROSS_MATCH_YAPILMA_DURUMU { get; set; }
    public string? KAN_ACIL_ACIKLAMA { get; set; }
    public string? KAN_ANTIKOR_DURUMU { get; set; }
    public string? TRANSPLANTASYON_GECIRME_DURUMU { get; set; }
    public string? TRANSFUZYON_GECIRME_DURUMU { get; set; }
    public string? TRANSFUZYON_REAKSIYON_DURUMU { get; set; }
    public string? GEBELIK_GECIRME_DURUMU { get; set; }
    public string? FETOMATERNAL_UYUSMAZLIK_DURUMU { get; set; }
    public string? KAN_TALEP_OZEL_DURUM { get; set; }
    public string? HEMATOKRIT_ORANI { get; set; }
    public string? TROMBOSIT_SAYISI { get; set; }
    public string? KAN_ENDIKASYON_TURU { get; set; }
}

