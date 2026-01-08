// Cihaz Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface CihazDto extends VemBaseDto {
  cihazKodu: string;
  cihazAdi?: string;
  cihazGrubu?: string;
  birimKodu?: string;
  cihazModeli?: string;
  cihazMarkasi?: string;
  seriNumarasi?: string;
  mkysKunyeNumarasi?: string;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListCihazDto {
  id: string;
  cihazKodu: string;
  cihazAdi?: string;
  cihazGrubu?: string;
  birimKodu?: string;
  cihazModeli?: string;
  cihazMarkasi?: string;
  seriNumarasi?: string;
  mkysKunyeNumarasi?: string;
}

export interface CreateCihazDto {
  cihazKodu: string;
  cihazAdi?: string;
  cihazGrubu?: string;
  birimKodu?: string;
  cihazModeli?: string;
  cihazMarkasi?: string;
  seriNumarasi?: string;
  mkysKunyeNumarasi?: string;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateCihazDto extends CreateCihazDto {
  id: string;
}

export interface CihazListFilter extends BaseListFilter {
  cihazKodu?: string;
  cihazAdi?: string;
  cihazGrubu?: string;
  birimKodu?: string;
  cihazModeli?: string;
}

export const newCihaz: CreateCihazDto = {
  cihazKodu: '',
  cihazAdi: '',
  cihazGrubu: '',
  birimKodu: '',
  cihazModeli: '',
  cihazMarkasi: '',
  seriNumarasi: '',
  mkysKunyeNumarasi: '',
  aktif: false,
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
