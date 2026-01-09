using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.MaddeBagimliligi;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class MaddeBagimliligiController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public MaddeBagimliligiController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.MaddeBagimliligi)]
    public async Task<List<MaddeBagimliligiDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<MADDE_BAGIMLILIGI>()
            .AsNoTracking()
            .Select(e => new MaddeBagimliligiDto
            {
                MADDE_BAGIMLILIGI_KODU = e.MADDE_BAGIMLILIGI_KODU,
HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                BILGI_ALINAN_KAYNAK = e.BILGI_ALINAN_KAYNAK,
                DANISMA_TEDAVI_HIZMET_DURUMU = e.DANISMA_TEDAVI_HIZMET_DURUMU,
                DANISMA_TEDAVI_HIZMET_ZAMANI = e.DANISMA_TEDAVI_HIZMET_ZAMANI,
                IKAME_TEDAVI_DURUMU = e.IKAME_TEDAVI_DURUMU,
                SON_IKAME_TEDAVI_ZAMANI = e.SON_IKAME_TEDAVI_ZAMANI,
                CEZAEVI_OYKUSU = e.CEZAEVI_OYKUSU,
                SOSYAL_YARDIM_ALMA_DURUMU = e.SOSYAL_YARDIM_ALMA_DURUMU,
                YASADIGI_BOLGE = e.YASADIGI_BOLGE,
                YASAM_BICIMI = e.YASAM_BICIMI,
                COCUKLARIYLA_YASAMA_DURUMU = e.COCUKLARIYLA_YASAMA_DURUMU,
                ENJEKSIYON_ILE_MADDE_KULLANIMI = e.ENJEKSIYON_ILE_MADDE_KULLANIMI,
                ENJEKSIYON_ILK_KULLANIM_YASI = e.ENJEKSIYON_ILK_KULLANIM_YASI,
                ENJEKTOR_PAYLASIM_DURUMU = e.ENJEKTOR_PAYLASIM_DURUMU,
                ILK_ENJEKTOR_PAYLASIM_YASI = e.ILK_ENJEKTOR_PAYLASIM_YASI,
                HIV_TEST_YAPILMA_DURUMU = e.HIV_TEST_YAPILMA_DURUMU,
                HCV_TEST_YAPILMA_DURUMU = e.HCV_TEST_YAPILMA_DURUMU,
                HBV_TEST_YAPILMA_DURUMU = e.HBV_TEST_YAPILMA_DURUMU,
                GORUSME_SONUCU = e.GORUSME_SONUCU,
                GONDEREN_BIRIM = e.GONDEREN_BIRIM,
                YASAM_ORTAMI = e.YASAM_ORTAMI,
                BULASICI_HASTALIK_DURUMU = e.BULASICI_HASTALIK_DURUMU,
                BASLANAN_TEDAVI_TIPI_BILGISI = e.BASLANAN_TEDAVI_TIPI_BILGISI,
                BIRINCIL_KULLANILAN_ESAS_MADDE = e.BIRINCIL_KULLANILAN_ESAS_MADDE,
                KULLANILAN_DIGER_MADDE = e.KULLANILAN_DIGER_MADDE,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.MaddeBagimliligi)]
    public async Task<ActionResult<MaddeBagimliligiDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<MADDE_BAGIMLILIGI>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.MADDE_BAGIMLILIGI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new MaddeBagimliligiDto
        {
            MADDE_BAGIMLILIGI_KODU = entity.MADDE_BAGIMLILIGI_KODU,
HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            BILGI_ALINAN_KAYNAK = entity.BILGI_ALINAN_KAYNAK,
            DANISMA_TEDAVI_HIZMET_DURUMU = entity.DANISMA_TEDAVI_HIZMET_DURUMU,
            DANISMA_TEDAVI_HIZMET_ZAMANI = entity.DANISMA_TEDAVI_HIZMET_ZAMANI,
            IKAME_TEDAVI_DURUMU = entity.IKAME_TEDAVI_DURUMU,
            SON_IKAME_TEDAVI_ZAMANI = entity.SON_IKAME_TEDAVI_ZAMANI,
            CEZAEVI_OYKUSU = entity.CEZAEVI_OYKUSU,
            SOSYAL_YARDIM_ALMA_DURUMU = entity.SOSYAL_YARDIM_ALMA_DURUMU,
            YASADIGI_BOLGE = entity.YASADIGI_BOLGE,
            YASAM_BICIMI = entity.YASAM_BICIMI,
            COCUKLARIYLA_YASAMA_DURUMU = entity.COCUKLARIYLA_YASAMA_DURUMU,
            ENJEKSIYON_ILE_MADDE_KULLANIMI = entity.ENJEKSIYON_ILE_MADDE_KULLANIMI,
            ENJEKSIYON_ILK_KULLANIM_YASI = entity.ENJEKSIYON_ILK_KULLANIM_YASI,
            ENJEKTOR_PAYLASIM_DURUMU = entity.ENJEKTOR_PAYLASIM_DURUMU,
            ILK_ENJEKTOR_PAYLASIM_YASI = entity.ILK_ENJEKTOR_PAYLASIM_YASI,
            HIV_TEST_YAPILMA_DURUMU = entity.HIV_TEST_YAPILMA_DURUMU,
            HCV_TEST_YAPILMA_DURUMU = entity.HCV_TEST_YAPILMA_DURUMU,
            HBV_TEST_YAPILMA_DURUMU = entity.HBV_TEST_YAPILMA_DURUMU,
            GORUSME_SONUCU = entity.GORUSME_SONUCU,
            GONDEREN_BIRIM = entity.GONDEREN_BIRIM,
            YASAM_ORTAMI = entity.YASAM_ORTAMI,
            BULASICI_HASTALIK_DURUMU = entity.BULASICI_HASTALIK_DURUMU,
            BASLANAN_TEDAVI_TIPI_BILGISI = entity.BASLANAN_TEDAVI_TIPI_BILGISI,
            BIRINCIL_KULLANILAN_ESAS_MADDE = entity.BIRINCIL_KULLANILAN_ESAS_MADDE,
            KULLANILAN_DIGER_MADDE = entity.KULLANILAN_DIGER_MADDE,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.MaddeBagimliligi)]
    public async Task<ActionResult<string>> Create(MaddeBagimliligiDto dto, CancellationToken ct)
    {
        var entity = new MADDE_BAGIMLILIGI
        {
            MADDE_BAGIMLILIGI_KODU = dto.MADDE_BAGIMLILIGI_KODU,
HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            BILGI_ALINAN_KAYNAK = dto.BILGI_ALINAN_KAYNAK,
            DANISMA_TEDAVI_HIZMET_DURUMU = dto.DANISMA_TEDAVI_HIZMET_DURUMU,
            DANISMA_TEDAVI_HIZMET_ZAMANI = dto.DANISMA_TEDAVI_HIZMET_ZAMANI,
            IKAME_TEDAVI_DURUMU = dto.IKAME_TEDAVI_DURUMU,
            SON_IKAME_TEDAVI_ZAMANI = dto.SON_IKAME_TEDAVI_ZAMANI,
            CEZAEVI_OYKUSU = dto.CEZAEVI_OYKUSU,
            SOSYAL_YARDIM_ALMA_DURUMU = dto.SOSYAL_YARDIM_ALMA_DURUMU,
            YASADIGI_BOLGE = dto.YASADIGI_BOLGE,
            YASAM_BICIMI = dto.YASAM_BICIMI,
            COCUKLARIYLA_YASAMA_DURUMU = dto.COCUKLARIYLA_YASAMA_DURUMU,
            ENJEKSIYON_ILE_MADDE_KULLANIMI = dto.ENJEKSIYON_ILE_MADDE_KULLANIMI,
            ENJEKSIYON_ILK_KULLANIM_YASI = dto.ENJEKSIYON_ILK_KULLANIM_YASI,
            ENJEKTOR_PAYLASIM_DURUMU = dto.ENJEKTOR_PAYLASIM_DURUMU,
            ILK_ENJEKTOR_PAYLASIM_YASI = dto.ILK_ENJEKTOR_PAYLASIM_YASI,
            HIV_TEST_YAPILMA_DURUMU = dto.HIV_TEST_YAPILMA_DURUMU,
            HCV_TEST_YAPILMA_DURUMU = dto.HCV_TEST_YAPILMA_DURUMU,
            HBV_TEST_YAPILMA_DURUMU = dto.HBV_TEST_YAPILMA_DURUMU,
            GORUSME_SONUCU = dto.GORUSME_SONUCU,
            GONDEREN_BIRIM = dto.GONDEREN_BIRIM,
            YASAM_ORTAMI = dto.YASAM_ORTAMI,
            BULASICI_HASTALIK_DURUMU = dto.BULASICI_HASTALIK_DURUMU,
            BASLANAN_TEDAVI_TIPI_BILGISI = dto.BASLANAN_TEDAVI_TIPI_BILGISI,
            BIRINCIL_KULLANILAN_ESAS_MADDE = dto.BIRINCIL_KULLANILAN_ESAS_MADDE,
            KULLANILAN_DIGER_MADDE = dto.KULLANILAN_DIGER_MADDE,
        };

        _db.Set<MADDE_BAGIMLILIGI>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.MADDE_BAGIMLILIGI_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.MaddeBagimliligi)]
    public async Task<IActionResult> Update(string id, MaddeBagimliligiDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<MADDE_BAGIMLILIGI>()
            .FirstOrDefaultAsync(e => e.MADDE_BAGIMLILIGI_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.BILGI_ALINAN_KAYNAK = dto.BILGI_ALINAN_KAYNAK;
        entity.DANISMA_TEDAVI_HIZMET_DURUMU = dto.DANISMA_TEDAVI_HIZMET_DURUMU;
        entity.DANISMA_TEDAVI_HIZMET_ZAMANI = dto.DANISMA_TEDAVI_HIZMET_ZAMANI;
        entity.IKAME_TEDAVI_DURUMU = dto.IKAME_TEDAVI_DURUMU;
        entity.SON_IKAME_TEDAVI_ZAMANI = dto.SON_IKAME_TEDAVI_ZAMANI;
        entity.CEZAEVI_OYKUSU = dto.CEZAEVI_OYKUSU;
        entity.SOSYAL_YARDIM_ALMA_DURUMU = dto.SOSYAL_YARDIM_ALMA_DURUMU;
        entity.YASADIGI_BOLGE = dto.YASADIGI_BOLGE;
        entity.YASAM_BICIMI = dto.YASAM_BICIMI;
        entity.COCUKLARIYLA_YASAMA_DURUMU = dto.COCUKLARIYLA_YASAMA_DURUMU;
        entity.ENJEKSIYON_ILE_MADDE_KULLANIMI = dto.ENJEKSIYON_ILE_MADDE_KULLANIMI;
        entity.ENJEKSIYON_ILK_KULLANIM_YASI = dto.ENJEKSIYON_ILK_KULLANIM_YASI;
        entity.ENJEKTOR_PAYLASIM_DURUMU = dto.ENJEKTOR_PAYLASIM_DURUMU;
        entity.ILK_ENJEKTOR_PAYLASIM_YASI = dto.ILK_ENJEKTOR_PAYLASIM_YASI;
        entity.HIV_TEST_YAPILMA_DURUMU = dto.HIV_TEST_YAPILMA_DURUMU;
        entity.HCV_TEST_YAPILMA_DURUMU = dto.HCV_TEST_YAPILMA_DURUMU;
        entity.HBV_TEST_YAPILMA_DURUMU = dto.HBV_TEST_YAPILMA_DURUMU;
        entity.GORUSME_SONUCU = dto.GORUSME_SONUCU;
        entity.GONDEREN_BIRIM = dto.GONDEREN_BIRIM;
        entity.YASAM_ORTAMI = dto.YASAM_ORTAMI;
        entity.BULASICI_HASTALIK_DURUMU = dto.BULASICI_HASTALIK_DURUMU;
        entity.BASLANAN_TEDAVI_TIPI_BILGISI = dto.BASLANAN_TEDAVI_TIPI_BILGISI;
        entity.BIRINCIL_KULLANILAN_ESAS_MADDE = dto.BIRINCIL_KULLANILAN_ESAS_MADDE;
        entity.KULLANILAN_DIGER_MADDE = dto.KULLANILAN_DIGER_MADDE;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.MaddeBagimliligi)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<MADDE_BAGIMLILIGI>()
            .FirstOrDefaultAsync(e => e.MADDE_BAGIMLILIGI_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<MADDE_BAGIMLILIGI>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
