using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Application.Vem.MedulaTakip;
using Server.Domain.Lbys;
using Server.Infrastructure.Auth.Permissions;
using Server.Infrastructure.Persistence.Context;
using Server.Shared.Authorization;

namespace Server.Host.Controllers.Vem;

[Route("api/vem/[controller]")]
public class MedulaTakipController : BaseApiController
{
    private readonly ApplicationDbContext _db;

    public MedulaTakipController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.MedulaTakip)]
    public async Task<List<MedulaTakipDto>> GetAll(CancellationToken ct)
    {
        return await _db.Set<MEDULA_TAKIP>()
            .AsNoTracking()
            .Select(e => new MedulaTakipDto
            {
                MEDULA_TAKIP_KODU = e.MEDULA_TAKIP_KODU,
                REFERANS_TABLO_ADI = e.REFERANS_TABLO_ADI,
                HASTA_BASVURU_KODU = e.HASTA_BASVURU_KODU,
                HASTA_KODU = e.HASTA_KODU,
                SGK_TAKIP_NUMARASI = e.SGK_TAKIP_NUMARASI,
                SGK_ILKTAKIP_NUMARASI = e.SGK_ILKTAKIP_NUMARASI,
                MEDULA_TESIS_KODU = e.MEDULA_TESIS_KODU,
                MEDULA_BRANS_KODU = e.MEDULA_BRANS_KODU,
                PROVIZYON_TURU = e.PROVIZYON_TURU,
                PROVIZYON_TARIHI = e.PROVIZYON_TARIHI,
                TC_KIMLIK_NUMARASI = e.TC_KIMLIK_NUMARASI,
                CINSIYET = e.CINSIYET,
                MEDULA_TUTARI = e.MEDULA_TUTARI,
                FATURA_TESLIM_NUMARASI = e.FATURA_TESLIM_NUMARASI,
                FATURA_TESLIM_TARIHI = e.FATURA_TESLIM_TARIHI,
                TEDAVI_TURU = e.TEDAVI_TURU,
                SIGORTALI_TURU = e.SIGORTALI_TURU,
                DEVREDILEN_KURUM = e.DEVREDILEN_KURUM,
                SONUC_KODU = e.SONUC_KODU,
                SONUC_MESAJI = e.SONUC_MESAJI,
                TAKIP_TIPI = e.TAKIP_TIPI,
                BASVURU_NUMARASI = e.BASVURU_NUMARASI,
                TEDAVI_TIPI = e.TEDAVI_TIPI,
                TEDAVI_SEKLI = e.TEDAVI_SEKLI,
            })
            .Take(1000)
            .ToListAsync(ct);
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.MedulaTakip)]
    public async Task<ActionResult<MedulaTakipDto>> GetById(string id, CancellationToken ct)
    {
        var entity = await _db.Set<MEDULA_TAKIP>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.MEDULA_TAKIP_KODU == id, ct);

        if (entity == null)
            return NotFound();

        return new MedulaTakipDto
        {
            MEDULA_TAKIP_KODU = entity.MEDULA_TAKIP_KODU,
            REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
            HASTA_BASVURU_KODU = entity.HASTA_BASVURU_KODU,
            HASTA_KODU = entity.HASTA_KODU,
            SGK_TAKIP_NUMARASI = entity.SGK_TAKIP_NUMARASI,
            SGK_ILKTAKIP_NUMARASI = entity.SGK_ILKTAKIP_NUMARASI,
            MEDULA_TESIS_KODU = entity.MEDULA_TESIS_KODU,
            MEDULA_BRANS_KODU = entity.MEDULA_BRANS_KODU,
            PROVIZYON_TURU = entity.PROVIZYON_TURU,
            PROVIZYON_TARIHI = entity.PROVIZYON_TARIHI,
            TC_KIMLIK_NUMARASI = entity.TC_KIMLIK_NUMARASI,
            CINSIYET = entity.CINSIYET,
            MEDULA_TUTARI = entity.MEDULA_TUTARI,
            FATURA_TESLIM_NUMARASI = entity.FATURA_TESLIM_NUMARASI,
            FATURA_TESLIM_TARIHI = entity.FATURA_TESLIM_TARIHI,
            TEDAVI_TURU = entity.TEDAVI_TURU,
            SIGORTALI_TURU = entity.SIGORTALI_TURU,
            DEVREDILEN_KURUM = entity.DEVREDILEN_KURUM,
            SONUC_KODU = entity.SONUC_KODU,
            SONUC_MESAJI = entity.SONUC_MESAJI,
            TAKIP_TIPI = entity.TAKIP_TIPI,
            BASVURU_NUMARASI = entity.BASVURU_NUMARASI,
            TEDAVI_TIPI = entity.TEDAVI_TIPI,
            TEDAVI_SEKLI = entity.TEDAVI_SEKLI,
        };
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.MedulaTakip)]
    public async Task<ActionResult<string>> Create(MedulaTakipDto dto, CancellationToken ct)
    {
        var entity = new MEDULA_TAKIP
        {
            MEDULA_TAKIP_KODU = dto.MEDULA_TAKIP_KODU,
            REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI,
            HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU,
            HASTA_KODU = dto.HASTA_KODU,
            SGK_TAKIP_NUMARASI = dto.SGK_TAKIP_NUMARASI,
            SGK_ILKTAKIP_NUMARASI = dto.SGK_ILKTAKIP_NUMARASI,
            MEDULA_TESIS_KODU = dto.MEDULA_TESIS_KODU,
            MEDULA_BRANS_KODU = dto.MEDULA_BRANS_KODU,
            PROVIZYON_TURU = dto.PROVIZYON_TURU,
            PROVIZYON_TARIHI = dto.PROVIZYON_TARIHI,
            TC_KIMLIK_NUMARASI = dto.TC_KIMLIK_NUMARASI,
            CINSIYET = dto.CINSIYET,
            MEDULA_TUTARI = dto.MEDULA_TUTARI,
            FATURA_TESLIM_NUMARASI = dto.FATURA_TESLIM_NUMARASI,
            FATURA_TESLIM_TARIHI = dto.FATURA_TESLIM_TARIHI,
            TEDAVI_TURU = dto.TEDAVI_TURU,
            SIGORTALI_TURU = dto.SIGORTALI_TURU,
            DEVREDILEN_KURUM = dto.DEVREDILEN_KURUM,
            SONUC_KODU = dto.SONUC_KODU,
            SONUC_MESAJI = dto.SONUC_MESAJI,
            TAKIP_TIPI = dto.TAKIP_TIPI,
            BASVURU_NUMARASI = dto.BASVURU_NUMARASI,
            TEDAVI_TIPI = dto.TEDAVI_TIPI,
            TEDAVI_SEKLI = dto.TEDAVI_SEKLI,
        };

        _db.Set<MEDULA_TAKIP>().Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.MEDULA_TAKIP_KODU;
    }

    [HttpPut("{id}")]
    [MustHavePermission(FSHAction.Update, FSHResource.MedulaTakip)]
    public async Task<IActionResult> Update(string id, MedulaTakipDto dto, CancellationToken ct)
    {
        var entity = await _db.Set<MEDULA_TAKIP>()
            .FirstOrDefaultAsync(e => e.MEDULA_TAKIP_KODU == id, ct);

        if (entity == null)
            return NotFound();
        entity.REFERANS_TABLO_ADI = dto.REFERANS_TABLO_ADI;
        entity.HASTA_BASVURU_KODU = dto.HASTA_BASVURU_KODU;
        entity.HASTA_KODU = dto.HASTA_KODU;
        entity.SGK_TAKIP_NUMARASI = dto.SGK_TAKIP_NUMARASI;
        entity.SGK_ILKTAKIP_NUMARASI = dto.SGK_ILKTAKIP_NUMARASI;
        entity.MEDULA_TESIS_KODU = dto.MEDULA_TESIS_KODU;
        entity.MEDULA_BRANS_KODU = dto.MEDULA_BRANS_KODU;
        entity.PROVIZYON_TURU = dto.PROVIZYON_TURU;
        entity.PROVIZYON_TARIHI = dto.PROVIZYON_TARIHI;
        entity.TC_KIMLIK_NUMARASI = dto.TC_KIMLIK_NUMARASI;
        entity.CINSIYET = dto.CINSIYET;
        entity.MEDULA_TUTARI = dto.MEDULA_TUTARI;
        entity.FATURA_TESLIM_NUMARASI = dto.FATURA_TESLIM_NUMARASI;
        entity.FATURA_TESLIM_TARIHI = dto.FATURA_TESLIM_TARIHI;
        entity.TEDAVI_TURU = dto.TEDAVI_TURU;
        entity.SIGORTALI_TURU = dto.SIGORTALI_TURU;
        entity.DEVREDILEN_KURUM = dto.DEVREDILEN_KURUM;
        entity.SONUC_KODU = dto.SONUC_KODU;
        entity.SONUC_MESAJI = dto.SONUC_MESAJI;
        entity.TAKIP_TIPI = dto.TAKIP_TIPI;
        entity.BASVURU_NUMARASI = dto.BASVURU_NUMARASI;
        entity.TEDAVI_TIPI = dto.TEDAVI_TIPI;
        entity.TEDAVI_SEKLI = dto.TEDAVI_SEKLI;

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.MedulaTakip)]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        var entity = await _db.Set<MEDULA_TAKIP>()
            .FirstOrDefaultAsync(e => e.MEDULA_TAKIP_KODU == id, ct);

        if (entity == null)
            return NotFound();

        _db.Set<MEDULA_TAKIP>().Remove(entity);
        await _db.SaveChangesAsync(ct);

        return NoContent();
    }
}
