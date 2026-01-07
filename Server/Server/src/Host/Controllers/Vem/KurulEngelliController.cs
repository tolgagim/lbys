using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.KurulEngelli;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class KurulEngelliController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public KurulEngelliController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.KurulEngelli)]
    public async Task<List<KurulEngelliDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<KURUL_ENGELLI>()
            .AsNoTracking()
            .Select(e => new KurulEngelliDto
            {
                KURUL_ENGELLI_KODU = e.KURUL_ENGELLI_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                KURUL_RAPOR_KODU = e.KURUL_RAPOR_KODU,
                CALISTIRILAMAYACAK_ISNITELIGI = e.CALISTIRILAMAYACAK_ISNITELIGI,
                ENGELLI_SUREKLILIK_DURUMU = e.ENGELLI_SUREKLILIK_DURUMU,
                AGIR_ENGELLI = e.AGIR_ENGELLI,
                ENGELLI_GRUBU = e.ENGELLI_GRUBU,
                ENGELLI_RAPOR_KULLANIM_AMACI = e.ENGELLI_RAPOR_KULLANIM_AMACI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.KurulEngelli)]
    public async Task<ActionResult<KurulEngelliDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KURUL_ENGELLI>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.KURUL_ENGELLI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new KurulEngelliDto
        {
            KURUL_ENGELLI_KODU = entity.KURUL_ENGELLI_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            KURUL_RAPOR_KODU = entity.KURUL_RAPOR_KODU,
            CALISTIRILAMAYACAK_ISNITELIGI = entity.CALISTIRILAMAYACAK_ISNITELIGI,
            ENGELLI_SUREKLILIK_DURUMU = entity.ENGELLI_SUREKLILIK_DURUMU,
            AGIR_ENGELLI = entity.AGIR_ENGELLI,
            ENGELLI_GRUBU = entity.ENGELLI_GRUBU,
            ENGELLI_RAPOR_KULLANIM_AMACI = entity.ENGELLI_RAPOR_KULLANIM_AMACI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.KurulEngelli)]
    public async Task<ActionResult<string>> Create(KurulEngelliDto dto, CancellationToken ct)
    {
        var entity = new KURUL_ENGELLI
        {
            KURUL_ENGELLI_KODU = dto.KURUL_ENGELLI_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            KURUL_RAPOR_KODU = dto.KURUL_RAPOR_KODU,
            CALISTIRILAMAYACAK_ISNITELIGI = dto.CALISTIRILAMAYACAK_ISNITELIGI,
            ENGELLI_SUREKLILIK_DURUMU = dto.ENGELLI_SUREKLILIK_DURUMU,
            AGIR_ENGELLI = dto.AGIR_ENGELLI,
            ENGELLI_GRUBU = dto.ENGELLI_GRUBU,
            ENGELLI_RAPOR_KULLANIM_AMACI = dto.ENGELLI_RAPOR_KULLANIM_AMACI,
        };

        _db.Set<KURUL_ENGELLI>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.KURUL_ENGELLI_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.KurulEngelli)]
    public async Task<IActionResult> Update(string id, KurulEngelliDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<KURUL_ENGELLI>()
            .FirstOrDefaultAsync(e => e.KURUL_ENGELLI_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.KURUL_RAPOR_KODU = dto.KURUL_RAPOR_KODU;
        entity.CALISTIRILAMAYACAK_ISNITELIGI = dto.CALISTIRILAMAYACAK_ISNITELIGI;
        entity.ENGELLI_SUREKLILIK_DURUMU = dto.ENGELLI_SUREKLILIK_DURUMU;
        entity.AGIR_ENGELLI = dto.AGIR_ENGELLI;
        entity.ENGELLI_GRUBU = dto.ENGELLI_GRUBU;
        entity.ENGELLI_RAPOR_KULLANIM_AMACI = dto.ENGELLI_RAPOR_KULLANIM_AMACI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.KurulEngelli)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KURUL_ENGELLI>()
            .FirstOrDefaultAsync(e => e.KURUL_ENGELLI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<KURUL_ENGELLI>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
