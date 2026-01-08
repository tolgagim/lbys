// SterilizasyonCikis Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface SterilizasyonCikisDto extends VemBaseDto {
  sterilizasyonCikisKodu: string;
  referansTabloAdi: string;
  depoKodu: string;
  sterilizasyonSetKodu: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  sterilizasyonCikisMiktari: string;
  sterilizasyonCikisZamani?: Date;
  cikisYapilanBirimKodu: string;
  teslimEdenPersonelKodu: string;
  teslimAlanPersonelKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListSterilizasyonCikisDto {
  id: string;
  sterilizasyonCikisKodu: string;
  referansTabloAdi: string;
  depoKodu: string;
  sterilizasyonSetKodu: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  sterilizasyonCikisMiktari: string;
  sterilizasyonCikisZamani?: Date;
}

export interface CreateSterilizasyonCikisDto {
  sterilizasyonCikisKodu: string;
  referansTabloAdi: string;
  depoKodu: string;
  sterilizasyonSetKodu: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  sterilizasyonCikisMiktari: string;
  sterilizasyonCikisZamani?: Date;
  cikisYapilanBirimKodu: string;
  teslimEdenPersonelKodu: string;
  teslimAlanPersonelKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateSterilizasyonCikisDto extends CreateSterilizasyonCikisDto {
  id: string;
}

export interface SterilizasyonCikisListFilter extends BaseListFilter {
  sterilizasyonCikisKodu?: string;
  referansTabloAdi?: string;
  depoKodu?: string;
  sterilizasyonSetKodu?: string;
  hastaKodu?: string;
}

export const newSterilizasyonCikis: CreateSterilizasyonCikisDto = {
  sterilizasyonCikisKodu: '',
  referansTabloAdi: '',
  depoKodu: '',
  sterilizasyonSetKodu: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  sterilizasyonCikisMiktari: '',
  sterilizasyonCikisZamani: undefined,
  cikisYapilanBirimKodu: '',
  teslimEdenPersonelKodu: '',
  teslimAlanPersonelKodu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
