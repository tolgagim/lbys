using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.SterilizasyonPaket;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class SterilizasyonPaketController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public SterilizasyonPaketController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.SterilizasyonPaket)]
    public async Task<List<SterilizasyonPaketDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<STERILIZASYON_PAKET>()
            .AsNoTracking()
            .Select(e => new SterilizasyonPaketDto
            {
                STERILIZASYON_PAKET_KODU = e.STERILIZASYON_PAKET_KODU,
STERILIZASYON_PAKET_ADI = e.STERILIZASYON_PAKET_ADI,
                PAKET_KODU = e.PAKET_KODU,
                ACIKLAMA = e.ACIKLAMA,
                STERILIZASYON_YONTEMI = e.STERILIZASYON_YONTEMI,
                STERILIZASYON_PAKET_GRUBU = e.STERILIZASYON_PAKET_GRUBU,
                PAKET_RAF_OMRU_BITIS_GUN = e.PAKET_RAF_OMRU_BITIS_GUN,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.SterilizasyonPaket)]
    public async Task<ActionResult<SterilizasyonPaketDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STERILIZASYON_PAKET>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.STERILIZASYON_PAKET_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new SterilizasyonPaketDto
        {
            STERILIZASYON_PAKET_KODU = entity.STERILIZASYON_PAKET_KODU,
STERILIZASYON_PAKET_ADI = entity.STERILIZASYON_PAKET_ADI,
            PAKET_KODU = entity.PAKET_KODU,
            ACIKLAMA = entity.ACIKLAMA,
            STERILIZASYON_YONTEMI = entity.STERILIZASYON_YONTEMI,
            STERILIZASYON_PAKET_GRUBU = entity.STERILIZASYON_PAKET_GRUBU,
            PAKET_RAF_OMRU_BITIS_GUN = entity.PAKET_RAF_OMRU_BITIS_GUN,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.SterilizasyonPaket)]
    public async Task<ActionResult<string>> Create(SterilizasyonPaketDto dto, CancellationToken ct)
    {
        var entity = new STERILIZASYON_PAKET
        {
            STERILIZASYON_PAKET_KODU = dto.STERILIZASYON_PAKET_KODU,
STERILIZASYON_PAKET_ADI = dto.STERILIZASYON_PAKET_ADI,
            PAKET_KODU = dto.PAKET_KODU,
            ACIKLAMA = dto.ACIKLAMA,
            STERILIZASYON_YONTEMI = dto.STERILIZASYON_YONTEMI,
            STERILIZASYON_PAKET_GRUBU = dto.STERILIZASYON_PAKET_GRUBU,
            PAKET_RAF_OMRU_BITIS_GUN = dto.PAKET_RAF_OMRU_BITIS_GUN,
        };

        _db.Set<STERILIZASYON_PAKET>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.STERILIZASYON_PAKET_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.SterilizasyonPaket)]
    public async Task<IActionResult> Update(string id, SterilizasyonPaketDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<STERILIZASYON_PAKET>()
            .FirstOrDefaultAsync(e => e.STERILIZASYON_PAKET_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.STERILIZASYON_PAKET_ADI = dto.STERILIZASYON_PAKET_ADI;
        entity.PAKET_KODU = dto.PAKET_KODU;
        entity.ACIKLAMA = dto.ACIKLAMA;
        entity.STERILIZASYON_YONTEMI = dto.STERILIZASYON_YONTEMI;
        entity.STERILIZASYON_PAKET_GRUBU = dto.STERILIZASYON_PAKET_GRUBU;
        entity.PAKET_RAF_OMRU_BITIS_GUN = dto.PAKET_RAF_OMRU_BITIS_GUN;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.SterilizasyonPaket)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STERILIZASYON_PAKET>()
            .FirstOrDefaultAsync(e => e.STERILIZASYON_PAKET_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<STERILIZASYON_PAKET>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
