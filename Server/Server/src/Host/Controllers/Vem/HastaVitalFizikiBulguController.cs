using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.HastaVitalFizikiBulgu;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class HastaVitalFizikiBulguController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public HastaVitalFizikiBulguController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.HastaVitalFizikiBulgu)]
    public async Task<List<HastaVitalFizikiBulguDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<HASTA_VITAL_FIZIKI_BULGU>()
            .AsNoTracking()
            .Select(e => new HastaVitalFizikiBulguDto
            {
                HASTA_VITAL_FIZIKI_BULGU_KODU = e.HASTA_VITAL_FIZIKI_BULGU_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                ISLEM_ZAMANI = e.ISLEM_ZAMANI,
                SISTOLIK_KAN_BASINCI_DEGERI = e.SISTOLIK_KAN_BASINCI_DEGERI,
                DIASTOLIK_KAN_BASINCI_DEGERI = e.DIASTOLIK_KAN_BASINCI_DEGERI,
                NABIZ = e.NABIZ,
                SOLUNUM = e.SOLUNUM,
                ATES = e.ATES,
                BAS_CEVRESI = e.BAS_CEVRESI,
                BOY = e.BOY,
                AGIRLIK = e.AGIRLIK,
                SATURASYON = e.SATURASYON,
                BEL_CEVRESI = e.BEL_CEVRESI,
                KALCA_CEVRESI = e.KALCA_CEVRESI,
                KOL_CEVRESI = e.KOL_CEVRESI,
                KARIN_CEVRESI = e.KARIN_CEVRESI,
                HEMSIRE_KODU = e.HEMSIRE_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.HastaVitalFizikiBulgu)]
    public async Task<ActionResult<HastaVitalFizikiBulguDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_VITAL_FIZIKI_BULGU>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.HASTA_VITAL_FIZIKI_BULGU_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new HastaVitalFizikiBulguDto
        {
            HASTA_VITAL_FIZIKI_BULGU_KODU = entity.HASTA_VITAL_FIZIKI_BULGU_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            ISLEM_ZAMANI = entity.ISLEM_ZAMANI,
            SISTOLIK_KAN_BASINCI_DEGERI = entity.SISTOLIK_KAN_BASINCI_DEGERI,
            DIASTOLIK_KAN_BASINCI_DEGERI = entity.DIASTOLIK_KAN_BASINCI_DEGERI,
            NABIZ = entity.NABIZ,
            SOLUNUM = entity.SOLUNUM,
            ATES = entity.ATES,
            BAS_CEVRESI = entity.BAS_CEVRESI,
            BOY = entity.BOY,
            AGIRLIK = entity.AGIRLIK,
            SATURASYON = entity.SATURASYON,
            BEL_CEVRESI = entity.BEL_CEVRESI,
            KALCA_CEVRESI = entity.KALCA_CEVRESI,
            KOL_CEVRESI = entity.KOL_CEVRESI,
            KARIN_CEVRESI = entity.KARIN_CEVRESI,
            HEMSIRE_KODU = entity.HEMSIRE_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.HastaVitalFizikiBulgu)]
    public async Task<ActionResult<string>> Create(HastaVitalFizikiBulguDto dto, CancellationToken ct)
    {
        var entity = new HASTA_VITAL_FIZIKI_BULGU
        {
            HASTA_VITAL_FIZIKI_BULGU_KODU = dto.HASTA_VITAL_FIZIKI_BULGU_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            ISLEM_ZAMANI = dto.ISLEM_ZAMANI,
            SISTOLIK_KAN_BASINCI_DEGERI = dto.SISTOLIK_KAN_BASINCI_DEGERI,
            DIASTOLIK_KAN_BASINCI_DEGERI = dto.DIASTOLIK_KAN_BASINCI_DEGERI,
            NABIZ = dto.NABIZ,
            SOLUNUM = dto.SOLUNUM,
            ATES = dto.ATES,
            BAS_CEVRESI = dto.BAS_CEVRESI,
            BOY = dto.BOY,
            AGIRLIK = dto.AGIRLIK,
            SATURASYON = dto.SATURASYON,
            BEL_CEVRESI = dto.BEL_CEVRESI,
            KALCA_CEVRESI = dto.KALCA_CEVRESI,
            KOL_CEVRESI = dto.KOL_CEVRESI,
            KARIN_CEVRESI = dto.KARIN_CEVRESI,
            HEMSIRE_KODU = dto.HEMSIRE_KODU,
        };

        _db.Set<HASTA_VITAL_FIZIKI_BULGU>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.HASTA_VITAL_FIZIKI_BULGU_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.HastaVitalFizikiBulgu)]
    public async Task<IActionResult> Update(string id, HastaVitalFizikiBulguDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_VITAL_FIZIKI_BULGU>()
            .FirstOrDefaultAsync(e => e.HASTA_VITAL_FIZIKI_BULGU_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.ISLEM_ZAMANI = dto.ISLEM_ZAMANI;
        entity.SISTOLIK_KAN_BASINCI_DEGERI = dto.SISTOLIK_KAN_BASINCI_DEGERI;
        entity.DIASTOLIK_KAN_BASINCI_DEGERI = dto.DIASTOLIK_KAN_BASINCI_DEGERI;
        entity.NABIZ = dto.NABIZ;
        entity.SOLUNUM = dto.SOLUNUM;
        entity.ATES = dto.ATES;
        entity.BAS_CEVRESI = dto.BAS_CEVRESI;
        entity.BOY = dto.BOY;
        entity.AGIRLIK = dto.AGIRLIK;
        entity.SATURASYON = dto.SATURASYON;
        entity.BEL_CEVRESI = dto.BEL_CEVRESI;
        entity.KALCA_CEVRESI = dto.KALCA_CEVRESI;
        entity.KOL_CEVRESI = dto.KOL_CEVRESI;
        entity.KARIN_CEVRESI = dto.KARIN_CEVRESI;
        entity.HEMSIRE_KODU = dto.HEMSIRE_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.HastaVitalFizikiBulgu)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_VITAL_FIZIKI_BULGU>()
            .FirstOrDefaultAsync(e => e.HASTA_VITAL_FIZIKI_BULGU_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<HASTA_VITAL_FIZIKI_BULGU>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
