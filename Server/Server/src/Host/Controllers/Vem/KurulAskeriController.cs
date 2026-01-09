using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.KurulAskeri;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class KurulAskeriController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public KurulAskeriController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.KurulAskeri)]
    public async Task<List<KurulAskeriDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<KURUL_ASKERI>()
            .AsNoTracking()
            .Select(e => new KurulAskeriDto
            {
                KURUL_ASKERI_KODU = e.KURUL_ASKERI_KODU,
KURUL_ADI = e.KURUL_ADI,
                MEDULA_RAPOR_TURU = e.MEDULA_RAPOR_TURU,
                MEDULA_ALT_RAPOR_TURU = e.MEDULA_ALT_RAPOR_TURU,
                ALKOL_MADDE_BAGIMLILIGI = e.ALKOL_MADDE_BAGIMLILIGI,
                BEDEN_RUH_ILERI_TETKIK_BULGUSU = e.BEDEN_RUH_ILERI_TETKIK_BULGUSU,
                GECMIS_HASTALIGA_DAIR_KAYIT = e.GECMIS_HASTALIGA_DAIR_KAYIT,
                GORME_ISITME_KAYBI = e.GORME_ISITME_KAYBI,
                PSIKIYATRIK_RAHATSIZLIK = e.PSIKIYATRIK_RAHATSIZLIK,
                UZUVKAYBI_ORTOPEDI_RAHATSIZLIK = e.UZUVKAYBI_ORTOPEDI_RAHATSIZLIK,
                ASAL_HASTALIK = e.ASAL_HASTALIK,
                ASAL_HASTALIK_TIPI = e.ASAL_HASTALIK_TIPI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.KurulAskeri)]
    public async Task<ActionResult<KurulAskeriDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KURUL_ASKERI>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.KURUL_ASKERI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new KurulAskeriDto
        {
            KURUL_ASKERI_KODU = entity.KURUL_ASKERI_KODU,
KURUL_ADI = entity.KURUL_ADI,
            MEDULA_RAPOR_TURU = entity.MEDULA_RAPOR_TURU,
            MEDULA_ALT_RAPOR_TURU = entity.MEDULA_ALT_RAPOR_TURU,
            ALKOL_MADDE_BAGIMLILIGI = entity.ALKOL_MADDE_BAGIMLILIGI,
            BEDEN_RUH_ILERI_TETKIK_BULGUSU = entity.BEDEN_RUH_ILERI_TETKIK_BULGUSU,
            GECMIS_HASTALIGA_DAIR_KAYIT = entity.GECMIS_HASTALIGA_DAIR_KAYIT,
            GORME_ISITME_KAYBI = entity.GORME_ISITME_KAYBI,
            PSIKIYATRIK_RAHATSIZLIK = entity.PSIKIYATRIK_RAHATSIZLIK,
            UZUVKAYBI_ORTOPEDI_RAHATSIZLIK = entity.UZUVKAYBI_ORTOPEDI_RAHATSIZLIK,
            ASAL_HASTALIK = entity.ASAL_HASTALIK,
            ASAL_HASTALIK_TIPI = entity.ASAL_HASTALIK_TIPI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.KurulAskeri)]
    public async Task<ActionResult<string>> Create(KurulAskeriDto dto, CancellationToken ct)
    {
        var entity = new KURUL_ASKERI
        {
            KURUL_ASKERI_KODU = dto.KURUL_ASKERI_KODU,
KURUL_ADI = dto.KURUL_ADI,
            MEDULA_RAPOR_TURU = dto.MEDULA_RAPOR_TURU,
            MEDULA_ALT_RAPOR_TURU = dto.MEDULA_ALT_RAPOR_TURU,
            ALKOL_MADDE_BAGIMLILIGI = dto.ALKOL_MADDE_BAGIMLILIGI,
            BEDEN_RUH_ILERI_TETKIK_BULGUSU = dto.BEDEN_RUH_ILERI_TETKIK_BULGUSU,
            GECMIS_HASTALIGA_DAIR_KAYIT = dto.GECMIS_HASTALIGA_DAIR_KAYIT,
            GORME_ISITME_KAYBI = dto.GORME_ISITME_KAYBI,
            PSIKIYATRIK_RAHATSIZLIK = dto.PSIKIYATRIK_RAHATSIZLIK,
            UZUVKAYBI_ORTOPEDI_RAHATSIZLIK = dto.UZUVKAYBI_ORTOPEDI_RAHATSIZLIK,
            ASAL_HASTALIK = dto.ASAL_HASTALIK,
            ASAL_HASTALIK_TIPI = dto.ASAL_HASTALIK_TIPI,
        };

        _db.Set<KURUL_ASKERI>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.KURUL_ASKERI_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.KurulAskeri)]
    public async Task<IActionResult> Update(string id, KurulAskeriDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<KURUL_ASKERI>()
            .FirstOrDefaultAsync(e => e.KURUL_ASKERI_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.KURUL_ADI = dto.KURUL_ADI;
        entity.MEDULA_RAPOR_TURU = dto.MEDULA_RAPOR_TURU;
        entity.MEDULA_ALT_RAPOR_TURU = dto.MEDULA_ALT_RAPOR_TURU;
        entity.ALKOL_MADDE_BAGIMLILIGI = dto.ALKOL_MADDE_BAGIMLILIGI;
        entity.BEDEN_RUH_ILERI_TETKIK_BULGUSU = dto.BEDEN_RUH_ILERI_TETKIK_BULGUSU;
        entity.GECMIS_HASTALIGA_DAIR_KAYIT = dto.GECMIS_HASTALIGA_DAIR_KAYIT;
        entity.GORME_ISITME_KAYBI = dto.GORME_ISITME_KAYBI;
        entity.PSIKIYATRIK_RAHATSIZLIK = dto.PSIKIYATRIK_RAHATSIZLIK;
        entity.UZUVKAYBI_ORTOPEDI_RAHATSIZLIK = dto.UZUVKAYBI_ORTOPEDI_RAHATSIZLIK;
        entity.ASAL_HASTALIK = dto.ASAL_HASTALIK;
        entity.ASAL_HASTALIK_TIPI = dto.ASAL_HASTALIK_TIPI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.KurulAskeri)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KURUL_ASKERI>()
            .FirstOrDefaultAsync(e => e.KURUL_ASKERI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<KURUL_ASKERI>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
