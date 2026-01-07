using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.KanBagisci;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class KanBagisciController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public KanBagisciController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.KanBagisci)]
    public async Task<List<KanBagisciDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<KAN_BAGISCI>()
            .AsNoTracking()
            .Select(e => new KanBagisciDto
            {
                KAN_BAGISCI_KODU = e.KAN_BAGISCI_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                BAGISCI_HASTA_BASVURU_KODU = e.BAGISCI_HASTA_BASVURU_KODU,
                BAGISCI_HASTA_KODU = e.BAGISCI_HASTA_KODU,
                KAN_BAGIS_ZAMANI = e.KAN_BAGIS_ZAMANI,
                KAN_GRUBU = e.KAN_GRUBU,
                ACIKLAMA = e.ACIKLAMA,
                REZERV_HASTA_KODU = e.REZERV_HASTA_KODU,
                BAGISLANAN_KAN_TURU = e.BAGISLANAN_KAN_TURU,
                REAKSIYON_DURUMU = e.REAKSIYON_DURUMU,
                REAKSIYON_TURU = e.REAKSIYON_TURU,
                REAKSIYON_ACIKLAMA = e.REAKSIYON_ACIKLAMA,
                KIZILAY_IZIN_NUMARASI = e.KIZILAY_IZIN_NUMARASI,
                SISTOLIK_KAN_BASINCI_DEGERI = e.SISTOLIK_KAN_BASINCI_DEGERI,
                DIASTOLIK_KAN_BASINCI_DEGERI = e.DIASTOLIK_KAN_BASINCI_DEGERI,
                ATES = e.ATES,
                BOY = e.BOY,
                AGIRLIK = e.AGIRLIK,
                UZMAN_DEGERLENDIRME = e.UZMAN_DEGERLENDIRME,
                LOT_NUMARASI = e.LOT_NUMARASI,
                KAN_HACIM = e.KAN_HACIM,
                SEGMENT_NUMARASI = e.SEGMENT_NUMARASI,
                BAGISCI_TURU = e.BAGISCI_TURU,
                KAN_BAGIS_DEGERLENDIRME_SONUCU = e.KAN_BAGIS_DEGERLENDIRME_SONUCU,
                DEGERLENDIREN_PERSONEL_KODU = e.DEGERLENDIREN_PERSONEL_KODU,
                KAN_BAGIS_DEGERLENDIRME_ZAMANI = e.KAN_BAGIS_DEGERLENDIRME_ZAMANI,
                KAN_BAGISCISI_RET_NEDENLERI = e.KAN_BAGISCISI_RET_NEDENLERI,
                RET_SURESI = e.RET_SURESI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.KanBagisci)]
    public async Task<ActionResult<KanBagisciDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KAN_BAGISCI>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.KAN_BAGISCI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new KanBagisciDto
        {
            KAN_BAGISCI_KODU = entity.KAN_BAGISCI_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            BAGISCI_HASTA_BASVURU_KODU = entity.BAGISCI_HASTA_BASVURU_KODU,
            BAGISCI_HASTA_KODU = entity.BAGISCI_HASTA_KODU,
            KAN_BAGIS_ZAMANI = entity.KAN_BAGIS_ZAMANI,
            KAN_GRUBU = entity.KAN_GRUBU,
            ACIKLAMA = entity.ACIKLAMA,
            REZERV_HASTA_KODU = entity.REZERV_HASTA_KODU,
            BAGISLANAN_KAN_TURU = entity.BAGISLANAN_KAN_TURU,
            REAKSIYON_DURUMU = entity.REAKSIYON_DURUMU,
            REAKSIYON_TURU = entity.REAKSIYON_TURU,
            REAKSIYON_ACIKLAMA = entity.REAKSIYON_ACIKLAMA,
            KIZILAY_IZIN_NUMARASI = entity.KIZILAY_IZIN_NUMARASI,
            SISTOLIK_KAN_BASINCI_DEGERI = entity.SISTOLIK_KAN_BASINCI_DEGERI,
            DIASTOLIK_KAN_BASINCI_DEGERI = entity.DIASTOLIK_KAN_BASINCI_DEGERI,
            ATES = entity.ATES,
            BOY = entity.BOY,
            AGIRLIK = entity.AGIRLIK,
            UZMAN_DEGERLENDIRME = entity.UZMAN_DEGERLENDIRME,
            LOT_NUMARASI = entity.LOT_NUMARASI,
            KAN_HACIM = entity.KAN_HACIM,
            SEGMENT_NUMARASI = entity.SEGMENT_NUMARASI,
            BAGISCI_TURU = entity.BAGISCI_TURU,
            KAN_BAGIS_DEGERLENDIRME_SONUCU = entity.KAN_BAGIS_DEGERLENDIRME_SONUCU,
            DEGERLENDIREN_PERSONEL_KODU = entity.DEGERLENDIREN_PERSONEL_KODU,
            KAN_BAGIS_DEGERLENDIRME_ZAMANI = entity.KAN_BAGIS_DEGERLENDIRME_ZAMANI,
            KAN_BAGISCISI_RET_NEDENLERI = entity.KAN_BAGISCISI_RET_NEDENLERI,
            RET_SURESI = entity.RET_SURESI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.KanBagisci)]
    public async Task<ActionResult<string>> Create(KanBagisciDto dto, CancellationToken ct)
    {
        var entity = new KAN_BAGISCI
        {
            KAN_BAGISCI_KODU = dto.KAN_BAGISCI_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            BAGISCI_HASTA_BASVURU_KODU = dto.BAGISCI_HASTA_BASVURU_KODU,
            BAGISCI_HASTA_KODU = dto.BAGISCI_HASTA_KODU,
            KAN_BAGIS_ZAMANI = dto.KAN_BAGIS_ZAMANI,
            KAN_GRUBU = dto.KAN_GRUBU,
            ACIKLAMA = dto.ACIKLAMA,
            REZERV_HASTA_KODU = dto.REZERV_HASTA_KODU,
            BAGISLANAN_KAN_TURU = dto.BAGISLANAN_KAN_TURU,
            REAKSIYON_DURUMU = dto.REAKSIYON_DURUMU,
            REAKSIYON_TURU = dto.REAKSIYON_TURU,
            REAKSIYON_ACIKLAMA = dto.REAKSIYON_ACIKLAMA,
            KIZILAY_IZIN_NUMARASI = dto.KIZILAY_IZIN_NUMARASI,
            SISTOLIK_KAN_BASINCI_DEGERI = dto.SISTOLIK_KAN_BASINCI_DEGERI,
            DIASTOLIK_KAN_BASINCI_DEGERI = dto.DIASTOLIK_KAN_BASINCI_DEGERI,
            ATES = dto.ATES,
            BOY = dto.BOY,
            AGIRLIK = dto.AGIRLIK,
            UZMAN_DEGERLENDIRME = dto.UZMAN_DEGERLENDIRME,
            LOT_NUMARASI = dto.LOT_NUMARASI,
            KAN_HACIM = dto.KAN_HACIM,
            SEGMENT_NUMARASI = dto.SEGMENT_NUMARASI,
            BAGISCI_TURU = dto.BAGISCI_TURU,
            KAN_BAGIS_DEGERLENDIRME_SONUCU = dto.KAN_BAGIS_DEGERLENDIRME_SONUCU,
            DEGERLENDIREN_PERSONEL_KODU = dto.DEGERLENDIREN_PERSONEL_KODU,
            KAN_BAGIS_DEGERLENDIRME_ZAMANI = dto.KAN_BAGIS_DEGERLENDIRME_ZAMANI,
            KAN_BAGISCISI_RET_NEDENLERI = dto.KAN_BAGISCISI_RET_NEDENLERI,
            RET_SURESI = dto.RET_SURESI,
        };

        _db.Set<KAN_BAGISCI>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.KAN_BAGISCI_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.KanBagisci)]
    public async Task<IActionResult> Update(string id, KanBagisciDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<KAN_BAGISCI>()
            .FirstOrDefaultAsync(e => e.KAN_BAGISCI_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.BAGISCI_HASTA_BASVURU_KODU = dto.BAGISCI_HASTA_BASVURU_KODU;
        entity.BAGISCI_HASTA_KODU = dto.BAGISCI_HASTA_KODU;
        entity.KAN_BAGIS_ZAMANI = dto.KAN_BAGIS_ZAMANI;
        entity.KAN_GRUBU = dto.KAN_GRUBU;
        entity.ACIKLAMA = dto.ACIKLAMA;
        entity.REZERV_HASTA_KODU = dto.REZERV_HASTA_KODU;
        entity.BAGISLANAN_KAN_TURU = dto.BAGISLANAN_KAN_TURU;
        entity.REAKSIYON_DURUMU = dto.REAKSIYON_DURUMU;
        entity.REAKSIYON_TURU = dto.REAKSIYON_TURU;
        entity.REAKSIYON_ACIKLAMA = dto.REAKSIYON_ACIKLAMA;
        entity.KIZILAY_IZIN_NUMARASI = dto.KIZILAY_IZIN_NUMARASI;
        entity.SISTOLIK_KAN_BASINCI_DEGERI = dto.SISTOLIK_KAN_BASINCI_DEGERI;
        entity.DIASTOLIK_KAN_BASINCI_DEGERI = dto.DIASTOLIK_KAN_BASINCI_DEGERI;
        entity.ATES = dto.ATES;
        entity.BOY = dto.BOY;
        entity.AGIRLIK = dto.AGIRLIK;
        entity.UZMAN_DEGERLENDIRME = dto.UZMAN_DEGERLENDIRME;
        entity.LOT_NUMARASI = dto.LOT_NUMARASI;
        entity.KAN_HACIM = dto.KAN_HACIM;
        entity.SEGMENT_NUMARASI = dto.SEGMENT_NUMARASI;
        entity.BAGISCI_TURU = dto.BAGISCI_TURU;
        entity.KAN_BAGIS_DEGERLENDIRME_SONUCU = dto.KAN_BAGIS_DEGERLENDIRME_SONUCU;
        entity.DEGERLENDIREN_PERSONEL_KODU = dto.DEGERLENDIREN_PERSONEL_KODU;
        entity.KAN_BAGIS_DEGERLENDIRME_ZAMANI = dto.KAN_BAGIS_DEGERLENDIRME_ZAMANI;
        entity.KAN_BAGISCISI_RET_NEDENLERI = dto.KAN_BAGISCISI_RET_NEDENLERI;
        entity.RET_SURESI = dto.RET_SURESI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.KanBagisci)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<KAN_BAGISCI>()
            .FirstOrDefaultAsync(e => e.KAN_BAGISCI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<KAN_BAGISCI>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
