using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Tetkik;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class TetkikController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public TetkikController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Tetkik)]
    public async Task<List<TetkikDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<TETKIK>()
            .AsNoTracking()
            .Select(e => new TetkikDto
            {
                TETKIK_KODU = e.TETKIK_KODU,
                TETKIK_ADI = e.TETKIK_ADI,
                LOINC_KODU = e.LOINC_KODU,
                HIZMET_KODU = e.HIZMET_KODU,
                RAPOR_SONUC_SIRASI = e.RAPOR_SONUC_SIRASI,
                HESAPLAMALI_TETKIK_BILGISI = e.HESAPLAMALI_TETKIK_BILGISI,
                HESAPLAMALI_TETKIK_FORMULU = e.HESAPLAMALI_TETKIK_FORMULU,
                IPTAL_DURUMU = e.IPTAL_DURUMU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Tetkik)]
    public async Task<ActionResult<TetkikDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<TETKIK>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.TETKIK_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new TetkikDto
        {
            TETKIK_KODU = entity.TETKIK_KODU,
            TETKIK_ADI = entity.TETKIK_ADI,
            LOINC_KODU = entity.LOINC_KODU,
            HIZMET_KODU = entity.HIZMET_KODU,
            RAPOR_SONUC_SIRASI = entity.RAPOR_SONUC_SIRASI,
            HESAPLAMALI_TETKIK_BILGISI = entity.HESAPLAMALI_TETKIK_BILGISI,
            HESAPLAMALI_TETKIK_FORMULU = entity.HESAPLAMALI_TETKIK_FORMULU,
            IPTAL_DURUMU = entity.IPTAL_DURUMU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Tetkik)]
    public async Task<ActionResult<string>> Create(TetkikDto dto, CancellationToken ct)
    {
        var entity = new TETKIK
        {
            TETKIK_KODU = dto.TETKIK_KODU,
            TETKIK_ADI = dto.TETKIK_ADI,
            LOINC_KODU = dto.LOINC_KODU,
            HIZMET_KODU = dto.HIZMET_KODU,
            RAPOR_SONUC_SIRASI = dto.RAPOR_SONUC_SIRASI,
            HESAPLAMALI_TETKIK_BILGISI = dto.HESAPLAMALI_TETKIK_BILGISI,
            HESAPLAMALI_TETKIK_FORMULU = dto.HESAPLAMALI_TETKIK_FORMULU,
            IPTAL_DURUMU = dto.IPTAL_DURUMU,
        };

        _db.Set<TETKIK>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.TETKIK_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Tetkik)]
    public async Task<IActionResult> Update(string id, TetkikDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<TETKIK>()
            .FirstOrDefaultAsync(e => e.TETKIK_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.TETKIK_ADI = dto.TETKIK_ADI;
        entity.LOINC_KODU = dto.LOINC_KODU;
        entity.HIZMET_KODU = dto.HIZMET_KODU;
        entity.RAPOR_SONUC_SIRASI = dto.RAPOR_SONUC_SIRASI;
        entity.HESAPLAMALI_TETKIK_BILGISI = dto.HESAPLAMALI_TETKIK_BILGISI;
        entity.HESAPLAMALI_TETKIK_FORMULU = dto.HESAPLAMALI_TETKIK_FORMULU;
        entity.IPTAL_DURUMU = dto.IPTAL_DURUMU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Tetkik)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<TETKIK>()
            .FirstOrDefaultAsync(e => e.TETKIK_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<TETKIK>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
