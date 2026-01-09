using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.PersonelIzinDurumu;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class PersonelIzinDurumuController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public PersonelIzinDurumuController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.PersonelIzinDurumu)]
    public async Task<List<PersonelIzinDurumuDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<PERSONEL_IZIN_DURUMU>()
            .AsNoTracking()
            .Select(e => new PersonelIzinDurumuDto
            {
                PERSONEL_IZIN_DURUMU_KODU = e.PERSONEL_IZIN_DURUMU_KODU,
PERSONEL_KODU = e.PERSONEL_KODU,
                KALAN_IZIN = e.KALAN_IZIN,
                YILLIK_IZIN_HAKKI = e.YILLIK_IZIN_HAKKI,
                PERSONEL_IZIN_YILI = e.PERSONEL_IZIN_YILI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.PersonelIzinDurumu)]
    public async Task<ActionResult<PersonelIzinDurumuDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_IZIN_DURUMU>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.PERSONEL_IZIN_DURUMU_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new PersonelIzinDurumuDto
        {
            PERSONEL_IZIN_DURUMU_KODU = entity.PERSONEL_IZIN_DURUMU_KODU,
PERSONEL_KODU = entity.PERSONEL_KODU,
            KALAN_IZIN = entity.KALAN_IZIN,
            YILLIK_IZIN_HAKKI = entity.YILLIK_IZIN_HAKKI,
            PERSONEL_IZIN_YILI = entity.PERSONEL_IZIN_YILI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.PersonelIzinDurumu)]
    public async Task<ActionResult<string>> Create(PersonelIzinDurumuDto dto, CancellationToken ct)
    {
        var entity = new PERSONEL_IZIN_DURUMU
        {
            PERSONEL_IZIN_DURUMU_KODU = dto.PERSONEL_IZIN_DURUMU_KODU,
PERSONEL_KODU = dto.PERSONEL_KODU,
            KALAN_IZIN = dto.KALAN_IZIN,
            YILLIK_IZIN_HAKKI = dto.YILLIK_IZIN_HAKKI,
            PERSONEL_IZIN_YILI = dto.PERSONEL_IZIN_YILI,
        };

        _db.Set<PERSONEL_IZIN_DURUMU>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.PERSONEL_IZIN_DURUMU_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.PersonelIzinDurumu)]
    public async Task<IActionResult> Update(string id, PersonelIzinDurumuDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_IZIN_DURUMU>()
            .FirstOrDefaultAsync(e => e.PERSONEL_IZIN_DURUMU_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.PERSONEL_KODU = dto.PERSONEL_KODU;
        entity.KALAN_IZIN = dto.KALAN_IZIN;
        entity.YILLIK_IZIN_HAKKI = dto.YILLIK_IZIN_HAKKI;
        entity.PERSONEL_IZIN_YILI = dto.PERSONEL_IZIN_YILI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.PersonelIzinDurumu)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_IZIN_DURUMU>()
            .FirstOrDefaultAsync(e => e.PERSONEL_IZIN_DURUMU_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<PERSONEL_IZIN_DURUMU>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
