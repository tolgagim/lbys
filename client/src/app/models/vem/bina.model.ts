// Bina Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface BinaDto extends VemBaseDto {
  binaKodu: string;
  binaAdi?: string;
  binaAdresi?: string;
  skrsKurumKodu?: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListBinaDto {
  id: string;
  binaKodu: string;
  binaAdi?: string;
  binaAdresi?: string;
  skrsKurumKodu?: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface CreateBinaDto {
  binaKodu: string;
  binaAdi?: string;
  binaAdresi?: string;
  skrsKurumKodu?: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateBinaDto extends CreateBinaDto {
  id: string;
}

export interface BinaListFilter extends BaseListFilter {
  binaKodu?: string;
  binaAdi?: string;
  binaAdresi?: string;
  skrsKurumKodu?: string;
  ekleyenKullaniciKodu?: string;
}

export const newBina: CreateBinaDto = {
  binaKodu: '',
  binaAdi: '',
  binaAdresi: '',
  skrsKurumKodu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
