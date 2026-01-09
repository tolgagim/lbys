using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.BildirimiZorunlu;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class BildirimiZorunluController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public BildirimiZorunluController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.BildirimiZorunlu)]
    public async Task<List<BildirimiZorunluDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<BILDIRIMI_ZORUNLU>()
            .AsNoTracking()
            .Select(e => new BildirimiZorunluDto
            {
                BILDIRIMI_ZORUNLU_KODU = e.BILDIRIMI_ZORUNLU_KODU,
HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                BILDIRIM_TURU = e.BILDIRIM_TURU,
                BILDIRIM_ZAMANI = e.BILDIRIM_ZAMANI,
                TANI_KODU = e.TANI_KODU,
                AILESINDE_INTIHAR_GIRISIMI = e.AILESINDE_INTIHAR_GIRISIMI,
                AILESINDE_PSIKIYATRIK_VAKA = e.AILESINDE_PSIKIYATRIK_VAKA,
                INTIHAR_KRIZ_VAKA_TURU = e.INTIHAR_KRIZ_VAKA_TURU,
                OLAY_ZAMANI = e.OLAY_ZAMANI,
                PSIKIYATRIK_TEDAVI_GECMISI = e.PSIKIYATRIK_TEDAVI_GECMISI,
                INTIHAR_GIRISIM_KRIZ_NEDENLERI = e.INTIHAR_GIRISIM_KRIZ_NEDENLERI,
                INTIHAR_GIRISIMI_YONTEMI = e.INTIHAR_GIRISIMI_YONTEMI,
                INTIHAR_GIRISIMI_GECMISI = e.INTIHAR_GIRISIMI_GECMISI,
                INTIHAR_KRIZ_VAKA_SONUCU = e.INTIHAR_KRIZ_VAKA_SONUCU,
                PSIKIYATRIK_TANI_GECMISI = e.PSIKIYATRIK_TANI_GECMISI,
                HAYVANIN_MEVCUT_DURUMU = e.HAYVANIN_MEVCUT_DURUMU,
                HAYVANIN_SAHIPLIK_DURUMU = e.HAYVANIN_SAHIPLIK_DURUMU,
                IMMUNGLOBULIN_TURU = e.IMMUNGLOBULIN_TURU,
                IMMUNGLOBULIN_MIKTARI = e.IMMUNGLOBULIN_MIKTARI,
                KATEGORIZASYON = e.KATEGORIZASYON,
                TEMAS_DEGERLENDIRME_DURUMU = e.TEMAS_DEGERLENDIRME_DURUMU,
                KUDUZ_SEBEP_OLAN_HAYVAN = e.KUDUZ_SEBEP_OLAN_HAYVAN,
                YAPTIRACAGINI_BEYAN_ETTIGI_TSM = e.YAPTIRACAGINI_BEYAN_ETTIGI_TSM,
                RISKLI_TEMAS_TIPI = e.RISKLI_TEMAS_TIPI,
                EV_TELEFONU = e.EV_TELEFONU,
                CEP_TELEFONU = e.CEP_TELEFONU,
                EV_ADRESI = e.EV_ADRESI,
                IL_KODU = e.IL_KODU,
                ILCE_KODU = e.ILCE_KODU,
                BCG_SKAR_SAYISI = e.BCG_SKAR_SAYISI,
                DGT_UYGULAMASINI_YAPAN_KISI = e.DGT_UYGULAMASINI_YAPAN_KISI,
                DGT_UYGULAMA_YERI = e.DGT_UYGULAMA_YERI,
                HASTANIN_TEDAVIYE_UYUMU = e.HASTANIN_TEDAVIYE_UYUMU,
                KULTUR_SONUCU = e.KULTUR_SONUCU,
                TUBERKULIN_DERI_TESTI_SONUCU = e.TUBERKULIN_DERI_TESTI_SONUCU,
                VEREM_HASTASI_TEDAVI_YONTEMI = e.VEREM_HASTASI_TEDAVI_YONTEMI,
                VEREM_OLGU_TANIMI = e.VEREM_OLGU_TANIMI,
                YAYMA_SONUCU = e.YAYMA_SONUCU,
                VEREM_HASTALIGI_TUTULUM_YERI = e.VEREM_HASTALIGI_TUTULUM_YERI,
                VEREM_HASTASI_KLINIK_ORNEGI = e.VEREM_HASTASI_KLINIK_ORNEGI,
                VEREM_ILAC_ADI = e.VEREM_ILAC_ADI,
                VEREM_TEDAVI_SONUCU = e.VEREM_TEDAVI_SONUCU,
                BULASICI_HASTALIK_VAKA_TIPI = e.BULASICI_HASTALIK_VAKA_TIPI,
                BELIRTILERIN_BASLADIGI_TARIH = e.BELIRTILERIN_BASLADIGI_TARIH,
                SIDDET_TURU = e.SIDDET_TURU,
                SIDDET_DEGERLENDIRME_SONUCU = e.SIDDET_DEGERLENDIRME_SONUCU,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.BildirimiZorunlu)]
    public async Task<ActionResult<BildirimiZorunluDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<BILDIRIMI_ZORUNLU>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.BILDIRIMI_ZORUNLU_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new BildirimiZorunluDto
        {
            BILDIRIMI_ZORUNLU_KODU = entity.BILDIRIMI_ZORUNLU_KODU,
HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            BILDIRIM_TURU = entity.BILDIRIM_TURU,
            BILDIRIM_ZAMANI = entity.BILDIRIM_ZAMANI,
            TANI_KODU = entity.TANI_KODU,
            AILESINDE_INTIHAR_GIRISIMI = entity.AILESINDE_INTIHAR_GIRISIMI,
            AILESINDE_PSIKIYATRIK_VAKA = entity.AILESINDE_PSIKIYATRIK_VAKA,
            INTIHAR_KRIZ_VAKA_TURU = entity.INTIHAR_KRIZ_VAKA_TURU,
            OLAY_ZAMANI = entity.OLAY_ZAMANI,
            PSIKIYATRIK_TEDAVI_GECMISI = entity.PSIKIYATRIK_TEDAVI_GECMISI,
            INTIHAR_GIRISIM_KRIZ_NEDENLERI = entity.INTIHAR_GIRISIM_KRIZ_NEDENLERI,
            INTIHAR_GIRISIMI_YONTEMI = entity.INTIHAR_GIRISIMI_YONTEMI,
            INTIHAR_GIRISIMI_GECMISI = entity.INTIHAR_GIRISIMI_GECMISI,
            INTIHAR_KRIZ_VAKA_SONUCU = entity.INTIHAR_KRIZ_VAKA_SONUCU,
            PSIKIYATRIK_TANI_GECMISI = entity.PSIKIYATRIK_TANI_GECMISI,
            HAYVANIN_MEVCUT_DURUMU = entity.HAYVANIN_MEVCUT_DURUMU,
            HAYVANIN_SAHIPLIK_DURUMU = entity.HAYVANIN_SAHIPLIK_DURUMU,
            IMMUNGLOBULIN_TURU = entity.IMMUNGLOBULIN_TURU,
            IMMUNGLOBULIN_MIKTARI = entity.IMMUNGLOBULIN_MIKTARI,
            KATEGORIZASYON = entity.KATEGORIZASYON,
            TEMAS_DEGERLENDIRME_DURUMU = entity.TEMAS_DEGERLENDIRME_DURUMU,
            KUDUZ_SEBEP_OLAN_HAYVAN = entity.KUDUZ_SEBEP_OLAN_HAYVAN,
            YAPTIRACAGINI_BEYAN_ETTIGI_TSM = entity.YAPTIRACAGINI_BEYAN_ETTIGI_TSM,
            RISKLI_TEMAS_TIPI = entity.RISKLI_TEMAS_TIPI,
            EV_TELEFONU = entity.EV_TELEFONU,
            CEP_TELEFONU = entity.CEP_TELEFONU,
            EV_ADRESI = entity.EV_ADRESI,
            IL_KODU = entity.IL_KODU,
            ILCE_KODU = entity.ILCE_KODU,
            BCG_SKAR_SAYISI = entity.BCG_SKAR_SAYISI,
            DGT_UYGULAMASINI_YAPAN_KISI = entity.DGT_UYGULAMASINI_YAPAN_KISI,
            DGT_UYGULAMA_YERI = entity.DGT_UYGULAMA_YERI,
            HASTANIN_TEDAVIYE_UYUMU = entity.HASTANIN_TEDAVIYE_UYUMU,
            KULTUR_SONUCU = entity.KULTUR_SONUCU,
            TUBERKULIN_DERI_TESTI_SONUCU = entity.TUBERKULIN_DERI_TESTI_SONUCU,
            VEREM_HASTASI_TEDAVI_YONTEMI = entity.VEREM_HASTASI_TEDAVI_YONTEMI,
            VEREM_OLGU_TANIMI = entity.VEREM_OLGU_TANIMI,
            YAYMA_SONUCU = entity.YAYMA_SONUCU,
            VEREM_HASTALIGI_TUTULUM_YERI = entity.VEREM_HASTALIGI_TUTULUM_YERI,
            VEREM_HASTASI_KLINIK_ORNEGI = entity.VEREM_HASTASI_KLINIK_ORNEGI,
            VEREM_ILAC_ADI = entity.VEREM_ILAC_ADI,
            VEREM_TEDAVI_SONUCU = entity.VEREM_TEDAVI_SONUCU,
            BULASICI_HASTALIK_VAKA_TIPI = entity.BULASICI_HASTALIK_VAKA_TIPI,
            BELIRTILERIN_BASLADIGI_TARIH = entity.BELIRTILERIN_BASLADIGI_TARIH,
            SIDDET_TURU = entity.SIDDET_TURU,
            SIDDET_DEGERLENDIRME_SONUCU = entity.SIDDET_DEGERLENDIRME_SONUCU,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.BildirimiZorunlu)]
    public async Task<ActionResult<string>> Create(BildirimiZorunluDto dto, CancellationToken ct)
    {
        var entity = new BILDIRIMI_ZORUNLU
        {
            BILDIRIMI_ZORUNLU_KODU = dto.BILDIRIMI_ZORUNLU_KODU,
HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            BILDIRIM_TURU = dto.BILDIRIM_TURU,
            BILDIRIM_ZAMANI = dto.BILDIRIM_ZAMANI,
            TANI_KODU = dto.TANI_KODU,
            AILESINDE_INTIHAR_GIRISIMI = dto.AILESINDE_INTIHAR_GIRISIMI,
            AILESINDE_PSIKIYATRIK_VAKA = dto.AILESINDE_PSIKIYATRIK_VAKA,
            INTIHAR_KRIZ_VAKA_TURU = dto.INTIHAR_KRIZ_VAKA_TURU,
            OLAY_ZAMANI = dto.OLAY_ZAMANI,
            PSIKIYATRIK_TEDAVI_GECMISI = dto.PSIKIYATRIK_TEDAVI_GECMISI,
            INTIHAR_GIRISIM_KRIZ_NEDENLERI = dto.INTIHAR_GIRISIM_KRIZ_NEDENLERI,
            INTIHAR_GIRISIMI_YONTEMI = dto.INTIHAR_GIRISIMI_YONTEMI,
            INTIHAR_GIRISIMI_GECMISI = dto.INTIHAR_GIRISIMI_GECMISI,
            INTIHAR_KRIZ_VAKA_SONUCU = dto.INTIHAR_KRIZ_VAKA_SONUCU,
            PSIKIYATRIK_TANI_GECMISI = dto.PSIKIYATRIK_TANI_GECMISI,
            HAYVANIN_MEVCUT_DURUMU = dto.HAYVANIN_MEVCUT_DURUMU,
            HAYVANIN_SAHIPLIK_DURUMU = dto.HAYVANIN_SAHIPLIK_DURUMU,
            IMMUNGLOBULIN_TURU = dto.IMMUNGLOBULIN_TURU,
            IMMUNGLOBULIN_MIKTARI = dto.IMMUNGLOBULIN_MIKTARI,
            KATEGORIZASYON = dto.KATEGORIZASYON,
            TEMAS_DEGERLENDIRME_DURUMU = dto.TEMAS_DEGERLENDIRME_DURUMU,
            KUDUZ_SEBEP_OLAN_HAYVAN = dto.KUDUZ_SEBEP_OLAN_HAYVAN,
            YAPTIRACAGINI_BEYAN_ETTIGI_TSM = dto.YAPTIRACAGINI_BEYAN_ETTIGI_TSM,
            RISKLI_TEMAS_TIPI = dto.RISKLI_TEMAS_TIPI,
            EV_TELEFONU = dto.EV_TELEFONU,
            CEP_TELEFONU = dto.CEP_TELEFONU,
            EV_ADRESI = dto.EV_ADRESI,
            IL_KODU = dto.IL_KODU,
            ILCE_KODU = dto.ILCE_KODU,
            BCG_SKAR_SAYISI = dto.BCG_SKAR_SAYISI,
            DGT_UYGULAMASINI_YAPAN_KISI = dto.DGT_UYGULAMASINI_YAPAN_KISI,
            DGT_UYGULAMA_YERI = dto.DGT_UYGULAMA_YERI,
            HASTANIN_TEDAVIYE_UYUMU = dto.HASTANIN_TEDAVIYE_UYUMU,
            KULTUR_SONUCU = dto.KULTUR_SONUCU,
            TUBERKULIN_DERI_TESTI_SONUCU = dto.TUBERKULIN_DERI_TESTI_SONUCU,
            VEREM_HASTASI_TEDAVI_YONTEMI = dto.VEREM_HASTASI_TEDAVI_YONTEMI,
            VEREM_OLGU_TANIMI = dto.VEREM_OLGU_TANIMI,
            YAYMA_SONUCU = dto.YAYMA_SONUCU,
            VEREM_HASTALIGI_TUTULUM_YERI = dto.VEREM_HASTALIGI_TUTULUM_YERI,
            VEREM_HASTASI_KLINIK_ORNEGI = dto.VEREM_HASTASI_KLINIK_ORNEGI,
            VEREM_ILAC_ADI = dto.VEREM_ILAC_ADI,
            VEREM_TEDAVI_SONUCU = dto.VEREM_TEDAVI_SONUCU,
            BULASICI_HASTALIK_VAKA_TIPI = dto.BULASICI_HASTALIK_VAKA_TIPI,
            BELIRTILERIN_BASLADIGI_TARIH = dto.BELIRTILERIN_BASLADIGI_TARIH,
            SIDDET_TURU = dto.SIDDET_TURU,
            SIDDET_DEGERLENDIRME_SONUCU = dto.SIDDET_DEGERLENDIRME_SONUCU,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<BILDIRIMI_ZORUNLU>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.BILDIRIMI_ZORUNLU_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.BildirimiZorunlu)]
    public async Task<IActionResult> Update(string id, BildirimiZorunluDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<BILDIRIMI_ZORUNLU>()
            .FirstOrDefaultAsync(e => e.BILDIRIMI_ZORUNLU_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.BILDIRIM_TURU = dto.BILDIRIM_TURU;
        entity.BILDIRIM_ZAMANI = dto.BILDIRIM_ZAMANI;
        entity.TANI_KODU = dto.TANI_KODU;
        entity.AILESINDE_INTIHAR_GIRISIMI = dto.AILESINDE_INTIHAR_GIRISIMI;
        entity.AILESINDE_PSIKIYATRIK_VAKA = dto.AILESINDE_PSIKIYATRIK_VAKA;
        entity.INTIHAR_KRIZ_VAKA_TURU = dto.INTIHAR_KRIZ_VAKA_TURU;
        entity.OLAY_ZAMANI = dto.OLAY_ZAMANI;
        entity.PSIKIYATRIK_TEDAVI_GECMISI = dto.PSIKIYATRIK_TEDAVI_GECMISI;
        entity.INTIHAR_GIRISIM_KRIZ_NEDENLERI = dto.INTIHAR_GIRISIM_KRIZ_NEDENLERI;
        entity.INTIHAR_GIRISIMI_YONTEMI = dto.INTIHAR_GIRISIMI_YONTEMI;
        entity.INTIHAR_GIRISIMI_GECMISI = dto.INTIHAR_GIRISIMI_GECMISI;
        entity.INTIHAR_KRIZ_VAKA_SONUCU = dto.INTIHAR_KRIZ_VAKA_SONUCU;
        entity.PSIKIYATRIK_TANI_GECMISI = dto.PSIKIYATRIK_TANI_GECMISI;
        entity.HAYVANIN_MEVCUT_DURUMU = dto.HAYVANIN_MEVCUT_DURUMU;
        entity.HAYVANIN_SAHIPLIK_DURUMU = dto.HAYVANIN_SAHIPLIK_DURUMU;
        entity.IMMUNGLOBULIN_TURU = dto.IMMUNGLOBULIN_TURU;
        entity.IMMUNGLOBULIN_MIKTARI = dto.IMMUNGLOBULIN_MIKTARI;
        entity.KATEGORIZASYON = dto.KATEGORIZASYON;
        entity.TEMAS_DEGERLENDIRME_DURUMU = dto.TEMAS_DEGERLENDIRME_DURUMU;
        entity.KUDUZ_SEBEP_OLAN_HAYVAN = dto.KUDUZ_SEBEP_OLAN_HAYVAN;
        entity.YAPTIRACAGINI_BEYAN_ETTIGI_TSM = dto.YAPTIRACAGINI_BEYAN_ETTIGI_TSM;
        entity.RISKLI_TEMAS_TIPI = dto.RISKLI_TEMAS_TIPI;
        entity.EV_TELEFONU = dto.EV_TELEFONU;
        entity.CEP_TELEFONU = dto.CEP_TELEFONU;
        entity.EV_ADRESI = dto.EV_ADRESI;
        entity.IL_KODU = dto.IL_KODU;
        entity.ILCE_KODU = dto.ILCE_KODU;
        entity.BCG_SKAR_SAYISI = dto.BCG_SKAR_SAYISI;
        entity.DGT_UYGULAMASINI_YAPAN_KISI = dto.DGT_UYGULAMASINI_YAPAN_KISI;
        entity.DGT_UYGULAMA_YERI = dto.DGT_UYGULAMA_YERI;
        entity.HASTANIN_TEDAVIYE_UYUMU = dto.HASTANIN_TEDAVIYE_UYUMU;
        entity.KULTUR_SONUCU = dto.KULTUR_SONUCU;
        entity.TUBERKULIN_DERI_TESTI_SONUCU = dto.TUBERKULIN_DERI_TESTI_SONUCU;
        entity.VEREM_HASTASI_TEDAVI_YONTEMI = dto.VEREM_HASTASI_TEDAVI_YONTEMI;
        entity.VEREM_OLGU_TANIMI = dto.VEREM_OLGU_TANIMI;
        entity.YAYMA_SONUCU = dto.YAYMA_SONUCU;
        entity.VEREM_HASTALIGI_TUTULUM_YERI = dto.VEREM_HASTALIGI_TUTULUM_YERI;
        entity.VEREM_HASTASI_KLINIK_ORNEGI = dto.VEREM_HASTASI_KLINIK_ORNEGI;
        entity.VEREM_ILAC_ADI = dto.VEREM_ILAC_ADI;
        entity.VEREM_TEDAVI_SONUCU = dto.VEREM_TEDAVI_SONUCU;
        entity.BULASICI_HASTALIK_VAKA_TIPI = dto.BULASICI_HASTALIK_VAKA_TIPI;
        entity.BELIRTILERIN_BASLADIGI_TARIH = dto.BELIRTILERIN_BASLADIGI_TARIH;
        entity.SIDDET_TURU = dto.SIDDET_TURU;
        entity.SIDDET_DEGERLENDIRME_SONUCU = dto.SIDDET_DEGERLENDIRME_SONUCU;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.BildirimiZorunlu)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<BILDIRIMI_ZORUNLU>()
            .FirstOrDefaultAsync(e => e.BILDIRIMI_ZORUNLU_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<BILDIRIMI_ZORUNLU>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
