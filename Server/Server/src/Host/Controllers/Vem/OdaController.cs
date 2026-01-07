using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Oda;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class OdaController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public OdaController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Oda)]
    public async Task<List<OdaDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<ODA>()
            .AsNoTracking()
            .Select(e => new OdaDto
            {
                ODA_KODU = e.ODA_KODU,
                ODA_ADI = e.ODA_ADI,
                BIRIM_KODU = e.BIRIM_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Oda)]
    public async Task<ActionResult<OdaDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<ODA>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.ODA_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new OdaDto
        {
            ODA_KODU = entity.ODA_KODU,
            ODA_ADI = entity.ODA_ADI,
            BIRIM_KODU = entity.BIRIM_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Oda)]
    public async Task<ActionResult<string>> Create(OdaDto dto, CancellationToken ct)
    {
        var entity = new ODA
        {
            ODA_KODU = dto.ODA_KODU,
            ODA_ADI = dto.ODA_ADI,
            BIRIM_KODU = dto.BIRIM_KODU,
        };

        _db.Set<ODA>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.ODA_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Oda)]
    public async Task<IActionResult> Update(string id, OdaDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<ODA>()
            .FirstOrDefaultAsync(e => e.ODA_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.ODA_ADI = dto.ODA_ADI;
        entity.BIRIM_KODU = dto.BIRIM_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Oda)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<ODA>()
            .FirstOrDefaultAsync(e => e.ODA_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<ODA>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
