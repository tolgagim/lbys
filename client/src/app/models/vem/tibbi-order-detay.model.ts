// TibbiOrderDetay Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface TibbiOrderDetayDto extends VemBaseDto {
  tibbiOrderDetayKodu: string;
  referansTabloAdi: string;
  tibbiOrderKodu: string;
  planlananUygulanmaZamani?: Date;
  uygulayanHemsireKodu: string;
  uygulamaZamani: Date;
  uygulanmaDurumu: string;
  tibbiOrderIptalNedeni: string;
  iptalEdenHemsireKodu: string;
  iptalZamani: Date;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListTibbiOrderDetayDto {
  id: string;
  tibbiOrderDetayKodu: string;
  referansTabloAdi: string;
  tibbiOrderKodu: string;
  planlananUygulanmaZamani?: Date;
  uygulayanHemsireKodu: string;
  uygulamaZamani: Date;
  uygulanmaDurumu: string;
  tibbiOrderIptalNedeni: string;
}

export interface CreateTibbiOrderDetayDto {
  tibbiOrderDetayKodu: string;
  referansTabloAdi: string;
  tibbiOrderKodu: string;
  planlananUygulanmaZamani?: Date;
  uygulayanHemsireKodu: string;
  uygulamaZamani: Date;
  uygulanmaDurumu: string;
  tibbiOrderIptalNedeni: string;
  iptalEdenHemsireKodu: string;
  iptalZamani: Date;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateTibbiOrderDetayDto extends CreateTibbiOrderDetayDto {
  id: string;
}

export interface TibbiOrderDetayListFilter extends BaseListFilter {
  tibbiOrderDetayKodu?: string;
  referansTabloAdi?: string;
  tibbiOrderKodu?: string;
  uygulayanHemsireKodu?: string;
  uygulanmaDurumu?: string;
}

export const newTibbiOrderDetay: CreateTibbiOrderDetayDto = {
  tibbiOrderDetayKodu: '',
  referansTabloAdi: '',
  tibbiOrderKodu: '',
  planlananUygulanmaZamani: undefined,
  uygulayanHemsireKodu: '',
  uygulamaZamani: undefined,
  uygulanmaDurumu: '',
  tibbiOrderIptalNedeni: '',
  iptalEdenHemsireKodu: '',
  iptalZamani: undefined,
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
