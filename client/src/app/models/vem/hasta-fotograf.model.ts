// HastaFotograf Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface HastaFotografDto extends VemBaseDto {
  hastaFotografKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  fotografTuru: string;
  fotografBilgisi: string;
  fotografDosyaYolu: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListHastaFotografDto {
  id: string;
  hastaFotografKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  fotografTuru: string;
  fotografBilgisi: string;
  fotografDosyaYolu: string;
  aciklama: string;
}

export interface CreateHastaFotografDto {
  hastaFotografKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  fotografTuru: string;
  fotografBilgisi: string;
  fotografDosyaYolu: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateHastaFotografDto extends CreateHastaFotografDto {
  id: string;
}

export interface HastaFotografListFilter extends BaseListFilter {
  hastaFotografKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  fotografTuru?: string;
}

export const newHastaFotograf: CreateHastaFotografDto = {
  hastaFotografKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  fotografTuru: '',
  fotografBilgisi: '',
  fotografDosyaYolu: '',
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
