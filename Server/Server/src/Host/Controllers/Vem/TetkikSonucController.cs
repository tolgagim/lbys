using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.TetkikSonuc;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class TetkikSonucController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public TetkikSonucController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.TetkikSonuc)]
    public async Task<List<TetkikSonucDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<TETKIK_SONUC>()
            .AsNoTracking()
            .Select(e => new TetkikSonucDto
            {
                TETKIK_SONUC_KODU = e.TETKIK_SONUC_KODU,
                TETKIK_NUMUNE_KODU = e.TETKIK_NUMUNE_KODU,
                TETKIK_PARAMETRE_KODU = e.TETKIK_PARAMETRE_KODU,
                TETKIK_KODU = e.TETKIK_KODU,
                TETKIK_ADI = e.TETKIK_ADI,
                HASTA_HIZMET_KODU = e.HASTA_HIZMET_KODU,
                TETKIK_SONUCU = e.TETKIK_SONUCU,
                SONUC_ZAMANI = e.SONUC_ZAMANI,
                TETKIK_SONUC_GIZLENME_DURUMU = e.TETKIK_SONUC_GIZLENME_DURUMU,
                WEB_SONUC_GIZLENME_DURUMU = e.WEB_SONUC_GIZLENME_DURUMU,
                NUMUNE_RET_NEDENI = e.NUMUNE_RET_NEDENI,
                RET_EDEN_KULLANICI_KODU = e.RET_EDEN_KULLANICI_KODU,
                RET_ZAMANI = e.RET_ZAMANI,
                KRITIK_DEGER_ARALIGI = e.KRITIK_DEGER_ARALIGI,
                CALISMA_BASLAMA_ZAMANI = e.CALISMA_BASLAMA_ZAMANI,
                CALISMA_BITIS_ZAMANI = e.CALISMA_BITIS_ZAMANI,
                ONAYLAYAN_TEKNISYEN_KODU = e.ONAYLAYAN_TEKNISYEN_KODU,
                TEKNISYEN_ONAY_ZAMANI = e.TEKNISYEN_ONAY_ZAMANI,
                ONAYLAYAN_HEKIM_KODU = e.ONAYLAYAN_HEKIM_KODU,
                TETKIK_UZMAN_ONAY_ZAMANI = e.TETKIK_UZMAN_ONAY_ZAMANI,
                LOINC_KODU = e.LOINC_KODU,
                TEKRAR_CALISMA_DURUMU = e.TEKRAR_CALISMA_DURUMU,
                MANUEL_TETKIK_SONUC_DURUMU = e.MANUEL_TETKIK_SONUC_DURUMU,
                UREME_DURUMU = e.UREME_DURUMU,
                CIHAZ_KODU = e.CIHAZ_KODU,
                CIHAZ_TETKIK_SONUCU = e.CIHAZ_TETKIK_SONUCU,
                TETKIK_SONUCU_BIRIMI = e.TETKIK_SONUCU_BIRIMI,
                TETKIK_SONUCU_REFERANS_DEGERI = e.TETKIK_SONUCU_REFERANS_DEGERI,
                TETKIK_SONUCU_DURUMU = e.TETKIK_SONUCU_DURUMU,
                TETKIK_SONUC_ACIKLAMA = e.TETKIK_SONUC_ACIKLAMA,
                RAPOR_YAZAN_PERSONEL_KODU = e.RAPOR_YAZAN_PERSONEL_KODU,
                SONUC_DIS_ERISIM_BILGISI = e.SONUC_DIS_ERISIM_BILGISI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.TetkikSonuc)]
    public async Task<ActionResult<TetkikSonucDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<TETKIK_SONUC>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.TETKIK_SONUC_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new TetkikSonucDto
        {
            TETKIK_SONUC_KODU = entity.TETKIK_SONUC_KODU,
            TETKIK_NUMUNE_KODU = entity.TETKIK_NUMUNE_KODU,
            TETKIK_PARAMETRE_KODU = entity.TETKIK_PARAMETRE_KODU,
            TETKIK_KODU = entity.TETKIK_KODU,
            TETKIK_ADI = entity.TETKIK_ADI,
            HASTA_HIZMET_KODU = entity.HASTA_HIZMET_KODU,
            TETKIK_SONUCU = entity.TETKIK_SONUCU,
            SONUC_ZAMANI = entity.SONUC_ZAMANI,
            TETKIK_SONUC_GIZLENME_DURUMU = entity.TETKIK_SONUC_GIZLENME_DURUMU,
            WEB_SONUC_GIZLENME_DURUMU = entity.WEB_SONUC_GIZLENME_DURUMU,
            NUMUNE_RET_NEDENI = entity.NUMUNE_RET_NEDENI,
            RET_EDEN_KULLANICI_KODU = entity.RET_EDEN_KULLANICI_KODU,
            RET_ZAMANI = entity.RET_ZAMANI,
            KRITIK_DEGER_ARALIGI = entity.KRITIK_DEGER_ARALIGI,
            CALISMA_BASLAMA_ZAMANI = entity.CALISMA_BASLAMA_ZAMANI,
            CALISMA_BITIS_ZAMANI = entity.CALISMA_BITIS_ZAMANI,
            ONAYLAYAN_TEKNISYEN_KODU = entity.ONAYLAYAN_TEKNISYEN_KODU,
            TEKNISYEN_ONAY_ZAMANI = entity.TEKNISYEN_ONAY_ZAMANI,
            ONAYLAYAN_HEKIM_KODU = entity.ONAYLAYAN_HEKIM_KODU,
            TETKIK_UZMAN_ONAY_ZAMANI = entity.TETKIK_UZMAN_ONAY_ZAMANI,
            LOINC_KODU = entity.LOINC_KODU,
            TEKRAR_CALISMA_DURUMU = entity.TEKRAR_CALISMA_DURUMU,
            MANUEL_TETKIK_SONUC_DURUMU = entity.MANUEL_TETKIK_SONUC_DURUMU,
            UREME_DURUMU = entity.UREME_DURUMU,
            CIHAZ_KODU = entity.CIHAZ_KODU,
            CIHAZ_TETKIK_SONUCU = entity.CIHAZ_TETKIK_SONUCU,
            TETKIK_SONUCU_BIRIMI = entity.TETKIK_SONUCU_BIRIMI,
            TETKIK_SONUCU_REFERANS_DEGERI = entity.TETKIK_SONUCU_REFERANS_DEGERI,
            TETKIK_SONUCU_DURUMU = entity.TETKIK_SONUCU_DURUMU,
            TETKIK_SONUC_ACIKLAMA = entity.TETKIK_SONUC_ACIKLAMA,
            RAPOR_YAZAN_PERSONEL_KODU = entity.RAPOR_YAZAN_PERSONEL_KODU,
            SONUC_DIS_ERISIM_BILGISI = entity.SONUC_DIS_ERISIM_BILGISI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.TetkikSonuc)]
    public async Task<ActionResult<string>> Create(TetkikSonucDto dto, CancellationToken ct)
    {
        var entity = new TETKIK_SONUC
        {
            TETKIK_SONUC_KODU = dto.TETKIK_SONUC_KODU,
            TETKIK_NUMUNE_KODU = dto.TETKIK_NUMUNE_KODU,
            TETKIK_PARAMETRE_KODU = dto.TETKIK_PARAMETRE_KODU,
            TETKIK_KODU = dto.TETKIK_KODU,
            TETKIK_ADI = dto.TETKIK_ADI,
            HASTA_HIZMET_KODU = dto.HASTA_HIZMET_KODU,
            TETKIK_SONUCU = dto.TETKIK_SONUCU,
            SONUC_ZAMANI = dto.SONUC_ZAMANI,
            TETKIK_SONUC_GIZLENME_DURUMU = dto.TETKIK_SONUC_GIZLENME_DURUMU,
            WEB_SONUC_GIZLENME_DURUMU = dto.WEB_SONUC_GIZLENME_DURUMU,
            NUMUNE_RET_NEDENI = dto.NUMUNE_RET_NEDENI,
            RET_EDEN_KULLANICI_KODU = dto.RET_EDEN_KULLANICI_KODU,
            RET_ZAMANI = dto.RET_ZAMANI,
            KRITIK_DEGER_ARALIGI = dto.KRITIK_DEGER_ARALIGI,
            CALISMA_BASLAMA_ZAMANI = dto.CALISMA_BASLAMA_ZAMANI,
            CALISMA_BITIS_ZAMANI = dto.CALISMA_BITIS_ZAMANI,
            ONAYLAYAN_TEKNISYEN_KODU = dto.ONAYLAYAN_TEKNISYEN_KODU,
            TEKNISYEN_ONAY_ZAMANI = dto.TEKNISYEN_ONAY_ZAMANI,
            ONAYLAYAN_HEKIM_KODU = dto.ONAYLAYAN_HEKIM_KODU,
            TETKIK_UZMAN_ONAY_ZAMANI = dto.TETKIK_UZMAN_ONAY_ZAMANI,
            LOINC_KODU = dto.LOINC_KODU,
            TEKRAR_CALISMA_DURUMU = dto.TEKRAR_CALISMA_DURUMU,
            MANUEL_TETKIK_SONUC_DURUMU = dto.MANUEL_TETKIK_SONUC_DURUMU,
            UREME_DURUMU = dto.UREME_DURUMU,
            CIHAZ_KODU = dto.CIHAZ_KODU,
            CIHAZ_TETKIK_SONUCU = dto.CIHAZ_TETKIK_SONUCU,
            TETKIK_SONUCU_BIRIMI = dto.TETKIK_SONUCU_BIRIMI,
            TETKIK_SONUCU_REFERANS_DEGERI = dto.TETKIK_SONUCU_REFERANS_DEGERI,
            TETKIK_SONUCU_DURUMU = dto.TETKIK_SONUCU_DURUMU,
            TETKIK_SONUC_ACIKLAMA = dto.TETKIK_SONUC_ACIKLAMA,
            RAPOR_YAZAN_PERSONEL_KODU = dto.RAPOR_YAZAN_PERSONEL_KODU,
            SONUC_DIS_ERISIM_BILGISI = dto.SONUC_DIS_ERISIM_BILGISI,
        };

        _db.Set<TETKIK_SONUC>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.TETKIK_SONUC_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.TetkikSonuc)]
    public async Task<IActionResult> Update(string id, TetkikSonucDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<TETKIK_SONUC>()
            .FirstOrDefaultAsync(e => e.TETKIK_SONUC_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.TETKIK_NUMUNE_KODU = dto.TETKIK_NUMUNE_KODU;
        entity.TETKIK_PARAMETRE_KODU = dto.TETKIK_PARAMETRE_KODU;
        entity.TETKIK_KODU = dto.TETKIK_KODU;
        entity.TETKIK_ADI = dto.TETKIK_ADI;
        entity.HASTA_HIZMET_KODU = dto.HASTA_HIZMET_KODU;
        entity.TETKIK_SONUCU = dto.TETKIK_SONUCU;
        entity.SONUC_ZAMANI = dto.SONUC_ZAMANI;
        entity.TETKIK_SONUC_GIZLENME_DURUMU = dto.TETKIK_SONUC_GIZLENME_DURUMU;
        entity.WEB_SONUC_GIZLENME_DURUMU = dto.WEB_SONUC_GIZLENME_DURUMU;
        entity.NUMUNE_RET_NEDENI = dto.NUMUNE_RET_NEDENI;
        entity.RET_EDEN_KULLANICI_KODU = dto.RET_EDEN_KULLANICI_KODU;
        entity.RET_ZAMANI = dto.RET_ZAMANI;
        entity.KRITIK_DEGER_ARALIGI = dto.KRITIK_DEGER_ARALIGI;
        entity.CALISMA_BASLAMA_ZAMANI = dto.CALISMA_BASLAMA_ZAMANI;
        entity.CALISMA_BITIS_ZAMANI = dto.CALISMA_BITIS_ZAMANI;
        entity.ONAYLAYAN_TEKNISYEN_KODU = dto.ONAYLAYAN_TEKNISYEN_KODU;
        entity.TEKNISYEN_ONAY_ZAMANI = dto.TEKNISYEN_ONAY_ZAMANI;
        entity.ONAYLAYAN_HEKIM_KODU = dto.ONAYLAYAN_HEKIM_KODU;
        entity.TETKIK_UZMAN_ONAY_ZAMANI = dto.TETKIK_UZMAN_ONAY_ZAMANI;
        entity.LOINC_KODU = dto.LOINC_KODU;
        entity.TEKRAR_CALISMA_DURUMU = dto.TEKRAR_CALISMA_DURUMU;
        entity.MANUEL_TETKIK_SONUC_DURUMU = dto.MANUEL_TETKIK_SONUC_DURUMU;
        entity.UREME_DURUMU = dto.UREME_DURUMU;
        entity.CIHAZ_KODU = dto.CIHAZ_KODU;
        entity.CIHAZ_TETKIK_SONUCU = dto.CIHAZ_TETKIK_SONUCU;
        entity.TETKIK_SONUCU_BIRIMI = dto.TETKIK_SONUCU_BIRIMI;
        entity.TETKIK_SONUCU_REFERANS_DEGERI = dto.TETKIK_SONUCU_REFERANS_DEGERI;
        entity.TETKIK_SONUCU_DURUMU = dto.TETKIK_SONUCU_DURUMU;
        entity.TETKIK_SONUC_ACIKLAMA = dto.TETKIK_SONUC_ACIKLAMA;
        entity.RAPOR_YAZAN_PERSONEL_KODU = dto.RAPOR_YAZAN_PERSONEL_KODU;
        entity.SONUC_DIS_ERISIM_BILGISI = dto.SONUC_DIS_ERISIM_BILGISI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.TetkikSonuc)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<TETKIK_SONUC>()
            .FirstOrDefaultAsync(e => e.TETKIK_SONUC_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<TETKIK_SONUC>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
