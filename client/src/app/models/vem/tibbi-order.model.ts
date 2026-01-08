// TibbiOrder Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface TibbiOrderDto extends VemBaseDto {
  tibbiOrderKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  tibbiOrderTuru: string;
  orderZamani?: Date;
  hekimKodu: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListTibbiOrderDto {
  id: string;
  tibbiOrderKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  tibbiOrderTuru: string;
  orderZamani?: Date;
  hekimKodu: string;
  aciklama: string;
}

export interface CreateTibbiOrderDto {
  tibbiOrderKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  tibbiOrderTuru: string;
  orderZamani?: Date;
  hekimKodu: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateTibbiOrderDto extends CreateTibbiOrderDto {
  id: string;
}

export interface TibbiOrderListFilter extends BaseListFilter {
  tibbiOrderKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  tibbiOrderTuru?: string;
}

export const newTibbiOrder: CreateTibbiOrderDto = {
  tibbiOrderKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  tibbiOrderTuru: '',
  orderZamani: undefined,
  hekimKodu: '',
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
