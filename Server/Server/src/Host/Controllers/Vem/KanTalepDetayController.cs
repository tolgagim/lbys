using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.KanTalepDetay;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class KanTalepDetayController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public KanTalepDetayController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.KanTalepDetay)]
    public async Task<List<KanTalepDetayDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<KAN_TALEP_DETAY>()
            .AsNoTracking()
            .Select(e => new KanTalepDetayDto
            {
                KAN_TALEP_DETAY_KODU = e.KAN_TALEP_DETAY_KODU,
KAN_TALEP_KODU = e.KAN_TALEP_KODU,
                KAN_URUN_KODU = e.KAN_URUN_KODU,
                ISTENEN_KAN_GRUBU = e.ISTENEN_KAN_GRUBU,
                RET_TARIHI = e.RET_TARIHI,
                RET_EDEN_KULLANICI_KODU = e.RET_EDEN_KULLANICI_KODU,
                KAN_TALEP_RET_NEDENI = e.KAN_TALEP_RET_NEDENI,
                KAN_TALEP_MIKTARI = e.KAN_TALEP_MIKTARI,
                KAN_HACIM = e.KAN_HACIM,
                ACIKLAMA = e.ACIKLAMA,
                BUFFYCOAT_UZAKLASTIRMA_DURUMU = e.BUFFYCOAT_UZAKLASTIRMA_DURUMU,
                KAN_FILTRELEME_DURUMU = e.KAN_FILTRELEME_DURUMU,
                KAN_ISINLAMA_DURUMU = e.KAN_ISINLAMA_DURUMU,
                KAN_YIKAMA_DURUMU = e.KAN_YIKAMA_DURUMU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.KanTalepDetay)]
    public async Task<ActionResult<KanTalepDetayDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KAN_TALEP_DETAY>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.KAN_TALEP_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new KanTalepDetayDto
        {
            KAN_TALEP_DETAY_KODU = entity.KAN_TALEP_DETAY_KODU,
KAN_TALEP_KODU = entity.KAN_TALEP_KODU,
            KAN_URUN_KODU = entity.KAN_URUN_KODU,
            ISTENEN_KAN_GRUBU = entity.ISTENEN_KAN_GRUBU,
            RET_TARIHI = entity.RET_TARIHI,
            RET_EDEN_KULLANICI_KODU = entity.RET_EDEN_KULLANICI_KODU,
            KAN_TALEP_RET_NEDENI = entity.KAN_TALEP_RET_NEDENI,
            KAN_TALEP_MIKTARI = entity.KAN_TALEP_MIKTARI,
            KAN_HACIM = entity.KAN_HACIM,
            ACIKLAMA = entity.ACIKLAMA,
            BUFFYCOAT_UZAKLASTIRMA_DURUMU = entity.BUFFYCOAT_UZAKLASTIRMA_DURUMU,
            KAN_FILTRELEME_DURUMU = entity.KAN_FILTRELEME_DURUMU,
            KAN_ISINLAMA_DURUMU = entity.KAN_ISINLAMA_DURUMU,
            KAN_YIKAMA_DURUMU = entity.KAN_YIKAMA_DURUMU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.KanTalepDetay)]
    public async Task<ActionResult<string>> Create(KanTalepDetayDto dto, CancellationToken ct)
    {
        var entity = new KAN_TALEP_DETAY
        {
            KAN_TALEP_DETAY_KODU = dto.KAN_TALEP_DETAY_KODU,
KAN_TALEP_KODU = dto.KAN_TALEP_KODU,
            KAN_URUN_KODU = dto.KAN_URUN_KODU,
            ISTENEN_KAN_GRUBU = dto.ISTENEN_KAN_GRUBU,
            RET_TARIHI = dto.RET_TARIHI,
            RET_EDEN_KULLANICI_KODU = dto.RET_EDEN_KULLANICI_KODU,
            KAN_TALEP_RET_NEDENI = dto.KAN_TALEP_RET_NEDENI,
            KAN_TALEP_MIKTARI = dto.KAN_TALEP_MIKTARI,
            KAN_HACIM = dto.KAN_HACIM,
            ACIKLAMA = dto.ACIKLAMA,
            BUFFYCOAT_UZAKLASTIRMA_DURUMU = dto.BUFFYCOAT_UZAKLASTIRMA_DURUMU,
            KAN_FILTRELEME_DURUMU = dto.KAN_FILTRELEME_DURUMU,
            KAN_ISINLAMA_DURUMU = dto.KAN_ISINLAMA_DURUMU,
            KAN_YIKAMA_DURUMU = dto.KAN_YIKAMA_DURUMU,
        };

        _db.Set<KAN_TALEP_DETAY>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.KAN_TALEP_DETAY_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.KanTalepDetay)]
    public async Task<IActionResult> Update(string id, KanTalepDetayDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<KAN_TALEP_DETAY>()
            .FirstOrDefaultAsync(e => e.KAN_TALEP_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.KAN_TALEP_KODU = dto.KAN_TALEP_KODU;
        entity.KAN_URUN_KODU = dto.KAN_URUN_KODU;
        entity.ISTENEN_KAN_GRUBU = dto.ISTENEN_KAN_GRUBU;
        entity.RET_TARIHI = dto.RET_TARIHI;
        entity.RET_EDEN_KULLANICI_KODU = dto.RET_EDEN_KULLANICI_KODU;
        entity.KAN_TALEP_RET_NEDENI = dto.KAN_TALEP_RET_NEDENI;
        entity.KAN_TALEP_MIKTARI = dto.KAN_TALEP_MIKTARI;
        entity.KAN_HACIM = dto.KAN_HACIM;
        entity.ACIKLAMA = dto.ACIKLAMA;
        entity.BUFFYCOAT_UZAKLASTIRMA_DURUMU = dto.BUFFYCOAT_UZAKLASTIRMA_DURUMU;
        entity.KAN_FILTRELEME_DURUMU = dto.KAN_FILTRELEME_DURUMU;
        entity.KAN_ISINLAMA_DURUMU = dto.KAN_ISINLAMA_DURUMU;
        entity.KAN_YIKAMA_DURUMU = dto.KAN_YIKAMA_DURUMU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.KanTalepDetay)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KAN_TALEP_DETAY>()
            .FirstOrDefaultAsync(e => e.KAN_TALEP_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<KAN_TALEP_DETAY>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
