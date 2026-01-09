using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.PersonelEgitim;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class PersonelEgitimController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public PersonelEgitimController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.PersonelEgitim)]
    public async Task<List<PersonelEgitimDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<PERSONEL_EGITIM>()
            .AsNoTracking()
            .Select(e => new PersonelEgitimDto
            {
                PERSONEL_EGITIM_KODU = e.PERSONEL_EGITIM_KODU,
PERSONEL_KODU = e.PERSONEL_KODU,
                PERSONEL_EGITIM_TURU = e.PERSONEL_EGITIM_TURU,
                SERTIFIKA_TIPI = e.SERTIFIKA_TIPI,
                SERTIFIKA_PUANI = e.SERTIFIKA_PUANI,
                BELGE_NUMARASI = e.BELGE_NUMARASI,
                EGITIM_BASLANGIC_ZAMANI = e.EGITIM_BASLANGIC_ZAMANI,
                EGITIM_BITIS_ZAMANI = e.EGITIM_BITIS_ZAMANI,
                EGITIM_VEREN_KISI_BILGISI = e.EGITIM_VEREN_KISI_BILGISI,
                EGITIM_YERI = e.EGITIM_YERI,
                ONAYLAYAN_PERSONEL_KODU = e.ONAYLAYAN_PERSONEL_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.PersonelEgitim)]
    public async Task<ActionResult<PersonelEgitimDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_EGITIM>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.PERSONEL_EGITIM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new PersonelEgitimDto
        {
            PERSONEL_EGITIM_KODU = entity.PERSONEL_EGITIM_KODU,
PERSONEL_KODU = entity.PERSONEL_KODU,
            PERSONEL_EGITIM_TURU = entity.PERSONEL_EGITIM_TURU,
            SERTIFIKA_TIPI = entity.SERTIFIKA_TIPI,
            SERTIFIKA_PUANI = entity.SERTIFIKA_PUANI,
            BELGE_NUMARASI = entity.BELGE_NUMARASI,
            EGITIM_BASLANGIC_ZAMANI = entity.EGITIM_BASLANGIC_ZAMANI,
            EGITIM_BITIS_ZAMANI = entity.EGITIM_BITIS_ZAMANI,
            EGITIM_VEREN_KISI_BILGISI = entity.EGITIM_VEREN_KISI_BILGISI,
            EGITIM_YERI = entity.EGITIM_YERI,
            ONAYLAYAN_PERSONEL_KODU = entity.ONAYLAYAN_PERSONEL_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.PersonelEgitim)]
    public async Task<ActionResult<string>> Create(PersonelEgitimDto dto, CancellationToken ct)
    {
        var entity = new PERSONEL_EGITIM
        {
            PERSONEL_EGITIM_KODU = dto.PERSONEL_EGITIM_KODU,
PERSONEL_KODU = dto.PERSONEL_KODU,
            PERSONEL_EGITIM_TURU = dto.PERSONEL_EGITIM_TURU,
            SERTIFIKA_TIPI = dto.SERTIFIKA_TIPI,
            SERTIFIKA_PUANI = dto.SERTIFIKA_PUANI,
            BELGE_NUMARASI = dto.BELGE_NUMARASI,
            EGITIM_BASLANGIC_ZAMANI = dto.EGITIM_BASLANGIC_ZAMANI,
            EGITIM_BITIS_ZAMANI = dto.EGITIM_BITIS_ZAMANI,
            EGITIM_VEREN_KISI_BILGISI = dto.EGITIM_VEREN_KISI_BILGISI,
            EGITIM_YERI = dto.EGITIM_YERI,
            ONAYLAYAN_PERSONEL_KODU = dto.ONAYLAYAN_PERSONEL_KODU,
        };

        _db.Set<PERSONEL_EGITIM>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.PERSONEL_EGITIM_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.PersonelEgitim)]
    public async Task<IActionResult> Update(string id, PersonelEgitimDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_EGITIM>()
            .FirstOrDefaultAsync(e => e.PERSONEL_EGITIM_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.PERSONEL_KODU = dto.PERSONEL_KODU;
        entity.PERSONEL_EGITIM_TURU = dto.PERSONEL_EGITIM_TURU;
        entity.SERTIFIKA_TIPI = dto.SERTIFIKA_TIPI;
        entity.SERTIFIKA_PUANI = dto.SERTIFIKA_PUANI;
        entity.BELGE_NUMARASI = dto.BELGE_NUMARASI;
        entity.EGITIM_BASLANGIC_ZAMANI = dto.EGITIM_BASLANGIC_ZAMANI;
        entity.EGITIM_BITIS_ZAMANI = dto.EGITIM_BITIS_ZAMANI;
        entity.EGITIM_VEREN_KISI_BILGISI = dto.EGITIM_VEREN_KISI_BILGISI;
        entity.EGITIM_YERI = dto.EGITIM_YERI;
        entity.ONAYLAYAN_PERSONEL_KODU = dto.ONAYLAYAN_PERSONEL_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.PersonelEgitim)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_EGITIM>()
            .FirstOrDefaultAsync(e => e.PERSONEL_EGITIM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<PERSONEL_EGITIM>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
