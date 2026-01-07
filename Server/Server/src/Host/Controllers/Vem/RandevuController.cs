using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Randevu;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class RandevuController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public RandevuController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Randevu)]
    public async Task<List<RandevuDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<RANDEVU>()
            .AsNoTracking()
            .Select(e => new RandevuDto
            {
                RANDEVU_KODU = e.RANDEVU_KODU,
                HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                RANDEVU_TURU = e.RANDEVU_TURU,
                RANDEVU_ALT_TURU = e.RANDEVU_ALT_TURU,
                RANDEVU_ZAMANI = e.RANDEVU_ZAMANI,
                RANDEVU_KAYIT_ZAMANI = e.RANDEVU_KAYIT_ZAMANI,
                HASTA_HIZMET_KODU = e.HASTA_HIZMET_KODU,
                BIRIM_KODU = e.BIRIM_KODU,
                HEKIM_KODU = e.HEKIM_KODU,
                MHRS_HRN_KODU = e.MHRS_HRN_KODU,
                MHRS_RANDEVU_NOTU = e.MHRS_RANDEVU_NOTU,
                RANDEVU_GELME_DURUMU = e.RANDEVU_GELME_DURUMU,
                CIHAZ_KODU = e.CIHAZ_KODU,
                TC_KIMLIK_NUMARASI = e.TC_KIMLIK_NUMARASI,
                AD = e.AD,
                SOYADI = e.SOYADI,
                CINSIYET = e.CINSIYET,
                TELEFON_NUMARASI = e.TELEFON_NUMARASI,
                IPTAL_DURUMU = e.IPTAL_DURUMU,
                IPTAL_EDEN_KULLANICI_KODU = e.IPTAL_EDEN_KULLANICI_KODU,
                IPTAL_ZAMANI = e.IPTAL_ZAMANI,
                IPTAL_ACIKLAMA = e.IPTAL_ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Randevu)]
    public async Task<ActionResult<RandevuDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<RANDEVU>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.RANDEVU_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new RandevuDto
        {
            RANDEVU_KODU = entity.RANDEVU_KODU,
            HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            RANDEVU_TURU = entity.RANDEVU_TURU,
            RANDEVU_ALT_TURU = entity.RANDEVU_ALT_TURU,
            RANDEVU_ZAMANI = entity.RANDEVU_ZAMANI,
            RANDEVU_KAYIT_ZAMANI = entity.RANDEVU_KAYIT_ZAMANI,
            HASTA_HIZMET_KODU = entity.HASTA_HIZMET_KODU,
            BIRIM_KODU = entity.BIRIM_KODU,
            HEKIM_KODU = entity.HEKIM_KODU,
            MHRS_HRN_KODU = entity.MHRS_HRN_KODU,
            MHRS_RANDEVU_NOTU = entity.MHRS_RANDEVU_NOTU,
            RANDEVU_GELME_DURUMU = entity.RANDEVU_GELME_DURUMU,
            CIHAZ_KODU = entity.CIHAZ_KODU,
            TC_KIMLIK_NUMARASI = entity.TC_KIMLIK_NUMARASI,
            AD = entity.AD,
            SOYADI = entity.SOYADI,
            CINSIYET = entity.CINSIYET,
            TELEFON_NUMARASI = entity.TELEFON_NUMARASI,
            IPTAL_DURUMU = entity.IPTAL_DURUMU,
            IPTAL_EDEN_KULLANICI_KODU = entity.IPTAL_EDEN_KULLANICI_KODU,
            IPTAL_ZAMANI = entity.IPTAL_ZAMANI,
            IPTAL_ACIKLAMA = entity.IPTAL_ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Randevu)]
    public async Task<ActionResult<string>> Create(RandevuDto dto, CancellationToken ct)
    {
        var entity = new RANDEVU
        {
            RANDEVU_KODU = dto.RANDEVU_KODU,
            HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            RANDEVU_TURU = dto.RANDEVU_TURU,
            RANDEVU_ALT_TURU = dto.RANDEVU_ALT_TURU,
            RANDEVU_ZAMANI = dto.RANDEVU_ZAMANI,
            RANDEVU_KAYIT_ZAMANI = dto.RANDEVU_KAYIT_ZAMANI,
            HASTA_HIZMET_KODU = dto.HASTA_HIZMET_KODU,
            BIRIM_KODU = dto.BIRIM_KODU,
            HEKIM_KODU = dto.HEKIM_KODU,
            MHRS_HRN_KODU = dto.MHRS_HRN_KODU,
            MHRS_RANDEVU_NOTU = dto.MHRS_RANDEVU_NOTU,
            RANDEVU_GELME_DURUMU = dto.RANDEVU_GELME_DURUMU,
            CIHAZ_KODU = dto.CIHAZ_KODU,
            TC_KIMLIK_NUMARASI = dto.TC_KIMLIK_NUMARASI,
            AD = dto.AD,
            SOYADI = dto.SOYADI,
            CINSIYET = dto.CINSIYET,
            TELEFON_NUMARASI = dto.TELEFON_NUMARASI,
            IPTAL_DURUMU = dto.IPTAL_DURUMU,
            IPTAL_EDEN_KULLANICI_KODU = dto.IPTAL_EDEN_KULLANICI_KODU,
            IPTAL_ZAMANI = dto.IPTAL_ZAMANI,
            IPTAL_ACIKLAMA = dto.IPTAL_ACIKLAMA,
        };

        _db.Set<RANDEVU>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.RANDEVU_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Randevu)]
    public async Task<IActionResult> Update(string id, RandevuDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<RANDEVU>()
            .FirstOrDefaultAsync(e => e.RANDEVU_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.RANDEVU_TURU = dto.RANDEVU_TURU;
        entity.RANDEVU_ALT_TURU = dto.RANDEVU_ALT_TURU;
        entity.RANDEVU_ZAMANI = dto.RANDEVU_ZAMANI;
        entity.RANDEVU_KAYIT_ZAMANI = dto.RANDEVU_KAYIT_ZAMANI;
        entity.HASTA_HIZMET_KODU = dto.HASTA_HIZMET_KODU;
        entity.BIRIM_KODU = dto.BIRIM_KODU;
        entity.HEKIM_KODU = dto.HEKIM_KODU;
        entity.MHRS_HRN_KODU = dto.MHRS_HRN_KODU;
        entity.MHRS_RANDEVU_NOTU = dto.MHRS_RANDEVU_NOTU;
        entity.RANDEVU_GELME_DURUMU = dto.RANDEVU_GELME_DURUMU;
        entity.CIHAZ_KODU = dto.CIHAZ_KODU;
        entity.TC_KIMLIK_NUMARASI = dto.TC_KIMLIK_NUMARASI;
        entity.AD = dto.AD;
        entity.SOYADI = dto.SOYADI;
        entity.CINSIYET = dto.CINSIYET;
        entity.TELEFON_NUMARASI = dto.TELEFON_NUMARASI;
        entity.IPTAL_DURUMU = dto.IPTAL_DURUMU;
        entity.IPTAL_EDEN_KULLANICI_KODU = dto.IPTAL_EDEN_KULLANICI_KODU;
        entity.IPTAL_ZAMANI = dto.IPTAL_ZAMANI;
        entity.IPTAL_ACIKLAMA = dto.IPTAL_ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Randevu)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<RANDEVU>()
            .FirstOrDefaultAsync(e => e.RANDEVU_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<RANDEVU>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
