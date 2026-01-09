using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Cihaz;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class CihazController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public CihazController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Cihaz)]
    public async Task<List<CihazDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<CIHAZ>()
            .AsNoTracking()
            .Select(e => new CihazDto
            {
                CIHAZ_KODU = e.CIHAZ_KODU,
                CIHAZ_ADI = e.CIHAZ_ADI,
                CIHAZ_GRUBU = e.CIHAZ_GRUBU,
                BIRIM_KODU = e.BIRIM_KODU,
                CIHAZ_MODELI = e.CIHAZ_MODELI,
                CIHAZ_MARKASI = e.CIHAZ_MARKASI,
                SERI_NUMARASI = e.SERI_NUMARASI,
                MKYS_KUNYE_NUMARASI = e.MKYS_KUNYE_NUMARASI,
                AKTIFLIK_BILGISI = e.AKTIFLIK_BILGISI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Cihaz)]
    public async Task<ActionResult<CihazDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<CIHAZ>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.CIHAZ_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new CihazDto
        {
            CIHAZ_KODU = entity.CIHAZ_KODU,
            CIHAZ_ADI = entity.CIHAZ_ADI,
            CIHAZ_GRUBU = entity.CIHAZ_GRUBU,
            BIRIM_KODU = entity.BIRIM_KODU,
            CIHAZ_MODELI = entity.CIHAZ_MODELI,
            CIHAZ_MARKASI = entity.CIHAZ_MARKASI,
            SERI_NUMARASI = entity.SERI_NUMARASI,
            MKYS_KUNYE_NUMARASI = entity.MKYS_KUNYE_NUMARASI,
            AKTIFLIK_BILGISI = entity.AKTIFLIK_BILGISI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Cihaz)]
    public async Task<ActionResult<string>> Create(CihazDto dto, CancellationToken ct)
    {
        var entity = new CIHAZ
        {
            CIHAZ_KODU = dto.CIHAZ_KODU,
            CIHAZ_ADI = dto.CIHAZ_ADI,
            CIHAZ_GRUBU = dto.CIHAZ_GRUBU,
            BIRIM_KODU = dto.BIRIM_KODU,
            CIHAZ_MODELI = dto.CIHAZ_MODELI,
            CIHAZ_MARKASI = dto.CIHAZ_MARKASI,
            SERI_NUMARASI = dto.SERI_NUMARASI,
            MKYS_KUNYE_NUMARASI = dto.MKYS_KUNYE_NUMARASI,
            AKTIFLIK_BILGISI = dto.AKTIFLIK_BILGISI,
        };

        _db.Set<CIHAZ>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.CIHAZ_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Cihaz)]
    public async Task<IActionResult> Update(string id, CihazDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<CIHAZ>()
            .FirstOrDefaultAsync(e => e.CIHAZ_KODU == id, ct);

        if (entity == null)
            return NotFound();

        entity.CIHAZ_ADI = dto.CIHAZ_ADI;
        entity.CIHAZ_GRUBU = dto.CIHAZ_GRUBU;
        entity.BIRIM_KODU = dto.BIRIM_KODU;
        entity.CIHAZ_MODELI = dto.CIHAZ_MODELI;
        entity.CIHAZ_MARKASI = dto.CIHAZ_MARKASI;
        entity.SERI_NUMARASI = dto.SERI_NUMARASI;
        entity.MKYS_KUNYE_NUMARASI = dto.MKYS_KUNYE_NUMARASI;
        entity.AKTIFLIK_BILGISI = dto.AKTIFLIK_BILGISI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Cihaz)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<CIHAZ>()
            .FirstOrDefaultAsync(e => e.CIHAZ_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<CIHAZ>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
