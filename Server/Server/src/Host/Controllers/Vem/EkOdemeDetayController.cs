using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.EkOdemeDetay;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class EkOdemeDetayController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public EkOdemeDetayController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.EkOdemeDetay)]
    public async Task<List<EkOdemeDetayDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<EK_ODEME_DETAY>()
            .AsNoTracking()
            .Select(e => new EkOdemeDetayDto
            {
                EK_ODEME_DETAY_KODU = e.EK_ODEME_DETAY_KODU,
EK_ODEME_KODU = e.EK_ODEME_KODU,
                GOREV_NUMARASI = e.GOREV_NUMARASI,
                KADRO_KODU = e.KADRO_KODU,
                KADRO_KATSAYISI = e.KADRO_KATSAYISI,
                GIRISIMSEL_ISLEM_PUANI = e.GIRISIMSEL_ISLEM_PUANI,
                OZELLIKLI_ISLEM_PUANI = e.OZELLIKLI_ISLEM_PUANI,
                TAVAN_KATSAYISI = e.TAVAN_KATSAYISI,
                CALISILAN_GUN_TOPLAMI = e.CALISILAN_GUN_TOPLAMI,
                CALISILAN_SAAT_TOPLAMI = e.CALISILAN_SAAT_TOPLAMI,
                AKTIF_CALISILAN_GUN_KATSAYISI = e.AKTIF_CALISILAN_GUN_KATSAYISI,
                HASTANE_PUAN_ORTALAMASI = e.HASTANE_PUAN_ORTALAMASI,
                KLINIK_KODU = e.KLINIK_KODU,
                KLINIK_PUAN_ORTALAMASI = e.KLINIK_PUAN_ORTALAMASI,
                BRUT_PERFORMANS_PUANI = e.BRUT_PERFORMANS_PUANI,
                EK_PERFORMANS_PUANI = e.EK_PERFORMANS_PUANI,
                NET_PERFORMANS_PUANI = e.NET_PERFORMANS_PUANI,
                EGITICI_DESTEKLEME_PUANI = e.EGITICI_DESTEKLEME_PUANI,
                BILIMSEL_CALISMA_PUANI = e.BILIMSEL_CALISMA_PUANI,
                SERBEST_MESLEK_KATSAYISI = e.SERBEST_MESLEK_KATSAYISI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.EkOdemeDetay)]
    public async Task<ActionResult<EkOdemeDetayDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<EK_ODEME_DETAY>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.EK_ODEME_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new EkOdemeDetayDto
        {
            EK_ODEME_DETAY_KODU = entity.EK_ODEME_DETAY_KODU,
EK_ODEME_KODU = entity.EK_ODEME_KODU,
            GOREV_NUMARASI = entity.GOREV_NUMARASI,
            KADRO_KODU = entity.KADRO_KODU,
            KADRO_KATSAYISI = entity.KADRO_KATSAYISI,
            GIRISIMSEL_ISLEM_PUANI = entity.GIRISIMSEL_ISLEM_PUANI,
            OZELLIKLI_ISLEM_PUANI = entity.OZELLIKLI_ISLEM_PUANI,
            TAVAN_KATSAYISI = entity.TAVAN_KATSAYISI,
            CALISILAN_GUN_TOPLAMI = entity.CALISILAN_GUN_TOPLAMI,
            CALISILAN_SAAT_TOPLAMI = entity.CALISILAN_SAAT_TOPLAMI,
            AKTIF_CALISILAN_GUN_KATSAYISI = entity.AKTIF_CALISILAN_GUN_KATSAYISI,
            HASTANE_PUAN_ORTALAMASI = entity.HASTANE_PUAN_ORTALAMASI,
            KLINIK_KODU = entity.KLINIK_KODU,
            KLINIK_PUAN_ORTALAMASI = entity.KLINIK_PUAN_ORTALAMASI,
            BRUT_PERFORMANS_PUANI = entity.BRUT_PERFORMANS_PUANI,
            EK_PERFORMANS_PUANI = entity.EK_PERFORMANS_PUANI,
            NET_PERFORMANS_PUANI = entity.NET_PERFORMANS_PUANI,
            EGITICI_DESTEKLEME_PUANI = entity.EGITICI_DESTEKLEME_PUANI,
            BILIMSEL_CALISMA_PUANI = entity.BILIMSEL_CALISMA_PUANI,
            SERBEST_MESLEK_KATSAYISI = entity.SERBEST_MESLEK_KATSAYISI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.EkOdemeDetay)]
    public async Task<ActionResult<string>> Create(EkOdemeDetayDto dto, CancellationToken ct)
    {
        var entity = new EK_ODEME_DETAY
        {
            EK_ODEME_DETAY_KODU = dto.EK_ODEME_DETAY_KODU,
EK_ODEME_KODU = dto.EK_ODEME_KODU,
            GOREV_NUMARASI = dto.GOREV_NUMARASI,
            KADRO_KODU = dto.KADRO_KODU,
            KADRO_KATSAYISI = dto.KADRO_KATSAYISI,
            GIRISIMSEL_ISLEM_PUANI = dto.GIRISIMSEL_ISLEM_PUANI,
            OZELLIKLI_ISLEM_PUANI = dto.OZELLIKLI_ISLEM_PUANI,
            TAVAN_KATSAYISI = dto.TAVAN_KATSAYISI,
            CALISILAN_GUN_TOPLAMI = dto.CALISILAN_GUN_TOPLAMI,
            CALISILAN_SAAT_TOPLAMI = dto.CALISILAN_SAAT_TOPLAMI,
            AKTIF_CALISILAN_GUN_KATSAYISI = dto.AKTIF_CALISILAN_GUN_KATSAYISI,
            HASTANE_PUAN_ORTALAMASI = dto.HASTANE_PUAN_ORTALAMASI,
            KLINIK_KODU = dto.KLINIK_KODU,
            KLINIK_PUAN_ORTALAMASI = dto.KLINIK_PUAN_ORTALAMASI,
            BRUT_PERFORMANS_PUANI = dto.BRUT_PERFORMANS_PUANI,
            EK_PERFORMANS_PUANI = dto.EK_PERFORMANS_PUANI,
            NET_PERFORMANS_PUANI = dto.NET_PERFORMANS_PUANI,
            EGITICI_DESTEKLEME_PUANI = dto.EGITICI_DESTEKLEME_PUANI,
            BILIMSEL_CALISMA_PUANI = dto.BILIMSEL_CALISMA_PUANI,
            SERBEST_MESLEK_KATSAYISI = dto.SERBEST_MESLEK_KATSAYISI,
        };

        _db.Set<EK_ODEME_DETAY>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.EK_ODEME_DETAY_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.EkOdemeDetay)]
    public async Task<IActionResult> Update(string id, EkOdemeDetayDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<EK_ODEME_DETAY>()
            .FirstOrDefaultAsync(e => e.EK_ODEME_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.EK_ODEME_KODU = dto.EK_ODEME_KODU;
        entity.GOREV_NUMARASI = dto.GOREV_NUMARASI;
        entity.KADRO_KODU = dto.KADRO_KODU;
        entity.KADRO_KATSAYISI = dto.KADRO_KATSAYISI;
        entity.GIRISIMSEL_ISLEM_PUANI = dto.GIRISIMSEL_ISLEM_PUANI;
        entity.OZELLIKLI_ISLEM_PUANI = dto.OZELLIKLI_ISLEM_PUANI;
        entity.TAVAN_KATSAYISI = dto.TAVAN_KATSAYISI;
        entity.CALISILAN_GUN_TOPLAMI = dto.CALISILAN_GUN_TOPLAMI;
        entity.CALISILAN_SAAT_TOPLAMI = dto.CALISILAN_SAAT_TOPLAMI;
        entity.AKTIF_CALISILAN_GUN_KATSAYISI = dto.AKTIF_CALISILAN_GUN_KATSAYISI;
        entity.HASTANE_PUAN_ORTALAMASI = dto.HASTANE_PUAN_ORTALAMASI;
        entity.KLINIK_KODU = dto.KLINIK_KODU;
        entity.KLINIK_PUAN_ORTALAMASI = dto.KLINIK_PUAN_ORTALAMASI;
        entity.BRUT_PERFORMANS_PUANI = dto.BRUT_PERFORMANS_PUANI;
        entity.EK_PERFORMANS_PUANI = dto.EK_PERFORMANS_PUANI;
        entity.NET_PERFORMANS_PUANI = dto.NET_PERFORMANS_PUANI;
        entity.EGITICI_DESTEKLEME_PUANI = dto.EGITICI_DESTEKLEME_PUANI;
        entity.BILIMSEL_CALISMA_PUANI = dto.BILIMSEL_CALISMA_PUANI;
        entity.SERBEST_MESLEK_KATSAYISI = dto.SERBEST_MESLEK_KATSAYISI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.EkOdemeDetay)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<EK_ODEME_DETAY>()
            .FirstOrDefaultAsync(e => e.EK_ODEME_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<EK_ODEME_DETAY>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
