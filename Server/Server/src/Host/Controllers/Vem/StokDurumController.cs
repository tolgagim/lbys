using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.StokDurum;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class StokDurumController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public StokDurumController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.StokDurum)]
    public async Task<List<StokDurumDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<STOK_DURUM>()
            .AsNoTracking()
            .Select(e => new StokDurumDto
            {
                STOK_DURUM_KODU = e.STOK_DURUM_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                DEPO_KODU = e.DEPO_KODU,
                STOK_KART_KODU = e.STOK_KART_KODU,
                MAKSIMUM_STOK = e.MAKSIMUM_STOK,
                MINIMUM_STOK = e.MINIMUM_STOK,
                KRITIK_STOK = e.KRITIK_STOK,
                TOPLAM_GIRIS_MIKTARI = e.TOPLAM_GIRIS_MIKTARI,
                TOPLAM_CIKIS_MIKTARI = e.TOPLAM_CIKIS_MIKTARI,
                STOK_MIKTARI = e.STOK_MIKTARI,
                OLCU_KODU = e.OLCU_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.StokDurum)]
    public async Task<ActionResult<StokDurumDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STOK_DURUM>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.STOK_DURUM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new StokDurumDto
        {
            STOK_DURUM_KODU = entity.STOK_DURUM_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            DEPO_KODU = entity.DEPO_KODU,
            STOK_KART_KODU = entity.STOK_KART_KODU,
            MAKSIMUM_STOK = entity.MAKSIMUM_STOK,
            MINIMUM_STOK = entity.MINIMUM_STOK,
            KRITIK_STOK = entity.KRITIK_STOK,
            TOPLAM_GIRIS_MIKTARI = entity.TOPLAM_GIRIS_MIKTARI,
            TOPLAM_CIKIS_MIKTARI = entity.TOPLAM_CIKIS_MIKTARI,
            STOK_MIKTARI = entity.STOK_MIKTARI,
            OLCU_KODU = entity.OLCU_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.StokDurum)]
    public async Task<ActionResult<string>> Create(StokDurumDto dto, CancellationToken ct)
    {
        var entity = new STOK_DURUM
        {
            STOK_DURUM_KODU = dto.STOK_DURUM_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            DEPO_KODU = dto.DEPO_KODU,
            STOK_KART_KODU = dto.STOK_KART_KODU,
            MAKSIMUM_STOK = dto.MAKSIMUM_STOK,
            MINIMUM_STOK = dto.MINIMUM_STOK,
            KRITIK_STOK = dto.KRITIK_STOK,
            TOPLAM_GIRIS_MIKTARI = dto.TOPLAM_GIRIS_MIKTARI,
            TOPLAM_CIKIS_MIKTARI = dto.TOPLAM_CIKIS_MIKTARI,
            STOK_MIKTARI = dto.STOK_MIKTARI,
            OLCU_KODU = dto.OLCU_KODU,
        };

        _db.Set<STOK_DURUM>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.STOK_DURUM_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.StokDurum)]
    public async Task<IActionResult> Update(string id, StokDurumDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<STOK_DURUM>()
            .FirstOrDefaultAsync(e => e.STOK_DURUM_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.DEPO_KODU = dto.DEPO_KODU;
        entity.STOK_KART_KODU = dto.STOK_KART_KODU;
        entity.MAKSIMUM_STOK = dto.MAKSIMUM_STOK;
        entity.MINIMUM_STOK = dto.MINIMUM_STOK;
        entity.KRITIK_STOK = dto.KRITIK_STOK;
        entity.TOPLAM_GIRIS_MIKTARI = dto.TOPLAM_GIRIS_MIKTARI;
        entity.TOPLAM_CIKIS_MIKTARI = dto.TOPLAM_CIKIS_MIKTARI;
        entity.STOK_MIKTARI = dto.STOK_MIKTARI;
        entity.OLCU_KODU = dto.OLCU_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.StokDurum)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STOK_DURUM>()
            .FirstOrDefaultAsync(e => e.STOK_DURUM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<STOK_DURUM>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
