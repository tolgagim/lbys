using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Hemoglobinopati;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class HemoglobinopatiController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public HemoglobinopatiController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Hemoglobinopati)]
    public async Task<List<HemoglobinopatiDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<HEMOGLOBINOPATI>()
            .AsNoTracking()
            .Select(e => new HemoglobinopatiDto
            {
                HEMOGLOBINOPATI_KODU = e.HEMOGLOBINOPATI_KODU,
HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                HEMOGLOBINOPATI_TARAMA_SONUCU = e.HEMOGLOBINOPATI_TARAMA_SONUCU,
                ES_ADAYI_TC_KIMLIK_NUMARASI = e.ES_ADAYI_TC_KIMLIK_NUMARASI,
                ES_ADAYI_TELEFON_NUMARASI = e.ES_ADAYI_TELEFON_NUMARASI,
                HEMOGLOBINOPATI_TESTI_SONUCU = e.HEMOGLOBINOPATI_TESTI_SONUCU,
                HEMOGLOBINOPATI_ISLEM_TIPI = e.HEMOGLOBINOPATI_ISLEM_TIPI,
                HEMOGLOBINOPATI_SONUC_HASTALIK = e.HEMOGLOBINOPATI_SONUC_HASTALIK,
                HEMOGLOBINOPATI_TASIYICILIK = e.HEMOGLOBINOPATI_TASIYICILIK,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Hemoglobinopati)]
    public async Task<ActionResult<HemoglobinopatiDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HEMOGLOBINOPATI>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.HEMOGLOBINOPATI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new HemoglobinopatiDto
        {
            HEMOGLOBINOPATI_KODU = entity.HEMOGLOBINOPATI_KODU,
HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            HEMOGLOBINOPATI_TARAMA_SONUCU = entity.HEMOGLOBINOPATI_TARAMA_SONUCU,
            ES_ADAYI_TC_KIMLIK_NUMARASI = entity.ES_ADAYI_TC_KIMLIK_NUMARASI,
            ES_ADAYI_TELEFON_NUMARASI = entity.ES_ADAYI_TELEFON_NUMARASI,
            HEMOGLOBINOPATI_TESTI_SONUCU = entity.HEMOGLOBINOPATI_TESTI_SONUCU,
            HEMOGLOBINOPATI_ISLEM_TIPI = entity.HEMOGLOBINOPATI_ISLEM_TIPI,
            HEMOGLOBINOPATI_SONUC_HASTALIK = entity.HEMOGLOBINOPATI_SONUC_HASTALIK,
            HEMOGLOBINOPATI_TASIYICILIK = entity.HEMOGLOBINOPATI_TASIYICILIK,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Hemoglobinopati)]
    public async Task<ActionResult<string>> Create(HemoglobinopatiDto dto, CancellationToken ct)
    {
        var entity = new HEMOGLOBINOPATI
        {
            HEMOGLOBINOPATI_KODU = dto.HEMOGLOBINOPATI_KODU,
HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            HEMOGLOBINOPATI_TARAMA_SONUCU = dto.HEMOGLOBINOPATI_TARAMA_SONUCU,
            ES_ADAYI_TC_KIMLIK_NUMARASI = dto.ES_ADAYI_TC_KIMLIK_NUMARASI,
            ES_ADAYI_TELEFON_NUMARASI = dto.ES_ADAYI_TELEFON_NUMARASI,
            HEMOGLOBINOPATI_TESTI_SONUCU = dto.HEMOGLOBINOPATI_TESTI_SONUCU,
            HEMOGLOBINOPATI_ISLEM_TIPI = dto.HEMOGLOBINOPATI_ISLEM_TIPI,
            HEMOGLOBINOPATI_SONUC_HASTALIK = dto.HEMOGLOBINOPATI_SONUC_HASTALIK,
            HEMOGLOBINOPATI_TASIYICILIK = dto.HEMOGLOBINOPATI_TASIYICILIK,
        };

        _db.Set<HEMOGLOBINOPATI>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.HEMOGLOBINOPATI_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Hemoglobinopati)]
    public async Task<IActionResult> Update(string id, HemoglobinopatiDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<HEMOGLOBINOPATI>()
            .FirstOrDefaultAsync(e => e.HEMOGLOBINOPATI_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.HEMOGLOBINOPATI_TARAMA_SONUCU = dto.HEMOGLOBINOPATI_TARAMA_SONUCU;
        entity.ES_ADAYI_TC_KIMLIK_NUMARASI = dto.ES_ADAYI_TC_KIMLIK_NUMARASI;
        entity.ES_ADAYI_TELEFON_NUMARASI = dto.ES_ADAYI_TELEFON_NUMARASI;
        entity.HEMOGLOBINOPATI_TESTI_SONUCU = dto.HEMOGLOBINOPATI_TESTI_SONUCU;
        entity.HEMOGLOBINOPATI_ISLEM_TIPI = dto.HEMOGLOBINOPATI_ISLEM_TIPI;
        entity.HEMOGLOBINOPATI_SONUC_HASTALIK = dto.HEMOGLOBINOPATI_SONUC_HASTALIK;
        entity.HEMOGLOBINOPATI_TASIYICILIK = dto.HEMOGLOBINOPATI_TASIYICILIK;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Hemoglobinopati)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HEMOGLOBINOPATI>()
            .FirstOrDefaultAsync(e => e.HEMOGLOBINOPATI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<HEMOGLOBINOPATI>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
