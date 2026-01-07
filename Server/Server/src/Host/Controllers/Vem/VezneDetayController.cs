using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.VezneDetay;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class VezneDetayController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public VezneDetayController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.VezneDetay)]
    public async Task<List<VezneDetayDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<VEZNE_DETAY>()
            .AsNoTracking()
            .Select(e => new VezneDetayDto
            {
                VEZNE_DETAY_KODU = e.VEZNE_DETAY_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                VEZNE_KODU = e.VEZNE_KODU,
                HASTA_HIZMET_KODU = e.HASTA_HIZMET_KODU,
                HASTA_MALZEME_KODU = e.HASTA_MALZEME_KODU,
                BUTCE_KODU = e.BUTCE_KODU,
                MAKBUZ_KALEM_TUTARI = e.MAKBUZ_KALEM_TUTARI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.VezneDetay)]
    public async Task<ActionResult<VezneDetayDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<VEZNE_DETAY>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.VEZNE_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new VezneDetayDto
        {
            VEZNE_DETAY_KODU = entity.VEZNE_DETAY_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            VEZNE_KODU = entity.VEZNE_KODU,
            HASTA_HIZMET_KODU = entity.HASTA_HIZMET_KODU,
            HASTA_MALZEME_KODU = entity.HASTA_MALZEME_KODU,
            BUTCE_KODU = entity.BUTCE_KODU,
            MAKBUZ_KALEM_TUTARI = entity.MAKBUZ_KALEM_TUTARI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.VezneDetay)]
    public async Task<ActionResult<string>> Create(VezneDetayDto dto, CancellationToken ct)
    {
        var entity = new VEZNE_DETAY
        {
            VEZNE_DETAY_KODU = dto.VEZNE_DETAY_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            VEZNE_KODU = dto.VEZNE_KODU,
            HASTA_HIZMET_KODU = dto.HASTA_HIZMET_KODU,
            HASTA_MALZEME_KODU = dto.HASTA_MALZEME_KODU,
            BUTCE_KODU = dto.BUTCE_KODU,
            MAKBUZ_KALEM_TUTARI = dto.MAKBUZ_KALEM_TUTARI,
        };

        _db.Set<VEZNE_DETAY>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.VEZNE_DETAY_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.VezneDetay)]
    public async Task<IActionResult> Update(string id, VezneDetayDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<VEZNE_DETAY>()
            .FirstOrDefaultAsync(e => e.VEZNE_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.VEZNE_KODU = dto.VEZNE_KODU;
        entity.HASTA_HIZMET_KODU = dto.HASTA_HIZMET_KODU;
        entity.HASTA_MALZEME_KODU = dto.HASTA_MALZEME_KODU;
        entity.BUTCE_KODU = dto.BUTCE_KODU;
        entity.MAKBUZ_KALEM_TUTARI = dto.MAKBUZ_KALEM_TUTARI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.VezneDetay)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<VEZNE_DETAY>()
            .FirstOrDefaultAsync(e => e.VEZNE_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<VEZNE_DETAY>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
