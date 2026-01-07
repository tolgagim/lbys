using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.HastaHizmet;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class HastaHizmetController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public HastaHizmetController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.HastaHizmet)]
    public async Task<List<HastaHizmetDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<HASTA_HIZMET>()
            .AsNoTracking()
            .Select(e => new HastaHizmetDto
            {
                HASTA_HIZMET_KODU = e.HASTA_HIZMET_KODU,
                HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                HIZMET_KODU = e.HIZMET_KODU,
                DOGUM_KODU = e.DOGUM_KODU,
                AMELIYAT_ISLEM_KODU = e.AMELIYAT_ISLEM_KODU,
                HASTA_HIZMET_DURUMU = e.HASTA_HIZMET_DURUMU,
                HIZMET_FATURA_DURUMU = e.HIZMET_FATURA_DURUMU,
                TIBBI_ISLEM_PUAN_BILGISI = e.TIBBI_ISLEM_PUAN_BILGISI,
                TARAF_BILGISI = e.TARAF_BILGISI,
                HIZMET_PUAN_BILGISI = e.HIZMET_PUAN_BILGISI,
                ISLEM_GERCEKLESME_ZAMANI = e.ISLEM_GERCEKLESME_ZAMANI,
                PUAN_HAKEDIS_ZAMANI = e.PUAN_HAKEDIS_ZAMANI,
                ISLEM_ZAMANI = e.ISLEM_ZAMANI,
                RANDEVU_ZAMANI = e.RANDEVU_ZAMANI,
                CIHAZ_KUNYE_NUMARASI = e.CIHAZ_KUNYE_NUMARASI,
                HIZMET_ADETI = e.HIZMET_ADETI,
                FATURA_ADET = e.FATURA_ADET,
                HASTA_TUTARI = e.HASTA_TUTARI,
                KURUM_TUTARI = e.KURUM_TUTARI,
                MEDULA_TUTARI = e.MEDULA_TUTARI,
                MEDULA_ISLEM_SIRA_NUMARASI = e.MEDULA_ISLEM_SIRA_NUMARASI,
                MEDULA_HIZMET_REF_NUMARASI = e.MEDULA_HIZMET_REF_NUMARASI,
                SYS_REFERANS_NUMARASI = e.SYS_REFERANS_NUMARASI,
                MEDULA_TAKIP_KODU = e.MEDULA_TAKIP_KODU,
                MEDULA_OZEL_DURUM = e.MEDULA_OZEL_DURUM,
                ONAYLAYAN_HEKIM_KODU = e.ONAYLAYAN_HEKIM_KODU,
                ISTEYEN_HEKIM_KODU = e.ISTEYEN_HEKIM_KODU,
                FATURA_KODU = e.FATURA_KODU,
                FATURA_TUTARI = e.FATURA_TUTARI,
                ISBT_UNITE_NUMARASI = e.ISBT_UNITE_NUMARASI,
                ISBT_BILESEN_NUMARASI = e.ISBT_BILESEN_NUMARASI,
                IPTAL_DURUMU = e.IPTAL_DURUMU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.HastaHizmet)]
    public async Task<ActionResult<HastaHizmetDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_HIZMET>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.HASTA_HIZMET_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new HastaHizmetDto
        {
            HASTA_HIZMET_KODU = entity.HASTA_HIZMET_KODU,
            HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            HIZMET_KODU = entity.HIZMET_KODU,
            DOGUM_KODU = entity.DOGUM_KODU,
            AMELIYAT_ISLEM_KODU = entity.AMELIYAT_ISLEM_KODU,
            HASTA_HIZMET_DURUMU = entity.HASTA_HIZMET_DURUMU,
            HIZMET_FATURA_DURUMU = entity.HIZMET_FATURA_DURUMU,
            TIBBI_ISLEM_PUAN_BILGISI = entity.TIBBI_ISLEM_PUAN_BILGISI,
            TARAF_BILGISI = entity.TARAF_BILGISI,
            HIZMET_PUAN_BILGISI = entity.HIZMET_PUAN_BILGISI,
            ISLEM_GERCEKLESME_ZAMANI = entity.ISLEM_GERCEKLESME_ZAMANI,
            PUAN_HAKEDIS_ZAMANI = entity.PUAN_HAKEDIS_ZAMANI,
            ISLEM_ZAMANI = entity.ISLEM_ZAMANI,
            RANDEVU_ZAMANI = entity.RANDEVU_ZAMANI,
            CIHAZ_KUNYE_NUMARASI = entity.CIHAZ_KUNYE_NUMARASI,
            HIZMET_ADETI = entity.HIZMET_ADETI,
            FATURA_ADET = entity.FATURA_ADET,
            HASTA_TUTARI = entity.HASTA_TUTARI,
            KURUM_TUTARI = entity.KURUM_TUTARI,
            MEDULA_TUTARI = entity.MEDULA_TUTARI,
            MEDULA_ISLEM_SIRA_NUMARASI = entity.MEDULA_ISLEM_SIRA_NUMARASI,
            MEDULA_HIZMET_REF_NUMARASI = entity.MEDULA_HIZMET_REF_NUMARASI,
            SYS_REFERANS_NUMARASI = entity.SYS_REFERANS_NUMARASI,
            MEDULA_TAKIP_KODU = entity.MEDULA_TAKIP_KODU,
            MEDULA_OZEL_DURUM = entity.MEDULA_OZEL_DURUM,
            ONAYLAYAN_HEKIM_KODU = entity.ONAYLAYAN_HEKIM_KODU,
            ISTEYEN_HEKIM_KODU = entity.ISTEYEN_HEKIM_KODU,
            FATURA_KODU = entity.FATURA_KODU,
            FATURA_TUTARI = entity.FATURA_TUTARI,
            ISBT_UNITE_NUMARASI = entity.ISBT_UNITE_NUMARASI,
            ISBT_BILESEN_NUMARASI = entity.ISBT_BILESEN_NUMARASI,
            IPTAL_DURUMU = entity.IPTAL_DURUMU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.HastaHizmet)]
    public async Task<ActionResult<string>> Create(HastaHizmetDto dto, CancellationToken ct)
    {
        var entity = new HASTA_HIZMET
        {
            HASTA_HIZMET_KODU = dto.HASTA_HIZMET_KODU,
            HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            HIZMET_KODU = dto.HIZMET_KODU,
            DOGUM_KODU = dto.DOGUM_KODU,
            AMELIYAT_ISLEM_KODU = dto.AMELIYAT_ISLEM_KODU,
            HASTA_HIZMET_DURUMU = dto.HASTA_HIZMET_DURUMU,
            HIZMET_FATURA_DURUMU = dto.HIZMET_FATURA_DURUMU,
            TIBBI_ISLEM_PUAN_BILGISI = dto.TIBBI_ISLEM_PUAN_BILGISI,
            TARAF_BILGISI = dto.TARAF_BILGISI,
            HIZMET_PUAN_BILGISI = dto.HIZMET_PUAN_BILGISI,
            ISLEM_GERCEKLESME_ZAMANI = dto.ISLEM_GERCEKLESME_ZAMANI,
            PUAN_HAKEDIS_ZAMANI = dto.PUAN_HAKEDIS_ZAMANI,
            ISLEM_ZAMANI = dto.ISLEM_ZAMANI,
            RANDEVU_ZAMANI = dto.RANDEVU_ZAMANI,
            CIHAZ_KUNYE_NUMARASI = dto.CIHAZ_KUNYE_NUMARASI,
            HIZMET_ADETI = dto.HIZMET_ADETI,
            FATURA_ADET = dto.FATURA_ADET,
            HASTA_TUTARI = dto.HASTA_TUTARI,
            KURUM_TUTARI = dto.KURUM_TUTARI,
            MEDULA_TUTARI = dto.MEDULA_TUTARI,
            MEDULA_ISLEM_SIRA_NUMARASI = dto.MEDULA_ISLEM_SIRA_NUMARASI,
            MEDULA_HIZMET_REF_NUMARASI = dto.MEDULA_HIZMET_REF_NUMARASI,
            SYS_REFERANS_NUMARASI = dto.SYS_REFERANS_NUMARASI,
            MEDULA_TAKIP_KODU = dto.MEDULA_TAKIP_KODU,
            MEDULA_OZEL_DURUM = dto.MEDULA_OZEL_DURUM,
            ONAYLAYAN_HEKIM_KODU = dto.ONAYLAYAN_HEKIM_KODU,
            ISTEYEN_HEKIM_KODU = dto.ISTEYEN_HEKIM_KODU,
            FATURA_KODU = dto.FATURA_KODU,
            FATURA_TUTARI = dto.FATURA_TUTARI,
            ISBT_UNITE_NUMARASI = dto.ISBT_UNITE_NUMARASI,
            ISBT_BILESEN_NUMARASI = dto.ISBT_BILESEN_NUMARASI,
            IPTAL_DURUMU = dto.IPTAL_DURUMU,
        };

        _db.Set<HASTA_HIZMET>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.HASTA_HIZMET_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.HastaHizmet)]
    public async Task<IActionResult> Update(string id, HastaHizmetDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_HIZMET>()
            .FirstOrDefaultAsync(e => e.HASTA_HIZMET_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.HIZMET_KODU = dto.HIZMET_KODU;
        entity.DOGUM_KODU = dto.DOGUM_KODU;
        entity.AMELIYAT_ISLEM_KODU = dto.AMELIYAT_ISLEM_KODU;
        entity.HASTA_HIZMET_DURUMU = dto.HASTA_HIZMET_DURUMU;
        entity.HIZMET_FATURA_DURUMU = dto.HIZMET_FATURA_DURUMU;
        entity.TIBBI_ISLEM_PUAN_BILGISI = dto.TIBBI_ISLEM_PUAN_BILGISI;
        entity.TARAF_BILGISI = dto.TARAF_BILGISI;
        entity.HIZMET_PUAN_BILGISI = dto.HIZMET_PUAN_BILGISI;
        entity.ISLEM_GERCEKLESME_ZAMANI = dto.ISLEM_GERCEKLESME_ZAMANI;
        entity.PUAN_HAKEDIS_ZAMANI = dto.PUAN_HAKEDIS_ZAMANI;
        entity.ISLEM_ZAMANI = dto.ISLEM_ZAMANI;
        entity.RANDEVU_ZAMANI = dto.RANDEVU_ZAMANI;
        entity.CIHAZ_KUNYE_NUMARASI = dto.CIHAZ_KUNYE_NUMARASI;
        entity.HIZMET_ADETI = dto.HIZMET_ADETI;
        entity.FATURA_ADET = dto.FATURA_ADET;
        entity.HASTA_TUTARI = dto.HASTA_TUTARI;
        entity.KURUM_TUTARI = dto.KURUM_TUTARI;
        entity.MEDULA_TUTARI = dto.MEDULA_TUTARI;
        entity.MEDULA_ISLEM_SIRA_NUMARASI = dto.MEDULA_ISLEM_SIRA_NUMARASI;
        entity.MEDULA_HIZMET_REF_NUMARASI = dto.MEDULA_HIZMET_REF_NUMARASI;
        entity.SYS_REFERANS_NUMARASI = dto.SYS_REFERANS_NUMARASI;
        entity.MEDULA_TAKIP_KODU = dto.MEDULA_TAKIP_KODU;
        entity.MEDULA_OZEL_DURUM = dto.MEDULA_OZEL_DURUM;
        entity.ONAYLAYAN_HEKIM_KODU = dto.ONAYLAYAN_HEKIM_KODU;
        entity.ISTEYEN_HEKIM_KODU = dto.ISTEYEN_HEKIM_KODU;
        entity.FATURA_KODU = dto.FATURA_KODU;
        entity.FATURA_TUTARI = dto.FATURA_TUTARI;
        entity.ISBT_UNITE_NUMARASI = dto.ISBT_UNITE_NUMARASI;
        entity.ISBT_BILESEN_NUMARASI = dto.ISBT_BILESEN_NUMARASI;
        entity.IPTAL_DURUMU = dto.IPTAL_DURUMU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.HastaHizmet)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_HIZMET>()
            .FirstOrDefaultAsync(e => e.HASTA_HIZMET_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<HASTA_HIZMET>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
