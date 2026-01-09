using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.EkOdeme;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class EkOdemeController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public EkOdemeController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.EkOdeme)]
    public async Task<List<EkOdemeDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<EK_ODEME>()
            .AsNoTracking()
            .Select(e => new EkOdemeDto
            {
                EK_ODEME_KODU = e.EK_ODEME_KODU,
EK_ODEME_DONEM_KODU = e.EK_ODEME_DONEM_KODU,
                PERSONEL_KODU = e.PERSONEL_KODU,
                HESAPLAMA_YONTEMI = e.HESAPLAMA_YONTEMI,
                MAAS_DERECESI = e.MAAS_DERECESI,
                MAAS_KADEMESI = e.MAAS_KADEMESI,
                MAAS_GOSTERGESI = e.MAAS_GOSTERGESI,
                AYLIK_TUTARI = e.AYLIK_TUTARI,
                OZEL_HIZMET_TUTARI = e.OZEL_HIZMET_TUTARI,
                EK_GOSTERGE_TUTARI = e.EK_GOSTERGE_TUTARI,
                YAN_ODEME_TUTARI = e.YAN_ODEME_TUTARI,
                DOGU_TAZMINATI_TUTARI = e.DOGU_TAZMINATI_TUTARI,
                EK_ODEME_MATRAHI = e.EK_ODEME_MATRAHI,
                BASKA_KURUMDAKI_EKODEME_TUTARI = e.BASKA_KURUMDAKI_EKODEME_TUTARI,
                DSSO_TUTARI = e.DSSO_TUTARI,
                ENGELLILIK_INDIRIM_ORANI = e.ENGELLILIK_INDIRIM_ORANI,
                KOMISYON_EK_PUANI_ORANI = e.KOMISYON_EK_PUANI_ORANI,
                EK_PUAN_ORANI = e.EK_PUAN_ORANI,
                BIRIM_PERFORMANS_KATSAYISI = e.BIRIM_PERFORMANS_KATSAYISI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.EkOdeme)]
    public async Task<ActionResult<EkOdemeDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<EK_ODEME>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.EK_ODEME_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new EkOdemeDto
        {
            EK_ODEME_KODU = entity.EK_ODEME_KODU,
EK_ODEME_DONEM_KODU = entity.EK_ODEME_DONEM_KODU,
            PERSONEL_KODU = entity.PERSONEL_KODU,
            HESAPLAMA_YONTEMI = entity.HESAPLAMA_YONTEMI,
            MAAS_DERECESI = entity.MAAS_DERECESI,
            MAAS_KADEMESI = entity.MAAS_KADEMESI,
            MAAS_GOSTERGESI = entity.MAAS_GOSTERGESI,
            AYLIK_TUTARI = entity.AYLIK_TUTARI,
            OZEL_HIZMET_TUTARI = entity.OZEL_HIZMET_TUTARI,
            EK_GOSTERGE_TUTARI = entity.EK_GOSTERGE_TUTARI,
            YAN_ODEME_TUTARI = entity.YAN_ODEME_TUTARI,
            DOGU_TAZMINATI_TUTARI = entity.DOGU_TAZMINATI_TUTARI,
            EK_ODEME_MATRAHI = entity.EK_ODEME_MATRAHI,
            BASKA_KURUMDAKI_EKODEME_TUTARI = entity.BASKA_KURUMDAKI_EKODEME_TUTARI,
            DSSO_TUTARI = entity.DSSO_TUTARI,
            ENGELLILIK_INDIRIM_ORANI = entity.ENGELLILIK_INDIRIM_ORANI,
            KOMISYON_EK_PUANI_ORANI = entity.KOMISYON_EK_PUANI_ORANI,
            EK_PUAN_ORANI = entity.EK_PUAN_ORANI,
            BIRIM_PERFORMANS_KATSAYISI = entity.BIRIM_PERFORMANS_KATSAYISI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.EkOdeme)]
    public async Task<ActionResult<string>> Create(EkOdemeDto dto, CancellationToken ct)
    {
        var entity = new EK_ODEME
        {
            EK_ODEME_KODU = dto.EK_ODEME_KODU,
EK_ODEME_DONEM_KODU = dto.EK_ODEME_DONEM_KODU,
            PERSONEL_KODU = dto.PERSONEL_KODU,
            HESAPLAMA_YONTEMI = dto.HESAPLAMA_YONTEMI,
            MAAS_DERECESI = dto.MAAS_DERECESI,
            MAAS_KADEMESI = dto.MAAS_KADEMESI,
            MAAS_GOSTERGESI = dto.MAAS_GOSTERGESI,
            AYLIK_TUTARI = dto.AYLIK_TUTARI,
            OZEL_HIZMET_TUTARI = dto.OZEL_HIZMET_TUTARI,
            EK_GOSTERGE_TUTARI = dto.EK_GOSTERGE_TUTARI,
            YAN_ODEME_TUTARI = dto.YAN_ODEME_TUTARI,
            DOGU_TAZMINATI_TUTARI = dto.DOGU_TAZMINATI_TUTARI,
            EK_ODEME_MATRAHI = dto.EK_ODEME_MATRAHI,
            BASKA_KURUMDAKI_EKODEME_TUTARI = dto.BASKA_KURUMDAKI_EKODEME_TUTARI,
            DSSO_TUTARI = dto.DSSO_TUTARI,
            ENGELLILIK_INDIRIM_ORANI = dto.ENGELLILIK_INDIRIM_ORANI,
            KOMISYON_EK_PUANI_ORANI = dto.KOMISYON_EK_PUANI_ORANI,
            EK_PUAN_ORANI = dto.EK_PUAN_ORANI,
            BIRIM_PERFORMANS_KATSAYISI = dto.BIRIM_PERFORMANS_KATSAYISI,
        };

        _db.Set<EK_ODEME>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.EK_ODEME_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.EkOdeme)]
    public async Task<IActionResult> Update(string id, EkOdemeDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<EK_ODEME>()
            .FirstOrDefaultAsync(e => e.EK_ODEME_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.EK_ODEME_DONEM_KODU = dto.EK_ODEME_DONEM_KODU;
        entity.PERSONEL_KODU = dto.PERSONEL_KODU;
        entity.HESAPLAMA_YONTEMI = dto.HESAPLAMA_YONTEMI;
        entity.MAAS_DERECESI = dto.MAAS_DERECESI;
        entity.MAAS_KADEMESI = dto.MAAS_KADEMESI;
        entity.MAAS_GOSTERGESI = dto.MAAS_GOSTERGESI;
        entity.AYLIK_TUTARI = dto.AYLIK_TUTARI;
        entity.OZEL_HIZMET_TUTARI = dto.OZEL_HIZMET_TUTARI;
        entity.EK_GOSTERGE_TUTARI = dto.EK_GOSTERGE_TUTARI;
        entity.YAN_ODEME_TUTARI = dto.YAN_ODEME_TUTARI;
        entity.DOGU_TAZMINATI_TUTARI = dto.DOGU_TAZMINATI_TUTARI;
        entity.EK_ODEME_MATRAHI = dto.EK_ODEME_MATRAHI;
        entity.BASKA_KURUMDAKI_EKODEME_TUTARI = dto.BASKA_KURUMDAKI_EKODEME_TUTARI;
        entity.DSSO_TUTARI = dto.DSSO_TUTARI;
        entity.ENGELLILIK_INDIRIM_ORANI = dto.ENGELLILIK_INDIRIM_ORANI;
        entity.KOMISYON_EK_PUANI_ORANI = dto.KOMISYON_EK_PUANI_ORANI;
        entity.EK_PUAN_ORANI = dto.EK_PUAN_ORANI;
        entity.BIRIM_PERFORMANS_KATSAYISI = dto.BIRIM_PERFORMANS_KATSAYISI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.EkOdeme)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<EK_ODEME>()
            .FirstOrDefaultAsync(e => e.EK_ODEME_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<EK_ODEME>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
