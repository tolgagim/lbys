// SterilizasyonSetDetay Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface SterilizasyonSetDetayDto extends VemBaseDto {
  sterilizasyonSetDetayKodu: string;
  referansTabloAdi: string;
  sterilizasyonSetKodu: string;
  stokKartKodu: string;
  sterilizasyonMalzemeMiktari: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListSterilizasyonSetDetayDto {
  id: string;
  sterilizasyonSetDetayKodu: string;
  referansTabloAdi: string;
  sterilizasyonSetKodu: string;
  stokKartKodu: string;
  sterilizasyonMalzemeMiktari: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
}

export interface CreateSterilizasyonSetDetayDto {
  sterilizasyonSetDetayKodu: string;
  referansTabloAdi: string;
  sterilizasyonSetKodu: string;
  stokKartKodu: string;
  sterilizasyonMalzemeMiktari: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateSterilizasyonSetDetayDto extends CreateSterilizasyonSetDetayDto {
  id: string;
}

export interface SterilizasyonSetDetayListFilter extends BaseListFilter {
  sterilizasyonSetDetayKodu?: string;
  referansTabloAdi?: string;
  sterilizasyonSetKodu?: string;
  stokKartKodu?: string;
  sterilizasyonMalzemeMiktari?: string;
}

export const newSterilizasyonSetDetay: CreateSterilizasyonSetDetayDto = {
  sterilizasyonSetDetayKodu: '',
  referansTabloAdi: '',
  sterilizasyonSetKodu: '',
  stokKartKodu: '',
  sterilizasyonMalzemeMiktari: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
