using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.HastaBorc;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class HastaBorcController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public HastaBorcController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.HastaBorc)]
    public async Task<List<HastaBorcDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<HASTA_BORC>()
            .AsNoTracking()
            .Select(e => new HastaBorcDto
            {
                HASTA_BORC_KODU = e.HASTA_BORC_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                ODENEN_BORC = e.ODENEN_BORC,
                TOPLAM_BORC = e.TOPLAM_BORC,
                KALAN_BORC = e.KALAN_BORC,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.HastaBorc)]
    public async Task<ActionResult<HastaBorcDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_BORC>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.HASTA_BORC_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new HastaBorcDto
        {
            HASTA_BORC_KODU = entity.HASTA_BORC_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            ODENEN_BORC = entity.ODENEN_BORC,
            TOPLAM_BORC = entity.TOPLAM_BORC,
            KALAN_BORC = entity.KALAN_BORC,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.HastaBorc)]
    public async Task<ActionResult<string>> Create(HastaBorcDto dto, CancellationToken ct)
    {
        var entity = new HASTA_BORC
        {
            HASTA_BORC_KODU = dto.HASTA_BORC_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            ODENEN_BORC = dto.ODENEN_BORC,
            TOPLAM_BORC = dto.TOPLAM_BORC,
            KALAN_BORC = dto.KALAN_BORC,
        };

        _db.Set<HASTA_BORC>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.HASTA_BORC_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.HastaBorc)]
    public async Task<IActionResult> Update(string id, HastaBorcDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_BORC>()
            .FirstOrDefaultAsync(e => e.HASTA_BORC_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.ODENEN_BORC = dto.ODENEN_BORC;
        entity.TOPLAM_BORC = dto.TOPLAM_BORC;
        entity.KALAN_BORC = dto.KALAN_BORC;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.HastaBorc)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_BORC>()
            .FirstOrDefaultAsync(e => e.HASTA_BORC_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<HASTA_BORC>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
