using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Kullanici;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class KullaniciController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public KullaniciController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Kullanici)]
    public async Task<List<KullaniciDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<KULLANICI>()
            .AsNoTracking()
            .Select(e => new KullaniciDto
            {
                KULLANICI_KODU = e.KULLANICI_KODU,
                PERSONEL_KODU = e.PERSONEL_KODU,
                KULLANICI_ADI = e.KULLANICI_ADI,
                AKTIF = e.AKTIF,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Kullanici)]
    public async Task<ActionResult<KullaniciDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KULLANICI>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.KULLANICI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new KullaniciDto
        {
            KULLANICI_KODU = entity.KULLANICI_KODU,
            PERSONEL_KODU = entity.PERSONEL_KODU,
            KULLANICI_ADI = entity.KULLANICI_ADI,
            AKTIF = entity.AKTIF,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Kullanici)]
    public async Task<ActionResult<string>> Create(KullaniciDto dto, CancellationToken ct)
    {
        var entity = new KULLANICI
        {
            KULLANICI_KODU = dto.KULLANICI_KODU,
            PERSONEL_KODU = dto.PERSONEL_KODU,
            KULLANICI_ADI = dto.KULLANICI_ADI,
            AKTIF = dto.AKTIF,
        };

        _db.Set<KULLANICI>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.KULLANICI_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Kullanici)]
    public async Task<IActionResult> Update(string id, KullaniciDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<KULLANICI>()
            .FirstOrDefaultAsync(e => e.KULLANICI_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.PERSONEL_KODU = dto.PERSONEL_KODU;
        entity.KULLANICI_ADI = dto.KULLANICI_ADI;
        entity.AKTIF = dto.AKTIF;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Kullanici)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KULLANICI>()
            .FirstOrDefaultAsync(e => e.KULLANICI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<KULLANICI>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
