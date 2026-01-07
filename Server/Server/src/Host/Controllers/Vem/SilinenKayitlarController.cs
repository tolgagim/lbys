using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.SilinenKayitlar;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class SilinenKayitlarController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public SilinenKayitlarController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.SilinenKayitlar)]
    public async Task<List<SilinenKayitlarDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<SILINEN_KAYITLAR>()
            .AsNoTracking()
            .Select(e => new SilinenKayitlarDto
            {
                SILINEN_KAYITLAR_KODU = e.SILINEN_KAYITLAR_KODU,
                REFERANS_GORUNTU_ADI = e.REFERANS_GORUNTU_ADI,
                SILINME_ZAMANI = e.SILINME_ZAMANI,
                SILINEN_KAYDIN_KODU = e.SILINEN_KAYDIN_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.SilinenKayitlar)]
    public async Task<ActionResult<SilinenKayitlarDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<SILINEN_KAYITLAR>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.SILINEN_KAYITLAR_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new SilinenKayitlarDto
        {
            SILINEN_KAYITLAR_KODU = entity.SILINEN_KAYITLAR_KODU,
            REFERANS_GORUNTU_ADI = entity.REFERANS_GORUNTU_ADI,
            SILINME_ZAMANI = entity.SILINME_ZAMANI,
            SILINEN_KAYDIN_KODU = entity.SILINEN_KAYDIN_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.SilinenKayitlar)]
    public async Task<ActionResult<string>> Create(SilinenKayitlarDto dto, CancellationToken ct)
    {
        var entity = new SILINEN_KAYITLAR
        {
            SILINEN_KAYITLAR_KODU = dto.SILINEN_KAYITLAR_KODU,
            REFERANS_GORUNTU_ADI = dto.REFERANS_GORUNTU_ADI,
            SILINME_ZAMANI = dto.SILINME_ZAMANI,
            SILINEN_KAYDIN_KODU = dto.SILINEN_KAYDIN_KODU,
        };

        _db.Set<SILINEN_KAYITLAR>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.SILINEN_KAYITLAR_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.SilinenKayitlar)]
    public async Task<IActionResult> Update(string id, SilinenKayitlarDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<SILINEN_KAYITLAR>()
            .FirstOrDefaultAsync(e => e.SILINEN_KAYITLAR_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_GORUNTU_ADI = dto.REFERANS_GORUNTU_ADI;
        entity.SILINME_ZAMANI = dto.SILINME_ZAMANI;
        entity.SILINEN_KAYDIN_KODU = dto.SILINEN_KAYDIN_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.SilinenKayitlar)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<SILINEN_KAYITLAR>()
            .FirstOrDefaultAsync(e => e.SILINEN_KAYITLAR_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<SILINEN_KAYITLAR>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
