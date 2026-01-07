using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.HastaArsivDetay;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class HastaArsivDetayController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public HastaArsivDetayController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.HastaArsivDetay)]
    public async Task<List<HastaArsivDetayDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<HASTA_ARSIV_DETAY>()
            .AsNoTracking()
            .Select(e => new HastaArsivDetayDto
            {
                HASTA_ARSIV_DETAY_KODU = e.HASTA_ARSIV_DETAY_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                HASTA_ARSIV_KODU = e.HASTA_ARSIV_KODU,
                DOSYA_ALAN_BIRIM_KODU = e.DOSYA_ALAN_BIRIM_KODU,
                DOSYANIN_ALINDIGI_ZAMAN = e.DOSYANIN_ALINDIGI_ZAMAN,
                DOSYA_ALAN_PERSONEL_KODU = e.DOSYA_ALAN_PERSONEL_KODU,
                DOSYA_VEREN_BIRIM_KODU = e.DOSYA_VEREN_BIRIM_KODU,
                DOSYANIN_VERILDIGI_ZAMAN = e.DOSYANIN_VERILDIGI_ZAMAN,
                DOSYA_VEREN_KULLANICI_KODU = e.DOSYA_VEREN_KULLANICI_KODU,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.HastaArsivDetay)]
    public async Task<ActionResult<HastaArsivDetayDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_ARSIV_DETAY>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.HASTA_ARSIV_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new HastaArsivDetayDto
        {
            HASTA_ARSIV_DETAY_KODU = entity.HASTA_ARSIV_DETAY_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            HASTA_ARSIV_KODU = entity.HASTA_ARSIV_KODU,
            DOSYA_ALAN_BIRIM_KODU = entity.DOSYA_ALAN_BIRIM_KODU,
            DOSYANIN_ALINDIGI_ZAMAN = entity.DOSYANIN_ALINDIGI_ZAMAN,
            DOSYA_ALAN_PERSONEL_KODU = entity.DOSYA_ALAN_PERSONEL_KODU,
            DOSYA_VEREN_BIRIM_KODU = entity.DOSYA_VEREN_BIRIM_KODU,
            DOSYANIN_VERILDIGI_ZAMAN = entity.DOSYANIN_VERILDIGI_ZAMAN,
            DOSYA_VEREN_KULLANICI_KODU = entity.DOSYA_VEREN_KULLANICI_KODU,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.HastaArsivDetay)]
    public async Task<ActionResult<string>> Create(HastaArsivDetayDto dto, CancellationToken ct)
    {
        var entity = new HASTA_ARSIV_DETAY
        {
            HASTA_ARSIV_DETAY_KODU = dto.HASTA_ARSIV_DETAY_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            HASTA_ARSIV_KODU = dto.HASTA_ARSIV_KODU,
            DOSYA_ALAN_BIRIM_KODU = dto.DOSYA_ALAN_BIRIM_KODU,
            DOSYANIN_ALINDIGI_ZAMAN = dto.DOSYANIN_ALINDIGI_ZAMAN,
            DOSYA_ALAN_PERSONEL_KODU = dto.DOSYA_ALAN_PERSONEL_KODU,
            DOSYA_VEREN_BIRIM_KODU = dto.DOSYA_VEREN_BIRIM_KODU,
            DOSYANIN_VERILDIGI_ZAMAN = dto.DOSYANIN_VERILDIGI_ZAMAN,
            DOSYA_VEREN_KULLANICI_KODU = dto.DOSYA_VEREN_KULLANICI_KODU,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<HASTA_ARSIV_DETAY>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.HASTA_ARSIV_DETAY_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.HastaArsivDetay)]
    public async Task<IActionResult> Update(string id, HastaArsivDetayDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_ARSIV_DETAY>()
            .FirstOrDefaultAsync(e => e.HASTA_ARSIV_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.HASTA_ARSIV_KODU = dto.HASTA_ARSIV_KODU;
        entity.DOSYA_ALAN_BIRIM_KODU = dto.DOSYA_ALAN_BIRIM_KODU;
        entity.DOSYANIN_ALINDIGI_ZAMAN = dto.DOSYANIN_ALINDIGI_ZAMAN;
        entity.DOSYA_ALAN_PERSONEL_KODU = dto.DOSYA_ALAN_PERSONEL_KODU;
        entity.DOSYA_VEREN_BIRIM_KODU = dto.DOSYA_VEREN_BIRIM_KODU;
        entity.DOSYANIN_VERILDIGI_ZAMAN = dto.DOSYANIN_VERILDIGI_ZAMAN;
        entity.DOSYA_VEREN_KULLANICI_KODU = dto.DOSYA_VEREN_KULLANICI_KODU;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.HastaArsivDetay)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_ARSIV_DETAY>()
            .FirstOrDefaultAsync(e => e.HASTA_ARSIV_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<HASTA_ARSIV_DETAY>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
