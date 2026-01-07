using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.KanTalep;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class KanTalepController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public KanTalepController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.KanTalep)]
    public async Task<List<KanTalepDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<KAN_TALEP>()
            .AsNoTracking()
            .Select(e => new KanTalepDto
            {
                KAN_TALEP_KODU = e.KAN_TALEP_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                KAN_TALEP_ZAMANI = e.KAN_TALEP_ZAMANI,
                KAN_TALEP_ACIKLAMA = e.KAN_TALEP_ACIKLAMA,
                KAN_TALEP_NEDENI = e.KAN_TALEP_NEDENI,
                KAN_ISTEYEN_BIRIM_KODU = e.KAN_ISTEYEN_BIRIM_KODU,
                ISTEYEN_HEKIM_KODU = e.ISTEYEN_HEKIM_KODU,
                ISTENEN_KAN_GRUBU = e.ISTENEN_KAN_GRUBU,
                PLANLANAN_TRANSFUZYON_ZAMANI = e.PLANLANAN_TRANSFUZYON_ZAMANI,
                PLANLANAN_TRANSFUZYON_SURESI = e.PLANLANAN_TRANSFUZYON_SURESI,
                KAN_TALEP_ACILIYET_SEVIYESI = e.KAN_TALEP_ACILIYET_SEVIYESI,
                CROSS_MATCH_YAPILMA_DURUMU = e.CROSS_MATCH_YAPILMA_DURUMU,
                KAN_ACIL_ACIKLAMA = e.KAN_ACIL_ACIKLAMA,
                KAN_ANTIKOR_DURUMU = e.KAN_ANTIKOR_DURUMU,
                TRANSPLANTASYON_GECIRME_DURUMU = e.TRANSPLANTASYON_GECIRME_DURUMU,
                TRANSFUZYON_GECIRME_DURUMU = e.TRANSFUZYON_GECIRME_DURUMU,
                TRANSFUZYON_REAKSIYON_DURUMU = e.TRANSFUZYON_REAKSIYON_DURUMU,
                GEBELIK_GECIRME_DURUMU = e.GEBELIK_GECIRME_DURUMU,
                FETOMATERNAL_UYUSMAZLIK_DURUMU = e.FETOMATERNAL_UYUSMAZLIK_DURUMU,
                KAN_TALEP_OZEL_DURUM = e.KAN_TALEP_OZEL_DURUM,
                HEMATOKRIT_ORANI = e.HEMATOKRIT_ORANI,
                TROMBOSIT_SAYISI = e.TROMBOSIT_SAYISI,
                KAN_ENDIKASYON_TURU = e.KAN_ENDIKASYON_TURU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.KanTalep)]
    public async Task<ActionResult<KanTalepDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KAN_TALEP>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.KAN_TALEP_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new KanTalepDto
        {
            KAN_TALEP_KODU = entity.KAN_TALEP_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            KAN_TALEP_ZAMANI = entity.KAN_TALEP_ZAMANI,
            KAN_TALEP_ACIKLAMA = entity.KAN_TALEP_ACIKLAMA,
            KAN_TALEP_NEDENI = entity.KAN_TALEP_NEDENI,
            KAN_ISTEYEN_BIRIM_KODU = entity.KAN_ISTEYEN_BIRIM_KODU,
            ISTEYEN_HEKIM_KODU = entity.ISTEYEN_HEKIM_KODU,
            ISTENEN_KAN_GRUBU = entity.ISTENEN_KAN_GRUBU,
            PLANLANAN_TRANSFUZYON_ZAMANI = entity.PLANLANAN_TRANSFUZYON_ZAMANI,
            PLANLANAN_TRANSFUZYON_SURESI = entity.PLANLANAN_TRANSFUZYON_SURESI,
            KAN_TALEP_ACILIYET_SEVIYESI = entity.KAN_TALEP_ACILIYET_SEVIYESI,
            CROSS_MATCH_YAPILMA_DURUMU = entity.CROSS_MATCH_YAPILMA_DURUMU,
            KAN_ACIL_ACIKLAMA = entity.KAN_ACIL_ACIKLAMA,
            KAN_ANTIKOR_DURUMU = entity.KAN_ANTIKOR_DURUMU,
            TRANSPLANTASYON_GECIRME_DURUMU = entity.TRANSPLANTASYON_GECIRME_DURUMU,
            TRANSFUZYON_GECIRME_DURUMU = entity.TRANSFUZYON_GECIRME_DURUMU,
            TRANSFUZYON_REAKSIYON_DURUMU = entity.TRANSFUZYON_REAKSIYON_DURUMU,
            GEBELIK_GECIRME_DURUMU = entity.GEBELIK_GECIRME_DURUMU,
            FETOMATERNAL_UYUSMAZLIK_DURUMU = entity.FETOMATERNAL_UYUSMAZLIK_DURUMU,
            KAN_TALEP_OZEL_DURUM = entity.KAN_TALEP_OZEL_DURUM,
            HEMATOKRIT_ORANI = entity.HEMATOKRIT_ORANI,
            TROMBOSIT_SAYISI = entity.TROMBOSIT_SAYISI,
            KAN_ENDIKASYON_TURU = entity.KAN_ENDIKASYON_TURU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.KanTalep)]
    public async Task<ActionResult<string>> Create(KanTalepDto dto, CancellationToken ct)
    {
        var entity = new KAN_TALEP
        {
            KAN_TALEP_KODU = dto.KAN_TALEP_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            KAN_TALEP_ZAMANI = dto.KAN_TALEP_ZAMANI,
            KAN_TALEP_ACIKLAMA = dto.KAN_TALEP_ACIKLAMA,
            KAN_TALEP_NEDENI = dto.KAN_TALEP_NEDENI,
            KAN_ISTEYEN_BIRIM_KODU = dto.KAN_ISTEYEN_BIRIM_KODU,
            ISTEYEN_HEKIM_KODU = dto.ISTEYEN_HEKIM_KODU,
            ISTENEN_KAN_GRUBU = dto.ISTENEN_KAN_GRUBU,
            PLANLANAN_TRANSFUZYON_ZAMANI = dto.PLANLANAN_TRANSFUZYON_ZAMANI,
            PLANLANAN_TRANSFUZYON_SURESI = dto.PLANLANAN_TRANSFUZYON_SURESI,
            KAN_TALEP_ACILIYET_SEVIYESI = dto.KAN_TALEP_ACILIYET_SEVIYESI,
            CROSS_MATCH_YAPILMA_DURUMU = dto.CROSS_MATCH_YAPILMA_DURUMU,
            KAN_ACIL_ACIKLAMA = dto.KAN_ACIL_ACIKLAMA,
            KAN_ANTIKOR_DURUMU = dto.KAN_ANTIKOR_DURUMU,
            TRANSPLANTASYON_GECIRME_DURUMU = dto.TRANSPLANTASYON_GECIRME_DURUMU,
            TRANSFUZYON_GECIRME_DURUMU = dto.TRANSFUZYON_GECIRME_DURUMU,
            TRANSFUZYON_REAKSIYON_DURUMU = dto.TRANSFUZYON_REAKSIYON_DURUMU,
            GEBELIK_GECIRME_DURUMU = dto.GEBELIK_GECIRME_DURUMU,
            FETOMATERNAL_UYUSMAZLIK_DURUMU = dto.FETOMATERNAL_UYUSMAZLIK_DURUMU,
            KAN_TALEP_OZEL_DURUM = dto.KAN_TALEP_OZEL_DURUM,
            HEMATOKRIT_ORANI = dto.HEMATOKRIT_ORANI,
            TROMBOSIT_SAYISI = dto.TROMBOSIT_SAYISI,
            KAN_ENDIKASYON_TURU = dto.KAN_ENDIKASYON_TURU,
        };

        _db.Set<KAN_TALEP>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.KAN_TALEP_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.KanTalep)]
    public async Task<IActionResult> Update(string id, KanTalepDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<KAN_TALEP>()
            .FirstOrDefaultAsync(e => e.KAN_TALEP_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.KAN_TALEP_ZAMANI = dto.KAN_TALEP_ZAMANI;
        entity.KAN_TALEP_ACIKLAMA = dto.KAN_TALEP_ACIKLAMA;
        entity.KAN_TALEP_NEDENI = dto.KAN_TALEP_NEDENI;
        entity.KAN_ISTEYEN_BIRIM_KODU = dto.KAN_ISTEYEN_BIRIM_KODU;
        entity.ISTEYEN_HEKIM_KODU = dto.ISTEYEN_HEKIM_KODU;
        entity.ISTENEN_KAN_GRUBU = dto.ISTENEN_KAN_GRUBU;
        entity.PLANLANAN_TRANSFUZYON_ZAMANI = dto.PLANLANAN_TRANSFUZYON_ZAMANI;
        entity.PLANLANAN_TRANSFUZYON_SURESI = dto.PLANLANAN_TRANSFUZYON_SURESI;
        entity.KAN_TALEP_ACILIYET_SEVIYESI = dto.KAN_TALEP_ACILIYET_SEVIYESI;
        entity.CROSS_MATCH_YAPILMA_DURUMU = dto.CROSS_MATCH_YAPILMA_DURUMU;
        entity.KAN_ACIL_ACIKLAMA = dto.KAN_ACIL_ACIKLAMA;
        entity.KAN_ANTIKOR_DURUMU = dto.KAN_ANTIKOR_DURUMU;
        entity.TRANSPLANTASYON_GECIRME_DURUMU = dto.TRANSPLANTASYON_GECIRME_DURUMU;
        entity.TRANSFUZYON_GECIRME_DURUMU = dto.TRANSFUZYON_GECIRME_DURUMU;
        entity.TRANSFUZYON_REAKSIYON_DURUMU = dto.TRANSFUZYON_REAKSIYON_DURUMU;
        entity.GEBELIK_GECIRME_DURUMU = dto.GEBELIK_GECIRME_DURUMU;
        entity.FETOMATERNAL_UYUSMAZLIK_DURUMU = dto.FETOMATERNAL_UYUSMAZLIK_DURUMU;
        entity.KAN_TALEP_OZEL_DURUM = dto.KAN_TALEP_OZEL_DURUM;
        entity.HEMATOKRIT_ORANI = dto.HEMATOKRIT_ORANI;
        entity.TROMBOSIT_SAYISI = dto.TROMBOSIT_SAYISI;
        entity.KAN_ENDIKASYON_TURU = dto.KAN_ENDIKASYON_TURU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.KanTalep)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KAN_TALEP>()
            .FirstOrDefaultAsync(e => e.KAN_TALEP_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<KAN_TALEP>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
