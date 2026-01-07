using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.HastaFotograf;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class HastaFotografController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public HastaFotografController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.HastaFotograf)]
    public async Task<List<HastaFotografDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<HASTA_FOTOGRAF>()
            .AsNoTracking()
            .Select(e => new HastaFotografDto
            {
                HASTA_FOTOGRAF_KODU = e.HASTA_FOTOGRAF_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                FOTOGRAF_TURU = e.FOTOGRAF_TURU,
                FOTOGRAF_BILGISI = e.FOTOGRAF_BILGISI,
                FOTOGRAF_DOSYA_YOLU = e.FOTOGRAF_DOSYA_YOLU,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.HastaFotograf)]
    public async Task<ActionResult<HastaFotografDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_FOTOGRAF>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.HASTA_FOTOGRAF_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new HastaFotografDto
        {
            HASTA_FOTOGRAF_KODU = entity.HASTA_FOTOGRAF_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            FOTOGRAF_TURU = entity.FOTOGRAF_TURU,
            FOTOGRAF_BILGISI = entity.FOTOGRAF_BILGISI,
            FOTOGRAF_DOSYA_YOLU = entity.FOTOGRAF_DOSYA_YOLU,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.HastaFotograf)]
    public async Task<ActionResult<string>> Create(HastaFotografDto dto, CancellationToken ct)
    {
        var entity = new HASTA_FOTOGRAF
        {
            HASTA_FOTOGRAF_KODU = dto.HASTA_FOTOGRAF_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            FOTOGRAF_TURU = dto.FOTOGRAF_TURU,
            FOTOGRAF_BILGISI = dto.FOTOGRAF_BILGISI,
            FOTOGRAF_DOSYA_YOLU = dto.FOTOGRAF_DOSYA_YOLU,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<HASTA_FOTOGRAF>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.HASTA_FOTOGRAF_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.HastaFotograf)]
    public async Task<IActionResult> Update(string id, HastaFotografDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_FOTOGRAF>()
            .FirstOrDefaultAsync(e => e.HASTA_FOTOGRAF_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.FOTOGRAF_TURU = dto.FOTOGRAF_TURU;
        entity.FOTOGRAF_BILGISI = dto.FOTOGRAF_BILGISI;
        entity.FOTOGRAF_DOSYA_YOLU = dto.FOTOGRAF_DOSYA_YOLU;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.HastaFotograf)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_FOTOGRAF>()
            .FirstOrDefaultAsync(e => e.HASTA_FOTOGRAF_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<HASTA_FOTOGRAF>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
