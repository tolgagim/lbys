// SilinenKayitlar Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface SilinenKayitlarDto extends VemBaseDto {
  silinenKayitlarKodu: string;
  referansGoruntuAdi: string;
  silinmeZamani?: Date;
  silinenKaydinKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListSilinenKayitlarDto {
  id: string;
  silinenKayitlarKodu: string;
  referansGoruntuAdi: string;
  silinmeZamani?: Date;
  silinenKaydinKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface CreateSilinenKayitlarDto {
  silinenKayitlarKodu: string;
  referansGoruntuAdi: string;
  silinmeZamani?: Date;
  silinenKaydinKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateSilinenKayitlarDto extends CreateSilinenKayitlarDto {
  id: string;
}

export interface SilinenKayitlarListFilter extends BaseListFilter {
  silinenKayitlarKodu?: string;
  referansGoruntuAdi?: string;
  silinenKaydinKodu?: string;
  ekleyenKullaniciKodu?: string;
  guncelleyenKullaniciKodu?: string;
}

export const newSilinenKayitlar: CreateSilinenKayitlarDto = {
  silinenKayitlarKodu: '',
  referansGoruntuAdi: '',
  silinmeZamani: undefined,
  silinenKaydinKodu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
