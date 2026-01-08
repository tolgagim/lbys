// RiskSkorlama Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface RiskSkorlamaDto extends VemBaseDto {
  riskSkorlamaKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hastaKodu: string;
  riskSkorlamaTuru: string;
  islemZamani?: Date;
  riskSkorlamaToplamPuani: string;
  beklenenOlumOrani: string;
  glasgowSkalasi: string;
  duzeltilmisbeklenenOlumOrani: string;
  tibbiOrderDetayKodu: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListRiskSkorlamaDto {
  id: string;
  riskSkorlamaKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hastaKodu: string;
  riskSkorlamaTuru: string;
  islemZamani?: Date;
  riskSkorlamaToplamPuani: string;
  beklenenOlumOrani: string;
}

export interface CreateRiskSkorlamaDto {
  riskSkorlamaKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hastaKodu: string;
  riskSkorlamaTuru: string;
  islemZamani?: Date;
  riskSkorlamaToplamPuani: string;
  beklenenOlumOrani: string;
  glasgowSkalasi: string;
  duzeltilmisbeklenenOlumOrani: string;
  tibbiOrderDetayKodu: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateRiskSkorlamaDto extends CreateRiskSkorlamaDto {
  id: string;
}

export interface RiskSkorlamaListFilter extends BaseListFilter {
  riskSkorlamaKodu?: string;
  referansTabloAdi?: string;
  hastaBasvuruKodu?: string;
  hastaKodu?: string;
  riskSkorlamaTuru?: string;
}

export const newRiskSkorlama: CreateRiskSkorlamaDto = {
  riskSkorlamaKodu: '',
  referansTabloAdi: '',
  hastaBasvuruKodu: '',
  hastaKodu: '',
  riskSkorlamaTuru: '',
  islemZamani: undefined,
  riskSkorlamaToplamPuani: '',
  beklenenOlumOrani: '',
  glasgowSkalasi: '',
  duzeltilmisbeklenenOlumOrani: '',
  tibbiOrderDetayKodu: '',
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
