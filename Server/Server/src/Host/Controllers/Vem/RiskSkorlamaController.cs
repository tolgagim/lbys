using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.RiskSkorlama;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class RiskSkorlamaController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public RiskSkorlamaController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.RiskSkorlama)]
    public async Task<List<RiskSkorlamaDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<RISK_SKORLAMA>()
            .AsNoTracking()
            .Select(e => new RiskSkorlamaDto
            {
                RISK_SKORLAMA_KODU = e.RISK_SKORLAMA_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                HASTA_KODU = e.HASTA_KODU,
                RISK_SKORLAMA_TURU = e.RISK_SKORLAMA_TURU,
                ISLEM_ZAMANI = e.ISLEM_ZAMANI,
                RISK_SKORLAMA_TOPLAM_PUANI = e.RISK_SKORLAMA_TOPLAM_PUANI,
                BEKLENEN_OLUM_ORANI = e.BEKLENEN_OLUM_ORANI,
                GLASGOW_SKALASI = e.GLASGOW_SKALASI,
                DUZELTILMISBEKLENEN_OLUM_ORANI = e.DUZELTILMISBEKLENEN_OLUM_ORANI,
                TIBBI_ORDER_DETAY_KODU = e.TIBBI_ORDER_DETAY_KODU,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.RiskSkorlama)]
    public async Task<ActionResult<RiskSkorlamaDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<RISK_SKORLAMA>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.RISK_SKORLAMA_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new RiskSkorlamaDto
        {
            RISK_SKORLAMA_KODU = entity.RISK_SKORLAMA_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            HASTA_KODU = entity.HASTA_KODU,
            RISK_SKORLAMA_TURU = entity.RISK_SKORLAMA_TURU,
            ISLEM_ZAMANI = entity.ISLEM_ZAMANI,
            RISK_SKORLAMA_TOPLAM_PUANI = entity.RISK_SKORLAMA_TOPLAM_PUANI,
            BEKLENEN_OLUM_ORANI = entity.BEKLENEN_OLUM_ORANI,
            GLASGOW_SKALASI = entity.GLASGOW_SKALASI,
            DUZELTILMISBEKLENEN_OLUM_ORANI = entity.DUZELTILMISBEKLENEN_OLUM_ORANI,
            TIBBI_ORDER_DETAY_KODU = entity.TIBBI_ORDER_DETAY_KODU,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.RiskSkorlama)]
    public async Task<ActionResult<string>> Create(RiskSkorlamaDto dto, CancellationToken ct)
    {
        var entity = new RISK_SKORLAMA
        {
            RISK_SKORLAMA_KODU = dto.RISK_SKORLAMA_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            HASTA_KODU = dto.HASTA_KODU,
            RISK_SKORLAMA_TURU = dto.RISK_SKORLAMA_TURU,
            ISLEM_ZAMANI = dto.ISLEM_ZAMANI,
            RISK_SKORLAMA_TOPLAM_PUANI = dto.RISK_SKORLAMA_TOPLAM_PUANI,
            BEKLENEN_OLUM_ORANI = dto.BEKLENEN_OLUM_ORANI,
            GLASGOW_SKALASI = dto.GLASGOW_SKALASI,
            DUZELTILMISBEKLENEN_OLUM_ORANI = dto.DUZELTILMISBEKLENEN_OLUM_ORANI,
            TIBBI_ORDER_DETAY_KODU = dto.TIBBI_ORDER_DETAY_KODU,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<RISK_SKORLAMA>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.RISK_SKORLAMA_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.RiskSkorlama)]
    public async Task<IActionResult> Update(string id, RiskSkorlamaDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<RISK_SKORLAMA>()
            .FirstOrDefaultAsync(e => e.RISK_SKORLAMA_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.RISK_SKORLAMA_TURU = dto.RISK_SKORLAMA_TURU;
        entity.ISLEM_ZAMANI = dto.ISLEM_ZAMANI;
        entity.RISK_SKORLAMA_TOPLAM_PUANI = dto.RISK_SKORLAMA_TOPLAM_PUANI;
        entity.BEKLENEN_OLUM_ORANI = dto.BEKLENEN_OLUM_ORANI;
        entity.GLASGOW_SKALASI = dto.GLASGOW_SKALASI;
        entity.DUZELTILMISBEKLENEN_OLUM_ORANI = dto.DUZELTILMISBEKLENEN_OLUM_ORANI;
        entity.TIBBI_ORDER_DETAY_KODU = dto.TIBBI_ORDER_DETAY_KODU;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.RiskSkorlama)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<RISK_SKORLAMA>()
            .FirstOrDefaultAsync(e => e.RISK_SKORLAMA_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<RISK_SKORLAMA>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
