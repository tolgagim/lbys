using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Hasta;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class HastaController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public HastaController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Hasta)]
    public async Task<List<HastaDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<HASTA>()
            .AsNoTracking()
            .Select(e => new HastaDto
            {
                HASTA_KODU = e.HASTA_KODU,
                TC_KIMLIK_NO = e.TC_KIMLIK_NO,
                AD = e.AD,
                SOYAD = e.SOYAD,
                CINSIYET = e.CINSIYET,
                DOGUM_TARIHI = e.DOGUM_TARIHI,
                DOGUM_YERI = e.DOGUM_YERI,
                ANA_ADI = e.ANA_ADI,
                BABA_ADI = e.BABA_ADI,
                KAN_GRUBU = e.KAN_GRUBU,
                MEDENI_HAL = e.MEDENI_HAL,
                UYRUK = e.UYRUK,
                MESLEK = e.MESLEK,
                EGITIM_DURUMU = e.EGITIM_DURUMU,
                IL_KODU = e.IL_KODU,
                ILCE_KODU = e.ILCE_KODU,
                ADRES = e.ADRES,
                TELEFON = e.TELEFON,
                CEP_TELEFON = e.CEP_TELEFON,
                EMAIL = e.EMAIL,
                SOSYAL_GUVENCE = e.SOSYAL_GUVENCE,
                SIGORTA_NO = e.SIGORTA_NO,
                PROTOKOL_NO = e.PROTOKOL_NO,
                AKTIF = e.AKTIF,
                OLUM_TARIHI = e.OLUM_TARIHI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Hasta)]
    public async Task<ActionResult<HastaDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.HASTA_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new HastaDto
        {
            HASTA_KODU = entity.HASTA_KODU,
            TC_KIMLIK_NO = entity.TC_KIMLIK_NO,
            AD = entity.AD,
            SOYAD = entity.SOYAD,
            CINSIYET = entity.CINSIYET,
            DOGUM_TARIHI = entity.DOGUM_TARIHI,
            DOGUM_YERI = entity.DOGUM_YERI,
            ANA_ADI = entity.ANA_ADI,
            BABA_ADI = entity.BABA_ADI,
            KAN_GRUBU = entity.KAN_GRUBU,
            MEDENI_HAL = entity.MEDENI_HAL,
            UYRUK = entity.UYRUK,
            MESLEK = entity.MESLEK,
            EGITIM_DURUMU = entity.EGITIM_DURUMU,
            IL_KODU = entity.IL_KODU,
            ILCE_KODU = entity.ILCE_KODU,
            ADRES = entity.ADRES,
            TELEFON = entity.TELEFON,
            CEP_TELEFON = entity.CEP_TELEFON,
            EMAIL = entity.EMAIL,
            SOSYAL_GUVENCE = entity.SOSYAL_GUVENCE,
            SIGORTA_NO = entity.SIGORTA_NO,
            PROTOKOL_NO = entity.PROTOKOL_NO,
            AKTIF = entity.AKTIF,
            OLUM_TARIHI = entity.OLUM_TARIHI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Hasta)]
    public async Task<ActionResult<string>> Create(HastaDto dto, CancellationToken ct)
    {
        var entity = new HASTA
        {
            HASTA_KODU = dto.HASTA_KODU,
            TC_KIMLIK_NO = dto.TC_KIMLIK_NO,
            AD = dto.AD,
            SOYAD = dto.SOYAD,
            CINSIYET = dto.CINSIYET,
            DOGUM_TARIHI = dto.DOGUM_TARIHI,
            DOGUM_YERI = dto.DOGUM_YERI,
            ANA_ADI = dto.ANA_ADI,
            BABA_ADI = dto.BABA_ADI,
            KAN_GRUBU = dto.KAN_GRUBU,
            MEDENI_HAL = dto.MEDENI_HAL,
            UYRUK = dto.UYRUK,
            MESLEK = dto.MESLEK,
            EGITIM_DURUMU = dto.EGITIM_DURUMU,
            IL_KODU = dto.IL_KODU,
            ILCE_KODU = dto.ILCE_KODU,
            ADRES = dto.ADRES,
            TELEFON = dto.TELEFON,
            CEP_TELEFON = dto.CEP_TELEFON,
            EMAIL = dto.EMAIL,
            SOSYAL_GUVENCE = dto.SOSYAL_GUVENCE,
            SIGORTA_NO = dto.SIGORTA_NO,
            PROTOKOL_NO = dto.PROTOKOL_NO,
            AKTIF = dto.AKTIF,
            OLUM_TARIHI = dto.OLUM_TARIHI,
        };

        _db.Set<HASTA>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.HASTA_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Hasta)]
    public async Task<IActionResult> Update(string id, HastaDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA>()
            .FirstOrDefaultAsync(e => e.HASTA_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.TC_KIMLIK_NO = dto.TC_KIMLIK_NO;
        entity.AD = dto.AD;
        entity.SOYAD = dto.SOYAD;
        entity.CINSIYET = dto.CINSIYET;
        entity.DOGUM_TARIHI = dto.DOGUM_TARIHI;
        entity.DOGUM_YERI = dto.DOGUM_YERI;
        entity.ANA_ADI = dto.ANA_ADI;
        entity.BABA_ADI = dto.BABA_ADI;
        entity.KAN_GRUBU = dto.KAN_GRUBU;
        entity.MEDENI_HAL = dto.MEDENI_HAL;
        entity.UYRUK = dto.UYRUK;
        entity.MESLEK = dto.MESLEK;
        entity.EGITIM_DURUMU = dto.EGITIM_DURUMU;
        entity.IL_KODU = dto.IL_KODU;
        entity.ILCE_KODU = dto.ILCE_KODU;
        entity.ADRES = dto.ADRES;
        entity.TELEFON = dto.TELEFON;
        entity.CEP_TELEFON = dto.CEP_TELEFON;
        entity.EMAIL = dto.EMAIL;
        entity.SOSYAL_GUVENCE = dto.SOSYAL_GUVENCE;
        entity.SIGORTA_NO = dto.SIGORTA_NO;
        entity.PROTOKOL_NO = dto.PROTOKOL_NO;
        entity.AKTIF = dto.AKTIF;
        entity.OLUM_TARIHI = dto.OLUM_TARIHI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Hasta)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA>()
            .FirstOrDefaultAsync(e => e.HASTA_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<HASTA>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
