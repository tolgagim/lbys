using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.DogumDetay;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class DogumDetayController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public DogumDetayController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.DogumDetay)]
    public async Task<List<DogumDetayDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<DOGUM_DETAY>()
            .AsNoTracking()
            .Select(e => new DogumDetayDto
            {
                DOGUM_DETAY_KODU = e.DOGUM_DETAY_KODU,
HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                DOGUM_KODU = e.DOGUM_KODU,
                DOGUM_ZAMANI = e.DOGUM_ZAMANI,
                CINSIYET = e.CINSIYET,
                DOGUM_YONTEMI = e.DOGUM_YONTEMI,
                AGIRLIK = e.AGIRLIK,
                BOY = e.BOY,
                BAS_CEVRESI = e.BAS_CEVRESI,
                APGAR_1 = e.APGAR_1,
                APGAR_5 = e.APGAR_5,
                APGAR_NOTU = e.APGAR_NOTU,
                KOMPLIKASYON_TANISI = e.KOMPLIKASYON_TANISI,
                DOGUM_SIRASI = e.DOGUM_SIRASI,
                GOGUS_CEVRESI = e.GOGUS_CEVRESI,
                PROGNOZ_BILGISI = e.PROGNOZ_BILGISI,
                SURMATURE_BILGISI = e.SURMATURE_BILGISI,
                K_VITAMINI_UYGULANMA_DURUMU = e.K_VITAMINI_UYGULANMA_DURUMU,
                BEBEGIN_HEPATIT_ASI_DURUMU = e.BEBEGIN_HEPATIT_ASI_DURUMU,
                YENIDOGAN_ISITME_TARAMA_DURUMU = e.YENIDOGAN_ISITME_TARAMA_DURUMU,
                ILK_BESLENME_ZAMANI = e.ILK_BESLENME_ZAMANI,
                TOPUK_KANI = e.TOPUK_KANI,
                TOPUK_KANI_ALINMA_ZAMANI = e.TOPUK_KANI_ALINMA_ZAMANI,
                BEBEK_ADI = e.BEBEK_ADI,
                BABA_TC_KIMLIK_NUMARASI = e.BABA_TC_KIMLIK_NUMARASI,
                BEBEGIN_YASAM_DURUMU = e.BEBEGIN_YASAM_DURUMU,
                SEZARYEN_ENDIKASYONLAR = e.SEZARYEN_ENDIKASYONLAR,
                ROBSON_GRUBU = e.ROBSON_GRUBU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.DogumDetay)]
    public async Task<ActionResult<DogumDetayDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<DOGUM_DETAY>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.DOGUM_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new DogumDetayDto
        {
            DOGUM_DETAY_KODU = entity.DOGUM_DETAY_KODU,
HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            DOGUM_KODU = entity.DOGUM_KODU,
            DOGUM_ZAMANI = entity.DOGUM_ZAMANI,
            CINSIYET = entity.CINSIYET,
            DOGUM_YONTEMI = entity.DOGUM_YONTEMI,
            AGIRLIK = entity.AGIRLIK,
            BOY = entity.BOY,
            BAS_CEVRESI = entity.BAS_CEVRESI,
            APGAR_1 = entity.APGAR_1,
            APGAR_5 = entity.APGAR_5,
            APGAR_NOTU = entity.APGAR_NOTU,
            KOMPLIKASYON_TANISI = entity.KOMPLIKASYON_TANISI,
            DOGUM_SIRASI = entity.DOGUM_SIRASI,
            GOGUS_CEVRESI = entity.GOGUS_CEVRESI,
            PROGNOZ_BILGISI = entity.PROGNOZ_BILGISI,
            SURMATURE_BILGISI = entity.SURMATURE_BILGISI,
            K_VITAMINI_UYGULANMA_DURUMU = entity.K_VITAMINI_UYGULANMA_DURUMU,
            BEBEGIN_HEPATIT_ASI_DURUMU = entity.BEBEGIN_HEPATIT_ASI_DURUMU,
            YENIDOGAN_ISITME_TARAMA_DURUMU = entity.YENIDOGAN_ISITME_TARAMA_DURUMU,
            ILK_BESLENME_ZAMANI = entity.ILK_BESLENME_ZAMANI,
            TOPUK_KANI = entity.TOPUK_KANI,
            TOPUK_KANI_ALINMA_ZAMANI = entity.TOPUK_KANI_ALINMA_ZAMANI,
            BEBEK_ADI = entity.BEBEK_ADI,
            BABA_TC_KIMLIK_NUMARASI = entity.BABA_TC_KIMLIK_NUMARASI,
            BEBEGIN_YASAM_DURUMU = entity.BEBEGIN_YASAM_DURUMU,
            SEZARYEN_ENDIKASYONLAR = entity.SEZARYEN_ENDIKASYONLAR,
            ROBSON_GRUBU = entity.ROBSON_GRUBU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.DogumDetay)]
    public async Task<ActionResult<string>> Create(DogumDetayDto dto, CancellationToken ct)
    {
        var entity = new DOGUM_DETAY
        {
            DOGUM_DETAY_KODU = dto.DOGUM_DETAY_KODU,
HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            DOGUM_KODU = dto.DOGUM_KODU,
            DOGUM_ZAMANI = dto.DOGUM_ZAMANI,
            CINSIYET = dto.CINSIYET,
            DOGUM_YONTEMI = dto.DOGUM_YONTEMI,
            AGIRLIK = dto.AGIRLIK,
            BOY = dto.BOY,
            BAS_CEVRESI = dto.BAS_CEVRESI,
            APGAR_1 = dto.APGAR_1,
            APGAR_5 = dto.APGAR_5,
            APGAR_NOTU = dto.APGAR_NOTU,
            KOMPLIKASYON_TANISI = dto.KOMPLIKASYON_TANISI,
            DOGUM_SIRASI = dto.DOGUM_SIRASI,
            GOGUS_CEVRESI = dto.GOGUS_CEVRESI,
            PROGNOZ_BILGISI = dto.PROGNOZ_BILGISI,
            SURMATURE_BILGISI = dto.SURMATURE_BILGISI,
            K_VITAMINI_UYGULANMA_DURUMU = dto.K_VITAMINI_UYGULANMA_DURUMU,
            BEBEGIN_HEPATIT_ASI_DURUMU = dto.BEBEGIN_HEPATIT_ASI_DURUMU,
            YENIDOGAN_ISITME_TARAMA_DURUMU = dto.YENIDOGAN_ISITME_TARAMA_DURUMU,
            ILK_BESLENME_ZAMANI = dto.ILK_BESLENME_ZAMANI,
            TOPUK_KANI = dto.TOPUK_KANI,
            TOPUK_KANI_ALINMA_ZAMANI = dto.TOPUK_KANI_ALINMA_ZAMANI,
            BEBEK_ADI = dto.BEBEK_ADI,
            BABA_TC_KIMLIK_NUMARASI = dto.BABA_TC_KIMLIK_NUMARASI,
            BEBEGIN_YASAM_DURUMU = dto.BEBEGIN_YASAM_DURUMU,
            SEZARYEN_ENDIKASYONLAR = dto.SEZARYEN_ENDIKASYONLAR,
            ROBSON_GRUBU = dto.ROBSON_GRUBU,
        };

        _db.Set<DOGUM_DETAY>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.DOGUM_DETAY_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.DogumDetay)]
    public async Task<IActionResult> Update(string id, DogumDetayDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<DOGUM_DETAY>()
            .FirstOrDefaultAsync(e => e.DOGUM_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.DOGUM_KODU = dto.DOGUM_KODU;
        entity.DOGUM_ZAMANI = dto.DOGUM_ZAMANI;
        entity.CINSIYET = dto.CINSIYET;
        entity.DOGUM_YONTEMI = dto.DOGUM_YONTEMI;
        entity.AGIRLIK = dto.AGIRLIK;
        entity.BOY = dto.BOY;
        entity.BAS_CEVRESI = dto.BAS_CEVRESI;
        entity.APGAR_1 = dto.APGAR_1;
        entity.APGAR_5 = dto.APGAR_5;
        entity.APGAR_NOTU = dto.APGAR_NOTU;
        entity.KOMPLIKASYON_TANISI = dto.KOMPLIKASYON_TANISI;
        entity.DOGUM_SIRASI = dto.DOGUM_SIRASI;
        entity.GOGUS_CEVRESI = dto.GOGUS_CEVRESI;
        entity.PROGNOZ_BILGISI = dto.PROGNOZ_BILGISI;
        entity.SURMATURE_BILGISI = dto.SURMATURE_BILGISI;
        entity.K_VITAMINI_UYGULANMA_DURUMU = dto.K_VITAMINI_UYGULANMA_DURUMU;
        entity.BEBEGIN_HEPATIT_ASI_DURUMU = dto.BEBEGIN_HEPATIT_ASI_DURUMU;
        entity.YENIDOGAN_ISITME_TARAMA_DURUMU = dto.YENIDOGAN_ISITME_TARAMA_DURUMU;
        entity.ILK_BESLENME_ZAMANI = dto.ILK_BESLENME_ZAMANI;
        entity.TOPUK_KANI = dto.TOPUK_KANI;
        entity.TOPUK_KANI_ALINMA_ZAMANI = dto.TOPUK_KANI_ALINMA_ZAMANI;
        entity.BEBEK_ADI = dto.BEBEK_ADI;
        entity.BABA_TC_KIMLIK_NUMARASI = dto.BABA_TC_KIMLIK_NUMARASI;
        entity.BEBEGIN_YASAM_DURUMU = dto.BEBEGIN_YASAM_DURUMU;
        entity.SEZARYEN_ENDIKASYONLAR = dto.SEZARYEN_ENDIKASYONLAR;
        entity.ROBSON_GRUBU = dto.ROBSON_GRUBU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.DogumDetay)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<DOGUM_DETAY>()
            .FirstOrDefaultAsync(e => e.DOGUM_DETAY_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<DOGUM_DETAY>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
