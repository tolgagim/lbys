using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.SterilizasyonYikama;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class SterilizasyonYikamaController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public SterilizasyonYikamaController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.SterilizasyonYikama)]
    public async Task<List<SterilizasyonYikamaDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<STERILIZASYON_YIKAMA>()
            .AsNoTracking()
            .Select(e => new SterilizasyonYikamaDto
            {
                STERILIZASYON_YIKAMA_KODU = e.STERILIZASYON_YIKAMA_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                DEPO_KODU = e.DEPO_KODU,
                STOK_KART_KODU = e.STOK_KART_KODU,
                YIKANAN_ALET_MIKTARI = e.YIKANAN_ALET_MIKTARI,
                STERILIZASYON_YIKAMA_TURU = e.STERILIZASYON_YIKAMA_TURU,
                YIKAMA_YAPAN_PERSONEL_KODU = e.YIKAMA_YAPAN_PERSONEL_KODU,
                YIKAMA_BASLAMA_ZAMANI = e.YIKAMA_BASLAMA_ZAMANI,
                YIKAMA_BITIS_ZAMANI = e.YIKAMA_BITIS_ZAMANI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.SterilizasyonYikama)]
    public async Task<ActionResult<SterilizasyonYikamaDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STERILIZASYON_YIKAMA>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.STERILIZASYON_YIKAMA_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new SterilizasyonYikamaDto
        {
            STERILIZASYON_YIKAMA_KODU = entity.STERILIZASYON_YIKAMA_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            DEPO_KODU = entity.DEPO_KODU,
            STOK_KART_KODU = entity.STOK_KART_KODU,
            YIKANAN_ALET_MIKTARI = entity.YIKANAN_ALET_MIKTARI,
            STERILIZASYON_YIKAMA_TURU = entity.STERILIZASYON_YIKAMA_TURU,
            YIKAMA_YAPAN_PERSONEL_KODU = entity.YIKAMA_YAPAN_PERSONEL_KODU,
            YIKAMA_BASLAMA_ZAMANI = entity.YIKAMA_BASLAMA_ZAMANI,
            YIKAMA_BITIS_ZAMANI = entity.YIKAMA_BITIS_ZAMANI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.SterilizasyonYikama)]
    public async Task<ActionResult<string>> Create(SterilizasyonYikamaDto dto, CancellationToken ct)
    {
        var entity = new STERILIZASYON_YIKAMA
        {
            STERILIZASYON_YIKAMA_KODU = dto.STERILIZASYON_YIKAMA_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            DEPO_KODU = dto.DEPO_KODU,
            STOK_KART_KODU = dto.STOK_KART_KODU,
            YIKANAN_ALET_MIKTARI = dto.YIKANAN_ALET_MIKTARI,
            STERILIZASYON_YIKAMA_TURU = dto.STERILIZASYON_YIKAMA_TURU,
            YIKAMA_YAPAN_PERSONEL_KODU = dto.YIKAMA_YAPAN_PERSONEL_KODU,
            YIKAMA_BASLAMA_ZAMANI = dto.YIKAMA_BASLAMA_ZAMANI,
            YIKAMA_BITIS_ZAMANI = dto.YIKAMA_BITIS_ZAMANI,
        };

        _db.Set<STERILIZASYON_YIKAMA>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.STERILIZASYON_YIKAMA_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.SterilizasyonYikama)]
    public async Task<IActionResult> Update(string id, SterilizasyonYikamaDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<STERILIZASYON_YIKAMA>()
            .FirstOrDefaultAsync(e => e.STERILIZASYON_YIKAMA_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.DEPO_KODU = dto.DEPO_KODU;
        entity.STOK_KART_KODU = dto.STOK_KART_KODU;
        entity.YIKANAN_ALET_MIKTARI = dto.YIKANAN_ALET_MIKTARI;
        entity.STERILIZASYON_YIKAMA_TURU = dto.STERILIZASYON_YIKAMA_TURU;
        entity.YIKAMA_YAPAN_PERSONEL_KODU = dto.YIKAMA_YAPAN_PERSONEL_KODU;
        entity.YIKAMA_BASLAMA_ZAMANI = dto.YIKAMA_BASLAMA_ZAMANI;
        entity.YIKAMA_BITIS_ZAMANI = dto.YIKAMA_BITIS_ZAMANI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.SterilizasyonYikama)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STERILIZASYON_YIKAMA>()
            .FirstOrDefaultAsync(e => e.STERILIZASYON_YIKAMA_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<STERILIZASYON_YIKAMA>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
