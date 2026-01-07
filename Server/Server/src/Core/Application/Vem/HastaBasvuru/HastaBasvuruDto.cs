namespace Server.Application.Vem.HastaBasvuru;

public class HastaBasvuruDto
{
    public string? HASTA_BASVURU_KODU { get; set; }
    public string? HASTA_KODU { get; set; }
    public DateTime BASVURU_TARIHI { get; set; }
    public string? BASVURU_TURU { get; set; }
    public string? BASVURU_SEKLI { get; set; }
    public string? BIRIM_KODU { get; set; }
    public string? DOKTOR_KODU { get; set; }
    public string? SIKAYET { get; set; }
    public string? TANI_KODU { get; set; }
    public string? TEDAVI_TURU { get; set; }
    public string? SEVK_EDEN_KURUM { get; set; }
    public string? PROVIZYON_TIPI { get; set; }
    public string? TAKIP_NO { get; set; }
    public DateTime? CIKIS_TARIHI { get; set; }
    public string? CIKIS_SEKLI { get; set; }
    public string? SONUC_KODU { get; set; }
    public bool AKTIF { get; set; }
}

