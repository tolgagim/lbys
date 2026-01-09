using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.KurulEtkenMadde;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class KurulEtkenMaddeController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public KurulEtkenMaddeController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.KurulEtkenMadde)]
    public async Task<List<KurulEtkenMaddeDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<KURUL_ETKEN_MADDE>()
            .AsNoTracking()
            .Select(e => new KurulEtkenMaddeDto
            {
                KURUL_ETKEN_MADDE_KODU = e.KURUL_ETKEN_MADDE_KODU,
KURUL_RAPOR_KODU = e.KURUL_RAPOR_KODU,
                ILAC_ETKEN_MADDE_KODU = e.ILAC_ETKEN_MADDE_KODU,
                DOZ_SAYISI = e.DOZ_SAYISI,
                DOZ_MIKTARI = e.DOZ_MIKTARI,
                DOZ_BIRIM = e.DOZ_BIRIM,
                ILAC_KULLANIM_PERIYODU = e.ILAC_KULLANIM_PERIYODU,
                ILAC_PERIYOT_BIRIMI = e.ILAC_PERIYOT_BIRIMI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.KurulEtkenMadde)]
    public async Task<ActionResult<KurulEtkenMaddeDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KURUL_ETKEN_MADDE>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.KURUL_ETKEN_MADDE_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new KurulEtkenMaddeDto
        {
            KURUL_ETKEN_MADDE_KODU = entity.KURUL_ETKEN_MADDE_KODU,
KURUL_RAPOR_KODU = entity.KURUL_RAPOR_KODU,
            ILAC_ETKEN_MADDE_KODU = entity.ILAC_ETKEN_MADDE_KODU,
            DOZ_SAYISI = entity.DOZ_SAYISI,
            DOZ_MIKTARI = entity.DOZ_MIKTARI,
            DOZ_BIRIM = entity.DOZ_BIRIM,
            ILAC_KULLANIM_PERIYODU = entity.ILAC_KULLANIM_PERIYODU,
            ILAC_PERIYOT_BIRIMI = entity.ILAC_PERIYOT_BIRIMI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.KurulEtkenMadde)]
    public async Task<ActionResult<string>> Create(KurulEtkenMaddeDto dto, CancellationToken ct)
    {
        var entity = new KURUL_ETKEN_MADDE
        {
            KURUL_ETKEN_MADDE_KODU = dto.KURUL_ETKEN_MADDE_KODU,
KURUL_RAPOR_KODU = dto.KURUL_RAPOR_KODU,
            ILAC_ETKEN_MADDE_KODU = dto.ILAC_ETKEN_MADDE_KODU,
            DOZ_SAYISI = dto.DOZ_SAYISI,
            DOZ_MIKTARI = dto.DOZ_MIKTARI,
            DOZ_BIRIM = dto.DOZ_BIRIM,
            ILAC_KULLANIM_PERIYODU = dto.ILAC_KULLANIM_PERIYODU,
            ILAC_PERIYOT_BIRIMI = dto.ILAC_PERIYOT_BIRIMI,
        };

        _db.Set<KURUL_ETKEN_MADDE>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.KURUL_ETKEN_MADDE_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.KurulEtkenMadde)]
    public async Task<IActionResult> Update(string id, KurulEtkenMaddeDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<KURUL_ETKEN_MADDE>()
            .FirstOrDefaultAsync(e => e.KURUL_ETKEN_MADDE_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.KURUL_RAPOR_KODU = dto.KURUL_RAPOR_KODU;
        entity.ILAC_ETKEN_MADDE_KODU = dto.ILAC_ETKEN_MADDE_KODU;
        entity.DOZ_SAYISI = dto.DOZ_SAYISI;
        entity.DOZ_MIKTARI = dto.DOZ_MIKTARI;
        entity.DOZ_BIRIM = dto.DOZ_BIRIM;
        entity.ILAC_KULLANIM_PERIYODU = dto.ILAC_KULLANIM_PERIYODU;
        entity.ILAC_PERIYOT_BIRIMI = dto.ILAC_PERIYOT_BIRIMI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.KurulEtkenMadde)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KURUL_ETKEN_MADDE>()
            .FirstOrDefaultAsync(e => e.KURUL_ETKEN_MADDE_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<KURUL_ETKEN_MADDE>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
