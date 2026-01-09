using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.StokIstek;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class StokIstekController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public StokIstekController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.StokIstek)]
    public async Task<List<StokIstekDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<STOK_ISTEK>()
            .AsNoTracking()
            .Select(e => new StokIstekDto
            {
                STOK_ISTEK_KODU = e.STOK_ISTEK_KODU,
HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                HASTA_KODU = e.HASTA_KODU,
                ISTEK_ZAMANI = e.ISTEK_ZAMANI,
                ISTEK_DEPO_KODU = e.ISTEK_DEPO_KODU,
                HEKIM_KODU = e.HEKIM_KODU,
                STOK_ISTEK_DURUMU = e.STOK_ISTEK_DURUMU,
                STOK_ISTEK_HEKIM_ACIKLAMA = e.STOK_ISTEK_HEKIM_ACIKLAMA,
                AMELIYAT_KODU = e.AMELIYAT_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.StokIstek)]
    public async Task<ActionResult<StokIstekDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STOK_ISTEK>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.STOK_ISTEK_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new StokIstekDto
        {
            STOK_ISTEK_KODU = entity.STOK_ISTEK_KODU,
HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            HASTA_KODU = entity.HASTA_KODU,
            ISTEK_ZAMANI = entity.ISTEK_ZAMANI,
            ISTEK_DEPO_KODU = entity.ISTEK_DEPO_KODU,
            HEKIM_KODU = entity.HEKIM_KODU,
            STOK_ISTEK_DURUMU = entity.STOK_ISTEK_DURUMU,
            STOK_ISTEK_HEKIM_ACIKLAMA = entity.STOK_ISTEK_HEKIM_ACIKLAMA,
            AMELIYAT_KODU = entity.AMELIYAT_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.StokIstek)]
    public async Task<ActionResult<string>> Create(StokIstekDto dto, CancellationToken ct)
    {
        var entity = new STOK_ISTEK
        {
            STOK_ISTEK_KODU = dto.STOK_ISTEK_KODU,
HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            HASTA_KODU = dto.HASTA_KODU,
            ISTEK_ZAMANI = dto.ISTEK_ZAMANI,
            ISTEK_DEPO_KODU = dto.ISTEK_DEPO_KODU,
            HEKIM_KODU = dto.HEKIM_KODU,
            STOK_ISTEK_DURUMU = dto.STOK_ISTEK_DURUMU,
            STOK_ISTEK_HEKIM_ACIKLAMA = dto.STOK_ISTEK_HEKIM_ACIKLAMA,
            AMELIYAT_KODU = dto.AMELIYAT_KODU,
        };

        _db.Set<STOK_ISTEK>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.STOK_ISTEK_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.StokIstek)]
    public async Task<IActionResult> Update(string id, StokIstekDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<STOK_ISTEK>()
            .FirstOrDefaultAsync(e => e.STOK_ISTEK_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.ISTEK_ZAMANI = dto.ISTEK_ZAMANI;
        entity.ISTEK_DEPO_KODU = dto.ISTEK_DEPO_KODU;
        entity.HEKIM_KODU = dto.HEKIM_KODU;
        entity.STOK_ISTEK_DURUMU = dto.STOK_ISTEK_DURUMU;
        entity.STOK_ISTEK_HEKIM_ACIKLAMA = dto.STOK_ISTEK_HEKIM_ACIKLAMA;
        entity.AMELIYAT_KODU = dto.AMELIYAT_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.StokIstek)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STOK_ISTEK>()
            .FirstOrDefaultAsync(e => e.STOK_ISTEK_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<STOK_ISTEK>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
