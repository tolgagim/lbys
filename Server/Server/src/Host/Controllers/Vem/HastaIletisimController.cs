using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.HastaIletisim;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class HastaIletisimController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public HastaIletisimController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.HastaIletisim)]
    public async Task<List<HastaIletisimDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<HASTA_ILETISIM>()
            .AsNoTracking()
            .Select(e => new HastaIletisimDto
            {
                HASTA_ILETISIM_KODU = e.HASTA_ILETISIM_KODU,
HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                ADRES_TIPI = e.ADRES_TIPI,
                ADRES_KODU_SEVIYESI = e.ADRES_KODU_SEVIYESI,
                BEYAN_ADRESI = e.BEYAN_ADRESI,
                NVI_ADRES = e.NVI_ADRES,
                ADRES_NUMARASI = e.ADRES_NUMARASI,
                IL_KODU = e.IL_KODU,
                ILCE_KODU = e.ILCE_KODU,
                BUCAK_KODU = e.BUCAK_KODU,
                KOY_KODU = e.KOY_KODU,
                MAHALLE_KODU = e.MAHALLE_KODU,
                CSBM_KODU = e.CSBM_KODU,
                DIS_KAPI_NUMARASI = e.DIS_KAPI_NUMARASI,
                IC_KAPI_NUMARASI = e.IC_KAPI_NUMARASI,
                EV_TELEFONU = e.EV_TELEFONU,
                CEP_TELEFONU = e.CEP_TELEFONU,
                IS_TELEFONU = e.IS_TELEFONU,
                EPOSTA_ADRESI = e.EPOSTA_ADRESI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.HastaIletisim)]
    public async Task<ActionResult<HastaIletisimDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_ILETISIM>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.HASTA_ILETISIM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new HastaIletisimDto
        {
            HASTA_ILETISIM_KODU = entity.HASTA_ILETISIM_KODU,
HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            ADRES_TIPI = entity.ADRES_TIPI,
            ADRES_KODU_SEVIYESI = entity.ADRES_KODU_SEVIYESI,
            BEYAN_ADRESI = entity.BEYAN_ADRESI,
            NVI_ADRES = entity.NVI_ADRES,
            ADRES_NUMARASI = entity.ADRES_NUMARASI,
            IL_KODU = entity.IL_KODU,
            ILCE_KODU = entity.ILCE_KODU,
            BUCAK_KODU = entity.BUCAK_KODU,
            KOY_KODU = entity.KOY_KODU,
            MAHALLE_KODU = entity.MAHALLE_KODU,
            CSBM_KODU = entity.CSBM_KODU,
            DIS_KAPI_NUMARASI = entity.DIS_KAPI_NUMARASI,
            IC_KAPI_NUMARASI = entity.IC_KAPI_NUMARASI,
            EV_TELEFONU = entity.EV_TELEFONU,
            CEP_TELEFONU = entity.CEP_TELEFONU,
            IS_TELEFONU = entity.IS_TELEFONU,
            EPOSTA_ADRESI = entity.EPOSTA_ADRESI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.HastaIletisim)]
    public async Task<ActionResult<string>> Create(HastaIletisimDto dto, CancellationToken ct)
    {
        var entity = new HASTA_ILETISIM
        {
            HASTA_ILETISIM_KODU = dto.HASTA_ILETISIM_KODU,
HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            ADRES_TIPI = dto.ADRES_TIPI,
            ADRES_KODU_SEVIYESI = dto.ADRES_KODU_SEVIYESI,
            BEYAN_ADRESI = dto.BEYAN_ADRESI,
            NVI_ADRES = dto.NVI_ADRES,
            ADRES_NUMARASI = dto.ADRES_NUMARASI,
            IL_KODU = dto.IL_KODU,
            ILCE_KODU = dto.ILCE_KODU,
            BUCAK_KODU = dto.BUCAK_KODU,
            KOY_KODU = dto.KOY_KODU,
            MAHALLE_KODU = dto.MAHALLE_KODU,
            CSBM_KODU = dto.CSBM_KODU,
            DIS_KAPI_NUMARASI = dto.DIS_KAPI_NUMARASI,
            IC_KAPI_NUMARASI = dto.IC_KAPI_NUMARASI,
            EV_TELEFONU = dto.EV_TELEFONU,
            CEP_TELEFONU = dto.CEP_TELEFONU,
            IS_TELEFONU = dto.IS_TELEFONU,
            EPOSTA_ADRESI = dto.EPOSTA_ADRESI,
        };

        _db.Set<HASTA_ILETISIM>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.HASTA_ILETISIM_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.HastaIletisim)]
    public async Task<IActionResult> Update(string id, HastaIletisimDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_ILETISIM>()
            .FirstOrDefaultAsync(e => e.HASTA_ILETISIM_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.ADRES_TIPI = dto.ADRES_TIPI;
        entity.ADRES_KODU_SEVIYESI = dto.ADRES_KODU_SEVIYESI;
        entity.BEYAN_ADRESI = dto.BEYAN_ADRESI;
        entity.NVI_ADRES = dto.NVI_ADRES;
        entity.ADRES_NUMARASI = dto.ADRES_NUMARASI;
        entity.IL_KODU = dto.IL_KODU;
        entity.ILCE_KODU = dto.ILCE_KODU;
        entity.BUCAK_KODU = dto.BUCAK_KODU;
        entity.KOY_KODU = dto.KOY_KODU;
        entity.MAHALLE_KODU = dto.MAHALLE_KODU;
        entity.CSBM_KODU = dto.CSBM_KODU;
        entity.DIS_KAPI_NUMARASI = dto.DIS_KAPI_NUMARASI;
        entity.IC_KAPI_NUMARASI = dto.IC_KAPI_NUMARASI;
        entity.EV_TELEFONU = dto.EV_TELEFONU;
        entity.CEP_TELEFONU = dto.CEP_TELEFONU;
        entity.IS_TELEFONU = dto.IS_TELEFONU;
        entity.EPOSTA_ADRESI = dto.EPOSTA_ADRESI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.HastaIletisim)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_ILETISIM>()
            .FirstOrDefaultAsync(e => e.HASTA_ILETISIM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<HASTA_ILETISIM>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
