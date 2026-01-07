using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.KullaniciGrup;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class KullaniciGrupController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public KullaniciGrupController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.KullaniciGrup)]
    public async Task<List<KullaniciGrupDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<KULLANICI_GRUP>()
            .AsNoTracking()
            .Select(e => new KullaniciGrupDto
            {
                KULLANICI_GRUP_KODU = e.KULLANICI_GRUP_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                KULLANICI_GRUP_ADI = e.KULLANICI_GRUP_ADI,
                AKTIFLIK_BILGISI = e.AKTIFLIK_BILGISI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.KullaniciGrup)]
    public async Task<ActionResult<KullaniciGrupDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KULLANICI_GRUP>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.KULLANICI_GRUP_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new KullaniciGrupDto
        {
            KULLANICI_GRUP_KODU = entity.KULLANICI_GRUP_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            KULLANICI_GRUP_ADI = entity.KULLANICI_GRUP_ADI,
            AKTIFLIK_BILGISI = entity.AKTIFLIK_BILGISI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.KullaniciGrup)]
    public async Task<ActionResult<string>> Create(KullaniciGrupDto dto, CancellationToken ct)
    {
        var entity = new KULLANICI_GRUP
        {
            KULLANICI_GRUP_KODU = dto.KULLANICI_GRUP_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            KULLANICI_GRUP_ADI = dto.KULLANICI_GRUP_ADI,
            AKTIFLIK_BILGISI = dto.AKTIFLIK_BILGISI,
        };

        _db.Set<KULLANICI_GRUP>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.KULLANICI_GRUP_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.KullaniciGrup)]
    public async Task<IActionResult> Update(string id, KullaniciGrupDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<KULLANICI_GRUP>()
            .FirstOrDefaultAsync(e => e.KULLANICI_GRUP_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.KULLANICI_GRUP_ADI = dto.KULLANICI_GRUP_ADI;
        entity.AKTIFLIK_BILGISI = dto.AKTIFLIK_BILGISI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.KullaniciGrup)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KULLANICI_GRUP>()
            .FirstOrDefaultAsync(e => e.KULLANICI_GRUP_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<KULLANICI_GRUP>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
