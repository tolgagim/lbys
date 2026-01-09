using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.EkOdemeDonem;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class EkOdemeDonemController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public EkOdemeDonemController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.EkOdemeDonem)]
    public async Task<List<EkOdemeDonemDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<EK_ODEME_DONEM>()
            .AsNoTracking()
            .Select(e => new EkOdemeDonemDto
            {
                EK_ODEME_DONEM_KODU = e.EK_ODEME_DONEM_KODU,
YIL = e.YIL,
                AY = e.AY,
                BORDRO_NUMARASI = e.BORDRO_NUMARASI,
                GIRISIMSEL_ISLEM_PUAN_TOPLAMI = e.GIRISIMSEL_ISLEM_PUAN_TOPLAMI,
                OZELLIKLI_ISLEM_PUAN_TOPLAMI = e.OZELLIKLI_ISLEM_PUAN_TOPLAMI,
                ACGK_TOPLAMI = e.ACGK_TOPLAMI,
                DAGITILACAK_EKODEME_TUTARI = e.DAGITILACAK_EKODEME_TUTARI,
                EK_ODEME_KATSAYISI = e.EK_ODEME_KATSAYISI,
                HASTANE_PUAN_ORTALAMASI = e.HASTANE_PUAN_ORTALAMASI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.EkOdemeDonem)]
    public async Task<ActionResult<EkOdemeDonemDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<EK_ODEME_DONEM>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.EK_ODEME_DONEM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new EkOdemeDonemDto
        {
            EK_ODEME_DONEM_KODU = entity.EK_ODEME_DONEM_KODU,
YIL = entity.YIL,
            AY = entity.AY,
            BORDRO_NUMARASI = entity.BORDRO_NUMARASI,
            GIRISIMSEL_ISLEM_PUAN_TOPLAMI = entity.GIRISIMSEL_ISLEM_PUAN_TOPLAMI,
            OZELLIKLI_ISLEM_PUAN_TOPLAMI = entity.OZELLIKLI_ISLEM_PUAN_TOPLAMI,
            ACGK_TOPLAMI = entity.ACGK_TOPLAMI,
            DAGITILACAK_EKODEME_TUTARI = entity.DAGITILACAK_EKODEME_TUTARI,
            EK_ODEME_KATSAYISI = entity.EK_ODEME_KATSAYISI,
            HASTANE_PUAN_ORTALAMASI = entity.HASTANE_PUAN_ORTALAMASI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.EkOdemeDonem)]
    public async Task<ActionResult<string>> Create(EkOdemeDonemDto dto, CancellationToken ct)
    {
        var entity = new EK_ODEME_DONEM
        {
            EK_ODEME_DONEM_KODU = dto.EK_ODEME_DONEM_KODU,
YIL = dto.YIL,
            AY = dto.AY,
            BORDRO_NUMARASI = dto.BORDRO_NUMARASI,
            GIRISIMSEL_ISLEM_PUAN_TOPLAMI = dto.GIRISIMSEL_ISLEM_PUAN_TOPLAMI,
            OZELLIKLI_ISLEM_PUAN_TOPLAMI = dto.OZELLIKLI_ISLEM_PUAN_TOPLAMI,
            ACGK_TOPLAMI = dto.ACGK_TOPLAMI,
            DAGITILACAK_EKODEME_TUTARI = dto.DAGITILACAK_EKODEME_TUTARI,
            EK_ODEME_KATSAYISI = dto.EK_ODEME_KATSAYISI,
            HASTANE_PUAN_ORTALAMASI = dto.HASTANE_PUAN_ORTALAMASI,
        };

        _db.Set<EK_ODEME_DONEM>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.EK_ODEME_DONEM_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.EkOdemeDonem)]
    public async Task<IActionResult> Update(string id, EkOdemeDonemDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<EK_ODEME_DONEM>()
            .FirstOrDefaultAsync(e => e.EK_ODEME_DONEM_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.YIL = dto.YIL;
        entity.AY = dto.AY;
        entity.BORDRO_NUMARASI = dto.BORDRO_NUMARASI;
        entity.GIRISIMSEL_ISLEM_PUAN_TOPLAMI = dto.GIRISIMSEL_ISLEM_PUAN_TOPLAMI;
        entity.OZELLIKLI_ISLEM_PUAN_TOPLAMI = dto.OZELLIKLI_ISLEM_PUAN_TOPLAMI;
        entity.ACGK_TOPLAMI = dto.ACGK_TOPLAMI;
        entity.DAGITILACAK_EKODEME_TUTARI = dto.DAGITILACAK_EKODEME_TUTARI;
        entity.EK_ODEME_KATSAYISI = dto.EK_ODEME_KATSAYISI;
        entity.HASTANE_PUAN_ORTALAMASI = dto.HASTANE_PUAN_ORTALAMASI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.EkOdemeDonem)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<EK_ODEME_DONEM>()
            .FirstOrDefaultAsync(e => e.EK_ODEME_DONEM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<EK_ODEME_DONEM>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
