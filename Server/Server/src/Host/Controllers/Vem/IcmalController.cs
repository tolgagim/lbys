using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Icmal;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class IcmalController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public IcmalController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Icmal)]
    public async Task<List<IcmalDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<ICMAL>()
            .AsNoTracking()
            .Select(e => new IcmalDto
            {
                ICMAL_KODU = e.ICMAL_KODU,
                ICMAL_DONEMI = e.ICMAL_DONEMI,
                ICMAL_NUMARASI = e.ICMAL_NUMARASI,
                ICMAL_ADI = e.ICMAL_ADI,
                KURUM_KODU = e.KURUM_KODU,
                ICMAL_ZAMANI = e.ICMAL_ZAMANI,
                ICMAL_TUTARI = e.ICMAL_TUTARI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Icmal)]
    public async Task<ActionResult<IcmalDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<ICMAL>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.ICMAL_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new IcmalDto
        {
            ICMAL_KODU = entity.ICMAL_KODU,
            ICMAL_DONEMI = entity.ICMAL_DONEMI,
            ICMAL_NUMARASI = entity.ICMAL_NUMARASI,
            ICMAL_ADI = entity.ICMAL_ADI,
            KURUM_KODU = entity.KURUM_KODU,
            ICMAL_ZAMANI = entity.ICMAL_ZAMANI,
            ICMAL_TUTARI = entity.ICMAL_TUTARI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Icmal)]
    public async Task<ActionResult<string>> Create(IcmalDto dto, CancellationToken ct)
    {
        var entity = new ICMAL
        {
            ICMAL_KODU = dto.ICMAL_KODU,
            ICMAL_DONEMI = dto.ICMAL_DONEMI,
            ICMAL_NUMARASI = dto.ICMAL_NUMARASI,
            ICMAL_ADI = dto.ICMAL_ADI,
            KURUM_KODU = dto.KURUM_KODU,
            ICMAL_ZAMANI = dto.ICMAL_ZAMANI,
            ICMAL_TUTARI = dto.ICMAL_TUTARI,
        };

        _db.Set<ICMAL>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.ICMAL_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Icmal)]
    public async Task<IActionResult> Update(string id, IcmalDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<ICMAL>()
            .FirstOrDefaultAsync(e => e.ICMAL_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.ICMAL_DONEMI = dto.ICMAL_DONEMI;
        entity.ICMAL_NUMARASI = dto.ICMAL_NUMARASI;
        entity.ICMAL_ADI = dto.ICMAL_ADI;
        entity.KURUM_KODU = dto.KURUM_KODU;
        entity.ICMAL_ZAMANI = dto.ICMAL_ZAMANI;
        entity.ICMAL_TUTARI = dto.ICMAL_TUTARI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Icmal)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<ICMAL>()
            .FirstOrDefaultAsync(e => e.ICMAL_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<ICMAL>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
