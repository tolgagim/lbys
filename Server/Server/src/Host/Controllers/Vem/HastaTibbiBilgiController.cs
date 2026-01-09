using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.HastaTibbiBilgi;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class HastaTibbiBilgiController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public HastaTibbiBilgiController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.HastaTibbiBilgi)]
    public async Task<List<HastaTibbiBilgiDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<HASTA_TIBBI_BILGI>()
            .AsNoTracking()
            .Select(e => new HastaTibbiBilgiDto
            {
                HASTA_TIBBI_BILGI_KODU = e.HASTA_TIBBI_BILGI_KODU,
HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                TIBBI_BILGI_TURU = e.TIBBI_BILGI_TURU,
                TIBBI_BILGI_ALT_TURU = e.TIBBI_BILGI_ALT_TURU,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.HastaTibbiBilgi)]
    public async Task<ActionResult<HastaTibbiBilgiDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_TIBBI_BILGI>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.HASTA_TIBBI_BILGI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new HastaTibbiBilgiDto
        {
            HASTA_TIBBI_BILGI_KODU = entity.HASTA_TIBBI_BILGI_KODU,
HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            TIBBI_BILGI_TURU = entity.TIBBI_BILGI_TURU,
            TIBBI_BILGI_ALT_TURU = entity.TIBBI_BILGI_ALT_TURU,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.HastaTibbiBilgi)]
    public async Task<ActionResult<string>> Create(HastaTibbiBilgiDto dto, CancellationToken ct)
    {
        var entity = new HASTA_TIBBI_BILGI
        {
            HASTA_TIBBI_BILGI_KODU = dto.HASTA_TIBBI_BILGI_KODU,
HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            TIBBI_BILGI_TURU = dto.TIBBI_BILGI_TURU,
            TIBBI_BILGI_ALT_TURU = dto.TIBBI_BILGI_ALT_TURU,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<HASTA_TIBBI_BILGI>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.HASTA_TIBBI_BILGI_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.HastaTibbiBilgi)]
    public async Task<IActionResult> Update(string id, HastaTibbiBilgiDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_TIBBI_BILGI>()
            .FirstOrDefaultAsync(e => e.HASTA_TIBBI_BILGI_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.TIBBI_BILGI_TURU = dto.TIBBI_BILGI_TURU;
        entity.TIBBI_BILGI_ALT_TURU = dto.TIBBI_BILGI_ALT_TURU;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.HastaTibbiBilgi)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_TIBBI_BILGI>()
            .FirstOrDefaultAsync(e => e.HASTA_TIBBI_BILGI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<HASTA_TIBBI_BILGI>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
