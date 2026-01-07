using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.GrupUyelik;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class GrupUyelikController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public GrupUyelikController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.GrupUyelik)]
    public async Task<List<GrupUyelikDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<GRUP_UYELIK>()
            .AsNoTracking()
            .Select(e => new GrupUyelikDto
            {
                GRUP_UYELIK_KODU = e.GRUP_UYELIK_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                KULLANICI_GRUP_KODU = e.KULLANICI_GRUP_KODU,
                KULLANICI_KODU = e.KULLANICI_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.GrupUyelik)]
    public async Task<ActionResult<GrupUyelikDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<GRUP_UYELIK>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.GRUP_UYELIK_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new GrupUyelikDto
        {
            GRUP_UYELIK_KODU = entity.GRUP_UYELIK_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            KULLANICI_GRUP_KODU = entity.KULLANICI_GRUP_KODU,
            KULLANICI_KODU = entity.KULLANICI_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.GrupUyelik)]
    public async Task<ActionResult<string>> Create(GrupUyelikDto dto, CancellationToken ct)
    {
        var entity = new GRUP_UYELIK
        {
            GRUP_UYELIK_KODU = dto.GRUP_UYELIK_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            KULLANICI_GRUP_KODU = dto.KULLANICI_GRUP_KODU,
            KULLANICI_KODU = dto.KULLANICI_KODU,
        };

        _db.Set<GRUP_UYELIK>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.GRUP_UYELIK_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.GrupUyelik)]
    public async Task<IActionResult> Update(string id, GrupUyelikDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<GRUP_UYELIK>()
            .FirstOrDefaultAsync(e => e.GRUP_UYELIK_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.KULLANICI_GRUP_KODU = dto.KULLANICI_GRUP_KODU;
        entity.KULLANICI_KODU = dto.KULLANICI_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.GrupUyelik)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<GRUP_UYELIK>()
            .FirstOrDefaultAsync(e => e.GRUP_UYELIK_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<GRUP_UYELIK>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
