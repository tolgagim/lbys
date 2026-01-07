using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.IlacUyum;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class IlacUyumController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public IlacUyumController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.IlacUyum)]
    public async Task<List<IlacUyumDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<ILAC_UYUM>()
            .AsNoTracking()
            .Select(e => new IlacUyumDto
            {
                ILAC_UYUM_KODU = e.ILAC_UYUM_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                ILAC_UYUMSUZLUK_TURU = e.ILAC_UYUMSUZLUK_TURU,
                BIRINCI_ILAC_BARKODU = e.BIRINCI_ILAC_BARKODU,
                BIRINCI_ETKEN_MADDE_KODU = e.BIRINCI_ETKEN_MADDE_KODU,
                IKINCI_ILAC_BARKODU = e.IKINCI_ILAC_BARKODU,
                IKINCI_ETKEN_MADDE_KODU = e.IKINCI_ETKEN_MADDE_KODU,
                BESIN_KODU = e.BESIN_KODU,
                YAS_BASLANGIC = e.YAS_BASLANGIC,
                YAS_BITIS = e.YAS_BITIS,
                CINSIYET = e.CINSIYET,
                RENK_SEVIYE_KODU = e.RENK_SEVIYE_KODU,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.IlacUyum)]
    public async Task<ActionResult<IlacUyumDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<ILAC_UYUM>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.ILAC_UYUM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new IlacUyumDto
        {
            ILAC_UYUM_KODU = entity.ILAC_UYUM_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            ILAC_UYUMSUZLUK_TURU = entity.ILAC_UYUMSUZLUK_TURU,
            BIRINCI_ILAC_BARKODU = entity.BIRINCI_ILAC_BARKODU,
            BIRINCI_ETKEN_MADDE_KODU = entity.BIRINCI_ETKEN_MADDE_KODU,
            IKINCI_ILAC_BARKODU = entity.IKINCI_ILAC_BARKODU,
            IKINCI_ETKEN_MADDE_KODU = entity.IKINCI_ETKEN_MADDE_KODU,
            BESIN_KODU = entity.BESIN_KODU,
            YAS_BASLANGIC = entity.YAS_BASLANGIC,
            YAS_BITIS = entity.YAS_BITIS,
            CINSIYET = entity.CINSIYET,
            RENK_SEVIYE_KODU = entity.RENK_SEVIYE_KODU,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.IlacUyum)]
    public async Task<ActionResult<string>> Create(IlacUyumDto dto, CancellationToken ct)
    {
        var entity = new ILAC_UYUM
        {
            ILAC_UYUM_KODU = dto.ILAC_UYUM_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            ILAC_UYUMSUZLUK_TURU = dto.ILAC_UYUMSUZLUK_TURU,
            BIRINCI_ILAC_BARKODU = dto.BIRINCI_ILAC_BARKODU,
            BIRINCI_ETKEN_MADDE_KODU = dto.BIRINCI_ETKEN_MADDE_KODU,
            IKINCI_ILAC_BARKODU = dto.IKINCI_ILAC_BARKODU,
            IKINCI_ETKEN_MADDE_KODU = dto.IKINCI_ETKEN_MADDE_KODU,
            BESIN_KODU = dto.BESIN_KODU,
            YAS_BASLANGIC = dto.YAS_BASLANGIC,
            YAS_BITIS = dto.YAS_BITIS,
            CINSIYET = dto.CINSIYET,
            RENK_SEVIYE_KODU = dto.RENK_SEVIYE_KODU,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<ILAC_UYUM>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.ILAC_UYUM_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.IlacUyum)]
    public async Task<IActionResult> Update(string id, IlacUyumDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<ILAC_UYUM>()
            .FirstOrDefaultAsync(e => e.ILAC_UYUM_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.ILAC_UYUMSUZLUK_TURU = dto.ILAC_UYUMSUZLUK_TURU;
        entity.BIRINCI_ILAC_BARKODU = dto.BIRINCI_ILAC_BARKODU;
        entity.BIRINCI_ETKEN_MADDE_KODU = dto.BIRINCI_ETKEN_MADDE_KODU;
        entity.IKINCI_ILAC_BARKODU = dto.IKINCI_ILAC_BARKODU;
        entity.IKINCI_ETKEN_MADDE_KODU = dto.IKINCI_ETKEN_MADDE_KODU;
        entity.BESIN_KODU = dto.BESIN_KODU;
        entity.YAS_BASLANGIC = dto.YAS_BASLANGIC;
        entity.YAS_BITIS = dto.YAS_BITIS;
        entity.CINSIYET = dto.CINSIYET;
        entity.RENK_SEVIYE_KODU = dto.RENK_SEVIYE_KODU;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.IlacUyum)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<ILAC_UYUM>()
            .FirstOrDefaultAsync(e => e.ILAC_UYUM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<ILAC_UYUM>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
