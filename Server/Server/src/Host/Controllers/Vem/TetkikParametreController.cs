using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.TetkikParametre;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class TetkikParametreController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public TetkikParametreController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.TetkikParametre)]
    public async Task<List<TetkikParametreDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<TETKIK_PARAMETRE>()
            .AsNoTracking()
            .Select(e => new TetkikParametreDto
            {
                TETKIK_PARAMETRE_KODU = e.TETKIK_PARAMETRE_KODU,
                TETKIK_PARAMETRE_ADI = e.TETKIK_PARAMETRE_ADI,
                TETKIK_PARAMETRE_BIRIMI = e.TETKIK_PARAMETRE_BIRIMI,
                TETKIK_KODU = e.TETKIK_KODU,
                CIHAZ_KODU = e.CIHAZ_KODU,
                MEDULA_PARAMETRE_KODU = e.MEDULA_PARAMETRE_KODU,
                LOINC_KODU = e.LOINC_KODU,
                RAPOR_SONUC_SIRASI = e.RAPOR_SONUC_SIRASI,
                AKTIF = e.AKTIF,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.TetkikParametre)]
    public async Task<ActionResult<TetkikParametreDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<TETKIK_PARAMETRE>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.TETKIK_PARAMETRE_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new TetkikParametreDto
        {
            TETKIK_PARAMETRE_KODU = entity.TETKIK_PARAMETRE_KODU,
            TETKIK_PARAMETRE_ADI = entity.TETKIK_PARAMETRE_ADI,
            TETKIK_PARAMETRE_BIRIMI = entity.TETKIK_PARAMETRE_BIRIMI,
            TETKIK_KODU = entity.TETKIK_KODU,
            CIHAZ_KODU = entity.CIHAZ_KODU,
            MEDULA_PARAMETRE_KODU = entity.MEDULA_PARAMETRE_KODU,
            LOINC_KODU = entity.LOINC_KODU,
            RAPOR_SONUC_SIRASI = entity.RAPOR_SONUC_SIRASI,
            AKTIF = entity.AKTIF,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.TetkikParametre)]
    public async Task<ActionResult<string>> Create(TetkikParametreDto dto, CancellationToken ct)
    {
        var entity = new TETKIK_PARAMETRE
        {
            TETKIK_PARAMETRE_KODU = dto.TETKIK_PARAMETRE_KODU,
            TETKIK_PARAMETRE_ADI = dto.TETKIK_PARAMETRE_ADI,
            TETKIK_PARAMETRE_BIRIMI = dto.TETKIK_PARAMETRE_BIRIMI,
            TETKIK_KODU = dto.TETKIK_KODU,
            CIHAZ_KODU = dto.CIHAZ_KODU,
            MEDULA_PARAMETRE_KODU = dto.MEDULA_PARAMETRE_KODU,
            LOINC_KODU = dto.LOINC_KODU,
            RAPOR_SONUC_SIRASI = dto.RAPOR_SONUC_SIRASI,
            AKTIF = dto.AKTIF,
        };

        _db.Set<TETKIK_PARAMETRE>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.TETKIK_PARAMETRE_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.TetkikParametre)]
    public async Task<IActionResult> Update(string id, TetkikParametreDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<TETKIK_PARAMETRE>()
            .FirstOrDefaultAsync(e => e.TETKIK_PARAMETRE_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.TETKIK_PARAMETRE_ADI = dto.TETKIK_PARAMETRE_ADI;
        entity.TETKIK_PARAMETRE_BIRIMI = dto.TETKIK_PARAMETRE_BIRIMI;
        entity.TETKIK_KODU = dto.TETKIK_KODU;
        entity.CIHAZ_KODU = dto.CIHAZ_KODU;
        entity.MEDULA_PARAMETRE_KODU = dto.MEDULA_PARAMETRE_KODU;
        entity.LOINC_KODU = dto.LOINC_KODU;
        entity.RAPOR_SONUC_SIRASI = dto.RAPOR_SONUC_SIRASI;
        entity.AKTIF = dto.AKTIF;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.TetkikParametre)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<TETKIK_PARAMETRE>()
            .FirstOrDefaultAsync(e => e.TETKIK_PARAMETRE_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<TETKIK_PARAMETRE>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
