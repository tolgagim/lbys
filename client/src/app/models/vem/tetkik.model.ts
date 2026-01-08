// Tetkik Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface TetkikDto extends VemBaseDto {
  tetkikKodu: string;
  tetkikAdi?: string;
  loincKodu?: string;
  hizmetKodu?: string;
  raporSonucSirasi?: string;
  hesaplamaliTetkikBilgisi?: string;
  hesaplamaliTetkikFormulu?: string;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListTetkikDto {
  id: string;
  tetkikKodu: string;
  tetkikAdi?: string;
  loincKodu?: string;
  hizmetKodu?: string;
  raporSonucSirasi?: string;
  hesaplamaliTetkikBilgisi?: string;
  hesaplamaliTetkikFormulu?: string;
  aktif: boolean;
}

export interface CreateTetkikDto {
  tetkikKodu: string;
  tetkikAdi?: string;
  loincKodu?: string;
  hizmetKodu?: string;
  raporSonucSirasi?: string;
  hesaplamaliTetkikBilgisi?: string;
  hesaplamaliTetkikFormulu?: string;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateTetkikDto extends CreateTetkikDto {
  id: string;
}

export interface TetkikListFilter extends BaseListFilter {
  tetkikKodu?: string;
  tetkikAdi?: string;
  loincKodu?: string;
  hizmetKodu?: string;
  raporSonucSirasi?: string;
}

export const newTetkik: CreateTetkikDto = {
  tetkikKodu: '',
  tetkikAdi: '',
  loincKodu: '',
  hizmetKodu: '',
  raporSonucSirasi: '',
  hesaplamaliTetkikBilgisi: '',
  hesaplamaliTetkikFormulu: '',
  aktif: false,
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
