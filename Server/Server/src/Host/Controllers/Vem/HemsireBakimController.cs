using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.HemsireBakim;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class HemsireBakimController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public HemsireBakimController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.HemsireBakim)]
    public async Task<List<HemsireBakimDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<HEMSIRE_BAKIM>()
            .AsNoTracking()
            .Select(e => new HemsireBakimDto
            {
                HEMSIRE_BAKIM_KODU = e.HEMSIRE_BAKIM_KODU,
HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                HEMSIRE_DEGERLENDIRME_ZAMANI = e.HEMSIRE_DEGERLENDIRME_ZAMANI,
                HEMSIRELIK_TANI_KODU = e.HEMSIRELIK_TANI_KODU,
                BAKIM_NEDENI = e.BAKIM_NEDENI,
                HEMSIRE_BAKIM_HEDEF_SONUC = e.HEMSIRE_BAKIM_HEDEF_SONUC,
                HEMSIRELIK_GIRISIMI = e.HEMSIRELIK_GIRISIMI,
                HEMSIRE_DEGERLENDIRME_DURUMU = e.HEMSIRE_DEGERLENDIRME_DURUMU,
                HEMSIRE_DEGERLENDIRME_NOTU = e.HEMSIRE_DEGERLENDIRME_NOTU,
                HEMSIRE_KODU = e.HEMSIRE_KODU,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.HemsireBakim)]
    public async Task<ActionResult<HemsireBakimDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HEMSIRE_BAKIM>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.HEMSIRE_BAKIM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new HemsireBakimDto
        {
            HEMSIRE_BAKIM_KODU = entity.HEMSIRE_BAKIM_KODU,
HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            HEMSIRE_DEGERLENDIRME_ZAMANI = entity.HEMSIRE_DEGERLENDIRME_ZAMANI,
            HEMSIRELIK_TANI_KODU = entity.HEMSIRELIK_TANI_KODU,
            BAKIM_NEDENI = entity.BAKIM_NEDENI,
            HEMSIRE_BAKIM_HEDEF_SONUC = entity.HEMSIRE_BAKIM_HEDEF_SONUC,
            HEMSIRELIK_GIRISIMI = entity.HEMSIRELIK_GIRISIMI,
            HEMSIRE_DEGERLENDIRME_DURUMU = entity.HEMSIRE_DEGERLENDIRME_DURUMU,
            HEMSIRE_DEGERLENDIRME_NOTU = entity.HEMSIRE_DEGERLENDIRME_NOTU,
            HEMSIRE_KODU = entity.HEMSIRE_KODU,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.HemsireBakim)]
    public async Task<ActionResult<string>> Create(HemsireBakimDto dto, CancellationToken ct)
    {
        var entity = new HEMSIRE_BAKIM
        {
            HEMSIRE_BAKIM_KODU = dto.HEMSIRE_BAKIM_KODU,
HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            HEMSIRE_DEGERLENDIRME_ZAMANI = dto.HEMSIRE_DEGERLENDIRME_ZAMANI,
            HEMSIRELIK_TANI_KODU = dto.HEMSIRELIK_TANI_KODU,
            BAKIM_NEDENI = dto.BAKIM_NEDENI,
            HEMSIRE_BAKIM_HEDEF_SONUC = dto.HEMSIRE_BAKIM_HEDEF_SONUC,
            HEMSIRELIK_GIRISIMI = dto.HEMSIRELIK_GIRISIMI,
            HEMSIRE_DEGERLENDIRME_DURUMU = dto.HEMSIRE_DEGERLENDIRME_DURUMU,
            HEMSIRE_DEGERLENDIRME_NOTU = dto.HEMSIRE_DEGERLENDIRME_NOTU,
            HEMSIRE_KODU = dto.HEMSIRE_KODU,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<HEMSIRE_BAKIM>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.HEMSIRE_BAKIM_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.HemsireBakim)]
    public async Task<IActionResult> Update(string id, HemsireBakimDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<HEMSIRE_BAKIM>()
            .FirstOrDefaultAsync(e => e.HEMSIRE_BAKIM_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.HEMSIRE_DEGERLENDIRME_ZAMANI = dto.HEMSIRE_DEGERLENDIRME_ZAMANI;
        entity.HEMSIRELIK_TANI_KODU = dto.HEMSIRELIK_TANI_KODU;
        entity.BAKIM_NEDENI = dto.BAKIM_NEDENI;
        entity.HEMSIRE_BAKIM_HEDEF_SONUC = dto.HEMSIRE_BAKIM_HEDEF_SONUC;
        entity.HEMSIRELIK_GIRISIMI = dto.HEMSIRELIK_GIRISIMI;
        entity.HEMSIRE_DEGERLENDIRME_DURUMU = dto.HEMSIRE_DEGERLENDIRME_DURUMU;
        entity.HEMSIRE_DEGERLENDIRME_NOTU = dto.HEMSIRE_DEGERLENDIRME_NOTU;
        entity.HEMSIRE_KODU = dto.HEMSIRE_KODU;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.HemsireBakim)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HEMSIRE_BAKIM>()
            .FirstOrDefaultAsync(e => e.HEMSIRE_BAKIM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<HEMSIRE_BAKIM>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
