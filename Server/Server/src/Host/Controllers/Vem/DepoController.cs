using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Depo;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class DepoController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public DepoController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Depo)]
    public async Task<List<DepoDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<DEPO>()
            .AsNoTracking()
            .Select(e => new DepoDto
            {
                DEPO_KODU = e.DEPO_KODU,
                DEPO_ADI = e.DEPO_ADI,
                DEPO_TURU = e.DEPO_TURU,
                BINA_KODU = e.BINA_KODU,
                MKYS_KODU = e.MKYS_KODU,
                MKYS_KULLANICI_KODU = e.MKYS_KULLANICI_KODU,
                AKTIFLIK_BILGISI = e.AKTIFLIK_BILGISI,
                MKYS_KULLANICI_SIFRESI = e.MKYS_KULLANICI_SIFRESI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Depo)]
    public async Task<ActionResult<DepoDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<DEPO>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.DEPO_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new DepoDto
        {
            DEPO_KODU = entity.DEPO_KODU,
            DEPO_ADI = entity.DEPO_ADI,
            DEPO_TURU = entity.DEPO_TURU,
            BINA_KODU = entity.BINA_KODU,
            MKYS_KODU = entity.MKYS_KODU,
            MKYS_KULLANICI_KODU = entity.MKYS_KULLANICI_KODU,
            AKTIFLIK_BILGISI = entity.AKTIFLIK_BILGISI,
            MKYS_KULLANICI_SIFRESI = entity.MKYS_KULLANICI_SIFRESI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Depo)]
    public async Task<ActionResult<string>> Create(DepoDto dto, CancellationToken ct)
    {
        var entity = new DEPO
        {
            DEPO_KODU = dto.DEPO_KODU,
            DEPO_ADI = dto.DEPO_ADI,
            DEPO_TURU = dto.DEPO_TURU,
            BINA_KODU = dto.BINA_KODU,
            MKYS_KODU = dto.MKYS_KODU,
            MKYS_KULLANICI_KODU = dto.MKYS_KULLANICI_KODU,
            AKTIFLIK_BILGISI = dto.AKTIFLIK_BILGISI,
            MKYS_KULLANICI_SIFRESI = dto.MKYS_KULLANICI_SIFRESI,
        };

        _db.Set<DEPO>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.DEPO_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Depo)]
    public async Task<IActionResult> Update(string id, DepoDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<DEPO>()
            .FirstOrDefaultAsync(e => e.DEPO_KODU == id, ct);

        if (entity == null)
            return NotFound();

        entity.DEPO_ADI = dto.DEPO_ADI;
        entity.DEPO_TURU = dto.DEPO_TURU;
        entity.BINA_KODU = dto.BINA_KODU;
        entity.MKYS_KODU = dto.MKYS_KODU;
        entity.MKYS_KULLANICI_KODU = dto.MKYS_KULLANICI_KODU;
        entity.AKTIFLIK_BILGISI = dto.AKTIFLIK_BILGISI;
        entity.MKYS_KULLANICI_SIFRESI = dto.MKYS_KULLANICI_SIFRESI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Depo)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<DEPO>()
            .FirstOrDefaultAsync(e => e.DEPO_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<DEPO>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
