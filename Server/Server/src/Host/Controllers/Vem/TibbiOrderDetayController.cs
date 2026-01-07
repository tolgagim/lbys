using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.TibbiOrderDetay;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class TibbiOrderDetayController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public TibbiOrderDetayController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.TibbiOrderDetay)]
    public async Task<List<TibbiOrderDetayDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<TIBBI_ORDER_DETAY>()
            .AsNoTracking()
            .Select(e => new TibbiOrderDetayDto
            {
                TIBBI_ORDER_DETAY_KODU = e.TIBBI_ORDER_DETAY_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                TIBBI_ORDER_KODU = e.TIBBI_ORDER_KODU,
                PLANLANAN_UYGULANMA_ZAMANI = e.PLANLANAN_UYGULANMA_ZAMANI,
                UYGULAYAN_HEMSIRE_KODU = e.UYGULAYAN_HEMSIRE_KODU,
                UYGULAMA_ZAMANI = e.UYGULAMA_ZAMANI,
                UYGULANMA_DURUMU = e.UYGULANMA_DURUMU,
                TIBBI_ORDER_IPTAL_NEDENI = e.TIBBI_ORDER_IPTAL_NEDENI,
                IPTAL_EDEN_HEMSIRE_KODU = e.IPTAL_EDEN_HEMSIRE_KODU,
                IPTAL_ZAMANI = e.IPTAL_ZAMANI,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.TibbiOrderDetay)]
    public async Task<ActionResult<TibbiOrderDetayDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<TIBBI_ORDER_DETAY>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.TIBBI_ORDER_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new TibbiOrderDetayDto
        {
            TIBBI_ORDER_DETAY_KODU = entity.TIBBI_ORDER_DETAY_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            TIBBI_ORDER_KODU = entity.TIBBI_ORDER_KODU,
            PLANLANAN_UYGULANMA_ZAMANI = entity.PLANLANAN_UYGULANMA_ZAMANI,
            UYGULAYAN_HEMSIRE_KODU = entity.UYGULAYAN_HEMSIRE_KODU,
            UYGULAMA_ZAMANI = entity.UYGULAMA_ZAMANI,
            UYGULANMA_DURUMU = entity.UYGULANMA_DURUMU,
            TIBBI_ORDER_IPTAL_NEDENI = entity.TIBBI_ORDER_IPTAL_NEDENI,
            IPTAL_EDEN_HEMSIRE_KODU = entity.IPTAL_EDEN_HEMSIRE_KODU,
            IPTAL_ZAMANI = entity.IPTAL_ZAMANI,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.TibbiOrderDetay)]
    public async Task<ActionResult<string>> Create(TibbiOrderDetayDto dto, CancellationToken ct)
    {
        var entity = new TIBBI_ORDER_DETAY
        {
            TIBBI_ORDER_DETAY_KODU = dto.TIBBI_ORDER_DETAY_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            TIBBI_ORDER_KODU = dto.TIBBI_ORDER_KODU,
            PLANLANAN_UYGULANMA_ZAMANI = dto.PLANLANAN_UYGULANMA_ZAMANI,
            UYGULAYAN_HEMSIRE_KODU = dto.UYGULAYAN_HEMSIRE_KODU,
            UYGULAMA_ZAMANI = dto.UYGULAMA_ZAMANI,
            UYGULANMA_DURUMU = dto.UYGULANMA_DURUMU,
            TIBBI_ORDER_IPTAL_NEDENI = dto.TIBBI_ORDER_IPTAL_NEDENI,
            IPTAL_EDEN_HEMSIRE_KODU = dto.IPTAL_EDEN_HEMSIRE_KODU,
            IPTAL_ZAMANI = dto.IPTAL_ZAMANI,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<TIBBI_ORDER_DETAY>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.TIBBI_ORDER_DETAY_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.TibbiOrderDetay)]
    public async Task<IActionResult> Update(string id, TibbiOrderDetayDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<TIBBI_ORDER_DETAY>()
            .FirstOrDefaultAsync(e => e.TIBBI_ORDER_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.TIBBI_ORDER_KODU = dto.TIBBI_ORDER_KODU;
        entity.PLANLANAN_UYGULANMA_ZAMANI = dto.PLANLANAN_UYGULANMA_ZAMANI;
        entity.UYGULAYAN_HEMSIRE_KODU = dto.UYGULAYAN_HEMSIRE_KODU;
        entity.UYGULAMA_ZAMANI = dto.UYGULAMA_ZAMANI;
        entity.UYGULANMA_DURUMU = dto.UYGULANMA_DURUMU;
        entity.TIBBI_ORDER_IPTAL_NEDENI = dto.TIBBI_ORDER_IPTAL_NEDENI;
        entity.IPTAL_EDEN_HEMSIRE_KODU = dto.IPTAL_EDEN_HEMSIRE_KODU;
        entity.IPTAL_ZAMANI = dto.IPTAL_ZAMANI;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.TibbiOrderDetay)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<TIBBI_ORDER_DETAY>()
            .FirstOrDefaultAsync(e => e.TIBBI_ORDER_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<TIBBI_ORDER_DETAY>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
