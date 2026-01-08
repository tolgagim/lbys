// TetkikCihazEslesme Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface TetkikCihazEslesmeDto extends VemBaseDto {
  tetkikCihazEslesmeKodu: string;
  referansTabloAdi: string;
  cihazKodu: string;
  tetkikKodu: string;
  tetkikParametreKodu: string;
  cihazdanGelenTestKodu: string;
  cihazaGidenTestKodu: string;
  iptalDurumu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListTetkikCihazEslesmeDto {
  id: string;
  tetkikCihazEslesmeKodu: string;
  referansTabloAdi: string;
  cihazKodu: string;
  tetkikKodu: string;
  tetkikParametreKodu: string;
  cihazdanGelenTestKodu: string;
  cihazaGidenTestKodu: string;
  iptalDurumu: string;
}

export interface CreateTetkikCihazEslesmeDto {
  tetkikCihazEslesmeKodu: string;
  referansTabloAdi: string;
  cihazKodu: string;
  tetkikKodu: string;
  tetkikParametreKodu: string;
  cihazdanGelenTestKodu: string;
  cihazaGidenTestKodu: string;
  iptalDurumu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateTetkikCihazEslesmeDto extends CreateTetkikCihazEslesmeDto {
  id: string;
}

export interface TetkikCihazEslesmeListFilter extends BaseListFilter {
  tetkikCihazEslesmeKodu?: string;
  referansTabloAdi?: string;
  cihazKodu?: string;
  tetkikKodu?: string;
  tetkikParametreKodu?: string;
}

export const newTetkikCihazEslesme: CreateTetkikCihazEslesmeDto = {
  tetkikCihazEslesmeKodu: '',
  referansTabloAdi: '',
  cihazKodu: '',
  tetkikKodu: '',
  tetkikParametreKodu: '',
  cihazdanGelenTestKodu: '',
  cihazaGidenTestKodu: '',
  iptalDurumu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
