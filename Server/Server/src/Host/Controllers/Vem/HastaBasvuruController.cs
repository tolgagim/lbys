using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.HastaBasvuru;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class HastaBasvuruController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public HastaBasvuruController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.HastaBasvuru)]
    public async Task<List<HastaBasvuruDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<HASTA_BASVURU>()
            .AsNoTracking()
            .Select(e => new HastaBasvuruDto
            {
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                HASTA_KODU = e.HASTA_KODU,
                BIRIM_KODU = e.BIRIM_KODU,
                TEDAVI_TURU = e.TEDAVI_TURU,
                CIKIS_SEKLI = e.CIKIS_SEKLI,
                HASTA_KABUL_ZAMANI = e.HASTA_KABUL_ZAMANI,
                CIKIS_ZAMANI = e.CIKIS_ZAMANI,
                HEKIM_KODU = e.HEKIM_KODU,
                HEKIM_BASVURU_NOTU = e.HEKIM_BASVURU_NOTU,
                MUAYENE_TURU = e.MUAYENE_TURU,
                KABUL_SEKLI = e.KABUL_SEKLI,
                SOSYAL_GUVENCE_DURUMU = e.SOSYAL_GUVENCE_DURUMU,
                SYS_TAKIP_NUMARASI = e.SYS_TAKIP_NUMARASI,
                TRIAJ_KODU = e.TRIAJ_KODU,
                ADLI_VAKA_GELIS_SEKLI = e.ADLI_VAKA_GELIS_SEKLI,
                AMBULANS_PLAKA_NUMARASI = e.AMBULANS_PLAKA_NUMARASI,
                AMBULANS_TAKIP_NUMARASI = e.AMBULANS_TAKIP_NUMARASI,
                ARAC_TURU = e.ARAC_TURU,
                ASISTAN_HEKIM_KODU = e.ASISTAN_HEKIM_KODU,
                BAGLI_OLDUGU_BASVURU_KODU = e.BAGLI_OLDUGU_BASVURU_KODU,
                BASVURU_DURUMU = e.BASVURU_DURUMU,
                BASVURU_PROTOKOL_NUMARASI = e.BASVURU_PROTOKOL_NUMARASI,
                CIKIS_VEREN_HEKIM_KODU = e.CIKIS_VEREN_HEKIM_KODU,
                DEFTER_NUMARASI = e.DEFTER_NUMARASI,
                DIYABET_EGITIMI = e.DIYABET_EGITIMI,
                DIYABET_KOMPLIKASYONLARI = e.DIYABET_KOMPLIKASYONLARI,
                GEBLIZ_BILDIRIM_NUMARASI = e.GEBLIZ_BILDIRIM_NUMARASI,
                GELDIGI_ULKE_KODU = e.GELDIGI_ULKE_KODU,
                GENCLIK_SAGLIGI_ISLEMLERI = e.GENCLIK_SAGLIGI_ISLEMLERI,
                GUNLUK_SIRA_NUMARASI = e.GUNLUK_SIRA_NUMARASI,
                HAYATI_TEHLIKE_DURUMU = e.HAYATI_TEHLIKE_DURUMU,
                HIZMET_SUNUCU = e.HIZMET_SUNUCU,
                KAYIT_YERI = e.KAYIT_YERI,
                KURUM_KODU = e.KURUM_KODU,
                MUAYENE_BASLAMA_ZAMANI = e.MUAYENE_BASLAMA_ZAMANI,
                MUAYENE_BITIS_ZAMANI = e.MUAYENE_BITIS_ZAMANI,
                MUAYENE_ONCELIK_SIRASI = e.MUAYENE_ONCELIK_SIRASI,
                OLAY_AFET_KODU = e.OLAY_AFET_KODU,
                ONLINE_PROTOKOL_NUMARASI = e.ONLINE_PROTOKOL_NUMARASI,
                SAGLIK_TURIZMI_ULKE_KODU = e.SAGLIK_TURIZMI_ULKE_KODU,
                SEVK_TANISI = e.SEVK_TANISI,
                SEVK_ZAMANI = e.SEVK_ZAMANI,
                SYS_REFERANS_NUMARASI = e.SYS_REFERANS_NUMARASI,
                TAMAMLAYICI_KURUM_KODU = e.TAMAMLAYICI_KURUM_KODU,
                VAKA_TURU = e.VAKA_TURU,
                YABANCI_HASTA_TURU = e.YABANCI_HASTA_TURU,
                YATIS_BILGISI = e.YATIS_BILGISI,
                YATIS_PROTOKOL_NUMARASI = e.YATIS_PROTOKOL_NUMARASI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.HastaBasvuru)]
    public async Task<ActionResult<HastaBasvuruDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_BASVURU>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.HASTA_BASVURU_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new HastaBasvuruDto
        {
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            HASTA_KODU = entity.HASTA_KODU,
            BIRIM_KODU = entity.BIRIM_KODU,
            TEDAVI_TURU = entity.TEDAVI_TURU,
            CIKIS_SEKLI = entity.CIKIS_SEKLI,
            HASTA_KABUL_ZAMANI = entity.HASTA_KABUL_ZAMANI,
            CIKIS_ZAMANI = entity.CIKIS_ZAMANI,
            HEKIM_KODU = entity.HEKIM_KODU,
            HEKIM_BASVURU_NOTU = entity.HEKIM_BASVURU_NOTU,
            MUAYENE_TURU = entity.MUAYENE_TURU,
            KABUL_SEKLI = entity.KABUL_SEKLI,
            SOSYAL_GUVENCE_DURUMU = entity.SOSYAL_GUVENCE_DURUMU,
            SYS_TAKIP_NUMARASI = entity.SYS_TAKIP_NUMARASI,
            TRIAJ_KODU = entity.TRIAJ_KODU,
            ADLI_VAKA_GELIS_SEKLI = entity.ADLI_VAKA_GELIS_SEKLI,
            AMBULANS_PLAKA_NUMARASI = entity.AMBULANS_PLAKA_NUMARASI,
            AMBULANS_TAKIP_NUMARASI = entity.AMBULANS_TAKIP_NUMARASI,
            ARAC_TURU = entity.ARAC_TURU,
            ASISTAN_HEKIM_KODU = entity.ASISTAN_HEKIM_KODU,
            BAGLI_OLDUGU_BASVURU_KODU = entity.BAGLI_OLDUGU_BASVURU_KODU,
            BASVURU_DURUMU = entity.BASVURU_DURUMU,
            BASVURU_PROTOKOL_NUMARASI = entity.BASVURU_PROTOKOL_NUMARASI,
            CIKIS_VEREN_HEKIM_KODU = entity.CIKIS_VEREN_HEKIM_KODU,
            DEFTER_NUMARASI = entity.DEFTER_NUMARASI,
            DIYABET_EGITIMI = entity.DIYABET_EGITIMI,
            DIYABET_KOMPLIKASYONLARI = entity.DIYABET_KOMPLIKASYONLARI,
            GEBLIZ_BILDIRIM_NUMARASI = entity.GEBLIZ_BILDIRIM_NUMARASI,
            GELDIGI_ULKE_KODU = entity.GELDIGI_ULKE_KODU,
            GENCLIK_SAGLIGI_ISLEMLERI = entity.GENCLIK_SAGLIGI_ISLEMLERI,
            GUNLUK_SIRA_NUMARASI = entity.GUNLUK_SIRA_NUMARASI,
            HAYATI_TEHLIKE_DURUMU = entity.HAYATI_TEHLIKE_DURUMU,
            HIZMET_SUNUCU = entity.HIZMET_SUNUCU,
            KAYIT_YERI = entity.KAYIT_YERI,
            KURUM_KODU = entity.KURUM_KODU,
            MUAYENE_BASLAMA_ZAMANI = entity.MUAYENE_BASLAMA_ZAMANI,
            MUAYENE_BITIS_ZAMANI = entity.MUAYENE_BITIS_ZAMANI,
            MUAYENE_ONCELIK_SIRASI = entity.MUAYENE_ONCELIK_SIRASI,
            OLAY_AFET_KODU = entity.OLAY_AFET_KODU,
            ONLINE_PROTOKOL_NUMARASI = entity.ONLINE_PROTOKOL_NUMARASI,
            SAGLIK_TURIZMI_ULKE_KODU = entity.SAGLIK_TURIZMI_ULKE_KODU,
            SEVK_TANISI = entity.SEVK_TANISI,
            SEVK_ZAMANI = entity.SEVK_ZAMANI,
            SYS_REFERANS_NUMARASI = entity.SYS_REFERANS_NUMARASI,
            TAMAMLAYICI_KURUM_KODU = entity.TAMAMLAYICI_KURUM_KODU,
            VAKA_TURU = entity.VAKA_TURU,
            YABANCI_HASTA_TURU = entity.YABANCI_HASTA_TURU,
            YATIS_BILGISI = entity.YATIS_BILGISI,
            YATIS_PROTOKOL_NUMARASI = entity.YATIS_PROTOKOL_NUMARASI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.HastaBasvuru)]
    public async Task<ActionResult<string>> Create(HastaBasvuruDto dto, CancellationToken ct)
    {
        var entity = new HASTA_BASVURU
        {
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            HASTA_KODU = dto.HASTA_KODU,
            BIRIM_KODU = dto.BIRIM_KODU,
            TEDAVI_TURU = dto.TEDAVI_TURU,
            CIKIS_SEKLI = dto.CIKIS_SEKLI,
            HASTA_KABUL_ZAMANI = dto.HASTA_KABUL_ZAMANI,
            CIKIS_ZAMANI = dto.CIKIS_ZAMANI,
            HEKIM_KODU = dto.HEKIM_KODU,
            HEKIM_BASVURU_NOTU = dto.HEKIM_BASVURU_NOTU,
            MUAYENE_TURU = dto.MUAYENE_TURU,
            KABUL_SEKLI = dto.KABUL_SEKLI,
            SOSYAL_GUVENCE_DURUMU = dto.SOSYAL_GUVENCE_DURUMU,
            SYS_TAKIP_NUMARASI = dto.SYS_TAKIP_NUMARASI,
            TRIAJ_KODU = dto.TRIAJ_KODU,
            ADLI_VAKA_GELIS_SEKLI = dto.ADLI_VAKA_GELIS_SEKLI,
            AMBULANS_PLAKA_NUMARASI = dto.AMBULANS_PLAKA_NUMARASI,
            AMBULANS_TAKIP_NUMARASI = dto.AMBULANS_TAKIP_NUMARASI,
            ARAC_TURU = dto.ARAC_TURU,
            ASISTAN_HEKIM_KODU = dto.ASISTAN_HEKIM_KODU,
            BAGLI_OLDUGU_BASVURU_KODU = dto.BAGLI_OLDUGU_BASVURU_KODU,
            BASVURU_DURUMU = dto.BASVURU_DURUMU,
            BASVURU_PROTOKOL_NUMARASI = dto.BASVURU_PROTOKOL_NUMARASI,
            CIKIS_VEREN_HEKIM_KODU = dto.CIKIS_VEREN_HEKIM_KODU,
            DEFTER_NUMARASI = dto.DEFTER_NUMARASI,
            DIYABET_EGITIMI = dto.DIYABET_EGITIMI,
            DIYABET_KOMPLIKASYONLARI = dto.DIYABET_KOMPLIKASYONLARI,
            GEBLIZ_BILDIRIM_NUMARASI = dto.GEBLIZ_BILDIRIM_NUMARASI,
            GELDIGI_ULKE_KODU = dto.GELDIGI_ULKE_KODU,
            GENCLIK_SAGLIGI_ISLEMLERI = dto.GENCLIK_SAGLIGI_ISLEMLERI,
            GUNLUK_SIRA_NUMARASI = dto.GUNLUK_SIRA_NUMARASI,
            HAYATI_TEHLIKE_DURUMU = dto.HAYATI_TEHLIKE_DURUMU,
            HIZMET_SUNUCU = dto.HIZMET_SUNUCU,
            KAYIT_YERI = dto.KAYIT_YERI,
            KURUM_KODU = dto.KURUM_KODU,
            MUAYENE_BASLAMA_ZAMANI = dto.MUAYENE_BASLAMA_ZAMANI,
            MUAYENE_BITIS_ZAMANI = dto.MUAYENE_BITIS_ZAMANI,
            MUAYENE_ONCELIK_SIRASI = dto.MUAYENE_ONCELIK_SIRASI,
            OLAY_AFET_KODU = dto.OLAY_AFET_KODU,
            ONLINE_PROTOKOL_NUMARASI = dto.ONLINE_PROTOKOL_NUMARASI,
            SAGLIK_TURIZMI_ULKE_KODU = dto.SAGLIK_TURIZMI_ULKE_KODU,
            SEVK_TANISI = dto.SEVK_TANISI,
            SEVK_ZAMANI = dto.SEVK_ZAMANI,
            SYS_REFERANS_NUMARASI = dto.SYS_REFERANS_NUMARASI,
            TAMAMLAYICI_KURUM_KODU = dto.TAMAMLAYICI_KURUM_KODU,
            VAKA_TURU = dto.VAKA_TURU,
            YABANCI_HASTA_TURU = dto.YABANCI_HASTA_TURU,
            YATIS_BILGISI = dto.YATIS_BILGISI,
            YATIS_PROTOKOL_NUMARASI = dto.YATIS_PROTOKOL_NUMARASI,
        };

        _db.Set<HASTA_BASVURU>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.HASTA_BASVURU_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.HastaBasvuru)]
    public async Task<IActionResult> Update(string id, HastaBasvuruDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_BASVURU>()
            .FirstOrDefaultAsync(e => e.HASTA_BASVURU_KODU == id, ct);

        if (entity == null)
            return NotFound();

        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.BIRIM_KODU = dto.BIRIM_KODU;
        entity.TEDAVI_TURU = dto.TEDAVI_TURU;
        entity.CIKIS_SEKLI = dto.CIKIS_SEKLI;
        entity.HASTA_KABUL_ZAMANI = dto.HASTA_KABUL_ZAMANI;
        entity.CIKIS_ZAMANI = dto.CIKIS_ZAMANI;
        entity.HEKIM_KODU = dto.HEKIM_KODU;
        entity.HEKIM_BASVURU_NOTU = dto.HEKIM_BASVURU_NOTU;
        entity.MUAYENE_TURU = dto.MUAYENE_TURU;
        entity.KABUL_SEKLI = dto.KABUL_SEKLI;
        entity.SOSYAL_GUVENCE_DURUMU = dto.SOSYAL_GUVENCE_DURUMU;
        entity.SYS_TAKIP_NUMARASI = dto.SYS_TAKIP_NUMARASI;
        entity.TRIAJ_KODU = dto.TRIAJ_KODU;
        entity.ADLI_VAKA_GELIS_SEKLI = dto.ADLI_VAKA_GELIS_SEKLI;
        entity.AMBULANS_PLAKA_NUMARASI = dto.AMBULANS_PLAKA_NUMARASI;
        entity.AMBULANS_TAKIP_NUMARASI = dto.AMBULANS_TAKIP_NUMARASI;
        entity.ARAC_TURU = dto.ARAC_TURU;
        entity.ASISTAN_HEKIM_KODU = dto.ASISTAN_HEKIM_KODU;
        entity.BAGLI_OLDUGU_BASVURU_KODU = dto.BAGLI_OLDUGU_BASVURU_KODU;
        entity.BASVURU_DURUMU = dto.BASVURU_DURUMU;
        entity.BASVURU_PROTOKOL_NUMARASI = dto.BASVURU_PROTOKOL_NUMARASI;
        entity.CIKIS_VEREN_HEKIM_KODU = dto.CIKIS_VEREN_HEKIM_KODU;
        entity.DEFTER_NUMARASI = dto.DEFTER_NUMARASI;
        entity.DIYABET_EGITIMI = dto.DIYABET_EGITIMI;
        entity.DIYABET_KOMPLIKASYONLARI = dto.DIYABET_KOMPLIKASYONLARI;
        entity.GEBLIZ_BILDIRIM_NUMARASI = dto.GEBLIZ_BILDIRIM_NUMARASI;
        entity.GELDIGI_ULKE_KODU = dto.GELDIGI_ULKE_KODU;
        entity.GENCLIK_SAGLIGI_ISLEMLERI = dto.GENCLIK_SAGLIGI_ISLEMLERI;
        entity.GUNLUK_SIRA_NUMARASI = dto.GUNLUK_SIRA_NUMARASI;
        entity.HAYATI_TEHLIKE_DURUMU = dto.HAYATI_TEHLIKE_DURUMU;
        entity.HIZMET_SUNUCU = dto.HIZMET_SUNUCU;
        entity.KAYIT_YERI = dto.KAYIT_YERI;
        entity.KURUM_KODU = dto.KURUM_KODU;
        entity.MUAYENE_BASLAMA_ZAMANI = dto.MUAYENE_BASLAMA_ZAMANI;
        entity.MUAYENE_BITIS_ZAMANI = dto.MUAYENE_BITIS_ZAMANI;
        entity.MUAYENE_ONCELIK_SIRASI = dto.MUAYENE_ONCELIK_SIRASI;
        entity.OLAY_AFET_KODU = dto.OLAY_AFET_KODU;
        entity.ONLINE_PROTOKOL_NUMARASI = dto.ONLINE_PROTOKOL_NUMARASI;
        entity.SAGLIK_TURIZMI_ULKE_KODU = dto.SAGLIK_TURIZMI_ULKE_KODU;
        entity.SEVK_TANISI = dto.SEVK_TANISI;
        entity.SEVK_ZAMANI = dto.SEVK_ZAMANI;
        entity.SYS_REFERANS_NUMARASI = dto.SYS_REFERANS_NUMARASI;
        entity.TAMAMLAYICI_KURUM_KODU = dto.TAMAMLAYICI_KURUM_KODU;
        entity.VAKA_TURU = dto.VAKA_TURU;
        entity.YABANCI_HASTA_TURU = dto.YABANCI_HASTA_TURU;
        entity.YATIS_BILGISI = dto.YATIS_BILGISI;
        entity.YATIS_PROTOKOL_NUMARASI = dto.YATIS_PROTOKOL_NUMARASI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.HastaBasvuru)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_BASVURU>()
            .FirstOrDefaultAsync(e => e.HASTA_BASVURU_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<HASTA_BASVURU>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
