using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Personel;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class PersonelController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public PersonelController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Personel)]
    public async Task<List<PersonelDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<PERSONEL>()
            .AsNoTracking()
            .Select(e => new PersonelDto
            {
                PERSONEL_KODU = e.PERSONEL_KODU,
                TC_KIMLIK_NO = e.TC_KIMLIK_NO,
                AD = e.AD,
                SOYAD = e.SOYAD,
                UNVAN = e.UNVAN,
                UZMANLIK_KODU = e.UZMANLIK_KODU,
                BIRIM_KODU = e.BIRIM_KODU,
                CINSIYET = e.CINSIYET,
                DOGUM_TARIHI = e.DOGUM_TARIHI,
                TELEFON = e.TELEFON,
                EMAIL = e.EMAIL,
                DIPLOMA_NO = e.DIPLOMA_NO,
                DIPLOMA_TESCIL_NO = e.DIPLOMA_TESCIL_NO,
                ISE_BASLAMA_TARIHI = e.ISE_BASLAMA_TARIHI,
                AKTIF = e.AKTIF,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Personel)]
    public async Task<ActionResult<PersonelDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.PERSONEL_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new PersonelDto
        {
            PERSONEL_KODU = entity.PERSONEL_KODU,
            TC_KIMLIK_NO = entity.TC_KIMLIK_NO,
            AD = entity.AD,
            SOYAD = entity.SOYAD,
            UNVAN = entity.UNVAN,
            UZMANLIK_KODU = entity.UZMANLIK_KODU,
            BIRIM_KODU = entity.BIRIM_KODU,
            CINSIYET = entity.CINSIYET,
            DOGUM_TARIHI = entity.DOGUM_TARIHI,
            TELEFON = entity.TELEFON,
            EMAIL = entity.EMAIL,
            DIPLOMA_NO = entity.DIPLOMA_NO,
            DIPLOMA_TESCIL_NO = entity.DIPLOMA_TESCIL_NO,
            ISE_BASLAMA_TARIHI = entity.ISE_BASLAMA_TARIHI,
            AKTIF = entity.AKTIF,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Personel)]
    public async Task<ActionResult<string>> Create(PersonelDto dto, CancellationToken ct)
    {
        var entity = new PERSONEL
        {
            PERSONEL_KODU = dto.PERSONEL_KODU,
            TC_KIMLIK_NO = dto.TC_KIMLIK_NO,
            AD = dto.AD,
            SOYAD = dto.SOYAD,
            UNVAN = dto.UNVAN,
            UZMANLIK_KODU = dto.UZMANLIK_KODU,
            BIRIM_KODU = dto.BIRIM_KODU,
            CINSIYET = dto.CINSIYET,
            DOGUM_TARIHI = dto.DOGUM_TARIHI,
            TELEFON = dto.TELEFON,
            EMAIL = dto.EMAIL,
            DIPLOMA_NO = dto.DIPLOMA_NO,
            DIPLOMA_TESCIL_NO = dto.DIPLOMA_TESCIL_NO,
            ISE_BASLAMA_TARIHI = dto.ISE_BASLAMA_TARIHI,
            AKTIF = dto.AKTIF,
        };

        _db.Set<PERSONEL>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.PERSONEL_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Personel)]
    public async Task<IActionResult> Update(string id, PersonelDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL>()
            .FirstOrDefaultAsync(e => e.PERSONEL_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.TC_KIMLIK_NO = dto.TC_KIMLIK_NO;
        entity.AD = dto.AD;
        entity.SOYAD = dto.SOYAD;
        entity.UNVAN = dto.UNVAN;
        entity.UZMANLIK_KODU = dto.UZMANLIK_KODU;
        entity.BIRIM_KODU = dto.BIRIM_KODU;
        entity.CINSIYET = dto.CINSIYET;
        entity.DOGUM_TARIHI = dto.DOGUM_TARIHI;
        entity.TELEFON = dto.TELEFON;
        entity.EMAIL = dto.EMAIL;
        entity.DIPLOMA_NO = dto.DIPLOMA_NO;
        entity.DIPLOMA_TESCIL_NO = dto.DIPLOMA_TESCIL_NO;
        entity.ISE_BASLAMA_TARIHI = dto.ISE_BASLAMA_TARIHI;
        entity.AKTIF = dto.AKTIF;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Personel)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL>()
            .FirstOrDefaultAsync(e => e.PERSONEL_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<PERSONEL>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
