using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.KlinikSeyir;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class KlinikSeyirController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public KlinikSeyirController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.KlinikSeyir)]
    public async Task<List<KlinikSeyirDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<KLINIK_SEYIR>()
            .AsNoTracking()
            .Select(e => new KlinikSeyirDto
            {
                KLINIK_SEYIR_KODU = e.KLINIK_SEYIR_KODU,
HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                SEYIR_TIPI = e.SEYIR_TIPI,
                SEYIR_ZAMANI = e.SEYIR_ZAMANI,
                SEYIR_BILGISI = e.SEYIR_BILGISI,
                SEPTIK_SOK = e.SEPTIK_SOK,
                SEPSIS_DURUMU = e.SEPSIS_DURUMU,
                HEKIM_KODU = e.HEKIM_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.KlinikSeyir)]
    public async Task<ActionResult<KlinikSeyirDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KLINIK_SEYIR>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.KLINIK_SEYIR_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new KlinikSeyirDto
        {
            KLINIK_SEYIR_KODU = entity.KLINIK_SEYIR_KODU,
HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            SEYIR_TIPI = entity.SEYIR_TIPI,
            SEYIR_ZAMANI = entity.SEYIR_ZAMANI,
            SEYIR_BILGISI = entity.SEYIR_BILGISI,
            SEPTIK_SOK = entity.SEPTIK_SOK,
            SEPSIS_DURUMU = entity.SEPSIS_DURUMU,
            HEKIM_KODU = entity.HEKIM_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.KlinikSeyir)]
    public async Task<ActionResult<string>> Create(KlinikSeyirDto dto, CancellationToken ct)
    {
        var entity = new KLINIK_SEYIR
        {
            KLINIK_SEYIR_KODU = dto.KLINIK_SEYIR_KODU,
HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            SEYIR_TIPI = dto.SEYIR_TIPI,
            SEYIR_ZAMANI = dto.SEYIR_ZAMANI,
            SEYIR_BILGISI = dto.SEYIR_BILGISI,
            SEPTIK_SOK = dto.SEPTIK_SOK,
            SEPSIS_DURUMU = dto.SEPSIS_DURUMU,
            HEKIM_KODU = dto.HEKIM_KODU,
        };

        _db.Set<KLINIK_SEYIR>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.KLINIK_SEYIR_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.KlinikSeyir)]
    public async Task<IActionResult> Update(string id, KlinikSeyirDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<KLINIK_SEYIR>()
            .FirstOrDefaultAsync(e => e.KLINIK_SEYIR_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.SEYIR_TIPI = dto.SEYIR_TIPI;
        entity.SEYIR_ZAMANI = dto.SEYIR_ZAMANI;
        entity.SEYIR_BILGISI = dto.SEYIR_BILGISI;
        entity.SEPTIK_SOK = dto.SEPTIK_SOK;
        entity.SEPSIS_DURUMU = dto.SEPSIS_DURUMU;
        entity.HEKIM_KODU = dto.HEKIM_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.KlinikSeyir)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KLINIK_SEYIR>()
            .FirstOrDefaultAsync(e => e.KLINIK_SEYIR_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<KLINIK_SEYIR>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
