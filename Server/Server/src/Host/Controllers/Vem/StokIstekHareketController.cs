using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.StokIstekHareket;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class StokIstekHareketController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public StokIstekHareketController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.StokIstekHareket)]
    public async Task<List<StokIstekHareketDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<STOK_ISTEK_HAREKET>()
            .AsNoTracking()
            .Select(e => new StokIstekHareketDto
            {
                STOK_ISTEK_HAREKET_KODU = e.STOK_ISTEK_HAREKET_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                STOK_ISTEK_KODU = e.STOK_ISTEK_KODU,
                ISTENEN_STOK_KART_KODU = e.ISTENEN_STOK_KART_KODU,
                ISTENEN_ILAC_JENERIK_KODU = e.ISTENEN_ILAC_JENERIK_KODU,
                VERILEN_STOK_KART_KODU = e.VERILEN_STOK_KART_KODU,
                ISTEK_GEREKLILIK_DURUMU = e.ISTEK_GEREKLILIK_DURUMU,
                TEDAVIDE_KULLANILAN_ILAC = e.TEDAVIDE_KULLANILAN_ILAC,
                ISTENEN_MIKTAR = e.ISTENEN_MIKTAR,
                ACIKLAMA = e.ACIKLAMA,
                DEPODAN_VERILEN_MIKTAR = e.DEPODAN_VERILEN_MIKTAR,
                STOK_ISTEK_RET_NEDENI = e.STOK_ISTEK_RET_NEDENI,
                STOK_ISTEK_RET_ZAMANI = e.STOK_ISTEK_RET_ZAMANI,
                STOK_ISTEK_RET_KULLANICI_KODU = e.STOK_ISTEK_RET_KULLANICI_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.StokIstekHareket)]
    public async Task<ActionResult<StokIstekHareketDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STOK_ISTEK_HAREKET>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.STOK_ISTEK_HAREKET_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new StokIstekHareketDto
        {
            STOK_ISTEK_HAREKET_KODU = entity.STOK_ISTEK_HAREKET_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            STOK_ISTEK_KODU = entity.STOK_ISTEK_KODU,
            ISTENEN_STOK_KART_KODU = entity.ISTENEN_STOK_KART_KODU,
            ISTENEN_ILAC_JENERIK_KODU = entity.ISTENEN_ILAC_JENERIK_KODU,
            VERILEN_STOK_KART_KODU = entity.VERILEN_STOK_KART_KODU,
            ISTEK_GEREKLILIK_DURUMU = entity.ISTEK_GEREKLILIK_DURUMU,
            TEDAVIDE_KULLANILAN_ILAC = entity.TEDAVIDE_KULLANILAN_ILAC,
            ISTENEN_MIKTAR = entity.ISTENEN_MIKTAR,
            ACIKLAMA = entity.ACIKLAMA,
            DEPODAN_VERILEN_MIKTAR = entity.DEPODAN_VERILEN_MIKTAR,
            STOK_ISTEK_RET_NEDENI = entity.STOK_ISTEK_RET_NEDENI,
            STOK_ISTEK_RET_ZAMANI = entity.STOK_ISTEK_RET_ZAMANI,
            STOK_ISTEK_RET_KULLANICI_KODU = entity.STOK_ISTEK_RET_KULLANICI_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.StokIstekHareket)]
    public async Task<ActionResult<string>> Create(StokIstekHareketDto dto, CancellationToken ct)
    {
        var entity = new STOK_ISTEK_HAREKET
        {
            STOK_ISTEK_HAREKET_KODU = dto.STOK_ISTEK_HAREKET_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            STOK_ISTEK_KODU = dto.STOK_ISTEK_KODU,
            ISTENEN_STOK_KART_KODU = dto.ISTENEN_STOK_KART_KODU,
            ISTENEN_ILAC_JENERIK_KODU = dto.ISTENEN_ILAC_JENERIK_KODU,
            VERILEN_STOK_KART_KODU = dto.VERILEN_STOK_KART_KODU,
            ISTEK_GEREKLILIK_DURUMU = dto.ISTEK_GEREKLILIK_DURUMU,
            TEDAVIDE_KULLANILAN_ILAC = dto.TEDAVIDE_KULLANILAN_ILAC,
            ISTENEN_MIKTAR = dto.ISTENEN_MIKTAR,
            ACIKLAMA = dto.ACIKLAMA,
            DEPODAN_VERILEN_MIKTAR = dto.DEPODAN_VERILEN_MIKTAR,
            STOK_ISTEK_RET_NEDENI = dto.STOK_ISTEK_RET_NEDENI,
            STOK_ISTEK_RET_ZAMANI = dto.STOK_ISTEK_RET_ZAMANI,
            STOK_ISTEK_RET_KULLANICI_KODU = dto.STOK_ISTEK_RET_KULLANICI_KODU,
        };

        _db.Set<STOK_ISTEK_HAREKET>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.STOK_ISTEK_HAREKET_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.StokIstekHareket)]
    public async Task<IActionResult> Update(string id, StokIstekHareketDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<STOK_ISTEK_HAREKET>()
            .FirstOrDefaultAsync(e => e.STOK_ISTEK_HAREKET_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.STOK_ISTEK_KODU = dto.STOK_ISTEK_KODU;
        entity.ISTENEN_STOK_KART_KODU = dto.ISTENEN_STOK_KART_KODU;
        entity.ISTENEN_ILAC_JENERIK_KODU = dto.ISTENEN_ILAC_JENERIK_KODU;
        entity.VERILEN_STOK_KART_KODU = dto.VERILEN_STOK_KART_KODU;
        entity.ISTEK_GEREKLILIK_DURUMU = dto.ISTEK_GEREKLILIK_DURUMU;
        entity.TEDAVIDE_KULLANILAN_ILAC = dto.TEDAVIDE_KULLANILAN_ILAC;
        entity.ISTENEN_MIKTAR = dto.ISTENEN_MIKTAR;
        entity.ACIKLAMA = dto.ACIKLAMA;
        entity.DEPODAN_VERILEN_MIKTAR = dto.DEPODAN_VERILEN_MIKTAR;
        entity.STOK_ISTEK_RET_NEDENI = dto.STOK_ISTEK_RET_NEDENI;
        entity.STOK_ISTEK_RET_ZAMANI = dto.STOK_ISTEK_RET_ZAMANI;
        entity.STOK_ISTEK_RET_KULLANICI_KODU = dto.STOK_ISTEK_RET_KULLANICI_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.StokIstekHareket)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STOK_ISTEK_HAREKET>()
            .FirstOrDefaultAsync(e => e.STOK_ISTEK_HAREKET_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<STOK_ISTEK_HAREKET>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
