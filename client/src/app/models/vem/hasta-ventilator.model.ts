// HastaVentilator Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface HastaVentilatorDto extends VemBaseDto {
  hastaVentilatorKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  ventilatorCihazKodu: string;
  yogunBakimSeviyeBilgisi: string;
  ventilatorBaglamaZamani?: Date;
  ventilatorAyrilmaZamani: Date;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListHastaVentilatorDto {
  id: string;
  hastaVentilatorKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  ventilatorCihazKodu: string;
  yogunBakimSeviyeBilgisi: string;
  ventilatorBaglamaZamani?: Date;
  ventilatorAyrilmaZamani: Date;
}

export interface CreateHastaVentilatorDto {
  hastaVentilatorKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  ventilatorCihazKodu: string;
  yogunBakimSeviyeBilgisi: string;
  ventilatorBaglamaZamani?: Date;
  ventilatorAyrilmaZamani: Date;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateHastaVentilatorDto extends CreateHastaVentilatorDto {
  id: string;
}

export interface HastaVentilatorListFilter extends BaseListFilter {
  hastaVentilatorKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  ventilatorCihazKodu?: string;
}

export const newHastaVentilator: CreateHastaVentilatorDto = {
  hastaVentilatorKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  ventilatorCihazKodu: '',
  yogunBakimSeviyeBilgisi: '',
  ventilatorBaglamaZamani: undefined,
  ventilatorAyrilmaZamani: undefined,
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
