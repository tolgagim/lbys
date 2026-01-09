using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.HastaDis;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class HastaDisController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public HastaDisController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.HastaDis)]
    public async Task<List<HastaDisDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<HASTA_DIS>()
            .AsNoTracking()
            .Select(e => new HastaDisDto
            {
                HASTA_DIS_KODU = e.HASTA_DIS_KODU,
HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                DIS_ISLEM_TURU = e.DIS_ISLEM_TURU,
                HASTA_HIZMET_KODU = e.HASTA_HIZMET_KODU,
                DIS_TAAHHUT_KODU = e.DIS_TAAHHUT_KODU,
                MEVCUT_DIS_DURUMU = e.MEVCUT_DIS_DURUMU,
                DIS_KODU = e.DIS_KODU,
                CENE_BOLGESI = e.CENE_BOLGESI,
                CENE_BOLGESI_DISLERI = e.CENE_BOLGESI_DISLERI,
                DISPROTEZ_KODU = e.DISPROTEZ_KODU,
                SONUC_KODU = e.SONUC_KODU,
                SONUC_MESAJI = e.SONUC_MESAJI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.HastaDis)]
    public async Task<ActionResult<HastaDisDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_DIS>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.HASTA_DIS_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new HastaDisDto
        {
            HASTA_DIS_KODU = entity.HASTA_DIS_KODU,
HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            DIS_ISLEM_TURU = entity.DIS_ISLEM_TURU,
            HASTA_HIZMET_KODU = entity.HASTA_HIZMET_KODU,
            DIS_TAAHHUT_KODU = entity.DIS_TAAHHUT_KODU,
            MEVCUT_DIS_DURUMU = entity.MEVCUT_DIS_DURUMU,
            DIS_KODU = entity.DIS_KODU,
            CENE_BOLGESI = entity.CENE_BOLGESI,
            CENE_BOLGESI_DISLERI = entity.CENE_BOLGESI_DISLERI,
            DISPROTEZ_KODU = entity.DISPROTEZ_KODU,
            SONUC_KODU = entity.SONUC_KODU,
            SONUC_MESAJI = entity.SONUC_MESAJI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.HastaDis)]
    public async Task<ActionResult<string>> Create(HastaDisDto dto, CancellationToken ct)
    {
        var entity = new HASTA_DIS
        {
            HASTA_DIS_KODU = dto.HASTA_DIS_KODU,
HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            DIS_ISLEM_TURU = dto.DIS_ISLEM_TURU,
            HASTA_HIZMET_KODU = dto.HASTA_HIZMET_KODU,
            DIS_TAAHHUT_KODU = dto.DIS_TAAHHUT_KODU,
            MEVCUT_DIS_DURUMU = dto.MEVCUT_DIS_DURUMU,
            DIS_KODU = dto.DIS_KODU,
            CENE_BOLGESI = dto.CENE_BOLGESI,
            CENE_BOLGESI_DISLERI = dto.CENE_BOLGESI_DISLERI,
            DISPROTEZ_KODU = dto.DISPROTEZ_KODU,
            SONUC_KODU = dto.SONUC_KODU,
            SONUC_MESAJI = dto.SONUC_MESAJI,
        };

        _db.Set<HASTA_DIS>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.HASTA_DIS_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.HastaDis)]
    public async Task<IActionResult> Update(string id, HastaDisDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_DIS>()
            .FirstOrDefaultAsync(e => e.HASTA_DIS_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.DIS_ISLEM_TURU = dto.DIS_ISLEM_TURU;
        entity.HASTA_HIZMET_KODU = dto.HASTA_HIZMET_KODU;
        entity.DIS_TAAHHUT_KODU = dto.DIS_TAAHHUT_KODU;
        entity.MEVCUT_DIS_DURUMU = dto.MEVCUT_DIS_DURUMU;
        entity.DIS_KODU = dto.DIS_KODU;
        entity.CENE_BOLGESI = dto.CENE_BOLGESI;
        entity.CENE_BOLGESI_DISLERI = dto.CENE_BOLGESI_DISLERI;
        entity.DISPROTEZ_KODU = dto.DISPROTEZ_KODU;
        entity.SONUC_KODU = dto.SONUC_KODU;
        entity.SONUC_MESAJI = dto.SONUC_MESAJI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.HastaDis)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_DIS>()
            .FirstOrDefaultAsync(e => e.HASTA_DIS_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<HASTA_DIS>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
