$sourceDir = "C:\Proje\GitHub\lbys\bilgi\Entities"
$targetDir = "C:\Proje\GitHub\lbys\Server\Server\src\Core\Domain\Lbys"

# Mevcut entity'ler
$existingEntities = @(
    "AMELIYAT", "BASVURU_TANI", "BINA", "BIRIM", "CIHAZ", "DEPO", "FATURA",
    "HASTA", "HASTA_BASVURU", "HASTA_HIZMET", "HASTA_YATAK", "HIZMET", "ICMAL",
    "KULLANICI", "KURUM", "ODA", "PERSONEL", "RANDEVU", "RECETE",
    "REFERANS_KODLAR", "STOK_KART", "TETKIK", "TETKIK_NUMUNE", "TETKIK_PARAMETRE",
    "TETKIK_SONUC", "YATAK", "VemEntity", "_AllEntities", "Common"
)

Get-ChildItem "$sourceDir\*.cs" | ForEach-Object {
    $fileName = $_.BaseName
    
    # Skip existing and special files
    if ($existingEntities -contains $fileName) {
        Write-Host "Skipping existing: $fileName"
        return
    }
    
    $content = Get-Content $_.FullName -Raw
    
    # Transform content
    $newContent = $content `
        -replace 'namespace Lbys\.Entities;', 'using Server.Domain.Lbys.Common;

namespace Server.Domain.Lbys;' `
        -replace 'public class (\w+)', 'public class $1 : VemEntity' `
        -replace '\s+public DateTime\? KAYIT_ZAMANI \{ get; set; \}', '' `
        -replace '\s+public DateTime KAYIT_ZAMANI \{ get; set; \}', '' `
        -replace '\s+\[ForeignKey\("EkleyenKullaniciNavigation"\)\]\s+public string EKLEYEN_KULLANICI_KODU \{ get; set; \}', '' `
        -replace '\s+\[ForeignKey\("EkleyenKullaniciNavigation"\)\]\s+public string\? EKLEYEN_KULLANICI_KODU \{ get; set; \}', '' `
        -replace '\s+public DateTime\? GUNCELLEME_ZAMANI \{ get; set; \}', '' `
        -replace '\s+public DateTime GUNCELLEME_ZAMANI \{ get; set; \}', '' `
        -replace '\s+\[Required\]\s+\[ForeignKey\("GuncelleyenKullaniciNavigation"\)\]\s+public string GUNCELLEYEN_KULLANICI_KODU \{ get; set; \}', '' `
        -replace '\s+\[ForeignKey\("GuncelleyenKullaniciNavigation"\)\]\s+public string\? GUNCELLEYEN_KULLANICI_KODU \{ get; set; \}', '' `
        -replace '\s+public virtual KULLANICI\? EkleyenKullaniciNavigation \{ get; set; \}', '' `
        -replace '\s+public virtual KULLANICI\? GuncelleyenKullaniciNavigation \{ get; set; \}', '' `
        -replace '/// <summary>.*?KAYIT.*?</summary>\s*', '' `
        -replace '/// <summary>.*?kayıt işlem.*?</summary>\s*', '' `
        -replace '/// <summary>.*?güncelleme işlem.*?</summary>\s*', ''
    
    # Add = default! to string Key properties
    $newContent = $newContent -replace '\[Key\]\s+public string (\w+) \{ get; set; \}', '[Key]
    public string $1 { get; set; } = default!'
    
    # Write new file
    $targetPath = Join-Path $targetDir "$fileName.cs"
    $newContent | Set-Content $targetPath -Encoding UTF8
    Write-Host "Created: $fileName.cs"
}
