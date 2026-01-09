using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.AmeliyatIslem;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class AmeliyatIslemController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public AmeliyatIslemController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.AmeliyatIslem)]
    public async Task<List<AmeliyatIslemDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<AMELIYAT_ISLEM>()
            .AsNoTracking()
            .Select(e => new AmeliyatIslemDto
            {
                AMELIYAT_ISLEM_KODU = e.AMELIYAT_ISLEM_KODU,
AMELIYAT_KODU = e.AMELIYAT_KODU,
                AMELIYAT_GRUBU = e.AMELIYAT_GRUBU,
                HASTA_HIZMET_KODU = e.HASTA_HIZMET_KODU,
                KESI_SAYISI = e.KESI_SAYISI,
                KESI_ORANI = e.KESI_ORANI,
                KESI_SEANS_BILGISI = e.KESI_SEANS_BILGISI,
                TARAF_BILGISI = e.TARAF_BILGISI,
                KOMPLIKASYON = e.KOMPLIKASYON,
                AMELIYAT_SONUCU = e.AMELIYAT_SONUCU,
                AMELIYAT_NOTU = e.AMELIYAT_NOTU,
                ASA_SKORU = e.ASA_SKORU,
                EUROSCORE = e.EUROSCORE,
                YARA_SINIFI = e.YARA_SINIFI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.AmeliyatIslem)]
    public async Task<ActionResult<AmeliyatIslemDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<AMELIYAT_ISLEM>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.AMELIYAT_ISLEM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new AmeliyatIslemDto
        {
            AMELIYAT_ISLEM_KODU = entity.AMELIYAT_ISLEM_KODU,
AMELIYAT_KODU = entity.AMELIYAT_KODU,
            AMELIYAT_GRUBU = entity.AMELIYAT_GRUBU,
            HASTA_HIZMET_KODU = entity.HASTA_HIZMET_KODU,
            KESI_SAYISI = entity.KESI_SAYISI,
            KESI_ORANI = entity.KESI_ORANI,
            KESI_SEANS_BILGISI = entity.KESI_SEANS_BILGISI,
            TARAF_BILGISI = entity.TARAF_BILGISI,
            KOMPLIKASYON = entity.KOMPLIKASYON,
            AMELIYAT_SONUCU = entity.AMELIYAT_SONUCU,
            AMELIYAT_NOTU = entity.AMELIYAT_NOTU,
            ASA_SKORU = entity.ASA_SKORU,
            EUROSCORE = entity.EUROSCORE,
            YARA_SINIFI = entity.YARA_SINIFI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.AmeliyatIslem)]
    public async Task<ActionResult<string>> Create(AmeliyatIslemDto dto, CancellationToken ct)
    {
        var entity = new AMELIYAT_ISLEM
        {
            AMELIYAT_ISLEM_KODU = dto.AMELIYAT_ISLEM_KODU,
AMELIYAT_KODU = dto.AMELIYAT_KODU,
            AMELIYAT_GRUBU = dto.AMELIYAT_GRUBU,
            HASTA_HIZMET_KODU = dto.HASTA_HIZMET_KODU,
            KESI_SAYISI = dto.KESI_SAYISI,
            KESI_ORANI = dto.KESI_ORANI,
            KESI_SEANS_BILGISI = dto.KESI_SEANS_BILGISI,
            TARAF_BILGISI = dto.TARAF_BILGISI,
            KOMPLIKASYON = dto.KOMPLIKASYON,
            AMELIYAT_SONUCU = dto.AMELIYAT_SONUCU,
            AMELIYAT_NOTU = dto.AMELIYAT_NOTU,
            ASA_SKORU = dto.ASA_SKORU,
            EUROSCORE = dto.EUROSCORE,
            YARA_SINIFI = dto.YARA_SINIFI,
        };

        _db.Set<AMELIYAT_ISLEM>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.AMELIYAT_ISLEM_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.AmeliyatIslem)]
    public async Task<IActionResult> Update(string id, AmeliyatIslemDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<AMELIYAT_ISLEM>()
            .FirstOrDefaultAsync(e => e.AMELIYAT_ISLEM_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.AMELIYAT_KODU = dto.AMELIYAT_KODU;
        entity.AMELIYAT_GRUBU = dto.AMELIYAT_GRUBU;
        entity.HASTA_HIZMET_KODU = dto.HASTA_HIZMET_KODU;
        entity.KESI_SAYISI = dto.KESI_SAYISI;
        entity.KESI_ORANI = dto.KESI_ORANI;
        entity.KESI_SEANS_BILGISI = dto.KESI_SEANS_BILGISI;
        entity.TARAF_BILGISI = dto.TARAF_BILGISI;
        entity.KOMPLIKASYON = dto.KOMPLIKASYON;
        entity.AMELIYAT_SONUCU = dto.AMELIYAT_SONUCU;
        entity.AMELIYAT_NOTU = dto.AMELIYAT_NOTU;
        entity.ASA_SKORU = dto.ASA_SKORU;
        entity.EUROSCORE = dto.EUROSCORE;
        entity.YARA_SINIFI = dto.YARA_SINIFI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.AmeliyatIslem)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<AMELIYAT_ISLEM>()
            .FirstOrDefaultAsync(e => e.AMELIYAT_ISLEM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<AMELIYAT_ISLEM>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
