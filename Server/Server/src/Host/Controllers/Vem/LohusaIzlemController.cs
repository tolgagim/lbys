using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.LohusaIzlem;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class LohusaIzlemController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public LohusaIzlemController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.LohusaIzlem)]
    public async Task<List<LohusaIzlemDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<LOHUSA_IZLEM>()
            .AsNoTracking()
            .Select(e => new LohusaIzlemDto
            {
                LOHUSA_IZLEM_KODU = e.LOHUSA_IZLEM_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                KACINCI_LOHUSA_IZLEM = e.KACINCI_LOHUSA_IZLEM,
                IZLEMIN_YAPILDIGI_YER = e.IZLEMIN_YAPILDIGI_YER,
                DEMIR_LOJISTIGI_VE_DESTEGI = e.DEMIR_LOJISTIGI_VE_DESTEGI,
                DVITAMINI_LOJISTIGI_VE_DESTEGI = e.DVITAMINI_LOJISTIGI_VE_DESTEGI,
                GEBELIK_SONLANMA_TARIHI = e.GEBELIK_SONLANMA_TARIHI,
                POSTPARTUM_DEPRESYON = e.POSTPARTUM_DEPRESYON,
                UTERUS_INVOLUSYON = e.UTERUS_INVOLUSYON,
                BILGI_ALINAN_KISI_AD_SOYADI = e.BILGI_ALINAN_KISI_AD_SOYADI,
                BILGI_ALINAN_KISI_TELEFON = e.BILGI_ALINAN_KISI_TELEFON,
                KONJENITAL_ANOMALI_VARLIGI = e.KONJENITAL_ANOMALI_VARLIGI,
                HEMOGLOBIN_DEGERI = e.HEMOGLOBIN_DEGERI,
                KOMPLIKASYON_TANISI = e.KOMPLIKASYON_TANISI,
                SEYIR_TEHLIKE_ISARETI = e.SEYIR_TEHLIKE_ISARETI,
                KADIN_SAGLIGI_ISLEMLERI = e.KADIN_SAGLIGI_ISLEMLERI,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.LohusaIzlem)]
    public async Task<ActionResult<LohusaIzlemDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<LOHUSA_IZLEM>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.LOHUSA_IZLEM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new LohusaIzlemDto
        {
            LOHUSA_IZLEM_KODU = entity.LOHUSA_IZLEM_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            KACINCI_LOHUSA_IZLEM = entity.KACINCI_LOHUSA_IZLEM,
            IZLEMIN_YAPILDIGI_YER = entity.IZLEMIN_YAPILDIGI_YER,
            DEMIR_LOJISTIGI_VE_DESTEGI = entity.DEMIR_LOJISTIGI_VE_DESTEGI,
            DVITAMINI_LOJISTIGI_VE_DESTEGI = entity.DVITAMINI_LOJISTIGI_VE_DESTEGI,
            GEBELIK_SONLANMA_TARIHI = entity.GEBELIK_SONLANMA_TARIHI,
            POSTPARTUM_DEPRESYON = entity.POSTPARTUM_DEPRESYON,
            UTERUS_INVOLUSYON = entity.UTERUS_INVOLUSYON,
            BILGI_ALINAN_KISI_AD_SOYADI = entity.BILGI_ALINAN_KISI_AD_SOYADI,
            BILGI_ALINAN_KISI_TELEFON = entity.BILGI_ALINAN_KISI_TELEFON,
            KONJENITAL_ANOMALI_VARLIGI = entity.KONJENITAL_ANOMALI_VARLIGI,
            HEMOGLOBIN_DEGERI = entity.HEMOGLOBIN_DEGERI,
            KOMPLIKASYON_TANISI = entity.KOMPLIKASYON_TANISI,
            SEYIR_TEHLIKE_ISARETI = entity.SEYIR_TEHLIKE_ISARETI,
            KADIN_SAGLIGI_ISLEMLERI = entity.KADIN_SAGLIGI_ISLEMLERI,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.LohusaIzlem)]
    public async Task<ActionResult<string>> Create(LohusaIzlemDto dto, CancellationToken ct)
    {
        var entity = new LOHUSA_IZLEM
        {
            LOHUSA_IZLEM_KODU = dto.LOHUSA_IZLEM_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            KACINCI_LOHUSA_IZLEM = dto.KACINCI_LOHUSA_IZLEM,
            IZLEMIN_YAPILDIGI_YER = dto.IZLEMIN_YAPILDIGI_YER,
            DEMIR_LOJISTIGI_VE_DESTEGI = dto.DEMIR_LOJISTIGI_VE_DESTEGI,
            DVITAMINI_LOJISTIGI_VE_DESTEGI = dto.DVITAMINI_LOJISTIGI_VE_DESTEGI,
            GEBELIK_SONLANMA_TARIHI = dto.GEBELIK_SONLANMA_TARIHI,
            POSTPARTUM_DEPRESYON = dto.POSTPARTUM_DEPRESYON,
            UTERUS_INVOLUSYON = dto.UTERUS_INVOLUSYON,
            BILGI_ALINAN_KISI_AD_SOYADI = dto.BILGI_ALINAN_KISI_AD_SOYADI,
            BILGI_ALINAN_KISI_TELEFON = dto.BILGI_ALINAN_KISI_TELEFON,
            KONJENITAL_ANOMALI_VARLIGI = dto.KONJENITAL_ANOMALI_VARLIGI,
            HEMOGLOBIN_DEGERI = dto.HEMOGLOBIN_DEGERI,
            KOMPLIKASYON_TANISI = dto.KOMPLIKASYON_TANISI,
            SEYIR_TEHLIKE_ISARETI = dto.SEYIR_TEHLIKE_ISARETI,
            KADIN_SAGLIGI_ISLEMLERI = dto.KADIN_SAGLIGI_ISLEMLERI,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<LOHUSA_IZLEM>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.LOHUSA_IZLEM_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.LohusaIzlem)]
    public async Task<IActionResult> Update(string id, LohusaIzlemDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<LOHUSA_IZLEM>()
            .FirstOrDefaultAsync(e => e.LOHUSA_IZLEM_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.KACINCI_LOHUSA_IZLEM = dto.KACINCI_LOHUSA_IZLEM;
        entity.IZLEMIN_YAPILDIGI_YER = dto.IZLEMIN_YAPILDIGI_YER;
        entity.DEMIR_LOJISTIGI_VE_DESTEGI = dto.DEMIR_LOJISTIGI_VE_DESTEGI;
        entity.DVITAMINI_LOJISTIGI_VE_DESTEGI = dto.DVITAMINI_LOJISTIGI_VE_DESTEGI;
        entity.GEBELIK_SONLANMA_TARIHI = dto.GEBELIK_SONLANMA_TARIHI;
        entity.POSTPARTUM_DEPRESYON = dto.POSTPARTUM_DEPRESYON;
        entity.UTERUS_INVOLUSYON = dto.UTERUS_INVOLUSYON;
        entity.BILGI_ALINAN_KISI_AD_SOYADI = dto.BILGI_ALINAN_KISI_AD_SOYADI;
        entity.BILGI_ALINAN_KISI_TELEFON = dto.BILGI_ALINAN_KISI_TELEFON;
        entity.KONJENITAL_ANOMALI_VARLIGI = dto.KONJENITAL_ANOMALI_VARLIGI;
        entity.HEMOGLOBIN_DEGERI = dto.HEMOGLOBIN_DEGERI;
        entity.KOMPLIKASYON_TANISI = dto.KOMPLIKASYON_TANISI;
        entity.SEYIR_TEHLIKE_ISARETI = dto.SEYIR_TEHLIKE_ISARETI;
        entity.KADIN_SAGLIGI_ISLEMLERI = dto.KADIN_SAGLIGI_ISLEMLERI;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.LohusaIzlem)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<LOHUSA_IZLEM>()
            .FirstOrDefaultAsync(e => e.LOHUSA_IZLEM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<LOHUSA_IZLEM>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
