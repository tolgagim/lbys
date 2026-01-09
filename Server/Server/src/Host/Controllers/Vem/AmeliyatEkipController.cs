using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.AmeliyatEkip;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class AmeliyatEkipController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public AmeliyatEkipController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.AmeliyatEkip)]
    public async Task<List<AmeliyatEkipDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<AMELIYAT_EKIP>()
            .AsNoTracking()
            .Select(e => new AmeliyatEkipDto
            {
                AMELIYAT_EKIP_KODU = e.AMELIYAT_EKIP_KODU,
AMELIYAT_KODU = e.AMELIYAT_KODU,
                AMELIYAT_ISLEM_KODU = e.AMELIYAT_ISLEM_KODU,
                EKIP_NUMARASI = e.EKIP_NUMARASI,
                PERSONEL_KODU = e.PERSONEL_KODU,
                AMELIYAT_PERSONEL_GOREV = e.AMELIYAT_PERSONEL_GOREV,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.AmeliyatEkip)]
    public async Task<ActionResult<AmeliyatEkipDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<AMELIYAT_EKIP>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.AMELIYAT_EKIP_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new AmeliyatEkipDto
        {
            AMELIYAT_EKIP_KODU = entity.AMELIYAT_EKIP_KODU,
AMELIYAT_KODU = entity.AMELIYAT_KODU,
            AMELIYAT_ISLEM_KODU = entity.AMELIYAT_ISLEM_KODU,
            EKIP_NUMARASI = entity.EKIP_NUMARASI,
            PERSONEL_KODU = entity.PERSONEL_KODU,
            AMELIYAT_PERSONEL_GOREV = entity.AMELIYAT_PERSONEL_GOREV,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.AmeliyatEkip)]
    public async Task<ActionResult<string>> Create(AmeliyatEkipDto dto, CancellationToken ct)
    {
        var entity = new AMELIYAT_EKIP
        {
            AMELIYAT_EKIP_KODU = dto.AMELIYAT_EKIP_KODU,
AMELIYAT_KODU = dto.AMELIYAT_KODU,
            AMELIYAT_ISLEM_KODU = dto.AMELIYAT_ISLEM_KODU,
            EKIP_NUMARASI = dto.EKIP_NUMARASI,
            PERSONEL_KODU = dto.PERSONEL_KODU,
            AMELIYAT_PERSONEL_GOREV = dto.AMELIYAT_PERSONEL_GOREV,
        };

        _db.Set<AMELIYAT_EKIP>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.AMELIYAT_EKIP_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.AmeliyatEkip)]
    public async Task<IActionResult> Update(string id, AmeliyatEkipDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<AMELIYAT_EKIP>()
            .FirstOrDefaultAsync(e => e.AMELIYAT_EKIP_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.AMELIYAT_KODU = dto.AMELIYAT_KODU;
        entity.AMELIYAT_ISLEM_KODU = dto.AMELIYAT_ISLEM_KODU;
        entity.EKIP_NUMARASI = dto.EKIP_NUMARASI;
        entity.PERSONEL_KODU = dto.PERSONEL_KODU;
        entity.AMELIYAT_PERSONEL_GOREV = dto.AMELIYAT_PERSONEL_GOREV;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.AmeliyatEkip)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<AMELIYAT_EKIP>()
            .FirstOrDefaultAsync(e => e.AMELIYAT_EKIP_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<AMELIYAT_EKIP>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
