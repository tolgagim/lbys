using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.ReceteIlac;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class ReceteIlacController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public ReceteIlacController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.ReceteIlac)]
    public async Task<List<ReceteIlacDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<RECETE_ILAC>()
            .AsNoTracking()
            .Select(e => new ReceteIlacDto
            {
                RECETE_ILAC_KODU = e.RECETE_ILAC_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                RECETE_KODU = e.RECETE_KODU,
                DOZ_BIRIM = e.DOZ_BIRIM,
                BARKOD = e.BARKOD,
                ILAC_ADI = e.ILAC_ADI,
                KUTU_ADETI = e.KUTU_ADETI,
                ILAC_KULLANIM_SEKLI = e.ILAC_KULLANIM_SEKLI,
                ILAC_KULLANIM_SAYISI = e.ILAC_KULLANIM_SAYISI,
                ILAC_KULLANIM_DOZU = e.ILAC_KULLANIM_DOZU,
                ILAC_KULLANIM_PERIYODU = e.ILAC_KULLANIM_PERIYODU,
                ILAC_KULLANIM_PERIYODU_BIRIMI = e.ILAC_KULLANIM_PERIYODU_BIRIMI,
                ILAC_ACIKLAMA = e.ILAC_ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.ReceteIlac)]
    public async Task<ActionResult<ReceteIlacDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<RECETE_ILAC>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.RECETE_ILAC_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new ReceteIlacDto
        {
            RECETE_ILAC_KODU = entity.RECETE_ILAC_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            RECETE_KODU = entity.RECETE_KODU,
            DOZ_BIRIM = entity.DOZ_BIRIM,
            BARKOD = entity.BARKOD,
            ILAC_ADI = entity.ILAC_ADI,
            KUTU_ADETI = entity.KUTU_ADETI,
            ILAC_KULLANIM_SEKLI = entity.ILAC_KULLANIM_SEKLI,
            ILAC_KULLANIM_SAYISI = entity.ILAC_KULLANIM_SAYISI,
            ILAC_KULLANIM_DOZU = entity.ILAC_KULLANIM_DOZU,
            ILAC_KULLANIM_PERIYODU = entity.ILAC_KULLANIM_PERIYODU,
            ILAC_KULLANIM_PERIYODU_BIRIMI = entity.ILAC_KULLANIM_PERIYODU_BIRIMI,
            ILAC_ACIKLAMA = entity.ILAC_ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.ReceteIlac)]
    public async Task<ActionResult<string>> Create(ReceteIlacDto dto, CancellationToken ct)
    {
        var entity = new RECETE_ILAC
        {
            RECETE_ILAC_KODU = dto.RECETE_ILAC_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            RECETE_KODU = dto.RECETE_KODU,
            DOZ_BIRIM = dto.DOZ_BIRIM,
            BARKOD = dto.BARKOD,
            ILAC_ADI = dto.ILAC_ADI,
            KUTU_ADETI = dto.KUTU_ADETI,
            ILAC_KULLANIM_SEKLI = dto.ILAC_KULLANIM_SEKLI,
            ILAC_KULLANIM_SAYISI = dto.ILAC_KULLANIM_SAYISI,
            ILAC_KULLANIM_DOZU = dto.ILAC_KULLANIM_DOZU,
            ILAC_KULLANIM_PERIYODU = dto.ILAC_KULLANIM_PERIYODU,
            ILAC_KULLANIM_PERIYODU_BIRIMI = dto.ILAC_KULLANIM_PERIYODU_BIRIMI,
            ILAC_ACIKLAMA = dto.ILAC_ACIKLAMA,
        };

        _db.Set<RECETE_ILAC>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.RECETE_ILAC_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.ReceteIlac)]
    public async Task<IActionResult> Update(string id, ReceteIlacDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<RECETE_ILAC>()
            .FirstOrDefaultAsync(e => e.RECETE_ILAC_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.RECETE_KODU = dto.RECETE_KODU;
        entity.DOZ_BIRIM = dto.DOZ_BIRIM;
        entity.BARKOD = dto.BARKOD;
        entity.ILAC_ADI = dto.ILAC_ADI;
        entity.KUTU_ADETI = dto.KUTU_ADETI;
        entity.ILAC_KULLANIM_SEKLI = dto.ILAC_KULLANIM_SEKLI;
        entity.ILAC_KULLANIM_SAYISI = dto.ILAC_KULLANIM_SAYISI;
        entity.ILAC_KULLANIM_DOZU = dto.ILAC_KULLANIM_DOZU;
        entity.ILAC_KULLANIM_PERIYODU = dto.ILAC_KULLANIM_PERIYODU;
        entity.ILAC_KULLANIM_PERIYODU_BIRIMI = dto.ILAC_KULLANIM_PERIYODU_BIRIMI;
        entity.ILAC_ACIKLAMA = dto.ILAC_ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.ReceteIlac)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<RECETE_ILAC>()
            .FirstOrDefaultAsync(e => e.RECETE_ILAC_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<RECETE_ILAC>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
