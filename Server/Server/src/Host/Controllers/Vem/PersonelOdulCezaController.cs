using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.PersonelOdulCeza;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class PersonelOdulCezaController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public PersonelOdulCezaController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.PersonelOdulCeza)]
    public async Task<List<PersonelOdulCezaDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<PERSONEL_ODUL_CEZA>()
            .AsNoTracking()
            .Select(e => new PersonelOdulCezaDto
            {
                PERSONEL_ODUL_CEZA_KODU = e.PERSONEL_ODUL_CEZA_KODU,
PERSONEL_KODU = e.PERSONEL_KODU,
                ODUL_CEZA_DURUMU = e.ODUL_CEZA_DURUMU,
                ODUL_CEZA_TURU = e.ODUL_CEZA_TURU,
                CEZA_BASLANGIC_TARIHI = e.CEZA_BASLANGIC_TARIHI,
                CEZA_BITIS_TARIHI = e.CEZA_BITIS_TARIHI,
                ODUL_CEZA_VEREN_KURUM_KODU = e.ODUL_CEZA_VEREN_KURUM_KODU,
                ODUL_CEZA_ACIKLAMA = e.ODUL_CEZA_ACIKLAMA,
                TEBLIG_TARIHI = e.TEBLIG_TARIHI,
                TEBLIG_EVRAK_TARIHI = e.TEBLIG_EVRAK_TARIHI,
                TEBLIG_EVRAK_NUMARASI = e.TEBLIG_EVRAK_NUMARASI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.PersonelOdulCeza)]
    public async Task<ActionResult<PersonelOdulCezaDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_ODUL_CEZA>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.PERSONEL_ODUL_CEZA_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new PersonelOdulCezaDto
        {
            PERSONEL_ODUL_CEZA_KODU = entity.PERSONEL_ODUL_CEZA_KODU,
PERSONEL_KODU = entity.PERSONEL_KODU,
            ODUL_CEZA_DURUMU = entity.ODUL_CEZA_DURUMU,
            ODUL_CEZA_TURU = entity.ODUL_CEZA_TURU,
            CEZA_BASLANGIC_TARIHI = entity.CEZA_BASLANGIC_TARIHI,
            CEZA_BITIS_TARIHI = entity.CEZA_BITIS_TARIHI,
            ODUL_CEZA_VEREN_KURUM_KODU = entity.ODUL_CEZA_VEREN_KURUM_KODU,
            ODUL_CEZA_ACIKLAMA = entity.ODUL_CEZA_ACIKLAMA,
            TEBLIG_TARIHI = entity.TEBLIG_TARIHI,
            TEBLIG_EVRAK_TARIHI = entity.TEBLIG_EVRAK_TARIHI,
            TEBLIG_EVRAK_NUMARASI = entity.TEBLIG_EVRAK_NUMARASI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.PersonelOdulCeza)]
    public async Task<ActionResult<string>> Create(PersonelOdulCezaDto dto, CancellationToken ct)
    {
        var entity = new PERSONEL_ODUL_CEZA
        {
            PERSONEL_ODUL_CEZA_KODU = dto.PERSONEL_ODUL_CEZA_KODU,
PERSONEL_KODU = dto.PERSONEL_KODU,
            ODUL_CEZA_DURUMU = dto.ODUL_CEZA_DURUMU,
            ODUL_CEZA_TURU = dto.ODUL_CEZA_TURU,
            CEZA_BASLANGIC_TARIHI = dto.CEZA_BASLANGIC_TARIHI,
            CEZA_BITIS_TARIHI = dto.CEZA_BITIS_TARIHI,
            ODUL_CEZA_VEREN_KURUM_KODU = dto.ODUL_CEZA_VEREN_KURUM_KODU,
            ODUL_CEZA_ACIKLAMA = dto.ODUL_CEZA_ACIKLAMA,
            TEBLIG_TARIHI = dto.TEBLIG_TARIHI,
            TEBLIG_EVRAK_TARIHI = dto.TEBLIG_EVRAK_TARIHI,
            TEBLIG_EVRAK_NUMARASI = dto.TEBLIG_EVRAK_NUMARASI,
        };

        _db.Set<PERSONEL_ODUL_CEZA>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.PERSONEL_ODUL_CEZA_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.PersonelOdulCeza)]
    public async Task<IActionResult> Update(string id, PersonelOdulCezaDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_ODUL_CEZA>()
            .FirstOrDefaultAsync(e => e.PERSONEL_ODUL_CEZA_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.PERSONEL_KODU = dto.PERSONEL_KODU;
        entity.ODUL_CEZA_DURUMU = dto.ODUL_CEZA_DURUMU;
        entity.ODUL_CEZA_TURU = dto.ODUL_CEZA_TURU;
        entity.CEZA_BASLANGIC_TARIHI = dto.CEZA_BASLANGIC_TARIHI;
        entity.CEZA_BITIS_TARIHI = dto.CEZA_BITIS_TARIHI;
        entity.ODUL_CEZA_VEREN_KURUM_KODU = dto.ODUL_CEZA_VEREN_KURUM_KODU;
        entity.ODUL_CEZA_ACIKLAMA = dto.ODUL_CEZA_ACIKLAMA;
        entity.TEBLIG_TARIHI = dto.TEBLIG_TARIHI;
        entity.TEBLIG_EVRAK_TARIHI = dto.TEBLIG_EVRAK_TARIHI;
        entity.TEBLIG_EVRAK_NUMARASI = dto.TEBLIG_EVRAK_NUMARASI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.PersonelOdulCeza)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_ODUL_CEZA>()
            .FirstOrDefaultAsync(e => e.PERSONEL_ODUL_CEZA_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<PERSONEL_ODUL_CEZA>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
