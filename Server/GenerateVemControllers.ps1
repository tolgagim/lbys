# VEM Controllers and DTOs Generator Script
# Bu script 141 VEM entity icin Controller ve DTO dosyalarini olusturur

$domainPath = "Server\src\Core\Domain\Lbys"
$controllersPath = "Server\src\Host\Controllers\Vem"
$applicationPath = "Server\src\Core\Application\Vem"

# Klasorleri olustur
if (-not (Test-Path $controllersPath)) {
    New-Item -ItemType Directory -Path $controllersPath -Force
}
if (-not (Test-Path $applicationPath)) {
    New-Item -ItemType Directory -Path $applicationPath -Force
}

# Turkce karakterleri ASCII'ye cevir
function ConvertToAscii($text) {
    $text = $text -replace 'İ', 'I'
    $text = $text -replace 'ı', 'i'
    $text = $text -replace 'Ğ', 'G'
    $text = $text -replace 'ğ', 'g'
    $text = $text -replace 'Ü', 'U'
    $text = $text -replace 'ü', 'u'
    $text = $text -replace 'Ş', 'S'
    $text = $text -replace 'ş', 's'
    $text = $text -replace 'Ö', 'O'
    $text = $text -replace 'ö', 'o'
    $text = $text -replace 'Ç', 'C'
    $text = $text -replace 'ç', 'c'
    return $text
}

# PascalCase'e cevir (InvariantCulture ile)
function ToPascalCase($text) {
    $culture = [System.Globalization.CultureInfo]::InvariantCulture
    $parts = $text -split '_'
    $result = ""
    foreach ($part in $parts) {
        if ($part.Length -gt 0) {
            $first = $culture.TextInfo.ToUpper($part[0])
            $rest = $culture.TextInfo.ToLower($part.Substring(1))
            $result += $first + $rest
        }
    }
    $result = ConvertToAscii $result
    return $result
}

# Entity dosyalarini oku (Common haric)
$entityFiles = Get-ChildItem -Path $domainPath -Filter "*.cs" | Where-Object { $_.Directory.Name -ne "Common" }

foreach ($file in $entityFiles) {
    $entityName = $file.BaseName

    # Resource name olustur
    $resourceName = ToPascalCase $entityName

    # Primary key'i bul
    $content = Get-Content $file.FullName -Raw
    if ($content -match '\[Key\]\s*public\s+string\s+(\w+)') {
        $primaryKey = $matches[1]
    } else {
        $primaryKey = $entityName + "_KODU"
    }

    # Property'leri cek - nullable tipler dahil
    $properties = @()
    # Regex: public string|int|DateTime|decimal|bool ile ? (nullable) veya onsuz yakalayalim
    $regex = [regex]'public\s+(string|int|DateTime|decimal|bool)(\?)?\s+(\w+)\s*{\s*get;\s*set;\s*}'
    $propMatches = $regex.Matches($content)
    foreach ($match in $propMatches) {
        $propType = $match.Groups[1].Value
        $isNullable = $match.Groups[2].Value -eq "?"
        $propName = $match.Groups[3].Value
        # Navigation property'leri atla
        if ($propName -notmatch "Navigation$") {
            $properties += @{Type = $propType; Name = $propName; IsNullable = $isNullable}
        }
    }

    # DTO klasoru
    $dtoFolder = Join-Path $applicationPath $resourceName
    if (-not (Test-Path $dtoFolder)) {
        New-Item -ItemType Directory -Path $dtoFolder -Force | Out-Null
    }

    # DTO dosyasi olustur - property nullability'yi koru
    $dtoContent = @"
namespace Server.Application.Vem.$resourceName;

public class ${resourceName}Dto
{
"@
    foreach ($prop in $properties) {
        $nullable = if ($prop.IsNullable -or $prop.Type -eq "string") { "?" } else { "" }
        $dtoContent += "`n    public $($prop.Type)$nullable $($prop.Name) { get; set; }"
    }
    $dtoContent += "`n}`n"

    $dtoFile = Join-Path $dtoFolder "${resourceName}Dto.cs"
    Set-Content -Path $dtoFile -Value $dtoContent -Encoding UTF8

    # Controller dosyasi olustur
    $controllerContent = @"
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.$resourceName;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class ${resourceName}Controller : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public ${resourceName}Controller(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.$resourceName)]
    public async Task<List<${resourceName}Dto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<$entityName>()
            .AsNoTracking()
            .Select(e => new ${resourceName}Dto
            {
"@
    foreach ($prop in $properties) {
        $controllerContent += "`n                $($prop.Name) = e.$($prop.Name),"
    }
    $controllerContent += @"

            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.$resourceName)]
    public async Task<ActionResult<${resourceName}Dto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<$entityName>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.$primaryKey == id, ct);

        if (entity == null)
            return NotFound();

        return new ${resourceName}Dto
        {
"@
    foreach ($prop in $properties) {
        $controllerContent += "`n            $($prop.Name) = entity.$($prop.Name),"
    }
    $controllerContent += @"

        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.$resourceName)]
    public async Task<ActionResult<string>> Create(${resourceName}Dto dto, CancellationToken ct)
    {
        var entity = new $entityName
        {
"@
    foreach ($prop in $properties) {
        # Non-nullable property icin null kontrolu ekle
        if ($prop.IsNullable -eq $false -and $prop.Type -ne "string") {
            $controllerContent += "`n            $($prop.Name) = dto.$($prop.Name),"
        } else {
            $controllerContent += "`n            $($prop.Name) = dto.$($prop.Name),"
        }
    }
    $controllerContent += @"

        };

        _db.Set<$entityName>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.$primaryKey;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.$resourceName)]
    public async Task<IActionResult> Update(string id, ${resourceName}Dto dto, CancellationToken ct)
    {
        var entity = await _db.Set<$entityName>()
            .FirstOrDefaultAsync(e => e.$primaryKey == id, ct);

        if (entity == null)
            return NotFound();

"@
    foreach ($prop in $properties) {
        if ($prop.Name -ne $primaryKey) {
            $controllerContent += "        entity.$($prop.Name) = dto.$($prop.Name);`n"
        }
    }
    $controllerContent += @"

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.$resourceName)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<$entityName>()
            .FirstOrDefaultAsync(e => e.$primaryKey == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<$entityName>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
"@

    $controllerFile = Join-Path $controllersPath "${resourceName}Controller.cs"
    Set-Content -Path $controllerFile -Value $controllerContent -Encoding UTF8

    Write-Host "Created: $resourceName"
}

Write-Host ""
Write-Host "Generation complete!"
