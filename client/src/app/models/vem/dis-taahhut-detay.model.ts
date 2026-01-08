// DisTaahhutDetay Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface DisTaahhutDetayDto extends VemBaseDto {
  disTaahhutDetayKodu: string;
  referansTabloAdi: string;
  disTaahhutKodu: string;
  disKodu: string;
  sutKodu: string;
  ceneKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListDisTaahhutDetayDto {
  id: string;
  disTaahhutDetayKodu: string;
  referansTabloAdi: string;
  disTaahhutKodu: string;
  disKodu: string;
  sutKodu: string;
  ceneKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
}

export interface CreateDisTaahhutDetayDto {
  disTaahhutDetayKodu: string;
  referansTabloAdi: string;
  disTaahhutKodu: string;
  disKodu: string;
  sutKodu: string;
  ceneKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateDisTaahhutDetayDto extends CreateDisTaahhutDetayDto {
  id: string;
}

export interface DisTaahhutDetayListFilter extends BaseListFilter {
  disTaahhutDetayKodu?: string;
  referansTabloAdi?: string;
  disTaahhutKodu?: string;
  disKodu?: string;
  sutKodu?: string;
}

export const newDisTaahhutDetay: CreateDisTaahhutDetayDto = {
  disTaahhutDetayKodu: '',
  referansTabloAdi: '',
  disTaahhutKodu: '',
  disKodu: '',
  sutKodu: '',
  ceneKodu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
