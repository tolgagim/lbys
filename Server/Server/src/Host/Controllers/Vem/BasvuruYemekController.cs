using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.BasvuruYemek;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class BasvuruYemekController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public BasvuruYemekController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.BasvuruYemek)]
    public async Task<List<BasvuruYemekDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<BASVURU_YEMEK>()
            .AsNoTracking()
            .Select(e => new BasvuruYemekDto
            {
                BASVURU_YEMEK_KODU = e.BASVURU_YEMEK_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                YEMEK_TURU = e.YEMEK_TURU,
                YEMEK_ZAMANI_TURU = e.YEMEK_ZAMANI_TURU,
                YEMEK_ZAMANI = e.YEMEK_ZAMANI,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.BasvuruYemek)]
    public async Task<ActionResult<BasvuruYemekDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<BASVURU_YEMEK>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.BASVURU_YEMEK_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new BasvuruYemekDto
        {
            BASVURU_YEMEK_KODU = entity.BASVURU_YEMEK_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            YEMEK_TURU = entity.YEMEK_TURU,
            YEMEK_ZAMANI_TURU = entity.YEMEK_ZAMANI_TURU,
            YEMEK_ZAMANI = entity.YEMEK_ZAMANI,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.BasvuruYemek)]
    public async Task<ActionResult<string>> Create(BasvuruYemekDto dto, CancellationToken ct)
    {
        var entity = new BASVURU_YEMEK
        {
            BASVURU_YEMEK_KODU = dto.BASVURU_YEMEK_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            YEMEK_TURU = dto.YEMEK_TURU,
            YEMEK_ZAMANI_TURU = dto.YEMEK_ZAMANI_TURU,
            YEMEK_ZAMANI = dto.YEMEK_ZAMANI,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<BASVURU_YEMEK>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.BASVURU_YEMEK_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.BasvuruYemek)]
    public async Task<IActionResult> Update(string id, BasvuruYemekDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<BASVURU_YEMEK>()
            .FirstOrDefaultAsync(e => e.BASVURU_YEMEK_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.YEMEK_TURU = dto.YEMEK_TURU;
        entity.YEMEK_ZAMANI_TURU = dto.YEMEK_ZAMANI_TURU;
        entity.YEMEK_ZAMANI = dto.YEMEK_ZAMANI;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.BasvuruYemek)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<BASVURU_YEMEK>()
            .FirstOrDefaultAsync(e => e.BASVURU_YEMEK_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<BASVURU_YEMEK>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
