using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.StokEhuTakip;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class StokEhuTakipController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public StokEhuTakipController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.StokEhuTakip)]
    public async Task<List<StokEhuTakipDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<STOK_EHU_TAKIP>()
            .AsNoTracking()
            .Select(e => new StokEhuTakipDto
            {
                STOK_EHU_TAKIP_KODU = e.STOK_EHU_TAKIP_KODU,
STOK_ISTEK_KODU = e.STOK_ISTEK_KODU,
                STOK_ISTEK_HAREKET_KODU = e.STOK_ISTEK_HAREKET_KODU,
                STOK_KART_KODU = e.STOK_KART_KODU,
                EHU_ONAY_BASLAMA_ZAMANI = e.EHU_ONAY_BASLAMA_ZAMANI,
                EHU_ONAY_BITIS_ZAMANI = e.EHU_ONAY_BITIS_ZAMANI,
                EHU_ILAC_MAKSIMUM_MIKTAR = e.EHU_ILAC_MAKSIMUM_MIKTAR,
                ACIKLAMA = e.ACIKLAMA,
                EHU_ONAYLAMA_ZAMANI = e.EHU_ONAYLAMA_ZAMANI,
                ONAYLAYAN_HEKIM_KODU = e.ONAYLAYAN_HEKIM_KODU,
                EHU_RET_NEDENI = e.EHU_RET_NEDENI,
                EHU_RET_ZAMANI = e.EHU_RET_ZAMANI,
                EHU_RET_PERSONEL_KODU = e.EHU_RET_PERSONEL_KODU,
                EHU_RET_ACIKLAMA = e.EHU_RET_ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.StokEhuTakip)]
    public async Task<ActionResult<StokEhuTakipDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STOK_EHU_TAKIP>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.STOK_EHU_TAKIP_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new StokEhuTakipDto
        {
            STOK_EHU_TAKIP_KODU = entity.STOK_EHU_TAKIP_KODU,
STOK_ISTEK_KODU = entity.STOK_ISTEK_KODU,
            STOK_ISTEK_HAREKET_KODU = entity.STOK_ISTEK_HAREKET_KODU,
            STOK_KART_KODU = entity.STOK_KART_KODU,
            EHU_ONAY_BASLAMA_ZAMANI = entity.EHU_ONAY_BASLAMA_ZAMANI,
            EHU_ONAY_BITIS_ZAMANI = entity.EHU_ONAY_BITIS_ZAMANI,
            EHU_ILAC_MAKSIMUM_MIKTAR = entity.EHU_ILAC_MAKSIMUM_MIKTAR,
            ACIKLAMA = entity.ACIKLAMA,
            EHU_ONAYLAMA_ZAMANI = entity.EHU_ONAYLAMA_ZAMANI,
            ONAYLAYAN_HEKIM_KODU = entity.ONAYLAYAN_HEKIM_KODU,
            EHU_RET_NEDENI = entity.EHU_RET_NEDENI,
            EHU_RET_ZAMANI = entity.EHU_RET_ZAMANI,
            EHU_RET_PERSONEL_KODU = entity.EHU_RET_PERSONEL_KODU,
            EHU_RET_ACIKLAMA = entity.EHU_RET_ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.StokEhuTakip)]
    public async Task<ActionResult<string>> Create(StokEhuTakipDto dto, CancellationToken ct)
    {
        var entity = new STOK_EHU_TAKIP
        {
            STOK_EHU_TAKIP_KODU = dto.STOK_EHU_TAKIP_KODU,
STOK_ISTEK_KODU = dto.STOK_ISTEK_KODU,
            STOK_ISTEK_HAREKET_KODU = dto.STOK_ISTEK_HAREKET_KODU,
            STOK_KART_KODU = dto.STOK_KART_KODU,
            EHU_ONAY_BASLAMA_ZAMANI = dto.EHU_ONAY_BASLAMA_ZAMANI,
            EHU_ONAY_BITIS_ZAMANI = dto.EHU_ONAY_BITIS_ZAMANI,
            EHU_ILAC_MAKSIMUM_MIKTAR = dto.EHU_ILAC_MAKSIMUM_MIKTAR,
            ACIKLAMA = dto.ACIKLAMA,
            EHU_ONAYLAMA_ZAMANI = dto.EHU_ONAYLAMA_ZAMANI,
            ONAYLAYAN_HEKIM_KODU = dto.ONAYLAYAN_HEKIM_KODU,
            EHU_RET_NEDENI = dto.EHU_RET_NEDENI,
            EHU_RET_ZAMANI = dto.EHU_RET_ZAMANI,
            EHU_RET_PERSONEL_KODU = dto.EHU_RET_PERSONEL_KODU,
            EHU_RET_ACIKLAMA = dto.EHU_RET_ACIKLAMA,
        };

        _db.Set<STOK_EHU_TAKIP>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.STOK_EHU_TAKIP_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.StokEhuTakip)]
    public async Task<IActionResult> Update(string id, StokEhuTakipDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<STOK_EHU_TAKIP>()
            .FirstOrDefaultAsync(e => e.STOK_EHU_TAKIP_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.STOK_ISTEK_KODU = dto.STOK_ISTEK_KODU;
        entity.STOK_ISTEK_HAREKET_KODU = dto.STOK_ISTEK_HAREKET_KODU;
        entity.STOK_KART_KODU = dto.STOK_KART_KODU;
        entity.EHU_ONAY_BASLAMA_ZAMANI = dto.EHU_ONAY_BASLAMA_ZAMANI;
        entity.EHU_ONAY_BITIS_ZAMANI = dto.EHU_ONAY_BITIS_ZAMANI;
        entity.EHU_ILAC_MAKSIMUM_MIKTAR = dto.EHU_ILAC_MAKSIMUM_MIKTAR;
        entity.ACIKLAMA = dto.ACIKLAMA;
        entity.EHU_ONAYLAMA_ZAMANI = dto.EHU_ONAYLAMA_ZAMANI;
        entity.ONAYLAYAN_HEKIM_KODU = dto.ONAYLAYAN_HEKIM_KODU;
        entity.EHU_RET_NEDENI = dto.EHU_RET_NEDENI;
        entity.EHU_RET_ZAMANI = dto.EHU_RET_ZAMANI;
        entity.EHU_RET_PERSONEL_KODU = dto.EHU_RET_PERSONEL_KODU;
        entity.EHU_RET_ACIKLAMA = dto.EHU_RET_ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.StokEhuTakip)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STOK_EHU_TAKIP>()
            .FirstOrDefaultAsync(e => e.STOK_EHU_TAKIP_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<STOK_EHU_TAKIP>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
