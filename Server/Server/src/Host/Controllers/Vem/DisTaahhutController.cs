using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.DisTaahhut;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class DisTaahhutController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public DisTaahhutController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.DisTaahhut)]
    public async Task<List<DisTaahhutDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<DIS_TAAHHUT>()
            .AsNoTracking()
            .Select(e => new DisTaahhutDto
            {
                DIS_TAAHHUT_KODU = e.DIS_TAAHHUT_KODU,
HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                HASTA_KODU = e.HASTA_KODU,
                HEKIM_KODU = e.HEKIM_KODU,
                DIS_TAAHHUT_NUMARASI = e.DIS_TAAHHUT_NUMARASI,
                SGK_TAKIP_NUMARASI = e.SGK_TAKIP_NUMARASI,
                CADDE_SOKAK = e.CADDE_SOKAK,
                DIS_KAPI_NUMARASI = e.DIS_KAPI_NUMARASI,
                EPOSTA_ADRESI = e.EPOSTA_ADRESI,
                IC_KAPI_NUMARASI = e.IC_KAPI_NUMARASI,
                IL_KODU = e.IL_KODU,
                TELEFON_NUMARASI = e.TELEFON_NUMARASI,
                ILCE_KODU = e.ILCE_KODU,
                MEDULA_SONUC_KODU = e.MEDULA_SONUC_KODU,
                MEDULA_SONUC_MESAJI = e.MEDULA_SONUC_MESAJI,
                IPTAL_DURUMU = e.IPTAL_DURUMU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.DisTaahhut)]
    public async Task<ActionResult<DisTaahhutDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<DIS_TAAHHUT>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.DIS_TAAHHUT_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new DisTaahhutDto
        {
            DIS_TAAHHUT_KODU = entity.DIS_TAAHHUT_KODU,
HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            HASTA_KODU = entity.HASTA_KODU,
            HEKIM_KODU = entity.HEKIM_KODU,
            DIS_TAAHHUT_NUMARASI = entity.DIS_TAAHHUT_NUMARASI,
            SGK_TAKIP_NUMARASI = entity.SGK_TAKIP_NUMARASI,
            CADDE_SOKAK = entity.CADDE_SOKAK,
            DIS_KAPI_NUMARASI = entity.DIS_KAPI_NUMARASI,
            EPOSTA_ADRESI = entity.EPOSTA_ADRESI,
            IC_KAPI_NUMARASI = entity.IC_KAPI_NUMARASI,
            IL_KODU = entity.IL_KODU,
            TELEFON_NUMARASI = entity.TELEFON_NUMARASI,
            ILCE_KODU = entity.ILCE_KODU,
            MEDULA_SONUC_KODU = entity.MEDULA_SONUC_KODU,
            MEDULA_SONUC_MESAJI = entity.MEDULA_SONUC_MESAJI,
            IPTAL_DURUMU = entity.IPTAL_DURUMU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.DisTaahhut)]
    public async Task<ActionResult<string>> Create(DisTaahhutDto dto, CancellationToken ct)
    {
        var entity = new DIS_TAAHHUT
        {
            DIS_TAAHHUT_KODU = dto.DIS_TAAHHUT_KODU,
HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            HASTA_KODU = dto.HASTA_KODU,
            HEKIM_KODU = dto.HEKIM_KODU,
            DIS_TAAHHUT_NUMARASI = dto.DIS_TAAHHUT_NUMARASI,
            SGK_TAKIP_NUMARASI = dto.SGK_TAKIP_NUMARASI,
            CADDE_SOKAK = dto.CADDE_SOKAK,
            DIS_KAPI_NUMARASI = dto.DIS_KAPI_NUMARASI,
            EPOSTA_ADRESI = dto.EPOSTA_ADRESI,
            IC_KAPI_NUMARASI = dto.IC_KAPI_NUMARASI,
            IL_KODU = dto.IL_KODU,
            TELEFON_NUMARASI = dto.TELEFON_NUMARASI,
            ILCE_KODU = dto.ILCE_KODU,
            MEDULA_SONUC_KODU = dto.MEDULA_SONUC_KODU,
            MEDULA_SONUC_MESAJI = dto.MEDULA_SONUC_MESAJI,
            IPTAL_DURUMU = dto.IPTAL_DURUMU,
        };

        _db.Set<DIS_TAAHHUT>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.DIS_TAAHHUT_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.DisTaahhut)]
    public async Task<IActionResult> Update(string id, DisTaahhutDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<DIS_TAAHHUT>()
            .FirstOrDefaultAsync(e => e.DIS_TAAHHUT_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HEKIM_KODU = dto.HEKIM_KODU;
        entity.DIS_TAAHHUT_NUMARASI = dto.DIS_TAAHHUT_NUMARASI;
        entity.SGK_TAKIP_NUMARASI = dto.SGK_TAKIP_NUMARASI;
        entity.CADDE_SOKAK = dto.CADDE_SOKAK;
        entity.DIS_KAPI_NUMARASI = dto.DIS_KAPI_NUMARASI;
        entity.EPOSTA_ADRESI = dto.EPOSTA_ADRESI;
        entity.IC_KAPI_NUMARASI = dto.IC_KAPI_NUMARASI;
        entity.IL_KODU = dto.IL_KODU;
        entity.TELEFON_NUMARASI = dto.TELEFON_NUMARASI;
        entity.ILCE_KODU = dto.ILCE_KODU;
        entity.MEDULA_SONUC_KODU = dto.MEDULA_SONUC_KODU;
        entity.MEDULA_SONUC_MESAJI = dto.MEDULA_SONUC_MESAJI;
        entity.IPTAL_DURUMU = dto.IPTAL_DURUMU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.DisTaahhut)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<DIS_TAAHHUT>()
            .FirstOrDefaultAsync(e => e.DIS_TAAHHUT_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<DIS_TAAHHUT>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
