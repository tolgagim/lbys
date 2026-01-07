using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.HastaSeans;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class HastaSeansController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public HastaSeansController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.HastaSeans)]
    public async Task<List<HastaSeansDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<HASTA_SEANS>()
            .AsNoTracking()
            .Select(e => new HastaSeansDto
            {
                HASTA_SEANS_KODU = e.HASTA_SEANS_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                SEANS_ISLEM_TURU = e.SEANS_ISLEM_TURU,
                CIHAZ_KODU = e.CIHAZ_KODU,
                PLANLANAN_SEANS_TARIHI = e.PLANLANAN_SEANS_TARIHI,
                SEANS_BASLAMA_ZAMANI = e.SEANS_BASLAMA_ZAMANI,
                SEANS_BITIS_ZAMANI = e.SEANS_BITIS_ZAMANI,
                ANTIHIPERTANSIF_ILAC_DURUMU = e.ANTIHIPERTANSIF_ILAC_DURUMU,
                ONCEKI_RRT_YONTEMI = e.ONCEKI_RRT_YONTEMI,
                HEMODIYALIZE_GECME_NEDENLERI = e.HEMODIYALIZE_GECME_NEDENLERI,
                DAMAR_ERISIM_YOLU = e.DAMAR_ERISIM_YOLU,
                DIYALIZE_GIRME_SIKLIGI = e.DIYALIZE_GIRME_SIKLIGI,
                DIYALIZOR_ALANI = e.DIYALIZOR_ALANI,
                DIYALIZOR_TIPI = e.DIYALIZOR_TIPI,
                KAN_AKIM_HIZI = e.KAN_AKIM_HIZI,
                AGIRLIK_OLCUM_ZAMANI = e.AGIRLIK_OLCUM_ZAMANI,
                KULLANILAN_DIYALIZ_TEDAVISI = e.KULLANILAN_DIYALIZ_TEDAVISI,
                PERITONEAL_GECIRGENLIK_DURUMU = e.PERITONEAL_GECIRGENLIK_DURUMU,
                PERITON_KACINCI_KATETER = e.PERITON_KACINCI_KATETER,
                PERITON_KATETER_TIPI = e.PERITON_KATETER_TIPI,
                PERITON_KATETER_YONTEMI = e.PERITON_KATETER_YONTEMI,
                PERITON_TUNEL_YONU = e.PERITON_TUNEL_YONU,
                SINEKALSET = e.SINEKALSET,
                TEDAVININ_SEYRI = e.TEDAVININ_SEYRI,
                AKTIF_VITAMIN_D_KULLANIMI = e.AKTIF_VITAMIN_D_KULLANIMI,
                ANEMI_TEDAVISI_YONTEMI = e.ANEMI_TEDAVISI_YONTEMI,
                FOSFOR_BAGLAYICI_AJAN = e.FOSFOR_BAGLAYICI_AJAN,
                PERITON_KOMPLIKASYON = e.PERITON_KOMPLIKASYON,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.HastaSeans)]
    public async Task<ActionResult<HastaSeansDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_SEANS>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.HASTA_SEANS_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new HastaSeansDto
        {
            HASTA_SEANS_KODU = entity.HASTA_SEANS_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            SEANS_ISLEM_TURU = entity.SEANS_ISLEM_TURU,
            CIHAZ_KODU = entity.CIHAZ_KODU,
            PLANLANAN_SEANS_TARIHI = entity.PLANLANAN_SEANS_TARIHI,
            SEANS_BASLAMA_ZAMANI = entity.SEANS_BASLAMA_ZAMANI,
            SEANS_BITIS_ZAMANI = entity.SEANS_BITIS_ZAMANI,
            ANTIHIPERTANSIF_ILAC_DURUMU = entity.ANTIHIPERTANSIF_ILAC_DURUMU,
            ONCEKI_RRT_YONTEMI = entity.ONCEKI_RRT_YONTEMI,
            HEMODIYALIZE_GECME_NEDENLERI = entity.HEMODIYALIZE_GECME_NEDENLERI,
            DAMAR_ERISIM_YOLU = entity.DAMAR_ERISIM_YOLU,
            DIYALIZE_GIRME_SIKLIGI = entity.DIYALIZE_GIRME_SIKLIGI,
            DIYALIZOR_ALANI = entity.DIYALIZOR_ALANI,
            DIYALIZOR_TIPI = entity.DIYALIZOR_TIPI,
            KAN_AKIM_HIZI = entity.KAN_AKIM_HIZI,
            AGIRLIK_OLCUM_ZAMANI = entity.AGIRLIK_OLCUM_ZAMANI,
            KULLANILAN_DIYALIZ_TEDAVISI = entity.KULLANILAN_DIYALIZ_TEDAVISI,
            PERITONEAL_GECIRGENLIK_DURUMU = entity.PERITONEAL_GECIRGENLIK_DURUMU,
            PERITON_KACINCI_KATETER = entity.PERITON_KACINCI_KATETER,
            PERITON_KATETER_TIPI = entity.PERITON_KATETER_TIPI,
            PERITON_KATETER_YONTEMI = entity.PERITON_KATETER_YONTEMI,
            PERITON_TUNEL_YONU = entity.PERITON_TUNEL_YONU,
            SINEKALSET = entity.SINEKALSET,
            TEDAVININ_SEYRI = entity.TEDAVININ_SEYRI,
            AKTIF_VITAMIN_D_KULLANIMI = entity.AKTIF_VITAMIN_D_KULLANIMI,
            ANEMI_TEDAVISI_YONTEMI = entity.ANEMI_TEDAVISI_YONTEMI,
            FOSFOR_BAGLAYICI_AJAN = entity.FOSFOR_BAGLAYICI_AJAN,
            PERITON_KOMPLIKASYON = entity.PERITON_KOMPLIKASYON,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.HastaSeans)]
    public async Task<ActionResult<string>> Create(HastaSeansDto dto, CancellationToken ct)
    {
        var entity = new HASTA_SEANS
        {
            HASTA_SEANS_KODU = dto.HASTA_SEANS_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            SEANS_ISLEM_TURU = dto.SEANS_ISLEM_TURU,
            CIHAZ_KODU = dto.CIHAZ_KODU,
            PLANLANAN_SEANS_TARIHI = dto.PLANLANAN_SEANS_TARIHI,
            SEANS_BASLAMA_ZAMANI = dto.SEANS_BASLAMA_ZAMANI,
            SEANS_BITIS_ZAMANI = dto.SEANS_BITIS_ZAMANI,
            ANTIHIPERTANSIF_ILAC_DURUMU = dto.ANTIHIPERTANSIF_ILAC_DURUMU,
            ONCEKI_RRT_YONTEMI = dto.ONCEKI_RRT_YONTEMI,
            HEMODIYALIZE_GECME_NEDENLERI = dto.HEMODIYALIZE_GECME_NEDENLERI,
            DAMAR_ERISIM_YOLU = dto.DAMAR_ERISIM_YOLU,
            DIYALIZE_GIRME_SIKLIGI = dto.DIYALIZE_GIRME_SIKLIGI,
            DIYALIZOR_ALANI = dto.DIYALIZOR_ALANI,
            DIYALIZOR_TIPI = dto.DIYALIZOR_TIPI,
            KAN_AKIM_HIZI = dto.KAN_AKIM_HIZI,
            AGIRLIK_OLCUM_ZAMANI = dto.AGIRLIK_OLCUM_ZAMANI,
            KULLANILAN_DIYALIZ_TEDAVISI = dto.KULLANILAN_DIYALIZ_TEDAVISI,
            PERITONEAL_GECIRGENLIK_DURUMU = dto.PERITONEAL_GECIRGENLIK_DURUMU,
            PERITON_KACINCI_KATETER = dto.PERITON_KACINCI_KATETER,
            PERITON_KATETER_TIPI = dto.PERITON_KATETER_TIPI,
            PERITON_KATETER_YONTEMI = dto.PERITON_KATETER_YONTEMI,
            PERITON_TUNEL_YONU = dto.PERITON_TUNEL_YONU,
            SINEKALSET = dto.SINEKALSET,
            TEDAVININ_SEYRI = dto.TEDAVININ_SEYRI,
            AKTIF_VITAMIN_D_KULLANIMI = dto.AKTIF_VITAMIN_D_KULLANIMI,
            ANEMI_TEDAVISI_YONTEMI = dto.ANEMI_TEDAVISI_YONTEMI,
            FOSFOR_BAGLAYICI_AJAN = dto.FOSFOR_BAGLAYICI_AJAN,
            PERITON_KOMPLIKASYON = dto.PERITON_KOMPLIKASYON,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<HASTA_SEANS>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.HASTA_SEANS_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.HastaSeans)]
    public async Task<IActionResult> Update(string id, HastaSeansDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_SEANS>()
            .FirstOrDefaultAsync(e => e.HASTA_SEANS_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.SEANS_ISLEM_TURU = dto.SEANS_ISLEM_TURU;
        entity.CIHAZ_KODU = dto.CIHAZ_KODU;
        entity.PLANLANAN_SEANS_TARIHI = dto.PLANLANAN_SEANS_TARIHI;
        entity.SEANS_BASLAMA_ZAMANI = dto.SEANS_BASLAMA_ZAMANI;
        entity.SEANS_BITIS_ZAMANI = dto.SEANS_BITIS_ZAMANI;
        entity.ANTIHIPERTANSIF_ILAC_DURUMU = dto.ANTIHIPERTANSIF_ILAC_DURUMU;
        entity.ONCEKI_RRT_YONTEMI = dto.ONCEKI_RRT_YONTEMI;
        entity.HEMODIYALIZE_GECME_NEDENLERI = dto.HEMODIYALIZE_GECME_NEDENLERI;
        entity.DAMAR_ERISIM_YOLU = dto.DAMAR_ERISIM_YOLU;
        entity.DIYALIZE_GIRME_SIKLIGI = dto.DIYALIZE_GIRME_SIKLIGI;
        entity.DIYALIZOR_ALANI = dto.DIYALIZOR_ALANI;
        entity.DIYALIZOR_TIPI = dto.DIYALIZOR_TIPI;
        entity.KAN_AKIM_HIZI = dto.KAN_AKIM_HIZI;
        entity.AGIRLIK_OLCUM_ZAMANI = dto.AGIRLIK_OLCUM_ZAMANI;
        entity.KULLANILAN_DIYALIZ_TEDAVISI = dto.KULLANILAN_DIYALIZ_TEDAVISI;
        entity.PERITONEAL_GECIRGENLIK_DURUMU = dto.PERITONEAL_GECIRGENLIK_DURUMU;
        entity.PERITON_KACINCI_KATETER = dto.PERITON_KACINCI_KATETER;
        entity.PERITON_KATETER_TIPI = dto.PERITON_KATETER_TIPI;
        entity.PERITON_KATETER_YONTEMI = dto.PERITON_KATETER_YONTEMI;
        entity.PERITON_TUNEL_YONU = dto.PERITON_TUNEL_YONU;
        entity.SINEKALSET = dto.SINEKALSET;
        entity.TEDAVININ_SEYRI = dto.TEDAVININ_SEYRI;
        entity.AKTIF_VITAMIN_D_KULLANIMI = dto.AKTIF_VITAMIN_D_KULLANIMI;
        entity.ANEMI_TEDAVISI_YONTEMI = dto.ANEMI_TEDAVISI_YONTEMI;
        entity.FOSFOR_BAGLAYICI_AJAN = dto.FOSFOR_BAGLAYICI_AJAN;
        entity.PERITON_KOMPLIKASYON = dto.PERITON_KOMPLIKASYON;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.HastaSeans)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_SEANS>()
            .FirstOrDefaultAsync(e => e.HASTA_SEANS_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<HASTA_SEANS>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
