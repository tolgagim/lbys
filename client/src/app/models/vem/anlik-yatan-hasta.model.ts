// AnlikYatanHasta Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface AnlikYatanHastaDto extends VemBaseDto {
  anlikYatanHastaKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  hekimKodu: string;
  yatisProtokolNumarasi: string;
  birimKodu: string;
  yatakKodu: string;
  odaKodu: string;
  yatisZamani?: Date;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListAnlikYatanHastaDto {
  id: string;
  anlikYatanHastaKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  hekimKodu: string;
  yatisProtokolNumarasi: string;
  birimKodu: string;
  yatakKodu: string;
}

export interface CreateAnlikYatanHastaDto {
  anlikYatanHastaKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  hekimKodu: string;
  yatisProtokolNumarasi: string;
  birimKodu: string;
  yatakKodu: string;
  odaKodu: string;
  yatisZamani?: Date;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateAnlikYatanHastaDto extends CreateAnlikYatanHastaDto {
  id: string;
}

export interface AnlikYatanHastaListFilter extends BaseListFilter {
  anlikYatanHastaKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  hekimKodu?: string;
}

export const newAnlikYatanHasta: CreateAnlikYatanHastaDto = {
  anlikYatanHastaKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  hekimKodu: '',
  yatisProtokolNumarasi: '',
  birimKodu: '',
  yatakKodu: '',
  odaKodu: '',
  yatisZamani: undefined,
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
