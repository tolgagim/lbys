using System.Collections.ObjectModel;

namespace Server.Shared.Authorization;

public static class FSHAction
{
    public const string View = nameof(View);
    public const string Search = nameof(Search);
    public const string Create = nameof(Create);
    public const string Update = nameof(Update);
    public const string Delete = nameof(Delete);
    public const string Export = nameof(Export);
    public const string Generate = nameof(Generate);
    public const string Clean = nameof(Clean);
}

public static class FSHResource
{
    // System Resources
    public const string Dashboard = nameof(Dashboard);
    public const string Hangfire = nameof(Hangfire);
    public const string Users = nameof(Users);
    public const string OtherUsers = nameof(OtherUsers);
    public const string UserRoles = nameof(UserRoles);
    public const string Roles = nameof(Roles);
    public const string RoleClaims = nameof(RoleClaims);

    // VEM 2.0 Resources - 141 entities
    public const string Ameliyat = nameof(Ameliyat);
    public const string AmeliyatEkip = nameof(AmeliyatEkip);
    public const string AmeliyatIslem = nameof(AmeliyatIslem);
    public const string AnlikYatanHasta = nameof(AnlikYatanHasta);
    public const string AntibiyotikSonuc = nameof(AntibiyotikSonuc);
    public const string AsiBilgisi = nameof(AsiBilgisi);
    public const string BakteriSonuc = nameof(BakteriSonuc);
    public const string BasvuruTani = nameof(BasvuruTani);
    public const string BasvuruYemek = nameof(BasvuruYemek);
    public const string BebekCocukIzlem = nameof(BebekCocukIzlem);
    public const string BildirimiZorunlu = nameof(BildirimiZorunlu);
    public const string Bina = nameof(Bina);
    public const string Birim = nameof(Birim);
    public const string Cihaz = nameof(Cihaz);
    public const string CocukDiyabet = nameof(CocukDiyabet);
    public const string Depo = nameof(Depo);
    public const string DisTaahhut = nameof(DisTaahhut);
    public const string DisTaahhutDetay = nameof(DisTaahhutDetay);
    public const string Disprotez = nameof(Disprotez);
    public const string DisprotezDetay = nameof(DisprotezDetay);
    public const string Diyabet = nameof(Diyabet);
    public const string Dogum = nameof(Dogum);
    public const string DogumDetay = nameof(DogumDetay);
    public const string DoktorMesaji = nameof(DoktorMesaji);
    public const string EkOdeme = nameof(EkOdeme);
    public const string EkOdemeDetay = nameof(EkOdemeDetay);
    public const string EkOdemeDonem = nameof(EkOdemeDonem);
    public const string EvdeSaglikIzlem = nameof(EvdeSaglikIzlem);
    public const string Fatura = nameof(Fatura);
    public const string Firma = nameof(Firma);
    public const string GebeIzlem = nameof(GebeIzlem);
    public const string Getat = nameof(Getat);
    public const string GrupUyelik = nameof(GrupUyelik);
    public const string Hasta = nameof(Hasta);
    public const string HastaAdliRapor = nameof(HastaAdliRapor);
    public const string HastaArsiv = nameof(HastaArsiv);
    public const string HastaArsivDetay = nameof(HastaArsivDetay);
    public const string HastaBasvuru = nameof(HastaBasvuru);
    public const string HastaBorc = nameof(HastaBorc);
    public const string HastaDis = nameof(HastaDis);
    public const string HastaEpikriz = nameof(HastaEpikriz);
    public const string HastaFotograf = nameof(HastaFotograf);
    public const string HastaGizlilik = nameof(HastaGizlilik);
    public const string HastaHizmet = nameof(HastaHizmet);
    public const string HastaIletisim = nameof(HastaIletisim);
    public const string HastaMalzeme = nameof(HastaMalzeme);
    public const string HastaNotlari = nameof(HastaNotlari);
    public const string HastaOlum = nameof(HastaOlum);
    public const string HastaSeans = nameof(HastaSeans);
    public const string HastaSevk = nameof(HastaSevk);
    public const string HastaTibbiBilgi = nameof(HastaTibbiBilgi);
    public const string HastaUyari = nameof(HastaUyari);
    public const string HastaVentilator = nameof(HastaVentilator);
    public const string HastaVitalFizikiBulgu = nameof(HastaVitalFizikiBulgu);
    public const string HastaYatak = nameof(HastaYatak);
    public const string Hemoglobinopati = nameof(Hemoglobinopati);
    public const string HemsireBakim = nameof(HemsireBakim);
    public const string Hizmet = nameof(Hizmet);
    public const string Icmal = nameof(Icmal);
    public const string IlacUyum = nameof(IlacUyum);
    public const string IntiharIzlem = nameof(IntiharIzlem);
    public const string KadinIzlem = nameof(KadinIzlem);
    public const string KanBagisci = nameof(KanBagisci);
    public const string KanCikis = nameof(KanCikis);
    public const string KanStok = nameof(KanStok);
    public const string KanTalep = nameof(KanTalep);
    public const string KanTalepDetay = nameof(KanTalepDetay);
    public const string KanUrun = nameof(KanUrun);
    public const string KanUrunImha = nameof(KanUrunImha);
    public const string KlinikSeyir = nameof(KlinikSeyir);
    public const string Konsultasyon = nameof(Konsultasyon);
    public const string KuduzIzlem = nameof(KuduzIzlem);
    public const string Kullanici = nameof(Kullanici);
    public const string KullaniciGrup = nameof(KullaniciGrup);
    public const string Kurul = nameof(Kurul);
    public const string KurulAskeri = nameof(KurulAskeri);
    public const string KurulEngelli = nameof(KurulEngelli);
    public const string KurulEtkenMadde = nameof(KurulEtkenMadde);
    public const string KurulHekim = nameof(KurulHekim);
    public const string KurulRapor = nameof(KurulRapor);
    public const string KurulTeshis = nameof(KurulTeshis);
    public const string Kurum = nameof(Kurum);
    public const string LohusaIzlem = nameof(LohusaIzlem);
    public const string MaddeBagimliligi = nameof(MaddeBagimliligi);
    public const string MedulaTakip = nameof(MedulaTakip);
    public const string NobetciPersonelBilgisi = nameof(NobetciPersonelBilgisi);
    public const string ObeziteIzlem = nameof(ObeziteIzlem);
    public const string Oda = nameof(Oda);
    public const string OptikRecete = nameof(OptikRecete);
    public const string OrtodontiIconSkor = nameof(OrtodontiIconSkor);
    public const string Patoloji = nameof(Patoloji);
    public const string Personel = nameof(Personel);
    public const string PersonelBakmaklaYukumlu = nameof(PersonelBakmaklaYukumlu);
    public const string PersonelBanka = nameof(PersonelBanka);
    public const string PersonelBordro = nameof(PersonelBordro);
    public const string PersonelBordroSondurum = nameof(PersonelBordroSondurum);
    public const string PersonelEgitim = nameof(PersonelEgitim);
    public const string PersonelGorevlendirme = nameof(PersonelGorevlendirme);
    public const string PersonelIzin = nameof(PersonelIzin);
    public const string PersonelIzinDurumu = nameof(PersonelIzinDurumu);
    public const string PersonelOdulCeza = nameof(PersonelOdulCeza);
    public const string PersonelOgrenim = nameof(PersonelOgrenim);
    public const string PersonelYandal = nameof(PersonelYandal);
    public const string Radyoloji = nameof(Radyoloji);
    public const string RadyolojiSonuc = nameof(RadyolojiSonuc);
    public const string Randevu = nameof(Randevu);
    public const string Recete = nameof(Recete);
    public const string ReceteIlac = nameof(ReceteIlac);
    public const string ReceteIlacAciklama = nameof(ReceteIlacAciklama);
    public const string ReferansKodlar = nameof(ReferansKodlar);
    public const string RiskSkorlama = nameof(RiskSkorlama);
    public const string RiskSkorlamaDetay = nameof(RiskSkorlamaDetay);
    public const string SilinenKayitlar = nameof(SilinenKayitlar);
    public const string SterilizasyonCikis = nameof(SterilizasyonCikis);
    public const string SterilizasyonGiris = nameof(SterilizasyonGiris);
    public const string SterilizasyonPaket = nameof(SterilizasyonPaket);
    public const string SterilizasyonPaketDetay = nameof(SterilizasyonPaketDetay);
    public const string SterilizasyonSet = nameof(SterilizasyonSet);
    public const string SterilizasyonSetDetay = nameof(SterilizasyonSetDetay);
    public const string SterilizasyonStokDurum = nameof(SterilizasyonStokDurum);
    public const string SterilizasyonYikama = nameof(SterilizasyonYikama);
    public const string StokDurum = nameof(StokDurum);
    public const string StokEhuTakip = nameof(StokEhuTakip);
    public const string StokFis = nameof(StokFis);
    public const string StokHareket = nameof(StokHareket);
    public const string StokIstek = nameof(StokIstek);
    public const string StokIstekHareket = nameof(StokIstekHareket);
    public const string StokIstekUygulama = nameof(StokIstekUygulama);
    public const string StokKart = nameof(StokKart);
    public const string SysPaket = nameof(SysPaket);
    public const string Tetkik = nameof(Tetkik);
    public const string TetkikCihazEslesme = nameof(TetkikCihazEslesme);
    public const string TetkikNumune = nameof(TetkikNumune);
    public const string TetkikParametre = nameof(TetkikParametre);
    public const string TetkikReferansAralik = nameof(TetkikReferansAralik);
    public const string TetkikSonuc = nameof(TetkikSonuc);
    public const string TibbiOrder = nameof(TibbiOrder);
    public const string TibbiOrderDetay = nameof(TibbiOrderDetay);
    public const string Vezne = nameof(Vezne);
    public const string VezneDetay = nameof(VezneDetay);
    public const string Yatak = nameof(Yatak);
}

