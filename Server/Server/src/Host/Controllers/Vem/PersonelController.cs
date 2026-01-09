using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.Personel;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class PersonelController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public PersonelController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Personel)]
    public async Task<List<PersonelDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<PERSONEL>()
            .AsNoTracking()
            .Select(e => new PersonelDto
            {
                PERSONEL_KODU = e.PERSONEL_KODU,
                AD = e.AD,
                CINSIYET = e.CINSIYET,
                DOGUM_TARIHI = e.DOGUM_TARIHI,
                ACIK_ADRES = e.ACIK_ADRES,
                ADRES_KODU_SEVIYESI = e.ADRES_KODU_SEVIYESI,
                ADRES_TIPI = e.ADRES_TIPI,
                AKADEMIK_UNVAN = e.AKADEMIK_UNVAN,
                AKTIFLIK_BILGISI = e.AKTIFLIK_BILGISI,
                ANNE_ADI = e.ANNE_ADI,
                ASALET_ALMA_TARIHI = e.ASALET_ALMA_TARIHI,
                ASKERLIK_DURUMU = e.ASKERLIK_DURUMU,
                BABA_ADI = e.BABA_ADI,
                CALISMA_DURUMU = e.CALISMA_DURUMU,
                CALISTIGI_BIRIM_KODU = e.CALISTIGI_BIRIM_KODU,
                CEP_TELEFONU = e.CEP_TELEFONU,
                DEVLET_HIZMET_YUKUMLULUK_KODU = e.DEVLET_HIZMET_YUKUMLULUK_KODU,
                DIPLOMA_NUMARASI = e.DIPLOMA_NUMARASI,
                DOGUM_YERI = e.DOGUM_YERI,
                EMEKLI_SICIL_NUMARASI = e.EMEKLI_SICIL_NUMARASI,
                EMEKLI_TERFI_TARIHI = e.EMEKLI_TERFI_TARIHI,
                ENGELLILIK_DURUMU = e.ENGELLILIK_DURUMU,
                EPOSTA_ADRESI = e.EPOSTA_ADRESI,
                EV_TELEFONU = e.EV_TELEFONU,
                FOTOGRAF_BILGISI = e.FOTOGRAF_BILGISI,
                FOTOGRAF_DOSYA_YOLU = e.FOTOGRAF_DOSYA_YOLU,
                HEKIM_MEDULA_SIFRESI = e.HEKIM_MEDULA_SIFRESI,
                IL_KODU = e.IL_KODU,
                ILCE_KODU = e.ILCE_KODU,
                ILK_ISE_BASLAMA_TARIHI = e.ILK_ISE_BASLAMA_TARIHI,
                IMZA_UNVAN_KODU = e.IMZA_UNVAN_KODU,
                IS_DURUMU = e.IS_DURUMU,
                ISTEN_AYRILMA_ACIKLAMASI = e.ISTEN_AYRILMA_ACIKLAMASI,
                ISTEN_AYRILMA_NEDENI = e.ISTEN_AYRILMA_NEDENI,
                ISTEN_AYRILMA_TARIHI = e.ISTEN_AYRILMA_TARIHI,
                KADRO_UNVAN_KODU = e.KADRO_UNVAN_KODU,
                KADROLU_GOREV_YERI = e.KADROLU_GOREV_YERI,
                KAN_GRUBU = e.KAN_GRUBU,
                KLINIK_KODU = e.KLINIK_KODU,
                MEDULA_BRANS_KODU = e.MEDULA_BRANS_KODU,
                MEMURIYET_TIPI = e.MEMURIYET_TIPI,
                MEMURIYETE_BASLAMA_TARIHI = e.MEMURIYETE_BASLAMA_TARIHI,
                OGRENIM_DURUMU = e.OGRENIM_DURUMU,
                ONCEKI_SOYADI = e.ONCEKI_SOYADI,
                PERSONEL_GOREV_KODU = e.PERSONEL_GOREV_KODU,
                PERSONEL_SICIL_NUMARASI = e.PERSONEL_SICIL_NUMARASI,
                SAGLIK_TESISINE_BASLAMA_TARIHI = e.SAGLIK_TESISINE_BASLAMA_TARIHI,
                SOYADI = e.SOYADI,
                TC_KIMLIK_NUMARASI = e.TC_KIMLIK_NUMARASI,
                TERFI_TARIHI = e.TERFI_TARIHI,
                TESCIL_NUMARASI = e.TESCIL_NUMARASI,
                ULKE_KODU = e.ULKE_KODU,
                UNVAN_KODU = e.UNVAN_KODU,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Personel)]
    public async Task<ActionResult<PersonelDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.PERSONEL_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new PersonelDto
        {
            PERSONEL_KODU = entity.PERSONEL_KODU,
            AD = entity.AD,
            CINSIYET = entity.CINSIYET,
            DOGUM_TARIHI = entity.DOGUM_TARIHI,
            ACIK_ADRES = entity.ACIK_ADRES,
            ADRES_KODU_SEVIYESI = entity.ADRES_KODU_SEVIYESI,
            ADRES_TIPI = entity.ADRES_TIPI,
            AKADEMIK_UNVAN = entity.AKADEMIK_UNVAN,
            AKTIFLIK_BILGISI = entity.AKTIFLIK_BILGISI,
            ANNE_ADI = entity.ANNE_ADI,
            ASALET_ALMA_TARIHI = entity.ASALET_ALMA_TARIHI,
            ASKERLIK_DURUMU = entity.ASKERLIK_DURUMU,
            BABA_ADI = entity.BABA_ADI,
            CALISMA_DURUMU = entity.CALISMA_DURUMU,
            CALISTIGI_BIRIM_KODU = entity.CALISTIGI_BIRIM_KODU,
            CEP_TELEFONU = entity.CEP_TELEFONU,
            DEVLET_HIZMET_YUKUMLULUK_KODU = entity.DEVLET_HIZMET_YUKUMLULUK_KODU,
            DIPLOMA_NUMARASI = entity.DIPLOMA_NUMARASI,
            DOGUM_YERI = entity.DOGUM_YERI,
            EMEKLI_SICIL_NUMARASI = entity.EMEKLI_SICIL_NUMARASI,
            EMEKLI_TERFI_TARIHI = entity.EMEKLI_TERFI_TARIHI,
            ENGELLILIK_DURUMU = entity.ENGELLILIK_DURUMU,
            EPOSTA_ADRESI = entity.EPOSTA_ADRESI,
            EV_TELEFONU = entity.EV_TELEFONU,
            FOTOGRAF_BILGISI = entity.FOTOGRAF_BILGISI,
            FOTOGRAF_DOSYA_YOLU = entity.FOTOGRAF_DOSYA_YOLU,
            HEKIM_MEDULA_SIFRESI = entity.HEKIM_MEDULA_SIFRESI,
            IL_KODU = entity.IL_KODU,
            ILCE_KODU = entity.ILCE_KODU,
            ILK_ISE_BASLAMA_TARIHI = entity.ILK_ISE_BASLAMA_TARIHI,
            IMZA_UNVAN_KODU = entity.IMZA_UNVAN_KODU,
            IS_DURUMU = entity.IS_DURUMU,
            ISTEN_AYRILMA_ACIKLAMASI = entity.ISTEN_AYRILMA_ACIKLAMASI,
            ISTEN_AYRILMA_NEDENI = entity.ISTEN_AYRILMA_NEDENI,
            ISTEN_AYRILMA_TARIHI = entity.ISTEN_AYRILMA_TARIHI,
            KADRO_UNVAN_KODU = entity.KADRO_UNVAN_KODU,
            KADROLU_GOREV_YERI = entity.KADROLU_GOREV_YERI,
            KAN_GRUBU = entity.KAN_GRUBU,
            KLINIK_KODU = entity.KLINIK_KODU,
            MEDULA_BRANS_KODU = entity.MEDULA_BRANS_KODU,
            MEMURIYET_TIPI = entity.MEMURIYET_TIPI,
            MEMURIYETE_BASLAMA_TARIHI = entity.MEMURIYETE_BASLAMA_TARIHI,
            OGRENIM_DURUMU = entity.OGRENIM_DURUMU,
            ONCEKI_SOYADI = entity.ONCEKI_SOYADI,
            PERSONEL_GOREV_KODU = entity.PERSONEL_GOREV_KODU,
            PERSONEL_SICIL_NUMARASI = entity.PERSONEL_SICIL_NUMARASI,
            SAGLIK_TESISINE_BASLAMA_TARIHI = entity.SAGLIK_TESISINE_BASLAMA_TARIHI,
            SOYADI = entity.SOYADI,
            TC_KIMLIK_NUMARASI = entity.TC_KIMLIK_NUMARASI,
            TERFI_TARIHI = entity.TERFI_TARIHI,
            TESCIL_NUMARASI = entity.TESCIL_NUMARASI,
            ULKE_KODU = entity.ULKE_KODU,
            UNVAN_KODU = entity.UNVAN_KODU,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Personel)]
    public async Task<ActionResult<string>> Create(PersonelDto dto, CancellationToken ct)
    {
        var entity = new PERSONEL
        {
            PERSONEL_KODU = dto.PERSONEL_KODU,
            AD = dto.AD,
            CINSIYET = dto.CINSIYET,
            DOGUM_TARIHI = dto.DOGUM_TARIHI,
            ACIK_ADRES = dto.ACIK_ADRES,
            ADRES_KODU_SEVIYESI = dto.ADRES_KODU_SEVIYESI,
            ADRES_TIPI = dto.ADRES_TIPI,
            AKADEMIK_UNVAN = dto.AKADEMIK_UNVAN,
            AKTIFLIK_BILGISI = dto.AKTIFLIK_BILGISI,
            ANNE_ADI = dto.ANNE_ADI,
            ASALET_ALMA_TARIHI = dto.ASALET_ALMA_TARIHI,
            ASKERLIK_DURUMU = dto.ASKERLIK_DURUMU,
            BABA_ADI = dto.BABA_ADI,
            CALISMA_DURUMU = dto.CALISMA_DURUMU,
            CALISTIGI_BIRIM_KODU = dto.CALISTIGI_BIRIM_KODU,
            CEP_TELEFONU = dto.CEP_TELEFONU,
            DEVLET_HIZMET_YUKUMLULUK_KODU = dto.DEVLET_HIZMET_YUKUMLULUK_KODU,
            DIPLOMA_NUMARASI = dto.DIPLOMA_NUMARASI,
            DOGUM_YERI = dto.DOGUM_YERI,
            EMEKLI_SICIL_NUMARASI = dto.EMEKLI_SICIL_NUMARASI,
            EMEKLI_TERFI_TARIHI = dto.EMEKLI_TERFI_TARIHI,
            ENGELLILIK_DURUMU = dto.ENGELLILIK_DURUMU,
            EPOSTA_ADRESI = dto.EPOSTA_ADRESI,
            EV_TELEFONU = dto.EV_TELEFONU,
            FOTOGRAF_BILGISI = dto.FOTOGRAF_BILGISI,
            FOTOGRAF_DOSYA_YOLU = dto.FOTOGRAF_DOSYA_YOLU,
            HEKIM_MEDULA_SIFRESI = dto.HEKIM_MEDULA_SIFRESI,
            IL_KODU = dto.IL_KODU,
            ILCE_KODU = dto.ILCE_KODU,
            ILK_ISE_BASLAMA_TARIHI = dto.ILK_ISE_BASLAMA_TARIHI,
            IMZA_UNVAN_KODU = dto.IMZA_UNVAN_KODU,
            IS_DURUMU = dto.IS_DURUMU,
            ISTEN_AYRILMA_ACIKLAMASI = dto.ISTEN_AYRILMA_ACIKLAMASI,
            ISTEN_AYRILMA_NEDENI = dto.ISTEN_AYRILMA_NEDENI,
            ISTEN_AYRILMA_TARIHI = dto.ISTEN_AYRILMA_TARIHI,
            KADRO_UNVAN_KODU = dto.KADRO_UNVAN_KODU,
            KADROLU_GOREV_YERI = dto.KADROLU_GOREV_YERI,
            KAN_GRUBU = dto.KAN_GRUBU,
            KLINIK_KODU = dto.KLINIK_KODU,
            MEDULA_BRANS_KODU = dto.MEDULA_BRANS_KODU,
            MEMURIYET_TIPI = dto.MEMURIYET_TIPI,
            MEMURIYETE_BASLAMA_TARIHI = dto.MEMURIYETE_BASLAMA_TARIHI,
            OGRENIM_DURUMU = dto.OGRENIM_DURUMU,
            ONCEKI_SOYADI = dto.ONCEKI_SOYADI,
            PERSONEL_GOREV_KODU = dto.PERSONEL_GOREV_KODU,
            PERSONEL_SICIL_NUMARASI = dto.PERSONEL_SICIL_NUMARASI,
            SAGLIK_TESISINE_BASLAMA_TARIHI = dto.SAGLIK_TESISINE_BASLAMA_TARIHI,
            SOYADI = dto.SOYADI,
            TC_KIMLIK_NUMARASI = dto.TC_KIMLIK_NUMARASI,
            TERFI_TARIHI = dto.TERFI_TARIHI,
            TESCIL_NUMARASI = dto.TESCIL_NUMARASI,
            ULKE_KODU = dto.ULKE_KODU,
            UNVAN_KODU = dto.UNVAN_KODU,
        };

        _db.Set<PERSONEL>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.PERSONEL_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Personel)]
    public async Task<IActionResult> Update(string id, PersonelDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL>()
            .FirstOrDefaultAsync(e => e.PERSONEL_KODU == id, ct);

        if (entity == null)
            return NotFound();

        entity.AD = dto.AD;
        entity.CINSIYET = dto.CINSIYET;
        entity.DOGUM_TARIHI = dto.DOGUM_TARIHI;
        entity.ACIK_ADRES = dto.ACIK_ADRES;
        entity.ADRES_KODU_SEVIYESI = dto.ADRES_KODU_SEVIYESI;
        entity.ADRES_TIPI = dto.ADRES_TIPI;
        entity.AKADEMIK_UNVAN = dto.AKADEMIK_UNVAN;
        entity.AKTIFLIK_BILGISI = dto.AKTIFLIK_BILGISI;
        entity.ANNE_ADI = dto.ANNE_ADI;
        entity.ASALET_ALMA_TARIHI = dto.ASALET_ALMA_TARIHI;
        entity.ASKERLIK_DURUMU = dto.ASKERLIK_DURUMU;
        entity.BABA_ADI = dto.BABA_ADI;
        entity.CALISMA_DURUMU = dto.CALISMA_DURUMU;
        entity.CALISTIGI_BIRIM_KODU = dto.CALISTIGI_BIRIM_KODU;
        entity.CEP_TELEFONU = dto.CEP_TELEFONU;
        entity.DEVLET_HIZMET_YUKUMLULUK_KODU = dto.DEVLET_HIZMET_YUKUMLULUK_KODU;
        entity.DIPLOMA_NUMARASI = dto.DIPLOMA_NUMARASI;
        entity.DOGUM_YERI = dto.DOGUM_YERI;
        entity.EMEKLI_SICIL_NUMARASI = dto.EMEKLI_SICIL_NUMARASI;
        entity.EMEKLI_TERFI_TARIHI = dto.EMEKLI_TERFI_TARIHI;
        entity.ENGELLILIK_DURUMU = dto.ENGELLILIK_DURUMU;
        entity.EPOSTA_ADRESI = dto.EPOSTA_ADRESI;
        entity.EV_TELEFONU = dto.EV_TELEFONU;
        entity.FOTOGRAF_BILGISI = dto.FOTOGRAF_BILGISI;
        entity.FOTOGRAF_DOSYA_YOLU = dto.FOTOGRAF_DOSYA_YOLU;
        entity.HEKIM_MEDULA_SIFRESI = dto.HEKIM_MEDULA_SIFRESI;
        entity.IL_KODU = dto.IL_KODU;
        entity.ILCE_KODU = dto.ILCE_KODU;
        entity.ILK_ISE_BASLAMA_TARIHI = dto.ILK_ISE_BASLAMA_TARIHI;
        entity.IMZA_UNVAN_KODU = dto.IMZA_UNVAN_KODU;
        entity.IS_DURUMU = dto.IS_DURUMU;
        entity.ISTEN_AYRILMA_ACIKLAMASI = dto.ISTEN_AYRILMA_ACIKLAMASI;
        entity.ISTEN_AYRILMA_NEDENI = dto.ISTEN_AYRILMA_NEDENI;
        entity.ISTEN_AYRILMA_TARIHI = dto.ISTEN_AYRILMA_TARIHI;
        entity.KADRO_UNVAN_KODU = dto.KADRO_UNVAN_KODU;
        entity.KADROLU_GOREV_YERI = dto.KADROLU_GOREV_YERI;
        entity.KAN_GRUBU = dto.KAN_GRUBU;
        entity.KLINIK_KODU = dto.KLINIK_KODU;
        entity.MEDULA_BRANS_KODU = dto.MEDULA_BRANS_KODU;
        entity.MEMURIYET_TIPI = dto.MEMURIYET_TIPI;
        entity.MEMURIYETE_BASLAMA_TARIHI = dto.MEMURIYETE_BASLAMA_TARIHI;
        entity.OGRENIM_DURUMU = dto.OGRENIM_DURUMU;
        entity.ONCEKI_SOYADI = dto.ONCEKI_SOYADI;
        entity.PERSONEL_GOREV_KODU = dto.PERSONEL_GOREV_KODU;
        entity.PERSONEL_SICIL_NUMARASI = dto.PERSONEL_SICIL_NUMARASI;
        entity.SAGLIK_TESISINE_BASLAMA_TARIHI = dto.SAGLIK_TESISINE_BASLAMA_TARIHI;
        entity.SOYADI = dto.SOYADI;
        entity.TC_KIMLIK_NUMARASI = dto.TC_KIMLIK_NUMARASI;
        entity.TERFI_TARIHI = dto.TERFI_TARIHI;
        entity.TESCIL_NUMARASI = dto.TESCIL_NUMARASI;
        entity.ULKE_KODU = dto.ULKE_KODU;
        entity.UNVAN_KODU = dto.UNVAN_KODU;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Personel)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<PERSONEL>()
            .FirstOrDefaultAsync(e => e.PERSONEL_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<PERSONEL>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
