// Depo Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface DepoDto extends VemBaseDto {
  depoKodu: string;
  depoAdi?: string;
  depoTuru?: string;
  binaKodu?: string;
  mkysKodu?: string;
  mkysKullaniciKodu?: string;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListDepoDto {
  id: string;
  depoKodu: string;
  depoAdi?: string;
  depoTuru?: string;
  binaKodu?: string;
  mkysKodu?: string;
  mkysKullaniciKodu?: string;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
}

export interface CreateDepoDto {
  depoKodu: string;
  depoAdi?: string;
  depoTuru?: string;
  binaKodu?: string;
  mkysKodu?: string;
  mkysKullaniciKodu?: string;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateDepoDto extends CreateDepoDto {
  id: string;
}

export interface DepoListFilter extends BaseListFilter {
  depoKodu?: string;
  depoAdi?: string;
  depoTuru?: string;
  binaKodu?: string;
  mkysKodu?: string;
  AKTIFLIK_BILGISI?: string | null;
  MKYS_KULLANICI_SIFRESI?: string | null;
}

export const newDepo: CreateDepoDto = {
  depoKodu: '',
  depoAdi: '',
  depoTuru: '',
  binaKodu: '',
  mkysKodu: '',
  mkysKullaniciKodu: '',
  aktif: false,
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
