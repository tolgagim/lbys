using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.KanStok;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class KanStokController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public KanStokController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.KanStok)]
    public async Task<List<KanStokDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<KAN_STOK>()
            .AsNoTracking()
            .Select(e => new KanStokDto
            {
                KAN_STOK_KODU = e.KAN_STOK_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                KAN_STOK_DURUMU = e.KAN_STOK_DURUMU,
                KAN_STOK_GIRIS_TARIHI = e.KAN_STOK_GIRIS_TARIHI,
                DEFTER_NUMARASI = e.DEFTER_NUMARASI,
                KAN_GRUBU = e.KAN_GRUBU,
                KAN_URUN_KODU = e.KAN_URUN_KODU,
                KAN_BAGISCI_KODU = e.KAN_BAGISCI_KODU,
                KURUM_KODU = e.KURUM_KODU,
                BIRIM_KODU = e.BIRIM_KODU,
                BAGLI_KAN_STOK_KODU = e.BAGLI_KAN_STOK_KODU,
                ISBT_UNITE_NUMARASI = e.ISBT_UNITE_NUMARASI,
                ISBT_BILESEN_NUMARASI = e.ISBT_BILESEN_NUMARASI,
                KAN_HACIM = e.KAN_HACIM,
                KAN_BAGIS_ZAMANI = e.KAN_BAGIS_ZAMANI,
                KAN_FILTRELEME_ZAMANI = e.KAN_FILTRELEME_ZAMANI,
                KAN_ISINLAMA_ZAMANI = e.KAN_ISINLAMA_ZAMANI,
                KAN_YIKAMA_ZAMANI = e.KAN_YIKAMA_ZAMANI,
                KAN_AYIRMA_ZAMANI = e.KAN_AYIRMA_ZAMANI,
                KAN_BOLME_ZAMANI = e.KAN_BOLME_ZAMANI,
                BUFFYCOAT_UZAKLASTIRMA_ZAMANI = e.BUFFYCOAT_UZAKLASTIRMA_ZAMANI,
                KAN_HAVUZLAMA_ZAMANI = e.KAN_HAVUZLAMA_ZAMANI,
                SON_KULLANMA_TARIHI = e.SON_KULLANMA_TARIHI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.KanStok)]
    public async Task<ActionResult<KanStokDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KAN_STOK>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.KAN_STOK_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new KanStokDto
        {
            KAN_STOK_KODU = entity.KAN_STOK_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            KAN_STOK_DURUMU = entity.KAN_STOK_DURUMU,
            KAN_STOK_GIRIS_TARIHI = entity.KAN_STOK_GIRIS_TARIHI,
            DEFTER_NUMARASI = entity.DEFTER_NUMARASI,
            KAN_GRUBU = entity.KAN_GRUBU,
            KAN_URUN_KODU = entity.KAN_URUN_KODU,
            KAN_BAGISCI_KODU = entity.KAN_BAGISCI_KODU,
            KURUM_KODU = entity.KURUM_KODU,
            BIRIM_KODU = entity.BIRIM_KODU,
            BAGLI_KAN_STOK_KODU = entity.BAGLI_KAN_STOK_KODU,
            ISBT_UNITE_NUMARASI = entity.ISBT_UNITE_NUMARASI,
            ISBT_BILESEN_NUMARASI = entity.ISBT_BILESEN_NUMARASI,
            KAN_HACIM = entity.KAN_HACIM,
            KAN_BAGIS_ZAMANI = entity.KAN_BAGIS_ZAMANI,
            KAN_FILTRELEME_ZAMANI = entity.KAN_FILTRELEME_ZAMANI,
            KAN_ISINLAMA_ZAMANI = entity.KAN_ISINLAMA_ZAMANI,
            KAN_YIKAMA_ZAMANI = entity.KAN_YIKAMA_ZAMANI,
            KAN_AYIRMA_ZAMANI = entity.KAN_AYIRMA_ZAMANI,
            KAN_BOLME_ZAMANI = entity.KAN_BOLME_ZAMANI,
            BUFFYCOAT_UZAKLASTIRMA_ZAMANI = entity.BUFFYCOAT_UZAKLASTIRMA_ZAMANI,
            KAN_HAVUZLAMA_ZAMANI = entity.KAN_HAVUZLAMA_ZAMANI,
            SON_KULLANMA_TARIHI = entity.SON_KULLANMA_TARIHI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.KanStok)]
    public async Task<ActionResult<string>> Create(KanStokDto dto, CancellationToken ct)
    {
        var entity = new KAN_STOK
        {
            KAN_STOK_KODU = dto.KAN_STOK_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            KAN_STOK_DURUMU = dto.KAN_STOK_DURUMU,
            KAN_STOK_GIRIS_TARIHI = dto.KAN_STOK_GIRIS_TARIHI,
            DEFTER_NUMARASI = dto.DEFTER_NUMARASI,
            KAN_GRUBU = dto.KAN_GRUBU,
            KAN_URUN_KODU = dto.KAN_URUN_KODU,
            KAN_BAGISCI_KODU = dto.KAN_BAGISCI_KODU,
            KURUM_KODU = dto.KURUM_KODU,
            BIRIM_KODU = dto.BIRIM_KODU,
            BAGLI_KAN_STOK_KODU = dto.BAGLI_KAN_STOK_KODU,
            ISBT_UNITE_NUMARASI = dto.ISBT_UNITE_NUMARASI,
            ISBT_BILESEN_NUMARASI = dto.ISBT_BILESEN_NUMARASI,
            KAN_HACIM = dto.KAN_HACIM,
            KAN_BAGIS_ZAMANI = dto.KAN_BAGIS_ZAMANI,
            KAN_FILTRELEME_ZAMANI = dto.KAN_FILTRELEME_ZAMANI,
            KAN_ISINLAMA_ZAMANI = dto.KAN_ISINLAMA_ZAMANI,
            KAN_YIKAMA_ZAMANI = dto.KAN_YIKAMA_ZAMANI,
            KAN_AYIRMA_ZAMANI = dto.KAN_AYIRMA_ZAMANI,
            KAN_BOLME_ZAMANI = dto.KAN_BOLME_ZAMANI,
            BUFFYCOAT_UZAKLASTIRMA_ZAMANI = dto.BUFFYCOAT_UZAKLASTIRMA_ZAMANI,
            KAN_HAVUZLAMA_ZAMANI = dto.KAN_HAVUZLAMA_ZAMANI,
            SON_KULLANMA_TARIHI = dto.SON_KULLANMA_TARIHI,
        };

        _db.Set<KAN_STOK>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.KAN_STOK_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.KanStok)]
    public async Task<IActionResult> Update(string id, KanStokDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<KAN_STOK>()
            .FirstOrDefaultAsync(e => e.KAN_STOK_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.KAN_STOK_DURUMU = dto.KAN_STOK_DURUMU;
        entity.KAN_STOK_GIRIS_TARIHI = dto.KAN_STOK_GIRIS_TARIHI;
        entity.DEFTER_NUMARASI = dto.DEFTER_NUMARASI;
        entity.KAN_GRUBU = dto.KAN_GRUBU;
        entity.KAN_URUN_KODU = dto.KAN_URUN_KODU;
        entity.KAN_BAGISCI_KODU = dto.KAN_BAGISCI_KODU;
        entity.KURUM_KODU = dto.KURUM_KODU;
        entity.BIRIM_KODU = dto.BIRIM_KODU;
        entity.BAGLI_KAN_STOK_KODU = dto.BAGLI_KAN_STOK_KODU;
        entity.ISBT_UNITE_NUMARASI = dto.ISBT_UNITE_NUMARASI;
        entity.ISBT_BILESEN_NUMARASI = dto.ISBT_BILESEN_NUMARASI;
        entity.KAN_HACIM = dto.KAN_HACIM;
        entity.KAN_BAGIS_ZAMANI = dto.KAN_BAGIS_ZAMANI;
        entity.KAN_FILTRELEME_ZAMANI = dto.KAN_FILTRELEME_ZAMANI;
        entity.KAN_ISINLAMA_ZAMANI = dto.KAN_ISINLAMA_ZAMANI;
        entity.KAN_YIKAMA_ZAMANI = dto.KAN_YIKAMA_ZAMANI;
        entity.KAN_AYIRMA_ZAMANI = dto.KAN_AYIRMA_ZAMANI;
        entity.KAN_BOLME_ZAMANI = dto.KAN_BOLME_ZAMANI;
        entity.BUFFYCOAT_UZAKLASTIRMA_ZAMANI = dto.BUFFYCOAT_UZAKLASTIRMA_ZAMANI;
        entity.KAN_HAVUZLAMA_ZAMANI = dto.KAN_HAVUZLAMA_ZAMANI;
        entity.SON_KULLANMA_TARIHI = dto.SON_KULLANMA_TARIHI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.KanStok)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KAN_STOK>()
            .FirstOrDefaultAsync(e => e.KAN_STOK_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<KAN_STOK>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
