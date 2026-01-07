using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Disprotez;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class DisprotezController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public DisprotezController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Disprotez)]
    public async Task<List<DisprotezDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<DISPROTEZ>()
            .AsNoTracking()
            .Select(e => new DisprotezDto
            {
                DISPROTEZ_KODU = e.DISPROTEZ_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                HASTA_KODU = e.HASTA_KODU,
                DISPROTEZ_BASLAMA_TARIHI = e.DISPROTEZ_BASLAMA_TARIHI,
                TEKNISYEN_KODU = e.TEKNISYEN_KODU,
                HEKIM_KODU = e.HEKIM_KODU,
                BIRIM_KODU = e.BIRIM_KODU,
                DISPROTEZ_IS_TURU_KODU = e.DISPROTEZ_IS_TURU_KODU,
                DISPROTEZ_IS_TURU_ALT_KODU = e.DISPROTEZ_IS_TURU_ALT_KODU,
                PARCA_SAYISI = e.PARCA_SAYISI,
                DISPROTEZ_AYAK_SAYISI = e.DISPROTEZ_AYAK_SAYISI,
                DISPROTEZ_GOVDE_SAYISI = e.DISPROTEZ_GOVDE_SAYISI,
                ACIKLAMA = e.ACIKLAMA,
                DISPROTEZ_BIRIM_KODU = e.DISPROTEZ_BIRIM_KODU,
                RPT_SEBEBI = e.RPT_SEBEBI,
                RPT_ZAMANI = e.RPT_ZAMANI,
                RPT_EDEN_PERSONEL_KODU = e.RPT_EDEN_PERSONEL_KODU,
                BARKOD_ZAMANI = e.BARKOD_ZAMANI,
                DISPROTEZ_KASIK_TURU = e.DISPROTEZ_KASIK_TURU,
                DISPROTEZ_RENGI = e.DISPROTEZ_RENGI,
                DIS_BOYUT_BILGISI = e.DIS_BOYUT_BILGISI,
                DISPROTEZ_ACIKLAMA = e.DISPROTEZ_ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Disprotez)]
    public async Task<ActionResult<DisprotezDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<DISPROTEZ>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.DISPROTEZ_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new DisprotezDto
        {
            DISPROTEZ_KODU = entity.DISPROTEZ_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            HASTA_KODU = entity.HASTA_KODU,
            DISPROTEZ_BASLAMA_TARIHI = entity.DISPROTEZ_BASLAMA_TARIHI,
            TEKNISYEN_KODU = entity.TEKNISYEN_KODU,
            HEKIM_KODU = entity.HEKIM_KODU,
            BIRIM_KODU = entity.BIRIM_KODU,
            DISPROTEZ_IS_TURU_KODU = entity.DISPROTEZ_IS_TURU_KODU,
            DISPROTEZ_IS_TURU_ALT_KODU = entity.DISPROTEZ_IS_TURU_ALT_KODU,
            PARCA_SAYISI = entity.PARCA_SAYISI,
            DISPROTEZ_AYAK_SAYISI = entity.DISPROTEZ_AYAK_SAYISI,
            DISPROTEZ_GOVDE_SAYISI = entity.DISPROTEZ_GOVDE_SAYISI,
            ACIKLAMA = entity.ACIKLAMA,
            DISPROTEZ_BIRIM_KODU = entity.DISPROTEZ_BIRIM_KODU,
            RPT_SEBEBI = entity.RPT_SEBEBI,
            RPT_ZAMANI = entity.RPT_ZAMANI,
            RPT_EDEN_PERSONEL_KODU = entity.RPT_EDEN_PERSONEL_KODU,
            BARKOD_ZAMANI = entity.BARKOD_ZAMANI,
            DISPROTEZ_KASIK_TURU = entity.DISPROTEZ_KASIK_TURU,
            DISPROTEZ_RENGI = entity.DISPROTEZ_RENGI,
            DIS_BOYUT_BILGISI = entity.DIS_BOYUT_BILGISI,
            DISPROTEZ_ACIKLAMA = entity.DISPROTEZ_ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Disprotez)]
    public async Task<ActionResult<string>> Create(DisprotezDto dto, CancellationToken ct)
    {
        var entity = new DISPROTEZ
        {
            DISPROTEZ_KODU = dto.DISPROTEZ_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            HASTA_KODU = dto.HASTA_KODU,
            DISPROTEZ_BASLAMA_TARIHI = dto.DISPROTEZ_BASLAMA_TARIHI,
            TEKNISYEN_KODU = dto.TEKNISYEN_KODU,
            HEKIM_KODU = dto.HEKIM_KODU,
            BIRIM_KODU = dto.BIRIM_KODU,
            DISPROTEZ_IS_TURU_KODU = dto.DISPROTEZ_IS_TURU_KODU,
            DISPROTEZ_IS_TURU_ALT_KODU = dto.DISPROTEZ_IS_TURU_ALT_KODU,
            PARCA_SAYISI = dto.PARCA_SAYISI,
            DISPROTEZ_AYAK_SAYISI = dto.DISPROTEZ_AYAK_SAYISI,
            DISPROTEZ_GOVDE_SAYISI = dto.DISPROTEZ_GOVDE_SAYISI,
            ACIKLAMA = dto.ACIKLAMA,
            DISPROTEZ_BIRIM_KODU = dto.DISPROTEZ_BIRIM_KODU,
            RPT_SEBEBI = dto.RPT_SEBEBI,
            RPT_ZAMANI = dto.RPT_ZAMANI,
            RPT_EDEN_PERSONEL_KODU = dto.RPT_EDEN_PERSONEL_KODU,
            BARKOD_ZAMANI = dto.BARKOD_ZAMANI,
            DISPROTEZ_KASIK_TURU = dto.DISPROTEZ_KASIK_TURU,
            DISPROTEZ_RENGI = dto.DISPROTEZ_RENGI,
            DIS_BOYUT_BILGISI = dto.DIS_BOYUT_BILGISI,
            DISPROTEZ_ACIKLAMA = dto.DISPROTEZ_ACIKLAMA,
        };

        _db.Set<DISPROTEZ>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.DISPROTEZ_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Disprotez)]
    public async Task<IActionResult> Update(string id, DisprotezDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<DISPROTEZ>()
            .FirstOrDefaultAsync(e => e.DISPROTEZ_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.DISPROTEZ_BASLAMA_TARIHI = dto.DISPROTEZ_BASLAMA_TARIHI;
        entity.TEKNISYEN_KODU = dto.TEKNISYEN_KODU;
        entity.HEKIM_KODU = dto.HEKIM_KODU;
        entity.BIRIM_KODU = dto.BIRIM_KODU;
        entity.DISPROTEZ_IS_TURU_KODU = dto.DISPROTEZ_IS_TURU_KODU;
        entity.DISPROTEZ_IS_TURU_ALT_KODU = dto.DISPROTEZ_IS_TURU_ALT_KODU;
        entity.PARCA_SAYISI = dto.PARCA_SAYISI;
        entity.DISPROTEZ_AYAK_SAYISI = dto.DISPROTEZ_AYAK_SAYISI;
        entity.DISPROTEZ_GOVDE_SAYISI = dto.DISPROTEZ_GOVDE_SAYISI;
        entity.ACIKLAMA = dto.ACIKLAMA;
        entity.DISPROTEZ_BIRIM_KODU = dto.DISPROTEZ_BIRIM_KODU;
        entity.RPT_SEBEBI = dto.RPT_SEBEBI;
        entity.RPT_ZAMANI = dto.RPT_ZAMANI;
        entity.RPT_EDEN_PERSONEL_KODU = dto.RPT_EDEN_PERSONEL_KODU;
        entity.BARKOD_ZAMANI = dto.BARKOD_ZAMANI;
        entity.DISPROTEZ_KASIK_TURU = dto.DISPROTEZ_KASIK_TURU;
        entity.DISPROTEZ_RENGI = dto.DISPROTEZ_RENGI;
        entity.DIS_BOYUT_BILGISI = dto.DIS_BOYUT_BILGISI;
        entity.DISPROTEZ_ACIKLAMA = dto.DISPROTEZ_ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Disprotez)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<DISPROTEZ>()
            .FirstOrDefaultAsync(e => e.DISPROTEZ_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<DISPROTEZ>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
