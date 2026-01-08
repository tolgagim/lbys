// SterilizasyonGiris Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface SterilizasyonGirisDto extends VemBaseDto {
  sterilizasyonGirisKodu: string;
  referansTabloAdi: string;
  depoKodu: string;
  stokKartKodu: string;
  sterilizasyonGirisMiktari: string;
  teslimEdenBirimKodu: string;
  teslimEdenPersonelKodu: string;
  teslimZamani?: Date;
  teslimAlanPersonelKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListSterilizasyonGirisDto {
  id: string;
  sterilizasyonGirisKodu: string;
  referansTabloAdi: string;
  depoKodu: string;
  stokKartKodu: string;
  sterilizasyonGirisMiktari: string;
  teslimEdenBirimKodu: string;
  teslimEdenPersonelKodu: string;
  teslimZamani?: Date;
}

export interface CreateSterilizasyonGirisDto {
  sterilizasyonGirisKodu: string;
  referansTabloAdi: string;
  depoKodu: string;
  stokKartKodu: string;
  sterilizasyonGirisMiktari: string;
  teslimEdenBirimKodu: string;
  teslimEdenPersonelKodu: string;
  teslimZamani?: Date;
  teslimAlanPersonelKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateSterilizasyonGirisDto extends CreateSterilizasyonGirisDto {
  id: string;
}

export interface SterilizasyonGirisListFilter extends BaseListFilter {
  sterilizasyonGirisKodu?: string;
  referansTabloAdi?: string;
  depoKodu?: string;
  stokKartKodu?: string;
  sterilizasyonGirisMiktari?: string;
}

export const newSterilizasyonGiris: CreateSterilizasyonGirisDto = {
  sterilizasyonGirisKodu: '',
  referansTabloAdi: '',
  depoKodu: '',
  stokKartKodu: '',
  sterilizasyonGirisMiktari: '',
  teslimEdenBirimKodu: '',
  teslimEdenPersonelKodu: '',
  teslimZamani: undefined,
  teslimAlanPersonelKodu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
