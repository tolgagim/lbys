using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.TetkikCihazEslesme;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class TetkikCihazEslesmeController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public TetkikCihazEslesmeController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.TetkikCihazEslesme)]
    public async Task<List<TetkikCihazEslesmeDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<TETKIK_CIHAZ_ESLESME>()
            .AsNoTracking()
            .Select(e => new TetkikCihazEslesmeDto
            {
                TETKIK_CIHAZ_ESLESME_KODU = e.TETKIK_CIHAZ_ESLESME_KODU,
CIHAZ_KODU = e.CIHAZ_KODU,
                TETKIK_KODU = e.TETKIK_KODU,
                TETKIK_PARAMETRE_KODU = e.TETKIK_PARAMETRE_KODU,
                CIHAZDAN_GELEN_TEST_KODU = e.CIHAZDAN_GELEN_TEST_KODU,
                CIHAZA_GIDEN_TEST_KODU = e.CIHAZA_GIDEN_TEST_KODU,
                IPTAL_DURUMU = e.IPTAL_DURUMU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.TetkikCihazEslesme)]
    public async Task<ActionResult<TetkikCihazEslesmeDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<TETKIK_CIHAZ_ESLESME>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.TETKIK_CIHAZ_ESLESME_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new TetkikCihazEslesmeDto
        {
            TETKIK_CIHAZ_ESLESME_KODU = entity.TETKIK_CIHAZ_ESLESME_KODU,
CIHAZ_KODU = entity.CIHAZ_KODU,
            TETKIK_KODU = entity.TETKIK_KODU,
            TETKIK_PARAMETRE_KODU = entity.TETKIK_PARAMETRE_KODU,
            CIHAZDAN_GELEN_TEST_KODU = entity.CIHAZDAN_GELEN_TEST_KODU,
            CIHAZA_GIDEN_TEST_KODU = entity.CIHAZA_GIDEN_TEST_KODU,
            IPTAL_DURUMU = entity.IPTAL_DURUMU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.TetkikCihazEslesme)]
    public async Task<ActionResult<string>> Create(TetkikCihazEslesmeDto dto, CancellationToken ct)
    {
        var entity = new TETKIK_CIHAZ_ESLESME
        {
            TETKIK_CIHAZ_ESLESME_KODU = dto.TETKIK_CIHAZ_ESLESME_KODU,
CIHAZ_KODU = dto.CIHAZ_KODU,
            TETKIK_KODU = dto.TETKIK_KODU,
            TETKIK_PARAMETRE_KODU = dto.TETKIK_PARAMETRE_KODU,
            CIHAZDAN_GELEN_TEST_KODU = dto.CIHAZDAN_GELEN_TEST_KODU,
            CIHAZA_GIDEN_TEST_KODU = dto.CIHAZA_GIDEN_TEST_KODU,
            IPTAL_DURUMU = dto.IPTAL_DURUMU,
        };

        _db.Set<TETKIK_CIHAZ_ESLESME>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.TETKIK_CIHAZ_ESLESME_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.TetkikCihazEslesme)]
    public async Task<IActionResult> Update(string id, TetkikCihazEslesmeDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<TETKIK_CIHAZ_ESLESME>()
            .FirstOrDefaultAsync(e => e.TETKIK_CIHAZ_ESLESME_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.CIHAZ_KODU = dto.CIHAZ_KODU;
        entity.TETKIK_KODU = dto.TETKIK_KODU;
        entity.TETKIK_PARAMETRE_KODU = dto.TETKIK_PARAMETRE_KODU;
        entity.CIHAZDAN_GELEN_TEST_KODU = dto.CIHAZDAN_GELEN_TEST_KODU;
        entity.CIHAZA_GIDEN_TEST_KODU = dto.CIHAZA_GIDEN_TEST_KODU;
        entity.IPTAL_DURUMU = dto.IPTAL_DURUMU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.TetkikCihazEslesme)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<TETKIK_CIHAZ_ESLESME>()
            .FirstOrDefaultAsync(e => e.TETKIK_CIHAZ_ESLESME_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<TETKIK_CIHAZ_ESLESME>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
