// HastaNotlari Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface HastaNotlariDto extends VemBaseDto {
  hastaNotlariKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  hastaNotTuru: string;
  personelKodu: string;
  hastaNotAciklamasi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListHastaNotlariDto {
  id: string;
  hastaNotlariKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  hastaNotTuru: string;
  personelKodu: string;
  hastaNotAciklamasi: string;
  ekleyenKullaniciKodu?: string;
}

export interface CreateHastaNotlariDto {
  hastaNotlariKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  hastaNotTuru: string;
  personelKodu: string;
  hastaNotAciklamasi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateHastaNotlariDto extends CreateHastaNotlariDto {
  id: string;
}

export interface HastaNotlariListFilter extends BaseListFilter {
  hastaNotlariKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  hastaNotTuru?: string;
}

export const newHastaNotlari: CreateHastaNotlariDto = {
  hastaNotlariKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  hastaNotTuru: '',
  personelKodu: '',
  hastaNotAciklamasi: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
