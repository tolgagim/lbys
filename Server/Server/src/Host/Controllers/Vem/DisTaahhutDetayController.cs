using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.DisTaahhutDetay;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class DisTaahhutDetayController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public DisTaahhutDetayController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.DisTaahhutDetay)]
    public async Task<List<DisTaahhutDetayDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<DIS_TAAHHUT_DETAY>()
            .AsNoTracking()
            .Select(e => new DisTaahhutDetayDto
            {
                DIS_TAAHHUT_DETAY_KODU = e.DIS_TAAHHUT_DETAY_KODU,
DIS_TAAHHUT_KODU = e.DIS_TAAHHUT_KODU,
                DIS_KODU = e.DIS_KODU,
                SUT_KODU = e.SUT_KODU,
                CENE_KODU = e.CENE_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.DisTaahhutDetay)]
    public async Task<ActionResult<DisTaahhutDetayDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<DIS_TAAHHUT_DETAY>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.DIS_TAAHHUT_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new DisTaahhutDetayDto
        {
            DIS_TAAHHUT_DETAY_KODU = entity.DIS_TAAHHUT_DETAY_KODU,
DIS_TAAHHUT_KODU = entity.DIS_TAAHHUT_KODU,
            DIS_KODU = entity.DIS_KODU,
            SUT_KODU = entity.SUT_KODU,
            CENE_KODU = entity.CENE_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.DisTaahhutDetay)]
    public async Task<ActionResult<string>> Create(DisTaahhutDetayDto dto, CancellationToken ct)
    {
        var entity = new DIS_TAAHHUT_DETAY
        {
            DIS_TAAHHUT_DETAY_KODU = dto.DIS_TAAHHUT_DETAY_KODU,
DIS_TAAHHUT_KODU = dto.DIS_TAAHHUT_KODU,
            DIS_KODU = dto.DIS_KODU,
            SUT_KODU = dto.SUT_KODU,
            CENE_KODU = dto.CENE_KODU,
        };

        _db.Set<DIS_TAAHHUT_DETAY>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.DIS_TAAHHUT_DETAY_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.DisTaahhutDetay)]
    public async Task<IActionResult> Update(string id, DisTaahhutDetayDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<DIS_TAAHHUT_DETAY>()
            .FirstOrDefaultAsync(e => e.DIS_TAAHHUT_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.DIS_TAAHHUT_KODU = dto.DIS_TAAHHUT_KODU;
        entity.DIS_KODU = dto.DIS_KODU;
        entity.SUT_KODU = dto.SUT_KODU;
        entity.CENE_KODU = dto.CENE_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.DisTaahhutDetay)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<DIS_TAAHHUT_DETAY>()
            .FirstOrDefaultAsync(e => e.DIS_TAAHHUT_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<DIS_TAAHHUT_DETAY>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
