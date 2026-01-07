using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.PersonelBanka;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class PersonelBankaController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public PersonelBankaController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.PersonelBanka)]
    public async Task<List<PersonelBankaDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<PERSONEL_BANKA>()
            .AsNoTracking()
            .Select(e => new PersonelBankaDto
            {
                PERSONEL_BANKA_KODU = e.PERSONEL_BANKA_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                PERSONEL_KODU = e.PERSONEL_KODU,
                BANKA = e.BANKA,
                HESAP_NUMARASI = e.HESAP_NUMARASI,
                SUBE_KODU = e.SUBE_KODU,
                IBAN_NUMARASI = e.IBAN_NUMARASI,
                BORDRO_TURU = e.BORDRO_TURU,
                HESAP_AKTIFLIK_BILGISI = e.HESAP_AKTIFLIK_BILGISI,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.PersonelBanka)]
    public async Task<ActionResult<PersonelBankaDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_BANKA>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.PERSONEL_BANKA_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new PersonelBankaDto
        {
            PERSONEL_BANKA_KODU = entity.PERSONEL_BANKA_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            PERSONEL_KODU = entity.PERSONEL_KODU,
            BANKA = entity.BANKA,
            HESAP_NUMARASI = entity.HESAP_NUMARASI,
            SUBE_KODU = entity.SUBE_KODU,
            IBAN_NUMARASI = entity.IBAN_NUMARASI,
            BORDRO_TURU = entity.BORDRO_TURU,
            HESAP_AKTIFLIK_BILGISI = entity.HESAP_AKTIFLIK_BILGISI,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.PersonelBanka)]
    public async Task<ActionResult<string>> Create(PersonelBankaDto dto, CancellationToken ct)
    {
        var entity = new PERSONEL_BANKA
        {
            PERSONEL_BANKA_KODU = dto.PERSONEL_BANKA_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            PERSONEL_KODU = dto.PERSONEL_KODU,
            BANKA = dto.BANKA,
            HESAP_NUMARASI = dto.HESAP_NUMARASI,
            SUBE_KODU = dto.SUBE_KODU,
            IBAN_NUMARASI = dto.IBAN_NUMARASI,
            BORDRO_TURU = dto.BORDRO_TURU,
            HESAP_AKTIFLIK_BILGISI = dto.HESAP_AKTIFLIK_BILGISI,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<PERSONEL_BANKA>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.PERSONEL_BANKA_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.PersonelBanka)]
    public async Task<IActionResult> Update(string id, PersonelBankaDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_BANKA>()
            .FirstOrDefaultAsync(e => e.PERSONEL_BANKA_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.PERSONEL_KODU = dto.PERSONEL_KODU;
        entity.BANKA = dto.BANKA;
        entity.HESAP_NUMARASI = dto.HESAP_NUMARASI;
        entity.SUBE_KODU = dto.SUBE_KODU;
        entity.IBAN_NUMARASI = dto.IBAN_NUMARASI;
        entity.BORDRO_TURU = dto.BORDRO_TURU;
        entity.HESAP_AKTIFLIK_BILGISI = dto.HESAP_AKTIFLIK_BILGISI;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.PersonelBanka)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_BANKA>()
            .FirstOrDefaultAsync(e => e.PERSONEL_BANKA_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<PERSONEL_BANKA>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
