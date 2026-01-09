using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.PersonelOgrenim;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class PersonelOgrenimController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public PersonelOgrenimController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.PersonelOgrenim)]
    public async Task<List<PersonelOgrenimDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<PERSONEL_OGRENIM>()
            .AsNoTracking()
            .Select(e => new PersonelOgrenimDto
            {
                PERSONEL_OGRENIM_KODU = e.PERSONEL_OGRENIM_KODU,
PERSONEL_KODU = e.PERSONEL_KODU,
                OGRENIM_DURUMU = e.OGRENIM_DURUMU,
                OKUL_ADI = e.OKUL_ADI,
                OKULA_BASLANGIC_TARIHI = e.OKULA_BASLANGIC_TARIHI,
                MEZUNIYET_TARIHI = e.MEZUNIYET_TARIHI,
                BELGE_NUMARASI = e.BELGE_NUMARASI,
                ONAYLAYAN_PERSONEL_KODU = e.ONAYLAYAN_PERSONEL_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.PersonelOgrenim)]
    public async Task<ActionResult<PersonelOgrenimDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_OGRENIM>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.PERSONEL_OGRENIM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new PersonelOgrenimDto
        {
            PERSONEL_OGRENIM_KODU = entity.PERSONEL_OGRENIM_KODU,
PERSONEL_KODU = entity.PERSONEL_KODU,
            OGRENIM_DURUMU = entity.OGRENIM_DURUMU,
            OKUL_ADI = entity.OKUL_ADI,
            OKULA_BASLANGIC_TARIHI = entity.OKULA_BASLANGIC_TARIHI,
            MEZUNIYET_TARIHI = entity.MEZUNIYET_TARIHI,
            BELGE_NUMARASI = entity.BELGE_NUMARASI,
            ONAYLAYAN_PERSONEL_KODU = entity.ONAYLAYAN_PERSONEL_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.PersonelOgrenim)]
    public async Task<ActionResult<string>> Create(PersonelOgrenimDto dto, CancellationToken ct)
    {
        var entity = new PERSONEL_OGRENIM
        {
            PERSONEL_OGRENIM_KODU = dto.PERSONEL_OGRENIM_KODU,
PERSONEL_KODU = dto.PERSONEL_KODU,
            OGRENIM_DURUMU = dto.OGRENIM_DURUMU,
            OKUL_ADI = dto.OKUL_ADI,
            OKULA_BASLANGIC_TARIHI = dto.OKULA_BASLANGIC_TARIHI,
            MEZUNIYET_TARIHI = dto.MEZUNIYET_TARIHI,
            BELGE_NUMARASI = dto.BELGE_NUMARASI,
            ONAYLAYAN_PERSONEL_KODU = dto.ONAYLAYAN_PERSONEL_KODU,
        };

        _db.Set<PERSONEL_OGRENIM>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.PERSONEL_OGRENIM_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.PersonelOgrenim)]
    public async Task<IActionResult> Update(string id, PersonelOgrenimDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_OGRENIM>()
            .FirstOrDefaultAsync(e => e.PERSONEL_OGRENIM_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.PERSONEL_KODU = dto.PERSONEL_KODU;
        entity.OGRENIM_DURUMU = dto.OGRENIM_DURUMU;
        entity.OKUL_ADI = dto.OKUL_ADI;
        entity.OKULA_BASLANGIC_TARIHI = dto.OKULA_BASLANGIC_TARIHI;
        entity.MEZUNIYET_TARIHI = dto.MEZUNIYET_TARIHI;
        entity.BELGE_NUMARASI = dto.BELGE_NUMARASI;
        entity.ONAYLAYAN_PERSONEL_KODU = dto.ONAYLAYAN_PERSONEL_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.PersonelOgrenim)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_OGRENIM>()
            .FirstOrDefaultAsync(e => e.PERSONEL_OGRENIM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<PERSONEL_OGRENIM>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
