using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.NobetciPersonelBilgisi;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class NobetciPersonelBilgisiController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public NobetciPersonelBilgisiController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.NobetciPersonelBilgisi)]
    public async Task<List<NobetciPersonelBilgisiDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<NOBETCI_PERSONEL_BILGISI>()
            .AsNoTracking()
            .Select(e => new NobetciPersonelBilgisiDto
            {
                NOBETCI_PERSONEL_BILGISI_KODU = e.NOBETCI_PERSONEL_BILGISI_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                SKRS_KURUM_KODU = e.SKRS_KURUM_KODU,
                PERSONEL_TC_KIMLIK_NUMARASI = e.PERSONEL_TC_KIMLIK_NUMARASI,
                KLINIK_KODU = e.KLINIK_KODU,
                GOREV_TURU = e.GOREV_TURU,
                PERSONEL_GOREV_KODU = e.PERSONEL_GOREV_KODU,
                NOBET_BASLANGIC_TARIHI = e.NOBET_BASLANGIC_TARIHI,
                NOBET_BITIS_TARIHI = e.NOBET_BITIS_TARIHI,
                TELEFON_NUMARASI = e.TELEFON_NUMARASI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.NobetciPersonelBilgisi)]
    public async Task<ActionResult<NobetciPersonelBilgisiDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<NOBETCI_PERSONEL_BILGISI>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.NOBETCI_PERSONEL_BILGISI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new NobetciPersonelBilgisiDto
        {
            NOBETCI_PERSONEL_BILGISI_KODU = entity.NOBETCI_PERSONEL_BILGISI_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            SKRS_KURUM_KODU = entity.SKRS_KURUM_KODU,
            PERSONEL_TC_KIMLIK_NUMARASI = entity.PERSONEL_TC_KIMLIK_NUMARASI,
            KLINIK_KODU = entity.KLINIK_KODU,
            GOREV_TURU = entity.GOREV_TURU,
            PERSONEL_GOREV_KODU = entity.PERSONEL_GOREV_KODU,
            NOBET_BASLANGIC_TARIHI = entity.NOBET_BASLANGIC_TARIHI,
            NOBET_BITIS_TARIHI = entity.NOBET_BITIS_TARIHI,
            TELEFON_NUMARASI = entity.TELEFON_NUMARASI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.NobetciPersonelBilgisi)]
    public async Task<ActionResult<string>> Create(NobetciPersonelBilgisiDto dto, CancellationToken ct)
    {
        var entity = new NOBETCI_PERSONEL_BILGISI
        {
            NOBETCI_PERSONEL_BILGISI_KODU = dto.NOBETCI_PERSONEL_BILGISI_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            SKRS_KURUM_KODU = dto.SKRS_KURUM_KODU,
            PERSONEL_TC_KIMLIK_NUMARASI = dto.PERSONEL_TC_KIMLIK_NUMARASI,
            KLINIK_KODU = dto.KLINIK_KODU,
            GOREV_TURU = dto.GOREV_TURU,
            PERSONEL_GOREV_KODU = dto.PERSONEL_GOREV_KODU,
            NOBET_BASLANGIC_TARIHI = dto.NOBET_BASLANGIC_TARIHI,
            NOBET_BITIS_TARIHI = dto.NOBET_BITIS_TARIHI,
            TELEFON_NUMARASI = dto.TELEFON_NUMARASI,
        };

        _db.Set<NOBETCI_PERSONEL_BILGISI>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.NOBETCI_PERSONEL_BILGISI_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.NobetciPersonelBilgisi)]
    public async Task<IActionResult> Update(string id, NobetciPersonelBilgisiDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<NOBETCI_PERSONEL_BILGISI>()
            .FirstOrDefaultAsync(e => e.NOBETCI_PERSONEL_BILGISI_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.SKRS_KURUM_KODU = dto.SKRS_KURUM_KODU;
        entity.PERSONEL_TC_KIMLIK_NUMARASI = dto.PERSONEL_TC_KIMLIK_NUMARASI;
        entity.KLINIK_KODU = dto.KLINIK_KODU;
        entity.GOREV_TURU = dto.GOREV_TURU;
        entity.PERSONEL_GOREV_KODU = dto.PERSONEL_GOREV_KODU;
        entity.NOBET_BASLANGIC_TARIHI = dto.NOBET_BASLANGIC_TARIHI;
        entity.NOBET_BITIS_TARIHI = dto.NOBET_BITIS_TARIHI;
        entity.TELEFON_NUMARASI = dto.TELEFON_NUMARASI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.NobetciPersonelBilgisi)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<NOBETCI_PERSONEL_BILGISI>()
            .FirstOrDefaultAsync(e => e.NOBETCI_PERSONEL_BILGISI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<NOBETCI_PERSONEL_BILGISI>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
