using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.HastaGizlilik;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class HastaGizlilikController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public HastaGizlilikController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.HastaGizlilik)]
    public async Task<List<HastaGizlilikDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<HASTA_GIZLILIK>()
            .AsNoTracking()
            .Select(e => new HastaGizlilikDto
            {
                HASTA_GIZLILIK_KODU = e.HASTA_GIZLILIK_KODU,
HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                GIZLILIK_NEDENI = e.GIZLILIK_NEDENI,
                GORUNECEK_HASTA_ADI = e.GORUNECEK_HASTA_ADI,
                GORUNECEK_HASTA_SOYADI = e.GORUNECEK_HASTA_SOYADI,
                GIZLILIK_TURU = e.GIZLILIK_TURU,
                GIZLILIK_BASLAMA_ZAMANI = e.GIZLILIK_BASLAMA_ZAMANI,
                GIZLILIK_BITIS_ZAMANI = e.GIZLILIK_BITIS_ZAMANI,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.HastaGizlilik)]
    public async Task<ActionResult<HastaGizlilikDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_GIZLILIK>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.HASTA_GIZLILIK_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new HastaGizlilikDto
        {
            HASTA_GIZLILIK_KODU = entity.HASTA_GIZLILIK_KODU,
HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            GIZLILIK_NEDENI = entity.GIZLILIK_NEDENI,
            GORUNECEK_HASTA_ADI = entity.GORUNECEK_HASTA_ADI,
            GORUNECEK_HASTA_SOYADI = entity.GORUNECEK_HASTA_SOYADI,
            GIZLILIK_TURU = entity.GIZLILIK_TURU,
            GIZLILIK_BASLAMA_ZAMANI = entity.GIZLILIK_BASLAMA_ZAMANI,
            GIZLILIK_BITIS_ZAMANI = entity.GIZLILIK_BITIS_ZAMANI,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.HastaGizlilik)]
    public async Task<ActionResult<string>> Create(HastaGizlilikDto dto, CancellationToken ct)
    {
        var entity = new HASTA_GIZLILIK
        {
            HASTA_GIZLILIK_KODU = dto.HASTA_GIZLILIK_KODU,
HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            GIZLILIK_NEDENI = dto.GIZLILIK_NEDENI,
            GORUNECEK_HASTA_ADI = dto.GORUNECEK_HASTA_ADI,
            GORUNECEK_HASTA_SOYADI = dto.GORUNECEK_HASTA_SOYADI,
            GIZLILIK_TURU = dto.GIZLILIK_TURU,
            GIZLILIK_BASLAMA_ZAMANI = dto.GIZLILIK_BASLAMA_ZAMANI,
            GIZLILIK_BITIS_ZAMANI = dto.GIZLILIK_BITIS_ZAMANI,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<HASTA_GIZLILIK>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.HASTA_GIZLILIK_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.HastaGizlilik)]
    public async Task<IActionResult> Update(string id, HastaGizlilikDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_GIZLILIK>()
            .FirstOrDefaultAsync(e => e.HASTA_GIZLILIK_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.GIZLILIK_NEDENI = dto.GIZLILIK_NEDENI;
        entity.GORUNECEK_HASTA_ADI = dto.GORUNECEK_HASTA_ADI;
        entity.GORUNECEK_HASTA_SOYADI = dto.GORUNECEK_HASTA_SOYADI;
        entity.GIZLILIK_TURU = dto.GIZLILIK_TURU;
        entity.GIZLILIK_BASLAMA_ZAMANI = dto.GIZLILIK_BASLAMA_ZAMANI;
        entity.GIZLILIK_BITIS_ZAMANI = dto.GIZLILIK_BITIS_ZAMANI;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.HastaGizlilik)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_GIZLILIK>()
            .FirstOrDefaultAsync(e => e.HASTA_GIZLILIK_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<HASTA_GIZLILIK>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
