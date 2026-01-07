using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.PersonelGorevlendirme;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class PersonelGorevlendirmeController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public PersonelGorevlendirmeController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.PersonelGorevlendirme)]
    public async Task<List<PersonelGorevlendirmeDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<PERSONEL_GOREVLENDIRME>()
            .AsNoTracking()
            .Select(e => new PersonelGorevlendirmeDto
            {
                PERSONEL_GOREVLENDIRME_KODU = e.PERSONEL_GOREVLENDIRME_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                PERSONEL_KODU = e.PERSONEL_KODU,
                GOREV_TURU = e.GOREV_TURU,
                GOREVLENDIRME_BASLAMA_TARIHI = e.GOREVLENDIRME_BASLAMA_TARIHI,
                GOREVLENDIRME_BITIS_TARIHI = e.GOREVLENDIRME_BITIS_TARIHI,
                GOREVLENDIRME_IL_KODU = e.GOREVLENDIRME_IL_KODU,
                GOREVLENDIRME_ILCE_KODU = e.GOREVLENDIRME_ILCE_KODU,
                GOREVLENDIRILDIGI_KURUM_KODU = e.GOREVLENDIRILDIGI_KURUM_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.PersonelGorevlendirme)]
    public async Task<ActionResult<PersonelGorevlendirmeDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_GOREVLENDIRME>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.PERSONEL_GOREVLENDIRME_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new PersonelGorevlendirmeDto
        {
            PERSONEL_GOREVLENDIRME_KODU = entity.PERSONEL_GOREVLENDIRME_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            PERSONEL_KODU = entity.PERSONEL_KODU,
            GOREV_TURU = entity.GOREV_TURU,
            GOREVLENDIRME_BASLAMA_TARIHI = entity.GOREVLENDIRME_BASLAMA_TARIHI,
            GOREVLENDIRME_BITIS_TARIHI = entity.GOREVLENDIRME_BITIS_TARIHI,
            GOREVLENDIRME_IL_KODU = entity.GOREVLENDIRME_IL_KODU,
            GOREVLENDIRME_ILCE_KODU = entity.GOREVLENDIRME_ILCE_KODU,
            GOREVLENDIRILDIGI_KURUM_KODU = entity.GOREVLENDIRILDIGI_KURUM_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.PersonelGorevlendirme)]
    public async Task<ActionResult<string>> Create(PersonelGorevlendirmeDto dto, CancellationToken ct)
    {
        var entity = new PERSONEL_GOREVLENDIRME
        {
            PERSONEL_GOREVLENDIRME_KODU = dto.PERSONEL_GOREVLENDIRME_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            PERSONEL_KODU = dto.PERSONEL_KODU,
            GOREV_TURU = dto.GOREV_TURU,
            GOREVLENDIRME_BASLAMA_TARIHI = dto.GOREVLENDIRME_BASLAMA_TARIHI,
            GOREVLENDIRME_BITIS_TARIHI = dto.GOREVLENDIRME_BITIS_TARIHI,
            GOREVLENDIRME_IL_KODU = dto.GOREVLENDIRME_IL_KODU,
            GOREVLENDIRME_ILCE_KODU = dto.GOREVLENDIRME_ILCE_KODU,
            GOREVLENDIRILDIGI_KURUM_KODU = dto.GOREVLENDIRILDIGI_KURUM_KODU,
        };

        _db.Set<PERSONEL_GOREVLENDIRME>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.PERSONEL_GOREVLENDIRME_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.PersonelGorevlendirme)]
    public async Task<IActionResult> Update(string id, PersonelGorevlendirmeDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_GOREVLENDIRME>()
            .FirstOrDefaultAsync(e => e.PERSONEL_GOREVLENDIRME_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.PERSONEL_KODU = dto.PERSONEL_KODU;
        entity.GOREV_TURU = dto.GOREV_TURU;
        entity.GOREVLENDIRME_BASLAMA_TARIHI = dto.GOREVLENDIRME_BASLAMA_TARIHI;
        entity.GOREVLENDIRME_BITIS_TARIHI = dto.GOREVLENDIRME_BITIS_TARIHI;
        entity.GOREVLENDIRME_IL_KODU = dto.GOREVLENDIRME_IL_KODU;
        entity.GOREVLENDIRME_ILCE_KODU = dto.GOREVLENDIRME_ILCE_KODU;
        entity.GOREVLENDIRILDIGI_KURUM_KODU = dto.GOREVLENDIRILDIGI_KURUM_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.PersonelGorevlendirme)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_GOREVLENDIRME>()
            .FirstOrDefaultAsync(e => e.PERSONEL_GOREVLENDIRME_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<PERSONEL_GOREVLENDIRME>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
