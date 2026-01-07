using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.SterilizasyonPaketDetay;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class SterilizasyonPaketDetayController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public SterilizasyonPaketDetayController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.SterilizasyonPaketDetay)]
    public async Task<List<SterilizasyonPaketDetayDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<STERILIZASYON_PAKET_DETAY>()
            .AsNoTracking()
            .Select(e => new SterilizasyonPaketDetayDto
            {
                STERILIZASYON_PAKET_DETAY_KODU = e.STERILIZASYON_PAKET_DETAY_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                STERILIZASYON_PAKET_KODU = e.STERILIZASYON_PAKET_KODU,
                STOK_KART_KODU = e.STOK_KART_KODU,
                STERILIZASYON_MALZEME_MIKTARI = e.STERILIZASYON_MALZEME_MIKTARI,
                OLCU_KODU = e.OLCU_KODU,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.SterilizasyonPaketDetay)]
    public async Task<ActionResult<SterilizasyonPaketDetayDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STERILIZASYON_PAKET_DETAY>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.STERILIZASYON_PAKET_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new SterilizasyonPaketDetayDto
        {
            STERILIZASYON_PAKET_DETAY_KODU = entity.STERILIZASYON_PAKET_DETAY_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            STERILIZASYON_PAKET_KODU = entity.STERILIZASYON_PAKET_KODU,
            STOK_KART_KODU = entity.STOK_KART_KODU,
            STERILIZASYON_MALZEME_MIKTARI = entity.STERILIZASYON_MALZEME_MIKTARI,
            OLCU_KODU = entity.OLCU_KODU,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.SterilizasyonPaketDetay)]
    public async Task<ActionResult<string>> Create(SterilizasyonPaketDetayDto dto, CancellationToken ct)
    {
        var entity = new STERILIZASYON_PAKET_DETAY
        {
            STERILIZASYON_PAKET_DETAY_KODU = dto.STERILIZASYON_PAKET_DETAY_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            STERILIZASYON_PAKET_KODU = dto.STERILIZASYON_PAKET_KODU,
            STOK_KART_KODU = dto.STOK_KART_KODU,
            STERILIZASYON_MALZEME_MIKTARI = dto.STERILIZASYON_MALZEME_MIKTARI,
            OLCU_KODU = dto.OLCU_KODU,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<STERILIZASYON_PAKET_DETAY>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.STERILIZASYON_PAKET_DETAY_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.SterilizasyonPaketDetay)]
    public async Task<IActionResult> Update(string id, SterilizasyonPaketDetayDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<STERILIZASYON_PAKET_DETAY>()
            .FirstOrDefaultAsync(e => e.STERILIZASYON_PAKET_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.STERILIZASYON_PAKET_KODU = dto.STERILIZASYON_PAKET_KODU;
        entity.STOK_KART_KODU = dto.STOK_KART_KODU;
        entity.STERILIZASYON_MALZEME_MIKTARI = dto.STERILIZASYON_MALZEME_MIKTARI;
        entity.OLCU_KODU = dto.OLCU_KODU;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.SterilizasyonPaketDetay)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STERILIZASYON_PAKET_DETAY>()
            .FirstOrDefaultAsync(e => e.STERILIZASYON_PAKET_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<STERILIZASYON_PAKET_DETAY>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
