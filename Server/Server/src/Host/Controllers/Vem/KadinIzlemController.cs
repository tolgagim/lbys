using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.KadinIzlem;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class KadinIzlemController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public KadinIzlemController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.KadinIzlem)]
    public async Task<List<KadinIzlemDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<KADIN_IZLEM>()
            .AsNoTracking()
            .Select(e => new KadinIzlemDto
            {
                KADIN_IZLEM_KODU = e.KADIN_IZLEM_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                KONJENITAL_ANOMALI_VARLIGI = e.KONJENITAL_ANOMALI_VARLIGI,
                CANLI_DOGAN_BEBEK_SAYISI = e.CANLI_DOGAN_BEBEK_SAYISI,
                OLU_DOGAN_BEBEK_SAYISI = e.OLU_DOGAN_BEBEK_SAYISI,
                HEMOGLOBIN_DEGERI = e.HEMOGLOBIN_DEGERI,
                ONCEKI_DOGUM_DURUMU = e.ONCEKI_DOGUM_DURUMU,
                IZLEMIN_YAPILDIGI_YER = e.IZLEMIN_YAPILDIGI_YER,
                KULLANILAN_AP_YONTEMI = e.KULLANILAN_AP_YONTEMI,
                BIR_ONCE_KULLANILAN_AP_YONTEMI = e.BIR_ONCE_KULLANILAN_AP_YONTEMI,
                AP_YONTEMI_LOJISTIGI = e.AP_YONTEMI_LOJISTIGI,
                KADIN_SAGLIGI_ISLEMLERI = e.KADIN_SAGLIGI_ISLEMLERI,
                AP_YONTEMI_KULLANMAMA_NEDENI = e.AP_YONTEMI_KULLANMAMA_NEDENI,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.KadinIzlem)]
    public async Task<ActionResult<KadinIzlemDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KADIN_IZLEM>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.KADIN_IZLEM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new KadinIzlemDto
        {
            KADIN_IZLEM_KODU = entity.KADIN_IZLEM_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            KONJENITAL_ANOMALI_VARLIGI = entity.KONJENITAL_ANOMALI_VARLIGI,
            CANLI_DOGAN_BEBEK_SAYISI = entity.CANLI_DOGAN_BEBEK_SAYISI,
            OLU_DOGAN_BEBEK_SAYISI = entity.OLU_DOGAN_BEBEK_SAYISI,
            HEMOGLOBIN_DEGERI = entity.HEMOGLOBIN_DEGERI,
            ONCEKI_DOGUM_DURUMU = entity.ONCEKI_DOGUM_DURUMU,
            IZLEMIN_YAPILDIGI_YER = entity.IZLEMIN_YAPILDIGI_YER,
            KULLANILAN_AP_YONTEMI = entity.KULLANILAN_AP_YONTEMI,
            BIR_ONCE_KULLANILAN_AP_YONTEMI = entity.BIR_ONCE_KULLANILAN_AP_YONTEMI,
            AP_YONTEMI_LOJISTIGI = entity.AP_YONTEMI_LOJISTIGI,
            KADIN_SAGLIGI_ISLEMLERI = entity.KADIN_SAGLIGI_ISLEMLERI,
            AP_YONTEMI_KULLANMAMA_NEDENI = entity.AP_YONTEMI_KULLANMAMA_NEDENI,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.KadinIzlem)]
    public async Task<ActionResult<string>> Create(KadinIzlemDto dto, CancellationToken ct)
    {
        var entity = new KADIN_IZLEM
        {
            KADIN_IZLEM_KODU = dto.KADIN_IZLEM_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            KONJENITAL_ANOMALI_VARLIGI = dto.KONJENITAL_ANOMALI_VARLIGI,
            CANLI_DOGAN_BEBEK_SAYISI = dto.CANLI_DOGAN_BEBEK_SAYISI,
            OLU_DOGAN_BEBEK_SAYISI = dto.OLU_DOGAN_BEBEK_SAYISI,
            HEMOGLOBIN_DEGERI = dto.HEMOGLOBIN_DEGERI,
            ONCEKI_DOGUM_DURUMU = dto.ONCEKI_DOGUM_DURUMU,
            IZLEMIN_YAPILDIGI_YER = dto.IZLEMIN_YAPILDIGI_YER,
            KULLANILAN_AP_YONTEMI = dto.KULLANILAN_AP_YONTEMI,
            BIR_ONCE_KULLANILAN_AP_YONTEMI = dto.BIR_ONCE_KULLANILAN_AP_YONTEMI,
            AP_YONTEMI_LOJISTIGI = dto.AP_YONTEMI_LOJISTIGI,
            KADIN_SAGLIGI_ISLEMLERI = dto.KADIN_SAGLIGI_ISLEMLERI,
            AP_YONTEMI_KULLANMAMA_NEDENI = dto.AP_YONTEMI_KULLANMAMA_NEDENI,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<KADIN_IZLEM>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.KADIN_IZLEM_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.KadinIzlem)]
    public async Task<IActionResult> Update(string id, KadinIzlemDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<KADIN_IZLEM>()
            .FirstOrDefaultAsync(e => e.KADIN_IZLEM_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.KONJENITAL_ANOMALI_VARLIGI = dto.KONJENITAL_ANOMALI_VARLIGI;
        entity.CANLI_DOGAN_BEBEK_SAYISI = dto.CANLI_DOGAN_BEBEK_SAYISI;
        entity.OLU_DOGAN_BEBEK_SAYISI = dto.OLU_DOGAN_BEBEK_SAYISI;
        entity.HEMOGLOBIN_DEGERI = dto.HEMOGLOBIN_DEGERI;
        entity.ONCEKI_DOGUM_DURUMU = dto.ONCEKI_DOGUM_DURUMU;
        entity.IZLEMIN_YAPILDIGI_YER = dto.IZLEMIN_YAPILDIGI_YER;
        entity.KULLANILAN_AP_YONTEMI = dto.KULLANILAN_AP_YONTEMI;
        entity.BIR_ONCE_KULLANILAN_AP_YONTEMI = dto.BIR_ONCE_KULLANILAN_AP_YONTEMI;
        entity.AP_YONTEMI_LOJISTIGI = dto.AP_YONTEMI_LOJISTIGI;
        entity.KADIN_SAGLIGI_ISLEMLERI = dto.KADIN_SAGLIGI_ISLEMLERI;
        entity.AP_YONTEMI_KULLANMAMA_NEDENI = dto.AP_YONTEMI_KULLANMAMA_NEDENI;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.KadinIzlem)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KADIN_IZLEM>()
            .FirstOrDefaultAsync(e => e.KADIN_IZLEM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<KADIN_IZLEM>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
