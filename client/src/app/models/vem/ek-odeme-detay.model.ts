// EkOdemeDetay Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface EkOdemeDetayDto extends VemBaseDto {
  ekOdemeDetayKodu: string;
  referansTabloAdi: string;
  ekOdemeKodu: string;
  gorevNumarasi: string;
  kadroKodu: string;
  kadroKatsayisi: string;
  girisimselIslemPuani: string;
  ozellikliIslemPuani: string;
  tavanKatsayisi: string;
  calisilanGunToplami: string;
  calisilanSaatToplami: string;
  aktifCalisilanGunKatsayisi: string;
  hastanePuanOrtalamasi: string;
  klinikKodu: string;
  klinikPuanOrtalamasi: string;
  brutPerformansPuani: string;
  ekPerformansPuani: string;
  netPerformansPuani: string;
  egiticiDesteklemePuani: string;
  bilimselCalismaPuani: string;
  serbestMeslekKatsayisi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListEkOdemeDetayDto {
  id: string;
  ekOdemeDetayKodu: string;
  referansTabloAdi: string;
  ekOdemeKodu: string;
  gorevNumarasi: string;
  kadroKodu: string;
  kadroKatsayisi: string;
  girisimselIslemPuani: string;
  ozellikliIslemPuani: string;
}

export interface CreateEkOdemeDetayDto {
  ekOdemeDetayKodu: string;
  referansTabloAdi: string;
  ekOdemeKodu: string;
  gorevNumarasi: string;
  kadroKodu: string;
  kadroKatsayisi: string;
  girisimselIslemPuani: string;
  ozellikliIslemPuani: string;
  tavanKatsayisi: string;
  calisilanGunToplami: string;
  calisilanSaatToplami: string;
  aktifCalisilanGunKatsayisi: string;
  hastanePuanOrtalamasi: string;
  klinikKodu: string;
  klinikPuanOrtalamasi: string;
  brutPerformansPuani: string;
  ekPerformansPuani: string;
  netPerformansPuani: string;
  egiticiDesteklemePuani: string;
  bilimselCalismaPuani: string;
  serbestMeslekKatsayisi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateEkOdemeDetayDto extends CreateEkOdemeDetayDto {
  id: string;
}

export interface EkOdemeDetayListFilter extends BaseListFilter {
  ekOdemeDetayKodu?: string;
  referansTabloAdi?: string;
  ekOdemeKodu?: string;
  gorevNumarasi?: string;
  kadroKodu?: string;
}

export const newEkOdemeDetay: CreateEkOdemeDetayDto = {
  ekOdemeDetayKodu: '',
  referansTabloAdi: '',
  ekOdemeKodu: '',
  gorevNumarasi: '',
  kadroKodu: '',
  kadroKatsayisi: '',
  girisimselIslemPuani: '',
  ozellikliIslemPuani: '',
  tavanKatsayisi: '',
  calisilanGunToplami: '',
  calisilanSaatToplami: '',
  aktifCalisilanGunKatsayisi: '',
  hastanePuanOrtalamasi: '',
  klinikKodu: '',
  klinikPuanOrtalamasi: '',
  brutPerformansPuani: '',
  ekPerformansPuani: '',
  netPerformansPuani: '',
  egiticiDesteklemePuani: '',
  bilimselCalismaPuani: '',
  serbestMeslekKatsayisi: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
