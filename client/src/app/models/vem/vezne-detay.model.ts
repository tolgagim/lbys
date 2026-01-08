// VezneDetay Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface VezneDetayDto extends VemBaseDto {
  vezneDetayKodu: string;
  referansTabloAdi: string;
  vezneKodu: string;
  hastaHizmetKodu: string;
  hastaMalzemeKodu: string;
  butceKodu: string;
  makbuzKalemTutari: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListVezneDetayDto {
  id: string;
  vezneDetayKodu: string;
  referansTabloAdi: string;
  vezneKodu: string;
  hastaHizmetKodu: string;
  hastaMalzemeKodu: string;
  butceKodu: string;
  makbuzKalemTutari: string;
  ekleyenKullaniciKodu?: string;
}

export interface CreateVezneDetayDto {
  vezneDetayKodu: string;
  referansTabloAdi: string;
  vezneKodu: string;
  hastaHizmetKodu: string;
  hastaMalzemeKodu: string;
  butceKodu: string;
  makbuzKalemTutari: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateVezneDetayDto extends CreateVezneDetayDto {
  id: string;
}

export interface VezneDetayListFilter extends BaseListFilter {
  vezneDetayKodu?: string;
  referansTabloAdi?: string;
  vezneKodu?: string;
  hastaHizmetKodu?: string;
  hastaMalzemeKodu?: string;
}

export const newVezneDetay: CreateVezneDetayDto = {
  vezneDetayKodu: '',
  referansTabloAdi: '',
  vezneKodu: '',
  hastaHizmetKodu: '',
  hastaMalzemeKodu: '',
  butceKodu: '',
  makbuzKalemTutari: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
