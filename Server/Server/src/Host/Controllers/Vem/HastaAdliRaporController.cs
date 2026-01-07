using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.HastaAdliRapor;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class HastaAdliRaporController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public HastaAdliRaporController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.HastaAdliRapor)]
    public async Task<List<HastaAdliRaporDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<HASTA_ADLI_RAPOR>()
            .AsNoTracking()
            .Select(e => new HastaAdliRaporDto
            {
                HASTA_ADLI_RAPOR_KODU = e.HASTA_ADLI_RAPOR_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                HASTA_KODU = e.HASTA_KODU,
                ADLI_RAPOR_TURU = e.ADLI_RAPOR_TURU,
                RAPOR_ZAMANI = e.RAPOR_ZAMANI,
                ADLI_MUAYENEYE_GONDEREN_KURUM = e.ADLI_MUAYENEYE_GONDEREN_KURUM,
                RESMI_YAZI_NUMARASI = e.RESMI_YAZI_NUMARASI,
                RESMI_YAZI_TARIHI = e.RESMI_YAZI_TARIHI,
                ADLI_MUAYENE_EDILME_NEDENI = e.ADLI_MUAYENE_EDILME_NEDENI,
                GUVENLIK_SICIL_NUMARASI = e.GUVENLIK_SICIL_NUMARASI,
                GUVENLIK_ADI_SOYADI = e.GUVENLIK_ADI_SOYADI,
                OLAY_ZAMANI = e.OLAY_ZAMANI,
                ADLI_OLAY_OYKUSU = e.ADLI_OLAY_OYKUSU,
                SIKAYET = e.SIKAYET,
                OZGECMISI = e.OZGECMISI,
                SOYGECMISI = e.SOYGECMISI,
                MUAYENE_ZAMANI = e.MUAYENE_ZAMANI,
                HEKIM_KODU = e.HEKIM_KODU,
                TIBBI_MUDAHALE = e.TIBBI_MUDAHALE,
                UYGUN_SART_SAGLANMA_DURUMU = e.UYGUN_SART_SAGLANMA_DURUMU,
                UYGUN_SART_ACIKLAMA = e.UYGUN_SART_ACIKLAMA,
                ELBISE_DURUMU = e.ELBISE_DURUMU,
                KONSULTASYON_BILGISI = e.KONSULTASYON_BILGISI,
                LEZYON_BULGULARI = e.LEZYON_BULGULARI,
                SISTEM_BULGULARI = e.SISTEM_BULGULARI,
                BILINC_DURUMU = e.BILINC_DURUMU,
                PUPILLA_DEGERLENDIRMESI = e.PUPILLA_DEGERLENDIRMESI,
                ISIK_REFLEKSI = e.ISIK_REFLEKSI,
                NABIZ = e.NABIZ,
                TENDON_REFLEKSI = e.TENDON_REFLEKSI,
                PSIKIYATRIK_MUAYENE = e.PSIKIYATRIK_MUAYENE,
                PSIKIYATRIK_SONUC = e.PSIKIYATRIK_SONUC,
                HIZMET_ACIKLAMA = e.HIZMET_ACIKLAMA,
                SEVK_DURUMU = e.SEVK_DURUMU,
                SEVK_ACIKLAMA = e.SEVK_ACIKLAMA,
                TESLIM_ALAN_ADI_SOYADI = e.TESLIM_ALAN_ADI_SOYADI,
                TESLIM_ALAN_TC_KIMLIK_NUMARASI = e.TESLIM_ALAN_TC_KIMLIK_NUMARASI,
                VUCUT_DIYAGRAMI = e.VUCUT_DIYAGRAMI,
                ACIKLAMA = e.ACIKLAMA,
                ADLI_MUAYENE_RIZA_DURUMU = e.ADLI_MUAYENE_RIZA_DURUMU,
                RIZA_VEREN_KISI = e.RIZA_VEREN_KISI,
                RIZA_VERENIN_YAKINLIK_DERECESI = e.RIZA_VERENIN_YAKINLIK_DERECESI,
                SON_CINSEL_ILISKI_TARIHI = e.SON_CINSEL_ILISKI_TARIHI,
                HAMILELIK_DURUMU = e.HAMILELIK_DURUMU,
                HAMILELIK_OYKUSU_ACIKLAMA = e.HAMILELIK_OYKUSU_ACIKLAMA,
                VENERYAL_HASTALIK_OYKUSU = e.VENERYAL_HASTALIK_OYKUSU,
                EMOSYONEL_HASTALIK_OYKUSU = e.EMOSYONEL_HASTALIK_OYKUSU,
                SOLUNUM = e.SOLUNUM,
                ADLI_MUAYENE_NOTU = e.ADLI_MUAYENE_NOTU,
                ALINAN_MATERYAL = e.ALINAN_MATERYAL,
                MUAYENEDEKI_KISI_BILGISI = e.MUAYENEDEKI_KISI_BILGISI,
                MUAYENEDEKI_KISI_ACIKLAMA = e.MUAYENEDEKI_KISI_ACIKLAMA,
                ALKOL_KULLANIMI = e.ALKOL_KULLANIMI,
                SIDDET_TEHDIT_BILGISI = e.SIDDET_TEHDIT_BILGISI,
                SILAH_ALET_BILGISI = e.SILAH_ALET_BILGISI,
                HAYATI_TEHLIKE_DURUMU = e.HAYATI_TEHLIKE_DURUMU,
                SISTOLIK_KAN_BASINCI_DEGERI = e.SISTOLIK_KAN_BASINCI_DEGERI,
                DIASTOLIK_KAN_BASINCI_DEGERI = e.DIASTOLIK_KAN_BASINCI_DEGERI,
                IPTAL_ZAMANI = e.IPTAL_ZAMANI,
                IPTAL_EDEN_KULLANICI_KODU = e.IPTAL_EDEN_KULLANICI_KODU,
                ADLI_RAPOR_IPTAL_GEREKCESI = e.ADLI_RAPOR_IPTAL_GEREKCESI,
                ONAYLAYAN_KULLANICI_KODU = e.ONAYLAYAN_KULLANICI_KODU,
                ADLI_RAPOR_ONAYLANMA_ZAMANI = e.ADLI_RAPOR_ONAYLANMA_ZAMANI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.HastaAdliRapor)]
    public async Task<ActionResult<HastaAdliRaporDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_ADLI_RAPOR>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.HASTA_ADLI_RAPOR_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new HastaAdliRaporDto
        {
            HASTA_ADLI_RAPOR_KODU = entity.HASTA_ADLI_RAPOR_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            HASTA_KODU = entity.HASTA_KODU,
            ADLI_RAPOR_TURU = entity.ADLI_RAPOR_TURU,
            RAPOR_ZAMANI = entity.RAPOR_ZAMANI,
            ADLI_MUAYENEYE_GONDEREN_KURUM = entity.ADLI_MUAYENEYE_GONDEREN_KURUM,
            RESMI_YAZI_NUMARASI = entity.RESMI_YAZI_NUMARASI,
            RESMI_YAZI_TARIHI = entity.RESMI_YAZI_TARIHI,
            ADLI_MUAYENE_EDILME_NEDENI = entity.ADLI_MUAYENE_EDILME_NEDENI,
            GUVENLIK_SICIL_NUMARASI = entity.GUVENLIK_SICIL_NUMARASI,
            GUVENLIK_ADI_SOYADI = entity.GUVENLIK_ADI_SOYADI,
            OLAY_ZAMANI = entity.OLAY_ZAMANI,
            ADLI_OLAY_OYKUSU = entity.ADLI_OLAY_OYKUSU,
            SIKAYET = entity.SIKAYET,
            OZGECMISI = entity.OZGECMISI,
            SOYGECMISI = entity.SOYGECMISI,
            MUAYENE_ZAMANI = entity.MUAYENE_ZAMANI,
            HEKIM_KODU = entity.HEKIM_KODU,
            TIBBI_MUDAHALE = entity.TIBBI_MUDAHALE,
            UYGUN_SART_SAGLANMA_DURUMU = entity.UYGUN_SART_SAGLANMA_DURUMU,
            UYGUN_SART_ACIKLAMA = entity.UYGUN_SART_ACIKLAMA,
            ELBISE_DURUMU = entity.ELBISE_DURUMU,
            KONSULTASYON_BILGISI = entity.KONSULTASYON_BILGISI,
            LEZYON_BULGULARI = entity.LEZYON_BULGULARI,
            SISTEM_BULGULARI = entity.SISTEM_BULGULARI,
            BILINC_DURUMU = entity.BILINC_DURUMU,
            PUPILLA_DEGERLENDIRMESI = entity.PUPILLA_DEGERLENDIRMESI,
            ISIK_REFLEKSI = entity.ISIK_REFLEKSI,
            NABIZ = entity.NABIZ,
            TENDON_REFLEKSI = entity.TENDON_REFLEKSI,
            PSIKIYATRIK_MUAYENE = entity.PSIKIYATRIK_MUAYENE,
            PSIKIYATRIK_SONUC = entity.PSIKIYATRIK_SONUC,
            HIZMET_ACIKLAMA = entity.HIZMET_ACIKLAMA,
            SEVK_DURUMU = entity.SEVK_DURUMU,
            SEVK_ACIKLAMA = entity.SEVK_ACIKLAMA,
            TESLIM_ALAN_ADI_SOYADI = entity.TESLIM_ALAN_ADI_SOYADI,
            TESLIM_ALAN_TC_KIMLIK_NUMARASI = entity.TESLIM_ALAN_TC_KIMLIK_NUMARASI,
            VUCUT_DIYAGRAMI = entity.VUCUT_DIYAGRAMI,
            ACIKLAMA = entity.ACIKLAMA,
            ADLI_MUAYENE_RIZA_DURUMU = entity.ADLI_MUAYENE_RIZA_DURUMU,
            RIZA_VEREN_KISI = entity.RIZA_VEREN_KISI,
            RIZA_VERENIN_YAKINLIK_DERECESI = entity.RIZA_VERENIN_YAKINLIK_DERECESI,
            SON_CINSEL_ILISKI_TARIHI = entity.SON_CINSEL_ILISKI_TARIHI,
            HAMILELIK_DURUMU = entity.HAMILELIK_DURUMU,
            HAMILELIK_OYKUSU_ACIKLAMA = entity.HAMILELIK_OYKUSU_ACIKLAMA,
            VENERYAL_HASTALIK_OYKUSU = entity.VENERYAL_HASTALIK_OYKUSU,
            EMOSYONEL_HASTALIK_OYKUSU = entity.EMOSYONEL_HASTALIK_OYKUSU,
            SOLUNUM = entity.SOLUNUM,
            ADLI_MUAYENE_NOTU = entity.ADLI_MUAYENE_NOTU,
            ALINAN_MATERYAL = entity.ALINAN_MATERYAL,
            MUAYENEDEKI_KISI_BILGISI = entity.MUAYENEDEKI_KISI_BILGISI,
            MUAYENEDEKI_KISI_ACIKLAMA = entity.MUAYENEDEKI_KISI_ACIKLAMA,
            ALKOL_KULLANIMI = entity.ALKOL_KULLANIMI,
            SIDDET_TEHDIT_BILGISI = entity.SIDDET_TEHDIT_BILGISI,
            SILAH_ALET_BILGISI = entity.SILAH_ALET_BILGISI,
            HAYATI_TEHLIKE_DURUMU = entity.HAYATI_TEHLIKE_DURUMU,
            SISTOLIK_KAN_BASINCI_DEGERI = entity.SISTOLIK_KAN_BASINCI_DEGERI,
            DIASTOLIK_KAN_BASINCI_DEGERI = entity.DIASTOLIK_KAN_BASINCI_DEGERI,
            IPTAL_ZAMANI = entity.IPTAL_ZAMANI,
            IPTAL_EDEN_KULLANICI_KODU = entity.IPTAL_EDEN_KULLANICI_KODU,
            ADLI_RAPOR_IPTAL_GEREKCESI = entity.ADLI_RAPOR_IPTAL_GEREKCESI,
            ONAYLAYAN_KULLANICI_KODU = entity.ONAYLAYAN_KULLANICI_KODU,
            ADLI_RAPOR_ONAYLANMA_ZAMANI = entity.ADLI_RAPOR_ONAYLANMA_ZAMANI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.HastaAdliRapor)]
    public async Task<ActionResult<string>> Create(HastaAdliRaporDto dto, CancellationToken ct)
    {
        var entity = new HASTA_ADLI_RAPOR
        {
            HASTA_ADLI_RAPOR_KODU = dto.HASTA_ADLI_RAPOR_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            HASTA_KODU = dto.HASTA_KODU,
            ADLI_RAPOR_TURU = dto.ADLI_RAPOR_TURU,
            RAPOR_ZAMANI = dto.RAPOR_ZAMANI,
            ADLI_MUAYENEYE_GONDEREN_KURUM = dto.ADLI_MUAYENEYE_GONDEREN_KURUM,
            RESMI_YAZI_NUMARASI = dto.RESMI_YAZI_NUMARASI,
            RESMI_YAZI_TARIHI = dto.RESMI_YAZI_TARIHI,
            ADLI_MUAYENE_EDILME_NEDENI = dto.ADLI_MUAYENE_EDILME_NEDENI,
            GUVENLIK_SICIL_NUMARASI = dto.GUVENLIK_SICIL_NUMARASI,
            GUVENLIK_ADI_SOYADI = dto.GUVENLIK_ADI_SOYADI,
            OLAY_ZAMANI = dto.OLAY_ZAMANI,
            ADLI_OLAY_OYKUSU = dto.ADLI_OLAY_OYKUSU,
            SIKAYET = dto.SIKAYET,
            OZGECMISI = dto.OZGECMISI,
            SOYGECMISI = dto.SOYGECMISI,
            MUAYENE_ZAMANI = dto.MUAYENE_ZAMANI,
            HEKIM_KODU = dto.HEKIM_KODU,
            TIBBI_MUDAHALE = dto.TIBBI_MUDAHALE,
            UYGUN_SART_SAGLANMA_DURUMU = dto.UYGUN_SART_SAGLANMA_DURUMU,
            UYGUN_SART_ACIKLAMA = dto.UYGUN_SART_ACIKLAMA,
            ELBISE_DURUMU = dto.ELBISE_DURUMU,
            KONSULTASYON_BILGISI = dto.KONSULTASYON_BILGISI,
            LEZYON_BULGULARI = dto.LEZYON_BULGULARI,
            SISTEM_BULGULARI = dto.SISTEM_BULGULARI,
            BILINC_DURUMU = dto.BILINC_DURUMU,
            PUPILLA_DEGERLENDIRMESI = dto.PUPILLA_DEGERLENDIRMESI,
            ISIK_REFLEKSI = dto.ISIK_REFLEKSI,
            NABIZ = dto.NABIZ,
            TENDON_REFLEKSI = dto.TENDON_REFLEKSI,
            PSIKIYATRIK_MUAYENE = dto.PSIKIYATRIK_MUAYENE,
            PSIKIYATRIK_SONUC = dto.PSIKIYATRIK_SONUC,
            HIZMET_ACIKLAMA = dto.HIZMET_ACIKLAMA,
            SEVK_DURUMU = dto.SEVK_DURUMU,
            SEVK_ACIKLAMA = dto.SEVK_ACIKLAMA,
            TESLIM_ALAN_ADI_SOYADI = dto.TESLIM_ALAN_ADI_SOYADI,
            TESLIM_ALAN_TC_KIMLIK_NUMARASI = dto.TESLIM_ALAN_TC_KIMLIK_NUMARASI,
            VUCUT_DIYAGRAMI = dto.VUCUT_DIYAGRAMI,
            ACIKLAMA = dto.ACIKLAMA,
            ADLI_MUAYENE_RIZA_DURUMU = dto.ADLI_MUAYENE_RIZA_DURUMU,
            RIZA_VEREN_KISI = dto.RIZA_VEREN_KISI,
            RIZA_VERENIN_YAKINLIK_DERECESI = dto.RIZA_VERENIN_YAKINLIK_DERECESI,
            SON_CINSEL_ILISKI_TARIHI = dto.SON_CINSEL_ILISKI_TARIHI,
            HAMILELIK_DURUMU = dto.HAMILELIK_DURUMU,
            HAMILELIK_OYKUSU_ACIKLAMA = dto.HAMILELIK_OYKUSU_ACIKLAMA,
            VENERYAL_HASTALIK_OYKUSU = dto.VENERYAL_HASTALIK_OYKUSU,
            EMOSYONEL_HASTALIK_OYKUSU = dto.EMOSYONEL_HASTALIK_OYKUSU,
            SOLUNUM = dto.SOLUNUM,
            ADLI_MUAYENE_NOTU = dto.ADLI_MUAYENE_NOTU,
            ALINAN_MATERYAL = dto.ALINAN_MATERYAL,
            MUAYENEDEKI_KISI_BILGISI = dto.MUAYENEDEKI_KISI_BILGISI,
            MUAYENEDEKI_KISI_ACIKLAMA = dto.MUAYENEDEKI_KISI_ACIKLAMA,
            ALKOL_KULLANIMI = dto.ALKOL_KULLANIMI,
            SIDDET_TEHDIT_BILGISI = dto.SIDDET_TEHDIT_BILGISI,
            SILAH_ALET_BILGISI = dto.SILAH_ALET_BILGISI,
            HAYATI_TEHLIKE_DURUMU = dto.HAYATI_TEHLIKE_DURUMU,
            SISTOLIK_KAN_BASINCI_DEGERI = dto.SISTOLIK_KAN_BASINCI_DEGERI,
            DIASTOLIK_KAN_BASINCI_DEGERI = dto.DIASTOLIK_KAN_BASINCI_DEGERI,
            IPTAL_ZAMANI = dto.IPTAL_ZAMANI,
            IPTAL_EDEN_KULLANICI_KODU = dto.IPTAL_EDEN_KULLANICI_KODU,
            ADLI_RAPOR_IPTAL_GEREKCESI = dto.ADLI_RAPOR_IPTAL_GEREKCESI,
            ONAYLAYAN_KULLANICI_KODU = dto.ONAYLAYAN_KULLANICI_KODU,
            ADLI_RAPOR_ONAYLANMA_ZAMANI = dto.ADLI_RAPOR_ONAYLANMA_ZAMANI,
        };

        _db.Set<HASTA_ADLI_RAPOR>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.HASTA_ADLI_RAPOR_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.HastaAdliRapor)]
    public async Task<IActionResult> Update(string id, HastaAdliRaporDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_ADLI_RAPOR>()
            .FirstOrDefaultAsync(e => e.HASTA_ADLI_RAPOR_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.ADLI_RAPOR_TURU = dto.ADLI_RAPOR_TURU;
        entity.RAPOR_ZAMANI = dto.RAPOR_ZAMANI;
        entity.ADLI_MUAYENEYE_GONDEREN_KURUM = dto.ADLI_MUAYENEYE_GONDEREN_KURUM;
        entity.RESMI_YAZI_NUMARASI = dto.RESMI_YAZI_NUMARASI;
        entity.RESMI_YAZI_TARIHI = dto.RESMI_YAZI_TARIHI;
        entity.ADLI_MUAYENE_EDILME_NEDENI = dto.ADLI_MUAYENE_EDILME_NEDENI;
        entity.GUVENLIK_SICIL_NUMARASI = dto.GUVENLIK_SICIL_NUMARASI;
        entity.GUVENLIK_ADI_SOYADI = dto.GUVENLIK_ADI_SOYADI;
        entity.OLAY_ZAMANI = dto.OLAY_ZAMANI;
        entity.ADLI_OLAY_OYKUSU = dto.ADLI_OLAY_OYKUSU;
        entity.SIKAYET = dto.SIKAYET;
        entity.OZGECMISI = dto.OZGECMISI;
        entity.SOYGECMISI = dto.SOYGECMISI;
        entity.MUAYENE_ZAMANI = dto.MUAYENE_ZAMANI;
        entity.HEKIM_KODU = dto.HEKIM_KODU;
        entity.TIBBI_MUDAHALE = dto.TIBBI_MUDAHALE;
        entity.UYGUN_SART_SAGLANMA_DURUMU = dto.UYGUN_SART_SAGLANMA_DURUMU;
        entity.UYGUN_SART_ACIKLAMA = dto.UYGUN_SART_ACIKLAMA;
        entity.ELBISE_DURUMU = dto.ELBISE_DURUMU;
        entity.KONSULTASYON_BILGISI = dto.KONSULTASYON_BILGISI;
        entity.LEZYON_BULGULARI = dto.LEZYON_BULGULARI;
        entity.SISTEM_BULGULARI = dto.SISTEM_BULGULARI;
        entity.BILINC_DURUMU = dto.BILINC_DURUMU;
        entity.PUPILLA_DEGERLENDIRMESI = dto.PUPILLA_DEGERLENDIRMESI;
        entity.ISIK_REFLEKSI = dto.ISIK_REFLEKSI;
        entity.NABIZ = dto.NABIZ;
        entity.TENDON_REFLEKSI = dto.TENDON_REFLEKSI;
        entity.PSIKIYATRIK_MUAYENE = dto.PSIKIYATRIK_MUAYENE;
        entity.PSIKIYATRIK_SONUC = dto.PSIKIYATRIK_SONUC;
        entity.HIZMET_ACIKLAMA = dto.HIZMET_ACIKLAMA;
        entity.SEVK_DURUMU = dto.SEVK_DURUMU;
        entity.SEVK_ACIKLAMA = dto.SEVK_ACIKLAMA;
        entity.TESLIM_ALAN_ADI_SOYADI = dto.TESLIM_ALAN_ADI_SOYADI;
        entity.TESLIM_ALAN_TC_KIMLIK_NUMARASI = dto.TESLIM_ALAN_TC_KIMLIK_NUMARASI;
        entity.VUCUT_DIYAGRAMI = dto.VUCUT_DIYAGRAMI;
        entity.ACIKLAMA = dto.ACIKLAMA;
        entity.ADLI_MUAYENE_RIZA_DURUMU = dto.ADLI_MUAYENE_RIZA_DURUMU;
        entity.RIZA_VEREN_KISI = dto.RIZA_VEREN_KISI;
        entity.RIZA_VERENIN_YAKINLIK_DERECESI = dto.RIZA_VERENIN_YAKINLIK_DERECESI;
        entity.SON_CINSEL_ILISKI_TARIHI = dto.SON_CINSEL_ILISKI_TARIHI;
        entity.HAMILELIK_DURUMU = dto.HAMILELIK_DURUMU;
        entity.HAMILELIK_OYKUSU_ACIKLAMA = dto.HAMILELIK_OYKUSU_ACIKLAMA;
        entity.VENERYAL_HASTALIK_OYKUSU = dto.VENERYAL_HASTALIK_OYKUSU;
        entity.EMOSYONEL_HASTALIK_OYKUSU = dto.EMOSYONEL_HASTALIK_OYKUSU;
        entity.SOLUNUM = dto.SOLUNUM;
        entity.ADLI_MUAYENE_NOTU = dto.ADLI_MUAYENE_NOTU;
        entity.ALINAN_MATERYAL = dto.ALINAN_MATERYAL;
        entity.MUAYENEDEKI_KISI_BILGISI = dto.MUAYENEDEKI_KISI_BILGISI;
        entity.MUAYENEDEKI_KISI_ACIKLAMA = dto.MUAYENEDEKI_KISI_ACIKLAMA;
        entity.ALKOL_KULLANIMI = dto.ALKOL_KULLANIMI;
        entity.SIDDET_TEHDIT_BILGISI = dto.SIDDET_TEHDIT_BILGISI;
        entity.SILAH_ALET_BILGISI = dto.SILAH_ALET_BILGISI;
        entity.HAYATI_TEHLIKE_DURUMU = dto.HAYATI_TEHLIKE_DURUMU;
        entity.SISTOLIK_KAN_BASINCI_DEGERI = dto.SISTOLIK_KAN_BASINCI_DEGERI;
        entity.DIASTOLIK_KAN_BASINCI_DEGERI = dto.DIASTOLIK_KAN_BASINCI_DEGERI;
        entity.IPTAL_ZAMANI = dto.IPTAL_ZAMANI;
        entity.IPTAL_EDEN_KULLANICI_KODU = dto.IPTAL_EDEN_KULLANICI_KODU;
        entity.ADLI_RAPOR_IPTAL_GEREKCESI = dto.ADLI_RAPOR_IPTAL_GEREKCESI;
        entity.ONAYLAYAN_KULLANICI_KODU = dto.ONAYLAYAN_KULLANICI_KODU;
        entity.ADLI_RAPOR_ONAYLANMA_ZAMANI = dto.ADLI_RAPOR_ONAYLANMA_ZAMANI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.HastaAdliRapor)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<HASTA_ADLI_RAPOR>()
            .FirstOrDefaultAsync(e => e.HASTA_ADLI_RAPOR_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<HASTA_ADLI_RAPOR>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
