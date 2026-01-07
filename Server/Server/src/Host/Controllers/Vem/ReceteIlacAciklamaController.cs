using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.ReceteIlacAciklama;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class ReceteIlacAciklamaController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public ReceteIlacAciklamaController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.ReceteIlacAciklama)]
    public async Task<List<ReceteIlacAciklamaDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<RECETE_ILAC_ACIKLAMA>()
            .AsNoTracking()
            .Select(e => new ReceteIlacAciklamaDto
            {
                RECETE_ILAC_ACIKLAMA_KODU = e.RECETE_ILAC_ACIKLAMA_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                RECETE_ILAC_KODU = e.RECETE_ILAC_KODU,
                RECETE_KODU = e.RECETE_KODU,
                ILAC_ACIKLAMA_TURU = e.ILAC_ACIKLAMA_TURU,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.ReceteIlacAciklama)]
    public async Task<ActionResult<ReceteIlacAciklamaDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<RECETE_ILAC_ACIKLAMA>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.RECETE_ILAC_ACIKLAMA_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new ReceteIlacAciklamaDto
        {
            RECETE_ILAC_ACIKLAMA_KODU = entity.RECETE_ILAC_ACIKLAMA_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            RECETE_ILAC_KODU = entity.RECETE_ILAC_KODU,
            RECETE_KODU = entity.RECETE_KODU,
            ILAC_ACIKLAMA_TURU = entity.ILAC_ACIKLAMA_TURU,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.ReceteIlacAciklama)]
    public async Task<ActionResult<string>> Create(ReceteIlacAciklamaDto dto, CancellationToken ct)
    {
        var entity = new RECETE_ILAC_ACIKLAMA
        {
            RECETE_ILAC_ACIKLAMA_KODU = dto.RECETE_ILAC_ACIKLAMA_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            RECETE_ILAC_KODU = dto.RECETE_ILAC_KODU,
            RECETE_KODU = dto.RECETE_KODU,
            ILAC_ACIKLAMA_TURU = dto.ILAC_ACIKLAMA_TURU,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<RECETE_ILAC_ACIKLAMA>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.RECETE_ILAC_ACIKLAMA_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.ReceteIlacAciklama)]
    public async Task<IActionResult> Update(string id, ReceteIlacAciklamaDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<RECETE_ILAC_ACIKLAMA>()
            .FirstOrDefaultAsync(e => e.RECETE_ILAC_ACIKLAMA_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.RECETE_ILAC_KODU = dto.RECETE_ILAC_KODU;
        entity.RECETE_KODU = dto.RECETE_KODU;
        entity.ILAC_ACIKLAMA_TURU = dto.ILAC_ACIKLAMA_TURU;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.ReceteIlacAciklama)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<RECETE_ILAC_ACIKLAMA>()
            .FirstOrDefaultAsync(e => e.RECETE_ILAC_ACIKLAMA_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<RECETE_ILAC_ACIKLAMA>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
