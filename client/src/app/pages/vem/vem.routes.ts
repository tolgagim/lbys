import { Routes } from '@angular/router';
import { AuthGuardService } from '../../services';

// VEM Component Imports
import { AmeliyatComponent } from './ameliyat/ameliyat.component';
import { AmeliyatEkipComponent } from './ameliyat-ekip/ameliyat-ekip.component';
import { AmeliyatIslemComponent } from './ameliyat-islem/ameliyat-islem.component';
import { AnlikYatanHastaComponent } from './anlik-yatan-hasta/anlik-yatan-hasta.component';
import { AntibiyotikSonucComponent } from './antibiyotik-sonuc/antibiyotik-sonuc.component';
import { AsiBilgisiComponent } from './asi-bilgisi/asi-bilgisi.component';
import { BakteriSonucComponent } from './bakteri-sonuc/bakteri-sonuc.component';
import { BasvuruTaniComponent } from './basvuru-tani/basvuru-tani.component';
import { BasvuruYemekComponent } from './basvuru-yemek/basvuru-yemek.component';
import { BebekCocukIzlemComponent } from './bebek-cocuk-izlem/bebek-cocuk-izlem.component';
import { BildirimiZorunluComponent } from './bildirimi-zorunlu/bildirimi-zorunlu.component';
import { BinaComponent } from './bina/bina.component';
import { BirimComponent } from './birim/birim.component';
import { CihazComponent } from './cihaz/cihaz.component';
import { CocukDiyabetComponent } from './cocuk-diyabet/cocuk-diyabet.component';
import { DepoComponent } from './depo/depo.component';
import { DisTaahhutComponent } from './dis-taahhut/dis-taahhut.component';
import { DisTaahhutDetayComponent } from './dis-taahhut-detay/dis-taahhut-detay.component';
import { DisprotezComponent } from './disprotez/disprotez.component';
import { DisprotezDetayComponent } from './disprotez-detay/disprotez-detay.component';
import { DiyabetComponent } from './diyabet/diyabet.component';
import { DogumComponent } from './dogum/dogum.component';
import { DogumDetayComponent } from './dogum-detay/dogum-detay.component';
import { DoktorMesajiComponent } from './doktor-mesaji/doktor-mesaji.component';
import { EkOdemeComponent } from './ek-odeme/ek-odeme.component';
import { EkOdemeDetayComponent } from './ek-odeme-detay/ek-odeme-detay.component';
import { EkOdemeDonemComponent } from './ek-odeme-donem/ek-odeme-donem.component';
import { EvdeSaglikIzlemComponent } from './evde-saglik-izlem/evde-saglik-izlem.component';
import { FaturaComponent } from './fatura/fatura.component';
import { FirmaComponent } from './firma/firma.component';
import { GebeIzlemComponent } from './gebe-izlem/gebe-izlem.component';
import { GetatComponent } from './getat/getat.component';
import { GrupUyelikComponent } from './grup-uyelik/grup-uyelik.component';
import { HastaComponent } from './hasta/hasta.component';
import { HastaAdliRaporComponent } from './hasta-adli-rapor/hasta-adli-rapor.component';
import { HastaArsivComponent } from './hasta-arsiv/hasta-arsiv.component';
import { HastaArsivDetayComponent } from './hasta-arsiv-detay/hasta-arsiv-detay.component';
import { HastaBasvuruComponent } from './hasta-basvuru/hasta-basvuru.component';
import { HastaBorcComponent } from './hasta-borc/hasta-borc.component';
import { HastaDisComponent } from './hasta-dis/hasta-dis.component';
import { HastaEpikrizComponent } from './hasta-epikriz/hasta-epikriz.component';
import { HastaFotografComponent } from './hasta-fotograf/hasta-fotograf.component';
import { HastaGizlilikComponent } from './hasta-gizlilik/hasta-gizlilik.component';
import { HastaHizmetComponent } from './hasta-hizmet/hasta-hizmet.component';
import { HastaIletisimComponent } from './hasta-iletisim/hasta-iletisim.component';
import { HastaMalzemeComponent } from './hasta-malzeme/hasta-malzeme.component';
import { HastaNotlariComponent } from './hasta-notlari/hasta-notlari.component';
import { HastaOlumComponent } from './hasta-olum/hasta-olum.component';
import { HastaSeansComponent } from './hasta-seans/hasta-seans.component';
import { HastaSevkComponent } from './hasta-sevk/hasta-sevk.component';
import { HastaTibbiBilgiComponent } from './hasta-tibbi-bilgi/hasta-tibbi-bilgi.component';
import { HastaUyariComponent } from './hasta-uyari/hasta-uyari.component';
import { HastaVentilatorComponent } from './hasta-ventilator/hasta-ventilator.component';
import { HastaVitalFizikiBulguComponent } from './hasta-vital-fiziki-bulgu/hasta-vital-fiziki-bulgu.component';
import { HastaYatakComponent } from './hasta-yatak/hasta-yatak.component';
import { HemoglobinopatiComponent } from './hemoglobinopati/hemoglobinopati.component';
import { HemsireBakimComponent } from './hemsire-bakim/hemsire-bakim.component';
import { HizmetComponent } from './hizmet/hizmet.component';
import { IcmalComponent } from './icmal/icmal.component';
import { IlacUyumComponent } from './ilac-uyum/ilac-uyum.component';
import { IntiharIzlemComponent } from './intihar-izlem/intihar-izlem.component';
import { KadinIzlemComponent } from './kadin-izlem/kadin-izlem.component';
import { KanBagisciComponent } from './kan-bagisci/kan-bagisci.component';
import { KanCikisComponent } from './kan-cikis/kan-cikis.component';
import { KanStokComponent } from './kan-stok/kan-stok.component';
import { KanTalepComponent } from './kan-talep/kan-talep.component';
import { KanTalepDetayComponent } from './kan-talep-detay/kan-talep-detay.component';
import { KanUrunComponent } from './kan-urun/kan-urun.component';
import { KanUrunImhaComponent } from './kan-urun-imha/kan-urun-imha.component';
import { KlinikSeyirComponent } from './klinik-seyir/klinik-seyir.component';
import { KonsultasyonComponent } from './konsultasyon/konsultasyon.component';
import { KuduzIzlemComponent } from './kuduz-izlem/kuduz-izlem.component';
import { KullaniciComponent } from './kullanici/kullanici.component';
import { KullaniciGrupComponent } from './kullanici-grup/kullanici-grup.component';
import { KurulComponent } from './kurul/kurul.component';
import { KurulAskeriComponent } from './kurul-askeri/kurul-askeri.component';
import { KurulEngelliComponent } from './kurul-engelli/kurul-engelli.component';
import { KurulEtkenMaddeComponent } from './kurul-etken-madde/kurul-etken-madde.component';
import { KurulHekimComponent } from './kurul-hekim/kurul-hekim.component';
import { KurulRaporComponent } from './kurul-rapor/kurul-rapor.component';
import { KurulTeshisComponent } from './kurul-teshis/kurul-teshis.component';
import { KurumComponent } from './kurum/kurum.component';
import { LohusaIzlemComponent } from './lohusa-izlem/lohusa-izlem.component';
import { MaddeBagimliligiComponent } from './madde-bagimliligi/madde-bagimliligi.component';
import { MedulaTakipComponent } from './medula-takip/medula-takip.component';
import { NobetciPersonelBilgisiComponent } from './nobetci-personel-bilgisi/nobetci-personel-bilgisi.component';
import { ObeziteIzlemComponent } from './obezite-izlem/obezite-izlem.component';
import { OdaComponent } from './oda/oda.component';
import { OptikReceteComponent } from './optik-recete/optik-recete.component';
import { OrtodontiIconSkorComponent } from './ortodonti-icon-skor/ortodonti-icon-skor.component';
import { PatolojiComponent } from './patoloji/patoloji.component';
import { PersonelComponent } from './personel/personel.component';
import { PersonelBakmaklaYukumluComponent } from './personel-bakmakla-yukumlu/personel-bakmakla-yukumlu.component';
import { PersonelBankaComponent } from './personel-banka/personel-banka.component';
import { PersonelBordroComponent } from './personel-bordro/personel-bordro.component';
import { PersonelBordroSondurumComponent } from './personel-bordro-sondurum/personel-bordro-sondurum.component';
import { PersonelEgitimComponent } from './personel-egitim/personel-egitim.component';
import { PersonelGorevlendirmeComponent } from './personel-gorevlendirme/personel-gorevlendirme.component';
import { PersonelIzinComponent } from './personel-izin/personel-izin.component';
import { PersonelIzinDurumuComponent } from './personel-izin-durumu/personel-izin-durumu.component';
import { PersonelOdulCezaComponent } from './personel-odul-ceza/personel-odul-ceza.component';
import { PersonelOgrenimComponent } from './personel-ogrenim/personel-ogrenim.component';
import { PersonelYandalComponent } from './personel-yandal/personel-yandal.component';
import { RadyolojiComponent } from './radyoloji/radyoloji.component';
import { RadyolojiSonucComponent } from './radyoloji-sonuc/radyoloji-sonuc.component';
import { RandevuComponent } from './randevu/randevu.component';
import { ReceteComponent } from './recete/recete.component';
import { ReceteIlacComponent } from './recete-ilac/recete-ilac.component';
import { ReceteIlacAciklamaComponent } from './recete-ilac-aciklama/recete-ilac-aciklama.component';
import { ReferansKodlarComponent } from './referans-kodlar/referans-kodlar.component';
import { RiskSkorlamaComponent } from './risk-skorlama/risk-skorlama.component';
import { RiskSkorlamaDetayComponent } from './risk-skorlama-detay/risk-skorlama-detay.component';
import { SilinenKayitlarComponent } from './silinen-kayitlar/silinen-kayitlar.component';
import { SterilizasyonCikisComponent } from './sterilizasyon-cikis/sterilizasyon-cikis.component';
import { SterilizasyonGirisComponent } from './sterilizasyon-giris/sterilizasyon-giris.component';
import { SterilizasyonPaketComponent } from './sterilizasyon-paket/sterilizasyon-paket.component';
import { SterilizasyonPaketDetayComponent } from './sterilizasyon-paket-detay/sterilizasyon-paket-detay.component';
import { SterilizasyonSetComponent } from './sterilizasyon-set/sterilizasyon-set.component';
import { SterilizasyonSetDetayComponent } from './sterilizasyon-set-detay/sterilizasyon-set-detay.component';
import { SterilizasyonStokDurumComponent } from './sterilizasyon-stok-durum/sterilizasyon-stok-durum.component';
import { SterilizasyonYikamaComponent } from './sterilizasyon-yikama/sterilizasyon-yikama.component';
import { StokDurumComponent } from './stok-durum/stok-durum.component';
import { StokEhuTakipComponent } from './stok-ehu-takip/stok-ehu-takip.component';
import { StokFisComponent } from './stok-fis/stok-fis.component';
import { StokHareketComponent } from './stok-hareket/stok-hareket.component';
import { StokIstekComponent } from './stok-istek/stok-istek.component';
import { StokIstekHareketComponent } from './stok-istek-hareket/stok-istek-hareket.component';
import { StokIstekUygulamaComponent } from './stok-istek-uygulama/stok-istek-uygulama.component';
import { StokKartComponent } from './stok-kart/stok-kart.component';
import { SysPaketComponent } from './sys-paket/sys-paket.component';
import { TetkikComponent } from './tetkik/tetkik.component';
import { TetkikCihazEslesmeComponent } from './tetkik-cihaz-eslesme/tetkik-cihaz-eslesme.component';
import { TetkikNumuneComponent } from './tetkik-numune/tetkik-numune.component';
import { TetkikParametreComponent } from './tetkik-parametre/tetkik-parametre.component';
import { TetkikReferansAralikComponent } from './tetkik-referans-aralik/tetkik-referans-aralik.component';
import { TetkikSonucComponent } from './tetkik-sonuc/tetkik-sonuc.component';
import { TibbiOrderComponent } from './tibbi-order/tibbi-order.component';
import { TibbiOrderDetayComponent } from './tibbi-order-detay/tibbi-order-detay.component';
import { VezneComponent } from './vezne/vezne.component';
import { VezneDetayComponent } from './vezne-detay/vezne-detay.component';
import { YatakComponent } from './yatak/yatak.component';

