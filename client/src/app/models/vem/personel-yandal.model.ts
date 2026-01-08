// PersonelYandal Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface PersonelYandalDto extends VemBaseDto {
  personelYandalKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  yandalBaslangicTarihi?: Date;
  yandalBitisTarihi: Date;
  medulaBransKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListPersonelYandalDto {
  id: string;
  personelYandalKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  yandalBaslangicTarihi?: Date;
  yandalBitisTarihi: Date;
  medulaBransKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
}

export interface CreatePersonelYandalDto {
  personelYandalKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  yandalBaslangicTarihi?: Date;
  yandalBitisTarihi: Date;
  medulaBransKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdatePersonelYandalDto extends CreatePersonelYandalDto {
  id: string;
}

export interface PersonelYandalListFilter extends BaseListFilter {
  personelYandalKodu?: string;
  referansTabloAdi?: string;
  personelKodu?: string;
  medulaBransKodu?: string;
  ekleyenKullaniciKodu?: string;
}

export const newPersonelYandal: CreatePersonelYandalDto = {
  personelYandalKodu: '',
  referansTabloAdi: '',
  personelKodu: '',
  yandalBaslangicTarihi: undefined,
  yandalBitisTarihi: undefined,
  medulaBransKodu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
