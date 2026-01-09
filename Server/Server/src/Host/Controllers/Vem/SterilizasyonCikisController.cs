using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.SterilizasyonCikis;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class SterilizasyonCikisController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public SterilizasyonCikisController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.SterilizasyonCikis)]
    public async Task<List<SterilizasyonCikisDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<STERILIZASYON_CIKIS>()
            .AsNoTracking()
            .Select(e => new SterilizasyonCikisDto
            {
                STERILIZASYON_CIKIS_KODU = e.STERILIZASYON_CIKIS_KODU,
DEPO_KODU = e.DEPO_KODU,
                STERILIZASYON_SET_KODU = e.STERILIZASYON_SET_KODU,
                HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                STERILIZASYON_CIKIS_MIKTARI = e.STERILIZASYON_CIKIS_MIKTARI,
                STERILIZASYON_CIKIS_ZAMANI = e.STERILIZASYON_CIKIS_ZAMANI,
                CIKIS_YAPILAN_BIRIM_KODU = e.CIKIS_YAPILAN_BIRIM_KODU,
                TESLIM_EDEN_PERSONEL_KODU = e.TESLIM_EDEN_PERSONEL_KODU,
                TESLIM_ALAN_PERSONEL_KODU = e.TESLIM_ALAN_PERSONEL_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.SterilizasyonCikis)]
    public async Task<ActionResult<SterilizasyonCikisDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STERILIZASYON_CIKIS>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.STERILIZASYON_CIKIS_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new SterilizasyonCikisDto
        {
            STERILIZASYON_CIKIS_KODU = entity.STERILIZASYON_CIKIS_KODU,
DEPO_KODU = entity.DEPO_KODU,
            STERILIZASYON_SET_KODU = entity.STERILIZASYON_SET_KODU,
            HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            STERILIZASYON_CIKIS_MIKTARI = entity.STERILIZASYON_CIKIS_MIKTARI,
            STERILIZASYON_CIKIS_ZAMANI = entity.STERILIZASYON_CIKIS_ZAMANI,
            CIKIS_YAPILAN_BIRIM_KODU = entity.CIKIS_YAPILAN_BIRIM_KODU,
            TESLIM_EDEN_PERSONEL_KODU = entity.TESLIM_EDEN_PERSONEL_KODU,
            TESLIM_ALAN_PERSONEL_KODU = entity.TESLIM_ALAN_PERSONEL_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.SterilizasyonCikis)]
    public async Task<ActionResult<string>> Create(SterilizasyonCikisDto dto, CancellationToken ct)
    {
        var entity = new STERILIZASYON_CIKIS
        {
            STERILIZASYON_CIKIS_KODU = dto.STERILIZASYON_CIKIS_KODU,
DEPO_KODU = dto.DEPO_KODU,
            STERILIZASYON_SET_KODU = dto.STERILIZASYON_SET_KODU,
            HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            STERILIZASYON_CIKIS_MIKTARI = dto.STERILIZASYON_CIKIS_MIKTARI,
            STERILIZASYON_CIKIS_ZAMANI = dto.STERILIZASYON_CIKIS_ZAMANI,
            CIKIS_YAPILAN_BIRIM_KODU = dto.CIKIS_YAPILAN_BIRIM_KODU,
            TESLIM_EDEN_PERSONEL_KODU = dto.TESLIM_EDEN_PERSONEL_KODU,
            TESLIM_ALAN_PERSONEL_KODU = dto.TESLIM_ALAN_PERSONEL_KODU,
        };

        _db.Set<STERILIZASYON_CIKIS>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.STERILIZASYON_CIKIS_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.SterilizasyonCikis)]
    public async Task<IActionResult> Update(string id, SterilizasyonCikisDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<STERILIZASYON_CIKIS>()
            .FirstOrDefaultAsync(e => e.STERILIZASYON_CIKIS_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.DEPO_KODU = dto.DEPO_KODU;
        entity.STERILIZASYON_SET_KODU = dto.STERILIZASYON_SET_KODU;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.STERILIZASYON_CIKIS_MIKTARI = dto.STERILIZASYON_CIKIS_MIKTARI;
        entity.STERILIZASYON_CIKIS_ZAMANI = dto.STERILIZASYON_CIKIS_ZAMANI;
        entity.CIKIS_YAPILAN_BIRIM_KODU = dto.CIKIS_YAPILAN_BIRIM_KODU;
        entity.TESLIM_EDEN_PERSONEL_KODU = dto.TESLIM_EDEN_PERSONEL_KODU;
        entity.TESLIM_ALAN_PERSONEL_KODU = dto.TESLIM_ALAN_PERSONEL_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.SterilizasyonCikis)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STERILIZASYON_CIKIS>()
            .FirstOrDefaultAsync(e => e.STERILIZASYON_CIKIS_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<STERILIZASYON_CIKIS>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
