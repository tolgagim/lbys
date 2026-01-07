$targetDir = "C:\Proje\GitHub\lbys\Server\Server\src\Core\Domain\Lbys"

# Mevcut entity'ler - bunlara dokunma
$existingEntities = @(
    "AMELIYAT", "BASVURU_TANI", "BINA", "BIRIM", "CIHAZ", "DEPO", "FATURA",
    "HASTA", "HASTA_BASVURU", "HASTA_HIZMET", "HASTA_YATAK", "HIZMET", "ICMAL",
    "KULLANICI", "KURUM", "ODA", "PERSONEL", "RANDEVU", "RECETE",
    "REFERANS_KODLAR", "STOK_KART", "TETKIK", "TETKIK_NUMUNE", "TETKIK_PARAMETRE",
    "TETKIK_SONUC", "YATAK"
)

Get-ChildItem "$targetDir\*.cs" | ForEach-Object {
    $fileName = $_.BaseName
    
    # Skip existing entities and special files
    if ($existingEntities -contains $fileName -or $fileName -eq "VemEntity" -or $fileName -eq "_AllEntities") {
        return
    }
    
    $content = Get-Content $_.FullName -Raw -Encoding UTF8
    
    # Fix: Add semicolon after = default!
    $content = $content -replace '= default!\s*\n', "= default!;`n"
    
    # Write with UTF8 without BOM
    [System.IO.File]::WriteAllText($_.FullName, $content, [System.Text.UTF8Encoding]::new($false))
    Write-Host "Fixed: $fileName"
}
