using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Fatura;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class FaturaController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public FaturaController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Fatura)]
    public async Task<List<FaturaDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<FATURA>()
            .AsNoTracking()
            .Select(e => new FaturaDto
            {
                FATURA_KODU = e.FATURA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                HASTA_KODU = e.HASTA_KODU,
                FATURA_DONEMI = e.FATURA_DONEMI,
                ICMAL_KODU = e.ICMAL_KODU,
                FATURA_TURU = e.FATURA_TURU,
                FATURA_ADI = e.FATURA_ADI,
                FATURA_ZAMANI = e.FATURA_ZAMANI,
                FATURA_TUTARI = e.FATURA_TUTARI,
                FATURA_NUMARASI = e.FATURA_NUMARASI,
                MEDULA_TESLIM_NUMARASI = e.MEDULA_TESLIM_NUMARASI,
                FATURA_KESILEN_KURUM_KODU = e.FATURA_KESILEN_KURUM_KODU,
                BUTCE_KODU = e.BUTCE_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Fatura)]
    public async Task<ActionResult<FaturaDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<FATURA>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.FATURA_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new FaturaDto
        {
            FATURA_KODU = entity.FATURA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            HASTA_KODU = entity.HASTA_KODU,
            FATURA_DONEMI = entity.FATURA_DONEMI,
            ICMAL_KODU = entity.ICMAL_KODU,
            FATURA_TURU = entity.FATURA_TURU,
            FATURA_ADI = entity.FATURA_ADI,
            FATURA_ZAMANI = entity.FATURA_ZAMANI,
            FATURA_TUTARI = entity.FATURA_TUTARI,
            FATURA_NUMARASI = entity.FATURA_NUMARASI,
            MEDULA_TESLIM_NUMARASI = entity.MEDULA_TESLIM_NUMARASI,
            FATURA_KESILEN_KURUM_KODU = entity.FATURA_KESILEN_KURUM_KODU,
            BUTCE_KODU = entity.BUTCE_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Fatura)]
    public async Task<ActionResult<string>> Create(FaturaDto dto, CancellationToken ct)
    {
        var entity = new FATURA
        {
            FATURA_KODU = dto.FATURA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            HASTA_KODU = dto.HASTA_KODU,
            FATURA_DONEMI = dto.FATURA_DONEMI,
            ICMAL_KODU = dto.ICMAL_KODU,
            FATURA_TURU = dto.FATURA_TURU,
            FATURA_ADI = dto.FATURA_ADI,
            FATURA_ZAMANI = dto.FATURA_ZAMANI,
            FATURA_TUTARI = dto.FATURA_TUTARI,
            FATURA_NUMARASI = dto.FATURA_NUMARASI,
            MEDULA_TESLIM_NUMARASI = dto.MEDULA_TESLIM_NUMARASI,
            FATURA_KESILEN_KURUM_KODU = dto.FATURA_KESILEN_KURUM_KODU,
            BUTCE_KODU = dto.BUTCE_KODU,
        };

        _db.Set<FATURA>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.FATURA_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Fatura)]
    public async Task<IActionResult> Update(string id, FaturaDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<FATURA>()
            .FirstOrDefaultAsync(e => e.FATURA_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.FATURA_DONEMI = dto.FATURA_DONEMI;
        entity.ICMAL_KODU = dto.ICMAL_KODU;
        entity.FATURA_TURU = dto.FATURA_TURU;
        entity.FATURA_ADI = dto.FATURA_ADI;
        entity.FATURA_ZAMANI = dto.FATURA_ZAMANI;
        entity.FATURA_TUTARI = dto.FATURA_TUTARI;
        entity.FATURA_NUMARASI = dto.FATURA_NUMARASI;
        entity.MEDULA_TESLIM_NUMARASI = dto.MEDULA_TESLIM_NUMARASI;
        entity.FATURA_KESILEN_KURUM_KODU = dto.FATURA_KESILEN_KURUM_KODU;
        entity.BUTCE_KODU = dto.BUTCE_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Fatura)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<FATURA>()
            .FirstOrDefaultAsync(e => e.FATURA_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<FATURA>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
