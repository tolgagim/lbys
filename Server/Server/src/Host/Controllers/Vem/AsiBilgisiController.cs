using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.AsiBilgisi;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class AsiBilgisiController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public AsiBilgisiController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.AsiBilgisi)]
    public async Task<List<AsiBilgisiDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<ASI_BILGISI>()
            .AsNoTracking()
            .Select(e => new AsiBilgisiDto
            {
                ASI_BILGISI_KODU = e.ASI_BILGISI_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                ASI_KODU = e.ASI_KODU,
                ASININ_DOZU = e.ASININ_DOZU,
                ASININ_UYGULAMA_SEKLI = e.ASININ_UYGULAMA_SEKLI,
                ASI_UYGULAMA_YERI = e.ASI_UYGULAMA_YERI,
                ASI_SORGU_NUMARASI = e.ASI_SORGU_NUMARASI,
                ASI_ISLEM_TURU = e.ASI_ISLEM_TURU,
                BILGI_ALINAN_KISI_AD_SOYADI = e.BILGI_ALINAN_KISI_AD_SOYADI,
                BILGI_ALINAN_KISI_TELEFON = e.BILGI_ALINAN_KISI_TELEFON,
                ASI_YAPILMA_ZAMANI = e.ASI_YAPILMA_ZAMANI,
                ASI_OZEL_DURUM_NEDENI = e.ASI_OZEL_DURUM_NEDENI,
                ASIE_ORTAYA_CIKIS_ZAMANI = e.ASIE_ORTAYA_CIKIS_ZAMANI,
                ASIE_NEDENLERI = e.ASIE_NEDENLERI,
                ASI_ERTELEME_SURESI = e.ASI_ERTELEME_SURESI,
                ASI_YAPILMAMA_DURUMU = e.ASI_YAPILMAMA_DURUMU,
                ASI_YAPILMAMA_NEDENI = e.ASI_YAPILMAMA_NEDENI,
                ALTTA_YATAN_HASTALIK = e.ALTTA_YATAN_HASTALIK,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.AsiBilgisi)]
    public async Task<ActionResult<AsiBilgisiDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<ASI_BILGISI>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.ASI_BILGISI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new AsiBilgisiDto
        {
            ASI_BILGISI_KODU = entity.ASI_BILGISI_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            ASI_KODU = entity.ASI_KODU,
            ASININ_DOZU = entity.ASININ_DOZU,
            ASININ_UYGULAMA_SEKLI = entity.ASININ_UYGULAMA_SEKLI,
            ASI_UYGULAMA_YERI = entity.ASI_UYGULAMA_YERI,
            ASI_SORGU_NUMARASI = entity.ASI_SORGU_NUMARASI,
            ASI_ISLEM_TURU = entity.ASI_ISLEM_TURU,
            BILGI_ALINAN_KISI_AD_SOYADI = entity.BILGI_ALINAN_KISI_AD_SOYADI,
            BILGI_ALINAN_KISI_TELEFON = entity.BILGI_ALINAN_KISI_TELEFON,
            ASI_YAPILMA_ZAMANI = entity.ASI_YAPILMA_ZAMANI,
            ASI_OZEL_DURUM_NEDENI = entity.ASI_OZEL_DURUM_NEDENI,
            ASIE_ORTAYA_CIKIS_ZAMANI = entity.ASIE_ORTAYA_CIKIS_ZAMANI,
            ASIE_NEDENLERI = entity.ASIE_NEDENLERI,
            ASI_ERTELEME_SURESI = entity.ASI_ERTELEME_SURESI,
            ASI_YAPILMAMA_DURUMU = entity.ASI_YAPILMAMA_DURUMU,
            ASI_YAPILMAMA_NEDENI = entity.ASI_YAPILMAMA_NEDENI,
            ALTTA_YATAN_HASTALIK = entity.ALTTA_YATAN_HASTALIK,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.AsiBilgisi)]
    public async Task<ActionResult<string>> Create(AsiBilgisiDto dto, CancellationToken ct)
    {
        var entity = new ASI_BILGISI
        {
            ASI_BILGISI_KODU = dto.ASI_BILGISI_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            ASI_KODU = dto.ASI_KODU,
            ASININ_DOZU = dto.ASININ_DOZU,
            ASININ_UYGULAMA_SEKLI = dto.ASININ_UYGULAMA_SEKLI,
            ASI_UYGULAMA_YERI = dto.ASI_UYGULAMA_YERI,
            ASI_SORGU_NUMARASI = dto.ASI_SORGU_NUMARASI,
            ASI_ISLEM_TURU = dto.ASI_ISLEM_TURU,
            BILGI_ALINAN_KISI_AD_SOYADI = dto.BILGI_ALINAN_KISI_AD_SOYADI,
            BILGI_ALINAN_KISI_TELEFON = dto.BILGI_ALINAN_KISI_TELEFON,
            ASI_YAPILMA_ZAMANI = dto.ASI_YAPILMA_ZAMANI,
            ASI_OZEL_DURUM_NEDENI = dto.ASI_OZEL_DURUM_NEDENI,
            ASIE_ORTAYA_CIKIS_ZAMANI = dto.ASIE_ORTAYA_CIKIS_ZAMANI,
            ASIE_NEDENLERI = dto.ASIE_NEDENLERI,
            ASI_ERTELEME_SURESI = dto.ASI_ERTELEME_SURESI,
            ASI_YAPILMAMA_DURUMU = dto.ASI_YAPILMAMA_DURUMU,
            ASI_YAPILMAMA_NEDENI = dto.ASI_YAPILMAMA_NEDENI,
            ALTTA_YATAN_HASTALIK = dto.ALTTA_YATAN_HASTALIK,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<ASI_BILGISI>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.ASI_BILGISI_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.AsiBilgisi)]
    public async Task<IActionResult> Update(string id, AsiBilgisiDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<ASI_BILGISI>()
            .FirstOrDefaultAsync(e => e.ASI_BILGISI_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.ASI_KODU = dto.ASI_KODU;
        entity.ASININ_DOZU = dto.ASININ_DOZU;
        entity.ASININ_UYGULAMA_SEKLI = dto.ASININ_UYGULAMA_SEKLI;
        entity.ASI_UYGULAMA_YERI = dto.ASI_UYGULAMA_YERI;
        entity.ASI_SORGU_NUMARASI = dto.ASI_SORGU_NUMARASI;
        entity.ASI_ISLEM_TURU = dto.ASI_ISLEM_TURU;
        entity.BILGI_ALINAN_KISI_AD_SOYADI = dto.BILGI_ALINAN_KISI_AD_SOYADI;
        entity.BILGI_ALINAN_KISI_TELEFON = dto.BILGI_ALINAN_KISI_TELEFON;
        entity.ASI_YAPILMA_ZAMANI = dto.ASI_YAPILMA_ZAMANI;
        entity.ASI_OZEL_DURUM_NEDENI = dto.ASI_OZEL_DURUM_NEDENI;
        entity.ASIE_ORTAYA_CIKIS_ZAMANI = dto.ASIE_ORTAYA_CIKIS_ZAMANI;
        entity.ASIE_NEDENLERI = dto.ASIE_NEDENLERI;
        entity.ASI_ERTELEME_SURESI = dto.ASI_ERTELEME_SURESI;
        entity.ASI_YAPILMAMA_DURUMU = dto.ASI_YAPILMAMA_DURUMU;
        entity.ASI_YAPILMAMA_NEDENI = dto.ASI_YAPILMAMA_NEDENI;
        entity.ALTTA_YATAN_HASTALIK = dto.ALTTA_YATAN_HASTALIK;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.AsiBilgisi)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<ASI_BILGISI>()
            .FirstOrDefaultAsync(e => e.ASI_BILGISI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<ASI_BILGISI>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
