using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Birim;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class BirimController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public BirimController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Birim)]
    public async Task<List<BirimDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<BIRIM>()
            .AsNoTracking()
            .Select(e => new BirimDto
            {
                BIRIM_KODU = e.BIRIM_KODU,
                BIRIM_ADI = e.BIRIM_ADI,
                BIRIM_TURU = e.BIRIM_TURU,
                UST_BIRIM_KODU = e.UST_BIRIM_KODU,
                KURUM_KODU = e.KURUM_KODU,
                AKTIF = e.AKTIF,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Birim)]
    public async Task<ActionResult<BirimDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<BIRIM>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.BIRIM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new BirimDto
        {
            BIRIM_KODU = entity.BIRIM_KODU,
            BIRIM_ADI = entity.BIRIM_ADI,
            BIRIM_TURU = entity.BIRIM_TURU,
            UST_BIRIM_KODU = entity.UST_BIRIM_KODU,
            KURUM_KODU = entity.KURUM_KODU,
            AKTIF = entity.AKTIF,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Birim)]
    public async Task<ActionResult<string>> Create(BirimDto dto, CancellationToken ct)
    {
        var entity = new BIRIM
        {
            BIRIM_KODU = dto.BIRIM_KODU,
            BIRIM_ADI = dto.BIRIM_ADI,
            BIRIM_TURU = dto.BIRIM_TURU,
            UST_BIRIM_KODU = dto.UST_BIRIM_KODU,
            KURUM_KODU = dto.KURUM_KODU,
            AKTIF = dto.AKTIF,
        };

        _db.Set<BIRIM>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.BIRIM_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Birim)]
    public async Task<IActionResult> Update(string id, BirimDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<BIRIM>()
            .FirstOrDefaultAsync(e => e.BIRIM_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.BIRIM_ADI = dto.BIRIM_ADI;
        entity.BIRIM_TURU = dto.BIRIM_TURU;
        entity.UST_BIRIM_KODU = dto.UST_BIRIM_KODU;
        entity.KURUM_KODU = dto.KURUM_KODU;
        entity.AKTIF = dto.AKTIF;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Birim)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<BIRIM>()
            .FirstOrDefaultAsync(e => e.BIRIM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<BIRIM>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
