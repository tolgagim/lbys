using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.EvdeSaglikIzlem;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class EvdeSaglikIzlemController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public EvdeSaglikIzlemController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.EvdeSaglikIzlem)]
    public async Task<List<EvdeSaglikIzlemDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<EVDE_SAGLIK_IZLEM>()
            .AsNoTracking()
            .Select(e => new EvdeSaglikIzlemDto
            {
                EVDE_SAGLIK_IZLEM_KODU = e.EVDE_SAGLIK_IZLEM_KODU,
HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                AGRI = e.AGRI,
                AYDINLATMA = e.AYDINLATMA,
                BAKIM_VE_DESTEK_IHTIYACI = e.BAKIM_VE_DESTEK_IHTIYACI,
                BASI_DEGERLENDIRMESI = e.BASI_DEGERLENDIRMESI,
                BASVURU_TURU = e.BASVURU_TURU,
                BESLENME = e.BESLENME,
                ESH_ESAS_HASTALIK_GRUBU = e.ESH_ESAS_HASTALIK_GRUBU,
                EV_HIJYENI = e.EV_HIJYENI,
                GUVENLIK = e.GUVENLIK,
                ISINMA = e.ISINMA,
                KISISEL_BAKIM = e.KISISEL_BAKIM,
                KISISEL_HIJYEN = e.KISISEL_HIJYEN,
                KONUT_TIPI = e.KONUT_TIPI,
                KULLANILAN_HELA_TIPI = e.KULLANILAN_HELA_TIPI,
                YATAGA_BAGIMLILIK = e.YATAGA_BAGIMLILIK,
                KULLANDIGI_YARDIMCI_ARACLAR = e.KULLANDIGI_YARDIMCI_ARACLAR,
                PSIKOLOJIK_DURUM_DEGERLENDIRME = e.PSIKOLOJIK_DURUM_DEGERLENDIRME,
                ESH_SONLANDIRILMASI = e.ESH_SONLANDIRILMASI,
                ESH_HASTA_NAKLI = e.ESH_HASTA_NAKLI,
                ESH_ALINACAK_IL = e.ESH_ALINACAK_IL,
                BIR_SONRAKI_HIZMET_IHTIYACI = e.BIR_SONRAKI_HIZMET_IHTIYACI,
                VERILEN_EGITIMLER = e.VERILEN_EGITIMLER,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.EvdeSaglikIzlem)]
    public async Task<ActionResult<EvdeSaglikIzlemDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<EVDE_SAGLIK_IZLEM>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.EVDE_SAGLIK_IZLEM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new EvdeSaglikIzlemDto
        {
            EVDE_SAGLIK_IZLEM_KODU = entity.EVDE_SAGLIK_IZLEM_KODU,
HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            AGRI = entity.AGRI,
            AYDINLATMA = entity.AYDINLATMA,
            BAKIM_VE_DESTEK_IHTIYACI = entity.BAKIM_VE_DESTEK_IHTIYACI,
            BASI_DEGERLENDIRMESI = entity.BASI_DEGERLENDIRMESI,
            BASVURU_TURU = entity.BASVURU_TURU,
            BESLENME = entity.BESLENME,
            ESH_ESAS_HASTALIK_GRUBU = entity.ESH_ESAS_HASTALIK_GRUBU,
            EV_HIJYENI = entity.EV_HIJYENI,
            GUVENLIK = entity.GUVENLIK,
            ISINMA = entity.ISINMA,
            KISISEL_BAKIM = entity.KISISEL_BAKIM,
            KISISEL_HIJYEN = entity.KISISEL_HIJYEN,
            KONUT_TIPI = entity.KONUT_TIPI,
            KULLANILAN_HELA_TIPI = entity.KULLANILAN_HELA_TIPI,
            YATAGA_BAGIMLILIK = entity.YATAGA_BAGIMLILIK,
            KULLANDIGI_YARDIMCI_ARACLAR = entity.KULLANDIGI_YARDIMCI_ARACLAR,
            PSIKOLOJIK_DURUM_DEGERLENDIRME = entity.PSIKOLOJIK_DURUM_DEGERLENDIRME,
            ESH_SONLANDIRILMASI = entity.ESH_SONLANDIRILMASI,
            ESH_HASTA_NAKLI = entity.ESH_HASTA_NAKLI,
            ESH_ALINACAK_IL = entity.ESH_ALINACAK_IL,
            BIR_SONRAKI_HIZMET_IHTIYACI = entity.BIR_SONRAKI_HIZMET_IHTIYACI,
            VERILEN_EGITIMLER = entity.VERILEN_EGITIMLER,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.EvdeSaglikIzlem)]
    public async Task<ActionResult<string>> Create(EvdeSaglikIzlemDto dto, CancellationToken ct)
    {
        var entity = new EVDE_SAGLIK_IZLEM
        {
            EVDE_SAGLIK_IZLEM_KODU = dto.EVDE_SAGLIK_IZLEM_KODU,
HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            AGRI = dto.AGRI,
            AYDINLATMA = dto.AYDINLATMA,
            BAKIM_VE_DESTEK_IHTIYACI = dto.BAKIM_VE_DESTEK_IHTIYACI,
            BASI_DEGERLENDIRMESI = dto.BASI_DEGERLENDIRMESI,
            BASVURU_TURU = dto.BASVURU_TURU,
            BESLENME = dto.BESLENME,
            ESH_ESAS_HASTALIK_GRUBU = dto.ESH_ESAS_HASTALIK_GRUBU,
            EV_HIJYENI = dto.EV_HIJYENI,
            GUVENLIK = dto.GUVENLIK,
            ISINMA = dto.ISINMA,
            KISISEL_BAKIM = dto.KISISEL_BAKIM,
            KISISEL_HIJYEN = dto.KISISEL_HIJYEN,
            KONUT_TIPI = dto.KONUT_TIPI,
            KULLANILAN_HELA_TIPI = dto.KULLANILAN_HELA_TIPI,
            YATAGA_BAGIMLILIK = dto.YATAGA_BAGIMLILIK,
            KULLANDIGI_YARDIMCI_ARACLAR = dto.KULLANDIGI_YARDIMCI_ARACLAR,
            PSIKOLOJIK_DURUM_DEGERLENDIRME = dto.PSIKOLOJIK_DURUM_DEGERLENDIRME,
            ESH_SONLANDIRILMASI = dto.ESH_SONLANDIRILMASI,
            ESH_HASTA_NAKLI = dto.ESH_HASTA_NAKLI,
            ESH_ALINACAK_IL = dto.ESH_ALINACAK_IL,
            BIR_SONRAKI_HIZMET_IHTIYACI = dto.BIR_SONRAKI_HIZMET_IHTIYACI,
            VERILEN_EGITIMLER = dto.VERILEN_EGITIMLER,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<EVDE_SAGLIK_IZLEM>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.EVDE_SAGLIK_IZLEM_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.EvdeSaglikIzlem)]
    public async Task<IActionResult> Update(string id, EvdeSaglikIzlemDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<EVDE_SAGLIK_IZLEM>()
            .FirstOrDefaultAsync(e => e.EVDE_SAGLIK_IZLEM_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.AGRI = dto.AGRI;
        entity.AYDINLATMA = dto.AYDINLATMA;
        entity.BAKIM_VE_DESTEK_IHTIYACI = dto.BAKIM_VE_DESTEK_IHTIYACI;
        entity.BASI_DEGERLENDIRMESI = dto.BASI_DEGERLENDIRMESI;
        entity.BASVURU_TURU = dto.BASVURU_TURU;
        entity.BESLENME = dto.BESLENME;
        entity.ESH_ESAS_HASTALIK_GRUBU = dto.ESH_ESAS_HASTALIK_GRUBU;
        entity.EV_HIJYENI = dto.EV_HIJYENI;
        entity.GUVENLIK = dto.GUVENLIK;
        entity.ISINMA = dto.ISINMA;
        entity.KISISEL_BAKIM = dto.KISISEL_BAKIM;
        entity.KISISEL_HIJYEN = dto.KISISEL_HIJYEN;
        entity.KONUT_TIPI = dto.KONUT_TIPI;
        entity.KULLANILAN_HELA_TIPI = dto.KULLANILAN_HELA_TIPI;
        entity.YATAGA_BAGIMLILIK = dto.YATAGA_BAGIMLILIK;
        entity.KULLANDIGI_YARDIMCI_ARACLAR = dto.KULLANDIGI_YARDIMCI_ARACLAR;
        entity.PSIKOLOJIK_DURUM_DEGERLENDIRME = dto.PSIKOLOJIK_DURUM_DEGERLENDIRME;
        entity.ESH_SONLANDIRILMASI = dto.ESH_SONLANDIRILMASI;
        entity.ESH_HASTA_NAKLI = dto.ESH_HASTA_NAKLI;
        entity.ESH_ALINACAK_IL = dto.ESH_ALINACAK_IL;
        entity.BIR_SONRAKI_HIZMET_IHTIYACI = dto.BIR_SONRAKI_HIZMET_IHTIYACI;
        entity.VERILEN_EGITIMLER = dto.VERILEN_EGITIMLER;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.EvdeSaglikIzlem)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<EVDE_SAGLIK_IZLEM>()
            .FirstOrDefaultAsync(e => e.EVDE_SAGLIK_IZLEM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<EVDE_SAGLIK_IZLEM>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
