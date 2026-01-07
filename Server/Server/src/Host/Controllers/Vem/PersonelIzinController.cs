using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.PersonelIzin;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class PersonelIzinController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public PersonelIzinController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.PersonelIzin)]
    public async Task<List<PersonelIzinDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<PERSONEL_IZIN>()
            .AsNoTracking()
            .Select(e => new PersonelIzinDto
            {
                PERSONEL_IZIN_KODU = e.PERSONEL_IZIN_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                PERSONEL_KODU = e.PERSONEL_KODU,
                PERSONEL_IZIN_TURU = e.PERSONEL_IZIN_TURU,
                KULLANILAN_IZIN = e.KULLANILAN_IZIN,
                GECEN_YILDAN_KULLANILAN_IZIN = e.GECEN_YILDAN_KULLANILAN_IZIN,
                AKTIF_YILDAN_KULLANILAN_IZIN = e.AKTIF_YILDAN_KULLANILAN_IZIN,
                IZIN_BASLAMA_TARIHI = e.IZIN_BASLAMA_TARIHI,
                IZIN_BITIS_TARIHI = e.IZIN_BITIS_TARIHI,
                PERSONEL_IZIN_YILI = e.PERSONEL_IZIN_YILI,
                PERSONEL_DONUS_TARIHI = e.PERSONEL_DONUS_TARIHI,
                IZIN_ADRESI = e.IZIN_ADRESI,
                ACIKLAMA = e.ACIKLAMA,
                SBYS_ENGELLENME_DURUMU = e.SBYS_ENGELLENME_DURUMU,
                SBYS_KULLANIM_ENGELLEME_ZAMANI = e.SBYS_KULLANIM_ENGELLEME_ZAMANI,
                SBYS_ENGELLEYEN_KULLANICI_KODU = e.SBYS_ENGELLEYEN_KULLANICI_KODU,
                ONAYLAYAN_PERSONEL_KODU = e.ONAYLAYAN_PERSONEL_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.PersonelIzin)]
    public async Task<ActionResult<PersonelIzinDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_IZIN>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.PERSONEL_IZIN_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new PersonelIzinDto
        {
            PERSONEL_IZIN_KODU = entity.PERSONEL_IZIN_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            PERSONEL_KODU = entity.PERSONEL_KODU,
            PERSONEL_IZIN_TURU = entity.PERSONEL_IZIN_TURU,
            KULLANILAN_IZIN = entity.KULLANILAN_IZIN,
            GECEN_YILDAN_KULLANILAN_IZIN = entity.GECEN_YILDAN_KULLANILAN_IZIN,
            AKTIF_YILDAN_KULLANILAN_IZIN = entity.AKTIF_YILDAN_KULLANILAN_IZIN,
            IZIN_BASLAMA_TARIHI = entity.IZIN_BASLAMA_TARIHI,
            IZIN_BITIS_TARIHI = entity.IZIN_BITIS_TARIHI,
            PERSONEL_IZIN_YILI = entity.PERSONEL_IZIN_YILI,
            PERSONEL_DONUS_TARIHI = entity.PERSONEL_DONUS_TARIHI,
            IZIN_ADRESI = entity.IZIN_ADRESI,
            ACIKLAMA = entity.ACIKLAMA,
            SBYS_ENGELLENME_DURUMU = entity.SBYS_ENGELLENME_DURUMU,
            SBYS_KULLANIM_ENGELLEME_ZAMANI = entity.SBYS_KULLANIM_ENGELLEME_ZAMANI,
            SBYS_ENGELLEYEN_KULLANICI_KODU = entity.SBYS_ENGELLEYEN_KULLANICI_KODU,
            ONAYLAYAN_PERSONEL_KODU = entity.ONAYLAYAN_PERSONEL_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.PersonelIzin)]
    public async Task<ActionResult<string>> Create(PersonelIzinDto dto, CancellationToken ct)
    {
        var entity = new PERSONEL_IZIN
        {
            PERSONEL_IZIN_KODU = dto.PERSONEL_IZIN_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            PERSONEL_KODU = dto.PERSONEL_KODU,
            PERSONEL_IZIN_TURU = dto.PERSONEL_IZIN_TURU,
            KULLANILAN_IZIN = dto.KULLANILAN_IZIN,
            GECEN_YILDAN_KULLANILAN_IZIN = dto.GECEN_YILDAN_KULLANILAN_IZIN,
            AKTIF_YILDAN_KULLANILAN_IZIN = dto.AKTIF_YILDAN_KULLANILAN_IZIN,
            IZIN_BASLAMA_TARIHI = dto.IZIN_BASLAMA_TARIHI,
            IZIN_BITIS_TARIHI = dto.IZIN_BITIS_TARIHI,
            PERSONEL_IZIN_YILI = dto.PERSONEL_IZIN_YILI,
            PERSONEL_DONUS_TARIHI = dto.PERSONEL_DONUS_TARIHI,
            IZIN_ADRESI = dto.IZIN_ADRESI,
            ACIKLAMA = dto.ACIKLAMA,
            SBYS_ENGELLENME_DURUMU = dto.SBYS_ENGELLENME_DURUMU,
            SBYS_KULLANIM_ENGELLEME_ZAMANI = dto.SBYS_KULLANIM_ENGELLEME_ZAMANI,
            SBYS_ENGELLEYEN_KULLANICI_KODU = dto.SBYS_ENGELLEYEN_KULLANICI_KODU,
            ONAYLAYAN_PERSONEL_KODU = dto.ONAYLAYAN_PERSONEL_KODU,
        };

        _db.Set<PERSONEL_IZIN>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.PERSONEL_IZIN_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.PersonelIzin)]
    public async Task<IActionResult> Update(string id, PersonelIzinDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_IZIN>()
            .FirstOrDefaultAsync(e => e.PERSONEL_IZIN_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.PERSONEL_KODU = dto.PERSONEL_KODU;
        entity.PERSONEL_IZIN_TURU = dto.PERSONEL_IZIN_TURU;
        entity.KULLANILAN_IZIN = dto.KULLANILAN_IZIN;
        entity.GECEN_YILDAN_KULLANILAN_IZIN = dto.GECEN_YILDAN_KULLANILAN_IZIN;
        entity.AKTIF_YILDAN_KULLANILAN_IZIN = dto.AKTIF_YILDAN_KULLANILAN_IZIN;
        entity.IZIN_BASLAMA_TARIHI = dto.IZIN_BASLAMA_TARIHI;
        entity.IZIN_BITIS_TARIHI = dto.IZIN_BITIS_TARIHI;
        entity.PERSONEL_IZIN_YILI = dto.PERSONEL_IZIN_YILI;
        entity.PERSONEL_DONUS_TARIHI = dto.PERSONEL_DONUS_TARIHI;
        entity.IZIN_ADRESI = dto.IZIN_ADRESI;
        entity.ACIKLAMA = dto.ACIKLAMA;
        entity.SBYS_ENGELLENME_DURUMU = dto.SBYS_ENGELLENME_DURUMU;
        entity.SBYS_KULLANIM_ENGELLEME_ZAMANI = dto.SBYS_KULLANIM_ENGELLEME_ZAMANI;
        entity.SBYS_ENGELLEYEN_KULLANICI_KODU = dto.SBYS_ENGELLEYEN_KULLANICI_KODU;
        entity.ONAYLAYAN_PERSONEL_KODU = dto.ONAYLAYAN_PERSONEL_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.PersonelIzin)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_IZIN>()
            .FirstOrDefaultAsync(e => e.PERSONEL_IZIN_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<PERSONEL_IZIN>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