public static class FSHPermissions
{
    private static readonly FSHPermission[] _all = new FSHPermission[]
    {
        // Dashboard & System
        new("View Dashboard", FSHAction.View, FSHResource.Dashboard, IsRoot: true),
        new("View Hangfire", FSHAction.View, FSHResource.Hangfire),

        // Users
        new("View Users", FSHAction.View, FSHResource.Users, IsRoot: true),
        new("Search Users", FSHAction.Search, FSHResource.Users, IsRoot: true),
        new("Create Users", FSHAction.Create, FSHResource.Users, IsRoot: true),
        new("Update Users", FSHAction.Update, FSHResource.Users, IsRoot: true),
        new("Delete Users", FSHAction.Delete, FSHResource.Users, IsRoot: true),
        new("Export Users", FSHAction.Export, FSHResource.Users, IsRoot: true),

        // User Roles
        new("View UserRoles", FSHAction.View, FSHResource.UserRoles, IsRoot: true),
        new("Update UserRoles", FSHAction.Update, FSHResource.UserRoles, IsRoot: true),
        new("Update OtherUsers", FSHAction.Update, FSHResource.OtherUsers, IsRoot: true),

        // Roles
        new("View Roles", FSHAction.View, FSHResource.Roles, IsRoot: true),
        new("Create Roles", FSHAction.Create, FSHResource.Roles, IsRoot: true),
        new("Update Roles", FSHAction.Update, FSHResource.Roles, IsRoot: true),
        new("Delete Roles", FSHAction.Delete, FSHResource.Roles, IsRoot: true),
        new("View RoleClaims", FSHAction.View, FSHResource.RoleClaims, IsRoot: true),
        new("Update RoleClaims", FSHAction.Update, FSHResource.RoleClaims, IsRoot: true),

        // VEM 2.0 - Ameliyat
        new("View Ameliyat", FSHAction.View, FSHResource.Ameliyat),
        new("Search Ameliyat", FSHAction.Search, FSHResource.Ameliyat),
        new("Create Ameliyat", FSHAction.Create, FSHResource.Ameliyat),
        new("Update Ameliyat", FSHAction.Update, FSHResource.Ameliyat),
        new("Delete Ameliyat", FSHAction.Delete, FSHResource.Ameliyat),

        // VEM 2.0 - AmeliyatEkip
        new("View AmeliyatEkip", FSHAction.View, FSHResource.AmeliyatEkip),
        new("Search AmeliyatEkip", FSHAction.Search, FSHResource.AmeliyatEkip),
        new("Create AmeliyatEkip", FSHAction.Create, FSHResource.AmeliyatEkip),
        new("Update AmeliyatEkip", FSHAction.Update, FSHResource.AmeliyatEkip),
        new("Delete AmeliyatEkip", FSHAction.Delete, FSHResource.AmeliyatEkip),

        // VEM 2.0 - AmeliyatIslem
        new("View AmeliyatIslem", FSHAction.View, FSHResource.AmeliyatIslem),
        new("Search AmeliyatIslem", FSHAction.Search, FSHResource.AmeliyatIslem),
        new("Create AmeliyatIslem", FSHAction.Create, FSHResource.AmeliyatIslem),
        new("Update AmeliyatIslem", FSHAction.Update, FSHResource.AmeliyatIslem),
        new("Delete AmeliyatIslem", FSHAction.Delete, FSHResource.AmeliyatIslem),

        // VEM 2.0 - AnlikYatanHasta
        new("View AnlikYatanHasta", FSHAction.View, FSHResource.AnlikYatanHasta),
        new("Search AnlikYatanHasta", FSHAction.Search, FSHResource.AnlikYatanHasta),
        new("Create AnlikYatanHasta", FSHAction.Create, FSHResource.AnlikYatanHasta),
        new("Update AnlikYatanHasta", FSHAction.Update, FSHResource.AnlikYatanHasta),
        new("Delete AnlikYatanHasta", FSHAction.Delete, FSHResource.AnlikYatanHasta),

        // VEM 2.0 - AntibiyotikSonuc
        new("View AntibiyotikSonuc", FSHAction.View, FSHResource.AntibiyotikSonuc),
        new("Search AntibiyotikSonuc", FSHAction.Search, FSHResource.AntibiyotikSonuc),
        new("Create AntibiyotikSonuc", FSHAction.Create, FSHResource.AntibiyotikSonuc),
        new("Update AntibiyotikSonuc", FSHAction.Update, FSHResource.AntibiyotikSonuc),
        new("Delete AntibiyotikSonuc", FSHAction.Delete, FSHResource.AntibiyotikSonuc),

        // VEM 2.0 - AsiBilgisi
        new("View AsiBilgisi", FSHAction.View, FSHResource.AsiBilgisi),
        new("Search AsiBilgisi", FSHAction.Search, FSHResource.AsiBilgisi),
        new("Create AsiBilgisi", FSHAction.Create, FSHResource.AsiBilgisi),
        new("Update AsiBilgisi", FSHAction.Update, FSHResource.AsiBilgisi),
        new("Delete AsiBilgisi", FSHAction.Delete, FSHResource.AsiBilgisi),

        // VEM 2.0 - BakteriSonuc
        new("View BakteriSonuc", FSHAction.View, FSHResource.BakteriSonuc),
        new("Search BakteriSonuc", FSHAction.Search, FSHResource.BakteriSonuc),
        new("Create BakteriSonuc", FSHAction.Create, FSHResource.BakteriSonuc),
        new("Update BakteriSonuc", FSHAction.Update, FSHResource.BakteriSonuc),
        new("Delete BakteriSonuc", FSHAction.Delete, FSHResource.BakteriSonuc),

        // VEM 2.0 - BasvuruTani
        new("View BasvuruTani", FSHAction.View, FSHResource.BasvuruTani),
        new("Search BasvuruTani", FSHAction.Search, FSHResource.BasvuruTani),
        new("Create BasvuruTani", FSHAction.Create, FSHResource.BasvuruTani),
        new("Update BasvuruTani", FSHAction.Update, FSHResource.BasvuruTani),
        new("Delete BasvuruTani", FSHAction.Delete, FSHResource.BasvuruTani),

        // VEM 2.0 - BasvuruYemek
        new("View BasvuruYemek", FSHAction.View, FSHResource.BasvuruYemek),
        new("Search BasvuruYemek", FSHAction.Search, FSHResource.BasvuruYemek),
        new("Create BasvuruYemek", FSHAction.Create, FSHResource.BasvuruYemek),
        new("Update BasvuruYemek", FSHAction.Update, FSHResource.BasvuruYemek),
        new("Delete BasvuruYemek", FSHAction.Delete, FSHResource.BasvuruYemek),

        // VEM 2.0 - BebekCocukIzlem
        new("View BebekCocukIzlem", FSHAction.View, FSHResource.BebekCocukIzlem),
        new("Search BebekCocukIzlem", FSHAction.Search, FSHResource.BebekCocukIzlem),
        new("Create BebekCocukIzlem", FSHAction.Create, FSHResource.BebekCocukIzlem),
        new("Update BebekCocukIzlem", FSHAction.Update, FSHResource.BebekCocukIzlem),
        new("Delete BebekCocukIzlem", FSHAction.Delete, FSHResource.BebekCocukIzlem),

        // VEM 2.0 - BildirimiZorunlu
        new("View BildirimiZorunlu", FSHAction.View, FSHResource.BildirimiZorunlu),
        new("Search BildirimiZorunlu", FSHAction.Search, FSHResource.BildirimiZorunlu),
        new("Create BildirimiZorunlu", FSHAction.Create, FSHResource.BildirimiZorunlu),
        new("Update BildirimiZorunlu", FSHAction.Update, FSHResource.BildirimiZorunlu),
        new("Delete BildirimiZorunlu", FSHAction.Delete, FSHResource.BildirimiZorunlu),

        // VEM 2.0 - Bina
        new("View Bina", FSHAction.View, FSHResource.Bina),
        new("Search Bina", FSHAction.Search, FSHResource.Bina),
        new("Create Bina", FSHAction.Create, FSHResource.Bina),
        new("Update Bina", FSHAction.Update, FSHResource.Bina),
        new("Delete Bina", FSHAction.Delete, FSHResource.Bina),

        // VEM 2.0 - Birim
        new("View Birim", FSHAction.View, FSHResource.Birim, IsBasic: true),
        new("Search Birim", FSHAction.Search, FSHResource.Birim),
        new("Create Birim", FSHAction.Create, FSHResource.Birim),
        new("Update Birim", FSHAction.Update, FSHResource.Birim),
        new("Delete Birim", FSHAction.Delete, FSHResource.Birim),

        // VEM 2.0 - Cihaz
        new("View Cihaz", FSHAction.View, FSHResource.Cihaz),
        new("Search Cihaz", FSHAction.Search, FSHResource.Cihaz),
        new("Create Cihaz", FSHAction.Create, FSHResource.Cihaz),
        new("Update Cihaz", FSHAction.Update, FSHResource.Cihaz),
        new("Delete Cihaz", FSHAction.Delete, FSHResource.Cihaz),

        // VEM 2.0 - CocukDiyabet
        new("View CocukDiyabet", FSHAction.View, FSHResource.CocukDiyabet),
        new("Search CocukDiyabet", FSHAction.Search, FSHResource.CocukDiyabet),
        new("Create CocukDiyabet", FSHAction.Create, FSHResource.CocukDiyabet),
        new("Update CocukDiyabet", FSHAction.Update, FSHResource.CocukDiyabet),
        new("Delete CocukDiyabet", FSHAction.Delete, FSHResource.CocukDiyabet),

        // VEM 2.0 - Depo
        new("View Depo", FSHAction.View, FSHResource.Depo),
        new("Search Depo", FSHAction.Search, FSHResource.Depo),
        new("Create Depo", FSHAction.Create, FSHResource.Depo),
        new("Update Depo", FSHAction.Update, FSHResource.Depo),
        new("Delete Depo", FSHAction.Delete, FSHResource.Depo),

        // VEM 2.0 - DisTaahhut
        new("View DisTaahhut", FSHAction.View, FSHResource.DisTaahhut),
        new("Search DisTaahhut", FSHAction.Search, FSHResource.DisTaahhut),
        new("Create DisTaahhut", FSHAction.Create, FSHResource.DisTaahhut),
        new("Update DisTaahhut", FSHAction.Update, FSHResource.DisTaahhut),
        new("Delete DisTaahhut", FSHAction.Delete, FSHResource.DisTaahhut),

        // VEM 2.0 - DisTaahhutDetay
        new("View DisTaahhutDetay", FSHAction.View, FSHResource.DisTaahhutDetay),
        new("Search DisTaahhutDetay", FSHAction.Search, FSHResource.DisTaahhutDetay),
        new("Create DisTaahhutDetay", FSHAction.Create, FSHResource.DisTaahhutDetay),
        new("Update DisTaahhutDetay", FSHAction.Update, FSHResource.DisTaahhutDetay),
        new("Delete DisTaahhutDetay", FSHAction.Delete, FSHResource.DisTaahhutDetay),

        // VEM 2.0 - Disprotez
        new("View Disprotez", FSHAction.View, FSHResource.Disprotez),
        new("Search Disprotez", FSHAction.Search, FSHResource.Disprotez),
        new("Create Disprotez", FSHAction.Create, FSHResource.Disprotez),
        new("Update Disprotez", FSHAction.Update, FSHResource.Disprotez),
        new("Delete Disprotez", FSHAction.Delete, FSHResource.Disprotez),

        // VEM 2.0 - DisprotezDetay
        new("View DisprotezDetay", FSHAction.View, FSHResource.DisprotezDetay),
        new("Search DisprotezDetay", FSHAction.Search, FSHResource.DisprotezDetay),
        new("Create DisprotezDetay", FSHAction.Create, FSHResource.DisprotezDetay),
        new("Update DisprotezDetay", FSHAction.Update, FSHResource.DisprotezDetay),
        new("Delete DisprotezDetay", FSHAction.Delete, FSHResource.DisprotezDetay),

        // VEM 2.0 - Diyabet
        new("View Diyabet", FSHAction.View, FSHResource.Diyabet),
        new("Search Diyabet", FSHAction.Search, FSHResource.Diyabet),
        new("Create Diyabet", FSHAction.Create, FSHResource.Diyabet),
        new("Update Diyabet", FSHAction.Update, FSHResource.Diyabet),
        new("Delete Diyabet", FSHAction.Delete, FSHResource.Diyabet),

        // VEM 2.0 - Dogum
        new("View Dogum", FSHAction.View, FSHResource.Dogum),
        new("Search Dogum", FSHAction.Search, FSHResource.Dogum),
        new("Create Dogum", FSHAction.Create, FSHResource.Dogum),
        new("Update Dogum", FSHAction.Update, FSHResource.Dogum),
        new("Delete Dogum", FSHAction.Delete, FSHResource.Dogum),

        // VEM 2.0 - DogumDetay
        new("View DogumDetay", FSHAction.View, FSHResource.DogumDetay),
        new("Search DogumDetay", FSHAction.Search, FSHResource.DogumDetay),
        new("Create DogumDetay", FSHAction.Create, FSHResource.DogumDetay),
        new("Update DogumDetay", FSHAction.Update, FSHResource.DogumDetay),
        new("Delete DogumDetay", FSHAction.Delete, FSHResource.DogumDetay),

        // VEM 2.0 - DoktorMesaji
        new("View DoktorMesaji", FSHAction.View, FSHResource.DoktorMesaji),
        new("Search DoktorMesaji", FSHAction.Search, FSHResource.DoktorMesaji),
        new("Create DoktorMesaji", FSHAction.Create, FSHResource.DoktorMesaji),
        new("Update DoktorMesaji", FSHAction.Update, FSHResource.DoktorMesaji),
        new("Delete DoktorMesaji", FSHAction.Delete, FSHResource.DoktorMesaji),

        // VEM 2.0 - EkOdeme
        new("View EkOdeme", FSHAction.View, FSHResource.EkOdeme),
        new("Search EkOdeme", FSHAction.Search, FSHResource.EkOdeme),
        new("Create EkOdeme", FSHAction.Create, FSHResource.EkOdeme),
        new("Update EkOdeme", FSHAction.Update, FSHResource.EkOdeme),
        new("Delete EkOdeme", FSHAction.Delete, FSHResource.EkOdeme),

        // VEM 2.0 - EkOdemeDetay
        new("View EkOdemeDetay", FSHAction.View, FSHResource.EkOdemeDetay),
        new("Search EkOdemeDetay", FSHAction.Search, FSHResource.EkOdemeDetay),
        new("Create EkOdemeDetay", FSHAction.Create, FSHResource.EkOdemeDetay),
        new("Update EkOdemeDetay", FSHAction.Update, FSHResource.EkOdemeDetay),
        new("Delete EkOdemeDetay", FSHAction.Delete, FSHResource.EkOdemeDetay),

        // VEM 2.0 - EkOdemeDonem
        new("View EkOdemeDonem", FSHAction.View, FSHResource.EkOdemeDonem),
        new("Search EkOdemeDonem", FSHAction.Search, FSHResource.EkOdemeDonem),
        new("Create EkOdemeDonem", FSHAction.Create, FSHResource.EkOdemeDonem),
        new("Update EkOdemeDonem", FSHAction.Update, FSHResource.EkOdemeDonem),
        new("Delete EkOdemeDonem", FSHAction.Delete, FSHResource.EkOdemeDonem),

        // VEM 2.0 - EvdeSaglikIzlem
        new("View EvdeSaglikIzlem", FSHAction.View, FSHResource.EvdeSaglikIzlem),
        new("Search EvdeSaglikIzlem", FSHAction.Search, FSHResource.EvdeSaglikIzlem),
        new("Create EvdeSaglikIzlem", FSHAction.Create, FSHResource.EvdeSaglikIzlem),
        new("Update EvdeSaglikIzlem", FSHAction.Update, FSHResource.EvdeSaglikIzlem),
        new("Delete EvdeSaglikIzlem", FSHAction.Delete, FSHResource.EvdeSaglikIzlem),

        // VEM 2.0 - Fatura
        new("View Fatura", FSHAction.View, FSHResource.Fatura),
        new("Search Fatura", FSHAction.Search, FSHResource.Fatura),
        new("Create Fatura", FSHAction.Create, FSHResource.Fatura),
        new("Update Fatura", FSHAction.Update, FSHResource.Fatura),
        new("Delete Fatura", FSHAction.Delete, FSHResource.Fatura),

        // VEM 2.0 - Firma
        new("View Firma", FSHAction.View, FSHResource.Firma),
        new("Search Firma", FSHAction.Search, FSHResource.Firma),
        new("Create Firma", FSHAction.Create, FSHResource.Firma),
        new("Update Firma", FSHAction.Update, FSHResource.Firma),
        new("Delete Firma", FSHAction.Delete, FSHResource.Firma),

        // VEM 2.0 - GebeIzlem
        new("View GebeIzlem", FSHAction.View, FSHResource.GebeIzlem),
        new("Search GebeIzlem", FSHAction.Search, FSHResource.GebeIzlem),
        new("Create GebeIzlem", FSHAction.Create, FSHResource.GebeIzlem),
        new("Update GebeIzlem", FSHAction.Update, FSHResource.GebeIzlem),
        new("Delete GebeIzlem", FSHAction.Delete, FSHResource.GebeIzlem),

        // VEM 2.0 - Getat
        new("View Getat", FSHAction.View, FSHResource.Getat),
        new("Search Getat", FSHAction.Search, FSHResource.Getat),
        new("Create Getat", FSHAction.Create, FSHResource.Getat),
        new("Update Getat", FSHAction.Update, FSHResource.Getat),
        new("Delete Getat", FSHAction.Delete, FSHResource.Getat),

        // VEM 2.0 - GrupUyelik
        new("View GrupUyelik", FSHAction.View, FSHResource.GrupUyelik),
        new("Search GrupUyelik", FSHAction.Search, FSHResource.GrupUyelik),
        new("Create GrupUyelik", FSHAction.Create, FSHResource.GrupUyelik),
        new("Update GrupUyelik", FSHAction.Update, FSHResource.GrupUyelik),
        new("Delete GrupUyelik", FSHAction.Delete, FSHResource.GrupUyelik),

        // VEM 2.0 - Hasta
        new("View Hasta", FSHAction.View, FSHResource.Hasta, IsBasic: true),
        new("Search Hasta", FSHAction.Search, FSHResource.Hasta),
        new("Create Hasta", FSHAction.Create, FSHResource.Hasta),
        new("Update Hasta", FSHAction.Update, FSHResource.Hasta),
        new("Delete Hasta", FSHAction.Delete, FSHResource.Hasta),

        // VEM 2.0 - HastaAdliRapor
        new("View HastaAdliRapor", FSHAction.View, FSHResource.HastaAdliRapor),
        new("Search HastaAdliRapor", FSHAction.Search, FSHResource.HastaAdliRapor),
        new("Create HastaAdliRapor", FSHAction.Create, FSHResource.HastaAdliRapor),
        new("Update HastaAdliRapor", FSHAction.Update, FSHResource.HastaAdliRapor),
        new("Delete HastaAdliRapor", FSHAction.Delete, FSHResource.HastaAdliRapor),

        // VEM 2.0 - HastaArsiv
        new("View HastaArsiv", FSHAction.View, FSHResource.HastaArsiv),
        new("Search HastaArsiv", FSHAction.Search, FSHResource.HastaArsiv),
        new("Create HastaArsiv", FSHAction.Create, FSHResource.HastaArsiv),
        new("Update HastaArsiv", FSHAction.Update, FSHResource.HastaArsiv),
        new("Delete HastaArsiv", FSHAction.Delete, FSHResource.HastaArsiv),

        // VEM 2.0 - HastaArsivDetay
        new("View HastaArsivDetay", FSHAction.View, FSHResource.HastaArsivDetay),
        new("Search HastaArsivDetay", FSHAction.Search, FSHResource.HastaArsivDetay),
        new("Create HastaArsivDetay", FSHAction.Create, FSHResource.HastaArsivDetay),
        new("Update HastaArsivDetay", FSHAction.Update, FSHResource.HastaArsivDetay),
        new("Delete HastaArsivDetay", FSHAction.Delete, FSHResource.HastaArsivDetay),

        // VEM 2.0 - HastaBasvuru
        new("View HastaBasvuru", FSHAction.View, FSHResource.HastaBasvuru, IsBasic: true),
        new("Search HastaBasvuru", FSHAction.Search, FSHResource.HastaBasvuru),
        new("Create HastaBasvuru", FSHAction.Create, FSHResource.HastaBasvuru),
        new("Update HastaBasvuru", FSHAction.Update, FSHResource.HastaBasvuru),
        new("Delete HastaBasvuru", FSHAction.Delete, FSHResource.HastaBasvuru),

        // VEM 2.0 - HastaBorc
        new("View HastaBorc", FSHAction.View, FSHResource.HastaBorc),
        new("Search HastaBorc", FSHAction.Search, FSHResource.HastaBorc),
        new("Create HastaBorc", FSHAction.Create, FSHResource.HastaBorc),
        new("Update HastaBorc", FSHAction.Update, FSHResource.HastaBorc),
        new("Delete HastaBorc", FSHAction.Delete, FSHResource.HastaBorc),

        // VEM 2.0 - HastaDis
        new("View HastaDis", FSHAction.View, FSHResource.HastaDis),
        new("Search HastaDis", FSHAction.Search, FSHResource.HastaDis),
        new("Create HastaDis", FSHAction.Create, FSHResource.HastaDis),
        new("Update HastaDis", FSHAction.Update, FSHResource.HastaDis),
        new("Delete HastaDis", FSHAction.Delete, FSHResource.HastaDis),

        // VEM 2.0 - HastaEpikriz
        new("View HastaEpikriz", FSHAction.View, FSHResource.HastaEpikriz),
        new("Search HastaEpikriz", FSHAction.Search, FSHResource.HastaEpikriz),
        new("Create HastaEpikriz", FSHAction.Create, FSHResource.HastaEpikriz),
        new("Update HastaEpikriz", FSHAction.Update, FSHResource.HastaEpikriz),
        new("Delete HastaEpikriz", FSHAction.Delete, FSHResource.HastaEpikriz),

        // VEM 2.0 - HastaFotograf
        new("View HastaFotograf", FSHAction.View, FSHResource.HastaFotograf),
        new("Search HastaFotograf", FSHAction.Search, FSHResource.HastaFotograf),
        new("Create HastaFotograf", FSHAction.Create, FSHResource.HastaFotograf),
        new("Update HastaFotograf", FSHAction.Update, FSHResource.HastaFotograf),
        new("Delete HastaFotograf", FSHAction.Delete, FSHResource.HastaFotograf),

        // VEM 2.0 - HastaGizlilik
        new("View HastaGizlilik", FSHAction.View, FSHResource.HastaGizlilik),
        new("Search HastaGizlilik", FSHAction.Search, FSHResource.HastaGizlilik),
        new("Create HastaGizlilik", FSHAction.Create, FSHResource.HastaGizlilik),
        new("Update HastaGizlilik", FSHAction.Update, FSHResource.HastaGizlilik),
        new("Delete HastaGizlilik", FSHAction.Delete, FSHResource.HastaGizlilik),

        // VEM 2.0 - HastaHizmet
        new("View HastaHizmet", FSHAction.View, FSHResource.HastaHizmet),
        new("Search HastaHizmet", FSHAction.Search, FSHResource.HastaHizmet),
        new("Create HastaHizmet", FSHAction.Create, FSHResource.HastaHizmet),
        new("Update HastaHizmet", FSHAction.Update, FSHResource.HastaHizmet),
        new("Delete HastaHizmet", FSHAction.Delete, FSHResource.HastaHizmet),

        // VEM 2.0 - HastaIletisim
        new("View HastaIletisim", FSHAction.View, FSHResource.HastaIletisim),
        new("Search HastaIletisim", FSHAction.Search, FSHResource.HastaIletisim),
        new("Create HastaIletisim", FSHAction.Create, FSHResource.HastaIletisim),
        new("Update HastaIletisim", FSHAction.Update, FSHResource.HastaIletisim),
        new("Delete HastaIletisim", FSHAction.Delete, FSHResource.HastaIletisim),

        // VEM 2.0 - HastaMalzeme
        new("View HastaMalzeme", FSHAction.View, FSHResource.HastaMalzeme),
        new("Search HastaMalzeme", FSHAction.Search, FSHResource.HastaMalzeme),
        new("Create HastaMalzeme", FSHAction.Create, FSHResource.HastaMalzeme),
        new("Update HastaMalzeme", FSHAction.Update, FSHResource.HastaMalzeme),
        new("Delete HastaMalzeme", FSHAction.Delete, FSHResource.HastaMalzeme),

        // VEM 2.0 - HastaNotlari
        new("View HastaNotlari", FSHAction.View, FSHResource.HastaNotlari),
        new("Search HastaNotlari", FSHAction.Search, FSHResource.HastaNotlari),
        new("Create HastaNotlari", FSHAction.Create, FSHResource.HastaNotlari),
        new("Update HastaNotlari", FSHAction.Update, FSHResource.HastaNotlari),
        new("Delete HastaNotlari", FSHAction.Delete, FSHResource.HastaNotlari),

        // VEM 2.0 - HastaOlum
        new("View HastaOlum", FSHAction.View, FSHResource.HastaOlum),
        new("Search HastaOlum", FSHAction.Search, FSHResource.HastaOlum),
        new("Create HastaOlum", FSHAction.Create, FSHResource.HastaOlum),
        new("Update HastaOlum", FSHAction.Update, FSHResource.HastaOlum),
        new("Delete HastaOlum", FSHAction.Delete, FSHResource.HastaOlum),

        // VEM 2.0 - HastaSeans
        new("View HastaSeans", FSHAction.View, FSHResource.HastaSeans),
        new("Search HastaSeans", FSHAction.Search, FSHResource.HastaSeans),
        new("Create HastaSeans", FSHAction.Create, FSHResource.HastaSeans),
        new("Update HastaSeans", FSHAction.Update, FSHResource.HastaSeans),
        new("Delete HastaSeans", FSHAction.Delete, FSHResource.HastaSeans),

        // VEM 2.0 - HastaSevk
        new("View HastaSevk", FSHAction.View, FSHResource.HastaSevk),
        new("Search HastaSevk", FSHAction.Search, FSHResource.HastaSevk),
        new("Create HastaSevk", FSHAction.Create, FSHResource.HastaSevk),
        new("Update HastaSevk", FSHAction.Update, FSHResource.HastaSevk),
        new("Delete HastaSevk", FSHAction.Delete, FSHResource.HastaSevk),

        // VEM 2.0 - HastaTibbiBilgi
        new("View HastaTibbiBilgi", FSHAction.View, FSHResource.HastaTibbiBilgi),
        new("Search HastaTibbiBilgi", FSHAction.Search, FSHResource.HastaTibbiBilgi),
        new("Create HastaTibbiBilgi", FSHAction.Create, FSHResource.HastaTibbiBilgi),
        new("Update HastaTibbiBilgi", FSHAction.Update, FSHResource.HastaTibbiBilgi),
        new("Delete HastaTibbiBilgi", FSHAction.Delete, FSHResource.HastaTibbiBilgi),

        // VEM 2.0 - HastaUyari
        new("View HastaUyari", FSHAction.View, FSHResource.HastaUyari),
        new("Search HastaUyari", FSHAction.Search, FSHResource.HastaUyari),
        new("Create HastaUyari", FSHAction.Create, FSHResource.HastaUyari),
        new("Update HastaUyari", FSHAction.Update, FSHResource.HastaUyari),
        new("Delete HastaUyari", FSHAction.Delete, FSHResource.HastaUyari),

        // VEM 2.0 - HastaVentilator
        new("View HastaVentilator", FSHAction.View, FSHResource.HastaVentilator),
        new("Search HastaVentilator", FSHAction.Search, FSHResource.HastaVentilator),
        new("Create HastaVentilator", FSHAction.Create, FSHResource.HastaVentilator),
        new("Update HastaVentilator", FSHAction.Update, FSHResource.HastaVentilator),
        new("Delete HastaVentilator", FSHAction.Delete, FSHResource.HastaVentilator),

        // VEM 2.0 - HastaVitalFizikiBulgu
        new("View HastaVitalFizikiBulgu", FSHAction.View, FSHResource.HastaVitalFizikiBulgu),
        new("Search HastaVitalFizikiBulgu", FSHAction.Search, FSHResource.HastaVitalFizikiBulgu),
        new("Create HastaVitalFizikiBulgu", FSHAction.Create, FSHResource.HastaVitalFizikiBulgu),
        new("Update HastaVitalFizikiBulgu", FSHAction.Update, FSHResource.HastaVitalFizikiBulgu),
        new("Delete HastaVitalFizikiBulgu", FSHAction.Delete, FSHResource.HastaVitalFizikiBulgu),

        // VEM 2.0 - HastaYatak
        new("View HastaYatak", FSHAction.View, FSHResource.HastaYatak),
        new("Search HastaYatak", FSHAction.Search, FSHResource.HastaYatak),
        new("Create HastaYatak", FSHAction.Create, FSHResource.HastaYatak),
        new("Update HastaYatak", FSHAction.Update, FSHResource.HastaYatak),
        new("Delete HastaYatak", FSHAction.Delete, FSHResource.HastaYatak),

        // VEM 2.0 - Hemoglobinopati
        new("View Hemoglobinopati", FSHAction.View, FSHResource.Hemoglobinopati),
        new("Search Hemoglobinopati", FSHAction.Search, FSHResource.Hemoglobinopati),
        new("Create Hemoglobinopati", FSHAction.Create, FSHResource.Hemoglobinopati),
        new("Update Hemoglobinopati", FSHAction.Update, FSHResource.Hemoglobinopati),
        new("Delete Hemoglobinopati", FSHAction.Delete, FSHResource.Hemoglobinopati),

        // VEM 2.0 - HemsireBakim
        new("View HemsireBakim", FSHAction.View, FSHResource.HemsireBakim),
        new("Search HemsireBakim", FSHAction.Search, FSHResource.HemsireBakim),
        new("Create HemsireBakim", FSHAction.Create, FSHResource.HemsireBakim),
        new("Update HemsireBakim", FSHAction.Update, FSHResource.HemsireBakim),
        new("Delete HemsireBakim", FSHAction.Delete, FSHResource.HemsireBakim),

        // VEM 2.0 - Hizmet
        new("View Hizmet", FSHAction.View, FSHResource.Hizmet),
        new("Search Hizmet", FSHAction.Search, FSHResource.Hizmet),
        new("Create Hizmet", FSHAction.Create, FSHResource.Hizmet),
        new("Update Hizmet", FSHAction.Update, FSHResource.Hizmet),
        new("Delete Hizmet", FSHAction.Delete, FSHResource.Hizmet),

        // VEM 2.0 - Icmal
        new("View Icmal", FSHAction.View, FSHResource.Icmal),
        new("Search Icmal", FSHAction.Search, FSHResource.Icmal),
        new("Create Icmal", FSHAction.Create, FSHResource.Icmal),
        new("Update Icmal", FSHAction.Update, FSHResource.Icmal),
        new("Delete Icmal", FSHAction.Delete, FSHResource.Icmal),

        // VEM 2.0 - IlacUyum
        new("View IlacUyum", FSHAction.View, FSHResource.IlacUyum),
        new("Search IlacUyum", FSHAction.Search, FSHResource.IlacUyum),
        new("Create IlacUyum", FSHAction.Create, FSHResource.IlacUyum),
        new("Update IlacUyum", FSHAction.Update, FSHResource.IlacUyum),
        new("Delete IlacUyum", FSHAction.Delete, FSHResource.IlacUyum),

        // VEM 2.0 - IntiharIzlem
        new("View IntiharIzlem", FSHAction.View, FSHResource.IntiharIzlem),
        new("Search IntiharIzlem", FSHAction.Search, FSHResource.IntiharIzlem),
        new("Create IntiharIzlem", FSHAction.Create, FSHResource.IntiharIzlem),
        new("Update IntiharIzlem", FSHAction.Update, FSHResource.IntiharIzlem),
        new("Delete IntiharIzlem", FSHAction.Delete, FSHResource.IntiharIzlem),

        // VEM 2.0 - KadinIzlem
        new("View KadinIzlem", FSHAction.View, FSHResource.KadinIzlem),
        new("Search KadinIzlem", FSHAction.Search, FSHResource.KadinIzlem),
        new("Create KadinIzlem", FSHAction.Create, FSHResource.KadinIzlem),
        new("Update KadinIzlem", FSHAction.Update, FSHResource.KadinIzlem),
        new("Delete KadinIzlem", FSHAction.Delete, FSHResource.KadinIzlem),

        // VEM 2.0 - KanBagisci
        new("View KanBagisci", FSHAction.View, FSHResource.KanBagisci),
        new("Search KanBagisci", FSHAction.Search, FSHResource.KanBagisci),
        new("Create KanBagisci", FSHAction.Create, FSHResource.KanBagisci),
        new("Update KanBagisci", FSHAction.Update, FSHResource.KanBagisci),
        new("Delete KanBagisci", FSHAction.Delete, FSHResource.KanBagisci),

        // VEM 2.0 - KanCikis
        new("View KanCikis", FSHAction.View, FSHResource.KanCikis),
        new("Search KanCikis", FSHAction.Search, FSHResource.KanCikis),
        new("Create KanCikis", FSHAction.Create, FSHResource.KanCikis),
        new("Update KanCikis", FSHAction.Update, FSHResource.KanCikis),
        new("Delete KanCikis", FSHAction.Delete, FSHResource.KanCikis),

        // VEM 2.0 - KanStok
        new("View KanStok", FSHAction.View, FSHResource.KanStok),
        new("Search KanStok", FSHAction.Search, FSHResource.KanStok),
        new("Create KanStok", FSHAction.Create, FSHResource.KanStok),
        new("Update KanStok", FSHAction.Update, FSHResource.KanStok),
        new("Delete KanStok", FSHAction.Delete, FSHResource.KanStok),

        // VEM 2.0 - KanTalep
        new("View KanTalep", FSHAction.View, FSHResource.KanTalep),
        new("Search KanTalep", FSHAction.Search, FSHResource.KanTalep),
        new("Create KanTalep", FSHAction.Create, FSHResource.KanTalep),
        new("Update KanTalep", FSHAction.Update, FSHResource.KanTalep),
        new("Delete KanTalep", FSHAction.Delete, FSHResource.KanTalep),

        // VEM 2.0 - KanTalepDetay
        new("View KanTalepDetay", FSHAction.View, FSHResource.KanTalepDetay),
        new("Search KanTalepDetay", FSHAction.Search, FSHResource.KanTalepDetay),
        new("Create KanTalepDetay", FSHAction.Create, FSHResource.KanTalepDetay),
        new("Update KanTalepDetay", FSHAction.Update, FSHResource.KanTalepDetay),
        new("Delete KanTalepDetay", FSHAction.Delete, FSHResource.KanTalepDetay),

        // VEM 2.0 - KanUrun
        new("View KanUrun", FSHAction.View, FSHResource.KanUrun),
        new("Search KanUrun", FSHAction.Search, FSHResource.KanUrun),
        new("Create KanUrun", FSHAction.Create, FSHResource.KanUrun),
        new("Update KanUrun", FSHAction.Update, FSHResource.KanUrun),
        new("Delete KanUrun", FSHAction.Delete, FSHResource.KanUrun),

        // VEM 2.0 - KanUrunImha
        new("View KanUrunImha", FSHAction.View, FSHResource.KanUrunImha),
        new("Search KanUrunImha", FSHAction.Search, FSHResource.KanUrunImha),
        new("Create KanUrunImha", FSHAction.Create, FSHResource.KanUrunImha),
        new("Update KanUrunImha", FSHAction.Update, FSHResource.KanUrunImha),
        new("Delete KanUrunImha", FSHAction.Delete, FSHResource.KanUrunImha),

        // VEM 2.0 - KlinikSeyir
        new("View KlinikSeyir", FSHAction.View, FSHResource.KlinikSeyir),
        new("Search KlinikSeyir", FSHAction.Search, FSHResource.KlinikSeyir),
        new("Create KlinikSeyir", FSHAction.Create, FSHResource.KlinikSeyir),
        new("Update KlinikSeyir", FSHAction.Update, FSHResource.KlinikSeyir),
        new("Delete KlinikSeyir", FSHAction.Delete, FSHResource.KlinikSeyir),

        // VEM 2.0 - Konsultasyon
        new("View Konsultasyon", FSHAction.View, FSHResource.Konsultasyon),
        new("Search Konsultasyon", FSHAction.Search, FSHResource.Konsultasyon),
        new("Create Konsultasyon", FSHAction.Create, FSHResource.Konsultasyon),
        new("Update Konsultasyon", FSHAction.Update, FSHResource.Konsultasyon),
        new("Delete Konsultasyon", FSHAction.Delete, FSHResource.Konsultasyon),

        // VEM 2.0 - KuduzIzlem
        new("View KuduzIzlem", FSHAction.View, FSHResource.KuduzIzlem),
        new("Search KuduzIzlem", FSHAction.Search, FSHResource.KuduzIzlem),
        new("Create KuduzIzlem", FSHAction.Create, FSHResource.KuduzIzlem),
        new("Update KuduzIzlem", FSHAction.Update, FSHResource.KuduzIzlem),
        new("Delete KuduzIzlem", FSHAction.Delete, FSHResource.KuduzIzlem),

        // VEM 2.0 - Kullanici
        new("View Kullanici", FSHAction.View, FSHResource.Kullanici),
        new("Search Kullanici", FSHAction.Search, FSHResource.Kullanici),
        new("Create Kullanici", FSHAction.Create, FSHResource.Kullanici),
        new("Update Kullanici", FSHAction.Update, FSHResource.Kullanici),
        new("Delete Kullanici", FSHAction.Delete, FSHResource.Kullanici),

        // VEM 2.0 - KullaniciGrup
        new("View KullaniciGrup", FSHAction.View, FSHResource.KullaniciGrup),
        new("Search KullaniciGrup", FSHAction.Search, FSHResource.KullaniciGrup),
        new("Create KullaniciGrup", FSHAction.Create, FSHResource.KullaniciGrup),
        new("Update KullaniciGrup", FSHAction.Update, FSHResource.KullaniciGrup),
        new("Delete KullaniciGrup", FSHAction.Delete, FSHResource.KullaniciGrup),

        // VEM 2.0 - Kurul
        new("View Kurul", FSHAction.View, FSHResource.Kurul),
        new("Search Kurul", FSHAction.Search, FSHResource.Kurul),
        new("Create Kurul", FSHAction.Create, FSHResource.Kurul),
        new("Update Kurul", FSHAction.Update, FSHResource.Kurul),
        new("Delete Kurul", FSHAction.Delete, FSHResource.Kurul),

        // VEM 2.0 - KurulAskeri
        new("View KurulAskeri", FSHAction.View, FSHResource.KurulAskeri),
        new("Search KurulAskeri", FSHAction.Search, FSHResource.KurulAskeri),
        new("Create KurulAskeri", FSHAction.Create, FSHResource.KurulAskeri),
        new("Update KurulAskeri", FSHAction.Update, FSHResource.KurulAskeri),
        new("Delete KurulAskeri", FSHAction.Delete, FSHResource.KurulAskeri),

        // VEM 2.0 - KurulEngelli
        new("View KurulEngelli", FSHAction.View, FSHResource.KurulEngelli),
        new("Search KurulEngelli", FSHAction.Search, FSHResource.KurulEngelli),
        new("Create KurulEngelli", FSHAction.Create, FSHResource.KurulEngelli),
        new("Update KurulEngelli", FSHAction.Update, FSHResource.KurulEngelli),
        new("Delete KurulEngelli", FSHAction.Delete, FSHResource.KurulEngelli),

        // VEM 2.0 - KurulEtkenMadde
        new("View KurulEtkenMadde", FSHAction.View, FSHResource.KurulEtkenMadde),
        new("Search KurulEtkenMadde", FSHAction.Search, FSHResource.KurulEtkenMadde),
        new("Create KurulEtkenMadde", FSHAction.Create, FSHResource.KurulEtkenMadde),
        new("Update KurulEtkenMadde", FSHAction.Update, FSHResource.KurulEtkenMadde),
        new("Delete KurulEtkenMadde", FSHAction.Delete, FSHResource.KurulEtkenMadde),

        // VEM 2.0 - KurulHekim
        new("View KurulHekim", FSHAction.View, FSHResource.KurulHekim),
        new("Search KurulHekim", FSHAction.Search, FSHResource.KurulHekim),
        new("Create KurulHekim", FSHAction.Create, FSHResource.KurulHekim),
        new("Update KurulHekim", FSHAction.Update, FSHResource.KurulHekim),
        new("Delete KurulHekim", FSHAction.Delete, FSHResource.KurulHekim),

        // VEM 2.0 - KurulRapor
        new("View KurulRapor", FSHAction.View, FSHResource.KurulRapor),
        new("Search KurulRapor", FSHAction.Search, FSHResource.KurulRapor),
        new("Create KurulRapor", FSHAction.Create, FSHResource.KurulRapor),
        new("Update KurulRapor", FSHAction.Update, FSHResource.KurulRapor),
        new("Delete KurulRapor", FSHAction.Delete, FSHResource.KurulRapor),

        // VEM 2.0 - KurulTeshis
        new("View KurulTeshis", FSHAction.View, FSHResource.KurulTeshis),
        new("Search KurulTeshis", FSHAction.Search, FSHResource.KurulTeshis),
        new("Create KurulTeshis", FSHAction.Create, FSHResource.KurulTeshis),
        new("Update KurulTeshis", FSHAction.Update, FSHResource.KurulTeshis),
        new("Delete KurulTeshis", FSHAction.Delete, FSHResource.KurulTeshis),

        // VEM 2.0 - Kurum
        new("View Kurum", FSHAction.View, FSHResource.Kurum),
        new("Search Kurum", FSHAction.Search, FSHResource.Kurum),
        new("Create Kurum", FSHAction.Create, FSHResource.Kurum),
        new("Update Kurum", FSHAction.Update, FSHResource.Kurum),
        new("Delete Kurum", FSHAction.Delete, FSHResource.Kurum),

        // VEM 2.0 - LohusaIzlem
        new("View LohusaIzlem", FSHAction.View, FSHResource.LohusaIzlem),
        new("Search LohusaIzlem", FSHAction.Search, FSHResource.LohusaIzlem),
        new("Create LohusaIzlem", FSHAction.Create, FSHResource.LohusaIzlem),
        new("Update LohusaIzlem", FSHAction.Update, FSHResource.LohusaIzlem),
        new("Delete LohusaIzlem", FSHAction.Delete, FSHResource.LohusaIzlem),

        // VEM 2.0 - MaddeBagimliligi
        new("View MaddeBagimliligi", FSHAction.View, FSHResource.MaddeBagimliligi),
        new("Search MaddeBagimliligi", FSHAction.Search, FSHResource.MaddeBagimliligi),
        new("Create MaddeBagimliligi", FSHAction.Create, FSHResource.MaddeBagimliligi),
        new("Update MaddeBagimliligi", FSHAction.Update, FSHResource.MaddeBagimliligi),
        new("Delete MaddeBagimliligi", FSHAction.Delete, FSHResource.MaddeBagimliligi),

        // VEM 2.0 - MedulaTakip
        new("View MedulaTakip", FSHAction.View, FSHResource.MedulaTakip),
        new("Search MedulaTakip", FSHAction.Search, FSHResource.MedulaTakip),
        new("Create MedulaTakip", FSHAction.Create, FSHResource.MedulaTakip),
        new("Update MedulaTakip", FSHAction.Update, FSHResource.MedulaTakip),
        new("Delete MedulaTakip", FSHAction.Delete, FSHResource.MedulaTakip),

        // VEM 2.0 - NobetciPersonelBilgisi
        new("View NobetciPersonelBilgisi", FSHAction.View, FSHResource.NobetciPersonelBilgisi),
        new("Search NobetciPersonelBilgisi", FSHAction.Search, FSHResource.NobetciPersonelBilgisi),
        new("Create NobetciPersonelBilgisi", FSHAction.Create, FSHResource.NobetciPersonelBilgisi),
        new("Update NobetciPersonelBilgisi", FSHAction.Update, FSHResource.NobetciPersonelBilgisi),
        new("Delete NobetciPersonelBilgisi", FSHAction.Delete, FSHResource.NobetciPersonelBilgisi),

        // VEM 2.0 - ObeziteIzlem
        new("View ObeziteIzlem", FSHAction.View, FSHResource.ObeziteIzlem),
        new("Search ObeziteIzlem", FSHAction.Search, FSHResource.ObeziteIzlem),
        new("Create ObeziteIzlem", FSHAction.Create, FSHResource.ObeziteIzlem),
        new("Update ObeziteIzlem", FSHAction.Update, FSHResource.ObeziteIzlem),
        new("Delete ObeziteIzlem", FSHAction.Delete, FSHResource.ObeziteIzlem),

        // VEM 2.0 - Oda
        new("View Oda", FSHAction.View, FSHResource.Oda),
        new("Search Oda", FSHAction.Search, FSHResource.Oda),
        new("Create Oda", FSHAction.Create, FSHResource.Oda),
        new("Update Oda", FSHAction.Update, FSHResource.Oda),
        new("Delete Oda", FSHAction.Delete, FSHResource.Oda),

        // VEM 2.0 - OptikRecete
        new("View OptikRecete", FSHAction.View, FSHResource.OptikRecete),
        new("Search OptikRecete", FSHAction.Search, FSHResource.OptikRecete),
        new("Create OptikRecete", FSHAction.Create, FSHResource.OptikRecete),
        new("Update OptikRecete", FSHAction.Update, FSHResource.OptikRecete),
        new("Delete OptikRecete", FSHAction.Delete, FSHResource.OptikRecete),

        // VEM 2.0 - OrtodontiIconSkor
        new("View OrtodontiIconSkor", FSHAction.View, FSHResource.OrtodontiIconSkor),
        new("Search OrtodontiIconSkor", FSHAction.Search, FSHResource.OrtodontiIconSkor),
        new("Create OrtodontiIconSkor", FSHAction.Create, FSHResource.OrtodontiIconSkor),
        new("Update OrtodontiIconSkor", FSHAction.Update, FSHResource.OrtodontiIconSkor),
        new("Delete OrtodontiIconSkor", FSHAction.Delete, FSHResource.OrtodontiIconSkor),

        // VEM 2.0 - Patoloji
        new("View Patoloji", FSHAction.View, FSHResource.Patoloji),
        new("Search Patoloji", FSHAction.Search, FSHResource.Patoloji),
        new("Create Patoloji", FSHAction.Create, FSHResource.Patoloji),
        new("Update Patoloji", FSHAction.Update, FSHResource.Patoloji),
        new("Delete Patoloji", FSHAction.Delete, FSHResource.Patoloji),

        // VEM 2.0 - Personel
        new("View Personel", FSHAction.View, FSHResource.Personel),
        new("Search Personel", FSHAction.Search, FSHResource.Personel),
        new("Create Personel", FSHAction.Create, FSHResource.Personel),
        new("Update Personel", FSHAction.Update, FSHResource.Personel),
        new("Delete Personel", FSHAction.Delete, FSHResource.Personel),

        // VEM 2.0 - PersonelBakmaklaYukumlu
        new("View PersonelBakmaklaYukumlu", FSHAction.View, FSHResource.PersonelBakmaklaYukumlu),
        new("Search PersonelBakmaklaYukumlu", FSHAction.Search, FSHResource.PersonelBakmaklaYukumlu),
        new("Create PersonelBakmaklaYukumlu", FSHAction.Create, FSHResource.PersonelBakmaklaYukumlu),
        new("Update PersonelBakmaklaYukumlu", FSHAction.Update, FSHResource.PersonelBakmaklaYukumlu),
        new("Delete PersonelBakmaklaYukumlu", FSHAction.Delete, FSHResource.PersonelBakmaklaYukumlu),

        // VEM 2.0 - PersonelBanka
        new("View PersonelBanka", FSHAction.View, FSHResource.PersonelBanka),
        new("Search PersonelBanka", FSHAction.Search, FSHResource.PersonelBanka),
        new("Create PersonelBanka", FSHAction.Create, FSHResource.PersonelBanka),
        new("Update PersonelBanka", FSHAction.Update, FSHResource.PersonelBanka),
        new("Delete PersonelBanka", FSHAction.Delete, FSHResource.PersonelBanka),

        // VEM 2.0 - PersonelBordro
        new("View PersonelBordro", FSHAction.View, FSHResource.PersonelBordro),
        new("Search PersonelBordro", FSHAction.Search, FSHResource.PersonelBordro),
        new("Create PersonelBordro", FSHAction.Create, FSHResource.PersonelBordro),
        new("Update PersonelBordro", FSHAction.Update, FSHResource.PersonelBordro),
        new("Delete PersonelBordro", FSHAction.Delete, FSHResource.PersonelBordro),

        // VEM 2.0 - PersonelBordroSondurum
        new("View PersonelBordroSondurum", FSHAction.View, FSHResource.PersonelBordroSondurum),
        new("Search PersonelBordroSondurum", FSHAction.Search, FSHResource.PersonelBordroSondurum),
        new("Create PersonelBordroSondurum", FSHAction.Create, FSHResource.PersonelBordroSondurum),
        new("Update PersonelBordroSondurum", FSHAction.Update, FSHResource.PersonelBordroSondurum),
        new("Delete PersonelBordroSondurum", FSHAction.Delete, FSHResource.PersonelBordroSondurum),

        // VEM 2.0 - PersonelEgitim
        new("View PersonelEgitim", FSHAction.View, FSHResource.PersonelEgitim),
        new("Search PersonelEgitim", FSHAction.Search, FSHResource.PersonelEgitim),
        new("Create PersonelEgitim", FSHAction.Create, FSHResource.PersonelEgitim),
        new("Update PersonelEgitim", FSHAction.Update, FSHResource.PersonelEgitim),
        new("Delete PersonelEgitim", FSHAction.Delete, FSHResource.PersonelEgitim),

        // VEM 2.0 - PersonelGorevlendirme
        new("View PersonelGorevlendirme", FSHAction.View, FSHResource.PersonelGorevlendirme),
        new("Search PersonelGorevlendirme", FSHAction.Search, FSHResource.PersonelGorevlendirme),
        new("Create PersonelGorevlendirme", FSHAction.Create, FSHResource.PersonelGorevlendirme),
        new("Update PersonelGorevlendirme", FSHAction.Update, FSHResource.PersonelGorevlendirme),
        new("Delete PersonelGorevlendirme", FSHAction.Delete, FSHResource.PersonelGorevlendirme),

        // VEM 2.0 - PersonelIzin
        new("View PersonelIzin", FSHAction.View, FSHResource.PersonelIzin),
        new("Search PersonelIzin", FSHAction.Search, FSHResource.PersonelIzin),
        new("Create PersonelIzin", FSHAction.Create, FSHResource.PersonelIzin),
        new("Update PersonelIzin", FSHAction.Update, FSHResource.PersonelIzin),
        new("Delete PersonelIzin", FSHAction.Delete, FSHResource.PersonelIzin),

        // VEM 2.0 - PersonelIzinDurumu
        new("View PersonelIzinDurumu", FSHAction.View, FSHResource.PersonelIzinDurumu),
        new("Search PersonelIzinDurumu", FSHAction.Search, FSHResource.PersonelIzinDurumu),
        new("Create PersonelIzinDurumu", FSHAction.Create, FSHResource.PersonelIzinDurumu),
        new("Update PersonelIzinDurumu", FSHAction.Update, FSHResource.PersonelIzinDurumu),
        new("Delete PersonelIzinDurumu", FSHAction.Delete, FSHResource.PersonelIzinDurumu),

        // VEM 2.0 - PersonelOdulCeza
        new("View PersonelOdulCeza", FSHAction.View, FSHResource.PersonelOdulCeza),
        new("Search PersonelOdulCeza", FSHAction.Search, FSHResource.PersonelOdulCeza),
        new("Create PersonelOdulCeza", FSHAction.Create, FSHResource.PersonelOdulCeza),
        new("Update PersonelOdulCeza", FSHAction.Update, FSHResource.PersonelOdulCeza),
        new("Delete PersonelOdulCeza", FSHAction.Delete, FSHResource.PersonelOdulCeza),

        // VEM 2.0 - PersonelOgrenim
        new("View PersonelOgrenim", FSHAction.View, FSHResource.PersonelOgrenim),
        new("Search PersonelOgrenim", FSHAction.Search, FSHResource.PersonelOgrenim),
        new("Create PersonelOgrenim", FSHAction.Create, FSHResource.PersonelOgrenim),
        new("Update PersonelOgrenim", FSHAction.Update, FSHResource.PersonelOgrenim),
        new("Delete PersonelOgrenim", FSHAction.Delete, FSHResource.PersonelOgrenim),

        // VEM 2.0 - PersonelYandal
        new("View PersonelYandal", FSHAction.View, FSHResource.PersonelYandal),
        new("Search PersonelYandal", FSHAction.Search, FSHResource.PersonelYandal),
        new("Create PersonelYandal", FSHAction.Create, FSHResource.PersonelYandal),
        new("Update PersonelYandal", FSHAction.Update, FSHResource.PersonelYandal),
        new("Delete PersonelYandal", FSHAction.Delete, FSHResource.PersonelYandal),

        // VEM 2.0 - Radyoloji
        new("View Radyoloji", FSHAction.View, FSHResource.Radyoloji),
        new("Search Radyoloji", FSHAction.Search, FSHResource.Radyoloji),
        new("Create Radyoloji", FSHAction.Create, FSHResource.Radyoloji),
        new("Update Radyoloji", FSHAction.Update, FSHResource.Radyoloji),
        new("Delete Radyoloji", FSHAction.Delete, FSHResource.Radyoloji),

        // VEM 2.0 - RadyolojiSonuc
        new("View RadyolojiSonuc", FSHAction.View, FSHResource.RadyolojiSonuc),
        new("Search RadyolojiSonuc", FSHAction.Search, FSHResource.RadyolojiSonuc),
        new("Create RadyolojiSonuc", FSHAction.Create, FSHResource.RadyolojiSonuc),
        new("Update RadyolojiSonuc", FSHAction.Update, FSHResource.RadyolojiSonuc),
        new("Delete RadyolojiSonuc", FSHAction.Delete, FSHResource.RadyolojiSonuc),

        // VEM 2.0 - Randevu
        new("View Randevu", FSHAction.View, FSHResource.Randevu, IsBasic: true),
        new("Search Randevu", FSHAction.Search, FSHResource.Randevu),
        new("Create Randevu", FSHAction.Create, FSHResource.Randevu),
        new("Update Randevu", FSHAction.Update, FSHResource.Randevu),
        new("Delete Randevu", FSHAction.Delete, FSHResource.Randevu),

        // VEM 2.0 - Recete
        new("View Recete", FSHAction.View, FSHResource.Recete),
        new("Search Recete", FSHAction.Search, FSHResource.Recete),
        new("Create Recete", FSHAction.Create, FSHResource.Recete),
        new("Update Recete", FSHAction.Update, FSHResource.Recete),
        new("Delete Recete", FSHAction.Delete, FSHResource.Recete),

        // VEM 2.0 - ReceteIlac
        new("View ReceteIlac", FSHAction.View, FSHResource.ReceteIlac),
        new("Search ReceteIlac", FSHAction.Search, FSHResource.ReceteIlac),
        new("Create ReceteIlac", FSHAction.Create, FSHResource.ReceteIlac),
        new("Update ReceteIlac", FSHAction.Update, FSHResource.ReceteIlac),
        new("Delete ReceteIlac", FSHAction.Delete, FSHResource.ReceteIlac),

        // VEM 2.0 - ReceteIlacAciklama
        new("View ReceteIlacAciklama", FSHAction.View, FSHResource.ReceteIlacAciklama),
        new("Search ReceteIlacAciklama", FSHAction.Search, FSHResource.ReceteIlacAciklama),
        new("Create ReceteIlacAciklama", FSHAction.Create, FSHResource.ReceteIlacAciklama),
        new("Update ReceteIlacAciklama", FSHAction.Update, FSHResource.ReceteIlacAciklama),
        new("Delete ReceteIlacAciklama", FSHAction.Delete, FSHResource.ReceteIlacAciklama),

        // VEM 2.0 - ReferansKodlar
        new("View ReferansKodlar", FSHAction.View, FSHResource.ReferansKodlar, IsBasic: true),
        new("Search ReferansKodlar", FSHAction.Search, FSHResource.ReferansKodlar),
        new("Create ReferansKodlar", FSHAction.Create, FSHResource.ReferansKodlar),
        new("Update ReferansKodlar", FSHAction.Update, FSHResource.ReferansKodlar),
        new("Delete ReferansKodlar", FSHAction.Delete, FSHResource.ReferansKodlar),

        // VEM 2.0 - RiskSkorlama
        new("View RiskSkorlama", FSHAction.View, FSHResource.RiskSkorlama),
        new("Search RiskSkorlama", FSHAction.Search, FSHResource.RiskSkorlama),
        new("Create RiskSkorlama", FSHAction.Create, FSHResource.RiskSkorlama),
        new("Update RiskSkorlama", FSHAction.Update, FSHResource.RiskSkorlama),
        new("Delete RiskSkorlama", FSHAction.Delete, FSHResource.RiskSkorlama),

        // VEM 2.0 - RiskSkorlamaDetay
        new("View RiskSkorlamaDetay", FSHAction.View, FSHResource.RiskSkorlamaDetay),
        new("Search RiskSkorlamaDetay", FSHAction.Search, FSHResource.RiskSkorlamaDetay),
        new("Create RiskSkorlamaDetay", FSHAction.Create, FSHResource.RiskSkorlamaDetay),
        new("Update RiskSkorlamaDetay", FSHAction.Update, FSHResource.RiskSkorlamaDetay),
        new("Delete RiskSkorlamaDetay", FSHAction.Delete, FSHResource.RiskSkorlamaDetay),

        // VEM 2.0 - SilinenKayitlar
        new("View SilinenKayitlar", FSHAction.View, FSHResource.SilinenKayitlar),
        new("Search SilinenKayitlar", FSHAction.Search, FSHResource.SilinenKayitlar),
        new("Create SilinenKayitlar", FSHAction.Create, FSHResource.SilinenKayitlar),
        new("Update SilinenKayitlar", FSHAction.Update, FSHResource.SilinenKayitlar),
        new("Delete SilinenKayitlar", FSHAction.Delete, FSHResource.SilinenKayitlar),

        // VEM 2.0 - SterilizasyonCikis
        new("View SterilizasyonCikis", FSHAction.View, FSHResource.SterilizasyonCikis),
        new("Search SterilizasyonCikis", FSHAction.Search, FSHResource.SterilizasyonCikis),
        new("Create SterilizasyonCikis", FSHAction.Create, FSHResource.SterilizasyonCikis),
        new("Update SterilizasyonCikis", FSHAction.Update, FSHResource.SterilizasyonCikis),
        new("Delete SterilizasyonCikis", FSHAction.Delete, FSHResource.SterilizasyonCikis),

        // VEM 2.0 - SterilizasyonGiris
        new("View SterilizasyonGiris", FSHAction.View, FSHResource.SterilizasyonGiris),
        new("Search SterilizasyonGiris", FSHAction.Search, FSHResource.SterilizasyonGiris),
        new("Create SterilizasyonGiris", FSHAction.Create, FSHResource.SterilizasyonGiris),
        new("Update SterilizasyonGiris", FSHAction.Update, FSHResource.SterilizasyonGiris),
        new("Delete SterilizasyonGiris", FSHAction.Delete, FSHResource.SterilizasyonGiris),

        // VEM 2.0 - SterilizasyonPaket
        new("View SterilizasyonPaket", FSHAction.View, FSHResource.SterilizasyonPaket),
        new("Search SterilizasyonPaket", FSHAction.Search, FSHResource.SterilizasyonPaket),
        new("Create SterilizasyonPaket", FSHAction.Create, FSHResource.SterilizasyonPaket),
        new("Update SterilizasyonPaket", FSHAction.Update, FSHResource.SterilizasyonPaket),
        new("Delete SterilizasyonPaket", FSHAction.Delete, FSHResource.SterilizasyonPaket),

        // VEM 2.0 - SterilizasyonPaketDetay
        new("View SterilizasyonPaketDetay", FSHAction.View, FSHResource.SterilizasyonPaketDetay),
        new("Search SterilizasyonPaketDetay", FSHAction.Search, FSHResource.SterilizasyonPaketDetay),
        new("Create SterilizasyonPaketDetay", FSHAction.Create, FSHResource.SterilizasyonPaketDetay),
        new("Update SterilizasyonPaketDetay", FSHAction.Update, FSHResource.SterilizasyonPaketDetay),
        new("Delete SterilizasyonPaketDetay", FSHAction.Delete, FSHResource.SterilizasyonPaketDetay),

        // VEM 2.0 - SterilizasyonSet
        new("View SterilizasyonSet", FSHAction.View, FSHResource.SterilizasyonSet),
        new("Search SterilizasyonSet", FSHAction.Search, FSHResource.SterilizasyonSet),
        new("Create SterilizasyonSet", FSHAction.Create, FSHResource.SterilizasyonSet),
        new("Update SterilizasyonSet", FSHAction.Update, FSHResource.SterilizasyonSet),
        new("Delete SterilizasyonSet", FSHAction.Delete, FSHResource.SterilizasyonSet),

        // VEM 2.0 - SterilizasyonSetDetay
        new("View SterilizasyonSetDetay", FSHAction.View, FSHResource.SterilizasyonSetDetay),
        new("Search SterilizasyonSetDetay", FSHAction.Search, FSHResource.SterilizasyonSetDetay),
        new("Create SterilizasyonSetDetay", FSHAction.Create, FSHResource.SterilizasyonSetDetay),
        new("Update SterilizasyonSetDetay", FSHAction.Update, FSHResource.SterilizasyonSetDetay),
        new("Delete SterilizasyonSetDetay", FSHAction.Delete, FSHResource.SterilizasyonSetDetay),

        // VEM 2.0 - SterilizasyonStokDurum
        new("View SterilizasyonStokDurum", FSHAction.View, FSHResource.SterilizasyonStokDurum),
        new("Search SterilizasyonStokDurum", FSHAction.Search, FSHResource.SterilizasyonStokDurum),
        new("Create SterilizasyonStokDurum", FSHAction.Create, FSHResource.SterilizasyonStokDurum),
        new("Update SterilizasyonStokDurum", FSHAction.Update, FSHResource.SterilizasyonStokDurum),
        new("Delete SterilizasyonStokDurum", FSHAction.Delete, FSHResource.SterilizasyonStokDurum),

        // VEM 2.0 - SterilizasyonYikama
        new("View SterilizasyonYikama", FSHAction.View, FSHResource.SterilizasyonYikama),
        new("Search SterilizasyonYikama", FSHAction.Search, FSHResource.SterilizasyonYikama),
        new("Create SterilizasyonYikama", FSHAction.Create, FSHResource.SterilizasyonYikama),
        new("Update SterilizasyonYikama", FSHAction.Update, FSHResource.SterilizasyonYikama),
        new("Delete SterilizasyonYikama", FSHAction.Delete, FSHResource.SterilizasyonYikama),

        // VEM 2.0 - StokDurum
        new("View StokDurum", FSHAction.View, FSHResource.StokDurum),
        new("Search StokDurum", FSHAction.Search, FSHResource.StokDurum),
        new("Create StokDurum", FSHAction.Create, FSHResource.StokDurum),
        new("Update StokDurum", FSHAction.Update, FSHResource.StokDurum),
        new("Delete StokDurum", FSHAction.Delete, FSHResource.StokDurum),

        // VEM 2.0 - StokEhuTakip
        new("View StokEhuTakip", FSHAction.View, FSHResource.StokEhuTakip),
        new("Search StokEhuTakip", FSHAction.Search, FSHResource.StokEhuTakip),
        new("Create StokEhuTakip", FSHAction.Create, FSHResource.StokEhuTakip),
        new("Update StokEhuTakip", FSHAction.Update, FSHResource.StokEhuTakip),
        new("Delete StokEhuTakip", FSHAction.Delete, FSHResource.StokEhuTakip),

        // VEM 2.0 - StokFis
        new("View StokFis", FSHAction.View, FSHResource.StokFis),
        new("Search StokFis", FSHAction.Search, FSHResource.StokFis),
        new("Create StokFis", FSHAction.Create, FSHResource.StokFis),
        new("Update StokFis", FSHAction.Update, FSHResource.StokFis),
        new("Delete StokFis", FSHAction.Delete, FSHResource.StokFis),

        // VEM 2.0 - StokHareket
        new("View StokHareket", FSHAction.View, FSHResource.StokHareket),
        new("Search StokHareket", FSHAction.Search, FSHResource.StokHareket),
        new("Create StokHareket", FSHAction.Create, FSHResource.StokHareket),
        new("Update StokHareket", FSHAction.Update, FSHResource.StokHareket),
        new("Delete StokHareket", FSHAction.Delete, FSHResource.StokHareket),

        // VEM 2.0 - StokIstek
        new("View StokIstek", FSHAction.View, FSHResource.StokIstek),
        new("Search StokIstek", FSHAction.Search, FSHResource.StokIstek),
        new("Create StokIstek", FSHAction.Create, FSHResource.StokIstek),
        new("Update StokIstek", FSHAction.Update, FSHResource.StokIstek),
        new("Delete StokIstek", FSHAction.Delete, FSHResource.StokIstek),

        // VEM 2.0 - StokIstekHareket
        new("View StokIstekHareket", FSHAction.View, FSHResource.StokIstekHareket),
        new("Search StokIstekHareket", FSHAction.Search, FSHResource.StokIstekHareket),
        new("Create StokIstekHareket", FSHAction.Create, FSHResource.StokIstekHareket),
        new("Update StokIstekHareket", FSHAction.Update, FSHResource.StokIstekHareket),
        new("Delete StokIstekHareket", FSHAction.Delete, FSHResource.StokIstekHareket),

        // VEM 2.0 - StokIstekUygulama
        new("View StokIstekUygulama", FSHAction.View, FSHResource.StokIstekUygulama),
        new("Search StokIstekUygulama", FSHAction.Search, FSHResource.StokIstekUygulama),
        new("Create StokIstekUygulama", FSHAction.Create, FSHResource.StokIstekUygulama),
        new("Update StokIstekUygulama", FSHAction.Update, FSHResource.StokIstekUygulama),
        new("Delete StokIstekUygulama", FSHAction.Delete, FSHResource.StokIstekUygulama),

        // VEM 2.0 - StokKart
        new("View StokKart", FSHAction.View, FSHResource.StokKart),
        new("Search StokKart", FSHAction.Search, FSHResource.StokKart),
        new("Create StokKart", FSHAction.Create, FSHResource.StokKart),
        new("Update StokKart", FSHAction.Update, FSHResource.StokKart),
        new("Delete StokKart", FSHAction.Delete, FSHResource.StokKart),

        // VEM 2.0 - SysPaket
        new("View SysPaket", FSHAction.View, FSHResource.SysPaket),
        new("Search SysPaket", FSHAction.Search, FSHResource.SysPaket),
        new("Create SysPaket", FSHAction.Create, FSHResource.SysPaket),
        new("Update SysPaket", FSHAction.Update, FSHResource.SysPaket),
        new("Delete SysPaket", FSHAction.Delete, FSHResource.SysPaket),

        // VEM 2.0 - Tetkik
        new("View Tetkik", FSHAction.View, FSHResource.Tetkik),
        new("Search Tetkik", FSHAction.Search, FSHResource.Tetkik),
        new("Create Tetkik", FSHAction.Create, FSHResource.Tetkik),
        new("Update Tetkik", FSHAction.Update, FSHResource.Tetkik),
        new("Delete Tetkik", FSHAction.Delete, FSHResource.Tetkik),

        // VEM 2.0 - TetkikCihazEslesme
        new("View TetkikCihazEslesme", FSHAction.View, FSHResource.TetkikCihazEslesme),
        new("Search TetkikCihazEslesme", FSHAction.Search, FSHResource.TetkikCihazEslesme),
        new("Create TetkikCihazEslesme", FSHAction.Create, FSHResource.TetkikCihazEslesme),
        new("Update TetkikCihazEslesme", FSHAction.Update, FSHResource.TetkikCihazEslesme),
        new("Delete TetkikCihazEslesme", FSHAction.Delete, FSHResource.TetkikCihazEslesme),

        // VEM 2.0 - TetkikNumune
        new("View TetkikNumune", FSHAction.View, FSHResource.TetkikNumune),
        new("Search TetkikNumune", FSHAction.Search, FSHResource.TetkikNumune),
        new("Create TetkikNumune", FSHAction.Create, FSHResource.TetkikNumune),
        new("Update TetkikNumune", FSHAction.Update, FSHResource.TetkikNumune),
        new("Delete TetkikNumune", FSHAction.Delete, FSHResource.TetkikNumune),

        // VEM 2.0 - TetkikParametre
        new("View TetkikParametre", FSHAction.View, FSHResource.TetkikParametre),
        new("Search TetkikParametre", FSHAction.Search, FSHResource.TetkikParametre),
        new("Create TetkikParametre", FSHAction.Create, FSHResource.TetkikParametre),
        new("Update TetkikParametre", FSHAction.Update, FSHResource.TetkikParametre),
        new("Delete TetkikParametre", FSHAction.Delete, FSHResource.TetkikParametre),

        // VEM 2.0 - TetkikReferansAralik
        new("View TetkikReferansAralik", FSHAction.View, FSHResource.TetkikReferansAralik),
        new("Search TetkikReferansAralik", FSHAction.Search, FSHResource.TetkikReferansAralik),
        new("Create TetkikReferansAralik", FSHAction.Create, FSHResource.TetkikReferansAralik),
        new("Update TetkikReferansAralik", FSHAction.Update, FSHResource.TetkikReferansAralik),
        new("Delete TetkikReferansAralik", FSHAction.Delete, FSHResource.TetkikReferansAralik),

        // VEM 2.0 - TetkikSonuc
        new("View TetkikSonuc", FSHAction.View, FSHResource.TetkikSonuc),
        new("Search TetkikSonuc", FSHAction.Search, FSHResource.TetkikSonuc),
        new("Create TetkikSonuc", FSHAction.Create, FSHResource.TetkikSonuc),
        new("Update TetkikSonuc", FSHAction.Update, FSHResource.TetkikSonuc),
        new("Delete TetkikSonuc", FSHAction.Delete, FSHResource.TetkikSonuc),

        // VEM 2.0 - TibbiOrder
        new("View TibbiOrder", FSHAction.View, FSHResource.TibbiOrder),
        new("Search TibbiOrder", FSHAction.Search, FSHResource.TibbiOrder),
        new("Create TibbiOrder", FSHAction.Create, FSHResource.TibbiOrder),
        new("Update TibbiOrder", FSHAction.Update, FSHResource.TibbiOrder),
        new("Delete TibbiOrder", FSHAction.Delete, FSHResource.TibbiOrder),

        // VEM 2.0 - TibbiOrderDetay
        new("View TibbiOrderDetay", FSHAction.View, FSHResource.TibbiOrderDetay),
        new("Search TibbiOrderDetay", FSHAction.Search, FSHResource.TibbiOrderDetay),
        new("Create TibbiOrderDetay", FSHAction.Create, FSHResource.TibbiOrderDetay),
        new("Update TibbiOrderDetay", FSHAction.Update, FSHResource.TibbiOrderDetay),
        new("Delete TibbiOrderDetay", FSHAction.Delete, FSHResource.TibbiOrderDetay),

        // VEM 2.0 - Vezne
        new("View Vezne", FSHAction.View, FSHResource.Vezne),
        new("Search Vezne", FSHAction.Search, FSHResource.Vezne),
        new("Create Vezne", FSHAction.Create, FSHResource.Vezne),
        new("Update Vezne", FSHAction.Update, FSHResource.Vezne),
        new("Delete Vezne", FSHAction.Delete, FSHResource.Vezne),

        // VEM 2.0 - VezneDetay
        new("View VezneDetay", FSHAction.View, FSHResource.VezneDetay),
        new("Search VezneDetay", FSHAction.Search, FSHResource.VezneDetay),
        new("Create VezneDetay", FSHAction.Create, FSHResource.VezneDetay),
        new("Update VezneDetay", FSHAction.Update, FSHResource.VezneDetay),
        new("Delete VezneDetay", FSHAction.Delete, FSHResource.VezneDetay),

        // VEM 2.0 - Yatak
        new("View Yatak", FSHAction.View, FSHResource.Yatak),
        new("Search Yatak", FSHAction.Search, FSHResource.Yatak),
        new("Create Yatak", FSHAction.Create, FSHResource.Yatak),
        new("Update Yatak", FSHAction.Update, FSHResource.Yatak),
        new("Delete Yatak", FSHAction.Delete, FSHResource.Yatak),
    };

    public static IReadOnlyList<FSHPermission> All { get; } = new ReadOnlyCollection<FSHPermission>(_all);
    public static IReadOnlyList<FSHPermission> Root { get; } = new ReadOnlyCollection<FSHPermission>(_all.Where(p => p.IsRoot).ToArray());
    public static IReadOnlyList<FSHPermission> Admin { get; } = new ReadOnlyCollection<FSHPermission>(_all.Where(p => !p.IsRoot).ToArray());
    public static IReadOnlyList<FSHPermission> Basic { get; } = new ReadOnlyCollection<FSHPermission>(_all.Where(p => p.IsBasic).ToArray());
}

public record FSHPermission(string Description, string Action, string Resource, bool IsBasic = false, bool IsRoot = false)
{
    public string Name => NameFor(Action, Resource);
    public static string NameFor(string action, string resource) => $"Permissions.{resource}.{action}";
}
