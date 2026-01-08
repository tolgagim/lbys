// EkOdemeDonem Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface EkOdemeDonemDto extends VemBaseDto {
  ekOdemeDonemKodu: string;
  referansTabloAdi: string;
  yil: string;
  ay: string;
  bordroNumarasi: string;
  girisimselIslemPuanToplami: string;
  ozellikliIslemPuanToplami: string;
  acgkToplami: string;
  dagitilacakEkodemeTutari: string;
  ekOdemeKatsayisi: string;
  hastanePuanOrtalamasi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListEkOdemeDonemDto {
  id: string;
  ekOdemeDonemKodu: string;
  referansTabloAdi: string;
  yil: string;
  ay: string;
  bordroNumarasi: string;
  girisimselIslemPuanToplami: string;
  ozellikliIslemPuanToplami: string;
  acgkToplami: string;
}

export interface CreateEkOdemeDonemDto {
  ekOdemeDonemKodu: string;
  referansTabloAdi: string;
  yil: string;
  ay: string;
  bordroNumarasi: string;
  girisimselIslemPuanToplami: string;
  ozellikliIslemPuanToplami: string;
  acgkToplami: string;
  dagitilacakEkodemeTutari: string;
  ekOdemeKatsayisi: string;
  hastanePuanOrtalamasi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateEkOdemeDonemDto extends CreateEkOdemeDonemDto {
  id: string;
}

export interface EkOdemeDonemListFilter extends BaseListFilter {
  ekOdemeDonemKodu?: string;
  referansTabloAdi?: string;
  yil?: string;
  ay?: string;
  bordroNumarasi?: string;
}

export const newEkOdemeDonem: CreateEkOdemeDonemDto = {
  ekOdemeDonemKodu: '',
  referansTabloAdi: '',
  yil: '',
  ay: '',
  bordroNumarasi: '',
  girisimselIslemPuanToplami: '',
  ozellikliIslemPuanToplami: '',
  acgkToplami: '',
  dagitilacakEkodemeTutari: '',
  ekOdemeKatsayisi: '',
  hastanePuanOrtalamasi: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
