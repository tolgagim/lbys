using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.ReferansKodlar;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class ReferansKodlarController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public ReferansKodlarController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.ReferansKodlar)]
    public async Task<List<ReferansKodlarDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<REFERANS_KODLAR>()
            .AsNoTracking()
            .Select(e => new ReferansKodlarDto
            {
                REFERANS_KODU = e.REFERANS_KODU,
                KOD_TURU = e.KOD_TURU,
                REFERANS_ADI = e.REFERANS_ADI,
                SKRS_KODU = e.SKRS_KODU,
                MEDULA_KODU = e.MEDULA_KODU,
                MKYS_KODU = e.MKYS_KODU,
                TIG_KODU = e.TIG_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.ReferansKodlar)]
    public async Task<ActionResult<ReferansKodlarDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<REFERANS_KODLAR>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.REFERANS_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new ReferansKodlarDto
        {
            REFERANS_KODU = entity.REFERANS_KODU,
            KOD_TURU = entity.KOD_TURU,
            REFERANS_ADI = entity.REFERANS_ADI,
            SKRS_KODU = entity.SKRS_KODU,
            MEDULA_KODU = entity.MEDULA_KODU,
            MKYS_KODU = entity.MKYS_KODU,
            TIG_KODU = entity.TIG_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.ReferansKodlar)]
    public async Task<ActionResult<string>> Create(ReferansKodlarDto dto, CancellationToken ct)
    {
        var entity = new REFERANS_KODLAR
        {
            REFERANS_KODU = dto.REFERANS_KODU,
            KOD_TURU = dto.KOD_TURU,
            REFERANS_ADI = dto.REFERANS_ADI,
            SKRS_KODU = dto.SKRS_KODU,
            MEDULA_KODU = dto.MEDULA_KODU,
            MKYS_KODU = dto.MKYS_KODU,
            TIG_KODU = dto.TIG_KODU,
        };

        _db.Set<REFERANS_KODLAR>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.REFERANS_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.ReferansKodlar)]
    public async Task<IActionResult> Update(string id, ReferansKodlarDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<REFERANS_KODLAR>()
            .FirstOrDefaultAsync(e => e.REFERANS_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.KOD_TURU = dto.KOD_TURU;
        entity.REFERANS_ADI = dto.REFERANS_ADI;
        entity.SKRS_KODU = dto.SKRS_KODU;
        entity.MEDULA_KODU = dto.MEDULA_KODU;
        entity.MKYS_KODU = dto.MKYS_KODU;
        entity.TIG_KODU = dto.TIG_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.ReferansKodlar)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<REFERANS_KODLAR>()
            .FirstOrDefaultAsync(e => e.REFERANS_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<REFERANS_KODLAR>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
