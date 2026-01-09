using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.SysPaket;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class SysPaketController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public SysPaketController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.SysPaket)]
    public async Task<List<SysPaketDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<SYS_PAKET>()
            .AsNoTracking()
            .Select(e => new SysPaketDto
            {
                SYS_PAKET_KODU = e.SYS_PAKET_KODU,
HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                HASTA_KODU = e.HASTA_KODU,
                VERI_PAKETI_NUMARASI = e.VERI_PAKETI_NUMARASI,
                VERI_PAKETI_GONDERILME_ZAMANI = e.VERI_PAKETI_GONDERILME_ZAMANI,
                VERI_PAKETI_GONDERIM_DURUMU = e.VERI_PAKETI_GONDERIM_DURUMU,
                GONDERILEN_PAKET_BILGISI = e.GONDERILEN_PAKET_BILGISI,
                GELEN_CEVAP_BILGISI = e.GELEN_CEVAP_BILGISI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.SysPaket)]
    public async Task<ActionResult<SysPaketDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<SYS_PAKET>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.SYS_PAKET_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new SysPaketDto
        {
            SYS_PAKET_KODU = entity.SYS_PAKET_KODU,
HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            HASTA_KODU = entity.HASTA_KODU,
            VERI_PAKETI_NUMARASI = entity.VERI_PAKETI_NUMARASI,
            VERI_PAKETI_GONDERILME_ZAMANI = entity.VERI_PAKETI_GONDERILME_ZAMANI,
            VERI_PAKETI_GONDERIM_DURUMU = entity.VERI_PAKETI_GONDERIM_DURUMU,
            GONDERILEN_PAKET_BILGISI = entity.GONDERILEN_PAKET_BILGISI,
            GELEN_CEVAP_BILGISI = entity.GELEN_CEVAP_BILGISI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.SysPaket)]
    public async Task<ActionResult<string>> Create(SysPaketDto dto, CancellationToken ct)
    {
        var entity = new SYS_PAKET
        {
            SYS_PAKET_KODU = dto.SYS_PAKET_KODU,
HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            HASTA_KODU = dto.HASTA_KODU,
            VERI_PAKETI_NUMARASI = dto.VERI_PAKETI_NUMARASI,
            VERI_PAKETI_GONDERILME_ZAMANI = dto.VERI_PAKETI_GONDERILME_ZAMANI,
            VERI_PAKETI_GONDERIM_DURUMU = dto.VERI_PAKETI_GONDERIM_DURUMU,
            GONDERILEN_PAKET_BILGISI = dto.GONDERILEN_PAKET_BILGISI,
            GELEN_CEVAP_BILGISI = dto.GELEN_CEVAP_BILGISI,
        };

        _db.Set<SYS_PAKET>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.SYS_PAKET_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.SysPaket)]
    public async Task<IActionResult> Update(string id, SysPaketDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<SYS_PAKET>()
            .FirstOrDefaultAsync(e => e.SYS_PAKET_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.VERI_PAKETI_NUMARASI = dto.VERI_PAKETI_NUMARASI;
        entity.VERI_PAKETI_GONDERILME_ZAMANI = dto.VERI_PAKETI_GONDERILME_ZAMANI;
        entity.VERI_PAKETI_GONDERIM_DURUMU = dto.VERI_PAKETI_GONDERIM_DURUMU;
        entity.GONDERILEN_PAKET_BILGISI = dto.GONDERILEN_PAKET_BILGISI;
        entity.GELEN_CEVAP_BILGISI = dto.GELEN_CEVAP_BILGISI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.SysPaket)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<SYS_PAKET>()
            .FirstOrDefaultAsync(e => e.SYS_PAKET_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<SYS_PAKET>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
