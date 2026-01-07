using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.HastaBasvuru;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class HastaBasvuruController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public HastaBasvuruController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.HastaBasvuru)]
    public async Task<List<HastaBasvuruDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<HASTA_BASVURU>()
            .AsNoTracking()
            .Select(e => new HastaBasvuruDto
            {
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                HASTA_KODU = e.HASTA_KODU,
                BASVURU_TARIHI = e.BASVURU_TARIHI,
                BASVURU_TURU = e.BASVURU_TURU,
                BASVURU_SEKLI = e.BASVURU_SEKLI,
                BIRIM_KODU = e.BIRIM_KODU,
                DOKTOR_KODU = e.DOKTOR_KODU,
                SIKAYET = e.SIKAYET,
                TANI_KODU = e.TANI_KODU,
                TEDAVI_TURU = e.TEDAVI_TURU,
                SEVK_EDEN_KURUM = e.SEVK_EDEN_KURUM,
                PROVIZYON_TIPI = e.PROVIZYON_TIPI,
                TAKIP_NO = e.TAKIP_NO,
                CIKIS_TARIHI = e.CIKIS_TARIHI,
                CIKIS_SEKLI = e.CIKIS_SEKLI,
                SONUC_KODU = e.SONUC_KODU,
                AKTIF = e.AKTIF,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.HastaBasvuru)]
    public async Task<ActionResult<HastaBasvuruDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_BASVURU>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.HASTA_BASVURU_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new HastaBasvuruDto
        {
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            HASTA_KODU = entity.HASTA_KODU,
            BASVURU_TARIHI = entity.BASVURU_TARIHI,
            BASVURU_TURU = entity.BASVURU_TURU,
            BASVURU_SEKLI = entity.BASVURU_SEKLI,
            BIRIM_KODU = entity.BIRIM_KODU,
            DOKTOR_KODU = entity.DOKTOR_KODU,
            SIKAYET = entity.SIKAYET,
            TANI_KODU = entity.TANI_KODU,
            TEDAVI_TURU = entity.TEDAVI_TURU,
            SEVK_EDEN_KURUM = entity.SEVK_EDEN_KURUM,
            PROVIZYON_TIPI = entity.PROVIZYON_TIPI,
            TAKIP_NO = entity.TAKIP_NO,
            CIKIS_TARIHI = entity.CIKIS_TARIHI,
            CIKIS_SEKLI = entity.CIKIS_SEKLI,
            SONUC_KODU = entity.SONUC_KODU,
            AKTIF = entity.AKTIF,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.HastaBasvuru)]
    public async Task<ActionResult<string>> Create(HastaBasvuruDto dto, CancellationToken ct)
    {
        var entity = new HASTA_BASVURU
        {
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            HASTA_KODU = dto.HASTA_KODU,
            BASVURU_TARIHI = dto.BASVURU_TARIHI,
            BASVURU_TURU = dto.BASVURU_TURU,
            BASVURU_SEKLI = dto.BASVURU_SEKLI,
            BIRIM_KODU = dto.BIRIM_KODU,
            DOKTOR_KODU = dto.DOKTOR_KODU,
            SIKAYET = dto.SIKAYET,
            TANI_KODU = dto.TANI_KODU,
            TEDAVI_TURU = dto.TEDAVI_TURU,
            SEVK_EDEN_KURUM = dto.SEVK_EDEN_KURUM,
            PROVIZYON_TIPI = dto.PROVIZYON_TIPI,
            TAKIP_NO = dto.TAKIP_NO,
            CIKIS_TARIHI = dto.CIKIS_TARIHI,
            CIKIS_SEKLI = dto.CIKIS_SEKLI,
            SONUC_KODU = dto.SONUC_KODU,
            AKTIF = dto.AKTIF,
        };

        _db.Set<HASTA_BASVURU>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.HASTA_BASVURU_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.HastaBasvuru)]
    public async Task<IActionResult> Update(string id, HastaBasvuruDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_BASVURU>()
            .FirstOrDefaultAsync(e => e.HASTA_BASVURU_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.BASVURU_TARIHI = dto.BASVURU_TARIHI;
        entity.BASVURU_TURU = dto.BASVURU_TURU;
        entity.BASVURU_SEKLI = dto.BASVURU_SEKLI;
        entity.BIRIM_KODU = dto.BIRIM_KODU;
        entity.DOKTOR_KODU = dto.DOKTOR_KODU;
        entity.SIKAYET = dto.SIKAYET;
        entity.TANI_KODU = dto.TANI_KODU;
        entity.TEDAVI_TURU = dto.TEDAVI_TURU;
        entity.SEVK_EDEN_KURUM = dto.SEVK_EDEN_KURUM;
        entity.PROVIZYON_TIPI = dto.PROVIZYON_TIPI;
        entity.TAKIP_NO = dto.TAKIP_NO;
        entity.CIKIS_TARIHI = dto.CIKIS_TARIHI;
        entity.CIKIS_SEKLI = dto.CIKIS_SEKLI;
        entity.SONUC_KODU = dto.SONUC_KODU;
        entity.AKTIF = dto.AKTIF;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.HastaBasvuru)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_BASVURU>()
            .FirstOrDefaultAsync(e => e.HASTA_BASVURU_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<HASTA_BASVURU>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
