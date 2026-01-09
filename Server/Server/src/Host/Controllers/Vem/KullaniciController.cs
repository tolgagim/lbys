using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Kullanici;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class KullaniciController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public KullaniciController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Kullanici)]
    public async Task<List<KullaniciDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<KULLANICI>()
            .AsNoTracking()
            .Select(e => new KullaniciDto
            {
                KULLANICI_KODU = e.KULLANICI_KODU,
                PERSONEL_KODU = e.PERSONEL_KODU,
                KULLANICI_ADI = e.KULLANICI_ADI,
                AKTIFLIK_BILGISI = e.AKTIFLIK_BILGISI,
                PAROLA = e.PAROLA,
                PAROLA_SIFRELEME_TURU = e.PAROLA_SIFRELEME_TURU,
                SOYADI = e.SOYADI,
                TC_KIMLIK_NUMARASI = e.TC_KIMLIK_NUMARASI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Kullanici)]
    public async Task<ActionResult<KullaniciDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KULLANICI>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.KULLANICI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new KullaniciDto
        {
            KULLANICI_KODU = entity.KULLANICI_KODU,
            PERSONEL_KODU = entity.PERSONEL_KODU,
            KULLANICI_ADI = entity.KULLANICI_ADI,
            AKTIFLIK_BILGISI = entity.AKTIFLIK_BILGISI,
            PAROLA = entity.PAROLA,
            PAROLA_SIFRELEME_TURU = entity.PAROLA_SIFRELEME_TURU,
            SOYADI = entity.SOYADI,
            TC_KIMLIK_NUMARASI = entity.TC_KIMLIK_NUMARASI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Kullanici)]
    public async Task<ActionResult<string>> Create(KullaniciDto dto, CancellationToken ct)
    {
        var entity = new KULLANICI
        {
            KULLANICI_KODU = dto.KULLANICI_KODU,
            PERSONEL_KODU = dto.PERSONEL_KODU,
            KULLANICI_ADI = dto.KULLANICI_ADI,
            AKTIFLIK_BILGISI = dto.AKTIFLIK_BILGISI,
            PAROLA = dto.PAROLA,
            PAROLA_SIFRELEME_TURU = dto.PAROLA_SIFRELEME_TURU,
            SOYADI = dto.SOYADI,
            TC_KIMLIK_NUMARASI = dto.TC_KIMLIK_NUMARASI,
        };

        _db.Set<KULLANICI>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.KULLANICI_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Kullanici)]
    public async Task<IActionResult> Update(string id, KullaniciDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<KULLANICI>()
            .FirstOrDefaultAsync(e => e.KULLANICI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        entity.PERSONEL_KODU = dto.PERSONEL_KODU;
        entity.KULLANICI_ADI = dto.KULLANICI_ADI;
        entity.AKTIFLIK_BILGISI = dto.AKTIFLIK_BILGISI;
        entity.PAROLA = dto.PAROLA;
        entity.PAROLA_SIFRELEME_TURU = dto.PAROLA_SIFRELEME_TURU;
        entity.SOYADI = dto.SOYADI;
        entity.TC_KIMLIK_NUMARASI = dto.TC_KIMLIK_NUMARASI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Kullanici)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KULLANICI>()
            .FirstOrDefaultAsync(e => e.KULLANICI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<KULLANICI>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
