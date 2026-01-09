using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.HastaNotlari;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class HastaNotlariController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public HastaNotlariController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.HastaNotlari)]
    public async Task<List<HastaNotlariDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<HASTA_NOTLARI>()
            .AsNoTracking()
            .Select(e => new HastaNotlariDto
            {
                HASTA_NOTLARI_KODU = e.HASTA_NOTLARI_KODU,
HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                HASTA_NOT_TURU = e.HASTA_NOT_TURU,
                PERSONEL_KODU = e.PERSONEL_KODU,
                HASTA_NOT_ACIKLAMASI = e.HASTA_NOT_ACIKLAMASI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.HastaNotlari)]
    public async Task<ActionResult<HastaNotlariDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_NOTLARI>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.HASTA_NOTLARI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new HastaNotlariDto
        {
            HASTA_NOTLARI_KODU = entity.HASTA_NOTLARI_KODU,
HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            HASTA_NOT_TURU = entity.HASTA_NOT_TURU,
            PERSONEL_KODU = entity.PERSONEL_KODU,
            HASTA_NOT_ACIKLAMASI = entity.HASTA_NOT_ACIKLAMASI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.HastaNotlari)]
    public async Task<ActionResult<string>> Create(HastaNotlariDto dto, CancellationToken ct)
    {
        var entity = new HASTA_NOTLARI
        {
            HASTA_NOTLARI_KODU = dto.HASTA_NOTLARI_KODU,
HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            HASTA_NOT_TURU = dto.HASTA_NOT_TURU,
            PERSONEL_KODU = dto.PERSONEL_KODU,
            HASTA_NOT_ACIKLAMASI = dto.HASTA_NOT_ACIKLAMASI,
        };

        _db.Set<HASTA_NOTLARI>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.HASTA_NOTLARI_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.HastaNotlari)]
    public async Task<IActionResult> Update(string id, HastaNotlariDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_NOTLARI>()
            .FirstOrDefaultAsync(e => e.HASTA_NOTLARI_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.HASTA_NOT_TURU = dto.HASTA_NOT_TURU;
        entity.PERSONEL_KODU = dto.PERSONEL_KODU;
        entity.HASTA_NOT_ACIKLAMASI = dto.HASTA_NOT_ACIKLAMASI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.HastaNotlari)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_NOTLARI>()
            .FirstOrDefaultAsync(e => e.HASTA_NOTLARI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<HASTA_NOTLARI>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
