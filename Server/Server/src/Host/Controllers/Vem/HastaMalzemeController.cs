using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.HastaMalzeme;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class HastaMalzemeController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public HastaMalzemeController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.HastaMalzeme)]
    public async Task<List<HastaMalzemeDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<HASTA_MALZEME>()
            .AsNoTracking()
            .Select(e => new HastaMalzemeDto
            {
                HASTA_MALZEME_KODU = e.HASTA_MALZEME_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                STOK_KART_KODU = e.STOK_KART_KODU,
                STOK_HAREKET_KODU = e.STOK_HAREKET_KODU,
                MALZEME_FATURA_DURUMU = e.MALZEME_FATURA_DURUMU,
                ISLEM_ZAMANI = e.ISLEM_ZAMANI,
                ISLEM_GERCEKLESME_ZAMANI = e.ISLEM_GERCEKLESME_ZAMANI,
                ATS_SORGU_NUMARASI = e.ATS_SORGU_NUMARASI,
                ALLOGREFT_DONOR_KODU = e.ALLOGREFT_DONOR_KODU,
                MALZEME_ADETI = e.MALZEME_ADETI,
                FATURA_ADET = e.FATURA_ADET,
                FATURA_KODU = e.FATURA_KODU,
                FATURA_TUTARI = e.FATURA_TUTARI,
                HASTA_TUTARI = e.HASTA_TUTARI,
                KURUM_TUTARI = e.KURUM_TUTARI,
                MEDULA_TUTARI = e.MEDULA_TUTARI,
                MEDULA_ISLEM_SIRA_NUMARASI = e.MEDULA_ISLEM_SIRA_NUMARASI,
                MEDULA_HIZMET_REF_NUMARASI = e.MEDULA_HIZMET_REF_NUMARASI,
                SYS_REFERANS_NUMARASI = e.SYS_REFERANS_NUMARASI,
                MEDULA_TAKIP_KODU = e.MEDULA_TAKIP_KODU,
                MEDULA_OZEL_DURUM = e.MEDULA_OZEL_DURUM,
                AMELIYAT_KODU = e.AMELIYAT_KODU,
                ISTEYEN_HEKIM_KODU = e.ISTEYEN_HEKIM_KODU,
                DEPO_KODU = e.DEPO_KODU,
                IPTAL_DURUMU = e.IPTAL_DURUMU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.HastaMalzeme)]
    public async Task<ActionResult<HastaMalzemeDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_MALZEME>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.HASTA_MALZEME_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new HastaMalzemeDto
        {
            HASTA_MALZEME_KODU = entity.HASTA_MALZEME_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            STOK_KART_KODU = entity.STOK_KART_KODU,
            STOK_HAREKET_KODU = entity.STOK_HAREKET_KODU,
            MALZEME_FATURA_DURUMU = entity.MALZEME_FATURA_DURUMU,
            ISLEM_ZAMANI = entity.ISLEM_ZAMANI,
            ISLEM_GERCEKLESME_ZAMANI = entity.ISLEM_GERCEKLESME_ZAMANI,
            ATS_SORGU_NUMARASI = entity.ATS_SORGU_NUMARASI,
            ALLOGREFT_DONOR_KODU = entity.ALLOGREFT_DONOR_KODU,
            MALZEME_ADETI = entity.MALZEME_ADETI,
            FATURA_ADET = entity.FATURA_ADET,
            FATURA_KODU = entity.FATURA_KODU,
            FATURA_TUTARI = entity.FATURA_TUTARI,
            HASTA_TUTARI = entity.HASTA_TUTARI,
            KURUM_TUTARI = entity.KURUM_TUTARI,
            MEDULA_TUTARI = entity.MEDULA_TUTARI,
            MEDULA_ISLEM_SIRA_NUMARASI = entity.MEDULA_ISLEM_SIRA_NUMARASI,
            MEDULA_HIZMET_REF_NUMARASI = entity.MEDULA_HIZMET_REF_NUMARASI,
            SYS_REFERANS_NUMARASI = entity.SYS_REFERANS_NUMARASI,
            MEDULA_TAKIP_KODU = entity.MEDULA_TAKIP_KODU,
            MEDULA_OZEL_DURUM = entity.MEDULA_OZEL_DURUM,
            AMELIYAT_KODU = entity.AMELIYAT_KODU,
            ISTEYEN_HEKIM_KODU = entity.ISTEYEN_HEKIM_KODU,
            DEPO_KODU = entity.DEPO_KODU,
            IPTAL_DURUMU = entity.IPTAL_DURUMU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.HastaMalzeme)]
    public async Task<ActionResult<string>> Create(HastaMalzemeDto dto, CancellationToken ct)
    {
        var entity = new HASTA_MALZEME
        {
            HASTA_MALZEME_KODU = dto.HASTA_MALZEME_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            STOK_KART_KODU = dto.STOK_KART_KODU,
            STOK_HAREKET_KODU = dto.STOK_HAREKET_KODU,
            MALZEME_FATURA_DURUMU = dto.MALZEME_FATURA_DURUMU,
            ISLEM_ZAMANI = dto.ISLEM_ZAMANI,
            ISLEM_GERCEKLESME_ZAMANI = dto.ISLEM_GERCEKLESME_ZAMANI,
            ATS_SORGU_NUMARASI = dto.ATS_SORGU_NUMARASI,
            ALLOGREFT_DONOR_KODU = dto.ALLOGREFT_DONOR_KODU,
            MALZEME_ADETI = dto.MALZEME_ADETI,
            FATURA_ADET = dto.FATURA_ADET,
            FATURA_KODU = dto.FATURA_KODU,
            FATURA_TUTARI = dto.FATURA_TUTARI,
            HASTA_TUTARI = dto.HASTA_TUTARI,
            KURUM_TUTARI = dto.KURUM_TUTARI,
            MEDULA_TUTARI = dto.MEDULA_TUTARI,
            MEDULA_ISLEM_SIRA_NUMARASI = dto.MEDULA_ISLEM_SIRA_NUMARASI,
            MEDULA_HIZMET_REF_NUMARASI = dto.MEDULA_HIZMET_REF_NUMARASI,
            SYS_REFERANS_NUMARASI = dto.SYS_REFERANS_NUMARASI,
            MEDULA_TAKIP_KODU = dto.MEDULA_TAKIP_KODU,
            MEDULA_OZEL_DURUM = dto.MEDULA_OZEL_DURUM,
            AMELIYAT_KODU = dto.AMELIYAT_KODU,
            ISTEYEN_HEKIM_KODU = dto.ISTEYEN_HEKIM_KODU,
            DEPO_KODU = dto.DEPO_KODU,
            IPTAL_DURUMU = dto.IPTAL_DURUMU,
        };

        _db.Set<HASTA_MALZEME>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.HASTA_MALZEME_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.HastaMalzeme)]
    public async Task<IActionResult> Update(string id, HastaMalzemeDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_MALZEME>()
            .FirstOrDefaultAsync(e => e.HASTA_MALZEME_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.STOK_KART_KODU = dto.STOK_KART_KODU;
        entity.STOK_HAREKET_KODU = dto.STOK_HAREKET_KODU;
        entity.MALZEME_FATURA_DURUMU = dto.MALZEME_FATURA_DURUMU;
        entity.ISLEM_ZAMANI = dto.ISLEM_ZAMANI;
        entity.ISLEM_GERCEKLESME_ZAMANI = dto.ISLEM_GERCEKLESME_ZAMANI;
        entity.ATS_SORGU_NUMARASI = dto.ATS_SORGU_NUMARASI;
        entity.ALLOGREFT_DONOR_KODU = dto.ALLOGREFT_DONOR_KODU;
        entity.MALZEME_ADETI = dto.MALZEME_ADETI;
        entity.FATURA_ADET = dto.FATURA_ADET;
        entity.FATURA_KODU = dto.FATURA_KODU;
        entity.FATURA_TUTARI = dto.FATURA_TUTARI;
        entity.HASTA_TUTARI = dto.HASTA_TUTARI;
        entity.KURUM_TUTARI = dto.KURUM_TUTARI;
        entity.MEDULA_TUTARI = dto.MEDULA_TUTARI;
        entity.MEDULA_ISLEM_SIRA_NUMARASI = dto.MEDULA_ISLEM_SIRA_NUMARASI;
        entity.MEDULA_HIZMET_REF_NUMARASI = dto.MEDULA_HIZMET_REF_NUMARASI;
        entity.SYS_REFERANS_NUMARASI = dto.SYS_REFERANS_NUMARASI;
        entity.MEDULA_TAKIP_KODU = dto.MEDULA_TAKIP_KODU;
        entity.MEDULA_OZEL_DURUM = dto.MEDULA_OZEL_DURUM;
        entity.AMELIYAT_KODU = dto.AMELIYAT_KODU;
        entity.ISTEYEN_HEKIM_KODU = dto.ISTEYEN_HEKIM_KODU;
        entity.DEPO_KODU = dto.DEPO_KODU;
        entity.IPTAL_DURUMU = dto.IPTAL_DURUMU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.HastaMalzeme)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_MALZEME>()
            .FirstOrDefaultAsync(e => e.HASTA_MALZEME_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<HASTA_MALZEME>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
