using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Patoloji;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class PatolojiController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public PatolojiController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Patoloji)]
    public async Task<List<PatolojiDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<PATOLOJI>()
            .AsNoTracking()
            .Select(e => new PatolojiDto
            {
                PATOLOJI_KODU = e.PATOLOJI_KODU,
HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                PATOLOJI_RAPOR_TURU = e.PATOLOJI_RAPOR_TURU,
                DOKUNUN_TEMEL_OZELLIGI = e.DOKUNUN_TEMEL_OZELLIGI,
                NUMUNE_ALINMA_SEKLI = e.NUMUNE_ALINMA_SEKLI,
                PATOLOJI_PREPARATI_DURUMU = e.PATOLOJI_PREPARATI_DURUMU,
                PATOLOJI_DEFTER_NUMARASI = e.PATOLOJI_DEFTER_NUMARASI,
                TETKIK_NUMUNE_KODU = e.TETKIK_NUMUNE_KODU,
                PATOLOJI_MATERYALI = e.PATOLOJI_MATERYALI,
                ORGAN = e.ORGAN,
                NUMUNE_ALINMA_YERI = e.NUMUNE_ALINMA_YERI,
                PATOLOJIK_BULGU = e.PATOLOJIK_BULGU,
                PATOLOJIK_TANI_MORFOLOJI_KODU = e.PATOLOJIK_TANI_MORFOLOJI_KODU,
                PATOLOJIK_TANI_YERLESIM_YERI = e.PATOLOJIK_TANI_YERLESIM_YERI,
                MAKROSKOPI_SONUCU = e.MAKROSKOPI_SONUCU,
                MIKROSKOPI_SONUCU = e.MIKROSKOPI_SONUCU,
                SONUC_ICERIK_TURU = e.SONUC_ICERIK_TURU,
                RAPOR_YAZAN_PERSONEL_KODU = e.RAPOR_YAZAN_PERSONEL_KODU,
                PARCA_KABUL_ZAMANI = e.PARCA_KABUL_ZAMANI,
                RAPOR_ZAMANI = e.RAPOR_ZAMANI,
                PATOLOJI_ACIKLAMA = e.PATOLOJI_ACIKLAMA,
                HISTOPATOLOJIK_TANI = e.HISTOPATOLOJIK_TANI,
                SITOPATOLOJIK_TANI = e.SITOPATOLOJIK_TANI,
                HISTOKIMYASAL_BOYAMA = e.HISTOKIMYASAL_BOYAMA,
                IMMUNHISTOKIMYA_BOYAMA = e.IMMUNHISTOKIMYA_BOYAMA,
                FROZEN_TANI = e.FROZEN_TANI,
                NUMUNE_BOYAMA_YONTEMI = e.NUMUNE_BOYAMA_YONTEMI,
                ONAYLAYAN_HEKIM_KODU = e.ONAYLAYAN_HEKIM_KODU,
                ASISTAN_HEKIM_KODU = e.ASISTAN_HEKIM_KODU,
                PATOLOJI_DIGER_HEKIM_KODU = e.PATOLOJI_DIGER_HEKIM_KODU,
                YORUM = e.YORUM,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Patoloji)]
    public async Task<ActionResult<PatolojiDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<PATOLOJI>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.PATOLOJI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new PatolojiDto
        {
            PATOLOJI_KODU = entity.PATOLOJI_KODU,
HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            PATOLOJI_RAPOR_TURU = entity.PATOLOJI_RAPOR_TURU,
            DOKUNUN_TEMEL_OZELLIGI = entity.DOKUNUN_TEMEL_OZELLIGI,
            NUMUNE_ALINMA_SEKLI = entity.NUMUNE_ALINMA_SEKLI,
            PATOLOJI_PREPARATI_DURUMU = entity.PATOLOJI_PREPARATI_DURUMU,
            PATOLOJI_DEFTER_NUMARASI = entity.PATOLOJI_DEFTER_NUMARASI,
            TETKIK_NUMUNE_KODU = entity.TETKIK_NUMUNE_KODU,
            PATOLOJI_MATERYALI = entity.PATOLOJI_MATERYALI,
            ORGAN = entity.ORGAN,
            NUMUNE_ALINMA_YERI = entity.NUMUNE_ALINMA_YERI,
            PATOLOJIK_BULGU = entity.PATOLOJIK_BULGU,
            PATOLOJIK_TANI_MORFOLOJI_KODU = entity.PATOLOJIK_TANI_MORFOLOJI_KODU,
            PATOLOJIK_TANI_YERLESIM_YERI = entity.PATOLOJIK_TANI_YERLESIM_YERI,
            MAKROSKOPI_SONUCU = entity.MAKROSKOPI_SONUCU,
            MIKROSKOPI_SONUCU = entity.MIKROSKOPI_SONUCU,
            SONUC_ICERIK_TURU = entity.SONUC_ICERIK_TURU,
            RAPOR_YAZAN_PERSONEL_KODU = entity.RAPOR_YAZAN_PERSONEL_KODU,
            PARCA_KABUL_ZAMANI = entity.PARCA_KABUL_ZAMANI,
            RAPOR_ZAMANI = entity.RAPOR_ZAMANI,
            PATOLOJI_ACIKLAMA = entity.PATOLOJI_ACIKLAMA,
            HISTOPATOLOJIK_TANI = entity.HISTOPATOLOJIK_TANI,
            SITOPATOLOJIK_TANI = entity.SITOPATOLOJIK_TANI,
            HISTOKIMYASAL_BOYAMA = entity.HISTOKIMYASAL_BOYAMA,
            IMMUNHISTOKIMYA_BOYAMA = entity.IMMUNHISTOKIMYA_BOYAMA,
            FROZEN_TANI = entity.FROZEN_TANI,
            NUMUNE_BOYAMA_YONTEMI = entity.NUMUNE_BOYAMA_YONTEMI,
            ONAYLAYAN_HEKIM_KODU = entity.ONAYLAYAN_HEKIM_KODU,
            ASISTAN_HEKIM_KODU = entity.ASISTAN_HEKIM_KODU,
            PATOLOJI_DIGER_HEKIM_KODU = entity.PATOLOJI_DIGER_HEKIM_KODU,
            YORUM = entity.YORUM,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Patoloji)]
    public async Task<ActionResult<string>> Create(PatolojiDto dto, CancellationToken ct)
    {
        var entity = new PATOLOJI
        {
            PATOLOJI_KODU = dto.PATOLOJI_KODU,
HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            PATOLOJI_RAPOR_TURU = dto.PATOLOJI_RAPOR_TURU,
            DOKUNUN_TEMEL_OZELLIGI = dto.DOKUNUN_TEMEL_OZELLIGI,
            NUMUNE_ALINMA_SEKLI = dto.NUMUNE_ALINMA_SEKLI,
            PATOLOJI_PREPARATI_DURUMU = dto.PATOLOJI_PREPARATI_DURUMU,
            PATOLOJI_DEFTER_NUMARASI = dto.PATOLOJI_DEFTER_NUMARASI,
            TETKIK_NUMUNE_KODU = dto.TETKIK_NUMUNE_KODU,
            PATOLOJI_MATERYALI = dto.PATOLOJI_MATERYALI,
            ORGAN = dto.ORGAN,
            NUMUNE_ALINMA_YERI = dto.NUMUNE_ALINMA_YERI,
            PATOLOJIK_BULGU = dto.PATOLOJIK_BULGU,
            PATOLOJIK_TANI_MORFOLOJI_KODU = dto.PATOLOJIK_TANI_MORFOLOJI_KODU,
            PATOLOJIK_TANI_YERLESIM_YERI = dto.PATOLOJIK_TANI_YERLESIM_YERI,
            MAKROSKOPI_SONUCU = dto.MAKROSKOPI_SONUCU,
            MIKROSKOPI_SONUCU = dto.MIKROSKOPI_SONUCU,
            SONUC_ICERIK_TURU = dto.SONUC_ICERIK_TURU,
            RAPOR_YAZAN_PERSONEL_KODU = dto.RAPOR_YAZAN_PERSONEL_KODU,
            PARCA_KABUL_ZAMANI = dto.PARCA_KABUL_ZAMANI,
            RAPOR_ZAMANI = dto.RAPOR_ZAMANI,
            PATOLOJI_ACIKLAMA = dto.PATOLOJI_ACIKLAMA,
            HISTOPATOLOJIK_TANI = dto.HISTOPATOLOJIK_TANI,
            SITOPATOLOJIK_TANI = dto.SITOPATOLOJIK_TANI,
            HISTOKIMYASAL_BOYAMA = dto.HISTOKIMYASAL_BOYAMA,
            IMMUNHISTOKIMYA_BOYAMA = dto.IMMUNHISTOKIMYA_BOYAMA,
            FROZEN_TANI = dto.FROZEN_TANI,
            NUMUNE_BOYAMA_YONTEMI = dto.NUMUNE_BOYAMA_YONTEMI,
            ONAYLAYAN_HEKIM_KODU = dto.ONAYLAYAN_HEKIM_KODU,
            ASISTAN_HEKIM_KODU = dto.ASISTAN_HEKIM_KODU,
            PATOLOJI_DIGER_HEKIM_KODU = dto.PATOLOJI_DIGER_HEKIM_KODU,
            YORUM = dto.YORUM,
        };

        _db.Set<PATOLOJI>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.PATOLOJI_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Patoloji)]
    public async Task<IActionResult> Update(string id, PatolojiDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<PATOLOJI>()
            .FirstOrDefaultAsync(e => e.PATOLOJI_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.PATOLOJI_RAPOR_TURU = dto.PATOLOJI_RAPOR_TURU;
        entity.DOKUNUN_TEMEL_OZELLIGI = dto.DOKUNUN_TEMEL_OZELLIGI;
        entity.NUMUNE_ALINMA_SEKLI = dto.NUMUNE_ALINMA_SEKLI;
        entity.PATOLOJI_PREPARATI_DURUMU = dto.PATOLOJI_PREPARATI_DURUMU;
        entity.PATOLOJI_DEFTER_NUMARASI = dto.PATOLOJI_DEFTER_NUMARASI;
        entity.TETKIK_NUMUNE_KODU = dto.TETKIK_NUMUNE_KODU;
        entity.PATOLOJI_MATERYALI = dto.PATOLOJI_MATERYALI;
        entity.ORGAN = dto.ORGAN;
        entity.NUMUNE_ALINMA_YERI = dto.NUMUNE_ALINMA_YERI;
        entity.PATOLOJIK_BULGU = dto.PATOLOJIK_BULGU;
        entity.PATOLOJIK_TANI_MORFOLOJI_KODU = dto.PATOLOJIK_TANI_MORFOLOJI_KODU;
        entity.PATOLOJIK_TANI_YERLESIM_YERI = dto.PATOLOJIK_TANI_YERLESIM_YERI;
        entity.MAKROSKOPI_SONUCU = dto.MAKROSKOPI_SONUCU;
        entity.MIKROSKOPI_SONUCU = dto.MIKROSKOPI_SONUCU;
        entity.SONUC_ICERIK_TURU = dto.SONUC_ICERIK_TURU;
        entity.RAPOR_YAZAN_PERSONEL_KODU = dto.RAPOR_YAZAN_PERSONEL_KODU;
        entity.PARCA_KABUL_ZAMANI = dto.PARCA_KABUL_ZAMANI;
        entity.RAPOR_ZAMANI = dto.RAPOR_ZAMANI;
        entity.PATOLOJI_ACIKLAMA = dto.PATOLOJI_ACIKLAMA;
        entity.HISTOPATOLOJIK_TANI = dto.HISTOPATOLOJIK_TANI;
        entity.SITOPATOLOJIK_TANI = dto.SITOPATOLOJIK_TANI;
        entity.HISTOKIMYASAL_BOYAMA = dto.HISTOKIMYASAL_BOYAMA;
        entity.IMMUNHISTOKIMYA_BOYAMA = dto.IMMUNHISTOKIMYA_BOYAMA;
        entity.FROZEN_TANI = dto.FROZEN_TANI;
        entity.NUMUNE_BOYAMA_YONTEMI = dto.NUMUNE_BOYAMA_YONTEMI;
        entity.ONAYLAYAN_HEKIM_KODU = dto.ONAYLAYAN_HEKIM_KODU;
        entity.ASISTAN_HEKIM_KODU = dto.ASISTAN_HEKIM_KODU;
        entity.PATOLOJI_DIGER_HEKIM_KODU = dto.PATOLOJI_DIGER_HEKIM_KODU;
        entity.YORUM = dto.YORUM;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Patoloji)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<PATOLOJI>()
            .FirstOrDefaultAsync(e => e.PATOLOJI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<PATOLOJI>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
