namespace Server.Application.Vem.StokEhuTakip;

public class StokEhuTakipDto
{
    public string? STOK_EHU_TAKIP_KODU { get; set; }
    public string? REFERANS_TABLO_ADI { get; set; }
    public string? STOK_ISTEK_KODU { get; set; }
    public string? STOK_ISTEK_HAREKET_KODU { get; set; }
    public string? STOK_KART_KODU { get; set; }
    public DateTime? EHU_ONAY_BASLAMA_ZAMANI { get; set; }
    public DateTime? EHU_ONAY_BITIS_ZAMANI { get; set; }
    public string? EHU_ILAC_MAKSIMUM_MIKTAR { get; set; }
    public string? ACIKLAMA { get; set; }
    public DateTime EHU_ONAYLAMA_ZAMANI { get; set; }
    public string? ONAYLAYAN_HEKIM_KODU { get; set; }
    public string? EHU_RET_NEDENI { get; set; }
    public DateTime EHU_RET_ZAMANI { get; set; }
    public string? EHU_RET_PERSONEL_KODU { get; set; }
    public string? EHU_RET_ACIKLAMA { get; set; }
}

