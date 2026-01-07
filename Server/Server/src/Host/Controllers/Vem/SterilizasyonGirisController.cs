using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.SterilizasyonGiris;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class SterilizasyonGirisController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public SterilizasyonGirisController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.SterilizasyonGiris)]
    public async Task<List<SterilizasyonGirisDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<STERILIZASYON_GIRIS>()
            .AsNoTracking()
            .Select(e => new SterilizasyonGirisDto
            {
                STERILIZASYON_GIRIS_KODU = e.STERILIZASYON_GIRIS_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                DEPO_KODU = e.DEPO_KODU,
                STOK_KART_KODU = e.STOK_KART_KODU,
                STERILIZASYON_GIRIS_MIKTARI = e.STERILIZASYON_GIRIS_MIKTARI,
                TESLIM_EDEN_BIRIM_KODU = e.TESLIM_EDEN_BIRIM_KODU,
                TESLIM_EDEN_PERSONEL_KODU = e.TESLIM_EDEN_PERSONEL_KODU,
                TESLIM_ZAMANI = e.TESLIM_ZAMANI,
                TESLIM_ALAN_PERSONEL_KODU = e.TESLIM_ALAN_PERSONEL_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.SterilizasyonGiris)]
    public async Task<ActionResult<SterilizasyonGirisDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STERILIZASYON_GIRIS>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.STERILIZASYON_GIRIS_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new SterilizasyonGirisDto
        {
            STERILIZASYON_GIRIS_KODU = entity.STERILIZASYON_GIRIS_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            DEPO_KODU = entity.DEPO_KODU,
            STOK_KART_KODU = entity.STOK_KART_KODU,
            STERILIZASYON_GIRIS_MIKTARI = entity.STERILIZASYON_GIRIS_MIKTARI,
            TESLIM_EDEN_BIRIM_KODU = entity.TESLIM_EDEN_BIRIM_KODU,
            TESLIM_EDEN_PERSONEL_KODU = entity.TESLIM_EDEN_PERSONEL_KODU,
            TESLIM_ZAMANI = entity.TESLIM_ZAMANI,
            TESLIM_ALAN_PERSONEL_KODU = entity.TESLIM_ALAN_PERSONEL_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.SterilizasyonGiris)]
    public async Task<ActionResult<string>> Create(SterilizasyonGirisDto dto, CancellationToken ct)
    {
        var entity = new STERILIZASYON_GIRIS
        {
            STERILIZASYON_GIRIS_KODU = dto.STERILIZASYON_GIRIS_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            DEPO_KODU = dto.DEPO_KODU,
            STOK_KART_KODU = dto.STOK_KART_KODU,
            STERILIZASYON_GIRIS_MIKTARI = dto.STERILIZASYON_GIRIS_MIKTARI,
            TESLIM_EDEN_BIRIM_KODU = dto.TESLIM_EDEN_BIRIM_KODU,
            TESLIM_EDEN_PERSONEL_KODU = dto.TESLIM_EDEN_PERSONEL_KODU,
            TESLIM_ZAMANI = dto.TESLIM_ZAMANI,
            TESLIM_ALAN_PERSONEL_KODU = dto.TESLIM_ALAN_PERSONEL_KODU,
        };

        _db.Set<STERILIZASYON_GIRIS>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.STERILIZASYON_GIRIS_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.SterilizasyonGiris)]
    public async Task<IActionResult> Update(string id, SterilizasyonGirisDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<STERILIZASYON_GIRIS>()
            .FirstOrDefaultAsync(e => e.STERILIZASYON_GIRIS_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.DEPO_KODU = dto.DEPO_KODU;
        entity.STOK_KART_KODU = dto.STOK_KART_KODU;
        entity.STERILIZASYON_GIRIS_MIKTARI = dto.STERILIZASYON_GIRIS_MIKTARI;
        entity.TESLIM_EDEN_BIRIM_KODU = dto.TESLIM_EDEN_BIRIM_KODU;
        entity.TESLIM_EDEN_PERSONEL_KODU = dto.TESLIM_EDEN_PERSONEL_KODU;
        entity.TESLIM_ZAMANI = dto.TESLIM_ZAMANI;
        entity.TESLIM_ALAN_PERSONEL_KODU = dto.TESLIM_ALAN_PERSONEL_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.SterilizasyonGiris)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STERILIZASYON_GIRIS>()
            .FirstOrDefaultAsync(e => e.STERILIZASYON_GIRIS_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<STERILIZASYON_GIRIS>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
