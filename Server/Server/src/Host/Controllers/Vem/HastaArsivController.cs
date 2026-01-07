using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.HastaArsiv;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class HastaArsivController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public HastaArsivController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.HastaArsiv)]
    public async Task<List<HastaArsivDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<HASTA_ARSIV>()
            .AsNoTracking()
            .Select(e => new HastaArsivDto
            {
                HASTA_ARSIV_KODU = e.HASTA_ARSIV_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                HASTA_KODU = e.HASTA_KODU,
                ARSIV_NUMARASI = e.ARSIV_NUMARASI,
                ESKI_ARSIV_NUMARASI = e.ESKI_ARSIV_NUMARASI,
                ARSIV_DEFTER_TURU = e.ARSIV_DEFTER_TURU,
                ARSIV_YERI = e.ARSIV_YERI,
                ACIKLAMA = e.ACIKLAMA,
                ARSIV_ILK_GIRIS_TARIHI = e.ARSIV_ILK_GIRIS_TARIHI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.HastaArsiv)]
    public async Task<ActionResult<HastaArsivDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_ARSIV>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.HASTA_ARSIV_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new HastaArsivDto
        {
            HASTA_ARSIV_KODU = entity.HASTA_ARSIV_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            HASTA_KODU = entity.HASTA_KODU,
            ARSIV_NUMARASI = entity.ARSIV_NUMARASI,
            ESKI_ARSIV_NUMARASI = entity.ESKI_ARSIV_NUMARASI,
            ARSIV_DEFTER_TURU = entity.ARSIV_DEFTER_TURU,
            ARSIV_YERI = entity.ARSIV_YERI,
            ACIKLAMA = entity.ACIKLAMA,
            ARSIV_ILK_GIRIS_TARIHI = entity.ARSIV_ILK_GIRIS_TARIHI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.HastaArsiv)]
    public async Task<ActionResult<string>> Create(HastaArsivDto dto, CancellationToken ct)
    {
        var entity = new HASTA_ARSIV
        {
            HASTA_ARSIV_KODU = dto.HASTA_ARSIV_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            HASTA_KODU = dto.HASTA_KODU,
            ARSIV_NUMARASI = dto.ARSIV_NUMARASI,
            ESKI_ARSIV_NUMARASI = dto.ESKI_ARSIV_NUMARASI,
            ARSIV_DEFTER_TURU = dto.ARSIV_DEFTER_TURU,
            ARSIV_YERI = dto.ARSIV_YERI,
            ACIKLAMA = dto.ACIKLAMA,
            ARSIV_ILK_GIRIS_TARIHI = dto.ARSIV_ILK_GIRIS_TARIHI,
        };

        _db.Set<HASTA_ARSIV>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.HASTA_ARSIV_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.HastaArsiv)]
    public async Task<IActionResult> Update(string id, HastaArsivDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_ARSIV>()
            .FirstOrDefaultAsync(e => e.HASTA_ARSIV_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.ARSIV_NUMARASI = dto.ARSIV_NUMARASI;
        entity.ESKI_ARSIV_NUMARASI = dto.ESKI_ARSIV_NUMARASI;
        entity.ARSIV_DEFTER_TURU = dto.ARSIV_DEFTER_TURU;
        entity.ARSIV_YERI = dto.ARSIV_YERI;
        entity.ACIKLAMA = dto.ACIKLAMA;
        entity.ARSIV_ILK_GIRIS_TARIHI = dto.ARSIV_ILK_GIRIS_TARIHI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.HastaArsiv)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_ARSIV>()
            .FirstOrDefaultAsync(e => e.HASTA_ARSIV_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<HASTA_ARSIV>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
