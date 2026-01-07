using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Ameliyat;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class AmeliyatController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public AmeliyatController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Ameliyat)]
    public async Task<List<AmeliyatDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<AMELIYAT>()
            .AsNoTracking()
            .Select(e => new AmeliyatDto
            {
                AMELIYAT_KODU = e.AMELIYAT_KODU,
                HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                AMELIYAT_ADI = e.AMELIYAT_ADI,
                AMELIYAT_TURU = e.AMELIYAT_TURU,
                AMELIYAT_BASLAMA_ZAMANI = e.AMELIYAT_BASLAMA_ZAMANI,
                AMELIYAT_BITIS_ZAMANI = e.AMELIYAT_BITIS_ZAMANI,
                MASA_CIHAZ_KODU = e.MASA_CIHAZ_KODU,
                BIRIM_KODU = e.BIRIM_KODU,
                DEFTER_NUMARASI = e.DEFTER_NUMARASI,
                AMELIYAT_DURUMU = e.AMELIYAT_DURUMU,
                ANESTEZI_TURU = e.ANESTEZI_TURU,
                ANESTEZI_NOTU = e.ANESTEZI_NOTU,
                ANESTEZI_BASLAMA_ZAMANI = e.ANESTEZI_BASLAMA_ZAMANI,
                ANESTEZI_BITIS_ZAMANI = e.ANESTEZI_BITIS_ZAMANI,
                AMELIYAT_TIPI = e.AMELIYAT_TIPI,
                SKOPI_SURESI = e.SKOPI_SURESI,
                PROFILAKSI_PERIYODU = e.PROFILAKSI_PERIYODU,
                PROFILAKSI_KODU = e.PROFILAKSI_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Ameliyat)]
    public async Task<ActionResult<AmeliyatDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<AMELIYAT>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.AMELIYAT_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new AmeliyatDto
        {
            AMELIYAT_KODU = entity.AMELIYAT_KODU,
            HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            AMELIYAT_ADI = entity.AMELIYAT_ADI,
            AMELIYAT_TURU = entity.AMELIYAT_TURU,
            AMELIYAT_BASLAMA_ZAMANI = entity.AMELIYAT_BASLAMA_ZAMANI,
            AMELIYAT_BITIS_ZAMANI = entity.AMELIYAT_BITIS_ZAMANI,
            MASA_CIHAZ_KODU = entity.MASA_CIHAZ_KODU,
            BIRIM_KODU = entity.BIRIM_KODU,
            DEFTER_NUMARASI = entity.DEFTER_NUMARASI,
            AMELIYAT_DURUMU = entity.AMELIYAT_DURUMU,
            ANESTEZI_TURU = entity.ANESTEZI_TURU,
            ANESTEZI_NOTU = entity.ANESTEZI_NOTU,
            ANESTEZI_BASLAMA_ZAMANI = entity.ANESTEZI_BASLAMA_ZAMANI,
            ANESTEZI_BITIS_ZAMANI = entity.ANESTEZI_BITIS_ZAMANI,
            AMELIYAT_TIPI = entity.AMELIYAT_TIPI,
            SKOPI_SURESI = entity.SKOPI_SURESI,
            PROFILAKSI_PERIYODU = entity.PROFILAKSI_PERIYODU,
            PROFILAKSI_KODU = entity.PROFILAKSI_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Ameliyat)]
    public async Task<ActionResult<string>> Create(AmeliyatDto dto, CancellationToken ct)
    {
        var entity = new AMELIYAT
        {
            AMELIYAT_KODU = dto.AMELIYAT_KODU,
            HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            AMELIYAT_ADI = dto.AMELIYAT_ADI,
            AMELIYAT_TURU = dto.AMELIYAT_TURU,
            AMELIYAT_BASLAMA_ZAMANI = dto.AMELIYAT_BASLAMA_ZAMANI,
            AMELIYAT_BITIS_ZAMANI = dto.AMELIYAT_BITIS_ZAMANI,
            MASA_CIHAZ_KODU = dto.MASA_CIHAZ_KODU,
            BIRIM_KODU = dto.BIRIM_KODU,
            DEFTER_NUMARASI = dto.DEFTER_NUMARASI,
            AMELIYAT_DURUMU = dto.AMELIYAT_DURUMU,
            ANESTEZI_TURU = dto.ANESTEZI_TURU,
            ANESTEZI_NOTU = dto.ANESTEZI_NOTU,
            ANESTEZI_BASLAMA_ZAMANI = dto.ANESTEZI_BASLAMA_ZAMANI,
            ANESTEZI_BITIS_ZAMANI = dto.ANESTEZI_BITIS_ZAMANI,
            AMELIYAT_TIPI = dto.AMELIYAT_TIPI,
            SKOPI_SURESI = dto.SKOPI_SURESI,
            PROFILAKSI_PERIYODU = dto.PROFILAKSI_PERIYODU,
            PROFILAKSI_KODU = dto.PROFILAKSI_KODU,
        };

        _db.Set<AMELIYAT>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.AMELIYAT_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Ameliyat)]
    public async Task<IActionResult> Update(string id, AmeliyatDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<AMELIYAT>()
            .FirstOrDefaultAsync(e => e.AMELIYAT_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.AMELIYAT_ADI = dto.AMELIYAT_ADI;
        entity.AMELIYAT_TURU = dto.AMELIYAT_TURU;
        entity.AMELIYAT_BASLAMA_ZAMANI = dto.AMELIYAT_BASLAMA_ZAMANI;
        entity.AMELIYAT_BITIS_ZAMANI = dto.AMELIYAT_BITIS_ZAMANI;
        entity.MASA_CIHAZ_KODU = dto.MASA_CIHAZ_KODU;
        entity.BIRIM_KODU = dto.BIRIM_KODU;
        entity.DEFTER_NUMARASI = dto.DEFTER_NUMARASI;
        entity.AMELIYAT_DURUMU = dto.AMELIYAT_DURUMU;
        entity.ANESTEZI_TURU = dto.ANESTEZI_TURU;
        entity.ANESTEZI_NOTU = dto.ANESTEZI_NOTU;
        entity.ANESTEZI_BASLAMA_ZAMANI = dto.ANESTEZI_BASLAMA_ZAMANI;
        entity.ANESTEZI_BITIS_ZAMANI = dto.ANESTEZI_BITIS_ZAMANI;
        entity.AMELIYAT_TIPI = dto.AMELIYAT_TIPI;
        entity.SKOPI_SURESI = dto.SKOPI_SURESI;
        entity.PROFILAKSI_PERIYODU = dto.PROFILAKSI_PERIYODU;
        entity.PROFILAKSI_KODU = dto.PROFILAKSI_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Ameliyat)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<AMELIYAT>()
            .FirstOrDefaultAsync(e => e.AMELIYAT_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<AMELIYAT>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
