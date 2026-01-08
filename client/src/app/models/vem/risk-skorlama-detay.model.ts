// RiskSkorlamaDetay Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface RiskSkorlamaDetayDto extends VemBaseDto {
  riskSkorlamaDetayKodu: string;
  referansTabloAdi: string;
  riskSkorlamaKodu: string;
  glasgowSkalasi: string;
  riskSkorlamaAltTuru: string;
  riskSkorDegeri: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListRiskSkorlamaDetayDto {
  id: string;
  riskSkorlamaDetayKodu: string;
  referansTabloAdi: string;
  riskSkorlamaKodu: string;
  glasgowSkalasi: string;
  riskSkorlamaAltTuru: string;
  riskSkorDegeri: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
}

export interface CreateRiskSkorlamaDetayDto {
  riskSkorlamaDetayKodu: string;
  referansTabloAdi: string;
  riskSkorlamaKodu: string;
  glasgowSkalasi: string;
  riskSkorlamaAltTuru: string;
  riskSkorDegeri: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateRiskSkorlamaDetayDto extends CreateRiskSkorlamaDetayDto {
  id: string;
}

export interface RiskSkorlamaDetayListFilter extends BaseListFilter {
  riskSkorlamaDetayKodu?: string;
  referansTabloAdi?: string;
  riskSkorlamaKodu?: string;
  glasgowSkalasi?: string;
  riskSkorlamaAltTuru?: string;
}

export const newRiskSkorlamaDetay: CreateRiskSkorlamaDetayDto = {
  riskSkorlamaDetayKodu: '',
  referansTabloAdi: '',
  riskSkorlamaKodu: '',
  glasgowSkalasi: '',
  riskSkorlamaAltTuru: '',
  riskSkorDegeri: '',
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
