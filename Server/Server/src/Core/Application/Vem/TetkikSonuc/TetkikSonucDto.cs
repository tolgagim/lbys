namespace Server.Application.Vem.TetkikSonuc;

public class TetkikSonucDto
{
    public string? TETKIK_SONUC_KODU { get; set; }
    public string? TETKIK_NUMUNE_KODU { get; set; }
    public string? TETKIK_PARAMETRE_KODU { get; set; }
    public string? TETKIK_KODU { get; set; }
    public string? TETKIK_ADI { get; set; }
    public string? HASTA_HIZMET_KODU { get; set; }
    public string? TETKIK_SONUCU { get; set; }
    public DateTime? SONUC_ZAMANI { get; set; }
    public string? TETKIK_SONUC_GIZLENME_DURUMU { get; set; }
    public string? WEB_SONUC_GIZLENME_DURUMU { get; set; }
    public string? NUMUNE_RET_NEDENI { get; set; }
    public string? RET_EDEN_KULLANICI_KODU { get; set; }
    public DateTime? RET_ZAMANI { get; set; }
    public string? KRITIK_DEGER_ARALIGI { get; set; }
    public DateTime? CALISMA_BASLAMA_ZAMANI { get; set; }
    public DateTime? CALISMA_BITIS_ZAMANI { get; set; }
    public string? ONAYLAYAN_TEKNISYEN_KODU { get; set; }
    public DateTime? TEKNISYEN_ONAY_ZAMANI { get; set; }
    public string? ONAYLAYAN_HEKIM_KODU { get; set; }
    public DateTime? TETKIK_UZMAN_ONAY_ZAMANI { get; set; }
    public string? LOINC_KODU { get; set; }
    public string? TEKRAR_CALISMA_DURUMU { get; set; }
    public string? MANUEL_TETKIK_SONUC_DURUMU { get; set; }
    public string? UREME_DURUMU { get; set; }
    public string? CIHAZ_KODU { get; set; }
    public string? CIHAZ_TETKIK_SONUCU { get; set; }
    public string? TETKIK_SONUCU_BIRIMI { get; set; }
    public string? TETKIK_SONUCU_REFERANS_DEGERI { get; set; }
    public string? TETKIK_SONUCU_DURUMU { get; set; }
    public string? TETKIK_SONUC_ACIKLAMA { get; set; }
    public string? RAPOR_YAZAN_PERSONEL_KODU { get; set; }
    public string? SONUC_DIS_ERISIM_BILGISI { get; set; }
}

