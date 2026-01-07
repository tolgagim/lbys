using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.BakteriSonuc;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class BakteriSonucController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public BakteriSonucController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.BakteriSonuc)]
    public async Task<List<BakteriSonucDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<BAKTERI_SONUC>()
            .AsNoTracking()
            .Select(e => new BakteriSonucDto
            {
                BAKTERI_SONUC_KODU = e.BAKTERI_SONUC_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                TETKIK_SONUC_KODU = e.TETKIK_SONUC_KODU,
                BAKTERI_KODU = e.BAKTERI_KODU,
                KOLONI_SAYISI = e.KOLONI_SAYISI,
                RAPOR_SONUC_SIRASI = e.RAPOR_SONUC_SIRASI,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.BakteriSonuc)]
    public async Task<ActionResult<BakteriSonucDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<BAKTERI_SONUC>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.BAKTERI_SONUC_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new BakteriSonucDto
        {
            BAKTERI_SONUC_KODU = entity.BAKTERI_SONUC_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            TETKIK_SONUC_KODU = entity.TETKIK_SONUC_KODU,
            BAKTERI_KODU = entity.BAKTERI_KODU,
            KOLONI_SAYISI = entity.KOLONI_SAYISI,
            RAPOR_SONUC_SIRASI = entity.RAPOR_SONUC_SIRASI,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.BakteriSonuc)]
    public async Task<ActionResult<string>> Create(BakteriSonucDto dto, CancellationToken ct)
    {
        var entity = new BAKTERI_SONUC
        {
            BAKTERI_SONUC_KODU = dto.BAKTERI_SONUC_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            TETKIK_SONUC_KODU = dto.TETKIK_SONUC_KODU,
            BAKTERI_KODU = dto.BAKTERI_KODU,
            KOLONI_SAYISI = dto.KOLONI_SAYISI,
            RAPOR_SONUC_SIRASI = dto.RAPOR_SONUC_SIRASI,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<BAKTERI_SONUC>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.BAKTERI_SONUC_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.BakteriSonuc)]
    public async Task<IActionResult> Update(string id, BakteriSonucDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<BAKTERI_SONUC>()
            .FirstOrDefaultAsync(e => e.BAKTERI_SONUC_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.TETKIK_SONUC_KODU = dto.TETKIK_SONUC_KODU;
        entity.BAKTERI_KODU = dto.BAKTERI_KODU;
        entity.KOLONI_SAYISI = dto.KOLONI_SAYISI;
        entity.RAPOR_SONUC_SIRASI = dto.RAPOR_SONUC_SIRASI;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.BakteriSonuc)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<BAKTERI_SONUC>()
            .FirstOrDefaultAsync(e => e.BAKTERI_SONUC_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<BAKTERI_SONUC>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
