using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.SterilizasyonStokDurum;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class SterilizasyonStokDurumController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public SterilizasyonStokDurumController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.SterilizasyonStokDurum)]
    public async Task<List<SterilizasyonStokDurumDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<STERILIZASYON_STOK_DURUM>()
            .AsNoTracking()
            .Select(e => new SterilizasyonStokDurumDto
            {
                STERILIZASYON_STOK_DURUM_KODU = e.STERILIZASYON_STOK_DURUM_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                DEPO_KODU = e.DEPO_KODU,
                STOK_KART_KODU = e.STOK_KART_KODU,
                STOK_MIKTARI = e.STOK_MIKTARI,
                STERIL_OLMAYAN_STOK_MIKTARI = e.STERIL_OLMAYAN_STOK_MIKTARI,
                STERIL_STOK_MIKTARI = e.STERIL_STOK_MIKTARI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.SterilizasyonStokDurum)]
    public async Task<ActionResult<SterilizasyonStokDurumDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STERILIZASYON_STOK_DURUM>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.STERILIZASYON_STOK_DURUM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new SterilizasyonStokDurumDto
        {
            STERILIZASYON_STOK_DURUM_KODU = entity.STERILIZASYON_STOK_DURUM_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            DEPO_KODU = entity.DEPO_KODU,
            STOK_KART_KODU = entity.STOK_KART_KODU,
            STOK_MIKTARI = entity.STOK_MIKTARI,
            STERIL_OLMAYAN_STOK_MIKTARI = entity.STERIL_OLMAYAN_STOK_MIKTARI,
            STERIL_STOK_MIKTARI = entity.STERIL_STOK_MIKTARI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.SterilizasyonStokDurum)]
    public async Task<ActionResult<string>> Create(SterilizasyonStokDurumDto dto, CancellationToken ct)
    {
        var entity = new STERILIZASYON_STOK_DURUM
        {
            STERILIZASYON_STOK_DURUM_KODU = dto.STERILIZASYON_STOK_DURUM_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            DEPO_KODU = dto.DEPO_KODU,
            STOK_KART_KODU = dto.STOK_KART_KODU,
            STOK_MIKTARI = dto.STOK_MIKTARI,
            STERIL_OLMAYAN_STOK_MIKTARI = dto.STERIL_OLMAYAN_STOK_MIKTARI,
            STERIL_STOK_MIKTARI = dto.STERIL_STOK_MIKTARI,
        };

        _db.Set<STERILIZASYON_STOK_DURUM>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.STERILIZASYON_STOK_DURUM_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.SterilizasyonStokDurum)]
    public async Task<IActionResult> Update(string id, SterilizasyonStokDurumDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<STERILIZASYON_STOK_DURUM>()
            .FirstOrDefaultAsync(e => e.STERILIZASYON_STOK_DURUM_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.DEPO_KODU = dto.DEPO_KODU;
        entity.STOK_KART_KODU = dto.STOK_KART_KODU;
        entity.STOK_MIKTARI = dto.STOK_MIKTARI;
        entity.STERIL_OLMAYAN_STOK_MIKTARI = dto.STERIL_OLMAYAN_STOK_MIKTARI;
        entity.STERIL_STOK_MIKTARI = dto.STERIL_STOK_MIKTARI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.SterilizasyonStokDurum)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STERILIZASYON_STOK_DURUM>()
            .FirstOrDefaultAsync(e => e.STERILIZASYON_STOK_DURUM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<STERILIZASYON_STOK_DURUM>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
