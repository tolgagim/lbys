// ReferansKodlar Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface ReferansKodlarDto extends VemBaseDto {
  referansKodu: string;
  kodTuru?: string;
  referansAdi?: string;
  skrsKodu: string;
  medulaKodu: string;
  mkysKodu: string;
  tigKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListReferansKodlarDto {
  id: string;
  referansKodu: string;
  kodTuru?: string;
  referansAdi?: string;
  skrsKodu: string;
  medulaKodu: string;
  mkysKodu: string;
  tigKodu: string;
  ekleyenKullaniciKodu?: string;
}

export interface CreateReferansKodlarDto {
  referansKodu: string;
  kodTuru?: string;
  referansAdi?: string;
  skrsKodu: string;
  medulaKodu: string;
  mkysKodu: string;
  tigKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateReferansKodlarDto extends CreateReferansKodlarDto {
  id: string;
}

export interface ReferansKodlarListFilter extends BaseListFilter {
  referansKodu?: string;
  kodTuru?: string;
  referansAdi?: string;
  skrsKodu?: string;
  medulaKodu?: string;
}

export const newReferansKodlar: CreateReferansKodlarDto = {
  referansKodu: '',
  kodTuru: '',
  referansAdi: '',
  skrsKodu: '',
  medulaKodu: '',
  mkysKodu: '',
  tigKodu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
