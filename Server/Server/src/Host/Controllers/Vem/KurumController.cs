using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Kurum;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class KurumController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public KurumController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Kurum)]
    public async Task<List<KurumDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<KURUM>()
            .AsNoTracking()
            .Select(e => new KurumDto
            {
                KURUM_KODU = e.KURUM_KODU,
                KURUM_ADI = e.KURUM_ADI,
                KURUM_TURU = e.KURUM_TURU,
                IL_KODU = e.IL_KODU,
                ILCE_KODU = e.ILCE_KODU,
                ADRES = e.ADRES,
                TELEFON = e.TELEFON,
                EMAIL = e.EMAIL,
                VERGI_NO = e.VERGI_NO,
                VERGI_DAIRESI = e.VERGI_DAIRESI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Kurum)]
    public async Task<ActionResult<KurumDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KURUM>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.KURUM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new KurumDto
        {
            KURUM_KODU = entity.KURUM_KODU,
            KURUM_ADI = entity.KURUM_ADI,
            KURUM_TURU = entity.KURUM_TURU,
            IL_KODU = entity.IL_KODU,
            ILCE_KODU = entity.ILCE_KODU,
            ADRES = entity.ADRES,
            TELEFON = entity.TELEFON,
            EMAIL = entity.EMAIL,
            VERGI_NO = entity.VERGI_NO,
            VERGI_DAIRESI = entity.VERGI_DAIRESI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Kurum)]
    public async Task<ActionResult<string>> Create(KurumDto dto, CancellationToken ct)
    {
        var entity = new KURUM
        {
            KURUM_KODU = dto.KURUM_KODU,
            KURUM_ADI = dto.KURUM_ADI,
            KURUM_TURU = dto.KURUM_TURU,
            IL_KODU = dto.IL_KODU,
            ILCE_KODU = dto.ILCE_KODU,
            ADRES = dto.ADRES,
            TELEFON = dto.TELEFON,
            EMAIL = dto.EMAIL,
            VERGI_NO = dto.VERGI_NO,
            VERGI_DAIRESI = dto.VERGI_DAIRESI,
        };

        _db.Set<KURUM>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.KURUM_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Kurum)]
    public async Task<IActionResult> Update(string id, KurumDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<KURUM>()
            .FirstOrDefaultAsync(e => e.KURUM_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.KURUM_ADI = dto.KURUM_ADI;
        entity.KURUM_TURU = dto.KURUM_TURU;
        entity.IL_KODU = dto.IL_KODU;
        entity.ILCE_KODU = dto.ILCE_KODU;
        entity.ADRES = dto.ADRES;
        entity.TELEFON = dto.TELEFON;
        entity.EMAIL = dto.EMAIL;
        entity.VERGI_NO = dto.VERGI_NO;
        entity.VERGI_DAIRESI = dto.VERGI_DAIRESI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Kurum)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KURUM>()
            .FirstOrDefaultAsync(e => e.KURUM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<KURUM>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
