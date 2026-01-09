namespace Server.Application.Vem.StokFis;

public class StokFisDto
{
    public string? STOK_FIS_KODU { get; set; }
public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? BAGLI_STOK_FIS_KODU { get; set; }
    public string? DEPO_KODU { get; set; }
    public string? HAREKET_TURU { get; set; }
    public string? MKYS_AYNIYAT_MAKBUZ_KODU { get; set; }
    public DateTime? HAREKET_TARIHI { get; set; }
    public string? SHCEK_PAYI { get; set; }
    public string? HAZINE_PAYI { get; set; }
    public string? SAGLIK_BAKANLIGI_PAYI { get; set; }
    public string? BEDELSIZ_FIS { get; set; }
    public string? FIS_TUTARI { get; set; }
    public string? HAREKET_SEKLI { get; set; }
    public string? ISLEMI_YAPAN_PERSONEL_KODU { get; set; }
    public DateTime? ISLEM_ZAMANI { get; set; }
    public string? FIRMA_KODU { get; set; }
    public string? IHALE_NUMARASI { get; set; }
    public DateTime IHALE_TARIHI { get; set; }
    public string? IHALE_TURU { get; set; }
    public string? MUAYENE_KABUL_NUMARASI { get; set; }
    public DateTime MUAYENE_TARIHI { get; set; }
    public string? TESLIM_EDEN_KISI { get; set; }
    public string? TESLIM_EDEN_KISI_UNVANI { get; set; }
    public string? BUTCE_TURU { get; set; }
    public string? FATURA_NUMARASI { get; set; }
    public DateTime FATURA_ZAMANI { get; set; }
    public string? IRSALIYE_NUMARASI { get; set; }
    public DateTime IRSALIYE_TARIHI { get; set; }
    public string? MKYS_KURUM_KODU { get; set; }
}

