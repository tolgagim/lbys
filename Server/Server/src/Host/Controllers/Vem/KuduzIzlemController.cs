using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.KuduzIzlem;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class KuduzIzlemController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public KuduzIzlemController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.KuduzIzlem)]
    public async Task<List<KuduzIzlemDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<KUDUZ_IZLEM>()
            .AsNoTracking()
            .Select(e => new KuduzIzlemDto
            {
                KUDUZ_IZLEM_KODU = e.KUDUZ_IZLEM_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                PROFILAKSI_TAMAMLANMA_DURUMU = e.PROFILAKSI_TAMAMLANMA_DURUMU,
                UYGULANAN_KUDUZ_PROFILAKSISI = e.UYGULANAN_KUDUZ_PROFILAKSISI,
                BEYAN_TSM_KURUM_KODU = e.BEYAN_TSM_KURUM_KODU,
                IMMUNGLOBULIN_MIKTARI = e.IMMUNGLOBULIN_MIKTARI,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.KuduzIzlem)]
    public async Task<ActionResult<KuduzIzlemDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KUDUZ_IZLEM>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.KUDUZ_IZLEM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new KuduzIzlemDto
        {
            KUDUZ_IZLEM_KODU = entity.KUDUZ_IZLEM_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            PROFILAKSI_TAMAMLANMA_DURUMU = entity.PROFILAKSI_TAMAMLANMA_DURUMU,
            UYGULANAN_KUDUZ_PROFILAKSISI = entity.UYGULANAN_KUDUZ_PROFILAKSISI,
            BEYAN_TSM_KURUM_KODU = entity.BEYAN_TSM_KURUM_KODU,
            IMMUNGLOBULIN_MIKTARI = entity.IMMUNGLOBULIN_MIKTARI,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.KuduzIzlem)]
    public async Task<ActionResult<string>> Create(KuduzIzlemDto dto, CancellationToken ct)
    {
        var entity = new KUDUZ_IZLEM
        {
            KUDUZ_IZLEM_KODU = dto.KUDUZ_IZLEM_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            PROFILAKSI_TAMAMLANMA_DURUMU = dto.PROFILAKSI_TAMAMLANMA_DURUMU,
            UYGULANAN_KUDUZ_PROFILAKSISI = dto.UYGULANAN_KUDUZ_PROFILAKSISI,
            BEYAN_TSM_KURUM_KODU = dto.BEYAN_TSM_KURUM_KODU,
            IMMUNGLOBULIN_MIKTARI = dto.IMMUNGLOBULIN_MIKTARI,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<KUDUZ_IZLEM>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.KUDUZ_IZLEM_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.KuduzIzlem)]
    public async Task<IActionResult> Update(string id, KuduzIzlemDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<KUDUZ_IZLEM>()
            .FirstOrDefaultAsync(e => e.KUDUZ_IZLEM_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.PROFILAKSI_TAMAMLANMA_DURUMU = dto.PROFILAKSI_TAMAMLANMA_DURUMU;
        entity.UYGULANAN_KUDUZ_PROFILAKSISI = dto.UYGULANAN_KUDUZ_PROFILAKSISI;
        entity.BEYAN_TSM_KURUM_KODU = dto.BEYAN_TSM_KURUM_KODU;
        entity.IMMUNGLOBULIN_MIKTARI = dto.IMMUNGLOBULIN_MIKTARI;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.KuduzIzlem)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KUDUZ_IZLEM>()
            .FirstOrDefaultAsync(e => e.KUDUZ_IZLEM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<KUDUZ_IZLEM>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
