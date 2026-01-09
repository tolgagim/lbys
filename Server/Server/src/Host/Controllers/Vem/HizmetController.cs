using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Hizmet;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class HizmetController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public HizmetController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Hizmet)]
    public async Task<List<HizmetDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<HIZMET>()
            .AsNoTracking()
            .Select(e => new HizmetDto
            {
                HIZMET_KODU = e.HIZMET_KODU,
                HIZMET_ISLEM_GRUBU = e.HIZMET_ISLEM_GRUBU,
                HIZMET_ISLEM_TURU = e.HIZMET_ISLEM_TURU,
                SUT_KODU = e.SUT_KODU,
                HIZMET_ADI = e.HIZMET_ADI,
                TIBBI_ISLEM_PUAN_BILGISI = e.TIBBI_ISLEM_PUAN_BILGISI,
                AKTIFLIK_BILGISI = e.AKTIFLIK_BILGISI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Hizmet)]
    public async Task<ActionResult<HizmetDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HIZMET>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.HIZMET_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new HizmetDto
        {
            HIZMET_KODU = entity.HIZMET_KODU,
            HIZMET_ISLEM_GRUBU = entity.HIZMET_ISLEM_GRUBU,
            HIZMET_ISLEM_TURU = entity.HIZMET_ISLEM_TURU,
            SUT_KODU = entity.SUT_KODU,
            HIZMET_ADI = entity.HIZMET_ADI,
            TIBBI_ISLEM_PUAN_BILGISI = entity.TIBBI_ISLEM_PUAN_BILGISI,
            AKTIFLIK_BILGISI = entity.AKTIFLIK_BILGISI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Hizmet)]
    public async Task<ActionResult<string>> Create(HizmetDto dto, CancellationToken ct)
    {
        var entity = new HIZMET
        {
            HIZMET_KODU = dto.HIZMET_KODU,
            HIZMET_ISLEM_GRUBU = dto.HIZMET_ISLEM_GRUBU,
            HIZMET_ISLEM_TURU = dto.HIZMET_ISLEM_TURU,
            SUT_KODU = dto.SUT_KODU,
            HIZMET_ADI = dto.HIZMET_ADI,
            TIBBI_ISLEM_PUAN_BILGISI = dto.TIBBI_ISLEM_PUAN_BILGISI,
            AKTIFLIK_BILGISI = dto.AKTIFLIK_BILGISI,
        };

        _db.Set<HIZMET>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.HIZMET_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Hizmet)]
    public async Task<IActionResult> Update(string id, HizmetDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<HIZMET>()
            .FirstOrDefaultAsync(e => e.HIZMET_KODU == id, ct);

        if (entity == null)
            return NotFound();

        entity.HIZMET_ISLEM_GRUBU = dto.HIZMET_ISLEM_GRUBU;
        entity.HIZMET_ISLEM_TURU = dto.HIZMET_ISLEM_TURU;
        entity.SUT_KODU = dto.SUT_KODU;
        entity.HIZMET_ADI = dto.HIZMET_ADI;
        entity.TIBBI_ISLEM_PUAN_BILGISI = dto.TIBBI_ISLEM_PUAN_BILGISI;
        entity.AKTIFLIK_BILGISI = dto.AKTIFLIK_BILGISI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Hizmet)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HIZMET>()
            .FirstOrDefaultAsync(e => e.HIZMET_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<HIZMET>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
