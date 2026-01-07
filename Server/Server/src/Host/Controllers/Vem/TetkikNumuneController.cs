using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.TetkikNumune;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class TetkikNumuneController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public TetkikNumuneController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.TetkikNumune)]
    public async Task<List<TetkikNumuneDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<TETKIK_NUMUNE>()
            .AsNoTracking()
            .Select(e => new TetkikNumuneDto
            {
                TETKIK_NUMUNE_KODU = e.TETKIK_NUMUNE_KODU,
                HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                NUMUNE_NUMARASI = e.NUMUNE_NUMARASI,
                NUMUNE_TURU = e.NUMUNE_TURU,
                BIRIM_KODU = e.BIRIM_KODU,
                NUMUNE_ALMA_ZAMANI = e.NUMUNE_ALMA_ZAMANI,
                NUMUNE_KABUL_ZAMANI = e.NUMUNE_KABUL_ZAMANI,
                BARKOD = e.BARKOD,
                BARKOD_ZAMANI = e.BARKOD_ZAMANI,
                NUMUNE_ALAN_KULLANICI_KODU = e.NUMUNE_ALAN_KULLANICI_KODU,
                KABUL_EDEN_KULLANICI_KODU = e.KABUL_EDEN_KULLANICI_KODU,
                NUMUNE_RET_NEDENI = e.NUMUNE_RET_NEDENI,
                RET_EDEN_KULLANICI_KODU = e.RET_EDEN_KULLANICI_KODU,
                RET_ZAMANI = e.RET_ZAMANI,
                NUMUNE_ACILIYET_DURUMU = e.NUMUNE_ACILIYET_DURUMU,
                ENTEGRASYON_NUMARASI = e.ENTEGRASYON_NUMARASI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.TetkikNumune)]
    public async Task<ActionResult<TetkikNumuneDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<TETKIK_NUMUNE>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.TETKIK_NUMUNE_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new TetkikNumuneDto
        {
            TETKIK_NUMUNE_KODU = entity.TETKIK_NUMUNE_KODU,
            HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            NUMUNE_NUMARASI = entity.NUMUNE_NUMARASI,
            NUMUNE_TURU = entity.NUMUNE_TURU,
            BIRIM_KODU = entity.BIRIM_KODU,
            NUMUNE_ALMA_ZAMANI = entity.NUMUNE_ALMA_ZAMANI,
            NUMUNE_KABUL_ZAMANI = entity.NUMUNE_KABUL_ZAMANI,
            BARKOD = entity.BARKOD,
            BARKOD_ZAMANI = entity.BARKOD_ZAMANI,
            NUMUNE_ALAN_KULLANICI_KODU = entity.NUMUNE_ALAN_KULLANICI_KODU,
            KABUL_EDEN_KULLANICI_KODU = entity.KABUL_EDEN_KULLANICI_KODU,
            NUMUNE_RET_NEDENI = entity.NUMUNE_RET_NEDENI,
            RET_EDEN_KULLANICI_KODU = entity.RET_EDEN_KULLANICI_KODU,
            RET_ZAMANI = entity.RET_ZAMANI,
            NUMUNE_ACILIYET_DURUMU = entity.NUMUNE_ACILIYET_DURUMU,
            ENTEGRASYON_NUMARASI = entity.ENTEGRASYON_NUMARASI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.TetkikNumune)]
    public async Task<ActionResult<string>> Create(TetkikNumuneDto dto, CancellationToken ct)
    {
        var entity = new TETKIK_NUMUNE
        {
            TETKIK_NUMUNE_KODU = dto.TETKIK_NUMUNE_KODU,
            HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            NUMUNE_NUMARASI = dto.NUMUNE_NUMARASI,
            NUMUNE_TURU = dto.NUMUNE_TURU,
            BIRIM_KODU = dto.BIRIM_KODU,
            NUMUNE_ALMA_ZAMANI = dto.NUMUNE_ALMA_ZAMANI,
            NUMUNE_KABUL_ZAMANI = dto.NUMUNE_KABUL_ZAMANI,
            BARKOD = dto.BARKOD,
            BARKOD_ZAMANI = dto.BARKOD_ZAMANI,
            NUMUNE_ALAN_KULLANICI_KODU = dto.NUMUNE_ALAN_KULLANICI_KODU,
            KABUL_EDEN_KULLANICI_KODU = dto.KABUL_EDEN_KULLANICI_KODU,
            NUMUNE_RET_NEDENI = dto.NUMUNE_RET_NEDENI,
            RET_EDEN_KULLANICI_KODU = dto.RET_EDEN_KULLANICI_KODU,
            RET_ZAMANI = dto.RET_ZAMANI,
            NUMUNE_ACILIYET_DURUMU = dto.NUMUNE_ACILIYET_DURUMU,
            ENTEGRASYON_NUMARASI = dto.ENTEGRASYON_NUMARASI,
        };

        _db.Set<TETKIK_NUMUNE>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.TETKIK_NUMUNE_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.TetkikNumune)]
    public async Task<IActionResult> Update(string id, TetkikNumuneDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<TETKIK_NUMUNE>()
            .FirstOrDefaultAsync(e => e.TETKIK_NUMUNE_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.NUMUNE_NUMARASI = dto.NUMUNE_NUMARASI;
        entity.NUMUNE_TURU = dto.NUMUNE_TURU;
        entity.BIRIM_KODU = dto.BIRIM_KODU;
        entity.NUMUNE_ALMA_ZAMANI = dto.NUMUNE_ALMA_ZAMANI;
        entity.NUMUNE_KABUL_ZAMANI = dto.NUMUNE_KABUL_ZAMANI;
        entity.BARKOD = dto.BARKOD;
        entity.BARKOD_ZAMANI = dto.BARKOD_ZAMANI;
        entity.NUMUNE_ALAN_KULLANICI_KODU = dto.NUMUNE_ALAN_KULLANICI_KODU;
        entity.KABUL_EDEN_KULLANICI_KODU = dto.KABUL_EDEN_KULLANICI_KODU;
        entity.NUMUNE_RET_NEDENI = dto.NUMUNE_RET_NEDENI;
        entity.RET_EDEN_KULLANICI_KODU = dto.RET_EDEN_KULLANICI_KODU;
        entity.RET_ZAMANI = dto.RET_ZAMANI;
        entity.NUMUNE_ACILIYET_DURUMU = dto.NUMUNE_ACILIYET_DURUMU;
        entity.ENTEGRASYON_NUMARASI = dto.ENTEGRASYON_NUMARASI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.TetkikNumune)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<TETKIK_NUMUNE>()
            .FirstOrDefaultAsync(e => e.TETKIK_NUMUNE_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<TETKIK_NUMUNE>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
