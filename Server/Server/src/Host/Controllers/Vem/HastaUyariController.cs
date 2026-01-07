using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.HastaUyari;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class HastaUyariController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public HastaUyariController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.HastaUyari)]
    public async Task<List<HastaUyariDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<HASTA_UYARI>()
            .AsNoTracking()
            .Select(e => new HastaUyariDto
            {
                HASTA_UYARI_KODU = e.HASTA_UYARI_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                UYARI_TURU = e.UYARI_TURU,
                ISLEME_IZIN_VERME_DURUMU = e.ISLEME_IZIN_VERME_DURUMU,
                HASTA_UYARI_BASLAMA_ZAMANI = e.HASTA_UYARI_BASLAMA_ZAMANI,
                HASTA_UYARI_BITIS_ZAMANI = e.HASTA_UYARI_BITIS_ZAMANI,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.HastaUyari)]
    public async Task<ActionResult<HastaUyariDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_UYARI>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.HASTA_UYARI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new HastaUyariDto
        {
            HASTA_UYARI_KODU = entity.HASTA_UYARI_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            UYARI_TURU = entity.UYARI_TURU,
            ISLEME_IZIN_VERME_DURUMU = entity.ISLEME_IZIN_VERME_DURUMU,
            HASTA_UYARI_BASLAMA_ZAMANI = entity.HASTA_UYARI_BASLAMA_ZAMANI,
            HASTA_UYARI_BITIS_ZAMANI = entity.HASTA_UYARI_BITIS_ZAMANI,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.HastaUyari)]
    public async Task<ActionResult<string>> Create(HastaUyariDto dto, CancellationToken ct)
    {
        var entity = new HASTA_UYARI
        {
            HASTA_UYARI_KODU = dto.HASTA_UYARI_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            UYARI_TURU = dto.UYARI_TURU,
            ISLEME_IZIN_VERME_DURUMU = dto.ISLEME_IZIN_VERME_DURUMU,
            HASTA_UYARI_BASLAMA_ZAMANI = dto.HASTA_UYARI_BASLAMA_ZAMANI,
            HASTA_UYARI_BITIS_ZAMANI = dto.HASTA_UYARI_BITIS_ZAMANI,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<HASTA_UYARI>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.HASTA_UYARI_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.HastaUyari)]
    public async Task<IActionResult> Update(string id, HastaUyariDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_UYARI>()
            .FirstOrDefaultAsync(e => e.HASTA_UYARI_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.UYARI_TURU = dto.UYARI_TURU;
        entity.ISLEME_IZIN_VERME_DURUMU = dto.ISLEME_IZIN_VERME_DURUMU;
        entity.HASTA_UYARI_BASLAMA_ZAMANI = dto.HASTA_UYARI_BASLAMA_ZAMANI;
        entity.HASTA_UYARI_BITIS_ZAMANI = dto.HASTA_UYARI_BITIS_ZAMANI;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.HastaUyari)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_UYARI>()
            .FirstOrDefaultAsync(e => e.HASTA_UYARI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<HASTA_UYARI>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
