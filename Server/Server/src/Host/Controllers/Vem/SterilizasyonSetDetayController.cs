using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.SterilizasyonSetDetay;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class SterilizasyonSetDetayController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public SterilizasyonSetDetayController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.SterilizasyonSetDetay)]
    public async Task<List<SterilizasyonSetDetayDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<STERILIZASYON_SET_DETAY>()
            .AsNoTracking()
            .Select(e => new SterilizasyonSetDetayDto
            {
                STERILIZASYON_SET_DETAY_KODU = e.STERILIZASYON_SET_DETAY_KODU,
STERILIZASYON_SET_KODU = e.STERILIZASYON_SET_KODU,
                STOK_KART_KODU = e.STOK_KART_KODU,
                STERILIZASYON_MALZEME_MIKTARI = e.STERILIZASYON_MALZEME_MIKTARI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.SterilizasyonSetDetay)]
    public async Task<ActionResult<SterilizasyonSetDetayDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STERILIZASYON_SET_DETAY>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.STERILIZASYON_SET_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new SterilizasyonSetDetayDto
        {
            STERILIZASYON_SET_DETAY_KODU = entity.STERILIZASYON_SET_DETAY_KODU,
STERILIZASYON_SET_KODU = entity.STERILIZASYON_SET_KODU,
            STOK_KART_KODU = entity.STOK_KART_KODU,
            STERILIZASYON_MALZEME_MIKTARI = entity.STERILIZASYON_MALZEME_MIKTARI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.SterilizasyonSetDetay)]
    public async Task<ActionResult<string>> Create(SterilizasyonSetDetayDto dto, CancellationToken ct)
    {
        var entity = new STERILIZASYON_SET_DETAY
        {
            STERILIZASYON_SET_DETAY_KODU = dto.STERILIZASYON_SET_DETAY_KODU,
STERILIZASYON_SET_KODU = dto.STERILIZASYON_SET_KODU,
            STOK_KART_KODU = dto.STOK_KART_KODU,
            STERILIZASYON_MALZEME_MIKTARI = dto.STERILIZASYON_MALZEME_MIKTARI,
        };

        _db.Set<STERILIZASYON_SET_DETAY>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.STERILIZASYON_SET_DETAY_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.SterilizasyonSetDetay)]
    public async Task<IActionResult> Update(string id, SterilizasyonSetDetayDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<STERILIZASYON_SET_DETAY>()
            .FirstOrDefaultAsync(e => e.STERILIZASYON_SET_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.STERILIZASYON_SET_KODU = dto.STERILIZASYON_SET_KODU;
        entity.STOK_KART_KODU = dto.STOK_KART_KODU;
        entity.STERILIZASYON_MALZEME_MIKTARI = dto.STERILIZASYON_MALZEME_MIKTARI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.SterilizasyonSetDetay)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STERILIZASYON_SET_DETAY>()
            .FirstOrDefaultAsync(e => e.STERILIZASYON_SET_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<STERILIZASYON_SET_DETAY>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
