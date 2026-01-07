using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.KanUrunImha;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class KanUrunImhaController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public KanUrunImhaController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.KanUrunImha)]
    public async Task<List<KanUrunImhaDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<KAN_URUN_IMHA>()
            .AsNoTracking()
            .Select(e => new KanUrunImhaDto
            {
                KAN_URUN_IMHA_KODU = e.KAN_URUN_IMHA_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                KAN_STOK_KODU = e.KAN_STOK_KODU,
                KAN_IMHA_NEDENI = e.KAN_IMHA_NEDENI,
                KAN_IMHA_ZAMANI = e.KAN_IMHA_ZAMANI,
                KAN_IMHA_ONAYLAYAN_HEKIM = e.KAN_IMHA_ONAYLAYAN_HEKIM,
                KAN_IMHA_ONAYLAYAN_TEKNISYEN = e.KAN_IMHA_ONAYLAYAN_TEKNISYEN,
                KAN_IMHA_EDEN_PERSONEL_KODU = e.KAN_IMHA_EDEN_PERSONEL_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.KanUrunImha)]
    public async Task<ActionResult<KanUrunImhaDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KAN_URUN_IMHA>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.KAN_URUN_IMHA_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new KanUrunImhaDto
        {
            KAN_URUN_IMHA_KODU = entity.KAN_URUN_IMHA_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            KAN_STOK_KODU = entity.KAN_STOK_KODU,
            KAN_IMHA_NEDENI = entity.KAN_IMHA_NEDENI,
            KAN_IMHA_ZAMANI = entity.KAN_IMHA_ZAMANI,
            KAN_IMHA_ONAYLAYAN_HEKIM = entity.KAN_IMHA_ONAYLAYAN_HEKIM,
            KAN_IMHA_ONAYLAYAN_TEKNISYEN = entity.KAN_IMHA_ONAYLAYAN_TEKNISYEN,
            KAN_IMHA_EDEN_PERSONEL_KODU = entity.KAN_IMHA_EDEN_PERSONEL_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.KanUrunImha)]
    public async Task<ActionResult<string>> Create(KanUrunImhaDto dto, CancellationToken ct)
    {
        var entity = new KAN_URUN_IMHA
        {
            KAN_URUN_IMHA_KODU = dto.KAN_URUN_IMHA_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            KAN_STOK_KODU = dto.KAN_STOK_KODU,
            KAN_IMHA_NEDENI = dto.KAN_IMHA_NEDENI,
            KAN_IMHA_ZAMANI = dto.KAN_IMHA_ZAMANI,
            KAN_IMHA_ONAYLAYAN_HEKIM = dto.KAN_IMHA_ONAYLAYAN_HEKIM,
            KAN_IMHA_ONAYLAYAN_TEKNISYEN = dto.KAN_IMHA_ONAYLAYAN_TEKNISYEN,
            KAN_IMHA_EDEN_PERSONEL_KODU = dto.KAN_IMHA_EDEN_PERSONEL_KODU,
        };

        _db.Set<KAN_URUN_IMHA>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.KAN_URUN_IMHA_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.KanUrunImha)]
    public async Task<IActionResult> Update(string id, KanUrunImhaDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<KAN_URUN_IMHA>()
            .FirstOrDefaultAsync(e => e.KAN_URUN_IMHA_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.KAN_STOK_KODU = dto.KAN_STOK_KODU;
        entity.KAN_IMHA_NEDENI = dto.KAN_IMHA_NEDENI;
        entity.KAN_IMHA_ZAMANI = dto.KAN_IMHA_ZAMANI;
        entity.KAN_IMHA_ONAYLAYAN_HEKIM = dto.KAN_IMHA_ONAYLAYAN_HEKIM;
        entity.KAN_IMHA_ONAYLAYAN_TEKNISYEN = dto.KAN_IMHA_ONAYLAYAN_TEKNISYEN;
        entity.KAN_IMHA_EDEN_PERSONEL_KODU = dto.KAN_IMHA_EDEN_PERSONEL_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.KanUrunImha)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KAN_URUN_IMHA>()
            .FirstOrDefaultAsync(e => e.KAN_URUN_IMHA_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<KAN_URUN_IMHA>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
