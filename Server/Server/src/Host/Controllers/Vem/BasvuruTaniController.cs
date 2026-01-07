using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.BasvuruTani;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class BasvuruTaniController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public BasvuruTaniController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.BasvuruTani)]
    public async Task<List<BasvuruTaniDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<BASVURU_TANI>()
            .AsNoTracking()
            .Select(e => new BasvuruTaniDto
            {
                BASVURU_TANI_KODU = e.BASVURU_TANI_KODU,
                HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                TANI_KODU = e.TANI_KODU,
                TANI_TURU = e.TANI_TURU,
                BIRINCIL_TANI = e.BIRINCIL_TANI,
                TANI_ZAMANI = e.TANI_ZAMANI,
                HEKIM_KODU = e.HEKIM_KODU,
                KURUL_RAPOR_KODU = e.KURUL_RAPOR_KODU,
                HASTA_SEVK_KODU = e.HASTA_SEVK_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.BasvuruTani)]
    public async Task<ActionResult<BasvuruTaniDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<BASVURU_TANI>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.BASVURU_TANI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new BasvuruTaniDto
        {
            BASVURU_TANI_KODU = entity.BASVURU_TANI_KODU,
            HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            TANI_KODU = entity.TANI_KODU,
            TANI_TURU = entity.TANI_TURU,
            BIRINCIL_TANI = entity.BIRINCIL_TANI,
            TANI_ZAMANI = entity.TANI_ZAMANI,
            HEKIM_KODU = entity.HEKIM_KODU,
            KURUL_RAPOR_KODU = entity.KURUL_RAPOR_KODU,
            HASTA_SEVK_KODU = entity.HASTA_SEVK_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.BasvuruTani)]
    public async Task<ActionResult<string>> Create(BasvuruTaniDto dto, CancellationToken ct)
    {
        var entity = new BASVURU_TANI
        {
            BASVURU_TANI_KODU = dto.BASVURU_TANI_KODU,
            HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            TANI_KODU = dto.TANI_KODU,
            TANI_TURU = dto.TANI_TURU,
            BIRINCIL_TANI = dto.BIRINCIL_TANI,
            TANI_ZAMANI = dto.TANI_ZAMANI,
            HEKIM_KODU = dto.HEKIM_KODU,
            KURUL_RAPOR_KODU = dto.KURUL_RAPOR_KODU,
            HASTA_SEVK_KODU = dto.HASTA_SEVK_KODU,
        };

        _db.Set<BASVURU_TANI>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.BASVURU_TANI_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.BasvuruTani)]
    public async Task<IActionResult> Update(string id, BasvuruTaniDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<BASVURU_TANI>()
            .FirstOrDefaultAsync(e => e.BASVURU_TANI_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.TANI_KODU = dto.TANI_KODU;
        entity.TANI_TURU = dto.TANI_TURU;
        entity.BIRINCIL_TANI = dto.BIRINCIL_TANI;
        entity.TANI_ZAMANI = dto.TANI_ZAMANI;
        entity.HEKIM_KODU = dto.HEKIM_KODU;
        entity.KURUL_RAPOR_KODU = dto.KURUL_RAPOR_KODU;
        entity.HASTA_SEVK_KODU = dto.HASTA_SEVK_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.BasvuruTani)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<BASVURU_TANI>()
            .FirstOrDefaultAsync(e => e.BASVURU_TANI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<BASVURU_TANI>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
