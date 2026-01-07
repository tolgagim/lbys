namespace Server.Application.Vem.Tetkik;

public class TetkikDto
{
    public string? TETKIK_KODU { get; set; }
    public string? TETKIK_ADI { get; set; }
    public string? LOINC_KODU { get; set; }
    public string? HIZMET_KODU { get; set; }
    public string? RAPOR_SONUC_SIRASI { get; set; }
    public string? HESAPLAMALI_TETKIK_BILGISI { get; set; }
    public string? HESAPLAMALI_TETKIK_FORMULU { get; set; }
    public bool AKTIF { get; set; }
}

