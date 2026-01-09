using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.RadyolojiSonuc;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class RadyolojiSonucController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public RadyolojiSonucController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.RadyolojiSonuc)]
    public async Task<List<RadyolojiSonucDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<RADYOLOJI_SONUC>()
            .AsNoTracking()
            .Select(e => new RadyolojiSonucDto
            {
                RADYOLOJI_SONUC_KODU = e.RADYOLOJI_SONUC_KODU,
RADYOLOJI_KODU = e.RADYOLOJI_KODU,
                TETKIK_SONUCU_METIN = e.TETKIK_SONUCU_METIN,
                RADYOLOJI_TETKIK_SONUCU = e.RADYOLOJI_TETKIK_SONUCU,
                RADYOLOJI_RAPOR_FORMATI = e.RADYOLOJI_RAPOR_FORMATI,
                RAPOR_TIPI = e.RAPOR_TIPI,
                RAPOR_YAZAN_PERSONEL_KODU = e.RAPOR_YAZAN_PERSONEL_KODU,
                ONAYLAYAN_PERSONEL_KODU_1 = e.ONAYLAYAN_PERSONEL_KODU_1,
                ONAYLAYAN_PERSONEL_KODU_2 = e.ONAYLAYAN_PERSONEL_KODU_2,
                ONAYLAYAN_PERSONEL_KODU_3 = e.ONAYLAYAN_PERSONEL_KODU_3,
                RAPOR_UZMAN_ONAY_ZAMANI = e.RAPOR_UZMAN_ONAY_ZAMANI,
                RAPOR_KAYIT_ZAMANI = e.RAPOR_KAYIT_ZAMANI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.RadyolojiSonuc)]
    public async Task<ActionResult<RadyolojiSonucDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<RADYOLOJI_SONUC>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.RADYOLOJI_SONUC_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new RadyolojiSonucDto
        {
            RADYOLOJI_SONUC_KODU = entity.RADYOLOJI_SONUC_KODU,
RADYOLOJI_KODU = entity.RADYOLOJI_KODU,
            TETKIK_SONUCU_METIN = entity.TETKIK_SONUCU_METIN,
            RADYOLOJI_TETKIK_SONUCU = entity.RADYOLOJI_TETKIK_SONUCU,
            RADYOLOJI_RAPOR_FORMATI = entity.RADYOLOJI_RAPOR_FORMATI,
            RAPOR_TIPI = entity.RAPOR_TIPI,
            RAPOR_YAZAN_PERSONEL_KODU = entity.RAPOR_YAZAN_PERSONEL_KODU,
            ONAYLAYAN_PERSONEL_KODU_1 = entity.ONAYLAYAN_PERSONEL_KODU_1,
            ONAYLAYAN_PERSONEL_KODU_2 = entity.ONAYLAYAN_PERSONEL_KODU_2,
            ONAYLAYAN_PERSONEL_KODU_3 = entity.ONAYLAYAN_PERSONEL_KODU_3,
            RAPOR_UZMAN_ONAY_ZAMANI = entity.RAPOR_UZMAN_ONAY_ZAMANI,
            RAPOR_KAYIT_ZAMANI = entity.RAPOR_KAYIT_ZAMANI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.RadyolojiSonuc)]
    public async Task<ActionResult<string>> Create(RadyolojiSonucDto dto, CancellationToken ct)
    {
        var entity = new RADYOLOJI_SONUC
        {
            RADYOLOJI_SONUC_KODU = dto.RADYOLOJI_SONUC_KODU,
RADYOLOJI_KODU = dto.RADYOLOJI_KODU,
            TETKIK_SONUCU_METIN = dto.TETKIK_SONUCU_METIN,
            RADYOLOJI_TETKIK_SONUCU = dto.RADYOLOJI_TETKIK_SONUCU,
            RADYOLOJI_RAPOR_FORMATI = dto.RADYOLOJI_RAPOR_FORMATI,
            RAPOR_TIPI = dto.RAPOR_TIPI,
            RAPOR_YAZAN_PERSONEL_KODU = dto.RAPOR_YAZAN_PERSONEL_KODU,
            ONAYLAYAN_PERSONEL_KODU_1 = dto.ONAYLAYAN_PERSONEL_KODU_1,
            ONAYLAYAN_PERSONEL_KODU_2 = dto.ONAYLAYAN_PERSONEL_KODU_2,
            ONAYLAYAN_PERSONEL_KODU_3 = dto.ONAYLAYAN_PERSONEL_KODU_3,
            RAPOR_UZMAN_ONAY_ZAMANI = dto.RAPOR_UZMAN_ONAY_ZAMANI,
            RAPOR_KAYIT_ZAMANI = dto.RAPOR_KAYIT_ZAMANI,
        };

        _db.Set<RADYOLOJI_SONUC>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.RADYOLOJI_SONUC_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.RadyolojiSonuc)]
    public async Task<IActionResult> Update(string id, RadyolojiSonucDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<RADYOLOJI_SONUC>()
            .FirstOrDefaultAsync(e => e.RADYOLOJI_SONUC_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.RADYOLOJI_KODU = dto.RADYOLOJI_KODU;
        entity.TETKIK_SONUCU_METIN = dto.TETKIK_SONUCU_METIN;
        entity.RADYOLOJI_TETKIK_SONUCU = dto.RADYOLOJI_TETKIK_SONUCU;
        entity.RADYOLOJI_RAPOR_FORMATI = dto.RADYOLOJI_RAPOR_FORMATI;
        entity.RAPOR_TIPI = dto.RAPOR_TIPI;
        entity.RAPOR_YAZAN_PERSONEL_KODU = dto.RAPOR_YAZAN_PERSONEL_KODU;
        entity.ONAYLAYAN_PERSONEL_KODU_1 = dto.ONAYLAYAN_PERSONEL_KODU_1;
        entity.ONAYLAYAN_PERSONEL_KODU_2 = dto.ONAYLAYAN_PERSONEL_KODU_2;
        entity.ONAYLAYAN_PERSONEL_KODU_3 = dto.ONAYLAYAN_PERSONEL_KODU_3;
        entity.RAPOR_UZMAN_ONAY_ZAMANI = dto.RAPOR_UZMAN_ONAY_ZAMANI;
        entity.RAPOR_KAYIT_ZAMANI = dto.RAPOR_KAYIT_ZAMANI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.RadyolojiSonuc)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<RADYOLOJI_SONUC>()
            .FirstOrDefaultAsync(e => e.RADYOLOJI_SONUC_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<RADYOLOJI_SONUC>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
