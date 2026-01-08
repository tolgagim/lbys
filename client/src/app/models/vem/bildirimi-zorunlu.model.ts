// BildirimiZorunlu Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface BildirimiZorunluDto extends VemBaseDto {
  bildirimiZorunluKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  bildirimTuru: string;
  bildirimZamani?: Date;
  taniKodu: string;
  ailesindeIntiharGirisimi: string;
  ailesindePsikiyatrikVaka: string;
  intiharKrizVakaTuru: string;
  olayZamani: Date;
  psikiyatrikTedaviGecmisi: string;
  intiharGirisimKrizNedenleri: string;
  intiharGirisimiYontemi: string;
  intiharGirisimiGecmisi: string;
  intiharKrizVakaSonucu: string;
  psikiyatrikTaniGecmisi: string;
  hayvaninMevcutDurumu: string;
  hayvaninSahiplikDurumu: string;
  immunglobulinTuru: string;
  immunglobulinMiktari: string;
  kategorizasyon: string;
  temasDegerlendirmeDurumu: string;
  kuduzSebepOlanHayvan: string;
  yaptiracaginiBeyanEttigiTsm: string;
  riskliTemasTipi: string;
  evTelefonu: string;
  cepTelefonu: string;
  evAdresi: string;
  ilKodu: string;
  ilceKodu: string;
  bcgSkarSayisi: string;
  dgtUygulamasiniYapanKisi: string;
  dgtUygulamaYeri: string;
  hastaninTedaviyeUyumu: string;
  kulturSonucu: string;
  tuberkulinDeriTestiSonucu: string;
  veremHastasiTedaviYontemi: string;
  veremOlguTanimi: string;
  yaymaSonucu: string;
  veremHastaligiTutulumYeri: string;
  veremHastasiKlinikOrnegi: string;
  veremIlacAdi: string;
  veremTedaviSonucu: string;
  bulasiciHastalikVakaTipi: string;
  belirtilerinBasladigiTarih: Date;
  siddetTuru: string;
  siddetDegerlendirmeSonucu: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListBildirimiZorunluDto {
  id: string;
  bildirimiZorunluKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  bildirimTuru: string;
  bildirimZamani?: Date;
  taniKodu: string;
  ailesindeIntiharGirisimi: string;
}

export interface CreateBildirimiZorunluDto {
  bildirimiZorunluKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  bildirimTuru: string;
  bildirimZamani?: Date;
  taniKodu: string;
  ailesindeIntiharGirisimi: string;
  ailesindePsikiyatrikVaka: string;
  intiharKrizVakaTuru: string;
  olayZamani: Date;
  psikiyatrikTedaviGecmisi: string;
  intiharGirisimKrizNedenleri: string;
  intiharGirisimiYontemi: string;
  intiharGirisimiGecmisi: string;
  intiharKrizVakaSonucu: string;
  psikiyatrikTaniGecmisi: string;
  hayvaninMevcutDurumu: string;
  hayvaninSahiplikDurumu: string;
  immunglobulinTuru: string;
  immunglobulinMiktari: string;
  kategorizasyon: string;
  temasDegerlendirmeDurumu: string;
  kuduzSebepOlanHayvan: string;
  yaptiracaginiBeyanEttigiTsm: string;
  riskliTemasTipi: string;
  evTelefonu: string;
  cepTelefonu: string;
  evAdresi: string;
  ilKodu: string;
  ilceKodu: string;
  bcgSkarSayisi: string;
  dgtUygulamasiniYapanKisi: string;
  dgtUygulamaYeri: string;
  hastaninTedaviyeUyumu: string;
  kulturSonucu: string;
  tuberkulinDeriTestiSonucu: string;
  veremHastasiTedaviYontemi: string;
  veremOlguTanimi: string;
  yaymaSonucu: string;
  veremHastaligiTutulumYeri: string;
  veremHastasiKlinikOrnegi: string;
  veremIlacAdi: string;
  veremTedaviSonucu: string;
  bulasiciHastalikVakaTipi: string;
  belirtilerinBasladigiTarih: Date;
  siddetTuru: string;
  siddetDegerlendirmeSonucu: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateBildirimiZorunluDto extends CreateBildirimiZorunluDto {
  id: string;
}

export interface BildirimiZorunluListFilter extends BaseListFilter {
  bildirimiZorunluKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  bildirimTuru?: string;
}

export const newBildirimiZorunlu: CreateBildirimiZorunluDto = {
  bildirimiZorunluKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  bildirimTuru: '',
  bildirimZamani: undefined,
  taniKodu: '',
  ailesindeIntiharGirisimi: '',
  ailesindePsikiyatrikVaka: '',
  intiharKrizVakaTuru: '',
  olayZamani: undefined,
  psikiyatrikTedaviGecmisi: '',
  intiharGirisimKrizNedenleri: '',
  intiharGirisimiYontemi: '',
  intiharGirisimiGecmisi: '',
  intiharKrizVakaSonucu: '',
  psikiyatrikTaniGecmisi: '',
  hayvaninMevcutDurumu: '',
  hayvaninSahiplikDurumu: '',
  immunglobulinTuru: '',
  immunglobulinMiktari: '',
  kategorizasyon: '',
  temasDegerlendirmeDurumu: '',
  kuduzSebepOlanHayvan: '',
  yaptiracaginiBeyanEttigiTsm: '',
  riskliTemasTipi: '',
  evTelefonu: '',
  cepTelefonu: '',
  evAdresi: '',
  ilKodu: '',
  ilceKodu: '',
  bcgSkarSayisi: '',
  dgtUygulamasiniYapanKisi: '',
  dgtUygulamaYeri: '',
  hastaninTedaviyeUyumu: '',
  kulturSonucu: '',
  tuberkulinDeriTestiSonucu: '',
  veremHastasiTedaviYontemi: '',
  veremOlguTanimi: '',
  yaymaSonucu: '',
  veremHastaligiTutulumYeri: '',
  veremHastasiKlinikOrnegi: '',
  veremIlacAdi: '',
  veremTedaviSonucu: '',
  bulasiciHastalikVakaTipi: '',
  belirtilerinBasladigiTarih: undefined,
  siddetTuru: '',
  siddetDegerlendirmeSonucu: '',
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
