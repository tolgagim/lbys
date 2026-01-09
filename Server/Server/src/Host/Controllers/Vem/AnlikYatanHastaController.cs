using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.AnlikYatanHasta;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class AnlikYatanHastaController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public AnlikYatanHastaController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.AnlikYatanHasta)]
    public async Task<List<AnlikYatanHastaDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<ANLIK_YATAN_HASTA>()
            .AsNoTracking()
            .Select(e => new AnlikYatanHastaDto
            {
                ANLIK_YATAN_HASTA_KODU = e.ANLIK_YATAN_HASTA_KODU,
HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                HEKIM_KODU = e.HEKIM_KODU,
                YATIS_PROTOKOL_NUMARASI = e.YATIS_PROTOKOL_NUMARASI,
                BIRIM_KODU = e.BIRIM_KODU,
                YATAK_KODU = e.YATAK_KODU,
                ODA_KODU = e.ODA_KODU,
                YATIS_ZAMANI = e.YATIS_ZAMANI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.AnlikYatanHasta)]
    public async Task<ActionResult<AnlikYatanHastaDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<ANLIK_YATAN_HASTA>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.ANLIK_YATAN_HASTA_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new AnlikYatanHastaDto
        {
            ANLIK_YATAN_HASTA_KODU = entity.ANLIK_YATAN_HASTA_KODU,
HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            HEKIM_KODU = entity.HEKIM_KODU,
            YATIS_PROTOKOL_NUMARASI = entity.YATIS_PROTOKOL_NUMARASI,
            BIRIM_KODU = entity.BIRIM_KODU,
            YATAK_KODU = entity.YATAK_KODU,
            ODA_KODU = entity.ODA_KODU,
            YATIS_ZAMANI = entity.YATIS_ZAMANI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.AnlikYatanHasta)]
    public async Task<ActionResult<string>> Create(AnlikYatanHastaDto dto, CancellationToken ct)
    {
        var entity = new ANLIK_YATAN_HASTA
        {
            ANLIK_YATAN_HASTA_KODU = dto.ANLIK_YATAN_HASTA_KODU,
HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            HEKIM_KODU = dto.HEKIM_KODU,
            YATIS_PROTOKOL_NUMARASI = dto.YATIS_PROTOKOL_NUMARASI,
            BIRIM_KODU = dto.BIRIM_KODU,
            YATAK_KODU = dto.YATAK_KODU,
            ODA_KODU = dto.ODA_KODU,
            YATIS_ZAMANI = dto.YATIS_ZAMANI,
        };

        _db.Set<ANLIK_YATAN_HASTA>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.ANLIK_YATAN_HASTA_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.AnlikYatanHasta)]
    public async Task<IActionResult> Update(string id, AnlikYatanHastaDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<ANLIK_YATAN_HASTA>()
            .FirstOrDefaultAsync(e => e.ANLIK_YATAN_HASTA_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.HEKIM_KODU = dto.HEKIM_KODU;
        entity.YATIS_PROTOKOL_NUMARASI = dto.YATIS_PROTOKOL_NUMARASI;
        entity.BIRIM_KODU = dto.BIRIM_KODU;
        entity.YATAK_KODU = dto.YATAK_KODU;
        entity.ODA_KODU = dto.ODA_KODU;
        entity.YATIS_ZAMANI = dto.YATIS_ZAMANI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.AnlikYatanHasta)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<ANLIK_YATAN_HASTA>()
            .FirstOrDefaultAsync(e => e.ANLIK_YATAN_HASTA_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<ANLIK_YATAN_HASTA>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
