using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Getat;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class GetatController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public GetatController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Getat)]
    public async Task<List<GetatDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<GETAT>()
            .AsNoTracking()
            .Select(e => new GetatDto
            {
                GETAT_KODU = e.GETAT_KODU,
HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                GETAT_UYGULAMA_BIRIMI = e.GETAT_UYGULAMA_BIRIMI,
                KOMPLIKASYON_TANISI = e.KOMPLIKASYON_TANISI,
                GETAT_TEDAVI_SONUCU = e.GETAT_TEDAVI_SONUCU,
                GETAT_UYGULAMA_TURU = e.GETAT_UYGULAMA_TURU,
                GETAT_UYGULANDIGI_DURUMLAR = e.GETAT_UYGULANDIGI_DURUMLAR,
                GETAT_UYGULAMA_BOLGESI = e.GETAT_UYGULAMA_BOLGESI,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Getat)]
    public async Task<ActionResult<GetatDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<GETAT>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.GETAT_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new GetatDto
        {
            GETAT_KODU = entity.GETAT_KODU,
HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            GETAT_UYGULAMA_BIRIMI = entity.GETAT_UYGULAMA_BIRIMI,
            KOMPLIKASYON_TANISI = entity.KOMPLIKASYON_TANISI,
            GETAT_TEDAVI_SONUCU = entity.GETAT_TEDAVI_SONUCU,
            GETAT_UYGULAMA_TURU = entity.GETAT_UYGULAMA_TURU,
            GETAT_UYGULANDIGI_DURUMLAR = entity.GETAT_UYGULANDIGI_DURUMLAR,
            GETAT_UYGULAMA_BOLGESI = entity.GETAT_UYGULAMA_BOLGESI,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Getat)]
    public async Task<ActionResult<string>> Create(GetatDto dto, CancellationToken ct)
    {
        var entity = new GETAT
        {
            GETAT_KODU = dto.GETAT_KODU,
HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            GETAT_UYGULAMA_BIRIMI = dto.GETAT_UYGULAMA_BIRIMI,
            KOMPLIKASYON_TANISI = dto.KOMPLIKASYON_TANISI,
            GETAT_TEDAVI_SONUCU = dto.GETAT_TEDAVI_SONUCU,
            GETAT_UYGULAMA_TURU = dto.GETAT_UYGULAMA_TURU,
            GETAT_UYGULANDIGI_DURUMLAR = dto.GETAT_UYGULANDIGI_DURUMLAR,
            GETAT_UYGULAMA_BOLGESI = dto.GETAT_UYGULAMA_BOLGESI,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<GETAT>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.GETAT_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Getat)]
    public async Task<IActionResult> Update(string id, GetatDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<GETAT>()
            .FirstOrDefaultAsync(e => e.GETAT_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.GETAT_UYGULAMA_BIRIMI = dto.GETAT_UYGULAMA_BIRIMI;
        entity.KOMPLIKASYON_TANISI = dto.KOMPLIKASYON_TANISI;
        entity.GETAT_TEDAVI_SONUCU = dto.GETAT_TEDAVI_SONUCU;
        entity.GETAT_UYGULAMA_TURU = dto.GETAT_UYGULAMA_TURU;
        entity.GETAT_UYGULANDIGI_DURUMLAR = dto.GETAT_UYGULANDIGI_DURUMLAR;
        entity.GETAT_UYGULAMA_BOLGESI = dto.GETAT_UYGULAMA_BOLGESI;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Getat)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<GETAT>()
            .FirstOrDefaultAsync(e => e.GETAT_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<GETAT>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
