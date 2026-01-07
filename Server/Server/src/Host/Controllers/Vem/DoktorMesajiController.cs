using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.DoktorMesaji;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class DoktorMesajiController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public DoktorMesajiController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.DoktorMesaji)]
    public async Task<List<DoktorMesajiDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<DOKTOR_MESAJI>()
            .AsNoTracking()
            .Select(e => new DoktorMesajiDto
            {
                DOKTOR_MESAJI_KODU = e.DOKTOR_MESAJI_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                HASTA_MESAJLARI_TURU = e.HASTA_MESAJLARI_TURU,
                MESAJ_DETAYI = e.MESAJ_DETAYI,
                MESAJ_TARIHI = e.MESAJ_TARIHI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.DoktorMesaji)]
    public async Task<ActionResult<DoktorMesajiDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<DOKTOR_MESAJI>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.DOKTOR_MESAJI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new DoktorMesajiDto
        {
            DOKTOR_MESAJI_KODU = entity.DOKTOR_MESAJI_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            HASTA_MESAJLARI_TURU = entity.HASTA_MESAJLARI_TURU,
            MESAJ_DETAYI = entity.MESAJ_DETAYI,
            MESAJ_TARIHI = entity.MESAJ_TARIHI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.DoktorMesaji)]
    public async Task<ActionResult<string>> Create(DoktorMesajiDto dto, CancellationToken ct)
    {
        var entity = new DOKTOR_MESAJI
        {
            DOKTOR_MESAJI_KODU = dto.DOKTOR_MESAJI_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            HASTA_MESAJLARI_TURU = dto.HASTA_MESAJLARI_TURU,
            MESAJ_DETAYI = dto.MESAJ_DETAYI,
            MESAJ_TARIHI = dto.MESAJ_TARIHI,
        };

        _db.Set<DOKTOR_MESAJI>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.DOKTOR_MESAJI_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.DoktorMesaji)]
    public async Task<IActionResult> Update(string id, DoktorMesajiDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<DOKTOR_MESAJI>()
            .FirstOrDefaultAsync(e => e.DOKTOR_MESAJI_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.HASTA_MESAJLARI_TURU = dto.HASTA_MESAJLARI_TURU;
        entity.MESAJ_DETAYI = dto.MESAJ_DETAYI;
        entity.MESAJ_TARIHI = dto.MESAJ_TARIHI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.DoktorMesaji)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<DOKTOR_MESAJI>()
            .FirstOrDefaultAsync(e => e.DOKTOR_MESAJI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<DOKTOR_MESAJI>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
