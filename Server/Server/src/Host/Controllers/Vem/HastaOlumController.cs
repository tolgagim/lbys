using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.HastaOlum;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class HastaOlumController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public HastaOlumController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.HastaOlum)]
    public async Task<List<HastaOlumDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<HASTA_OLUM>()
            .AsNoTracking()
            .Select(e => new HastaOlumDto
            {
                HASTA_OLUM_KODU = e.HASTA_OLUM_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                OLUM_ZAMANI = e.OLUM_ZAMANI,
                OLUM_YERI = e.OLUM_YERI,
                ANNE_OLUM_NEDENI = e.ANNE_OLUM_NEDENI,
                ACIKLAMA = e.ACIKLAMA,
                OTOPSI_DURUMU = e.OTOPSI_DURUMU,
                OLUM_BELGESI_PERSONEL_KODU = e.OLUM_BELGESI_PERSONEL_KODU,
                OLUM_NEDENI_TANI_KODU = e.OLUM_NEDENI_TANI_KODU,
                OLUM_NEDENI_TURU = e.OLUM_NEDENI_TURU,
                OLUM_SEKLI = e.OLUM_SEKLI,
                EX_KARARINI_VEREN_HEKIM_KODU = e.EX_KARARINI_VEREN_HEKIM_KODU,
                TUTANAK_ZAMANI = e.TUTANAK_ZAMANI,
                TESLIM_ALAN_TC_KIMLIK_NUMARASI = e.TESLIM_ALAN_TC_KIMLIK_NUMARASI,
                TESLIM_ALAN_ADI_SOYADI = e.TESLIM_ALAN_ADI_SOYADI,
                TESLIM_ALAN_TELEFON_BILGISI = e.TESLIM_ALAN_TELEFON_BILGISI,
                TESLIM_ALAN_ADRESI = e.TESLIM_ALAN_ADRESI,
                TESLIM_EDEN_PERSONEL_KODU = e.TESLIM_EDEN_PERSONEL_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.HastaOlum)]
    public async Task<ActionResult<HastaOlumDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_OLUM>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.HASTA_OLUM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new HastaOlumDto
        {
            HASTA_OLUM_KODU = entity.HASTA_OLUM_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            OLUM_ZAMANI = entity.OLUM_ZAMANI,
            OLUM_YERI = entity.OLUM_YERI,
            ANNE_OLUM_NEDENI = entity.ANNE_OLUM_NEDENI,
            ACIKLAMA = entity.ACIKLAMA,
            OTOPSI_DURUMU = entity.OTOPSI_DURUMU,
            OLUM_BELGESI_PERSONEL_KODU = entity.OLUM_BELGESI_PERSONEL_KODU,
            OLUM_NEDENI_TANI_KODU = entity.OLUM_NEDENI_TANI_KODU,
            OLUM_NEDENI_TURU = entity.OLUM_NEDENI_TURU,
            OLUM_SEKLI = entity.OLUM_SEKLI,
            EX_KARARINI_VEREN_HEKIM_KODU = entity.EX_KARARINI_VEREN_HEKIM_KODU,
            TUTANAK_ZAMANI = entity.TUTANAK_ZAMANI,
            TESLIM_ALAN_TC_KIMLIK_NUMARASI = entity.TESLIM_ALAN_TC_KIMLIK_NUMARASI,
            TESLIM_ALAN_ADI_SOYADI = entity.TESLIM_ALAN_ADI_SOYADI,
            TESLIM_ALAN_TELEFON_BILGISI = entity.TESLIM_ALAN_TELEFON_BILGISI,
            TESLIM_ALAN_ADRESI = entity.TESLIM_ALAN_ADRESI,
            TESLIM_EDEN_PERSONEL_KODU = entity.TESLIM_EDEN_PERSONEL_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.HastaOlum)]
    public async Task<ActionResult<string>> Create(HastaOlumDto dto, CancellationToken ct)
    {
        var entity = new HASTA_OLUM
        {
            HASTA_OLUM_KODU = dto.HASTA_OLUM_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            OLUM_ZAMANI = dto.OLUM_ZAMANI,
            OLUM_YERI = dto.OLUM_YERI,
            ANNE_OLUM_NEDENI = dto.ANNE_OLUM_NEDENI,
            ACIKLAMA = dto.ACIKLAMA,
            OTOPSI_DURUMU = dto.OTOPSI_DURUMU,
            OLUM_BELGESI_PERSONEL_KODU = dto.OLUM_BELGESI_PERSONEL_KODU,
            OLUM_NEDENI_TANI_KODU = dto.OLUM_NEDENI_TANI_KODU,
            OLUM_NEDENI_TURU = dto.OLUM_NEDENI_TURU,
            OLUM_SEKLI = dto.OLUM_SEKLI,
            EX_KARARINI_VEREN_HEKIM_KODU = dto.EX_KARARINI_VEREN_HEKIM_KODU,
            TUTANAK_ZAMANI = dto.TUTANAK_ZAMANI,
            TESLIM_ALAN_TC_KIMLIK_NUMARASI = dto.TESLIM_ALAN_TC_KIMLIK_NUMARASI,
            TESLIM_ALAN_ADI_SOYADI = dto.TESLIM_ALAN_ADI_SOYADI,
            TESLIM_ALAN_TELEFON_BILGISI = dto.TESLIM_ALAN_TELEFON_BILGISI,
            TESLIM_ALAN_ADRESI = dto.TESLIM_ALAN_ADRESI,
            TESLIM_EDEN_PERSONEL_KODU = dto.TESLIM_EDEN_PERSONEL_KODU,
        };

        _db.Set<HASTA_OLUM>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.HASTA_OLUM_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.HastaOlum)]
    public async Task<IActionResult> Update(string id, HastaOlumDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_OLUM>()
            .FirstOrDefaultAsync(e => e.HASTA_OLUM_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.OLUM_ZAMANI = dto.OLUM_ZAMANI;
        entity.OLUM_YERI = dto.OLUM_YERI;
        entity.ANNE_OLUM_NEDENI = dto.ANNE_OLUM_NEDENI;
        entity.ACIKLAMA = dto.ACIKLAMA;
        entity.OTOPSI_DURUMU = dto.OTOPSI_DURUMU;
        entity.OLUM_BELGESI_PERSONEL_KODU = dto.OLUM_BELGESI_PERSONEL_KODU;
        entity.OLUM_NEDENI_TANI_KODU = dto.OLUM_NEDENI_TANI_KODU;
        entity.OLUM_NEDENI_TURU = dto.OLUM_NEDENI_TURU;
        entity.OLUM_SEKLI = dto.OLUM_SEKLI;
        entity.EX_KARARINI_VEREN_HEKIM_KODU = dto.EX_KARARINI_VEREN_HEKIM_KODU;
        entity.TUTANAK_ZAMANI = dto.TUTANAK_ZAMANI;
        entity.TESLIM_ALAN_TC_KIMLIK_NUMARASI = dto.TESLIM_ALAN_TC_KIMLIK_NUMARASI;
        entity.TESLIM_ALAN_ADI_SOYADI = dto.TESLIM_ALAN_ADI_SOYADI;
        entity.TESLIM_ALAN_TELEFON_BILGISI = dto.TESLIM_ALAN_TELEFON_BILGISI;
        entity.TESLIM_ALAN_ADRESI = dto.TESLIM_ALAN_ADRESI;
        entity.TESLIM_EDEN_PERSONEL_KODU = dto.TESLIM_EDEN_PERSONEL_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.HastaOlum)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_OLUM>()
            .FirstOrDefaultAsync(e => e.HASTA_OLUM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<HASTA_OLUM>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
