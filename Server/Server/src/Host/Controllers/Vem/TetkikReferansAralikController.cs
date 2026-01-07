using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.TetkikReferansAralik;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class TetkikReferansAralikController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public TetkikReferansAralikController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.TetkikReferansAralik)]
    public async Task<List<TetkikReferansAralikDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<TETKIK_REFERANS_ARALIK>()
            .AsNoTracking()
            .Select(e => new TetkikReferansAralikDto
            {
                TETKIK_REFERANS_ARALIK_KODU = e.TETKIK_REFERANS_ARALIK_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                TETKIK_PARAMETRE_KODU = e.TETKIK_PARAMETRE_KODU,
                TETKIK_KODU = e.TETKIK_KODU,
                CIHAZ_KODU = e.CIHAZ_KODU,
                TETKIK_CINSIYET = e.TETKIK_CINSIYET,
                YAS_ARALIGI_BASLANGIC_GUN = e.YAS_ARALIGI_BASLANGIC_GUN,
                YAS_ARALIGI_BITIS_GUN = e.YAS_ARALIGI_BITIS_GUN,
                REFERANS_BASLANGIC_DEGERI = e.REFERANS_BASLANGIC_DEGERI,
                REFERANS_BITIS_DEGERI = e.REFERANS_BITIS_DEGERI,
                ALT_KRITIK_DEGER = e.ALT_KRITIK_DEGER,
                UST_KRITIK_DEGER = e.UST_KRITIK_DEGER,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.TetkikReferansAralik)]
    public async Task<ActionResult<TetkikReferansAralikDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<TETKIK_REFERANS_ARALIK>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.TETKIK_REFERANS_ARALIK_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new TetkikReferansAralikDto
        {
            TETKIK_REFERANS_ARALIK_KODU = entity.TETKIK_REFERANS_ARALIK_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            TETKIK_PARAMETRE_KODU = entity.TETKIK_PARAMETRE_KODU,
            TETKIK_KODU = entity.TETKIK_KODU,
            CIHAZ_KODU = entity.CIHAZ_KODU,
            TETKIK_CINSIYET = entity.TETKIK_CINSIYET,
            YAS_ARALIGI_BASLANGIC_GUN = entity.YAS_ARALIGI_BASLANGIC_GUN,
            YAS_ARALIGI_BITIS_GUN = entity.YAS_ARALIGI_BITIS_GUN,
            REFERANS_BASLANGIC_DEGERI = entity.REFERANS_BASLANGIC_DEGERI,
            REFERANS_BITIS_DEGERI = entity.REFERANS_BITIS_DEGERI,
            ALT_KRITIK_DEGER = entity.ALT_KRITIK_DEGER,
            UST_KRITIK_DEGER = entity.UST_KRITIK_DEGER,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.TetkikReferansAralik)]
    public async Task<ActionResult<string>> Create(TetkikReferansAralikDto dto, CancellationToken ct)
    {
        var entity = new TETKIK_REFERANS_ARALIK
        {
            TETKIK_REFERANS_ARALIK_KODU = dto.TETKIK_REFERANS_ARALIK_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            TETKIK_PARAMETRE_KODU = dto.TETKIK_PARAMETRE_KODU,
            TETKIK_KODU = dto.TETKIK_KODU,
            CIHAZ_KODU = dto.CIHAZ_KODU,
            TETKIK_CINSIYET = dto.TETKIK_CINSIYET,
            YAS_ARALIGI_BASLANGIC_GUN = dto.YAS_ARALIGI_BASLANGIC_GUN,
            YAS_ARALIGI_BITIS_GUN = dto.YAS_ARALIGI_BITIS_GUN,
            REFERANS_BASLANGIC_DEGERI = dto.REFERANS_BASLANGIC_DEGERI,
            REFERANS_BITIS_DEGERI = dto.REFERANS_BITIS_DEGERI,
            ALT_KRITIK_DEGER = dto.ALT_KRITIK_DEGER,
            UST_KRITIK_DEGER = dto.UST_KRITIK_DEGER,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<TETKIK_REFERANS_ARALIK>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.TETKIK_REFERANS_ARALIK_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.TetkikReferansAralik)]
    public async Task<IActionResult> Update(string id, TetkikReferansAralikDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<TETKIK_REFERANS_ARALIK>()
            .FirstOrDefaultAsync(e => e.TETKIK_REFERANS_ARALIK_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.TETKIK_PARAMETRE_KODU = dto.TETKIK_PARAMETRE_KODU;
        entity.TETKIK_KODU = dto.TETKIK_KODU;
        entity.CIHAZ_KODU = dto.CIHAZ_KODU;
        entity.TETKIK_CINSIYET = dto.TETKIK_CINSIYET;
        entity.YAS_ARALIGI_BASLANGIC_GUN = dto.YAS_ARALIGI_BASLANGIC_GUN;
        entity.YAS_ARALIGI_BITIS_GUN = dto.YAS_ARALIGI_BITIS_GUN;
        entity.REFERANS_BASLANGIC_DEGERI = dto.REFERANS_BASLANGIC_DEGERI;
        entity.REFERANS_BITIS_DEGERI = dto.REFERANS_BITIS_DEGERI;
        entity.ALT_KRITIK_DEGER = dto.ALT_KRITIK_DEGER;
        entity.UST_KRITIK_DEGER = dto.UST_KRITIK_DEGER;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.TetkikReferansAralik)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<TETKIK_REFERANS_ARALIK>()
            .FirstOrDefaultAsync(e => e.TETKIK_REFERANS_ARALIK_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<TETKIK_REFERANS_ARALIK>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
