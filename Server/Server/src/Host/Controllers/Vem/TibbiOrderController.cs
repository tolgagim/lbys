using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.TibbiOrder;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class TibbiOrderController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public TibbiOrderController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.TibbiOrder)]
    public async Task<List<TibbiOrderDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<TIBBI_ORDER>()
            .AsNoTracking()
            .Select(e => new TibbiOrderDto
            {
                TIBBI_ORDER_KODU = e.TIBBI_ORDER_KODU,
HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                TIBBI_ORDER_TURU = e.TIBBI_ORDER_TURU,
                ORDER_ZAMANI = e.ORDER_ZAMANI,
                HEKIM_KODU = e.HEKIM_KODU,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.TibbiOrder)]
    public async Task<ActionResult<TibbiOrderDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<TIBBI_ORDER>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.TIBBI_ORDER_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new TibbiOrderDto
        {
            TIBBI_ORDER_KODU = entity.TIBBI_ORDER_KODU,
HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            TIBBI_ORDER_TURU = entity.TIBBI_ORDER_TURU,
            ORDER_ZAMANI = entity.ORDER_ZAMANI,
            HEKIM_KODU = entity.HEKIM_KODU,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.TibbiOrder)]
    public async Task<ActionResult<string>> Create(TibbiOrderDto dto, CancellationToken ct)
    {
        var entity = new TIBBI_ORDER
        {
            TIBBI_ORDER_KODU = dto.TIBBI_ORDER_KODU,
HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            TIBBI_ORDER_TURU = dto.TIBBI_ORDER_TURU,
            ORDER_ZAMANI = dto.ORDER_ZAMANI,
            HEKIM_KODU = dto.HEKIM_KODU,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<TIBBI_ORDER>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.TIBBI_ORDER_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.TibbiOrder)]
    public async Task<IActionResult> Update(string id, TibbiOrderDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<TIBBI_ORDER>()
            .FirstOrDefaultAsync(e => e.TIBBI_ORDER_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.TIBBI_ORDER_TURU = dto.TIBBI_ORDER_TURU;
        entity.ORDER_ZAMANI = dto.ORDER_ZAMANI;
        entity.HEKIM_KODU = dto.HEKIM_KODU;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.TibbiOrder)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<TIBBI_ORDER>()
            .FirstOrDefaultAsync(e => e.TIBBI_ORDER_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<TIBBI_ORDER>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
