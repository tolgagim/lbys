// Oda Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface OdaDto extends VemBaseDto {
  odaKodu: string;
  odaAdi?: string;
  birimKodu?: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListOdaDto {
  id: string;
  odaKodu: string;
  odaAdi?: string;
  birimKodu?: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface CreateOdaDto {
  odaKodu: string;
  odaAdi?: string;
  birimKodu?: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateOdaDto extends CreateOdaDto {
  id: string;
}

export interface OdaListFilter extends BaseListFilter {
  odaKodu?: string;
  odaAdi?: string;
  birimKodu?: string;
  ekleyenKullaniciKodu?: string;
  guncelleyenKullaniciKodu?: string;
}

export const newOda: CreateOdaDto = {
  odaKodu: '',
  odaAdi: '',
  birimKodu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
