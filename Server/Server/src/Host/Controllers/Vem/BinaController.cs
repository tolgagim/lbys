using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Bina;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class BinaController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public BinaController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Bina)]
    public async Task<List<BinaDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<BINA>()
            .AsNoTracking()
            .Select(e => new BinaDto
            {
                BINA_KODU = e.BINA_KODU,
                BINA_ADI = e.BINA_ADI,
                BINA_ADRESI = e.BINA_ADRESI,
                SKRS_KURUM_KODU = e.SKRS_KURUM_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Bina)]
    public async Task<ActionResult<BinaDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<BINA>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.BINA_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new BinaDto
        {
            BINA_KODU = entity.BINA_KODU,
            BINA_ADI = entity.BINA_ADI,
            BINA_ADRESI = entity.BINA_ADRESI,
            SKRS_KURUM_KODU = entity.SKRS_KURUM_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Bina)]
    public async Task<ActionResult<string>> Create(BinaDto dto, CancellationToken ct)
    {
        var entity = new BINA
        {
            BINA_KODU = dto.BINA_KODU,
            BINA_ADI = dto.BINA_ADI,
            BINA_ADRESI = dto.BINA_ADRESI,
            SKRS_KURUM_KODU = dto.SKRS_KURUM_KODU,
        };

        _db.Set<BINA>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.BINA_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Bina)]
    public async Task<IActionResult> Update(string id, BinaDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<BINA>()
            .FirstOrDefaultAsync(e => e.BINA_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.BINA_ADI = dto.BINA_ADI;
        entity.BINA_ADRESI = dto.BINA_ADRESI;
        entity.SKRS_KURUM_KODU = dto.SKRS_KURUM_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Bina)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<BINA>()
            .FirstOrDefaultAsync(e => e.BINA_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<BINA>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
