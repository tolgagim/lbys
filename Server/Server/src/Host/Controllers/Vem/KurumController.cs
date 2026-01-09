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
                AKTIFLIK_BILGISI = e.AKTIFLIK_BILGISI,
                AYAKTAN_BUTCE_KODU = e.AYAKTAN_BUTCE_KODU,
                DEVREDILEN_KURUM = e.DEVREDILEN_KURUM,
                GUNUBIRLIK_BUTCE_KODU = e.GUNUBIRLIK_BUTCE_KODU,
                HASTA_KURUM_TURU = e.HASTA_KURUM_TURU,
                KURUM_ADRESI = e.KURUM_ADRESI,
                SKRS_KURUM_KODU = e.SKRS_KURUM_KODU,
                YATAN_BUTCE_KODU = e.YATAN_BUTCE_KODU,
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
            AKTIFLIK_BILGISI = entity.AKTIFLIK_BILGISI,
            AYAKTAN_BUTCE_KODU = entity.AYAKTAN_BUTCE_KODU,
            DEVREDILEN_KURUM = entity.DEVREDILEN_KURUM,
            GUNUBIRLIK_BUTCE_KODU = entity.GUNUBIRLIK_BUTCE_KODU,
            HASTA_KURUM_TURU = entity.HASTA_KURUM_TURU,
            KURUM_ADRESI = entity.KURUM_ADRESI,
            SKRS_KURUM_KODU = entity.SKRS_KURUM_KODU,
            YATAN_BUTCE_KODU = entity.YATAN_BUTCE_KODU,
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
            AKTIFLIK_BILGISI = dto.AKTIFLIK_BILGISI,
            AYAKTAN_BUTCE_KODU = dto.AYAKTAN_BUTCE_KODU,
            DEVREDILEN_KURUM = dto.DEVREDILEN_KURUM,
            GUNUBIRLIK_BUTCE_KODU = dto.GUNUBIRLIK_BUTCE_KODU,
            HASTA_KURUM_TURU = dto.HASTA_KURUM_TURU,
            KURUM_ADRESI = dto.KURUM_ADRESI,
            SKRS_KURUM_KODU = dto.SKRS_KURUM_KODU,
            YATAN_BUTCE_KODU = dto.YATAN_BUTCE_KODU,
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
        entity.AKTIFLIK_BILGISI = dto.AKTIFLIK_BILGISI;
        entity.AYAKTAN_BUTCE_KODU = dto.AYAKTAN_BUTCE_KODU;
        entity.DEVREDILEN_KURUM = dto.DEVREDILEN_KURUM;
        entity.GUNUBIRLIK_BUTCE_KODU = dto.GUNUBIRLIK_BUTCE_KODU;
        entity.HASTA_KURUM_TURU = dto.HASTA_KURUM_TURU;
        entity.KURUM_ADRESI = dto.KURUM_ADRESI;
        entity.SKRS_KURUM_KODU = dto.SKRS_KURUM_KODU;
        entity.YATAN_BUTCE_KODU = dto.YATAN_BUTCE_KODU;

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
