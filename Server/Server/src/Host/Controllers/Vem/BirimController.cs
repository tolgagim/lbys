using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Birim;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class BirimController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public BirimController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Birim)]
    public async Task<List<BirimDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<BIRIM>()
            .AsNoTracking()
            .Select(e => new BirimDto
            {
                BIRIM_KODU = e.BIRIM_KODU,
                BIRIM_ADI = e.BIRIM_ADI,
                BIRIM_TURU = e.BIRIM_TURU,
                AKTIFLIK_BILGISI = e.AKTIFLIK_BILGISI,
                BINA_KODU = e.BINA_KODU,
                KLINIK_KODU = e.KLINIK_KODU,
                MEDULA_BRANS_KODU = e.MEDULA_BRANS_KODU,
                MHRS_ADI = e.MHRS_ADI,
                MHRS_KODU = e.MHRS_KODU,
                MKYS_KODU = e.MKYS_KODU,
                YATAK_SAYISI = e.YATAK_SAYISI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Birim)]
    public async Task<ActionResult<BirimDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<BIRIM>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.BIRIM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new BirimDto
        {
            BIRIM_KODU = entity.BIRIM_KODU,
            BIRIM_ADI = entity.BIRIM_ADI,
            BIRIM_TURU = entity.BIRIM_TURU,
            AKTIFLIK_BILGISI = entity.AKTIFLIK_BILGISI,
            BINA_KODU = entity.BINA_KODU,
            KLINIK_KODU = entity.KLINIK_KODU,
            MEDULA_BRANS_KODU = entity.MEDULA_BRANS_KODU,
            MHRS_ADI = entity.MHRS_ADI,
            MHRS_KODU = entity.MHRS_KODU,
            MKYS_KODU = entity.MKYS_KODU,
            YATAK_SAYISI = entity.YATAK_SAYISI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Birim)]
    public async Task<ActionResult<string>> Create(BirimDto dto, CancellationToken ct)
    {
        var entity = new BIRIM
        {
            BIRIM_KODU = dto.BIRIM_KODU,
            BIRIM_ADI = dto.BIRIM_ADI,
            BIRIM_TURU = dto.BIRIM_TURU,
            AKTIFLIK_BILGISI = dto.AKTIFLIK_BILGISI,
            BINA_KODU = dto.BINA_KODU,
            KLINIK_KODU = dto.KLINIK_KODU,
            MEDULA_BRANS_KODU = dto.MEDULA_BRANS_KODU,
            MHRS_ADI = dto.MHRS_ADI,
            MHRS_KODU = dto.MHRS_KODU,
            MKYS_KODU = dto.MKYS_KODU,
            YATAK_SAYISI = dto.YATAK_SAYISI,
        };

        _db.Set<BIRIM>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.BIRIM_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Birim)]
    public async Task<IActionResult> Update(string id, BirimDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<BIRIM>()
            .FirstOrDefaultAsync(e => e.BIRIM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        entity.BIRIM_ADI = dto.BIRIM_ADI;
        entity.BIRIM_TURU = dto.BIRIM_TURU;
        entity.AKTIFLIK_BILGISI = dto.AKTIFLIK_BILGISI;
        entity.BINA_KODU = dto.BINA_KODU;
        entity.KLINIK_KODU = dto.KLINIK_KODU;
        entity.MEDULA_BRANS_KODU = dto.MEDULA_BRANS_KODU;
        entity.MHRS_ADI = dto.MHRS_ADI;
        entity.MHRS_KODU = dto.MHRS_KODU;
        entity.MKYS_KODU = dto.MKYS_KODU;
        entity.YATAK_SAYISI = dto.YATAK_SAYISI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Birim)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<BIRIM>()
            .FirstOrDefaultAsync(e => e.BIRIM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<BIRIM>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
