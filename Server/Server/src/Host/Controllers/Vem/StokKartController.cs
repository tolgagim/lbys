using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.StokKart;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class StokKartController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public StokKartController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.StokKart)]
    public async Task<List<StokKartDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<STOK_KART>()
            .AsNoTracking()
            .Select(e => new StokKartDto
            {
                STOK_KART_KODU = e.STOK_KART_KODU,
                MALZEME_ADI = e.MALZEME_ADI,
                MKYS_MALZEME_KODU = e.MKYS_MALZEME_KODU,
                TASINIR_KODU = e.TASINIR_KODU,
                MALZEME_TIPI = e.MALZEME_TIPI,
                BARKOD = e.BARKOD,
                MALZEME_SUT_KODU = e.MALZEME_SUT_KODU,
                RECETE_TURU = e.RECETE_TURU,
                MEDULA_CARPANI = e.MEDULA_CARPANI,
                EHU_ILAC_GUN_MIKTARI = e.EHU_ILAC_GUN_MIKTARI,
                EHU_ILAC_MAKSIMUM_ADET = e.EHU_ILAC_MAKSIMUM_ADET,
                EHU_ONAY_DURUMU = e.EHU_ONAY_DURUMU,
                AKTIF = e.AKTIF,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.StokKart)]
    public async Task<ActionResult<StokKartDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STOK_KART>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.STOK_KART_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new StokKartDto
        {
            STOK_KART_KODU = entity.STOK_KART_KODU,
            MALZEME_ADI = entity.MALZEME_ADI,
            MKYS_MALZEME_KODU = entity.MKYS_MALZEME_KODU,
            TASINIR_KODU = entity.TASINIR_KODU,
            MALZEME_TIPI = entity.MALZEME_TIPI,
            BARKOD = entity.BARKOD,
            MALZEME_SUT_KODU = entity.MALZEME_SUT_KODU,
            RECETE_TURU = entity.RECETE_TURU,
            MEDULA_CARPANI = entity.MEDULA_CARPANI,
            EHU_ILAC_GUN_MIKTARI = entity.EHU_ILAC_GUN_MIKTARI,
            EHU_ILAC_MAKSIMUM_ADET = entity.EHU_ILAC_MAKSIMUM_ADET,
            EHU_ONAY_DURUMU = entity.EHU_ONAY_DURUMU,
            AKTIF = entity.AKTIF,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.StokKart)]
    public async Task<ActionResult<string>> Create(StokKartDto dto, CancellationToken ct)
    {
        var entity = new STOK_KART
        {
            STOK_KART_KODU = dto.STOK_KART_KODU,
            MALZEME_ADI = dto.MALZEME_ADI,
            MKYS_MALZEME_KODU = dto.MKYS_MALZEME_KODU,
            TASINIR_KODU = dto.TASINIR_KODU,
            MALZEME_TIPI = dto.MALZEME_TIPI,
            BARKOD = dto.BARKOD,
            MALZEME_SUT_KODU = dto.MALZEME_SUT_KODU,
            RECETE_TURU = dto.RECETE_TURU,
            MEDULA_CARPANI = dto.MEDULA_CARPANI,
            EHU_ILAC_GUN_MIKTARI = dto.EHU_ILAC_GUN_MIKTARI,
            EHU_ILAC_MAKSIMUM_ADET = dto.EHU_ILAC_MAKSIMUM_ADET,
            EHU_ONAY_DURUMU = dto.EHU_ONAY_DURUMU,
            AKTIF = dto.AKTIF,
        };

        _db.Set<STOK_KART>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.STOK_KART_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.StokKart)]
    public async Task<IActionResult> Update(string id, StokKartDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<STOK_KART>()
            .FirstOrDefaultAsync(e => e.STOK_KART_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.MALZEME_ADI = dto.MALZEME_ADI;
        entity.MKYS_MALZEME_KODU = dto.MKYS_MALZEME_KODU;
        entity.TASINIR_KODU = dto.TASINIR_KODU;
        entity.MALZEME_TIPI = dto.MALZEME_TIPI;
        entity.BARKOD = dto.BARKOD;
        entity.MALZEME_SUT_KODU = dto.MALZEME_SUT_KODU;
        entity.RECETE_TURU = dto.RECETE_TURU;
        entity.MEDULA_CARPANI = dto.MEDULA_CARPANI;
        entity.EHU_ILAC_GUN_MIKTARI = dto.EHU_ILAC_GUN_MIKTARI;
        entity.EHU_ILAC_MAKSIMUM_ADET = dto.EHU_ILAC_MAKSIMUM_ADET;
        entity.EHU_ONAY_DURUMU = dto.EHU_ONAY_DURUMU;
        entity.AKTIF = dto.AKTIF;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.StokKart)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STOK_KART>()
            .FirstOrDefaultAsync(e => e.STOK_KART_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<STOK_KART>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
