using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Dogum;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class DogumController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public DogumController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Dogum)]
    public async Task<List<DogumDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<DOGUM>()
            .AsNoTracking()
            .Select(e => new DogumDto
            {
                DOGUM_KODU = e.DOGUM_KODU,
HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                HASTA_HIZMET_KODU = e.HASTA_HIZMET_KODU,
                AMELIYAT_KODU = e.AMELIYAT_KODU,
                BABA_TC_KIMLIK_NUMARASI = e.BABA_TC_KIMLIK_NUMARASI,
                KOMPLIKASYON_TANISI = e.KOMPLIKASYON_TANISI,
                DOGUM_NOTU = e.DOGUM_NOTU,
                DOGUM_BASLAMA_ZAMANI = e.DOGUM_BASLAMA_ZAMANI,
                DOGUM_BITIS_ZAMANI = e.DOGUM_BITIS_ZAMANI,
                HEKIM_KODU = e.HEKIM_KODU,
                EBE_KODU = e.EBE_KODU,
                BIRIM_KODU = e.BIRIM_KODU,
                DEFTER_NUMARASI = e.DEFTER_NUMARASI,
                GUNCELLEYEN_KULLANICI_KODU = e.GUNCELLEYEN_KULLANICI_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Dogum)]
    public async Task<ActionResult<DogumDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<DOGUM>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.DOGUM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new DogumDto
        {
            DOGUM_KODU = entity.DOGUM_KODU,
HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            HASTA_HIZMET_KODU = entity.HASTA_HIZMET_KODU,
            AMELIYAT_KODU = entity.AMELIYAT_KODU,
            BABA_TC_KIMLIK_NUMARASI = entity.BABA_TC_KIMLIK_NUMARASI,
            KOMPLIKASYON_TANISI = entity.KOMPLIKASYON_TANISI,
            DOGUM_NOTU = entity.DOGUM_NOTU,
            DOGUM_BASLAMA_ZAMANI = entity.DOGUM_BASLAMA_ZAMANI,
            DOGUM_BITIS_ZAMANI = entity.DOGUM_BITIS_ZAMANI,
            HEKIM_KODU = entity.HEKIM_KODU,
            EBE_KODU = entity.EBE_KODU,
            BIRIM_KODU = entity.BIRIM_KODU,
            DEFTER_NUMARASI = entity.DEFTER_NUMARASI,
            GUNCELLEYEN_KULLANICI_KODU = entity.GUNCELLEYEN_KULLANICI_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Dogum)]
    public async Task<ActionResult<string>> Create(DogumDto dto, CancellationToken ct)
    {
        var entity = new DOGUM
        {
            DOGUM_KODU = dto.DOGUM_KODU,
HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            HASTA_HIZMET_KODU = dto.HASTA_HIZMET_KODU,
            AMELIYAT_KODU = dto.AMELIYAT_KODU,
            BABA_TC_KIMLIK_NUMARASI = dto.BABA_TC_KIMLIK_NUMARASI,
            KOMPLIKASYON_TANISI = dto.KOMPLIKASYON_TANISI,
            DOGUM_NOTU = dto.DOGUM_NOTU,
            DOGUM_BASLAMA_ZAMANI = dto.DOGUM_BASLAMA_ZAMANI,
            DOGUM_BITIS_ZAMANI = dto.DOGUM_BITIS_ZAMANI,
            HEKIM_KODU = dto.HEKIM_KODU,
            EBE_KODU = dto.EBE_KODU,
            BIRIM_KODU = dto.BIRIM_KODU,
            DEFTER_NUMARASI = dto.DEFTER_NUMARASI,
            GUNCELLEYEN_KULLANICI_KODU = dto.GUNCELLEYEN_KULLANICI_KODU,
        };

        _db.Set<DOGUM>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.DOGUM_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Dogum)]
    public async Task<IActionResult> Update(string id, DogumDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<DOGUM>()
            .FirstOrDefaultAsync(e => e.DOGUM_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.HASTA_HIZMET_KODU = dto.HASTA_HIZMET_KODU;
        entity.AMELIYAT_KODU = dto.AMELIYAT_KODU;
        entity.BABA_TC_KIMLIK_NUMARASI = dto.BABA_TC_KIMLIK_NUMARASI;
        entity.KOMPLIKASYON_TANISI = dto.KOMPLIKASYON_TANISI;
        entity.DOGUM_NOTU = dto.DOGUM_NOTU;
        entity.DOGUM_BASLAMA_ZAMANI = dto.DOGUM_BASLAMA_ZAMANI;
        entity.DOGUM_BITIS_ZAMANI = dto.DOGUM_BITIS_ZAMANI;
        entity.HEKIM_KODU = dto.HEKIM_KODU;
        entity.EBE_KODU = dto.EBE_KODU;
        entity.BIRIM_KODU = dto.BIRIM_KODU;
        entity.DEFTER_NUMARASI = dto.DEFTER_NUMARASI;
        entity.GUNCELLEYEN_KULLANICI_KODU = dto.GUNCELLEYEN_KULLANICI_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Dogum)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<DOGUM>()
            .FirstOrDefaultAsync(e => e.DOGUM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<DOGUM>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
