namespace Server.Application.Vem.HastaHizmet;

public class HastaHizmetDto
{
    public string? HASTA_HIZMET_KODU { get; set; }
    public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? HIZMET_KODU { get; set; }
    public string? DOGUM_KODU { get; set; }
    public string? AMELIYAT_ISLEM_KODU { get; set; }
    public string? HASTA_HIZMET_DURUMU { get; set; }
    public string? HIZMET_FATURA_DURUMU { get; set; }
    public string? TIBBI_ISLEM_PUAN_BILGISI { get; set; }
    public string? TARAF_BILGISI { get; set; }
    public string? HIZMET_PUAN_BILGISI { get; set; }
    public DateTime? ISLEM_GERCEKLESME_ZAMANI { get; set; }
    public DateTime? PUAN_HAKEDIS_ZAMANI { get; set; }
    public DateTime? ISLEM_ZAMANI { get; set; }
    public DateTime? RANDEVU_ZAMANI { get; set; }
    public string? CIHAZ_KUNYE_NUMARASI { get; set; }
    public int? HIZMET_ADETI { get; set; }
    public int? FATURA_ADET { get; set; }
    public decimal? HASTA_TUTARI { get; set; }
    public decimal? KURUM_TUTARI { get; set; }
    public decimal? MEDULA_TUTARI { get; set; }
    public string? MEDULA_ISLEM_SIRA_NUMARASI { get; set; }
    public string? MEDULA_HIZMET_REF_NUMARASI { get; set; }
    public string? SYS_REFERANS_NUMARASI { get; set; }
    public string? MEDULA_TAKIP_KODU { get; set; }
    public string? MEDULA_OZEL_DURUM { get; set; }
    public string? ONAYLAYAN_HEKIM_KODU { get; set; }
    public string? ISTEYEN_HEKIM_KODU { get; set; }
    public string? FATURA_KODU { get; set; }
    public decimal? FATURA_TUTARI { get; set; }
    public string? ISBT_UNITE_NUMARASI { get; set; }
    public string? ISBT_BILESEN_NUMARASI { get; set; }
    public string? IPTAL_DURUMU { get; set; }
}

