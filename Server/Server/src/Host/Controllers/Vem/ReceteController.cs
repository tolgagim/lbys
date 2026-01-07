using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Recete;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class ReceteController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public ReceteController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Recete)]
    public async Task<List<ReceteDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<RECETE>()
            .AsNoTracking()
            .Select(e => new ReceteDto
            {
                RECETE_KODU = e.RECETE_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                HASTA_KODU = e.HASTA_KODU,
                RECETE_ZAMANI = e.RECETE_ZAMANI,
                RECETE_TURU = e.RECETE_TURU,
                RECETE_ALT_TURU = e.RECETE_ALT_TURU,
                HEKIM_KODU = e.HEKIM_KODU,
                DEFTER_NUMARASI = e.DEFTER_NUMARASI,
                MEDULA_E_RECETE_NUMARASI = e.MEDULA_E_RECETE_NUMARASI,
                RENKLI_RECETE_NUMARASI = e.RENKLI_RECETE_NUMARASI,
                SERI_NUMARASI = e.SERI_NUMARASI,
                RECETE_E_IMZA_DURUMU = e.RECETE_E_IMZA_DURUMU,
                SGK_TAKIP_NUMARASI = e.SGK_TAKIP_NUMARASI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Recete)]
    public async Task<ActionResult<ReceteDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<RECETE>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.RECETE_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new ReceteDto
        {
            RECETE_KODU = entity.RECETE_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            HASTA_KODU = entity.HASTA_KODU,
            RECETE_ZAMANI = entity.RECETE_ZAMANI,
            RECETE_TURU = entity.RECETE_TURU,
            RECETE_ALT_TURU = entity.RECETE_ALT_TURU,
            HEKIM_KODU = entity.HEKIM_KODU,
            DEFTER_NUMARASI = entity.DEFTER_NUMARASI,
            MEDULA_E_RECETE_NUMARASI = entity.MEDULA_E_RECETE_NUMARASI,
            RENKLI_RECETE_NUMARASI = entity.RENKLI_RECETE_NUMARASI,
            SERI_NUMARASI = entity.SERI_NUMARASI,
            RECETE_E_IMZA_DURUMU = entity.RECETE_E_IMZA_DURUMU,
            SGK_TAKIP_NUMARASI = entity.SGK_TAKIP_NUMARASI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Recete)]
    public async Task<ActionResult<string>> Create(ReceteDto dto, CancellationToken ct)
    {
        var entity = new RECETE
        {
            RECETE_KODU = dto.RECETE_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            HASTA_KODU = dto.HASTA_KODU,
            RECETE_ZAMANI = dto.RECETE_ZAMANI,
            RECETE_TURU = dto.RECETE_TURU,
            RECETE_ALT_TURU = dto.RECETE_ALT_TURU,
            HEKIM_KODU = dto.HEKIM_KODU,
            DEFTER_NUMARASI = dto.DEFTER_NUMARASI,
            MEDULA_E_RECETE_NUMARASI = dto.MEDULA_E_RECETE_NUMARASI,
            RENKLI_RECETE_NUMARASI = dto.RENKLI_RECETE_NUMARASI,
            SERI_NUMARASI = dto.SERI_NUMARASI,
            RECETE_E_IMZA_DURUMU = dto.RECETE_E_IMZA_DURUMU,
            SGK_TAKIP_NUMARASI = dto.SGK_TAKIP_NUMARASI,
        };

        _db.Set<RECETE>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.RECETE_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Recete)]
    public async Task<IActionResult> Update(string id, ReceteDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<RECETE>()
            .FirstOrDefaultAsync(e => e.RECETE_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.RECETE_ZAMANI = dto.RECETE_ZAMANI;
        entity.RECETE_TURU = dto.RECETE_TURU;
        entity.RECETE_ALT_TURU = dto.RECETE_ALT_TURU;
        entity.HEKIM_KODU = dto.HEKIM_KODU;
        entity.DEFTER_NUMARASI = dto.DEFTER_NUMARASI;
        entity.MEDULA_E_RECETE_NUMARASI = dto.MEDULA_E_RECETE_NUMARASI;
        entity.RENKLI_RECETE_NUMARASI = dto.RENKLI_RECETE_NUMARASI;
        entity.SERI_NUMARASI = dto.SERI_NUMARASI;
        entity.RECETE_E_IMZA_DURUMU = dto.RECETE_E_IMZA_DURUMU;
        entity.SGK_TAKIP_NUMARASI = dto.SGK_TAKIP_NUMARASI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Recete)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<RECETE>()
            .FirstOrDefaultAsync(e => e.RECETE_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<RECETE>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
