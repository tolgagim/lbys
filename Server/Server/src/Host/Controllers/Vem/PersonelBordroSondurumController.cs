using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.PersonelBordroSondurum;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class PersonelBordroSondurumController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public PersonelBordroSondurumController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.PersonelBordroSondurum)]
    public async Task<List<PersonelBordroSondurumDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<PERSONEL_BORDRO_SONDURUM>()
            .AsNoTracking()
            .Select(e => new PersonelBordroSondurumDto
            {
                PERSONEL_SONDURUM_KODU = e.PERSONEL_SONDURUM_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                PERSONEL_KODU = e.PERSONEL_KODU,
                PERSONEL_KADEMESI = e.PERSONEL_KADEMESI,
                PERSONEL_DERECESI = e.PERSONEL_DERECESI,
                EMEKLI_DERECESI = e.EMEKLI_DERECESI,
                EMEKLI_KADEMESI = e.EMEKLI_KADEMESI,
                SENDIKA_BILGISI = e.SENDIKA_BILGISI,
                KIDEM_YILI = e.KIDEM_YILI,
                KIDEM_AYI = e.KIDEM_AYI,
                KIDEM_GUNU = e.KIDEM_GUNU,
                EK_GOSTERGE = e.EK_GOSTERGE,
                EMEKLI_EK_GOSTERGESI = e.EMEKLI_EK_GOSTERGESI,
                GOSTERGE = e.GOSTERGE,
                EMEKLI_GOSTERGESI = e.EMEKLI_GOSTERGESI,
                YAN_ODEME_PUANI = e.YAN_ODEME_PUANI,
                OZEL_HIZMET_PUANI = e.OZEL_HIZMET_PUANI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.PersonelBordroSondurum)]
    public async Task<ActionResult<PersonelBordroSondurumDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_BORDRO_SONDURUM>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.PERSONEL_SONDURUM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new PersonelBordroSondurumDto
        {
            PERSONEL_SONDURUM_KODU = entity.PERSONEL_SONDURUM_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            PERSONEL_KODU = entity.PERSONEL_KODU,
            PERSONEL_KADEMESI = entity.PERSONEL_KADEMESI,
            PERSONEL_DERECESI = entity.PERSONEL_DERECESI,
            EMEKLI_DERECESI = entity.EMEKLI_DERECESI,
            EMEKLI_KADEMESI = entity.EMEKLI_KADEMESI,
            SENDIKA_BILGISI = entity.SENDIKA_BILGISI,
            KIDEM_YILI = entity.KIDEM_YILI,
            KIDEM_AYI = entity.KIDEM_AYI,
            KIDEM_GUNU = entity.KIDEM_GUNU,
            EK_GOSTERGE = entity.EK_GOSTERGE,
            EMEKLI_EK_GOSTERGESI = entity.EMEKLI_EK_GOSTERGESI,
            GOSTERGE = entity.GOSTERGE,
            EMEKLI_GOSTERGESI = entity.EMEKLI_GOSTERGESI,
            YAN_ODEME_PUANI = entity.YAN_ODEME_PUANI,
            OZEL_HIZMET_PUANI = entity.OZEL_HIZMET_PUANI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.PersonelBordroSondurum)]
    public async Task<ActionResult<string>> Create(PersonelBordroSondurumDto dto, CancellationToken ct)
    {
        var entity = new PERSONEL_BORDRO_SONDURUM
        {
            PERSONEL_SONDURUM_KODU = dto.PERSONEL_SONDURUM_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            PERSONEL_KODU = dto.PERSONEL_KODU,
            PERSONEL_KADEMESI = dto.PERSONEL_KADEMESI,
            PERSONEL_DERECESI = dto.PERSONEL_DERECESI,
            EMEKLI_DERECESI = dto.EMEKLI_DERECESI,
            EMEKLI_KADEMESI = dto.EMEKLI_KADEMESI,
            SENDIKA_BILGISI = dto.SENDIKA_BILGISI,
            KIDEM_YILI = dto.KIDEM_YILI,
            KIDEM_AYI = dto.KIDEM_AYI,
            KIDEM_GUNU = dto.KIDEM_GUNU,
            EK_GOSTERGE = dto.EK_GOSTERGE,
            EMEKLI_EK_GOSTERGESI = dto.EMEKLI_EK_GOSTERGESI,
            GOSTERGE = dto.GOSTERGE,
            EMEKLI_GOSTERGESI = dto.EMEKLI_GOSTERGESI,
            YAN_ODEME_PUANI = dto.YAN_ODEME_PUANI,
            OZEL_HIZMET_PUANI = dto.OZEL_HIZMET_PUANI,
        };

        _db.Set<PERSONEL_BORDRO_SONDURUM>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.PERSONEL_SONDURUM_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.PersonelBordroSondurum)]
    public async Task<IActionResult> Update(string id, PersonelBordroSondurumDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_BORDRO_SONDURUM>()
            .FirstOrDefaultAsync(e => e.PERSONEL_SONDURUM_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.PERSONEL_KODU = dto.PERSONEL_KODU;
        entity.PERSONEL_KADEMESI = dto.PERSONEL_KADEMESI;
        entity.PERSONEL_DERECESI = dto.PERSONEL_DERECESI;
        entity.EMEKLI_DERECESI = dto.EMEKLI_DERECESI;
        entity.EMEKLI_KADEMESI = dto.EMEKLI_KADEMESI;
        entity.SENDIKA_BILGISI = dto.SENDIKA_BILGISI;
        entity.KIDEM_YILI = dto.KIDEM_YILI;
        entity.KIDEM_AYI = dto.KIDEM_AYI;
        entity.KIDEM_GUNU = dto.KIDEM_GUNU;
        entity.EK_GOSTERGE = dto.EK_GOSTERGE;
        entity.EMEKLI_EK_GOSTERGESI = dto.EMEKLI_EK_GOSTERGESI;
        entity.GOSTERGE = dto.GOSTERGE;
        entity.EMEKLI_GOSTERGESI = dto.EMEKLI_GOSTERGESI;
        entity.YAN_ODEME_PUANI = dto.YAN_ODEME_PUANI;
        entity.OZEL_HIZMET_PUANI = dto.OZEL_HIZMET_PUANI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.PersonelBordroSondurum)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL_BORDRO_SONDURUM>()
            .FirstOrDefaultAsync(e => e.PERSONEL_SONDURUM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<PERSONEL_BORDRO_SONDURUM>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
