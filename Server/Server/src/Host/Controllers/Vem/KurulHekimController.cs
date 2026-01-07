using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.KurulHekim;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class KurulHekimController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public KurulHekimController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.KurulHekim)]
    public async Task<List<KurulHekimDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<KURUL_HEKIM>()
            .AsNoTracking()
            .Select(e => new KurulHekimDto
            {
                KURUL_HEKIM_KODU = e.KURUL_HEKIM_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                HASTA_KODU = e.HASTA_KODU,
                KURUL_RAPOR_KODU = e.KURUL_RAPOR_KODU,
                HEKIM_KODU = e.HEKIM_KODU,
                MEDULA_BRANS_KODU = e.MEDULA_BRANS_KODU,
                SISTEM_KODU = e.SISTEM_KODU,
                KURUL_SONUC = e.KURUL_SONUC,
                ENGELLILIK_ORANI = e.ENGELLILIK_ORANI,
                HEKIM_KURUL_GOREVI = e.HEKIM_KURUL_GOREVI,
                HEKIM_SIRA_NUMARASI = e.HEKIM_SIRA_NUMARASI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.KurulHekim)]
    public async Task<ActionResult<KurulHekimDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KURUL_HEKIM>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.KURUL_HEKIM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new KurulHekimDto
        {
            KURUL_HEKIM_KODU = entity.KURUL_HEKIM_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            HASTA_KODU = entity.HASTA_KODU,
            KURUL_RAPOR_KODU = entity.KURUL_RAPOR_KODU,
            HEKIM_KODU = entity.HEKIM_KODU,
            MEDULA_BRANS_KODU = entity.MEDULA_BRANS_KODU,
            SISTEM_KODU = entity.SISTEM_KODU,
            KURUL_SONUC = entity.KURUL_SONUC,
            ENGELLILIK_ORANI = entity.ENGELLILIK_ORANI,
            HEKIM_KURUL_GOREVI = entity.HEKIM_KURUL_GOREVI,
            HEKIM_SIRA_NUMARASI = entity.HEKIM_SIRA_NUMARASI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.KurulHekim)]
    public async Task<ActionResult<string>> Create(KurulHekimDto dto, CancellationToken ct)
    {
        var entity = new KURUL_HEKIM
        {
            KURUL_HEKIM_KODU = dto.KURUL_HEKIM_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            HASTA_KODU = dto.HASTA_KODU,
            KURUL_RAPOR_KODU = dto.KURUL_RAPOR_KODU,
            HEKIM_KODU = dto.HEKIM_KODU,
            MEDULA_BRANS_KODU = dto.MEDULA_BRANS_KODU,
            SISTEM_KODU = dto.SISTEM_KODU,
            KURUL_SONUC = dto.KURUL_SONUC,
            ENGELLILIK_ORANI = dto.ENGELLILIK_ORANI,
            HEKIM_KURUL_GOREVI = dto.HEKIM_KURUL_GOREVI,
            HEKIM_SIRA_NUMARASI = dto.HEKIM_SIRA_NUMARASI,
        };

        _db.Set<KURUL_HEKIM>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.KURUL_HEKIM_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.KurulHekim)]
    public async Task<IActionResult> Update(string id, KurulHekimDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<KURUL_HEKIM>()
            .FirstOrDefaultAsync(e => e.KURUL_HEKIM_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.KURUL_RAPOR_KODU = dto.KURUL_RAPOR_KODU;
        entity.HEKIM_KODU = dto.HEKIM_KODU;
        entity.MEDULA_BRANS_KODU = dto.MEDULA_BRANS_KODU;
        entity.SISTEM_KODU = dto.SISTEM_KODU;
        entity.KURUL_SONUC = dto.KURUL_SONUC;
        entity.ENGELLILIK_ORANI = dto.ENGELLILIK_ORANI;
        entity.HEKIM_KURUL_GOREVI = dto.HEKIM_KURUL_GOREVI;
        entity.HEKIM_SIRA_NUMARASI = dto.HEKIM_SIRA_NUMARASI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.KurulHekim)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KURUL_HEKIM>()
            .FirstOrDefaultAsync(e => e.KURUL_HEKIM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<KURUL_HEKIM>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
