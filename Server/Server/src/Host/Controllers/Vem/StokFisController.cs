using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.StokFis;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class StokFisController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public StokFisController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.StokFis)]
    public async Task<List<StokFisDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<STOK_FIS>()
            .AsNoTracking()
            .Select(e => new StokFisDto
            {
                STOK_FIS_KODU = e.STOK_FIS_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                BAGLI_STOK_FIS_KODU = e.BAGLI_STOK_FIS_KODU,
                DEPO_KODU = e.DEPO_KODU,
                HAREKET_TURU = e.HAREKET_TURU,
                MKYS_AYNIYAT_MAKBUZ_KODU = e.MKYS_AYNIYAT_MAKBUZ_KODU,
                HAREKET_TARIHI = e.HAREKET_TARIHI,
                SHCEK_PAYI = e.SHCEK_PAYI,
                HAZINE_PAYI = e.HAZINE_PAYI,
                SAGLIK_BAKANLIGI_PAYI = e.SAGLIK_BAKANLIGI_PAYI,
                BEDELSIZ_FIS = e.BEDELSIZ_FIS,
                FIS_TUTARI = e.FIS_TUTARI,
                HAREKET_SEKLI = e.HAREKET_SEKLI,
                ISLEMI_YAPAN_PERSONEL_KODU = e.ISLEMI_YAPAN_PERSONEL_KODU,
                ISLEM_ZAMANI = e.ISLEM_ZAMANI,
                FIRMA_KODU = e.FIRMA_KODU,
                IHALE_NUMARASI = e.IHALE_NUMARASI,
                IHALE_TARIHI = e.IHALE_TARIHI,
                IHALE_TURU = e.IHALE_TURU,
                MUAYENE_KABUL_NUMARASI = e.MUAYENE_KABUL_NUMARASI,
                MUAYENE_TARIHI = e.MUAYENE_TARIHI,
                TESLIM_EDEN_KISI = e.TESLIM_EDEN_KISI,
                TESLIM_EDEN_KISI_UNVANI = e.TESLIM_EDEN_KISI_UNVANI,
                BUTCE_TURU = e.BUTCE_TURU,
                FATURA_NUMARASI = e.FATURA_NUMARASI,
                FATURA_ZAMANI = e.FATURA_ZAMANI,
                IRSALIYE_NUMARASI = e.IRSALIYE_NUMARASI,
                IRSALIYE_TARIHI = e.IRSALIYE_TARIHI,
                MKYS_KURUM_KODU = e.MKYS_KURUM_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.StokFis)]
    public async Task<ActionResult<StokFisDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STOK_FIS>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.STOK_FIS_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new StokFisDto
        {
            STOK_FIS_KODU = entity.STOK_FIS_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            BAGLI_STOK_FIS_KODU = entity.BAGLI_STOK_FIS_KODU,
            DEPO_KODU = entity.DEPO_KODU,
            HAREKET_TURU = entity.HAREKET_TURU,
            MKYS_AYNIYAT_MAKBUZ_KODU = entity.MKYS_AYNIYAT_MAKBUZ_KODU,
            HAREKET_TARIHI = entity.HAREKET_TARIHI,
            SHCEK_PAYI = entity.SHCEK_PAYI,
            HAZINE_PAYI = entity.HAZINE_PAYI,
            SAGLIK_BAKANLIGI_PAYI = entity.SAGLIK_BAKANLIGI_PAYI,
            BEDELSIZ_FIS = entity.BEDELSIZ_FIS,
            FIS_TUTARI = entity.FIS_TUTARI,
            HAREKET_SEKLI = entity.HAREKET_SEKLI,
            ISLEMI_YAPAN_PERSONEL_KODU = entity.ISLEMI_YAPAN_PERSONEL_KODU,
            ISLEM_ZAMANI = entity.ISLEM_ZAMANI,
            FIRMA_KODU = entity.FIRMA_KODU,
            IHALE_NUMARASI = entity.IHALE_NUMARASI,
            IHALE_TARIHI = entity.IHALE_TARIHI,
            IHALE_TURU = entity.IHALE_TURU,
            MUAYENE_KABUL_NUMARASI = entity.MUAYENE_KABUL_NUMARASI,
            MUAYENE_TARIHI = entity.MUAYENE_TARIHI,
            TESLIM_EDEN_KISI = entity.TESLIM_EDEN_KISI,
            TESLIM_EDEN_KISI_UNVANI = entity.TESLIM_EDEN_KISI_UNVANI,
            BUTCE_TURU = entity.BUTCE_TURU,
            FATURA_NUMARASI = entity.FATURA_NUMARASI,
            FATURA_ZAMANI = entity.FATURA_ZAMANI,
            IRSALIYE_NUMARASI = entity.IRSALIYE_NUMARASI,
            IRSALIYE_TARIHI = entity.IRSALIYE_TARIHI,
            MKYS_KURUM_KODU = entity.MKYS_KURUM_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.StokFis)]
    public async Task<ActionResult<string>> Create(StokFisDto dto, CancellationToken ct)
    {
        var entity = new STOK_FIS
        {
            STOK_FIS_KODU = dto.STOK_FIS_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            BAGLI_STOK_FIS_KODU = dto.BAGLI_STOK_FIS_KODU,
            DEPO_KODU = dto.DEPO_KODU,
            HAREKET_TURU = dto.HAREKET_TURU,
            MKYS_AYNIYAT_MAKBUZ_KODU = dto.MKYS_AYNIYAT_MAKBUZ_KODU,
            HAREKET_TARIHI = dto.HAREKET_TARIHI,
            SHCEK_PAYI = dto.SHCEK_PAYI,
            HAZINE_PAYI = dto.HAZINE_PAYI,
            SAGLIK_BAKANLIGI_PAYI = dto.SAGLIK_BAKANLIGI_PAYI,
            BEDELSIZ_FIS = dto.BEDELSIZ_FIS,
            FIS_TUTARI = dto.FIS_TUTARI,
            HAREKET_SEKLI = dto.HAREKET_SEKLI,
            ISLEMI_YAPAN_PERSONEL_KODU = dto.ISLEMI_YAPAN_PERSONEL_KODU,
            ISLEM_ZAMANI = dto.ISLEM_ZAMANI,
            FIRMA_KODU = dto.FIRMA_KODU,
            IHALE_NUMARASI = dto.IHALE_NUMARASI,
            IHALE_TARIHI = dto.IHALE_TARIHI,
            IHALE_TURU = dto.IHALE_TURU,
            MUAYENE_KABUL_NUMARASI = dto.MUAYENE_KABUL_NUMARASI,
            MUAYENE_TARIHI = dto.MUAYENE_TARIHI,
            TESLIM_EDEN_KISI = dto.TESLIM_EDEN_KISI,
            TESLIM_EDEN_KISI_UNVANI = dto.TESLIM_EDEN_KISI_UNVANI,
            BUTCE_TURU = dto.BUTCE_TURU,
            FATURA_NUMARASI = dto.FATURA_NUMARASI,
            FATURA_ZAMANI = dto.FATURA_ZAMANI,
            IRSALIYE_NUMARASI = dto.IRSALIYE_NUMARASI,
            IRSALIYE_TARIHI = dto.IRSALIYE_TARIHI,
            MKYS_KURUM_KODU = dto.MKYS_KURUM_KODU,
        };

        _db.Set<STOK_FIS>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.STOK_FIS_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.StokFis)]
    public async Task<IActionResult> Update(string id, StokFisDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<STOK_FIS>()
            .FirstOrDefaultAsync(e => e.STOK_FIS_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.BAGLI_STOK_FIS_KODU = dto.BAGLI_STOK_FIS_KODU;
        entity.DEPO_KODU = dto.DEPO_KODU;
        entity.HAREKET_TURU = dto.HAREKET_TURU;
        entity.MKYS_AYNIYAT_MAKBUZ_KODU = dto.MKYS_AYNIYAT_MAKBUZ_KODU;
        entity.HAREKET_TARIHI = dto.HAREKET_TARIHI;
        entity.SHCEK_PAYI = dto.SHCEK_PAYI;
        entity.HAZINE_PAYI = dto.HAZINE_PAYI;
        entity.SAGLIK_BAKANLIGI_PAYI = dto.SAGLIK_BAKANLIGI_PAYI;
        entity.BEDELSIZ_FIS = dto.BEDELSIZ_FIS;
        entity.FIS_TUTARI = dto.FIS_TUTARI;
        entity.HAREKET_SEKLI = dto.HAREKET_SEKLI;
        entity.ISLEMI_YAPAN_PERSONEL_KODU = dto.ISLEMI_YAPAN_PERSONEL_KODU;
        entity.ISLEM_ZAMANI = dto.ISLEM_ZAMANI;
        entity.FIRMA_KODU = dto.FIRMA_KODU;
        entity.IHALE_NUMARASI = dto.IHALE_NUMARASI;
        entity.IHALE_TARIHI = dto.IHALE_TARIHI;
        entity.IHALE_TURU = dto.IHALE_TURU;
        entity.MUAYENE_KABUL_NUMARASI = dto.MUAYENE_KABUL_NUMARASI;
        entity.MUAYENE_TARIHI = dto.MUAYENE_TARIHI;
        entity.TESLIM_EDEN_KISI = dto.TESLIM_EDEN_KISI;
        entity.TESLIM_EDEN_KISI_UNVANI = dto.TESLIM_EDEN_KISI_UNVANI;
        entity.BUTCE_TURU = dto.BUTCE_TURU;
        entity.FATURA_NUMARASI = dto.FATURA_NUMARASI;
        entity.FATURA_ZAMANI = dto.FATURA_ZAMANI;
        entity.IRSALIYE_NUMARASI = dto.IRSALIYE_NUMARASI;
        entity.IRSALIYE_TARIHI = dto.IRSALIYE_TARIHI;
        entity.MKYS_KURUM_KODU = dto.MKYS_KURUM_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.StokFis)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STOK_FIS>()
            .FirstOrDefaultAsync(e => e.STOK_FIS_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<STOK_FIS>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
