using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.OrtodontiIconSkor;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class OrtodontiIconSkorController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public OrtodontiIconSkorController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.OrtodontiIconSkor)]
    public async Task<List<OrtodontiIconSkorDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<ORTODONTI_ICON_SKOR>()
            .AsNoTracking()
            .Select(e => new OrtodontiIconSkorDto
            {
                ORTODONTI_ICON_SKOR_KODU = e.ORTODONTI_ICON_SKOR_KODU,
HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                OIS_DEGERLENDIRME_ZAMANI = e.OIS_DEGERLENDIRME_ZAMANI,
                OIS_ESTETIK_BOZUKLUK_BILGISI = e.OIS_ESTETIK_BOZUKLUK_BILGISI,
                OIS_ESTETIK_PUAN_KATSAYISI = e.OIS_ESTETIK_PUAN_KATSAYISI,
                OIS_ESTETIK_PUANI = e.OIS_ESTETIK_PUANI,
                UST_DIS_ARKA_CAPRASIKLIK = e.UST_DIS_ARKA_CAPRASIKLIK,
                UST_ARKA_CAPRASIKLIK_KATSAYISI = e.UST_ARKA_CAPRASIKLIK_KATSAYISI,
                UST_ARKA_CAPRASIKLIK_PUANI = e.UST_ARKA_CAPRASIKLIK_PUANI,
                UST_DIS_ARKA_BOSLUK = e.UST_DIS_ARKA_BOSLUK,
                UST_ARKA_BOSLUK_KATSAYISI = e.UST_ARKA_BOSLUK_KATSAYISI,
                UST_ARKA_BOSLUK_PUANI = e.UST_ARKA_BOSLUK_PUANI,
                DIS_CAPRAZLIK_DURUMU = e.DIS_CAPRAZLIK_DURUMU,
                DIS_CAPRAZLIK_KATSAYISI = e.DIS_CAPRAZLIK_KATSAYISI,
                DIS_CAPRAZLIK_PUANI = e.DIS_CAPRAZLIK_PUANI,
                ON_ACIK_KAPANIS = e.ON_ACIK_KAPANIS,
                ON_ACIK_KAPANIS_KATSAYISI = e.ON_ACIK_KAPANIS_KATSAYISI,
                ON_ACIK_KAPANIS_PUANI = e.ON_ACIK_KAPANIS_PUANI,
                ON_DERIN_KAPANIS = e.ON_DERIN_KAPANIS,
                ON_DERIN_KAPANIS_KATSAYISI = e.ON_DERIN_KAPANIS_KATSAYISI,
                ON_DERIN_KAPANIS_PUANI = e.ON_DERIN_KAPANIS_PUANI,
                BUKKAL_BOLGE_SAG = e.BUKKAL_BOLGE_SAG,
                BUKKAL_BOLGE_SAG_KATSAYISI = e.BUKKAL_BOLGE_SAG_KATSAYISI,
                BUKKAL_BOLGE_SAG_PUANI = e.BUKKAL_BOLGE_SAG_PUANI,
                BUKKAL_BOLGE_SOL = e.BUKKAL_BOLGE_SOL,
                BUKKAL_BOLGE_SOL_KATSAYISI = e.BUKKAL_BOLGE_SOL_KATSAYISI,
                BUKKAL_BOLGE_SOL_PUANI = e.BUKKAL_BOLGE_SOL_PUANI,
                BUKKAL_TOPLAM_PUANI = e.BUKKAL_TOPLAM_PUANI,
                TOPLAM_ICON_SKOR_PUANI = e.TOPLAM_ICON_SKOR_PUANI,
                OIS_DEGERLENDIREN_1_HEKIM_KODU = e.OIS_DEGERLENDIREN_1_HEKIM_KODU,
                OIS_DEGERLENDIREN_2_HEKIM_KODU = e.OIS_DEGERLENDIREN_2_HEKIM_KODU,
                OIS_DEGERLENDIREN_3_HEKIM_KODU = e.OIS_DEGERLENDIREN_3_HEKIM_KODU,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.OrtodontiIconSkor)]
    public async Task<ActionResult<OrtodontiIconSkorDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<ORTODONTI_ICON_SKOR>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.ORTODONTI_ICON_SKOR_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new OrtodontiIconSkorDto
        {
            ORTODONTI_ICON_SKOR_KODU = entity.ORTODONTI_ICON_SKOR_KODU,
HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            OIS_DEGERLENDIRME_ZAMANI = entity.OIS_DEGERLENDIRME_ZAMANI,
            OIS_ESTETIK_BOZUKLUK_BILGISI = entity.OIS_ESTETIK_BOZUKLUK_BILGISI,
            OIS_ESTETIK_PUAN_KATSAYISI = entity.OIS_ESTETIK_PUAN_KATSAYISI,
            OIS_ESTETIK_PUANI = entity.OIS_ESTETIK_PUANI,
            UST_DIS_ARKA_CAPRASIKLIK = entity.UST_DIS_ARKA_CAPRASIKLIK,
            UST_ARKA_CAPRASIKLIK_KATSAYISI = entity.UST_ARKA_CAPRASIKLIK_KATSAYISI,
            UST_ARKA_CAPRASIKLIK_PUANI = entity.UST_ARKA_CAPRASIKLIK_PUANI,
            UST_DIS_ARKA_BOSLUK = entity.UST_DIS_ARKA_BOSLUK,
            UST_ARKA_BOSLUK_KATSAYISI = entity.UST_ARKA_BOSLUK_KATSAYISI,
            UST_ARKA_BOSLUK_PUANI = entity.UST_ARKA_BOSLUK_PUANI,
            DIS_CAPRAZLIK_DURUMU = entity.DIS_CAPRAZLIK_DURUMU,
            DIS_CAPRAZLIK_KATSAYISI = entity.DIS_CAPRAZLIK_KATSAYISI,
            DIS_CAPRAZLIK_PUANI = entity.DIS_CAPRAZLIK_PUANI,
            ON_ACIK_KAPANIS = entity.ON_ACIK_KAPANIS,
            ON_ACIK_KAPANIS_KATSAYISI = entity.ON_ACIK_KAPANIS_KATSAYISI,
            ON_ACIK_KAPANIS_PUANI = entity.ON_ACIK_KAPANIS_PUANI,
            ON_DERIN_KAPANIS = entity.ON_DERIN_KAPANIS,
            ON_DERIN_KAPANIS_KATSAYISI = entity.ON_DERIN_KAPANIS_KATSAYISI,
            ON_DERIN_KAPANIS_PUANI = entity.ON_DERIN_KAPANIS_PUANI,
            BUKKAL_BOLGE_SAG = entity.BUKKAL_BOLGE_SAG,
            BUKKAL_BOLGE_SAG_KATSAYISI = entity.BUKKAL_BOLGE_SAG_KATSAYISI,
            BUKKAL_BOLGE_SAG_PUANI = entity.BUKKAL_BOLGE_SAG_PUANI,
            BUKKAL_BOLGE_SOL = entity.BUKKAL_BOLGE_SOL,
            BUKKAL_BOLGE_SOL_KATSAYISI = entity.BUKKAL_BOLGE_SOL_KATSAYISI,
            BUKKAL_BOLGE_SOL_PUANI = entity.BUKKAL_BOLGE_SOL_PUANI,
            BUKKAL_TOPLAM_PUANI = entity.BUKKAL_TOPLAM_PUANI,
            TOPLAM_ICON_SKOR_PUANI = entity.TOPLAM_ICON_SKOR_PUANI,
            OIS_DEGERLENDIREN_1_HEKIM_KODU = entity.OIS_DEGERLENDIREN_1_HEKIM_KODU,
            OIS_DEGERLENDIREN_2_HEKIM_KODU = entity.OIS_DEGERLENDIREN_2_HEKIM_KODU,
            OIS_DEGERLENDIREN_3_HEKIM_KODU = entity.OIS_DEGERLENDIREN_3_HEKIM_KODU,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.OrtodontiIconSkor)]
    public async Task<ActionResult<string>> Create(OrtodontiIconSkorDto dto, CancellationToken ct)
    {
        var entity = new ORTODONTI_ICON_SKOR
        {
            ORTODONTI_ICON_SKOR_KODU = dto.ORTODONTI_ICON_SKOR_KODU,
HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            OIS_DEGERLENDIRME_ZAMANI = dto.OIS_DEGERLENDIRME_ZAMANI,
            OIS_ESTETIK_BOZUKLUK_BILGISI = dto.OIS_ESTETIK_BOZUKLUK_BILGISI,
            OIS_ESTETIK_PUAN_KATSAYISI = dto.OIS_ESTETIK_PUAN_KATSAYISI,
            OIS_ESTETIK_PUANI = dto.OIS_ESTETIK_PUANI,
            UST_DIS_ARKA_CAPRASIKLIK = dto.UST_DIS_ARKA_CAPRASIKLIK,
            UST_ARKA_CAPRASIKLIK_KATSAYISI = dto.UST_ARKA_CAPRASIKLIK_KATSAYISI,
            UST_ARKA_CAPRASIKLIK_PUANI = dto.UST_ARKA_CAPRASIKLIK_PUANI,
            UST_DIS_ARKA_BOSLUK = dto.UST_DIS_ARKA_BOSLUK,
            UST_ARKA_BOSLUK_KATSAYISI = dto.UST_ARKA_BOSLUK_KATSAYISI,
            UST_ARKA_BOSLUK_PUANI = dto.UST_ARKA_BOSLUK_PUANI,
            DIS_CAPRAZLIK_DURUMU = dto.DIS_CAPRAZLIK_DURUMU,
            DIS_CAPRAZLIK_KATSAYISI = dto.DIS_CAPRAZLIK_KATSAYISI,
            DIS_CAPRAZLIK_PUANI = dto.DIS_CAPRAZLIK_PUANI,
            ON_ACIK_KAPANIS = dto.ON_ACIK_KAPANIS,
            ON_ACIK_KAPANIS_KATSAYISI = dto.ON_ACIK_KAPANIS_KATSAYISI,
            ON_ACIK_KAPANIS_PUANI = dto.ON_ACIK_KAPANIS_PUANI,
            ON_DERIN_KAPANIS = dto.ON_DERIN_KAPANIS,
            ON_DERIN_KAPANIS_KATSAYISI = dto.ON_DERIN_KAPANIS_KATSAYISI,
            ON_DERIN_KAPANIS_PUANI = dto.ON_DERIN_KAPANIS_PUANI,
            BUKKAL_BOLGE_SAG = dto.BUKKAL_BOLGE_SAG,
            BUKKAL_BOLGE_SAG_KATSAYISI = dto.BUKKAL_BOLGE_SAG_KATSAYISI,
            BUKKAL_BOLGE_SAG_PUANI = dto.BUKKAL_BOLGE_SAG_PUANI,
            BUKKAL_BOLGE_SOL = dto.BUKKAL_BOLGE_SOL,
            BUKKAL_BOLGE_SOL_KATSAYISI = dto.BUKKAL_BOLGE_SOL_KATSAYISI,
            BUKKAL_BOLGE_SOL_PUANI = dto.BUKKAL_BOLGE_SOL_PUANI,
            BUKKAL_TOPLAM_PUANI = dto.BUKKAL_TOPLAM_PUANI,
            TOPLAM_ICON_SKOR_PUANI = dto.TOPLAM_ICON_SKOR_PUANI,
            OIS_DEGERLENDIREN_1_HEKIM_KODU = dto.OIS_DEGERLENDIREN_1_HEKIM_KODU,
            OIS_DEGERLENDIREN_2_HEKIM_KODU = dto.OIS_DEGERLENDIREN_2_HEKIM_KODU,
            OIS_DEGERLENDIREN_3_HEKIM_KODU = dto.OIS_DEGERLENDIREN_3_HEKIM_KODU,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<ORTODONTI_ICON_SKOR>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.ORTODONTI_ICON_SKOR_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.OrtodontiIconSkor)]
    public async Task<IActionResult> Update(string id, OrtodontiIconSkorDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<ORTODONTI_ICON_SKOR>()
            .FirstOrDefaultAsync(e => e.ORTODONTI_ICON_SKOR_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.OIS_DEGERLENDIRME_ZAMANI = dto.OIS_DEGERLENDIRME_ZAMANI;
        entity.OIS_ESTETIK_BOZUKLUK_BILGISI = dto.OIS_ESTETIK_BOZUKLUK_BILGISI;
        entity.OIS_ESTETIK_PUAN_KATSAYISI = dto.OIS_ESTETIK_PUAN_KATSAYISI;
        entity.OIS_ESTETIK_PUANI = dto.OIS_ESTETIK_PUANI;
        entity.UST_DIS_ARKA_CAPRASIKLIK = dto.UST_DIS_ARKA_CAPRASIKLIK;
        entity.UST_ARKA_CAPRASIKLIK_KATSAYISI = dto.UST_ARKA_CAPRASIKLIK_KATSAYISI;
        entity.UST_ARKA_CAPRASIKLIK_PUANI = dto.UST_ARKA_CAPRASIKLIK_PUANI;
        entity.UST_DIS_ARKA_BOSLUK = dto.UST_DIS_ARKA_BOSLUK;
        entity.UST_ARKA_BOSLUK_KATSAYISI = dto.UST_ARKA_BOSLUK_KATSAYISI;
        entity.UST_ARKA_BOSLUK_PUANI = dto.UST_ARKA_BOSLUK_PUANI;
        entity.DIS_CAPRAZLIK_DURUMU = dto.DIS_CAPRAZLIK_DURUMU;
        entity.DIS_CAPRAZLIK_KATSAYISI = dto.DIS_CAPRAZLIK_KATSAYISI;
        entity.DIS_CAPRAZLIK_PUANI = dto.DIS_CAPRAZLIK_PUANI;
        entity.ON_ACIK_KAPANIS = dto.ON_ACIK_KAPANIS;
        entity.ON_ACIK_KAPANIS_KATSAYISI = dto.ON_ACIK_KAPANIS_KATSAYISI;
        entity.ON_ACIK_KAPANIS_PUANI = dto.ON_ACIK_KAPANIS_PUANI;
        entity.ON_DERIN_KAPANIS = dto.ON_DERIN_KAPANIS;
        entity.ON_DERIN_KAPANIS_KATSAYISI = dto.ON_DERIN_KAPANIS_KATSAYISI;
        entity.ON_DERIN_KAPANIS_PUANI = dto.ON_DERIN_KAPANIS_PUANI;
        entity.BUKKAL_BOLGE_SAG = dto.BUKKAL_BOLGE_SAG;
        entity.BUKKAL_BOLGE_SAG_KATSAYISI = dto.BUKKAL_BOLGE_SAG_KATSAYISI;
        entity.BUKKAL_BOLGE_SAG_PUANI = dto.BUKKAL_BOLGE_SAG_PUANI;
        entity.BUKKAL_BOLGE_SOL = dto.BUKKAL_BOLGE_SOL;
        entity.BUKKAL_BOLGE_SOL_KATSAYISI = dto.BUKKAL_BOLGE_SOL_KATSAYISI;
        entity.BUKKAL_BOLGE_SOL_PUANI = dto.BUKKAL_BOLGE_SOL_PUANI;
        entity.BUKKAL_TOPLAM_PUANI = dto.BUKKAL_TOPLAM_PUANI;
        entity.TOPLAM_ICON_SKOR_PUANI = dto.TOPLAM_ICON_SKOR_PUANI;
        entity.OIS_DEGERLENDIREN_1_HEKIM_KODU = dto.OIS_DEGERLENDIREN_1_HEKIM_KODU;
        entity.OIS_DEGERLENDIREN_2_HEKIM_KODU = dto.OIS_DEGERLENDIREN_2_HEKIM_KODU;
        entity.OIS_DEGERLENDIREN_3_HEKIM_KODU = dto.OIS_DEGERLENDIREN_3_HEKIM_KODU;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.OrtodontiIconSkor)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<ORTODONTI_ICON_SKOR>()
            .FirstOrDefaultAsync(e => e.ORTODONTI_ICON_SKOR_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<ORTODONTI_ICON_SKOR>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
