using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.RiskSkorlamaDetay;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class RiskSkorlamaDetayController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public RiskSkorlamaDetayController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.RiskSkorlamaDetay)]
    public async Task<List<RiskSkorlamaDetayDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<RISK_SKORLAMA_DETAY>()
            .AsNoTracking()
            .Select(e => new RiskSkorlamaDetayDto
            {
                RISK_SKORLAMA_DETAY_KODU = e.RISK_SKORLAMA_DETAY_KODU,
RISK_SKORLAMA_KODU = e.RISK_SKORLAMA_KODU,
                GLASGOW_SKALASI = e.GLASGOW_SKALASI,
                RISK_SKORLAMA_ALT_TURU = e.RISK_SKORLAMA_ALT_TURU,
                RISK_SKOR_DEGERI = e.RISK_SKOR_DEGERI,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.RiskSkorlamaDetay)]
    public async Task<ActionResult<RiskSkorlamaDetayDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<RISK_SKORLAMA_DETAY>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.RISK_SKORLAMA_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new RiskSkorlamaDetayDto
        {
            RISK_SKORLAMA_DETAY_KODU = entity.RISK_SKORLAMA_DETAY_KODU,
RISK_SKORLAMA_KODU = entity.RISK_SKORLAMA_KODU,
            GLASGOW_SKALASI = entity.GLASGOW_SKALASI,
            RISK_SKORLAMA_ALT_TURU = entity.RISK_SKORLAMA_ALT_TURU,
            RISK_SKOR_DEGERI = entity.RISK_SKOR_DEGERI,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.RiskSkorlamaDetay)]
    public async Task<ActionResult<string>> Create(RiskSkorlamaDetayDto dto, CancellationToken ct)
    {
        var entity = new RISK_SKORLAMA_DETAY
        {
            RISK_SKORLAMA_DETAY_KODU = dto.RISK_SKORLAMA_DETAY_KODU,
RISK_SKORLAMA_KODU = dto.RISK_SKORLAMA_KODU,
            GLASGOW_SKALASI = dto.GLASGOW_SKALASI,
            RISK_SKORLAMA_ALT_TURU = dto.RISK_SKORLAMA_ALT_TURU,
            RISK_SKOR_DEGERI = dto.RISK_SKOR_DEGERI,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<RISK_SKORLAMA_DETAY>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.RISK_SKORLAMA_DETAY_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.RiskSkorlamaDetay)]
    public async Task<IActionResult> Update(string id, RiskSkorlamaDetayDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<RISK_SKORLAMA_DETAY>()
            .FirstOrDefaultAsync(e => e.RISK_SKORLAMA_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.RISK_SKORLAMA_KODU = dto.RISK_SKORLAMA_KODU;
        entity.GLASGOW_SKALASI = dto.GLASGOW_SKALASI;
        entity.RISK_SKORLAMA_ALT_TURU = dto.RISK_SKORLAMA_ALT_TURU;
        entity.RISK_SKOR_DEGERI = dto.RISK_SKOR_DEGERI;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.RiskSkorlamaDetay)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<RISK_SKORLAMA_DETAY>()
            .FirstOrDefaultAsync(e => e.RISK_SKORLAMA_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<RISK_SKORLAMA_DETAY>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
