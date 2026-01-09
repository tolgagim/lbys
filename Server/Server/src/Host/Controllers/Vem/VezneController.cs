using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Vezne;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class VezneController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public VezneController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Vezne)]
    public async Task<List<VezneDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<VEZNE>()
            .AsNoTracking()
            .Select(e => new VezneDto
            {
                VEZNE_KODU = e.VEZNE_KODU,
HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                MAKBUZ_NUMARASI = e.MAKBUZ_NUMARASI,
                VEZNE_OZEL_NUMARASI = e.VEZNE_OZEL_NUMARASI,
                VEZNE_GIRIS_CIKIS_BILGISI = e.VEZNE_GIRIS_CIKIS_BILGISI,
                MAKBUZ_ZAMANI = e.MAKBUZ_ZAMANI,
                VEZNE_BIRIM_KODU = e.VEZNE_BIRIM_KODU,
                MAKBUZ_SERI_NUMARASI = e.MAKBUZ_SERI_NUMARASI,
                IPTAL_DURUMU = e.IPTAL_DURUMU,
                IPTAL_ZAMANI = e.IPTAL_ZAMANI,
                IPTAL_ACIKLAMA = e.IPTAL_ACIKLAMA,
                TAHSIL_TURU = e.TAHSIL_TURU,
                MAKBUZ_TUTARI = e.MAKBUZ_TUTARI,
                ACIKLAMA = e.ACIKLAMA,
                MAKBUZ_SAHIBI_ADRESI = e.MAKBUZ_SAHIBI_ADRESI,
                FIRMA_ADI = e.FIRMA_ADI,
                FIRMA_KODU = e.FIRMA_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Vezne)]
    public async Task<ActionResult<VezneDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<VEZNE>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.VEZNE_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new VezneDto
        {
            VEZNE_KODU = entity.VEZNE_KODU,
HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            MAKBUZ_NUMARASI = entity.MAKBUZ_NUMARASI,
            VEZNE_OZEL_NUMARASI = entity.VEZNE_OZEL_NUMARASI,
            VEZNE_GIRIS_CIKIS_BILGISI = entity.VEZNE_GIRIS_CIKIS_BILGISI,
            MAKBUZ_ZAMANI = entity.MAKBUZ_ZAMANI,
            VEZNE_BIRIM_KODU = entity.VEZNE_BIRIM_KODU,
            MAKBUZ_SERI_NUMARASI = entity.MAKBUZ_SERI_NUMARASI,
            IPTAL_DURUMU = entity.IPTAL_DURUMU,
            IPTAL_ZAMANI = entity.IPTAL_ZAMANI,
            IPTAL_ACIKLAMA = entity.IPTAL_ACIKLAMA,
            TAHSIL_TURU = entity.TAHSIL_TURU,
            MAKBUZ_TUTARI = entity.MAKBUZ_TUTARI,
            ACIKLAMA = entity.ACIKLAMA,
            MAKBUZ_SAHIBI_ADRESI = entity.MAKBUZ_SAHIBI_ADRESI,
            FIRMA_ADI = entity.FIRMA_ADI,
            FIRMA_KODU = entity.FIRMA_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Vezne)]
    public async Task<ActionResult<string>> Create(VezneDto dto, CancellationToken ct)
    {
        var entity = new VEZNE
        {
            VEZNE_KODU = dto.VEZNE_KODU,
HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            MAKBUZ_NUMARASI = dto.MAKBUZ_NUMARASI,
            VEZNE_OZEL_NUMARASI = dto.VEZNE_OZEL_NUMARASI,
            VEZNE_GIRIS_CIKIS_BILGISI = dto.VEZNE_GIRIS_CIKIS_BILGISI,
            MAKBUZ_ZAMANI = dto.MAKBUZ_ZAMANI,
            VEZNE_BIRIM_KODU = dto.VEZNE_BIRIM_KODU,
            MAKBUZ_SERI_NUMARASI = dto.MAKBUZ_SERI_NUMARASI,
            IPTAL_DURUMU = dto.IPTAL_DURUMU,
            IPTAL_ZAMANI = dto.IPTAL_ZAMANI,
            IPTAL_ACIKLAMA = dto.IPTAL_ACIKLAMA,
            TAHSIL_TURU = dto.TAHSIL_TURU,
            MAKBUZ_TUTARI = dto.MAKBUZ_TUTARI,
            ACIKLAMA = dto.ACIKLAMA,
            MAKBUZ_SAHIBI_ADRESI = dto.MAKBUZ_SAHIBI_ADRESI,
            FIRMA_ADI = dto.FIRMA_ADI,
            FIRMA_KODU = dto.FIRMA_KODU,
        };

        _db.Set<VEZNE>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.VEZNE_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Vezne)]
    public async Task<IActionResult> Update(string id, VezneDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<VEZNE>()
            .FirstOrDefaultAsync(e => e.VEZNE_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.MAKBUZ_NUMARASI = dto.MAKBUZ_NUMARASI;
        entity.VEZNE_OZEL_NUMARASI = dto.VEZNE_OZEL_NUMARASI;
        entity.VEZNE_GIRIS_CIKIS_BILGISI = dto.VEZNE_GIRIS_CIKIS_BILGISI;
        entity.MAKBUZ_ZAMANI = dto.MAKBUZ_ZAMANI;
        entity.VEZNE_BIRIM_KODU = dto.VEZNE_BIRIM_KODU;
        entity.MAKBUZ_SERI_NUMARASI = dto.MAKBUZ_SERI_NUMARASI;
        entity.IPTAL_DURUMU = dto.IPTAL_DURUMU;
        entity.IPTAL_ZAMANI = dto.IPTAL_ZAMANI;
        entity.IPTAL_ACIKLAMA = dto.IPTAL_ACIKLAMA;
        entity.TAHSIL_TURU = dto.TAHSIL_TURU;
        entity.MAKBUZ_TUTARI = dto.MAKBUZ_TUTARI;
        entity.ACIKLAMA = dto.ACIKLAMA;
        entity.MAKBUZ_SAHIBI_ADRESI = dto.MAKBUZ_SAHIBI_ADRESI;
        entity.FIRMA_ADI = dto.FIRMA_ADI;
        entity.FIRMA_KODU = dto.FIRMA_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Vezne)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<VEZNE>()
            .FirstOrDefaultAsync(e => e.VEZNE_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<VEZNE>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
