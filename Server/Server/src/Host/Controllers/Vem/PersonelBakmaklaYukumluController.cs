using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.PersonelBakmaklaYukumlu;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class PersonelBakmaklaYukumluController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public PersonelBakmaklaYukumluController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.PersonelBakmaklaYukumlu)]
    public async Task<List<PersonelBakmaklaYukumluDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<PERSONEL_BAKMAKLA_YUKUMLU>()
            .AsNoTracking()
            .Select(e => new PersonelBakmaklaYukumluDto
            {
                PERSONEL_BAKMAKLA_YUKUMLU_KODU = e.PERSONEL_BAKMAKLA_YUKUMLU_KODU,
PERSONEL_KODU = e.PERSONEL_KODU,
                PERSONEL_YAKINLIK_DERECESI = e.PERSONEL_YAKINLIK_DERECESI,
                TC_KIMLIK_NUMARASI = e.TC_KIMLIK_NUMARASI,
                AD = e.AD,
                SOYADI = e.SOYADI,
                DOGUM_TARIHI = e.DOGUM_TARIHI,
                OGRENIM_DURUMU = e.OGRENIM_DURUMU,
                ENGELLILIK_DURUMU = e.ENGELLILIK_DURUMU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.PersonelBakmaklaYukumlu)]
    public async Task<ActionResult<PersonelBakmaklaYukumluDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_BAKMAKLA_YUKUMLU>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.PERSONEL_BAKMAKLA_YUKUMLU_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new PersonelBakmaklaYukumluDto
        {
            PERSONEL_BAKMAKLA_YUKUMLU_KODU = entity.PERSONEL_BAKMAKLA_YUKUMLU_KODU,
PERSONEL_KODU = entity.PERSONEL_KODU,
            PERSONEL_YAKINLIK_DERECESI = entity.PERSONEL_YAKINLIK_DERECESI,
            TC_KIMLIK_NUMARASI = entity.TC_KIMLIK_NUMARASI,
            AD = entity.AD,
            SOYADI = entity.SOYADI,
            DOGUM_TARIHI = entity.DOGUM_TARIHI,
            OGRENIM_DURUMU = entity.OGRENIM_DURUMU,
            ENGELLILIK_DURUMU = entity.ENGELLILIK_DURUMU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.PersonelBakmaklaYukumlu)]
    public async Task<ActionResult<string>> Create(PersonelBakmaklaYukumluDto dto, CancellationToken ct)
    {
        var entity = new PERSONEL_BAKMAKLA_YUKUMLU
        {
            PERSONEL_BAKMAKLA_YUKUMLU_KODU = dto.PERSONEL_BAKMAKLA_YUKUMLU_KODU,
PERSONEL_KODU = dto.PERSONEL_KODU,
            PERSONEL_YAKINLIK_DERECESI = dto.PERSONEL_YAKINLIK_DERECESI,
            TC_KIMLIK_NUMARASI = dto.TC_KIMLIK_NUMARASI,
            AD = dto.AD,
            SOYADI = dto.SOYADI,
            DOGUM_TARIHI = dto.DOGUM_TARIHI,
            OGRENIM_DURUMU = dto.OGRENIM_DURUMU,
            ENGELLILIK_DURUMU = dto.ENGELLILIK_DURUMU,
        };

        _db.Set<PERSONEL_BAKMAKLA_YUKUMLU>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.PERSONEL_BAKMAKLA_YUKUMLU_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.PersonelBakmaklaYukumlu)]
    public async Task<IActionResult> Update(string id, PersonelBakmaklaYukumluDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_BAKMAKLA_YUKUMLU>()
            .FirstOrDefaultAsync(e => e.PERSONEL_BAKMAKLA_YUKUMLU_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.PERSONEL_KODU = dto.PERSONEL_KODU;
        entity.PERSONEL_YAKINLIK_DERECESI = dto.PERSONEL_YAKINLIK_DERECESI;
        entity.TC_KIMLIK_NUMARASI = dto.TC_KIMLIK_NUMARASI;
        entity.AD = dto.AD;
        entity.SOYADI = dto.SOYADI;
        entity.DOGUM_TARIHI = dto.DOGUM_TARIHI;
        entity.OGRENIM_DURUMU = dto.OGRENIM_DURUMU;
        entity.ENGELLILIK_DURUMU = dto.ENGELLILIK_DURUMU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.PersonelBakmaklaYukumlu)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_BAKMAKLA_YUKUMLU>()
            .FirstOrDefaultAsync(e => e.PERSONEL_BAKMAKLA_YUKUMLU_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<PERSONEL_BAKMAKLA_YUKUMLU>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
