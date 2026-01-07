using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.HastaYatak;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class HastaYatakController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public HastaYatakController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.HastaYatak)]
    public async Task<List<HastaYatakDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<HASTA_YATAK>()
            .AsNoTracking()
            .Select(e => new HastaYatakDto
            {
                HASTA_YATAK_KODU = e.HASTA_YATAK_KODU,
                HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                YATAK_KODU = e.YATAK_KODU,
                YATIS_BASLAMA_ZAMANI = e.YATIS_BASLAMA_ZAMANI,
                YATIS_BITIS_ZAMANI = e.YATIS_BITIS_ZAMANI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.HastaYatak)]
    public async Task<ActionResult<HastaYatakDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_YATAK>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.HASTA_YATAK_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new HastaYatakDto
        {
            HASTA_YATAK_KODU = entity.HASTA_YATAK_KODU,
            HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            YATAK_KODU = entity.YATAK_KODU,
            YATIS_BASLAMA_ZAMANI = entity.YATIS_BASLAMA_ZAMANI,
            YATIS_BITIS_ZAMANI = entity.YATIS_BITIS_ZAMANI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.HastaYatak)]
    public async Task<ActionResult<string>> Create(HastaYatakDto dto, CancellationToken ct)
    {
        var entity = new HASTA_YATAK
        {
            HASTA_YATAK_KODU = dto.HASTA_YATAK_KODU,
            HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            YATAK_KODU = dto.YATAK_KODU,
            YATIS_BASLAMA_ZAMANI = dto.YATIS_BASLAMA_ZAMANI,
            YATIS_BITIS_ZAMANI = dto.YATIS_BITIS_ZAMANI,
        };

        _db.Set<HASTA_YATAK>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.HASTA_YATAK_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.HastaYatak)]
    public async Task<IActionResult> Update(string id, HastaYatakDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_YATAK>()
            .FirstOrDefaultAsync(e => e.HASTA_YATAK_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.YATAK_KODU = dto.YATAK_KODU;
        entity.YATIS_BASLAMA_ZAMANI = dto.YATIS_BASLAMA_ZAMANI;
        entity.YATIS_BITIS_ZAMANI = dto.YATIS_BITIS_ZAMANI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.HastaYatak)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_YATAK>()
            .FirstOrDefaultAsync(e => e.HASTA_YATAK_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<HASTA_YATAK>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
