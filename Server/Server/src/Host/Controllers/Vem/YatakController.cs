using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Yatak;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class YatakController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public YatakController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Yatak)]
    public async Task<List<YatakDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<YATAK>()
            .AsNoTracking()
            .Select(e => new YatakDto
            {
                YATAK_KODU = e.YATAK_KODU,
                YATAK_ADI = e.YATAK_ADI,
                ODA_KODU = e.ODA_KODU,
                YATAK_TURU = e.YATAK_TURU,
                YOGUN_BAKIM_YATAK_SEVIYESI = e.YOGUN_BAKIM_YATAK_SEVIYESI,
                VENTILATOR_CIHAZ_KODU = e.VENTILATOR_CIHAZ_KODU,
                AKTIF = e.AKTIF,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Yatak)]
    public async Task<ActionResult<YatakDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<YATAK>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.YATAK_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new YatakDto
        {
            YATAK_KODU = entity.YATAK_KODU,
            YATAK_ADI = entity.YATAK_ADI,
            ODA_KODU = entity.ODA_KODU,
            YATAK_TURU = entity.YATAK_TURU,
            YOGUN_BAKIM_YATAK_SEVIYESI = entity.YOGUN_BAKIM_YATAK_SEVIYESI,
            VENTILATOR_CIHAZ_KODU = entity.VENTILATOR_CIHAZ_KODU,
            AKTIF = entity.AKTIF,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Yatak)]
    public async Task<ActionResult<string>> Create(YatakDto dto, CancellationToken ct)
    {
        var entity = new YATAK
        {
            YATAK_KODU = dto.YATAK_KODU,
            YATAK_ADI = dto.YATAK_ADI,
            ODA_KODU = dto.ODA_KODU,
            YATAK_TURU = dto.YATAK_TURU,
            YOGUN_BAKIM_YATAK_SEVIYESI = dto.YOGUN_BAKIM_YATAK_SEVIYESI,
            VENTILATOR_CIHAZ_KODU = dto.VENTILATOR_CIHAZ_KODU,
            AKTIF = dto.AKTIF,
        };

        _db.Set<YATAK>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.YATAK_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Yatak)]
    public async Task<IActionResult> Update(string id, YatakDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<YATAK>()
            .FirstOrDefaultAsync(e => e.YATAK_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.YATAK_ADI = dto.YATAK_ADI;
        entity.ODA_KODU = dto.ODA_KODU;
        entity.YATAK_TURU = dto.YATAK_TURU;
        entity.YOGUN_BAKIM_YATAK_SEVIYESI = dto.YOGUN_BAKIM_YATAK_SEVIYESI;
        entity.VENTILATOR_CIHAZ_KODU = dto.VENTILATOR_CIHAZ_KODU;
        entity.AKTIF = dto.AKTIF;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Yatak)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<YATAK>()
            .FirstOrDefaultAsync(e => e.YATAK_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<YATAK>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
