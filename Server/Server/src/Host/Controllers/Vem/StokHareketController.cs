using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.StokHareket;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class StokHareketController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public StokHareketController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.StokHareket)]
    public async Task<List<StokHareketDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<STOK_HAREKET>()
            .AsNoTracking()
            .Select(e => new StokHareketDto
            {
                STOK_HAREKET_KODU = e.STOK_HAREKET_KODU,
BAGLI_STOK_HAREKET_KODU = e.BAGLI_STOK_HAREKET_KODU,
                ILK_GIRIS_STOK_HAREKET_KODU = e.ILK_GIRIS_STOK_HAREKET_KODU,
                STOK_ISTEK_HAREKET_KODU = e.STOK_ISTEK_HAREKET_KODU,
                STOK_FIS_KODU = e.STOK_FIS_KODU,
                STOK_KART_KODU = e.STOK_KART_KODU,
                BARKOD = e.BARKOD,
                LOT_NUMARASI = e.LOT_NUMARASI,
                SERI_SIRA_NUMARASI = e.SERI_SIRA_NUMARASI,
                FIRMA_TANIMLAYICI_NUMARASI = e.FIRMA_TANIMLAYICI_NUMARASI,
                MALZEME_SUT_KODU = e.MALZEME_SUT_KODU,
                STOK_HAREKET_MIKTARI = e.STOK_HAREKET_MIKTARI,
                TASINIR_NUMARASI = e.TASINIR_NUMARASI,
                ALIS_BIRIM_FIYATI = e.ALIS_BIRIM_FIYATI,
                SATIS_BIRIM_FIYATI = e.SATIS_BIRIM_FIYATI,
                OLCU_KODU = e.OLCU_KODU,
                ISLEMI_YAPAN_PERSONEL_KODU = e.ISLEMI_YAPAN_PERSONEL_KODU,
                KDV_ORANI = e.KDV_ORANI,
                ISKONTO_ORANI = e.ISKONTO_ORANI,
                ISKONTO_TUTARI = e.ISKONTO_TUTARI,
                SON_KULLANMA_TARIHI = e.SON_KULLANMA_TARIHI,
                MKYS_STOK_HAREKET_KODU = e.MKYS_STOK_HAREKET_KODU,
                IPTAL_DURUMU = e.IPTAL_DURUMU,
                MKYS_KARSI_STOK_HAREKET_KODU = e.MKYS_KARSI_STOK_HAREKET_KODU,
                MKYS_KUNYE_NUMARASI = e.MKYS_KUNYE_NUMARASI,
                UTS_KAYIT_UDI = e.UTS_KAYIT_UDI,
                BAYILIK_NUMARASI = e.BAYILIK_NUMARASI,
                CIHAZ_KODU = e.CIHAZ_KODU,
                ATS_SORGU_NUMARASI = e.ATS_SORGU_NUMARASI,
                ALLOGREFT_DONOR_KODU = e.ALLOGREFT_DONOR_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.StokHareket)]
    public async Task<ActionResult<StokHareketDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STOK_HAREKET>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.STOK_HAREKET_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new StokHareketDto
        {
            STOK_HAREKET_KODU = entity.STOK_HAREKET_KODU,
BAGLI_STOK_HAREKET_KODU = entity.BAGLI_STOK_HAREKET_KODU,
            ILK_GIRIS_STOK_HAREKET_KODU = entity.ILK_GIRIS_STOK_HAREKET_KODU,
            STOK_ISTEK_HAREKET_KODU = entity.STOK_ISTEK_HAREKET_KODU,
            STOK_FIS_KODU = entity.STOK_FIS_KODU,
            STOK_KART_KODU = entity.STOK_KART_KODU,
            BARKOD = entity.BARKOD,
            LOT_NUMARASI = entity.LOT_NUMARASI,
            SERI_SIRA_NUMARASI = entity.SERI_SIRA_NUMARASI,
            FIRMA_TANIMLAYICI_NUMARASI = entity.FIRMA_TANIMLAYICI_NUMARASI,
            MALZEME_SUT_KODU = entity.MALZEME_SUT_KODU,
            STOK_HAREKET_MIKTARI = entity.STOK_HAREKET_MIKTARI,
            TASINIR_NUMARASI = entity.TASINIR_NUMARASI,
            ALIS_BIRIM_FIYATI = entity.ALIS_BIRIM_FIYATI,
            SATIS_BIRIM_FIYATI = entity.SATIS_BIRIM_FIYATI,
            OLCU_KODU = entity.OLCU_KODU,
            ISLEMI_YAPAN_PERSONEL_KODU = entity.ISLEMI_YAPAN_PERSONEL_KODU,
            KDV_ORANI = entity.KDV_ORANI,
            ISKONTO_ORANI = entity.ISKONTO_ORANI,
            ISKONTO_TUTARI = entity.ISKONTO_TUTARI,
            SON_KULLANMA_TARIHI = entity.SON_KULLANMA_TARIHI,
            MKYS_STOK_HAREKET_KODU = entity.MKYS_STOK_HAREKET_KODU,
            IPTAL_DURUMU = entity.IPTAL_DURUMU,
            MKYS_KARSI_STOK_HAREKET_KODU = entity.MKYS_KARSI_STOK_HAREKET_KODU,
            MKYS_KUNYE_NUMARASI = entity.MKYS_KUNYE_NUMARASI,
            UTS_KAYIT_UDI = entity.UTS_KAYIT_UDI,
            BAYILIK_NUMARASI = entity.BAYILIK_NUMARASI,
            CIHAZ_KODU = entity.CIHAZ_KODU,
            ATS_SORGU_NUMARASI = entity.ATS_SORGU_NUMARASI,
            ALLOGREFT_DONOR_KODU = entity.ALLOGREFT_DONOR_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.StokHareket)]
    public async Task<ActionResult<string>> Create(StokHareketDto dto, CancellationToken ct)
    {
        var entity = new STOK_HAREKET
        {
            STOK_HAREKET_KODU = dto.STOK_HAREKET_KODU,
BAGLI_STOK_HAREKET_KODU = dto.BAGLI_STOK_HAREKET_KODU,
            ILK_GIRIS_STOK_HAREKET_KODU = dto.ILK_GIRIS_STOK_HAREKET_KODU,
            STOK_ISTEK_HAREKET_KODU = dto.STOK_ISTEK_HAREKET_KODU,
            STOK_FIS_KODU = dto.STOK_FIS_KODU,
            STOK_KART_KODU = dto.STOK_KART_KODU,
            BARKOD = dto.BARKOD,
            LOT_NUMARASI = dto.LOT_NUMARASI,
            SERI_SIRA_NUMARASI = dto.SERI_SIRA_NUMARASI,
            FIRMA_TANIMLAYICI_NUMARASI = dto.FIRMA_TANIMLAYICI_NUMARASI,
            MALZEME_SUT_KODU = dto.MALZEME_SUT_KODU,
            STOK_HAREKET_MIKTARI = dto.STOK_HAREKET_MIKTARI,
            TASINIR_NUMARASI = dto.TASINIR_NUMARASI,
            ALIS_BIRIM_FIYATI = dto.ALIS_BIRIM_FIYATI,
            SATIS_BIRIM_FIYATI = dto.SATIS_BIRIM_FIYATI,
            OLCU_KODU = dto.OLCU_KODU,
            ISLEMI_YAPAN_PERSONEL_KODU = dto.ISLEMI_YAPAN_PERSONEL_KODU,
            KDV_ORANI = dto.KDV_ORANI,
            ISKONTO_ORANI = dto.ISKONTO_ORANI,
            ISKONTO_TUTARI = dto.ISKONTO_TUTARI,
            SON_KULLANMA_TARIHI = dto.SON_KULLANMA_TARIHI,
            MKYS_STOK_HAREKET_KODU = dto.MKYS_STOK_HAREKET_KODU,
            IPTAL_DURUMU = dto.IPTAL_DURUMU,
            MKYS_KARSI_STOK_HAREKET_KODU = dto.MKYS_KARSI_STOK_HAREKET_KODU,
            MKYS_KUNYE_NUMARASI = dto.MKYS_KUNYE_NUMARASI,
            UTS_KAYIT_UDI = dto.UTS_KAYIT_UDI,
            BAYILIK_NUMARASI = dto.BAYILIK_NUMARASI,
            CIHAZ_KODU = dto.CIHAZ_KODU,
            ATS_SORGU_NUMARASI = dto.ATS_SORGU_NUMARASI,
            ALLOGREFT_DONOR_KODU = dto.ALLOGREFT_DONOR_KODU,
        };

        _db.Set<STOK_HAREKET>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.STOK_HAREKET_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.StokHareket)]
    public async Task<IActionResult> Update(string id, StokHareketDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<STOK_HAREKET>()
            .FirstOrDefaultAsync(e => e.STOK_HAREKET_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.BAGLI_STOK_HAREKET_KODU = dto.BAGLI_STOK_HAREKET_KODU;
        entity.ILK_GIRIS_STOK_HAREKET_KODU = dto.ILK_GIRIS_STOK_HAREKET_KODU;
        entity.STOK_ISTEK_HAREKET_KODU = dto.STOK_ISTEK_HAREKET_KODU;
        entity.STOK_FIS_KODU = dto.STOK_FIS_KODU;
        entity.STOK_KART_KODU = dto.STOK_KART_KODU;
        entity.BARKOD = dto.BARKOD;
        entity.LOT_NUMARASI = dto.LOT_NUMARASI;
        entity.SERI_SIRA_NUMARASI = dto.SERI_SIRA_NUMARASI;
        entity.FIRMA_TANIMLAYICI_NUMARASI = dto.FIRMA_TANIMLAYICI_NUMARASI;
        entity.MALZEME_SUT_KODU = dto.MALZEME_SUT_KODU;
        entity.STOK_HAREKET_MIKTARI = dto.STOK_HAREKET_MIKTARI;
        entity.TASINIR_NUMARASI = dto.TASINIR_NUMARASI;
        entity.ALIS_BIRIM_FIYATI = dto.ALIS_BIRIM_FIYATI;
        entity.SATIS_BIRIM_FIYATI = dto.SATIS_BIRIM_FIYATI;
        entity.OLCU_KODU = dto.OLCU_KODU;
        entity.ISLEMI_YAPAN_PERSONEL_KODU = dto.ISLEMI_YAPAN_PERSONEL_KODU;
        entity.KDV_ORANI = dto.KDV_ORANI;
        entity.ISKONTO_ORANI = dto.ISKONTO_ORANI;
        entity.ISKONTO_TUTARI = dto.ISKONTO_TUTARI;
        entity.SON_KULLANMA_TARIHI = dto.SON_KULLANMA_TARIHI;
        entity.MKYS_STOK_HAREKET_KODU = dto.MKYS_STOK_HAREKET_KODU;
        entity.IPTAL_DURUMU = dto.IPTAL_DURUMU;
        entity.MKYS_KARSI_STOK_HAREKET_KODU = dto.MKYS_KARSI_STOK_HAREKET_KODU;
        entity.MKYS_KUNYE_NUMARASI = dto.MKYS_KUNYE_NUMARASI;
        entity.UTS_KAYIT_UDI = dto.UTS_KAYIT_UDI;
        entity.BAYILIK_NUMARASI = dto.BAYILIK_NUMARASI;
        entity.CIHAZ_KODU = dto.CIHAZ_KODU;
        entity.ATS_SORGU_NUMARASI = dto.ATS_SORGU_NUMARASI;
        entity.ALLOGREFT_DONOR_KODU = dto.ALLOGREFT_DONOR_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.StokHareket)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<STOK_HAREKET>()
            .FirstOrDefaultAsync(e => e.STOK_HAREKET_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<STOK_HAREKET>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
