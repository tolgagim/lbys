using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Diyabet;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class DiyabetController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public DiyabetController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Diyabet)]
    public async Task<List<DiyabetDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<DIYABET>()
            .AsNoTracking()
            .Select(e => new DiyabetDto
            {
                DIYABET_KODU = e.DIYABET_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                ILK_TANI_TARIHI = e.ILK_TANI_TARIHI,
                AGIRLIK = e.AGIRLIK,
                BOY = e.BOY,
                DIYABET_EGITIMI = e.DIYABET_EGITIMI,
                DIYABET_KOMPLIKASYONLARI = e.DIYABET_KOMPLIKASYONLARI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Diyabet)]
    public async Task<ActionResult<DiyabetDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<DIYABET>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.DIYABET_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new DiyabetDto
        {
            DIYABET_KODU = entity.DIYABET_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            ILK_TANI_TARIHI = entity.ILK_TANI_TARIHI,
            AGIRLIK = entity.AGIRLIK,
            BOY = entity.BOY,
            DIYABET_EGITIMI = entity.DIYABET_EGITIMI,
            DIYABET_KOMPLIKASYONLARI = entity.DIYABET_KOMPLIKASYONLARI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Diyabet)]
    public async Task<ActionResult<string>> Create(DiyabetDto dto, CancellationToken ct)
    {
        var entity = new DIYABET
        {
            DIYABET_KODU = dto.DIYABET_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            ILK_TANI_TARIHI = dto.ILK_TANI_TARIHI,
            AGIRLIK = dto.AGIRLIK,
            BOY = dto.BOY,
            DIYABET_EGITIMI = dto.DIYABET_EGITIMI,
            DIYABET_KOMPLIKASYONLARI = dto.DIYABET_KOMPLIKASYONLARI,
        };

        _db.Set<DIYABET>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.DIYABET_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Diyabet)]
    public async Task<IActionResult> Update(string id, DiyabetDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<DIYABET>()
            .FirstOrDefaultAsync(e => e.DIYABET_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.ILK_TANI_TARIHI = dto.ILK_TANI_TARIHI;
        entity.AGIRLIK = dto.AGIRLIK;
        entity.BOY = dto.BOY;
        entity.DIYABET_EGITIMI = dto.DIYABET_EGITIMI;
        entity.DIYABET_KOMPLIKASYONLARI = dto.DIYABET_KOMPLIKASYONLARI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Diyabet)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<DIYABET>()
            .FirstOrDefaultAsync(e => e.DIYABET_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<DIYABET>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
