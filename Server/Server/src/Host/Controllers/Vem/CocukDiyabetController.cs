using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.CocukDiyabet;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class CocukDiyabetController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public CocukDiyabetController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.CocukDiyabet)]
    public async Task<List<CocukDiyabetDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<COCUK_DIYABET>()
            .AsNoTracking()
            .Select(e => new CocukDiyabetDto
            {
                COCUK_DIYABET_KODU = e.COCUK_DIYABET_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                ILK_TANI_TARIHI = e.ILK_TANI_TARIHI,
                AGIRLIK = e.AGIRLIK,
                BOY = e.BOY,
                DIYABET_TIPI = e.DIYABET_TIPI,
                KIZ_COCUKLARDA_MENARS_YASI = e.KIZ_COCUKLARDA_MENARS_YASI,
                BEYIN_ODEMI_DURUMU = e.BEYIN_ODEMI_DURUMU,
                KETOASIDOZ_DURUMU = e.KETOASIDOZ_DURUMU,
                DIYABET_SIKAYET = e.DIYABET_SIKAYET,
                SIKAYETIN_SURESI = e.SIKAYETIN_SURESI,
                AKSILLER_KILLANMA_DURUMU = e.AKSILLER_KILLANMA_DURUMU,
                PUBIK_KILLANMA_DURUMU = e.PUBIK_KILLANMA_DURUMU,
                MEME_EVRE = e.MEME_EVRE,
                TESTIS_VOLUM_SAG = e.TESTIS_VOLUM_SAG,
                TESTIS_VOLUM_SOL = e.TESTIS_VOLUM_SOL,
                ESLIKEDEN_HASTALIK = e.ESLIKEDEN_HASTALIK,
                ESLIKEDEN_HASTALIK_TANI_TARIHI = e.ESLIKEDEN_HASTALIK_TANI_TARIHI,
                DIYABET_ILAC_TEDAVI_SEKLI = e.DIYABET_ILAC_TEDAVI_SEKLI,
                DIYET_TIBBI_BESLENME_TEDAVISI = e.DIYET_TIBBI_BESLENME_TEDAVISI,
                DIYABETLI_HASTA_AILE_OYKUSU = e.DIYABETLI_HASTA_AILE_OYKUSU,
                DIYABET_EGITIMI_VERILME_DURUMU = e.DIYABET_EGITIMI_VERILME_DURUMU,
                TIROID_MUAYENESI = e.TIROID_MUAYENESI,
                DIYABET_KOMPLIKASYONLARI = e.DIYABET_KOMPLIKASYONLARI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.CocukDiyabet)]
    public async Task<ActionResult<CocukDiyabetDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<COCUK_DIYABET>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.COCUK_DIYABET_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new CocukDiyabetDto
        {
            COCUK_DIYABET_KODU = entity.COCUK_DIYABET_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            ILK_TANI_TARIHI = entity.ILK_TANI_TARIHI,
            AGIRLIK = entity.AGIRLIK,
            BOY = entity.BOY,
            DIYABET_TIPI = entity.DIYABET_TIPI,
            KIZ_COCUKLARDA_MENARS_YASI = entity.KIZ_COCUKLARDA_MENARS_YASI,
            BEYIN_ODEMI_DURUMU = entity.BEYIN_ODEMI_DURUMU,
            KETOASIDOZ_DURUMU = entity.KETOASIDOZ_DURUMU,
            DIYABET_SIKAYET = entity.DIYABET_SIKAYET,
            SIKAYETIN_SURESI = entity.SIKAYETIN_SURESI,
            AKSILLER_KILLANMA_DURUMU = entity.AKSILLER_KILLANMA_DURUMU,
            PUBIK_KILLANMA_DURUMU = entity.PUBIK_KILLANMA_DURUMU,
            MEME_EVRE = entity.MEME_EVRE,
            TESTIS_VOLUM_SAG = entity.TESTIS_VOLUM_SAG,
            TESTIS_VOLUM_SOL = entity.TESTIS_VOLUM_SOL,
            ESLIKEDEN_HASTALIK = entity.ESLIKEDEN_HASTALIK,
            ESLIKEDEN_HASTALIK_TANI_TARIHI = entity.ESLIKEDEN_HASTALIK_TANI_TARIHI,
            DIYABET_ILAC_TEDAVI_SEKLI = entity.DIYABET_ILAC_TEDAVI_SEKLI,
            DIYET_TIBBI_BESLENME_TEDAVISI = entity.DIYET_TIBBI_BESLENME_TEDAVISI,
            DIYABETLI_HASTA_AILE_OYKUSU = entity.DIYABETLI_HASTA_AILE_OYKUSU,
            DIYABET_EGITIMI_VERILME_DURUMU = entity.DIYABET_EGITIMI_VERILME_DURUMU,
            TIROID_MUAYENESI = entity.TIROID_MUAYENESI,
            DIYABET_KOMPLIKASYONLARI = entity.DIYABET_KOMPLIKASYONLARI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.CocukDiyabet)]
    public async Task<ActionResult<string>> Create(CocukDiyabetDto dto, CancellationToken ct)
    {
        var entity = new COCUK_DIYABET
        {
            COCUK_DIYABET_KODU = dto.COCUK_DIYABET_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            ILK_TANI_TARIHI = dto.ILK_TANI_TARIHI,
            AGIRLIK = dto.AGIRLIK,
            BOY = dto.BOY,
            DIYABET_TIPI = dto.DIYABET_TIPI,
            KIZ_COCUKLARDA_MENARS_YASI = dto.KIZ_COCUKLARDA_MENARS_YASI,
            BEYIN_ODEMI_DURUMU = dto.BEYIN_ODEMI_DURUMU,
            KETOASIDOZ_DURUMU = dto.KETOASIDOZ_DURUMU,
            DIYABET_SIKAYET = dto.DIYABET_SIKAYET,
            SIKAYETIN_SURESI = dto.SIKAYETIN_SURESI,
            AKSILLER_KILLANMA_DURUMU = dto.AKSILLER_KILLANMA_DURUMU,
            PUBIK_KILLANMA_DURUMU = dto.PUBIK_KILLANMA_DURUMU,
            MEME_EVRE = dto.MEME_EVRE,
            TESTIS_VOLUM_SAG = dto.TESTIS_VOLUM_SAG,
            TESTIS_VOLUM_SOL = dto.TESTIS_VOLUM_SOL,
            ESLIKEDEN_HASTALIK = dto.ESLIKEDEN_HASTALIK,
            ESLIKEDEN_HASTALIK_TANI_TARIHI = dto.ESLIKEDEN_HASTALIK_TANI_TARIHI,
            DIYABET_ILAC_TEDAVI_SEKLI = dto.DIYABET_ILAC_TEDAVI_SEKLI,
            DIYET_TIBBI_BESLENME_TEDAVISI = dto.DIYET_TIBBI_BESLENME_TEDAVISI,
            DIYABETLI_HASTA_AILE_OYKUSU = dto.DIYABETLI_HASTA_AILE_OYKUSU,
            DIYABET_EGITIMI_VERILME_DURUMU = dto.DIYABET_EGITIMI_VERILME_DURUMU,
            TIROID_MUAYENESI = dto.TIROID_MUAYENESI,
            DIYABET_KOMPLIKASYONLARI = dto.DIYABET_KOMPLIKASYONLARI,
        };

        _db.Set<COCUK_DIYABET>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.COCUK_DIYABET_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.CocukDiyabet)]
    public async Task<IActionResult> Update(string id, CocukDiyabetDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<COCUK_DIYABET>()
            .FirstOrDefaultAsync(e => e.COCUK_DIYABET_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.ILK_TANI_TARIHI = dto.ILK_TANI_TARIHI;
        entity.AGIRLIK = dto.AGIRLIK;
        entity.BOY = dto.BOY;
        entity.DIYABET_TIPI = dto.DIYABET_TIPI;
        entity.KIZ_COCUKLARDA_MENARS_YASI = dto.KIZ_COCUKLARDA_MENARS_YASI;
        entity.BEYIN_ODEMI_DURUMU = dto.BEYIN_ODEMI_DURUMU;
        entity.KETOASIDOZ_DURUMU = dto.KETOASIDOZ_DURUMU;
        entity.DIYABET_SIKAYET = dto.DIYABET_SIKAYET;
        entity.SIKAYETIN_SURESI = dto.SIKAYETIN_SURESI;
        entity.AKSILLER_KILLANMA_DURUMU = dto.AKSILLER_KILLANMA_DURUMU;
        entity.PUBIK_KILLANMA_DURUMU = dto.PUBIK_KILLANMA_DURUMU;
        entity.MEME_EVRE = dto.MEME_EVRE;
        entity.TESTIS_VOLUM_SAG = dto.TESTIS_VOLUM_SAG;
        entity.TESTIS_VOLUM_SOL = dto.TESTIS_VOLUM_SOL;
        entity.ESLIKEDEN_HASTALIK = dto.ESLIKEDEN_HASTALIK;
        entity.ESLIKEDEN_HASTALIK_TANI_TARIHI = dto.ESLIKEDEN_HASTALIK_TANI_TARIHI;
        entity.DIYABET_ILAC_TEDAVI_SEKLI = dto.DIYABET_ILAC_TEDAVI_SEKLI;
        entity.DIYET_TIBBI_BESLENME_TEDAVISI = dto.DIYET_TIBBI_BESLENME_TEDAVISI;
        entity.DIYABETLI_HASTA_AILE_OYKUSU = dto.DIYABETLI_HASTA_AILE_OYKUSU;
        entity.DIYABET_EGITIMI_VERILME_DURUMU = dto.DIYABET_EGITIMI_VERILME_DURUMU;
        entity.TIROID_MUAYENESI = dto.TIROID_MUAYENESI;
        entity.DIYABET_KOMPLIKASYONLARI = dto.DIYABET_KOMPLIKASYONLARI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.CocukDiyabet)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<COCUK_DIYABET>()
            .FirstOrDefaultAsync(e => e.COCUK_DIYABET_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<COCUK_DIYABET>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
