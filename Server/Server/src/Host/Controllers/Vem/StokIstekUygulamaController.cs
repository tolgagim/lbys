using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.StokIstekUygulama;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class StokIstekUygulamaController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public StokIstekUygulamaController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.StokIstekUygulama)]
    public async Task<List<StokIstekUygulamaDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<STOK_ISTEK_UYGULAMA>()
            .AsNoTracking()
            .Select(e => new StokIstekUygulamaDto
            {
                STOK_ISTEK_UYGULAMA_KODU = e.STOK_ISTEK_UYGULAMA_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                STOK_ISTEK_HAREKET_KODU = e.STOK_ISTEK_HAREKET_KODU,
                ORDER_PLANLANAN_ZAMAN = e.ORDER_PLANLANAN_ZAMAN,
                ORDER_UYGULANAN_ZAMAN = e.ORDER_UYGULANAN_ZAMAN,
                UYGULAYAN_HEMSIRE_KODU = e.UYGULAYAN_HEMSIRE_KODU,
                ISTEK_IPTAL_NEDENI = e.ISTEK_IPTAL_NEDENI,
                IPTAL_EDEN_HEMSIRE_KODU = e.IPTAL_EDEN_HEMSIRE_KODU,
                IPTAL_ZAMANI = e.IPTAL_ZAMANI,
                UYGULANAN_MIKTAR = e.UYGULANAN_MIKTAR,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.StokIstekUygulama)]
    public async Task<ActionResult<StokIstekUygulamaDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STOK_ISTEK_UYGULAMA>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.STOK_ISTEK_UYGULAMA_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new StokIstekUygulamaDto
        {
            STOK_ISTEK_UYGULAMA_KODU = entity.STOK_ISTEK_UYGULAMA_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            STOK_ISTEK_HAREKET_KODU = entity.STOK_ISTEK_HAREKET_KODU,
            ORDER_PLANLANAN_ZAMAN = entity.ORDER_PLANLANAN_ZAMAN,
            ORDER_UYGULANAN_ZAMAN = entity.ORDER_UYGULANAN_ZAMAN,
            UYGULAYAN_HEMSIRE_KODU = entity.UYGULAYAN_HEMSIRE_KODU,
            ISTEK_IPTAL_NEDENI = entity.ISTEK_IPTAL_NEDENI,
            IPTAL_EDEN_HEMSIRE_KODU = entity.IPTAL_EDEN_HEMSIRE_KODU,
            IPTAL_ZAMANI = entity.IPTAL_ZAMANI,
            UYGULANAN_MIKTAR = entity.UYGULANAN_MIKTAR,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.StokIstekUygulama)]
    public async Task<ActionResult<string>> Create(StokIstekUygulamaDto dto, CancellationToken ct)
    {
        var entity = new STOK_ISTEK_UYGULAMA
        {
            STOK_ISTEK_UYGULAMA_KODU = dto.STOK_ISTEK_UYGULAMA_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            STOK_ISTEK_HAREKET_KODU = dto.STOK_ISTEK_HAREKET_KODU,
            ORDER_PLANLANAN_ZAMAN = dto.ORDER_PLANLANAN_ZAMAN,
            ORDER_UYGULANAN_ZAMAN = dto.ORDER_UYGULANAN_ZAMAN,
            UYGULAYAN_HEMSIRE_KODU = dto.UYGULAYAN_HEMSIRE_KODU,
            ISTEK_IPTAL_NEDENI = dto.ISTEK_IPTAL_NEDENI,
            IPTAL_EDEN_HEMSIRE_KODU = dto.IPTAL_EDEN_HEMSIRE_KODU,
            IPTAL_ZAMANI = dto.IPTAL_ZAMANI,
            UYGULANAN_MIKTAR = dto.UYGULANAN_MIKTAR,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<STOK_ISTEK_UYGULAMA>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.STOK_ISTEK_UYGULAMA_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.StokIstekUygulama)]
    public async Task<IActionResult> Update(string id, StokIstekUygulamaDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<STOK_ISTEK_UYGULAMA>()
            .FirstOrDefaultAsync(e => e.STOK_ISTEK_UYGULAMA_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.STOK_ISTEK_HAREKET_KODU = dto.STOK_ISTEK_HAREKET_KODU;
        entity.ORDER_PLANLANAN_ZAMAN = dto.ORDER_PLANLANAN_ZAMAN;
        entity.ORDER_UYGULANAN_ZAMAN = dto.ORDER_UYGULANAN_ZAMAN;
        entity.UYGULAYAN_HEMSIRE_KODU = dto.UYGULAYAN_HEMSIRE_KODU;
        entity.ISTEK_IPTAL_NEDENI = dto.ISTEK_IPTAL_NEDENI;
        entity.IPTAL_EDEN_HEMSIRE_KODU = dto.IPTAL_EDEN_HEMSIRE_KODU;
        entity.IPTAL_ZAMANI = dto.IPTAL_ZAMANI;
        entity.UYGULANAN_MIKTAR = dto.UYGULANAN_MIKTAR;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.StokIstekUygulama)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STOK_ISTEK_UYGULAMA>()
            .FirstOrDefaultAsync(e => e.STOK_ISTEK_UYGULAMA_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<STOK_ISTEK_UYGULAMA>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
