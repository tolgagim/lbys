using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.AntibiyotikSonuc;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class AntibiyotikSonucController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public AntibiyotikSonucController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.AntibiyotikSonuc)]
    public async Task<List<AntibiyotikSonucDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<ANTIBIYOTIK_SONUC>()
            .AsNoTracking()
            .Select(e => new AntibiyotikSonucDto
            {
                ANTIBIYOTIK_SONUC_KODU = e.ANTIBIYOTIK_SONUC_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                BAKTERI_SONUC_KODU = e.BAKTERI_SONUC_KODU,
                ANTIBIYOTIK_KODU = e.ANTIBIYOTIK_KODU,
                TETKIK_SONUCU = e.TETKIK_SONUCU,
                ZON_CAPI = e.ZON_CAPI,
                ACIKLAMA = e.ACIKLAMA,
                RAPORDA_GORULME_DURUMU = e.RAPORDA_GORULME_DURUMU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.AntibiyotikSonuc)]
    public async Task<ActionResult<AntibiyotikSonucDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<ANTIBIYOTIK_SONUC>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.ANTIBIYOTIK_SONUC_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new AntibiyotikSonucDto
        {
            ANTIBIYOTIK_SONUC_KODU = entity.ANTIBIYOTIK_SONUC_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            BAKTERI_SONUC_KODU = entity.BAKTERI_SONUC_KODU,
            ANTIBIYOTIK_KODU = entity.ANTIBIYOTIK_KODU,
            TETKIK_SONUCU = entity.TETKIK_SONUCU,
            ZON_CAPI = entity.ZON_CAPI,
            ACIKLAMA = entity.ACIKLAMA,
            RAPORDA_GORULME_DURUMU = entity.RAPORDA_GORULME_DURUMU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.AntibiyotikSonuc)]
    public async Task<ActionResult<string>> Create(AntibiyotikSonucDto dto, CancellationToken ct)
    {
        var entity = new ANTIBIYOTIK_SONUC
        {
            ANTIBIYOTIK_SONUC_KODU = dto.ANTIBIYOTIK_SONUC_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            BAKTERI_SONUC_KODU = dto.BAKTERI_SONUC_KODU,
            ANTIBIYOTIK_KODU = dto.ANTIBIYOTIK_KODU,
            TETKIK_SONUCU = dto.TETKIK_SONUCU,
            ZON_CAPI = dto.ZON_CAPI,
            ACIKLAMA = dto.ACIKLAMA,
            RAPORDA_GORULME_DURUMU = dto.RAPORDA_GORULME_DURUMU,
        };

        _db.Set<ANTIBIYOTIK_SONUC>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.ANTIBIYOTIK_SONUC_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.AntibiyotikSonuc)]
    public async Task<IActionResult> Update(string id, AntibiyotikSonucDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<ANTIBIYOTIK_SONUC>()
            .FirstOrDefaultAsync(e => e.ANTIBIYOTIK_SONUC_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.BAKTERI_SONUC_KODU = dto.BAKTERI_SONUC_KODU;
        entity.ANTIBIYOTIK_KODU = dto.ANTIBIYOTIK_KODU;
        entity.TETKIK_SONUCU = dto.TETKIK_SONUCU;
        entity.ZON_CAPI = dto.ZON_CAPI;
        entity.ACIKLAMA = dto.ACIKLAMA;
        entity.RAPORDA_GORULME_DURUMU = dto.RAPORDA_GORULME_DURUMU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.AntibiyotikSonuc)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<ANTIBIYOTIK_SONUC>()
            .FirstOrDefaultAsync(e => e.ANTIBIYOTIK_SONUC_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<ANTIBIYOTIK_SONUC>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
