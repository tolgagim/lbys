using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.DisprotezDetay;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class DisprotezDetayController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public DisprotezDetayController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.DisprotezDetay)]
    public async Task<List<DisprotezDetayDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<DISPROTEZ_DETAY>()
            .AsNoTracking()
            .Select(e => new DisprotezDetayDto
            {
                DISPROTEZ_DETAY_KODU = e.DISPROTEZ_DETAY_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                DISPROTEZ_KODU = e.DISPROTEZ_KODU,
                DISPROTEZ_PLANLAMA_ZAMANI = e.DISPROTEZ_PLANLAMA_ZAMANI,
                DISPROTEZ_IS_TURU_ASAMA_KODU = e.DISPROTEZ_IS_TURU_ASAMA_KODU,
                DISPROTEZ_ASAMA_BITIS_ZAMANI = e.DISPROTEZ_ASAMA_BITIS_ZAMANI,
                FIRMA_KODU = e.FIRMA_KODU,
                FIRMA_DISPROTEZ_ALIM_ZAMANI = e.FIRMA_DISPROTEZ_ALIM_ZAMANI,
                PLANLANAN_BITIS_TARIHI = e.PLANLANAN_BITIS_TARIHI,
                FIRMA_TESLIM_ZAMANI = e.FIRMA_TESLIM_ZAMANI,
                DISPROTEZ_ASAMA_ONAY_ZAMANI = e.DISPROTEZ_ASAMA_ONAY_ZAMANI,
                RPT_ONAY_DURUMU = e.RPT_ONAY_DURUMU,
                RANDEVU_KODU = e.RANDEVU_KODU,
                ASAMA_RPT_ZAMANI = e.ASAMA_RPT_ZAMANI,
                ASAMA_RPT_SEBEBI = e.ASAMA_RPT_SEBEBI,
                ASAMA_RPT_KULLANICI_KODU = e.ASAMA_RPT_KULLANICI_KODU,
                OLCU_DOKUM_ZAMANI = e.OLCU_DOKUM_ZAMANI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.DisprotezDetay)]
    public async Task<ActionResult<DisprotezDetayDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<DISPROTEZ_DETAY>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.DISPROTEZ_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new DisprotezDetayDto
        {
            DISPROTEZ_DETAY_KODU = entity.DISPROTEZ_DETAY_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            DISPROTEZ_KODU = entity.DISPROTEZ_KODU,
            DISPROTEZ_PLANLAMA_ZAMANI = entity.DISPROTEZ_PLANLAMA_ZAMANI,
            DISPROTEZ_IS_TURU_ASAMA_KODU = entity.DISPROTEZ_IS_TURU_ASAMA_KODU,
            DISPROTEZ_ASAMA_BITIS_ZAMANI = entity.DISPROTEZ_ASAMA_BITIS_ZAMANI,
            FIRMA_KODU = entity.FIRMA_KODU,
            FIRMA_DISPROTEZ_ALIM_ZAMANI = entity.FIRMA_DISPROTEZ_ALIM_ZAMANI,
            PLANLANAN_BITIS_TARIHI = entity.PLANLANAN_BITIS_TARIHI,
            FIRMA_TESLIM_ZAMANI = entity.FIRMA_TESLIM_ZAMANI,
            DISPROTEZ_ASAMA_ONAY_ZAMANI = entity.DISPROTEZ_ASAMA_ONAY_ZAMANI,
            RPT_ONAY_DURUMU = entity.RPT_ONAY_DURUMU,
            RANDEVU_KODU = entity.RANDEVU_KODU,
            ASAMA_RPT_ZAMANI = entity.ASAMA_RPT_ZAMANI,
            ASAMA_RPT_SEBEBI = entity.ASAMA_RPT_SEBEBI,
            ASAMA_RPT_KULLANICI_KODU = entity.ASAMA_RPT_KULLANICI_KODU,
            OLCU_DOKUM_ZAMANI = entity.OLCU_DOKUM_ZAMANI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.DisprotezDetay)]
    public async Task<ActionResult<string>> Create(DisprotezDetayDto dto, CancellationToken ct)
    {
        var entity = new DISPROTEZ_DETAY
        {
            DISPROTEZ_DETAY_KODU = dto.DISPROTEZ_DETAY_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            DISPROTEZ_KODU = dto.DISPROTEZ_KODU,
            DISPROTEZ_PLANLAMA_ZAMANI = dto.DISPROTEZ_PLANLAMA_ZAMANI,
            DISPROTEZ_IS_TURU_ASAMA_KODU = dto.DISPROTEZ_IS_TURU_ASAMA_KODU,
            DISPROTEZ_ASAMA_BITIS_ZAMANI = dto.DISPROTEZ_ASAMA_BITIS_ZAMANI,
            FIRMA_KODU = dto.FIRMA_KODU,
            FIRMA_DISPROTEZ_ALIM_ZAMANI = dto.FIRMA_DISPROTEZ_ALIM_ZAMANI,
            PLANLANAN_BITIS_TARIHI = dto.PLANLANAN_BITIS_TARIHI,
            FIRMA_TESLIM_ZAMANI = dto.FIRMA_TESLIM_ZAMANI,
            DISPROTEZ_ASAMA_ONAY_ZAMANI = dto.DISPROTEZ_ASAMA_ONAY_ZAMANI,
            RPT_ONAY_DURUMU = dto.RPT_ONAY_DURUMU,
            RANDEVU_KODU = dto.RANDEVU_KODU,
            ASAMA_RPT_ZAMANI = dto.ASAMA_RPT_ZAMANI,
            ASAMA_RPT_SEBEBI = dto.ASAMA_RPT_SEBEBI,
            ASAMA_RPT_KULLANICI_KODU = dto.ASAMA_RPT_KULLANICI_KODU,
            OLCU_DOKUM_ZAMANI = dto.OLCU_DOKUM_ZAMANI,
        };

        _db.Set<DISPROTEZ_DETAY>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.DISPROTEZ_DETAY_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.DisprotezDetay)]
    public async Task<IActionResult> Update(string id, DisprotezDetayDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<DISPROTEZ_DETAY>()
            .FirstOrDefaultAsync(e => e.DISPROTEZ_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.DISPROTEZ_KODU = dto.DISPROTEZ_KODU;
        entity.DISPROTEZ_PLANLAMA_ZAMANI = dto.DISPROTEZ_PLANLAMA_ZAMANI;
        entity.DISPROTEZ_IS_TURU_ASAMA_KODU = dto.DISPROTEZ_IS_TURU_ASAMA_KODU;
        entity.DISPROTEZ_ASAMA_BITIS_ZAMANI = dto.DISPROTEZ_ASAMA_BITIS_ZAMANI;
        entity.FIRMA_KODU = dto.FIRMA_KODU;
        entity.FIRMA_DISPROTEZ_ALIM_ZAMANI = dto.FIRMA_DISPROTEZ_ALIM_ZAMANI;
        entity.PLANLANAN_BITIS_TARIHI = dto.PLANLANAN_BITIS_TARIHI;
        entity.FIRMA_TESLIM_ZAMANI = dto.FIRMA_TESLIM_ZAMANI;
        entity.DISPROTEZ_ASAMA_ONAY_ZAMANI = dto.DISPROTEZ_ASAMA_ONAY_ZAMANI;
        entity.RPT_ONAY_DURUMU = dto.RPT_ONAY_DURUMU;
        entity.RANDEVU_KODU = dto.RANDEVU_KODU;
        entity.ASAMA_RPT_ZAMANI = dto.ASAMA_RPT_ZAMANI;
        entity.ASAMA_RPT_SEBEBI = dto.ASAMA_RPT_SEBEBI;
        entity.ASAMA_RPT_KULLANICI_KODU = dto.ASAMA_RPT_KULLANICI_KODU;
        entity.OLCU_DOKUM_ZAMANI = dto.OLCU_DOKUM_ZAMANI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.DisprotezDetay)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<DISPROTEZ_DETAY>()
            .FirstOrDefaultAsync(e => e.DISPROTEZ_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<DISPROTEZ_DETAY>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
