using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.HastaEpikriz;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class HastaEpikrizController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public HastaEpikrizController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.HastaEpikriz)]
    public async Task<List<HastaEpikrizDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<HASTA_EPIKRIZ>()
            .AsNoTracking()
            .Select(e => new HastaEpikrizDto
            {
                HASTA_EPIKRIZ_KODU = e.HASTA_EPIKRIZ_KODU,
HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                EPIKRIZ_ZAMANI = e.EPIKRIZ_ZAMANI,
                EPIKRIZ_BASLIK_BILGISI = e.EPIKRIZ_BASLIK_BILGISI,
                EPIKRIZ_BILGISI_ACIKLAMA = e.EPIKRIZ_BILGISI_ACIKLAMA,
                HEKIM_KODU = e.HEKIM_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.HastaEpikriz)]
    public async Task<ActionResult<HastaEpikrizDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_EPIKRIZ>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.HASTA_EPIKRIZ_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new HastaEpikrizDto
        {
            HASTA_EPIKRIZ_KODU = entity.HASTA_EPIKRIZ_KODU,
HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            EPIKRIZ_ZAMANI = entity.EPIKRIZ_ZAMANI,
            EPIKRIZ_BASLIK_BILGISI = entity.EPIKRIZ_BASLIK_BILGISI,
            EPIKRIZ_BILGISI_ACIKLAMA = entity.EPIKRIZ_BILGISI_ACIKLAMA,
            HEKIM_KODU = entity.HEKIM_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.HastaEpikriz)]
    public async Task<ActionResult<string>> Create(HastaEpikrizDto dto, CancellationToken ct)
    {
        var entity = new HASTA_EPIKRIZ
        {
            HASTA_EPIKRIZ_KODU = dto.HASTA_EPIKRIZ_KODU,
HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            EPIKRIZ_ZAMANI = dto.EPIKRIZ_ZAMANI,
            EPIKRIZ_BASLIK_BILGISI = dto.EPIKRIZ_BASLIK_BILGISI,
            EPIKRIZ_BILGISI_ACIKLAMA = dto.EPIKRIZ_BILGISI_ACIKLAMA,
            HEKIM_KODU = dto.HEKIM_KODU,
        };

        _db.Set<HASTA_EPIKRIZ>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.HASTA_EPIKRIZ_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.HastaEpikriz)]
    public async Task<IActionResult> Update(string id, HastaEpikrizDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_EPIKRIZ>()
            .FirstOrDefaultAsync(e => e.HASTA_EPIKRIZ_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.EPIKRIZ_ZAMANI = dto.EPIKRIZ_ZAMANI;
        entity.EPIKRIZ_BASLIK_BILGISI = dto.EPIKRIZ_BASLIK_BILGISI;
        entity.EPIKRIZ_BILGISI_ACIKLAMA = dto.EPIKRIZ_BILGISI_ACIKLAMA;
        entity.HEKIM_KODU = dto.HEKIM_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.HastaEpikriz)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_EPIKRIZ>()
            .FirstOrDefaultAsync(e => e.HASTA_EPIKRIZ_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<HASTA_EPIKRIZ>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
