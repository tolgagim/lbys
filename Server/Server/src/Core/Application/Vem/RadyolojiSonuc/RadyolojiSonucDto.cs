namespace Server.Application.Vem.RadyolojiSonuc;

public class RadyolojiSonucDto
{
    public string? RADYOLOJI_SONUC_KODU { get; set; }
    public string? REFERANS_TABLO_ADI { get; set; }
    public string? RADYOLOJI_KODU { get; set; }
    public string? TETKIK_SONUCU_METIN { get; set; }
    public string? RADYOLOJI_TETKIK_SONUCU { get; set; }
    public string? RADYOLOJI_RAPOR_FORMATI { get; set; }
    public string? RAPOR_TIPI { get; set; }
    public string? RAPOR_YAZAN_PERSONEL_KODU { get; set; }
    public string? ONAYLAYAN_PERSONEL_KODU_1 { get; set; }
    public string? ONAYLAYAN_PERSONEL_KODU_2 { get; set; }
    public string? ONAYLAYAN_PERSONEL_KODU_3 { get; set; }
    public DateTime RAPOR_UZMAN_ONAY_ZAMANI { get; set; }
    public DateTime? RAPOR_KAYIT_ZAMANI { get; set; }
}

