using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.HastaSevk;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class HastaSevkController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public HastaSevkController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.HastaSevk)]
    public async Task<List<HastaSevkDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<HASTA_SEVK>()
            .AsNoTracking()
            .Select(e => new HastaSevkDto
            {
                HASTA_SEVK_KODU = e.HASTA_SEVK_KODU,
HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                SEVK_TAKIP_NUMARASI = e.SEVK_TAKIP_NUMARASI,
                SEVK_NEDENI = e.SEVK_NEDENI,
                SEVK_EDILEN_BRANS_KODU = e.SEVK_EDILEN_BRANS_KODU,
                SEVK_EDILEN_KURUM_KODU = e.SEVK_EDILEN_KURUM_KODU,
                SEVK_ZAMANI = e.SEVK_ZAMANI,
                SEVK_TANISI = e.SEVK_TANISI,
                SEVK_SEKLI = e.SEVK_SEKLI,
                SEVK_VASITASI_KODU = e.SEVK_VASITASI_KODU,
                SEVK_TEDAVI_TIPI = e.SEVK_TEDAVI_TIPI,
                SEVK_ACIKLAMA = e.SEVK_ACIKLAMA,
                SEVK_EDEN_1_PERSONEL_KODU = e.SEVK_EDEN_1_PERSONEL_KODU,
                SEVK_EDEN_2_PERSONEL_KODU = e.SEVK_EDEN_2_PERSONEL_KODU,
                SEVK_EDEN_3_PERSONEL_KODU = e.SEVK_EDEN_3_PERSONEL_KODU,
                REFAKATCI_DURUMU = e.REFAKATCI_DURUMU,
                MEDULA_E_SEVK_NUMARASI = e.MEDULA_E_SEVK_NUMARASI,
                AMBULANS_PROTOKOL_NUMARASI = e.AMBULANS_PROTOKOL_NUMARASI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.HastaSevk)]
    public async Task<ActionResult<HastaSevkDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_SEVK>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.HASTA_SEVK_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new HastaSevkDto
        {
            HASTA_SEVK_KODU = entity.HASTA_SEVK_KODU,
HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            SEVK_TAKIP_NUMARASI = entity.SEVK_TAKIP_NUMARASI,
            SEVK_NEDENI = entity.SEVK_NEDENI,
            SEVK_EDILEN_BRANS_KODU = entity.SEVK_EDILEN_BRANS_KODU,
            SEVK_EDILEN_KURUM_KODU = entity.SEVK_EDILEN_KURUM_KODU,
            SEVK_ZAMANI = entity.SEVK_ZAMANI,
            SEVK_TANISI = entity.SEVK_TANISI,
            SEVK_SEKLI = entity.SEVK_SEKLI,
            SEVK_VASITASI_KODU = entity.SEVK_VASITASI_KODU,
            SEVK_TEDAVI_TIPI = entity.SEVK_TEDAVI_TIPI,
            SEVK_ACIKLAMA = entity.SEVK_ACIKLAMA,
            SEVK_EDEN_1_PERSONEL_KODU = entity.SEVK_EDEN_1_PERSONEL_KODU,
            SEVK_EDEN_2_PERSONEL_KODU = entity.SEVK_EDEN_2_PERSONEL_KODU,
            SEVK_EDEN_3_PERSONEL_KODU = entity.SEVK_EDEN_3_PERSONEL_KODU,
            REFAKATCI_DURUMU = entity.REFAKATCI_DURUMU,
            MEDULA_E_SEVK_NUMARASI = entity.MEDULA_E_SEVK_NUMARASI,
            AMBULANS_PROTOKOL_NUMARASI = entity.AMBULANS_PROTOKOL_NUMARASI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.HastaSevk)]
    public async Task<ActionResult<string>> Create(HastaSevkDto dto, CancellationToken ct)
    {
        var entity = new HASTA_SEVK
        {
            HASTA_SEVK_KODU = dto.HASTA_SEVK_KODU,
HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            SEVK_TAKIP_NUMARASI = dto.SEVK_TAKIP_NUMARASI,
            SEVK_NEDENI = dto.SEVK_NEDENI,
            SEVK_EDILEN_BRANS_KODU = dto.SEVK_EDILEN_BRANS_KODU,
            SEVK_EDILEN_KURUM_KODU = dto.SEVK_EDILEN_KURUM_KODU,
            SEVK_ZAMANI = dto.SEVK_ZAMANI,
            SEVK_TANISI = dto.SEVK_TANISI,
            SEVK_SEKLI = dto.SEVK_SEKLI,
            SEVK_VASITASI_KODU = dto.SEVK_VASITASI_KODU,
            SEVK_TEDAVI_TIPI = dto.SEVK_TEDAVI_TIPI,
            SEVK_ACIKLAMA = dto.SEVK_ACIKLAMA,
            SEVK_EDEN_1_PERSONEL_KODU = dto.SEVK_EDEN_1_PERSONEL_KODU,
            SEVK_EDEN_2_PERSONEL_KODU = dto.SEVK_EDEN_2_PERSONEL_KODU,
            SEVK_EDEN_3_PERSONEL_KODU = dto.SEVK_EDEN_3_PERSONEL_KODU,
            REFAKATCI_DURUMU = dto.REFAKATCI_DURUMU,
            MEDULA_E_SEVK_NUMARASI = dto.MEDULA_E_SEVK_NUMARASI,
            AMBULANS_PROTOKOL_NUMARASI = dto.AMBULANS_PROTOKOL_NUMARASI,
        };

        _db.Set<HASTA_SEVK>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.HASTA_SEVK_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.HastaSevk)]
    public async Task<IActionResult> Update(string id, HastaSevkDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_SEVK>()
            .FirstOrDefaultAsync(e => e.HASTA_SEVK_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.SEVK_TAKIP_NUMARASI = dto.SEVK_TAKIP_NUMARASI;
        entity.SEVK_NEDENI = dto.SEVK_NEDENI;
        entity.SEVK_EDILEN_BRANS_KODU = dto.SEVK_EDILEN_BRANS_KODU;
        entity.SEVK_EDILEN_KURUM_KODU = dto.SEVK_EDILEN_KURUM_KODU;
        entity.SEVK_ZAMANI = dto.SEVK_ZAMANI;
        entity.SEVK_TANISI = dto.SEVK_TANISI;
        entity.SEVK_SEKLI = dto.SEVK_SEKLI;
        entity.SEVK_VASITASI_KODU = dto.SEVK_VASITASI_KODU;
        entity.SEVK_TEDAVI_TIPI = dto.SEVK_TEDAVI_TIPI;
        entity.SEVK_ACIKLAMA = dto.SEVK_ACIKLAMA;
        entity.SEVK_EDEN_1_PERSONEL_KODU = dto.SEVK_EDEN_1_PERSONEL_KODU;
        entity.SEVK_EDEN_2_PERSONEL_KODU = dto.SEVK_EDEN_2_PERSONEL_KODU;
        entity.SEVK_EDEN_3_PERSONEL_KODU = dto.SEVK_EDEN_3_PERSONEL_KODU;
        entity.REFAKATCI_DURUMU = dto.REFAKATCI_DURUMU;
        entity.MEDULA_E_SEVK_NUMARASI = dto.MEDULA_E_SEVK_NUMARASI;
        entity.AMBULANS_PROTOKOL_NUMARASI = dto.AMBULANS_PROTOKOL_NUMARASI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.HastaSevk)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_SEVK>()
            .FirstOrDefaultAsync(e => e.HASTA_SEVK_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<HASTA_SEVK>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
