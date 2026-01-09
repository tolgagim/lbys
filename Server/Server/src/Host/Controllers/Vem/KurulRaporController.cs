using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.KurulRapor;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class KurulRaporController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public KurulRaporController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.KurulRapor)]
    public async Task<List<KurulRaporDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<KURUL_RAPOR>()
            .AsNoTracking()
            .Select(e => new KurulRaporDto
            {
                KURUL_RAPOR_KODU = e.KURUL_RAPOR_KODU,
KURUL_KODU = e.KURUL_KODU,
                HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                RAPOR_ADI = e.RAPOR_ADI,
                RAPOR_ZAMANI = e.RAPOR_ZAMANI,
                ACIKLAMA = e.ACIKLAMA,
                RAPOR_KARAR_NUMARASI = e.RAPOR_KARAR_NUMARASI,
                RAPOR_SIRA_NUMARASI = e.RAPOR_SIRA_NUMARASI,
                RAPOR_TAKIP_NUMARASI = e.RAPOR_TAKIP_NUMARASI,
                KURUL_RAPOR_NUMARASI = e.KURUL_RAPOR_NUMARASI,
                RAPOR_BASLAMA_TARIHI = e.RAPOR_BASLAMA_TARIHI,
                RAPOR_BITIS_TARIHI = e.RAPOR_BITIS_TARIHI,
                LABORATUVAR_BULGU = e.LABORATUVAR_BULGU,
                KURUL_RAPOR_MUAYENE_BULGUSU = e.KURUL_RAPOR_MUAYENE_BULGUSU,
                KURUL_TANI_BILGISI = e.KURUL_TANI_BILGISI,
                KURUL_RAPOR_KARARI = e.KURUL_RAPOR_KARARI,
                KARAR_ICERIK_FORMATI = e.KARAR_ICERIK_FORMATI,
                MURACAAT_DURUMU = e.MURACAAT_DURUMU,
                ENGELLILIK_ORANI = e.ENGELLILIK_ORANI,
                ILAC_RAPOR_DUZELTME_ACIKLAMASI = e.ILAC_RAPOR_DUZELTME_ACIKLAMASI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.KurulRapor)]
    public async Task<ActionResult<KurulRaporDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KURUL_RAPOR>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.KURUL_RAPOR_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new KurulRaporDto
        {
            KURUL_RAPOR_KODU = entity.KURUL_RAPOR_KODU,
KURUL_KODU = entity.KURUL_KODU,
            HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            RAPOR_ADI = entity.RAPOR_ADI,
            RAPOR_ZAMANI = entity.RAPOR_ZAMANI,
            ACIKLAMA = entity.ACIKLAMA,
            RAPOR_KARAR_NUMARASI = entity.RAPOR_KARAR_NUMARASI,
            RAPOR_SIRA_NUMARASI = entity.RAPOR_SIRA_NUMARASI,
            RAPOR_TAKIP_NUMARASI = entity.RAPOR_TAKIP_NUMARASI,
            KURUL_RAPOR_NUMARASI = entity.KURUL_RAPOR_NUMARASI,
            RAPOR_BASLAMA_TARIHI = entity.RAPOR_BASLAMA_TARIHI,
            RAPOR_BITIS_TARIHI = entity.RAPOR_BITIS_TARIHI,
            LABORATUVAR_BULGU = entity.LABORATUVAR_BULGU,
            KURUL_RAPOR_MUAYENE_BULGUSU = entity.KURUL_RAPOR_MUAYENE_BULGUSU,
            KURUL_TANI_BILGISI = entity.KURUL_TANI_BILGISI,
            KURUL_RAPOR_KARARI = entity.KURUL_RAPOR_KARARI,
            KARAR_ICERIK_FORMATI = entity.KARAR_ICERIK_FORMATI,
            MURACAAT_DURUMU = entity.MURACAAT_DURUMU,
            ENGELLILIK_ORANI = entity.ENGELLILIK_ORANI,
            ILAC_RAPOR_DUZELTME_ACIKLAMASI = entity.ILAC_RAPOR_DUZELTME_ACIKLAMASI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.KurulRapor)]
    public async Task<ActionResult<string>> Create(KurulRaporDto dto, CancellationToken ct)
    {
        var entity = new KURUL_RAPOR
        {
            KURUL_RAPOR_KODU = dto.KURUL_RAPOR_KODU,
KURUL_KODU = dto.KURUL_KODU,
            HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            RAPOR_ADI = dto.RAPOR_ADI,
            RAPOR_ZAMANI = dto.RAPOR_ZAMANI,
            ACIKLAMA = dto.ACIKLAMA,
            RAPOR_KARAR_NUMARASI = dto.RAPOR_KARAR_NUMARASI,
            RAPOR_SIRA_NUMARASI = dto.RAPOR_SIRA_NUMARASI,
            RAPOR_TAKIP_NUMARASI = dto.RAPOR_TAKIP_NUMARASI,
            KURUL_RAPOR_NUMARASI = dto.KURUL_RAPOR_NUMARASI,
            RAPOR_BASLAMA_TARIHI = dto.RAPOR_BASLAMA_TARIHI,
            RAPOR_BITIS_TARIHI = dto.RAPOR_BITIS_TARIHI,
            LABORATUVAR_BULGU = dto.LABORATUVAR_BULGU,
            KURUL_RAPOR_MUAYENE_BULGUSU = dto.KURUL_RAPOR_MUAYENE_BULGUSU,
            KURUL_TANI_BILGISI = dto.KURUL_TANI_BILGISI,
            KURUL_RAPOR_KARARI = dto.KURUL_RAPOR_KARARI,
            KARAR_ICERIK_FORMATI = dto.KARAR_ICERIK_FORMATI,
            MURACAAT_DURUMU = dto.MURACAAT_DURUMU,
            ENGELLILIK_ORANI = dto.ENGELLILIK_ORANI,
            ILAC_RAPOR_DUZELTME_ACIKLAMASI = dto.ILAC_RAPOR_DUZELTME_ACIKLAMASI,
        };

        _db.Set<KURUL_RAPOR>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.KURUL_RAPOR_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.KurulRapor)]
    public async Task<IActionResult> Update(string id, KurulRaporDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<KURUL_RAPOR>()
            .FirstOrDefaultAsync(e => e.KURUL_RAPOR_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.KURUL_KODU = dto.KURUL_KODU;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.RAPOR_ADI = dto.RAPOR_ADI;
        entity.RAPOR_ZAMANI = dto.RAPOR_ZAMANI;
        entity.ACIKLAMA = dto.ACIKLAMA;
        entity.RAPOR_KARAR_NUMARASI = dto.RAPOR_KARAR_NUMARASI;
        entity.RAPOR_SIRA_NUMARASI = dto.RAPOR_SIRA_NUMARASI;
        entity.RAPOR_TAKIP_NUMARASI = dto.RAPOR_TAKIP_NUMARASI;
        entity.KURUL_RAPOR_NUMARASI = dto.KURUL_RAPOR_NUMARASI;
        entity.RAPOR_BASLAMA_TARIHI = dto.RAPOR_BASLAMA_TARIHI;
        entity.RAPOR_BITIS_TARIHI = dto.RAPOR_BITIS_TARIHI;
        entity.LABORATUVAR_BULGU = dto.LABORATUVAR_BULGU;
        entity.KURUL_RAPOR_MUAYENE_BULGUSU = dto.KURUL_RAPOR_MUAYENE_BULGUSU;
        entity.KURUL_TANI_BILGISI = dto.KURUL_TANI_BILGISI;
        entity.KURUL_RAPOR_KARARI = dto.KURUL_RAPOR_KARARI;
        entity.KARAR_ICERIK_FORMATI = dto.KARAR_ICERIK_FORMATI;
        entity.MURACAAT_DURUMU = dto.MURACAAT_DURUMU;
        entity.ENGELLILIK_ORANI = dto.ENGELLILIK_ORANI;
        entity.ILAC_RAPOR_DUZELTME_ACIKLAMASI = dto.ILAC_RAPOR_DUZELTME_ACIKLAMASI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.KurulRapor)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KURUL_RAPOR>()
            .FirstOrDefaultAsync(e => e.KURUL_RAPOR_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<KURUL_RAPOR>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