export const VEM_ROUTES: Routes = [
  { path: 'ameliyat', component: AmeliyatComponent, canActivate: [AuthGuardService] },
  { path: 'ameliyat-ekip', component: AmeliyatEkipComponent, canActivate: [AuthGuardService] },
  { path: 'ameliyat-islem', component: AmeliyatIslemComponent, canActivate: [AuthGuardService] },
  { path: 'anlik-yatan-hasta', component: AnlikYatanHastaComponent, canActivate: [AuthGuardService] },
  { path: 'antibiyotik-sonuc', component: AntibiyotikSonucComponent, canActivate: [AuthGuardService] },
  { path: 'asi-bilgisi', component: AsiBilgisiComponent, canActivate: [AuthGuardService] },
  { path: 'bakteri-sonuc', component: BakteriSonucComponent, canActivate: [AuthGuardService] },
  { path: 'basvuru-tani', component: BasvuruTaniComponent, canActivate: [AuthGuardService] },
  { path: 'basvuru-yemek', component: BasvuruYemekComponent, canActivate: [AuthGuardService] },
  { path: 'bebek-cocuk-izlem', component: BebekCocukIzlemComponent, canActivate: [AuthGuardService] },
  { path: 'bildirimi-zorunlu', component: BildirimiZorunluComponent, canActivate: [AuthGuardService] },
  { path: 'bina', component: BinaComponent, canActivate: [AuthGuardService] },
  { path: 'birim', component: BirimComponent, canActivate: [AuthGuardService] },
  { path: 'cihaz', component: CihazComponent, canActivate: [AuthGuardService] },
  { path: 'cocuk-diyabet', component: CocukDiyabetComponent, canActivate: [AuthGuardService] },
  { path: 'depo', component: DepoComponent, canActivate: [AuthGuardService] },
  { path: 'dis-taahhut', component: DisTaahhutComponent, canActivate: [AuthGuardService] },
  { path: 'dis-taahhut-detay', component: DisTaahhutDetayComponent, canActivate: [AuthGuardService] },
  { path: 'disprotez', component: DisprotezComponent, canActivate: [AuthGuardService] },
  { path: 'disprotez-detay', component: DisprotezDetayComponent, canActivate: [AuthGuardService] },
  { path: 'diyabet', component: DiyabetComponent, canActivate: [AuthGuardService] },
  { path: 'dogum', component: DogumComponent, canActivate: [AuthGuardService] },
  { path: 'dogum-detay', component: DogumDetayComponent, canActivate: [AuthGuardService] },
  { path: 'doktor-mesaji', component: DoktorMesajiComponent, canActivate: [AuthGuardService] },
  { path: 'ek-odeme', component: EkOdemeComponent, canActivate: [AuthGuardService] },
  { path: 'ek-odeme-detay', component: EkOdemeDetayComponent, canActivate: [AuthGuardService] },
  { path: 'ek-odeme-donem', component: EkOdemeDonemComponent, canActivate: [AuthGuardService] },
  { path: 'evde-saglik-izlem', component: EvdeSaglikIzlemComponent, canActivate: [AuthGuardService] },
  { path: 'fatura', component: FaturaComponent, canActivate: [AuthGuardService] },
  { path: 'firma', component: FirmaComponent, canActivate: [AuthGuardService] },
  { path: 'gebe-izlem', component: GebeIzlemComponent, canActivate: [AuthGuardService] },
  { path: 'getat', component: GetatComponent, canActivate: [AuthGuardService] },
  { path: 'grup-uyelik', component: GrupUyelikComponent, canActivate: [AuthGuardService] },
  { path: 'hasta', component: HastaComponent, canActivate: [AuthGuardService] },
  { path: 'hasta-adli-rapor', component: HastaAdliRaporComponent, canActivate: [AuthGuardService] },
  { path: 'hasta-arsiv', component: HastaArsivComponent, canActivate: [AuthGuardService] },
  { path: 'hasta-arsiv-detay', component: HastaArsivDetayComponent, canActivate: [AuthGuardService] },
  { path: 'hasta-basvuru', component: HastaBasvuruComponent, canActivate: [AuthGuardService] },
  { path: 'hasta-borc', component: HastaBorcComponent, canActivate: [AuthGuardService] },
  { path: 'hasta-dis', component: HastaDisComponent, canActivate: [AuthGuardService] },
  { path: 'hasta-epikriz', component: HastaEpikrizComponent, canActivate: [AuthGuardService] },
  { path: 'hasta-fotograf', component: HastaFotografComponent, canActivate: [AuthGuardService] },
  { path: 'hasta-gizlilik', component: HastaGizlilikComponent, canActivate: [AuthGuardService] },
  { path: 'hasta-hizmet', component: HastaHizmetComponent, canActivate: [AuthGuardService] },
  { path: 'hasta-iletisim', component: HastaIletisimComponent, canActivate: [AuthGuardService] },
  { path: 'hasta-malzeme', component: HastaMalzemeComponent, canActivate: [AuthGuardService] },
  { path: 'hasta-notlari', component: HastaNotlariComponent, canActivate: [AuthGuardService] },
  { path: 'hasta-olum', component: HastaOlumComponent, canActivate: [AuthGuardService] },
  { path: 'hasta-seans', component: HastaSeansComponent, canActivate: [AuthGuardService] },
  { path: 'hasta-sevk', component: HastaSevkComponent, canActivate: [AuthGuardService] },
  { path: 'hasta-tibbi-bilgi', component: HastaTibbiBilgiComponent, canActivate: [AuthGuardService] },
  { path: 'hasta-uyari', component: HastaUyariComponent, canActivate: [AuthGuardService] },
  { path: 'hasta-ventilator', component: HastaVentilatorComponent, canActivate: [AuthGuardService] },
  { path: 'hasta-vital-fiziki-bulgu', component: HastaVitalFizikiBulguComponent, canActivate: [AuthGuardService] },
  { path: 'hasta-yatak', component: HastaYatakComponent, canActivate: [AuthGuardService] },
  { path: 'hemoglobinopati', component: HemoglobinopatiComponent, canActivate: [AuthGuardService] },
  { path: 'hemsire-bakim', component: HemsireBakimComponent, canActivate: [AuthGuardService] },
  { path: 'hizmet', component: HizmetComponent, canActivate: [AuthGuardService] },
  { path: 'icmal', component: IcmalComponent, canActivate: [AuthGuardService] },
  { path: 'ilac-uyum', component: IlacUyumComponent, canActivate: [AuthGuardService] },
  { path: 'intihar-izlem', component: IntiharIzlemComponent, canActivate: [AuthGuardService] },
  { path: 'kadin-izlem', component: KadinIzlemComponent, canActivate: [AuthGuardService] },
  { path: 'kan-bagisci', component: KanBagisciComponent, canActivate: [AuthGuardService] },
  { path: 'kan-cikis', component: KanCikisComponent, canActivate: [AuthGuardService] },
  { path: 'kan-stok', component: KanStokComponent, canActivate: [AuthGuardService] },
  { path: 'kan-talep', component: KanTalepComponent, canActivate: [AuthGuardService] },
  { path: 'kan-talep-detay', component: KanTalepDetayComponent, canActivate: [AuthGuardService] },
  { path: 'kan-urun', component: KanUrunComponent, canActivate: [AuthGuardService] },
  { path: 'kan-urun-imha', component: KanUrunImhaComponent, canActivate: [AuthGuardService] },
  { path: 'klinik-seyir', component: KlinikSeyirComponent, canActivate: [AuthGuardService] },
  { path: 'konsultasyon', component: KonsultasyonComponent, canActivate: [AuthGuardService] },
  { path: 'kuduz-izlem', component: KuduzIzlemComponent, canActivate: [AuthGuardService] },
  { path: 'kullanici', component: KullaniciComponent, canActivate: [AuthGuardService] },
  { path: 'kullanici-grup', component: KullaniciGrupComponent, canActivate: [AuthGuardService] },
  { path: 'kurul', component: KurulComponent, canActivate: [AuthGuardService] },
  { path: 'kurul-askeri', component: KurulAskeriComponent, canActivate: [AuthGuardService] },
  { path: 'kurul-engelli', component: KurulEngelliComponent, canActivate: [AuthGuardService] },
  { path: 'kurul-etken-madde', component: KurulEtkenMaddeComponent, canActivate: [AuthGuardService] },
  { path: 'kurul-hekim', component: KurulHekimComponent, canActivate: [AuthGuardService] },
  { path: 'kurul-rapor', component: KurulRaporComponent, canActivate: [AuthGuardService] },
  { path: 'kurul-teshis', component: KurulTeshisComponent, canActivate: [AuthGuardService] },
  { path: 'kurum', component: KurumComponent, canActivate: [AuthGuardService] },
  { path: 'lohusa-izlem', component: LohusaIzlemComponent, canActivate: [AuthGuardService] },
  { path: 'madde-bagimliligi', component: MaddeBagimliligiComponent, canActivate: [AuthGuardService] },
  { path: 'medula-takip', component: MedulaTakipComponent, canActivate: [AuthGuardService] },
  { path: 'nobetci-personel-bilgisi', component: NobetciPersonelBilgisiComponent, canActivate: [AuthGuardService] },
  { path: 'obezite-izlem', component: ObeziteIzlemComponent, canActivate: [AuthGuardService] },
  { path: 'oda', component: OdaComponent, canActivate: [AuthGuardService] },
  { path: 'optik-recete', component: OptikReceteComponent, canActivate: [AuthGuardService] },
  { path: 'ortodonti-icon-skor', component: OrtodontiIconSkorComponent, canActivate: [AuthGuardService] },
  { path: 'patoloji', component: PatolojiComponent, canActivate: [AuthGuardService] },
  { path: 'personel', component: PersonelComponent, canActivate: [AuthGuardService] },
  { path: 'personel-bakmakla-yukumlu', component: PersonelBakmaklaYukumluComponent, canActivate: [AuthGuardService] },
  { path: 'personel-banka', component: PersonelBankaComponent, canActivate: [AuthGuardService] },
  { path: 'personel-bordro', component: PersonelBordroComponent, canActivate: [AuthGuardService] },
  { path: 'personel-bordro-sondurum', component: PersonelBordroSondurumComponent, canActivate: [AuthGuardService] },
  { path: 'personel-egitim', component: PersonelEgitimComponent, canActivate: [AuthGuardService] },
  { path: 'personel-gorevlendirme', component: PersonelGorevlendirmeComponent, canActivate: [AuthGuardService] },
  { path: 'personel-izin', component: PersonelIzinComponent, canActivate: [AuthGuardService] },
  { path: 'personel-izin-durumu', component: PersonelIzinDurumuComponent, canActivate: [AuthGuardService] },
  { path: 'personel-odul-ceza', component: PersonelOdulCezaComponent, canActivate: [AuthGuardService] },
  { path: 'personel-ogrenim', component: PersonelOgrenimComponent, canActivate: [AuthGuardService] },
  { path: 'personel-yandal', component: PersonelYandalComponent, canActivate: [AuthGuardService] },
  { path: 'radyoloji', component: RadyolojiComponent, canActivate: [AuthGuardService] },
  { path: 'radyoloji-sonuc', component: RadyolojiSonucComponent, canActivate: [AuthGuardService] },
  { path: 'randevu', component: RandevuComponent, canActivate: [AuthGuardService] },
  { path: 'recete', component: ReceteComponent, canActivate: [AuthGuardService] },
  { path: 'recete-ilac', component: ReceteIlacComponent, canActivate: [AuthGuardService] },
  { path: 'recete-ilac-aciklama', component: ReceteIlacAciklamaComponent, canActivate: [AuthGuardService] },
  { path: 'referans-kodlar', component: ReferansKodlarComponent, canActivate: [AuthGuardService] },
  { path: 'risk-skorlama', component: RiskSkorlamaComponent, canActivate: [AuthGuardService] },
  { path: 'risk-skorlama-detay', component: RiskSkorlamaDetayComponent, canActivate: [AuthGuardService] },
  { path: 'silinen-kayitlar', component: SilinenKayitlarComponent, canActivate: [AuthGuardService] },
  { path: 'sterilizasyon-cikis', component: SterilizasyonCikisComponent, canActivate: [AuthGuardService] },
  { path: 'sterilizasyon-giris', component: SterilizasyonGirisComponent, canActivate: [AuthGuardService] },
  { path: 'sterilizasyon-paket', component: SterilizasyonPaketComponent, canActivate: [AuthGuardService] },
  { path: 'sterilizasyon-paket-detay', component: SterilizasyonPaketDetayComponent, canActivate: [AuthGuardService] },
  { path: 'sterilizasyon-set', component: SterilizasyonSetComponent, canActivate: [AuthGuardService] },
  { path: 'sterilizasyon-set-detay', component: SterilizasyonSetDetayComponent, canActivate: [AuthGuardService] },
  { path: 'sterilizasyon-stok-durum', component: SterilizasyonStokDurumComponent, canActivate: [AuthGuardService] },
  { path: 'sterilizasyon-yikama', component: SterilizasyonYikamaComponent, canActivate: [AuthGuardService] },
  { path: 'stok-durum', component: StokDurumComponent, canActivate: [AuthGuardService] },
  { path: 'stok-ehu-takip', component: StokEhuTakipComponent, canActivate: [AuthGuardService] },
  { path: 'stok-fis', component: StokFisComponent, canActivate: [AuthGuardService] },
  { path: 'stok-hareket', component: StokHareketComponent, canActivate: [AuthGuardService] },
  { path: 'stok-istek', component: StokIstekComponent, canActivate: [AuthGuardService] },
  { path: 'stok-istek-hareket', component: StokIstekHareketComponent, canActivate: [AuthGuardService] },
  { path: 'stok-istek-uygulama', component: StokIstekUygulamaComponent, canActivate: [AuthGuardService] },
  { path: 'stok-kart', component: StokKartComponent, canActivate: [AuthGuardService] },
  { path: 'sys-paket', component: SysPaketComponent, canActivate: [AuthGuardService] },
  { path: 'tetkik', component: TetkikComponent, canActivate: [AuthGuardService] },
  { path: 'tetkik-cihaz-eslesme', component: TetkikCihazEslesmeComponent, canActivate: [AuthGuardService] },
  { path: 'tetkik-numune', component: TetkikNumuneComponent, canActivate: [AuthGuardService] },
  { path: 'tetkik-parametre', component: TetkikParametreComponent, canActivate: [AuthGuardService] },
  { path: 'tetkik-referans-aralik', component: TetkikReferansAralikComponent, canActivate: [AuthGuardService] },
  { path: 'tetkik-sonuc', component: TetkikSonucComponent, canActivate: [AuthGuardService] },
  { path: 'tibbi-order', component: TibbiOrderComponent, canActivate: [AuthGuardService] },
  { path: 'tibbi-order-detay', component: TibbiOrderDetayComponent, canActivate: [AuthGuardService] },
  { path: 'vezne', component: VezneComponent, canActivate: [AuthGuardService] },
  { path: 'vezne-detay', component: VezneDetayComponent, canActivate: [AuthGuardService] },
  { path: 'yatak', component: YatakComponent, canActivate: [AuthGuardService] },
];
