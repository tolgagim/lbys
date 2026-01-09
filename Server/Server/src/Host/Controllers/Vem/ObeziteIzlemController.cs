using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.ObeziteIzlem;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class ObeziteIzlemController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public ObeziteIzlemController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.ObeziteIzlem)]
    public async Task<List<ObeziteIzlemDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<OBEZITE_IZLEM>()
            .AsNoTracking()
            .Select(e => new ObeziteIzlemDto
            {
                OBEZITE_IZLEM_KODU = e.OBEZITE_IZLEM_KODU,
HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                DIYET_TIBBI_BESLENME_TEDAVISI = e.DIYET_TIBBI_BESLENME_TEDAVISI,
                ILK_TANI_TARIHI = e.ILK_TANI_TARIHI,
                MORBIT_OBEZ_LENFATIK_ODEM = e.MORBIT_OBEZ_LENFATIK_ODEM,
                OBEZITE_ILAC_TEDAVISI = e.OBEZITE_ILAC_TEDAVISI,
                PSIKOLOJIK_TEDAVI = e.PSIKOLOJIK_TEDAVI,
                BIRLIKTE_GORULEN_EK_HASTALIK = e.BIRLIKTE_GORULEN_EK_HASTALIK,
                EGZERSIZ = e.EGZERSIZ,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.ObeziteIzlem)]
    public async Task<ActionResult<ObeziteIzlemDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<OBEZITE_IZLEM>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.OBEZITE_IZLEM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new ObeziteIzlemDto
        {
            OBEZITE_IZLEM_KODU = entity.OBEZITE_IZLEM_KODU,
HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            DIYET_TIBBI_BESLENME_TEDAVISI = entity.DIYET_TIBBI_BESLENME_TEDAVISI,
            ILK_TANI_TARIHI = entity.ILK_TANI_TARIHI,
            MORBIT_OBEZ_LENFATIK_ODEM = entity.MORBIT_OBEZ_LENFATIK_ODEM,
            OBEZITE_ILAC_TEDAVISI = entity.OBEZITE_ILAC_TEDAVISI,
            PSIKOLOJIK_TEDAVI = entity.PSIKOLOJIK_TEDAVI,
            BIRLIKTE_GORULEN_EK_HASTALIK = entity.BIRLIKTE_GORULEN_EK_HASTALIK,
            EGZERSIZ = entity.EGZERSIZ,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.ObeziteIzlem)]
    public async Task<ActionResult<string>> Create(ObeziteIzlemDto dto, CancellationToken ct)
    {
        var entity = new OBEZITE_IZLEM
        {
            OBEZITE_IZLEM_KODU = dto.OBEZITE_IZLEM_KODU,
HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            DIYET_TIBBI_BESLENME_TEDAVISI = dto.DIYET_TIBBI_BESLENME_TEDAVISI,
            ILK_TANI_TARIHI = dto.ILK_TANI_TARIHI,
            MORBIT_OBEZ_LENFATIK_ODEM = dto.MORBIT_OBEZ_LENFATIK_ODEM,
            OBEZITE_ILAC_TEDAVISI = dto.OBEZITE_ILAC_TEDAVISI,
            PSIKOLOJIK_TEDAVI = dto.PSIKOLOJIK_TEDAVI,
            BIRLIKTE_GORULEN_EK_HASTALIK = dto.BIRLIKTE_GORULEN_EK_HASTALIK,
            EGZERSIZ = dto.EGZERSIZ,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<OBEZITE_IZLEM>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.OBEZITE_IZLEM_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.ObeziteIzlem)]
    public async Task<IActionResult> Update(string id, ObeziteIzlemDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<OBEZITE_IZLEM>()
            .FirstOrDefaultAsync(e => e.OBEZITE_IZLEM_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.DIYET_TIBBI_BESLENME_TEDAVISI = dto.DIYET_TIBBI_BESLENME_TEDAVISI;
        entity.ILK_TANI_TARIHI = dto.ILK_TANI_TARIHI;
        entity.MORBIT_OBEZ_LENFATIK_ODEM = dto.MORBIT_OBEZ_LENFATIK_ODEM;
        entity.OBEZITE_ILAC_TEDAVISI = dto.OBEZITE_ILAC_TEDAVISI;
        entity.PSIKOLOJIK_TEDAVI = dto.PSIKOLOJIK_TEDAVI;
        entity.BIRLIKTE_GORULEN_EK_HASTALIK = dto.BIRLIKTE_GORULEN_EK_HASTALIK;
        entity.EGZERSIZ = dto.EGZERSIZ;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.ObeziteIzlem)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<OBEZITE_IZLEM>()
            .FirstOrDefaultAsync(e => e.OBEZITE_IZLEM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<OBEZITE_IZLEM>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
