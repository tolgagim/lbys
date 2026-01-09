using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.SterilizasyonSet;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class SterilizasyonSetController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public SterilizasyonSetController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.SterilizasyonSet)]
    public async Task<List<SterilizasyonSetDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<STERILIZASYON_SET>()
            .AsNoTracking()
            .Select(e => new SterilizasyonSetDto
            {
                STERILIZASYON_SET_KODU = e.STERILIZASYON_SET_KODU,
DEPO_KODU = e.DEPO_KODU,
                STERILIZASYON_PAKET_KODU = e.STERILIZASYON_PAKET_KODU,
                BARKOD = e.BARKOD,
                BARKOD_BASAN_KULLANICI_KODU = e.BARKOD_BASAN_KULLANICI_KODU,
                BARKOD_ZAMANI = e.BARKOD_ZAMANI,
                CIHAZ_KODU = e.CIHAZ_KODU,
                STERILIZASYON_CEVRIM_NUMARASI = e.STERILIZASYON_CEVRIM_NUMARASI,
                SET_IADE_DURUMU = e.SET_IADE_DURUMU,
                SET_IADE_ZAMANI = e.SET_IADE_ZAMANI,
                SET_IADE_EDEN_PERSONEL_KODU = e.SET_IADE_EDEN_PERSONEL_KODU,
                SET_IADE_ALAN_PERSONEL_KODU = e.SET_IADE_ALAN_PERSONEL_KODU,
                PAKET_RAF_OMRU_BITIS_TARIHI = e.PAKET_RAF_OMRU_BITIS_TARIHI,
                PAKETLEYEN_PERSONEL_KODU = e.PAKETLEYEN_PERSONEL_KODU,
                ISLEM_ZAMANI = e.ISLEM_ZAMANI,
                STERILIZASYON_BASLAMA_ZAMANI = e.STERILIZASYON_BASLAMA_ZAMANI,
                STERILIZASYON_BITIS_ZAMANI = e.STERILIZASYON_BITIS_ZAMANI,
                STERILIZASYON_PERSONEL_KODU = e.STERILIZASYON_PERSONEL_KODU,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.SterilizasyonSet)]
    public async Task<ActionResult<SterilizasyonSetDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STERILIZASYON_SET>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.STERILIZASYON_SET_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new SterilizasyonSetDto
        {
            STERILIZASYON_SET_KODU = entity.STERILIZASYON_SET_KODU,
DEPO_KODU = entity.DEPO_KODU,
            STERILIZASYON_PAKET_KODU = entity.STERILIZASYON_PAKET_KODU,
            BARKOD = entity.BARKOD,
            BARKOD_BASAN_KULLANICI_KODU = entity.BARKOD_BASAN_KULLANICI_KODU,
            BARKOD_ZAMANI = entity.BARKOD_ZAMANI,
            CIHAZ_KODU = entity.CIHAZ_KODU,
            STERILIZASYON_CEVRIM_NUMARASI = entity.STERILIZASYON_CEVRIM_NUMARASI,
            SET_IADE_DURUMU = entity.SET_IADE_DURUMU,
            SET_IADE_ZAMANI = entity.SET_IADE_ZAMANI,
            SET_IADE_EDEN_PERSONEL_KODU = entity.SET_IADE_EDEN_PERSONEL_KODU,
            SET_IADE_ALAN_PERSONEL_KODU = entity.SET_IADE_ALAN_PERSONEL_KODU,
            PAKET_RAF_OMRU_BITIS_TARIHI = entity.PAKET_RAF_OMRU_BITIS_TARIHI,
            PAKETLEYEN_PERSONEL_KODU = entity.PAKETLEYEN_PERSONEL_KODU,
            ISLEM_ZAMANI = entity.ISLEM_ZAMANI,
            STERILIZASYON_BASLAMA_ZAMANI = entity.STERILIZASYON_BASLAMA_ZAMANI,
            STERILIZASYON_BITIS_ZAMANI = entity.STERILIZASYON_BITIS_ZAMANI,
            STERILIZASYON_PERSONEL_KODU = entity.STERILIZASYON_PERSONEL_KODU,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.SterilizasyonSet)]
    public async Task<ActionResult<string>> Create(SterilizasyonSetDto dto, CancellationToken ct)
    {
        var entity = new STERILIZASYON_SET
        {
            STERILIZASYON_SET_KODU = dto.STERILIZASYON_SET_KODU,
DEPO_KODU = dto.DEPO_KODU,
            STERILIZASYON_PAKET_KODU = dto.STERILIZASYON_PAKET_KODU,
            BARKOD = dto.BARKOD,
            BARKOD_BASAN_KULLANICI_KODU = dto.BARKOD_BASAN_KULLANICI_KODU,
            BARKOD_ZAMANI = dto.BARKOD_ZAMANI,
            CIHAZ_KODU = dto.CIHAZ_KODU,
            STERILIZASYON_CEVRIM_NUMARASI = dto.STERILIZASYON_CEVRIM_NUMARASI,
            SET_IADE_DURUMU = dto.SET_IADE_DURUMU,
            SET_IADE_ZAMANI = dto.SET_IADE_ZAMANI,
            SET_IADE_EDEN_PERSONEL_KODU = dto.SET_IADE_EDEN_PERSONEL_KODU,
            SET_IADE_ALAN_PERSONEL_KODU = dto.SET_IADE_ALAN_PERSONEL_KODU,
            PAKET_RAF_OMRU_BITIS_TARIHI = dto.PAKET_RAF_OMRU_BITIS_TARIHI,
            PAKETLEYEN_PERSONEL_KODU = dto.PAKETLEYEN_PERSONEL_KODU,
            ISLEM_ZAMANI = dto.ISLEM_ZAMANI,
            STERILIZASYON_BASLAMA_ZAMANI = dto.STERILIZASYON_BASLAMA_ZAMANI,
            STERILIZASYON_BITIS_ZAMANI = dto.STERILIZASYON_BITIS_ZAMANI,
            STERILIZASYON_PERSONEL_KODU = dto.STERILIZASYON_PERSONEL_KODU,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<STERILIZASYON_SET>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.STERILIZASYON_SET_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.SterilizasyonSet)]
    public async Task<IActionResult> Update(string id, SterilizasyonSetDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<STERILIZASYON_SET>()
            .FirstOrDefaultAsync(e => e.STERILIZASYON_SET_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.DEPO_KODU = dto.DEPO_KODU;
        entity.STERILIZASYON_PAKET_KODU = dto.STERILIZASYON_PAKET_KODU;
        entity.BARKOD = dto.BARKOD;
        entity.BARKOD_BASAN_KULLANICI_KODU = dto.BARKOD_BASAN_KULLANICI_KODU;
        entity.BARKOD_ZAMANI = dto.BARKOD_ZAMANI;
        entity.CIHAZ_KODU = dto.CIHAZ_KODU;
        entity.STERILIZASYON_CEVRIM_NUMARASI = dto.STERILIZASYON_CEVRIM_NUMARASI;
        entity.SET_IADE_DURUMU = dto.SET_IADE_DURUMU;
        entity.SET_IADE_ZAMANI = dto.SET_IADE_ZAMANI;
        entity.SET_IADE_EDEN_PERSONEL_KODU = dto.SET_IADE_EDEN_PERSONEL_KODU;
        entity.SET_IADE_ALAN_PERSONEL_KODU = dto.SET_IADE_ALAN_PERSONEL_KODU;
        entity.PAKET_RAF_OMRU_BITIS_TARIHI = dto.PAKET_RAF_OMRU_BITIS_TARIHI;
        entity.PAKETLEYEN_PERSONEL_KODU = dto.PAKETLEYEN_PERSONEL_KODU;
        entity.ISLEM_ZAMANI = dto.ISLEM_ZAMANI;
        entity.STERILIZASYON_BASLAMA_ZAMANI = dto.STERILIZASYON_BASLAMA_ZAMANI;
        entity.STERILIZASYON_BITIS_ZAMANI = dto.STERILIZASYON_BITIS_ZAMANI;
        entity.STERILIZASYON_PERSONEL_KODU = dto.STERILIZASYON_PERSONEL_KODU;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.SterilizasyonSet)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STERILIZASYON_SET>()
            .FirstOrDefaultAsync(e => e.STERILIZASYON_SET_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<STERILIZASYON_SET>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
