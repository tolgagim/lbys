using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.OptikRecete;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class OptikReceteController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public OptikReceteController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.OptikRecete)]
    public async Task<List<OptikReceteDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<OPTIK_RECETE>()
            .AsNoTracking()
            .Select(e => new OptikReceteDto
            {
                OPTIK_RECETE_KODU = e.OPTIK_RECETE_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                HASTA_KODU = e.HASTA_KODU,
                GOZLUK_RECETE_TIPI = e.GOZLUK_RECETE_TIPI,
                HEKIM_KODU = e.HEKIM_KODU,
                RECETE_ZAMANI = e.RECETE_ZAMANI,
                GOZLUK_TURU = e.GOZLUK_TURU,
                SAG_CAM_TIPI = e.SAG_CAM_TIPI,
                SAG_CAM_RENGI = e.SAG_CAM_RENGI,
                SAG_CAM_SFERIK = e.SAG_CAM_SFERIK,
                SAG_CAM_SILINDIRIK = e.SAG_CAM_SILINDIRIK,
                SAG_CAM_AKS = e.SAG_CAM_AKS,
                SOL_CAM_TIPI = e.SOL_CAM_TIPI,
                SOL_CAM_RENGI = e.SOL_CAM_RENGI,
                SOL_CAM_SFERIK = e.SOL_CAM_SFERIK,
                SOL_CAM_SILINDIRIK = e.SOL_CAM_SILINDIRIK,
                SOL_CAM_AKS = e.SOL_CAM_AKS,
                SAG_LENS_CAM_SFERIK = e.SAG_LENS_CAM_SFERIK,
                SAG_LENS_CAM_SILINDIRIK = e.SAG_LENS_CAM_SILINDIRIK,
                SAG_LENS_CAM_CAP = e.SAG_LENS_CAM_CAP,
                SAG_LENS_CAM_EGIM = e.SAG_LENS_CAM_EGIM,
                SAG_LENS_CAM_AKS = e.SAG_LENS_CAM_AKS,
                SOL_LENS_CAM_SFERIK = e.SOL_LENS_CAM_SFERIK,
                SOL_LENS_CAM_SILINDIRIK = e.SOL_LENS_CAM_SILINDIRIK,
                SOL_LENS_CAM_CAP = e.SOL_LENS_CAM_CAP,
                SOL_LENS_CAM_EGIM = e.SOL_LENS_CAM_EGIM,
                SOL_LENS_CAM_AKS = e.SOL_LENS_CAM_AKS,
                SAG_KERATAKONUS_CAM_SFERIK = e.SAG_KERATAKONUS_CAM_SFERIK,
                SAG_KERATAKONUS_CAM_SILINDIR = e.SAG_KERATAKONUS_CAM_SILINDIR,
                SAG_KERATAKONUS_CAM_CAP = e.SAG_KERATAKONUS_CAM_CAP,
                SAG_KERATAKONUS_CAM_EGIM = e.SAG_KERATAKONUS_CAM_EGIM,
                SAG_KERATAKONUS_CAM_AKS = e.SAG_KERATAKONUS_CAM_AKS,
                SOL_KERATAKONUS_CAM_SFERIK = e.SOL_KERATAKONUS_CAM_SFERIK,
                SOL_KERATAKONUS_CAM_SILINDIR = e.SOL_KERATAKONUS_CAM_SILINDIR,
                SOL_KERATAKONUS_CAM_CAP = e.SOL_KERATAKONUS_CAM_CAP,
                SOL_KERATAKONUS_CAM_EGIM = e.SOL_KERATAKONUS_CAM_EGIM,
                SOL_KERATAKONUS_CAM_AKS = e.SOL_KERATAKONUS_CAM_AKS,
                TELESKOPIK_GOZLUK_TIPI = e.TELESKOPIK_GOZLUK_TIPI,
                TELESKOPIK_GOZLUK_TURU = e.TELESKOPIK_GOZLUK_TURU,
                TELESKOPIK_SAG_CAM = e.TELESKOPIK_SAG_CAM,
                TELESKOPIK_SOL_CAM = e.TELESKOPIK_SOL_CAM,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.OptikRecete)]
    public async Task<ActionResult<OptikReceteDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<OPTIK_RECETE>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.OPTIK_RECETE_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new OptikReceteDto
        {
            OPTIK_RECETE_KODU = entity.OPTIK_RECETE_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            HASTA_KODU = entity.HASTA_KODU,
            GOZLUK_RECETE_TIPI = entity.GOZLUK_RECETE_TIPI,
            HEKIM_KODU = entity.HEKIM_KODU,
            RECETE_ZAMANI = entity.RECETE_ZAMANI,
            GOZLUK_TURU = entity.GOZLUK_TURU,
            SAG_CAM_TIPI = entity.SAG_CAM_TIPI,
            SAG_CAM_RENGI = entity.SAG_CAM_RENGI,
            SAG_CAM_SFERIK = entity.SAG_CAM_SFERIK,
            SAG_CAM_SILINDIRIK = entity.SAG_CAM_SILINDIRIK,
            SAG_CAM_AKS = entity.SAG_CAM_AKS,
            SOL_CAM_TIPI = entity.SOL_CAM_TIPI,
            SOL_CAM_RENGI = entity.SOL_CAM_RENGI,
            SOL_CAM_SFERIK = entity.SOL_CAM_SFERIK,
            SOL_CAM_SILINDIRIK = entity.SOL_CAM_SILINDIRIK,
            SOL_CAM_AKS = entity.SOL_CAM_AKS,
            SAG_LENS_CAM_SFERIK = entity.SAG_LENS_CAM_SFERIK,
            SAG_LENS_CAM_SILINDIRIK = entity.SAG_LENS_CAM_SILINDIRIK,
            SAG_LENS_CAM_CAP = entity.SAG_LENS_CAM_CAP,
            SAG_LENS_CAM_EGIM = entity.SAG_LENS_CAM_EGIM,
            SAG_LENS_CAM_AKS = entity.SAG_LENS_CAM_AKS,
            SOL_LENS_CAM_SFERIK = entity.SOL_LENS_CAM_SFERIK,
            SOL_LENS_CAM_SILINDIRIK = entity.SOL_LENS_CAM_SILINDIRIK,
            SOL_LENS_CAM_CAP = entity.SOL_LENS_CAM_CAP,
            SOL_LENS_CAM_EGIM = entity.SOL_LENS_CAM_EGIM,
            SOL_LENS_CAM_AKS = entity.SOL_LENS_CAM_AKS,
            SAG_KERATAKONUS_CAM_SFERIK = entity.SAG_KERATAKONUS_CAM_SFERIK,
            SAG_KERATAKONUS_CAM_SILINDIR = entity.SAG_KERATAKONUS_CAM_SILINDIR,
            SAG_KERATAKONUS_CAM_CAP = entity.SAG_KERATAKONUS_CAM_CAP,
            SAG_KERATAKONUS_CAM_EGIM = entity.SAG_KERATAKONUS_CAM_EGIM,
            SAG_KERATAKONUS_CAM_AKS = entity.SAG_KERATAKONUS_CAM_AKS,
            SOL_KERATAKONUS_CAM_SFERIK = entity.SOL_KERATAKONUS_CAM_SFERIK,
            SOL_KERATAKONUS_CAM_SILINDIR = entity.SOL_KERATAKONUS_CAM_SILINDIR,
            SOL_KERATAKONUS_CAM_CAP = entity.SOL_KERATAKONUS_CAM_CAP,
            SOL_KERATAKONUS_CAM_EGIM = entity.SOL_KERATAKONUS_CAM_EGIM,
            SOL_KERATAKONUS_CAM_AKS = entity.SOL_KERATAKONUS_CAM_AKS,
            TELESKOPIK_GOZLUK_TIPI = entity.TELESKOPIK_GOZLUK_TIPI,
            TELESKOPIK_GOZLUK_TURU = entity.TELESKOPIK_GOZLUK_TURU,
            TELESKOPIK_SAG_CAM = entity.TELESKOPIK_SAG_CAM,
            TELESKOPIK_SOL_CAM = entity.TELESKOPIK_SOL_CAM,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.OptikRecete)]
    public async Task<ActionResult<string>> Create(OptikReceteDto dto, CancellationToken ct)
    {
        var entity = new OPTIK_RECETE
        {
            OPTIK_RECETE_KODU = dto.OPTIK_RECETE_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            HASTA_KODU = dto.HASTA_KODU,
            GOZLUK_RECETE_TIPI = dto.GOZLUK_RECETE_TIPI,
            HEKIM_KODU = dto.HEKIM_KODU,
            RECETE_ZAMANI = dto.RECETE_ZAMANI,
            GOZLUK_TURU = dto.GOZLUK_TURU,
            SAG_CAM_TIPI = dto.SAG_CAM_TIPI,
            SAG_CAM_RENGI = dto.SAG_CAM_RENGI,
            SAG_CAM_SFERIK = dto.SAG_CAM_SFERIK,
            SAG_CAM_SILINDIRIK = dto.SAG_CAM_SILINDIRIK,
            SAG_CAM_AKS = dto.SAG_CAM_AKS,
            SOL_CAM_TIPI = dto.SOL_CAM_TIPI,
            SOL_CAM_RENGI = dto.SOL_CAM_RENGI,
            SOL_CAM_SFERIK = dto.SOL_CAM_SFERIK,
            SOL_CAM_SILINDIRIK = dto.SOL_CAM_SILINDIRIK,
            SOL_CAM_AKS = dto.SOL_CAM_AKS,
            SAG_LENS_CAM_SFERIK = dto.SAG_LENS_CAM_SFERIK,
            SAG_LENS_CAM_SILINDIRIK = dto.SAG_LENS_CAM_SILINDIRIK,
            SAG_LENS_CAM_CAP = dto.SAG_LENS_CAM_CAP,
            SAG_LENS_CAM_EGIM = dto.SAG_LENS_CAM_EGIM,
            SAG_LENS_CAM_AKS = dto.SAG_LENS_CAM_AKS,
            SOL_LENS_CAM_SFERIK = dto.SOL_LENS_CAM_SFERIK,
            SOL_LENS_CAM_SILINDIRIK = dto.SOL_LENS_CAM_SILINDIRIK,
            SOL_LENS_CAM_CAP = dto.SOL_LENS_CAM_CAP,
            SOL_LENS_CAM_EGIM = dto.SOL_LENS_CAM_EGIM,
            SOL_LENS_CAM_AKS = dto.SOL_LENS_CAM_AKS,
            SAG_KERATAKONUS_CAM_SFERIK = dto.SAG_KERATAKONUS_CAM_SFERIK,
            SAG_KERATAKONUS_CAM_SILINDIR = dto.SAG_KERATAKONUS_CAM_SILINDIR,
            SAG_KERATAKONUS_CAM_CAP = dto.SAG_KERATAKONUS_CAM_CAP,
            SAG_KERATAKONUS_CAM_EGIM = dto.SAG_KERATAKONUS_CAM_EGIM,
            SAG_KERATAKONUS_CAM_AKS = dto.SAG_KERATAKONUS_CAM_AKS,
            SOL_KERATAKONUS_CAM_SFERIK = dto.SOL_KERATAKONUS_CAM_SFERIK,
            SOL_KERATAKONUS_CAM_SILINDIR = dto.SOL_KERATAKONUS_CAM_SILINDIR,
            SOL_KERATAKONUS_CAM_CAP = dto.SOL_KERATAKONUS_CAM_CAP,
            SOL_KERATAKONUS_CAM_EGIM = dto.SOL_KERATAKONUS_CAM_EGIM,
            SOL_KERATAKONUS_CAM_AKS = dto.SOL_KERATAKONUS_CAM_AKS,
            TELESKOPIK_GOZLUK_TIPI = dto.TELESKOPIK_GOZLUK_TIPI,
            TELESKOPIK_GOZLUK_TURU = dto.TELESKOPIK_GOZLUK_TURU,
            TELESKOPIK_SAG_CAM = dto.TELESKOPIK_SAG_CAM,
            TELESKOPIK_SOL_CAM = dto.TELESKOPIK_SOL_CAM,
        };

        _db.Set<OPTIK_RECETE>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.OPTIK_RECETE_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.OptikRecete)]
    public async Task<IActionResult> Update(string id, OptikReceteDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<OPTIK_RECETE>()
            .FirstOrDefaultAsync(e => e.OPTIK_RECETE_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.GOZLUK_RECETE_TIPI = dto.GOZLUK_RECETE_TIPI;
        entity.HEKIM_KODU = dto.HEKIM_KODU;
        entity.RECETE_ZAMANI = dto.RECETE_ZAMANI;
        entity.GOZLUK_TURU = dto.GOZLUK_TURU;
        entity.SAG_CAM_TIPI = dto.SAG_CAM_TIPI;
        entity.SAG_CAM_RENGI = dto.SAG_CAM_RENGI;
        entity.SAG_CAM_SFERIK = dto.SAG_CAM_SFERIK;
        entity.SAG_CAM_SILINDIRIK = dto.SAG_CAM_SILINDIRIK;
        entity.SAG_CAM_AKS = dto.SAG_CAM_AKS;
        entity.SOL_CAM_TIPI = dto.SOL_CAM_TIPI;
        entity.SOL_CAM_RENGI = dto.SOL_CAM_RENGI;
        entity.SOL_CAM_SFERIK = dto.SOL_CAM_SFERIK;
        entity.SOL_CAM_SILINDIRIK = dto.SOL_CAM_SILINDIRIK;
        entity.SOL_CAM_AKS = dto.SOL_CAM_AKS;
        entity.SAG_LENS_CAM_SFERIK = dto.SAG_LENS_CAM_SFERIK;
        entity.SAG_LENS_CAM_SILINDIRIK = dto.SAG_LENS_CAM_SILINDIRIK;
        entity.SAG_LENS_CAM_CAP = dto.SAG_LENS_CAM_CAP;
        entity.SAG_LENS_CAM_EGIM = dto.SAG_LENS_CAM_EGIM;
        entity.SAG_LENS_CAM_AKS = dto.SAG_LENS_CAM_AKS;
        entity.SOL_LENS_CAM_SFERIK = dto.SOL_LENS_CAM_SFERIK;
        entity.SOL_LENS_CAM_SILINDIRIK = dto.SOL_LENS_CAM_SILINDIRIK;
        entity.SOL_LENS_CAM_CAP = dto.SOL_LENS_CAM_CAP;
        entity.SOL_LENS_CAM_EGIM = dto.SOL_LENS_CAM_EGIM;
        entity.SOL_LENS_CAM_AKS = dto.SOL_LENS_CAM_AKS;
        entity.SAG_KERATAKONUS_CAM_SFERIK = dto.SAG_KERATAKONUS_CAM_SFERIK;
        entity.SAG_KERATAKONUS_CAM_SILINDIR = dto.SAG_KERATAKONUS_CAM_SILINDIR;
        entity.SAG_KERATAKONUS_CAM_CAP = dto.SAG_KERATAKONUS_CAM_CAP;
        entity.SAG_KERATAKONUS_CAM_EGIM = dto.SAG_KERATAKONUS_CAM_EGIM;
        entity.SAG_KERATAKONUS_CAM_AKS = dto.SAG_KERATAKONUS_CAM_AKS;
        entity.SOL_KERATAKONUS_CAM_SFERIK = dto.SOL_KERATAKONUS_CAM_SFERIK;
        entity.SOL_KERATAKONUS_CAM_SILINDIR = dto.SOL_KERATAKONUS_CAM_SILINDIR;
        entity.SOL_KERATAKONUS_CAM_CAP = dto.SOL_KERATAKONUS_CAM_CAP;
        entity.SOL_KERATAKONUS_CAM_EGIM = dto.SOL_KERATAKONUS_CAM_EGIM;
        entity.SOL_KERATAKONUS_CAM_AKS = dto.SOL_KERATAKONUS_CAM_AKS;
        entity.TELESKOPIK_GOZLUK_TIPI = dto.TELESKOPIK_GOZLUK_TIPI;
        entity.TELESKOPIK_GOZLUK_TURU = dto.TELESKOPIK_GOZLUK_TURU;
        entity.TELESKOPIK_SAG_CAM = dto.TELESKOPIK_SAG_CAM;
        entity.TELESKOPIK_SOL_CAM = dto.TELESKOPIK_SOL_CAM;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.OptikRecete)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<OPTIK_RECETE>()
            .FirstOrDefaultAsync(e => e.OPTIK_RECETE_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<OPTIK_RECETE>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
