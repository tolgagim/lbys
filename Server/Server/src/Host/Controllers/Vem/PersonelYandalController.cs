using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.PersonelYandal;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class PersonelYandalController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public PersonelYandalController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.PersonelYandal)]
    public async Task<List<PersonelYandalDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<PERSONEL_YANDAL>()
            .AsNoTracking()
            .Select(e => new PersonelYandalDto
            {
                PERSONEL_YANDAL_KODU = e.PERSONEL_YANDAL_KODU,
PERSONEL_KODU = e.PERSONEL_KODU,
                YANDAL_BASLANGIC_TARIHI = e.YANDAL_BASLANGIC_TARIHI,
                YANDAL_BITIS_TARIHI = e.YANDAL_BITIS_TARIHI,
                MEDULA_BRANS_KODU = e.MEDULA_BRANS_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.PersonelYandal)]
    public async Task<ActionResult<PersonelYandalDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_YANDAL>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.PERSONEL_YANDAL_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new PersonelYandalDto
        {
            PERSONEL_YANDAL_KODU = entity.PERSONEL_YANDAL_KODU,
PERSONEL_KODU = entity.PERSONEL_KODU,
            YANDAL_BASLANGIC_TARIHI = entity.YANDAL_BASLANGIC_TARIHI,
            YANDAL_BITIS_TARIHI = entity.YANDAL_BITIS_TARIHI,
            MEDULA_BRANS_KODU = entity.MEDULA_BRANS_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.PersonelYandal)]
    public async Task<ActionResult<string>> Create(PersonelYandalDto dto, CancellationToken ct)
    {
        var entity = new PERSONEL_YANDAL
        {
            PERSONEL_YANDAL_KODU = dto.PERSONEL_YANDAL_KODU,
PERSONEL_KODU = dto.PERSONEL_KODU,
            YANDAL_BASLANGIC_TARIHI = dto.YANDAL_BASLANGIC_TARIHI,
            YANDAL_BITIS_TARIHI = dto.YANDAL_BITIS_TARIHI,
            MEDULA_BRANS_KODU = dto.MEDULA_BRANS_KODU,
        };

        _db.Set<PERSONEL_YANDAL>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.PERSONEL_YANDAL_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.PersonelYandal)]
    public async Task<IActionResult> Update(string id, PersonelYandalDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_YANDAL>()
            .FirstOrDefaultAsync(e => e.PERSONEL_YANDAL_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.PERSONEL_KODU = dto.PERSONEL_KODU;
        entity.YANDAL_BASLANGIC_TARIHI = dto.YANDAL_BASLANGIC_TARIHI;
        entity.YANDAL_BITIS_TARIHI = dto.YANDAL_BITIS_TARIHI;
        entity.MEDULA_BRANS_KODU = dto.MEDULA_BRANS_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.PersonelYandal)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_YANDAL>()
            .FirstOrDefaultAsync(e => e.PERSONEL_YANDAL_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<PERSONEL_YANDAL>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
