using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Firma;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class FirmaController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public FirmaController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Firma)]
    public async Task<List<FirmaDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<FIRMA>()
            .AsNoTracking()
            .Select(e => new FirmaDto
            {
                FIRMA_KODU = e.FIRMA_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                FIRMA_ADI = e.FIRMA_ADI,
                TELEFON_NUMARASI = e.TELEFON_NUMARASI,
                YETKILI_KISI = e.YETKILI_KISI,
                FIRMA_ADRESI = e.FIRMA_ADRESI,
                AKTIFLIK_BILGISI = e.AKTIFLIK_BILGISI,
                VERGI_DAIRESI = e.VERGI_DAIRESI,
                VERGI_NUMARASI = e.VERGI_NUMARASI,
                EPOSTA_ADRESI = e.EPOSTA_ADRESI,
                IBAN_NUMARASI = e.IBAN_NUMARASI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Firma)]
    public async Task<ActionResult<FirmaDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<FIRMA>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.FIRMA_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new FirmaDto
        {
            FIRMA_KODU = entity.FIRMA_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            FIRMA_ADI = entity.FIRMA_ADI,
            TELEFON_NUMARASI = entity.TELEFON_NUMARASI,
            YETKILI_KISI = entity.YETKILI_KISI,
            FIRMA_ADRESI = entity.FIRMA_ADRESI,
            AKTIFLIK_BILGISI = entity.AKTIFLIK_BILGISI,
            VERGI_DAIRESI = entity.VERGI_DAIRESI,
            VERGI_NUMARASI = entity.VERGI_NUMARASI,
            EPOSTA_ADRESI = entity.EPOSTA_ADRESI,
            IBAN_NUMARASI = entity.IBAN_NUMARASI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Firma)]
    public async Task<ActionResult<string>> Create(FirmaDto dto, CancellationToken ct)
    {
        var entity = new FIRMA
        {
            FIRMA_KODU = dto.FIRMA_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            FIRMA_ADI = dto.FIRMA_ADI,
            TELEFON_NUMARASI = dto.TELEFON_NUMARASI,
            YETKILI_KISI = dto.YETKILI_KISI,
            FIRMA_ADRESI = dto.FIRMA_ADRESI,
            AKTIFLIK_BILGISI = dto.AKTIFLIK_BILGISI,
            VERGI_DAIRESI = dto.VERGI_DAIRESI,
            VERGI_NUMARASI = dto.VERGI_NUMARASI,
            EPOSTA_ADRESI = dto.EPOSTA_ADRESI,
            IBAN_NUMARASI = dto.IBAN_NUMARASI,
        };

        _db.Set<FIRMA>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.FIRMA_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Firma)]
    public async Task<IActionResult> Update(string id, FirmaDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<FIRMA>()
            .FirstOrDefaultAsync(e => e.FIRMA_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.FIRMA_ADI = dto.FIRMA_ADI;
        entity.TELEFON_NUMARASI = dto.TELEFON_NUMARASI;
        entity.YETKILI_KISI = dto.YETKILI_KISI;
        entity.FIRMA_ADRESI = dto.FIRMA_ADRESI;
        entity.AKTIFLIK_BILGISI = dto.AKTIFLIK_BILGISI;
        entity.VERGI_DAIRESI = dto.VERGI_DAIRESI;
        entity.VERGI_NUMARASI = dto.VERGI_NUMARASI;
        entity.EPOSTA_ADRESI = dto.EPOSTA_ADRESI;
        entity.IBAN_NUMARASI = dto.IBAN_NUMARASI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Firma)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<FIRMA>()
            .FirstOrDefaultAsync(e => e.FIRMA_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<FIRMA>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
