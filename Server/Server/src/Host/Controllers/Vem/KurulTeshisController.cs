using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.KurulTeshis;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class KurulTeshisController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public KurulTeshisController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.KurulTeshis)]
    public async Task<List<KurulTeshisDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<KURUL_TESHIS>()
            .AsNoTracking()
            .Select(e => new KurulTeshisDto
            {
                KURUL_TESHIS_KODU = e.KURUL_TESHIS_KODU,
KURUL_RAPOR_KODU = e.KURUL_RAPOR_KODU,
                ILAC_TESHIS_KODU = e.ILAC_TESHIS_KODU,
                TANI_KODU = e.TANI_KODU,
                RAPOR_BASLAMA_TARIHI = e.RAPOR_BASLAMA_TARIHI,
                RAPOR_BITIS_TARIHI = e.RAPOR_BITIS_TARIHI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.KurulTeshis)]
    public async Task<ActionResult<KurulTeshisDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KURUL_TESHIS>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.KURUL_TESHIS_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new KurulTeshisDto
        {
            KURUL_TESHIS_KODU = entity.KURUL_TESHIS_KODU,
KURUL_RAPOR_KODU = entity.KURUL_RAPOR_KODU,
            ILAC_TESHIS_KODU = entity.ILAC_TESHIS_KODU,
            TANI_KODU = entity.TANI_KODU,
            RAPOR_BASLAMA_TARIHI = entity.RAPOR_BASLAMA_TARIHI,
            RAPOR_BITIS_TARIHI = entity.RAPOR_BITIS_TARIHI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.KurulTeshis)]
    public async Task<ActionResult<string>> Create(KurulTeshisDto dto, CancellationToken ct)
    {
        var entity = new KURUL_TESHIS
        {
            KURUL_TESHIS_KODU = dto.KURUL_TESHIS_KODU,
KURUL_RAPOR_KODU = dto.KURUL_RAPOR_KODU,
            ILAC_TESHIS_KODU = dto.ILAC_TESHIS_KODU,
            TANI_KODU = dto.TANI_KODU,
            RAPOR_BASLAMA_TARIHI = dto.RAPOR_BASLAMA_TARIHI,
            RAPOR_BITIS_TARIHI = dto.RAPOR_BITIS_TARIHI,
        };

        _db.Set<KURUL_TESHIS>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.KURUL_TESHIS_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.KurulTeshis)]
    public async Task<IActionResult> Update(string id, KurulTeshisDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<KURUL_TESHIS>()
            .FirstOrDefaultAsync(e => e.KURUL_TESHIS_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.KURUL_RAPOR_KODU = dto.KURUL_RAPOR_KODU;
        entity.ILAC_TESHIS_KODU = dto.ILAC_TESHIS_KODU;
        entity.TANI_KODU = dto.TANI_KODU;
        entity.RAPOR_BASLAMA_TARIHI = dto.RAPOR_BASLAMA_TARIHI;
        entity.RAPOR_BITIS_TARIHI = dto.RAPOR_BITIS_TARIHI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.KurulTeshis)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KURUL_TESHIS>()
            .FirstOrDefaultAsync(e => e.KURUL_TESHIS_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<KURUL_TESHIS>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
