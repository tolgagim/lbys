using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Konsultasyon;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class KonsultasyonController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public KonsultasyonController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Konsultasyon)]
    public async Task<List<KonsultasyonDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<KONSULTASYON>()
            .AsNoTracking()
            .Select(e => new KonsultasyonDto
            {
                KONSULTASYON_KODU = e.KONSULTASYON_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                HASTA_HIZMET_KODU = e.HASTA_HIZMET_KODU,
                KONSULTASYON_BASVURU_KODU = e.KONSULTASYON_BASVURU_KODU,
                KONSULTASYON_ISTEK_NOTU = e.KONSULTASYON_ISTEK_NOTU,
                KONSULTASYON_CEVAP_NOTU = e.KONSULTASYON_CEVAP_NOTU,
                KONSULTASYONA_CAGRILMA_ZAMANI = e.KONSULTASYONA_CAGRILMA_ZAMANI,
                KONSULTASYONA_GELIS_ZAMANI = e.KONSULTASYONA_GELIS_ZAMANI,
                KONSULTASYON_YERI = e.KONSULTASYON_YERI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Konsultasyon)]
    public async Task<ActionResult<KonsultasyonDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KONSULTASYON>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.KONSULTASYON_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new KonsultasyonDto
        {
            KONSULTASYON_KODU = entity.KONSULTASYON_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            HASTA_HIZMET_KODU = entity.HASTA_HIZMET_KODU,
            KONSULTASYON_BASVURU_KODU = entity.KONSULTASYON_BASVURU_KODU,
            KONSULTASYON_ISTEK_NOTU = entity.KONSULTASYON_ISTEK_NOTU,
            KONSULTASYON_CEVAP_NOTU = entity.KONSULTASYON_CEVAP_NOTU,
            KONSULTASYONA_CAGRILMA_ZAMANI = entity.KONSULTASYONA_CAGRILMA_ZAMANI,
            KONSULTASYONA_GELIS_ZAMANI = entity.KONSULTASYONA_GELIS_ZAMANI,
            KONSULTASYON_YERI = entity.KONSULTASYON_YERI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Konsultasyon)]
    public async Task<ActionResult<string>> Create(KonsultasyonDto dto, CancellationToken ct)
    {
        var entity = new KONSULTASYON
        {
            KONSULTASYON_KODU = dto.KONSULTASYON_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            HASTA_HIZMET_KODU = dto.HASTA_HIZMET_KODU,
            KONSULTASYON_BASVURU_KODU = dto.KONSULTASYON_BASVURU_KODU,
            KONSULTASYON_ISTEK_NOTU = dto.KONSULTASYON_ISTEK_NOTU,
            KONSULTASYON_CEVAP_NOTU = dto.KONSULTASYON_CEVAP_NOTU,
            KONSULTASYONA_CAGRILMA_ZAMANI = dto.KONSULTASYONA_CAGRILMA_ZAMANI,
            KONSULTASYONA_GELIS_ZAMANI = dto.KONSULTASYONA_GELIS_ZAMANI,
            KONSULTASYON_YERI = dto.KONSULTASYON_YERI,
        };

        _db.Set<KONSULTASYON>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.KONSULTASYON_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Konsultasyon)]
    public async Task<IActionResult> Update(string id, KonsultasyonDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<KONSULTASYON>()
            .FirstOrDefaultAsync(e => e.KONSULTASYON_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.HASTA_HIZMET_KODU = dto.HASTA_HIZMET_KODU;
        entity.KONSULTASYON_BASVURU_KODU = dto.KONSULTASYON_BASVURU_KODU;
        entity.KONSULTASYON_ISTEK_NOTU = dto.KONSULTASYON_ISTEK_NOTU;
        entity.KONSULTASYON_CEVAP_NOTU = dto.KONSULTASYON_CEVAP_NOTU;
        entity.KONSULTASYONA_CAGRILMA_ZAMANI = dto.KONSULTASYONA_CAGRILMA_ZAMANI;
        entity.KONSULTASYONA_GELIS_ZAMANI = dto.KONSULTASYONA_GELIS_ZAMANI;
        entity.KONSULTASYON_YERI = dto.KONSULTASYON_YERI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Konsultasyon)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KONSULTASYON>()
            .FirstOrDefaultAsync(e => e.KONSULTASYON_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<KONSULTASYON>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
