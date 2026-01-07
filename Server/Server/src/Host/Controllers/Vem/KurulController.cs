using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Kurul;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class KurulController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public KurulController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Kurul)]
    public async Task<List<KurulDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<KURUL>()
            .AsNoTracking()
            .Select(e => new KurulDto
            {
                KURUL_KODU = e.KURUL_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                KURUL_ADI = e.KURUL_ADI,
                RAPOR_TURU = e.RAPOR_TURU,
                MEDULA_RAPOR_TURU = e.MEDULA_RAPOR_TURU,
                MEDULA_ALT_RAPOR_TURU = e.MEDULA_ALT_RAPOR_TURU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Kurul)]
    public async Task<ActionResult<KurulDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KURUL>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.KURUL_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new KurulDto
        {
            KURUL_KODU = entity.KURUL_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            KURUL_ADI = entity.KURUL_ADI,
            RAPOR_TURU = entity.RAPOR_TURU,
            MEDULA_RAPOR_TURU = entity.MEDULA_RAPOR_TURU,
            MEDULA_ALT_RAPOR_TURU = entity.MEDULA_ALT_RAPOR_TURU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Kurul)]
    public async Task<ActionResult<string>> Create(KurulDto dto, CancellationToken ct)
    {
        var entity = new KURUL
        {
            KURUL_KODU = dto.KURUL_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            KURUL_ADI = dto.KURUL_ADI,
            RAPOR_TURU = dto.RAPOR_TURU,
            MEDULA_RAPOR_TURU = dto.MEDULA_RAPOR_TURU,
            MEDULA_ALT_RAPOR_TURU = dto.MEDULA_ALT_RAPOR_TURU,
        };

        _db.Set<KURUL>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.KURUL_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Kurul)]
    public async Task<IActionResult> Update(string id, KurulDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<KURUL>()
            .FirstOrDefaultAsync(e => e.KURUL_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.KURUL_ADI = dto.KURUL_ADI;
        entity.RAPOR_TURU = dto.RAPOR_TURU;
        entity.MEDULA_RAPOR_TURU = dto.MEDULA_RAPOR_TURU;
        entity.MEDULA_ALT_RAPOR_TURU = dto.MEDULA_ALT_RAPOR_TURU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Kurul)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KURUL>()
            .FirstOrDefaultAsync(e => e.KURUL_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<KURUL>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
