using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.GebeIzlem;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class GebeIzlemController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public GebeIzlemController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.GebeIzlem)]
    public async Task<List<GebeIzlemDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<GEBE_IZLEM>()
            .AsNoTracking()
            .Select(e => new GebeIzlemDto
            {
                GEBE_IZLEM_KODU = e.GEBE_IZLEM_KODU,
HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                KACINCI_GEBE_IZLEM = e.KACINCI_GEBE_IZLEM,
                SON_ADET_TARIHI = e.SON_ADET_TARIHI,
                ONCEKI_DOGUM_DURUMU = e.ONCEKI_DOGUM_DURUMU,
                GEBE_IZLEM_ISLEM_TURU = e.GEBE_IZLEM_ISLEM_TURU,
                GESTASYONEL_DIYABET_TARAMASI = e.GESTASYONEL_DIYABET_TARAMASI,
                IDRARDA_PROTEIN = e.IDRARDA_PROTEIN,
                HEMOGLOBIN_DEGERI = e.HEMOGLOBIN_DEGERI,
                DEMIR_LOJISTIGI_VE_DESTEGI = e.DEMIR_LOJISTIGI_VE_DESTEGI,
                DVITAMINI_LOJISTIGI_VE_DESTEGI = e.DVITAMINI_LOJISTIGI_VE_DESTEGI,
                KONJENITAL_ANOMALI_VARLIGI = e.KONJENITAL_ANOMALI_VARLIGI,
                FETUS_KALP_SESI = e.FETUS_KALP_SESI,
                DIASTOLIK_KAN_BASINCI_DEGERI = e.DIASTOLIK_KAN_BASINCI_DEGERI,
                SISTOLIK_KAN_BASINCI_DEGERI = e.SISTOLIK_KAN_BASINCI_DEGERI,
                GEBELIKTE_RISK_FAKTORLERI = e.GEBELIKTE_RISK_FAKTORLERI,
                BC_BEYIN_GELISIM_RISKLERI = e.BC_BEYIN_GELISIM_RISKLERI,
                PSIKOLOJIK_GELISIM_RISK_EGITIM = e.PSIKOLOJIK_GELISIM_RISK_EGITIM,
                RISK_FAKTORLERINE_MUDAHALE = e.RISK_FAKTORLERINE_MUDAHALE,
                RISK_ALTINDAKI_OLGU_TAKIBI = e.RISK_ALTINDAKI_OLGU_TAKIBI,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.GebeIzlem)]
    public async Task<ActionResult<GebeIzlemDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<GEBE_IZLEM>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.GEBE_IZLEM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new GebeIzlemDto
        {
            GEBE_IZLEM_KODU = entity.GEBE_IZLEM_KODU,
HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            KACINCI_GEBE_IZLEM = entity.KACINCI_GEBE_IZLEM,
            SON_ADET_TARIHI = entity.SON_ADET_TARIHI,
            ONCEKI_DOGUM_DURUMU = entity.ONCEKI_DOGUM_DURUMU,
            GEBE_IZLEM_ISLEM_TURU = entity.GEBE_IZLEM_ISLEM_TURU,
            GESTASYONEL_DIYABET_TARAMASI = entity.GESTASYONEL_DIYABET_TARAMASI,
            IDRARDA_PROTEIN = entity.IDRARDA_PROTEIN,
            HEMOGLOBIN_DEGERI = entity.HEMOGLOBIN_DEGERI,
            DEMIR_LOJISTIGI_VE_DESTEGI = entity.DEMIR_LOJISTIGI_VE_DESTEGI,
            DVITAMINI_LOJISTIGI_VE_DESTEGI = entity.DVITAMINI_LOJISTIGI_VE_DESTEGI,
            KONJENITAL_ANOMALI_VARLIGI = entity.KONJENITAL_ANOMALI_VARLIGI,
            FETUS_KALP_SESI = entity.FETUS_KALP_SESI,
            DIASTOLIK_KAN_BASINCI_DEGERI = entity.DIASTOLIK_KAN_BASINCI_DEGERI,
            SISTOLIK_KAN_BASINCI_DEGERI = entity.SISTOLIK_KAN_BASINCI_DEGERI,
            GEBELIKTE_RISK_FAKTORLERI = entity.GEBELIKTE_RISK_FAKTORLERI,
            BC_BEYIN_GELISIM_RISKLERI = entity.BC_BEYIN_GELISIM_RISKLERI,
            PSIKOLOJIK_GELISIM_RISK_EGITIM = entity.PSIKOLOJIK_GELISIM_RISK_EGITIM,
            RISK_FAKTORLERINE_MUDAHALE = entity.RISK_FAKTORLERINE_MUDAHALE,
            RISK_ALTINDAKI_OLGU_TAKIBI = entity.RISK_ALTINDAKI_OLGU_TAKIBI,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.GebeIzlem)]
    public async Task<ActionResult<string>> Create(GebeIzlemDto dto, CancellationToken ct)
    {
        var entity = new GEBE_IZLEM
        {
            GEBE_IZLEM_KODU = dto.GEBE_IZLEM_KODU,
HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            KACINCI_GEBE_IZLEM = dto.KACINCI_GEBE_IZLEM,
            SON_ADET_TARIHI = dto.SON_ADET_TARIHI,
            ONCEKI_DOGUM_DURUMU = dto.ONCEKI_DOGUM_DURUMU,
            GEBE_IZLEM_ISLEM_TURU = dto.GEBE_IZLEM_ISLEM_TURU,
            GESTASYONEL_DIYABET_TARAMASI = dto.GESTASYONEL_DIYABET_TARAMASI,
            IDRARDA_PROTEIN = dto.IDRARDA_PROTEIN,
            HEMOGLOBIN_DEGERI = dto.HEMOGLOBIN_DEGERI,
            DEMIR_LOJISTIGI_VE_DESTEGI = dto.DEMIR_LOJISTIGI_VE_DESTEGI,
            DVITAMINI_LOJISTIGI_VE_DESTEGI = dto.DVITAMINI_LOJISTIGI_VE_DESTEGI,
            KONJENITAL_ANOMALI_VARLIGI = dto.KONJENITAL_ANOMALI_VARLIGI,
            FETUS_KALP_SESI = dto.FETUS_KALP_SESI,
            DIASTOLIK_KAN_BASINCI_DEGERI = dto.DIASTOLIK_KAN_BASINCI_DEGERI,
            SISTOLIK_KAN_BASINCI_DEGERI = dto.SISTOLIK_KAN_BASINCI_DEGERI,
            GEBELIKTE_RISK_FAKTORLERI = dto.GEBELIKTE_RISK_FAKTORLERI,
            BC_BEYIN_GELISIM_RISKLERI = dto.BC_BEYIN_GELISIM_RISKLERI,
            PSIKOLOJIK_GELISIM_RISK_EGITIM = dto.PSIKOLOJIK_GELISIM_RISK_EGITIM,
            RISK_FAKTORLERINE_MUDAHALE = dto.RISK_FAKTORLERINE_MUDAHALE,
            RISK_ALTINDAKI_OLGU_TAKIBI = dto.RISK_ALTINDAKI_OLGU_TAKIBI,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<GEBE_IZLEM>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.GEBE_IZLEM_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.GebeIzlem)]
    public async Task<IActionResult> Update(string id, GebeIzlemDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<GEBE_IZLEM>()
            .FirstOrDefaultAsync(e => e.GEBE_IZLEM_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.KACINCI_GEBE_IZLEM = dto.KACINCI_GEBE_IZLEM;
        entity.SON_ADET_TARIHI = dto.SON_ADET_TARIHI;
        entity.ONCEKI_DOGUM_DURUMU = dto.ONCEKI_DOGUM_DURUMU;
        entity.GEBE_IZLEM_ISLEM_TURU = dto.GEBE_IZLEM_ISLEM_TURU;
        entity.GESTASYONEL_DIYABET_TARAMASI = dto.GESTASYONEL_DIYABET_TARAMASI;
        entity.IDRARDA_PROTEIN = dto.IDRARDA_PROTEIN;
        entity.HEMOGLOBIN_DEGERI = dto.HEMOGLOBIN_DEGERI;
        entity.DEMIR_LOJISTIGI_VE_DESTEGI = dto.DEMIR_LOJISTIGI_VE_DESTEGI;
        entity.DVITAMINI_LOJISTIGI_VE_DESTEGI = dto.DVITAMINI_LOJISTIGI_VE_DESTEGI;
        entity.KONJENITAL_ANOMALI_VARLIGI = dto.KONJENITAL_ANOMALI_VARLIGI;
        entity.FETUS_KALP_SESI = dto.FETUS_KALP_SESI;
        entity.DIASTOLIK_KAN_BASINCI_DEGERI = dto.DIASTOLIK_KAN_BASINCI_DEGERI;
        entity.SISTOLIK_KAN_BASINCI_DEGERI = dto.SISTOLIK_KAN_BASINCI_DEGERI;
        entity.GEBELIKTE_RISK_FAKTORLERI = dto.GEBELIKTE_RISK_FAKTORLERI;
        entity.BC_BEYIN_GELISIM_RISKLERI = dto.BC_BEYIN_GELISIM_RISKLERI;
        entity.PSIKOLOJIK_GELISIM_RISK_EGITIM = dto.PSIKOLOJIK_GELISIM_RISK_EGITIM;
        entity.RISK_FAKTORLERINE_MUDAHALE = dto.RISK_FAKTORLERINE_MUDAHALE;
        entity.RISK_ALTINDAKI_OLGU_TAKIBI = dto.RISK_ALTINDAKI_OLGU_TAKIBI;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.GebeIzlem)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<GEBE_IZLEM>()
            .FirstOrDefaultAsync(e => e.GEBE_IZLEM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<GEBE_IZLEM>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
