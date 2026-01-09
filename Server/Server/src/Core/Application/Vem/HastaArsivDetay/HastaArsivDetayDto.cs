namespace Server.Application.Vem.HastaArsivDetay;

public class HastaArsivDetayDto
{
    public string? HASTA_ARSIV_DETAY_KODU { get; set; }
public string? HASTA_KODU { get; set; }
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? HASTA_ARSIV_KODU { get; set; }
    public string? DOSYA_ALAN_BIRIM_KODU { get; set; }
    public DateTime DOSYANIN_ALINDIGI_ZAMAN { get; set; }
    public string? DOSYA_ALAN_PERSONEL_KODU { get; set; }
    public string? DOSYA_VEREN_BIRIM_KODU { get; set; }
    public DateTime DOSYANIN_VERILDIGI_ZAMAN { get; set; }
    public string? DOSYA_VEREN_KULLANICI_KODU { get; set; }
    public string? ACIKLAMA { get; set; }
}

