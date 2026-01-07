using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.BebekCocukIzlem;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class BebekCocukIzlemController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public BebekCocukIzlemController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.BebekCocukIzlem)]
    public async Task<List<BebekCocukIzlemDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<BEBEK_COCUK_IZLEM>()
            .AsNoTracking()
            .Select(e => new BebekCocukIzlemDto
            {
                BEBEK_COCUK_IZLEM_KODU = e.BEBEK_COCUK_IZLEM_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                HASTA_KODU = e.HASTA_KODU,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                KACINCI_IZLEM = e.KACINCI_IZLEM,
                AGIZDAN_SIVI_TEDAVISI = e.AGIZDAN_SIVI_TEDAVISI,
                BAS_CEVRESI = e.BAS_CEVRESI,
                DEMIR_LOJISTIGI_VE_DESTEGI = e.DEMIR_LOJISTIGI_VE_DESTEGI,
                DOGUM_AGIRLIGI = e.DOGUM_AGIRLIGI,
                DVITAMINI_LOJISTIGI_VE_DESTEGI = e.DVITAMINI_LOJISTIGI_VE_DESTEGI,
                GKD_TARAMA_SONUCU = e.GKD_TARAMA_SONUCU,
                HEMATOKRIT_DEGERI = e.HEMATOKRIT_DEGERI,
                HEMOGLOBIN_DEGERI = e.HEMOGLOBIN_DEGERI,
                TOPUK_KANI = e.TOPUK_KANI,
                TOPUK_KANI_ALINMA_ZAMANI = e.TOPUK_KANI_ALINMA_ZAMANI,
                IZLEMIN_YAPILDIGI_YER = e.IZLEMIN_YAPILDIGI_YER,
                IZLEMI_YAPAN_PERSONEL_KODU = e.IZLEMI_YAPAN_PERSONEL_KODU,
                BILGI_ALINAN_KISI_AD_SOYADI = e.BILGI_ALINAN_KISI_AD_SOYADI,
                BILGI_ALINAN_KISI_TELEFON = e.BILGI_ALINAN_KISI_TELEFON,
                BEBEKTE_RISK_FAKTORLERI = e.BEBEKTE_RISK_FAKTORLERI,
                TARAMA_SONUCU = e.TARAMA_SONUCU,
                ANNE_SUTUNDEN_KESILDIGI_AY = e.ANNE_SUTUNDEN_KESILDIGI_AY,
                BEBEGIN_BESLENME_DURUMU = e.BEBEGIN_BESLENME_DURUMU,
                EK_GIDAYA_BASLADIGI_AY = e.EK_GIDAYA_BASLADIGI_AY,
                SADECE_ANNE_SUTU_ALDIGI_SURE = e.SADECE_ANNE_SUTU_ALDIGI_SURE,
                GELISIM_TABLOSU_BILGILERI = e.GELISIM_TABLOSU_BILGILERI,
                NTP_TAKIP_BILGISI = e.NTP_TAKIP_BILGISI,
                BC_BEYIN_GELISIM_RISKLERI = e.BC_BEYIN_GELISIM_RISKLERI,
                EBEVEYN_DESTEK_AKTIVITELERI = e.EBEVEYN_DESTEK_AKTIVITELERI,
                BC_PSIKOLOJIK_RISK_EGITIM = e.BC_PSIKOLOJIK_RISK_EGITIM,
                BC_RISK_YAPILAN_MUDAHALE = e.BC_RISK_YAPILAN_MUDAHALE,
                BC_RISKLI_OLGU_TAKIBI = e.BC_RISKLI_OLGU_TAKIBI,
                ACIKLAMA = e.ACIKLAMA,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.BebekCocukIzlem)]
    public async Task<ActionResult<BebekCocukIzlemDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<BEBEK_COCUK_IZLEM>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.BEBEK_COCUK_IZLEM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new BebekCocukIzlemDto
        {
            BEBEK_COCUK_IZLEM_KODU = entity.BEBEK_COCUK_IZLEM_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            HASTA_KODU = entity.HASTA_KODU,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            KACINCI_IZLEM = entity.KACINCI_IZLEM,
            AGIZDAN_SIVI_TEDAVISI = entity.AGIZDAN_SIVI_TEDAVISI,
            BAS_CEVRESI = entity.BAS_CEVRESI,
            DEMIR_LOJISTIGI_VE_DESTEGI = entity.DEMIR_LOJISTIGI_VE_DESTEGI,
            DOGUM_AGIRLIGI = entity.DOGUM_AGIRLIGI,
            DVITAMINI_LOJISTIGI_VE_DESTEGI = entity.DVITAMINI_LOJISTIGI_VE_DESTEGI,
            GKD_TARAMA_SONUCU = entity.GKD_TARAMA_SONUCU,
            HEMATOKRIT_DEGERI = entity.HEMATOKRIT_DEGERI,
            HEMOGLOBIN_DEGERI = entity.HEMOGLOBIN_DEGERI,
            TOPUK_KANI = entity.TOPUK_KANI,
            TOPUK_KANI_ALINMA_ZAMANI = entity.TOPUK_KANI_ALINMA_ZAMANI,
            IZLEMIN_YAPILDIGI_YER = entity.IZLEMIN_YAPILDIGI_YER,
            IZLEMI_YAPAN_PERSONEL_KODU = entity.IZLEMI_YAPAN_PERSONEL_KODU,
            BILGI_ALINAN_KISI_AD_SOYADI = entity.BILGI_ALINAN_KISI_AD_SOYADI,
            BILGI_ALINAN_KISI_TELEFON = entity.BILGI_ALINAN_KISI_TELEFON,
            BEBEKTE_RISK_FAKTORLERI = entity.BEBEKTE_RISK_FAKTORLERI,
            TARAMA_SONUCU = entity.TARAMA_SONUCU,
            ANNE_SUTUNDEN_KESILDIGI_AY = entity.ANNE_SUTUNDEN_KESILDIGI_AY,
            BEBEGIN_BESLENME_DURUMU = entity.BEBEGIN_BESLENME_DURUMU,
            EK_GIDAYA_BASLADIGI_AY = entity.EK_GIDAYA_BASLADIGI_AY,
            SADECE_ANNE_SUTU_ALDIGI_SURE = entity.SADECE_ANNE_SUTU_ALDIGI_SURE,
            GELISIM_TABLOSU_BILGILERI = entity.GELISIM_TABLOSU_BILGILERI,
            NTP_TAKIP_BILGISI = entity.NTP_TAKIP_BILGISI,
            BC_BEYIN_GELISIM_RISKLERI = entity.BC_BEYIN_GELISIM_RISKLERI,
            EBEVEYN_DESTEK_AKTIVITELERI = entity.EBEVEYN_DESTEK_AKTIVITELERI,
            BC_PSIKOLOJIK_RISK_EGITIM = entity.BC_PSIKOLOJIK_RISK_EGITIM,
            BC_RISK_YAPILAN_MUDAHALE = entity.BC_RISK_YAPILAN_MUDAHALE,
            BC_RISKLI_OLGU_TAKIBI = entity.BC_RISKLI_OLGU_TAKIBI,
            ACIKLAMA = entity.ACIKLAMA,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.BebekCocukIzlem)]
    public async Task<ActionResult<string>> Create(BebekCocukIzlemDto dto, CancellationToken ct)
    {
        var entity = new BEBEK_COCUK_IZLEM
        {
            BEBEK_COCUK_IZLEM_KODU = dto.BEBEK_COCUK_IZLEM_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            HASTA_KODU = dto.HASTA_KODU,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            KACINCI_IZLEM = dto.KACINCI_IZLEM,
            AGIZDAN_SIVI_TEDAVISI = dto.AGIZDAN_SIVI_TEDAVISI,
            BAS_CEVRESI = dto.BAS_CEVRESI,
            DEMIR_LOJISTIGI_VE_DESTEGI = dto.DEMIR_LOJISTIGI_VE_DESTEGI,
            DOGUM_AGIRLIGI = dto.DOGUM_AGIRLIGI,
            DVITAMINI_LOJISTIGI_VE_DESTEGI = dto.DVITAMINI_LOJISTIGI_VE_DESTEGI,
            GKD_TARAMA_SONUCU = dto.GKD_TARAMA_SONUCU,
            HEMATOKRIT_DEGERI = dto.HEMATOKRIT_DEGERI,
            HEMOGLOBIN_DEGERI = dto.HEMOGLOBIN_DEGERI,
            TOPUK_KANI = dto.TOPUK_KANI,
            TOPUK_KANI_ALINMA_ZAMANI = dto.TOPUK_KANI_ALINMA_ZAMANI,
            IZLEMIN_YAPILDIGI_YER = dto.IZLEMIN_YAPILDIGI_YER,
            IZLEMI_YAPAN_PERSONEL_KODU = dto.IZLEMI_YAPAN_PERSONEL_KODU,
            BILGI_ALINAN_KISI_AD_SOYADI = dto.BILGI_ALINAN_KISI_AD_SOYADI,
            BILGI_ALINAN_KISI_TELEFON = dto.BILGI_ALINAN_KISI_TELEFON,
            BEBEKTE_RISK_FAKTORLERI = dto.BEBEKTE_RISK_FAKTORLERI,
            TARAMA_SONUCU = dto.TARAMA_SONUCU,
            ANNE_SUTUNDEN_KESILDIGI_AY = dto.ANNE_SUTUNDEN_KESILDIGI_AY,
            BEBEGIN_BESLENME_DURUMU = dto.BEBEGIN_BESLENME_DURUMU,
            EK_GIDAYA_BASLADIGI_AY = dto.EK_GIDAYA_BASLADIGI_AY,
            SADECE_ANNE_SUTU_ALDIGI_SURE = dto.SADECE_ANNE_SUTU_ALDIGI_SURE,
            GELISIM_TABLOSU_BILGILERI = dto.GELISIM_TABLOSU_BILGILERI,
            NTP_TAKIP_BILGISI = dto.NTP_TAKIP_BILGISI,
            BC_BEYIN_GELISIM_RISKLERI = dto.BC_BEYIN_GELISIM_RISKLERI,
            EBEVEYN_DESTEK_AKTIVITELERI = dto.EBEVEYN_DESTEK_AKTIVITELERI,
            BC_PSIKOLOJIK_RISK_EGITIM = dto.BC_PSIKOLOJIK_RISK_EGITIM,
            BC_RISK_YAPILAN_MUDAHALE = dto.BC_RISK_YAPILAN_MUDAHALE,
            BC_RISKLI_OLGU_TAKIBI = dto.BC_RISKLI_OLGU_TAKIBI,
            ACIKLAMA = dto.ACIKLAMA,
        };

        _db.Set<BEBEK_COCUK_IZLEM>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.BEBEK_COCUK_IZLEM_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.BebekCocukIzlem)]
    public async Task<IActionResult> Update(string id, BebekCocukIzlemDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<BEBEK_COCUK_IZLEM>()
            .FirstOrDefaultAsync(e => e.BEBEK_COCUK_IZLEM_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.KACINCI_IZLEM = dto.KACINCI_IZLEM;
        entity.AGIZDAN_SIVI_TEDAVISI = dto.AGIZDAN_SIVI_TEDAVISI;
        entity.BAS_CEVRESI = dto.BAS_CEVRESI;
        entity.DEMIR_LOJISTIGI_VE_DESTEGI = dto.DEMIR_LOJISTIGI_VE_DESTEGI;
        entity.DOGUM_AGIRLIGI = dto.DOGUM_AGIRLIGI;
        entity.DVITAMINI_LOJISTIGI_VE_DESTEGI = dto.DVITAMINI_LOJISTIGI_VE_DESTEGI;
        entity.GKD_TARAMA_SONUCU = dto.GKD_TARAMA_SONUCU;
        entity.HEMATOKRIT_DEGERI = dto.HEMATOKRIT_DEGERI;
        entity.HEMOGLOBIN_DEGERI = dto.HEMOGLOBIN_DEGERI;
        entity.TOPUK_KANI = dto.TOPUK_KANI;
        entity.TOPUK_KANI_ALINMA_ZAMANI = dto.TOPUK_KANI_ALINMA_ZAMANI;
        entity.IZLEMIN_YAPILDIGI_YER = dto.IZLEMIN_YAPILDIGI_YER;
        entity.IZLEMI_YAPAN_PERSONEL_KODU = dto.IZLEMI_YAPAN_PERSONEL_KODU;
        entity.BILGI_ALINAN_KISI_AD_SOYADI = dto.BILGI_ALINAN_KISI_AD_SOYADI;
        entity.BILGI_ALINAN_KISI_TELEFON = dto.BILGI_ALINAN_KISI_TELEFON;
        entity.BEBEKTE_RISK_FAKTORLERI = dto.BEBEKTE_RISK_FAKTORLERI;
        entity.TARAMA_SONUCU = dto.TARAMA_SONUCU;
        entity.ANNE_SUTUNDEN_KESILDIGI_AY = dto.ANNE_SUTUNDEN_KESILDIGI_AY;
        entity.BEBEGIN_BESLENME_DURUMU = dto.BEBEGIN_BESLENME_DURUMU;
        entity.EK_GIDAYA_BASLADIGI_AY = dto.EK_GIDAYA_BASLADIGI_AY;
        entity.SADECE_ANNE_SUTU_ALDIGI_SURE = dto.SADECE_ANNE_SUTU_ALDIGI_SURE;
        entity.GELISIM_TABLOSU_BILGILERI = dto.GELISIM_TABLOSU_BILGILERI;
        entity.NTP_TAKIP_BILGISI = dto.NTP_TAKIP_BILGISI;
        entity.BC_BEYIN_GELISIM_RISKLERI = dto.BC_BEYIN_GELISIM_RISKLERI;
        entity.EBEVEYN_DESTEK_AKTIVITELERI = dto.EBEVEYN_DESTEK_AKTIVITELERI;
        entity.BC_PSIKOLOJIK_RISK_EGITIM = dto.BC_PSIKOLOJIK_RISK_EGITIM;
        entity.BC_RISK_YAPILAN_MUDAHALE = dto.BC_RISK_YAPILAN_MUDAHALE;
        entity.BC_RISKLI_OLGU_TAKIBI = dto.BC_RISKLI_OLGU_TAKIBI;
        entity.ACIKLAMA = dto.ACIKLAMA;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.BebekCocukIzlem)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<BEBEK_COCUK_IZLEM>()
            .FirstOrDefaultAsync(e => e.BEBEK_COCUK_IZLEM_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<BEBEK_COCUK_IZLEM>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
