using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.IntiharIzlem;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class IntiharIzlemController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public IntiharIzlemController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.IntiharIzlem)]
    public async Task<List<IntiharIzlemDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<INTIHAR_IZLEM>()
            .AsNoTracking()
            .Select(e => new IntiharIzlemDto
            {
                INTIHAR_IZLEM_KODU = e.INTIHAR_IZLEM_KODU,
HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                INTIHAR_KRIZ_VAKA_TURU = e.INTIHAR_KRIZ_VAKA_TURU,
                INTIHAR_GIRISIM_KRIZ_NEDENLERI = e.INTIHAR_GIRISIM_KRIZ_NEDENLERI,
                INTIHAR_GIRISIMI_YONTEMI = e.INTIHAR_GIRISIMI_YONTEMI,
                INTIHAR_KRIZ_VAKA_SONUCU = e.INTIHAR_KRIZ_VAKA_SONUCU,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.IntiharIzlem)]
    public async Task<ActionResult<IntiharIzlemDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<INTIHAR_IZLEM>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.INTIHAR_IZLEM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new IntiharIzlemDto
        {
            INTIHAR_IZLEM_KODU = entity.INTIHAR_IZLEM_KODU,
HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            INTIHAR_KRIZ_VAKA_TURU = entity.INTIHAR_KRIZ_VAKA_TURU,
            INTIHAR_GIRISIM_KRIZ_NEDENLERI = entity.INTIHAR_GIRISIM_KRIZ_NEDENLERI,
            INTIHAR_GIRISIMI_YONTEMI = entity.INTIHAR_GIRISIMI_YONTEMI,
            INTIHAR_KRIZ_VAKA_SONUCU = entity.INTIHAR_KRIZ_VAKA_SONUCU,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.IntiharIzlem)]
    public async Task<ActionResult<string>> Create(IntiharIzlemDto dto, CancellationToken ct)
    {
        var entity = new INTIHAR_IZLEM
        {
            INTIHAR_IZLEM_KODU = dto.INTIHAR_IZLEM_KODU,
HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            INTIHAR_KRIZ_VAKA_TURU = dto.INTIHAR_KRIZ_VAKA_TURU,
            INTIHAR_GIRISIM_KRIZ_NEDENLERI = dto.INTIHAR_GIRISIM_KRIZ_NEDENLERI,
            INTIHAR_GIRISIMI_YONTEMI = dto.INTIHAR_GIRISIMI_YONTEMI,
            INTIHAR_KRIZ_VAKA_SONUCU = dto.INTIHAR_KRIZ_VAKA_SONUCU,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<INTIHAR_IZLEM>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.INTIHAR_IZLEM_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.IntiharIzlem)]
    public async Task<IActionResult> Update(string id, IntiharIzlemDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<INTIHAR_IZLEM>()
            .FirstOrDefaultAsync(e => e.INTIHAR_IZLEM_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.INTIHAR_KRIZ_VAKA_TURU = dto.INTIHAR_KRIZ_VAKA_TURU;
        entity.INTIHAR_GIRISIM_KRIZ_NEDENLERI = dto.INTIHAR_GIRISIM_KRIZ_NEDENLERI;
        entity.INTIHAR_GIRISIMI_YONTEMI = dto.INTIHAR_GIRISIMI_YONTEMI;
        entity.INTIHAR_KRIZ_VAKA_SONUCU = dto.INTIHAR_KRIZ_VAKA_SONUCU;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.IntiharIzlem)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<INTIHAR_IZLEM>()
            .FirstOrDefaultAsync(e => e.INTIHAR_IZLEM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<INTIHAR_IZLEM>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
