using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.HastaVentilator;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class HastaVentilatorController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public HastaVentilatorController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.HastaVentilator)]
    public async Task<List<HastaVentilatorDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<HASTA_VENTILATOR>()
            .AsNoTracking()
            .Select(e => new HastaVentilatorDto
            {
                HASTA_VENTILATOR_KODU = e.HASTA_VENTILATOR_KODU,
HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                VENTILATOR_CIHAZ_KODU = e.VENTILATOR_CIHAZ_KODU,
                YOGUN_BAKIM_SEVIYE_BILGISI = e.YOGUN_BAKIM_SEVIYE_BILGISI,
                VENTILATOR_BAGLAMA_ZAMANI = e.VENTILATOR_BAGLAMA_ZAMANI,
                VENTILATOR_AYRILMA_ZAMANI = e.VENTILATOR_AYRILMA_ZAMANI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.HastaVentilator)]
    public async Task<ActionResult<HastaVentilatorDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_VENTILATOR>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.HASTA_VENTILATOR_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new HastaVentilatorDto
        {
            HASTA_VENTILATOR_KODU = entity.HASTA_VENTILATOR_KODU,
HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            VENTILATOR_CIHAZ_KODU = entity.VENTILATOR_CIHAZ_KODU,
            YOGUN_BAKIM_SEVIYE_BILGISI = entity.YOGUN_BAKIM_SEVIYE_BILGISI,
            VENTILATOR_BAGLAMA_ZAMANI = entity.VENTILATOR_BAGLAMA_ZAMANI,
            VENTILATOR_AYRILMA_ZAMANI = entity.VENTILATOR_AYRILMA_ZAMANI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.HastaVentilator)]
    public async Task<ActionResult<string>> Create(HastaVentilatorDto dto, CancellationToken ct)
    {
        var entity = new HASTA_VENTILATOR
        {
            HASTA_VENTILATOR_KODU = dto.HASTA_VENTILATOR_KODU,
HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            VENTILATOR_CIHAZ_KODU = dto.VENTILATOR_CIHAZ_KODU,
            YOGUN_BAKIM_SEVIYE_BILGISI = dto.YOGUN_BAKIM_SEVIYE_BILGISI,
            VENTILATOR_BAGLAMA_ZAMANI = dto.VENTILATOR_BAGLAMA_ZAMANI,
            VENTILATOR_AYRILMA_ZAMANI = dto.VENTILATOR_AYRILMA_ZAMANI,
        };

        _db.Set<HASTA_VENTILATOR>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.HASTA_VENTILATOR_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.HastaVentilator)]
    public async Task<IActionResult> Update(string id, HastaVentilatorDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_VENTILATOR>()
            .FirstOrDefaultAsync(e => e.HASTA_VENTILATOR_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.VENTILATOR_CIHAZ_KODU = dto.VENTILATOR_CIHAZ_KODU;
        entity.YOGUN_BAKIM_SEVIYE_BILGISI = dto.YOGUN_BAKIM_SEVIYE_BILGISI;
        entity.VENTILATOR_BAGLAMA_ZAMANI = dto.VENTILATOR_BAGLAMA_ZAMANI;
        entity.VENTILATOR_AYRILMA_ZAMANI = dto.VENTILATOR_AYRILMA_ZAMANI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.HastaVentilator)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_VENTILATOR>()
            .FirstOrDefaultAsync(e => e.HASTA_VENTILATOR_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<HASTA_VENTILATOR>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
