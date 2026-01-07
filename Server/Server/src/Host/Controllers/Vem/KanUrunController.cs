using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.KanUrun;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class KanUrunController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public KanUrunController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.KanUrun)]
    public async Task<List<KanUrunDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<KAN_URUN>()
            .AsNoTracking()
            .Select(e => new KanUrunDto
            {
                KAN_URUN_KODU = e.KAN_URUN_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                KAN_URUN_ADI = e.KAN_URUN_ADI,
                HIZMET_KODU = e.HIZMET_KODU,
                KAN_MIAT_SURESI = e.KAN_MIAT_SURESI,
                KAN_MIAT_PERIYODU = e.KAN_MIAT_PERIYODU,
                KIZILAY_BILESEN_TURU = e.KIZILAY_BILESEN_TURU,
                KAN_FILTRELEME_UYGUNLUK = e.KAN_FILTRELEME_UYGUNLUK,
                KAN_YIKAMA_UYGUNLUK_DURUMU = e.KAN_YIKAMA_UYGUNLUK_DURUMU,
                KAN_ISINLAMA_UYGUNLUK_DURUMU = e.KAN_ISINLAMA_UYGUNLUK_DURUMU,
                KAN_HAVUZLAMA_UYGUNLUK = e.KAN_HAVUZLAMA_UYGUNLUK,
                KAN_AYIRMA_UYGUNLUK = e.KAN_AYIRMA_UYGUNLUK,
                KAN_BOLME_UYGUNLUK = e.KAN_BOLME_UYGUNLUK,
                BUFFYCOAT_UZAKLASTIRMAYA_UYGUN = e.BUFFYCOAT_UZAKLASTIRMAYA_UYGUN,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.KanUrun)]
    public async Task<ActionResult<KanUrunDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KAN_URUN>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.KAN_URUN_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new KanUrunDto
        {
            KAN_URUN_KODU = entity.KAN_URUN_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            KAN_URUN_ADI = entity.KAN_URUN_ADI,
            HIZMET_KODU = entity.HIZMET_KODU,
            KAN_MIAT_SURESI = entity.KAN_MIAT_SURESI,
            KAN_MIAT_PERIYODU = entity.KAN_MIAT_PERIYODU,
            KIZILAY_BILESEN_TURU = entity.KIZILAY_BILESEN_TURU,
            KAN_FILTRELEME_UYGUNLUK = entity.KAN_FILTRELEME_UYGUNLUK,
            KAN_YIKAMA_UYGUNLUK_DURUMU = entity.KAN_YIKAMA_UYGUNLUK_DURUMU,
            KAN_ISINLAMA_UYGUNLUK_DURUMU = entity.KAN_ISINLAMA_UYGUNLUK_DURUMU,
            KAN_HAVUZLAMA_UYGUNLUK = entity.KAN_HAVUZLAMA_UYGUNLUK,
            KAN_AYIRMA_UYGUNLUK = entity.KAN_AYIRMA_UYGUNLUK,
            KAN_BOLME_UYGUNLUK = entity.KAN_BOLME_UYGUNLUK,
            BUFFYCOAT_UZAKLASTIRMAYA_UYGUN = entity.BUFFYCOAT_UZAKLASTIRMAYA_UYGUN,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.KanUrun)]
    public async Task<ActionResult<string>> Create(KanUrunDto dto, CancellationToken ct)
    {
        var entity = new KAN_URUN
        {
            KAN_URUN_KODU = dto.KAN_URUN_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            KAN_URUN_ADI = dto.KAN_URUN_ADI,
            HIZMET_KODU = dto.HIZMET_KODU,
            KAN_MIAT_SURESI = dto.KAN_MIAT_SURESI,
            KAN_MIAT_PERIYODU = dto.KAN_MIAT_PERIYODU,
            KIZILAY_BILESEN_TURU = dto.KIZILAY_BILESEN_TURU,
            KAN_FILTRELEME_UYGUNLUK = dto.KAN_FILTRELEME_UYGUNLUK,
            KAN_YIKAMA_UYGUNLUK_DURUMU = dto.KAN_YIKAMA_UYGUNLUK_DURUMU,
            KAN_ISINLAMA_UYGUNLUK_DURUMU = dto.KAN_ISINLAMA_UYGUNLUK_DURUMU,
            KAN_HAVUZLAMA_UYGUNLUK = dto.KAN_HAVUZLAMA_UYGUNLUK,
            KAN_AYIRMA_UYGUNLUK = dto.KAN_AYIRMA_UYGUNLUK,
            KAN_BOLME_UYGUNLUK = dto.KAN_BOLME_UYGUNLUK,
            BUFFYCOAT_UZAKLASTIRMAYA_UYGUN = dto.BUFFYCOAT_UZAKLASTIRMAYA_UYGUN,
        };

        _db.Set<KAN_URUN>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.KAN_URUN_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.KanUrun)]
    public async Task<IActionResult> Update(string id, KanUrunDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<KAN_URUN>()
            .FirstOrDefaultAsync(e => e.KAN_URUN_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.KAN_URUN_ADI = dto.KAN_URUN_ADI;
        entity.HIZMET_KODU = dto.HIZMET_KODU;
        entity.KAN_MIAT_SURESI = dto.KAN_MIAT_SURESI;
        entity.KAN_MIAT_PERIYODU = dto.KAN_MIAT_PERIYODU;
        entity.KIZILAY_BILESEN_TURU = dto.KIZILAY_BILESEN_TURU;
        entity.KAN_FILTRELEME_UYGUNLUK = dto.KAN_FILTRELEME_UYGUNLUK;
        entity.KAN_YIKAMA_UYGUNLUK_DURUMU = dto.KAN_YIKAMA_UYGUNLUK_DURUMU;
        entity.KAN_ISINLAMA_UYGUNLUK_DURUMU = dto.KAN_ISINLAMA_UYGUNLUK_DURUMU;
        entity.KAN_HAVUZLAMA_UYGUNLUK = dto.KAN_HAVUZLAMA_UYGUNLUK;
        entity.KAN_AYIRMA_UYGUNLUK = dto.KAN_AYIRMA_UYGUNLUK;
        entity.KAN_BOLME_UYGUNLUK = dto.KAN_BOLME_UYGUNLUK;
        entity.BUFFYCOAT_UZAKLASTIRMAYA_UYGUN = dto.BUFFYCOAT_UZAKLASTIRMAYA_UYGUN;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.KanUrun)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KAN_URUN>()
            .FirstOrDefaultAsync(e => e.KAN_URUN_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<KAN_URUN>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
