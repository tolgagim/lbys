using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Radyoloji;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class RadyolojiController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public RadyolojiController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Radyoloji)]
    public async Task<List<RadyolojiDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<RADYOLOJI>()
            .AsNoTracking()
            .Select(e => new RadyolojiDto
            {
                RADYOLOJI_KODU = e.RADYOLOJI_KODU,
HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                BIRIM_KODU = e.BIRIM_KODU,
                TETKIK_CEKIM_KABUL_ZAMANI = e.TETKIK_CEKIM_KABUL_ZAMANI,
                BARKOD = e.BARKOD,
                BARKOD_ZAMANI = e.BARKOD_ZAMANI,
                CIHAZ_KODU = e.CIHAZ_KODU,
                CALISMA_BASLAMA_ZAMANI = e.CALISMA_BASLAMA_ZAMANI,
                CALISMA_BITIS_ZAMANI = e.CALISMA_BITIS_ZAMANI,
                KABUL_EDEN_KULLANICI_KODU = e.KABUL_EDEN_KULLANICI_KODU,
                TETKIK_CEKEN_TEKNISYEN_KODU = e.TETKIK_CEKEN_TEKNISYEN_KODU,
                HASTA_HIZMET_KODU = e.HASTA_HIZMET_KODU,
                LOINC_KODU = e.LOINC_KODU,
                TETKIK_ISTENME_DURUMU = e.TETKIK_ISTENME_DURUMU,
                ERISIM_NUMARASI = e.ERISIM_NUMARASI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Radyoloji)]
    public async Task<ActionResult<RadyolojiDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<RADYOLOJI>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.RADYOLOJI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new RadyolojiDto
        {
            RADYOLOJI_KODU = entity.RADYOLOJI_KODU,
HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            BIRIM_KODU = entity.BIRIM_KODU,
            TETKIK_CEKIM_KABUL_ZAMANI = entity.TETKIK_CEKIM_KABUL_ZAMANI,
            BARKOD = entity.BARKOD,
            BARKOD_ZAMANI = entity.BARKOD_ZAMANI,
            CIHAZ_KODU = entity.CIHAZ_KODU,
            CALISMA_BASLAMA_ZAMANI = entity.CALISMA_BASLAMA_ZAMANI,
            CALISMA_BITIS_ZAMANI = entity.CALISMA_BITIS_ZAMANI,
            KABUL_EDEN_KULLANICI_KODU = entity.KABUL_EDEN_KULLANICI_KODU,
            TETKIK_CEKEN_TEKNISYEN_KODU = entity.TETKIK_CEKEN_TEKNISYEN_KODU,
            HASTA_HIZMET_KODU = entity.HASTA_HIZMET_KODU,
            LOINC_KODU = entity.LOINC_KODU,
            TETKIK_ISTENME_DURUMU = entity.TETKIK_ISTENME_DURUMU,
            ERISIM_NUMARASI = entity.ERISIM_NUMARASI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Radyoloji)]
    public async Task<ActionResult<string>> Create(RadyolojiDto dto, CancellationToken ct)
    {
        var entity = new RADYOLOJI
        {
            RADYOLOJI_KODU = dto.RADYOLOJI_KODU,
HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            BIRIM_KODU = dto.BIRIM_KODU,
            TETKIK_CEKIM_KABUL_ZAMANI = dto.TETKIK_CEKIM_KABUL_ZAMANI,
            BARKOD = dto.BARKOD,
            BARKOD_ZAMANI = dto.BARKOD_ZAMANI,
            CIHAZ_KODU = dto.CIHAZ_KODU,
            CALISMA_BASLAMA_ZAMANI = dto.CALISMA_BASLAMA_ZAMANI,
            CALISMA_BITIS_ZAMANI = dto.CALISMA_BITIS_ZAMANI,
            KABUL_EDEN_KULLANICI_KODU = dto.KABUL_EDEN_KULLANICI_KODU,
            TETKIK_CEKEN_TEKNISYEN_KODU = dto.TETKIK_CEKEN_TEKNISYEN_KODU,
            HASTA_HIZMET_KODU = dto.HASTA_HIZMET_KODU,
            LOINC_KODU = dto.LOINC_KODU,
            TETKIK_ISTENME_DURUMU = dto.TETKIK_ISTENME_DURUMU,
            ERISIM_NUMARASI = dto.ERISIM_NUMARASI,
        };

        _db.Set<RADYOLOJI>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.RADYOLOJI_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Radyoloji)]
    public async Task<IActionResult> Update(string id, RadyolojiDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<RADYOLOJI>()
            .FirstOrDefaultAsync(e => e.RADYOLOJI_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.BIRIM_KODU = dto.BIRIM_KODU;
        entity.TETKIK_CEKIM_KABUL_ZAMANI = dto.TETKIK_CEKIM_KABUL_ZAMANI;
        entity.BARKOD = dto.BARKOD;
        entity.BARKOD_ZAMANI = dto.BARKOD_ZAMANI;
        entity.CIHAZ_KODU = dto.CIHAZ_KODU;
        entity.CALISMA_BASLAMA_ZAMANI = dto.CALISMA_BASLAMA_ZAMANI;
        entity.CALISMA_BITIS_ZAMANI = dto.CALISMA_BITIS_ZAMANI;
        entity.KABUL_EDEN_KULLANICI_KODU = dto.KABUL_EDEN_KULLANICI_KODU;
        entity.TETKIK_CEKEN_TEKNISYEN_KODU = dto.TETKIK_CEKEN_TEKNISYEN_KODU;
        entity.HASTA_HIZMET_KODU = dto.HASTA_HIZMET_KODU;
        entity.LOINC_KODU = dto.LOINC_KODU;
        entity.TETKIK_ISTENME_DURUMU = dto.TETKIK_ISTENME_DURUMU;
        entity.ERISIM_NUMARASI = dto.ERISIM_NUMARASI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Radyoloji)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<RADYOLOJI>()
            .FirstOrDefaultAsync(e => e.RADYOLOJI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<RADYOLOJI>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
