using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.KanCikis;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class KanCikisController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public KanCikisController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.KanCikis)]
    public async Task<List<KanCikisDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<KAN_CIKIS>()
            .AsNoTracking()
            .Select(e => new KanCikisDto
            {
                KAN_CIKIS_KODU = e.KAN_CIKIS_KODU,
KAN_TALEP_DETAY_KODU = e.KAN_TALEP_DETAY_KODU,
                HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                KAN_STOK_KODU = e.KAN_STOK_KODU,
                KANI_TESLIM_ALAN_KISI = e.KANI_TESLIM_ALAN_KISI,
                KAN_CIKIS_ZAMANI = e.KAN_CIKIS_ZAMANI,
                KURUM_KODU = e.KURUM_KODU,
                KAN_CIKIS_PERSONEL_KODU = e.KAN_CIKIS_PERSONEL_KODU,
                REZERVE_ZAMANI = e.REZERVE_ZAMANI,
                REZERVE_EDEN_KULLANICI_KODU = e.REZERVE_EDEN_KULLANICI_KODU,
                CROSS_MATCH_KULLANICI_KODU = e.CROSS_MATCH_KULLANICI_KODU,
                CROSS_MATCH_CALISMA_ZAMANI = e.CROSS_MATCH_CALISMA_ZAMANI,
                CROSS_MATCH_CALISMA_YONTEMI = e.CROSS_MATCH_CALISMA_YONTEMI,
                CROSS_MATCH_SONUCU = e.CROSS_MATCH_SONUCU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.KanCikis)]
    public async Task<ActionResult<KanCikisDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KAN_CIKIS>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.KAN_CIKIS_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new KanCikisDto
        {
            KAN_CIKIS_KODU = entity.KAN_CIKIS_KODU,
KAN_TALEP_DETAY_KODU = entity.KAN_TALEP_DETAY_KODU,
            HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            KAN_STOK_KODU = entity.KAN_STOK_KODU,
            KANI_TESLIM_ALAN_KISI = entity.KANI_TESLIM_ALAN_KISI,
            KAN_CIKIS_ZAMANI = entity.KAN_CIKIS_ZAMANI,
            KURUM_KODU = entity.KURUM_KODU,
            KAN_CIKIS_PERSONEL_KODU = entity.KAN_CIKIS_PERSONEL_KODU,
            REZERVE_ZAMANI = entity.REZERVE_ZAMANI,
            REZERVE_EDEN_KULLANICI_KODU = entity.REZERVE_EDEN_KULLANICI_KODU,
            CROSS_MATCH_KULLANICI_KODU = entity.CROSS_MATCH_KULLANICI_KODU,
            CROSS_MATCH_CALISMA_ZAMANI = entity.CROSS_MATCH_CALISMA_ZAMANI,
            CROSS_MATCH_CALISMA_YONTEMI = entity.CROSS_MATCH_CALISMA_YONTEMI,
            CROSS_MATCH_SONUCU = entity.CROSS_MATCH_SONUCU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.KanCikis)]
    public async Task<ActionResult<string>> Create(KanCikisDto dto, CancellationToken ct)
    {
        var entity = new KAN_CIKIS
        {
            KAN_CIKIS_KODU = dto.KAN_CIKIS_KODU,
KAN_TALEP_DETAY_KODU = dto.KAN_TALEP_DETAY_KODU,
            HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            KAN_STOK_KODU = dto.KAN_STOK_KODU,
            KANI_TESLIM_ALAN_KISI = dto.KANI_TESLIM_ALAN_KISI,
            KAN_CIKIS_ZAMANI = dto.KAN_CIKIS_ZAMANI,
            KURUM_KODU = dto.KURUM_KODU,
            KAN_CIKIS_PERSONEL_KODU = dto.KAN_CIKIS_PERSONEL_KODU,
            REZERVE_ZAMANI = dto.REZERVE_ZAMANI,
            REZERVE_EDEN_KULLANICI_KODU = dto.REZERVE_EDEN_KULLANICI_KODU,
            CROSS_MATCH_KULLANICI_KODU = dto.CROSS_MATCH_KULLANICI_KODU,
            CROSS_MATCH_CALISMA_ZAMANI = dto.CROSS_MATCH_CALISMA_ZAMANI,
            CROSS_MATCH_CALISMA_YONTEMI = dto.CROSS_MATCH_CALISMA_YONTEMI,
            CROSS_MATCH_SONUCU = dto.CROSS_MATCH_SONUCU,
        };

        _db.Set<KAN_CIKIS>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.KAN_CIKIS_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.KanCikis)]
    public async Task<IActionResult> Update(string id, KanCikisDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<KAN_CIKIS>()
            .FirstOrDefaultAsync(e => e.KAN_CIKIS_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.KAN_TALEP_DETAY_KODU = dto.KAN_TALEP_DETAY_KODU;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.KAN_STOK_KODU = dto.KAN_STOK_KODU;
        entity.KANI_TESLIM_ALAN_KISI = dto.KANI_TESLIM_ALAN_KISI;
        entity.KAN_CIKIS_ZAMANI = dto.KAN_CIKIS_ZAMANI;
        entity.KURUM_KODU = dto.KURUM_KODU;
        entity.KAN_CIKIS_PERSONEL_KODU = dto.KAN_CIKIS_PERSONEL_KODU;
        entity.REZERVE_ZAMANI = dto.REZERVE_ZAMANI;
        entity.REZERVE_EDEN_KULLANICI_KODU = dto.REZERVE_EDEN_KULLANICI_KODU;
        entity.CROSS_MATCH_KULLANICI_KODU = dto.CROSS_MATCH_KULLANICI_KODU;
        entity.CROSS_MATCH_CALISMA_ZAMANI = dto.CROSS_MATCH_CALISMA_ZAMANI;
        entity.CROSS_MATCH_CALISMA_YONTEMI = dto.CROSS_MATCH_CALISMA_YONTEMI;
        entity.CROSS_MATCH_SONUCU = dto.CROSS_MATCH_SONUCU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.KanCikis)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KAN_CIKIS>()
            .FirstOrDefaultAsync(e => e.KAN_CIKIS_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<KAN_CIKIS>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
