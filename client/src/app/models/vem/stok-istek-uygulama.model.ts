// StokIstekUygulama Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface StokIstekUygulamaDto extends VemBaseDto {
  stokIstekUygulamaKodu: string;
  referansTabloAdi: string;
  stokIstekHareketKodu: string;
  orderPlanlananZaman?: Date;
  orderUygulananZaman: Date;
  uygulayanHemsireKodu: string;
  istekIptalNedeni: string;
  iptalEdenHemsireKodu: string;
  iptalZamani: Date;
  uygulananMiktar: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListStokIstekUygulamaDto {
  id: string;
  stokIstekUygulamaKodu: string;
  referansTabloAdi: string;
  stokIstekHareketKodu: string;
  orderPlanlananZaman?: Date;
  orderUygulananZaman: Date;
  uygulayanHemsireKodu: string;
  istekIptalNedeni: string;
  iptalEdenHemsireKodu: string;
}

export interface CreateStokIstekUygulamaDto {
  stokIstekUygulamaKodu: string;
  referansTabloAdi: string;
  stokIstekHareketKodu: string;
  orderPlanlananZaman?: Date;
  orderUygulananZaman: Date;
  uygulayanHemsireKodu: string;
  istekIptalNedeni: string;
  iptalEdenHemsireKodu: string;
  iptalZamani: Date;
  uygulananMiktar: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateStokIstekUygulamaDto extends CreateStokIstekUygulamaDto {
  id: string;
}

export interface StokIstekUygulamaListFilter extends BaseListFilter {
  stokIstekUygulamaKodu?: string;
  referansTabloAdi?: string;
  stokIstekHareketKodu?: string;
  uygulayanHemsireKodu?: string;
  istekIptalNedeni?: string;
}

export const newStokIstekUygulama: CreateStokIstekUygulamaDto = {
  stokIstekUygulamaKodu: '',
  referansTabloAdi: '',
  stokIstekHareketKodu: '',
  orderPlanlananZaman: undefined,
  orderUygulananZaman: undefined,
  uygulayanHemsireKodu: '',
  istekIptalNedeni: '',
  iptalEdenHemsireKodu: '',
  iptalZamani: undefined,
  uygulananMiktar: '',
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
