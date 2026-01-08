// Icmal Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface IcmalDto extends VemBaseDto {
  icmalKodu: string;
  icmalDonemi?: string;
  icmalNumarasi?: string;
  icmalAdi?: string;
  kurumKodu?: string;
  icmalZamani?: Date;
  icmalTutari?: number;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListIcmalDto {
  id: string;
  icmalKodu: string;
  icmalDonemi?: string;
  icmalNumarasi?: string;
  icmalAdi?: string;
  kurumKodu?: string;
  icmalZamani?: Date;
  icmalTutari?: number;
  ekleyenKullaniciKodu?: string;
}

export interface CreateIcmalDto {
  icmalKodu: string;
  icmalDonemi?: string;
  icmalNumarasi?: string;
  icmalAdi?: string;
  kurumKodu?: string;
  icmalZamani?: Date;
  icmalTutari?: number;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateIcmalDto extends CreateIcmalDto {
  id: string;
}

export interface IcmalListFilter extends BaseListFilter {
  icmalKodu?: string;
  icmalDonemi?: string;
  icmalNumarasi?: string;
  icmalAdi?: string;
  kurumKodu?: string;
}

export const newIcmal: CreateIcmalDto = {
  icmalKodu: '',
  icmalDonemi: '',
  icmalNumarasi: '',
  icmalAdi: '',
  kurumKodu: '',
  icmalZamani: undefined,
  icmalTutari: 0,
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
