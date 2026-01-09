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
                TC_KIMLIK_NUMARASI = e.TC_KIMLIK_NUMARASI,
                AD = e.AD,
                SOYADI = e.SOYADI,
                CINSIYET = e.CINSIYET,
                DOGUM_TARIHI = e.DOGUM_TARIHI,
                DOGUM_YERI = e.DOGUM_YERI,
                ANNE_ADI = e.ANNE_ADI,
                BABA_ADI = e.BABA_ADI,
                KAN_GRUBU = e.KAN_GRUBU,
                MEDENI_HALI = e.MEDENI_HALI,
                UYRUK = e.UYRUK,
                MESLEK = e.MESLEK,
                OGRENIM_DURUMU = e.OGRENIM_DURUMU,
                OLUM_TARIHI = e.OLUM_TARIHI,
                OLUM_YERI = e.OLUM_YERI,
                ANNE_HASTA_KODU = e.ANNE_HASTA_KODU,
                ANNE_TC_KIMLIK_NUMARASI = e.ANNE_TC_KIMLIK_NUMARASI,
                BABA_HASTA_KODU = e.BABA_HASTA_KODU,
                BABA_TC_KIMLIK_NUMARASI = e.BABA_TC_KIMLIK_NUMARASI,
                BEYAN_DOGUM_TARIHI = e.BEYAN_DOGUM_TARIHI,
                DOGUM_SIRASI = e.DOGUM_SIRASI,
                ENGELLILIK_DURUMU = e.ENGELLILIK_DURUMU,
                HASTA_TIPI = e.HASTA_TIPI,
                KIMLIKSIZ_HASTA_BILGISI = e.KIMLIKSIZ_HASTA_BILGISI,
                MUAYENE_ONCELIK_SIRASI = e.MUAYENE_ONCELIK_SIRASI,
                PASAPORT_NUMARASI = e.PASAPORT_NUMARASI,
                SON_KURUM_KODU = e.SON_KURUM_KODU,
                YUPASS_NUMARASI = e.YUPASS_NUMARASI,
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
            TC_KIMLIK_NUMARASI = entity.TC_KIMLIK_NUMARASI,
            AD = entity.AD,
            SOYADI = entity.SOYADI,
            CINSIYET = entity.CINSIYET,
            DOGUM_TARIHI = entity.DOGUM_TARIHI,
            DOGUM_YERI = entity.DOGUM_YERI,
            ANNE_ADI = entity.ANNE_ADI,
            BABA_ADI = entity.BABA_ADI,
            KAN_GRUBU = entity.KAN_GRUBU,
            MEDENI_HALI = entity.MEDENI_HALI,
            UYRUK = entity.UYRUK,
            MESLEK = entity.MESLEK,
            OGRENIM_DURUMU = entity.OGRENIM_DURUMU,
            OLUM_TARIHI = entity.OLUM_TARIHI,
            OLUM_YERI = entity.OLUM_YERI,
            ANNE_HASTA_KODU = entity.ANNE_HASTA_KODU,
            ANNE_TC_KIMLIK_NUMARASI = entity.ANNE_TC_KIMLIK_NUMARASI,
            BABA_HASTA_KODU = entity.BABA_HASTA_KODU,
            BABA_TC_KIMLIK_NUMARASI = entity.BABA_TC_KIMLIK_NUMARASI,
            BEYAN_DOGUM_TARIHI = entity.BEYAN_DOGUM_TARIHI,
            DOGUM_SIRASI = entity.DOGUM_SIRASI,
            ENGELLILIK_DURUMU = entity.ENGELLILIK_DURUMU,
            HASTA_TIPI = entity.HASTA_TIPI,
            KIMLIKSIZ_HASTA_BILGISI = entity.KIMLIKSIZ_HASTA_BILGISI,
            MUAYENE_ONCELIK_SIRASI = entity.MUAYENE_ONCELIK_SIRASI,
            PASAPORT_NUMARASI = entity.PASAPORT_NUMARASI,
            SON_KURUM_KODU = entity.SON_KURUM_KODU,
            YUPASS_NUMARASI = entity.YUPASS_NUMARASI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Hasta)]
    public async Task<ActionResult<string>> Create(HastaDto dto, CancellationToken ct)
    {
        var entity = new HASTA
        {
            HASTA_KODU = dto.HASTA_KODU,
            TC_KIMLIK_NUMARASI = dto.TC_KIMLIK_NUMARASI,
            AD = dto.AD,
            SOYADI = dto.SOYADI,
            CINSIYET = dto.CINSIYET,
            DOGUM_TARIHI = dto.DOGUM_TARIHI,
            DOGUM_YERI = dto.DOGUM_YERI,
            ANNE_ADI = dto.ANNE_ADI,
            BABA_ADI = dto.BABA_ADI,
            KAN_GRUBU = dto.KAN_GRUBU,
            MEDENI_HALI = dto.MEDENI_HALI,
            UYRUK = dto.UYRUK,
            MESLEK = dto.MESLEK,
            OGRENIM_DURUMU = dto.OGRENIM_DURUMU,
            OLUM_TARIHI = dto.OLUM_TARIHI,
            OLUM_YERI = dto.OLUM_YERI,
            ANNE_HASTA_KODU = dto.ANNE_HASTA_KODU,
            ANNE_TC_KIMLIK_NUMARASI = dto.ANNE_TC_KIMLIK_NUMARASI,
            BABA_HASTA_KODU = dto.BABA_HASTA_KODU,
            BABA_TC_KIMLIK_NUMARASI = dto.BABA_TC_KIMLIK_NUMARASI,
            BEYAN_DOGUM_TARIHI = dto.BEYAN_DOGUM_TARIHI,
            DOGUM_SIRASI = dto.DOGUM_SIRASI,
            ENGELLILIK_DURUMU = dto.ENGELLILIK_DURUMU,
            HASTA_TIPI = dto.HASTA_TIPI,
            KIMLIKSIZ_HASTA_BILGISI = dto.KIMLIKSIZ_HASTA_BILGISI,
            MUAYENE_ONCELIK_SIRASI = dto.MUAYENE_ONCELIK_SIRASI,
            PASAPORT_NUMARASI = dto.PASAPORT_NUMARASI,
            SON_KURUM_KODU = dto.SON_KURUM_KODU,
            YUPASS_NUMARASI = dto.YUPASS_NUMARASI,
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

        entity.TC_KIMLIK_NUMARASI = dto.TC_KIMLIK_NUMARASI;
        entity.AD = dto.AD;
        entity.SOYADI = dto.SOYADI;
        entity.CINSIYET = dto.CINSIYET;
        entity.DOGUM_TARIHI = dto.DOGUM_TARIHI;
        entity.DOGUM_YERI = dto.DOGUM_YERI;
        entity.ANNE_ADI = dto.ANNE_ADI;
        entity.BABA_ADI = dto.BABA_ADI;
        entity.KAN_GRUBU = dto.KAN_GRUBU;
        entity.MEDENI_HALI = dto.MEDENI_HALI;
        entity.UYRUK = dto.UYRUK;
        entity.MESLEK = dto.MESLEK;
        entity.OGRENIM_DURUMU = dto.OGRENIM_DURUMU;
        entity.OLUM_TARIHI = dto.OLUM_TARIHI;
        entity.OLUM_YERI = dto.OLUM_YERI;
        entity.ANNE_HASTA_KODU = dto.ANNE_HASTA_KODU;
        entity.ANNE_TC_KIMLIK_NUMARASI = dto.ANNE_TC_KIMLIK_NUMARASI;
        entity.BABA_HASTA_KODU = dto.BABA_HASTA_KODU;
        entity.BABA_TC_KIMLIK_NUMARASI = dto.BABA_TC_KIMLIK_NUMARASI;
        entity.BEYAN_DOGUM_TARIHI = dto.BEYAN_DOGUM_TARIHI;
        entity.DOGUM_SIRASI = dto.DOGUM_SIRASI;
        entity.ENGELLILIK_DURUMU = dto.ENGELLILIK_DURUMU;
        entity.HASTA_TIPI = dto.HASTA_TIPI;
        entity.KIMLIKSIZ_HASTA_BILGISI = dto.KIMLIKSIZ_HASTA_BILGISI;
        entity.MUAYENE_ONCELIK_SIRASI = dto.MUAYENE_ONCELIK_SIRASI;
        entity.PASAPORT_NUMARASI = dto.PASAPORT_NUMARASI;
        entity.SON_KURUM_KODU = dto.SON_KURUM_KODU;
        entity.YUPASS_NUMARASI = dto.YUPASS_NUMARASI;

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
